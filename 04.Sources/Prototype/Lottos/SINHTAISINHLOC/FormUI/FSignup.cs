// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FSignup
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class FSignup : Form
  {
    private string vang = "";
    private string bac = "";
    private string ngaysudung = "";
    private IContainer components = (IContainer) null;
    public string[] Msg;
    public TbUser ObjUser;
    public TbNgaysudung ObjNgaysudung;
    private tbMessage _infoMessage;
    private string userGioiThieu;
    private TbGioiThieu objGioiThieu;
    private DataTable dt;
    private BunifuElipse bunifuElipse2;
    private Panel panel1;
    private BunifuMaterialTextbox txtMatkhau;
    private PictureBox pictureBox4;
    private PictureBox pictureBox3;
    private BunifuMaterialTextbox txtEmail;
    private Label label1;
    private PictureBox picAvatar;
    private PictureBox picMainTop;
    private BunifuImageButton bunifuImageButton3;
    private BunifuElipse bunifuElipse_Avatar;
    private OpenFileDialog openFileDialog1;
    private BunifuMaterialTextbox txtNguoiGioiThieu;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label lblThongbao;
    private LinkLabel lblDongy;
    private BunifuCheckbox cbDongy;
    private PictureBox pictureBox1;
    private BunifuMaterialTextbox txtUsername;
    private PictureBox pictureBox6;
    private BunifuThinButton2 btnDangki;
    private LinkLabel linkLabel1;
    private LinkLabel linkLabel2;

    public FSignup()
    {
      this.ObjUser = new TbUser();
      this.objGioiThieu = new TbGioiThieu();
      this.InitializeComponent();
      try
      {
        tbConfigApp tbConfigApp = new tbConfigApp();
        FMain.ConfigApp = new tbConfigApp();
        FMain.ConfigApp = tbConfigApp.GetInfoApp();
        tbConfigApp.configApp = FMain.ConfigApp;
      }
      catch (Exception ex)
      {
        FLogin.MsgId = "10";
        FLogin.LogOutStatus = "1";
      }
    }

    private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      FLogin flogin = new FLogin();
      this.Hide();
      int num = (int) flogin.ShowDialog();
    }

    private void BunifuImageButton3Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void BunifuMaterialTextbox3KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void BunifuThinButton21Click(object sender, EventArgs e)
    {
      this.CheckDangki();
    }

    public void CheckDangki()
    {
      if (this.ObjUser.IsUserNameAllowed(this.txtUsername.Text.Trim()))
      {
        string tenDangnhap = this.txtUsername.Text.Trim();
        if (this.ObjUser.CheckUsername(tenDangnhap))
        {
          this.ObjUser.TenDangnhap = tenDangnhap;
          this.lblThongbao.Visible = false;
          if (this.txtEmail.Text.Trim().Length > 0)
          {
            string str1 = this.txtEmail.Text.Trim();
            if (this.ObjUser.IsEmailAllowed(this.txtEmail.Text.Trim()))
            {
              this.ObjUser.Email = str1;
              this.lblThongbao.Visible = false;
              string str2 = ClMain.Encrypt(this.txtMatkhau.Text.Trim(), tbConfigApp.configApp.keyUser);
              if (this.ObjUser.IsPassWordAllowed(this.txtMatkhau.Text.Trim()))
              {
                this.ObjUser.MatKhau = str2;
                this.ObjUser.MatKhauTam = str2;
                this.lblThongbao.Visible = false;
                if (this.txtNguoiGioiThieu.Text.Length > 5)
                {
                  this.userGioiThieu = this.txtNguoiGioiThieu.Text;
                  if (!this.ObjUser.CheckNguoiGioiThieu(this.userGioiThieu))
                  {
                    this.Msg = ClMain.Get_Msg("027");
                    this.lblThongbao.Visible = true;
                    this.lblThongbao.Text = this.Msg[1];
                    this.txtNguoiGioiThieu.Focus();
                  }
                  else
                  {
                    this.lblThongbao.Visible = false;
                    if (!this.cbDongy.Checked)
                    {
                      int num1 = (int) MessageBox.Show(Resources.FSignup_check_Dangki_BẠN_CHƯA_ĐỒNG_Ý_VỚI_NỘI_QUY__, Resources.FSignup_check_Dangki_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                      this.ObjUser.IDC = FLogin.IDC;
                      if ((uint) this.ObjUser.Insert(this.ObjUser) > 0U)
                      {
                        try
                        {
                          this.objGioiThieu.Insert(this.userGioiThieu, this.txtUsername.Text);
                        }
                        catch (Exception ex)
                        {
                          FLogin.MsgId = "009";
                          FLogin.LogOutStatus = "1";
                        }
                        this.InsertInfoSinUp();
                        if (MessageBox.Show(Resources.FSignup_check_Dangki_ĐĂNG_KÍ_THÀNH_CÔNG__ĐĂNG_NHẬP_NGAY, Resources.FSignup_check_Dangki_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                          this.ShowFLogin();
                        else
                          Application.Exit();
                      }
                      else
                      {
                        int num2 = (int) MessageBox.Show(Resources.FSignup_check_Dangki_, Resources.FSignup_check_Dangki_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                      }
                    }
                  }
                }
                else
                {
                  this.Msg = ClMain.Get_Msg("026");
                  this.lblThongbao.Visible = true;
                  this.lblThongbao.Text = this.Msg[1];
                  this.txtNguoiGioiThieu.Focus();
                }
              }
              else
              {
                this.Msg = ClMain.Get_Msg("004");
                this.lblThongbao.Visible = true;
                this.lblThongbao.Text = this.Msg[1];
                this.txtMatkhau.Focus();
              }
            }
            else
            {
              this.Msg = ClMain.Get_Msg("003");
              this.lblThongbao.Visible = true;
              this.lblThongbao.Text = this.Msg[1];
              this.txtEmail.Focus();
            }
          }
          else
          {
            this.lblThongbao.Visible = true;
            this.lblThongbao.Text = Resources.FSignup_CheckDangki_Vui_lòng_nhập_vào_địa_chỉ_email_thật_của_bạn;
            this.txtEmail.Focus();
          }
        }
        else
        {
          this.lblThongbao.Text = Resources.FSignup_txtUsername_OnValueChanged_Tên_đăng_nhập_này_đã_tồn_tại;
          this.lblThongbao.Visible = true;
          this.txtUsername.Focus();
        }
      }
      else
      {
        this.Msg = ClMain.Get_Msg("002");
        this.lblThongbao.Visible = true;
        this.lblThongbao.Text = this.Msg[1];
        this.txtUsername.Focus();
      }
    }

    public void InsertInfoSinUp()
    {
      new tbConfigApp().GetInfoApp();
      this.InsertMessageChaoMung();
      this.InsertNgaysudung();
      this.InsertVangsudung();
      this.InsertMoney();
    }

    private void InsertMessageNguoiNhan()
    {
      tbMessage tbMessage = new tbMessage();
      tbMessage.NguoiGui = "Administrator";
      tbMessage.NguoiNhan = this.txtUsername.Text;
      tbMessage.TieuDe = "Thưởng xu đăng kí mới";
      this.ngaysudung = "[<b style=''color:red''>" + tbConfigApp.configApp.NgayDangkiMoi + "</b>] ngày sử dụng miễn phí từ Sinh Tài Sinh Lộc";
      tbMessage.NoiDung = "Bạn vừa nhận được " + this.ngaysudung + "<br/>";
      tbMessage.Insert(tbMessage);
    }

    private void InsertMessageChaoMung()
    {
      this._infoMessage = new tbMessage();
      this._infoMessage.NguoiGui = "Administrator";
      this._infoMessage.NguoiNhan = this.txtUsername.Text;
      this._infoMessage.TieuDe = "Đăng kí thành công";
      this._infoMessage.NoiDung = "Chào mừng bạn đã đến với Sinh Tài Sinh Lộc. Hi vọng bạn sẽ tìm được bí quyết riêng cho mình.<br>Nếu gặp bất kỳ khó khăn gì thì đừng ngại liên hệ với ban quản trị bạn nhé. Chúc bạn luôn thành công và may mắn.";
      this._infoMessage.Insert(this._infoMessage);
    }

    private void InsertMessageKhongDuocHuongKhuyenMai()
    {
      this._infoMessage = new tbMessage();
      this._infoMessage.NguoiGui = "Quản trị viên";
      this._infoMessage.NguoiNhan = this.txtUsername.Text;
      this._infoMessage.TieuDe = "Thông tin đăng ký";
      this._infoMessage.NoiDung = "<b>Máy tính của bạn đã được sử dụng để đăng ký một tài khoản khác nên những chương trình khuyến mại sẽ không còn được áp dụng trên tài khoản này. Rất mong bạn thông cảm vì sự bất tiện này.<br>Để tiếp tục sử dụng chương trình bạn vui lòng nạp thêm vàng vào tài khoản.</b>";
      this._infoMessage.Insert(this._infoMessage);
    }

    public void InsertNgaysudung()
    {
      this.ObjNgaysudung = new TbNgaysudung();
      this.ObjNgaysudung.TenDangnhap = this.txtUsername.Text;
      this.ObjNgaysudung.NgaySudung = tbConfigApp.configApp.ngayDangkiMoi;
      this.ObjNgaysudung.CachSudung = "Được tặng từ đăng kí mới";
      this.dt = ClMain.getTime_Server_CheckConnection();
      this.ObjNgaysudung.NgayChuyendoi = Convert.ToDateTime(this.dt.Rows[0][0].ToString());
      this.ObjNgaysudung.NgayHethan = this.ObjNgaysudung.NgayChuyendoi.AddDays((double) Convert.ToInt32(this.ObjNgaysudung.NgaySudung));
      this.ObjNgaysudung.Insert(this.ObjNgaysudung);
    }

    public void InsertVangsudung()
    {
      tbVangsudung tbVangsudung = new tbVangsudung();
      tbVangsudung.TenDangnhap = this.txtUsername.Text;
      tbVangsudung.VangSudung = tbConfigApp.configApp.ThuongVangDangkimoi;
      tbVangsudung.CachSudung = "Được tặng từ đăng kí mới";
      tbVangsudung.Insert(tbVangsudung);
    }

    public void InsertXusudung()
    {
      tbXusudung tbXusudung = new tbXusudung();
      tbXusudung.TenDangnhap = this.txtUsername.Text;
      tbXusudung.XuSudung = tbConfigApp.configApp.thuongXuDangkimoi;
      tbXusudung.CachSudung = "Được tặng từ đăng kí mới";
      tbXusudung.Insert(tbXusudung);
    }

    public void InsertMoney()
    {
      tbMoneyUSER tbMoneyUser = new tbMoneyUSER();
      tbMoneyUser.TenDangnhap = this.txtUsername.Text;
      if (!this.ObjUser.CheckIDC(FLogin.IDC))
      {
        tbMoneyUser.VangHienco = tbConfigApp.configApp.ThuongVangDangkimoi;
        tbMoneyUser.XuHienco = tbConfigApp.configApp.thuongXuDangkimoi;
        tbMoneyUser.SuDungtu_Ngay = this.ObjNgaysudung.NgayChuyendoi;
        tbMoneyUser.SuDungden_Ngay = this.ObjNgaysudung.NgayHethan;
      }
      else
      {
        this.dt = ClMain.getTime_Server_CheckConnection();
        tbMoneyUser.VangHienco = "0";
        tbMoneyUser.XuHienco = "0";
        tbMoneyUser.SuDungtu_Ngay = Convert.ToDateTime(this.dt.Rows[0][0].ToString());
        tbMoneyUser.SuDungden_Ngay = Convert.ToDateTime(this.dt.Rows[0][0].ToString());
        this.InsertMessageKhongDuocHuongKhuyenMai();
      }
      tbMoneyUser.Insert(tbMoneyUser);
    }

    public void ShowFLogin()
    {
      FLogin flogin = new FLogin();
      this.Hide();
      int num = (int) flogin.ShowDialog();
    }

    private void LblDongyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(tbConfigApp.configApp.Dieukhoansudung);
    }

    private void txtUsername_OnValueChanged(object sender, EventArgs e)
    {
    }

    private void txtEmail_OnValueChanged(object sender, EventArgs e)
    {
    }

    private void txtMatkhau_OnValueChanged(object sender, EventArgs e)
    {
    }

    private void BunifuMaterialTextbox3MouseClick(object sender, MouseEventArgs e)
    {
      if (!(this.txtUsername.Text == Resources.FSignup_bunifuMaterialTextbox3_MouseClick_Tên_đăng_nhập))
        return;
      this.txtUsername.Text = "";
    }

    private void TxtEmailMouseClick(object sender, MouseEventArgs e)
    {
      if (!(this.txtEmail.Text == Resources.FSignup_txtEmail_MouseClick_Địa_chỉ_Email))
        return;
      this.txtEmail.Text = "";
    }

    private void TxtMatkhauMouseClick(object sender, MouseEventArgs e)
    {
      if (!(this.txtMatkhau.Text == Resources.FSignup_txtMatkhau_MouseClick_Mật_khẩu))
        return;
      this.txtMatkhau.Text = "";
    }

    private void PicMainTopMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("http://sinhtaisinhloc.com/tin/chinh-sach-h-tro-thanh-vien-va-nhom-p966435611-c31202796-n787846137");
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FSignup));
      this.bunifuElipse2 = new BunifuElipse(this.components);
      this.panel1 = new Panel();
      this.txtNguoiGioiThieu = new BunifuMaterialTextbox();
      this.linkLabel2 = new LinkLabel();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.lblThongbao = new Label();
      this.pictureBox1 = new PictureBox();
      this.lblDongy = new LinkLabel();
      this.cbDongy = new BunifuCheckbox();
      this.txtUsername = new BunifuMaterialTextbox();
      this.pictureBox6 = new PictureBox();
      this.txtMatkhau = new BunifuMaterialTextbox();
      this.pictureBox4 = new PictureBox();
      this.pictureBox3 = new PictureBox();
      this.btnDangki = new BunifuThinButton2();
      this.linkLabel1 = new LinkLabel();
      this.txtEmail = new BunifuMaterialTextbox();
      this.label1 = new Label();
      this.picAvatar = new PictureBox();
      this.picMainTop = new PictureBox();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.bunifuElipse_Avatar = new BunifuElipse(this.components);
      this.openFileDialog1 = new OpenFileDialog();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox6).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.picAvatar).BeginInit();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.SuspendLayout();
      this.bunifuElipse2.ElipseRadius = 10;
      this.bunifuElipse2.TargetControl = (Control) this.panel1;
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.txtNguoiGioiThieu);
      this.panel1.Controls.Add((Control) this.linkLabel2);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.lblThongbao);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.lblDongy);
      this.panel1.Controls.Add((Control) this.cbDongy);
      this.panel1.Controls.Add((Control) this.txtUsername);
      this.panel1.Controls.Add((Control) this.pictureBox6);
      this.panel1.Controls.Add((Control) this.txtMatkhau);
      this.panel1.Controls.Add((Control) this.pictureBox4);
      this.panel1.Controls.Add((Control) this.pictureBox3);
      this.panel1.Controls.Add((Control) this.btnDangki);
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.txtEmail);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.picAvatar);
      this.panel1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.panel1.Location = new Point(95, 18);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(596, 434);
      this.panel1.TabIndex = 0;
      this.txtNguoiGioiThieu.Cursor = Cursors.IBeam;
      this.txtNguoiGioiThieu.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtNguoiGioiThieu.ForeColor = Color.DimGray;
      this.txtNguoiGioiThieu.HintForeColor = Color.DimGray;
      this.txtNguoiGioiThieu.HintText = "Người giới thiệu (tên đăng nhập hoặc email)";
      this.txtNguoiGioiThieu.isPassword = false;
      this.txtNguoiGioiThieu.LineFocusedColor = Color.Red;
      this.txtNguoiGioiThieu.LineIdleColor = Color.Gray;
      this.txtNguoiGioiThieu.LineMouseHoverColor = Color.Red;
      this.txtNguoiGioiThieu.LineThickness = 1;
      this.txtNguoiGioiThieu.Location = new Point(121, 301);
      this.txtNguoiGioiThieu.Margin = new Padding(5);
      this.txtNguoiGioiThieu.Name = "txtNguoiGioiThieu";
      this.txtNguoiGioiThieu.Size = new Size(361, 35);
      this.txtNguoiGioiThieu.TabIndex = 3;
      this.txtNguoiGioiThieu.Text = "haiduong";
      this.txtNguoiGioiThieu.TextAlign = HorizontalAlignment.Left;
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel2.ForeColor = Color.Red;
      this.linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
      this.linkLabel2.LinkColor = Color.Red;
      this.linkLabel2.Location = new Point(490, 315);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(69, 15);
      this.linkLabel2.TabIndex = 25;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "(xem thêm)";
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DimGray;
      this.label4.Location = new Point(493, 260);
      this.label4.Name = "label4";
      this.label4.Size = new Size(58, 14);
      this.label4.TabIndex = 24;
      this.label4.Text = "(Bắt buộc)";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DimGray;
      this.label3.Location = new Point(493, 202);
      this.label3.Name = "label3";
      this.label3.Size = new Size(58, 14);
      this.label3.TabIndex = 23;
      this.label3.Text = "(Bắt buộc)";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DimGray;
      this.label2.Location = new Point(493, 142);
      this.label2.Name = "label2";
      this.label2.Size = new Size(58, 14);
      this.label2.TabIndex = 18;
      this.label2.Text = "(Bắt buộc)";
      this.lblThongbao.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThongbao.ForeColor = Color.Red;
      this.lblThongbao.Location = new Point(97, 99);
      this.lblThongbao.Name = "lblThongbao";
      this.lblThongbao.Size = new Size(423, 18);
      this.lblThongbao.TabIndex = 17;
      this.lblThongbao.Text = "*Thông báo tên đăng nhập";
      this.lblThongbao.TextAlign = ContentAlignment.TopCenter;
      this.lblThongbao.Visible = false;
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(86, 307);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(26, 26);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 16;
      this.pictureBox1.TabStop = false;
      this.lblDongy.AutoSize = true;
      this.lblDongy.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblDongy.LinkBehavior = LinkBehavior.NeverUnderline;
      this.lblDongy.LinkColor = Color.DarkSlateGray;
      this.lblDongy.Location = new Point(140, 364);
      this.lblDongy.Name = "lblDongy";
      this.lblDongy.Size = new Size(338, 17);
      this.lblDongy.TabIndex = 5;
      this.lblDongy.TabStop = true;
      this.lblDongy.Text = "Tôi đồng ý với các điều khoản và quy định tham gia";
      this.lblDongy.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LblDongyLinkClicked);
      this.cbDongy.AutoSize = true;
      this.cbDongy.BackColor = Color.FromArgb(51, 205, 117);
      this.cbDongy.ChechedOffColor = Color.FromArgb(132, 135, 140);
      this.cbDongy.Checked = true;
      this.cbDongy.CheckedOnColor = Color.FromArgb(51, 205, 117);
      this.cbDongy.Cursor = Cursors.Hand;
      this.cbDongy.ForeColor = Color.White;
      this.cbDongy.Location = new Point(116, 363);
      this.cbDongy.Margin = new Padding(0);
      this.cbDongy.Name = "cbDongy";
      this.cbDongy.Size = new Size(20, 20);
      this.cbDongy.TabIndex = 4;
      this.txtUsername.Cursor = Cursors.IBeam;
      this.txtUsername.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtUsername.ForeColor = Color.DimGray;
      this.txtUsername.HintForeColor = Color.DimGray;
      this.txtUsername.HintText = "Tên đăng nhập";
      this.txtUsername.isPassword = false;
      this.txtUsername.LineFocusedColor = Color.Red;
      this.txtUsername.LineIdleColor = Color.Gray;
      this.txtUsername.LineMouseHoverColor = Color.Red;
      this.txtUsername.LineThickness = 1;
      this.txtUsername.Location = new Point(121, (int) sbyte.MaxValue);
      this.txtUsername.Margin = new Padding(5);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new Size(357, 35);
      this.txtUsername.TabIndex = 0;
      this.txtUsername.TextAlign = HorizontalAlignment.Left;
      this.txtUsername.OnValueChanged += new EventHandler(this.txtUsername_OnValueChanged);
      this.txtUsername.KeyPress += new KeyPressEventHandler(this.BunifuMaterialTextbox3KeyPress);
      this.txtUsername.MouseClick += new MouseEventHandler(this.BunifuMaterialTextbox3MouseClick);
      this.pictureBox6.Image = (Image) componentResourceManager.GetObject("pictureBox6.Image");
      this.pictureBox6.Location = new Point(85, 249);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new Size(27, 27);
      this.pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox6.TabIndex = 11;
      this.pictureBox6.TabStop = false;
      this.txtMatkhau.Cursor = Cursors.IBeam;
      this.txtMatkhau.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtMatkhau.ForeColor = Color.DimGray;
      this.txtMatkhau.HintForeColor = Color.DimGray;
      this.txtMatkhau.HintText = "Mật khẩu của bạn (hiển thị)";
      this.txtMatkhau.isPassword = false;
      this.txtMatkhau.LineFocusedColor = Color.Red;
      this.txtMatkhau.LineIdleColor = Color.Gray;
      this.txtMatkhau.LineMouseHoverColor = Color.Red;
      this.txtMatkhau.LineThickness = 1;
      this.txtMatkhau.Location = new Point(121, 243);
      this.txtMatkhau.Margin = new Padding(5);
      this.txtMatkhau.Name = "txtMatkhau";
      this.txtMatkhau.Size = new Size(357, 35);
      this.txtMatkhau.TabIndex = 2;
      this.txtMatkhau.TextAlign = HorizontalAlignment.Left;
      this.txtMatkhau.OnValueChanged += new EventHandler(this.txtMatkhau_OnValueChanged);
      this.txtMatkhau.MouseClick += new MouseEventHandler(this.TxtMatkhauMouseClick);
      this.pictureBox4.Image = (Image) componentResourceManager.GetObject("pictureBox4.Image");
      this.pictureBox4.Location = new Point(87, 190);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(25, 25);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox4.TabIndex = 7;
      this.pictureBox4.TabStop = false;
      this.pictureBox3.Image = (Image) componentResourceManager.GetObject("pictureBox3.Image");
      this.pictureBox3.Location = new Point(87, 132);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(26, 26);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox3.TabIndex = 6;
      this.pictureBox3.TabStop = false;
      this.btnDangki.ActiveBorderThickness = 1;
      this.btnDangki.ActiveCornerRadius = 20;
      this.btnDangki.ActiveFillColor = Color.DodgerBlue;
      this.btnDangki.ActiveForecolor = Color.Transparent;
      this.btnDangki.ActiveLineColor = Color.DodgerBlue;
      this.btnDangki.BackColor = Color.White;
      this.btnDangki.BackgroundImage = (Image) componentResourceManager.GetObject("btnDangki.BackgroundImage");
      this.btnDangki.ButtonText = "Đăng ký";
      this.btnDangki.Cursor = Cursors.Hand;
      this.btnDangki.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDangki.ForeColor = Color.Black;
      this.btnDangki.IdleBorderThickness = 1;
      this.btnDangki.IdleCornerRadius = 20;
      this.btnDangki.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.IdleForecolor = Color.White;
      this.btnDangki.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.Location = new Point(187, 386);
      this.btnDangki.Margin = new Padding(6, 5, 6, 5);
      this.btnDangki.Name = "btnDangki";
      this.btnDangki.Size = new Size(295, 40);
      this.btnDangki.TabIndex = 6;
      this.btnDangki.TextAlign = ContentAlignment.MiddleCenter;
      this.btnDangki.Click += new EventHandler(this.BunifuThinButton21Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(115, 398);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(70, 16);
      this.linkLabel1.TabIndex = 7;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Đăng nhập";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
      this.txtEmail.Cursor = Cursors.IBeam;
      this.txtEmail.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEmail.ForeColor = Color.DimGray;
      this.txtEmail.HintForeColor = Color.DimGray;
      this.txtEmail.HintText = "Địa chỉ email thật của bạn";
      this.txtEmail.isPassword = false;
      this.txtEmail.LineFocusedColor = Color.Red;
      this.txtEmail.LineIdleColor = Color.Gray;
      this.txtEmail.LineMouseHoverColor = Color.Red;
      this.txtEmail.LineThickness = 1;
      this.txtEmail.Location = new Point(121, 185);
      this.txtEmail.Margin = new Padding(5);
      this.txtEmail.Name = "txtEmail";
      this.txtEmail.Size = new Size(357, 35);
      this.txtEmail.TabIndex = 1;
      this.txtEmail.TextAlign = HorizontalAlignment.Left;
      this.txtEmail.OnValueChanged += new EventHandler(this.txtEmail_OnValueChanged);
      this.txtEmail.MouseClick += new MouseEventHandler(this.TxtEmailMouseClick);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.label1.ForeColor = SystemColors.ControlDarkDark;
      this.label1.Location = new Point(138, 69);
      this.label1.Name = "label1";
      this.label1.Size = new Size(344, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "ĐĂNG KÝ THAM GIA CỘNG ĐỒNG SINH TÀI SINH LỘC";
      this.picAvatar.BackColor = Color.Transparent;
      this.picAvatar.ErrorImage = (Image) componentResourceManager.GetObject("picAvatar.ErrorImage");
      this.picAvatar.Image = (Image) componentResourceManager.GetObject("picAvatar.Image");
      this.picAvatar.Location = new Point(270, 4);
      this.picAvatar.Margin = new Padding(0);
      this.picAvatar.Name = "picAvatar";
      this.picAvatar.Size = new Size(60, 60);
      this.picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
      this.picAvatar.TabIndex = 0;
      this.picAvatar.TabStop = false;
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(784, 240);
      this.picMainTop.TabIndex = 6;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.PicMainTopMouseDown);
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(759, 2);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(23, 23);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 8;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 10;
      this.bunifuImageButton3.Click += new EventHandler(this.BunifuImageButton3Click);
      this.bunifuElipse_Avatar.ElipseRadius = 0;
      this.bunifuElipse_Avatar.TargetControl = (Control) this.picAvatar;
      this.openFileDialog1.FileName = "openFileDialog1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(784, 468);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.picMainTop);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FSignup);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Đăng ký tài khoản";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox6).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.picAvatar).EndInit();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.bunifuImageButton3.EndInit();
      this.ResumeLayout(false);
    }
  }
}
