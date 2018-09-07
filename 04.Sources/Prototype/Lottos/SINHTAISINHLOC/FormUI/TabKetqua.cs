// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabKetqua
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
  public class TabKetqua : UserControl
  {
    private int cbbThuDai = 0;
    private IContainer components = (IContainer) null;
    public DataTable DT;
    private Tbketqua _obj;
    private string strHTML;
    private BunifuElipse bunifuElipse1;
    private WebBrowser web_Brow_Ketqua;
    private Panel panel1;
    private Label label1;
    private Button btnXem;
    private DateTimePicker dt_tu_ngay;
    private Label label6;
    private ComboBox cbb_Thu_Dai;
    private DateTimePicker dt_den_ngay;
    private Label label9;
    private Label label10;
    private BackgroundWorker backgroundWorker1;
    private Timer timer1;
    private PictureBox picLoading;

    public TabKetqua()
    {
      this.InitializeComponent();
      Tbketqua.AddGiaTriCbbThu(this.cbb_Thu_Dai);
      this.cbb_Thu_Dai.SelectedIndex = 0;
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.dt_den_ngay.Value = FMain.NgayKetQuaMoiNhat;
      this.dt_tu_ngay.Value = FMain.NgayKetQuaMoiNhat.AddDays(-45.0);
      this.web_Brow_Ketqua.IsWebBrowserContextMenuEnabled = false;
      this.web_Brow_Ketqua.AllowWebBrowserDrop = false;
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void ShowKq(DateTime tuNgay, DateTime denNgay)
    {
      this.strHTML = "";
      if (this.dt_den_ngay.Value.Subtract(this.dt_tu_ngay.Value).Days > 365)
      {
        int num = (int) MessageBox.Show(Resources.tabKetqua_show_Khoảng_Thời_Gian_Tìm_Kiếm_Tối_Đa_60_Ngày);
      }
      else
        this.strHTML = this.DoDulieuRaHtml(tuNgay, denNgay);
    }

    public string DoDulieuRaHtml(DateTime tuNgay, DateTime denNgay)
    {
      string str = "";
      this.DT = new DataTable();
      this.DT = Tbketqua.GetTbketquaNgayThangThu(tuNgay, denNgay, this.cbbThuDai);
      if (this.DT.Rows.Count > 0)
      {
        for (int index = 0; index < this.DT.Rows.Count; ++index)
        {
          this._obj = new Tbketqua();
          this._obj.Clthutu = int.Parse(this.DT.Rows[index]["clthutu"].ToString());
          this._obj.Cldai = this.DT.Rows[index]["cldai"].ToString();
          this._obj.Clngaythang = DateTime.Parse(this.DT.Rows[index]["clngaythang"].ToString());
          this._obj.ClNguoithem = this.DT.Rows[index]["clNguoithem"].ToString();
          this._obj.G0 = this.DT.Rows[index]["G0"].ToString();
          this._obj.G1 = this.DT.Rows[index]["G1"].ToString();
          this._obj.G21 = this.DT.Rows[index]["G21"].ToString();
          this._obj.G22 = this.DT.Rows[index]["G22"].ToString();
          this._obj.G31 = this.DT.Rows[index]["G31"].ToString();
          this._obj.G32 = this.DT.Rows[index]["G32"].ToString();
          this._obj.G33 = this.DT.Rows[index]["G33"].ToString();
          this._obj.G34 = this.DT.Rows[index]["G34"].ToString();
          this._obj.G35 = this.DT.Rows[index]["G35"].ToString();
          this._obj.G36 = this.DT.Rows[index]["G36"].ToString();
          this._obj.G41 = this.DT.Rows[index]["G41"].ToString();
          this._obj.G42 = this.DT.Rows[index]["G42"].ToString();
          this._obj.G43 = this.DT.Rows[index]["G43"].ToString();
          this._obj.G44 = this.DT.Rows[index]["G44"].ToString();
          this._obj.G51 = this.DT.Rows[index]["G51"].ToString();
          this._obj.G52 = this.DT.Rows[index]["G52"].ToString();
          this._obj.G53 = this.DT.Rows[index]["G53"].ToString();
          this._obj.G54 = this.DT.Rows[index]["G54"].ToString();
          this._obj.G55 = this.DT.Rows[index]["G55"].ToString();
          this._obj.G56 = this.DT.Rows[index]["G56"].ToString();
          this._obj.G61 = this.DT.Rows[index]["G61"].ToString();
          this._obj.G62 = this.DT.Rows[index]["G62"].ToString();
          this._obj.G63 = this.DT.Rows[index]["G63"].ToString();
          this._obj.G71 = this.DT.Rows[index]["G71"].ToString();
          this._obj.G72 = this.DT.Rows[index]["G72"].ToString();
          this._obj.G73 = this.DT.Rows[index]["G73"].ToString();
          this._obj.G74 = this.DT.Rows[index]["G74"].ToString();
          str = str + "<div class=\"main\"><span class=\"title_XS\">Kết quả xổ số " + Tbketqua.GetThuTrongtuan(Convert.ToDateTime(this.DT.Rows[index]["clngaythang"].ToString())) + "</span>" + "<table class=\"table_KQ\"><tr><td class=\"style1\" style=\"color:Red;font-weight:bold;font-size:14px;\"  >&nbsp; Giải đặc biệt</td>" + "<td class=\"style2\" style=\"color:Red;font-weight:bold;font-size:24px;\" >&nbsp; " + this._obj.G0 + "</td></tr><tr>" + "<td class=\"style1\" >&nbsp; Giải nhất</td>" + "<td class=\"style2\" >&nbsp; " + this._obj.G1 + "</td>" + "</tr><tr><td class=\"style1\" >&nbsp; Giải nhì</td>" + "<td  class=\"style2\">&nbsp; " + this._obj.G21 + " - " + this._obj.G22 + "</td></tr><tr>" + "<td class=\"style1\" >&nbsp; Giải ba</td>" + "<td class=\"style2\" >&nbsp; " + this._obj.G31 + " - " + this._obj.G32 + " - " + this._obj.G33 + " - " + this._obj.G34 + " - " + this._obj.G35 + " - " + this._obj.G36 + "</td></tr><tr>" + "<td class=\"style1\" >&nbsp; Giải tư</td>" + "<td class=\"style2\"   >&nbsp; " + this._obj.G41 + " - " + this._obj.G42 + " - " + this._obj.G43 + " - " + this._obj.G44 + "</td></tr><tr>" + "<td class=\"style1\" >&nbsp; Giải năm</td>" + "<td class=\"style2\"  >&nbsp; " + this._obj.G51 + " - " + this._obj.G52 + " - " + this._obj.G53 + " - " + this._obj.G54 + " - " + this._obj.G55 + " - " + this._obj.G56 + "</td></tr><tr>" + "<td class=\"style1\" >&nbsp; Giải sáu</td>" + "<td class=\"style2\" >&nbsp; " + this._obj.G61 + " - " + this._obj.G62 + " - " + this._obj.G63 + "</td></tr><tr>" + "<td class=\"style1\" style=\"border-bottom-width: 0px;\">&nbsp; Giải bảy</td>" + "<td class=\"style2\" style=\"border-bottom-width: 0px;\">&nbsp; " + this._obj.G71 + " - " + this._obj.G72 + " - " + this._obj.G73 + " - " + this._obj.G74 + "</td></tr></table>" + "<table style=\"border: 1px dotted #FF9933; width: 20%; float: left; margin-bottom: 0px; margin-left: 15px;\" bgcolor=\"Transparent\"><tr><td class=\"style3\" >ĐẦU</td><td  class=\"style4\">LOTO</td>" + "</tr><tr><td class=\"style3\" >0</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "0", "dau") + "</td>" + "</tr><tr><td class=\"style3\" >1</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "1", "dau") + "</td></tr><tr>" + "<td class=\"style3\" >2</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "2", "dau") + " </td></tr><tr>" + "<td class=\"style3\" >3</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "3", "dau") + " </td></tr><tr>" + "<td class=\"style3\" >4</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "4", "dau") + "</td></tr><tr>" + "<td class=\"style3\" >5</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "5", "dau") + " </td></tr><tr>" + "<td class=\"style3\">6</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "6", "dau") + " </td></tr><tr>" + "<td class=\"style3\" >7</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "7", "dau") + " </td></tr><tr>" + "<td class=\"style3\" >8</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "8", "dau") + " </td></tr><tr>" + "<td class=\"style3\" style=\"border-bottom-width: 0px;\">9</td><td class=\"style4\"style=\"border-bottom-width: 0px;\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "9", "dau") + " </td></tr></table>" + "<table style=\"border: 1px dotted #FF9933; width: 20%; float: left; margin-bottom: 0px; margin-left: 15px;\" bgcolor=\"Transparent\"><tr><td class=\"style3\" >ĐÍT</td><td  class=\"style4\">LOTO</td>" + "</tr><tr><td class=\"style3\" >0</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "0", "dit") + "</td>" + "</tr><tr><td class=\"style3\" >1</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "1", "dit") + "</td></tr><tr>" + "<td class=\"style3\" >2</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "2", "dit") + " </td></tr><tr>" + "<td class=\"style3\" >3</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "3", "dit") + " </td></tr><tr>" + "<td class=\"style3\" >4</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "4", "dit") + "</td></tr><tr>" + "<td class=\"style3\" >5</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "5", "dit") + " </td></tr><tr>" + "<td class=\"style3\">6</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "6", "dit") + " </td></tr><tr>" + "<td class=\"style3\" >7</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "7", "dit") + " </td></tr><tr>" + "<td class=\"style3\" >8</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "8", "dit") + " </td></tr><tr>" + "<td class=\"style3\" style=\"border-bottom-width: 0px;\">9</td><td class=\"style4\"style=\"border-bottom-width: 0px;\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._obj, "9", "dit") + " </td></tr></table></div></br></br></br></br></br>";
        }
      }
      return str;
    }

    private void BtnXemClick(object sender, EventArgs e)
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void DTTuNgayValueChanged(object sender, EventArgs e)
    {
      if (this.dt_tu_ngay.Value >= this.dt_den_ngay.Value)
        this.dt_tu_ngay.Value = this.dt_den_ngay.Value.AddDays(-45.0);
      if (this.dt_den_ngay.Value.Subtract(this.dt_tu_ngay.Value).Days <= 365)
        return;
      this.dt_tu_ngay.Value = this.dt_den_ngay.Value.AddDays(-365.0);
    }

    private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
    {
      this.ShowKq(this.dt_tu_ngay.Value, this.dt_den_ngay.Value);
    }

    private void CbbThuDaiSelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        this.cbbThuDai = Convert.ToInt32(this.cbb_Thu_Dai.SelectedValue);
      }
      catch (Exception ex)
      {
        this.cbbThuDai = 0;
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.backgroundWorker1.IsBusy;
    }

    private void dt_den_ngay_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dt_den_ngay.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dt_den_ngay.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Tbketqua.HienThiKetQua(this.web_Brow_Ketqua, this.strHTML);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabKetqua));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.web_Brow_Ketqua = new WebBrowser();
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.btnXem = new Button();
      this.dt_tu_ngay = new DateTimePicker();
      this.label6 = new Label();
      this.cbb_Thu_Dai = new ComboBox();
      this.dt_den_ngay = new DateTimePicker();
      this.label9 = new Label();
      this.label10 = new Label();
      this.backgroundWorker1 = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.picLoading = new PictureBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.web_Brow_Ketqua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.web_Brow_Ketqua.Location = new Point(0, 30);
      this.web_Brow_Ketqua.MinimumSize = new Size(23, 23);
      this.web_Brow_Ketqua.Name = "web_Brow_Ketqua";
      this.web_Brow_Ketqua.Size = new Size(1186, 515);
      this.web_Brow_Ketqua.TabIndex = 19;
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btnXem);
      this.panel1.Controls.Add((Control) this.dt_tu_ngay);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.cbb_Thu_Dai);
      this.panel1.Controls.Add((Control) this.dt_den_ngay);
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.label10);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1169, 31);
      this.panel1.TabIndex = 20;
      this.label1.BackColor = Color.DimGray;
      this.label1.Dock = DockStyle.Bottom;
      this.label1.Location = new Point(0, 30);
      this.label1.Name = "label1";
      this.label1.Size = new Size(1169, 1);
      this.label1.TabIndex = 27;
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(456, 3);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(155, 23);
      this.btnXem.TabIndex = 3;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.BtnXemClick);
      this.dt_tu_ngay.CalendarFont = new Font("Arial", 9f, FontStyle.Bold);
      this.dt_tu_ngay.CalendarForeColor = Color.Red;
      this.dt_tu_ngay.CustomFormat = "dd/MM/yyyy";
      this.dt_tu_ngay.Font = new Font("Arial", 9f, FontStyle.Bold);
      this.dt_tu_ngay.Format = DateTimePickerFormat.Custom;
      this.dt_tu_ngay.Location = new Point(81, 5);
      this.dt_tu_ngay.Margin = new Padding(3, 5, 3, 5);
      this.dt_tu_ngay.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
      this.dt_tu_ngay.Name = "dt_tu_ngay";
      this.dt_tu_ngay.Size = new Size(100, 21);
      this.dt_tu_ngay.TabIndex = 0;
      this.dt_tu_ngay.ValueChanged += new EventHandler(this.DTTuNgayValueChanged);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(34, 8);
      this.label6.Name = "label6";
      this.label6.Size = new Size(46, 15);
      this.label6.TabIndex = 20;
      this.label6.Text = "Xem từ";
      this.cbb_Thu_Dai.BackColor = Color.Teal;
      this.cbb_Thu_Dai.Cursor = Cursors.Hand;
      this.cbb_Thu_Dai.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbb_Thu_Dai.FlatStyle = FlatStyle.Popup;
      this.cbb_Thu_Dai.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbb_Thu_Dai.ForeColor = Color.White;
      this.cbb_Thu_Dai.FormattingEnabled = true;
      this.cbb_Thu_Dai.Location = new Point(348, 3);
      this.cbb_Thu_Dai.Margin = new Padding(2, 5, 3, 3);
      this.cbb_Thu_Dai.Name = "cbb_Thu_Dai";
      this.cbb_Thu_Dai.Size = new Size(102, 23);
      this.cbb_Thu_Dai.TabIndex = 2;
      this.cbb_Thu_Dai.SelectedIndexChanged += new EventHandler(this.CbbThuDaiSelectedIndexChanged);
      this.dt_den_ngay.CalendarFont = new Font("Arial", 9f, FontStyle.Bold);
      this.dt_den_ngay.CalendarForeColor = Color.Red;
      this.dt_den_ngay.Cursor = Cursors.Hand;
      this.dt_den_ngay.CustomFormat = "dd/MM/yyyy";
      this.dt_den_ngay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dt_den_ngay.Format = DateTimePickerFormat.Custom;
      this.dt_den_ngay.Location = new Point(211, 5);
      this.dt_den_ngay.Margin = new Padding(3, 5, 3, 5);
      this.dt_den_ngay.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
      this.dt_den_ngay.Name = "dt_den_ngay";
      this.dt_den_ngay.Size = new Size(100, 21);
      this.dt_den_ngay.TabIndex = 1;
      this.dt_den_ngay.ValueChanged += new EventHandler(this.dt_den_ngay_ValueChanged);
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(322, 7);
      this.label9.Name = "label9";
      this.label9.Size = new Size(25, 15);
      this.label9.TabIndex = 23;
      this.label9.Text = "thứ";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(180, 8);
      this.label10.Name = "label10";
      this.label10.Size = new Size(28, 15);
      this.label10.TabIndex = 21;
      this.label10.Text = "đến";
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.BackgroundWorker1DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(535, 314);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 60;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.web_Brow_Ketqua);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabKetqua);
      this.Size = new Size(1169, 546);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
