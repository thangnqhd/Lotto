// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.fThongbao
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Thống_kê_xổ_số.FormUI
{
  public class fThongbao : Form
  {
    private IContainer components = (IContainer) null;
    public static string tieude;
    public static string message;
    private Panel panel1;
    private Label lblTieude;
    private Label lblMsg;
    private Button btnClose;
    private BunifuImageButton bunifuImageButton1;

    public fThongbao(string tieude, string message)
    {
      this.InitializeComponent();
      this.lblTieude.Text = tieude;
      this.lblMsg.Text = message;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (fThongbao));
      this.panel1 = new Panel();
      this.lblTieude = new Label();
      this.lblMsg = new Label();
      this.btnClose = new Button();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.panel1.SuspendLayout();
      this.bunifuImageButton1.BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(80, 164, 226);
      this.panel1.Controls.Add((Control) this.bunifuImageButton1);
      this.panel1.Controls.Add((Control) this.lblTieude);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.ForeColor = Color.White;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(328, 28);
      this.panel1.TabIndex = 0;
      this.lblTieude.AutoSize = true;
      this.lblTieude.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTieude.Location = new Point(3, 6);
      this.lblTieude.Name = "lblTieude";
      this.lblTieude.Size = new Size(75, 15);
      this.lblTieude.TabIndex = 0;
      this.lblTieude.Text = "THÔNG BÁO";
      this.lblMsg.Font = new Font("Arial Narrow", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMsg.Location = new Point(6, 43);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new Size(313, 51);
      this.lblMsg.TabIndex = 1;
      this.lblMsg.Text = "TÀI KHOẢN CỦA BẠN VỪA ĐƯỢC ĐĂNG NHẬP TRÊN MÁY TÍNH KHÁC";
      this.lblMsg.TextAlign = ContentAlignment.TopCenter;
      this.btnClose.BackColor = SystemColors.ControlLightLight;
      this.btnClose.FlatStyle = FlatStyle.Flat;
      this.btnClose.Location = new Point(220, 106);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(102, 24);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Đóng";
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.InitialImage = (Image) null;
      this.bunifuImageButton1.Location = new Point(300, 2);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(25, 25);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 1;
      this.bunifuImageButton1.TabStop = false;
      this.bunifuImageButton1.Zoom = 10;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FloralWhite;
      this.ClientSize = new Size(328, 134);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.lblMsg);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (fThongbao);
      this.Text = nameof (fThongbao);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.bunifuImageButton1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
