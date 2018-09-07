// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FLossPw
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class FLossPw : Form
  {
    private IContainer components = (IContainer) null;
    private BunifuElipse bunifuElipse1;
    private Panel panel1;
    private Panel panel2;
    private PictureBox pictureBox5;
    private PictureBox pictureBox4;
    private BunifuThinButton2 bunifuThinButton21;
    private LinkLabel linkLabel1;
    private BunifuMaterialTextbox txtEmail;
    private Label label1;
    private PictureBox pictureBox2;
    private PictureBox picMainTop;
    private LinkLabel linkLabel2;
    private BunifuImageButton bunifuImageButton3;

    public FLossPw()
    {
      this.InitializeComponent();
    }

    private void txtPassword_OnValueChanged(object sender, EventArgs e)
    {
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Hide();
      int num = (int) new FLogin().ShowDialog();
    }

    private void bunifuThinButton21_Click(object sender, EventArgs e)
    {
      this.XuLy();
    }

    private void XuLy()
    {
      int num1 = new Random().Next(10000, 99999);
      string message = "Mật khẩu tạm thời của bạn \n" + (object) num1;
      tbConServerEmail infor = new tbConServerEmail().GetInfor();
      if (new TbUser().SendPassTam(this.txtEmail.Text, num1.ToString()) == 1)
      {
        if (ClMain.SendEmail(this.txtEmail.Text, "[1386.com] Thay đổi thông tin tài khoản", message, infor.email, infor.pass, infor.host, Convert.ToInt32(infor.port)))
        {
          int num2 = (int) MessageBox.Show(Resources.FLossPw_XuLy_MẬT_KHẨU_MỚI_ĐÃ_ĐƯỢC_GỬI_ĐẾN_EMAIL_CỦA_BẠN, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.Hide();
          int num3 = (int) new FLogin().ShowDialog();
          this.Insert_Message();
        }
        else
        {
          int num4 = (int) MessageBox.Show(Resources.FLossPw_XuLy_KHÔNG_GỬI_ĐƯỢC_EMAIL_XÁC_NHẬN, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      else
      {
        int num5 = (int) MessageBox.Show(Resources.FLossPw_XuLy_KHÔNG_GỬI_MẬT_KHẨU_MỚI_ĐẾN_EMAIL_NÀY, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void Insert_Message()
    {
      tbMessage tbMessage = new tbMessage();
      tbMessage.NguoiGui = "Administrator";
      tbMessage.NguoiNhan = TbUser.Tbuser.TenDangnhap;
      tbMessage.TieuDe = "Mua thêm ngày sử dụng";
      tbMessage.NoiDung = "Bạn vừa yêu cầu đổi mật khẩu thành công !!!";
      tbMessage.Insert(tbMessage);
    }

    private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.XuLy();
    }

    private void picMainTop_MouseDown(object sender, MouseEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FLossPw));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel2 = new Panel();
      this.linkLabel2 = new LinkLabel();
      this.pictureBox5 = new PictureBox();
      this.pictureBox4 = new PictureBox();
      this.bunifuThinButton21 = new BunifuThinButton2();
      this.linkLabel1 = new LinkLabel();
      this.txtEmail = new BunifuMaterialTextbox();
      this.label1 = new Label();
      this.pictureBox2 = new PictureBox();
      this.panel1 = new Panel();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.picMainTop = new PictureBox();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.panel1.SuspendLayout();
      this.bunifuImageButton3.BeginInit();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 10;
      this.bunifuElipse1.TargetControl = (Control) this.panel2;
      this.panel2.BackColor = Color.White;
      this.panel2.Controls.Add((Control) this.linkLabel2);
      this.panel2.Controls.Add((Control) this.pictureBox5);
      this.panel2.Controls.Add((Control) this.pictureBox4);
      this.panel2.Controls.Add((Control) this.bunifuThinButton21);
      this.panel2.Controls.Add((Control) this.linkLabel1);
      this.panel2.Controls.Add((Control) this.txtEmail);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.pictureBox2);
      this.panel2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel2.Location = new Point(69, 20);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(558, 252);
      this.panel2.TabIndex = 9;
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel2.LinkColor = Color.Red;
      this.linkLabel2.Location = new Point(88, 224);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(405, 17);
      this.linkLabel2.TabIndex = 3;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = ">> mật khẩu mới sẽ được gửi vào Email đăng ký của bạn <<";
      this.pictureBox5.Image = (Image) componentResourceManager.GetObject("pictureBox5.Image");
      this.pictureBox5.Location = new Point(193, 191);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(18, 18);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox5.TabIndex = 8;
      this.pictureBox5.TabStop = false;
      this.pictureBox4.Image = (Image) componentResourceManager.GetObject("pictureBox4.Image");
      this.pictureBox4.Location = new Point(86, 133);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(25, 25);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox4.TabIndex = 7;
      this.pictureBox4.TabStop = false;
      this.bunifuThinButton21.ActiveBorderThickness = 1;
      this.bunifuThinButton21.ActiveCornerRadius = 20;
      this.bunifuThinButton21.ActiveFillColor = Color.DodgerBlue;
      this.bunifuThinButton21.ActiveForecolor = Color.White;
      this.bunifuThinButton21.ActiveLineColor = Color.DodgerBlue;
      this.bunifuThinButton21.BackColor = Color.White;
      this.bunifuThinButton21.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
      this.bunifuThinButton21.ButtonText = "Tiếp tục";
      this.bunifuThinButton21.Cursor = Cursors.Hand;
      this.bunifuThinButton21.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton21.ForeColor = Color.Black;
      this.bunifuThinButton21.IdleBorderThickness = 1;
      this.bunifuThinButton21.IdleCornerRadius = 20;
      this.bunifuThinButton21.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.IdleForecolor = Color.White;
      this.bunifuThinButton21.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.Location = new Point(221, 178);
      this.bunifuThinButton21.Margin = new Padding(6, 5, 6, 5);
      this.bunifuThinButton21.Name = "bunifuThinButton21";
      this.bunifuThinButton21.Size = new Size(265, 40);
      this.bunifuThinButton21.TabIndex = 1;
      this.bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton21.Click += new EventHandler(this.bunifuThinButton21_Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(114, 189);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(79, 17);
      this.linkLabel1.TabIndex = 2;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Đăng nhập";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.txtEmail.Cursor = Cursors.IBeam;
      this.txtEmail.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEmail.ForeColor = Color.FromArgb(53, 73, 106);
      this.txtEmail.HintForeColor = Color.DimGray;
      this.txtEmail.HintText = "nhập vào địa chỉ email của bạn";
      this.txtEmail.isPassword = false;
      this.txtEmail.LineFocusedColor = Color.FromArgb(81, 164, 227);
      this.txtEmail.LineIdleColor = Color.Gray;
      this.txtEmail.LineMouseHoverColor = Color.FromArgb(81, 164, 227);
      this.txtEmail.LineThickness = 3;
      this.txtEmail.Location = new Point(117, 128);
      this.txtEmail.Margin = new Padding(5);
      this.txtEmail.Name = "txtEmail";
      this.txtEmail.Size = new Size(368, 35);
      this.txtEmail.TabIndex = 0;
      this.txtEmail.TextAlign = HorizontalAlignment.Left;
      this.txtEmail.OnValueChanged += new EventHandler(this.txtPassword_OnValueChanged);
      this.txtEmail.KeyPress += new KeyPressEventHandler(this.txtEmail_KeyPress);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.label1.ForeColor = SystemColors.ControlDarkDark;
      this.label1.Location = new Point(231, 72);
      this.label1.Name = "label1";
      this.label1.Size = new Size(106, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Quên Mật Khẩu";
      this.pictureBox2.Image = (Image) componentResourceManager.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(253, 8);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(55, 55);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      this.panel1.BackColor = Color.FromArgb(232, 232, 236);
      this.panel1.Controls.Add((Control) this.bunifuImageButton3);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.picMainTop);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(700, 290);
      this.panel1.TabIndex = 0;
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(673, 2);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(25, 25);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 10;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(700, 154);
      this.picMainTop.TabIndex = 8;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.picMainTop_MouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(700, 290);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FLossPw);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Quên mật khẩu";
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.pictureBox5).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.panel1.ResumeLayout(false);
      this.bunifuImageButton3.EndInit();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.ResumeLayout(false);
    }
  }
}
