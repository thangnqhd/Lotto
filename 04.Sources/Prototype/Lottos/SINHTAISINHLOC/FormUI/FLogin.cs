// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FLogin
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using myStruct;
using ns1;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class FLogin : Form
  {
    public static string PublicIp = "127.0.0.1";
    public static int StatusChat = 0;
    public static bool ConnectStatus = false;
    public static string _version = "";
    public static string _newVersion = "";
    public static bool RefreshChat = false;
    public static string _msgFormServer = "";
    public static bool _reconnectochat = false;
    public static Decimal _countChat = new Decimal();
    public static string MsgId = "";
    public static string LogOutStatus = "0";
    public static string ErrorMsg = "";
    public static string ErrorMsgInfo = "";
    private IContainer components = (IContainer) null;
    public TbUser User;
    private string[] _msg;
    private TbUser objUser;
    private Structure _structure;
    private const uint WmClose = 16;
    public static string MacAddress;
    private readonly System.Windows.Forms.Timer _tm;
    private BunifuElipse bunifuElipse2;
    private LinkLabel linkLabel1;
    private BunifuImageButton bunifuImageButton3;
    private BackgroundWorker backgroundWorker1;
    private Panel panel2;
    private Panel panel1;
    private PictureBox picLoading;
    private BunifuThinButton2 bunifuThinButton21;
    private LinkLabel linkLabel2;
    private PictureBox pictureBox4;
    private PictureBox pictureBox3;
    private Label label1;
    private PictureBox pictureBox2;
    private BunifuMaterialTextbox txtPass;
    public BunifuMaterialTextbox txtUsername;
    private ToolTip toolTip1;

    public static string IDC { get; set; }

    public static ClientSettings.ClientSettings Client { get; set; }

    public FLogin()
    {
      this._tm = new System.Windows.Forms.Timer() { Interval = 100 };
      this.InitializeComponent();
      this.objUser = new TbUser();
      FLogin._version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
      this._tm.Start();
      this._tm.Tick += new EventHandler(this.TmTick);
      if (!FLogin.ConnectStatus)
        this.ConnectToServer();
      if (!FLogin.ConnectStatus)
      {
        int num = (int) MessageBox.Show(Resources.FLogin_FLogin_KHÔNG_THỂ_KẾT_NỐI_TỚI_MÁY_CHỦ__VUI_LÒNG_THỬ_LẠI_SAU, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Environment.Exit(0);
      }
      FLogin.IDC = FingerPrint.GetIDCValue();
    }

    public void ConnectToServer()
    {
      FLogin.Client = new ClientSettings.ClientSettings();
      if (FLogin.Client.Connect(FMain.IpServer, FMain.PortServer))
      {
        FLogin.Client.Disconnected += new ClientSettings.ClientSettings.DisconnectedEventHandler(FLogin.Client_Disconnected);
        FLogin.Client.Received += new ClientSettings.ClientSettings.ReceivedEventHandler(this.ClientReceived);
        FLogin.ConnectStatus = true;
      }
      else
        FLogin.ConnectStatus = false;
    }

    public static void Client_Disconnected(ClientSettings.ClientSettings cs)
    {
    }

    public void ClientReceived(ClientSettings.ClientSettings cs, Structure struc)
    {
      string sendType = struc.SendType;
      if (!(sendType == "SendConnection"))
      {
        if (!(sendType == "ControlFormServer"))
        {
          if (!(sendType == "UpdateData"))
          {
            if (!(sendType == "LoadLaiForm"))
              return;
            Program.Invoke(this, (Action) (() => FMain.LoadLaiForm = 1));
          }
          else
            Program.Invoke(this, (Action) (() => FMain.UpdateKetqua()));
        }
        else
          Program.Invoke(this, (Action) (() => FLogin.BienDichMaDieuKhienTuSever(struc)));
      }
      else
        Program.Invoke(this, (Action) (() =>
        {
          try
          {
            ClMain._strConData = struc.TextChat.Split(';')[0];
            ClMain._strConUser = struc.TextChat.Split(';')[1];
            ClMain._strkey = struc.TextChat.Split(';')[2];
            FLogin._newVersion = struc.VersionClient;
            sqlConnection._strConData = ClMain._strConData;
            sqlConnection._strConUser = ClMain._strConUser;
            sqlConnection._strkey = ClMain._strkey;
          }
          catch
          {
            FLogin.MsgId = "024";
            FLogin.LogOutStatus = "1";
          }
        }));
    }

    public static void BienDichMaDieuKhienTuSever(Structure _structure)
    {
      if (_structure.LogOutStatus == "001")
      {
        Process.Start(_structure.TextChat);
      }
      else
      {
        FLogin.LogOutStatus = _structure.LogOutStatus;
        FLogin._msgFormServer = _structure.TextChat;
        FLogin._version = _structure.VersionClient;
        FLogin.MsgId = "023";
      }
    }

    public static string StrListUser { get; set; }

    public static string StrChat { get; set; }

    private void ClientConnected(object sender, EventArgs e)
    {
      this._structure = new Structure();
      this._structure.Username = this.txtUsername.Text;
      this._structure.SendTo = "Server";
      this._structure.SendType = "Connect";
      this._structure.TextChat = "connected";
      this._structure.VersionClient = FLogin._version;
      FLogin.Client.Send(this._structure);
    }

    private void TmTick(object sender, EventArgs e)
    {
      if (FLogin.MsgId != "")
        this.ProccessMsg(FLogin._msgFormServer, FLogin.MsgId, FLogin.LogOutStatus);
      this.picLoading.Visible = this.backgroundWorker1.IsBusy;
    }

    private void ProccessMsg(string mmsgServer, string idMsg, string loStatus)
    {
      try
      {
        FLogin.MsgId = "";
        FLogin.LogOutStatus = "0";
        this._msg = ClMain.Get_Msg(idMsg);
      }
      catch (Exception ex)
      {
        this._msg = ClMain.Get_Msg("009");
      }
      FLogin.ErrorMsg = this._msg[1];
      if (mmsgServer != "")
        FLogin.ErrorMsg = FLogin._msgFormServer;
      FLogin.ErrorMsgInfo = this._msg[2];
      this.ShowAutoClosingMessageBox(FLogin.ErrorMsg, FLogin.ErrorMsgInfo, loStatus);
      FLogin._msgFormServer = "";
    }

    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
    private static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);

    [DllImport("user32.Dll")]
    private static extern int PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

    public void ShowAutoClosingMessageBox(string message, string caption, string loStatus)
    {
      if (loStatus == "1")
      {
        System.Timers.Timer timer = new System.Timers.Timer(5000.0)
        {
          AutoReset = false
        };
        timer.Elapsed += (ElapsedEventHandler) ((_param1, _param2) =>
        {
          IntPtr windowByCaption = FLogin.FindWindowByCaption(IntPtr.Zero, caption);
          if ((uint) windowByCaption.ToInt32() <= 0U)
            return;
          FLogin.PostMessage(windowByCaption, 16U, 0, 0);
        });
        timer.Enabled = true;
      }
      if (MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
      {
        IntPtr windowByCaption = FLogin.FindWindowByCaption(IntPtr.Zero, caption);
        if ((uint) windowByCaption.ToInt32() > 0U)
          FLogin.PostMessage(windowByCaption, 16U, 0, 0);
      }
      if (!(loStatus == "1"))
        return;
      Environment.Exit(1);
    }

    private void FLoginLoad(object sender, EventArgs e)
    {
    }

    private void LinkLabel1LinkClicked1(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!(ClMain._strConData != "") || !(ClMain._strConUser != "") || !(ClMain._strkey != ""))
        return;
      FSignup fsignup = new FSignup();
      this.Hide();
      int num = (int) fsignup.ShowDialog();
    }

    private void BunifuImageButton3Click(object sender, EventArgs e)
    {
      Environment.Exit(0);
    }

    private void Panel1Paint1(object sender, PaintEventArgs e)
    {
    }

    private void BunifuThinButton21Click2(object sender, EventArgs e)
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private bool checkConnectSql()
    {
      if (ClMain._strConData == "" || ClMain._strConUser == "" || ClMain._strkey == "")
        return false;
      bool flag = true;
      try
      {
        if (FLogin.PublicIp != "")
        {
          tbLogin.PublicIp = FLogin.PublicIp;
          tbConfigApp tbConfigApp = new tbConfigApp();
          FMain.ConfigApp = new tbConfigApp();
          FMain.ConfigApp = tbConfigApp.GetInfoApp();
          tbConfigApp.configApp = FMain.ConfigApp;
        }
        else
          flag = false;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    public void CheckLogin()
    {
      if (this.checkConnectSql())
      {
        this.User = new TbUser();
        if (this.txtUsername.Text.Length > 5 && this.txtPass.Text.Length > 5)
        {
          this.UpdateIDC(this.txtUsername.Text);
          this.User.MatKhau = ClMain.Encrypt(this.txtPass.Text, FMain.ConfigApp.keyUser);
          if (!(tbConfigApp.configApp.useIDC == "False") ? this.User.GetInforUser_IDC(this.txtUsername.Text, this.User.MatKhau, FLogin.IDC) : this.User.GetInforUser(this.txtUsername.Text, this.User.MatKhau))
          {
            try
            {
              FLogin.MacAddress = tbLogin.GetMacAddress();
              this._structure = new Structure();
              this._structure.Username = this.txtUsername.Text;
              this._structure.SendTo = FLogin.IDC + "|" + FLogin.MacAddress;
              this._structure.SendType = "Connect";
              this._structure.TextChat = "connected";
              this._structure.VersionClient = FLogin._version;
              FLogin.Client.Send(this._structure);
              if (TbUser.Tbuser.TrangThaiKickHoat == 1 && TbUser.Tbuser.TrangthaiSudung == "sudung" && (TbUser.Tbuser.PhanQuyen == "user" || TbUser.Tbuser.PhanQuyen == "cms"))
              {
                this.Invoke((Delegate) new Action(((Control) this).Hide));
                ClMain.tune_Thongbao("online.wav");
              }
              else
              {
                FLogin.MsgId = "008";
                FLogin.LogOutStatus = "1";
              }
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show(Resources.FLogin_CheckLogin_Không_lấy_được_thông_tin_hệ_thống__Vui_lòng_tải_phiên_bản_mới_nhất__, Resources.tbConfigApp_Get_Info_App_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
          }
          else
          {
            FLogin.MsgId = "007";
            FLogin.LogOutStatus = "0";
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show(Resources.FLogin_CheckLogin_Vui_lòng_nhập_chính_xác_tên_đăng_nhập_và_mật_khẩu_đã_đăng_ký__, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      else
        FLogin.MsgId = "020";
    }

    private void TxtPassEnter(object sender, EventArgs e)
    {
    }

    private void TxtPassKeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r' || this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void TxtUsernameMouseClick1(object sender, MouseEventArgs e)
    {
      if (this.txtUsername.Text.Length <= 0 || !(this.txtUsername.Text == Resources.FLogin_TxtUsernameMouseClick1_Tên_đăng_nhập_hoặc_Email))
        return;
      this.txtUsername.Text = "";
    }

    private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Hide();
      int num = (int) new FLossPw().ShowDialog();
    }

    private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
    {
      this.CheckLogin();
    }

    private void UpdateIDC(string username)
    {
      this.objUser.UpdateIDC(username, FLogin.IDC);
    }

    private void FLoginMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FLogin));
      this.bunifuElipse2 = new BunifuElipse(this.components);
      this.panel1 = new Panel();
      this.linkLabel1 = new LinkLabel();
      this.picLoading = new PictureBox();
      this.bunifuThinButton21 = new BunifuThinButton2();
      this.txtPass = new BunifuMaterialTextbox();
      this.txtUsername = new BunifuMaterialTextbox();
      this.pictureBox4 = new PictureBox();
      this.pictureBox3 = new PictureBox();
      this.label1 = new Label();
      this.pictureBox2 = new PictureBox();
      this.linkLabel2 = new LinkLabel();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.backgroundWorker1 = new BackgroundWorker();
      this.panel2 = new Panel();
      this.toolTip1 = new ToolTip(this.components);
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.bunifuElipse2.ElipseRadius = 10;
      this.bunifuElipse2.TargetControl = (Control) this.panel1;
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.picLoading);
      this.panel1.Controls.Add((Control) this.bunifuThinButton21);
      this.panel1.Controls.Add((Control) this.txtPass);
      this.panel1.Controls.Add((Control) this.txtUsername);
      this.panel1.Controls.Add((Control) this.pictureBox4);
      this.panel1.Controls.Add((Control) this.pictureBox3);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.pictureBox2);
      this.panel1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.panel1.Location = new Point(120, 52);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(520, 256);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new PaintEventHandler(this.Panel1Paint1);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Cursor = Cursors.Hand;
      this.linkLabel1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(91, 220);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(51, 15);
      this.linkLabel1.TabIndex = 3;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Đăng ký";
      this.toolTip1.SetToolTip((Control) this.linkLabel1, "Đăng ký tài khoản mới");
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked1);
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(246, 142);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(27, 27);
      this.picLoading.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picLoading.TabIndex = 60;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.bunifuThinButton21.ActiveBorderThickness = 1;
      this.bunifuThinButton21.ActiveCornerRadius = 20;
      this.bunifuThinButton21.ActiveFillColor = Color.DodgerBlue;
      this.bunifuThinButton21.ActiveForecolor = Color.Transparent;
      this.bunifuThinButton21.ActiveLineColor = Color.DodgerBlue;
      this.bunifuThinButton21.BackColor = Color.White;
      this.bunifuThinButton21.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
      this.bunifuThinButton21.ButtonText = "Đăng nhập";
      this.bunifuThinButton21.Cursor = Cursors.Hand;
      this.bunifuThinButton21.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton21.ForeColor = Color.Black;
      this.bunifuThinButton21.IdleBorderThickness = 1;
      this.bunifuThinButton21.IdleCornerRadius = 20;
      this.bunifuThinButton21.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.IdleForecolor = Color.White;
      this.bunifuThinButton21.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.Location = new Point(146, 207);
      this.bunifuThinButton21.Margin = new Padding(8, 6, 8, 6);
      this.bunifuThinButton21.Name = "bunifuThinButton21";
      this.bunifuThinButton21.Size = new Size(308, 40);
      this.bunifuThinButton21.TabIndex = 2;
      this.bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.bunifuThinButton21, "Đăng nhập");
      this.bunifuThinButton21.Click += new EventHandler(this.BunifuThinButton21Click2);
      this.txtPass.Cursor = Cursors.IBeam;
      this.txtPass.Font = new Font("Bookman Old Style", 12f);
      this.txtPass.ForeColor = Color.DimGray;
      this.txtPass.HintForeColor = Color.DimGray;
      this.txtPass.HintText = "Mật khẩu của bạn";
      this.txtPass.isPassword = true;
      this.txtPass.LineFocusedColor = Color.Red;
      this.txtPass.LineIdleColor = SystemColors.GrayText;
      this.txtPass.LineMouseHoverColor = Color.Red;
      this.txtPass.LineThickness = 1;
      this.txtPass.Location = new Point(94, 159);
      this.txtPass.Margin = new Padding(5, 6, 5, 6);
      this.txtPass.Name = "txtPass";
      this.txtPass.Size = new Size(360, 35);
      this.txtPass.TabIndex = 1;
      this.txtPass.Text = "*****";
      this.txtPass.TextAlign = HorizontalAlignment.Left;
      this.txtPass.Enter += new EventHandler(this.TxtPassEnter);
      this.txtPass.KeyPress += new KeyPressEventHandler(this.TxtPassKeyPress);
      this.txtUsername.Cursor = Cursors.IBeam;
      this.txtUsername.Font = new Font("Bookman Old Style", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtUsername.ForeColor = Color.DimGray;
      this.txtUsername.HintForeColor = Color.DimGray;
      this.txtUsername.HintText = "Tên đăng nhập hoặc email";
      this.txtUsername.isPassword = false;
      this.txtUsername.LineFocusedColor = Color.Red;
      this.txtUsername.LineIdleColor = Color.Gray;
      this.txtUsername.LineMouseHoverColor = Color.Red;
      this.txtUsername.LineThickness = 1;
      this.txtUsername.Location = new Point(93, 102);
      this.txtUsername.Margin = new Padding(5, 6, 5, 6);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new Size(361, 35);
      this.txtUsername.TabIndex = 0;
      this.txtUsername.TextAlign = HorizontalAlignment.Left;
      this.txtUsername.MouseClick += new MouseEventHandler(this.TxtUsernameMouseClick1);
      this.pictureBox4.Image = (Image) componentResourceManager.GetObject("pictureBox4.Image");
      this.pictureBox4.Location = new Point(61, 163);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(25, 25);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox4.TabIndex = 7;
      this.pictureBox4.TabStop = false;
      this.pictureBox3.Image = (Image) componentResourceManager.GetObject("pictureBox3.Image");
      this.pictureBox3.Location = new Point(63, 108);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(25, 25);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox3.TabIndex = 6;
      this.pictureBox3.TabStop = false;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.ControlDarkDark;
      this.label1.Location = new Point(193, 63);
      this.label1.Name = "label1";
      this.label1.Size = new Size(146, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "HỘI VIÊN ĐĂNG NHẬP";
      this.pictureBox2.Image = (Image) componentResourceManager.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(236, 3);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(55, 55);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.Cursor = Cursors.Hand;
      this.linkLabel2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel2.LinkColor = Color.DodgerBlue;
      this.linkLabel2.Location = new Point(646, 152);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(97, 16);
      this.linkLabel2.TabIndex = 4;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "Quên mật khẩu";
      this.linkLabel2.Visible = false;
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel2LinkClicked);
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(731, 1);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(23, 23);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 9;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 10;
      this.bunifuImageButton3.Click += new EventHandler(this.BunifuImageButton3Click);
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.BackgroundWorker1DoWork);
      this.panel2.BackColor = Color.FromArgb(236, 238, 245);
      this.panel2.Controls.Add((Control) this.linkLabel2);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 177);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(755, 182);
      this.panel2.TabIndex = 10;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(27, 40, 61);
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(755, 359);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.DoubleBuffered = true;
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FLogin);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Đăng nhập";
      this.Load += new EventHandler(this.FLoginLoad);
      this.MouseDown += new MouseEventHandler(this.FLoginMouseDown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.bunifuImageButton3.EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
