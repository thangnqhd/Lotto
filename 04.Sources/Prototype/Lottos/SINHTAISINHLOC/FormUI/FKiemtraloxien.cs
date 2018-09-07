// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FKiemtraloxien
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class FKiemtraloxien : Form
  {
    private string sql = "";
    private DateTime ngaybatdau = DateTime.Now.AddDays(12.0);
    private DateTime ngayketthuc = DateTime.Now.AddDays(13.0);
    private int countCheckBox = 0;
    private int soBanghiKiemTra = 0;
    private int soThangKiemTra = 1;
    private IContainer components = (IContainer) null;
    private Tbloto objloto;
    private TbLoxien objLoxien;
    private string _caplon;
    private string _trungdau;
    private string _trungduoi;
    private Decimal diemganLon;
    private Decimal diemganNho;
    private DataTable dtLoto;
    private DataTable dtLoaiLoto;
    private DataTable dtLoaiLotoTong;
    private DataTable dataTableKetQua;
    private DataTable _dtLoToVe;
    private string[] _Caploto;
    private string _loto1;
    private string _loto2;
    private Panel pnTop;
    private Panel pnBot;
    private GroupBox groupBox1;
    private Label label1;
    private DateTimePicker dtDenngay;
    private Label label2;
    private DateTimePicker dtTungay;
    private CheckBox cbTrungdau;
    private Label label3;
    private CheckBox cbCaplon;
    private CheckBox cbTrungduoi;
    private CheckBox cbCaptudo;
    private Button btnThongke;
    private BackgroundWorker bgXuly;
    private StatusStrip statusStrip1;
    private ToolStripProgressBar processbar;
    private ToolStripStatusLabel lblTrangthai;
    private Label label4;
    private Label label6;
    private Label label5;
    private NumericUpDown numLon;
    private NumericUpDown numNho;
    private DataGridView dtg_Ketqua;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn ngayThang;
    private DataGridViewTextBoxColumn boSo;
    private DataGridViewTextBoxColumn tongSoCap;
    private DataGridViewTextBoxColumn soCapVe;
    private DataGridViewTextBoxColumn soCapXit;
    private DataGridViewTextBoxColumn hieuQua;
    private DataGridViewTextBoxColumn colTrong;

    public FKiemtraloxien()
    {
      this.InitializeComponent();
      this.dtDenngay.Value = FMain.NgayKetQuaMoiNhat;
      this.dtTungay.Value = FMain.NgayKetQuaMoiNhat.AddMonths(-this.soThangKiemTra);
      this.objLoxien = new TbLoxien();
      this.objloto = new Tbloto();
      this.dtLoto = new DataTable();
      this.dtLoto = new DataTable();
      this.bgXuly.WorkerReportsProgress = true;
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      this.diemganNho = this.numNho.Value;
      this.diemganLon = this.numLon.Value;
      if (this.countCheckBox < 1)
      {
        int num = (int) MessageBox.Show("Vui lòng chọn một loại lô tô để kiểm tra", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (this.bgXuly.IsBusy)
          return;
        this._caplon = "";
        this._trungdau = "";
        this._trungduoi = "";
        this.sql = "select boSo,ngayChuaRa,maxGan,diemGan,veNgay from TbLoxien where boSo=N'00' ";
        if (this.cbCaplon.Checked)
          this._caplon = " or loai=N'locap'";
        if (this.cbTrungdau.Checked)
          this._trungdau = " or loai=N'trungdau'";
        if (this.cbTrungduoi.Checked)
          this._trungduoi = " or loai=N'trungduoi'";
        if (this.cbCaptudo.Checked)
          this._trungduoi = " or loai=N'tudo'";
        this.sql = this.sql + this._caplon + this._trungdau + this._trungduoi;
        this.TaoBangLuuTru();
        this.bgXuly.RunWorkerAsync();
      }
    }

    private void XuLy()
    {
      this.ngaybatdau = this.dtTungay.Value;
      this.ngayketthuc = this.dtDenngay.Value;
      this.dtLoaiLoto = this.objLoxien.GetAllByLoaiLoto_Sql(this.sql);
      this.dtLoto = this.objloto.GetLotoByNgayThang(this.ngaybatdau.AddMonths(-10), this.ngayketthuc);
      this.lblTrangthai.Text = "Truy xuất dữ liệu";
      if (this.dtLoto.Rows.Count <= 0)
        return;
      DataTable dataTable1 = ((IEnumerable<DataRow>) this.dtLoto.Select("clngaythang>='" + (object) this.ngaybatdau + "' and clngaythang<='" + (object) this.ngayketthuc + "'")).CopyToDataTable<DataRow>();
      this.soBanghiKiemTra = dataTable1.Rows.Count;
      for (int percentProgress = 0; percentProgress < dataTable1.Rows.Count; ++percentProgress)
      {
        this.bgXuly.ReportProgress(percentProgress);
        DateTime dateTime = Convert.ToDateTime(dataTable1.Rows[percentProgress]["clngaythang"].ToString());
        this.lblTrangthai.Text = " đang xử lý dữ liệu ngày " + dateTime.ToString("dd/MM/yyyy");
        DataRow[] dataRowArray = this.dtLoto.Select("clngaythang<='" + (object) dateTime + "'");
        if ((uint) dataRowArray.Length > 0U)
        {
          DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
          if (dataTable2.Rows.Count > 0)
          {
            DataView defaultView = dataTable2.DefaultView;
            defaultView.Sort = "clngaythang desc";
            DataTable table = defaultView.ToTable();
            for (int index1 = 0; index1 < this.dtLoaiLoto.Rows.Count; ++index1)
            {
              string[] strArray = this.dtLoaiLoto.Rows[index1]["boSo"].ToString().Split('-');
              string str1 = strArray[0];
              string str2 = strArray[1];
              int num = 0;
              for (int index2 = 0; index2 < table.Rows.Count; ++index2)
              {
                bool flag1 = false;
                bool flag2 = false;
                for (int index3 = 2; index3 < table.Columns.Count; ++index3)
                {
                  string str3 = table.Rows[index2][index3].ToString();
                  if (str1 == str3)
                    flag1 = true;
                  if (str2 == str3)
                    flag2 = true;
                  if (flag1 & flag2)
                    break;
                }
                if (flag1 & flag2)
                {
                  num = index2;
                  break;
                }
              }
              this.dtLoaiLoto.Rows[index1]["ngayChuaRa"] = (object) num;
              this.dtLoaiLoto.Rows[index1]["diemGan"] = (object) Math.Round(Convert.ToDecimal(num) / Convert.ToDecimal(this.dtLoaiLoto.Rows[index1]["maxGan"].ToString()) * new Decimal(10), 2);
            }
            if (this.dtLoaiLoto.Rows.Count > 0)
              this.TinhToanLoVeTungNgay(this.dtLoaiLoto, dateTime);
          }
        }
      }
      this.lblTrangthai.Text = " Hoàn thành";
    }

    private void TaoBangLuuTru()
    {
      this.dataTableKetQua = new DataTable();
      this.dataTableKetQua.Columns.Add("STT", typeof (int));
      this.dataTableKetQua.Columns.Add("ngayThang", typeof (DateTime));
      this.dataTableKetQua.Columns.Add("boSo", typeof (string));
      this.dataTableKetQua.Columns.Add("tongSoCap", typeof (int));
      this.dataTableKetQua.Columns.Add("soCapVe", typeof (int));
      this.dataTableKetQua.Columns.Add("soCapxit", typeof (int));
      this.dataTableKetQua.Columns.Add("hieuQua", typeof (string));
    }

    private void TinhToanLoVeTungNgay(DataTable _dataTable, DateTime _ngayThang)
    {
      DataRow[] dataRowArray1 = _dataTable.Select("diemGan>=" + (object) this.diemganNho + " and diemGan<=" + (object) this.diemganLon ?? "");
      if ((uint) dataRowArray1.Length <= 0U)
        return;
      _dataTable = ((IEnumerable<DataRow>) dataRowArray1).CopyToDataTable<DataRow>();
      this._dtLoToVe = new DataTable();
      DataRow[] dataRowArray2 = this.dtLoto.Select("clngaythang > '" + (object) _ngayThang + "' and clngaythang <= '" + (object) _ngayThang.AddDays((double) FMain.ObjConfigBacNho.KhungLoXien2) + "'");
      if ((uint) dataRowArray2.Length > 0U)
        this._dtLoToVe = ((IEnumerable<DataRow>) dataRowArray2).CopyToDataTable<DataRow>();
      string str1 = "";
      int num1 = 0;
      int num2 = 0;
      for (int index1 = 0; index1 < _dataTable.Rows.Count; ++index1)
      {
        bool flag1 = false;
        bool flag2 = false;
        this._Caploto = _dataTable.Rows[index1]["boSo"].ToString().Split('-');
        this._loto1 = this._Caploto[0];
        this._loto2 = this._Caploto[1];
        str1 = str1 + this._loto1 + "-" + this._loto2 + ";";
        int num3 = 0;
        for (int index2 = 0; index2 < this._dtLoToVe.Rows.Count; ++index2)
        {
          flag1 = false;
          flag2 = false;
          for (int index3 = 2; index3 < this._dtLoToVe.Columns.Count; ++index3)
          {
            string str2 = this._dtLoToVe.Rows[index2][index3].ToString();
            if (this._loto1 == str2)
              flag1 = true;
            if (this._loto2 == str2)
              flag2 = true;
            if (flag1 & flag2)
              break;
          }
          if (flag1 & flag2)
          {
            num3 = index2 + 1;
            break;
          }
        }
        if (flag1 & flag2)
        {
          if (num3 <= FMain.ObjConfigBacNho.KhungLoXien2)
            ++num1;
        }
        else
          ++num2;
        _dataTable.Rows[index1]["veNgay"] = (object) num3;
      }
      DataRow row = this.dataTableKetQua.NewRow();
      row["STT"] = (object) (this.dataTableKetQua.Rows.Count + 1);
      row["ngayThang"] = (object) _ngayThang;
      row["boSo"] = (object) str1;
      row["tongSoCap"] = (object) _dataTable.Rows.Count;
      row["soCapVe"] = (object) num1;
      row["soCapxit"] = (object) num2;
      row["hieuQua"] = num1 != 0 ? (object) "Tuyệt vời" : (object) "Không về";
      this.dataTableKetQua.Rows.Add(row);
    }

    private void bgXuly_DoWork(object sender, DoWorkEventArgs e)
    {
      this.XuLy();
    }

    private void cbCaplon_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      if (checkBox.Checked)
      {
        checkBox.ForeColor = Color.Red;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Bold);
        ++this.countCheckBox;
      }
      else
      {
        checkBox.ForeColor = Color.Black;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Regular);
        --this.countCheckBox;
      }
    }

    private void dtTungay_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtTungay.Value > this.dtDenngay.Value))
        return;
      this.dtTungay.Value = this.dtDenngay.Value.AddMonths(-this.soThangKiemTra);
    }

    private void bgXuly_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.processbar.Maximum = this.soBanghiKiemTra;
      this.processbar.Value = e.ProgressPercentage;
    }

    private void bgXuly_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      int num1 = 0;
      int count = this.dataTableKetQua.Rows.Count;
      int num2 = 0;
      int num3 = 0;
      for (int index = 0; index < this.dataTableKetQua.Rows.Count; ++index)
      {
        if (this.dataTableKetQua.Rows[index]["hieuQua"].ToString() == "Tuyệt vời")
          ++num1;
        num2 += Convert.ToInt32(this.dataTableKetQua.Rows[index]["soCapVe"].ToString());
        num3 += Convert.ToInt32(this.dataTableKetQua.Rows[index]["tongSoCap"].ToString());
      }
      if (this.dataTableKetQua.Rows.Count > 0)
        this.dataTableKetQua.Rows[this.dataTableKetQua.Rows.Count - 1]["hieuQua"] = (object) "Đang đợi";
      this.dtg_Ketqua.DataSource = (object) this.dataTableKetQua;
      this.lblTrangthai.Text = "Số ngày về " + (object) num1 + "/" + (object) count + " ngày   Số cặp về " + (object) num2 + "/" + (object) num3 + " cặp";
    }

    private void XuLyMau()
    {
      for (int index1 = 0; index1 < this.dtg_Ketqua.Rows.Count; ++index1)
      {
        for (int index2 = 0; index2 < this.dtg_Ketqua.Columns.Count; ++index2)
        {
          string str = this.dtg_Ketqua.Rows[index1].Cells["hieuQua"].Value.ToString();
          DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
          if (str == "Không về" || str == "Đang đợi")
          {
            gridViewCellStyle.ForeColor = Color.Black;
            gridViewCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
          }
          this.dtg_Ketqua.Rows[index1].Cells[index2].Style = gridViewCellStyle;
        }
      }
    }

    private void dtg_Ketqua_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      this.XuLyMau();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      this.pnTop = new Panel();
      this.groupBox1 = new GroupBox();
      this.numLon = new NumericUpDown();
      this.numNho = new NumericUpDown();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.btnThongke = new Button();
      this.cbCaptudo = new CheckBox();
      this.cbTrungduoi = new CheckBox();
      this.cbTrungdau = new CheckBox();
      this.label3 = new Label();
      this.cbCaplon = new CheckBox();
      this.label1 = new Label();
      this.dtDenngay = new DateTimePicker();
      this.label2 = new Label();
      this.dtTungay = new DateTimePicker();
      this.pnBot = new Panel();
      this.bgXuly = new BackgroundWorker();
      this.statusStrip1 = new StatusStrip();
      this.processbar = new ToolStripProgressBar();
      this.lblTrangthai = new ToolStripStatusLabel();
      this.dtg_Ketqua = new DataGridView();
      this.stt = new DataGridViewTextBoxColumn();
      this.ngayThang = new DataGridViewTextBoxColumn();
      this.boSo = new DataGridViewTextBoxColumn();
      this.tongSoCap = new DataGridViewTextBoxColumn();
      this.soCapVe = new DataGridViewTextBoxColumn();
      this.soCapXit = new DataGridViewTextBoxColumn();
      this.hieuQua = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.pnTop.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.numLon.BeginInit();
      this.numNho.BeginInit();
      this.pnBot.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.SuspendLayout();
      this.pnTop.Controls.Add((Control) this.groupBox1);
      this.pnTop.Dock = DockStyle.Top;
      this.pnTop.Location = new Point(0, 0);
      this.pnTop.Name = "pnTop";
      this.pnTop.Size = new Size(1242, 55);
      this.pnTop.TabIndex = 0;
      this.groupBox1.Controls.Add((Control) this.numLon);
      this.groupBox1.Controls.Add((Control) this.numNho);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.btnThongke);
      this.groupBox1.Controls.Add((Control) this.cbCaptudo);
      this.groupBox1.Controls.Add((Control) this.cbTrungduoi);
      this.groupBox1.Controls.Add((Control) this.cbTrungdau);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.cbCaplon);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.dtDenngay);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.dtTungay);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1242, 55);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.numLon.DecimalPlaces = 2;
      this.numLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numLon.ForeColor = Color.Red;
      this.numLon.Location = new Point(967, 19);
      this.numLon.Name = "numLon";
      this.numLon.Size = new Size(60, 21);
      this.numLon.TabIndex = 64;
      this.numLon.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numNho.DecimalPlaces = 2;
      this.numNho.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numNho.ForeColor = Color.Red;
      this.numNho.Location = new Point(867, 19);
      this.numNho.Name = "numNho";
      this.numNho.Size = new Size(60, 21);
      this.numNho.TabIndex = 63;
      this.numNho.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.label6.AutoSize = true;
      this.label6.Location = new Point(937, 22);
      this.label6.Name = "label6";
      this.label6.Size = new Size(30, 15);
      this.label6.TabIndex = 62;
      this.label6.Text = "Đến";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(845, 22);
      this.label5.Name = "label5";
      this.label5.Size = new Size(22, 15);
      this.label5.TabIndex = 61;
      this.label5.Text = "Từ";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(757, 22);
      this.label4.Name = "label4";
      this.label4.Size = new Size(79, 15);
      this.label4.TabIndex = 59;
      this.label4.Text = "Xét điểm gan";
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(1064, 16);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(137, 25);
      this.btnThongke.TabIndex = 58;
      this.btnThongke.Text = "Kiểm tra hiệu quả";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.cbCaptudo.AutoSize = true;
      this.cbCaptudo.Cursor = Cursors.Hand;
      this.cbCaptudo.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbCaptudo.ForeColor = Color.Black;
      this.cbCaptudo.Location = new Point(650, 21);
      this.cbCaptudo.Name = "cbCaptudo";
      this.cbCaptudo.Size = new Size(80, 19);
      this.cbCaptudo.TabIndex = 57;
      this.cbCaptudo.Text = "Cặp tự do";
      this.cbCaptudo.UseVisualStyleBackColor = true;
      this.cbCaptudo.CheckedChanged += new EventHandler(this.cbCaplon_CheckedChanged);
      this.cbTrungduoi.AutoSize = true;
      this.cbTrungduoi.Cursor = Cursors.Hand;
      this.cbTrungduoi.Location = new Point(532, 21);
      this.cbTrungduoi.Name = "cbTrungduoi";
      this.cbTrungduoi.Size = new Size(107, 19);
      this.cbTrungduoi.TabIndex = 56;
      this.cbTrungduoi.Text = "Cặp trùng đuôi";
      this.cbTrungduoi.UseVisualStyleBackColor = true;
      this.cbTrungduoi.CheckedChanged += new EventHandler(this.cbCaplon_CheckedChanged);
      this.cbTrungdau.AutoSize = true;
      this.cbTrungdau.Cursor = Cursors.Hand;
      this.cbTrungdau.Location = new Point(417, 21);
      this.cbTrungdau.Name = "cbTrungdau";
      this.cbTrungdau.Size = new Size(104, 19);
      this.cbTrungdau.TabIndex = 55;
      this.cbTrungdau.Text = "Cặp trùng đầu";
      this.cbTrungdau.UseVisualStyleBackColor = true;
      this.cbTrungdau.CheckedChanged += new EventHandler(this.cbCaplon_CheckedChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(293, 22);
      this.label3.Name = "label3";
      this.label3.Size = new Size(38, 15);
      this.label3.TabIndex = 54;
      this.label3.Text = "bộ số";
      this.cbCaplon.AutoSize = true;
      this.cbCaplon.Cursor = Cursors.Hand;
      this.cbCaplon.Location = new Point(337, 21);
      this.cbCaplon.Name = "cbCaplon";
      this.cbCaplon.Size = new Size(69, 19);
      this.cbCaplon.TabIndex = 53;
      this.cbCaplon.Text = "Cặp lộn";
      this.cbCaplon.UseVisualStyleBackColor = true;
      this.cbCaplon.CheckedChanged += new EventHandler(this.cbCaplon_CheckedChanged);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(162, 21);
      this.label1.Name = "label1";
      this.label1.Size = new Size(12, 16);
      this.label1.TabIndex = 52;
      this.label1.Text = "-";
      this.dtDenngay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtDenngay.CalendarForeColor = Color.Red;
      this.dtDenngay.CalendarMonthBackground = SystemColors.Info;
      this.dtDenngay.CustomFormat = "dd/MM/yyyy";
      this.dtDenngay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtDenngay.Format = DateTimePickerFormat.Custom;
      this.dtDenngay.Location = new Point(174, 19);
      this.dtDenngay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtDenngay.Name = "dtDenngay";
      this.dtDenngay.Size = new Size(91, 21);
      this.dtDenngay.TabIndex = 51;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(11, 21);
      this.label2.Name = "label2";
      this.label2.Size = new Size(56, 16);
      this.label2.TabIndex = 50;
      this.label2.Text = "Từ ngày";
      this.dtTungay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtTungay.CalendarForeColor = Color.Red;
      this.dtTungay.CalendarMonthBackground = SystemColors.Info;
      this.dtTungay.CustomFormat = "dd/MM/yyyy";
      this.dtTungay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtTungay.Format = DateTimePickerFormat.Custom;
      this.dtTungay.Location = new Point(70, 19);
      this.dtTungay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtTungay.Name = "dtTungay";
      this.dtTungay.Size = new Size(91, 21);
      this.dtTungay.TabIndex = 49;
      this.dtTungay.ValueChanged += new EventHandler(this.dtTungay_ValueChanged);
      this.pnBot.Controls.Add((Control) this.dtg_Ketqua);
      this.pnBot.Dock = DockStyle.Fill;
      this.pnBot.Location = new Point(0, 55);
      this.pnBot.Name = "pnBot";
      this.pnBot.Size = new Size(1242, 473);
      this.pnBot.TabIndex = 1;
      this.bgXuly.DoWork += new DoWorkEventHandler(this.bgXuly_DoWork);
      this.bgXuly.ProgressChanged += new ProgressChangedEventHandler(this.bgXuly_ProgressChanged);
      this.bgXuly.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgXuly_RunWorkerCompleted);
      this.statusStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.processbar,
        (ToolStripItem) this.lblTrangthai
      });
      this.statusStrip1.Location = new Point(0, 506);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.RenderMode = ToolStripRenderMode.Professional;
      this.statusStrip1.Size = new Size(1242, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      this.processbar.Name = "processbar";
      this.processbar.Size = new Size(120, 16);
      this.processbar.Step = 1;
      this.processbar.Value = 100;
      this.lblTrangthai.Name = "lblTrangthai";
      this.lblTrangthai.Size = new Size(56, 17);
      this.lblTrangthai.Text = "Trạng thái";
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_Ketqua.BackgroundColor = SystemColors.ButtonHighlight;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 24;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.stt, (DataGridViewColumn) this.ngayThang, (DataGridViewColumn) this.boSo, (DataGridViewColumn) this.tongSoCap, (DataGridViewColumn) this.soCapVe, (DataGridViewColumn) this.soCapXit, (DataGridViewColumn) this.hieuQua, (DataGridViewColumn) this.colTrong);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.GridColor = Color.WhiteSmoke;
      this.dtg_Ketqua.Location = new Point(1, 1);
      this.dtg_Ketqua.Margin = new Padding(0);
      this.dtg_Ketqua.MultiSelect = false;
      this.dtg_Ketqua.Name = "dtg_Ketqua";
      this.dtg_Ketqua.ReadOnly = true;
      this.dtg_Ketqua.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.BackColor = Color.Cornsilk;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dtg_Ketqua.RowHeadersVisible = false;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dtg_Ketqua.RowTemplate.Height = 24;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(1240, 450);
      this.dtg_Ketqua.TabIndex = 4;
      this.dtg_Ketqua.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dtg_Ketqua_DataBindingComplete);
      this.stt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.stt.DataPropertyName = "STT";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle4.ForeColor = Color.Gray;
      this.stt.DefaultCellStyle = gridViewCellStyle4;
      this.stt.HeaderText = "STT ";
      this.stt.Name = "stt";
      this.stt.ReadOnly = true;
      this.stt.Width = 45;
      this.ngayThang.DataPropertyName = "ngayThang";
      gridViewCellStyle5.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.ngayThang.DefaultCellStyle = gridViewCellStyle5;
      this.ngayThang.HeaderText = "Ngày tháng";
      this.ngayThang.Name = "ngayThang";
      this.ngayThang.ReadOnly = true;
      this.boSo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.boSo.DataPropertyName = "boSo";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle6.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle6.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle6.ForeColor = Color.Red;
      this.boSo.DefaultCellStyle = gridViewCellStyle6;
      this.boSo.HeaderText = "Bộ số";
      this.boSo.Name = "boSo";
      this.boSo.ReadOnly = true;
      this.boSo.ToolTipText = "Lô tạo thành";
      this.tongSoCap.DataPropertyName = "tongSoCap";
      this.tongSoCap.HeaderText = "Tổng số cặp";
      this.tongSoCap.Name = "tongSoCap";
      this.tongSoCap.ReadOnly = true;
      this.tongSoCap.Width = 85;
      this.soCapVe.DataPropertyName = "soCapVe";
      this.soCapVe.HeaderText = "Số cặp về";
      this.soCapVe.Name = "soCapVe";
      this.soCapVe.ReadOnly = true;
      this.soCapVe.Width = 70;
      this.soCapXit.DataPropertyName = "soCapxit";
      this.soCapXit.HeaderText = "Số cặp xịt";
      this.soCapXit.Name = "soCapXit";
      this.soCapXit.ReadOnly = true;
      this.soCapXit.Width = 70;
      this.hieuQua.DataPropertyName = "hieuQua";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle7.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = Color.Red;
      this.hieuQua.DefaultCellStyle = gridViewCellStyle7;
      this.hieuQua.HeaderText = "Hiệu quả";
      this.hieuQua.Name = "hieuQua";
      this.hieuQua.ReadOnly = true;
      this.hieuQua.Width = 80;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.colTrong.Width = 250;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1242, 528);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.pnBot);
      this.Controls.Add((Control) this.pnTop);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (FKiemtraloxien);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Kiểm tra hiệu quả lô xiên";
      this.pnTop.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numLon.EndInit();
      this.numNho.EndInit();
      this.pnBot.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
