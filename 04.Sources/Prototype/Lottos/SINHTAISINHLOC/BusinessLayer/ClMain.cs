// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.ClMain
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Thống_kê_xổ_số.FormUI;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.BusinessLayer
{
  internal class ClMain
  {
    public static string _strConData = "";
    public static string _strConUser = "";
    public static string _strkey = "";
    public const int WM_NCLBUTTONDOWN = 161;
    public const int HT_CAPTION = 2;
    public static ArrayList arrMsg;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    public static DateTime timeHientai { get; set; }

    public static void SendMailNapTien(string noidung, string emmailNhan, string tennguoinhan)
    {
      MailAddress from = new MailAddress("baydac89@gmail.com", "SINH TÀI SINH LỘC");
      MailAddress to = new MailAddress(emmailNhan, tennguoinhan);
      string str = noidung;
      using (MailMessage message = new MailMessage(from, to)
      {
        Subject = "NẠP TIỀN THÀNH CÔNG",
        Body = str
      })
        new SmtpClient()
        {
          Host = "smtp.gmail.com",
          Port = 587,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          UseDefaultCredentials = false,
          Credentials = ((ICredentialsByHost) new NetworkCredential(from.Address, "geoqzhmooyzxwecy"))
        }.Send(message);
    }

    public static string[] Get_Msg(string maLoi)
    {
      string[] strArray = new string[0];
      foreach (string str in ClMain.arrMsg)
      {
        strArray = str.Split(';');
        if (!(strArray[0] == maLoi))
          strArray = "999;LỖI XỦ LÝ;THÔNG BÁO".Split(';');
        else
          break;
      }
      return strArray;
    }

    public static void tune_Thongbao(string fileName)
    {
      SoundPlayer soundPlayer = new SoundPlayer();
      try
      {
        soundPlayer.SoundLocation = Directory.GetCurrentDirectory() + "\\sound\\" + fileName ?? "";
        soundPlayer.Play();
      }
      catch
      {
      }
    }

    public void Load_Data_Msg()
    {
      if (ClMain.ReadFile("/msg.txt"))
        return;
      int num = (int) MessageBox.Show(Resources.ClMain_Load_Data_Msg_KHÔNG_THỂ_KHỞI_ĐỘNG_PHẦN_MỀM, Resources.ClMain_Load_Data_Msg_LỖI_NGHIÊM_TRỌNG, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      Environment.Exit(0);
    }

    public static bool ReadFile(string strPath)
    {
      ClMain.arrMsg = new ArrayList();
      try
      {
        StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + strPath);
        for (string str = streamReader.ReadLine(); str != null; str = streamReader.ReadLine())
          ClMain.arrMsg.Add((object) str);
        streamReader.Close();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static string Encrypt(string strToEncrypt, string strKey)
    {
      try
      {
        TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
        byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(strKey));
        cryptoServiceProvider.Key = hash;
        cryptoServiceProvider.Mode = CipherMode.ECB;
        byte[] bytes = Encoding.Unicode.GetBytes(strToEncrypt);
        return Convert.ToBase64String(cryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
      }
      catch
      {
        return "0";
      }
    }

    public static string Decrypt(string strEncrypted, string strKey)
    {
      try
      {
        TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
        byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(strKey));
        cryptoServiceProvider.Key = hash;
        cryptoServiceProvider.Mode = CipherMode.ECB;
        byte[] inputBuffer = Convert.FromBase64String(strEncrypted);
        return Encoding.Unicode.GetString(cryptoServiceProvider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
      }
      catch
      {
        return "0";
      }
    }

    public static Image CropToCircle(Image srcImage, Color backGround)
    {
      Image image = (Image) new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
      Graphics graphics = Graphics.FromImage(image);
      using (Brush brush = (Brush) new SolidBrush(backGround))
        graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
      GraphicsPath path = new GraphicsPath();
      path.AddEllipse(0, 0, image.Width, image.Height);
      graphics.SetClip(path);
      graphics.DrawImage(srcImage, 0, 0);
      return image;
    }

    public static DataTable getTime_Server_CheckConnection()
    {
      DataTable dataTable = new DataTable();
      string sql = "select GETDATE()";
      try
      {
        dataTable = new DataTable();
        dataTable = DataWeb.db.GetData(sql);
        if (dataTable.Rows.Count > 0)
          return dataTable;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return dataTable;
    }

    public static string chuyenDoiVang_Xu(Decimal score)
    {
      string str = score.ToString();
      if (score > new Decimal(100000000))
        str = (score / new Decimal(1000000000)).ToString("#,#0.0") + "B";
      else if (score > new Decimal(100000))
        str = (score / new Decimal(1000000)).ToString("#,#0.0") + "M";
      else if (score > new Decimal(100))
        str = (score / new Decimal(1000)).ToString("#,#0.0") + "K";
      return str;
    }

    public static bool SendEmail(string eMailTo, string tilte, string message, string emailSend, string passSend, string host, int port)
    {
      try
      {
        new SmtpClient()
        {
          Host = host,
          Port = port,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          Credentials = ((ICredentialsByHost) new NetworkCredential(emailSend, passSend)),
          Timeout = 10000
        }.Send(new MailMessage(emailSend, eMailTo, tilte, message));
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public static string QuiDoiSoLuong(string soLuong, string donVi)
    {
      try
      {
        return Convert.ToDecimal(soLuong).ToString("##,#0") + " " + donVi;
      }
      catch (Exception ex)
      {
        return "0.0 " + donVi;
      }
    }

    public static string ImgHtml(byte[] hinhanh)
    {
      return "data:image;base64," + Convert.ToBase64String(hinhanh);
    }

    public static bool IsNumber(string number)
    {
      try
      {
        Decimal.Parse(number);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public static string CatChuoi_DaiQua(string chuoi, int doDaiMongmuon)
    {
      if (chuoi.Length > doDaiMongmuon)
        return "####";
      return chuoi;
    }

    public static string check_Loto_Cap(string loto)
    {
      string str;
      switch (loto)
      {
        case "00":
          str = "55";
          break;
        case "11":
          str = "66";
          break;
        case "22":
          str = "77";
          break;
        case "33":
          str = "88";
          break;
        case "44":
          str = "99";
          break;
        case "55":
          str = "00";
          break;
        case "66":
          str = "11";
          break;
        case "77":
          str = "22";
          break;
        case "88":
          str = "33";
          break;
        case "99":
          str = "44";
          break;
        default:
          str = loto.Substring(1, 1) + loto.Substring(0, 1);
          break;
      }
      return str;
    }

    public class AddValue
    {
      private string m_Display;
      private string m_Value;

      public AddValue(string display, string value)
      {
        this.m_Display = display;
        this.m_Value = value;
      }

      public string Display
      {
        get
        {
          return this.m_Display;
        }
      }

      public string Value
      {
        get
        {
          return this.m_Value;
        }
      }
    }

    public class ComboboxItem
    {
      public string Text { get; set; }

      public object Value { get; set; }

      public override string ToString()
      {
        return this.Text;
      }
    }
  }
}
