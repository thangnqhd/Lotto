// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabLoxien
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabLoxien : UserControl
  {
    private int soNgayKiemTra = 365;
    private string loaiLoto = "locap";
    private DateTime tuNgayCu = DateTime.Now.AddYears(-10);
    private DateTime denNgayCu = DateTime.Now.AddYears(-10);
    private int khungLoXienCu = 16;
    private IContainer components = (IContainer) null;
    private TbLoxien objLoxien;
    private DataTable dtBoSo;
    private Tbloto objLoto;
    public List<TabLoxien.LOTO> listLotoTuDo;
    private DataTable dtLoto;
    private DataTable dtLotoNgaySau;
    private string veNgaysau;
    private Panel panel1;
    private Label label2;
    private Button btnThongke;
    private DateTimePicker dtTungay;
    private Panel panel2;
    private PictureBox picLoading;
    private Button button1;
    private BackgroundWorker bgXuly;
    private Timer timer1;
    private DataGridView dtgKetqua;
    private RadioButton rdTuDo;
    private RadioButton rdTrungDuoi;
    private RadioButton rdTrungDau;
    private RadioButton rdCap;
    private Label label1;
    private DateTimePicker dtDenngay;
    private ToolTip toolTip1;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn boSo;
    private DataGridViewTextBoxColumn solanve;
    private DataGridViewTextBoxColumn chuKy;
    private DataGridViewTextBoxColumn ngayChuara;
    private DataGridViewTextBoxColumn max365ngay;
    private DataGridViewTextBoxColumn maxGan;
    private DataGridViewTextBoxColumn diemTanXuat;
    private DataGridViewTextBoxColumn diemGan;
    private DataGridViewTextBoxColumn veNgay;
    private DataGridViewTextBoxColumn colTrong;
    private GroupBox groupBox1;
    private BunifuElipse bunifuElipse1;

    public TabLoxien()
    {
      this.InitializeComponent();
      this.dtDenngay.Value = FMain.NgayKetQuaMoiNhat;
      this.dtTungay.Value = FMain.NgayKetQuaMoiNhat.AddDays((double) -this.soNgayKiemTra);
      this.objLoxien = new TbLoxien();
      this.objLoto = new Tbloto();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
    }

    private void dtNgayXem_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtTungay.Value > this.dtDenngay.Value))
        return;
      this.dtTungay.Value = this.dtDenngay.Value.AddDays(-365.0);
    }

    private void TaoListLotoTuDo()
    {
      this.listLotoTuDo = new List<TabLoxien.LOTO>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        for (int index2 = 0; index2 < 100; ++index2)
        {
          if (index1 != index2)
          {
            TabLoxien.LOTO LOTO = new TabLoxien.LOTO()
            {
              loto1 = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture),
              loto2 = index2.ToString((IFormatProvider) CultureInfo.InvariantCulture)
            };
            if (index1 < 10)
              LOTO.loto1 = "0" + (object) index1;
            string loto1 = LOTO.loto1;
            if (index2 < 10)
              LOTO.loto2 = "0" + (object) index2;
            if (Convert.ToInt32(LOTO.loto1) > Convert.ToInt32(LOTO.loto2))
            {
              LOTO.loto1 = LOTO.loto2;
              LOTO.loto2 = loto1;
            }
            if (!this.listLotoTuDo.Any<TabLoxien.LOTO>((Func<TabLoxien.LOTO, bool>) (item =>
            {
              if (item.loto1 == LOTO.loto1)
                return item.loto2 == LOTO.loto2;
              return false;
            })))
              this.listLotoTuDo.Add(LOTO);
          }
        }
      }
      for (int index = 0; index < this.listLotoTuDo.Count; ++index)
      {
        string loto1 = this.listLotoTuDo[index].loto1;
        string loto2 = this.listLotoTuDo[index].loto2;
        this.objLoxien.InsertBoSo(!(loto1 == loto2) ? (!(loto1.Substring(0, 1) == loto2.Substring(0, 1)) ? (!(loto1.Substring(1, 1) == loto2.Substring(1, 1)) ? (!(ClMain.check_Loto_Cap(loto1) == loto2) ? "tudo" : "locap") : "trungduoi") : "trungdau") : "bachthu", loto1 + "-" + loto2, "0", "1", "2", "3", "4", "5", "6", "7");
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.TaoListLotoTuDo();
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      if (this.bgXuly.IsBusy)
        return;
      this.bgXuly.RunWorkerAsync();
    }

    public void getData()
    {
      this.dtBoSo = this.objLoxien.GetAllByLoaiLoto(this.loaiLoto);
      this.dtLoto = this.objLoto.GetLotoByNgayThang(this.dtTungay.Value, this.dtDenngay.Value);
      this.dtLotoNgaySau = this.objLoto.GetLotoByNgayThangSoBanGhi(this.dtDenngay.Value, FMain.ObjConfigBacNho.KhungLoXien2);
      this.tuNgayCu = this.dtTungay.Value;
      this.denNgayCu = this.dtDenngay.Value;
      if (this.dtLoto.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this.dtBoSo.Rows.Count; ++index1)
      {
        string[] strArray = this.dtBoSo.Rows[index1]["boSo"].ToString().Split('-');
        string loto1 = strArray[0];
        string loto2 = strArray[1];
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        for (int index2 = 0; index2 < this.dtLoto.Rows.Count; ++index2)
        {
          bool flag1 = false;
          bool flag2 = false;
          for (int index3 = 2; index3 < this.dtLoto.Columns.Count; ++index3)
          {
            string str = this.dtLoto.Rows[index2][index3].ToString();
            if (loto1 == str)
              flag1 = true;
            if (loto2 == str)
              flag2 = true;
          }
          if (flag1 & flag2)
          {
            if (num2 > num3)
              num3 = num2;
            ++num1;
            this.dtBoSo.Rows[index1]["soLanve"] = (object) num1;
            num2 = 0;
          }
          else
            ++num2;
          if (index2 == this.dtLoto.Rows.Count - 1)
          {
            Decimal num4 = Math.Round(Convert.ToDecimal(this.dtLoto.Rows.Count) / Convert.ToDecimal(num1), 1);
            Decimal d1 = ((Decimal) num2 + num4) / new Decimal(2) / (Decimal) num3 * new Decimal(10);
            Decimal d2 = Convert.ToDecimal(num2) / Convert.ToDecimal(this.dtBoSo.Rows[index1]["maxGan"].ToString()) * new Decimal(10);
            this.dtBoSo.Rows[index1]["chuKy"] = (object) num4;
            this.dtBoSo.Rows[index1]["ngayChuaRa"] = (object) num2;
            this.dtBoSo.Rows[index1]["max365ngay"] = (object) num3;
            this.dtBoSo.Rows[index1]["diemTanXuat"] = (object) Math.Round(d1, 1);
            this.dtBoSo.Rows[index1]["diemGan"] = (object) Math.Round(d2, 1);
            this.dtBoSo.Rows[index1]["veNgay"] = (object) this.TimNgayVe(this.dtLotoNgaySau, loto1, loto2);
          }
        }
      }
    }

    private string TimNgayVe(DataTable _dtLoNgaySau, string loto1, string loto2)
    {
      this.veNgaysau = "0";
      if (_dtLoNgaySau.Rows.Count > 0)
      {
        string str1 = loto1;
        string str2 = loto2;
        for (int index1 = 0; index1 < _dtLoNgaySau.Rows.Count; ++index1)
        {
          bool flag1 = false;
          bool flag2 = false;
          for (int index2 = 2; index2 < _dtLoNgaySau.Columns.Count; ++index2)
          {
            string str3 = _dtLoNgaySau.Rows[index1][index2].ToString();
            if (str1 == str3)
              flag1 = true;
            if (str2 == str3)
              flag2 = true;
            if (flag1 & flag2)
              break;
          }
          if (flag1 & flag2)
          {
            this.veNgaysau = (index1 + 1).ToString();
            break;
          }
        }
      }
      return this.veNgaysau;
    }

    private void bgXuly_DoWork(object sender, DoWorkEventArgs e)
    {
      this.getData();
    }

    private void bgXuly_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.dtBoSo.Rows.Count <= 0)
        return;
      this.dtgKetqua.DataSource = (object) this.dtBoSo;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.bgXuly.IsBusy;
    }

    private void rdCap_CheckedChanged_1(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton) sender;
      if (radioButton.Checked)
      {
        radioButton.ForeColor = Color.Red;
        radioButton.Font = new Font("Arial", 9f, FontStyle.Bold);
        if (radioButton.Name == "rdCap")
          this.loaiLoto = "locap";
        else if (radioButton.Name == "rdTrungDau")
          this.loaiLoto = "trungdau";
        else if (radioButton.Name == "rdTrungDuoi")
        {
          this.loaiLoto = "trungduoi";
        }
        else
        {
          if (!(radioButton.Name == "rdTuDo"))
            return;
          this.loaiLoto = "tudo";
        }
      }
      else
      {
        radioButton.ForeColor = Color.Black;
        radioButton.Font = new Font("Arial", 9f, FontStyle.Regular);
      }
    }

    private void dtDenngay_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtDenngay.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dtDenngay.Value = FMain.NgayKetQuaMoiNhat;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabLoxien));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.dtDenngay = new DateTimePicker();
      this.rdTuDo = new RadioButton();
      this.rdTrungDuoi = new RadioButton();
      this.rdTrungDau = new RadioButton();
      this.rdCap = new RadioButton();
      this.button1 = new Button();
      this.label2 = new Label();
      this.btnThongke = new Button();
      this.dtTungay = new DateTimePicker();
      this.panel2 = new Panel();
      this.picLoading = new PictureBox();
      this.dtgKetqua = new DataGridView();
      this.stt = new DataGridViewTextBoxColumn();
      this.boSo = new DataGridViewTextBoxColumn();
      this.solanve = new DataGridViewTextBoxColumn();
      this.chuKy = new DataGridViewTextBoxColumn();
      this.ngayChuara = new DataGridViewTextBoxColumn();
      this.max365ngay = new DataGridViewTextBoxColumn();
      this.maxGan = new DataGridViewTextBoxColumn();
      this.diemTanXuat = new DataGridViewTextBoxColumn();
      this.diemGan = new DataGridViewTextBoxColumn();
      this.veNgay = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.bgXuly = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.toolTip1 = new ToolTip(this.components);
      this.groupBox1 = new GroupBox();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      ((ISupportInitialize) this.dtgKetqua).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 45);
      this.panel1.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(164, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(12, 16);
      this.label1.TabIndex = 48;
      this.label1.Text = "-";
      this.dtDenngay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtDenngay.CalendarForeColor = Color.Red;
      this.dtDenngay.CalendarMonthBackground = SystemColors.Info;
      this.dtDenngay.CustomFormat = "dd/MM/yyyy";
      this.dtDenngay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtDenngay.Format = DateTimePickerFormat.Custom;
      this.dtDenngay.Location = new Point(177, 15);
      this.dtDenngay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtDenngay.Name = "dtDenngay";
      this.dtDenngay.Size = new Size(91, 21);
      this.dtDenngay.TabIndex = 47;
      this.dtDenngay.ValueChanged += new EventHandler(this.dtDenngay_ValueChanged);
      this.rdTuDo.AutoSize = true;
      this.rdTuDo.Cursor = Cursors.Hand;
      this.rdTuDo.FlatStyle = FlatStyle.Flat;
      this.rdTuDo.ForeColor = Color.Black;
      this.rdTuDo.Location = new Point(558, 15);
      this.rdTuDo.Name = "rdTuDo";
      this.rdTuDo.Size = new Size(101, 19);
      this.rdTuDo.TabIndex = 46;
      this.rdTuDo.Text = "Lô Cặp Tự Do";
      this.toolTip1.SetToolTip((Control) this.rdTuDo, "Kiểm tra tất cả các cặp lô tự do cùng về trong một ngày");
      this.rdTuDo.UseVisualStyleBackColor = true;
      this.rdTuDo.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged_1);
      this.rdTrungDuoi.AutoSize = true;
      this.rdTrungDuoi.Cursor = Cursors.Hand;
      this.rdTrungDuoi.FlatStyle = FlatStyle.Flat;
      this.rdTrungDuoi.ForeColor = Color.Black;
      this.rdTrungDuoi.Location = new Point(464, 15);
      this.rdTrungDuoi.Name = "rdTrungDuoi";
      this.rdTrungDuoi.Size = new Size(85, 19);
      this.rdTrungDuoi.TabIndex = 45;
      this.rdTrungDuoi.Text = "Trùng Đuôi";
      this.toolTip1.SetToolTip((Control) this.rdTrungDuoi, "Kiểm tra tất cả các lô trùng đuôi cùng về trong một ngày");
      this.rdTrungDuoi.UseVisualStyleBackColor = true;
      this.rdTrungDuoi.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged_1);
      this.rdTrungDau.AutoSize = true;
      this.rdTrungDau.Cursor = Cursors.Hand;
      this.rdTrungDau.FlatStyle = FlatStyle.Flat;
      this.rdTrungDau.ForeColor = Color.Black;
      this.rdTrungDau.Location = new Point(373, 15);
      this.rdTrungDau.Name = "rdTrungDau";
      this.rdTrungDau.Size = new Size(82, 19);
      this.rdTrungDau.TabIndex = 44;
      this.rdTrungDau.Text = "Trùng Đầu";
      this.toolTip1.SetToolTip((Control) this.rdTrungDau, "Kiểm tra tất cả các lô trùng đầu cùng về trong một ngày");
      this.rdTrungDau.UseVisualStyleBackColor = true;
      this.rdTrungDau.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged_1);
      this.rdCap.AutoSize = true;
      this.rdCap.Checked = true;
      this.rdCap.Cursor = Cursors.Hand;
      this.rdCap.FlatStyle = FlatStyle.Flat;
      this.rdCap.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.rdCap.ForeColor = Color.Red;
      this.rdCap.Location = new Point(300, 15);
      this.rdCap.Name = "rdCap";
      this.rdCap.Size = new Size(63, 19);
      this.rdCap.TabIndex = 42;
      this.rdCap.TabStop = true;
      this.rdCap.Text = "Lô Cặp";
      this.toolTip1.SetToolTip((Control) this.rdCap, "Kiểm tra tất cả các lô cặp cùng về trong một ngày");
      this.rdCap.UseVisualStyleBackColor = true;
      this.rdCap.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged_1);
      this.button1.BackColor = Color.Teal;
      this.button1.Cursor = Cursors.Hand;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.White;
      this.button1.Location = new Point(808, 13);
      this.button1.Margin = new Padding(3, 0, 3, 0);
      this.button1.Name = "button1";
      this.button1.Size = new Size(87, 24);
      this.button1.TabIndex = 41;
      this.button1.Text = "Thêm Bộ Số";
      this.button1.TextAlign = ContentAlignment.TopCenter;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Visible = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(14, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(56, 16);
      this.label2.TabIndex = 39;
      this.label2.Text = "Từ ngày";
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(689, 13);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(113, 24);
      this.btnThongke.TabIndex = 7;
      this.btnThongke.Text = "Thống kê lô xiên";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.dtTungay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtTungay.CalendarForeColor = Color.Red;
      this.dtTungay.CalendarMonthBackground = SystemColors.Info;
      this.dtTungay.CustomFormat = "dd/MM/yyyy";
      this.dtTungay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtTungay.Format = DateTimePickerFormat.Custom;
      this.dtTungay.Location = new Point(73, 15);
      this.dtTungay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtTungay.Name = "dtTungay";
      this.dtTungay.Size = new Size(91, 21);
      this.dtTungay.TabIndex = 0;
      this.dtTungay.ValueChanged += new EventHandler(this.dtNgayXem_ValueChanged);
      this.panel2.Controls.Add((Control) this.picLoading);
      this.panel2.Controls.Add((Control) this.dtgKetqua);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 45);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 539);
      this.panel2.TabIndex = 2;
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(544, 286);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 61;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.dtgKetqua.AllowUserToAddRows = false;
      this.dtgKetqua.AllowUserToDeleteRows = false;
      this.dtgKetqua.AllowUserToResizeRows = false;
      this.dtgKetqua.BackgroundColor = SystemColors.ButtonHighlight;
      this.dtgKetqua.BorderStyle = BorderStyle.None;
      this.dtgKetqua.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dtgKetqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtgKetqua.ColumnHeadersHeight = 24;
      this.dtgKetqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtgKetqua.Columns.AddRange((DataGridViewColumn) this.stt, (DataGridViewColumn) this.boSo, (DataGridViewColumn) this.solanve, (DataGridViewColumn) this.chuKy, (DataGridViewColumn) this.ngayChuara, (DataGridViewColumn) this.max365ngay, (DataGridViewColumn) this.maxGan, (DataGridViewColumn) this.diemTanXuat, (DataGridViewColumn) this.diemGan, (DataGridViewColumn) this.veNgay, (DataGridViewColumn) this.colTrong);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtgKetqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtgKetqua.Dock = DockStyle.Fill;
      this.dtgKetqua.GridColor = Color.WhiteSmoke;
      this.dtgKetqua.Location = new Point(0, 0);
      this.dtgKetqua.Margin = new Padding(0);
      this.dtgKetqua.MultiSelect = false;
      this.dtgKetqua.Name = "dtgKetqua";
      this.dtgKetqua.ReadOnly = true;
      this.dtgKetqua.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.BackColor = Color.Cornsilk;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dtgKetqua.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dtgKetqua.RowHeadersVisible = false;
      this.dtgKetqua.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dtgKetqua.RowTemplate.Height = 24;
      this.dtgKetqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtgKetqua.Size = new Size(1100, 539);
      this.dtgKetqua.TabIndex = 3;
      this.stt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.stt.DataPropertyName = "stt";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle4.ForeColor = Color.Gray;
      this.stt.DefaultCellStyle = gridViewCellStyle4;
      this.stt.HeaderText = "STT ";
      this.stt.Name = "stt";
      this.stt.ReadOnly = true;
      this.stt.Width = 45;
      this.boSo.DataPropertyName = "boSo";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle5.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = Color.Red;
      this.boSo.DefaultCellStyle = gridViewCellStyle5;
      this.boSo.HeaderText = "Bộ số";
      this.boSo.Name = "boSo";
      this.boSo.ReadOnly = true;
      this.boSo.ToolTipText = "Danh sách những bộ số cùng về";
      this.boSo.Width = 120;
      this.solanve.DataPropertyName = "soLanve";
      gridViewCellStyle6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.solanve.DefaultCellStyle = gridViewCellStyle6;
      this.solanve.HeaderText = "Số lần về cùng nhau";
      this.solanve.Name = "solanve";
      this.solanve.ReadOnly = true;
      this.solanve.ToolTipText = "Số lần về cùng nhau của bộ số trong khung kiểm tra";
      this.solanve.Width = 130;
      this.chuKy.DataPropertyName = "chuKy";
      gridViewCellStyle7.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.chuKy.DefaultCellStyle = gridViewCellStyle7;
      this.chuKy.HeaderText = "Chu kỳ (ngày)";
      this.chuKy.Name = "chuKy";
      this.chuKy.ReadOnly = true;
      this.chuKy.ToolTipText = "Chu kỳ trung bình để 2 lô tô về cùng nhau";
      this.chuKy.Visible = false;
      this.chuKy.Width = 90;
      this.ngayChuara.DataPropertyName = "ngayChuaRa";
      gridViewCellStyle8.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle8.ForeColor = Color.Red;
      this.ngayChuara.DefaultCellStyle = gridViewCellStyle8;
      this.ngayChuara.HeaderText = "Ngày chưa ra";
      this.ngayChuara.Name = "ngayChuara";
      this.ngayChuara.ReadOnly = true;
      this.ngayChuara.ToolTipText = "Số ngày chưa ra của cặp sô";
      this.ngayChuara.Width = 120;
      this.max365ngay.DataPropertyName = "max365ngay";
      gridViewCellStyle9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.max365ngay.DefaultCellStyle = gridViewCellStyle9;
      this.max365ngay.HeaderText = "Gan trong khung";
      this.max365ngay.Name = "max365ngay";
      this.max365ngay.ReadOnly = true;
      this.max365ngay.ToolTipText = "Khoảng gan lớn nhất trong khung kiểm tra để 2 số cùng về";
      this.max365ngay.Width = 120;
      this.maxGan.DataPropertyName = "maxGan";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.maxGan.DefaultCellStyle = gridViewCellStyle10;
      this.maxGan.HeaderText = "Gan lịch sử";
      this.maxGan.Name = "maxGan";
      this.maxGan.ReadOnly = true;
      this.maxGan.ToolTipText = "Khoảng gan lớn nhất trong lịch sử để hai số cùng về";
      this.maxGan.Width = 120;
      this.diemTanXuat.DataPropertyName = "diemTanXuat";
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle11.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle11.ForeColor = Color.Red;
      this.diemTanXuat.DefaultCellStyle = gridViewCellStyle11;
      this.diemTanXuat.HeaderText = "Điểm tần xuất";
      this.diemTanXuat.Name = "diemTanXuat";
      this.diemTanXuat.ReadOnly = true;
      this.diemTanXuat.ToolTipText = "Điểm tần xuất lớn thể hiện cặp lô xiên đó đã chạm max trong khung kt";
      this.diemTanXuat.Width = 120;
      this.diemGan.DataPropertyName = "diemGan";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle12.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle12.ForeColor = Color.Red;
      this.diemGan.DefaultCellStyle = gridViewCellStyle12;
      this.diemGan.HeaderText = "Điểm gan";
      this.diemGan.Name = "diemGan";
      this.diemGan.ReadOnly = true;
      this.diemGan.ToolTipText = "Điểm gan lớn thể hiện cặp lô xiên đó đã chạm max trong lịch sử";
      this.diemGan.Width = 120;
      this.veNgay.DataPropertyName = "veNgay";
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle13.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle13.ForeColor = Color.Blue;
      this.veNgay.DefaultCellStyle = gridViewCellStyle13;
      this.veNgay.HeaderText = "Về ngày";
      this.veNgay.Name = "veNgay";
      this.veNgay.ReadOnly = true;
      this.colTrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.bgXuly.DoWork += new DoWorkEventHandler(this.bgXuly_DoWork);
      this.bgXuly.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgXuly_RunWorkerCompleted);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.dtTungay);
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.btnThongke);
      this.groupBox1.Controls.Add((Control) this.rdTuDo);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.rdTrungDuoi);
      this.groupBox1.Controls.Add((Control) this.rdTrungDau);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.rdCap);
      this.groupBox1.Controls.Add((Control) this.dtDenngay);
      this.groupBox1.Location = new Point(2, -1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1097, 43);
      this.groupBox1.TabIndex = 49;
      this.groupBox1.TabStop = false;
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabLoxien);
      this.Size = new Size(1100, 584);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      ((ISupportInitialize) this.dtgKetqua).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    public class LOTO
    {
      public string loto1 { get; set; }

      public string loto2 { get; set; }
    }
  }
}
