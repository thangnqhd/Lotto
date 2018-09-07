// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabChukygiaiDacBiet
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabChukygiaiDacBiet : UserControl
  {
    private IContainer components = (IContainer) null;
    private Tbloto objLoto;
    private DateTime ngaykiemtra;
    private DataTable dataTable;
    private Decimal tongsongayxet;
    private ArrayList _arrloto;
    private string _loto;
    private DataTable dtG0;
    private DataView _view;
    private DataRow rows;
    private Panel panel1;
    private GroupBox groupBox8;
    private CheckBox cbGan2nam;
    private NumericUpDown numGan2namLon;
    private Label label16;
    private NumericUpDown numGan2namNho;
    private Label label17;
    private GroupBox groupBox7;
    private CheckBox cbDiemgan;
    private NumericUpDown numDiemganLon;
    private Label label14;
    private NumericUpDown numDiemganNho;
    private Label label15;
    private GroupBox groupBox6;
    private Button btnThongke;
    private Label label3;
    private DateTimePicker dtNgayXem;
    private Label label2;
    private TextBox txtBiendokiemtra;
    private Label label1;
    private GroupBox groupBox1;
    private CheckBox cbSolanve;
    private NumericUpDown numSolanveLon;
    private Label label5;
    private NumericUpDown numSolanveBe;
    private Label label4;
    private GroupBox groupBox4;
    private CheckBox cbDiemtanxuat;
    private NumericUpDown numTanxuatLon;
    private Label label10;
    private NumericUpDown numTanxuatBe;
    private Label label11;
    private GroupBox groupBox3;
    private CheckBox cbGantrongkhung;
    private NumericUpDown numGantrongkhungLon;
    private Label label8;
    private NumericUpDown numGantrongkhungBe;
    private Label label9;
    private GroupBox groupBox2;
    private CheckBox cbNgaychuara;
    private NumericUpDown numNgaychuaraLon;
    private Label label6;
    private NumericUpDown numNgaychuaraBe;
    private Label label7;
    private Panel pnBot;
    private DataGridView dtg_Ketqua;
    private PictureBox picLoading;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn loto;
    private DataGridViewTextBoxColumn solanve;
    private DataGridViewTextBoxColumn trungbinhnam;
    private DataGridViewTextBoxColumn chuKi;
    private DataGridViewTextBoxColumn ngayChuara;
    private DataGridViewTextBoxColumn gantrongkhung;
    private DataGridViewTextBoxColumn maxGan;
    private DataGridViewTextBoxColumn diemtanxuat;
    private DataGridViewTextBoxColumn diemGan;
    private DataGridViewTextBoxColumn veNgay;
    private DataGridViewTextBoxColumn colTrong;
    private Timer timer1;
    private BackgroundWorker bgXuly;

    public TabChukygiaiDacBiet()
    {
      this.InitializeComponent();
      this.objLoto = new Tbloto();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.bgXuly.IsBusy;
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      if (this.txtBiendokiemtra.Text.Length <= 0)
        return;
      try
      {
        Convert.ToInt32(this.txtBiendokiemtra.Text);
        if (!this.bgXuly.IsBusy)
          this.bgXuly.RunWorkerAsync();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Số năm kiểm tra không chính xác. Vui lòng nhập lại !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    public void KhoiTao_DataTable()
    {
      this.dataTable = new DataTable();
      this.dataTable.Columns.Add("stt", typeof (int));
      this.dataTable.Columns.Add("loto", typeof (string));
      this.dataTable.Columns.Add("solanve", typeof (int));
      this.dataTable.Columns.Add("trungbinhnam", typeof (int));
      this.dataTable.Columns.Add("chuKi", typeof (double));
      this.dataTable.Columns.Add("ngayChuara", typeof (int));
      this.dataTable.Columns.Add("gantrongkhung", typeof (int));
      this.dataTable.Columns.Add("maxGan", typeof (int));
      this.dataTable.Columns.Add("diemtanxuat", typeof (double));
      this.dataTable.Columns.Add("diemGan", typeof (double));
      this.dataTable.Columns.Add("veNgay", typeof (double));
      this.dataTable.Columns.Add("colTrong", typeof (string));
    }

    private void Xuly()
    {
      this.KhoiTao_DataTable();
      this.dtG0 = this.objLoto.Get_G0_By_Date(this.dtNgayXem.Value.AddMonths(-Convert.ToInt32(this.txtBiendokiemtra.Text)), this.dtNgayXem.Value);
      if (this.dtG0.Rows.Count <= 0)
        return;
      this._arrloto = new ArrayList();
      for (int index = 0; index < 100; ++index)
      {
        this._loto = index.ToString();
        if (Convert.ToInt32(this._loto) < 10)
          this._loto = "0" + index.ToString();
        this._arrloto.Add((object) this._loto);
      }
      this.tongsongayxet = (Decimal) this.dtG0.Rows.Count;
      for (int index1 = 0; index1 < this._arrloto.Count; ++index1)
      {
        bool flag = false;
        int num1 = 0;
        int num2 = 0;
        int num3 = -1;
        Decimal num4 = new Decimal();
        string str = this._arrloto[index1].ToString();
        for (int index2 = 0; index2 < this.dtG0.Rows.Count; ++index2)
        {
          if (this.dtG0.Rows[index2]["loto"].ToString() == str)
          {
            ++num4;
            if (!flag)
            {
              num3 = index2;
              flag = true;
            }
            if (num2 > num1)
            {
              num1 = num2;
              num2 = 0;
            }
          }
          else
            ++num2;
        }
        this.rows = this.dataTable.NewRow();
        this.rows["stt"] = (object) (index1 + 1).ToString();
        this.rows["loto"] = (object) str;
        this.rows["solanve"] = (object) num4;
        this.rows["trungbinhnam"] = (object) "0";
        this.rows["chuKi"] = !(num4 < Decimal.One) ? (object) Math.Round(this.tongsongayxet / num4) : (object) "0";
        this.rows["ngayChuara"] = (object) num3;
        this.rows["gantrongkhung"] = (object) num1;
        this.dataTable.Rows.Add(this.rows);
      }
    }

    private void dtNgayXem_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayXem.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void bgXuly_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Xuly();
    }

    private void bgXuly_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.dtg_Ketqua.DataSource = (object) this.dataTable;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabChukygiaiDacBiet));
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
      this.groupBox8 = new GroupBox();
      this.cbGan2nam = new CheckBox();
      this.numGan2namLon = new NumericUpDown();
      this.label16 = new Label();
      this.numGan2namNho = new NumericUpDown();
      this.label17 = new Label();
      this.groupBox7 = new GroupBox();
      this.cbDiemgan = new CheckBox();
      this.numDiemganLon = new NumericUpDown();
      this.label14 = new Label();
      this.numDiemganNho = new NumericUpDown();
      this.label15 = new Label();
      this.groupBox6 = new GroupBox();
      this.btnThongke = new Button();
      this.label3 = new Label();
      this.dtNgayXem = new DateTimePicker();
      this.label2 = new Label();
      this.txtBiendokiemtra = new TextBox();
      this.label1 = new Label();
      this.groupBox1 = new GroupBox();
      this.cbSolanve = new CheckBox();
      this.numSolanveLon = new NumericUpDown();
      this.label5 = new Label();
      this.numSolanveBe = new NumericUpDown();
      this.label4 = new Label();
      this.groupBox4 = new GroupBox();
      this.cbDiemtanxuat = new CheckBox();
      this.numTanxuatLon = new NumericUpDown();
      this.label10 = new Label();
      this.numTanxuatBe = new NumericUpDown();
      this.label11 = new Label();
      this.groupBox3 = new GroupBox();
      this.cbGantrongkhung = new CheckBox();
      this.numGantrongkhungLon = new NumericUpDown();
      this.label8 = new Label();
      this.numGantrongkhungBe = new NumericUpDown();
      this.label9 = new Label();
      this.groupBox2 = new GroupBox();
      this.cbNgaychuara = new CheckBox();
      this.numNgaychuaraLon = new NumericUpDown();
      this.label6 = new Label();
      this.numNgaychuaraBe = new NumericUpDown();
      this.label7 = new Label();
      this.pnBot = new Panel();
      this.picLoading = new PictureBox();
      this.dtg_Ketqua = new DataGridView();
      this.stt = new DataGridViewTextBoxColumn();
      this.loto = new DataGridViewTextBoxColumn();
      this.solanve = new DataGridViewTextBoxColumn();
      this.trungbinhnam = new DataGridViewTextBoxColumn();
      this.chuKi = new DataGridViewTextBoxColumn();
      this.ngayChuara = new DataGridViewTextBoxColumn();
      this.gantrongkhung = new DataGridViewTextBoxColumn();
      this.maxGan = new DataGridViewTextBoxColumn();
      this.diemtanxuat = new DataGridViewTextBoxColumn();
      this.diemGan = new DataGridViewTextBoxColumn();
      this.veNgay = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.timer1 = new Timer(this.components);
      this.bgXuly = new BackgroundWorker();
      this.panel1.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.numGan2namLon.BeginInit();
      this.numGan2namNho.BeginInit();
      this.groupBox7.SuspendLayout();
      this.numDiemganLon.BeginInit();
      this.numDiemganNho.BeginInit();
      this.groupBox6.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.numSolanveLon.BeginInit();
      this.numSolanveBe.BeginInit();
      this.groupBox4.SuspendLayout();
      this.numTanxuatLon.BeginInit();
      this.numTanxuatBe.BeginInit();
      this.groupBox3.SuspendLayout();
      this.numGantrongkhungLon.BeginInit();
      this.numGantrongkhungBe.BeginInit();
      this.groupBox2.SuspendLayout();
      this.numNgaychuaraLon.BeginInit();
      this.numNgaychuaraBe.BeginInit();
      this.pnBot.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.groupBox8);
      this.panel1.Controls.Add((Control) this.groupBox7);
      this.panel1.Controls.Add((Control) this.groupBox6);
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Controls.Add((Control) this.groupBox4);
      this.panel1.Controls.Add((Control) this.groupBox3);
      this.panel1.Controls.Add((Control) this.groupBox2);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 124);
      this.panel1.TabIndex = 1;
      this.groupBox8.BackColor = Color.Transparent;
      this.groupBox8.Controls.Add((Control) this.cbGan2nam);
      this.groupBox8.Controls.Add((Control) this.numGan2namLon);
      this.groupBox8.Controls.Add((Control) this.label16);
      this.groupBox8.Controls.Add((Control) this.numGan2namNho);
      this.groupBox8.Controls.Add((Control) this.label17);
      this.groupBox8.Location = new Point(626, 48);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new Size(150, 69);
      this.groupBox8.TabIndex = 48;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Gan (+2 năm)";
      this.cbGan2nam.AutoSize = true;
      this.cbGan2nam.Cursor = Cursors.Hand;
      this.cbGan2nam.Location = new Point(8, 18);
      this.cbGan2nam.Name = "cbGan2nam";
      this.cbGan2nam.Size = new Size(43, 19);
      this.cbGan2nam.TabIndex = 4;
      this.cbGan2nam.Text = "Tắt";
      this.cbGan2nam.UseVisualStyleBackColor = true;
      this.numGan2namLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGan2namLon.Location = new Point(104, 42);
      this.numGan2namLon.Name = "numGan2namLon";
      this.numGan2namLon.Size = new Size(40, 21);
      this.numGan2namLon.TabIndex = 3;
      this.numGan2namLon.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.label16.AutoSize = true;
      this.label16.Location = new Point(71, 46);
      this.label16.Name = "label16";
      this.label16.Size = new Size(30, 15);
      this.label16.TabIndex = 2;
      this.label16.Text = "Đến";
      this.numGan2namNho.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGan2namNho.Location = new Point(27, 42);
      this.numGan2namNho.Name = "numGan2namNho";
      this.numGan2namNho.Size = new Size(40, 21);
      this.numGan2namNho.TabIndex = 1;
      this.label17.AutoSize = true;
      this.label17.Location = new Point(4, 46);
      this.label17.Name = "label17";
      this.label17.Size = new Size(22, 15);
      this.label17.TabIndex = 0;
      this.label17.Text = "Từ";
      this.groupBox7.BackColor = Color.Transparent;
      this.groupBox7.Controls.Add((Control) this.cbDiemgan);
      this.groupBox7.Controls.Add((Control) this.numDiemganLon);
      this.groupBox7.Controls.Add((Control) this.label14);
      this.groupBox7.Controls.Add((Control) this.numDiemganNho);
      this.groupBox7.Controls.Add((Control) this.label15);
      this.groupBox7.Location = new Point(940, 48);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(150, 69);
      this.groupBox7.TabIndex = 47;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Điểm gan";
      this.cbDiemgan.AutoSize = true;
      this.cbDiemgan.Cursor = Cursors.Hand;
      this.cbDiemgan.Location = new Point(8, 18);
      this.cbDiemgan.Name = "cbDiemgan";
      this.cbDiemgan.Size = new Size(43, 19);
      this.cbDiemgan.TabIndex = 4;
      this.cbDiemgan.Text = "Tắt";
      this.cbDiemgan.UseVisualStyleBackColor = true;
      this.numDiemganLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numDiemganLon.Location = new Point(102, 42);
      this.numDiemganLon.Name = "numDiemganLon";
      this.numDiemganLon.Size = new Size(40, 21);
      this.numDiemganLon.TabIndex = 3;
      this.numDiemganLon.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.label14.AutoSize = true;
      this.label14.Location = new Point(69, 46);
      this.label14.Name = "label14";
      this.label14.Size = new Size(30, 15);
      this.label14.TabIndex = 2;
      this.label14.Text = "Đến";
      this.numDiemganNho.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numDiemganNho.Location = new Point(26, 42);
      this.numDiemganNho.Name = "numDiemganNho";
      this.numDiemganNho.Size = new Size(40, 21);
      this.numDiemganNho.TabIndex = 1;
      this.label15.AutoSize = true;
      this.label15.Location = new Point(4, 46);
      this.label15.Name = "label15";
      this.label15.Size = new Size(22, 15);
      this.label15.TabIndex = 0;
      this.label15.Text = "Từ";
      this.groupBox6.Controls.Add((Control) this.btnThongke);
      this.groupBox6.Controls.Add((Control) this.label3);
      this.groupBox6.Controls.Add((Control) this.dtNgayXem);
      this.groupBox6.Controls.Add((Control) this.label2);
      this.groupBox6.Controls.Add((Control) this.txtBiendokiemtra);
      this.groupBox6.Controls.Add((Control) this.label1);
      this.groupBox6.Location = new Point(10, 0);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(1080, 45);
      this.groupBox6.TabIndex = 46;
      this.groupBox6.TabStop = false;
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(456, 13);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(587, 24);
      this.btnThongke.TabIndex = 7;
      this.btnThongke.Text = "Thống Kê";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(215, 16);
      this.label3.Name = "label3";
      this.label3.Size = new Size(50, 16);
      this.label3.TabIndex = 36;
      this.label3.Text = "biên độ";
      this.dtNgayXem.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.CalendarForeColor = Color.Red;
      this.dtNgayXem.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayXem.CustomFormat = "dd/MM/yyyy";
      this.dtNgayXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.Format = DateTimePickerFormat.Custom;
      this.dtNgayXem.Location = new Point(69, 15);
      this.dtNgayXem.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayXem.Name = "dtNgayXem";
      this.dtNgayXem.Size = new Size(91, 21);
      this.dtNgayXem.TabIndex = 0;
      this.dtNgayXem.ValueChanged += new EventHandler(this.dtNgayXem_ValueChanged);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(4, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(65, 16);
      this.label2.TabIndex = 39;
      this.label2.Text = "Xem ngày";
      this.txtBiendokiemtra.BorderStyle = BorderStyle.FixedSingle;
      this.txtBiendokiemtra.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.txtBiendokiemtra.ForeColor = Color.Red;
      this.txtBiendokiemtra.Location = new Point(267, 14);
      this.txtBiendokiemtra.Name = "txtBiendokiemtra";
      this.txtBiendokiemtra.Size = new Size(51, 21);
      this.txtBiendokiemtra.TabIndex = 1;
      this.txtBiendokiemtra.Text = "24";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(321, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(93, 16);
      this.label1.TabIndex = 38;
      this.label1.Text = "tháng về trước";
      this.groupBox1.BackColor = Color.Transparent;
      this.groupBox1.Controls.Add((Control) this.cbSolanve);
      this.groupBox1.Controls.Add((Control) this.numSolanveLon);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.numSolanveBe);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Location = new Point(10, 48);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(145, 69);
      this.groupBox1.TabIndex = 40;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Số lần về";
      this.cbSolanve.AutoSize = true;
      this.cbSolanve.Cursor = Cursors.Hand;
      this.cbSolanve.Location = new Point(9, 16);
      this.cbSolanve.Name = "cbSolanve";
      this.cbSolanve.Size = new Size(43, 19);
      this.cbSolanve.TabIndex = 4;
      this.cbSolanve.Text = "Tắt";
      this.cbSolanve.UseVisualStyleBackColor = true;
      this.numSolanveLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numSolanveLon.Location = new Point(101, 42);
      this.numSolanveLon.Name = "numSolanveLon";
      this.numSolanveLon.Size = new Size(40, 21);
      this.numSolanveLon.TabIndex = 3;
      this.numSolanveLon.Value = new Decimal(new int[4]
      {
        13,
        0,
        0,
        0
      });
      this.label5.AutoSize = true;
      this.label5.Location = new Point(68, 46);
      this.label5.Name = "label5";
      this.label5.Size = new Size(30, 15);
      this.label5.TabIndex = 2;
      this.label5.Text = "Đến";
      this.numSolanveBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numSolanveBe.Location = new Point(27, 42);
      this.numSolanveBe.Name = "numSolanveBe";
      this.numSolanveBe.Size = new Size(40, 21);
      this.numSolanveBe.TabIndex = 1;
      this.numSolanveBe.Value = new Decimal(new int[4]
      {
        6,
        0,
        0,
        0
      });
      this.label4.AutoSize = true;
      this.label4.Location = new Point(4, 46);
      this.label4.Name = "label4";
      this.label4.Size = new Size(22, 15);
      this.label4.TabIndex = 0;
      this.label4.Text = "Từ";
      this.groupBox4.BackColor = Color.Transparent;
      this.groupBox4.Controls.Add((Control) this.cbDiemtanxuat);
      this.groupBox4.Controls.Add((Control) this.numTanxuatLon);
      this.groupBox4.Controls.Add((Control) this.label10);
      this.groupBox4.Controls.Add((Control) this.numTanxuatBe);
      this.groupBox4.Controls.Add((Control) this.label11);
      this.groupBox4.Location = new Point(783, 48);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(150, 69);
      this.groupBox4.TabIndex = 45;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Điểm tần xuất";
      this.cbDiemtanxuat.AutoSize = true;
      this.cbDiemtanxuat.Cursor = Cursors.Hand;
      this.cbDiemtanxuat.Location = new Point(8, 18);
      this.cbDiemtanxuat.Name = "cbDiemtanxuat";
      this.cbDiemtanxuat.Size = new Size(43, 19);
      this.cbDiemtanxuat.TabIndex = 4;
      this.cbDiemtanxuat.Text = "Tắt";
      this.cbDiemtanxuat.UseVisualStyleBackColor = true;
      this.numTanxuatLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTanxuatLon.Location = new Point(102, 42);
      this.numTanxuatLon.Name = "numTanxuatLon";
      this.numTanxuatLon.Size = new Size(40, 21);
      this.numTanxuatLon.TabIndex = 3;
      this.numTanxuatLon.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.label10.AutoSize = true;
      this.label10.Location = new Point(69, 46);
      this.label10.Name = "label10";
      this.label10.Size = new Size(30, 15);
      this.label10.TabIndex = 2;
      this.label10.Text = "Đến";
      this.numTanxuatBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTanxuatBe.Location = new Point(26, 42);
      this.numTanxuatBe.Name = "numTanxuatBe";
      this.numTanxuatBe.Size = new Size(40, 21);
      this.numTanxuatBe.TabIndex = 1;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(4, 46);
      this.label11.Name = "label11";
      this.label11.Size = new Size(22, 15);
      this.label11.TabIndex = 0;
      this.label11.Text = "Từ";
      this.groupBox3.BackColor = Color.Transparent;
      this.groupBox3.Controls.Add((Control) this.cbGantrongkhung);
      this.groupBox3.Controls.Add((Control) this.numGantrongkhungLon);
      this.groupBox3.Controls.Add((Control) this.label8);
      this.groupBox3.Controls.Add((Control) this.numGantrongkhungBe);
      this.groupBox3.Controls.Add((Control) this.label9);
      this.groupBox3.Location = new Point(466, 48);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(152, 69);
      this.groupBox3.TabIndex = 42;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Gan trong khung";
      this.cbGantrongkhung.AutoSize = true;
      this.cbGantrongkhung.Cursor = Cursors.Hand;
      this.cbGantrongkhung.Location = new Point(8, 17);
      this.cbGantrongkhung.Name = "cbGantrongkhung";
      this.cbGantrongkhung.Size = new Size(43, 19);
      this.cbGantrongkhung.TabIndex = 4;
      this.cbGantrongkhung.Text = "Tắt";
      this.cbGantrongkhung.UseVisualStyleBackColor = true;
      this.numGantrongkhungLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGantrongkhungLon.Location = new Point(104, 42);
      this.numGantrongkhungLon.Name = "numGantrongkhungLon";
      this.numGantrongkhungLon.Size = new Size(40, 21);
      this.numGantrongkhungLon.TabIndex = 3;
      this.numGantrongkhungLon.Value = new Decimal(new int[4]
      {
        8,
        0,
        0,
        0
      });
      this.label8.AutoSize = true;
      this.label8.Location = new Point(74, 46);
      this.label8.Name = "label8";
      this.label8.Size = new Size(30, 15);
      this.label8.TabIndex = 2;
      this.label8.Text = "Đến";
      this.numGantrongkhungBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGantrongkhungBe.Location = new Point(28, 42);
      this.numGantrongkhungBe.Name = "numGantrongkhungBe";
      this.numGantrongkhungBe.Size = new Size(40, 21);
      this.numGantrongkhungBe.TabIndex = 1;
      this.numGantrongkhungBe.Value = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.label9.AutoSize = true;
      this.label9.Location = new Point(4, 46);
      this.label9.Name = "label9";
      this.label9.Size = new Size(22, 15);
      this.label9.TabIndex = 0;
      this.label9.Text = "Từ";
      this.groupBox2.BackColor = Color.Transparent;
      this.groupBox2.Controls.Add((Control) this.cbNgaychuara);
      this.groupBox2.Controls.Add((Control) this.numNgaychuaraLon);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.numNgaychuaraBe);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Location = new Point(314, 48);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(145, 69);
      this.groupBox2.TabIndex = 41;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Ngày chưa ra";
      this.cbNgaychuara.AutoSize = true;
      this.cbNgaychuara.Cursor = Cursors.Hand;
      this.cbNgaychuara.Location = new Point(9, 18);
      this.cbNgaychuara.Name = "cbNgaychuara";
      this.cbNgaychuara.Size = new Size(43, 19);
      this.cbNgaychuara.TabIndex = 4;
      this.cbNgaychuara.Text = "Tắt";
      this.cbNgaychuara.UseVisualStyleBackColor = true;
      this.numNgaychuaraLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numNgaychuaraLon.Location = new Point(100, 42);
      this.numNgaychuaraLon.Name = "numNgaychuaraLon";
      this.numNgaychuaraLon.Size = new Size(40, 21);
      this.numNgaychuaraLon.TabIndex = 3;
      this.numNgaychuaraLon.Value = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.label6.AutoSize = true;
      this.label6.Location = new Point(70, 46);
      this.label6.Name = "label6";
      this.label6.Size = new Size(30, 15);
      this.label6.TabIndex = 2;
      this.label6.Text = "Đến";
      this.numNgaychuaraBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numNgaychuaraBe.Location = new Point(28, 42);
      this.numNgaychuaraBe.Name = "numNgaychuaraBe";
      this.numNgaychuaraBe.Size = new Size(40, 21);
      this.numNgaychuaraBe.TabIndex = 1;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(4, 46);
      this.label7.Name = "label7";
      this.label7.Size = new Size(22, 15);
      this.label7.TabIndex = 0;
      this.label7.Text = "Từ";
      this.pnBot.Controls.Add((Control) this.picLoading);
      this.pnBot.Controls.Add((Control) this.dtg_Ketqua);
      this.pnBot.Dock = DockStyle.Fill;
      this.pnBot.Location = new Point(0, 124);
      this.pnBot.Name = "pnBot";
      this.pnBot.Size = new Size(1100, 451);
      this.pnBot.TabIndex = 2;
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(520, 206);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 62;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
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
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.stt, (DataGridViewColumn) this.loto, (DataGridViewColumn) this.solanve, (DataGridViewColumn) this.trungbinhnam, (DataGridViewColumn) this.chuKi, (DataGridViewColumn) this.ngayChuara, (DataGridViewColumn) this.gantrongkhung, (DataGridViewColumn) this.maxGan, (DataGridViewColumn) this.diemtanxuat, (DataGridViewColumn) this.diemGan, (DataGridViewColumn) this.veNgay, (DataGridViewColumn) this.colTrong);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.Dock = DockStyle.Fill;
      this.dtg_Ketqua.GridColor = Color.WhiteSmoke;
      this.dtg_Ketqua.Location = new Point(0, 0);
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
      this.dtg_Ketqua.Size = new Size(1100, 451);
      this.dtg_Ketqua.TabIndex = 4;
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
      this.loto.DataPropertyName = "loto";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle5.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = Color.Red;
      this.loto.DefaultCellStyle = gridViewCellStyle5;
      this.loto.HeaderText = "Bộ số";
      this.loto.Name = "loto";
      this.loto.ReadOnly = true;
      this.loto.ToolTipText = "Lô tạo thành";
      this.loto.Width = 90;
      this.solanve.DataPropertyName = "solanve";
      gridViewCellStyle6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.solanve.DefaultCellStyle = gridViewCellStyle6;
      this.solanve.HeaderText = "Số lần về";
      this.solanve.Name = "solanve";
      this.solanve.ReadOnly = true;
      this.solanve.ToolTipText = "Số lần về của lô tô trong khung kiểm tra";
      this.solanve.Width = 80;
      this.trungbinhnam.DataPropertyName = "trungbinhnam";
      this.trungbinhnam.HeaderText = "Trung bình/Năm (lần)";
      this.trungbinhnam.Name = "trungbinhnam";
      this.trungbinhnam.ReadOnly = true;
      this.trungbinhnam.Width = 130;
      this.chuKi.DataPropertyName = "chuKi";
      gridViewCellStyle7.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.chuKi.DefaultCellStyle = gridViewCellStyle7;
      this.chuKi.HeaderText = "Chu kỳ (ngày)";
      this.chuKi.Name = "chuKi";
      this.chuKi.ReadOnly = true;
      this.chuKi.ToolTipText = "Chu kỳ trung bình để lô tô về lại";
      this.ngayChuara.DataPropertyName = "ngayChuara";
      gridViewCellStyle8.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle8.ForeColor = Color.Red;
      this.ngayChuara.DefaultCellStyle = gridViewCellStyle8;
      this.ngayChuara.HeaderText = "Ngày chưa ra";
      this.ngayChuara.Name = "ngayChuara";
      this.ngayChuara.ReadOnly = true;
      this.ngayChuara.ToolTipText = "Số ngày chưa ra của lô tô";
      this.ngayChuara.Width = 95;
      this.gantrongkhung.DataPropertyName = "gantrongkhung";
      gridViewCellStyle9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.gantrongkhung.DefaultCellStyle = gridViewCellStyle9;
      this.gantrongkhung.HeaderText = "Gan trong khung";
      this.gantrongkhung.Name = "gantrongkhung";
      this.gantrongkhung.ReadOnly = true;
      this.gantrongkhung.ToolTipText = "Khoảng ngày chưa ra lớn nhất trong khung kiểm tra";
      this.gantrongkhung.Width = 110;
      this.maxGan.DataPropertyName = "maxGan";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.maxGan.DefaultCellStyle = gridViewCellStyle10;
      this.maxGan.HeaderText = "Gan lịch sử";
      this.maxGan.Name = "maxGan";
      this.maxGan.ReadOnly = true;
      this.maxGan.ToolTipText = "Khoảng ngày chưa ra lớn nhất trong khung kiểm tra + 2 năm";
      this.diemtanxuat.DataPropertyName = "diemtanxuat";
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle11.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle11.ForeColor = Color.Red;
      this.diemtanxuat.DefaultCellStyle = gridViewCellStyle11;
      this.diemtanxuat.HeaderText = "Điểm tần xuất";
      this.diemtanxuat.Name = "diemtanxuat";
      this.diemtanxuat.ReadOnly = true;
      this.diemtanxuat.ToolTipText = "Điểm tần xuất đạt được trong MAX I";
      this.diemtanxuat.Width = 130;
      this.diemGan.DataPropertyName = "diemGan";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle12.Font = new Font("Arial Narrow", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle12.ForeColor = Color.Red;
      this.diemGan.DefaultCellStyle = gridViewCellStyle12;
      this.diemGan.HeaderText = "Điểm gan";
      this.diemGan.Name = "diemGan";
      this.diemGan.ReadOnly = true;
      this.diemGan.ToolTipText = "Điểm gan đạt được trong MAX II";
      this.veNgay.DataPropertyName = "veNgay";
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle13.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle13.ForeColor = Color.Blue;
      this.veNgay.DefaultCellStyle = gridViewCellStyle13;
      this.veNgay.HeaderText = "Về ngày";
      this.veNgay.Name = "veNgay";
      this.veNgay.ReadOnly = true;
      this.veNgay.ToolTipText = "Ngày về của lô tô";
      this.colTrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.bgXuly.DoWork += new DoWorkEventHandler(this.bgXuly_DoWork);
      this.bgXuly.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgXuly_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.pnBot);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabChukygiaiDacBiet);
      this.Size = new Size(1100, 575);
      this.panel1.ResumeLayout(false);
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.numGan2namLon.EndInit();
      this.numGan2namNho.EndInit();
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.numDiemganLon.EndInit();
      this.numDiemganNho.EndInit();
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numSolanveLon.EndInit();
      this.numSolanveBe.EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.numTanxuatLon.EndInit();
      this.numTanxuatBe.EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.numGantrongkhungLon.EndInit();
      this.numGantrongkhungBe.EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.numNgaychuaraLon.EndInit();
      this.numNgaychuaraBe.EndInit();
      this.pnBot.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.ResumeLayout(false);
    }
  }
}
