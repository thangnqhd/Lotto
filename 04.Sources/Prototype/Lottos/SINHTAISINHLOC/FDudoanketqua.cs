// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FDudoanketqua
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số
{
  public class FDudoanketqua : Form
  {
    private IContainer components = (IContainer) null;
    private PictureBox picMainTop;
    private BunifuImageButton bunifuImageButton3;
    private Panel pnMain;
    private TextBox txtMota;
    private Label label11;
    private ComboBox cbbHinhThucDudoan;
    private TextBox txtTieude;
    private TextBox txtSotien;
    private BunifuThinButton2 btnXuly;
    private Label lblSotienmotcon;
    private Label label2;
    private LinkLabel linkLabel1;
    private Label label8;
    private Label label14;
    private Label label4;
    private GroupBox groupBox1;
    private RichTextBox richTextBox1;
    private BunifuElipse bunifuElipse1;
    private ToolTip toolTip1;
    private Label lblKytuTieude;
    private Label label1;
    private TextBox textBox1;
    private TextBox txtBoso;

    private int Hinhthucchoi { get; set; }

    public FDudoanketqua(int _hinhthucchoi)
    {
      this.InitializeComponent();
      this.Hinhthucchoi = _hinhthucchoi;
      this.cbbHinhThucDudoan.SelectedIndex = this.Hinhthucchoi;
    }

    private void picMainTop_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Close();
    }

    private void cbbDudoan_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbbHinhThucDudoan.SelectedIndex == 0 || this.cbbHinhThucDudoan.SelectedIndex == 1)
      {
        this.lblSotienmotcon.Text = "bạc/1con";
        this.lblSotienmotcon.ForeColor = Color.Black;
      }
      else
      {
        this.lblSotienmotcon.Text = "bạc/dàn";
        this.lblSotienmotcon.ForeColor = Color.Red;
      }
    }

    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = true;
    }

    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
      e.Handled = true;
    }

    private void txtTieude_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.txtTieude.Text.Length > 39)
        e.Handled = true;
      if (e.KeyChar == '\b')
        e.Handled = false;
      this.lblKytuTieude.Text = this.txtTieude.Text.Length.ToString() + "/40";
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FDudoanketqua));
      this.picMainTop = new PictureBox();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.pnMain = new Panel();
      this.lblKytuTieude = new Label();
      this.groupBox1 = new GroupBox();
      this.richTextBox1 = new RichTextBox();
      this.txtMota = new TextBox();
      this.label11 = new Label();
      this.cbbHinhThucDudoan = new ComboBox();
      this.txtTieude = new TextBox();
      this.txtSotien = new TextBox();
      this.btnXuly = new BunifuThinButton2();
      this.lblSotienmotcon = new Label();
      this.label2 = new Label();
      this.linkLabel1 = new LinkLabel();
      this.label8 = new Label();
      this.label14 = new Label();
      this.label4 = new Label();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.toolTip1 = new ToolTip(this.components);
      this.label1 = new Label();
      this.txtBoso = new TextBox();
      this.textBox1 = new TextBox();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.pnMain.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(1000, 229);
      this.picMainTop.TabIndex = 15;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.picMainTop_MouseDown);
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(977, 1);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(22, 22);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 16;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 9;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.pnMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
      this.pnMain.BackColor = Color.White;
      this.pnMain.Controls.Add((Control) this.textBox1);
      this.pnMain.Controls.Add((Control) this.label1);
      this.pnMain.Controls.Add((Control) this.lblKytuTieude);
      this.pnMain.Controls.Add((Control) this.groupBox1);
      this.pnMain.Controls.Add((Control) this.txtMota);
      this.pnMain.Controls.Add((Control) this.label11);
      this.pnMain.Controls.Add((Control) this.cbbHinhThucDudoan);
      this.pnMain.Controls.Add((Control) this.txtTieude);
      this.pnMain.Controls.Add((Control) this.txtSotien);
      this.pnMain.Controls.Add((Control) this.txtBoso);
      this.pnMain.Controls.Add((Control) this.btnXuly);
      this.pnMain.Controls.Add((Control) this.lblSotienmotcon);
      this.pnMain.Controls.Add((Control) this.label2);
      this.pnMain.Controls.Add((Control) this.linkLabel1);
      this.pnMain.Controls.Add((Control) this.label8);
      this.pnMain.Controls.Add((Control) this.label14);
      this.pnMain.Controls.Add((Control) this.label4);
      this.pnMain.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.pnMain.Location = new Point(21, 22);
      this.pnMain.Name = "pnMain";
      this.pnMain.Size = new Size(959, 370);
      this.pnMain.TabIndex = 17;
      this.lblKytuTieude.AutoSize = true;
      this.lblKytuTieude.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblKytuTieude.Location = new Point(386, 24);
      this.lblKytuTieude.Name = "lblKytuTieude";
      this.lblKytuTieude.Size = new Size(34, 14);
      this.lblKytuTieude.TabIndex = 36;
      this.lblKytuTieude.Text = "40/40";
      this.groupBox1.Controls.Add((Control) this.richTextBox1);
      this.groupBox1.Location = new Point(433, 14);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(523, 317);
      this.groupBox1.TabIndex = 35;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Hướng dẫn";
      this.richTextBox1.BorderStyle = BorderStyle.None;
      this.richTextBox1.Dock = DockStyle.Fill;
      this.richTextBox1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBox1.Location = new Point(3, 17);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(517, 297);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
      this.richTextBox1.KeyDown += new KeyEventHandler(this.richTextBox1_KeyDown);
      this.richTextBox1.KeyPress += new KeyPressEventHandler(this.richTextBox1_KeyPress);
      this.txtMota.BackColor = Color.White;
      this.txtMota.BorderStyle = BorderStyle.FixedSingle;
      this.txtMota.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtMota.ForeColor = Color.Black;
      this.txtMota.Location = new Point(84, 242);
      this.txtMota.Multiline = true;
      this.txtMota.Name = "txtMota";
      this.txtMota.Size = new Size(335, 89);
      this.txtMota.TabIndex = 4;
      this.txtMota.Tag = (object) "0";
      this.txtMota.Text = "Rất hy vọng dự đoán chính xác. Mọi người tham khảo nhé. Chúc cả nhà mình cùng winnnnn";
      this.toolTip1.SetToolTip((Control) this.txtMota, "Nói thêm một chút về bài chốt số của bạn giúp mọi người hiểu rõ hơn");
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = SystemColors.ControlDarkDark;
      this.label11.Location = new Point(16, 243);
      this.label11.Name = "label11";
      this.label11.Size = new Size(67, 16);
      this.label11.TabIndex = 34;
      this.label11.Text = "Lời nhắn :";
      this.cbbHinhThucDudoan.BackColor = Color.Teal;
      this.cbbHinhThucDudoan.Cursor = Cursors.Hand;
      this.cbbHinhThucDudoan.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbHinhThucDudoan.FlatStyle = FlatStyle.Popup;
      this.cbbHinhThucDudoan.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbHinhThucDudoan.ForeColor = Color.White;
      this.cbbHinhThucDudoan.FormattingEnabled = true;
      this.cbbHinhThucDudoan.Items.AddRange(new object[7]
      {
        (object) "                         Dự đoàn lô thường",
        (object) "                          Dự đoán đặc biệt",
        (object) "                          Dự đoán lô xiên 2",
        (object) "                          Dự đoán lô xiên 3",
        (object) "                          Dự đoán lô xiên 4",
        (object) "                      Dự đoán lô trượt 8 con",
        (object) "                      Dự đoán lô trượt 10 con"
      });
      this.cbbHinhThucDudoan.Location = new Point(84, 50);
      this.cbbHinhThucDudoan.Name = "cbbHinhThucDudoan";
      this.cbbHinhThucDudoan.Size = new Size(338, 24);
      this.cbbHinhThucDudoan.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.cbbHinhThucDudoan, "Hình thức mà bạn muốn dự đoán");
      this.cbbHinhThucDudoan.SelectedIndexChanged += new EventHandler(this.cbbDudoan_SelectedIndexChanged);
      this.txtTieude.BackColor = Color.White;
      this.txtTieude.BorderStyle = BorderStyle.FixedSingle;
      this.txtTieude.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTieude.ForeColor = Color.Black;
      this.txtTieude.Location = new Point(85, 20);
      this.txtTieude.Name = "txtTieude";
      this.txtTieude.Size = new Size(337, 21);
      this.txtTieude.TabIndex = 0;
      this.txtTieude.Tag = (object) "0";
      this.txtTieude.Text = "Mô tả cho mọi người biết về bài chốt số của bạn";
      this.toolTip1.SetToolTip((Control) this.txtTieude, "Tiêu đề bài chốt số của bạn");
      this.txtTieude.KeyPress += new KeyPressEventHandler(this.txtTieude_KeyPress);
      this.txtSotien.BorderStyle = BorderStyle.FixedSingle;
      this.txtSotien.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtSotien.ForeColor = Color.Red;
      this.txtSotien.Location = new Point(85, 213);
      this.txtSotien.Name = "txtSotien";
      this.txtSotien.Size = new Size(170, 22);
      this.txtSotien.TabIndex = 3;
      this.txtSotien.Tag = (object) "0";
      this.txtSotien.Text = "0";
      this.toolTip1.SetToolTip((Control) this.txtSotien, "Số bạc bạn muốn dự đoán cho dàn số");
      this.btnXuly.ActiveBorderThickness = 1;
      this.btnXuly.ActiveCornerRadius = 20;
      this.btnXuly.ActiveFillColor = Color.DodgerBlue;
      this.btnXuly.ActiveForecolor = Color.White;
      this.btnXuly.ActiveLineColor = Color.DodgerBlue;
      this.btnXuly.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnXuly.BackColor = Color.White;
      this.btnXuly.BackgroundImage = (Image) componentResourceManager.GetObject("btnXuly.BackgroundImage");
      this.btnXuly.ButtonText = "Tự tin chốt";
      this.btnXuly.Cursor = Cursors.Hand;
      this.btnXuly.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnXuly.ForeColor = Color.Black;
      this.btnXuly.IdleBorderThickness = 1;
      this.btnXuly.IdleCornerRadius = 20;
      this.btnXuly.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnXuly.IdleForecolor = Color.White;
      this.btnXuly.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnXuly.Location = new Point(671, 333);
      this.btnXuly.Margin = new Padding(6, 5, 6, 5);
      this.btnXuly.Name = "btnXuly";
      this.btnXuly.Size = new Size(282, 35);
      this.btnXuly.TabIndex = 5;
      this.btnXuly.TextAlign = ContentAlignment.MiddleCenter;
      this.lblSotienmotcon.AutoSize = true;
      this.lblSotienmotcon.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSotienmotcon.ForeColor = SystemColors.ControlDarkDark;
      this.lblSotienmotcon.Location = new Point((int) byte.MaxValue, 216);
      this.lblSotienmotcon.Name = "lblSotienmotcon";
      this.lblSotienmotcon.Size = new Size(61, 16);
      this.lblSotienmotcon.TabIndex = 9;
      this.lblSotienmotcon.Text = "bạc/1con";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = SystemColors.ControlDarkDark;
      this.label2.Location = new Point(26, 216);
      this.label2.Name = "label2";
      this.label2.Size = new Size(57, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "Số tiền :";
      this.linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Cursor = Cursors.Hand;
      this.linkLabel1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(620, 343);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(45, 15);
      this.linkLabel1.TabIndex = 6;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Hủy bỏ";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = SystemColors.ControlDarkDark;
      this.label8.Location = new Point(33, 85);
      this.label8.Name = "label8";
      this.label8.Size = new Size(50, 16);
      this.label8.TabIndex = 6;
      this.label8.Text = "Bộ số :";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = SystemColors.ControlDarkDark;
      this.label14.Location = new Point(25, 23);
      this.label14.Name = "label14";
      this.label14.Size = new Size(58, 16);
      this.label14.TabIndex = 1;
      this.label14.Text = "Tiều đề :";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.ControlDarkDark;
      this.label4.Location = new Point(17, 54);
      this.label4.Name = "label4";
      this.label4.Size = new Size(66, 16);
      this.label4.TabIndex = 2;
      this.label4.Text = "Dự đoán :";
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this.pnMain;
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.ControlDarkDark;
      this.label1.Location = new Point(31, 185);
      this.label1.Name = "label1";
      this.label1.Size = new Size(52, 16);
      this.label1.TabIndex = 37;
      this.label1.Text = "Số dư :";
      this.txtBoso.BackColor = Color.White;
      this.txtBoso.BorderStyle = BorderStyle.FixedSingle;
      this.txtBoso.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtBoso.ForeColor = Color.DarkRed;
      this.txtBoso.HideSelection = false;
      this.txtBoso.Location = new Point(85, 83);
      this.txtBoso.Multiline = true;
      this.txtBoso.Name = "txtBoso";
      this.txtBoso.Size = new Size(335, 91);
      this.txtBoso.TabIndex = 2;
      this.txtBoso.Tag = (object) "0";
      this.toolTip1.SetToolTip((Control) this.txtBoso, "Dàn số dự đoán của bạn");
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox1.ForeColor = Color.Red;
      this.textBox1.Location = new Point(84, 182);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(170, 22);
      this.textBox1.TabIndex = 38;
      this.textBox1.Tag = (object) "0";
      this.textBox1.Text = "0";
      this.toolTip1.SetToolTip((Control) this.textBox1, "Số bạc bạn muốn dự đoán cho dàn số");
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(1000, 404);
      this.Controls.Add((Control) this.pnMain);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.picMainTop);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FDudoanketqua);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Dự đoán kết quả";
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.bunifuImageButton3.EndInit();
      this.pnMain.ResumeLayout(false);
      this.pnMain.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
