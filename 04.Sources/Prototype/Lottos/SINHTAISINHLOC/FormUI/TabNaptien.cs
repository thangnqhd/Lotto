// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabNaptien
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using MobileCard;
using ns1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabNaptien : UserControl
  {
    private static readonly Encoding encoding = Encoding.UTF8;
    private IContainer components = (IContainer) null;
    public DataTable dtTable;
    private TBThanhToanNganHang obj;
    private TbQuidoiVangNgaySuDung objVangNgaysudung;
    private tbMoneyUSER objMoneyUser;
    private TBNhaMang objNhaMang;
    private TBNaptienhethong objNapTienHeThong;
    private TBManager objManager;
    private TBNapTienTheNap objNapTienTheNap;
    private string LoaiThe;
    private string MaThe;
    private string Seri;
    private string noidung;
    private string StatusCode;
    private BunifuElipse bunifuElipse1;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private Panel panel2;
    private Panel panel3;
    private ComboBox cbbLoaiThe;
    private Label label2;
    private TextBox txtSeri;
    private TextBox txtMaThe;
    private Label label4;
    private Label label3;
    private BunifuThinButton2 btnDangki;
    private Label label5;
    private BackgroundWorker backgroundWorkerSendMail;
    private PictureBox pictureBox1;

    public TabNaptien()
    {
      this.InitializeComponent();
      this.objNhaMang = new TBNhaMang();
      this.objMoneyUser = new tbMoneyUSER();
      this.objNapTienHeThong = new TBNaptienhethong();
      this.objNapTienTheNap = new TBNapTienTheNap();
      this.objManager = new TBManager();
      this.LoaiThe = "VIETEL";
      this.GetNhaMang();
    }

    private void GetNhaMang()
    {
      this.dtTable = this.objNhaMang.GetAll();
      if (this.dtTable.Rows.Count > 0)
        this.AddCombobox(this.dtTable, this.cbbLoaiThe);
      else
        Environment.Exit(1);
      this.cbbLoaiThe.SelectedIndex = 0;
    }

    private void AddCombobox(DataTable dt, ComboBox cbb)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) new ClMain.AddValue("------ CHỌN LOẠI THẺ NẠP ------", "0"));
      for (int index = 0; index < dt.Rows.Count; ++index)
      {
        string display = dt.Rows[index]["NhaMang"].ToString().Trim() + " ( Triết khấu của nhà mạng " + dt.Rows[index]["TrietKhau"].ToString().Trim() + "% )";
        string str = dt.Rows[index]["IDNhaMang"].ToString().Trim();
        arrayList.Add((object) new ClMain.AddValue(display, str));
      }
      cbb.DataSource = (object) arrayList;
      cbb.DisplayMember = "Display";
      cbb.ValueMember = "Value";
    }

    private void btnDangki_Click(object sender, EventArgs e)
    {
      if (this.cbbLoaiThe.SelectedIndex == 0)
      {
        int num = (int) MessageBox.Show("Vui lòng chọn loại thẻ bạn muốn nạp.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.cbbLoaiThe.Focus();
      }
      else if (this.txtMaThe.Text.Trim().Length < 1)
      {
        int num = (int) MessageBox.Show("Vui lòng nhập vào mã thẻ cào của bạn.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.txtMaThe.Focus();
      }
      else if (this.txtSeri.Text.Trim().Length < 1)
      {
        int num = (int) MessageBox.Show("Vui lòng nhập vào Seri thẻ cào của bạn.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.txtSeri.Focus();
      }
      else if (FMain.SoLanNapThe >= 5)
      {
        int num1 = (int) MessageBox.Show("Bạn đã nạp sai quá số lần cho phép. Vui lòng đợi!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.XuLyNapTheNganLuong(this.LoaiThe, this.MaThe, this.Seri);
    }

    private void XuLyNapTheNganLuong(string loaithe, string mathe, string seri)
    {
      ResponseInfo responseInfo = NLCardLib.CardChage(new RequestInfo()
      {
        Merchant_id = "54490",
        Merchant_acount = "dacbay290@gmail.com",
        Merchant_password = "4f46ec897331db7f540026b0677ca9cf",
        CardType = loaithe,
        Pincard = mathe,
        Refcode = new Random().Next(0, 10000).ToString(),
        SerialCard = seri
      });
      string str = "";
      string text;
      if (responseInfo.Errorcode.Equals("00"))
      {
        double num1 = 0.0;
        double num2 = 25.0;
        FMain.SoLanNapThe = 0;
        try
        {
          responseInfo.Card_amount = responseInfo.Card_amount;
          num1 = Convert.ToDouble(responseInfo.Card_amount);
        }
        catch
        {
          responseInfo.Card_amount = "10000";
        }
        for (int index = 0; index < this.dtTable.Rows.Count; ++index)
        {
          if (this.dtTable.Rows[index]["IDNhaMang"].ToString() == loaithe)
          {
            try
            {
              num2 = Convert.ToDouble(this.dtTable.Rows[index]["TrietKhau"].ToString().Trim());
              break;
            }
            catch (Exception ex)
            {
              num2 = 25.0;
              break;
            }
          }
        }
        double sovangnhanduoc = Convert.ToDouble(responseInfo.Card_amount);
        double num3 = sovangnhanduoc * ((100.0 - num2) / 100.0);
        if (this.InsertSoVangNhanDuoc(FMain.UserName, sovangnhanduoc))
        {
          this.InsertNapTienHeThong(this.LoaiThe, FMain.UserName, num3.ToString(), sovangnhanduoc.ToString());
          this.Insert_TBNapTienTheNap(responseInfo.Refcode, FMain.UserName, this.LoaiThe, this.MaThe, this.Seri, responseInfo.Card_amount, num2.ToString(), num3.ToString(), responseInfo.Card_amount);
          this.noidung = "[" + FMain.UserName + "] đã nạp thành công thẻ  " + this.LoaiThe + " mệnh giá " + TabNaptien.QuiDoiSoLuong(responseInfo.Card_amount, "VND") + " và nhận được " + TabNaptien.QuiDoiSoLuong(responseInfo.Card_amount.ToString(), "Vàng") + ".";
          if (!this.backgroundWorkerSendMail.IsBusy)
            this.backgroundWorkerSendMail.RunWorkerAsync();
          FMain.LoadLaiForm = 1;
          FMain.LoadLai_napTien = 1;
        }
        else
          Environment.Exit(0);
        this.txtMaThe.Text = "";
        this.txtSeri.Text = "";
        text = str + responseInfo.Message + "</div>" + "Số tiền nạp : <b>" + responseInfo.Card_amount + " VND\r\n" + "Mã giao dịch : <b>" + responseInfo.TransactionID + "\r\n" + "Mã đơn hàng : <b>" + responseInfo.Refcode + "\r\n";
      }
      else
        text = str + "Nạp thẻ không thành công." + (responseInfo.Message ?? "");
      int num = (int) MessageBox.Show(text, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void Insert_TBNapTienTheNap(string MaGiaoDich, string TenDangNhap, string NhaMang, string MaTheNap, string SeriTheNap, string MenhGia, string TrietKhau, string ThucNhan, string SoVangNhan)
    {
      try
      {
        this.objNapTienTheNap.Insert(MaGiaoDich, TenDangNhap, NhaMang, MaTheNap, SeriTheNap, MenhGia, TrietKhau, ThucNhan, SoVangNhan);
      }
      catch
      {
        Environment.Exit(0);
      }
    }

    private void SendMail(string noidung)
    {
      DataTable dataTable = new DataTable();
      DataTable all = this.objManager.GetAll();
      if (all.Rows.Count <= 0)
        return;
      for (int index = 0; index < all.Rows.Count; ++index)
      {
        string emmailNhan = all.Rows[index]["Email"].ToString();
        string tennguoinhan = all.Rows[index]["FullName"].ToString();
        ClMain.SendMailNapTien(noidung, emmailNhan, tennguoinhan);
      }
    }

    private bool InsertSoVangNhanDuoc(string username, double sovangnhanduoc)
    {
      bool flag = false;
      try
      {
        double num = (double) this.objMoneyUser.GetVangHienCoByUsername(username) + sovangnhanduoc;
        if (this.objMoneyUser.Update_VangHienCo(username, num.ToString()))
          flag = true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Lỗi cộng tiền vào tài khoản cho khách hàng. Hãy thực hiện thao tác này bằng tay và ghi nhớ số tiền nạp của khách hàng.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      return flag;
    }

    private bool InsertNapTienHeThong(string nhamang, string username, string sotienchuyen, string sovangnhan)
    {
      bool flag = false;
      try
      {
        this.objNapTienHeThong.NapTienHeThong(nhamang, username, sotienchuyen, sovangnhan, username, "True");
      }
      catch (Exception ex)
      {
        flag = false;
      }
      return flag;
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

    private static void AppendBytes(StringBuilder sb, List<byte> bytes)
    {
      if ((uint) bytes.Count <= 0U)
        return;
      string str = Encoding.UTF8.GetString(bytes.ToArray());
      sb.Append(str);
      bytes.Clear();
    }

    public static string Encode(string input, byte[] key)
    {
      byte[] bytes = Encoding.ASCII.GetBytes(input);
      using (HMACSHA1 hmacshA1 = new HMACSHA1(key))
        return ((IEnumerable<byte>) hmacshA1.ComputeHash(bytes)).Aggregate<byte, string, string>("", (Func<string, byte, string>) ((s, e) => s + string.Format("{0:x2}", (object) e)), (Func<string, string>) (s => s));
    }

    public string BuildQuery(Dictionary<string, string> param)
    {
      return param.Aggregate<KeyValuePair<string, string>, string>(string.Empty, (Func<string, KeyValuePair<string, string>, string>) ((current, item) => current + string.Format("{0}={1}&", (object) item.Key, (object) item.Value))).TrimEnd('&');
    }

    public string HttpWebRequestDigest(string url, string postData, string method, NetworkCredential credential = null)
    {
      try
      {
        string str = string.Empty;
        Uri uri = new Uri(url);
        using (HttpWebResponse response = new DigestHttpWebRequest(credential.UserName, credential.Password)
        {
          Method = method,
          ContentType = "application/x-www-form-urlencoded",
          PostData = Encoding.ASCII.GetBytes(postData)
        }.GetResponse(uri))
        {
          using (Stream responseStream = response.GetResponseStream())
          {
            if (responseStream != null)
            {
              using (StreamReader streamReader = new StreamReader(responseStream))
                str = streamReader.ReadToEnd();
            }
          }
        }
        return str;
      }
      catch (WebException ex)
      {
        if (ex.Response != null)
        {
          using (HttpWebResponse response = (HttpWebResponse) ex.Response)
          {
            using (Stream responseStream = response.GetResponseStream())
            {
              if (responseStream != null)
              {
                using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                  return streamReader.ReadToEnd();
              }
            }
          }
        }
        throw new WebException(string.Format("Exception in WebServiceCall: {0}", (object) ex.Message));
      }
      catch (Exception ex)
      {
        throw new Exception(string.Format("Exception in WebServiceCall: {0}", (object) ex.Message));
      }
    }

    private void cbbLoaiThe_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LoaiThe = this.cbbLoaiThe.SelectedValue.ToString();
    }

    private void txtMaThe_TextChanged(object sender, EventArgs e)
    {
      this.MaThe = this.txtMaThe.Text.Trim();
    }

    private void txtSeri_TextChanged(object sender, EventArgs e)
    {
      this.Seri = this.txtSeri.Text.Trim();
    }

    private void backgroundWorkerSendMail_DoWork(object sender, DoWorkEventArgs e)
    {
      this.SendMail(this.noidung);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabNaptien));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label1 = new Label();
      this.btnDangki = new BunifuThinButton2();
      this.txtSeri = new TextBox();
      this.txtMaThe = new TextBox();
      this.label4 = new Label();
      this.cbbLoaiThe = new ComboBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.panel3 = new Panel();
      this.label5 = new Label();
      this.backgroundWorkerSendMail = new BackgroundWorker();
      this.pictureBox1 = new PictureBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 1, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 55f));
      this.tableLayoutPanel1.Size = new Size(1147, 740);
      this.tableLayoutPanel1.TabIndex = 1;
      this.panel2.BackColor = Color.White;
      this.panel2.Controls.Add((Control) this.pictureBox1);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.btnDangki);
      this.panel2.Controls.Add((Control) this.txtSeri);
      this.panel2.Controls.Add((Control) this.txtMaThe);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.cbbLoaiThe);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(347, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(510, 327);
      this.panel2.TabIndex = 1;
      this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Red;
      this.label1.Location = new Point(55, 37);
      this.label1.Name = "label1";
      this.label1.Size = new Size(417, 24);
      this.label1.TabIndex = 0;
      this.label1.Text = "NẠP BẰNG THẺ ĐIỆN THOẠI - THẺ GAME";
      this.btnDangki.ActiveBorderThickness = 1;
      this.btnDangki.ActiveCornerRadius = 20;
      this.btnDangki.ActiveFillColor = Color.DodgerBlue;
      this.btnDangki.ActiveForecolor = Color.White;
      this.btnDangki.ActiveLineColor = Color.DodgerBlue;
      this.btnDangki.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDangki.BackColor = Color.White;
      this.btnDangki.BackgroundImage = (Image) componentResourceManager.GetObject("btnDangki.BackgroundImage");
      this.btnDangki.ButtonText = "Nạp Tiền";
      this.btnDangki.Cursor = Cursors.Hand;
      this.btnDangki.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDangki.ForeColor = Color.Black;
      this.btnDangki.IdleBorderThickness = 1;
      this.btnDangki.IdleCornerRadius = 20;
      this.btnDangki.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.IdleForecolor = Color.White;
      this.btnDangki.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.Location = new Point(113, 279);
      this.btnDangki.Margin = new Padding(6, 5, 6, 5);
      this.btnDangki.Name = "btnDangki";
      this.btnDangki.Size = new Size(374, 40);
      this.btnDangki.TabIndex = 3;
      this.btnDangki.TextAlign = ContentAlignment.MiddleCenter;
      this.btnDangki.Click += new EventHandler(this.btnDangki_Click);
      this.txtSeri.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtSeri.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtSeri.ForeColor = Color.Red;
      this.txtSeri.Location = new Point(113, 252);
      this.txtSeri.Name = "txtSeri";
      this.txtSeri.Size = new Size(374, 22);
      this.txtSeri.TabIndex = 2;
      this.txtSeri.TextChanged += new EventHandler(this.txtSeri_TextChanged);
      this.txtMaThe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtMaThe.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtMaThe.ForeColor = Color.Red;
      this.txtMaThe.Location = new Point(113, 212);
      this.txtMaThe.Name = "txtMaThe";
      this.txtMaThe.Size = new Size(374, 22);
      this.txtMaThe.TabIndex = 1;
      this.txtMaThe.TextChanged += new EventHandler(this.txtMaThe_TextChanged);
      this.label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(23, 257);
      this.label4.Name = "label4";
      this.label4.Size = new Size(29, 15);
      this.label4.TabIndex = 0;
      this.label4.Text = "Seri";
      this.cbbLoaiThe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cbbLoaiThe.BackColor = Color.White;
      this.cbbLoaiThe.Cursor = Cursors.Hand;
      this.cbbLoaiThe.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoaiThe.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbLoaiThe.ForeColor = Color.Black;
      this.cbbLoaiThe.FormattingEnabled = true;
      this.cbbLoaiThe.Items.AddRange(new object[4]
      {
        (object) "VIETEL",
        (object) "VINA",
        (object) "MOBI",
        (object) "GATE"
      });
      this.cbbLoaiThe.Location = new Point(113, 173);
      this.cbbLoaiThe.Name = "cbbLoaiThe";
      this.cbbLoaiThe.Size = new Size(374, 24);
      this.cbbLoaiThe.TabIndex = 0;
      this.cbbLoaiThe.SelectedIndexChanged += new EventHandler(this.cbbLoaiThe_SelectedIndexChanged);
      this.label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(23, 216);
      this.label3.Name = "label3";
      this.label3.Size = new Size(66, 15);
      this.label3.TabIndex = 0;
      this.label3.Text = "Mã thẻ cào";
      this.label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(23, 176);
      this.label2.Name = "label2";
      this.label2.Size = new Size(81, 15);
      this.label2.TabIndex = 0;
      this.label2.Text = "Loại Thẻ Cào";
      this.panel3.Controls.Add((Control) this.label5);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(347, 336);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(510, 401);
      this.panel3.TabIndex = 2;
      this.label5.Dock = DockStyle.Top;
      this.label5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(0, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(510, 200);
      this.label5.TabIndex = 3;
      this.label5.Text = componentResourceManager.GetString("label5.Text");
      this.backgroundWorkerSendMail.DoWork += new DoWorkEventHandler(this.backgroundWorkerSendMail_DoWork);
      this.pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox1.ErrorImage = (Image) componentResourceManager.GetObject("pictureBox1.ErrorImage");
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.InitialImage = (Image) componentResourceManager.GetObject("pictureBox1.InitialImage");
      this.pictureBox1.Location = new Point(26, 68);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(461, 91);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabNaptien);
      this.Size = new Size(1147, 740);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
