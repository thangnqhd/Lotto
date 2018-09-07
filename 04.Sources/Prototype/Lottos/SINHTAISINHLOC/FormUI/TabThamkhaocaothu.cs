// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabThamkhaocaothu
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
  public class TabThamkhaocaothu : UserControl
  {
    private int _hinhthucchoi = 0;
    private DateTime ngayKiemTraCu = DateTime.Now.AddDays(-120.0);
    private IContainer components = (IContainer) null;
    private TbDuDoanLoTo objDuDoanLoTo;
    private DataTable dtDuDoan;
    private FDudoanketqua fDudoanketqua;
    private BunifuElipse bunifuElipse1;
    private Panel pnBot;
    private Panel pnTop;
    private GroupBox groupBox1;
    private DataGridView dtg_Ketqua;
    private RadioButton rdLotruot;
    private RadioButton rdDacbiet;
    private RadioButton rdLoxien;
    private Label label3;
    private Label label2;
    private Button btnXem;
    private Button button1;
    private RadioButton rdLoto;
    private RadioButton rdAll;
    private Label label13;
    private DateTimePicker dtNgayXem;
    private BackgroundWorker bgXuLy;
    private ToolTip toolTip1;
    private DataGridViewTextBoxColumn sttID;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn userName;
    private DataGridViewTextBoxColumn tieuDe;
    private DataGridViewTextBoxColumn boSo;
    private DataGridViewTextBoxColumn soTienDanh;
    private DataGridViewTextBoxColumn loiNhuanDauTu;
    private DataGridViewTextBoxColumn hinhThucDuDoan;
    private DataGridViewTextBoxColumn luotxem;
    private DataGridViewTextBoxColumn luotBinhLuan;
    private DataGridViewTextBoxColumn thoiGianDuDoan;
    private DataGridViewTextBoxColumn colTrong;

    public TabThamkhaocaothu()
    {
      this.InitializeComponent();
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      this.objDuDoanLoTo = new TbDuDoanLoTo();
      this.btnXem.PerformClick();
    }

    private void GetData()
    {
      if (!(this.ngayKiemTraCu != this.dtNgayXem.Value))
        return;
      this.ngayKiemTraCu = this.dtNgayXem.Value;
      this.dtDuDoan = this.objDuDoanLoTo.GetByDate(this.ngayKiemTraCu);
    }

    private void rdAll_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton) sender;
      if (radioButton.Checked)
      {
        radioButton.ForeColor = Color.Red;
        radioButton.Font = new Font("Arial", 9f, FontStyle.Bold);
      }
      else
      {
        radioButton.ForeColor = Color.Black;
        radioButton.Font = new Font("Arial", 9f, FontStyle.Regular);
      }
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (this.bgXuLy.IsBusy)
        return;
      this.bgXuLy.RunWorkerAsync();
    }

    private void bgXuLy_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetData();
    }

    private void bgXuLy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.dtg_Ketqua.DataSource = (object) this.dtDuDoan;
    }

    private void dtNgayXem_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayXem.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.rdAll.Checked)
        this._hinhthucchoi = 0;
      if (this.rdLoto.Checked)
        this._hinhthucchoi = 0;
      if (this.rdDacbiet.Checked)
        this._hinhthucchoi = 1;
      if (this.rdLoxien.Checked)
        this._hinhthucchoi = 2;
      if (this.rdLotruot.Checked)
        this._hinhthucchoi = 5;
      this.fDudoanketqua = new FDudoanketqua(this._hinhthucchoi);
      int num = (int) this.fDudoanketqua.ShowDialog();
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
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.pnTop = new Panel();
      this.groupBox1 = new GroupBox();
      this.label13 = new Label();
      this.dtNgayXem = new DateTimePicker();
      this.rdLoto = new RadioButton();
      this.rdAll = new RadioButton();
      this.button1 = new Button();
      this.rdLotruot = new RadioButton();
      this.rdDacbiet = new RadioButton();
      this.rdLoxien = new RadioButton();
      this.label3 = new Label();
      this.label2 = new Label();
      this.btnXem = new Button();
      this.pnBot = new Panel();
      this.dtg_Ketqua = new DataGridView();
      this.sttID = new DataGridViewTextBoxColumn();
      this.stt = new DataGridViewTextBoxColumn();
      this.userName = new DataGridViewTextBoxColumn();
      this.tieuDe = new DataGridViewTextBoxColumn();
      this.boSo = new DataGridViewTextBoxColumn();
      this.soTienDanh = new DataGridViewTextBoxColumn();
      this.loiNhuanDauTu = new DataGridViewTextBoxColumn();
      this.hinhThucDuDoan = new DataGridViewTextBoxColumn();
      this.luotxem = new DataGridViewTextBoxColumn();
      this.luotBinhLuan = new DataGridViewTextBoxColumn();
      this.thoiGianDuDoan = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.bgXuLy = new BackgroundWorker();
      this.toolTip1 = new ToolTip(this.components);
      this.pnTop.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.pnBot.SuspendLayout();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.pnTop.Controls.Add((Control) this.groupBox1);
      this.pnTop.Dock = DockStyle.Top;
      this.pnTop.Location = new Point(0, 0);
      this.pnTop.Name = "pnTop";
      this.pnTop.Size = new Size(1100, 40);
      this.pnTop.TabIndex = 0;
      this.groupBox1.Controls.Add((Control) this.label13);
      this.groupBox1.Controls.Add((Control) this.dtNgayXem);
      this.groupBox1.Controls.Add((Control) this.rdLoto);
      this.groupBox1.Controls.Add((Control) this.rdAll);
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.rdLotruot);
      this.groupBox1.Controls.Add((Control) this.rdDacbiet);
      this.groupBox1.Controls.Add((Control) this.rdLoxien);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.btnXem);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1100, 40);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.Black;
      this.label13.Location = new Point(9, 13);
      this.label13.Name = "label13";
      this.label13.Size = new Size(188, 17);
      this.label13.TabIndex = 42;
      this.label13.Text = "Những người dự đoán ngày";
      this.dtNgayXem.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.CalendarForeColor = Color.Red;
      this.dtNgayXem.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayXem.CustomFormat = "dd/MM/yyyy";
      this.dtNgayXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.Format = DateTimePickerFormat.Custom;
      this.dtNgayXem.Location = new Point(200, 13);
      this.dtNgayXem.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayXem.Name = "dtNgayXem";
      this.dtNgayXem.Size = new Size(103, 21);
      this.dtNgayXem.TabIndex = 41;
      this.toolTip1.SetToolTip((Control) this.dtNgayXem, "Ngày muốn xem dự đoán của các thành viên");
      this.dtNgayXem.ValueChanged += new EventHandler(this.dtNgayXem_ValueChanged);
      this.rdLoto.AutoSize = true;
      this.rdLoto.Cursor = Cursors.Hand;
      this.rdLoto.FlatStyle = FlatStyle.Flat;
      this.rdLoto.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdLoto.ForeColor = Color.Black;
      this.rdLoto.Location = new Point(448, 14);
      this.rdLoto.Name = "rdLoto";
      this.rdLoto.Size = new Size(48, 19);
      this.rdLoto.TabIndex = 40;
      this.rdLoto.Text = "Loto";
      this.toolTip1.SetToolTip((Control) this.rdLoto, "Xem tất cả những bộ số được dự đoán về lô hôm nay");
      this.rdLoto.UseVisualStyleBackColor = true;
      this.rdLoto.CheckedChanged += new EventHandler(this.rdAll_CheckedChanged);
      this.rdAll.AutoSize = true;
      this.rdAll.Checked = true;
      this.rdAll.Cursor = Cursors.Hand;
      this.rdAll.FlatStyle = FlatStyle.Flat;
      this.rdAll.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.rdAll.ForeColor = Color.Red;
      this.rdAll.Location = new Point(376, 14);
      this.rdAll.Name = "rdAll";
      this.rdAll.Size = new Size(59, 19);
      this.rdAll.TabIndex = 39;
      this.rdAll.TabStop = true;
      this.rdAll.Text = "Tất cả";
      this.toolTip1.SetToolTip((Control) this.rdAll, "Xem tất cả những bộ số được dự đoán hôm nay");
      this.rdAll.UseVisualStyleBackColor = true;
      this.rdAll.CheckedChanged += new EventHandler(this.rdAll_CheckedChanged);
      this.button1.BackColor = Color.Teal;
      this.button1.Cursor = Cursors.Hand;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.White;
      this.button1.Location = new Point(878, 11);
      this.button1.Margin = new Padding(3, 0, 3, 0);
      this.button1.Name = "button1";
      this.button1.Size = new Size(167, 24);
      this.button1.TabIndex = 38;
      this.button1.Text = "DỰ ĐOÁN NGAY";
      this.button1.TextAlign = ContentAlignment.TopCenter;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.rdLotruot.AutoSize = true;
      this.rdLotruot.Cursor = Cursors.Hand;
      this.rdLotruot.FlatStyle = FlatStyle.Flat;
      this.rdLotruot.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdLotruot.ForeColor = Color.Black;
      this.rdLotruot.Location = new Point(667, 14);
      this.rdLotruot.Name = "rdLotruot";
      this.rdLotruot.Size = new Size(67, 19);
      this.rdLotruot.TabIndex = 37;
      this.rdLotruot.Text = "Lô trượt";
      this.toolTip1.SetToolTip((Control) this.rdLotruot, "Xem tất cả những bộ số được dự đoán không về hôm nay (lô trượt)");
      this.rdLotruot.UseVisualStyleBackColor = true;
      this.rdLotruot.CheckedChanged += new EventHandler(this.rdAll_CheckedChanged);
      this.rdDacbiet.AutoSize = true;
      this.rdDacbiet.Cursor = Cursors.Hand;
      this.rdDacbiet.FlatStyle = FlatStyle.Flat;
      this.rdDacbiet.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdDacbiet.ForeColor = Color.Black;
      this.rdDacbiet.Location = new Point(509, 14);
      this.rdDacbiet.Name = "rdDacbiet";
      this.rdDacbiet.Size = new Size(69, 19);
      this.rdDacbiet.TabIndex = 36;
      this.rdDacbiet.Text = "Đặc biệt";
      this.toolTip1.SetToolTip((Control) this.rdDacbiet, "Xem tất cả những bộ sô được dự đoán về đặc biệt hôm nay");
      this.rdDacbiet.UseVisualStyleBackColor = true;
      this.rdDacbiet.CheckedChanged += new EventHandler(this.rdAll_CheckedChanged);
      this.rdLoxien.AutoSize = true;
      this.rdLoxien.Cursor = Cursors.Hand;
      this.rdLoxien.FlatStyle = FlatStyle.Flat;
      this.rdLoxien.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdLoxien.ForeColor = Color.Black;
      this.rdLoxien.Location = new Point(591, 14);
      this.rdLoxien.Name = "rdLoxien";
      this.rdLoxien.Size = new Size(63, 19);
      this.rdLoxien.TabIndex = 35;
      this.rdLoxien.Text = "Lô xiên";
      this.toolTip1.SetToolTip((Control) this.rdLoxien, "Xem tất cả những bộ số được dự đoán về cùng nhau hôm nay (lô xiên)");
      this.rdLoxien.UseVisualStyleBackColor = true;
      this.rdLoxien.CheckedChanged += new EventHandler(this.rdAll_CheckedChanged);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(741, 13);
      this.label3.Name = "label3";
      this.label3.Size = new Size(12, 18);
      this.label3.TabIndex = 32;
      this.label3.Text = "]";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(356, 13);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 18);
      this.label2.TabIndex = 31;
      this.label2.Text = "[";
      this.btnXem.BackColor = Color.Yellow;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.Red;
      this.btnXem.Location = new Point(805, 12);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(72, 22);
      this.btnXem.TabIndex = 30;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnXem, "Xem kết quả dự đoán");
      this.btnXem.UseVisualStyleBackColor = false;
      this.btnXem.Click += new EventHandler(this.btnXem_Click);
      this.pnBot.Controls.Add((Control) this.dtg_Ketqua);
      this.pnBot.Dock = DockStyle.Fill;
      this.pnBot.Location = new Point(0, 40);
      this.pnBot.Name = "pnBot";
      this.pnBot.Size = new Size(1100, 550);
      this.pnBot.TabIndex = 1;
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToOrderColumns = true;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.BackgroundColor = Color.White;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
      gridViewCellStyle1.NullValue = (object) "#####";
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 26;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.sttID, (DataGridViewColumn) this.stt, (DataGridViewColumn) this.userName, (DataGridViewColumn) this.tieuDe, (DataGridViewColumn) this.boSo, (DataGridViewColumn) this.soTienDanh, (DataGridViewColumn) this.loiNhuanDauTu, (DataGridViewColumn) this.hinhThucDuDoan, (DataGridViewColumn) this.luotxem, (DataGridViewColumn) this.luotBinhLuan, (DataGridViewColumn) this.thoiGianDuDoan, (DataGridViewColumn) this.colTrong);
      this.dtg_Ketqua.Cursor = Cursors.Hand;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle2.ForeColor = Color.Black;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.Dock = DockStyle.Fill;
      this.dtg_Ketqua.Location = new Point(0, 0);
      this.dtg_Ketqua.Margin = new Padding(0);
      this.dtg_Ketqua.MultiSelect = false;
      this.dtg_Ketqua.Name = "dtg_Ketqua";
      this.dtg_Ketqua.ReadOnly = true;
      this.dtg_Ketqua.RowHeadersVisible = false;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtg_Ketqua.RowTemplate.Height = 32;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(1100, 550);
      this.dtg_Ketqua.TabIndex = 1;
      this.sttID.DataPropertyName = "sttID";
      this.sttID.HeaderText = "stt";
      this.sttID.Name = "sttID";
      this.sttID.ReadOnly = true;
      this.sttID.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.sttID.Visible = false;
      this.stt.DataPropertyName = "stt";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle3.ForeColor = Color.DimGray;
      this.stt.DefaultCellStyle = gridViewCellStyle3;
      this.stt.HeaderText = "STT ";
      this.stt.Name = "stt";
      this.stt.ReadOnly = true;
      this.stt.ToolTipText = "Số thứ tự";
      this.stt.Width = 40;
      this.userName.DataPropertyName = "userName";
      gridViewCellStyle4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.Red;
      this.userName.DefaultCellStyle = gridViewCellStyle4;
      this.userName.HeaderText = "Người chốt";
      this.userName.Name = "userName";
      this.userName.ReadOnly = true;
      this.userName.ToolTipText = "Người dự đoán bộ số này";
      this.userName.Width = 90;
      this.tieuDe.DataPropertyName = "tieuDe";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle5.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = Color.Red;
      this.tieuDe.DefaultCellStyle = gridViewCellStyle5;
      this.tieuDe.HeaderText = "Tiêu đề";
      this.tieuDe.Name = "tieuDe";
      this.tieuDe.ReadOnly = true;
      this.tieuDe.ToolTipText = "Tiêu đề chốt số";
      this.tieuDe.Width = 180;
      this.boSo.DataPropertyName = "boSo";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle6.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle6.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle6.ForeColor = Color.Black;
      this.boSo.DefaultCellStyle = gridViewCellStyle6;
      this.boSo.HeaderText = "Bộ số";
      this.boSo.Name = "boSo";
      this.boSo.ReadOnly = true;
      this.boSo.ToolTipText = "Bộ số đã chốt";
      this.boSo.Width = 130;
      this.soTienDanh.DataPropertyName = "soTienDanh";
      this.soTienDanh.HeaderText = "Tổng vốn (bạc)";
      this.soTienDanh.Name = "soTienDanh";
      this.soTienDanh.ReadOnly = true;
      this.soTienDanh.ToolTipText = "Số tiền đã ghi cho bộ số này";
      this.loiNhuanDauTu.DataPropertyName = "loiNhuanDauTu";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle7.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = Color.Red;
      this.loiNhuanDauTu.DefaultCellStyle = gridViewCellStyle7;
      this.loiNhuanDauTu.HeaderText = "Lợi nhuận (%)";
      this.loiNhuanDauTu.Name = "loiNhuanDauTu";
      this.loiNhuanDauTu.ReadOnly = true;
      this.loiNhuanDauTu.ToolTipText = "Tỷ lệ lợi nhuận trên số vốn đầu tư của người chơi trong tuần này";
      this.hinhThucDuDoan.DataPropertyName = "hinhThucDuDoan";
      this.hinhThucDuDoan.HeaderText = "Hình thức";
      this.hinhThucDuDoan.Name = "hinhThucDuDoan";
      this.hinhThucDuDoan.ReadOnly = true;
      this.hinhThucDuDoan.ToolTipText = "Hình thức đánh của bộ số";
      this.hinhThucDuDoan.Width = 120;
      this.luotxem.DataPropertyName = "luotXem";
      this.luotxem.HeaderText = "Lượt xem";
      this.luotxem.Name = "luotxem";
      this.luotxem.ReadOnly = true;
      this.luotxem.ToolTipText = "Số lượt người xem click vào bài chốt số";
      this.luotxem.Width = 70;
      this.luotBinhLuan.DataPropertyName = "luotBinhLuan";
      this.luotBinhLuan.HeaderText = "Bình luận";
      this.luotBinhLuan.Name = "luotBinhLuan";
      this.luotBinhLuan.ReadOnly = true;
      this.luotBinhLuan.ToolTipText = "Số lượng người bình luận trong bài chốt";
      this.luotBinhLuan.Width = 70;
      this.thoiGianDuDoan.DataPropertyName = "thoiGianDuDoan";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle8.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle8.ForeColor = Color.Red;
      this.thoiGianDuDoan.DefaultCellStyle = gridViewCellStyle8;
      this.thoiGianDuDoan.HeaderText = "Thời gian";
      this.thoiGianDuDoan.Name = "thoiGianDuDoan";
      this.thoiGianDuDoan.ReadOnly = true;
      this.thoiGianDuDoan.ToolTipText = "Thời gian chốt số của người chơi";
      this.thoiGianDuDoan.Width = 145;
      this.colTrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.colTrong.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.bgXuLy.DoWork += new DoWorkEventHandler(this.bgXuLy_DoWork);
      this.bgXuLy.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgXuLy_RunWorkerCompleted);
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.pnBot);
      this.Controls.Add((Control) this.pnTop);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabThamkhaocaothu);
      this.Size = new Size(1100, 590);
      this.pnTop.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.pnBot.ResumeLayout(false);
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.ResumeLayout(false);
    }
  }
}
