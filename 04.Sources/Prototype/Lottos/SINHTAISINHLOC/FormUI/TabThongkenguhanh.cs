// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabThongkenguhanh
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabThongkenguhanh : UserControl
  {
    private IContainer components = (IContainer) null;
    private DataTable dataTable;
    private DataTable dtLoto;
    private DataRow _row;
    private Tbloto objloto;
    private string _vebongduong;
    private string _vebongam;
    private string _venguhanh;
    private string lobongduong;
    private string lobongam;
    private string longuhanh;
    private string lotoKetqua;
    private DataGridView dtg_Ketqua;
    private GroupBox groupBox6;
    private Button btnThongke;
    private DateTimePicker dtNgayXem;
    private Label label2;
    private BackgroundWorker backgroundWorker1;
    private Timer timer1;
    private PictureBox picLoading;
    private DataGridViewTextBoxColumn boso;
    private DataGridViewTextBoxColumn bongduong;
    private DataGridViewTextBoxColumn bongam;
    private DataGridViewTextBoxColumn songuhanh;
    private DataGridViewTextBoxColumn vebongduong;
    private DataGridViewTextBoxColumn vebongam;
    private DataGridViewTextBoxColumn venguhanh;
    private DataGridViewTextBoxColumn tongsolan;
    private DataGridViewTextBoxColumn vengay;
    private DataGridViewTextBoxColumn colTrong;

    public TabThongkenguhanh()
    {
      this.InitializeComponent();
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.objloto = new Tbloto();
    }

    private void KhoiTaoDataTable()
    {
      this.dataTable = new DataTable();
      this.dataTable.Columns.Add("boso", typeof (string));
      this.dataTable.Columns.Add("bongduong", typeof (string));
      this.dataTable.Columns.Add("bongam", typeof (string));
      this.dataTable.Columns.Add("songuhanh", typeof (string));
      this.dataTable.Columns.Add("vebongduong", typeof (string));
      this.dataTable.Columns.Add("vebongam", typeof (string));
      this.dataTable.Columns.Add("venguhanh", typeof (string));
      this.dataTable.Columns.Add("tongsolan", typeof (int));
      this.dataTable.Columns.Add("vengay", typeof (string));
      this.dataTable.Columns.Add("coltrong", typeof (string));
      for (int index = 0; index < 100; ++index)
      {
        string str = index.ToString();
        if (index < 10)
          str = "0" + index.ToString();
        if (str.Length == 2)
        {
          string dauso1 = str.Substring(0, 1);
          string dauso2 = str.Substring(1, 1);
          this._row = this.dataTable.NewRow();
          this._row["boso"] = (object) str;
          this._row["bongduong"] = (object) (Biendoiloto.BiendoiBongduong1Vitri(dauso1) + Biendoiloto.BiendoiBongduong1Vitri(dauso2));
          this._row["bongam"] = (object) (Biendoiloto.BiendoiBongAm1Vitri(dauso1) + Biendoiloto.BiendoiBongAm1Vitri(dauso2));
          this._row["songuhanh"] = (object) (Biendoiloto.BiendoiTuongSinh1Vitri(dauso1) + Biendoiloto.BiendoiTuongSinh1Vitri(dauso2));
          this._row["vebongduong"] = (object) "Không";
          this._row["vebongam"] = (object) "Không";
          this._row["venguhanh"] = (object) "Không";
          this._row["tongsolan"] = (object) "0";
          this._row["vengay"] = (object) "0";
          this._row["coltrong"] = (object) " ";
          this.dataTable.Rows.Add(this._row);
        }
      }
    }

    private void Process()
    {
      this.dtLoto = this.objloto.GetByDate(this.dtNgayXem.Value);
      if (this.dtLoto.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this.dataTable.Rows.Count; ++index1)
      {
        this._vebongduong = "Không";
        this._vebongam = "Không";
        this._venguhanh = "Không";
        this.lobongduong = this.dataTable.Rows[index1]["bongduong"].ToString();
        this.lobongam = this.dataTable.Rows[index1]["bongam"].ToString();
        this.longuhanh = this.dataTable.Rows[index1]["songuhanh"].ToString();
        for (int index2 = 2; index2 < this.dtLoto.Columns.Count; ++index2)
        {
          this.lotoKetqua = this.dtLoto.Rows[0][index2].ToString();
          if (this.lotoKetqua == this.lobongduong)
          {
            this._vebongduong = "Có";
            this.dataTable.Rows[index1]["vebongduong"] = (object) this._vebongduong;
            this.dataTable.Rows[index1]["tongsolan"] = (object) (Convert.ToInt32(this.dataTable.Rows[index1]["tongsolan"]) + 1);
          }
          if (this.lotoKetqua == this.lobongam)
          {
            this._vebongam = "Có";
            this.dataTable.Rows[index1]["vebongam"] = (object) this._vebongam;
            this.dataTable.Rows[index1]["tongsolan"] = (object) (Convert.ToInt32(this.dataTable.Rows[index1]["tongsolan"]) + 1);
          }
          if (this.lotoKetqua == this.longuhanh)
          {
            this._venguhanh = "Có";
            this.dataTable.Rows[index1]["venguhanh"] = (object) this._venguhanh;
            this.dataTable.Rows[index1]["tongsolan"] = (object) (Convert.ToInt32(this.dataTable.Rows[index1]["tongsolan"]) + 1);
          }
        }
      }
    }

    private void dtNgayXem_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtNgayXem.Value > FMain.NgayKetQuaMoiNhat)
        this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.KhoiTaoDataTable();
      this.Process();
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.dtg_Ketqua.DataSource = (object) this.dataTable;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.backgroundWorker1.IsBusy;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabThongkenguhanh));
      this.dtg_Ketqua = new DataGridView();
      this.boso = new DataGridViewTextBoxColumn();
      this.bongduong = new DataGridViewTextBoxColumn();
      this.bongam = new DataGridViewTextBoxColumn();
      this.songuhanh = new DataGridViewTextBoxColumn();
      this.vebongduong = new DataGridViewTextBoxColumn();
      this.vebongam = new DataGridViewTextBoxColumn();
      this.venguhanh = new DataGridViewTextBoxColumn();
      this.tongsolan = new DataGridViewTextBoxColumn();
      this.vengay = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.groupBox6 = new GroupBox();
      this.btnThongke = new Button();
      this.dtNgayXem = new DateTimePicker();
      this.label2 = new Label();
      this.backgroundWorker1 = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.picLoading = new PictureBox();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.groupBox6.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
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
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.boso, (DataGridViewColumn) this.bongduong, (DataGridViewColumn) this.bongam, (DataGridViewColumn) this.songuhanh, (DataGridViewColumn) this.vebongduong, (DataGridViewColumn) this.vebongam, (DataGridViewColumn) this.venguhanh, (DataGridViewColumn) this.tongsolan, (DataGridViewColumn) this.vengay, (DataGridViewColumn) this.colTrong);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.GridColor = Color.WhiteSmoke;
      this.dtg_Ketqua.Location = new Point(4, 47);
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
      this.dtg_Ketqua.Size = new Size(1091, 430);
      this.dtg_Ketqua.TabIndex = 5;
      this.boso.DataPropertyName = "boso";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle4.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.Red;
      this.boso.DefaultCellStyle = gridViewCellStyle4;
      this.boso.HeaderText = "Bộ số";
      this.boso.Name = "boso";
      this.boso.ReadOnly = true;
      this.boso.Width = 60;
      this.bongduong.DataPropertyName = "bongduong";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bongduong.DefaultCellStyle = gridViewCellStyle5;
      this.bongduong.HeaderText = "Bóng dương";
      this.bongduong.Name = "bongduong";
      this.bongduong.ReadOnly = true;
      this.bongduong.ToolTipText = "Bóng dương của đầu số";
      this.bongduong.Width = 85;
      this.bongam.DataPropertyName = "bongam";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bongam.DefaultCellStyle = gridViewCellStyle6;
      this.bongam.HeaderText = "Bóng âm";
      this.bongam.Name = "bongam";
      this.bongam.ReadOnly = true;
      this.bongam.ToolTipText = "Bóng âm của đầu số";
      this.bongam.Width = 80;
      this.songuhanh.DataPropertyName = "songuhanh";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle7.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.songuhanh.DefaultCellStyle = gridViewCellStyle7;
      this.songuhanh.HeaderText = "Ngũ hành";
      this.songuhanh.Name = "songuhanh";
      this.songuhanh.ReadOnly = true;
      this.songuhanh.ToolTipText = "Số tương sinh tương khắc của đầu số";
      this.songuhanh.Width = 80;
      this.vebongduong.DataPropertyName = "vebongduong";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.vebongduong.DefaultCellStyle = gridViewCellStyle8;
      this.vebongduong.HeaderText = "Về (bóng dương)";
      this.vebongduong.Name = "vebongduong";
      this.vebongduong.ReadOnly = true;
      this.vebongduong.ToolTipText = "Số lần xuất hiện của đầu số trong tất cả các vị trí";
      this.vebongduong.Width = 110;
      this.vebongam.DataPropertyName = "vebongam";
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.vebongam.DefaultCellStyle = gridViewCellStyle9;
      this.vebongam.HeaderText = "Về (bóng âm)";
      this.vebongam.Name = "vebongam";
      this.vebongam.ReadOnly = true;
      this.vebongam.ToolTipText = "Số lần xuất hiện của đầu số trong 2 số cuối của các giải";
      this.vebongam.Width = 110;
      this.venguhanh.DataPropertyName = "venguhanh";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.venguhanh.DefaultCellStyle = gridViewCellStyle10;
      this.venguhanh.HeaderText = "Về (ngũ hành)";
      this.venguhanh.Name = "venguhanh";
      this.venguhanh.ReadOnly = true;
      this.tongsolan.DataPropertyName = "tongsolan";
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle11.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle11.ForeColor = Color.Red;
      this.tongsolan.DefaultCellStyle = gridViewCellStyle11;
      this.tongsolan.HeaderText = "Tổng số lần";
      this.tongsolan.Name = "tongsolan";
      this.tongsolan.ReadOnly = true;
      this.tongsolan.ToolTipText = "Xuất hiện trong giải đặc biệt";
      this.tongsolan.Width = 85;
      this.vengay.DataPropertyName = "vengay";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle12.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle12.ForeColor = Color.Red;
      this.vengay.DefaultCellStyle = gridViewCellStyle12;
      this.vengay.HeaderText = "Về ngày";
      this.vengay.Name = "vengay";
      this.vengay.ReadOnly = true;
      this.colTrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox6.Controls.Add((Control) this.btnThongke);
      this.groupBox6.Controls.Add((Control) this.dtNgayXem);
      this.groupBox6.Controls.Add((Control) this.label2);
      this.groupBox6.Location = new Point(5, 0);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(1090, 45);
      this.groupBox6.TabIndex = 4;
      this.groupBox6.TabStop = false;
      this.btnThongke.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(197, 13);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(877, 24);
      this.btnThongke.TabIndex = 7;
      this.btnThongke.Text = "Thống Kê";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.dtNgayXem.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.CalendarForeColor = Color.Red;
      this.dtNgayXem.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayXem.CustomFormat = "dd/MM/yyyy";
      this.dtNgayXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.Format = DateTimePickerFormat.Custom;
      this.dtNgayXem.Location = new Point(69, 15);
      this.dtNgayXem.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayXem.Name = "dtNgayXem";
      this.dtNgayXem.Size = new Size(122, 21);
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
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(525, 285);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 63;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.dtg_Ketqua);
      this.Controls.Add((Control) this.groupBox6);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabThongkenguhanh);
      this.Size = new Size(1100, 478);
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
