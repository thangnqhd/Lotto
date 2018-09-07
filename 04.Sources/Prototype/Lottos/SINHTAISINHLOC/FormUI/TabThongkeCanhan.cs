// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabThongkeCanhan
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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabThongkeCanhan : UserControl
  {
    public static int LoadLaiForm = 1;
    private IContainer components = (IContainer) null;
    private tbChukidanh _objChukidanh;
    private readonly TbLoOffline _objLoOffline;
    private DataTable _dt;
    private readonly TabThongkeCanhan.ValueControl _objValue;
    private List<TbLoOffline> _listData;
    private int _month;
    private int _year;
    private int _thangTruoc;
    private int _namTruoc;
    private int _maChuki;
    private int _maChotLoto;
    private DataGridView.HitTestInfo _myHitTestDown;
    private Panel panel2;
    private BunifuElipse bunifuElipse1;
    private Panel pn1;
    private Label lblLoinhuandautu_Thang;
    private Label label5;
    private Label lblTonglaiThangtruoc;
    private Label LabelTonglaiThangtr;
    private Label lblTonglaiThangnay;
    private Label label1;
    private Panel pn2;
    private Label lblLoinhuanDautu_Chuki;
    private Label label8;
    private Label lblTongvonchukiHientai;
    private Label label10;
    private Label lblTonglaichukiHientai;
    private Label label12;
    private Panel pn3;
    private Label lblMuctieuConlai;
    private Label label14;
    private Label lblDahoanThanhMuctieu;
    private Label label16;
    private Label lblMuctieuChuki;
    private Label label18;
    private Panel pn4;
    private Label lblBacHienCo;
    private Label label20;
    private Label lblVanghienco;
    private Label label22;
    private Label lblThoihanSudung;
    private Label label24;
    private BunifuImageButton bunifuImageButton1;
    private BunifuImageButton bunifuImageButton3;
    private BunifuImageButton bunifuImageButton2;
    private BunifuImageButton bunifuImageButton4;
    private Label label29;
    private Label lblTongthuCuaNam;
    private BunifuImageButton bunifuImageButton5;
    private Label label31;
    private Label lblTongthutuLoto;
    private BunifuImageButton bunifuImageButton6;
    private Label label37;
    private Label label35;
    private Label label33;
    private Label lblTongthuTuDacBiet;
    private Label lblLoinhuanDauTu_Loto;
    private Label lblTrungBinhMoiChuKi;
    private BunifuImageButton bunifuImageButton7;
    private BunifuImageButton bunifuImageButton9;
    private Label label39;
    private Label lblLoinhuanDauTu_DacBiet;
    private BunifuImageButton bunifuImageButton10;
    private BackgroundWorker backgroundWorkerXuly;
    private Timer timer1;
    private Panel panel7;
    private Label label27;
    private Label label26;
    private DataGridView dtg_Ketqua;
    private ToolTip toolTip1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem chỉnhSửaToolStripMenuItem;
    private ToolStripMenuItem xóaToolStripMenuItem;
    private ToolStripMenuItem chốtSốToolStripMenuItem;
    private PictureBox picLoading;
    private Panel pn5;
    private Panel pn6;
    private Panel pn9;
    private Panel pn8;
    private Panel pn7;
    private Panel pn10;
    private BunifuImageButton bunifuImageButton8;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn sothutu;
    private DataGridViewTextBoxColumn nguonloto;
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

    public TabThongkeCanhan()
    {
      this.InitializeComponent();
      TabThongkeCanhan.LoadLaiForm = 1;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Arial"), 9f, FontStyle.Regular);
      this.dtg_Ketqua.AllowUserToOrderColumns = true;
      this._objLoOffline = new TbLoOffline();
      this._objChukidanh = new tbChukidanh();
      this._objValue = new TabThongkeCanhan.ValueControl();
      this._listData = new List<TbLoOffline>();
      this._dt = new DataTable();
      this.EditLocaltionPanel();
    }

    private void EditLocaltionPanel()
    {
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      int num1 = (FMain.ChieurongForm - 14 - 12 - 8) / 4;
      this.pn1.Location = new Point(7, this.pn1.Location.Y);
      this.pn1.Width = num1;
      this.pn2.Location = new Point(num1 + 7 + 4, this.pn2.Location.Y);
      this.pn2.Width = num1;
      this.pn3.Location = new Point(num1 * 2 + 7 + 8, this.pn3.Location.Y);
      this.pn3.Width = num1;
      this.pn4.Location = new Point(num1 * 3 + 7 + 12, this.pn4.Location.Y);
      this.pn4.Width = num1;
      int num2 = (FMain.ChieurongForm - 14 - 20 - 15) / 6;
      this.pn5.Location = new Point(7, this.pn5.Location.Y);
      this.pn5.Width = num2;
      this.pn6.Location = new Point(num2 + 7 + 4, this.pn6.Location.Y);
      this.pn6.Width = num2;
      this.pn7.Location = new Point(num2 * 2 + 7 + 4, this.pn7.Location.Y);
      this.pn7.Width = num2;
      this.pn8.Location = new Point(num2 * 3 + 7 + 8, this.pn8.Location.Y);
      this.pn8.Width = num2;
      this.pn9.Location = new Point(num2 * 4 + 7 + 12, this.pn9.Location.Y);
      this.pn9.Width = num2;
      this.pn10.Location = new Point(num2 * 5 + 7 + 16, this.pn10.Location.Y);
      this.pn10.Width = num2;
    }

    private void UpdateValue()
    {
      if (string.IsNullOrEmpty(this._objChukidanh.donviTien))
        this._objChukidanh.donviTien = "VND";
      this.lblTonglaiThangnay.Text = ClMain.QuiDoiSoLuong(this._objValue.Tonglaithangnay.ToString(), this._objChukidanh.donviTien);
      this.lblTonglaiThangtruoc.Text = ClMain.QuiDoiSoLuong(this._objValue.TonglaiThangTruoc.ToString(), this._objChukidanh.donviTien);
      this.lblLoinhuandautu_Thang.Text = string.Format("{0:0.00}", (object) this._objValue.LoinhuanDauTuCuathang) + Resources.TabThongkeCanhan_UpdateValue__;
      this.lblTonglaichukiHientai.Text = ClMain.QuiDoiSoLuong(this._objValue.TonglaichukiHientai.ToString(), this._objChukidanh.donviTien);
      this.lblTongvonchukiHientai.Text = ClMain.QuiDoiSoLuong(this._objValue.TongVontrongchuki.ToString(), this._objChukidanh.donviTien);
      this.lblLoinhuanDautu_Chuki.Text = string.Format("{0:0.00}", (object) this._objValue.LoinhuanDauTuCuaChuKi) + Resources.TabThongkeCanhan_UpdateValue__;
      this.lblMuctieuChuki.Text = ClMain.QuiDoiSoLuong(this._objValue.MuctieuChuKi.ToString(), this._objChukidanh.donviTien);
      this.lblDahoanThanhMuctieu.Text = string.Format("{0:0.00}", (object) this._objValue.HoanThanhMucTieu) + Resources.TabThongkeCanhan_UpdateValue__;
      this.lblMuctieuConlai.Text = string.Format("{0:0.00}", (object) this._objValue.MucTieuConLai) + Resources.TabThongkeCanhan_UpdateValue__;
    }

    private void UpdateValueBot()
    {
      if (string.IsNullOrEmpty(this._objChukidanh.donviTien))
        this._objChukidanh.donviTien = "VND";
      this.lblTongthutuLoto.Text = ClMain.QuiDoiSoLuong(this._objValue.TongThuTuLoto.ToString(), this._objChukidanh.donviTien);
      this.lblLoinhuanDauTu_Loto.Text = string.Format("{0:0.00}", (object) this._objValue.LoiNhuanDauTuLoto) + Resources.TabThongkeCanhan_UpdateValue__;
      this.lblTongthuTuDacBiet.Text = ClMain.QuiDoiSoLuong(this._objValue.TongThuTuDacbiet.ToString(), this._objChukidanh.donviTien);
      this.lblLoinhuanDauTu_DacBiet.Text = string.Format("{0:0.00}", (object) this._objValue.LoiNhuanDauTuDacBiet) + Resources.TabThongkeCanhan_UpdateValue__;
      this.lblTongthuCuaNam.Text = ClMain.QuiDoiSoLuong(string.Format("{0:0.00}", (object) this._objValue.TongthuCuaNam), this._objChukidanh.donviTien);
      this.lblTrungBinhMoiChuKi.Text = ClMain.QuiDoiSoLuong(string.Format("{0:0.00}", (object) this._objValue.TrungBinhMoiChuKi), this._objChukidanh.donviTien);
    }

    private void LayDuLieuChuki(int maChuki)
    {
      this._listData = this._objLoOffline.GetListByMaChuKiObj(maChuki, this._objChukidanh.donviTien);
    }

    private void ShowDataChuKi()
    {
      if (this._listData.Count > 0)
      {
        this.dtg_Ketqua.AutoGenerateColumns = false;
        this.dtg_Ketqua.DataSource = (object) this._listData;
      }
      else
        this.dtg_Ketqua.DataSource = (object) null;
    }

    private void ShowVonLaiLotoDacBiet(int maChuki)
    {
      this._dt = this._objLoOffline.GetSoVonSolaiByMaChuKi(maChuki);
      if (this._dt.Rows.Count > 0)
      {
        this._objValue.TongVonTuLoto = Decimal.Zero;
        this._objValue.TongThuTuLoto = Decimal.Zero;
        this._objValue.TongVonTuDacbiet = Decimal.Zero;
        this._objValue.TongThuTuDacbiet = Decimal.Zero;
        for (int index = 0; index < this._dt.Rows.Count; ++index)
        {
          if (this._dt.Rows[index]["hinhThucDanh"].ToString() == "0" || this._dt.Rows[index]["hinhThucDanh"].ToString() == "1")
          {
            this._objValue.TongVonTuLoto += Decimal.Parse(this._dt.Rows[index]["soVon"].ToString());
            this._objValue.TongThuTuLoto += Decimal.Parse(this._dt.Rows[index]["soLai"].ToString());
          }
          else
          {
            this._objValue.TongVonTuDacbiet += Decimal.Parse(this._dt.Rows[index]["soVon"].ToString());
            this._objValue.TongThuTuDacbiet += Decimal.Parse(this._dt.Rows[index]["soLai"].ToString());
          }
        }
        this._objValue.LoiNhuanDauTuLoto = Decimal.Zero;
        if (this._objValue.TongVonTuLoto > Decimal.Zero && this._objValue.TongThuTuLoto > Decimal.Zero)
          this._objValue.LoiNhuanDauTuLoto = this._objValue.TongThuTuLoto / this._objValue.TongVonTuLoto * new Decimal(100);
        this._objValue.LoiNhuanDauTuDacBiet = Decimal.Zero;
        if (!(this._objValue.TongVonTuDacbiet > Decimal.Zero) || !(this._objValue.TongThuTuDacbiet > Decimal.Zero))
          return;
        this._objValue.LoiNhuanDauTuDacBiet = this._objValue.TongThuTuDacbiet / this._objValue.TongVonTuDacbiet * new Decimal(100);
      }
      else
      {
        this._objValue.TongVonTuLoto = Decimal.Zero;
        this._objValue.TongThuTuLoto = Decimal.Zero;
        this._objValue.LoiNhuanDauTuLoto = Decimal.Zero;
        this._objValue.LoiNhuanDauTuDacBiet = Decimal.Zero;
      }
    }

    private void TinhTongThuCuaNam(int year)
    {
      this._dt = this._objChukidanh.Get_Solai_By_Year(year, TbUser.Tbuser.TenDangnhap);
      if (this._dt.Rows.Count > 0)
      {
        this._objValue.TrungBinhMoiChuKi = Decimal.Zero;
        this._objValue.TongthuCuaNam = Decimal.Zero;
        this._objValue.TongVonCuaNam = Decimal.Zero;
        for (int index = 0; index < this._dt.Rows.Count; ++index)
        {
          this._objValue.TongthuCuaNam += Decimal.Parse(this._dt.Rows[index]["tongTienLai"].ToString());
          this._objValue.TongVonCuaNam += Decimal.Parse(this._dt.Rows[index]["tongSovon"].ToString());
        }
        this._objValue.TrungBinhMoiChuKi = this._objValue.TongthuCuaNam / (Decimal) this._dt.Rows.Count;
      }
      else
      {
        this._objValue.TongthuCuaNam = Decimal.Zero;
        this._objValue.TongVonCuaNam = Decimal.Zero;
      }
    }

    private void DemVangBacThoiHanSuDung()
    {
      this.lblThoihanSudung.Text = FMain.HanSuDung;
      this.lblVanghienco.Text = TabThongkeCanhan.QuiDoiSoLuong(FMain.VanghienCo.ToString((IFormatProvider) CultureInfo.InvariantCulture), Resources.fThemXu_show_Value__vàng);
      this.lblBacHienCo.Text = TabThongkeCanhan.QuiDoiSoLuong(FMain.BacHienco.ToString((IFormatProvider) CultureInfo.InvariantCulture), "bạc");
    }

    public static string QuiDoiSoLuong(string soLuong, string donVi)
    {
      try
      {
        return Convert.ToDecimal(soLuong).ToString("##,#0") + " " + donVi;
      }
      catch (Exception ex)
      {
        return "0.0 " + donVi;
      }
    }

    private void TinhTongLaiChuKiHienTaiMucTieu(int maChuki)
    {
      this._objChukidanh = this._objChukidanh.GetInfor(maChuki);
      this._month = this._objChukidanh.ngayBatdau.Month;
      this._year = this._objChukidanh.ngayBatdau.Year;
      DateTime dateTime1 = this._objChukidanh.ngayBatdau;
      dateTime1 = dateTime1.AddMonths(-1);
      this._thangTruoc = dateTime1.Month;
      DateTime dateTime2 = this._objChukidanh.ngayBatdau;
      dateTime2 = dateTime2.AddMonths(-1);
      this._namTruoc = dateTime2.Year;
      if (this._objChukidanh.tenChuki != null)
      {
        this._objValue.TonglaichukiHientai = this._objChukidanh.tongTienLai;
        this._objValue.TongVontrongchuki = this._objChukidanh.tongSovon;
        this._objValue.MuctieuChuKi = this._objChukidanh.muctieuChuki;
        if (this._objValue.TonglaichukiHientai != Decimal.Zero && this._objValue.TongVontrongchuki != Decimal.Zero)
        {
          this._objValue.LoinhuanDauTuCuaChuKi = this._objValue.TonglaichukiHientai / this._objValue.TongVontrongchuki * new Decimal(100);
          this._objValue.HoanThanhMucTieu = this._objValue.TonglaichukiHientai / this._objValue.MuctieuChuKi * new Decimal(100);
        }
        else
        {
          this._objValue.LoinhuanDauTuCuaChuKi = Decimal.Zero;
          this._objValue.HoanThanhMucTieu = Decimal.Zero;
        }
        this._objValue.MucTieuConLai = new Decimal(100) - this._objValue.HoanThanhMucTieu;
        if (!(this._objValue.MucTieuConLai < Decimal.One))
          return;
        this._objValue.MucTieuConLai = Decimal.Zero;
      }
      else
      {
        this._objValue.TonglaichukiHientai = Decimal.Zero;
        this._objValue.TongVontrongchuki = Decimal.Zero;
        this._objValue.LoinhuanDauTuCuaChuKi = Decimal.Zero;
        this._objValue.MuctieuChuKi = Decimal.Zero;
        this._objValue.HoanThanhMucTieu = Decimal.Zero;
        this._objValue.MucTieuConLai = Decimal.Zero;
      }
    }

    private void TinhTongLaiThang(int thang, int namYear)
    {
      this._dt = this._objLoOffline.GetSolaiByMonth(thang, namYear, TbUser.Tbuser.TenDangnhap);
      if (this._dt.Rows.Count > 0)
      {
        this._objValue.Tonglaithangnay = Decimal.Zero;
        this._objValue.TongVonthangnay = Decimal.Zero;
        for (int index = 0; index < this._dt.Rows.Count; ++index)
        {
          this._objValue.Tonglaithangnay += Convert.ToDecimal(this._dt.Rows[index]["soLai"].ToString());
          this._objValue.TongVonthangnay += Convert.ToDecimal(this._dt.Rows[index]["soVon"].ToString());
        }
        this._objValue.LoinhuanDauTuCuathang = this._objValue.Tonglaithangnay / this._objValue.TongVonthangnay * new Decimal(100);
      }
      else
      {
        this._objValue.Tonglaithangnay = Decimal.Zero;
        this._objValue.TongVonthangnay = Decimal.Zero;
        this._objValue.LoinhuanDauTuCuathang = Decimal.Zero;
      }
    }

    private void TinhTongLaiThangTruoc(int thang, int namYear)
    {
      this._dt = this._objLoOffline.GetSolaiByMonth(thang, namYear, TbUser.Tbuser.TenDangnhap);
      if (this._dt.Rows.Count > 0)
      {
        for (int index = 0; index < this._dt.Rows.Count; ++index)
          this._objValue.TonglaiThangTruoc += Convert.ToDecimal(this._dt.Rows[index]["soLai"].ToString());
      }
      else
        this._objValue.TonglaiThangTruoc = Decimal.Zero;
    }

    private void Timer1Tick(object sender, EventArgs e)
    {
      this.DemVangBacThoiHanSuDung();
      this.picLoading.Visible = this.backgroundWorkerXuly.IsBusy;
      if (TabThongkeCanhan.LoadLaiForm != 1)
        return;
      TabThongkeCanhan.LoadLaiForm = 0;
      if (!this.backgroundWorkerXuly.IsBusy)
        this.backgroundWorkerXuly.RunWorkerAsync();
    }

    private void BackgroundWorkerXulyDoWork(object sender, DoWorkEventArgs e)
    {
      this._maChuki = this._objChukidanh.GetMaChuKiByUsernameTop(TbUser.Tbuser.TenDangnhap);
      if (this._maChuki <= -1)
        return;
      this.TinhTongLaiChuKiHienTaiMucTieu(this._maChuki);
      this.TinhTongLaiThang(this._month, this._year);
      this.TinhTongLaiThangTruoc(this._thangTruoc, this._namTruoc);
      this.TinhTongThuCuaNam(this._year);
      this.LayDuLieuChuki(this._maChuki);
      this.ShowVonLaiLotoDacBiet(this._maChuki);
    }

    private void BackgroundWorkerXulyRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.UpdateValue();
      this.UpdateValueBot();
      this.ShowDataChuKi();
    }

    private void TabThongkeCanhanLoad(object sender, EventArgs e)
    {
    }

    private void BunifuImageButton4Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ThongTinTaiKhoan;
    }

    private void BunifuImageButton2Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ChotSo;
    }

    private void BunifuImageButton3Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ChotSo;
    }

    private void BunifuImageButton1Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ChotSo;
    }

    private void DtgKetquaCellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void DtgKetquaKeyDown(object sender, KeyEventArgs e)
    {
      if (this._maChotLoto == -1 || this.dtg_Ketqua.Rows.Count <= 0 || e.KeyCode != System.Windows.Forms.Keys.Delete || MessageBox.Show(Resources.TabVaotienChukiDanh_dtg_Ketqua_KeyDown_BẠN_CÓ_CHẮC_CHẮN_MUỐN_XÓA_MỤC_CHỐT_NÀY____, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this._objLoOffline.Delete(this._maChotLoto);
      TabThongkeCanhan.LoadLaiForm = 1;
    }

    private void DtgKetquaCellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex <= -1 || this._objChukidanh.status != 1)
        return;
      this._maChotLoto = int.Parse(this.dtg_Ketqua.Rows[e.RowIndex].Cells[0].Value.ToString());
    }

    private void BunifuSeparator1Load(object sender, EventArgs e)
    {
    }

    private void ChỉnhSửaToolStripMenuItemClick(object sender, EventArgs e)
    {
      int num = (int) new FLotoOffline(this._maChuki, "update", this._maChotLoto).ShowDialog();
    }

    private void XóaToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (this._maChotLoto == -1 || MessageBox.Show(Resources.TabVaotienChukiDanh_dtg_Ketqua_KeyDown_BẠN_CÓ_CHẮC_CHẮN_MUỐN_XÓA_MỤC_CHỐT_NÀY____, Resources.tabInfoUser_btnCapnhat_Click_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this._objLoOffline.Delete(this._maChotLoto);
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
      FMain.LoadTabname = FMain.TabName.ChotSo;
    }

    private void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
    {
      this.HienthiMenuStrip();
    }

    private void HienthiMenuStrip()
    {
      if (this._objChukidanh.status == 0)
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabThongkeCanhan));
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
      this.panel2 = new Panel();
      this.pn4 = new Panel();
      this.bunifuImageButton4 = new BunifuImageButton();
      this.lblBacHienCo = new Label();
      this.label20 = new Label();
      this.lblVanghienco = new Label();
      this.label22 = new Label();
      this.lblThoihanSudung = new Label();
      this.label24 = new Label();
      this.pn3 = new Panel();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.lblMuctieuConlai = new Label();
      this.label14 = new Label();
      this.lblDahoanThanhMuctieu = new Label();
      this.label16 = new Label();
      this.lblMuctieuChuki = new Label();
      this.label18 = new Label();
      this.pn2 = new Panel();
      this.bunifuImageButton2 = new BunifuImageButton();
      this.lblLoinhuanDautu_Chuki = new Label();
      this.label8 = new Label();
      this.lblTongvonchukiHientai = new Label();
      this.label10 = new Label();
      this.lblTonglaichukiHientai = new Label();
      this.label12 = new Label();
      this.pn1 = new Panel();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.lblLoinhuandautu_Thang = new Label();
      this.label5 = new Label();
      this.lblTonglaiThangtruoc = new Label();
      this.LabelTonglaiThangtr = new Label();
      this.lblTonglaiThangnay = new Label();
      this.label1 = new Label();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.bunifuImageButton5 = new BunifuImageButton();
      this.lblTongthuCuaNam = new Label();
      this.label29 = new Label();
      this.bunifuImageButton6 = new BunifuImageButton();
      this.lblTongthutuLoto = new Label();
      this.label31 = new Label();
      this.bunifuImageButton7 = new BunifuImageButton();
      this.lblTrungBinhMoiChuKi = new Label();
      this.label33 = new Label();
      this.lblLoinhuanDauTu_Loto = new Label();
      this.label35 = new Label();
      this.lblTongthuTuDacBiet = new Label();
      this.label37 = new Label();
      this.bunifuImageButton9 = new BunifuImageButton();
      this.bunifuImageButton10 = new BunifuImageButton();
      this.lblLoinhuanDauTu_DacBiet = new Label();
      this.label39 = new Label();
      this.backgroundWorkerXuly = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.label26 = new Label();
      this.label27 = new Label();
      this.panel7 = new Panel();
      this.picLoading = new PictureBox();
      this.dtg_Ketqua = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.chốtSốToolStripMenuItem = new ToolStripMenuItem();
      this.chỉnhSửaToolStripMenuItem = new ToolStripMenuItem();
      this.xóaToolStripMenuItem = new ToolStripMenuItem();
      this.toolTip1 = new ToolTip(this.components);
      this.pn5 = new Panel();
      this.pn6 = new Panel();
      this.pn7 = new Panel();
      this.pn8 = new Panel();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.pn9 = new Panel();
      this.pn10 = new Panel();
      this.stt = new DataGridViewTextBoxColumn();
      this.sothutu = new DataGridViewTextBoxColumn();
      this.nguonloto = new DataGridViewTextBoxColumn();
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
      this.panel2.SuspendLayout();
      this.pn4.SuspendLayout();
      this.bunifuImageButton4.BeginInit();
      this.pn3.SuspendLayout();
      this.bunifuImageButton3.BeginInit();
      this.pn2.SuspendLayout();
      this.bunifuImageButton2.BeginInit();
      this.pn1.SuspendLayout();
      this.bunifuImageButton1.BeginInit();
      this.bunifuImageButton5.BeginInit();
      this.bunifuImageButton6.BeginInit();
      this.bunifuImageButton7.BeginInit();
      this.bunifuImageButton9.BeginInit();
      this.bunifuImageButton10.BeginInit();
      this.panel7.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.pn5.SuspendLayout();
      this.pn6.SuspendLayout();
      this.pn7.SuspendLayout();
      this.pn8.SuspendLayout();
      this.bunifuImageButton8.BeginInit();
      this.pn9.SuspendLayout();
      this.pn10.SuspendLayout();
      this.SuspendLayout();
      this.panel2.Controls.Add((Control) this.pn4);
      this.panel2.Controls.Add((Control) this.pn3);
      this.panel2.Controls.Add((Control) this.pn2);
      this.panel2.Controls.Add((Control) this.pn1);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1155, 143);
      this.panel2.TabIndex = 2;
      this.pn4.BackColor = Color.Teal;
      this.pn4.Controls.Add((Control) this.bunifuImageButton4);
      this.pn4.Controls.Add((Control) this.lblBacHienCo);
      this.pn4.Controls.Add((Control) this.label20);
      this.pn4.Controls.Add((Control) this.lblVanghienco);
      this.pn4.Controls.Add((Control) this.label22);
      this.pn4.Controls.Add((Control) this.lblThoihanSudung);
      this.pn4.Controls.Add((Control) this.label24);
      this.pn4.Location = new Point(865, 7);
      this.pn4.Name = "pn4";
      this.pn4.Size = new Size(282, (int) sbyte.MaxValue);
      this.pn4.TabIndex = 0;
      this.bunifuImageButton4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.bunifuImageButton4.BackColor = Color.Transparent;
      this.bunifuImageButton4.Cursor = Cursors.Hand;
      this.bunifuImageButton4.Image = (Image) componentResourceManager.GetObject("bunifuImageButton4.Image");
      this.bunifuImageButton4.ImageActive = (Image) null;
      this.bunifuImageButton4.Location = new Point(209, -3);
      this.bunifuImageButton4.Name = "bunifuImageButton4";
      this.bunifuImageButton4.Size = new Size(75, 75);
      this.bunifuImageButton4.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton4.TabIndex = 2;
      this.bunifuImageButton4.TabStop = false;
      this.bunifuImageButton4.Zoom = 8;
      this.bunifuImageButton4.Click += new EventHandler(this.BunifuImageButton4Click);
      this.lblBacHienCo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblBacHienCo.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblBacHienCo.ForeColor = Color.White;
      this.lblBacHienCo.Location = new Point(124, 101);
      this.lblBacHienCo.Name = "lblBacHienCo";
      this.lblBacHienCo.Size = new Size(151, 19);
      this.lblBacHienCo.TabIndex = 0;
      this.lblBacHienCo.Text = "0 bạc";
      this.lblBacHienCo.TextAlign = ContentAlignment.TopRight;
      this.toolTip1.SetToolTip((Control) this.lblBacHienCo, "Số bạc hiện có của bạn");
      this.label20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label20.ForeColor = Color.White;
      this.label20.Location = new Point(203, 83);
      this.label20.Name = "label20";
      this.label20.Size = new Size(75, 16);
      this.label20.TabIndex = 0;
      this.label20.Text = "bạc hiện có";
      this.lblVanghienco.AutoSize = true;
      this.lblVanghienco.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblVanghienco.ForeColor = Color.White;
      this.lblVanghienco.Location = new Point(4, 103);
      this.lblVanghienco.Name = "lblVanghienco";
      this.lblVanghienco.Size = new Size(51, 17);
      this.lblVanghienco.TabIndex = 0;
      this.lblVanghienco.Text = "0 vàng";
      this.toolTip1.SetToolTip((Control) this.lblVanghienco, "Số vàng hiện có của bạn");
      this.label22.AutoSize = true;
      this.label22.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label22.ForeColor = Color.White;
      this.label22.Location = new Point(4, 82);
      this.label22.Name = "label22";
      this.label22.Size = new Size(80, 16);
      this.label22.TabIndex = 0;
      this.label22.Text = "vàng hiện có";
      this.lblThoihanSudung.AutoSize = true;
      this.lblThoihanSudung.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblThoihanSudung.ForeColor = Color.White;
      this.lblThoihanSudung.Location = new Point(4, 33);
      this.lblThoihanSudung.Name = "lblThoihanSudung";
      this.lblThoihanSudung.Size = new Size(151, 16);
      this.lblThoihanSudung.TabIndex = 0;
      this.lblThoihanSudung.Text = "00d 00giờ 00phút 00giây";
      this.label24.AutoSize = true;
      this.label24.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label24.ForeColor = Color.White;
      this.label24.Location = new Point(4, 11);
      this.label24.Name = "label24";
      this.label24.Size = new Size(122, 17);
      this.label24.TabIndex = 0;
      this.label24.Text = "thời gian sử dụng";
      this.pn3.BackColor = Color.FromArgb(222, 24, 112);
      this.pn3.Controls.Add((Control) this.bunifuImageButton3);
      this.pn3.Controls.Add((Control) this.lblMuctieuConlai);
      this.pn3.Controls.Add((Control) this.label14);
      this.pn3.Controls.Add((Control) this.lblDahoanThanhMuctieu);
      this.pn3.Controls.Add((Control) this.label16);
      this.pn3.Controls.Add((Control) this.lblMuctieuChuki);
      this.pn3.Controls.Add((Control) this.label18);
      this.pn3.Location = new Point(579, 7);
      this.pn3.Name = "pn3";
      this.pn3.Size = new Size(282, (int) sbyte.MaxValue);
      this.pn3.TabIndex = 0;
      this.bunifuImageButton3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.bunifuImageButton3.BackColor = Color.Transparent;
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(204, 1);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(77, 77);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 2;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 10;
      this.bunifuImageButton3.Click += new EventHandler(this.BunifuImageButton3Click);
      this.lblMuctieuConlai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblMuctieuConlai.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblMuctieuConlai.ForeColor = Color.White;
      this.lblMuctieuConlai.Location = new Point(156, 101);
      this.lblMuctieuConlai.Name = "lblMuctieuConlai";
      this.lblMuctieuConlai.Size = new Size(118, 19);
      this.lblMuctieuConlai.TabIndex = 0;
      this.lblMuctieuConlai.Text = "0%";
      this.lblMuctieuConlai.TextAlign = ContentAlignment.TopRight;
      this.toolTip1.SetToolTip((Control) this.lblMuctieuConlai, "Mục tiêu còn lại");
      this.label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label14.ForeColor = Color.WhiteSmoke;
      this.label14.Location = new Point(177, 82);
      this.label14.Name = "label14";
      this.label14.Size = new Size(100, 16);
      this.label14.TabIndex = 0;
      this.label14.Text = "mục tiêu còn lại";
      this.lblDahoanThanhMuctieu.AutoSize = true;
      this.lblDahoanThanhMuctieu.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblDahoanThanhMuctieu.ForeColor = Color.White;
      this.lblDahoanThanhMuctieu.Location = new Point(5, 103);
      this.lblDahoanThanhMuctieu.Name = "lblDahoanThanhMuctieu";
      this.lblDahoanThanhMuctieu.Size = new Size(29, 17);
      this.lblDahoanThanhMuctieu.TabIndex = 0;
      this.lblDahoanThanhMuctieu.Text = "0%";
      this.toolTip1.SetToolTip((Control) this.lblDahoanThanhMuctieu, "Mục tiêu đã hoàn thành");
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label16.ForeColor = Color.WhiteSmoke;
      this.label16.Location = new Point(5, 82);
      this.label16.Name = "label16";
      this.label16.Size = new Size(90, 16);
      this.label16.TabIndex = 0;
      this.label16.Text = "đã hoàn thành";
      this.lblMuctieuChuki.AutoSize = true;
      this.lblMuctieuChuki.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblMuctieuChuki.ForeColor = Color.White;
      this.lblMuctieuChuki.Location = new Point(5, 33);
      this.lblMuctieuChuki.Name = "lblMuctieuChuki";
      this.lblMuctieuChuki.Size = new Size(55, 18);
      this.lblMuctieuChuki.TabIndex = 0;
      this.lblMuctieuChuki.Text = "0 VND";
      this.toolTip1.SetToolTip((Control) this.lblMuctieuChuki, "Mục tiêu của chu kì");
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label18.ForeColor = Color.WhiteSmoke;
      this.label18.Location = new Point(5, 11);
      this.label18.Name = "label18";
      this.label18.Size = new Size(134, 17);
      this.label18.TabIndex = 0;
      this.label18.Text = "mục tiêu của chu kì";
      this.pn2.BackColor = Color.FromArgb(105, 184, 41);
      this.pn2.Controls.Add((Control) this.bunifuImageButton2);
      this.pn2.Controls.Add((Control) this.lblLoinhuanDautu_Chuki);
      this.pn2.Controls.Add((Control) this.label8);
      this.pn2.Controls.Add((Control) this.lblTongvonchukiHientai);
      this.pn2.Controls.Add((Control) this.label10);
      this.pn2.Controls.Add((Control) this.lblTonglaichukiHientai);
      this.pn2.Controls.Add((Control) this.label12);
      this.pn2.Location = new Point(293, 7);
      this.pn2.Name = "pn2";
      this.pn2.Size = new Size(282, (int) sbyte.MaxValue);
      this.pn2.TabIndex = 0;
      this.bunifuImageButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.bunifuImageButton2.BackColor = Color.Transparent;
      this.bunifuImageButton2.Cursor = Cursors.Hand;
      this.bunifuImageButton2.Image = (Image) componentResourceManager.GetObject("bunifuImageButton2.Image");
      this.bunifuImageButton2.ImageActive = (Image) null;
      this.bunifuImageButton2.Location = new Point(204, 1);
      this.bunifuImageButton2.Name = "bunifuImageButton2";
      this.bunifuImageButton2.Size = new Size(75, 75);
      this.bunifuImageButton2.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton2.TabIndex = 2;
      this.bunifuImageButton2.TabStop = false;
      this.bunifuImageButton2.Zoom = 10;
      this.bunifuImageButton2.Click += new EventHandler(this.BunifuImageButton2Click);
      this.lblLoinhuanDautu_Chuki.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblLoinhuanDautu_Chuki.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblLoinhuanDautu_Chuki.ForeColor = Color.White;
      this.lblLoinhuanDautu_Chuki.Location = new Point(152, 101);
      this.lblLoinhuanDautu_Chuki.Name = "lblLoinhuanDautu_Chuki";
      this.lblLoinhuanDautu_Chuki.Size = new Size(124, 19);
      this.lblLoinhuanDautu_Chuki.TabIndex = 0;
      this.lblLoinhuanDautu_Chuki.Text = "0%";
      this.lblLoinhuanDautu_Chuki.TextAlign = ContentAlignment.TopRight;
      this.toolTip1.SetToolTip((Control) this.lblLoinhuanDautu_Chuki, "Tỉ lệ lợi nhuận đầu tư của chu kỳ");
      this.label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label8.ForeColor = Color.WhiteSmoke;
      this.label8.Location = new Point(175, 82);
      this.label8.Name = "label8";
      this.label8.Size = new Size(104, 16);
      this.label8.TabIndex = 0;
      this.label8.Text = "lợi nhuận đầu tư";
      this.lblTongvonchukiHientai.AutoSize = true;
      this.lblTongvonchukiHientai.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblTongvonchukiHientai.ForeColor = Color.White;
      this.lblTongvonchukiHientai.Location = new Point(5, 98);
      this.lblTongvonchukiHientai.Name = "lblTongvonchukiHientai";
      this.lblTongvonchukiHientai.Size = new Size(50, 17);
      this.lblTongvonchukiHientai.TabIndex = 0;
      this.lblTongvonchukiHientai.Text = "0 VND";
      this.toolTip1.SetToolTip((Control) this.lblTongvonchukiHientai, "Tổng số vốn đã dùng trong chu kỳ");
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label10.ForeColor = Color.WhiteSmoke;
      this.label10.Location = new Point(5, 82);
      this.label10.Name = "label10";
      this.label10.Size = new Size(99, 16);
      this.label10.TabIndex = 0;
      this.label10.Text = "vốn trong chu kì";
      this.lblTonglaichukiHientai.AutoSize = true;
      this.lblTonglaichukiHientai.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblTonglaichukiHientai.ForeColor = Color.White;
      this.lblTonglaichukiHientai.Location = new Point(5, 33);
      this.lblTonglaichukiHientai.Name = "lblTonglaichukiHientai";
      this.lblTonglaichukiHientai.Size = new Size(55, 18);
      this.lblTonglaichukiHientai.TabIndex = 0;
      this.lblTonglaichukiHientai.Text = "0 VND";
      this.toolTip1.SetToolTip((Control) this.lblTonglaichukiHientai, "Tổng số lãi của chu kỳ mới nhất");
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label12.ForeColor = Color.WhiteSmoke;
      this.label12.Location = new Point(5, 11);
      this.label12.Name = "label12";
      this.label12.Size = new Size(146, 17);
      this.label12.TabIndex = 0;
      this.label12.Text = "tổng lãi chu kì hiện tại";
      this.pn1.BackColor = Color.FromArgb(79, 142, 247);
      this.pn1.Controls.Add((Control) this.bunifuImageButton1);
      this.pn1.Controls.Add((Control) this.lblLoinhuandautu_Thang);
      this.pn1.Controls.Add((Control) this.label5);
      this.pn1.Controls.Add((Control) this.lblTonglaiThangtruoc);
      this.pn1.Controls.Add((Control) this.LabelTonglaiThangtr);
      this.pn1.Controls.Add((Control) this.lblTonglaiThangnay);
      this.pn1.Controls.Add((Control) this.label1);
      this.pn1.Location = new Point(7, 7);
      this.pn1.Name = "pn1";
      this.pn1.Size = new Size(282, (int) sbyte.MaxValue);
      this.pn1.TabIndex = 0;
      this.bunifuImageButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Cursor = Cursors.Hand;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(205, 2);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(75, 75);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 2;
      this.bunifuImageButton1.TabStop = false;
      this.bunifuImageButton1.Zoom = 10;
      this.bunifuImageButton1.Click += new EventHandler(this.BunifuImageButton1Click);
      this.lblLoinhuandautu_Thang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblLoinhuandautu_Thang.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblLoinhuandautu_Thang.ForeColor = Color.White;
      this.lblLoinhuandautu_Thang.Location = new Point(166, 101);
      this.lblLoinhuandautu_Thang.Name = "lblLoinhuandautu_Thang";
      this.lblLoinhuandautu_Thang.Size = new Size(109, 19);
      this.lblLoinhuandautu_Thang.TabIndex = 0;
      this.lblLoinhuandautu_Thang.Text = "0%";
      this.lblLoinhuandautu_Thang.TextAlign = ContentAlignment.TopRight;
      this.toolTip1.SetToolTip((Control) this.lblLoinhuandautu_Thang, "Tỉ lệ lợi nhuận đầu tư của tháng này");
      this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label5.ForeColor = Color.WhiteSmoke;
      this.label5.Location = new Point(175, 82);
      this.label5.Name = "label5";
      this.label5.Size = new Size(104, 16);
      this.label5.TabIndex = 0;
      this.label5.Text = "lợi nhuận đầu tư";
      this.lblTonglaiThangtruoc.AutoSize = true;
      this.lblTonglaiThangtruoc.Cursor = Cursors.Default;
      this.lblTonglaiThangtruoc.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblTonglaiThangtruoc.ForeColor = Color.White;
      this.lblTonglaiThangtruoc.Location = new Point(5, 103);
      this.lblTonglaiThangtruoc.Name = "lblTonglaiThangtruoc";
      this.lblTonglaiThangtruoc.Size = new Size(50, 17);
      this.lblTonglaiThangtruoc.TabIndex = 0;
      this.lblTonglaiThangtruoc.Text = "0 VND";
      this.toolTip1.SetToolTip((Control) this.lblTonglaiThangtruoc, "Tổng lợi nhuận đầu tư của tháng trước");
      this.LabelTonglaiThangtr.AutoSize = true;
      this.LabelTonglaiThangtr.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.LabelTonglaiThangtr.ForeColor = Color.WhiteSmoke;
      this.LabelTonglaiThangtr.Location = new Point(5, 82);
      this.LabelTonglaiThangtr.Name = "LabelTonglaiThangtr";
      this.LabelTonglaiThangtr.Size = new Size(77, 16);
      this.LabelTonglaiThangtr.TabIndex = 0;
      this.LabelTonglaiThangtr.Text = "tháng trước";
      this.lblTonglaiThangnay.AutoSize = true;
      this.lblTonglaiThangnay.Cursor = Cursors.Default;
      this.lblTonglaiThangnay.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblTonglaiThangnay.ForeColor = Color.White;
      this.lblTonglaiThangnay.Location = new Point(5, 33);
      this.lblTonglaiThangnay.Name = "lblTonglaiThangnay";
      this.lblTonglaiThangnay.Size = new Size(55, 18);
      this.lblTonglaiThangnay.TabIndex = 0;
      this.lblTonglaiThangnay.Text = "0 VND";
      this.toolTip1.SetToolTip((Control) this.lblTonglaiThangnay, "Tổng lợi nhuận đầu tư của tháng này");
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label1.ForeColor = Color.WhiteSmoke;
      this.label1.Location = new Point(5, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(121, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "tổng lãi tháng này";
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.bunifuImageButton5.BackColor = Color.Transparent;
      this.bunifuImageButton5.Cursor = Cursors.Hand;
      this.bunifuImageButton5.Dock = DockStyle.Bottom;
      this.bunifuImageButton5.Image = (Image) componentResourceManager.GetObject("bunifuImageButton5.Image");
      this.bunifuImageButton5.ImageActive = (Image) null;
      this.bunifuImageButton5.Location = new Point(0, 3);
      this.bunifuImageButton5.Name = "bunifuImageButton5";
      this.bunifuImageButton5.Size = new Size(188, 29);
      this.bunifuImageButton5.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton5.TabIndex = 5;
      this.bunifuImageButton5.TabStop = false;
      this.bunifuImageButton5.Zoom = 0;
      this.lblTongthuCuaNam.Cursor = Cursors.Hand;
      this.lblTongthuCuaNam.Dock = DockStyle.Bottom;
      this.lblTongthuCuaNam.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTongthuCuaNam.ForeColor = Color.DimGray;
      this.lblTongthuCuaNam.Location = new Point(0, 32);
      this.lblTongthuCuaNam.Name = "lblTongthuCuaNam";
      this.lblTongthuCuaNam.Size = new Size(188, 25);
      this.lblTongthuCuaNam.TabIndex = 6;
      this.lblTongthuCuaNam.Text = "999.999.999.999 VND";
      this.lblTongthuCuaNam.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthuCuaNam, "Tổng số lợi nhuận của năm nay");
      this.label29.Cursor = Cursors.Hand;
      this.label29.Dock = DockStyle.Bottom;
      this.label29.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label29.ForeColor = Color.Gray;
      this.label29.Location = new Point(0, 57);
      this.label29.Name = "label29";
      this.label29.Size = new Size(188, 17);
      this.label29.TabIndex = 6;
      this.label29.Text = "tổng thu của năm";
      this.label29.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuImageButton6.BackColor = Color.Transparent;
      this.bunifuImageButton6.Cursor = Cursors.Hand;
      this.bunifuImageButton6.Dock = DockStyle.Bottom;
      this.bunifuImageButton6.Image = (Image) componentResourceManager.GetObject("bunifuImageButton6.Image");
      this.bunifuImageButton6.ImageActive = (Image) null;
      this.bunifuImageButton6.Location = new Point(0, 3);
      this.bunifuImageButton6.Name = "bunifuImageButton6";
      this.bunifuImageButton6.Size = new Size(188, 30);
      this.bunifuImageButton6.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton6.TabIndex = 5;
      this.bunifuImageButton6.TabStop = false;
      this.bunifuImageButton6.Zoom = 0;
      this.lblTongthutuLoto.Cursor = Cursors.Hand;
      this.lblTongthutuLoto.Dock = DockStyle.Bottom;
      this.lblTongthutuLoto.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTongthutuLoto.ForeColor = Color.DimGray;
      this.lblTongthutuLoto.Location = new Point(0, 33);
      this.lblTongthutuLoto.Name = "lblTongthutuLoto";
      this.lblTongthutuLoto.Size = new Size(188, 25);
      this.lblTongthutuLoto.TabIndex = 6;
      this.lblTongthutuLoto.Text = "0 VND";
      this.lblTongthutuLoto.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthutuLoto, "Tổng lợi nhuận từ lô tô trong chu kỳ");
      this.label31.Cursor = Cursors.Hand;
      this.label31.Dock = DockStyle.Bottom;
      this.label31.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label31.ForeColor = Color.Gray;
      this.label31.Location = new Point(0, 58);
      this.label31.Name = "label31";
      this.label31.Size = new Size(188, 16);
      this.label31.TabIndex = 6;
      this.label31.Text = "tổng thu từ lô tô";
      this.label31.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuImageButton7.BackColor = Color.Transparent;
      this.bunifuImageButton7.Cursor = Cursors.Hand;
      this.bunifuImageButton7.Dock = DockStyle.Bottom;
      this.bunifuImageButton7.Image = (Image) componentResourceManager.GetObject("bunifuImageButton7.Image");
      this.bunifuImageButton7.ImageActive = (Image) null;
      this.bunifuImageButton7.Location = new Point(0, 5);
      this.bunifuImageButton7.Name = "bunifuImageButton7";
      this.bunifuImageButton7.Size = new Size(188, 28);
      this.bunifuImageButton7.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton7.TabIndex = 5;
      this.bunifuImageButton7.TabStop = false;
      this.bunifuImageButton7.Zoom = 0;
      this.lblTrungBinhMoiChuKi.Cursor = Cursors.Hand;
      this.lblTrungBinhMoiChuKi.Dock = DockStyle.Bottom;
      this.lblTrungBinhMoiChuKi.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTrungBinhMoiChuKi.ForeColor = Color.DimGray;
      this.lblTrungBinhMoiChuKi.Location = new Point(0, 33);
      this.lblTrungBinhMoiChuKi.Name = "lblTrungBinhMoiChuKi";
      this.lblTrungBinhMoiChuKi.Size = new Size(188, 25);
      this.lblTrungBinhMoiChuKi.TabIndex = 6;
      this.lblTrungBinhMoiChuKi.Text = "0 VND";
      this.lblTrungBinhMoiChuKi.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTrungBinhMoiChuKi, "Lợi nhuận trung bình trên mỗi chu kỳ");
      this.label33.Cursor = Cursors.Hand;
      this.label33.Dock = DockStyle.Bottom;
      this.label33.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label33.ForeColor = Color.Gray;
      this.label33.Location = new Point(0, 58);
      this.label33.Name = "label33";
      this.label33.Size = new Size(188, 16);
      this.label33.TabIndex = 6;
      this.label33.Text = "trung bình mỗi chu kì";
      this.label33.TextAlign = ContentAlignment.MiddleCenter;
      this.lblLoinhuanDauTu_Loto.Cursor = Cursors.Hand;
      this.lblLoinhuanDauTu_Loto.Dock = DockStyle.Bottom;
      this.lblLoinhuanDauTu_Loto.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLoinhuanDauTu_Loto.ForeColor = Color.DimGray;
      this.lblLoinhuanDauTu_Loto.Location = new Point(0, 33);
      this.lblLoinhuanDauTu_Loto.Name = "lblLoinhuanDauTu_Loto";
      this.lblLoinhuanDauTu_Loto.Size = new Size(188, 25);
      this.lblLoinhuanDauTu_Loto.TabIndex = 6;
      this.lblLoinhuanDauTu_Loto.Text = "0%";
      this.lblLoinhuanDauTu_Loto.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblLoinhuanDauTu_Loto, "Tỉ lệ lợi nhuận đầu tư của lô tô");
      this.label35.Cursor = Cursors.Hand;
      this.label35.Dock = DockStyle.Bottom;
      this.label35.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label35.ForeColor = Color.Gray;
      this.label35.Location = new Point(0, 58);
      this.label35.Name = "label35";
      this.label35.Size = new Size(188, 16);
      this.label35.TabIndex = 6;
      this.label35.Text = "lợi nhuận đầu tư";
      this.label35.TextAlign = ContentAlignment.MiddleCenter;
      this.lblTongthuTuDacBiet.Cursor = Cursors.Hand;
      this.lblTongthuTuDacBiet.Dock = DockStyle.Bottom;
      this.lblTongthuTuDacBiet.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTongthuTuDacBiet.ForeColor = Color.DimGray;
      this.lblTongthuTuDacBiet.Location = new Point(0, 33);
      this.lblTongthuTuDacBiet.Name = "lblTongthuTuDacBiet";
      this.lblTongthuTuDacBiet.Size = new Size(188, 25);
      this.lblTongthuTuDacBiet.TabIndex = 6;
      this.lblTongthuTuDacBiet.Text = "0 VND";
      this.lblTongthuTuDacBiet.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblTongthuTuDacBiet, "Tổng lợi nhuận từ đặc biệt trong chu kỳ");
      this.label37.Cursor = Cursors.Hand;
      this.label37.Dock = DockStyle.Bottom;
      this.label37.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label37.ForeColor = Color.Gray;
      this.label37.Location = new Point(0, 58);
      this.label37.Name = "label37";
      this.label37.Size = new Size(188, 16);
      this.label37.TabIndex = 6;
      this.label37.Text = "tổng thu từ đề";
      this.label37.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuImageButton9.BackColor = Color.Transparent;
      this.bunifuImageButton9.Cursor = Cursors.Hand;
      this.bunifuImageButton9.Dock = DockStyle.Bottom;
      this.bunifuImageButton9.Image = (Image) componentResourceManager.GetObject("bunifuImageButton9.Image");
      this.bunifuImageButton9.ImageActive = (Image) null;
      this.bunifuImageButton9.Location = new Point(0, 2);
      this.bunifuImageButton9.Name = "bunifuImageButton9";
      this.bunifuImageButton9.Size = new Size(188, 31);
      this.bunifuImageButton9.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton9.TabIndex = 5;
      this.bunifuImageButton9.TabStop = false;
      this.bunifuImageButton9.Zoom = 0;
      this.bunifuImageButton10.BackColor = Color.Transparent;
      this.bunifuImageButton10.Cursor = Cursors.Hand;
      this.bunifuImageButton10.Dock = DockStyle.Bottom;
      this.bunifuImageButton10.Image = (Image) componentResourceManager.GetObject("bunifuImageButton10.Image");
      this.bunifuImageButton10.ImageActive = (Image) null;
      this.bunifuImageButton10.Location = new Point(0, 8);
      this.bunifuImageButton10.Name = "bunifuImageButton10";
      this.bunifuImageButton10.Size = new Size(188, 25);
      this.bunifuImageButton10.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton10.TabIndex = 5;
      this.bunifuImageButton10.TabStop = false;
      this.bunifuImageButton10.Zoom = 0;
      this.lblLoinhuanDauTu_DacBiet.Cursor = Cursors.Hand;
      this.lblLoinhuanDauTu_DacBiet.Dock = DockStyle.Bottom;
      this.lblLoinhuanDauTu_DacBiet.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLoinhuanDauTu_DacBiet.ForeColor = Color.DimGray;
      this.lblLoinhuanDauTu_DacBiet.Location = new Point(0, 33);
      this.lblLoinhuanDauTu_DacBiet.Name = "lblLoinhuanDauTu_DacBiet";
      this.lblLoinhuanDauTu_DacBiet.Size = new Size(188, 25);
      this.lblLoinhuanDauTu_DacBiet.TabIndex = 6;
      this.lblLoinhuanDauTu_DacBiet.Text = "0%";
      this.lblLoinhuanDauTu_DacBiet.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblLoinhuanDauTu_DacBiet, "Tỉ lệ lợi nhuận đầu tư của đặc biệt");
      this.label39.Cursor = Cursors.Hand;
      this.label39.Dock = DockStyle.Bottom;
      this.label39.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label39.ForeColor = Color.Gray;
      this.label39.Location = new Point(0, 58);
      this.label39.Name = "label39";
      this.label39.Size = new Size(188, 16);
      this.label39.TabIndex = 6;
      this.label39.Text = "lợi nhuận đầu tư";
      this.label39.TextAlign = ContentAlignment.MiddleCenter;
      this.backgroundWorkerXuly.DoWork += new DoWorkEventHandler(this.BackgroundWorkerXulyDoWork);
      this.backgroundWorkerXuly.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackgroundWorkerXulyRunWorkerCompleted);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.Timer1Tick);
      this.label26.BackColor = Color.FromArgb((int) byte.MaxValue, 185, 1);
      this.label26.Dock = DockStyle.Top;
      this.label26.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label26.ForeColor = Color.White;
      this.label26.Location = new Point(0, 0);
      this.label26.Margin = new Padding(3, 5, 3, 0);
      this.label26.Name = "label26";
      this.label26.Size = new Size(1141, 1);
      this.label26.TabIndex = 1;
      this.label26.TextAlign = ContentAlignment.TopCenter;
      this.label27.BackColor = Color.FromArgb((int) byte.MaxValue, 185, 1);
      this.label27.Dock = DockStyle.Bottom;
      this.label27.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label27.ForeColor = Color.White;
      this.label27.Location = new Point(0, 359);
      this.label27.Margin = new Padding(3, 5, 3, 0);
      this.label27.Name = "label27";
      this.label27.Size = new Size(1141, 1);
      this.label27.TabIndex = 3;
      this.label27.TextAlign = ContentAlignment.TopCenter;
      this.panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel7.BackColor = Color.White;
      this.panel7.Controls.Add((Control) this.picLoading);
      this.panel7.Controls.Add((Control) this.dtg_Ketqua);
      this.panel7.Controls.Add((Control) this.label27);
      this.panel7.Controls.Add((Control) this.label26);
      this.panel7.Location = new Point(7, 140);
      this.panel7.Name = "panel7";
      this.panel7.Size = new Size(1141, 360);
      this.panel7.TabIndex = 1;
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(548, 163);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 58;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToOrderColumns = true;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.BackgroundColor = Color.White;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.NullValue = (object) "#####";
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 24;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.stt, (DataGridViewColumn) this.sothutu, (DataGridViewColumn) this.nguonloto, (DataGridViewColumn) this.soChot, (DataGridViewColumn) this.tongDiem, (DataGridViewColumn) this.soLove, (DataGridViewColumn) this.soVon, (DataGridViewColumn) this.soLai, (DataGridViewColumn) this.hinhThucDanh, (DataGridViewColumn) this.ngayDanh, (DataGridViewColumn) this.duNo, (DataGridViewColumn) this.ngayChot, (DataGridViewColumn) this.colTrong);
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
      this.dtg_Ketqua.GridColor = Color.LightGray;
      this.dtg_Ketqua.Location = new Point(0, 1);
      this.dtg_Ketqua.Margin = new Padding(0);
      this.dtg_Ketqua.MultiSelect = false;
      this.dtg_Ketqua.Name = "dtg_Ketqua";
      this.dtg_Ketqua.ReadOnly = true;
      this.dtg_Ketqua.RowHeadersVisible = false;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtg_Ketqua.RowTemplate.Height = 36;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(1141, 358);
      this.dtg_Ketqua.TabIndex = 4;
      this.dtg_Ketqua.CellClick += new DataGridViewCellEventHandler(this.DtgKetquaCellClick);
      this.dtg_Ketqua.CellDoubleClick += new DataGridViewCellEventHandler(this.DtgKetquaCellClick);
      this.dtg_Ketqua.KeyDown += new KeyEventHandler(this.DtgKetquaKeyDown);
      this.dtg_Ketqua.MouseDown += new MouseEventHandler(this.DtgKetquaMouseDown);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.chốtSốToolStripMenuItem,
        (ToolStripItem) this.chỉnhSửaToolStripMenuItem,
        (ToolStripItem) this.xóaToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(168, 70);
      this.contextMenuStrip1.Opening += new CancelEventHandler(this.ContextMenuStrip1Opening);
      this.chốtSốToolStripMenuItem.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.chốtSốToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("chốtSốToolStripMenuItem.Image");
      this.chốtSốToolStripMenuItem.Name = "chốtSốToolStripMenuItem";
      this.chốtSốToolStripMenuItem.Size = new Size(167, 22);
      this.chốtSốToolStripMenuItem.Text = "Chốt số hôm nay";
      this.chốtSốToolStripMenuItem.Click += new EventHandler(this.ChốtSốToolStripMenuItemClick);
      this.chỉnhSửaToolStripMenuItem.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.chỉnhSửaToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("chỉnhSửaToolStripMenuItem.Image");
      this.chỉnhSửaToolStripMenuItem.Name = "chỉnhSửaToolStripMenuItem";
      this.chỉnhSửaToolStripMenuItem.Size = new Size(167, 22);
      this.chỉnhSửaToolStripMenuItem.Text = "Chỉnh sửa";
      this.chỉnhSửaToolStripMenuItem.Click += new EventHandler(this.ChỉnhSửaToolStripMenuItemClick);
      this.xóaToolStripMenuItem.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.xóaToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("xóaToolStripMenuItem.Image");
      this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
      this.xóaToolStripMenuItem.Size = new Size(167, 22);
      this.xóaToolStripMenuItem.Text = "Xóa";
      this.xóaToolStripMenuItem.Click += new EventHandler(this.XóaToolStripMenuItemClick);
      this.toolTip1.AutomaticDelay = 400;
      this.pn5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pn5.Controls.Add((Control) this.bunifuImageButton5);
      this.pn5.Controls.Add((Control) this.lblTongthuCuaNam);
      this.pn5.Controls.Add((Control) this.label29);
      this.pn5.Location = new Point(7, 503);
      this.pn5.Name = "pn5";
      this.pn5.Size = new Size(188, 74);
      this.pn5.TabIndex = 9;
      this.pn6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pn6.Controls.Add((Control) this.bunifuImageButton7);
      this.pn6.Controls.Add((Control) this.lblTrungBinhMoiChuKi);
      this.pn6.Controls.Add((Control) this.label33);
      this.pn6.Location = new Point(198, 503);
      this.pn6.Name = "pn6";
      this.pn6.Size = new Size(188, 74);
      this.pn6.TabIndex = 59;
      this.pn7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pn7.Controls.Add((Control) this.bunifuImageButton6);
      this.pn7.Controls.Add((Control) this.lblTongthutuLoto);
      this.pn7.Controls.Add((Control) this.label31);
      this.pn7.Location = new Point(389, 503);
      this.pn7.Name = "pn7";
      this.pn7.Size = new Size(188, 74);
      this.pn7.TabIndex = 59;
      this.pn8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pn8.Controls.Add((Control) this.bunifuImageButton8);
      this.pn8.Controls.Add((Control) this.lblLoinhuanDauTu_Loto);
      this.pn8.Controls.Add((Control) this.label35);
      this.pn8.Location = new Point(580, 503);
      this.pn8.Name = "pn8";
      this.pn8.Size = new Size(188, 74);
      this.pn8.TabIndex = 59;
      this.bunifuImageButton8.BackColor = Color.Transparent;
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Dock = DockStyle.Bottom;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(0, 6);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(188, 27);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 7;
      this.bunifuImageButton8.TabStop = false;
      this.bunifuImageButton8.Zoom = 0;
      this.pn9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pn9.Controls.Add((Control) this.bunifuImageButton9);
      this.pn9.Controls.Add((Control) this.lblTongthuTuDacBiet);
      this.pn9.Controls.Add((Control) this.label37);
      this.pn9.Location = new Point(771, 503);
      this.pn9.Name = "pn9";
      this.pn9.Size = new Size(188, 74);
      this.pn9.TabIndex = 59;
      this.pn10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pn10.Controls.Add((Control) this.bunifuImageButton10);
      this.pn10.Controls.Add((Control) this.lblLoinhuanDauTu_DacBiet);
      this.pn10.Controls.Add((Control) this.label39);
      this.pn10.Location = new Point(962, 503);
      this.pn10.Name = "pn10";
      this.pn10.Size = new Size(188, 74);
      this.pn10.TabIndex = 59;
      this.stt.DataPropertyName = "Stt";
      this.stt.HeaderText = "stt";
      this.stt.Name = "stt";
      this.stt.ReadOnly = true;
      this.stt.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.stt.Visible = false;
      this.stt.Width = 5;
      this.sothutu.DataPropertyName = "Sothutu";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = Color.Black;
      this.sothutu.DefaultCellStyle = gridViewCellStyle3;
      this.sothutu.HeaderText = "STT ";
      this.sothutu.Name = "sothutu";
      this.sothutu.ReadOnly = true;
      this.sothutu.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.sothutu.ToolTipText = "Số thứ tự";
      this.sothutu.Width = 50;
      this.nguonloto.DataPropertyName = "nguonloto";
      this.nguonloto.HeaderText = "Nguồn Loto";
      this.nguonloto.Name = "nguonloto";
      this.nguonloto.ReadOnly = true;
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
      this.soChot.Width = 120;
      this.tongDiem.DataPropertyName = "tongDiem";
      this.tongDiem.HeaderText = "Tổng điểm";
      this.tongDiem.Name = "tongDiem";
      this.tongDiem.ReadOnly = true;
      this.tongDiem.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.tongDiem.ToolTipText = "Tổng số điểm đánh";
      this.tongDiem.Width = 80;
      this.soLove.DataPropertyName = "SoLove";
      gridViewCellStyle5.ForeColor = Color.Red;
      this.soLove.DefaultCellStyle = gridViewCellStyle5;
      this.soLove.HeaderText = "Về(điểm)";
      this.soLove.Name = "soLove";
      this.soLove.ReadOnly = true;
      this.soLove.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.soLove.ToolTipText = "Số điểm được ăn hôm nay";
      this.soLove.Width = 80;
      this.soVon.DataPropertyName = "SoVon";
      this.soVon.HeaderText = "Vốn";
      this.soVon.Name = "soVon";
      this.soVon.ReadOnly = true;
      this.soVon.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.soVon.ToolTipText = "Số vốn bỏ ra";
      this.soVon.Width = 130;
      this.soLai.DataPropertyName = "SoLai";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle6.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle6.ForeColor = Color.Red;
      this.soLai.DefaultCellStyle = gridViewCellStyle6;
      this.soLai.HeaderText = "Lãi";
      this.soLai.Name = "soLai";
      this.soLai.ReadOnly = true;
      this.soLai.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.soLai.ToolTipText = "Số lãi nhận được";
      this.soLai.Width = 130;
      this.hinhThucDanh.DataPropertyName = "HinhThucDanh";
      gridViewCellStyle7.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.hinhThucDanh.DefaultCellStyle = gridViewCellStyle7;
      this.hinhThucDanh.HeaderText = "Chốt";
      this.hinhThucDanh.Name = "hinhThucDanh";
      this.hinhThucDanh.ReadOnly = true;
      this.hinhThucDanh.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.ngayDanh.DataPropertyName = "NgayDanh";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle8.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle8.ForeColor = Color.Black;
      this.ngayDanh.DefaultCellStyle = gridViewCellStyle8;
      this.ngayDanh.HeaderText = "Mô tả";
      this.ngayDanh.Name = "ngayDanh";
      this.ngayDanh.ReadOnly = true;
      this.ngayDanh.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.ngayDanh.ToolTipText = "Mô tả hình thức chốt";
      this.ngayDanh.Width = 120;
      this.duNo.DataPropertyName = "DuNo";
      gridViewCellStyle9.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle9.ForeColor = Color.Red;
      this.duNo.DefaultCellStyle = gridViewCellStyle9;
      this.duNo.HeaderText = "Dư nợ";
      this.duNo.Name = "duNo";
      this.duNo.ReadOnly = true;
      this.duNo.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.duNo.ToolTipText = "Lưu trữ dư nợ hàng ngày của bạn";
      this.duNo.Width = 110;
      this.ngayChot.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.ngayChot.DataPropertyName = "NgayChot";
      gridViewCellStyle10.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle10.ForeColor = Color.Black;
      this.ngayChot.DefaultCellStyle = gridViewCellStyle10;
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
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.pn10);
      this.Controls.Add((Control) this.pn9);
      this.Controls.Add((Control) this.pn8);
      this.Controls.Add((Control) this.pn7);
      this.Controls.Add((Control) this.pn6);
      this.Controls.Add((Control) this.pn5);
      this.Controls.Add((Control) this.panel7);
      this.Controls.Add((Control) this.panel2);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabThongkeCanhan);
      this.Size = new Size(1155, 590);
      this.Load += new EventHandler(this.TabThongkeCanhanLoad);
      this.panel2.ResumeLayout(false);
      this.pn4.ResumeLayout(false);
      this.pn4.PerformLayout();
      this.bunifuImageButton4.EndInit();
      this.pn3.ResumeLayout(false);
      this.pn3.PerformLayout();
      this.bunifuImageButton3.EndInit();
      this.pn2.ResumeLayout(false);
      this.pn2.PerformLayout();
      this.bunifuImageButton2.EndInit();
      this.pn1.ResumeLayout(false);
      this.pn1.PerformLayout();
      this.bunifuImageButton1.EndInit();
      this.bunifuImageButton5.EndInit();
      this.bunifuImageButton6.EndInit();
      this.bunifuImageButton7.EndInit();
      this.bunifuImageButton9.EndInit();
      this.bunifuImageButton10.EndInit();
      this.panel7.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.pn5.ResumeLayout(false);
      this.pn6.ResumeLayout(false);
      this.pn7.ResumeLayout(false);
      this.pn8.ResumeLayout(false);
      this.bunifuImageButton8.EndInit();
      this.pn9.ResumeLayout(false);
      this.pn10.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public class ValueControl
    {
      public Decimal Tonglaithangnay { get; set; }

      public Decimal TongVonthangnay { get; set; }

      public Decimal TonglaiThangTruoc { get; set; }

      public Decimal LoinhuanDauTuCuathang { get; set; }

      public Decimal TonglaichukiHientai { get; set; }

      public Decimal TongVontrongchuki { get; set; }

      public Decimal LoinhuanDauTuCuaChuKi { get; set; }

      public Decimal MuctieuChuKi { get; set; }

      public Decimal HoanThanhMucTieu { get; set; }

      public Decimal MucTieuConLai { get; set; }

      public Decimal TongthuCuaNam { get; set; }

      public Decimal TongVonCuaNam { get; set; }

      public Decimal TrungBinhMoiChuKi { get; set; }

      public Decimal TongThuTuLoto { get; set; }

      public Decimal TongVonTuLoto { get; set; }

      public Decimal TongThuTuDacbiet { get; set; }

      public Decimal TongVonTuDacbiet { get; set; }

      public Decimal LoiNhuanDauTuLoto { get; set; }

      public Decimal LoiNhuanDauTuDacBiet { get; set; }

      public DataTable DtgView { get; set; }

      public Chart ChartChuki { get; set; }
    }
  }
}
