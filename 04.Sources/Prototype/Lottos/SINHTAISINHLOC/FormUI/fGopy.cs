// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.fGopy
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
  public class fGopy : Form
  {
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private BunifuThinButton2 btnDangki;
    private LinkLabel linkLabel1;
    private Label label1;
    private PictureBox picAvatar;
    private PictureBox picMainTop;
    private BunifuImageButton bunifuImageButton3;
    private Label label4;
    private RichTextBox richTextBoxNoidung;
    private ComboBox cbbGopy;
    private Label label5;
    private Label lblThongbao;
    private BunifuElipse bunifuElipse1;

    public fGopy()
    {
      this.InitializeComponent();
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void fGopy_Load(object sender, EventArgs e)
    {
      this.cbbGopy.SelectedIndex = 0;
    }

    private void richTextBoxNoidung_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.richTextBoxNoidung.Text.Length <= 500)
        return;
      e.Handled = true;
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Close();
    }

    private void btnDangki_Click(object sender, EventArgs e)
    {
      if (this.richTextBoxNoidung.Text.Length < 21)
      {
        this.lblThongbao.ForeColor = Color.Red;
        this.lblThongbao.Text = Resources.fGopy_btnDangki_Click___Bạn_hãy_góp_ý_chi_tiết_một_chút_nhé____;
        this.richTextBoxNoidung.Focus();
      }
      else if (this.richTextBoxNoidung.Text.Length > 500)
      {
        this.lblThongbao.ForeColor = Color.Red;
        this.lblThongbao.Text = Resources.fGopy_btnDangki_Click___Nội_dung_tin_nhắn_nhỏ_hơn_500_kí_tự_bạn_nhé____;
        this.richTextBoxNoidung.Focus();
      }
      else
      {
        this.lblThongbao.ForeColor = Color.Black;
        this.lblThongbao.Text = Resources.fGopy_btnDangki_Click___Chúng_tôi_rất_mong_nhận_được_sự_góp_ý_chân_thành_của_bạn;
        tbGopy tbGopy = new tbGopy();
        tbGopy.TenDangnhap = TbUser.Tbuser.TenDangnhap;
        tbGopy.ChuyenMuc = this.cbbGopy.SelectedItem.ToString();
        tbGopy.NoiDung = this.richTextBoxNoidung.Text;
        if (tbGopy.Insert(tbGopy) != 1)
          return;
        ClMain.tune_Thongbao("sent.wav");
        int num = (int) MessageBox.Show(Resources.fGopy_btnDangki_Click_CẢM_ƠN_BẠN_ĐÃ_GÓP_Ý__CHÚC_BẠN_GẶP_THẬT_NHIỀU_MAY_MẮN_VÀ_THÀNH_CÔNG, Resources.fGopy_btnDangki_Click_THÔNG_BÁO);
        this.Close();
      }
    }

    private void cbbGopy_SelectedIndexChanged(object sender, EventArgs e)
    {
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (fGopy));
      this.panel1 = new Panel();
      this.richTextBoxNoidung = new RichTextBox();
      this.cbbGopy = new ComboBox();
      this.btnDangki = new BunifuThinButton2();
      this.linkLabel1 = new LinkLabel();
      this.label5 = new Label();
      this.lblThongbao = new Label();
      this.label4 = new Label();
      this.label1 = new Label();
      this.picAvatar = new PictureBox();
      this.picMainTop = new PictureBox();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picAvatar).BeginInit();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.richTextBoxNoidung);
      this.panel1.Controls.Add((Control) this.cbbGopy);
      this.panel1.Controls.Add((Control) this.btnDangki);
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.lblThongbao);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.picAvatar);
      this.panel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel1.Location = new Point(130, 11);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(702, 338);
      this.panel1.TabIndex = 7;
      this.richTextBoxNoidung.BorderStyle = BorderStyle.FixedSingle;
      this.richTextBoxNoidung.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBoxNoidung.Location = new Point(152, 137);
      this.richTextBoxNoidung.Name = "richTextBoxNoidung";
      this.richTextBoxNoidung.Size = new Size(440, 137);
      this.richTextBoxNoidung.TabIndex = 1;
      this.richTextBoxNoidung.Text = "";
      this.richTextBoxNoidung.KeyPress += new KeyPressEventHandler(this.richTextBoxNoidung_KeyPress);
      this.cbbGopy.BackColor = Color.Teal;
      this.cbbGopy.Cursor = Cursors.Hand;
      this.cbbGopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbGopy.FlatStyle = FlatStyle.Popup;
      this.cbbGopy.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbGopy.ForeColor = Color.White;
      this.cbbGopy.FormattingEnabled = true;
      this.cbbGopy.Items.AddRange(new object[4]
      {
        (object) "Ý tưởng xây dựng và phát triển phần mềm",
        (object) "Các vấn đề về tài khoản(Lỗi đăng nhập, khóa nick...)",
        (object) "Các vấn đề về hệ thống, báo cáo sự cố",
        (object) "Vấn đề khác"
      });
      this.cbbGopy.Location = new Point(152, 94);
      this.cbbGopy.Name = "cbbGopy";
      this.cbbGopy.Size = new Size(440, 23);
      this.cbbGopy.TabIndex = 0;
      this.cbbGopy.SelectedIndexChanged += new EventHandler(this.cbbGopy_SelectedIndexChanged);
      this.btnDangki.ActiveBorderThickness = 1;
      this.btnDangki.ActiveCornerRadius = 20;
      this.btnDangki.ActiveFillColor = Color.DodgerBlue;
      this.btnDangki.ActiveForecolor = Color.White;
      this.btnDangki.ActiveLineColor = Color.DodgerBlue;
      this.btnDangki.BackColor = Color.White;
      this.btnDangki.BackgroundImage = (Image) componentResourceManager.GetObject("btnDangki.BackgroundImage");
      this.btnDangki.ButtonText = "Góp ý";
      this.btnDangki.Cursor = Cursors.Hand;
      this.btnDangki.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDangki.ForeColor = Color.Black;
      this.btnDangki.IdleBorderThickness = 1;
      this.btnDangki.IdleCornerRadius = 20;
      this.btnDangki.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.IdleForecolor = Color.White;
      this.btnDangki.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.Location = new Point(207, 296);
      this.btnDangki.Margin = new Padding(6, 5, 6, 5);
      this.btnDangki.Name = "btnDangki";
      this.btnDangki.Size = new Size(385, 40);
      this.btnDangki.TabIndex = 2;
      this.btnDangki.TextAlign = ContentAlignment.MiddleCenter;
      this.btnDangki.Click += new EventHandler(this.btnDangki_Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Cursor = Cursors.Hand;
      this.linkLabel1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(157, 310);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(45, 15);
      this.linkLabel1.TabIndex = 3;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Hủy bỏ";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = SystemColors.ControlDarkDark;
      this.label5.Location = new Point(79, 136);
      this.label5.Name = "label5";
      this.label5.Size = new Size(73, 17);
      this.label5.TabIndex = 1;
      this.label5.Text = "Nội dung :";
      this.label5.Click += new EventHandler(this.label1_Click);
      this.lblThongbao.AutoSize = true;
      this.lblThongbao.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblThongbao.ForeColor = Color.Black;
      this.lblThongbao.Location = new Point(149, 281);
      this.lblThongbao.Name = "lblThongbao";
      this.lblThongbao.Size = new Size(353, 14);
      this.lblThongbao.TabIndex = 1;
      this.lblThongbao.Text = "* Chúng tôi rất mong nhận được sự góp ý chân thành của bạn";
      this.lblThongbao.Click += new EventHandler(this.label1_Click);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.ControlDarkDark;
      this.label4.Location = new Point(56, 96);
      this.label4.Name = "label4";
      this.label4.Size = new Size(99, 17);
      this.label4.TabIndex = 1;
      this.label4.Text = "Chuyên mục :";
      this.label4.Click += new EventHandler(this.label1_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.label1.ForeColor = SystemColors.ControlDarkDark;
      this.label1.Location = new Point(265, 67);
      this.label1.Name = "label1";
      this.label1.Size = new Size(193, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "GÓP Ý XÂY DỰNG HỆ THỐNG";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.picAvatar.ErrorImage = (Image) componentResourceManager.GetObject("picAvatar.ErrorImage");
      this.picAvatar.Image = (Image) componentResourceManager.GetObject("picAvatar.Image");
      this.picAvatar.Location = new Point(329, 6);
      this.picAvatar.Margin = new Padding(0);
      this.picAvatar.Name = "picAvatar";
      this.picAvatar.Size = new Size(55, 55);
      this.picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
      this.picAvatar.TabIndex = 0;
      this.picAvatar.TabStop = false;
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(941, 200);
      this.picMainTop.TabIndex = 8;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.picMainTop_MouseDown);
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(915, 2);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(23, 23);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 9;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.bunifuElipse1.ElipseRadius = 10;
      this.bunifuElipse1.TargetControl = (Control) this.panel1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(941, 360);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.picMainTop);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (fGopy);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Đóng góp ý kiến";
      this.Load += new EventHandler(this.fGopy_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picAvatar).EndInit();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.bunifuImageButton3.EndInit();
      this.ResumeLayout(false);
    }
  }
}
