// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FVaotien
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
  public class FVaotien : Form
  {
    private Decimal _bienSonhayve = Decimal.One;
    private IContainer components = (IContainer) null;
    private FVaotien.ValueTextBox valueTextBox;
    private Decimal _dongia;
    private Decimal _hesonhan;
    private Decimal _bienTextBox1;
    private Decimal _tongVon;
    private Decimal _tongLai;
    private Decimal _trungBinh;
    private Panel panel1;
    private Label label1;
    private BunifuImageButton bunifuImageButton8;
    private Label label2;
    private Label label3;
    private ComboBox cbbLoto_Dacbiet;
    private ComboBox comboBoxChukiDanh;
    private Panel panel2;
    private TextBox textBox1;
    private Label label4;
    private Label label5;
    private Label label6;
    private BunifuSeparator bunifuSeparator1;
    private BunifuSeparator bunifuSeparator2;
    private TextBox textBox2;
    private Label label7;
    private TextBox textBox3;
    private Label label8;
    private TextBox textBox4;
    private Label label9;
    private TextBox textBox5;
    private Label label10;
    private TextBox textBox6;
    private Label label11;
    private TextBox textBox7;
    private Label label12;
    private TextBox textBox8;
    private Label label13;
    private Label label16;
    private Label label17;
    private Label lblDodaichuki;
    private Label lblTOnglai;
    private Label label20;
    private Label lblTrungbinh;
    private Label label14;
    private ToolTip toolTip1;
    private GroupBox groupBox1;
    private Label label19;
    private Label label18;
    private Label label15;
    private Label label21;
    private Label lblTientrungbinh;
    private Label lblSodiemdanh;
    private Label lblSonhayve;
    private Label lblTongvon;
    private Button button1;
    private BunifuImageButton bunifuImageButton1;
    private ComboBox cbbSonhayve;

    public Decimal DongiaLoto { get; set; }

    public Decimal HesonhanLoto { get; set; }

    public Decimal DongiaDacbiet { get; set; }

    public Decimal HesonhanDacbiet { get; set; }

    public string DonviTiente { get; set; }

    public int SoNgayCuaChuki { get; set; }

    public FVaotien(Decimal dongiaLoto, Decimal hesonhanLoto, Decimal dongiaDacbiet, Decimal hesonhanDacbiet, string donviTiente)
    {
      this.DongiaLoto = dongiaLoto;
      this.HesonhanLoto = hesonhanLoto;
      this.DongiaDacbiet = dongiaDacbiet;
      this.HesonhanDacbiet = hesonhanDacbiet;
      this.DonviTiente = donviTiente;
      this.InitializeComponent();
      this.valueTextBox = new FVaotien.ValueTextBox();
      this.cbbLoto_Dacbiet.SelectedIndex = 0;
      this.comboBoxChukiDanh.SelectedIndex = 0;
      this.textBox1.Text = Resources.FVaotien_FVaotien__1;
      this.cbbSonhayve.SelectedIndex = 0;
    }

    private void bunifuImageButton8_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void comboBoxChukiDanh_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBoxChukiDanh.SelectedIndex == 0)
      {
        this.textBox1.Enabled = true;
        this.textBox2.Enabled = false;
        this.textBox3.Enabled = false;
        this.textBox4.Enabled = false;
        this.textBox5.Enabled = false;
        this.textBox6.Enabled = false;
        this.textBox7.Enabled = false;
        this.textBox8.Enabled = false;
        this.SoNgayCuaChuki = 1;
      }
      if (this.comboBoxChukiDanh.SelectedIndex == 1)
      {
        this.textBox2.Enabled = true;
        this.textBox3.Enabled = false;
        this.textBox4.Enabled = false;
        this.textBox5.Enabled = false;
        this.textBox6.Enabled = false;
        this.textBox7.Enabled = false;
        this.textBox8.Enabled = false;
        this.SoNgayCuaChuki = 2;
      }
      if (this.comboBoxChukiDanh.SelectedIndex == 2)
      {
        this.textBox2.Enabled = true;
        this.textBox3.Enabled = true;
        this.textBox4.Enabled = false;
        this.textBox5.Enabled = false;
        this.textBox6.Enabled = false;
        this.textBox7.Enabled = false;
        this.textBox8.Enabled = false;
        this.SoNgayCuaChuki = 3;
      }
      if (this.comboBoxChukiDanh.SelectedIndex == 3)
      {
        this.textBox2.Enabled = true;
        this.textBox3.Enabled = true;
        this.textBox4.Enabled = true;
        this.textBox5.Enabled = false;
        this.textBox6.Enabled = false;
        this.textBox7.Enabled = false;
        this.textBox8.Enabled = false;
        this.SoNgayCuaChuki = 4;
      }
      if (this.comboBoxChukiDanh.SelectedIndex == 4)
      {
        this.textBox2.Enabled = true;
        this.textBox3.Enabled = true;
        this.textBox4.Enabled = true;
        this.textBox5.Enabled = true;
        this.textBox6.Enabled = false;
        this.textBox7.Enabled = false;
        this.textBox8.Enabled = false;
        this.SoNgayCuaChuki = 5;
      }
      if (this.comboBoxChukiDanh.SelectedIndex == 5)
      {
        this.textBox2.Enabled = true;
        this.textBox3.Enabled = true;
        this.textBox4.Enabled = true;
        this.textBox5.Enabled = true;
        this.textBox6.Enabled = true;
        this.textBox7.Enabled = false;
        this.textBox8.Enabled = false;
        this.SoNgayCuaChuki = 6;
      }
      if (this.comboBoxChukiDanh.SelectedIndex == 6)
      {
        this.textBox2.Enabled = true;
        this.textBox3.Enabled = true;
        this.textBox4.Enabled = true;
        this.textBox5.Enabled = true;
        this.textBox6.Enabled = true;
        this.textBox7.Enabled = true;
        this.textBox8.Enabled = false;
        this.SoNgayCuaChuki = 7;
      }
      if (this.comboBoxChukiDanh.SelectedIndex != 7)
        return;
      this.textBox2.Enabled = true;
      this.textBox3.Enabled = true;
      this.textBox4.Enabled = true;
      this.textBox5.Enabled = true;
      this.textBox6.Enabled = true;
      this.textBox7.Enabled = true;
      this.textBox8.Enabled = true;
      this.SoNgayCuaChuki = 8;
    }

    private void TextBox1KeyPress1(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '0' || e.KeyChar == '1' || (e.KeyChar == '2' || e.KeyChar == '3') || (e.KeyChar == '4' || e.KeyChar == '5' || (e.KeyChar == '6' || e.KeyChar == '7')) || (e.KeyChar == '8' || e.KeyChar == '9' || (e.KeyChar == '\b' || e.KeyChar == '.') || e.KeyChar == '.') || e.KeyChar == ',')
        e.Handled = false;
      else
        e.Handled = true;
    }

    private void CbbLotoDacbietSelectedIndexChanged(object sender, EventArgs e)
    {
      this._bienTextBox1 = Decimal.Parse(this.textBox1.Text);
      this.ChangeValue(this._bienTextBox1);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      this.valueTextBox.SoVonTextBox1 = Decimal.Zero;
      this.valueTextBox.SoLaiTextBox1 = Decimal.Zero;
      this.valueTextBox.SoVonTextBox1 = Decimal.Parse(this.textBox1.Text) * this._dongia;
      this.valueTextBox.SoLaiTextBox1 = Decimal.Parse(this.textBox1.Text) * this._hesonhan;
      if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
        this.valueTextBox.SoLaiTextBox1 = Decimal.One * this._hesonhan;
      Decimal bien = new Decimal();
      TextBox textBox = (TextBox) sender;
      try
      {
        bien = Convert.ToDecimal(textBox.Text);
        if (textBox.Name == "textBox1" && this._bienTextBox1.ToString() != bien.ToString())
        {
          this._bienTextBox1 = bien;
          this.ChangeValue(bien);
        }
        if (textBox.Name == "textBox2")
        {
          this.valueTextBox.SoVonTextBox2 = Decimal.Zero;
          this.valueTextBox.SoLaiTextBox2 = Decimal.Zero;
          this.valueTextBox.SoVonTextBox2 = bien * this._dongia;
          if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
            bien = Decimal.One;
          this.valueTextBox.SoLaiTextBox2 = bien * this._hesonhan;
        }
        if (textBox.Name == "textBox3")
        {
          this.valueTextBox.SoVonTextBox3 = Decimal.Zero;
          this.valueTextBox.SoLaiTextBox3 = Decimal.Zero;
          this.valueTextBox.SoVonTextBox3 = bien * this._dongia;
          if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
            bien = Decimal.One;
          this.valueTextBox.SoLaiTextBox3 = bien * this._hesonhan;
        }
        if (textBox.Name == "textBox4")
        {
          this.valueTextBox.SoVonTextBox4 = Decimal.Zero;
          this.valueTextBox.SoLaiTextBox4 = Decimal.Zero;
          this.valueTextBox.SoVonTextBox4 = bien * this._dongia;
          if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
            bien = Decimal.One;
          this.valueTextBox.SoLaiTextBox4 = bien * this._hesonhan;
        }
        if (textBox.Name == "textBox5")
        {
          this.valueTextBox.SoVonTextBox5 = Decimal.Zero;
          this.valueTextBox.SoLaiTextBox5 = Decimal.Zero;
          this.valueTextBox.SoVonTextBox5 = bien * this._dongia;
          if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
            bien = Decimal.One;
          this.valueTextBox.SoLaiTextBox5 = bien * this._hesonhan;
        }
        if (textBox.Name == "textBox6")
        {
          this.valueTextBox.SoVonTextBox6 = Decimal.Zero;
          this.valueTextBox.SoLaiTextBox6 = Decimal.Zero;
          this.valueTextBox.SoVonTextBox6 = bien * this._dongia;
          if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
            bien = Decimal.One;
          this.valueTextBox.SoLaiTextBox6 = bien * this._hesonhan;
        }
        if (textBox.Name == "textBox7")
        {
          this.valueTextBox.SoVonTextBox7 = Decimal.Zero;
          this.valueTextBox.SoLaiTextBox7 = Decimal.Zero;
          this.valueTextBox.SoVonTextBox7 = bien * this._dongia;
          if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
            bien = Decimal.One;
          this.valueTextBox.SoLaiTextBox7 = bien * this._hesonhan;
        }
        if (textBox.Name == "textBox8")
        {
          this.valueTextBox.SoVonTextBox8 = Decimal.Zero;
          this.valueTextBox.SoLaiTextBox8 = Decimal.Zero;
          this.valueTextBox.SoVonTextBox8 = bien * this._dongia;
          if (this.cbbLoto_Dacbiet.SelectedIndex == 2)
            bien = Decimal.One;
          this.valueTextBox.SoLaiTextBox8 = bien * this._hesonhan;
        }
      }
      catch (Exception ex)
      {
        textBox.Text = Resources.FVaotien_FVaotien__1;
      }
      if (!(Math.Abs(bien) < Decimal.One))
        return;
      textBox.Text = Resources.FVaotien_FVaotien__1;
    }

    private void ChangeValue(Decimal bien)
    {
      this.lblSonhayve.ForeColor = Color.Black;
      this.lblSodiemdanh.ForeColor = Color.Red;
      Decimal num;
      if (this.cbbLoto_Dacbiet.SelectedIndex == 0)
      {
        this._dongia = this.DongiaLoto;
        this._hesonhan = this.HesonhanLoto;
        this.groupBox1.Text = Resources.FVaotien_ChangeValue_lô_bạch_thủ_nuôi;
        this.lblDodaichuki.Text = Resources.FVaotien_ChangeValue_đơn_giá_và_tỉ_lệ_ăn_sẽ_được_tính_theo_chu_kì_mới_nhất_của_bạn;
        this.lblSonhayve.Text = Resources.FVaotien_ChangeValue_số_nháy_về_được_tính_là_số_nháy_về_của_ngày_cuối_cùng_trong_khung;
        this.lblSodiemdanh.Text = Resources.FVaotien_ChangeValue_là_số_điểm_của_một_con_lô___bạch_thủ___bạn_chốt;
        this.lblTientrungbinh.Text = Resources.FVaotien_ChangeValue_là_số_lãi_trung_bình_trên_số_ngày_trong_khung_của_bạn;
        this.textBox1.Text = (bien * Decimal.One).ToString();
        TextBox textBox2 = this.textBox2;
        num = bien * Convert.ToDecimal(1.5);
        string str1 = num.ToString();
        textBox2.Text = str1;
        TextBox textBox3 = this.textBox3;
        num = bien * new Decimal(3);
        string str2 = num.ToString();
        textBox3.Text = str2;
        TextBox textBox4 = this.textBox4;
        num = bien * new Decimal(5);
        string str3 = num.ToString();
        textBox4.Text = str3;
        TextBox textBox5 = this.textBox5;
        num = bien * Convert.ToDecimal(7.5);
        string str4 = num.ToString();
        textBox5.Text = str4;
        TextBox textBox6 = this.textBox6;
        num = bien * new Decimal(11);
        string str5 = num.ToString();
        textBox6.Text = str5;
        TextBox textBox7 = this.textBox7;
        num = bien * new Decimal(16);
        string str6 = num.ToString();
        textBox7.Text = str6;
        TextBox textBox8 = this.textBox8;
        num = bien * new Decimal(23);
        string str7 = num.ToString();
        textBox8.Text = str7;
      }
      if (this.cbbLoto_Dacbiet.SelectedIndex == 1)
      {
        this._dongia = this.DongiaLoto * new Decimal(2);
        this._hesonhan = this.HesonhanLoto;
        this.groupBox1.Text = Resources.FVaotien_ChangeValue_lô_cặp_nuôi;
        this.lblDodaichuki.Text = Resources.FVaotien_ChangeValue_đơn_giá_và_tỉ_lệ_ăn_sẽ_được_tính_theo_chu_kì_mới_nhất_của_bạn;
        this.lblSonhayve.Text = Resources.FVaotien_ChangeValue_số_nháy_về_được_tính_là_số_nháy_về_của_ngày_cuối_cùng_trong_khung;
        this.lblSodiemdanh.Text = Resources.FVaotien_ChangeValue_là_số_điểm_của_một_con_lô_tô_trong___cặp___số_điểm_2_con_là_bằng_nhau;
        this.lblTientrungbinh.Text = Resources.FVaotien_ChangeValue_là_số_lãi_trung_bình_trên_số_ngày_trong_khung_của_bạn;
        TextBox textBox1 = this.textBox1;
        num = bien * Decimal.One;
        string str1 = num.ToString();
        textBox1.Text = str1;
        TextBox textBox2 = this.textBox2;
        num = bien * Convert.ToDecimal(3.5);
        string str2 = num.ToString();
        textBox2.Text = str2;
        TextBox textBox3 = this.textBox3;
        num = bien * new Decimal(9);
        string str3 = num.ToString();
        textBox3.Text = str3;
        TextBox textBox4 = this.textBox4;
        num = bien * new Decimal(22);
        string str4 = num.ToString();
        textBox4.Text = str4;
        TextBox textBox5 = this.textBox5;
        num = bien * new Decimal(53);
        string str5 = num.ToString();
        textBox5.Text = str5;
        TextBox textBox6 = this.textBox6;
        num = bien * new Decimal(126);
        string str6 = num.ToString();
        textBox6.Text = str6;
        TextBox textBox7 = this.textBox7;
        num = bien * new Decimal(300);
        string str7 = num.ToString();
        textBox7.Text = str7;
        TextBox textBox8 = this.textBox8;
        num = bien * new Decimal(705);
        string str8 = num.ToString();
        textBox8.Text = str8;
      }
      if (this.cbbLoto_Dacbiet.SelectedIndex != 2)
        return;
      this._dongia = this.DongiaDacbiet;
      this._hesonhan = this.HesonhanDacbiet;
      this.groupBox1.Text = Resources.FVaotien_ChangeValue_đặc_biệt_nuôi;
      this.lblDodaichuki.Text = Resources.FVaotien_ChangeValue_đơn_giá_và_tỉ_lệ_ăn_sẽ_được_tính_theo_chu_kì_mới_nhất_của_bạn;
      this.lblSonhayve.ForeColor = Color.Red;
      this.lblSodiemdanh.ForeColor = Color.Black;
      this.lblSonhayve.Text = Resources.FVaotien_ChangeValue_số_nháy_về_được_tính_là__số_điểm_được_ăn___ngày_cuối_cùng_trong_khung;
      this.lblSodiemdanh.Text = Resources.FVaotien_ChangeValue_là_số_điểm_của_tổng___dàn_đề___bạn_chốt;
      this.lblTientrungbinh.Text = Resources.FVaotien_ChangeValue_là_số_lãi_trung_bình_trên_số_ngày_trong_khung_của_bạn;
      TextBox textBox1_1 = this.textBox1;
      num = bien * Decimal.One;
      string str9 = num.ToString();
      textBox1_1.Text = str9;
      TextBox textBox2_1 = this.textBox2;
      num = bien * new Decimal(2);
      string str10 = num.ToString();
      textBox2_1.Text = str10;
      TextBox textBox3_1 = this.textBox3;
      num = bien * new Decimal(4);
      string str11 = num.ToString();
      textBox3_1.Text = str11;
      TextBox textBox4_1 = this.textBox4;
      num = bien * new Decimal(8);
      string str12 = num.ToString();
      textBox4_1.Text = str12;
      TextBox textBox5_1 = this.textBox5;
      num = bien * new Decimal(16);
      string str13 = num.ToString();
      textBox5_1.Text = str13;
      TextBox textBox6_1 = this.textBox6;
      num = bien * new Decimal(32);
      string str14 = num.ToString();
      textBox6_1.Text = str14;
      TextBox textBox7_1 = this.textBox7;
      num = bien * new Decimal(64);
      string str15 = num.ToString();
      textBox7_1.Text = str15;
      TextBox textBox8_1 = this.textBox8;
      num = bien * new Decimal(128);
      string str16 = num.ToString();
      textBox8_1.Text = str16;
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void textBox9_TextChanged(object sender, EventArgs e)
    {
    }

    private void TinhToan()
    {
      try
      {
        this._tongVon = new Decimal();
        this._tongLai = new Decimal();
        if (this.textBox1.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox1;
          if (this.SoNgayCuaChuki == 1)
            this._tongLai = this.valueTextBox.SoLaiTextBox1 * this._bienSonhayve - this._tongVon;
        }
        if (this.textBox2.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox2;
          if (this.SoNgayCuaChuki == 2)
            this._tongLai = this.valueTextBox.SoLaiTextBox2 * this._bienSonhayve - this._tongVon;
        }
        if (this.textBox3.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox3;
          if (this.SoNgayCuaChuki == 3)
            this._tongLai = this.valueTextBox.SoLaiTextBox3 * this._bienSonhayve - this._tongVon;
        }
        if (this.textBox4.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox4;
          if (this.SoNgayCuaChuki == 4)
            this._tongLai = this.valueTextBox.SoLaiTextBox4 * this._bienSonhayve - this._tongVon;
        }
        if (this.textBox5.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox5;
          if (this.SoNgayCuaChuki == 5)
            this._tongLai = this.valueTextBox.SoLaiTextBox5 * this._bienSonhayve - this._tongVon;
        }
        if (this.textBox6.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox6;
          if (this.SoNgayCuaChuki == 6)
            this._tongLai = this.valueTextBox.SoLaiTextBox6 * this._bienSonhayve - this._tongVon;
        }
        if (this.textBox7.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox7;
          if (this.SoNgayCuaChuki == 7)
            this._tongLai = this.valueTextBox.SoLaiTextBox7 * this._bienSonhayve - this._tongVon;
        }
        if (this.textBox8.Enabled)
        {
          this._tongVon += this.valueTextBox.SoVonTextBox8;
          if (this.SoNgayCuaChuki == 8)
            this._tongLai = this.valueTextBox.SoLaiTextBox8 * this._bienSonhayve - this._tongVon;
        }
        this._trungBinh = this._tongLai / (Decimal) this.SoNgayCuaChuki;
        this.lblTongvon.Text = ClMain.QuiDoiSoLuong(this._tongVon.ToString(), this.DonviTiente);
        this.lblTOnglai.Text = ClMain.QuiDoiSoLuong(this._tongLai.ToString(), this.DonviTiente);
        this.lblTrungbinh.Text = ClMain.QuiDoiSoLuong(this._trungBinh.ToString(), this.DonviTiente);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("LỖI NHẬP DỮ LIỆU ĐẦU VÀO", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void lblTOnglai_Click(object sender, EventArgs e)
    {
    }

    private void FVaotien_Load(object sender, EventArgs e)
    {
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.TinhToan();
    }

    private void cbbSonhayve_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._bienSonhayve = (Decimal) (this.cbbSonhayve.SelectedIndex + 1);
      this.TinhToan();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FVaotien));
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.label4 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.cbbLoto_Dacbiet = new ComboBox();
      this.comboBoxChukiDanh = new ComboBox();
      this.panel2 = new Panel();
      this.textBox1 = new TextBox();
      this.label5 = new Label();
      this.label6 = new Label();
      this.bunifuSeparator1 = new BunifuSeparator();
      this.bunifuSeparator2 = new BunifuSeparator();
      this.textBox2 = new TextBox();
      this.label7 = new Label();
      this.textBox3 = new TextBox();
      this.label8 = new Label();
      this.textBox4 = new TextBox();
      this.label9 = new Label();
      this.textBox5 = new TextBox();
      this.label10 = new Label();
      this.textBox6 = new TextBox();
      this.label11 = new Label();
      this.textBox7 = new TextBox();
      this.label12 = new Label();
      this.textBox8 = new TextBox();
      this.label13 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.lblDodaichuki = new Label();
      this.lblTOnglai = new Label();
      this.label20 = new Label();
      this.lblTrungbinh = new Label();
      this.label14 = new Label();
      this.toolTip1 = new ToolTip(this.components);
      this.cbbSonhayve = new ComboBox();
      this.groupBox1 = new GroupBox();
      this.label19 = new Label();
      this.label18 = new Label();
      this.label15 = new Label();
      this.label21 = new Label();
      this.lblTientrungbinh = new Label();
      this.lblSodiemdanh = new Label();
      this.lblSonhayve = new Label();
      this.lblTongvon = new Label();
      this.button1 = new Button();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.panel1.SuspendLayout();
      this.bunifuImageButton8.BeginInit();
      this.groupBox1.SuspendLayout();
      this.bunifuImageButton1.BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(27, 40, 61);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.bunifuImageButton8);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(693, 25);
      this.panel1.TabIndex = 0;
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(27, 4);
      this.label1.Name = "label1";
      this.label1.Size = new Size(86, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Bảng vào tiền";
      this.bunifuImageButton8.BackColor = Color.Transparent;
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(668, 1);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(23, 23);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 28;
      this.bunifuImageButton8.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton8, "Đóng");
      this.bunifuImageButton8.Zoom = 10;
      this.bunifuImageButton8.Click += new EventHandler(this.bunifuImageButton8_Click);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DimGray;
      this.label4.Location = new Point(45, 79);
      this.label4.Name = "label4";
      this.label4.Size = new Size(36, 16);
      this.label4.TabIndex = 3;
      this.label4.Text = "ngày";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DimGray;
      this.label2.Location = new Point(27, 49);
      this.label2.Name = "label2";
      this.label2.Size = new Size(70, 16);
      this.label2.TabIndex = 0;
      this.label2.Text = "Chọn loại :";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DimGray;
      this.label3.Location = new Point(271, 50);
      this.label3.Name = "label3";
      this.label3.Size = new Size(62, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "số ngày :";
      this.cbbLoto_Dacbiet.BackColor = Color.Teal;
      this.cbbLoto_Dacbiet.Cursor = Cursors.Hand;
      this.cbbLoto_Dacbiet.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoto_Dacbiet.FlatStyle = FlatStyle.Popup;
      this.cbbLoto_Dacbiet.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbLoto_Dacbiet.ForeColor = Color.White;
      this.cbbLoto_Dacbiet.FormattingEnabled = true;
      this.cbbLoto_Dacbiet.Items.AddRange(new object[3]
      {
        (object) "   Lô Bạch Thủ Nuôi",
        (object) "      Lô Cặp Nuôi",
        (object) "  Dàn Đặc Biệt Nuôi"
      });
      this.cbbLoto_Dacbiet.Location = new Point(95, 45);
      this.cbbLoto_Dacbiet.Name = "cbbLoto_Dacbiet";
      this.cbbLoto_Dacbiet.Size = new Size(144, 23);
      this.cbbLoto_Dacbiet.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.cbbLoto_Dacbiet, "Bạn muốn vào tiền cho hình thức nào");
      this.cbbLoto_Dacbiet.SelectedIndexChanged += new EventHandler(this.CbbLotoDacbietSelectedIndexChanged);
      this.comboBoxChukiDanh.BackColor = Color.Teal;
      this.comboBoxChukiDanh.Cursor = Cursors.Hand;
      this.comboBoxChukiDanh.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxChukiDanh.FlatStyle = FlatStyle.Popup;
      this.comboBoxChukiDanh.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.comboBoxChukiDanh.ForeColor = Color.White;
      this.comboBoxChukiDanh.FormattingEnabled = true;
      this.comboBoxChukiDanh.Items.AddRange(new object[8]
      {
        (object) "1 ngày",
        (object) "2 ngày",
        (object) "3 ngày",
        (object) "4 ngày",
        (object) "5 ngày",
        (object) "6 ngày",
        (object) "7 ngày",
        (object) "8 ngày"
      });
      this.comboBoxChukiDanh.Location = new Point(334, 45);
      this.comboBoxChukiDanh.Name = "comboBoxChukiDanh";
      this.comboBoxChukiDanh.Size = new Size(72, 23);
      this.comboBoxChukiDanh.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.comboBoxChukiDanh, "Độ dài của chu kì");
      this.comboBoxChukiDanh.SelectedIndexChanged += new EventHandler(this.comboBoxChukiDanh_SelectedIndexChanged);
      this.panel2.BackColor = Color.FromArgb(27, 40, 61);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 336);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(693, 1);
      this.panel2.TabIndex = 3;
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(115, 105);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(63, 25);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "0";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox1, "Số điểm đánh ngày 1");
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox1.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DimGray;
      this.label5.Location = new Point(34, 108);
      this.label5.Name = "label5";
      this.label5.Size = new Size(54, 16);
      this.label5.TabIndex = 4;
      this.label5.Text = "số điểm";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Red;
      this.label6.Location = new Point(140, 78);
      this.label6.Name = "label6";
      this.label6.Size = new Size(15, 16);
      this.label6.TabIndex = 7;
      this.label6.Text = "1";
      this.bunifuSeparator1.BackColor = Color.Transparent;
      this.bunifuSeparator1.LineColor = Color.FromArgb(105, 105, 105);
      this.bunifuSeparator1.LineThickness = 1;
      this.bunifuSeparator1.Location = new Point(27, 95);
      this.bunifuSeparator1.Name = "bunifuSeparator1";
      this.bunifuSeparator1.Size = new Size(654, 10);
      this.bunifuSeparator1.TabIndex = 5;
      this.bunifuSeparator1.Transparency = (int) byte.MaxValue;
      this.bunifuSeparator1.Vertical = false;
      this.bunifuSeparator2.BackColor = Color.Transparent;
      this.bunifuSeparator2.LineColor = Color.FromArgb(105, 105, 105);
      this.bunifuSeparator2.LineThickness = 1;
      this.bunifuSeparator2.Location = new Point(91, 80);
      this.bunifuSeparator2.Name = "bunifuSeparator2";
      this.bunifuSeparator2.Size = new Size(12, 50);
      this.bunifuSeparator2.TabIndex = 6;
      this.bunifuSeparator2.Transparency = (int) byte.MaxValue;
      this.bunifuSeparator2.Vertical = true;
      this.textBox2.BorderStyle = BorderStyle.FixedSingle;
      this.textBox2.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox2.Location = new Point(187, 105);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(63, 25);
      this.textBox2.TabIndex = 5;
      this.textBox2.Text = "0";
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox2, "Số điểm đánh ngày 2");
      this.textBox2.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox2.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Red;
      this.label7.Location = new Point(212, 78);
      this.label7.Name = "label7";
      this.label7.Size = new Size(15, 16);
      this.label7.TabIndex = 8;
      this.label7.Text = "2";
      this.textBox3.BorderStyle = BorderStyle.FixedSingle;
      this.textBox3.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox3.Location = new Point(258, 105);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(63, 25);
      this.textBox3.TabIndex = 6;
      this.textBox3.Text = "0";
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox3, "Số điểm đánh ngày 3");
      this.textBox3.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox3.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.Red;
      this.label8.Location = new Point(283, 78);
      this.label8.Name = "label8";
      this.label8.Size = new Size(15, 16);
      this.label8.TabIndex = 9;
      this.label8.Text = "3";
      this.textBox4.BorderStyle = BorderStyle.FixedSingle;
      this.textBox4.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox4.Location = new Point(328, 105);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(63, 25);
      this.textBox4.TabIndex = 7;
      this.textBox4.Text = "0";
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox4, "Số điểm đánh ngày 4");
      this.textBox4.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox4.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.Red;
      this.label9.Location = new Point(353, 78);
      this.label9.Name = "label9";
      this.label9.Size = new Size(15, 16);
      this.label9.TabIndex = 10;
      this.label9.Text = "4";
      this.textBox5.BorderStyle = BorderStyle.FixedSingle;
      this.textBox5.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox5.Location = new Point(399, 105);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(63, 25);
      this.textBox5.TabIndex = 8;
      this.textBox5.Text = "0";
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox5, "Số điểm đánh ngày 5");
      this.textBox5.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox5.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.Red;
      this.label10.Location = new Point(424, 78);
      this.label10.Name = "label10";
      this.label10.Size = new Size(15, 16);
      this.label10.TabIndex = 11;
      this.label10.Text = "5";
      this.textBox6.BorderStyle = BorderStyle.FixedSingle;
      this.textBox6.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox6.Location = new Point(470, 105);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new Size(63, 25);
      this.textBox6.TabIndex = 9;
      this.textBox6.Text = "0";
      this.textBox6.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox6, "Số điểm đánh ngày 6");
      this.textBox6.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox6.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.Red;
      this.label11.Location = new Point(496, 78);
      this.label11.Name = "label11";
      this.label11.Size = new Size(15, 16);
      this.label11.TabIndex = 12;
      this.label11.Text = "6";
      this.textBox7.BorderStyle = BorderStyle.FixedSingle;
      this.textBox7.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox7.Location = new Point(541, 105);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(63, 25);
      this.textBox7.TabIndex = 10;
      this.textBox7.Text = "0";
      this.textBox7.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox7, "Số điểm đánh ngày 7");
      this.textBox7.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox7.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.Red;
      this.label12.Location = new Point(566, 78);
      this.label12.Name = "label12";
      this.label12.Size = new Size(15, 16);
      this.label12.TabIndex = 13;
      this.label12.Text = "7";
      this.textBox8.BorderStyle = BorderStyle.FixedSingle;
      this.textBox8.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox8.Location = new Point(613, 105);
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new Size(63, 25);
      this.textBox8.TabIndex = 11;
      this.textBox8.Text = "0";
      this.textBox8.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.textBox8, "Số điểm đánh ngày 8");
      this.textBox8.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox8.KeyPress += new KeyPressEventHandler(this.TextBox1KeyPress1);
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.Red;
      this.label13.Location = new Point(638, 78);
      this.label13.Name = "label13";
      this.label13.Size = new Size(15, 16);
      this.label13.TabIndex = 14;
      this.label13.Text = "8";
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.ForeColor = Color.Black;
      this.label16.Location = new Point(17, 146);
      this.label16.Name = "label16";
      this.label16.Size = new Size(67, 16);
      this.label16.TabIndex = 15;
      this.label16.Text = "Tổng vốn :";
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.ForeColor = Color.Black;
      this.label17.Location = new Point(223, 146);
      this.label17.Name = "label17";
      this.label17.Size = new Size(61, 16);
      this.label17.TabIndex = 17;
      this.label17.Text = "Tổng lãi :";
      this.lblDodaichuki.AutoSize = true;
      this.lblDodaichuki.Font = new Font("Arial", 11.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.lblDodaichuki.ForeColor = Color.Black;
      this.lblDodaichuki.Location = new Point(133, 26);
      this.lblDodaichuki.Name = "lblDodaichuki";
      this.lblDodaichuki.Size = new Size(52, 17);
      this.lblDodaichuki.TabIndex = 16;
      this.lblDodaichuki.Text = "0 VND";
      this.lblTOnglai.AutoSize = true;
      this.lblTOnglai.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTOnglai.ForeColor = Color.Red;
      this.lblTOnglai.Location = new Point(285, 146);
      this.lblTOnglai.Name = "lblTOnglai";
      this.lblTOnglai.Size = new Size(50, 17);
      this.lblTOnglai.TabIndex = 18;
      this.lblTOnglai.Text = "0 VND";
      this.lblTOnglai.Click += new EventHandler(this.lblTOnglai_Click);
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.ForeColor = Color.Black;
      this.label20.Location = new Point(428, 146);
      this.label20.Name = "label20";
      this.label20.Size = new Size(108, 16);
      this.label20.TabIndex = 19;
      this.label20.Text = "Trung bình/ngày :";
      this.lblTrungbinh.AutoSize = true;
      this.lblTrungbinh.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTrungbinh.ForeColor = Color.Red;
      this.lblTrungbinh.Location = new Point(540, 146);
      this.lblTrungbinh.Name = "lblTrungbinh";
      this.lblTrungbinh.Size = new Size(50, 17);
      this.lblTrungbinh.TabIndex = 20;
      this.lblTrungbinh.Text = "0 VND";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.DimGray;
      this.label14.Location = new Point(420, 50);
      this.label14.Name = "label14";
      this.label14.Size = new Size(78, 16);
      this.label14.TabIndex = 2;
      this.label14.Text = "số nháy về :";
      this.cbbSonhayve.BackColor = Color.Teal;
      this.cbbSonhayve.Cursor = Cursors.Hand;
      this.cbbSonhayve.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbSonhayve.FlatStyle = FlatStyle.Popup;
      this.cbbSonhayve.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbSonhayve.ForeColor = Color.White;
      this.cbbSonhayve.FormattingEnabled = true;
      this.cbbSonhayve.Items.AddRange(new object[5]
      {
        (object) "1 Nháy",
        (object) "2 Nháy",
        (object) "3 Nháy",
        (object) "4 Nháy",
        (object) "5 Nháy"
      });
      this.cbbSonhayve.Location = new Point(499, 45);
      this.cbbSonhayve.Name = "cbbSonhayve";
      this.cbbSonhayve.Size = new Size(82, 23);
      this.cbbSonhayve.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.cbbSonhayve, "Độ dài của chu kì");
      this.cbbSonhayve.SelectedIndexChanged += new EventHandler(this.cbbSonhayve_SelectedIndexChanged);
      this.groupBox1.BackColor = Color.Transparent;
      this.groupBox1.Controls.Add((Control) this.label19);
      this.groupBox1.Controls.Add((Control) this.label18);
      this.groupBox1.Controls.Add((Control) this.label15);
      this.groupBox1.Controls.Add((Control) this.label21);
      this.groupBox1.Controls.Add((Control) this.lblTientrungbinh);
      this.groupBox1.Controls.Add((Control) this.lblSodiemdanh);
      this.groupBox1.Controls.Add((Control) this.lblSonhayve);
      this.groupBox1.Controls.Add((Control) this.lblDodaichuki);
      this.groupBox1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.groupBox1.ForeColor = Color.DimGray;
      this.groupBox1.Location = new Point(17, 176);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(664, 153);
      this.groupBox1.TabIndex = 32;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Hướng dẫn";
      this.groupBox1.Enter += new EventHandler(this.groupBox1_Enter);
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.ForeColor = Color.DimGray;
      this.label19.Location = new Point(69, 90);
      this.label19.Name = "label19";
      this.label19.Size = new Size(64, 16);
      this.label19.TabIndex = 0;
      this.label19.Text = "Số điểm :";
      this.label19.Click += new EventHandler(this.label2_Click);
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.ForeColor = Color.DimGray;
      this.label18.Location = new Point(53, 58);
      this.label18.Name = "label18";
      this.label18.Size = new Size(80, 16);
      this.label18.TabIndex = 0;
      this.label18.Text = "Số nháy về :";
      this.label18.Click += new EventHandler(this.label2_Click);
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.DimGray;
      this.label15.Location = new Point(12, 26);
      this.label15.Name = "label15";
      this.label15.Size = new Size(121, 16);
      this.label15.TabIndex = 0;
      this.label15.Text = "Đơn giá và tỉ lệ ăn :";
      this.label15.Click += new EventHandler(this.label2_Click);
      this.label21.AutoSize = true;
      this.label21.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.ForeColor = Color.DimGray;
      this.label21.Location = new Point(32, 122);
      this.label21.Name = "label21";
      this.label21.Size = new Size(101, 16);
      this.label21.TabIndex = 19;
      this.label21.Text = "Tiền trung bình :";
      this.lblTientrungbinh.AutoSize = true;
      this.lblTientrungbinh.Font = new Font("Arial", 11.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.lblTientrungbinh.ForeColor = Color.Black;
      this.lblTientrungbinh.Location = new Point(133, 122);
      this.lblTientrungbinh.Name = "lblTientrungbinh";
      this.lblTientrungbinh.Size = new Size(52, 17);
      this.lblTientrungbinh.TabIndex = 16;
      this.lblTientrungbinh.Text = "0 VND";
      this.lblSodiemdanh.AutoSize = true;
      this.lblSodiemdanh.Font = new Font("Arial", 11.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.lblSodiemdanh.ForeColor = Color.Red;
      this.lblSodiemdanh.Location = new Point(133, 90);
      this.lblSodiemdanh.Name = "lblSodiemdanh";
      this.lblSodiemdanh.Size = new Size(52, 17);
      this.lblSodiemdanh.TabIndex = 16;
      this.lblSodiemdanh.Text = "0 VND";
      this.lblSonhayve.AutoSize = true;
      this.lblSonhayve.Font = new Font("Arial", 11.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.lblSonhayve.ForeColor = Color.Black;
      this.lblSonhayve.Location = new Point(133, 58);
      this.lblSonhayve.Name = "lblSonhayve";
      this.lblSonhayve.Size = new Size(52, 17);
      this.lblSonhayve.TabIndex = 16;
      this.lblSonhayve.Text = "0 VND";
      this.lblTongvon.AutoSize = true;
      this.lblTongvon.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTongvon.ForeColor = Color.Red;
      this.lblTongvon.Location = new Point(85, 146);
      this.lblTongvon.Name = "lblTongvon";
      this.lblTongvon.Size = new Size(50, 17);
      this.lblTongvon.TabIndex = 18;
      this.lblTongvon.Text = "0 VND";
      this.lblTongvon.Click += new EventHandler(this.lblTOnglai_Click);
      this.button1.BackColor = Color.WhiteSmoke;
      this.button1.Cursor = Cursors.Hand;
      this.button1.FlatStyle = FlatStyle.Popup;
      this.button1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.Location = new Point(584, 46);
      this.button1.Name = "button1";
      this.button1.Size = new Size(97, 22);
      this.button1.TabIndex = 3;
      this.button1.Text = "Xem";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.bunifuImageButton1.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(2, 2);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(22, 22);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 29;
      this.bunifuImageButton1.TabStop = false;
      this.bunifuImageButton1.Zoom = 10;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(693, 337);
      this.Controls.Add((Control) this.cbbSonhayve);
      this.Controls.Add((Control) this.bunifuImageButton1);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.bunifuSeparator2);
      this.Controls.Add((Control) this.bunifuSeparator1);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.textBox8);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.textBox7);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.textBox6);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.comboBoxChukiDanh);
      this.Controls.Add((Control) this.cbbLoto_Dacbiet);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.lblTongvon);
      this.Controls.Add((Control) this.lblTOnglai);
      this.Controls.Add((Control) this.lblTrungbinh);
      this.Controls.Add((Control) this.label20);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FVaotien);
      this.RightToLeftLayout = true;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Bảng vào tiền";
      this.Load += new EventHandler(this.FVaotien_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.bunifuImageButton8.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.bunifuImageButton1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class ValueTextBox
    {
      public Decimal SoVonTextBox1 { get; set; }

      public Decimal SoLaiTextBox1 { get; set; }

      public Decimal SoVonTextBox2 { get; set; }

      public Decimal SoLaiTextBox2 { get; set; }

      public Decimal SoVonTextBox3 { get; set; }

      public Decimal SoLaiTextBox3 { get; set; }

      public Decimal SoVonTextBox4 { get; set; }

      public Decimal SoLaiTextBox4 { get; set; }

      public Decimal SoVonTextBox5 { get; set; }

      public Decimal SoLaiTextBox5 { get; set; }

      public Decimal SoVonTextBox6 { get; set; }

      public Decimal SoLaiTextBox6 { get; set; }

      public Decimal SoVonTextBox7 { get; set; }

      public Decimal SoLaiTextBox7 { get; set; }

      public Decimal SoVonTextBox8 { get; set; }

      public Decimal SoLaiTextBox8 { get; set; }
    }
  }
}
