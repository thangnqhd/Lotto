// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabVaotienChukiDanh
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabVaotienChukiDanh : UserControl
  {
    public static int LoadLaiCombobox = 0;
    public static string DonviTiente = "VND";
    public static int LoadLaiDuLieu_Combobox = 0;
    private int _trangthaiChuki = 0;
    private IContainer components = (IContainer) null;
    public static string TenChuki;
    private DataTable _dt;
    private tbChukidanh _infoChuki;
    private TbLoOffline _objTbLoOffline;
    private FChuki _fChuki;
    private int _firstBandau;
    private int _valueCombobox;
    private ArrayList _listCombo;
    private int _machukiMoiNhat;
    private TabVaotienChukiDanh.ValueControl _valueControl;
    private int _maChotLoto;
    private int _month;
    private int _year;
    private FVaotien _fVaotien;
    private DataGridView.HitTestInfo _myHitTestDown;
    private GroupBox groupBox1;
    private Label label1;
    private ToolTip toolTip1;
    private Button button4;
    private ComboBox cbbChukidanh;
    private Button btnXoa;
    private Button btnChotso;
    private Timer timer1;
    private BunifuElipse bunifuElipse1;
    private BackgroundWorker backgroundWorker1;
    private BackgroundWorker backgroundWorker2;
    private Panel panel1;
    private Panel panel3;
    private Panel panel2;
    private BunifuImageButton bunifuImageButton8;
    private Label label39;
    private Label label37;
    private Label label35;
    private Label label31;
    private Label label33;
    private Label lblTongthuCuaThang;
    private Label lblLoinhuanDauTu_DacBiet;
    private Label lblTongthuTuDacBiet;
    private Label lblLoinhuanDauTu_Loto;
    private Label lblTongthutuLoto;
    private Label lblTongthucuaChuki;
    private Label lblTongthuCuaThang1;
    private BunifuImageButton bunifuImageButton10;
    private BunifuImageButton bunifuImageButton9;
    private BunifuImageButton bunifuImageButton6;
    private BunifuImageButton bunifuImageButton7;
    private BunifuImageButton bunifuImageButton5;
    private DataGridView dtg_Ketqua;
    private Label label27;
    private Label label6;
    private Label lblLoinhuandauTuChuki;
    private BunifuImageButton bunifuImageButton1;
    private BunifuImageButton bunifuImageButton3;
    private BunifuImageButton bunifuImageButton2;
    private Label lblHoanthanhMucTieu;
    private Label lblMuctieuChuki;
    private BunifuImageButton bunifuImageButton4;
    private Label lblTongthucuaChuk2;
    private BunifuImageButton bunifuImageButton11;
    private Label label2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem chỉnhSửaToolStripMenuItem;
    private ToolStripMenuItem xóaToolStripMenuItem;
    private ToolStripMenuItem chốtSốToolStripMenuItem;
    private PictureBox picLoading;
    private Timer timeLoading;
    private Button btnKhoachuky;
    private Panel pnTop1;
    private Panel pnTop4;
    private Panel pnTop3;
    private Panel pnTop2;
    private Panel pnbot1;
    private Panel pnbot2;
    private Panel pnbot3;
    private Panel pnbot5;
    private Panel pnbot4;
    private Panel pnbot6;
    private Panel pnbot7;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn sothutu;
    private DataGridViewTextBoxColumn nguonLoto;
    private DataGridViewTextBoxColumn soChot;
    private DataGridViewTextBoxColumn tongDiem;
    private DataGridViewTextBoxColumn soLove;
    private DataGridViewTextBoxColumn soVon;
    private DataGridViewTextBoxColumn soLai;
    private DataGridViewTextBoxColumn hinhThucDanh;
    private DataGridViewTextBoxColumn ngayDanh;
    private DataGridViewTextBoxColumn duNo;
    private DataGridViewTextBoxColumn ngayChot;
    private DataGridViewTextBoxColumn colTrong;

    public TabVaotienChukiDanh()
    {
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.EditLocaltionPanel();
    }

    private void EditLocaltionPanel()
    {
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      int num1 = FMain.ChieurongForm / 8;
      this.pnTop1.Location = new Point(num1 * 4 + 10, this.pnTop1.Location.Y);
      this.pnTop2.Location = new Point(num1 * 5 + 35, this.pnTop2.Location.Y);
      this.pnTop3.Location = new Point(num1 * 6 + 55, this.pnTop3.Location.Y);
      this.pnTop4.Location = new Point(num1 * 7 + 40, this.pnTop4.Location.Y);
      int num2 = (FMain.ChieurongForm - 16) / 7;
      this.pnbot1.Location = new Point(3, this.pnbot1.Location.Y);
      this.pnbot1.Width = num2;
      this.pnbot2.Location = new Point(num2 + 3 + 1, this.pnbot2.Location.Y);
      this.pnbot2.Width = num2;
      this.pnbot3.Location = new Point(num2 * 2 + 3 + 1, this.pnbot3.Location.Y);
      this.pnbot3.Width = num2;
      this.pnbot4.Location = new Point(num2 * 3 + 3 + 2, this.pnbot4.Location.Y);
      this.pnbot4.Width = num2;
      this.pnbot5.Location = new Point(num2 * 4 + 3 + 3, this.pnbot5.Location.Y);
      this.pnbot5.Width = num2;
      this.pnbot6.Location = new Point(num2 * 5 + 3 + 4, this.pnbot6.Location.Y);
      this.pnbot6.Width = num2;
      this.pnbot7.Location = new Point(num2 * 6 + 3 + 5, this.pnbot7.Location.Y);
      this.pnbot7.Width = num2;
    }

    private void CreateCombooBoxData()
    {
      this._dt = new DataTable();
      this._dt = this._infoChuki.GetList_By_Username(TbUser.Tbuser.TenDangnhap);
      this._listCombo = new ArrayList();
      if (this._dt.Rows.Count > 0)
      {
        for (int index = 0; index < this._dt.Rows.Count; ++index)
        {
          string str1 = " - Chưa chốt ]";
          this._valueCombobox = int.Parse(this._dt.Rows[0]["stt"].ToString());
          if (this._dt.Rows[index]["status"].ToString() == "False" || this._dt.Rows[index]["status"].ToString() == "0")
            str1 = " - " + Convert.ToDateTime(this._dt.Rows[index]["ngayKetthuc"].ToString()).ToString("dd/MM") + " ]";
          string str2 = " [ " + Convert.ToDateTime(this._dt.Rows[index]["ngayBatdau"].ToString()).ToString("dd/MM");
          this._listCombo.Add((object) new ClMain.AddValue("  " + this._dt.Rows[index]["tenChuki"] + str2 + str1, this._dt.Rows[index]["stt"].ToString()));
        }
      }
      else
        this._listCombo.Clear();
    }

    private void Button4Click(object sender, EventArgs e)
    {
      if (this.cbbChukidanh.SelectedValue == null || MessageBox.Show(Resources.tabVaotien_ChukiDanh_button4_Click_BẠN_CÓ_CHẮC_CHẮN_MUỐN_XÓA_CHU_KÌ_NÀY, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      if (this._infoChuki.Delete_By_Stt(this.cbbChukidanh.SelectedValue.ToString()))
      {
        TabVaotienChukiDanh.LoadLaiCombobox = 1;
        TabThongkeCanhan.LoadLaiForm = 1;
      }
      else
      {
        int num = (int) MessageBox.Show(Resources.tabVaotien_ChukiDanh_button4_Click_XÓA_KHÔNG_THÀNH_CÔNG, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO);
      }
    }

    private void Button4Click1(object sender, EventArgs e)
    {
      int num = (int) this._fChuki.ShowDialog();
    }

    private void Timer1Tick(object sender, EventArgs e)
    {
      if (TabVaotienChukiDanh.LoadLaiCombobox == 1)
      {
        TabVaotienChukiDanh.LoadLaiCombobox = 0;
        this._infoChuki = new tbChukidanh();
        if (!this.backgroundWorker1.IsBusy)
          this.backgroundWorker1.RunWorkerAsync();
      }
      if (TabVaotienChukiDanh.LoadLaiDuLieu_Combobox == 1)
      {
        TabVaotienChukiDanh.LoadLaiDuLieu_Combobox = 0;
        if (!this.backgroundWorker2.IsBusy)
          this.backgroundWorker2.RunWorkerAsync();
      }
      if (this._listCombo != null)
      {
        if (this._trangthaiChuki == 0 || this._listCombo.Count < 1)
        {
          this.btnKhoachuky.Enabled = false;
          this.btnChotso.Enabled = false;
        }
        else
        {
          this.btnKhoachuky.Enabled = true;
          this.btnChotso.Enabled = true;
        }
      }
      else
      {
        this.btnKhoachuky.Enabled = false;
        this.btnChotso.Enabled = false;
      }
    }

    private void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
    {
      this._firstBandau = 1;
      if (this._listCombo.Count > 0)
      {
        this._firstBandau = this._listCombo.Count + 1;
        if (this.cbbChukidanh.SelectedValue.ToString() != "Thống_kê_xổ_số.BusinessLayer.ClMain+AddValue")
        {
          if (this.cbbChukidanh.SelectedIndex == 0)
            this._machukiMoiNhat = Convert.ToInt32(this.cbbChukidanh.SelectedValue.ToString());
          this._valueCombobox = int.Parse(this.cbbChukidanh.SelectedValue.ToString());
          if (!this.backgroundWorker2.IsBusy)
            this.backgroundWorker2.RunWorkerAsync();
        }
      }
      TabVaotienChukiDanh.TenChuki = "Tiêu diệt chủ lô " + (object) this._firstBandau;
    }

    private void Xuly(int vaLue)
    {
      this._objTbLoOffline = new TbLoOffline();
      this._valueControl = new TabVaotienChukiDanh.ValueControl();
      this.GetInfoTbChuki(vaLue);
      this.ShowVonLaiLotoDacBiet(vaLue);
    }

    private void UpdateValuse()
    {
      this.lblTongthuCuaThang.Text = ClMain.CatChuoi_DaiQua(ClMain.QuiDoiSoLuong(this._valueControl.Tonglaithangnay.ToString(), TabVaotienChukiDanh.DonviTiente), 16);
      this.lblTongthucuaChuki.Text = this._valueControl.TonglaichukiHientai;
      this.lblLoinhuandauTuChuki.Text = this._valueControl.LoinhuanDauTuCuaChuKi;
      this.lblTongthutuLoto.Text = ClMain.CatChuoi_DaiQua(ClMain.QuiDoiSoLuong(this._valueControl.TongThuTuLoto.ToString(), TabVaotienChukiDanh.DonviTiente), 16);
      this.lblLoinhuanDauTu_Loto.Text = ClMain.CatChuoi_DaiQua(string.Format("{0:0.00}", (object) this._valueControl.LoiNhuanDauTuLoto) + " %", 9);
      this.lblTongthuTuDacBiet.Text = ClMain.CatChuoi_DaiQua(ClMain.QuiDoiSoLuong(this._valueControl.TongThuTuDacbiet.ToString(), TabVaotienChukiDanh.DonviTiente), 16);
      this.lblLoinhuanDauTu_DacBiet.Text = ClMain.CatChuoi_DaiQua(string.Format("{0:0.00}", (object) this._valueControl.LoiNhuanDauTuDacBiet) + " %", 9);
      this.lblMuctieuChuki.Text = this._valueControl.MuctieuChuKi;
      this.lblHoanthanhMucTieu.Text = this._valueControl.HoanThanhMucTieu;
      this.lblTongthucuaChuk2.Text = this._valueControl.TonglaichukiHientai;
      this.dtg_Ketqua.AutoGenerateColumns = false;
      this.dtg_Ketqua.DataSource = (object) this._valueControl.ListData;
    }

    private void GetInfoTbChuki(int maChuki)
    {
      this._infoChuki = new tbChukidanh();
      this._infoChuki = this._infoChuki.GetInfor(maChuki);
      this._month = this._infoChuki.ngayBatdau.Month;
      this._year = this._infoChuki.ngayBatdau.Year;
      TabVaotienChukiDanh.DonviTiente = this._infoChuki.donviTien;
      this._valueControl.TonglaichukiHientai = ClMain.CatChuoi_DaiQua(ClMain.QuiDoiSoLuong(this._infoChuki.tongTienLai.ToString(), TabVaotienChukiDanh.DonviTiente), 16);
      this._valueControl.TongVontrongchuki = ClMain.CatChuoi_DaiQua(ClMain.QuiDoiSoLuong(this._infoChuki.tongSovon.ToString(), TabVaotienChukiDanh.DonviTiente), 16);
      this._valueControl.MuctieuChuKi = ClMain.CatChuoi_DaiQua(ClMain.QuiDoiSoLuong(this._infoChuki.muctieuChuki.ToString(), TabVaotienChukiDanh.DonviTiente), 16);
      this._valueControl.HoanThanhMucTieu = "0%";
      this._valueControl.LoinhuanDauTuCuaChuKi = "0%";
      if (this._infoChuki.tongTienLai != Decimal.Zero && this._infoChuki.muctieuChuki != Decimal.Zero)
      {
        this._valueControl.HoanThanhMucTieu = ClMain.CatChuoi_DaiQua(string.Format("{0:0.00}", (object) (this._infoChuki.tongTienLai / this._infoChuki.muctieuChuki * new Decimal(100))) + " %", 9);
        this._valueControl.LoinhuanDauTuCuaChuKi = ClMain.CatChuoi_DaiQua(string.Format("{0:0.00}", (object) (this._infoChuki.tongTienLai / this._infoChuki.tongSovon * new Decimal(100))) + " %", 9);
      }
      this._valueControl.ListData = this._objTbLoOffline.GetListByMaChuKiObj(maChuki, TabVaotienChukiDanh.DonviTiente);
      this._trangthaiChuki = this._infoChuki.status;
    }

    private void ShowVonLaiLotoDacBiet(int maChuki)
    {
      this._dt = this._objTbLoOffline.GetSoVonSolaiByMaChuKi(maChuki);
      if (this._dt.Rows.Count <= 0)
        return;
      this._valueControl.TongVonTuLoto = Decimal.Zero;
      this._valueControl.TongThuTuLoto = Decimal.Zero;
      this._valueControl.TongVonTuDacbiet = Decimal.Zero;
      this._valueControl.TongThuTuDacbiet = Decimal.Zero;
      for (int index = 0; index < this._dt.Rows.Count; ++index)
      {
        if (this._dt.Rows[index]["hinhThucDanh"].ToString() == "0" || this._dt.Rows[index]["hinhThucDanh"].ToString() == "1")
        {
          this._valueControl.TongVonTuLoto += Decimal.Parse(this._dt.Rows[index]["soVon"].ToString());
          this._valueControl.TongThuTuLoto += Decimal.Parse(this._dt.Rows[index]["soLai"].ToString());
        }
        else
        {
          this._valueControl.TongVonTuDacbiet += Decimal.Parse(this._dt.Rows[index]["soVon"].ToString());
          this._valueControl.TongThuTuDacbiet += Decimal.Parse(this._dt.Rows[index]["soLai"].ToString());
        }
      }
      this._valueControl.LoiNhuanDauTuLoto = Decimal.Zero;
      if (this._valueControl.TongVonTuLoto > Decimal.Zero && this._valueControl.TongThuTuLoto > Decimal.Zero)
        this._valueControl.LoiNhuanDauTuLoto = this._valueControl.TongThuTuLoto / this._valueControl.TongVonTuLoto * new Decimal(100);
      this._valueControl.LoiNhuanDauTuDacBiet = Decimal.Zero;
      if (this._valueControl.TongVonTuDacbiet > Decimal.Zero && this._valueControl.TongThuTuDacbiet > Decimal.Zero)
        this._valueControl.LoiNhuanDauTuDacBiet = this._valueControl.TongThuTuDacbiet / this._valueControl.TongVonTuDacbiet * new Decimal(100);
    }

    private void TinhTongLaiThang(int thang, int namYear)
    {
      this._dt = this._objTbLoOffline.GetSolaiByMonth(thang, namYear, TbUser.Tbuser.TenDangnhap);
      if (this._dt.Rows.Count > 0)
      {
        for (int index = 0; index < this._dt.Rows.Count; ++index)
          this._valueControl.Tonglaithangnay += Decimal.Parse(this._dt.Rows[index]["soLai"].ToString());
      }
      else
        this._valueControl.Tonglaithangnay = Decimal.Zero;
    }

    private void TabVaotienChukiDanhLoad(object sender, EventArgs e)
    {
      this._dt = new DataTable();
      this._fChuki = new FChuki();
      this._objTbLoOffline = new TbLoOffline();
      this._infoChuki = new tbChukidanh();
      TabVaotienChukiDanh.LoadLaiCombobox = 1;
      this.timer1.Start();
    }

    private void BtnChotsoClick(object sender, EventArgs e)
    {
      if (this._listCombo.Count <= 0)
        return;
      DataTable dataTable = new DataTable();
      if (this._infoChuki.CheckStatus(this._valueCombobox).Rows.Count > 0)
      {
        int num1 = (int) new FLotoOffline(this._valueCombobox, "add", this._maChotLoto).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show(Resources.TabVaotienChukiDanh_btnChotso_Click_Chu_kì_này_đã_được_chốt__Bạn_không_thể_thể_chốt_thêm_số_cho_chu_kì_này, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void IndexChange(DataGridViewCellEventArgs e)
    {
      this._maChotLoto = -1;
      if (e.RowIndex <= -1)
        return;
      this._maChotLoto = int.Parse(this.dtg_Ketqua.Rows[e.RowIndex].Cells["Stt"].Value.ToString());
    }

    private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
    {
      this.CreateCombooBoxData();
    }

    private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._listCombo.Count > 0)
      {
        this.cbbChukidanh.DataSource = (object) this._listCombo;
        this.cbbChukidanh.ValueMember = "Value";
        this.cbbChukidanh.DisplayMember = "Display";
      }
      else
        this.cbbChukidanh.DataSource = (object) null;
    }

    private void BackgroundWorker2DoWork(object sender, DoWorkEventArgs e)
    {
      this.Xuly(this._valueCombobox);
      if (this._month <= 0 || this._year <= 0)
        return;
      this.TinhTongLaiThang(this._month, this._year);
    }

    private void BackgroundWorker2RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.UpdateValuse();
    }

    private void DtgKetquaCellDoubleClick1(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex <= -1 || this._infoChuki.status != 1)
        return;
      int num = (int) new FLotoOffline(this._valueCombobox, "update", this._maChotLoto).ShowDialog();
    }

    private void DtgKetquaKeyDown1(object sender, KeyEventArgs e)
    {
      if (this._maChotLoto == -1 || this._infoChuki.status != 1 || (e.KeyCode != Keys.Delete || MessageBox.Show(Resources.TabVaotienChukiDanh_dtg_Ketqua_KeyDown_BẠN_CÓ_CHẮC_CHẮN_MUỐN_XÓA_MỤC_CHỐT_NÀY____, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes))
        return;
      this._objTbLoOffline.Delete(this._maChotLoto);
      if (!this.backgroundWorker2.IsBusy)
        this.backgroundWorker2.RunWorkerAsync();
      TabThongkeCanhan.LoadLaiForm = 1;
    }

    private void DtgKetquaRowEnter1(object sender, DataGridViewCellEventArgs e)
    {
      this.IndexChange(e);
    }

    private void BunifuImageButton11Click(object sender, EventArgs e)
    {
      if (Application.OpenForms.OfType<FVaotien>().Count<FVaotien>() == 1)
      {
        this._fVaotien.WindowState = FormWindowState.Normal;
        this._fVaotien.Show();
        this._fVaotien.Focus();
      }
      else
      {
        Decimal num = this._infoChuki.hesoNhanLo;
        Decimal dongiaLoto = Decimal.Parse(num.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        num = this._infoChuki.tileAnLo;
        Decimal hesonhanLoto = Decimal.Parse(num.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        num = this._infoChuki.hesoNhanDe;
        Decimal dongiaDacbiet = Decimal.Parse(num.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        num = this._infoChuki.tileAnDe;
        Decimal hesonhanDacbiet = Decimal.Parse(num.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        string donviTien = this._infoChuki.donviTien;
        this._fVaotien = new FVaotien(dongiaLoto, hesonhanLoto, dongiaDacbiet, hesonhanDacbiet, donviTien);
        this._fVaotien.Show();
      }
    }

    private void ChỉnhSửaToolStripMenuItemClick(object sender, EventArgs e)
    {
      int num = (int) new FLotoOffline(this._valueCombobox, "update", this._maChotLoto).ShowDialog();
    }

    private void XóaToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (this._maChotLoto == -1 || MessageBox.Show(Resources.TabVaotienChukiDanh_dtg_Ketqua_KeyDown_BẠN_CÓ_CHẮC_CHẮN_MUỐN_XÓA_MỤC_CHỐT_NÀY____, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this._objTbLoOffline.Delete(this._maChotLoto);
      if (!this.backgroundWorker2.IsBusy)
        this.backgroundWorker2.RunWorkerAsync();
      TabThongkeCanhan.LoadLaiForm = 1;
    }

    private void DtgKetquaMouseDown(object sender, MouseEventArgs e)
    {
      this._myHitTestDown = this.dtg_Ketqua.HitTest(e.X, e.Y);
      if (this._myHitTestDown.RowIndex <= -1 || (e.Button != MouseButtons.Right || this._myHitTestDown.RowIndex <= -1))
        return;
      this.dtg_Ketqua.Rows[this._myHitTestDown.RowIndex].Selected = true;
      this._maChotLoto = int.Parse(this.dtg_Ketqua.Rows[this._myHitTestDown.RowIndex].Cells[0].Value.ToString());
    }

    private void ChốtSốToolStripMenuItemClick(object sender, EventArgs e)
    {
      int num = (int) new FLotoOffline(this._valueCombobox, "add", this._maChotLoto).ShowDialog();
    }

    private void HienthiMenuStrip()
    {
      if (this._trangthaiChuki == 0)
      {
        this.contextMenuStrip1.Enabled = false;
      }
      else
      {
        this.contextMenuStrip1.Enabled = true;
        if (this.dtg_Ketqua.Rows.Count < 1)
        {
          this.contextMenuStrip1.Items[1].Enabled = false;
          this.contextMenuStrip1.Items[2].Enabled = false;
        }
        else
        {
          this.contextMenuStrip1.Items[1].Enabled = true;
          this.contextMenuStrip1.Items[2].Enabled = true;
        }
      }
    }

    private void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
    {
      this.HienthiMenuStrip();
    }

    private void timeLoading_Tick(object sender, EventArgs e)
    {
      if (!this.backgroundWorker1.IsBusy && !this.backgroundWorker2.IsBusy)
        this.picLoading.Visible = false;
      else
        this.picLoading.Visible = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DataTable dataTable1 = new DataTable();
      if (this._listCombo.Count <= 0)
        return;
      DataTable dataTable2 = this._infoChuki.CheckStatus(this._valueCombobox);
      if (dataTable2.Rows.Count > 0 && MessageBox.Show("Chu kì [ " + dataTable2.Rows[0]["tenChuki"] + " ] sẽ được chốt, Bạn sẽ không thể 'CHỈNH SỬA', 'XÓA' hoặc 'THÊM MỚI' các bản ghi cho chu kì này. Bạn có muốn tiếp tục ?", Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes && this._infoChuki.Update_Status(this._valueCombobox, "0") == 1)
      {
        int num = (int) MessageBox.Show("CẬP NHẬT CHU KỲ KHÔNG THÀNH CÔNG", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        TabVaotienChukiDanh.LoadLaiCombobox = 1;
      }
    }

    private void toolTip1_Popup(object sender, PopupEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabVaotienChukiDanh));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      this.groupBox1 = new GroupBox();
      this.pnTop4 = new Panel();
      this.bunifuImageButton11 = new BunifuImageButton();
      this.label2 = new Label();
      this.pnTop3 = new Panel();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.lblHoanthanhMucTieu = new Label();
      this.pnTop2 = new Panel();
      this.bunifuImageButton4 = new BunifuImageButton();
      this.lblTongthucuaChuk2 = new Label();
      this.pnTop1 = new Panel();
      this.bunifuImageButton2 = new BunifuImageButton();
      this.lblMuctieuChuki = new Label();
      this.btnKhoachuky = new Button();
      this.cbbChukidanh = new ComboBox();
      this.btnXoa = new Button();
      this.btnChotso = new Button();
      this.button4 = new Button();
      this.label1 = new Label();
      this.toolTip1 = new ToolTip(this.components);
      this.lblLoinhuanDauTu_DacBiet = new Label();
      this.lblTongthuTuDacBiet = new Label();
      this.lblLoinhuanDauTu_Loto = new Label();
      this.lblTongthutuLoto = new Label();
      this.lblTongthucuaChuki = new Label();
      this.lblLoinhuandauTuChuki = new Label();
      this.lblTongthuCuaThang = new Label();
      this.lblTongthuCuaThang1 = new Label();
      this.timer1 = new Timer(this.components);
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.backgroundWorker1 = new BackgroundWorker();
      this.backgroundWorker2 = new BackgroundWorker();
      this.panel1 = new Panel();
      this.panel3 = new Panel();
      this.picLoading = new PictureBox();
      this.dtg_Ketqua = new DataGridView();
      this.stt = new DataGridViewTextBoxColumn();
      this.sothutu = new DataGridViewTextBoxColumn();
      this.nguonLoto = new DataGridViewTextBoxColumn();
      this.soChot = new DataGridViewTextBoxColumn();
      this.tongDiem = new DataGridViewTextBoxColumn();
      this.soLove = new DataGridViewTextBoxColumn();
      this.soVon = new DataGridViewTextBoxColumn();
      this.soLai = new DataGridViewTextBoxColumn();
      this.hinhThucDanh = new DataGridViewTextBoxColumn();
      this.ngayDanh = new DataGridViewTextBoxColumn();
      this.duNo = new DataGridViewTextBoxColumn();
      this.ngayChot = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.chốtSốToolStripMenuItem = new ToolStripMenuItem();
      this.chỉnhSửaToolStripMenuItem = new ToolStripMenuItem();
      this.xóaToolStripMenuItem = new ToolStripMenuItem();
      this.panel2 = new Panel();
      this.pnbot7 = new Panel();
      this.bunifuImageButton10 = new BunifuImageButton();
      this.label39 = new Label();
      this.pnbot6 = new Panel();
      this.bunifuImageButton9 = new BunifuImageButton();
      this.label37 = new Label();
      this.pnbot5 = new Panel();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.label35 = new Label();
      this.pnbot4 = new Panel();
      this.bunifuImageButton6 = new BunifuImageButton();
      this.label31 = new Label();
      this.pnbot3 = new Panel();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.label6 = new Label();
      this.pnbot2 = new Panel();
      this.bunifuImageButton7 = new BunifuImageButton();
      this.label33 = new Label();
      this.pnbot1 = new Panel();
      this.bunifuImageButton5 = new BunifuImageButton();
      this.label27 = new Label();
      this.timeLoading = new Timer(this.components);
      this.groupBox1.SuspendLayout();
      this.pnTop4.SuspendLayout();
      this.bunifuImageButton11.BeginInit();
      this.pnTop3.SuspendLayout();
      this.bunifuImageButton3.BeginInit();
      this.pnTop2.SuspendLayout();
      this.bunifuImageButton4.BeginInit();
      this.pnTop1.SuspendLayout();
      this.bunifuImageButton2.BeginInit();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.pnbot7.SuspendLayout();
      this.bunifuImageButton10.BeginInit();
      this.pnbot6.SuspendLayout();
      this.bunifuImageButton9.BeginInit();
      this.pnbot5.SuspendLayout();
      this.bunifuImageButton8.BeginInit();
      this.pnbot4.SuspendLayout();
      this.bunifuImageButton6.BeginInit();
      this.pnbot3.SuspendLayout();
      this.bunifuImageButton1.BeginInit();
      this.pnbot2.SuspendLayout();
      this.bunifuImageButton7.BeginInit();
      this.pnbot1.SuspendLayout();
      this.bunifuImageButton5.BeginInit();
      this.SuspendLayout();
      this.groupBox1.BackColor = Color.White;
      this.groupBox1.Controls.Add((Control) this.pnTop4);
      this.groupBox1.Controls.Add((Control) this.pnTop3);
      this.groupBox1.Controls.Add((Control) this.pnTop2);
      this.groupBox1.Controls.Add((Control) this.pnTop1);
      this.groupBox1.Controls.Add((Control) this.btnKhoachuky);
      this.groupBox1.Controls.Add((Control) this.cbbChukidanh);
      this.groupBox1.Controls.Add((Control) this.btnXoa);
      this.groupBox1.Controls.Add((Control) this.btnChotso);
      this.groupBox1.Controls.Add((Control) this.button4);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Dock = DockStyle.Top;
      this.groupBox1.FlatStyle = FlatStyle.Popup;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1100, 48);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.pnTop4.Controls.Add((Control) this.bunifuImageButton11);
      this.pnTop4.Controls.Add((Control) this.label2);
      this.pnTop4.Location = new Point(990, 12);
      this.pnTop4.Name = "pnTop4";
      this.pnTop4.Size = new Size(100, 28);
      this.pnTop4.TabIndex = 61;
      this.bunifuImageButton11.BackColor = Color.Transparent;
      this.bunifuImageButton11.Cursor = Cursors.Hand;
      this.bunifuImageButton11.Image = (Image) componentResourceManager.GetObject("bunifuImageButton11.Image");
      this.bunifuImageButton11.ImageActive = (Image) null;
      this.bunifuImageButton11.Location = new Point(3, 1);
      this.bunifuImageButton11.Name = "bunifuImageButton11";
      this.bunifuImageButton11.Size = new Size(24, 24);
      this.bunifuImageButton11.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton11.TabIndex = 27;
      this.bunifuImageButton11.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton11, " Bảng vào tiền, tính toán nhanh");
      this.bunifuImageButton11.Zoom = 0;
      this.bunifuImageButton11.Click += new EventHandler(this.BunifuImageButton11Click);
      this.label2.AutoSize = true;
      this.label2.Cursor = Cursors.Default;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.label2.ForeColor = Color.DimGray;
      this.label2.Location = new Point(27, 6);
      this.label2.Name = "label2";
      this.label2.Size = new Size(61, 16);
      this.label2.TabIndex = 16;
      this.label2.Text = "Vào tiền";
      this.label2.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.label2, " Bảng vào tiền, tính toán nhanh");
      this.pnTop3.Controls.Add((Control) this.bunifuImageButton3);
      this.pnTop3.Controls.Add((Control) this.lblHoanthanhMucTieu);
      this.pnTop3.Location = new Point(862, 12);
      this.pnTop3.Name = "pnTop3";
      this.pnTop3.Size = new Size(130, 28);
      this.pnTop3.TabIndex = 60;
      this.bunifuImageButton3.BackColor = Color.Transparent;
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Dock = DockStyle.Left;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(0, 0);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(24, 28);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 27;
      this.bunifuImageButton3.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton3, " Tỉ lệ hoàn thành mục tiêu");
      this.bunifuImageButton3.Zoom = 0;
      this.lblHoanthanhMucTieu.AutoSize = true;
      this.lblHoanthanhMucTieu.Cursor = Cursors.Default;
      this.lblHoanthanhMucTieu.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.lblHoanthanhMucTieu.ForeColor = Color.DimGray;
      this.lblHoanthanhMucTieu.Location = new Point(25, 6);
      this.lblHoanthanhMucTieu.Name = "lblHoanthanhMucTieu";
      this.lblHoanthanhMucTieu.Size = new Size(25, 16);
      this.lblHoanthanhMucTieu.TabIndex = 16;
      this.lblHoanthanhMucTieu.Text = "0%";
      this.lblHoanthanhMucTieu.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.lblHoanthanhMucTieu, " Tỉ lệ hoàn thành mục tiêu");
      this.pnTop2.Controls.Add((Control) this.bunifuImageButton4);
      this.pnTop2.Controls.Add((Control) this.lblTongthucuaChuk2);
      this.pnTop2.Location = new Point(714, 12);
      this.pnTop2.Name = "pnTop2";
      this.pnTop2.Size = new Size(140, 28);
      this.pnTop2.TabIndex = 59;
      this.bunifuImageButton4.BackColor = Color.Transparent;
      this.bunifuImageButton4.Cursor = Cursors.Hand;
      this.bunifuImageButton4.Dock = DockStyle.Left;
      this.bunifuImageButton4.Image = (Image) componentResourceManager.GetObject("bunifuImageButton4.Image");
      this.bunifuImageButton4.ImageActive = (Image) null;
      this.bunifuImageButton4.Location = new Point(0, 0);
      this.bunifuImageButton4.Name = "bunifuImageButton4";
      this.bunifuImageButton4.Size = new Size(25, 28);
      this.bunifuImageButton4.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton4.TabIndex = 10;
      this.bunifuImageButton4.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton4, " Mục tiêu đã đạt được");
      this.bunifuImageButton4.Zoom = 0;
      this.lblTongthucuaChuk2.AutoSize = true;
      this.lblTongthucuaChuk2.Cursor = Cursors.Default;
      this.lblTongthucuaChuk2.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.lblTongthucuaChuk2.ForeColor = Color.DimGray;
      this.lblTongthucuaChuk2.Location = new Point(25, 6);
      this.lblTongthucuaChuk2.Name = "lblTongthucuaChuk2";
      this.lblTongthucuaChuk2.Size = new Size(46, 16);
      this.lblTongthucuaChuk2.TabIndex = 16;
      this.lblTongthucuaChuk2.Text = "0 VND";
      this.lblTongthucuaChuk2.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthucuaChuk2, " Mục tiêu đã đạt được");
      this.pnTop1.Controls.Add((Control) this.bunifuImageButton2);
      this.pnTop1.Controls.Add((Control) this.lblMuctieuChuki);
      this.pnTop1.Location = new Point(566, 12);
      this.pnTop1.Name = "pnTop1";
      this.pnTop1.Size = new Size(140, 28);
      this.pnTop1.TabIndex = 58;
      this.bunifuImageButton2.BackColor = Color.Transparent;
      this.bunifuImageButton2.Cursor = Cursors.Hand;
      this.bunifuImageButton2.Dock = DockStyle.Left;
      this.bunifuImageButton2.Image = (Image) componentResourceManager.GetObject("bunifuImageButton2.Image");
      this.bunifuImageButton2.ImageActive = (Image) null;
      this.bunifuImageButton2.Location = new Point(0, 0);
      this.bunifuImageButton2.Name = "bunifuImageButton2";
      this.bunifuImageButton2.Size = new Size(27, 28);
      this.bunifuImageButton2.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton2.TabIndex = 10;
      this.bunifuImageButton2.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton2, " Mục tiêu chu kì");
      this.bunifuImageButton2.Zoom = 0;
      this.lblMuctieuChuki.AutoSize = true;
      this.lblMuctieuChuki.Cursor = Cursors.Default;
      this.lblMuctieuChuki.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.lblMuctieuChuki.ForeColor = Color.DimGray;
      this.lblMuctieuChuki.Location = new Point(25, 6);
      this.lblMuctieuChuki.Name = "lblMuctieuChuki";
      this.lblMuctieuChuki.Size = new Size(46, 16);
      this.lblMuctieuChuki.TabIndex = 16;
      this.lblMuctieuChuki.Text = "0 VND";
      this.lblMuctieuChuki.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblMuctieuChuki, " Mục tiêu chu kỳ hiện tại của bạn");
      this.btnKhoachuky.BackColor = Color.Teal;
      this.btnKhoachuky.Cursor = Cursors.Hand;
      this.btnKhoachuky.FlatStyle = FlatStyle.Flat;
      this.btnKhoachuky.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnKhoachuky.ForeColor = Color.White;
      this.btnKhoachuky.Location = new Point(304, 14);
      this.btnKhoachuky.Margin = new Padding(3, 0, 3, 0);
      this.btnKhoachuky.Name = "btnKhoachuky";
      this.btnKhoachuky.Size = new Size(63, 24);
      this.btnKhoachuky.TabIndex = 1;
      this.btnKhoachuky.Text = "Khóa";
      this.btnKhoachuky.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnKhoachuky, "Khóa chu kỳ này(Bạn sẽ không thể thêm xóa hay chỉnh sửa thông tin của chu kỳ)");
      this.btnKhoachuky.UseVisualStyleBackColor = false;
      this.btnKhoachuky.Click += new EventHandler(this.button1_Click);
      this.cbbChukidanh.BackColor = Color.Teal;
      this.cbbChukidanh.Cursor = Cursors.Hand;
      this.cbbChukidanh.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbChukidanh.FlatStyle = FlatStyle.Popup;
      this.cbbChukidanh.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.cbbChukidanh.ForeColor = Color.White;
      this.cbbChukidanh.Location = new Point(47, 14);
      this.cbbChukidanh.Name = "cbbChukidanh";
      this.cbbChukidanh.Size = new Size(257, 24);
      this.cbbChukidanh.TabIndex = 0;
      this.cbbChukidanh.SelectedIndexChanged += new EventHandler(this.ComboBox1SelectedIndexChanged);
      this.btnXoa.BackColor = Color.Teal;
      this.btnXoa.Cursor = Cursors.Hand;
      this.btnXoa.FlatStyle = FlatStyle.Flat;
      this.btnXoa.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXoa.ForeColor = Color.White;
      this.btnXoa.Location = new Point(430, 14);
      this.btnXoa.Margin = new Padding(3, 0, 3, 0);
      this.btnXoa.Name = "btnXoa";
      this.btnXoa.Size = new Size(63, 24);
      this.btnXoa.TabIndex = 3;
      this.btnXoa.Text = "Xóa";
      this.btnXoa.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnXoa, "Xóa chu kì này");
      this.btnXoa.UseVisualStyleBackColor = true;
      this.btnXoa.Click += new EventHandler(this.Button4Click);
      this.btnChotso.BackColor = Color.Yellow;
      this.btnChotso.Cursor = Cursors.Hand;
      this.btnChotso.FlatStyle = FlatStyle.Flat;
      this.btnChotso.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnChotso.ForeColor = Color.Red;
      this.btnChotso.Location = new Point(493, 14);
      this.btnChotso.Margin = new Padding(3, 0, 3, 0);
      this.btnChotso.Name = "btnChotso";
      this.btnChotso.Size = new Size(63, 24);
      this.btnChotso.TabIndex = 4;
      this.btnChotso.Text = "Chốt số";
      this.btnChotso.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnChotso, "Chốt số hôm nay");
      this.btnChotso.UseVisualStyleBackColor = false;
      this.btnChotso.Click += new EventHandler(this.BtnChotsoClick);
      this.button4.BackColor = Color.Teal;
      this.button4.Cursor = Cursors.Hand;
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button4.ForeColor = Color.White;
      this.button4.Location = new Point(367, 14);
      this.button4.Margin = new Padding(3, 0, 3, 0);
      this.button4.Name = "button4";
      this.button4.Size = new Size(63, 24);
      this.button4.TabIndex = 2;
      this.button4.Text = "Thêm";
      this.button4.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.button4, "Thêm mới một chu kì");
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.Button4Click1);
      this.label1.AutoSize = true;
      this.label1.ForeColor = Color.DimGray;
      this.label1.Location = new Point(2, 19);
      this.label1.Name = "label1";
      this.label1.Size = new Size(48, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Chu kì :";
      this.toolTip1.AutomaticDelay = 200;
      this.toolTip1.AutoPopDelay = 4000;
      this.toolTip1.InitialDelay = 200;
      this.toolTip1.ReshowDelay = 100;
      this.toolTip1.Popup += new PopupEventHandler(this.toolTip1_Popup);
      this.lblLoinhuanDauTu_DacBiet.Cursor = Cursors.Hand;
      this.lblLoinhuanDauTu_DacBiet.Dock = DockStyle.Bottom;
      this.lblLoinhuanDauTu_DacBiet.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLoinhuanDauTu_DacBiet.ForeColor = Color.DimGray;
      this.lblLoinhuanDauTu_DacBiet.Location = new Point(0, 33);
      this.lblLoinhuanDauTu_DacBiet.Name = "lblLoinhuanDauTu_DacBiet";
      this.lblLoinhuanDauTu_DacBiet.Size = new Size(160, 25);
      this.lblLoinhuanDauTu_DacBiet.TabIndex = 25;
      this.lblLoinhuanDauTu_DacBiet.Text = "0%";
      this.lblLoinhuanDauTu_DacBiet.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblLoinhuanDauTu_DacBiet, "Tỉ lệ lợi nhuận đầu tư của đặc biệt");
      this.lblTongthuTuDacBiet.Cursor = Cursors.Hand;
      this.lblTongthuTuDacBiet.Dock = DockStyle.Bottom;
      this.lblTongthuTuDacBiet.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTongthuTuDacBiet.ForeColor = Color.DimGray;
      this.lblTongthuTuDacBiet.Location = new Point(0, 33);
      this.lblTongthuTuDacBiet.Name = "lblTongthuTuDacBiet";
      this.lblTongthuTuDacBiet.Size = new Size(160, 25);
      this.lblTongthuTuDacBiet.TabIndex = 18;
      this.lblTongthuTuDacBiet.Text = "0 VND";
      this.lblTongthuTuDacBiet.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthuTuDacBiet, "Tổng lợi nhuận từ đặc biệt trong chu kỳ");
      this.lblLoinhuanDauTu_Loto.Cursor = Cursors.Hand;
      this.lblLoinhuanDauTu_Loto.Dock = DockStyle.Bottom;
      this.lblLoinhuanDauTu_Loto.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLoinhuanDauTu_Loto.ForeColor = Color.DimGray;
      this.lblLoinhuanDauTu_Loto.Location = new Point(0, 33);
      this.lblLoinhuanDauTu_Loto.Name = "lblLoinhuanDauTu_Loto";
      this.lblLoinhuanDauTu_Loto.Size = new Size(160, 25);
      this.lblLoinhuanDauTu_Loto.TabIndex = 17;
      this.lblLoinhuanDauTu_Loto.Text = "0%";
      this.lblLoinhuanDauTu_Loto.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblLoinhuanDauTu_Loto, "Tỉ lệ lợi nhuận đầu tư của lô tô");
      this.lblTongthutuLoto.Cursor = Cursors.Hand;
      this.lblTongthutuLoto.Dock = DockStyle.Bottom;
      this.lblTongthutuLoto.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTongthutuLoto.ForeColor = Color.DimGray;
      this.lblTongthutuLoto.Location = new Point(0, 33);
      this.lblTongthutuLoto.Name = "lblTongthutuLoto";
      this.lblTongthutuLoto.Size = new Size(160, 25);
      this.lblTongthutuLoto.TabIndex = 16;
      this.lblTongthutuLoto.Text = "0 VND";
      this.lblTongthutuLoto.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthutuLoto, "Tổng lợi nhuận từ lô tô trong chu kỳ");
      this.lblTongthucuaChuki.Cursor = Cursors.Hand;
      this.lblTongthucuaChuki.Dock = DockStyle.Bottom;
      this.lblTongthucuaChuki.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTongthucuaChuki.ForeColor = Color.DimGray;
      this.lblTongthucuaChuki.Location = new Point(0, 33);
      this.lblTongthucuaChuki.Name = "lblTongthucuaChuki";
      this.lblTongthucuaChuki.Size = new Size(160, 25);
      this.lblTongthucuaChuki.TabIndex = 15;
      this.lblTongthucuaChuki.Text = "0 VND";
      this.lblTongthucuaChuki.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthucuaChuki, " Tổng số lãi của chu kỳ đang trọn");
      this.lblLoinhuandauTuChuki.Cursor = Cursors.Hand;
      this.lblLoinhuandauTuChuki.Dock = DockStyle.Bottom;
      this.lblLoinhuandauTuChuki.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLoinhuandauTuChuki.ForeColor = Color.DimGray;
      this.lblLoinhuandauTuChuki.Location = new Point(0, 32);
      this.lblLoinhuandauTuChuki.Name = "lblLoinhuandauTuChuki";
      this.lblLoinhuandauTuChuki.Size = new Size(160, 26);
      this.lblLoinhuandauTuChuki.TabIndex = 16;
      this.lblLoinhuandauTuChuki.Text = "0%";
      this.lblLoinhuandauTuChuki.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblLoinhuandauTuChuki, " Tỉ lệ lợi nhuận đầu tư của chu kỳ");
      this.lblTongthuCuaThang.Cursor = Cursors.Hand;
      this.lblTongthuCuaThang.Dock = DockStyle.Bottom;
      this.lblTongthuCuaThang.Font = new Font("Arial", 12f, FontStyle.Bold);
      this.lblTongthuCuaThang.ForeColor = Color.DimGray;
      this.lblTongthuCuaThang.Location = new Point(0, 33);
      this.lblTongthuCuaThang.Name = "lblTongthuCuaThang";
      this.lblTongthuCuaThang.Size = new Size(160, 25);
      this.lblTongthuCuaThang.TabIndex = 19;
      this.lblTongthuCuaThang.Text = "0 VND";
      this.lblTongthuCuaThang.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthuCuaThang, "Tổng số lãi của tháng trong chu kỳ hiện tại");
      this.lblTongthuCuaThang1.Cursor = Cursors.Hand;
      this.lblTongthuCuaThang1.Dock = DockStyle.Bottom;
      this.lblTongthuCuaThang1.Font = new Font("Arial", 9.75f);
      this.lblTongthuCuaThang1.ForeColor = Color.Gray;
      this.lblTongthuCuaThang1.Location = new Point(0, 58);
      this.lblTongthuCuaThang1.Name = "lblTongthuCuaThang1";
      this.lblTongthuCuaThang1.Size = new Size(160, 16);
      this.lblTongthuCuaThang1.TabIndex = 14;
      this.lblTongthuCuaThang1.Text = "tổng lãi của tháng";
      this.lblTongthuCuaThang1.TextAlign = ContentAlignment.BottomCenter;
      this.timer1.Interval = 50;
      this.timer1.Tick += new EventHandler(this.Timer1Tick);
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.BackgroundWorker1DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackgroundWorker1RunWorkerCompleted);
      this.backgroundWorker2.DoWork += new DoWorkEventHandler(this.BackgroundWorker2DoWork);
      this.backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackgroundWorker2RunWorkerCompleted);
      this.panel1.Controls.Add((Control) this.panel3);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 48);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 534);
      this.panel1.TabIndex = 4;
      this.panel3.Controls.Add((Control) this.picLoading);
      this.panel3.Controls.Add((Control) this.dtg_Ketqua);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1100, 443);
      this.panel3.TabIndex = 6;
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(608, 225);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 57;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToOrderColumns = true;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.BackgroundColor = Color.White;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
      gridViewCellStyle1.NullValue = (object) "#####";
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 26;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.stt, (DataGridViewColumn) this.sothutu, (DataGridViewColumn) this.nguonLoto, (DataGridViewColumn) this.soChot, (DataGridViewColumn) this.tongDiem, (DataGridViewColumn) this.soLove, (DataGridViewColumn) this.soVon, (DataGridViewColumn) this.soLai, (DataGridViewColumn) this.hinhThucDanh, (DataGridViewColumn) this.ngayDanh, (DataGridViewColumn) this.duNo, (DataGridViewColumn) this.ngayChot, (DataGridViewColumn) this.colTrong);
      this.dtg_Ketqua.ContextMenuStrip = this.contextMenuStrip1;
      this.dtg_Ketqua.Cursor = Cursors.Hand;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
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
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtg_Ketqua.RowTemplate.Height = 32;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(1100, 443);
      this.dtg_Ketqua.TabIndex = 0;
      this.dtg_Ketqua.CellDoubleClick += new DataGridViewCellEventHandler(this.DtgKetquaCellDoubleClick1);
      this.dtg_Ketqua.RowEnter += new DataGridViewCellEventHandler(this.DtgKetquaRowEnter1);
      this.dtg_Ketqua.KeyDown += new KeyEventHandler(this.DtgKetquaKeyDown1);
      this.dtg_Ketqua.MouseDown += new MouseEventHandler(this.DtgKetquaMouseDown);
      this.stt.DataPropertyName = "Stt";
      this.stt.HeaderText = "stt";
      this.stt.Name = "stt";
      this.stt.ReadOnly = true;
      this.stt.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.stt.Visible = false;
      this.sothutu.DataPropertyName = "Sothutu";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle3.ForeColor = Color.DimGray;
      this.sothutu.DefaultCellStyle = gridViewCellStyle3;
      this.sothutu.HeaderText = "STT ";
      this.sothutu.Name = "sothutu";
      this.sothutu.ReadOnly = true;
      this.sothutu.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.sothutu.ToolTipText = "Số thứ tự";
      this.sothutu.Width = 50;
      this.nguonLoto.DataPropertyName = "Nguonloto";
      this.nguonLoto.HeaderText = "Nguồn Loto";
      this.nguonLoto.Name = "nguonLoto";
      this.nguonLoto.ReadOnly = true;
      this.nguonLoto.ToolTipText = "Số bạn chốt hôm nay được lấy từ nguồn nào";
      this.soChot.DataPropertyName = "SoChot";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle4.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.Black;
      this.soChot.DefaultCellStyle = gridViewCellStyle4;
      this.soChot.HeaderText = "Bộ số";
      this.soChot.Name = "soChot";
      this.soChot.ReadOnly = true;
      this.soChot.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.soChot.ToolTipText = "Số mà bạn chốt";
      this.soChot.Width = 130;
      this.tongDiem.DataPropertyName = "tongDiem";
      this.tongDiem.HeaderText = "Tổng điểm";
      this.tongDiem.Name = "tongDiem";
      this.tongDiem.ReadOnly = true;
      this.tongDiem.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.tongDiem.ToolTipText = "Tổng số điểm đánh";
      this.tongDiem.Width = 80;
      this.soLove.DataPropertyName = "SoLove";
      this.soLove.HeaderText = "Về(điểm)";
      this.soLove.Name = "soLove";
      this.soLove.ReadOnly = true;
      this.soLove.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.soLove.ToolTipText = "Số điểm được ăn hôm nay";
      this.soLove.Width = 70;
      this.soVon.DataPropertyName = "SoVon";
      this.soVon.HeaderText = "Vốn";
      this.soVon.Name = "soVon";
      this.soVon.ReadOnly = true;
      this.soVon.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.soVon.ToolTipText = "Số vốn bỏ ra";
      this.soVon.Width = 135;
      this.soLai.DataPropertyName = "SoLai";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = Color.Red;
      this.soLai.DefaultCellStyle = gridViewCellStyle5;
      this.soLai.HeaderText = "Lãi";
      this.soLai.Name = "soLai";
      this.soLai.ReadOnly = true;
      this.soLai.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.soLai.ToolTipText = "Số lãi nhận được";
      this.soLai.Width = 135;
      this.hinhThucDanh.DataPropertyName = "HinhThucDanh";
      gridViewCellStyle6.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.hinhThucDanh.DefaultCellStyle = gridViewCellStyle6;
      this.hinhThucDanh.HeaderText = "Chốt";
      this.hinhThucDanh.Name = "hinhThucDanh";
      this.hinhThucDanh.ReadOnly = true;
      this.hinhThucDanh.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.hinhThucDanh.Width = 105;
      this.ngayDanh.DataPropertyName = "NgayDanh";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle7.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = Color.Red;
      this.ngayDanh.DefaultCellStyle = gridViewCellStyle7;
      this.ngayDanh.HeaderText = "Mô tả";
      this.ngayDanh.Name = "ngayDanh";
      this.ngayDanh.ReadOnly = true;
      this.ngayDanh.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.ngayDanh.ToolTipText = "Mô tả về hình thức chốt số của bạn";
      this.duNo.DataPropertyName = "DuNo";
      gridViewCellStyle8.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle8.ForeColor = Color.Red;
      this.duNo.DefaultCellStyle = gridViewCellStyle8;
      this.duNo.HeaderText = "Dư nợ";
      this.duNo.Name = "duNo";
      this.duNo.ReadOnly = true;
      this.duNo.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.duNo.ToolTipText = "Số tiền bạn và chủ lô còn nợ nhau";
      this.ngayChot.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.ngayChot.DataPropertyName = "NgayChot";
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle9.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle9.ForeColor = Color.Red;
      this.ngayChot.DefaultCellStyle = gridViewCellStyle9;
      this.ngayChot.HeaderText = "Ngày tháng";
      this.ngayChot.Name = "ngayChot";
      this.ngayChot.ReadOnly = true;
      this.ngayChot.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.colTrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.colTrong.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.chốtSốToolStripMenuItem,
        (ToolStripItem) this.chỉnhSửaToolStripMenuItem,
        (ToolStripItem) this.xóaToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(138, 70);
      this.contextMenuStrip1.Opening += new CancelEventHandler(this.ContextMenuStrip1Opening);
      this.chốtSốToolStripMenuItem.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.chốtSốToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("chốtSốToolStripMenuItem.Image");
      this.chốtSốToolStripMenuItem.Name = "chốtSốToolStripMenuItem";
      this.chốtSốToolStripMenuItem.Size = new Size(137, 22);
      this.chốtSốToolStripMenuItem.Text = "Tự tin chốt";
      this.chốtSốToolStripMenuItem.Click += new EventHandler(this.ChốtSốToolStripMenuItemClick);
      this.chỉnhSửaToolStripMenuItem.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.chỉnhSửaToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("chỉnhSửaToolStripMenuItem.Image");
      this.chỉnhSửaToolStripMenuItem.Name = "chỉnhSửaToolStripMenuItem";
      this.chỉnhSửaToolStripMenuItem.Size = new Size(137, 22);
      this.chỉnhSửaToolStripMenuItem.Text = "Chỉnh sửa";
      this.chỉnhSửaToolStripMenuItem.Click += new EventHandler(this.ChỉnhSửaToolStripMenuItemClick);
      this.xóaToolStripMenuItem.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.xóaToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("xóaToolStripMenuItem.Image");
      this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
      this.xóaToolStripMenuItem.Size = new Size(137, 22);
      this.xóaToolStripMenuItem.Text = "Xóa";
      this.xóaToolStripMenuItem.Click += new EventHandler(this.XóaToolStripMenuItemClick);
      this.panel2.BackColor = Color.White;
      this.panel2.Controls.Add((Control) this.pnbot7);
      this.panel2.Controls.Add((Control) this.pnbot6);
      this.panel2.Controls.Add((Control) this.pnbot5);
      this.panel2.Controls.Add((Control) this.pnbot4);
      this.panel2.Controls.Add((Control) this.pnbot3);
      this.panel2.Controls.Add((Control) this.pnbot2);
      this.panel2.Controls.Add((Control) this.pnbot1);
      this.panel2.Controls.Add((Control) this.label27);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 443);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 91);
      this.panel2.TabIndex = 5;
      this.pnbot7.Controls.Add((Control) this.bunifuImageButton10);
      this.pnbot7.Controls.Add((Control) this.lblLoinhuanDauTu_DacBiet);
      this.pnbot7.Controls.Add((Control) this.label39);
      this.pnbot7.Location = new Point(974, 4);
      this.pnbot7.Name = "pnbot7";
      this.pnbot7.Size = new Size(160, 74);
      this.pnbot7.TabIndex = 58;
      this.bunifuImageButton10.BackColor = Color.Transparent;
      this.bunifuImageButton10.Cursor = Cursors.Hand;
      this.bunifuImageButton10.Dock = DockStyle.Bottom;
      this.bunifuImageButton10.Image = (Image) componentResourceManager.GetObject("bunifuImageButton10.Image");
      this.bunifuImageButton10.ImageActive = (Image) null;
      this.bunifuImageButton10.Location = new Point(0, 5);
      this.bunifuImageButton10.Name = "bunifuImageButton10";
      this.bunifuImageButton10.Size = new Size(160, 28);
      this.bunifuImageButton10.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton10.TabIndex = 12;
      this.bunifuImageButton10.TabStop = false;
      this.bunifuImageButton10.Zoom = 0;
      this.label39.Cursor = Cursors.Hand;
      this.label39.Dock = DockStyle.Bottom;
      this.label39.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label39.ForeColor = Color.Gray;
      this.label39.Location = new Point(0, 58);
      this.label39.Name = "label39";
      this.label39.Size = new Size(160, 16);
      this.label39.TabIndex = 24;
      this.label39.Text = "lợi nhuận đầu tư";
      this.label39.TextAlign = ContentAlignment.BottomCenter;
      this.pnbot6.Controls.Add((Control) this.bunifuImageButton9);
      this.pnbot6.Controls.Add((Control) this.lblTongthuTuDacBiet);
      this.pnbot6.Controls.Add((Control) this.label37);
      this.pnbot6.Location = new Point(812, 4);
      this.pnbot6.Name = "pnbot6";
      this.pnbot6.Size = new Size(160, 74);
      this.pnbot6.TabIndex = 58;
      this.bunifuImageButton9.BackColor = Color.Transparent;
      this.bunifuImageButton9.Cursor = Cursors.Hand;
      this.bunifuImageButton9.Dock = DockStyle.Bottom;
      this.bunifuImageButton9.Image = (Image) componentResourceManager.GetObject("bunifuImageButton9.Image");
      this.bunifuImageButton9.ImageActive = (Image) null;
      this.bunifuImageButton9.Location = new Point(0, 2);
      this.bunifuImageButton9.Name = "bunifuImageButton9";
      this.bunifuImageButton9.Size = new Size(160, 31);
      this.bunifuImageButton9.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton9.TabIndex = 11;
      this.bunifuImageButton9.TabStop = false;
      this.bunifuImageButton9.Zoom = 0;
      this.label37.Cursor = Cursors.Hand;
      this.label37.Dock = DockStyle.Bottom;
      this.label37.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label37.ForeColor = Color.Gray;
      this.label37.Location = new Point(0, 58);
      this.label37.Name = "label37";
      this.label37.Size = new Size(160, 16);
      this.label37.TabIndex = 23;
      this.label37.Text = "tổng thu từ đặc biệt";
      this.label37.TextAlign = ContentAlignment.BottomCenter;
      this.pnbot5.Controls.Add((Control) this.bunifuImageButton8);
      this.pnbot5.Controls.Add((Control) this.lblLoinhuanDauTu_Loto);
      this.pnbot5.Controls.Add((Control) this.label35);
      this.pnbot5.Location = new Point(650, 4);
      this.pnbot5.Name = "pnbot5";
      this.pnbot5.Size = new Size(160, 74);
      this.pnbot5.TabIndex = 58;
      this.bunifuImageButton8.BackColor = Color.Transparent;
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Dock = DockStyle.Bottom;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(0, 5);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(160, 28);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 27;
      this.bunifuImageButton8.TabStop = false;
      this.bunifuImageButton8.Zoom = 0;
      this.label35.Cursor = Cursors.Hand;
      this.label35.Dock = DockStyle.Bottom;
      this.label35.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label35.ForeColor = Color.Gray;
      this.label35.Location = new Point(0, 58);
      this.label35.Name = "label35";
      this.label35.Size = new Size(160, 16);
      this.label35.TabIndex = 22;
      this.label35.Text = "lợi nhuận đầu tư";
      this.label35.TextAlign = ContentAlignment.BottomCenter;
      this.pnbot4.Controls.Add((Control) this.bunifuImageButton6);
      this.pnbot4.Controls.Add((Control) this.lblTongthutuLoto);
      this.pnbot4.Controls.Add((Control) this.label31);
      this.pnbot4.Location = new Point(488, 4);
      this.pnbot4.Name = "pnbot4";
      this.pnbot4.Size = new Size(160, 74);
      this.pnbot4.TabIndex = 58;
      this.bunifuImageButton6.BackColor = Color.Transparent;
      this.bunifuImageButton6.Cursor = Cursors.Hand;
      this.bunifuImageButton6.Dock = DockStyle.Bottom;
      this.bunifuImageButton6.Image = (Image) componentResourceManager.GetObject("bunifuImageButton6.Image");
      this.bunifuImageButton6.ImageActive = (Image) null;
      this.bunifuImageButton6.Location = new Point(0, 3);
      this.bunifuImageButton6.Name = "bunifuImageButton6";
      this.bunifuImageButton6.Size = new Size(160, 30);
      this.bunifuImageButton6.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton6.TabIndex = 10;
      this.bunifuImageButton6.TabStop = false;
      this.bunifuImageButton6.Zoom = 0;
      this.label31.Cursor = Cursors.Hand;
      this.label31.Dock = DockStyle.Bottom;
      this.label31.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label31.ForeColor = Color.Gray;
      this.label31.Location = new Point(0, 58);
      this.label31.Name = "label31";
      this.label31.Size = new Size(160, 16);
      this.label31.TabIndex = 21;
      this.label31.Text = "tổng thu từ lô tô";
      this.label31.TextAlign = ContentAlignment.BottomCenter;
      this.pnbot3.Controls.Add((Control) this.bunifuImageButton1);
      this.pnbot3.Controls.Add((Control) this.lblLoinhuandauTuChuki);
      this.pnbot3.Controls.Add((Control) this.label6);
      this.pnbot3.Location = new Point(326, 4);
      this.pnbot3.Name = "pnbot3";
      this.pnbot3.Size = new Size(160, 74);
      this.pnbot3.TabIndex = 58;
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Cursor = Cursors.Hand;
      this.bunifuImageButton1.Dock = DockStyle.Bottom;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(0, 7);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(160, 25);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 29;
      this.bunifuImageButton1.TabStop = false;
      this.bunifuImageButton1.Zoom = 0;
      this.label6.Cursor = Cursors.Hand;
      this.label6.Dock = DockStyle.Bottom;
      this.label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Gray;
      this.label6.Location = new Point(0, 58);
      this.label6.Name = "label6";
      this.label6.Size = new Size(160, 16);
      this.label6.TabIndex = 21;
      this.label6.Text = "lợi nhuận đầu tư chu kì";
      this.label6.TextAlign = ContentAlignment.BottomCenter;
      this.pnbot2.Controls.Add((Control) this.bunifuImageButton7);
      this.pnbot2.Controls.Add((Control) this.lblTongthucuaChuki);
      this.pnbot2.Controls.Add((Control) this.label33);
      this.pnbot2.Location = new Point(165, 4);
      this.pnbot2.Name = "pnbot2";
      this.pnbot2.Size = new Size(160, 74);
      this.pnbot2.TabIndex = 58;
      this.bunifuImageButton7.BackColor = Color.Transparent;
      this.bunifuImageButton7.Cursor = Cursors.Hand;
      this.bunifuImageButton7.Dock = DockStyle.Bottom;
      this.bunifuImageButton7.Image = (Image) componentResourceManager.GetObject("bunifuImageButton7.Image");
      this.bunifuImageButton7.ImageActive = (Image) null;
      this.bunifuImageButton7.Location = new Point(0, 3);
      this.bunifuImageButton7.Name = "bunifuImageButton7";
      this.bunifuImageButton7.Size = new Size(160, 30);
      this.bunifuImageButton7.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton7.TabIndex = 13;
      this.bunifuImageButton7.TabStop = false;
      this.bunifuImageButton7.Zoom = 0;
      this.label33.Cursor = Cursors.Hand;
      this.label33.Dock = DockStyle.Bottom;
      this.label33.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label33.ForeColor = Color.Gray;
      this.label33.Location = new Point(0, 58);
      this.label33.Name = "label33";
      this.label33.Size = new Size(160, 16);
      this.label33.TabIndex = 20;
      this.label33.Text = "tổng thu của chu kì";
      this.label33.TextAlign = ContentAlignment.BottomCenter;
      this.pnbot1.Controls.Add((Control) this.bunifuImageButton5);
      this.pnbot1.Controls.Add((Control) this.lblTongthuCuaThang);
      this.pnbot1.Controls.Add((Control) this.lblTongthuCuaThang1);
      this.pnbot1.Location = new Point(3, 4);
      this.pnbot1.Name = "pnbot1";
      this.pnbot1.Size = new Size(160, 74);
      this.pnbot1.TabIndex = 58;
      this.bunifuImageButton5.BackColor = Color.Transparent;
      this.bunifuImageButton5.Cursor = Cursors.Hand;
      this.bunifuImageButton5.Dock = DockStyle.Bottom;
      this.bunifuImageButton5.Image = (Image) componentResourceManager.GetObject("bunifuImageButton5.Image");
      this.bunifuImageButton5.ImageActive = (Image) null;
      this.bunifuImageButton5.Location = new Point(0, 4);
      this.bunifuImageButton5.Name = "bunifuImageButton5";
      this.bunifuImageButton5.Size = new Size(160, 29);
      this.bunifuImageButton5.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton5.TabIndex = 9;
      this.bunifuImageButton5.TabStop = false;
      this.bunifuImageButton5.Zoom = 0;
      this.label27.BackColor = Color.FromArgb((int) byte.MaxValue, 185, 1);
      this.label27.Dock = DockStyle.Top;
      this.label27.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label27.ForeColor = Color.White;
      this.label27.Location = new Point(0, 0);
      this.label27.Margin = new Padding(3, 5, 3, 0);
      this.label27.Name = "label27";
      this.label27.Size = new Size(1100, 1);
      this.label27.TabIndex = 28;
      this.label27.TextAlign = ContentAlignment.TopCenter;
      this.timeLoading.Enabled = true;
      this.timeLoading.Tick += new EventHandler(this.timeLoading_Tick);
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.Gray;
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.groupBox1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabVaotienChukiDanh);
      this.Size = new Size(1100, 582);
      this.Load += new EventHandler(this.TabVaotienChukiDanhLoad);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.pnTop4.ResumeLayout(false);
      this.pnTop4.PerformLayout();
      this.bunifuImageButton11.EndInit();
      this.pnTop3.ResumeLayout(false);
      this.pnTop3.PerformLayout();
      this.bunifuImageButton3.EndInit();
      this.pnTop2.ResumeLayout(false);
      this.pnTop2.PerformLayout();
      this.bunifuImageButton4.EndInit();
      this.pnTop1.ResumeLayout(false);
      this.pnTop1.PerformLayout();
      this.bunifuImageButton2.EndInit();
      this.panel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.pnbot7.ResumeLayout(false);
      this.bunifuImageButton10.EndInit();
      this.pnbot6.ResumeLayout(false);
      this.bunifuImageButton9.EndInit();
      this.pnbot5.ResumeLayout(false);
      this.bunifuImageButton8.EndInit();
      this.pnbot4.ResumeLayout(false);
      this.bunifuImageButton6.EndInit();
      this.pnbot3.ResumeLayout(false);
      this.bunifuImageButton1.EndInit();
      this.pnbot2.ResumeLayout(false);
      this.bunifuImageButton7.EndInit();
      this.pnbot1.ResumeLayout(false);
      this.bunifuImageButton5.EndInit();
      this.ResumeLayout(false);
    }

    public class ValueControl
    {
      public Decimal Tonglaithangnay { get; set; }

      public string TonglaichukiHientai { get; set; }

      public string TongVontrongchuki { get; set; }

      public string LoinhuanDauTuCuaChuKi { get; set; }

      public string MuctieuChuKi { get; set; }

      public string HoanThanhMucTieu { get; set; }

      public string MucTieuConLai { get; set; }

      public Decimal TongThuTuLoto { get; set; }

      public Decimal TongVonTuLoto { get; set; }

      public Decimal TongThuTuDacbiet { get; set; }

      public Decimal TongVonTuDacbiet { get; set; }

      public Decimal LoiNhuanDauTuLoto { get; set; }

      public Decimal LoiNhuanDauTuDacBiet { get; set; }

      public List<TbLoOffline> ListData { get; set; }
    }
  }
}
