// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabInfoUser
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabInfoUser : UserControl
  {
    public static int LoadLaiFrom = 1;
    private IContainer components = (IContainer) null;
    public TbUser User;
    private string[] _msg;
    public tbMoneyUSER TbMoney;
    private string userName;
    private Panel panel1;
    private BunifuCustomLabel bunifuCustomLabel1;
    private BunifuSeparator bunifuSeparator1;
    private Panel panel2;
    private Panel panel3;
    private BunifuThinButton2 btnCapnhat;
    private BunifuCustomLabel bunifuCustomLabel8;
    private BunifuCustomLabel bunifuCustomLabel7;
    private BunifuCustomLabel bunifuCustomLabel6;
    private BunifuCustomLabel bunifuCustomLabel5;
    private BunifuCustomLabel bunifuCustomLabel4;
    private BunifuCustomLabel bunifuCustomLabel3;
    private PictureBox picAvatar;
    private BunifuCustomLabel bunifuCustomLabel2;
    private BunifuMaterialTextbox txtSdt;
    private BunifuMaterialTextbox txtMatkhau;
    private BunifuMaterialTextbox txtEmail;
    private BunifuMaterialTextbox txtTendangnhap;
    private BunifuMaterialTextbox txtHovaten;
    private DateTimePicker dtNgaysinh;
    private LinkLabel linkLabel2;
    private BunifuCustomLabel bunifuCustomLabel9;
    private BunifuCustomLabel lblThoihan;
    private BunifuThinButton2 bunifuThinButton21;
    private Panel panel5;
    private BunifuCustomLabel lblVang;
    private BunifuThinButton2 bunifuThinButton22;
    private BunifuCustomLabel bunifuCustomLabel11;
    private Panel panel4;
    private BunifuSeparator bunifuSeparator2;
    private Timer timerThoiHanSuDung;
    private Panel panel7;
    private BunifuElipse bunifuElipse1;
    private BunifuImageButton bunifuImageButton1;
    private BackgroundWorker backgroundWorker1;
    private PictureBox picLoading;
    private Panel panel6;
    private BunifuCustomLabel lblBac;
    private BunifuThinButton2 bunifuThinButton23;
    private BunifuCustomLabel bunifuCustomLabel14;

    public TabInfoUser()
    {
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.userName = TbUser.Tbuser.TenDangnhap;
    }

    public void ShowInfoUser()
    {
      this.TbMoney = new tbMoneyUSER();
      this.TbMoney = this.TbMoney.GetInfor(this.userName);
      this.User = new TbUser();
      if (this.User.GetInforUserUsername(this.userName))
        return;
      int num = (int) MessageBox.Show(Resources.tabInfoUser_show_InfoUser_KHÔNG_LẤY_ĐƯỢC_THÔNG_TIN_TÀI_KHOẢN, Resources.tabInfoUser_show_InfoUser_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      Environment.Exit(0);
    }

    private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      int num = (int) new fChangePW().ShowDialog();
    }

    private void BtnCapnhatClick(object sender, EventArgs e)
    {
      if (this.txtHovaten.Text == "")
        this.txtHovaten.Focus();
      else if (this.txtSdt.Text == "")
        this.txtSdt.Focus();
      else if (this.CheckEmail())
      {
        TbUser.Tbuser.Email = this.txtEmail.Text;
        TbUser.Tbuser.Hovaten = this.txtHovaten.Text;
        TbUser.Tbuser.SoDienthoai = this.txtSdt.Text;
        if (TbUser.Tbuser.Update(TbUser.Tbuser) <= 0 || MessageBox.Show(Resources.tabInfoUser_btnCapnhat_Click_CẬP_NHẬT_THÀNH_CÔNG, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk) != DialogResult.OK)
          return;
        FMain.LoadLaiForm = 1;
        TabInfoUser.LoadLaiFrom = 1;
      }
      else
      {
        int num = (int) MessageBox.Show(Resources.tabInfoUser_btnCapnhat_Click_ĐỊNH_DẠNG_EMAIL_KHÔNG_CHÍNH_XÁC_HOẶC_ĐÃ_ĐƯỢC_SỬ_DỤNG, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.txtEmail.Focus();
      }
    }

    private void DtNgaysinhValueChanged(object sender, EventArgs e)
    {
      TbUser.Tbuser.Ngaysinh = this.dtNgaysinh.Value;
    }

    private void TimerThoiHanSuDungTick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.backgroundWorker1.IsBusy;
      this.lblThoihan.Text = FMain.HanSuDung;
      this.lblVang.Text = ClMain.QuiDoiSoLuong(FMain.VanghienCo.ToString((IFormatProvider) CultureInfo.InvariantCulture), "vàng");
      this.lblBac.Text = ClMain.QuiDoiSoLuong(FMain.BacHienco.ToString((IFormatProvider) CultureInfo.InvariantCulture), "bạc");
      if (TabInfoUser.LoadLaiFrom != 1)
        return;
      if (!this.backgroundWorker1.IsBusy)
        this.backgroundWorker1.RunWorkerAsync();
      TabInfoUser.LoadLaiFrom = 0;
    }

    private void txtEmail_OnValueChanged(object sender, EventArgs e)
    {
    }

    private bool CheckEmail()
    {
      return TbUser.Tbuser.IsEmailAllowed(this.txtEmail.Text);
    }

    private void BunifuThinButton22Click(object sender, EventArgs e)
    {
      this.addtabNaptien();
    }

    private void addtabNaptien()
    {
      FMain.LoadTabname = "Nạp tiền";
    }

    private void BunifuThinButton23Click(object sender, EventArgs e)
    {
      this.ShowInfoUser();
      if (Convert.ToInt32(this.TbMoney.VangHienco) > 0)
      {
        int num = (int) new FThemXu().ShowDialog();
      }
      else
      {
        this._msg = ClMain.Get_Msg("015");
        if (MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
          this.addtabNaptien();
      }
    }

    private void BunifuThinButton21Click(object sender, EventArgs e)
    {
      int num = (int) new FThemNgaysudung().ShowDialog();
    }

    private void TabInfoUserLoad(object sender, EventArgs e)
    {
      TabInfoUser.LoadLaiFrom = 1;
    }

    private void BunifuImageButton1Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Filter = Resources.FSignup_btnImage_Click_Image_Files___jpeg___png___jpg;
        openFileDialog1.ValidateNames = true;
        openFileDialog1.Multiselect = false;
        using (OpenFileDialog openFileDialog2 = openFileDialog1)
        {
          if (openFileDialog2.ShowDialog() != DialogResult.OK || openFileDialog2.FileName == null)
            return;
          this.picAvatar.Image = Image.FromFile(openFileDialog2.FileName);
        }
      }
      catch
      {
        int num = (int) MessageBox.Show(Resources.FSignup_btnImage_Click_LỖI_THÊM_ẢNH, Resources.tabInfoUser_show_InfoUser_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.txtHovaten.Text = TbUser.Tbuser.Hovaten;
      this.txtTendangnhap.Text = this.userName;
      this.txtEmail.Text = TbUser.Tbuser.Email;
      this.txtSdt.Text = TbUser.Tbuser.SoDienthoai;
      this.dtNgaysinh.Value = TbUser.Tbuser.Ngaysinh;
    }

    private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
    {
      this.ShowInfoUser();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabInfoUser));
      this.panel1 = new Panel();
      this.bunifuCustomLabel1 = new BunifuCustomLabel();
      this.bunifuSeparator1 = new BunifuSeparator();
      this.panel2 = new Panel();
      this.panel3 = new Panel();
      this.picLoading = new PictureBox();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.panel7 = new Panel();
      this.panel6 = new Panel();
      this.lblBac = new BunifuCustomLabel();
      this.bunifuThinButton23 = new BunifuThinButton2();
      this.bunifuCustomLabel14 = new BunifuCustomLabel();
      this.panel5 = new Panel();
      this.bunifuCustomLabel11 = new BunifuCustomLabel();
      this.lblVang = new BunifuCustomLabel();
      this.bunifuThinButton22 = new BunifuThinButton2();
      this.bunifuSeparator2 = new BunifuSeparator();
      this.panel4 = new Panel();
      this.lblThoihan = new BunifuCustomLabel();
      this.bunifuThinButton21 = new BunifuThinButton2();
      this.bunifuCustomLabel9 = new BunifuCustomLabel();
      this.linkLabel2 = new LinkLabel();
      this.dtNgaysinh = new DateTimePicker();
      this.txtSdt = new BunifuMaterialTextbox();
      this.txtMatkhau = new BunifuMaterialTextbox();
      this.txtEmail = new BunifuMaterialTextbox();
      this.txtTendangnhap = new BunifuMaterialTextbox();
      this.txtHovaten = new BunifuMaterialTextbox();
      this.btnCapnhat = new BunifuThinButton2();
      this.bunifuCustomLabel8 = new BunifuCustomLabel();
      this.bunifuCustomLabel7 = new BunifuCustomLabel();
      this.bunifuCustomLabel6 = new BunifuCustomLabel();
      this.bunifuCustomLabel5 = new BunifuCustomLabel();
      this.bunifuCustomLabel4 = new BunifuCustomLabel();
      this.bunifuCustomLabel3 = new BunifuCustomLabel();
      this.picAvatar = new PictureBox();
      this.bunifuCustomLabel2 = new BunifuCustomLabel();
      this.timerThoiHanSuDung = new Timer(this.components);
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.backgroundWorker1 = new BackgroundWorker();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.bunifuImageButton1.BeginInit();
      this.panel7.SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel4.SuspendLayout();
      ((ISupportInitialize) this.picAvatar).BeginInit();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.bunifuCustomLabel1);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1339, 44);
      this.panel1.TabIndex = 0;
      this.bunifuCustomLabel1.AutoSize = true;
      this.bunifuCustomLabel1.Font = new Font("Arial", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel1.ForeColor = Color.Teal;
      this.bunifuCustomLabel1.Location = new Point(11, 9);
      this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
      this.bunifuCustomLabel1.Size = new Size(219, 27);
      this.bunifuCustomLabel1.TabIndex = 0;
      this.bunifuCustomLabel1.Text = "Thông tin tài khoản";
      this.bunifuSeparator1.BackColor = Color.Transparent;
      this.bunifuSeparator1.Dock = DockStyle.Top;
      this.bunifuSeparator1.LineColor = Color.FromArgb(105, 105, 105);
      this.bunifuSeparator1.LineThickness = 1;
      this.bunifuSeparator1.Location = new Point(0, 44);
      this.bunifuSeparator1.Margin = new Padding(5, 3, 5, 3);
      this.bunifuSeparator1.Name = "bunifuSeparator1";
      this.bunifuSeparator1.Size = new Size(1339, 1);
      this.bunifuSeparator1.TabIndex = 1;
      this.bunifuSeparator1.Transparency = (int) byte.MaxValue;
      this.bunifuSeparator1.Vertical = false;
      this.panel2.Controls.Add((Control) this.panel3);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 45);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1339, 594);
      this.panel2.TabIndex = 2;
      this.panel3.Controls.Add((Control) this.picLoading);
      this.panel3.Controls.Add((Control) this.bunifuImageButton1);
      this.panel3.Controls.Add((Control) this.panel7);
      this.panel3.Controls.Add((Control) this.linkLabel2);
      this.panel3.Controls.Add((Control) this.dtNgaysinh);
      this.panel3.Controls.Add((Control) this.txtSdt);
      this.panel3.Controls.Add((Control) this.txtMatkhau);
      this.panel3.Controls.Add((Control) this.txtEmail);
      this.panel3.Controls.Add((Control) this.txtTendangnhap);
      this.panel3.Controls.Add((Control) this.txtHovaten);
      this.panel3.Controls.Add((Control) this.btnCapnhat);
      this.panel3.Controls.Add((Control) this.bunifuCustomLabel8);
      this.panel3.Controls.Add((Control) this.bunifuCustomLabel7);
      this.panel3.Controls.Add((Control) this.bunifuCustomLabel6);
      this.panel3.Controls.Add((Control) this.bunifuCustomLabel5);
      this.panel3.Controls.Add((Control) this.bunifuCustomLabel4);
      this.panel3.Controls.Add((Control) this.bunifuCustomLabel3);
      this.panel3.Controls.Add((Control) this.picAvatar);
      this.panel3.Controls.Add((Control) this.bunifuCustomLabel2);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1339, 594);
      this.panel3.TabIndex = 0;
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(658, 238);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 56;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Cursor = Cursors.Hand;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(435, 151);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(28, 28);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 55;
      this.bunifuImageButton1.TabStop = false;
      this.bunifuImageButton1.Visible = false;
      this.bunifuImageButton1.Zoom = 10;
      this.bunifuImageButton1.Click += new EventHandler(this.BunifuImageButton1Click);
      this.panel7.Controls.Add((Control) this.panel6);
      this.panel7.Controls.Add((Control) this.panel5);
      this.panel7.Controls.Add((Control) this.bunifuSeparator2);
      this.panel7.Controls.Add((Control) this.panel4);
      this.panel7.Dock = DockStyle.Bottom;
      this.panel7.Location = new Point(0, 489);
      this.panel7.Name = "panel7";
      this.panel7.Size = new Size(1339, 105);
      this.panel7.TabIndex = 53;
      this.panel6.Controls.Add((Control) this.lblBac);
      this.panel6.Controls.Add((Control) this.bunifuThinButton23);
      this.panel6.Controls.Add((Control) this.bunifuCustomLabel14);
      this.panel6.Location = new Point(435, 8);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(194, 89);
      this.panel6.TabIndex = 52;
      this.panel6.Visible = false;
      this.lblBac.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblBac.ForeColor = Color.Red;
      this.lblBac.Location = new Point(3, 43);
      this.lblBac.Name = "lblBac";
      this.lblBac.Size = new Size(193, 18);
      this.lblBac.TabIndex = 49;
      this.lblBac.Text = "150.000 Bạc";
      this.lblBac.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton23.ActiveBorderThickness = 1;
      this.bunifuThinButton23.ActiveCornerRadius = 20;
      this.bunifuThinButton23.ActiveFillColor = SystemColors.ButtonFace;
      this.bunifuThinButton23.ActiveForecolor = Color.Black;
      this.bunifuThinButton23.ActiveLineColor = SystemColors.ControlDarkDark;
      this.bunifuThinButton23.BackColor = Color.White;
      this.bunifuThinButton23.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton23.BackgroundImage");
      this.bunifuThinButton23.ButtonText = "Đổi thêm bạc";
      this.bunifuThinButton23.Cursor = Cursors.Hand;
      this.bunifuThinButton23.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton23.ForeColor = Color.Black;
      this.bunifuThinButton23.IdleBorderThickness = 1;
      this.bunifuThinButton23.IdleCornerRadius = 20;
      this.bunifuThinButton23.IdleFillColor = Color.WhiteSmoke;
      this.bunifuThinButton23.IdleForecolor = Color.Black;
      this.bunifuThinButton23.IdleLineColor = Color.DodgerBlue;
      this.bunifuThinButton23.Location = new Point(14, 54);
      this.bunifuThinButton23.Margin = new Padding(0);
      this.bunifuThinButton23.Name = "bunifuThinButton23";
      this.bunifuThinButton23.Size = new Size(164, 33);
      this.bunifuThinButton23.TabIndex = 0;
      this.bunifuThinButton23.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton23.Click += new EventHandler(this.BunifuThinButton23Click);
      this.bunifuCustomLabel14.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel14.ForeColor = Color.Black;
      this.bunifuCustomLabel14.Location = new Point(1, 18);
      this.bunifuCustomLabel14.Name = "bunifuCustomLabel14";
      this.bunifuCustomLabel14.Size = new Size(193, 18);
      this.bunifuCustomLabel14.TabIndex = 44;
      this.bunifuCustomLabel14.Text = "Bạc hiện có";
      this.bunifuCustomLabel14.TextAlign = ContentAlignment.TopCenter;
      this.panel5.Controls.Add((Control) this.bunifuCustomLabel11);
      this.panel5.Controls.Add((Control) this.lblVang);
      this.panel5.Controls.Add((Control) this.bunifuThinButton22);
      this.panel5.Location = new Point(218, 8);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(195, 89);
      this.panel5.TabIndex = 52;
      this.bunifuCustomLabel11.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel11.ForeColor = Color.Black;
      this.bunifuCustomLabel11.Location = new Point(4, 18);
      this.bunifuCustomLabel11.Name = "bunifuCustomLabel11";
      this.bunifuCustomLabel11.Size = new Size(193, 18);
      this.bunifuCustomLabel11.TabIndex = 44;
      this.bunifuCustomLabel11.Text = "Vàng hiện có";
      this.bunifuCustomLabel11.TextAlign = ContentAlignment.TopCenter;
      this.lblVang.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVang.ForeColor = Color.Red;
      this.lblVang.Location = new Point(4, 43);
      this.lblVang.Name = "lblVang";
      this.lblVang.Size = new Size(193, 18);
      this.lblVang.TabIndex = 49;
      this.lblVang.Text = "13 vàng";
      this.lblVang.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton22.ActiveBorderThickness = 1;
      this.bunifuThinButton22.ActiveCornerRadius = 20;
      this.bunifuThinButton22.ActiveFillColor = SystemColors.ButtonFace;
      this.bunifuThinButton22.ActiveForecolor = Color.Black;
      this.bunifuThinButton22.ActiveLineColor = SystemColors.ControlDarkDark;
      this.bunifuThinButton22.BackColor = Color.White;
      this.bunifuThinButton22.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton22.BackgroundImage");
      this.bunifuThinButton22.ButtonText = "Mua thêm vàng";
      this.bunifuThinButton22.Cursor = Cursors.Hand;
      this.bunifuThinButton22.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton22.ForeColor = Color.Black;
      this.bunifuThinButton22.IdleBorderThickness = 1;
      this.bunifuThinButton22.IdleCornerRadius = 20;
      this.bunifuThinButton22.IdleFillColor = Color.WhiteSmoke;
      this.bunifuThinButton22.IdleForecolor = Color.Black;
      this.bunifuThinButton22.IdleLineColor = Color.DodgerBlue;
      this.bunifuThinButton22.Location = new Point(17, 54);
      this.bunifuThinButton22.Margin = new Padding(0);
      this.bunifuThinButton22.Name = "bunifuThinButton22";
      this.bunifuThinButton22.Size = new Size(164, 33);
      this.bunifuThinButton22.TabIndex = 0;
      this.bunifuThinButton22.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton22.Visible = false;
      this.bunifuThinButton22.Click += new EventHandler(this.BunifuThinButton22Click);
      this.bunifuSeparator2.BackColor = Color.Transparent;
      this.bunifuSeparator2.Dock = DockStyle.Top;
      this.bunifuSeparator2.LineColor = Color.FromArgb(105, 105, 105);
      this.bunifuSeparator2.LineThickness = 1;
      this.bunifuSeparator2.Location = new Point(0, 0);
      this.bunifuSeparator2.Name = "bunifuSeparator2";
      this.bunifuSeparator2.Size = new Size(1339, 4);
      this.bunifuSeparator2.TabIndex = 47;
      this.bunifuSeparator2.Transparency = (int) byte.MaxValue;
      this.bunifuSeparator2.Vertical = false;
      this.panel4.Controls.Add((Control) this.lblThoihan);
      this.panel4.Controls.Add((Control) this.bunifuThinButton21);
      this.panel4.Controls.Add((Control) this.bunifuCustomLabel9);
      this.panel4.Location = new Point(3, 8);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(193, 89);
      this.panel4.TabIndex = 52;
      this.lblThoihan.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThoihan.ForeColor = Color.Red;
      this.lblThoihan.Location = new Point(1, 43);
      this.lblThoihan.Name = "lblThoihan";
      this.lblThoihan.Size = new Size(192, 18);
      this.lblThoihan.TabIndex = 49;
      this.lblThoihan.Text = "3 ngày 4 giờ 15 phút";
      this.lblThoihan.TextAlign = ContentAlignment.TopCenter;
      this.bunifuThinButton21.ActiveBorderThickness = 1;
      this.bunifuThinButton21.ActiveCornerRadius = 20;
      this.bunifuThinButton21.ActiveFillColor = SystemColors.ButtonFace;
      this.bunifuThinButton21.ActiveForecolor = Color.Black;
      this.bunifuThinButton21.ActiveLineColor = SystemColors.ControlDarkDark;
      this.bunifuThinButton21.BackColor = Color.White;
      this.bunifuThinButton21.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
      this.bunifuThinButton21.ButtonText = "Thêm ngày sử dụng";
      this.bunifuThinButton21.Cursor = Cursors.Hand;
      this.bunifuThinButton21.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton21.ForeColor = Color.Black;
      this.bunifuThinButton21.IdleBorderThickness = 1;
      this.bunifuThinButton21.IdleCornerRadius = 20;
      this.bunifuThinButton21.IdleFillColor = Color.WhiteSmoke;
      this.bunifuThinButton21.IdleForecolor = Color.Black;
      this.bunifuThinButton21.IdleLineColor = Color.DodgerBlue;
      this.bunifuThinButton21.Location = new Point(14, 55);
      this.bunifuThinButton21.Margin = new Padding(0);
      this.bunifuThinButton21.Name = "bunifuThinButton21";
      this.bunifuThinButton21.Size = new Size(164, 33);
      this.bunifuThinButton21.TabIndex = 0;
      this.bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton21.Visible = false;
      this.bunifuThinButton21.Click += new EventHandler(this.BunifuThinButton21Click);
      this.bunifuCustomLabel9.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel9.ForeColor = Color.Black;
      this.bunifuCustomLabel9.Location = new Point(1, 18);
      this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
      this.bunifuCustomLabel9.Size = new Size(192, 18);
      this.bunifuCustomLabel9.TabIndex = 44;
      this.bunifuCustomLabel9.Text = "Thời hạn sử dụng";
      this.bunifuCustomLabel9.TextAlign = ContentAlignment.TopCenter;
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel2.Location = new Point(398, 337);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(49, 15);
      this.linkLabel2.TabIndex = 5;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "thay đổi";
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel2LinkClicked);
      this.dtNgaysinh.CalendarFont = new Font("Arial", 9f, FontStyle.Bold);
      this.dtNgaysinh.CalendarForeColor = Color.Red;
      this.dtNgaysinh.CustomFormat = "dd/MM/yyyy";
      this.dtNgaysinh.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgaysinh.Format = DateTimePickerFormat.Custom;
      this.dtNgaysinh.Location = new Point(164, 422);
      this.dtNgaysinh.Margin = new Padding(3, 5, 3, 5);
      this.dtNgaysinh.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
      this.dtNgaysinh.Name = "dtNgaysinh";
      this.dtNgaysinh.Size = new Size(169, 22);
      this.dtNgaysinh.TabIndex = 6;
      this.dtNgaysinh.ValueChanged += new EventHandler(this.DtNgaysinhValueChanged);
      this.txtSdt.Cursor = Cursors.IBeam;
      this.txtSdt.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSdt.ForeColor = Color.Black;
      this.txtSdt.HintForeColor = Color.Empty;
      this.txtSdt.HintText = "";
      this.txtSdt.isPassword = false;
      this.txtSdt.LineFocusedColor = Color.SkyBlue;
      this.txtSdt.LineIdleColor = Color.Gray;
      this.txtSdt.LineMouseHoverColor = Color.SkyBlue;
      this.txtSdt.LineThickness = 1;
      this.txtSdt.Location = new Point(164, 370);
      this.txtSdt.Margin = new Padding(5, 4, 5, 4);
      this.txtSdt.Name = "txtSdt";
      this.txtSdt.Size = new Size(231, 30);
      this.txtSdt.TabIndex = 4;
      this.txtSdt.Text = "Số điện thoại";
      this.txtSdt.TextAlign = HorizontalAlignment.Left;
      this.txtMatkhau.Cursor = Cursors.IBeam;
      this.txtMatkhau.Enabled = false;
      this.txtMatkhau.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtMatkhau.ForeColor = Color.FromArgb(64, 64, 64);
      this.txtMatkhau.HintForeColor = Color.Empty;
      this.txtMatkhau.HintText = "";
      this.txtMatkhau.isPassword = true;
      this.txtMatkhau.LineFocusedColor = Color.SkyBlue;
      this.txtMatkhau.LineIdleColor = Color.Gray;
      this.txtMatkhau.LineMouseHoverColor = Color.SkyBlue;
      this.txtMatkhau.LineThickness = 1;
      this.txtMatkhau.Location = new Point(164, 323);
      this.txtMatkhau.Margin = new Padding(5, 4, 5, 4);
      this.txtMatkhau.Name = "txtMatkhau";
      this.txtMatkhau.Size = new Size(231, 30);
      this.txtMatkhau.TabIndex = 3;
      this.txtMatkhau.Text = "Mật khẩu";
      this.txtMatkhau.TextAlign = HorizontalAlignment.Left;
      this.txtEmail.Cursor = Cursors.IBeam;
      this.txtEmail.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEmail.ForeColor = Color.Black;
      this.txtEmail.HintForeColor = Color.Empty;
      this.txtEmail.HintText = "";
      this.txtEmail.isPassword = false;
      this.txtEmail.LineFocusedColor = Color.SkyBlue;
      this.txtEmail.LineIdleColor = Color.Gray;
      this.txtEmail.LineMouseHoverColor = Color.SkyBlue;
      this.txtEmail.LineThickness = 1;
      this.txtEmail.Location = new Point(164, 276);
      this.txtEmail.Margin = new Padding(5, 4, 5, 4);
      this.txtEmail.Name = "txtEmail";
      this.txtEmail.Size = new Size(334, 30);
      this.txtEmail.TabIndex = 2;
      this.txtEmail.Text = "Địa chỉ email";
      this.txtEmail.TextAlign = HorizontalAlignment.Left;
      this.txtEmail.OnValueChanged += new EventHandler(this.txtEmail_OnValueChanged);
      this.txtTendangnhap.Cursor = Cursors.IBeam;
      this.txtTendangnhap.Enabled = false;
      this.txtTendangnhap.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtTendangnhap.ForeColor = Color.Black;
      this.txtTendangnhap.HintForeColor = Color.Empty;
      this.txtTendangnhap.HintText = "";
      this.txtTendangnhap.isPassword = false;
      this.txtTendangnhap.LineFocusedColor = Color.SkyBlue;
      this.txtTendangnhap.LineIdleColor = Color.Gray;
      this.txtTendangnhap.LineMouseHoverColor = Color.SkyBlue;
      this.txtTendangnhap.LineThickness = 1;
      this.txtTendangnhap.Location = new Point(164, 229);
      this.txtTendangnhap.Margin = new Padding(5, 4, 5, 4);
      this.txtTendangnhap.Name = "txtTendangnhap";
      this.txtTendangnhap.Size = new Size(261, 30);
      this.txtTendangnhap.TabIndex = 1;
      this.txtTendangnhap.Text = "Tên đăng nhập";
      this.txtTendangnhap.TextAlign = HorizontalAlignment.Left;
      this.txtHovaten.Cursor = Cursors.IBeam;
      this.txtHovaten.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtHovaten.ForeColor = Color.Black;
      this.txtHovaten.HintForeColor = Color.Empty;
      this.txtHovaten.HintText = "";
      this.txtHovaten.isPassword = false;
      this.txtHovaten.LineFocusedColor = Color.SkyBlue;
      this.txtHovaten.LineIdleColor = Color.Gray;
      this.txtHovaten.LineMouseHoverColor = Color.SkyBlue;
      this.txtHovaten.LineThickness = 1;
      this.txtHovaten.Location = new Point(164, 182);
      this.txtHovaten.Margin = new Padding(4);
      this.txtHovaten.Name = "txtHovaten";
      this.txtHovaten.Size = new Size(201, 30);
      this.txtHovaten.TabIndex = 0;
      this.txtHovaten.Text = "Họ và tên";
      this.txtHovaten.TextAlign = HorizontalAlignment.Left;
      this.btnCapnhat.ActiveBorderThickness = 1;
      this.btnCapnhat.ActiveCornerRadius = 20;
      this.btnCapnhat.ActiveFillColor = Color.DodgerBlue;
      this.btnCapnhat.ActiveForecolor = Color.White;
      this.btnCapnhat.ActiveLineColor = Color.DodgerBlue;
      this.btnCapnhat.BackColor = Color.White;
      this.btnCapnhat.BackgroundImage = (Image) componentResourceManager.GetObject("btnCapnhat.BackgroundImage");
      this.btnCapnhat.ButtonText = "Cập nhật";
      this.btnCapnhat.Cursor = Cursors.Hand;
      this.btnCapnhat.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnCapnhat.ForeColor = Color.Black;
      this.btnCapnhat.IdleBorderThickness = 1;
      this.btnCapnhat.IdleCornerRadius = 20;
      this.btnCapnhat.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnCapnhat.IdleForecolor = Color.White;
      this.btnCapnhat.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnCapnhat.Location = new Point(164, 449);
      this.btnCapnhat.Margin = new Padding(6, 5, 6, 5);
      this.btnCapnhat.Name = "btnCapnhat";
      this.btnCapnhat.Size = new Size(169, 34);
      this.btnCapnhat.TabIndex = 7;
      this.btnCapnhat.TextAlign = ContentAlignment.MiddleCenter;
      this.btnCapnhat.Click += new EventHandler(this.BtnCapnhatClick);
      this.bunifuCustomLabel8.AutoSize = true;
      this.bunifuCustomLabel8.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel8.ForeColor = Color.DimGray;
      this.bunifuCustomLabel8.Location = new Point(20, 192);
      this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
      this.bunifuCustomLabel8.Size = new Size(69, 17);
      this.bunifuCustomLabel8.TabIndex = 32;
      this.bunifuCustomLabel8.Text = "Họ và tên";
      this.bunifuCustomLabel7.AutoSize = true;
      this.bunifuCustomLabel7.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel7.ForeColor = Color.DimGray;
      this.bunifuCustomLabel7.Location = new Point(20, 423);
      this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
      this.bunifuCustomLabel7.Size = new Size(72, 17);
      this.bunifuCustomLabel7.TabIndex = 29;
      this.bunifuCustomLabel7.Text = "Ngày sinh";
      this.bunifuCustomLabel6.AutoSize = true;
      this.bunifuCustomLabel6.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel6.ForeColor = Color.DimGray;
      this.bunifuCustomLabel6.Location = new Point(20, 376);
      this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
      this.bunifuCustomLabel6.Size = new Size(92, 17);
      this.bunifuCustomLabel6.TabIndex = 27;
      this.bunifuCustomLabel6.Text = "Số điện thoại";
      this.bunifuCustomLabel5.AutoSize = true;
      this.bunifuCustomLabel5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel5.ForeColor = Color.DimGray;
      this.bunifuCustomLabel5.Location = new Point(20, 330);
      this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
      this.bunifuCustomLabel5.Size = new Size(66, 17);
      this.bunifuCustomLabel5.TabIndex = 25;
      this.bunifuCustomLabel5.Text = "Mật khẩu";
      this.bunifuCustomLabel4.AutoSize = true;
      this.bunifuCustomLabel4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel4.ForeColor = Color.DimGray;
      this.bunifuCustomLabel4.Location = new Point(20, 284);
      this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
      this.bunifuCustomLabel4.Size = new Size(45, 17);
      this.bunifuCustomLabel4.TabIndex = 23;
      this.bunifuCustomLabel4.Text = "Email";
      this.bunifuCustomLabel3.AutoSize = true;
      this.bunifuCustomLabel3.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel3.ForeColor = Color.DimGray;
      this.bunifuCustomLabel3.Location = new Point(19, 88);
      this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
      this.bunifuCustomLabel3.Size = new Size(87, 17);
      this.bunifuCustomLabel3.TabIndex = 21;
      this.bunifuCustomLabel3.Text = "Ảnh đại diện";
      this.picAvatar.BackgroundImage = (Image) componentResourceManager.GetObject("picAvatar.BackgroundImage");
      this.picAvatar.BackgroundImageLayout = ImageLayout.Zoom;
      this.picAvatar.ErrorImage = (Image) null;
      this.picAvatar.InitialImage = (Image) null;
      this.picAvatar.Location = new Point(164, 47);
      this.picAvatar.Name = "picAvatar";
      this.picAvatar.Size = new Size(130, 128);
      this.picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
      this.picAvatar.TabIndex = 19;
      this.picAvatar.TabStop = false;
      this.bunifuCustomLabel2.AutoSize = true;
      this.bunifuCustomLabel2.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuCustomLabel2.ForeColor = Color.DimGray;
      this.bunifuCustomLabel2.Location = new Point(20, 238);
      this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
      this.bunifuCustomLabel2.Size = new Size(105, 17);
      this.bunifuCustomLabel2.TabIndex = 20;
      this.bunifuCustomLabel2.Text = "Tên đăng nhập";
      this.timerThoiHanSuDung.Enabled = true;
      this.timerThoiHanSuDung.Interval = 50;
      this.timerThoiHanSuDung.Tick += new EventHandler(this.TimerThoiHanSuDungTick);
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.BackgroundWorker1DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackgroundWorker1RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.bunifuSeparator1);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (TabInfoUser);
      this.Size = new Size(1339, 639);
      this.Load += new EventHandler(this.TabInfoUserLoad);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.bunifuImageButton1.EndInit();
      this.panel7.ResumeLayout(false);
      this.panel6.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      ((ISupportInitialize) this.picAvatar).EndInit();
      this.ResumeLayout(false);
    }
  }
}
