// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.AppInfo
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class AppInfo : Form
  {
    private IContainer components = (IContainer) null;
    private Panel panel2;
    private Label label4;
    private ToolTip toolTip1;
    private BunifuElipse bunifuElipse1;
    private BunifuImageButton bunifuImageButton8;
    private Label label5;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private LinkLabel linkVersion;
    private LinkLabel linkLabel2;
    private LinkLabel linkLabel1;
    private Label label2;
    private Label label12;
    private Label label3;
    private Label label11;
    private Label label7;
    private Label label9;
    private Label label6;
    private BunifuImageButton bunifuImageButton1;

    public AppInfo()
    {
      this.InitializeComponent();
      this.linkVersion.Text = FLogin._version + Resources.AppInfo_AppInfo___phiên_bản_mới_nhất_;
    }

    private void bunifuImageButton8_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void AppInfo_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void label5_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void linkVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(tbConfigApp.configApp.LinkApp);
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(tbConfigApp.configApp.LinkFacebook);
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(tbConfigApp.configApp.HomePage);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AppInfo));
      this.panel2 = new Panel();
      this.groupBox2 = new GroupBox();
      this.linkVersion = new LinkLabel();
      this.linkLabel2 = new LinkLabel();
      this.linkLabel1 = new LinkLabel();
      this.label2 = new Label();
      this.label12 = new Label();
      this.label3 = new Label();
      this.label11 = new Label();
      this.label7 = new Label();
      this.label9 = new Label();
      this.label6 = new Label();
      this.groupBox1 = new GroupBox();
      this.label4 = new Label();
      this.toolTip1 = new ToolTip(this.components);
      this.bunifuImageButton8 = new BunifuImageButton();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.label5 = new Label();
      this.panel2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.bunifuImageButton8.BeginInit();
      this.bunifuImageButton1.BeginInit();
      this.SuspendLayout();
      this.panel2.BackColor = Color.White;
      this.panel2.Controls.Add((Control) this.groupBox2);
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Location = new Point(1, 21);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(698, 280);
      this.panel2.TabIndex = 1;
      this.groupBox2.BackColor = Color.White;
      this.groupBox2.Controls.Add((Control) this.linkVersion);
      this.groupBox2.Controls.Add((Control) this.linkLabel2);
      this.groupBox2.Controls.Add((Control) this.linkLabel1);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.label12);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.label11);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.label9);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Location = new Point(4, 172);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(690, 105);
      this.groupBox2.TabIndex = 35;
      this.groupBox2.TabStop = false;
      this.linkVersion.AutoSize = true;
      this.linkVersion.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.linkVersion.ForeColor = Color.Black;
      this.linkVersion.LinkBehavior = LinkBehavior.NeverUnderline;
      this.linkVersion.LinkColor = Color.Black;
      this.linkVersion.Location = new Point(82, 21);
      this.linkVersion.Name = "linkVersion";
      this.linkVersion.Size = new Size(121, 15);
      this.linkVersion.TabIndex = 35;
      this.linkVersion.TabStop = true;
      this.linkVersion.Text = "0.0.0.0 (đã cập nhật)";
      this.toolTip1.SetToolTip((Control) this.linkVersion, "Kiểm tra phiên bản mới nhất của phần mềm");
      this.linkVersion.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkVersion_LinkClicked);
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.DisabledLinkColor = Color.Black;
      this.linkLabel2.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.linkLabel2.ForeColor = Color.Black;
      this.linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
      this.linkLabel2.LinkColor = Color.Black;
      this.linkLabel2.Location = new Point(81, 51);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(147, 15);
      this.linkLabel2.TabIndex = 34;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "www.sinhtaisinhloc.com";
      this.toolTip1.SetToolTip((Control) this.linkLabel2, "http://sinhtaisinhloc.com");
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.DisabledLinkColor = Color.Black;
      this.linkLabel1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.ForeColor = Color.Black;
      this.linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
      this.linkLabel1.LinkColor = Color.Black;
      this.linkLabel1.Location = new Point(357, 22);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(104, 15);
      this.linkLabel1.TabIndex = 33;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Sinh Tài Sinh Lộc";
      this.toolTip1.SetToolTip((Control) this.linkLabel1, "Sinh Tài Sinh Lộc");
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(8, 21);
      this.label2.Name = "label2";
      this.label2.Size = new Size(72, 15);
      this.label2.TabIndex = 2;
      this.label2.Text = "Phiên bản  :";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Times New Roman", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.Red;
      this.label12.Location = new Point(6, 76);
      this.label12.Name = "label12";
      this.label12.Size = new Size(675, 15);
      this.label12.TabIndex = 32;
      this.label12.Text = "2017© BẢN QUYỀN THUỘC VỀ SINH TÀI SINH LỘC. PHẦN MỀM THỐNG KÊ XỔ SỐ DÀNH CHO DÂN CHUYÊN NGHIỆP";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(283, 22);
      this.label3.Name = "label3";
      this.label3.Size = new Size(76, 15);
      this.label3.TabIndex = 3;
      this.label3.Text = "Fanpage      :";
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.Black;
      this.label11.Location = new Point(484, 51);
      this.label11.Name = "label11";
      this.label11.Size = new Size(158, 15);
      this.label11.TabIndex = 31;
      this.label11.Text = "Tel     : (+84)) 165-399-7161";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(283, 51);
      this.label7.Name = "label7";
      this.label7.Size = new Size(171, 15);
      this.label7.TabIndex = 25;
      this.label7.Text = "Phone    : (+84) 165-399-7161";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.Black;
      this.label9.Location = new Point(472, 21);
      this.label9.Name = "label9";
      this.label9.Size = new Size(209, 15);
      this.label9.TabIndex = 27;
      this.label9.Text = "Email    : lienhe@sinhtaisinhloc.com";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(8, 51);
      this.label6.Name = "label6";
      this.label6.Size = new Size(75, 15);
      this.label6.TabIndex = 28;
      this.label6.Text = "Website      :";
      this.groupBox1.BackColor = Color.White;
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Location = new Point(4, 1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(690, 165);
      this.groupBox1.TabIndex = 33;
      this.groupBox1.TabStop = false;
      this.label4.BackColor = Color.WhiteSmoke;
      this.label4.Font = new Font("Calibri", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(5, 9);
      this.label4.Name = "label4";
      this.label4.Size = new Size(680, 152);
      this.label4.TabIndex = 4;
      this.label4.Text = componentResourceManager.GetString("label4.Text");
      this.bunifuImageButton8.BackColor = Color.Transparent;
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(678, 0);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(21, 21);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 29;
      this.bunifuImageButton8.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton8, "Đóng");
      this.bunifuImageButton8.Zoom = 0;
      this.bunifuImageButton8.Click += new EventHandler(this.bunifuImageButton8_Click);
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Cursor = Cursors.Hand;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(3, 1);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(19, 19);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 31;
      this.bunifuImageButton1.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton1, "Đóng");
      this.bunifuImageButton1.Zoom = 0;
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this.label4;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.White;
      this.label5.Location = new Point(26, 4);
      this.label5.Name = "label5";
      this.label5.Size = new Size(493, 15);
      this.label5.TabIndex = 30;
      this.label5.Text = "SINH TÀI SINH LỘC -  PHẦN MỀM THỐNG KÊ XỔ SỐ DÀNH CHO DÂN CHUYÊN NGHIỆP";
      this.label5.MouseDown += new MouseEventHandler(this.label5_MouseDown);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(27, 40, 61);
      this.ClientSize = new Size(700, 302);
      this.Controls.Add((Control) this.bunifuImageButton1);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.bunifuImageButton8);
      this.Controls.Add((Control) this.panel2);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (AppInfo);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Thông tin";
      this.MouseDown += new MouseEventHandler(this.AppInfo_MouseDown);
      this.panel2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.bunifuImageButton8.EndInit();
      this.bunifuImageButton1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
