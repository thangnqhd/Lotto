// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabThongkedauso
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

namespace Thống_kê_xổ_số.FormUI
{
  public class TabThongkedauso : UserControl
  {
    private IContainer components = (IContainer) null;
    private TbVitri objVitri;
    private Tbloto objLoto;
    private DataTable dtKetqua;
    private DataTable dtVitri;
    private DataTable dtLoto;
    private BunifuElipse bunifuElipse1;
    private GroupBox groupBox6;
    private Button btnThongke;
    private DateTimePicker dtNgayXem;
    private Label label2;
    private BackgroundWorker bgXuly;
    private DataGridView dtg_Ketqua;
    private ToolTip toolTip1;
    private PictureBox picLoading;
    private Timer timer1;
    private DataGridViewTextBoxColumn dauso;
    private DataGridViewTextBoxColumn bongduong;
    private DataGridViewTextBoxColumn bongam;
    private DataGridViewTextBoxColumn tuongsinh;
    private DataGridViewTextBoxColumn nguhanh;
    private DataGridViewTextBoxColumn longso8;
    private DataGridViewTextBoxColumn longso9;
    private DataGridViewTextBoxColumn tatcavitri;
    private DataGridViewTextBoxColumn haisocuoi;
    private DataGridViewTextBoxColumn tongsolan;
    private DataGridViewTextBoxColumn colTrong;

    public TabThongkedauso()
    {
      this.InitializeComponent();
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.objVitri = new TbVitri();
      this.objLoto = new Tbloto();
    }

    private void CreateDataTable()
    {
      this.dtKetqua = new DataTable();
      this.dtKetqua.Columns.Add("dauso", typeof (string));
      this.dtKetqua.Columns.Add("bongduong", typeof (int));
      this.dtKetqua.Columns.Add("bongam", typeof (int));
      this.dtKetqua.Columns.Add("tuongsinh", typeof (int));
      this.dtKetqua.Columns.Add("longso8", typeof (int));
      this.dtKetqua.Columns.Add("longso9", typeof (int));
      this.dtKetqua.Columns.Add("tatcavitri", typeof (int));
      this.dtKetqua.Columns.Add("haisocuoi", typeof (int));
      this.dtKetqua.Columns.Add("tongsolan", typeof (int));
      this.dtKetqua.Columns.Add("colTrong", typeof (string));
      for (int index = 0; index < 10; ++index)
      {
        string dauso = index.ToString();
        string str = Biendoiloto.BiendoiTuongSinh1Vitri(dauso);
        DataRow row = this.dtKetqua.NewRow();
        row["dauso"] = (object) dauso;
        row["bongduong"] = (object) Biendoiloto.BiendoiBongduong1Vitri(dauso);
        row["bongam"] = (object) Biendoiloto.BiendoiBongAm1Vitri(dauso);
        row["tuongsinh"] = (object) str;
        row["longso8"] = (object) 0;
        row["longso9"] = (object) 0;
        row["tatcavitri"] = (object) 0;
        row["haisocuoi"] = (object) 0;
        row["tongsolan"] = (object) 0;
        row["colTrong"] = (object) " ";
        this.dtKetqua.Rows.Add(row);
      }
    }

    private void dtNgayXem_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtNgayXem.Value > FMain.NgayKetQuaMoiNhat)
        this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      this.btnThongke.PerformClick();
    }

    private void Processing()
    {
      try
      {
        this.dtVitri = this.objVitri.GetByDay(this.dtNgayXem.Value);
        this.dtLoto = this.objLoto.GetByDate(this.dtNgayXem.Value);
        if (this.dtVitri.Rows.Count > 0 && this.dtLoto.Rows.Count > 0)
        {
          for (int index1 = 2; index1 < this.dtVitri.Columns.Count; ++index1)
          {
            string str1 = this.dtVitri.Rows[0][index1].ToString();
            for (int index2 = 0; index2 < this.dtKetqua.Rows.Count; ++index2)
            {
              string str2 = this.dtKetqua.Rows[index2]["dauso"].ToString();
              if (str1 == str2)
                this.dtKetqua.Rows[index2]["tatcavitri"] = (object) (Convert.ToInt32(this.dtKetqua.Rows[index2]["tatcavitri"]) + 1);
            }
          }
          for (int index1 = 1; index1 < this.dtLoto.Columns.Count; ++index1)
          {
            char[] charArray = this.dtLoto.Rows[0][index1].ToString().ToCharArray();
            if ((uint) charArray.Length > 0U)
            {
              for (int index2 = 0; index2 < charArray.Length; ++index2)
              {
                for (int index3 = 0; index3 < this.dtKetqua.Rows.Count; ++index3)
                {
                  string str = this.dtKetqua.Rows[index3]["dauso"].ToString();
                  if (charArray[index2].ToString() == str)
                    this.dtKetqua.Rows[index3]["haisocuoi"] = (object) (Convert.ToInt32(this.dtKetqua.Rows[index3]["haisocuoi"]) + 1);
                }
              }
            }
          }
          for (int index1 = 1; index1 < this.dtLoto.Columns.Count; ++index1)
          {
            char[] charArray = this.dtLoto.Rows[0][index1].ToString().ToCharArray();
            if ((uint) charArray.Length > 0U)
            {
              for (int index2 = 0; index2 < this.dtKetqua.Rows.Count; ++index2)
              {
                string str = this.dtKetqua.Rows[index2]["dauso"].ToString();
                if (charArray[0].ToString() == str)
                  this.dtKetqua.Rows[index2]["longso8"] = (object) (Convert.ToInt32(this.dtKetqua.Rows[index2]["longso8"]) + 1);
                if (charArray[1].ToString() == str)
                  this.dtKetqua.Rows[index2]["longso9"] = (object) (Convert.ToInt32(this.dtKetqua.Rows[index2]["longso9"]) + 1);
              }
            }
          }
          for (int index = 0; index < this.dtKetqua.Rows.Count; ++index)
            this.dtKetqua.Rows[index]["tongsolan"] = (object) (Convert.ToInt32(this.dtKetqua.Rows[index]["tatcavitri"].ToString()) + Convert.ToInt32(this.dtKetqua.Rows[index]["haisocuoi"].ToString()));
        }
        else
        {
          int num = (int) MessageBox.Show("Không có dữ liệu kiểm tra cho ngày hôm nay, nó có thể là một ngày nghỉ tết. Vui lòng kiểm tra ngày khác !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.dtNgayXem.Focus();
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      this.CreateDataTable();
      if (this.bgXuly.IsBusy)
        return;
      this.bgXuly.RunWorkerAsync();
    }

    private void ProSuccess()
    {
      if (this.dtKetqua.Rows.Count <= 0)
        return;
      this.dtg_Ketqua.DataSource = (object) this.dtKetqua;
    }

    private void bgXuly_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.ProSuccess();
    }

    private void bgXuly_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Processing();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.bgXuly.IsBusy;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabThongkedauso));
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.groupBox6 = new GroupBox();
      this.btnThongke = new Button();
      this.dtNgayXem = new DateTimePicker();
      this.label2 = new Label();
      this.bgXuly = new BackgroundWorker();
      this.dtg_Ketqua = new DataGridView();
      this.toolTip1 = new ToolTip(this.components);
      this.picLoading = new PictureBox();
      this.timer1 = new Timer(this.components);
      this.dauso = new DataGridViewTextBoxColumn();
      this.bongduong = new DataGridViewTextBoxColumn();
      this.bongam = new DataGridViewTextBoxColumn();
      this.tuongsinh = new DataGridViewTextBoxColumn();
      this.nguhanh = new DataGridViewTextBoxColumn();
      this.longso8 = new DataGridViewTextBoxColumn();
      this.longso9 = new DataGridViewTextBoxColumn();
      this.tatcavitri = new DataGridViewTextBoxColumn();
      this.haisocuoi = new DataGridViewTextBoxColumn();
      this.tongsolan = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.groupBox6.SuspendLayout();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox6.Controls.Add((Control) this.btnThongke);
      this.groupBox6.Controls.Add((Control) this.dtNgayXem);
      this.groupBox6.Controls.Add((Control) this.label2);
      this.groupBox6.Location = new Point(5, 0);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(1090, 45);
      this.groupBox6.TabIndex = 2;
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
      this.toolTip1.SetToolTip((Control) this.btnThongke, "Nhấn để thống kê");
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
      this.toolTip1.SetToolTip((Control) this.dtNgayXem, "Ngày tháng kiểm tra");
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
      this.bgXuly.DoWork += new DoWorkEventHandler(this.bgXuly_DoWork);
      this.bgXuly.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgXuly_RunWorkerCompleted);
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
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.dauso, (DataGridViewColumn) this.bongduong, (DataGridViewColumn) this.bongam, (DataGridViewColumn) this.tuongsinh, (DataGridViewColumn) this.nguhanh, (DataGridViewColumn) this.longso8, (DataGridViewColumn) this.longso9, (DataGridViewColumn) this.tatcavitri, (DataGridViewColumn) this.haisocuoi, (DataGridViewColumn) this.tongsolan, (DataGridViewColumn) this.colTrong);
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
      this.dtg_Ketqua.TabIndex = 3;
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(535, 363);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 62;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.dauso.DataPropertyName = "dauso";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle4.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.Red;
      this.dauso.DefaultCellStyle = gridViewCellStyle4;
      this.dauso.HeaderText = "Đầu số";
      this.dauso.Name = "dauso";
      this.dauso.ReadOnly = true;
      this.dauso.ToolTipText = "Đầu số xuất hiện";
      this.dauso.Width = 70;
      this.bongduong.DataPropertyName = "bongduong";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.bongduong.DefaultCellStyle = gridViewCellStyle5;
      this.bongduong.HeaderText = "Bóng dương";
      this.bongduong.Name = "bongduong";
      this.bongduong.ReadOnly = true;
      this.bongduong.ToolTipText = "Bóng dương của đầu số";
      this.bongduong.Width = 85;
      this.bongam.DataPropertyName = "bongam";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle6.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.bongam.DefaultCellStyle = gridViewCellStyle6;
      this.bongam.HeaderText = "Bóng âm";
      this.bongam.Name = "bongam";
      this.bongam.ReadOnly = true;
      this.bongam.ToolTipText = "Bóng âm của đầu số";
      this.bongam.Width = 80;
      this.tuongsinh.DataPropertyName = "tuongsinh";
      this.tuongsinh.HeaderText = "Ngũ hành";
      this.tuongsinh.Name = "tuongsinh";
      this.tuongsinh.ReadOnly = true;
      this.tuongsinh.ToolTipText = "Số tương sinh tương khắc của đầu số";
      this.tuongsinh.Width = 80;
      this.nguhanh.DataPropertyName = "nguhanh";
      this.nguhanh.HeaderText = "Ngũ hành";
      this.nguhanh.Name = "nguhanh";
      this.nguhanh.ReadOnly = true;
      this.nguhanh.ToolTipText = "Thông tin ngũ hành đầu số và tương sinh";
      this.nguhanh.Visible = false;
      this.nguhanh.Width = 120;
      this.longso8.DataPropertyName = "longso8";
      this.longso8.HeaderText = "Hàng chục";
      this.longso8.Name = "longso8";
      this.longso8.ReadOnly = true;
      this.longso8.Width = 80;
      this.longso9.DataPropertyName = "longso9";
      this.longso9.HeaderText = "Hàng đơn vị";
      this.longso9.Name = "longso9";
      this.longso9.ReadOnly = true;
      this.longso9.Width = 80;
      this.tatcavitri.DataPropertyName = "tatcavitri";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle7.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle7.ForeColor = Color.Red;
      this.tatcavitri.DefaultCellStyle = gridViewCellStyle7;
      this.tatcavitri.HeaderText = "Tất cả vị trí (lần)";
      this.tatcavitri.Name = "tatcavitri";
      this.tatcavitri.ReadOnly = true;
      this.tatcavitri.ToolTipText = "Số lần xuất hiện của đầu số trong tất cả các vị trí";
      this.tatcavitri.Width = 110;
      this.haisocuoi.DataPropertyName = "haisocuoi";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle8.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      gridViewCellStyle8.ForeColor = Color.Red;
      this.haisocuoi.DefaultCellStyle = gridViewCellStyle8;
      this.haisocuoi.HeaderText = "Hai số cuối (lần)";
      this.haisocuoi.Name = "haisocuoi";
      this.haisocuoi.ReadOnly = true;
      this.haisocuoi.ToolTipText = "Số lần xuất hiện của đầu số trong 2 số cuối của các giải";
      this.haisocuoi.Width = 110;
      this.tongsolan.DataPropertyName = "tongsolan";
      this.tongsolan.HeaderText = "Tổng số lần";
      this.tongsolan.Name = "tongsolan";
      this.tongsolan.ReadOnly = true;
      this.colTrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.dtg_Ketqua);
      this.Controls.Add((Control) this.groupBox6);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabThongkedauso);
      this.Size = new Size(1100, 478);
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
