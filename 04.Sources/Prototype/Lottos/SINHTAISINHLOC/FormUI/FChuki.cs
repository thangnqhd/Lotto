// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FChuki
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class FChuki : Form
  {
    private int _stt = -1;
    private IContainer components = (IContainer) null;
    private tbChukidanh _infoChuki;
    private DataTable _dt;
    private BunifuImageButton bunifuImageButton3;
    private Panel panel1;
    private BunifuThinButton2 btnDangki;
    private LinkLabel linkLabel1;
    private Label label5;
    private Label lblThongbao;
    private Label label4;
    private Label label1;
    private PictureBox picMainTop;
    private TextBox txtTenchuki;
    private GroupBox groupBox2;
    private TextBox txtDongiaDacbiet;
    private TextBox txtTileanDacbiet;
    private Label label6;
    private Label label7;
    private GroupBox groupBox1;
    private TextBox txtDongiaLoto;
    private TextBox txtTileanLoto;
    private Label label3;
    private TextBox txtDonvitiente;
    private Label label8;
    private Label lbl1;
    private Label lbl4;
    private Label lbl3;
    private Label lbl2;
    private ToolTip toolTip1;
    private BunifuElipse bunifuElipse1;
    private TextBox txtMuctieuchuki;
    private Label lbl0;
    private Label label2;

    public FChuki()
    {
      this.InitializeComponent();
    }

    private void GetInfo()
    {
      this._infoChuki = new tbChukidanh();
      this._infoChuki = this._infoChuki.GetList_Top_By_Username(TbUser.Tbuser.TenDangnhap, 1);
      if (this._infoChuki.tenChuki == null)
        return;
      this.txtDonvitiente.Text = this._infoChuki.donviTien;
      this.txtDongiaLoto.Text = this._infoChuki.hesoNhanLo.ToString();
      this.txtTileanLoto.Text = this._infoChuki.tileAnLo.ToString();
      this.txtDongiaDacbiet.Text = this._infoChuki.hesoNhanDe.ToString();
      this.txtTileanDacbiet.Text = this._infoChuki.tileAnDe.ToString();
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      this.CloseF();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.CloseF();
    }

    private void CloseF()
    {
      this.Close();
    }

    private void BtnDangkiClick(object sender, EventArgs e)
    {
      this._stt = -1;
      this._infoChuki = new tbChukidanh();
      this._dt = this._infoChuki.GetList_By_TenChuki(TbUser.Tbuser.TenDangnhap, this.txtTenchuki.Text);
      if (this._dt.Rows.Count > 0)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click__Tên_chu_kì_đã_tồn_tại;
        this.txtTenchuki.Focus();
      }
      else if (this.txtTenchuki.Text.Length < 1 || this.txtTenchuki.Text.Length > 20)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click__Tên_chu_kì_không_được_để_trống;
        this.txtTenchuki.Focus();
      }
      else if (this.txtDonvitiente.Text.Length < 1)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click__Đơn_vị_tiền_tệ_không_được_trống;
        this.txtDonvitiente.Focus();
      }
      else if (!ClMain.IsNumber(this.txtMuctieuchuki.Text) || int.Parse(this.txtMuctieuchuki.Text) < 1)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click_Bạn_cần_có_một_mục_tiêu_cho_chu_kì_này;
        this.txtMuctieuchuki.Focus();
      }
      else if (!ClMain.IsNumber(this.txtDongiaLoto.Text) || int.Parse(this.txtDongiaLoto.Text) < 1)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click__Đơn_giá_loto_của_bạn_chưa_chính_xác;
        this.txtDongiaLoto.Focus();
      }
      else if (!ClMain.IsNumber(this.txtTileanLoto.Text) && int.Parse(this.txtTileanLoto.Text) < 1)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click__Tỉ_lệ_ăn_loto_của_bạn_chưa_chính_xác;
        this.txtTileanLoto.Focus();
      }
      else if (!ClMain.IsNumber(this.txtDongiaDacbiet.Text) && int.Parse(this.txtDongiaDacbiet.Text) < 1)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click__Đơn_giá_đặc_biệt_của_bạn_chưa_chính_xác;
        this.txtDongiaDacbiet.Focus();
      }
      else if (!ClMain.IsNumber(this.txtTileanDacbiet.Text) || int.Parse(this.txtTileanDacbiet.Text) < 1)
      {
        this.lblThongbao.Text = Resources.fChuki_btnDangki_Click__Tỉ_lệ_ăn_đặc_biệt_của_bạn_chưa_chính_xác;
        this.txtTileanDacbiet.Focus();
      }
      else
      {
        this._infoChuki = new tbChukidanh();
        this._infoChuki = this._infoChuki.GetList_Top_By_Username(TbUser.Tbuser.TenDangnhap, 1);
        string text = Resources.fChuki_btnDangki_Click_BẠN_CÓ_CHẮC_CHẮN_MUỐN_THÊM_CHU_KÌ_NÀY;
        if (this._infoChuki.tenDangnhap != null)
        {
          this._stt = this._infoChuki.stt;
          text = string.Format("BẠN ĐÃ TẠO ĐƯỢC MỘT CHU KÌ NHƯ Ý RỒI CHỨ ?");
        }
        if (MessageBox.Show(text, Resources.fGopy_btnDangki_Click_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
          return;
        this._infoChuki = new tbChukidanh()
        {
          muctieuChuki = Decimal.Parse(this.txtMuctieuchuki.Text.Trim()),
          tenDangnhap = TbUser.Tbuser.TenDangnhap,
          tenChuki = this.txtTenchuki.Text.Trim(),
          donviTien = this.txtDonvitiente.Text.Trim(),
          hesoNhanLo = Decimal.Parse(this.txtDongiaLoto.Text.Trim()),
          tileAnLo = Decimal.Parse(this.txtTileanLoto.Text.Trim()),
          hesoNhanDe = Decimal.Parse(this.txtDongiaDacbiet.Text.Trim()),
          tileAnDe = Decimal.Parse(this.txtTileanDacbiet.Text.Trim())
        };
        if (this._infoChuki.Insert(this._infoChuki) == 1)
        {
          TabVaotienChukiDanh.LoadLaiCombobox = 1;
          TabThongkeCanhan.LoadLaiForm = 1;
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.fChuki_btnDangki_Click_THÊM_MỚI_KHÔNG_THÀNH_CÔNG, Resources.fGopy_btnDangki_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
    }

    private void txtDonvitiente_TextChanged(object sender, EventArgs e)
    {
      this.lbl0.Text = this.txtDonvitiente.Text;
      this.lbl1.Text = this.txtDonvitiente.Text;
      this.lbl2.Text = this.txtDonvitiente.Text;
      this.lbl3.Text = this.txtDonvitiente.Text;
      this.lbl4.Text = this.txtDonvitiente.Text;
    }

    private void fChuki_Load(object sender, EventArgs e)
    {
      this.txtTenchuki.Text = TabVaotienChukiDanh.TenChuki ?? Resources.fChuki_fChuki_Load_Tiêu_diệt_chủ_lô_1;
      this.GetInfo();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FChuki));
      this.bunifuImageButton3 = new BunifuImageButton();
      this.panel1 = new Panel();
      this.txtTenchuki = new TextBox();
      this.txtMuctieuchuki = new TextBox();
      this.txtDonvitiente = new TextBox();
      this.groupBox2 = new GroupBox();
      this.txtDongiaDacbiet = new TextBox();
      this.txtTileanDacbiet = new TextBox();
      this.label6 = new Label();
      this.label7 = new Label();
      this.lbl4 = new Label();
      this.lbl3 = new Label();
      this.groupBox1 = new GroupBox();
      this.txtDongiaLoto = new TextBox();
      this.txtTileanLoto = new TextBox();
      this.label5 = new Label();
      this.label3 = new Label();
      this.lbl2 = new Label();
      this.lbl1 = new Label();
      this.lbl0 = new Label();
      this.btnDangki = new BunifuThinButton2();
      this.linkLabel1 = new LinkLabel();
      this.label2 = new Label();
      this.label8 = new Label();
      this.lblThongbao = new Label();
      this.label4 = new Label();
      this.label1 = new Label();
      this.picMainTop = new PictureBox();
      this.toolTip1 = new ToolTip(this.components);
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.bunifuImageButton3.BeginInit();
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.SuspendLayout();
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(728, 2);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(23, 23);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 12;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.txtTenchuki);
      this.panel1.Controls.Add((Control) this.txtMuctieuchuki);
      this.panel1.Controls.Add((Control) this.txtDonvitiente);
      this.panel1.Controls.Add((Control) this.groupBox2);
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Controls.Add((Control) this.lbl0);
      this.panel1.Controls.Add((Control) this.btnDangki);
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label8);
      this.panel1.Controls.Add((Control) this.lblThongbao);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel1.Location = new Point(115, 15);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(526, 410);
      this.panel1.TabIndex = 0;
      this.txtTenchuki.BorderStyle = BorderStyle.FixedSingle;
      this.txtTenchuki.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTenchuki.Location = new Point(145, 39);
      this.txtTenchuki.Name = "txtTenchuki";
      this.txtTenchuki.Size = new Size(298, 22);
      this.txtTenchuki.TabIndex = 0;
      this.txtTenchuki.Tag = (object) "0";
      this.txtTenchuki.Text = "Tiêu diệt chủ lô 1";
      this.toolTip1.SetToolTip((Control) this.txtTenchuki, "Tên chù kì bạn muốn thêm");
      this.txtMuctieuchuki.BorderStyle = BorderStyle.FixedSingle;
      this.txtMuctieuchuki.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtMuctieuchuki.ForeColor = Color.Red;
      this.txtMuctieuchuki.Location = new Point(143, 103);
      this.txtMuctieuchuki.Name = "txtMuctieuchuki";
      this.txtMuctieuchuki.Size = new Size(220, 22);
      this.txtMuctieuchuki.TabIndex = 2;
      this.txtMuctieuchuki.Tag = (object) "0";
      this.txtMuctieuchuki.Text = "1000000";
      this.toolTip1.SetToolTip((Control) this.txtMuctieuchuki, " Bạn muốn đạt được bao nhiêu tiền trong chu kì này");
      this.txtMuctieuchuki.TextChanged += new EventHandler(this.txtDonvitiente_TextChanged);
      this.txtDonvitiente.BorderStyle = BorderStyle.FixedSingle;
      this.txtDonvitiente.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDonvitiente.Location = new Point(144, 71);
      this.txtDonvitiente.Name = "txtDonvitiente";
      this.txtDonvitiente.Size = new Size(48, 22);
      this.txtDonvitiente.TabIndex = 1;
      this.txtDonvitiente.Tag = (object) "0";
      this.txtDonvitiente.Text = "VND";
      this.toolTip1.SetToolTip((Control) this.txtDonvitiente, "Đơn vị tiền tệ của bạn [VND,JPY,USD..]");
      this.txtDonvitiente.TextChanged += new EventHandler(this.txtDonvitiente_TextChanged);
      this.groupBox2.Controls.Add((Control) this.txtDongiaDacbiet);
      this.groupBox2.Controls.Add((Control) this.txtTileanDacbiet);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.lbl4);
      this.groupBox2.Controls.Add((Control) this.lbl3);
      this.groupBox2.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.groupBox2.Location = new Point(56, 235);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(422, 100);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Đặc biệt";
      this.txtDongiaDacbiet.BorderStyle = BorderStyle.FixedSingle;
      this.txtDongiaDacbiet.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDongiaDacbiet.ForeColor = Color.Red;
      this.txtDongiaDacbiet.Location = new Point(87, 22);
      this.txtDongiaDacbiet.Name = "txtDongiaDacbiet";
      this.txtDongiaDacbiet.Size = new Size(184, 22);
      this.txtDongiaDacbiet.TabIndex = 0;
      this.txtDongiaDacbiet.Tag = (object) "0";
      this.txtDongiaDacbiet.Text = "1000";
      this.toolTip1.SetToolTip((Control) this.txtDongiaDacbiet, "Đơn giá trên một điểm đặc biệt");
      this.txtTileanDacbiet.BorderStyle = BorderStyle.FixedSingle;
      this.txtTileanDacbiet.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTileanDacbiet.ForeColor = Color.Red;
      this.txtTileanDacbiet.Location = new Point(87, 61);
      this.txtTileanDacbiet.Name = "txtTileanDacbiet";
      this.txtTileanDacbiet.Size = new Size(219, 22);
      this.txtTileanDacbiet.TabIndex = 1;
      this.txtTileanDacbiet.Tag = (object) "0";
      this.txtTileanDacbiet.Text = "80000";
      this.toolTip1.SetToolTip((Control) this.txtTileanDacbiet, "Tỉ lệ ăn trên một đơn vị điểm đặc biệt");
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.DimGray;
      this.label6.Location = new Point(12, 25);
      this.label6.Name = "label6";
      this.label6.Size = new Size(68, 17);
      this.label6.TabIndex = 0;
      this.label6.Text = "Đơn giá :";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.DimGray;
      this.label7.Location = new Point(16, 64);
      this.label7.Name = "label7";
      this.label7.Size = new Size(63, 17);
      this.label7.TabIndex = 1;
      this.label7.Text = "Tỉ lệ ăn :";
      this.lbl4.AutoSize = true;
      this.lbl4.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl4.ForeColor = Color.DimGray;
      this.lbl4.Location = new Point(307, 64);
      this.lbl4.Name = "lbl4";
      this.lbl4.Size = new Size(35, 16);
      this.lbl4.TabIndex = 3;
      this.lbl4.Text = "VND";
      this.lbl3.AutoSize = true;
      this.lbl3.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl3.ForeColor = Color.DimGray;
      this.lbl3.Location = new Point(272, 25);
      this.lbl3.Name = "lbl3";
      this.lbl3.Size = new Size(35, 16);
      this.lbl3.TabIndex = 2;
      this.lbl3.Text = "VND";
      this.groupBox1.Controls.Add((Control) this.txtDongiaLoto);
      this.groupBox1.Controls.Add((Control) this.txtTileanLoto);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.lbl2);
      this.groupBox1.Controls.Add((Control) this.lbl1);
      this.groupBox1.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.groupBox1.Location = new Point(56, 130);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(422, 100);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Loto";
      this.txtDongiaLoto.BorderStyle = BorderStyle.FixedSingle;
      this.txtDongiaLoto.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDongiaLoto.ForeColor = Color.Red;
      this.txtDongiaLoto.Location = new Point(87, 23);
      this.txtDongiaLoto.Name = "txtDongiaLoto";
      this.txtDongiaLoto.Size = new Size(184, 22);
      this.txtDongiaLoto.TabIndex = 0;
      this.txtDongiaLoto.Tag = (object) "0";
      this.txtDongiaLoto.Text = "23000";
      this.toolTip1.SetToolTip((Control) this.txtDongiaLoto, "Đơn giá trên một điểm loto");
      this.txtTileanLoto.BorderStyle = BorderStyle.FixedSingle;
      this.txtTileanLoto.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTileanLoto.ForeColor = Color.Red;
      this.txtTileanLoto.Location = new Point(87, 62);
      this.txtTileanLoto.Name = "txtTileanLoto";
      this.txtTileanLoto.Size = new Size(219, 22);
      this.txtTileanLoto.TabIndex = 1;
      this.txtTileanLoto.Tag = (object) "0";
      this.txtTileanLoto.Text = "80000";
      this.toolTip1.SetToolTip((Control) this.txtTileanLoto, "Tỉ lệ ăn trên một điểm loto");
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DimGray;
      this.label5.Location = new Point(12, 26);
      this.label5.Name = "label5";
      this.label5.Size = new Size(68, 17);
      this.label5.TabIndex = 1;
      this.label5.Text = "Đơn giá :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DimGray;
      this.label3.Location = new Point(16, 65);
      this.label3.Name = "label3";
      this.label3.Size = new Size(63, 17);
      this.label3.TabIndex = 1;
      this.label3.Text = "Tỉ lệ ăn :";
      this.lbl2.AutoSize = true;
      this.lbl2.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl2.ForeColor = Color.DimGray;
      this.lbl2.Location = new Point(307, 65);
      this.lbl2.Name = "lbl2";
      this.lbl2.Size = new Size(35, 16);
      this.lbl2.TabIndex = 3;
      this.lbl2.Text = "VND";
      this.lbl1.AutoSize = true;
      this.lbl1.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl1.ForeColor = Color.DimGray;
      this.lbl1.Location = new Point(272, 26);
      this.lbl1.Name = "lbl1";
      this.lbl1.Size = new Size(35, 16);
      this.lbl1.TabIndex = 2;
      this.lbl1.Text = "VND";
      this.lbl0.AutoSize = true;
      this.lbl0.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl0.ForeColor = Color.DimGray;
      this.lbl0.Location = new Point(361, 106);
      this.lbl0.Name = "lbl0";
      this.lbl0.Size = new Size(35, 16);
      this.lbl0.TabIndex = 7;
      this.lbl0.Text = "VND";
      this.btnDangki.ActiveBorderThickness = 1;
      this.btnDangki.ActiveCornerRadius = 20;
      this.btnDangki.ActiveFillColor = Color.DodgerBlue;
      this.btnDangki.ActiveForecolor = Color.White;
      this.btnDangki.ActiveLineColor = Color.DodgerBlue;
      this.btnDangki.BackColor = Color.White;
      this.btnDangki.BackgroundImage = (Image) componentResourceManager.GetObject("btnDangki.BackgroundImage");
      this.btnDangki.ButtonText = "Thêm mới";
      this.btnDangki.Cursor = Cursors.Hand;
      this.btnDangki.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDangki.ForeColor = Color.Black;
      this.btnDangki.IdleBorderThickness = 1;
      this.btnDangki.IdleCornerRadius = 20;
      this.btnDangki.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.IdleForecolor = Color.FromArgb(247, 248, 249);
      this.btnDangki.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.Location = new Point(143, 361);
      this.btnDangki.Margin = new Padding(6, 5, 6, 5);
      this.btnDangki.Name = "btnDangki";
      this.btnDangki.Size = new Size(335, 40);
      this.btnDangki.TabIndex = 5;
      this.btnDangki.TextAlign = ContentAlignment.MiddleCenter;
      this.btnDangki.Click += new EventHandler(this.BtnDangkiClick);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Cursor = Cursors.Hand;
      this.linkLabel1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(81, 372);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(49, 16);
      this.linkLabel1.TabIndex = 6;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Hủy bỏ";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DimGray;
      this.label2.Location = new Point(71, 105);
      this.label2.Name = "label2";
      this.label2.Size = new Size(70, 17);
      this.label2.TabIndex = 3;
      this.label2.Text = "Mục tiêu :";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DimGray;
      this.label8.Location = new Point(39, 73);
      this.label8.Name = "label8";
      this.label8.Size = new Size(102, 17);
      this.label8.TabIndex = 2;
      this.label8.Text = "Đơn vị tiền tệ :";
      this.lblThongbao.AutoSize = true;
      this.lblThongbao.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThongbao.ForeColor = Color.Red;
      this.lblThongbao.Location = new Point(58, 342);
      this.lblThongbao.Name = "lblThongbao";
      this.lblThongbao.Size = new Size(335, 15);
      this.lblThongbao.TabIndex = 6;
      this.lblThongbao.Text = "*Các chu kì đã thêm sẽ không thể chỉnh sửa hoặc thêm mới";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DimGray;
      this.label4.Location = new Point(58, 42);
      this.label4.Name = "label4";
      this.label4.Size = new Size(83, 17);
      this.label4.TabIndex = 1;
      this.label4.Text = "Tên chu kì :";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(179, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(173, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "THÊM MỚI CHU KỲ LÔ";
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(753, 231);
      this.picMainTop.TabIndex = 11;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.picMainTop_MouseDown);
      this.toolTip1.AutomaticDelay = 200;
      this.bunifuElipse1.ElipseRadius = 10;
      this.bunifuElipse1.TargetControl = (Control) this.panel1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(753, 439);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.picMainTop);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FChuki);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Thêm mới chu kỳ";
      this.Load += new EventHandler(this.fChuki_Load);
      this.bunifuImageButton3.EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.ResumeLayout(false);
    }
  }
}
