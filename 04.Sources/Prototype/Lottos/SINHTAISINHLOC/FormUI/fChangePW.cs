// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.fChangePW
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
  public class fChangePW : Form
  {
    private IContainer components = (IContainer) null;
    public string[] msg;
    private BunifuElipse bunifuElipse1;
    private Panel panel1;
    private Panel panel2;
    private PictureBox picMainTop;
    private BunifuImageButton bunifuImageButton3;
    private Label label4;
    private Label label3;
    private Label label2;
    private BunifuMaterialTextbox txtPassReEnter;
    private BunifuMaterialTextbox txtPassNew;
    private BunifuThinButton2 bunifuThinButton21;
    private LinkLabel linkLabel1;
    private BunifuMaterialTextbox txtPasswordOld;
    private Label label1;
    private PictureBox pictureBox2;
    private Label lblThongbao;

    public fChangePW()
    {
      this.InitializeComponent();
    }

    private void txtPassword_OnValueChanged(object sender, EventArgs e)
    {
    }

    private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
    {
    }

    private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
    {
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Close();
    }

    private void bunifuThinButton21_Click(object sender, EventArgs e)
    {
      if (this.txtPasswordOld.Text.Length > 0)
      {
        if (ClMain.Encrypt(this.txtPasswordOld.Text, tbConfigApp.configApp.KeyUser) == TbUser.Tbuser.MatKhau)
        {
          this.lblThongbao.Visible = false;
        }
        else
        {
          this.msg = ClMain.Get_Msg("012");
          this.lblThongbao.Visible = true;
          this.lblThongbao.Text = this.msg[1];
          this.txtPasswordOld.Focus();
        }
      }
      else
      {
        this.lblThongbao.Visible = true;
        this.lblThongbao.Text = Resources.fChangePW_txtPassword_OnValueChanged_Nhập_mật_khẩu_cũ_của_bạn;
        this.txtPasswordOld.Focus();
      }
      if (this.txtPassNew.Text.Length > 0)
      {
        if (TbUser.Tbuser.IsPassWordAllowed(this.txtPassNew.Text))
        {
          this.lblThongbao.Visible = false;
        }
        else
        {
          this.msg = ClMain.Get_Msg("004");
          this.lblThongbao.Visible = true;
          this.lblThongbao.Text = this.msg[1];
          this.txtPassNew.Focus();
        }
      }
      else
      {
        this.lblThongbao.Visible = true;
        this.lblThongbao.Text = Resources.fChangePW_bunifuMaterialTextbox1_OnValueChanged_Nhập_mật_khẩu_mơi;
        this.txtPassNew.Focus();
      }
      if (this.txtPassReEnter.Text.Length > 0)
      {
        if (this.txtPassNew.Text == this.txtPassReEnter.Text)
        {
          this.lblThongbao.Visible = false;
        }
        else
        {
          this.msg = ClMain.Get_Msg("013");
          this.lblThongbao.Visible = true;
          this.lblThongbao.Text = this.msg[1];
          this.txtPassReEnter.Focus();
        }
      }
      else
      {
        this.lblThongbao.Visible = true;
        this.lblThongbao.Text = Resources.fChangePW_bunifuMaterialTextbox1_OnValueChanged_Nhập_mật_khẩu_mơi;
        this.txtPassReEnter.Focus();
      }
      this.Update_Pass();
    }

    public void Update_Pass()
    {
      if (ClMain.Encrypt(this.txtPasswordOld.Text, tbConfigApp.configApp.KeyUser) == TbUser.Tbuser.MatKhau)
      {
        this.lblThongbao.Visible = false;
        if (TbUser.Tbuser.IsPassWordAllowed(this.txtPassNew.Text))
        {
          this.lblThongbao.Visible = false;
          if (this.txtPassNew.Text == this.txtPassReEnter.Text)
          {
            this.lblThongbao.Visible = false;
            TbUser.Tbuser.MatKhau = ClMain.Encrypt(this.txtPassReEnter.Text, tbConfigApp.configApp.KeyUser);
            if (TbUser.Tbuser.Update(TbUser.Tbuser) != 1)
              return;
            this.msg = ClMain.Get_Msg("014");
            if (MessageBox.Show(this.msg[1], this.msg[2], MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
              this.Hide();
          }
          else
          {
            this.msg = ClMain.Get_Msg("013");
            this.lblThongbao.Visible = true;
            this.lblThongbao.Text = this.msg[1];
            this.txtPassReEnter.Focus();
          }
        }
        else
        {
          this.msg = ClMain.Get_Msg("004");
          this.lblThongbao.Visible = true;
          this.lblThongbao.Text = this.msg[1];
          this.txtPassNew.Focus();
        }
      }
      else
      {
        this.msg = ClMain.Get_Msg("012");
        this.lblThongbao.Visible = true;
        this.lblThongbao.Text = this.msg[1];
        this.txtPasswordOld.Focus();
      }
    }

    private void txtPassReEnter_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.Update_Pass();
    }

    private void txtPassNew_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.Update_Pass();
    }

    private void txtPasswordOld_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.Update_Pass();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (fChangePW));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel2 = new Panel();
      this.label4 = new Label();
      this.label3 = new Label();
      this.lblThongbao = new Label();
      this.label2 = new Label();
      this.txtPassReEnter = new BunifuMaterialTextbox();
      this.txtPassNew = new BunifuMaterialTextbox();
      this.bunifuThinButton21 = new BunifuThinButton2();
      this.linkLabel1 = new LinkLabel();
      this.txtPasswordOld = new BunifuMaterialTextbox();
      this.label1 = new Label();
      this.pictureBox2 = new PictureBox();
      this.picMainTop = new PictureBox();
      this.panel1 = new Panel();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.panel1.SuspendLayout();
      this.bunifuImageButton3.BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 10;
      this.bunifuElipse1.TargetControl = (Control) this.panel2;
      this.panel2.BackColor = Color.White;
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.lblThongbao);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Controls.Add((Control) this.txtPassReEnter);
      this.panel2.Controls.Add((Control) this.txtPassNew);
      this.panel2.Controls.Add((Control) this.bunifuThinButton21);
      this.panel2.Controls.Add((Control) this.linkLabel1);
      this.panel2.Controls.Add((Control) this.txtPasswordOld);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.pictureBox2);
      this.panel2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel2.Location = new Point(85, 21);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(596, 344);
      this.panel2.TabIndex = 9;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.FromArgb(53, 73, 106);
      this.label4.Location = new Point(28, 246);
      this.label4.Name = "label4";
      this.label4.Size = new Size((int) sbyte.MaxValue, 16);
      this.label4.TabIndex = 17;
      this.label4.Text = "Xác nhận mật khẩu :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.FromArgb(53, 73, 106);
      this.label3.Location = new Point(62, 185);
      this.label3.Name = "label3";
      this.label3.Size = new Size(97, 16);
      this.label3.TabIndex = 16;
      this.label3.Text = "Mật khẩu mới :";
      this.lblThongbao.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThongbao.ForeColor = Color.Red;
      this.lblThongbao.Location = new Point(164, 95);
      this.lblThongbao.Name = "lblThongbao";
      this.lblThongbao.Size = new Size(269, 15);
      this.lblThongbao.TabIndex = 15;
      this.lblThongbao.Text = "Thông báo:";
      this.lblThongbao.TextAlign = ContentAlignment.TopCenter;
      this.lblThongbao.Visible = false;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.FromArgb(53, 73, 106);
      this.label2.Location = new Point(72, 126);
      this.label2.Name = "label2";
      this.label2.Size = new Size(88, 16);
      this.label2.TabIndex = 15;
      this.label2.Text = "Mật khẩu cũ :";
      this.txtPassReEnter.Cursor = Cursors.IBeam;
      this.txtPassReEnter.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPassReEnter.ForeColor = Color.FromArgb(53, 73, 106);
      this.txtPassReEnter.HintForeColor = Color.Empty;
      this.txtPassReEnter.HintText = "";
      this.txtPassReEnter.isPassword = true;
      this.txtPassReEnter.LineFocusedColor = Color.FromArgb(81, 164, 227);
      this.txtPassReEnter.LineIdleColor = Color.Gray;
      this.txtPassReEnter.LineMouseHoverColor = Color.FromArgb(81, 164, 227);
      this.txtPassReEnter.LineThickness = 3;
      this.txtPassReEnter.Location = new Point(169, 234);
      this.txtPassReEnter.Margin = new Padding(5);
      this.txtPassReEnter.Name = "txtPassReEnter";
      this.txtPassReEnter.Size = new Size(368, 35);
      this.txtPassReEnter.TabIndex = 2;
      this.txtPassReEnter.TextAlign = HorizontalAlignment.Left;
      this.txtPassReEnter.OnValueChanged += new EventHandler(this.bunifuMaterialTextbox2_OnValueChanged);
      this.txtPassReEnter.KeyPress += new KeyPressEventHandler(this.txtPassReEnter_KeyPress);
      this.txtPassNew.Cursor = Cursors.IBeam;
      this.txtPassNew.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPassNew.ForeColor = Color.FromArgb(53, 73, 106);
      this.txtPassNew.HintForeColor = Color.Empty;
      this.txtPassNew.HintText = "";
      this.txtPassNew.isPassword = true;
      this.txtPassNew.LineFocusedColor = Color.FromArgb(81, 164, 227);
      this.txtPassNew.LineIdleColor = Color.Gray;
      this.txtPassNew.LineMouseHoverColor = Color.FromArgb(81, 164, 227);
      this.txtPassNew.LineThickness = 3;
      this.txtPassNew.Location = new Point(169, 173);
      this.txtPassNew.Margin = new Padding(5);
      this.txtPassNew.Name = "txtPassNew";
      this.txtPassNew.Size = new Size(368, 35);
      this.txtPassNew.TabIndex = 1;
      this.txtPassNew.TextAlign = HorizontalAlignment.Left;
      this.txtPassNew.OnValueChanged += new EventHandler(this.bunifuMaterialTextbox1_OnValueChanged);
      this.txtPassNew.KeyPress += new KeyPressEventHandler(this.txtPassNew_KeyPress);
      this.bunifuThinButton21.ActiveBorderThickness = 1;
      this.bunifuThinButton21.ActiveCornerRadius = 20;
      this.bunifuThinButton21.ActiveFillColor = Color.DodgerBlue;
      this.bunifuThinButton21.ActiveForecolor = Color.White;
      this.bunifuThinButton21.ActiveLineColor = Color.DodgerBlue;
      this.bunifuThinButton21.BackColor = Color.White;
      this.bunifuThinButton21.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
      this.bunifuThinButton21.ButtonText = "Xác Nhận";
      this.bunifuThinButton21.Cursor = Cursors.Hand;
      this.bunifuThinButton21.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton21.ForeColor = Color.Black;
      this.bunifuThinButton21.IdleBorderThickness = 1;
      this.bunifuThinButton21.IdleCornerRadius = 20;
      this.bunifuThinButton21.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.IdleForecolor = Color.White;
      this.bunifuThinButton21.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.Location = new Point(233, 289);
      this.bunifuThinButton21.Margin = new Padding(7, 5, 7, 5);
      this.bunifuThinButton21.Name = "bunifuThinButton21";
      this.bunifuThinButton21.Size = new Size(303, 50);
      this.bunifuThinButton21.TabIndex = 3;
      this.bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton21.Click += new EventHandler(this.bunifuThinButton21_Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Cursor = Cursors.Hand;
      this.linkLabel1.Font = new Font("Arial", 10f);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(176, 307);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(52, 16);
      this.linkLabel1.TabIndex = 4;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Hủy bỏ";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.txtPasswordOld.Cursor = Cursors.IBeam;
      this.txtPasswordOld.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPasswordOld.ForeColor = Color.FromArgb(53, 73, 106);
      this.txtPasswordOld.HintForeColor = Color.Empty;
      this.txtPasswordOld.HintText = "";
      this.txtPasswordOld.isPassword = true;
      this.txtPasswordOld.LineFocusedColor = Color.FromArgb(81, 164, 227);
      this.txtPasswordOld.LineIdleColor = Color.Gray;
      this.txtPasswordOld.LineMouseHoverColor = Color.FromArgb(81, 164, 227);
      this.txtPasswordOld.LineThickness = 3;
      this.txtPasswordOld.Location = new Point(169, 115);
      this.txtPasswordOld.Margin = new Padding(5);
      this.txtPasswordOld.Name = "txtPasswordOld";
      this.txtPasswordOld.Size = new Size(368, 35);
      this.txtPasswordOld.TabIndex = 0;
      this.txtPasswordOld.TextAlign = HorizontalAlignment.Left;
      this.txtPasswordOld.OnValueChanged += new EventHandler(this.txtPassword_OnValueChanged);
      this.txtPasswordOld.KeyPress += new KeyPressEventHandler(this.txtPasswordOld_KeyPress);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.ControlDarkDark;
      this.label1.Location = new Point(232, 77);
      this.label1.Name = "label1";
      this.label1.Size = new Size((int) sbyte.MaxValue, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Thay đổi mật khẩu";
      this.pictureBox2.Image = (Image) componentResourceManager.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(271, 10);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(60, 60);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(774, 211);
      this.picMainTop.TabIndex = 8;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.picMainTop_MouseDown);
      this.panel1.BackColor = Color.FromArgb(233, 235, 238);
      this.panel1.Controls.Add((Control) this.bunifuImageButton3);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.picMainTop);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(774, 391);
      this.panel1.TabIndex = 0;
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(747, 2);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(25, 25);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 10;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(774, 391);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (fChangePW);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Đổi mật khẩu";
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.panel1.ResumeLayout(false);
      this.bunifuImageButton3.EndInit();
      this.ResumeLayout(false);
    }
  }
}
