// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbUser
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using Thống_kê_xổ_số.FormUI;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TbUser
  {
    private readonly Regex _sUserNameAllowedRegEx = new Regex("^(?=.{6,25}$)([A-Za-z0-9][._()\\[\\]-]?)*$", RegexOptions.Compiled);
    private readonly Regex _sEmailAllowedRegEx = new Regex("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.Compiled);
    private readonly Regex _sPassAllowedRegEx = new Regex("^(?=.*?[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]).{6,20}$", RegexOptions.Compiled);
    private readonly Regex _sMobileAllowedRegEx = new Regex("^\\d+$", RegexOptions.Compiled);
    public static TbUser Tbuser;
    public string Hovaten;
    public DateTime Ngaysinh;
    private SqlCommand cmd;
    private DataTable _dtTable;

    public int Stt { get; set; }

    public string TenDangnhap { get; set; }

    public string MatKhau { get; set; }

    public string MatKhauTam { get; set; }

    public string SoDienthoai { get; set; }

    public string Email { get; set; }

    public int TrangThaiKickHoat { get; set; }

    public DateTime NgayDangki { get; set; }

    public string PhanQuyen { get; set; }

    public string TrangthaiSudung { get; set; }

    public string IDC { get; set; }

    public byte[] ImgMessage { get; set; }

    public bool IsUserNameAllowed(string userName)
    {
      return !(userName == "Tên đăng nhập") && !string.IsNullOrEmpty(userName) && this._sUserNameAllowedRegEx.IsMatch(userName);
    }

    public bool IsEmailAllowed(string email)
    {
      return !(email == "Địa chỉ Email") && !string.IsNullOrEmpty(email) && this._sEmailAllowedRegEx.IsMatch(email) && this.CheckEmail(email);
    }

    public bool IsPassWordAllowed(string password)
    {
      return !(password == "************") && !string.IsNullOrEmpty(password) && this._sPassAllowedRegEx.IsMatch(password) && !(password == "Mật khẩu cũ của bạn");
    }

    public bool IsMobileAllowed(string mobile)
    {
      return !(mobile == "Số điện thoại") && !string.IsNullOrEmpty(mobile) && (this._sMobileAllowedRegEx.IsMatch(mobile) && mobile.Length >= 6) && mobile.Length <= 13;
    }

    public static byte[] ImageToByteArray(Image imageIn)
    {
      MemoryStream memoryStream = new MemoryStream();
      imageIn.Save((Stream) memoryStream, ImageFormat.Jpeg);
      return memoryStream.ToArray();
    }

    public static Image ByteArrayToImage(byte[] byteArrayIn)
    {
      return Image.FromStream((Stream) new MemoryStream(byteArrayIn));
    }

    public bool CheckUsername(string tenDangnhap)
    {
      bool flag = false;
      this._dtTable = new DataTable();
      string sql = "Select * From tbUser Where tenDangnhap ='" + tenDangnhap + "' ";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count <= 0)
          flag = true;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return flag;
    }

    public bool UpdateIDC(string username, string idc)
    {
      bool flag = false;
      string cmdText = "TBUser_Update_IDC";
      try
      {
        this._dtTable = new DataTable();
        this.cmd = new SqlCommand("select IDC from TbUser where tenDangnhap=N'" + username + "' or email=N'" + username + "'");
        this.cmd.CommandType = CommandType.Text;
        this._dtTable = DataWeb.db.GetData(this.cmd);
        if (this._dtTable.Rows.Count > 0)
        {
          if (string.IsNullOrEmpty(this._dtTable.Rows[0][0].ToString()))
          {
            this.cmd = new SqlCommand(cmdText);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@userName", (object) username);
            this.cmd.Parameters.AddWithValue("@IDC", (object) idc);
            DataWeb.db.ExecuteNonQuery(this.cmd);
            flag = true;
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
      return flag;
    }

    public DataTable GetImageByUsername(string tenDangnhap)
    {
      string sql = string.Format("tbUser_Get_Image_By_Username N'{0}'", (object) tenDangnhap);
      this._dtTable = new DataTable();
      this._dtTable = DataWeb.db.GetData(sql);
      return this._dtTable;
    }

    public bool CheckIDC(string idc)
    {
      bool flag = false;
      this._dtTable = new DataTable();
      string cmdText = "TBUser_CheckIDC";
      try
      {
        this.cmd = new SqlCommand(cmdText);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.cmd.Parameters.AddWithValue("@IDC", (object) idc);
        this._dtTable = DataWeb.db.GetData(this.cmd);
        if (this._dtTable.Rows.Count > 1)
          flag = true;
      }
      catch (Exception ex)
      {
        throw;
      }
      return flag;
    }

    public bool CheckEmail(string emailCheck)
    {
      bool flag = false;
      if (this.Email != emailCheck)
      {
        this._dtTable = new DataTable();
        string sql = "Select * From tbUser Where email ='" + emailCheck + "' ";
        try
        {
          this._dtTable = new DataTable();
          this._dtTable = DataWeb.db.GetData(sql);
          if (this._dtTable.Rows.Count <= 0)
            flag = true;
        }
        catch
        {
          FLogin.MsgId = "009";
          FLogin.LogOutStatus = "1";
        }
      }
      else
        flag = true;
      return flag;
    }

    public bool CheckNguoiGioiThieu(string txtNguoiGioiThieu)
    {
      bool flag = false;
      string sql = "Select stt From tbUser Where email ='" + txtNguoiGioiThieu + "' or tenDangnhap='" + txtNguoiGioiThieu + "'";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
          flag = true;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return flag;
    }

    public bool GetInforUser(string tenDangnhap, string matKhau)
    {
      bool flag = false;
      string sql = string.Format("tbUser_getby_Username_Pass N'{0}',N'{1}'", (object) tenDangnhap, (object) matKhau);
      try
      {
        TbUser tbUser = new TbUser();
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbUser.Stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            this.Stt = 0;
          }
          tbUser.TenDangnhap = this._dtTable.Rows[0][nameof (tenDangnhap)].ToString();
          tbUser.MatKhau = this._dtTable.Rows[0][nameof (matKhau)].ToString();
          tbUser.MatKhauTam = this._dtTable.Rows[0]["matKhauTam"].ToString();
          tbUser.Email = this._dtTable.Rows[0]["email"].ToString();
          tbUser.TrangThaiKickHoat = this._dtTable.Rows[0]["trangThaiKickHoat"].ToString() == "True" ? 1 : 0;
          try
          {
            tbUser.NgayDangki = DateTime.Parse(this._dtTable.Rows[0]["ngayDangki"].ToString());
          }
          catch (FormatException ex)
          {
            tbUser.NgayDangki = DateTime.Now;
          }
          tbUser.PhanQuyen = this._dtTable.Rows[0]["phanQuyen"].ToString();
          tbUser.TrangthaiSudung = this._dtTable.Rows[0]["trangthaiSudung"].ToString();
          tbUser.IDC = this._dtTable.Rows[0]["IDC"].ToString();
          TbUser.Tbuser = tbUser;
          flag = true;
        }
      }
      catch
      {
        throw;
      }
      return flag;
    }

    public bool GetInforUser_IDC(string tenDangnhap, string matKhau, string idc)
    {
      bool flag = false;
      string cmdText = "TBUser_GET_By_Username_Password_IDC";
      try
      {
        TbUser tbUser = new TbUser();
        this._dtTable = new DataTable();
        this.cmd = new SqlCommand(cmdText);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.cmd.Parameters.AddWithValue("@tenDangnhap", (object) tenDangnhap);
        this.cmd.Parameters.AddWithValue("@matKhau", (object) matKhau);
        this.cmd.Parameters.AddWithValue("@IDC", (object) idc);
        this._dtTable = DataWeb.db.GetData(this.cmd);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbUser.Stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            this.Stt = 0;
          }
          tbUser.TenDangnhap = this._dtTable.Rows[0][nameof (tenDangnhap)].ToString();
          tbUser.MatKhau = this._dtTable.Rows[0][nameof (matKhau)].ToString();
          tbUser.MatKhauTam = this._dtTable.Rows[0]["matKhauTam"].ToString();
          tbUser.Email = this._dtTable.Rows[0]["email"].ToString();
          tbUser.TrangThaiKickHoat = this._dtTable.Rows[0]["trangThaiKickHoat"].ToString() == "True" ? 1 : 0;
          try
          {
            tbUser.NgayDangki = DateTime.Parse(this._dtTable.Rows[0]["ngayDangki"].ToString());
          }
          catch (FormatException ex)
          {
            tbUser.NgayDangki = DateTime.Now;
          }
          tbUser.PhanQuyen = this._dtTable.Rows[0]["phanQuyen"].ToString();
          tbUser.TrangthaiSudung = this._dtTable.Rows[0]["trangthaiSudung"].ToString();
          TbUser.Tbuser = tbUser;
          flag = true;
        }
      }
      catch
      {
        throw;
      }
      return flag;
    }

    public bool GetInforUserUsername(string tenDangnhap)
    {
      bool flag = false;
      string sql = "select stt,hovaten,ngaysinh,tenDangnhap,matKhau,matKhauTam,soDienthoai,email,trangThaiKickHoat,phanQuyen,trangthaiSudung,ngayDangki,IDC from tbUser where tenDangnhap = '" + tenDangnhap + "'";
      TbUser tbUser = new TbUser();
      this._dtTable = new DataTable();
      this._dtTable = DataWeb.db.GetData(sql);
      if (this._dtTable.Rows.Count > 0)
      {
        try
        {
          tbUser.Stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
        }
        catch (FormatException ex)
        {
          tbUser.Stt = 0;
        }
        tbUser.Hovaten = this._dtTable.Rows[0]["hovaten"].ToString();
        try
        {
          tbUser.Ngaysinh = DateTime.Parse(this._dtTable.Rows[0]["ngaysinh"].ToString());
        }
        catch (FormatException ex)
        {
          tbUser.Ngaysinh = DateTime.Now;
        }
        tbUser.TenDangnhap = this._dtTable.Rows[0][nameof (tenDangnhap)].ToString();
        tbUser.MatKhau = this._dtTable.Rows[0]["matKhau"].ToString();
        tbUser.MatKhauTam = this._dtTable.Rows[0]["matKhauTam"].ToString();
        tbUser.SoDienthoai = this._dtTable.Rows[0]["soDienthoai"].ToString();
        tbUser.Email = this._dtTable.Rows[0]["email"].ToString();
        tbUser.TrangThaiKickHoat = this._dtTable.Rows[0]["trangThaiKickHoat"].ToString() == "True" ? 1 : 0;
        try
        {
          tbUser.NgayDangki = DateTime.Parse(this._dtTable.Rows[0]["ngayDangki"].ToString());
        }
        catch (FormatException ex)
        {
        }
        tbUser.PhanQuyen = this._dtTable.Rows[0]["phanQuyen"].ToString();
        tbUser.TrangthaiSudung = this._dtTable.Rows[0]["trangthaiSudung"].ToString();
        tbUser.IDC = this._dtTable.Rows[0]["IDC"].ToString();
        TbUser.Tbuser = tbUser;
        flag = true;
      }
      return flag;
    }

    public int Insert(TbUser obj)
    {
      int num = 0;
      obj.TrangThaiKickHoat = 1;
      obj.Hovaten = "Chưa cập nhật";
      obj.NgayDangki = DateTime.Now;
      obj.Ngaysinh = DateTime.Now;
      obj.PhanQuyen = "user";
      obj.TrangthaiSudung = "sudung";
      obj.SoDienthoai = "Chưa cập nhật";
      obj.IDC = FLogin.IDC;
      try
      {
        SqlCommand cmd = new SqlCommand("tbUser_Insert");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@hovaten", (object) obj.Hovaten);
        cmd.Parameters.Add("@ngaysinh", (object) obj.Ngaysinh.ToString("yyyy-MM-dd hh:mm:ss"));
        cmd.Parameters.Add("@tenDangnhap", (object) obj.TenDangnhap);
        cmd.Parameters.Add("@matKhau", (object) obj.MatKhau);
        cmd.Parameters.Add("@matKhauTam", (object) obj.MatKhauTam);
        cmd.Parameters.Add("@soDienthoai", (object) obj.SoDienthoai);
        cmd.Parameters.Add("@email", (object) obj.Email);
        cmd.Parameters.Add("@trangThaiKickHoat", (object) obj.TrangThaiKickHoat);
        cmd.Parameters.Add("@phanQuyen", (object) obj.PhanQuyen);
        cmd.Parameters.Add("@trangthaiSudung", (object) obj.TrangthaiSudung);
        cmd.Parameters.Add("@IDC", (object) obj.IDC);
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public int SendPassTam(string email, string passTam)
    {
      string cmdText = string.Format("Update tbUser Set matKhauTam = N'" + ClMain.Encrypt(passTam, tbConfigApp.configApp.KeyUser) + "' Where email =N'" + email + "'");
      int num;
      try
      {
        SqlCommand sqlCommand = new SqlCommand(cmdText);
        sqlCommand.CommandType = CommandType.Text;
        SqlCommand cmd = sqlCommand;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        num = 1;
      }
      return num;
    }

    public int Update(TbUser objUser)
    {
      int num;
      try
      {
        SqlCommand cmd = new SqlCommand("tbUser_Update");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@hovaten", (object) this.Hovaten);
        cmd.Parameters.Add("@ngaysinh", (object) objUser.Ngaysinh.ToString("yyyy-MM-dd"));
        cmd.Parameters.Add("@tenDangnhap", (object) objUser.TenDangnhap);
        cmd.Parameters.Add("@matKhau", (object) objUser.MatKhau);
        cmd.Parameters.Add("@matKhauTam", (object) objUser.MatKhauTam);
        cmd.Parameters.Add("@soDienthoai", (object) objUser.SoDienthoai);
        cmd.Parameters.Add("@email", (object) objUser.Email);
        cmd.Parameters.Add("@trangThaiKickHoat", (object) objUser.TrangThaiKickHoat);
        cmd.Parameters.Add("@ngayDangki", (object) objUser.NgayDangki);
        cmd.Parameters.Add("@phanQuyen", (object) objUser.PhanQuyen);
        cmd.Parameters.Add("@trangthaiSudung", (object) objUser.TrangthaiSudung);
        cmd.Parameters.Add("@IDC", (object) this.IDC);
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        num = 0;
      }
      return num;
    }
  }
}
