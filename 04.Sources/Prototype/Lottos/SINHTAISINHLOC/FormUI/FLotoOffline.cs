// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FLotoOffline
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
  public class FLotoOffline : Form
  {
    private IContainer components = (IContainer) null;
    private Decimal _hesonhanDecimal;
    private Decimal _tileanDecimal;
    private readonly string _action;
    private Decimal _tongVon;
    private Decimal _tongLai;
    private int _loai;
    private TbLoOffline _objTbLoOffline;
    private BunifuImageButton bunifuImageButton3;
    private Panel panel1;
    private TextBox txtSochot_homnay;
    private BunifuThinButton2 btnXuly;
    private LinkLabel linkLabel1;
    private Label label8;
    private Label lblThongbao;
    private Label label4;
    private Label label1;
    private PictureBox picMainTop;
    private ComboBox comboBoxChot_Loto_Dacbiet;
    private TextBox txtTongdiemDanh;
    private Label label2;
    private Label label3;
    private TextBox txtDuno;
    private Label lbl5;
    private TextBox txtSo_loto_Ve;
    private Label lblTonglai;
    private Label label12;
    private Label lblTongvon;
    private Label label9;
    private Label label10;
    private Label label6;
    private Label label7;
    private Label label5;
    private TextBox txtTenchuki;
    private Label label14;
    private ToolTip toolTip1;
    private Label lblDongia;
    private Label lblTilean;
    private Label label16;
    private Label label15;
    private BunifuElipse bunifuElipse1;
    private tbChukidanh objChukidanh;
    private ComboBox comboBoxDanhNgay;
    private TextBox txtNguonloto;
    private Label label11;

    public int MaChuki { private get; set; }

    public int MaChotLoto { get; set; }

    public FLotoOffline(int maChuki, string action, int maChotLoto)
    {
      this.MaChuki = maChuki;
      this.MaChotLoto = maChotLoto;
      this._action = action;
      this.InitializeComponent();
      this.objChukidanh = new tbChukidanh();
      this._objTbLoOffline = new TbLoOffline();
    }

    private void Get_Info_tbChuki(int stt)
    {
      this.objChukidanh = this.objChukidanh.GetInfor(stt);
      this.txtTenchuki.Text = this.objChukidanh.tenChuki;
      this.lblDongia.Text = this.lblTilean.Text = this.lblTongvon.Text = this.lblTonglai.Text = this.lbl5.Text = this.objChukidanh.donviTien;
    }

    private void Get_Info_ChotLoto(int maChotLoto)
    {
      this._objTbLoOffline = this._objTbLoOffline.GetInfor(maChotLoto);
      if (this._objTbLoOffline.HinhThucDanh == null)
        return;
      this.comboBoxChot_Loto_Dacbiet.SelectedIndex = 0;
      this.comboBoxChot_Loto_Dacbiet.SelectedIndex = int.Parse(this._objTbLoOffline.HinhThucDanh);
      this.txtSochot_homnay.Text = this._objTbLoOffline.SoChot;
      TextBox txtTongdiemDanh = this.txtTongdiemDanh;
      Decimal num = this._objTbLoOffline.TongDiem;
      string str1 = num.ToString();
      txtTongdiemDanh.Text = str1;
      TextBox txtSoLotoVe = this.txtSo_loto_Ve;
      num = this._objTbLoOffline.SoLove;
      string str2 = num.ToString();
      txtSoLotoVe.Text = str2;
      this.lblTongvon.Text = ClMain.QuiDoiSoLuong(this._objTbLoOffline.SoVon, this.objChukidanh.donviTien);
      this.lblTonglai.Text = ClMain.QuiDoiSoLuong(this._objTbLoOffline.SoLai, this.objChukidanh.donviTien);
      this.comboBoxDanhNgay.SelectedIndex = int.Parse(this._objTbLoOffline.NgayDanh) - 1;
      this.txtDuno.Text = this._objTbLoOffline.DuNo;
      this.txtNguonloto.Text = this._objTbLoOffline.Nguonloto;
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      this.CloseForm();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.CloseForm();
    }

    private void CloseForm()
    {
      this.Close();
    }

    private void comboBoxChot_Loto_Dacbiet_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBoxChot_Loto_Dacbiet.SelectedIndex == 0)
      {
        this._hesonhanDecimal = this.objChukidanh.hesoNhanLo;
        this._tileanDecimal = this.objChukidanh.tileAnLo;
        this.lblDongia.Text = ClMain.QuiDoiSoLuong(this._hesonhanDecimal.ToString(), this.objChukidanh.donviTien);
        this.lblTilean.Text = ClMain.QuiDoiSoLuong(this._tileanDecimal.ToString(), this.objChukidanh.donviTien);
        this._loai = 0;
        this.comboBoxDanhNgay.Enabled = false;
      }
      if (this.comboBoxChot_Loto_Dacbiet.SelectedIndex == 1)
      {
        this._hesonhanDecimal = this.objChukidanh.hesoNhanLo;
        this._tileanDecimal = this.objChukidanh.tileAnLo;
        this.lblDongia.Text = ClMain.QuiDoiSoLuong(this._hesonhanDecimal.ToString(), this.objChukidanh.donviTien);
        this.lblTilean.Text = ClMain.QuiDoiSoLuong(this._tileanDecimal.ToString(), this.objChukidanh.donviTien);
        this._loai = 1;
        this.comboBoxDanhNgay.Enabled = true;
      }
      if (this.comboBoxChot_Loto_Dacbiet.SelectedIndex == 2)
      {
        this._hesonhanDecimal = this.objChukidanh.hesoNhanDe;
        this._tileanDecimal = this.objChukidanh.tileAnDe;
        this.lblDongia.Text = ClMain.QuiDoiSoLuong(this._hesonhanDecimal.ToString(), this.objChukidanh.donviTien);
        this.lblTilean.Text = ClMain.QuiDoiSoLuong(this._tileanDecimal.ToString(), this.objChukidanh.donviTien);
        this._loai = 2;
        this.comboBoxDanhNgay.Enabled = false;
      }
      if (this.comboBoxChot_Loto_Dacbiet.SelectedIndex == 3)
      {
        this._hesonhanDecimal = this.objChukidanh.hesoNhanDe;
        this._tileanDecimal = this.objChukidanh.tileAnDe;
        this.lblDongia.Text = ClMain.QuiDoiSoLuong(this._hesonhanDecimal.ToString(), this.objChukidanh.donviTien);
        this.lblTilean.Text = ClMain.QuiDoiSoLuong(this._tileanDecimal.ToString(), this.objChukidanh.donviTien);
        this._loai = 3;
        this.comboBoxDanhNgay.Enabled = true;
      }
      this.tinhVon_Lai();
    }

    private void FLotoOffline_Load(object sender, EventArgs e)
    {
      this.Get_Info_tbChuki(this.MaChuki);
      this.comboBoxChot_Loto_Dacbiet.SelectedIndex = 0;
      this.comboBoxDanhNgay.SelectedIndex = 0;
      this.btnXuly.ButtonText = this._action == "add" ? "Tự tin chốt" : "Cập nhật";
      if (!(this._action == "update"))
        return;
      this.Get_Info_ChotLoto(this.MaChotLoto);
    }

    private void txtTongdiemDanh_TextChanged(object sender, EventArgs e)
    {
      this.tinhVon_Lai();
    }

    private void tinhVon_Lai()
    {
      this.lblThongbao.Text = Resources.FLotoOffline_tinhVon_Lai__Hãy__tự_tin_vào_chính_bản_thân_bạn;
      if (this.txtTongdiemDanh.Text.Length < 8 && ClMain.IsNumber(this.txtTongdiemDanh.Text) && Decimal.Parse(this.txtTongdiemDanh.Text) > Decimal.Zero)
      {
        this._tongVon = this._hesonhanDecimal * Decimal.Parse(this.txtTongdiemDanh.Text);
        this.lblTongvon.Text = ClMain.QuiDoiSoLuong(this._tongVon.ToString(), this.objChukidanh.donviTien);
        if (this.txtSo_loto_Ve.Text.Length < 7 && ClMain.IsNumber(this.txtTongdiemDanh.Text) && (ClMain.IsNumber(this.txtSo_loto_Ve.Text) && Decimal.Parse(this.txtSo_loto_Ve.Text) > Decimal.MinusOne) && Decimal.Parse(this.txtTongdiemDanh.Text) > Decimal.Zero)
        {
          this._tongLai = this._tileanDecimal * Decimal.Parse(this.txtSo_loto_Ve.Text) - this._tongVon;
          this.lblTonglai.Text = ClMain.QuiDoiSoLuong(this._tongLai.ToString(), this.objChukidanh.donviTien);
        }
        else
        {
          this._tongLai = new Decimal();
          this.lblTonglai.Text = this.lblTongvon.Text = ClMain.QuiDoiSoLuong(Resources.FLotoOffline_tinhVon_Lai__0, this.objChukidanh.donviTien);
          this.txtSo_loto_Ve.Focus();
        }
      }
      else
      {
        this._tongVon = new Decimal();
        this.lblTongvon.Text = ClMain.QuiDoiSoLuong(Resources.FLotoOffline_tinhVon_Lai__0, this.objChukidanh.donviTien);
        this.txtTongdiemDanh.Focus();
      }
    }

    private void txtSo_loto_Ve_TextChanged(object sender, EventArgs e)
    {
      this.tinhVon_Lai();
    }

    private void btnDangki_Click(object sender, EventArgs e)
    {
      TbLoOffline tbLoOffline = new TbLoOffline();
      if (this.txtSochot_homnay.Text.Length < 2)
      {
        this.lblThongbao.Text = Resources.FLotoOffline_btnDangki_Click__Nhập_vào_lô_tô_mà_bạn_chốt_hôm_nay;
        this.txtSochot_homnay.Focus();
      }
      else if (!ClMain.IsNumber(this.txtTongdiemDanh.Text) || Decimal.Parse(this.txtTongdiemDanh.Text) < Decimal.One)
      {
        this.lblThongbao.Text = Resources.FLotoOffline_btnDangki_Click__Tổng_số_điểm_chốt_phải___0;
        this.txtTongdiemDanh.Focus();
      }
      else if (!ClMain.IsNumber(this.txtSo_loto_Ve.Text) || Decimal.Parse(this.txtSo_loto_Ve.Text) < Decimal.Zero)
      {
        this.lblThongbao.Text = Resources.FLotoOffline_btnDangki_Click__Số_lô_tô_về_số_nháy__phải_là_số;
        this.txtSo_loto_Ve.Focus();
      }
      else if (!ClMain.IsNumber(this.txtDuno.Text))
      {
        this.lblThongbao.Text = Resources.FLotoOffline_btnDangki_Click__Số_tiền_đã_thanh_toán_không_chính_xác;
        this.txtDuno.Focus();
      }
      else
      {
        this.lblThongbao.Text = Resources.FLotoOffline_btnDangki_Click__Hệ_số_nhân_được_tính_cho_các_con_lô_bằng_điểm;
        tbLoOffline.Stt = this.MaChotLoto;
        tbLoOffline.MaChuki = this.MaChuki;
        tbLoOffline.TenDangnhap = TbUser.Tbuser.TenDangnhap;
        tbLoOffline.TenChuki = this.txtTenchuki.Text;
        tbLoOffline.SoChot = this.txtSochot_homnay.Text;
        tbLoOffline.TongDiem = Decimal.Parse(this.txtTongdiemDanh.Text);
        tbLoOffline.SoLove = Decimal.Parse(this.txtSo_loto_Ve.Text);
        tbLoOffline.SoVon = this._tongVon.ToString();
        tbLoOffline.SoLai = this._tongLai.ToString();
        tbLoOffline.NgayDanh = (this.comboBoxDanhNgay.SelectedIndex + 1).ToString();
        tbLoOffline.DuNo = this.txtDuno.Text;
        tbLoOffline.HinhThucDanh = this._loai.ToString();
        tbLoOffline.Nguonloto = this.txtNguonloto.Text;
        if (this._action == "add")
        {
          if (tbLoOffline.Insert(tbLoOffline))
          {
            int num = (int) MessageBox.Show(Resources.FLotoOffline_btnDangki_Click_BẠN_ĐÃ_CHỐT_THÀNH_CÔNG, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            TabVaotienChukiDanh.LoadLaiDuLieu_Combobox = 1;
            TabThongkeCanhan.LoadLaiForm = 1;
            this.Close();
          }
          else
          {
            int num = (int) MessageBox.Show(Resources.FLotoOffline_btnDangki_Click_LỖI_THÊM_DỮ_LIỆU, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
          }
        }
        else if (this._action == "update")
        {
          if (tbLoOffline.Update(tbLoOffline))
          {
            int num = (int) MessageBox.Show(Resources.FLotoOffline_btnDangki_Click_CẬP_NHẬT_THÔNG_TIN_THÀNH_CÔNG, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            TabVaotienChukiDanh.LoadLaiDuLieu_Combobox = 1;
            TabThongkeCanhan.LoadLaiForm = 1;
            this.Close();
          }
          else
          {
            int num = (int) MessageBox.Show(Resources.FLotoOffline_btnDangki_Click_CẬP_NHẬT_THÔNG_TIN_KHÔNG_THÀNH_CÔNG, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
          }
        }
      }
    }

    private void picMainTop_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void label14_Click(object sender, EventArgs e)
    {
    }

    private void label8_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void label5_Click(object sender, EventArgs e)
    {
    }

    private void label15_Click(object sender, EventArgs e)
    {
    }

    private void label16_Click(object sender, EventArgs e)
    {
    }

    private void label9_Click(object sender, EventArgs e)
    {
    }

    private void label12_Click(object sender, EventArgs e)
    {
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FLotoOffline));
      this.bunifuImageButton3 = new BunifuImageButton();
      this.panel1 = new Panel();
      this.txtNguonloto = new TextBox();
      this.label11 = new Label();
      this.comboBoxDanhNgay = new ComboBox();
      this.comboBoxChot_Loto_Dacbiet = new ComboBox();
      this.txtDuno = new TextBox();
      this.lbl5 = new Label();
      this.txtSo_loto_Ve = new TextBox();
      this.lblTonglai = new Label();
      this.txtTenchuki = new TextBox();
      this.txtTongdiemDanh = new TextBox();
      this.label12 = new Label();
      this.lblDongia = new Label();
      this.lblTilean = new Label();
      this.lblTongvon = new Label();
      this.label9 = new Label();
      this.txtSochot_homnay = new TextBox();
      this.label10 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.btnXuly = new BunifuThinButton2();
      this.label16 = new Label();
      this.label5 = new Label();
      this.label15 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.linkLabel1 = new LinkLabel();
      this.label8 = new Label();
      this.lblThongbao = new Label();
      this.label14 = new Label();
      this.label4 = new Label();
      this.label1 = new Label();
      this.picMainTop = new PictureBox();
      this.toolTip1 = new ToolTip(this.components);
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.bunifuImageButton3.BeginInit();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.SuspendLayout();
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(672, 2);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(22, 22);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 15;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.txtNguonloto);
      this.panel1.Controls.Add((Control) this.label11);
      this.panel1.Controls.Add((Control) this.comboBoxDanhNgay);
      this.panel1.Controls.Add((Control) this.comboBoxChot_Loto_Dacbiet);
      this.panel1.Controls.Add((Control) this.txtDuno);
      this.panel1.Controls.Add((Control) this.lbl5);
      this.panel1.Controls.Add((Control) this.txtSo_loto_Ve);
      this.panel1.Controls.Add((Control) this.lblTonglai);
      this.panel1.Controls.Add((Control) this.txtTenchuki);
      this.panel1.Controls.Add((Control) this.txtTongdiemDanh);
      this.panel1.Controls.Add((Control) this.label12);
      this.panel1.Controls.Add((Control) this.lblDongia);
      this.panel1.Controls.Add((Control) this.lblTilean);
      this.panel1.Controls.Add((Control) this.lblTongvon);
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.txtSochot_homnay);
      this.panel1.Controls.Add((Control) this.label10);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Controls.Add((Control) this.btnXuly);
      this.panel1.Controls.Add((Control) this.label16);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.label15);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.label8);
      this.panel1.Controls.Add((Control) this.lblThongbao);
      this.panel1.Controls.Add((Control) this.label14);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel1.Location = new Point(78, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(542, 448);
      this.panel1.TabIndex = 13;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.txtNguonloto.BackColor = Color.White;
      this.txtNguonloto.BorderStyle = BorderStyle.FixedSingle;
      this.txtNguonloto.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtNguonloto.ForeColor = Color.DarkRed;
      this.txtNguonloto.Location = new Point(134, 339);
      this.txtNguonloto.Multiline = true;
      this.txtNguonloto.Name = "txtNguonloto";
      this.txtNguonloto.Size = new Size(335, 36);
      this.txtNguonloto.TabIndex = 7;
      this.txtNguonloto.Tag = (object) "0";
      this.txtNguonloto.Text = "G3:4:2-G5:1:6";
      this.toolTip1.SetToolTip((Control) this.txtNguonloto, "Bộ số bạn chốt hôm nay được lấy từ nguồn nào");
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = SystemColors.ControlDarkDark;
      this.label11.Location = new Point(48, 341);
      this.label11.Name = "label11";
      this.label11.Size = new Size(82, 16);
      this.label11.TabIndex = 34;
      this.label11.Text = "Nguồn lô tô :";
      this.comboBoxDanhNgay.BackColor = Color.Teal;
      this.comboBoxDanhNgay.Cursor = Cursors.Hand;
      this.comboBoxDanhNgay.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxDanhNgay.FlatStyle = FlatStyle.Popup;
      this.comboBoxDanhNgay.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.comboBoxDanhNgay.ForeColor = Color.White;
      this.comboBoxDanhNgay.FormattingEnabled = true;
      this.comboBoxDanhNgay.Items.AddRange(new object[8]
      {
        (object) "                                Ngày [ 1 ]              ",
        (object) "                                Ngày [ 2 ]              ",
        (object) "                                Ngày [ 3 ]              ",
        (object) "                                Ngày [ 4 ]              ",
        (object) "                                Ngày [ 5 ]              ",
        (object) "                                Ngày [ 6 ]              ",
        (object) "                                Ngày [ 7 ]              ",
        (object) "                                Ngày [ 8 ]              "
      });
      this.comboBoxDanhNgay.Location = new Point(134, 278);
      this.comboBoxDanhNgay.Name = "comboBoxDanhNgay";
      this.comboBoxDanhNgay.Size = new Size(335, 24);
      this.comboBoxDanhNgay.TabIndex = 5;
      this.comboBoxChot_Loto_Dacbiet.BackColor = Color.Teal;
      this.comboBoxChot_Loto_Dacbiet.Cursor = Cursors.Hand;
      this.comboBoxChot_Loto_Dacbiet.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxChot_Loto_Dacbiet.FlatStyle = FlatStyle.Popup;
      this.comboBoxChot_Loto_Dacbiet.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.comboBoxChot_Loto_Dacbiet.ForeColor = Color.White;
      this.comboBoxChot_Loto_Dacbiet.FormattingEnabled = true;
      this.comboBoxChot_Loto_Dacbiet.Items.AddRange(new object[4]
      {
        (object) "                              Chốt Lô Ngày",
        (object) "                           Chốt Lô Cặp Nuôi",
        (object) "                     Chốt Đặc Biệt Đánh Ngày",
        (object) "                     Chốt Đặc Biệt Đánh Nuôi"
      });
      this.comboBoxChot_Loto_Dacbiet.Location = new Point(133, 69);
      this.comboBoxChot_Loto_Dacbiet.Name = "comboBoxChot_Loto_Dacbiet";
      this.comboBoxChot_Loto_Dacbiet.Size = new Size(338, 24);
      this.comboBoxChot_Loto_Dacbiet.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.comboBoxChot_Loto_Dacbiet, "Bạn muốn chốt lô tô hay đặc biệt");
      this.comboBoxChot_Loto_Dacbiet.SelectedIndexChanged += new EventHandler(this.comboBoxChot_Loto_Dacbiet_SelectedIndexChanged);
      this.txtDuno.BackColor = Color.White;
      this.txtDuno.BorderStyle = BorderStyle.FixedSingle;
      this.txtDuno.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDuno.ForeColor = Color.DarkRed;
      this.txtDuno.Location = new Point(134, 308);
      this.txtDuno.Name = "txtDuno";
      this.txtDuno.Size = new Size(304, 22);
      this.txtDuno.TabIndex = 6;
      this.txtDuno.Tag = (object) "0";
      this.txtDuno.Text = "0";
      this.toolTip1.SetToolTip((Control) this.txtDuno, "Dư nợ mà bạn nợ hoặc chủ lô nợ");
      this.lbl5.AutoSize = true;
      this.lbl5.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl5.ForeColor = Color.Black;
      this.lbl5.Location = new Point(440, 311);
      this.lbl5.Name = "lbl5";
      this.lbl5.Size = new Size(31, 15);
      this.lbl5.TabIndex = 20;
      this.lbl5.Text = "VND";
      this.txtSo_loto_Ve.BorderStyle = BorderStyle.FixedSingle;
      this.txtSo_loto_Ve.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtSo_loto_Ve.ForeColor = Color.Black;
      this.txtSo_loto_Ve.Location = new Point(134, 196);
      this.txtSo_loto_Ve.Name = "txtSo_loto_Ve";
      this.txtSo_loto_Ve.Size = new Size(251, 22);
      this.txtSo_loto_Ve.TabIndex = 4;
      this.txtSo_loto_Ve.Tag = (object) "0";
      this.txtSo_loto_Ve.Text = "0";
      this.toolTip1.SetToolTip((Control) this.txtSo_loto_Ve, "Số nháy về");
      this.txtSo_loto_Ve.TextChanged += new EventHandler(this.txtSo_loto_Ve_TextChanged);
      this.lblTonglai.AutoSize = true;
      this.lblTonglai.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTonglai.ForeColor = Color.Black;
      this.lblTonglai.Location = new Point(341, 256);
      this.lblTonglai.Name = "lblTonglai";
      this.lblTonglai.Size = new Size(31, 15);
      this.lblTonglai.TabIndex = 18;
      this.lblTonglai.Text = "VND";
      this.txtTenchuki.BackColor = Color.White;
      this.txtTenchuki.BorderStyle = BorderStyle.FixedSingle;
      this.txtTenchuki.Enabled = false;
      this.txtTenchuki.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTenchuki.ForeColor = Color.DarkRed;
      this.txtTenchuki.Location = new Point(134, 39);
      this.txtTenchuki.Name = "txtTenchuki";
      this.txtTenchuki.Size = new Size(337, 22);
      this.txtTenchuki.TabIndex = 0;
      this.txtTenchuki.Tag = (object) "0";
      this.txtTenchuki.Text = "Tiêu diệt chủ lô 1";
      this.toolTip1.SetToolTip((Control) this.txtTenchuki, "Tên chu kì");
      this.txtTongdiemDanh.BorderStyle = BorderStyle.FixedSingle;
      this.txtTongdiemDanh.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTongdiemDanh.ForeColor = Color.DarkRed;
      this.txtTongdiemDanh.Location = new Point(134, 168);
      this.txtTongdiemDanh.Name = "txtTongdiemDanh";
      this.txtTongdiemDanh.Size = new Size(251, 22);
      this.txtTongdiemDanh.TabIndex = 3;
      this.txtTongdiemDanh.Tag = (object) "0";
      this.txtTongdiemDanh.Text = "0";
      this.toolTip1.SetToolTip((Control) this.txtTongdiemDanh, "Tổng điểm các con lô mà bạn chốt");
      this.txtTongdiemDanh.TextChanged += new EventHandler(this.txtTongdiemDanh_TextChanged);
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = SystemColors.ControlDarkDark;
      this.label12.Location = new Point(76, 309);
      this.label12.Name = "label12";
      this.label12.Size = new Size(54, 16);
      this.label12.TabIndex = 8;
      this.label12.Text = "Dư nợ :";
      this.label12.Click += new EventHandler(this.label12_Click);
      this.lblDongia.AutoSize = true;
      this.lblDongia.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblDongia.ForeColor = Color.Black;
      this.lblDongia.Location = new Point(131, 228);
      this.lblDongia.Name = "lblDongia";
      this.lblDongia.Size = new Size(31, 15);
      this.lblDongia.TabIndex = 15;
      this.lblDongia.Text = "VND";
      this.lblTilean.AutoSize = true;
      this.lblTilean.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTilean.ForeColor = Color.Black;
      this.lblTilean.Location = new Point(131, 256);
      this.lblTilean.Name = "lblTilean";
      this.lblTilean.Size = new Size(31, 15);
      this.lblTilean.TabIndex = 16;
      this.lblTilean.Text = "VND";
      this.lblTongvon.AutoSize = true;
      this.lblTongvon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTongvon.ForeColor = Color.Black;
      this.lblTongvon.Location = new Point(341, 229);
      this.lblTongvon.Name = "lblTongvon";
      this.lblTongvon.Size = new Size(31, 15);
      this.lblTongvon.TabIndex = 17;
      this.lblTongvon.Text = "VND";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = SystemColors.ControlDarkDark;
      this.label9.Location = new Point(52, 280);
      this.label9.Name = "label9";
      this.label9.Size = new Size(78, 16);
      this.label9.TabIndex = 7;
      this.label9.Text = "Đánh ngày :";
      this.label9.Click += new EventHandler(this.label9_Click);
      this.txtSochot_homnay.BackColor = Color.White;
      this.txtSochot_homnay.BorderStyle = BorderStyle.FixedSingle;
      this.txtSochot_homnay.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtSochot_homnay.ForeColor = Color.DarkRed;
      this.txtSochot_homnay.HideSelection = false;
      this.txtSochot_homnay.Location = new Point(134, 102);
      this.txtSochot_homnay.Multiline = true;
      this.txtSochot_homnay.Name = "txtSochot_homnay";
      this.txtSochot_homnay.Size = new Size(335, 59);
      this.txtSochot_homnay.TabIndex = 2;
      this.txtSochot_homnay.Tag = (object) "0";
      this.toolTip1.SetToolTip((Control) this.txtSochot_homnay, "Số chốt hôm nay của bạn");
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = SystemColors.ControlDarkDark;
      this.label10.Location = new Point(311, 254);
      this.label10.Name = "label10";
      this.label10.Size = new Size(33, 16);
      this.label10.TabIndex = 6;
      this.label10.Text = "Lãi :";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = SystemColors.ControlDarkDark;
      this.label6.Location = new Point(386, 199);
      this.label6.Name = "label6";
      this.label6.Size = new Size(36, 16);
      this.label6.TabIndex = 10;
      this.label6.Text = "điểm";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = SystemColors.ControlDarkDark;
      this.label7.Location = new Point(279, 227);
      this.label7.Name = "label7";
      this.label7.Size = new Size(64, 16);
      this.label7.TabIndex = 5;
      this.label7.Text = "Vốn cần :";
      this.btnXuly.ActiveBorderThickness = 1;
      this.btnXuly.ActiveCornerRadius = 20;
      this.btnXuly.ActiveFillColor = Color.DodgerBlue;
      this.btnXuly.ActiveForecolor = Color.White;
      this.btnXuly.ActiveLineColor = Color.DodgerBlue;
      this.btnXuly.BackColor = Color.White;
      this.btnXuly.BackgroundImage = (Image) componentResourceManager.GetObject("btnXuly.BackgroundImage");
      this.btnXuly.ButtonText = "Tự tin chốt";
      this.btnXuly.Cursor = Cursors.Hand;
      this.btnXuly.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnXuly.ForeColor = Color.Black;
      this.btnXuly.IdleBorderThickness = 1;
      this.btnXuly.IdleCornerRadius = 20;
      this.btnXuly.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnXuly.IdleForecolor = Color.White;
      this.btnXuly.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnXuly.Location = new Point(187, 403);
      this.btnXuly.Margin = new Padding(6, 5, 6, 5);
      this.btnXuly.Name = "btnXuly";
      this.btnXuly.Size = new Size(282, 41);
      this.btnXuly.TabIndex = 8;
      this.btnXuly.TextAlign = ContentAlignment.MiddleCenter;
      this.btnXuly.Click += new EventHandler(this.btnDangki_Click);
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.ForeColor = SystemColors.ControlDarkDark;
      this.label16.Location = new Point(72, 254);
      this.label16.Name = "label16";
      this.label16.Size = new Size(58, 16);
      this.label16.TabIndex = 12;
      this.label16.Text = "Tỉ lệ ăn :";
      this.label16.Click += new EventHandler(this.label16_Click);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = SystemColors.ControlDarkDark;
      this.label5.Location = new Point(62, 198);
      this.label5.Name = "label5";
      this.label5.Size = new Size(68, 16);
      this.label5.TabIndex = 4;
      this.label5.Text = "Được ăn :";
      this.label5.Click += new EventHandler(this.label5_Click);
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = SystemColors.ControlDarkDark;
      this.label15.Location = new Point(68, 227);
      this.label15.Name = "label15";
      this.label15.Size = new Size(62, 16);
      this.label15.TabIndex = 11;
      this.label15.Text = "Đơn giá :";
      this.label15.Click += new EventHandler(this.label15_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = SystemColors.ControlDarkDark;
      this.label3.Location = new Point(386, 171);
      this.label3.Name = "label3";
      this.label3.Size = new Size(36, 16);
      this.label3.TabIndex = 9;
      this.label3.Text = "điểm";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = SystemColors.ControlDarkDark;
      this.label2.Location = new Point(54, 170);
      this.label2.Name = "label2";
      this.label2.Size = new Size(76, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "Tổng điểm :";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Cursor = Cursors.Hand;
      this.linkLabel1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(134, 416);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(49, 16);
      this.linkLabel1.TabIndex = 9;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Hủy bỏ";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = SystemColors.ControlDarkDark;
      this.label8.Location = new Point(80, 103);
      this.label8.Name = "label8";
      this.label8.Size = new Size(50, 16);
      this.label8.TabIndex = 6;
      this.label8.Text = "Bộ số :";
      this.label8.Click += new EventHandler(this.label8_Click);
      this.lblThongbao.AutoSize = true;
      this.lblThongbao.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThongbao.ForeColor = Color.Red;
      this.lblThongbao.Location = new Point(131, 385);
      this.lblThongbao.Name = "lblThongbao";
      this.lblThongbao.Size = new Size(274, 15);
      this.lblThongbao.TabIndex = 21;
      this.lblThongbao.Text = "*Hệ số nhân được tính cho các con lô bằng điểm";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = SystemColors.ControlDarkDark;
      this.label14.Location = new Point(54, 40);
      this.label14.Name = "label14";
      this.label14.Size = new Size(76, 16);
      this.label14.TabIndex = 1;
      this.label14.Text = "Tên chu kì :";
      this.label14.Click += new EventHandler(this.label14_Click);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.ControlDarkDark;
      this.label4.Location = new Point(33, 72);
      this.label4.Name = "label4";
      this.label4.Size = new Size(97, 16);
      this.label4.TabIndex = 2;
      this.label4.Text = "Hôm nay chốt :";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(211, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(130, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "CHỐT SỐ HÔM NAY";
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(696, 238);
      this.picMainTop.TabIndex = 14;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.picMainTop_MouseDown);
      this.toolTip1.AutomaticDelay = 200;
      this.bunifuElipse1.ElipseRadius = 10;
      this.bunifuElipse1.TargetControl = (Control) this.panel1;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(696, 471);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.picMainTop);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FLotoOffline);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Chốt số";
      this.Load += new EventHandler(this.FLotoOffline_Load);
      this.bunifuImageButton3.EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.ResumeLayout(false);
    }
  }
}
