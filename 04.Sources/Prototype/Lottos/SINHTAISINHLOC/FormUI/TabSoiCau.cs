// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabSoiCau
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
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabSoiCau : UserControl
  {
    private int _biendotrungdau = 2;
    private int _biendotrungduoi = 2;
    private string lotoCbb = "00";
    private DateTime _ngaykiemtracu = DateTime.Now.AddYears(-3);
    private int sobanghivetruocCu = 100;
    private string loaiLoto = "locap";
    private string strHtml = "";
    private IContainer components = (IContainer) null;
    private DataTable _dtCau;
    private DataTable _dtVitri;
    private DataTable _dtLoto;
    private string VT1;
    private string VT2;
    private string LoVT1;
    private string LoVT2;
    private int songaycauchay;
    public List<TabSoiCau.LOTO> ListLotoCap;
    public List<TabSoiCau.LOTO> ListLotoBachThu;
    public List<TabSoiCau.LOTO> ListLotoTrungDau;
    public List<TabSoiCau.LOTO> ListLotoTrungDuoi;
    public List<TabSoiCau.LOTO> ListLotoChuan;
    private int _cbbXetTheo;
    private DataTable dtKetqua;
    private readonly Tbloto _objLOTO;
    private readonly TbVitri _objVitri1;
    private TabSoiCau.LotoVitri lotoVitri;
    private string[] loBiendoi;
    private DataTable _dtLoto1000ngay;
    private DataTable _dtVitri1000ngay;
    private const int sobanghiLichsu = 1095;
    private DataTable dataTableLichSuCau;
    private int lotoKT;
    private int _khoangcach;
    private TbVitri _objVitri;
    private Tbketqua _obj;
    private int _rowIndex;
    private DataGridView.HitTestInfo _myHitTestDown;
    private BunifuElipse bunifuElipse1;
    private Panel panel1;
    private Button btnThongke;
    private Panel panel2;
    private ToolTip toolTip1;
    private Label label13;
    private DateTimePicker dtNgaykiemtra;
    private ComboBox cbbDodaicauchay;
    private BackgroundWorker bgKhoitaodulieu;
    private BackgroundWorker bgGetDataNgayKiemTra;
    private Panel panel4;
    private Panel panel3;
    private DataGridView dtg_Ketqua;
    private Timer timerProcess;
    private Label label2;
    private ComboBox cbbXettheo;
    private ComboBox cbbLoto;
    private Label label3;
    private ComboBox cbbLoaiLoto;
    private NumericUpDown numTien;
    private NumericUpDown numLui;
    private Label label10;
    private Label label12;
    private Panel pnLuitien;
    private WebBrowser wbHienthi;
    private BackgroundWorker bgChitietcauchay;
    private PictureBox picLoading;
    private Timer timer1;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn vt111;
    private DataGridViewTextBoxColumn vt222;
    private DataGridViewTextBoxColumn loto;
    private DataGridViewTextBoxColumn dodai;
    private DataGridViewTextBoxColumn vengay;
    private Label label4;
    private BackgroundWorker bgLoadInfoCau;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem xemChiTiếtCầuChạyToolStripMenuItem;
    private ToolStripMenuItem tầnXuấtBộSốToolStripMenuItem;
    private ToolStripMenuItem chuKỳCủaBộToolStripMenuItem;
    private GroupBox groupBox1;

    public TabSoiCau()
    {
      this.InitializeComponent();
      this.dtNgaykiemtra.Value = FMain.NgayKetQuaMoiNhat;
      this.cbbDodaicauchay.SelectedIndex = 0;
      this._objLOTO = new Tbloto();
      this._objVitri1 = new TbVitri();
      this.cbbXettheo.SelectedIndex = 0;
      this.wbHienthi.IsWebBrowserContextMenuEnabled = false;
      this.wbHienthi.AllowWebBrowserDrop = false;
      this.timer1.Start();
      this.picLoading.Location = new Point(this.dtg_Ketqua.Width / 2 - 10, this.picLoading.Location.Y);
      if (!this.bgKhoitaodulieu.IsBusy)
        this.bgKhoitaodulieu.RunWorkerAsync();
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Tahoma"), 8f, FontStyle.Regular);
    }

    private void KhoiTaoDTCau()
    {
      this._dtCau = new DataTable();
      this._dtCau.Columns.Add("stt", typeof (int));
      this._dtCau.Columns.Add("loto", typeof (string));
      this._dtCau.Columns.Add("vt111", typeof (string));
      this._dtCau.Columns.Add("vt222", typeof (string));
      this._dtCau.Columns.Add("dodai", typeof (int));
      this._dtCau.Columns.Add("vengay", typeof (string));
    }

    public void AddROW(int _stt, string _loto, string _vt1, string _vt2, string _dodai, string _vengay)
    {
      DataRow row = this._dtCau.NewRow();
      row[0] = (object) _stt;
      row[1] = (object) _loto;
      row[2] = (object) _vt1;
      row[3] = (object) _vt2;
      row[4] = (object) _dodai;
      row[5] = (object) _vengay;
      this._dtCau.Rows.Add(row);
    }

    private void CbbSongaySelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void AddLotoToCbb(List<TabSoiCau.LOTO> listlotochuan)
    {
      if (listlotochuan == null || listlotochuan.Count <= 0)
        return;
      this.cbbLoto.Items.Clear();
      foreach (TabSoiCau.LOTO loto in listlotochuan)
      {
        if (this.cbbLoaiLoto.SelectedIndex == 1)
          this.cbbLoto.Items.Add((object) loto.LOTO1);
        else
          this.cbbLoto.Items.Add((object) (loto.LOTO1 + "-" + loto.LOTO2));
      }
      this.cbbLoto.SelectedIndex = 0;
    }

    private void BgKhoitaodulieuDoWork(object sender, DoWorkEventArgs e)
    {
      this.TaoListLotoCap();
      this.TaoListLotoBachThu();
      this.ListLotoChuan = new List<TabSoiCau.LOTO>((IEnumerable<TabSoiCau.LOTO>) this.ListLotoCap);
    }

    public void TaoListLotoCap()
    {
      this.ListLotoCap = new List<TabSoiCau.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabSoiCau.LOTO LOTO = new TabSoiCau.LOTO()
        {
          LOTO1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          LOTO.LOTO1 = "0" + (object) index;
        LOTO.LOTO2 = ClMain.check_Loto_Cap(LOTO.LOTO1);
        if (Convert.ToInt32(LOTO.LOTO1) > Convert.ToInt32(LOTO.LOTO2))
        {
          LOTO.LOTO1 = LOTO.LOTO2;
          LOTO.LOTO2 = ClMain.check_Loto_Cap(LOTO.LOTO1);
        }
        if (this.ListLotoCap.Count > 0)
        {
          if (!this.ListLotoCap.Any<TabSoiCau.LOTO>((Func<TabSoiCau.LOTO, bool>) (lo => LOTO.LOTO1 == lo.LOTO1)))
            this.ListLotoCap.Add(LOTO);
        }
        else
          this.ListLotoCap.Add(LOTO);
      }
    }

    private void TaoListLotoBachThu()
    {
      this.ListLotoBachThu = new List<TabSoiCau.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabSoiCau.LOTO loto = new TabSoiCau.LOTO()
        {
          LOTO1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.LOTO1 = "0" + (object) index;
        loto.LOTO2 = loto.LOTO1;
        this.ListLotoBachThu.Add(loto);
      }
    }

    private void TaoListLotoTrungDau(int biendo)
    {
      this.ListLotoTrungDau = new List<TabSoiCau.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabSoiCau.LOTO loto = new TabSoiCau.LOTO()
        {
          LOTO1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.LOTO1 = "0" + (object) index;
        loto.LOTO2 = this.BienDoiLoToTrungDau(loto.LOTO1, biendo);
        if (!(loto.LOTO2 == ""))
          this.ListLotoTrungDau.Add(loto);
      }
    }

    private void TaoListLotoTrungDuoi(int biendo)
    {
      this.ListLotoTrungDuoi = new List<TabSoiCau.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabSoiCau.LOTO loto = new TabSoiCau.LOTO()
        {
          LOTO1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.LOTO1 = "0" + (object) index;
        loto.LOTO2 = this.BienDoiLoToTrungDuoi(loto.LOTO1, biendo);
        if (!(loto.LOTO2 == ""))
          this.ListLotoTrungDuoi.Add(loto);
      }
    }

    private string BienDoiLoToTrungDau(string lototrungdau, int bienDo)
    {
      string str = (int.Parse(lototrungdau) + bienDo).ToString((IFormatProvider) CultureInfo.InvariantCulture);
      if (str.Length < 2)
        str = "0" + str;
      if (lototrungdau.Substring(0, 1) != str.Substring(0, 1))
        str = "";
      return str;
    }

    private string BienDoiLoToTrungDuoi(string lotoTam, int bienDo)
    {
      string s = (int.Parse(lotoTam.Substring(0, 1)) + bienDo).ToString((IFormatProvider) CultureInfo.InvariantCulture) + lotoTam.Substring(1, 1);
      if (lotoTam.Substring(1, 1) != s.Substring(1, 1))
        s = "";
      else if (int.Parse(s) > 99)
        s = "";
      return s;
    }

    private void BtnThongkeClick(object sender, EventArgs e)
    {
      if (this.numTien.Enabled)
      {
        if (this.numLui.Value == this.numTien.Value)
        {
          if (MessageBox.Show(Resources.TabSoiCau_BtnThongkeClick_Lô_lùi_và_lô_tiến_bằng_nhau__bạn_có_muốn_chuyển_sang_xem_cầu_bạch_thủ__, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
          {
            this.cbbLoaiLoto.SelectedIndex = 1;
          }
          else
          {
            this.numLui.Focus();
            return;
          }
        }
        else if (this.numLui.Value > this.numTien.Value)
        {
          int num = (int) MessageBox.Show(Resources.tabGepCau_btnThongke_Click_LÔ_TÔ__LÙI__PHẢI_NHỎ_HƠN_LÔ_TÔ___TIẾN__BẠN_NHÉ__, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.numLui.Focus();
          return;
        }
      }
      this.timer1.Start();
      this._cbbXetTheo = this.cbbXettheo.SelectedIndex;
      this.lotoCbb = this.cbbLoto.SelectedItem.ToString();
      this.songaycauchay = !this.cbbDodaicauchay.Visible ? 15 : this.cbbDodaicauchay.SelectedIndex + 2;
      if (this.bgGetDataNgayKiemTra.IsBusy)
        return;
      this.KhoiTaoDTCau();
      this.bgGetDataNgayKiemTra.RunWorkerAsync();
      if (this.dtg_Ketqua.Rows.Count > 0)
        this.dtg_Ketqua.DataSource = (object) null;
      this.dtNgaykiemtra.Focus();
    }

    private void BgGetDataNgayKiemTraDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetData(this.dtNgaykiemtra.Value, this.songaycauchay);
      this.sobanghivetruocCu = this.songaycauchay;
    }

    private void Lichsucau(string _vt1, string _vt2)
    {
      this.dataTableLichSuCau = new DataTable();
      this.dataTableLichSuCau.Columns.Add("ngay", typeof (int));
      this.dataTableLichSuCau.Columns.Add("tongsolan", typeof (int));
      DataRow row = this.dataTableLichSuCau.NewRow();
      row[0] = (object) "1";
      row[1] = (object) "0";
      this.dataTableLichSuCau.Rows.Add(row);
      int num1 = 0;
      int num2 = 0;
      if (this._dtLoto1000ngay.Rows.Count >= 1095 && this._dtVitri1000ngay.Rows.Count >= 1095)
      {
        int num3 = 0;
        int dodaicauchay = 0;
        for (int index1 = 0; index1 < this._dtLoto1000ngay.Rows.Count; ++index1)
        {
          bool flag = false;
          this.LoVT1 = this._dtVitri1000ngay.Rows[index1 + 1][_vt1].ToString();
          this.LoVT2 = this._dtVitri1000ngay.Rows[index1 + 1][_vt2].ToString();
          this.loBiendoi = this.BienDoiLoTo(this.LoVT1, this.LoVT2);
          for (int index2 = 2; index2 < this._dtLoto1000ngay.Columns.Count; ++index2)
          {
            if (this._dtLoto1000ngay.Rows[index1][index2].ToString() == this.loBiendoi[0] || this._dtLoto1000ngay.Rows[index1][index2].ToString() == this.loBiendoi[1])
            {
              flag = true;
              break;
            }
          }
          if (flag)
          {
            if (num3 > num2)
              num2 = num3;
            num3 = 0;
            ++dodaicauchay;
          }
          else
          {
            ++num3;
            if (dodaicauchay > 0)
              this.ThemDuLieu_LichSuCau(dodaicauchay);
            if (dodaicauchay > num1)
              num1 = dodaicauchay;
            dodaicauchay = 0;
          }
        }
      }
      DataView defaultView = this.dataTableLichSuCau.DefaultView;
      defaultView.Sort = "ngay ASC";
      this.dataTableLichSuCau = defaultView.ToTable();
      if (this.dataTableLichSuCau.Rows.Count <= 0)
        return;
      string str1 = "";
      int num4 = 0;
      int num5 = 0;
      for (int index = 0; index < this.dataTableLichSuCau.Rows.Count; ++index)
      {
        int int32_1 = Convert.ToInt32(this.dataTableLichSuCau.Rows[index][1].ToString());
        int int32_2 = Convert.ToInt32(this.dataTableLichSuCau.Rows[index][0].ToString());
        num4 += int32_1;
        num5 += int32_1 * int32_2;
        str1 = str1 + "Ngày " + (object) int32_2 + " - <b style='color:red;'>" + (object) int32_1 + "</b> lần. ";
      }
      string str2 = !(this.dataTableLichSuCau.Rows[this.dataTableLichSuCau.Rows.Count - 1][1].ToString() == "1") ? "có " + this.dataTableLichSuCau.Rows[this.dataTableLichSuCau.Rows.Count - 1][1] + " lần ." : "1 lần duy nhất .";
      this.strHtml = "<div style='border:0px dotted #000000;height:auto;float:left;width:auto;margin-left:20px;font-family: arial;margin-top:0px;font-size:14px;'>";
      this.strHtml = this.strHtml + "Trong <b style='color:red;'>" + (object) 1095 + "</b> ngày vừa qua cầu ở vị trí [<span style='color: Red;'>" + _vt1 + "</span>] - [<span style='color:Blue;'>" + _vt2 + "</span>] chạy tất cả <span style='color: #FF0000;'>" + (object) num4 + "</span> lần <span style='color: #FF0000;'>" + (object) num5 + "</span> ngày. Cầu chạy dài nhất là (<b style='color:red;'>" + (object) num1 + "</b>) ngày " + str2 + "<br>";
      this.strHtml = this.strHtml + "Mức gan lớn nhất để cầu chạy lại là  (<b style='color:red;'>" + (object) num2 + "</b>) ngày, Trung bình cứ  (<b style='color:red;'>" + (object) Math.Round(Convert.ToDouble(1095) / Convert.ToDouble(num5), 2) + "</b>) ngày cầu sẽ chạy lại một lần. Chi tiết các lần cầu chạy như sau :<br>";
      this.strHtml = this.strHtml + str1 + "<br>";
      this.strHtml += "<i style='color:red;'>Gợi ý : hiểu rõ các thông số của cầu để làm cơ sở nắm bắt xem khả năng chạy tiếp của cầu . </i><br>";
      this.strHtml += "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
      this.strHtml += "</div>";
    }

    private void ThemDuLieu_LichSuCau(int dodaicauchay)
    {
      if (this.dataTableLichSuCau.Rows.Count <= 0)
        return;
      bool flag = false;
      for (int index = 0; index < this.dataTableLichSuCau.Rows.Count; ++index)
      {
        if (this.dataTableLichSuCau.Rows[index][0].ToString() == dodaicauchay.ToString())
        {
          this.dataTableLichSuCau.Rows[index][1] = (object) (Convert.ToInt32(this.dataTableLichSuCau.Rows[index][1]) + 1);
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        DataRow row = this.dataTableLichSuCau.NewRow();
        row[0] = (object) dodaicauchay;
        row[1] = (object) 1;
        this.dataTableLichSuCau.Rows.Add(row);
      }
    }

    private void GetData(DateTime ngaykiemtra, int sobanghivetruoc)
    {
      if (this._ngaykiemtracu != ngaykiemtra)
      {
        this._dtLoto1000ngay = new DataTable();
        this._dtLoto1000ngay = this._objLOTO.TblotoGetByDateSoBanGhiTrovetruoc(ngaykiemtra, 1095);
        this._dtVitri1000ngay = new DataTable();
        this._dtVitri1000ngay = this._objVitri1.GetVitriByDateAndSobanghi(ngaykiemtra, 1096);
      }
      if (this._ngaykiemtracu != ngaykiemtra || this.sobanghivetruocCu != sobanghivetruoc)
      {
        this._dtLoto = new DataTable();
        this._dtLoto = this._objLOTO.TblotoGetByDateSoBanGhiTrovetruoc(ngaykiemtra, sobanghivetruoc + 1);
        this._dtVitri = new DataTable();
        this._dtVitri = this._objVitri1.GetVitriByDateAndSobanghi(ngaykiemtra, sobanghivetruoc + 2);
        this._ngaykiemtracu = this.dtNgaykiemtra.Value;
        this.dtKetqua = new DataTable();
        this.dtKetqua = Tbketqua.GetKetquaNgayKetthucSobanghi(ngaykiemtra, sobanghivetruoc + 1);
      }
      if (this._dtLoto.Rows.Count <= 0 || this._dtVitri.Rows.Count <= 0 || this.ListLotoChuan.Count <= 0)
        return;
      List<TabSoiCau.LotoVitri> lotoVitriList = new List<TabSoiCau.LotoVitri>();
      for (int index1 = 0; index1 < this.ListLotoChuan.Count; ++index1)
      {
        bool flag = false;
        for (int index2 = 2; index2 < this._dtLoto.Columns.Count; ++index2)
        {
          string str = this._dtLoto.Rows[0][index2].ToString();
          if (str == this.ListLotoChuan[index1].LOTO1 || str == this.ListLotoChuan[index1].LOTO2)
          {
            flag = true;
            break;
          }
        }
        if (flag)
        {
          for (int index2 = 0; index2 <= 9; ++index2)
          {
            this.lotoVitri = new TabSoiCau.LotoVitri();
            this.lotoVitri.lotoVT1 = this.ListLotoChuan[index1].LOTO1.Substring(0, 1);
            this.lotoVitri.lotoVT2 = index2.ToString();
            this.loBiendoi = this.BienDoiLoTo(this.lotoVitri.lotoVT1, this.lotoVitri.lotoVT2);
            if (this.loBiendoi[0] == this.ListLotoChuan[index1].LOTO1 && this.loBiendoi[1] == this.ListLotoChuan[index1].LOTO2)
              lotoVitriList.Add(this.lotoVitri);
          }
        }
      }
      for (int index1 = 0; index1 < lotoVitriList.Count; ++index1)
      {
        DataTable dataTable1 = new DataTable();
        dataTable1.Columns.Add("vt1");
        dataTable1.Columns.Add("loDau");
        DataTable dataTable2 = new DataTable();
        dataTable2.Columns.Add("vt1");
        dataTable2.Columns.Add("loDuoi");
        for (int index2 = 2; index2 < this._dtVitri.Columns.Count; ++index2)
        {
          if (this._dtVitri.Rows[1][index2].ToString() == lotoVitriList[index1].lotoVT1)
          {
            DataRow row = dataTable1.NewRow();
            row[0] = (object) this._dtVitri.Columns[index2].ToString();
            row[1] = (object) lotoVitriList[index1].lotoVT1;
            dataTable1.Rows.Add(row);
          }
          if (this._dtVitri.Rows[1][index2].ToString() == lotoVitriList[index1].lotoVT2)
          {
            DataRow row = dataTable2.NewRow();
            row[0] = (object) this._dtVitri.Columns[index2].ToString();
            row[1] = (object) lotoVitriList[index1].lotoVT2;
            dataTable2.Rows.Add(row);
          }
        }
        for (int index2 = 0; index2 < dataTable1.Rows.Count; ++index2)
        {
          for (int index3 = 0; index3 < dataTable2.Rows.Count; ++index3)
          {
            string _vt1 = dataTable1.Rows[index2][0].ToString();
            string _vt2 = dataTable2.Rows[index3][0].ToString();
            string[] strArray = this.BienDoiLoTo(this._dtVitri.Rows[0][_vt1].ToString(), this._dtVitri.Rows[0][_vt2].ToString());
            string _loto = strArray[0] + "-" + strArray[1];
            if (this.loaiLoto == "lobachthu")
              _loto = strArray[0];
            this.AddROW(this._dtCau.Rows.Count + 1, _loto, _vt1, _vt2, "0", "");
          }
        }
      }
      DataTable dataTable = this._dtCau.Copy();
      for (int index1 = 0; index1 < dataTable.Rows.Count; ++index1)
      {
        this.VT1 = dataTable.Rows[index1][2].ToString();
        this.VT2 = dataTable.Rows[index1][3].ToString();
        int num = 0;
        for (int index2 = 0; index2 < this._dtLoto.Rows.Count; ++index2)
        {
          bool flag = false;
          this.LoVT1 = this._dtVitri.Rows[index2 + 1][this.VT1].ToString();
          this.LoVT2 = this._dtVitri.Rows[index2 + 1][this.VT2].ToString();
          string[] strArray = this.BienDoiLoTo(this.LoVT1, this.LoVT2);
          for (int index3 = 2; index3 < this._dtLoto.Columns.Count; ++index3)
          {
            string str = this._dtLoto.Rows[index2][index3].ToString();
            if (str == strArray[0] || str == strArray[1])
            {
              ++num;
              flag = true;
              break;
            }
          }
          if (!flag)
            break;
        }
        if (this._cbbXetTheo == 0)
        {
          for (int index2 = 0; index2 < this._dtCau.Rows.Count; ++index2)
          {
            if (this._dtCau.Rows[index2][2].ToString() == this.VT1 && this._dtCau.Rows[index2][3].ToString() == this.VT2)
            {
              if (this.songaycauchay == num)
              {
                this._dtCau.Rows[index2]["dodai"] = (object) num;
                break;
              }
              this._dtCau.Rows.RemoveAt(index2);
              break;
            }
          }
        }
        else
        {
          for (int index2 = 0; index2 < this._dtCau.Rows.Count; ++index2)
          {
            if (this._dtCau.Rows[index2][2].ToString() == this.VT1 && this._dtCau.Rows[index2][3].ToString() == this.VT2)
            {
              if (this.lotoCbb == this._dtCau.Rows[index2]["loto"].ToString())
              {
                this._dtCau.Rows[index2]["dodai"] = (object) num;
                break;
              }
              this._dtCau.Rows.RemoveAt(index2);
              break;
            }
          }
        }
      }
    }

    public string CheckLotoCap(string lotoCheckCap)
    {
      string str;
      switch (lotoCheckCap)
      {
        case "00":
          str = "55";
          break;
        case "11":
          str = "66";
          break;
        case "22":
          str = "77";
          break;
        case "33":
          str = "88";
          break;
        case "44":
          str = "99";
          break;
        case "55":
          str = "00";
          break;
        case "66":
          str = "11";
          break;
        case "77":
          str = "22";
          break;
        case "88":
          str = "33";
          break;
        case "99":
          str = "44";
          break;
        default:
          str = lotoCheckCap.Substring(1, 1) + lotoCheckCap.Substring(0, 1);
          break;
      }
      return str;
    }

    private string[] BienDoiLoTo(string soVitri1, string soVitri2)
    {
      this._khoangcach = Convert.ToInt32(this.numTien.Value - this.numLui.Value);
      string[] strArray1 = new string[2]{ "", "" };
      try
      {
      }
      catch
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      this.lotoKT = int.Parse(soVitri1 + soVitri2);
      if (this.loaiLoto == "locap")
      {
        strArray1[0] = ((Decimal) this.lotoKT + this.numLui.Value).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (int.Parse(strArray1[0]) <= 0)
          strArray1[0] = "00";
        else if (int.Parse(strArray1[0]) < 10 && int.Parse(strArray1[0]) > 0)
          strArray1[0] = "0" + strArray1[0];
        else if (int.Parse(strArray1[0]) > 99)
          strArray1[0] = "99";
        strArray1[1] = this.CheckLotoCap(strArray1[0]);
      }
      if (this.loaiLoto == "lobachthu")
      {
        strArray1[0] = ((Decimal) this.lotoKT + this.numLui.Value).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray1[0]) <= 0)
          strArray1[0] = "00";
        else if (int.Parse(strArray1[0]) < 10 && int.Parse(strArray1[0]) > 0)
          strArray1[0] = "0" + strArray1[0];
        else if (int.Parse(strArray1[0]) > 99)
          strArray1[0] = "99";
        strArray1[1] = strArray1[0];
      }
      int num;
      if (this.loaiLoto == "lotrungdau")
      {
        strArray1[0] = ((Decimal) int.Parse(soVitri2) + this.numLui.Value).ToString();
        strArray1[1] = ((Decimal) int.Parse(soVitri2) + this.numTien.Value).ToString();
        if (int.Parse(strArray1[0]) <= 0)
        {
          strArray1[0] = "0";
          strArray1[1] = this._khoangcach.ToString();
        }
        if (int.Parse(strArray1[1]) > 9)
        {
          strArray1[0] = "9";
          string[] strArray2 = strArray1;
          int index = 1;
          num = 9 - this._khoangcach;
          string str = num.ToString();
          strArray2[index] = str;
        }
        strArray1[0] = soVitri1 + strArray1[0];
        strArray1[1] = soVitri1 + strArray1[1];
      }
      if (this.loaiLoto == "lotrungduoi")
      {
        strArray1[0] = ((Decimal) int.Parse(soVitri1) + this.numLui.Value).ToString();
        strArray1[1] = ((Decimal) int.Parse(soVitri1) + this.numTien.Value).ToString();
        if (int.Parse(strArray1[0]) <= 0)
        {
          strArray1[0] = "0";
          strArray1[1] = this._khoangcach.ToString();
        }
        if (int.Parse(strArray1[1]) > 9)
        {
          strArray1[0] = "9";
          string[] strArray2 = strArray1;
          int index = 1;
          num = 9 - this._khoangcach;
          string str = num.ToString();
          strArray2[index] = str;
        }
        strArray1[0] = strArray1[0] + soVitri2;
        strArray1[1] = strArray1[1] + soVitri2;
      }
      string str1 = strArray1[0];
      if (int.Parse(strArray1[1]) < int.Parse(strArray1[0]))
      {
        strArray1[0] = strArray1[1];
        strArray1[1] = str1;
      }
      return strArray1;
    }

    private void DTNgaykiemtraValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgaykiemtra.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dtNgaykiemtra.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void BgKhoitaodulieuRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.AddLotoToCbb(this.ListLotoChuan);
      this.cbbLoto.SelectedIndex = 0;
      this.cbbLoaiLoto.SelectedIndex = 0;
    }

    private void TimerProcessTick(object sender, EventArgs e)
    {
      this.btnThongke.Enabled = !this.bgKhoitaodulieu.IsBusy;
    }

    private void CbbXettheoSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbbXettheo.SelectedIndex == 0)
      {
        this.cbbLoto.Visible = false;
        this.cbbDodaicauchay.Visible = true;
        this.cbbDodaicauchay.Location = new Point(717, 12);
      }
      else
      {
        this.cbbLoto.Visible = true;
        this.cbbDodaicauchay.Visible = false;
        this.cbbLoto.Location = new Point(717, 12);
      }
    }

    private void cbbLoaiLoto_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.TaoDanhSachLoToChuan();
    }

    private void TaoDanhSachLoToChuan()
    {
      if (this.cbbLoaiLoto.SelectedIndex == 0)
      {
        this.loaiLoto = "locap";
        this.TaoListLotoCap();
        this.ListLotoChuan = new List<TabSoiCau.LOTO>((IEnumerable<TabSoiCau.LOTO>) this.ListLotoCap);
        this.AddLotoToCbb(this.ListLotoChuan);
        this.numLui.Enabled = true;
        this.numTien.Enabled = false;
      }
      if (this.cbbLoaiLoto.SelectedIndex == 1)
      {
        this.loaiLoto = "lobachthu";
        this.TaoListLotoBachThu();
        this.ListLotoChuan = new List<TabSoiCau.LOTO>((IEnumerable<TabSoiCau.LOTO>) this.ListLotoBachThu);
        this.AddLotoToCbb(this.ListLotoChuan);
        this.numLui.Enabled = true;
        this.numTien.Enabled = false;
      }
      if (this.cbbLoaiLoto.SelectedIndex == 2)
      {
        this.loaiLoto = "lotrungdau";
        this.TaoListLotoTrungDau(this._biendotrungdau);
        this.ListLotoChuan = new List<TabSoiCau.LOTO>((IEnumerable<TabSoiCau.LOTO>) this.ListLotoTrungDau);
        this.AddLotoToCbb(this.ListLotoChuan);
        this.numLui.Enabled = true;
        this.numTien.Enabled = true;
      }
      if (this.cbbLoaiLoto.SelectedIndex != 3)
        return;
      this.loaiLoto = "lotrungduoi";
      this.TaoListLotoTrungDuoi(this._biendotrungduoi);
      this.ListLotoChuan = new List<TabSoiCau.LOTO>((IEnumerable<TabSoiCau.LOTO>) this.ListLotoTrungDuoi);
      this.AddLotoToCbb(this.ListLotoChuan);
      this.numLui.Enabled = true;
      this.numTien.Enabled = true;
    }

    private void cbbLoto_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void bgGetDataNgayKiemTra_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._dtCau.Rows.Count > 0)
      {
        this.dtg_Ketqua.AutoGenerateColumns = false;
        DataView defaultView = this._dtCau.DefaultView;
        defaultView.Sort = this._cbbXetTheo == 0 ? "loto ASC" : "dodai DESC";
        this._dtCau = defaultView.ToTable();
        for (int index = 0; index < this._dtCau.Rows.Count; ++index)
          this._dtCau.Rows[index]["STT"] = (object) (index + 1).ToString();
        this.dtg_Ketqua.DataSource = (object) this._dtCau;
        this._rowIndex = 0;
      }
      else
        this.dtg_Ketqua.DataSource = (object) null;
    }

    private void dtg_Ketqua_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex <= -1)
        ;
    }

    private void dtg_Ketqua_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex <= -1)
        return;
      this._rowIndex = e.RowIndex;
      if (!this.bgLoadInfoCau.IsBusy)
        this.bgLoadInfoCau.RunWorkerAsync();
    }

    private void showInfoCau(string vt1, string vt2, int dodaicau)
    {
      this.StrKetQuaXoSo(this.dtKetqua, vt1, vt2, dodaicau);
    }

    public static void HienThiKetQua(WebBrowser wb, string strHtml)
    {
      string html = "<html><head>\r\n            <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n            <meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\" />\r\n            <style type=\"text/css\">\r\n            .style1{width: 18%;height: 30px;border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;border-bottom-width: 1px;font-size:14px;text-align:center;}\r\n            .style2 {text-align: center;height: 31px;font-size: 17px;border-bottom-style: dotted;border-bottom-width:1px;border-color: orangered;font-family: arial;}\r\n            .style3{border-color: red;width: 45px; height: 21px; border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;font-size:16px;}\r\n            .style4 {border-color: red;border-bottom-style: dotted; border-bottom-width: 1px;font-size:15px;}\r\n            .main{width:97%;float:right;margin-right:1%;margin-left: auto; margin-top: 0;padding-bottom: 20px;}\r\n            .table_KQ {border: 1px dotted #FF6600; width: 65%; float: left;}\r\n            .title_XS { text-align:center;margin:0px auto;width:75%;float:left;font-size:14px;font-family: arial;}\r\n            .cochu{\r\n            font-size:18px;\r\n                }\r\n            .vt1{color:red;font-size:19px;}\r\n            .vt2{color:blue;font-size:19px;}\r\n             </style>\r\n            \r\n            </head>\r\n            <body oncontextmenu='return false;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void StrKetQuaXoSo(DataTable dtTable, string vt1, string vt2, int dodaicau)
    {
      this._objVitri = new TbVitri();
      if (dtTable.Rows.Count <= 0)
        return;
      for (int index = 0; index < dodaicau; ++index)
      {
        this.LoVT1 = this._dtVitri.Rows[index + 1][vt1].ToString();
        this.LoVT2 = this._dtVitri.Rows[index + 1][vt2].ToString();
        string[] strArray1 = this.BienDoiLoTo(this.LoVT1, this.LoVT2);
        this.LoVT1 = this._dtVitri.Rows[index][vt1].ToString();
        this.LoVT2 = this._dtVitri.Rows[index][vt2].ToString();
        string[] strArray2 = this.BienDoiLoTo(this.LoVT1, this.LoVT2);
        string str = "<b style='color:red;'>" + strArray2[0] + "<sup style='color:red;'>1</sup></b>";
        if (strArray2[0] != strArray2[1])
          str = "<b style='color:red;'>" + strArray2[0] + "<sup style='color:red;'>1</sup></b> - <b style='color:red;'>" + strArray2[1] + "<sup style='color:blue;'>2</sup></b>";
        string loto1 = strArray1[0];
        string loto2 = strArray1[1];
        this._obj = new Tbketqua();
        this._obj.G0 = dtTable.Rows[index]["G0"].ToString();
        this._objVitri.G011 = this._obj.G0.Substring(0, 1);
        this._objVitri.G012 = this._obj.G0.Substring(1, 1);
        this._objVitri.G013 = this._obj.G0.Substring(2, 1);
        this._objVitri.G014 = this._obj.G0.Substring(3, 1);
        this._objVitri.G015 = this._obj.G0.Substring(4, 1);
        this._obj.G1 = dtTable.Rows[index]["G1"].ToString();
        this._objVitri.G111 = this._obj.G1.Substring(0, 1);
        this._objVitri.G112 = this._obj.G1.Substring(1, 1);
        this._objVitri.G113 = this._obj.G1.Substring(2, 1);
        this._objVitri.G114 = this._obj.G1.Substring(3, 1);
        this._objVitri.G115 = this._obj.G1.Substring(4, 1);
        this._obj.G21 = dtTable.Rows[index]["G21"].ToString();
        this._objVitri.G211 = this._obj.G21.Substring(0, 1);
        this._objVitri.G212 = this._obj.G21.Substring(1, 1);
        this._objVitri.G213 = this._obj.G21.Substring(2, 1);
        this._objVitri.G214 = this._obj.G21.Substring(3, 1);
        this._objVitri.G215 = this._obj.G21.Substring(4, 1);
        this._obj.G22 = dtTable.Rows[index]["G22"].ToString();
        this._objVitri.G221 = this._obj.G22.Substring(0, 1);
        this._objVitri.G222 = this._obj.G22.Substring(1, 1);
        this._objVitri.G223 = this._obj.G22.Substring(2, 1);
        this._objVitri.G224 = this._obj.G22.Substring(3, 1);
        this._objVitri.G225 = this._obj.G22.Substring(4, 1);
        this._obj.G31 = dtTable.Rows[index]["G31"].ToString();
        this._objVitri.G311 = this._obj.G31.Substring(0, 1);
        this._objVitri.G312 = this._obj.G31.Substring(1, 1);
        this._objVitri.G313 = this._obj.G31.Substring(2, 1);
        this._objVitri.G314 = this._obj.G31.Substring(3, 1);
        this._objVitri.G315 = this._obj.G31.Substring(4, 1);
        this._obj.G32 = dtTable.Rows[index]["G32"].ToString();
        this._objVitri.G321 = this._obj.G32.Substring(0, 1);
        this._objVitri.G322 = this._obj.G32.Substring(1, 1);
        this._objVitri.G323 = this._obj.G32.Substring(2, 1);
        this._objVitri.G324 = this._obj.G32.Substring(3, 1);
        this._objVitri.G325 = this._obj.G32.Substring(4, 1);
        this._obj.G33 = dtTable.Rows[index]["G33"].ToString();
        this._objVitri.G331 = this._obj.G33.Substring(0, 1);
        this._objVitri.G332 = this._obj.G33.Substring(1, 1);
        this._objVitri.G333 = this._obj.G33.Substring(2, 1);
        this._objVitri.G334 = this._obj.G33.Substring(3, 1);
        this._objVitri.G335 = this._obj.G33.Substring(4, 1);
        this._obj.G34 = dtTable.Rows[index]["G34"].ToString();
        this._objVitri.G341 = this._obj.G34.Substring(0, 1);
        this._objVitri.G342 = this._obj.G34.Substring(1, 1);
        this._objVitri.G343 = this._obj.G34.Substring(2, 1);
        this._objVitri.G344 = this._obj.G34.Substring(3, 1);
        this._objVitri.G345 = this._obj.G34.Substring(4, 1);
        this._obj.G35 = dtTable.Rows[index]["G35"].ToString();
        this._objVitri.G351 = this._obj.G35.Substring(0, 1);
        this._objVitri.G352 = this._obj.G35.Substring(1, 1);
        this._objVitri.G353 = this._obj.G35.Substring(2, 1);
        this._objVitri.G354 = this._obj.G35.Substring(3, 1);
        this._objVitri.G355 = this._obj.G35.Substring(4, 1);
        this._obj.G36 = dtTable.Rows[index]["G36"].ToString();
        this._objVitri.G361 = this._obj.G36.Substring(0, 1);
        this._objVitri.G362 = this._obj.G36.Substring(1, 1);
        this._objVitri.G363 = this._obj.G36.Substring(2, 1);
        this._objVitri.G364 = this._obj.G36.Substring(3, 1);
        this._objVitri.G365 = this._obj.G36.Substring(4, 1);
        this._obj.G41 = dtTable.Rows[index]["G41"].ToString();
        this._objVitri.G411 = this._obj.G41.Substring(0, 1);
        this._objVitri.G412 = this._obj.G41.Substring(1, 1);
        this._objVitri.G413 = this._obj.G41.Substring(2, 1);
        this._objVitri.G414 = this._obj.G41.Substring(3, 1);
        this._obj.G42 = dtTable.Rows[index]["G42"].ToString();
        this._objVitri.G421 = this._obj.G42.Substring(0, 1);
        this._objVitri.G422 = this._obj.G42.Substring(1, 1);
        this._objVitri.G423 = this._obj.G42.Substring(2, 1);
        this._objVitri.G424 = this._obj.G42.Substring(3, 1);
        this._obj.G43 = dtTable.Rows[index]["G43"].ToString();
        this._objVitri.G431 = this._obj.G43.Substring(0, 1);
        this._objVitri.G432 = this._obj.G43.Substring(1, 1);
        this._objVitri.G433 = this._obj.G43.Substring(2, 1);
        this._objVitri.G434 = this._obj.G43.Substring(3, 1);
        this._obj.G44 = dtTable.Rows[index]["G44"].ToString();
        this._objVitri.G441 = this._obj.G44.Substring(0, 1);
        this._objVitri.G442 = this._obj.G44.Substring(1, 1);
        this._objVitri.G443 = this._obj.G44.Substring(2, 1);
        this._objVitri.G444 = this._obj.G44.Substring(3, 1);
        this._obj.G51 = dtTable.Rows[index]["G51"].ToString();
        this._objVitri.G511 = this._obj.G51.Substring(0, 1);
        this._objVitri.G512 = this._obj.G51.Substring(1, 1);
        this._objVitri.G513 = this._obj.G51.Substring(2, 1);
        this._objVitri.G514 = this._obj.G51.Substring(3, 1);
        this._obj.G52 = dtTable.Rows[index]["G52"].ToString();
        this._objVitri.G521 = this._obj.G52.Substring(0, 1);
        this._objVitri.G522 = this._obj.G52.Substring(1, 1);
        this._objVitri.G523 = this._obj.G52.Substring(2, 1);
        this._objVitri.G524 = this._obj.G52.Substring(3, 1);
        this._obj.G53 = dtTable.Rows[index]["G53"].ToString();
        this._objVitri.G531 = this._obj.G53.Substring(0, 1);
        this._objVitri.G532 = this._obj.G53.Substring(1, 1);
        this._objVitri.G533 = this._obj.G53.Substring(2, 1);
        this._objVitri.G534 = this._obj.G53.Substring(3, 1);
        this._obj.G54 = dtTable.Rows[index]["G54"].ToString();
        this._objVitri.G541 = this._obj.G54.Substring(0, 1);
        this._objVitri.G542 = this._obj.G54.Substring(1, 1);
        this._objVitri.G543 = this._obj.G54.Substring(2, 1);
        this._objVitri.G544 = this._obj.G54.Substring(3, 1);
        this._obj.G55 = dtTable.Rows[index]["G55"].ToString();
        this._objVitri.G551 = this._obj.G55.Substring(0, 1);
        this._objVitri.G552 = this._obj.G55.Substring(1, 1);
        this._objVitri.G553 = this._obj.G55.Substring(2, 1);
        this._objVitri.G554 = this._obj.G55.Substring(3, 1);
        this._obj.G56 = dtTable.Rows[index]["G56"].ToString();
        this._objVitri.G561 = this._obj.G56.Substring(0, 1);
        this._objVitri.G562 = this._obj.G56.Substring(1, 1);
        this._objVitri.G563 = this._obj.G56.Substring(2, 1);
        this._objVitri.G564 = this._obj.G56.Substring(3, 1);
        this._obj.G61 = dtTable.Rows[index]["G61"].ToString();
        this._objVitri.G611 = this._obj.G61.Substring(0, 1);
        this._objVitri.G612 = this._obj.G61.Substring(1, 1);
        this._objVitri.G613 = this._obj.G61.Substring(2, 1);
        this._obj.G62 = dtTable.Rows[index]["G62"].ToString();
        this._objVitri.G621 = this._obj.G62.Substring(0, 1);
        this._objVitri.G622 = this._obj.G62.Substring(1, 1);
        this._objVitri.G623 = this._obj.G62.Substring(2, 1);
        this._obj.G63 = dtTable.Rows[index]["G63"].ToString();
        this._objVitri.G631 = this._obj.G63.Substring(0, 1);
        this._objVitri.G632 = this._obj.G63.Substring(1, 1);
        this._objVitri.G633 = this._obj.G63.Substring(2, 1);
        this._obj.G71 = dtTable.Rows[index]["G71"].ToString();
        this._objVitri.G711 = this._obj.G71.Substring(0, 1);
        this._objVitri.G712 = this._obj.G71.Substring(1, 1);
        this._obj.G72 = dtTable.Rows[index]["G72"].ToString();
        this._objVitri.G721 = this._obj.G72.Substring(0, 1);
        this._objVitri.G722 = this._obj.G72.Substring(1, 1);
        this._obj.G73 = dtTable.Rows[index]["G73"].ToString();
        this._objVitri.G731 = this._obj.G73.Substring(0, 1);
        this._objVitri.G732 = this._obj.G73.Substring(1, 1);
        this._obj.G74 = dtTable.Rows[index]["G74"].ToString();
        this._objVitri.G741 = this._obj.G74.Substring(0, 1);
        this._objVitri.G742 = this._obj.G74.Substring(1, 1);
        if ("G0:1:1" == vt1)
          this._objVitri.G011 = "<b class='vt1'>(" + this._objVitri.G011 + ")<sup>1</sup></b>";
        if ("G0:1:1" == vt2)
          this._objVitri.G011 = "<b class='vt2'>(" + this._objVitri.G011 + ")<sup>2</sup></b>";
        if ("G0:1:2" == vt1)
          this._objVitri.G012 = "<b class='vt1'>(" + this._objVitri.G012 + ")<sup>1</sup></b>";
        if ("G0:1:2" == vt2)
          this._objVitri.G012 = "<b class='vt2'>(" + this._objVitri.G012 + ")<sup>2</sup></b>";
        if ("G0:1:3" == vt1)
          this._objVitri.G013 = "<b class='vt1'>(" + this._objVitri.G013 + ")<sup>1</sup></b>";
        if ("G0:1:3" == vt2)
          this._objVitri.G013 = "<b class='vt2'>(" + this._objVitri.G013 + ")<sup>2</sup></b>";
        if ("G0:1:4" == vt1)
          this._objVitri.G014 = "<b class='vt1'>(" + this._objVitri.G014 + ")<sup>1</sup></b>";
        if ("G0:1:4" == vt2)
          this._objVitri.G014 = "<b class='vt2'>(" + this._objVitri.G014 + ")<sup>2</sup></b>";
        if ("G0:1:5" == vt1)
          this._objVitri.G015 = "<b class='vt1'>(" + this._objVitri.G015 + ")<sup>1</sup></b>";
        if ("G0:1:5" == vt2)
          this._objVitri.G015 = "<b class='vt2'>(" + this._objVitri.G015 + ")<sup>2</sup></b>";
        if ("G1:1:1" == vt1)
          this._objVitri.G111 = "<b class='vt1'>(" + this._objVitri.G111 + ")<sup>1</sup></b>";
        if ("G1:1:1" == vt2)
          this._objVitri.G111 = "<b class='vt2'>(" + this._objVitri.G111 + ")<sup>2</sup></b>";
        if ("G1:1:2" == vt1)
          this._objVitri.G112 = "<b class='vt1'>(" + this._objVitri.G112 + ")<sup>1</sup></b>";
        if ("G1:1:2" == vt2)
          this._objVitri.G112 = "<b class='vt2'>(" + this._objVitri.G112 + ")<sup>2</sup></b>";
        if ("G1:1:3" == vt1)
          this._objVitri.G113 = "<b class='vt1'>(" + this._objVitri.G113 + ")<sup>1</sup></b>";
        if ("G1:1:3" == vt2)
          this._objVitri.G113 = "<b class='vt2'>(" + this._objVitri.G113 + ")<sup>2</sup></b>";
        if ("G1:1:4" == vt1)
          this._objVitri.G114 = "<b class='vt1'>(" + this._objVitri.G114 + ")<sup>1</sup></b>";
        if ("G1:1:4" == vt2)
          this._objVitri.G114 = "<b class='vt2'>(" + this._objVitri.G114 + ")<sup>2</sup></b>";
        if ("G1:1:5" == vt1)
          this._objVitri.G115 = "<b class='vt1'>(" + this._objVitri.G115 + ")<sup>1</sup></b>";
        if ("G1:1:5" == vt2)
          this._objVitri.G115 = "<b class='vt2'>(" + this._objVitri.G115 + ")<sup>2</sup></b>";
        if ("G2:1:1" == vt1)
          this._objVitri.G211 = "<b class='vt1'>(" + this._objVitri.G211 + ")<sup>1</sup></b>";
        if ("G2:1:1" == vt2)
          this._objVitri.G211 = "<b class='vt2'>(" + this._objVitri.G211 + ")<sup>2</sup></b>";
        if ("G2:1:2" == vt1)
          this._objVitri.G212 = "<b class='vt1'>(" + this._objVitri.G212 + ")<sup>1</sup></b>";
        if ("G2:1:2" == vt2)
          this._objVitri.G212 = "<b class='vt2'>(" + this._objVitri.G212 + ")<sup>2</sup></b>";
        if ("G2:1:3" == vt1)
          this._objVitri.G213 = "<b class='vt1'>(" + this._objVitri.G213 + ")<sup>1</sup></b>";
        if ("G2:1:3" == vt2)
          this._objVitri.G213 = "<b class='vt2'>(" + this._objVitri.G213 + ")<sup>2</sup></b>";
        if ("G2:1:4" == vt1)
          this._objVitri.G214 = "<b class='vt1'>(" + this._objVitri.G214 + ")<sup>1</sup></b>";
        if ("G2:1:4" == vt2)
          this._objVitri.G214 = "<b class='vt2'>(" + this._objVitri.G214 + ")<sup>2</sup></b>";
        if ("G2:1:5" == vt1)
          this._objVitri.G215 = "<b class='vt1'>(" + this._objVitri.G215 + ")<sup>1</sup></b>";
        if ("G2:1:5" == vt2)
          this._objVitri.G215 = "<b class='vt2'>(" + this._objVitri.G215 + ")<sup>2</sup></b>";
        if ("G2:2:1" == vt1)
          this._objVitri.G221 = "<b class='vt1'>(" + this._objVitri.G221 + ")<sup>1</sup></b>";
        if ("G2:2:1" == vt2)
          this._objVitri.G221 = "<b class='vt2'>(" + this._objVitri.G221 + ")<sup>2</sup></b>";
        if ("G2:2:2" == vt1)
          this._objVitri.G222 = "<b class='vt1'>(" + this._objVitri.G222 + ")<sup>1</sup></b>";
        if ("G2:2:2" == vt2)
          this._objVitri.G222 = "<b class='vt2'>(" + this._objVitri.G222 + ")<sup>2</sup></b>";
        if ("G2:2:3" == vt1)
          this._objVitri.G223 = "<b class='vt1'>(" + this._objVitri.G223 + ")<sup>1</sup></b>";
        if ("G2:2:3" == vt2)
          this._objVitri.G223 = "<b class='vt2'>(" + this._objVitri.G223 + ")<sup>2</sup></b>";
        if ("G2:2:4" == vt1)
          this._objVitri.G224 = "<b class='vt1'>(" + this._objVitri.G224 + ")<sup>1</sup></b>";
        if ("G2:2:4" == vt2)
          this._objVitri.G224 = "<b class='vt2'>(" + this._objVitri.G224 + ")<sup>2</sup></b>";
        if ("G2:2:5" == vt1)
          this._objVitri.G225 = "<b class='vt1'>(" + this._objVitri.G225 + ")<sup>1</sup></b>";
        if ("G2:2:5" == vt2)
          this._objVitri.G225 = "<b class='vt2'>(" + this._objVitri.G225 + ")<sup>2</sup></b>";
        if ("G3:1:1" == vt1)
          this._objVitri.G311 = "<b class='vt1'>(" + this._objVitri.G311 + ")<sup>1</sup></b>";
        if ("G3:1:1" == vt2)
          this._objVitri.G311 = "<b class='vt2'>(" + this._objVitri.G311 + ")<sup>2</sup></b>";
        if ("G3:1:2" == vt1)
          this._objVitri.G312 = "<b class='vt1'>(" + this._objVitri.G312 + ")<sup>1</sup></b>";
        if ("G3:1:2" == vt2)
          this._objVitri.G312 = "<b class='vt2'>(" + this._objVitri.G312 + ")<sup>2</sup></b>";
        if ("G3:1:3" == vt1)
          this._objVitri.G313 = "<b class='vt1'>(" + this._objVitri.G313 + ")<sup>1</sup></b>";
        if ("G3:1:3" == vt2)
          this._objVitri.G313 = "<b class='vt2'>(" + this._objVitri.G313 + ")<sup>2</sup></b>";
        if ("G3:1:4" == vt1)
          this._objVitri.G314 = "<b class='vt1'>(" + this._objVitri.G314 + ")<sup>1</sup></b>";
        if ("G3:1:4" == vt2)
          this._objVitri.G314 = "<b class='vt2'>(" + this._objVitri.G314 + ")<sup>2</sup></b>";
        if ("G3:1:5" == vt1)
          this._objVitri.G315 = "<b class='vt1'>(" + this._objVitri.G315 + ")<sup>1</sup></b>";
        if ("G3:1:5" == vt2)
          this._objVitri.G315 = "<b class='vt2'>(" + this._objVitri.G315 + ")<sup>2</sup></b>";
        if ("G3:2:1" == vt1)
          this._objVitri.G321 = "<b class='vt1'>(" + this._objVitri.G321 + ")<sup>1</sup></b>";
        if ("G3:2:1" == vt2)
          this._objVitri.G321 = "<b class='vt2'>(" + this._objVitri.G321 + ")<sup>2</sup></b>";
        if ("G3:2:2" == vt1)
          this._objVitri.G322 = "<b class='vt1'>(" + this._objVitri.G322 + ")<sup>1</sup></b>";
        if ("G3:2:2" == vt2)
          this._objVitri.G322 = "<b class='vt2'>(" + this._objVitri.G322 + ")<sup>2</sup></b>";
        if ("G3:2:3" == vt1)
          this._objVitri.G323 = "<b class='vt1'>(" + this._objVitri.G323 + ")<sup>1</sup></b>";
        if ("G3:2:3" == vt2)
          this._objVitri.G323 = "<b class='vt2'>(" + this._objVitri.G323 + ")<sup>2</sup></b>";
        if ("G3:2:4" == vt1)
          this._objVitri.G324 = "<b class='vt1'>(" + this._objVitri.G324 + ")<sup>1</sup></b>";
        if ("G3:2:4" == vt2)
          this._objVitri.G324 = "<b class='vt2'>(" + this._objVitri.G324 + ")<sup>2</sup></b>";
        if ("G3:2:5" == vt1)
          this._objVitri.G325 = "<b class='vt1'>(" + this._objVitri.G325 + ")<sup>1</sup></b>";
        if ("G3:2:5" == vt2)
          this._objVitri.G325 = "<b class='vt2'>(" + this._objVitri.G325 + ")<sup>2</sup></b>";
        if ("G3:3:1" == vt1)
          this._objVitri.G331 = "<b class='vt1'>(" + this._objVitri.G331 + ")<sup>1</sup></b>";
        if ("G3:3:1" == vt2)
          this._objVitri.G331 = "<b class='vt2'>(" + this._objVitri.G331 + ")<sup>2</sup></b>";
        if ("G3:3:2" == vt1)
          this._objVitri.G332 = "<b class='vt1'>(" + this._objVitri.G332 + ")<sup>1</sup></b>";
        if ("G3:3:2" == vt2)
          this._objVitri.G332 = "<b class='vt2'>(" + this._objVitri.G332 + ")<sup>2</sup></b>";
        if ("G3:3:3" == vt1)
          this._objVitri.G333 = "<b class='vt1'>(" + this._objVitri.G333 + ")<sup>1</sup></b>";
        if ("G3:3:3" == vt2)
          this._objVitri.G333 = "<b class='vt2'>(" + this._objVitri.G333 + ")<sup>2</sup></b>";
        if ("G3:3:4" == vt1)
          this._objVitri.G334 = "<b class='vt1'>(" + this._objVitri.G334 + ")<sup>1</sup></b>";
        if ("G3:3:4" == vt2)
          this._objVitri.G334 = "<b class='vt2'>(" + this._objVitri.G334 + ")<sup>2</sup></b>";
        if ("G3:3:5" == vt1)
          this._objVitri.G335 = "<b class='vt1'>(" + this._objVitri.G335 + ")<sup>1</sup></b>";
        if ("G3:3:5" == vt2)
          this._objVitri.G335 = "<b class='vt2'>(" + this._objVitri.G335 + ")<sup>2</sup></b>";
        if ("G3:4:1" == vt1)
          this._objVitri.G341 = "<b class='vt1'>(" + this._objVitri.G341 + ")<sup>1</sup></b>";
        if ("G3:4:1" == vt2)
          this._objVitri.G341 = "<b class='vt2'>(" + this._objVitri.G341 + ")<sup>2</sup></b>";
        if ("G3:4:2" == vt1)
          this._objVitri.G342 = "<b class='vt1'>(" + this._objVitri.G342 + ")<sup>1</sup></b>";
        if ("G3:4:2" == vt2)
          this._objVitri.G342 = "<b class='vt2'>(" + this._objVitri.G342 + ")<sup>2</sup></b>";
        if ("G3:4:3" == vt1)
          this._objVitri.G343 = "<b class='vt1'>(" + this._objVitri.G343 + ")<sup>1</sup></b>";
        if ("G3:4:3" == vt2)
          this._objVitri.G343 = "<b class='vt2'>(" + this._objVitri.G343 + ")<sup>2</sup></b>";
        if ("G3:4:4" == vt1)
          this._objVitri.G344 = "<b class='vt1'>(" + this._objVitri.G344 + ")<sup>1</sup></b>";
        if ("G3:4:4" == vt2)
          this._objVitri.G344 = "<b class='vt2'>(" + this._objVitri.G344 + ")<sup>2</sup></b>";
        if ("G3:4:5" == vt1)
          this._objVitri.G345 = "<b class='vt1'>(" + this._objVitri.G345 + ")<sup>1</sup></b>";
        if ("G3:4:5" == vt2)
          this._objVitri.G345 = "<b class='vt2'>(" + this._objVitri.G345 + ")<sup>2</sup></b>";
        if ("G3:5:1" == vt1)
          this._objVitri.G351 = "<b class='vt1'>(" + this._objVitri.G351 + ")<sup>1</sup></b>";
        if ("G3:5:1" == vt2)
          this._objVitri.G351 = "<b class='vt2'>(" + this._objVitri.G351 + ")<sup>2</sup></b>";
        if ("G3:5:2" == vt1)
          this._objVitri.G352 = "<b class='vt1'>(" + this._objVitri.G352 + ")<sup>1</sup></b>";
        if ("G3:5:2" == vt2)
          this._objVitri.G352 = "<b class='vt2'>(" + this._objVitri.G352 + ")<sup>2</sup></b>";
        if ("G3:5:3" == vt1)
          this._objVitri.G353 = "<b class='vt1'>(" + this._objVitri.G353 + ")<sup>1</sup></b>";
        if ("G3:5:3" == vt2)
          this._objVitri.G353 = "<b class='vt2'>(" + this._objVitri.G353 + ")<sup>2</sup></b>";
        if ("G3:5:4" == vt1)
          this._objVitri.G354 = "<b class='vt1'>(" + this._objVitri.G354 + ")<sup>1</sup></b>";
        if ("G3:5:4" == vt2)
          this._objVitri.G354 = "<b class='vt2'>(" + this._objVitri.G354 + ")<sup>2</sup></b>";
        if ("G3:5:5" == vt1)
          this._objVitri.G355 = "<b class='vt1'>(" + this._objVitri.G355 + ")<sup>1</sup></b>";
        if ("G3:5:5" == vt2)
          this._objVitri.G355 = "<b class='vt2'>(" + this._objVitri.G355 + ")<sup>2</sup></b>";
        if ("G3:6:1" == vt1)
          this._objVitri.G361 = "<b class='vt1'>(" + this._objVitri.G361 + ")<sup>1</sup></b>";
        if ("G3:6:1" == vt2)
          this._objVitri.G361 = "<b class='vt2'>(" + this._objVitri.G361 + ")<sup>2</sup></b>";
        if ("G3:6:2" == vt1)
          this._objVitri.G362 = "<b class='vt1'>(" + this._objVitri.G362 + ")<sup>1</sup></b>";
        if ("G3:6:2" == vt2)
          this._objVitri.G362 = "<b class='vt2'>(" + this._objVitri.G362 + ")<sup>2</sup></b>";
        if ("G3:6:3" == vt1)
          this._objVitri.G363 = "<b class='vt1'>(" + this._objVitri.G363 + ")<sup>1</sup></b>";
        if ("G3:6:3" == vt2)
          this._objVitri.G363 = "<b class='vt2'>(" + this._objVitri.G363 + ")<sup>2</sup></b>";
        if ("G3:6:4" == vt1)
          this._objVitri.G364 = "<b class='vt1'>(" + this._objVitri.G364 + ")<sup>1</sup></b>";
        if ("G3:6:4" == vt2)
          this._objVitri.G364 = "<b class='vt2'>(" + this._objVitri.G364 + ")<sup>2</sup></b>";
        if ("G3:6:5" == vt1)
          this._objVitri.G365 = "<b class='vt1'>(" + this._objVitri.G365 + ")<sup>1</sup></b>";
        if ("G3:6:5" == vt2)
          this._objVitri.G365 = "<b class='vt2'>(" + this._objVitri.G365 + ")<sup>2</sup></b>";
        if ("G4:1:1" == vt1)
          this._objVitri.G411 = "<b class='vt1'>(" + this._objVitri.G411 + ")<sup>1</sup></b>";
        if ("G4:1:1" == vt2)
          this._objVitri.G411 = "<b class='vt2'>(" + this._objVitri.G411 + ")<sup>2</sup></b>";
        if ("G4:1:2" == vt1)
          this._objVitri.G412 = "<b class='vt1'>(" + this._objVitri.G412 + ")<sup>1</sup></b>";
        if ("G4:1:2" == vt2)
          this._objVitri.G412 = "<b class='vt2'>(" + this._objVitri.G412 + ")<sup>2</sup></b>";
        if ("G4:1:3" == vt1)
          this._objVitri.G413 = "<b class='vt1'>(" + this._objVitri.G413 + ")<sup>1</sup></b>";
        if ("G4:1:3" == vt2)
          this._objVitri.G413 = "<b class='vt2'>(" + this._objVitri.G413 + ")<sup>2</sup></b>";
        if ("G4:1:4" == vt1)
          this._objVitri.G414 = "<b class='vt1'>(" + this._objVitri.G414 + ")<sup>1</sup></b>";
        if ("G4:1:4" == vt2)
          this._objVitri.G414 = "<b class='vt2'>(" + this._objVitri.G414 + ")<sup>2</sup></b>";
        if ("G4:2:1" == vt1)
          this._objVitri.G421 = "<b class='vt1'>(" + this._objVitri.G421 + ")<sup>1</sup></b>";
        if ("G4:2:1" == vt2)
          this._objVitri.G421 = "<b class='vt2'>(" + this._objVitri.G421 + ")<sup>2</sup></b>";
        if ("G4:2:2" == vt1)
          this._objVitri.G422 = "<b class='vt1'>(" + this._objVitri.G422 + ")<sup>1</sup></b>";
        if ("G4:2:2" == vt2)
          this._objVitri.G422 = "<b class='vt2'>(" + this._objVitri.G422 + ")<sup>2</sup></b>";
        if ("G4:2:3" == vt1)
          this._objVitri.G423 = "<b class='vt1'>(" + this._objVitri.G423 + ")<sup>1</sup></b>";
        if ("G4:2:3" == vt2)
          this._objVitri.G423 = "<b class='vt2'>(" + this._objVitri.G423 + ")<sup>2</sup></b>";
        if ("G4:2:4" == vt1)
          this._objVitri.G424 = "<b class='vt1'>(" + this._objVitri.G424 + ")<sup>1</sup></b>";
        if ("G4:2:4" == vt2)
          this._objVitri.G424 = "<b class='vt2'>(" + this._objVitri.G424 + ")<sup>2</sup></b>";
        if ("G4:3:1" == vt1)
          this._objVitri.G431 = "<b class='vt1'>(" + this._objVitri.G431 + ")<sup>1</sup></b>";
        if ("G4:3:1" == vt2)
          this._objVitri.G431 = "<b class='vt2'>(" + this._objVitri.G431 + ")<sup>2</sup></b>";
        if ("G4:3:2" == vt1)
          this._objVitri.G432 = "<b class='vt1'>(" + this._objVitri.G432 + ")<sup>1</sup></b>";
        if ("G4:3:2" == vt2)
          this._objVitri.G432 = "<b class='vt2'>(" + this._objVitri.G432 + ")<sup>2</sup></b>";
        if ("G4:3:3" == vt1)
          this._objVitri.G433 = "<b class='vt1'>(" + this._objVitri.G433 + ")<sup>1</sup></b>";
        if ("G4:3:3" == vt2)
          this._objVitri.G433 = "<b class='vt2'>(" + this._objVitri.G433 + ")<sup>2</sup></b>";
        if ("G4:3:4" == vt1)
          this._objVitri.G434 = "<b class='vt1'>(" + this._objVitri.G434 + ")<sup>1</sup></b>";
        if ("G4:3:4" == vt2)
          this._objVitri.G434 = "<b class='vt2'>(" + this._objVitri.G434 + ")<sup>2</sup></b>";
        if ("G4:4:1" == vt1)
          this._objVitri.G441 = "<b class='vt1'>(" + this._objVitri.G441 + ")<sup>1</sup></b>";
        if ("G4:4:1" == vt2)
          this._objVitri.G441 = "<b class='vt2'>(" + this._objVitri.G441 + ")<sup>2</sup></b>";
        if ("G4:4:2" == vt1)
          this._objVitri.G442 = "<b class='vt1'>(" + this._objVitri.G442 + ")<sup>1</sup></b>";
        if ("G4:4:2" == vt2)
          this._objVitri.G442 = "<b class='vt2'>(" + this._objVitri.G442 + ")<sup>2</sup></b>";
        if ("G4:4:3" == vt1)
          this._objVitri.G443 = "<b class='vt1'>(" + this._objVitri.G443 + ")<sup>1</sup></b>";
        if ("G4:4:3" == vt2)
          this._objVitri.G443 = "<b class='vt2'>(" + this._objVitri.G443 + ")<sup>2</sup></b>";
        if ("G4:4:4" == vt1)
          this._objVitri.G444 = "<b class='vt1'>(" + this._objVitri.G444 + ")<sup>1</sup></b>";
        if ("G4:4:4" == vt2)
          this._objVitri.G444 = "<b class='vt2'>(" + this._objVitri.G444 + ")<sup>2</sup></b>";
        if ("G5:1:1" == vt1)
          this._objVitri.G511 = "<b class='vt1'>(" + this._objVitri.G511 + ")<sup>1</sup></b>";
        if ("G5:1:1" == vt2)
          this._objVitri.G511 = "<b class='vt2'>(" + this._objVitri.G511 + ")<sup>2</sup></b>";
        if ("G5:1:2" == vt1)
          this._objVitri.G512 = "<b class='vt1'>(" + this._objVitri.G512 + ")<sup>1</sup></b>";
        if ("G5:1:2" == vt2)
          this._objVitri.G512 = "<b class='vt2'>(" + this._objVitri.G512 + ")<sup>2</sup></b>";
        if ("G5:1:3" == vt1)
          this._objVitri.G513 = "<b class='vt1'>(" + this._objVitri.G513 + ")<sup>1</sup></b>";
        if ("G5:1:3" == vt2)
          this._objVitri.G513 = "<b class='vt2'>(" + this._objVitri.G513 + ")<sup>2</sup></b>";
        if ("G5:1:4" == vt1)
          this._objVitri.G514 = "<b class='vt1'>(" + this._objVitri.G514 + ")<sup>1</sup></b>";
        if ("G5:1:4" == vt2)
          this._objVitri.G514 = "<b class='vt2'>(" + this._objVitri.G514 + ")<sup>2</sup></b>";
        if ("G5:2:1" == vt1)
          this._objVitri.G521 = "<b class='vt1'>(" + this._objVitri.G521 + ")<sup>1</sup></b>";
        if ("G5:2:1" == vt2)
          this._objVitri.G521 = "<b class='vt2'>(" + this._objVitri.G521 + ")<sup>2</sup></b>";
        if ("G5:2:2" == vt1)
          this._objVitri.G522 = "<b class='vt1'>(" + this._objVitri.G522 + ")<sup>1</sup></b>";
        if ("G5:2:2" == vt2)
          this._objVitri.G522 = "<b class='vt2'>(" + this._objVitri.G522 + ")<sup>2</sup></b>";
        if ("G5:2:3" == vt1)
          this._objVitri.G523 = "<b class='vt1'>(" + this._objVitri.G523 + ")<sup>1</sup></b>";
        if ("G5:2:3" == vt2)
          this._objVitri.G523 = "<b class='vt2'>(" + this._objVitri.G523 + ")<sup>2</sup></b>";
        if ("G5:2:4" == vt1)
          this._objVitri.G524 = "<b class='vt1'>(" + this._objVitri.G524 + ")<sup>1</sup></b>";
        if ("G5:2:4" == vt2)
          this._objVitri.G524 = "<b class='vt2'>(" + this._objVitri.G524 + ")<sup>2</sup></b>";
        if ("G5:3:1" == vt1)
          this._objVitri.G531 = "<b class='vt1'>(" + this._objVitri.G531 + ")<sup>1</sup></b>";
        if ("G5:3:1" == vt2)
          this._objVitri.G531 = "<b class='vt2'>(" + this._objVitri.G531 + ")<sup>2</sup></b>";
        if ("G5:3:2" == vt1)
          this._objVitri.G532 = "<b class='vt1'>(" + this._objVitri.G532 + ")<sup>1</sup></b>";
        if ("G5:3:2" == vt2)
          this._objVitri.G532 = "<b class='vt2'>(" + this._objVitri.G532 + ")<sup>2</sup></b>";
        if ("G5:3:3" == vt1)
          this._objVitri.G533 = "<b class='vt1'>(" + this._objVitri.G533 + ")<sup>1</sup></b>";
        if ("G5:3:3" == vt2)
          this._objVitri.G533 = "<b class='vt2'>(" + this._objVitri.G533 + ")<sup>2</sup></b>";
        if ("G5:3:4" == vt1)
          this._objVitri.G534 = "<b class='vt1'>(" + this._objVitri.G534 + ")<sup>1</sup></b>";
        if ("G5:3:4" == vt2)
          this._objVitri.G534 = "<b class='vt2'>(" + this._objVitri.G534 + ")<sup>2</sup></b>";
        if ("G5:4:1" == vt1)
          this._objVitri.G541 = "<b class='vt1'>(" + this._objVitri.G541 + ")<sup>1</sup></b>";
        if ("G5:4:1" == vt2)
          this._objVitri.G541 = "<b class='vt2'>(" + this._objVitri.G541 + ")<sup>2</sup></b>";
        if ("G5:4:2" == vt1)
          this._objVitri.G542 = "<b class='vt1'>(" + this._objVitri.G542 + ")<sup>1</sup></b>";
        if ("G5:4:2" == vt2)
          this._objVitri.G542 = "<b class='vt2'>(" + this._objVitri.G542 + ")<sup>2</sup></b>";
        if ("G5:4:3" == vt1)
          this._objVitri.G543 = "<b class='vt1'>(" + this._objVitri.G543 + ")<sup>1</sup></b>";
        if ("G5:4:3" == vt2)
          this._objVitri.G543 = "<b class='vt2'>(" + this._objVitri.G543 + ")<sup>2</sup></b>";
        if ("G5:4:4" == vt1)
          this._objVitri.G544 = "<b class='vt1'>(" + this._objVitri.G544 + ")<sup>1</sup></b>";
        if ("G5:4:4" == vt2)
          this._objVitri.G544 = "<b class='vt2'>(" + this._objVitri.G544 + ")<sup>2</sup></b>";
        if ("G5:5:1" == vt1)
          this._objVitri.G551 = "<b class='vt1'>(" + this._objVitri.G551 + ")<sup>1</sup></b>";
        if ("G5:5:1" == vt2)
          this._objVitri.G551 = "<b class='vt2'>(" + this._objVitri.G551 + ")<sup>2</sup></b>";
        if ("G5:5:2" == vt1)
          this._objVitri.G552 = "<b class='vt1'>(" + this._objVitri.G552 + ")<sup>1</sup></b>";
        if ("G5:5:2" == vt2)
          this._objVitri.G552 = "<b class='vt2'>(" + this._objVitri.G552 + ")<sup>2</sup></b>";
        if ("G5:5:3" == vt1)
          this._objVitri.G553 = "<b class='vt1'>(" + this._objVitri.G553 + ")<sup>1</sup></b>";
        if ("G5:5:3" == vt2)
          this._objVitri.G553 = "<b class='vt2'>(" + this._objVitri.G553 + ")<sup>2</sup></b>";
        if ("G5:5:4" == vt1)
          this._objVitri.G554 = "<b class='vt1'>(" + this._objVitri.G554 + ")<sup>1</sup></b>";
        if ("G5:5:4" == vt2)
          this._objVitri.G554 = "<b class='vt2'>(" + this._objVitri.G554 + ")<sup>2</sup></b>";
        if ("G5:6:1" == vt1)
          this._objVitri.G561 = "<b class='vt1'>(" + this._objVitri.G561 + ")<sup>1</sup></b>";
        if ("G5:6:1" == vt2)
          this._objVitri.G561 = "<b class='vt2'>(" + this._objVitri.G561 + ")<sup>2</sup></b>";
        if ("G5:6:2" == vt1)
          this._objVitri.G562 = "<b class='vt1'>(" + this._objVitri.G562 + ")<sup>1</sup></b>";
        if ("G5:6:2" == vt2)
          this._objVitri.G562 = "<b class='vt2'>(" + this._objVitri.G562 + ")<sup>2</sup></b>";
        if ("G5:6:3" == vt1)
          this._objVitri.G563 = "<b class='vt1'>(" + this._objVitri.G563 + ")<sup>1</sup></b>";
        if ("G5:6:3" == vt2)
          this._objVitri.G563 = "<b class='vt2'>(" + this._objVitri.G563 + ")<sup>2</sup></b>";
        if ("G5:6:4" == vt1)
          this._objVitri.G564 = "<b class='vt1'>(" + this._objVitri.G564 + ")<sup>1</sup></b>";
        if ("G5:6:4" == vt2)
          this._objVitri.G564 = "<b class='vt2'>(" + this._objVitri.G564 + ")<sup>2</sup></b>";
        if ("G6:1:1" == vt1)
          this._objVitri.G611 = "<b class='vt1'>(" + this._objVitri.G611 + ")<sup>1</sup></b>";
        if ("G6:1:1" == vt2)
          this._objVitri.G611 = "<b class='vt2'>(" + this._objVitri.G611 + ")<sup>2</sup></b>";
        if ("G6:1:2" == vt1)
          this._objVitri.G612 = "<b class='vt1'>(" + this._objVitri.G612 + ")<sup>1</sup></b>";
        if ("G6:1:2" == vt2)
          this._objVitri.G612 = "<b class='vt2'>(" + this._objVitri.G612 + ")<sup>2</sup></b>";
        if ("G6:1:3" == vt1)
          this._objVitri.G613 = "<b class='vt1'>(" + this._objVitri.G613 + ")<sup>1</sup></b>";
        if ("G6:1:3" == vt2)
          this._objVitri.G613 = "<b class='vt2'>(" + this._objVitri.G613 + ")<sup>2</sup></b>";
        if ("G6:2:1" == vt1)
          this._objVitri.G621 = "<b class='vt1'>(" + this._objVitri.G621 + ")<sup>1</sup></b>";
        if ("G6:2:1" == vt2)
          this._objVitri.G621 = "<b class='vt2'>(" + this._objVitri.G621 + ")<sup>2</sup></b>";
        if ("G6:2:2" == vt1)
          this._objVitri.G622 = "<b class='vt1'>(" + this._objVitri.G622 + ")<sup>1</sup></b>";
        if ("G6:2:2" == vt2)
          this._objVitri.G622 = "<b class='vt2'>(" + this._objVitri.G622 + ")<sup>2</sup></b>";
        if ("G6:2:3" == vt1)
          this._objVitri.G623 = "<b class='vt1'>(" + this._objVitri.G623 + ")<sup>1</sup></b>";
        if ("G6:2:3" == vt2)
          this._objVitri.G623 = "<b class='vt2'>(" + this._objVitri.G623 + ")<sup>2</sup></b>";
        if ("G6:3:1" == vt1)
          this._objVitri.G631 = "<b class='vt1'>(" + this._objVitri.G631 + ")<sup>1</sup></b>";
        if ("G6:3:1" == vt2)
          this._objVitri.G631 = "<b class='vt2'>(" + this._objVitri.G631 + ")<sup>2</sup></b>";
        if ("G6:3:2" == vt1)
          this._objVitri.G632 = "<b class='vt1'>(" + this._objVitri.G632 + ")<sup>1</sup></b>";
        if ("G6:3:2" == vt2)
          this._objVitri.G632 = "<b class='vt2'>(" + this._objVitri.G632 + ")<sup>2</sup></b>";
        if ("G6:3:3" == vt1)
          this._objVitri.G633 = "<b class='vt1'>(" + this._objVitri.G633 + ")<sup>1</sup></b>";
        if ("G6:3:3" == vt2)
          this._objVitri.G633 = "<b class='vt2'>(" + this._objVitri.G633 + ")<sup>2</sup></b>";
        if ("G7:1:1" == vt1)
          this._objVitri.G711 = "<b class='vt1'>(" + this._objVitri.G711 + ")<sup>1</sup></b>";
        if ("G7:1:1" == vt2)
          this._objVitri.G711 = "<b class='vt2'>(" + this._objVitri.G711 + ")<sup>2</sup></b>";
        if ("G7:1:2" == vt1)
          this._objVitri.G712 = "<b class='vt1'>(" + this._objVitri.G712 + ")<sup>1</sup></b>";
        if ("G7:1:2" == vt2)
          this._objVitri.G712 = "<b class='vt2'>(" + this._objVitri.G712 + ")<sup>2</sup></b>";
        if ("G7:2:1" == vt1)
          this._objVitri.G721 = "<b class='vt1'>(" + this._objVitri.G721 + ")<sup>1</sup></b>";
        if ("G7:2:1" == vt2)
          this._objVitri.G721 = "<b class='vt2'>(" + this._objVitri.G721 + ")<sup>2</sup></b>";
        if ("G7:2:2" == vt1)
          this._objVitri.G722 = "<b class='vt1'>(" + this._objVitri.G722 + ")<sup>1</sup></b>";
        if ("G7:2:2" == vt2)
          this._objVitri.G722 = "<b class='vt2'>(" + this._objVitri.G722 + ")<sup>2</sup></b>";
        if ("G7:3:1" == vt1)
          this._objVitri.G731 = "<b class='vt1'>(" + this._objVitri.G731 + ")<sup>1</sup></b>";
        if ("G7:3:1" == vt2)
          this._objVitri.G731 = "<b class='vt2'>(" + this._objVitri.G731 + ")<sup>2</sup></b>";
        if ("G7:3:2" == vt1)
          this._objVitri.G732 = "<b class='vt1'>(" + this._objVitri.G732 + ")<sup>1</sup></b>";
        if ("G7:3:2" == vt2)
          this._objVitri.G732 = "<b class='vt2'>(" + this._objVitri.G732 + ")<sup>2</sup></b>";
        if ("G7:4:1" == vt1)
          this._objVitri.G741 = "<b class='vt1'>(" + this._objVitri.G741 + ")<sup>1</sup></b>";
        if ("G7:4:1" == vt2)
          this._objVitri.G741 = "<b class='vt2'>(" + this._objVitri.G741 + ")<sup>2</sup></b>";
        if ("G7:4:2" == vt1)
          this._objVitri.G742 = "<b class='vt1'>(" + this._objVitri.G742 + ")<sup>1</sup></b>";
        if ("G7:4:2" == vt2)
          this._objVitri.G742 = "<b class='vt2'>(" + this._objVitri.G742 + ")<sup>2</sup></b>";
        this.strHtml = this.strHtml + "<div class=\"main\"><span class=\"title_XS\">Kết quả xổ số " + Tbketqua.GetThuTrongtuan(Convert.ToDateTime(dtTable.Rows[index]["clngaythang"].ToString())) + " - Bộ Số Tạo Thành Từ Cầu [" + str + "]</span>";
        this.strHtml += "<table class=\"table_KQ\"><tr><td class=\"style1\" style=\"color:Red;font-weight:bold;font-size:15px;\"  >&nbsp; Giải đặc biệt</td>";
        this.strHtml = this.strHtml + "<td class=\"style2\" style=\"color:Red;font-weight:bold;font-size:16px;\" >&nbsp; " + this._objVitri.G011 + this._objVitri.G012 + this._objVitri.G013 + this._objVitri.G014 + this._objVitri.G015 + "</td></tr><tr>";
        this.strHtml += "<td class=\"style1\" >&nbsp; Giải nhất</td>";
        this.strHtml = this.strHtml + "<td class=\"style2\" >&nbsp; " + this._objVitri.G111 + this._objVitri.G112 + this._objVitri.G113 + this._objVitri.G114 + this._objVitri.G115 + "</td>";
        this.strHtml += "</tr><tr><td class=\"style1\" >&nbsp; Giải nhì</td>";
        this.strHtml = this.strHtml + "<td  class=\"style2\">&nbsp; " + this._objVitri.G211 + this._objVitri.G212 + this._objVitri.G213 + this._objVitri.G214 + this._objVitri.G215 + " - " + this._objVitri.G221 + this._objVitri.G222 + this._objVitri.G223 + this._objVitri.G224 + this._objVitri.G225 + "</td></tr><tr>";
        this.strHtml += "<td class=\"style1\" >&nbsp; Giải ba</td>";
        this.strHtml = this.strHtml + ("<td class=\"style2\" >&nbsp; " + this._objVitri.G311 + this._objVitri.G312 + this._objVitri.G313 + this._objVitri.G314 + this._objVitri.G315 + " - " + this._objVitri.G321 + this._objVitri.G322 + this._objVitri.G323 + this._objVitri.G324 + this._objVitri.G325 + " - " + this._objVitri.G331 + this._objVitri.G332 + this._objVitri.G333 + this._objVitri.G334 + this._objVitri.G335 + " - " + this._objVitri.G341 + this._objVitri.G342 + this._objVitri.G343 + this._objVitri.G344 + this._objVitri.G345 + " - " + this._objVitri.G351 + this._objVitri.G352 + this._objVitri.G353 + this._objVitri.G354 + this._objVitri.G355) + " - " + this._objVitri.G361 + this._objVitri.G362 + this._objVitri.G363 + this._objVitri.G364 + this._objVitri.G365 + "</td></tr><tr>";
        this.strHtml += "<td class=\"style1\" >&nbsp; Giải tư</td>";
        this.strHtml = this.strHtml + ("<td class=\"style2\"   >&nbsp; " + this._objVitri.G411 + this._objVitri.G412 + this._objVitri.G413 + this._objVitri.G414 + " - " + this._objVitri.G421 + this._objVitri.G422 + this._objVitri.G423 + this._objVitri.G424 + " - " + this._objVitri.G431 + this._objVitri.G432 + this._objVitri.G433 + this._objVitri.G434) + " - " + this._objVitri.G441 + this._objVitri.G442 + this._objVitri.G443 + this._objVitri.G444 + "</td></tr><tr>";
        this.strHtml += "<td class=\"style1\" >&nbsp; Giải năm</td>";
        this.strHtml = this.strHtml + ("<td class=\"style2\"  >&nbsp; " + this._objVitri.G511 + this._objVitri.G512 + this._objVitri.G513 + this._objVitri.G514 + " - " + this._objVitri.G521 + this._objVitri.G522 + this._objVitri.G523 + this._objVitri.G524 + " - " + this._objVitri.G531 + this._objVitri.G532 + this._objVitri.G533 + this._objVitri.G534 + " - " + this._objVitri.G541 + this._objVitri.G542 + this._objVitri.G543 + this._objVitri.G544 + " - " + this._objVitri.G551 + this._objVitri.G552 + this._objVitri.G553 + this._objVitri.G554) + " - " + this._objVitri.G561 + this._objVitri.G562 + this._objVitri.G563 + this._objVitri.G564 + "</td></tr><tr>";
        this.strHtml += "<td class=\"style1\" >&nbsp; Giải sáu</td>";
        this.strHtml = this.strHtml + ("<td class=\"style2\" >&nbsp; " + this._objVitri.G611 + this._objVitri.G612 + this._objVitri.G613 + " - " + this._objVitri.G621 + this._objVitri.G622 + this._objVitri.G623) + " - " + this._objVitri.G631 + this._objVitri.G632 + this._objVitri.G633 + "</td></tr><tr>";
        this.strHtml += "<td class=\"style1\" style=\"border-bottom-width: 0px;\">&nbsp; Giải bảy</td>";
        this.strHtml = this.strHtml + ("<td class=\"style2\" style=\"border-bottom-width: 0px;\">&nbsp; " + this._objVitri.G711 + this._objVitri.G712 + " - " + this._objVitri.G721 + this._objVitri.G722 + " - " + this._objVitri.G731 + this._objVitri.G732) + " - " + this._objVitri.G741 + this._objVitri.G742 + "</td></tr></table>";
        this.strHtml += "<table style=\"border: 1px dotted #FF9933; width: 26%; float: left; margin-bottom: 0px; margin-left: 15px;\" bgcolor=\"Transparent\"><tr><td class=\"style3\" >ĐẦU</td><td  class=\"style4\">LOTO</td>";
        this.strHtml = this.strHtml + "</tr><tr><td class=\"style3\" >0</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "0", "dau", loto1, loto2) + "</td>";
        this.strHtml = this.strHtml + "</tr><tr><td class=\"style3\" >1</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "1", "dau", loto1, loto2) + "</td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\" >2</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "2", "dau", loto1, loto2) + " </td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\" >3</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "3", "dau", loto1, loto2) + " </td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\" >4</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "4", "dau", loto1, loto2) + "</td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\" >5</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "5", "dau", loto1, loto2) + " </td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\">6</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "6", "dau", loto1, loto2) + " </td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\" >7</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "7", "dau", loto1, loto2) + " </td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\" >8</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "8", "dau", loto1, loto2) + " </td></tr><tr>";
        this.strHtml = this.strHtml + "<td class=\"style3\" style=\"border-bottom-width: 0px;\">9</td><td class=\"style4\"style=\"border-bottom-width: 0px;\">&nbsp;" + Tbketqua.GetLotoTheoDauCau(this._obj, "9", "dau", loto1, loto2) + " </td></tr></table></div><div style='width:100%;'></br></br></div>";
      }
    }

    private void xemChiTietCau()
    {
      if (this._rowIndex <= -1)
        return;
      TbVitri.Vitri1 = this.dtg_Ketqua.Rows[this._rowIndex].Cells[1].Value.ToString();
      TbVitri.Vitri2 = this.dtg_Ketqua.Rows[this._rowIndex].Cells[2].Value.ToString();
      TbVitri.NumLui = this.numLui.Value;
      TbVitri.NumTien = this.numTien.Value;
      TbVitri.NgayBatDau = this.dtNgaykiemtra.Value.AddYears(-1);
      TbVitri.NgayKetThuc = this.dtNgaykiemtra.Value;
      if (this.loaiLoto == "locap")
        TbVitri.CbbLotoSelectId = 0;
      if (this.loaiLoto == "lobachthu")
        TbVitri.CbbLotoSelectId = 1;
      if (this.loaiLoto == "lotrungdau")
        TbVitri.CbbLotoSelectId = 2;
      if (this.loaiLoto == "lotrungduoi")
        TbVitri.CbbLotoSelectId = 3;
      FMain.LoadTabname = FMain.TabName.ChiTietCau;
    }

    private void bgChitietcauchay_DoWork(object sender, DoWorkEventArgs e)
    {
      this.xemChiTietCau();
    }

    private void dtg_Ketqua_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.RowIndex <= -1)
        return;
      this._rowIndex = e.RowIndex;
      this.dtg_Ketqua.Rows[e.RowIndex].Selected = true;
    }

    private void dtg_Ketqua_MouseDown(object sender, MouseEventArgs e)
    {
      this._myHitTestDown = this.dtg_Ketqua.HitTest(e.X, e.Y);
      if (this._myHitTestDown.RowIndex <= -1 || (e.Button != MouseButtons.Right || this._myHitTestDown.RowIndex <= -1))
        return;
      this.dtg_Ketqua.Rows[this._myHitTestDown.RowIndex].Selected = true;
      this._rowIndex = this._myHitTestDown.RowIndex;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.bgGetDataNgayKiemTra.IsBusy)
      {
        this.picLoading.Visible = true;
        this.btnThongke.Enabled = true;
      }
      else
      {
        this.picLoading.Visible = false;
        this.btnThongke.Enabled = false;
        this.timer1.Stop();
      }
    }

    private void bgLoadInfoCau_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        TbVitri.Vitri1 = this.dtg_Ketqua.Rows[this._rowIndex].Cells[1].Value.ToString();
        TbVitri.Vitri2 = this.dtg_Ketqua.Rows[this._rowIndex].Cells[2].Value.ToString();
        this.Lichsucau(TbVitri.Vitri1, TbVitri.Vitri2);
        int dodaicau = Convert.ToInt32(this.dtg_Ketqua.Rows[this._rowIndex].Cells[4].Value.ToString()) + 1;
        this.showInfoCau(TbVitri.Vitri1, TbVitri.Vitri2, dodaicau);
      }
      catch
      {
      }
    }

    private void numLui_ValueChanged(object sender, EventArgs e)
    {
      this._biendotrungdau = Convert.ToInt32(this.numTien.Value - this.numLui.Value);
      this._biendotrungduoi = Convert.ToInt32(this.numTien.Value - this.numLui.Value);
      this.TaoDanhSachLoToChuan();
    }

    private void numTien_ValueChanged(object sender, EventArgs e)
    {
      this._biendotrungdau = Convert.ToInt32(this.numTien.Value - this.numLui.Value);
      this._biendotrungduoi = Convert.ToInt32(this.numTien.Value - this.numLui.Value);
      this.TaoDanhSachLoToChuan();
    }

    private void bgLoadInfoCau_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      TabSoiCau.HienThiKetQua(this.wbHienthi, this.strHtml);
    }

    private void xemChiTiếtCầuChạyToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      if (this.bgChitietcauchay.IsBusy)
        return;
      this.bgChitietcauchay.RunWorkerAsync();
    }

    private void tầnXuấtBộSốToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Tanxuatloto;
    }

    private void chuKỳCủaBộToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Chukiloto;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabSoiCau));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1 = new Panel();
      this.pnLuitien = new Panel();
      this.numLui = new NumericUpDown();
      this.numTien = new NumericUpDown();
      this.label12 = new Label();
      this.label10 = new Label();
      this.label3 = new Label();
      this.cbbLoaiLoto = new ComboBox();
      this.cbbLoto = new ComboBox();
      this.cbbXettheo = new ComboBox();
      this.label2 = new Label();
      this.cbbDodaicauchay = new ComboBox();
      this.label13 = new Label();
      this.dtNgaykiemtra = new DateTimePicker();
      this.btnThongke = new Button();
      this.panel2 = new Panel();
      this.panel4 = new Panel();
      this.wbHienthi = new WebBrowser();
      this.panel3 = new Panel();
      this.label4 = new Label();
      this.picLoading = new PictureBox();
      this.dtg_Ketqua = new DataGridView();
      this.stt = new DataGridViewTextBoxColumn();
      this.vt111 = new DataGridViewTextBoxColumn();
      this.vt222 = new DataGridViewTextBoxColumn();
      this.loto = new DataGridViewTextBoxColumn();
      this.dodai = new DataGridViewTextBoxColumn();
      this.vengay = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.xemChiTiếtCầuChạyToolStripMenuItem = new ToolStripMenuItem();
      this.tầnXuấtBộSốToolStripMenuItem = new ToolStripMenuItem();
      this.chuKỳCủaBộToolStripMenuItem = new ToolStripMenuItem();
      this.toolTip1 = new ToolTip(this.components);
      this.bgKhoitaodulieu = new BackgroundWorker();
      this.bgGetDataNgayKiemTra = new BackgroundWorker();
      this.timerProcess = new Timer(this.components);
      this.bgChitietcauchay = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.bgLoadInfoCau = new BackgroundWorker();
      this.groupBox1 = new GroupBox();
      this.panel1.SuspendLayout();
      this.pnLuitien.SuspendLayout();
      this.numLui.BeginInit();
      this.numTien.BeginInit();
      this.panel2.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 46);
      this.panel1.TabIndex = 1;
      this.pnLuitien.Controls.Add((Control) this.numLui);
      this.pnLuitien.Controls.Add((Control) this.numTien);
      this.pnLuitien.Controls.Add((Control) this.label12);
      this.pnLuitien.Controls.Add((Control) this.label10);
      this.pnLuitien.Location = new Point(385, 8);
      this.pnLuitien.Name = "pnLuitien";
      this.pnLuitien.Size = new Size(151, 30);
      this.pnLuitien.TabIndex = 57;
      this.numLui.BackColor = Color.White;
      this.numLui.BorderStyle = BorderStyle.FixedSingle;
      this.numLui.Cursor = Cursors.Hand;
      this.numLui.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numLui.ForeColor = Color.Black;
      this.numLui.Location = new Point(26, 5);
      this.numLui.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numLui.Minimum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        int.MinValue
      });
      this.numLui.Name = "numLui";
      this.numLui.Size = new Size(43, 21);
      this.numLui.TabIndex = 53;
      this.toolTip1.SetToolTip((Control) this.numLui, "Biên độ lùi của bộ số");
      this.numLui.ValueChanged += new EventHandler(this.numLui_ValueChanged);
      this.numTien.BackColor = Color.White;
      this.numTien.BorderStyle = BorderStyle.FixedSingle;
      this.numTien.Cursor = Cursors.Hand;
      this.numTien.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTien.ForeColor = Color.Black;
      this.numTien.Location = new Point(99, 5);
      this.numTien.Maximum = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numTien.Name = "numTien";
      this.numTien.Size = new Size(43, 21);
      this.numTien.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.numTien, "Biên độ tiến của bộ số");
      this.numTien.Value = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numTien.ValueChanged += new EventHandler(this.numTien_ValueChanged);
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.Black;
      this.label12.Location = new Point(6, 7);
      this.label12.Name = "label12";
      this.label12.Size = new Size(21, 16);
      this.label12.TabIndex = 0;
      this.label12.Text = "lùi";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.DarkSlateGray;
      this.label10.Location = new Point(72, 7);
      this.label10.Name = "label10";
      this.label10.Size = new Size(29, 16);
      this.label10.TabIndex = 55;
      this.label10.Text = "tiến";
      this.label3.AutoSize = true;
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(207, 16);
      this.label3.Name = "label3";
      this.label3.Size = new Size(27, 15);
      this.label3.TabIndex = 52;
      this.label3.Text = "loại";
      this.cbbLoaiLoto.BackColor = Color.Teal;
      this.cbbLoaiLoto.Cursor = Cursors.Hand;
      this.cbbLoaiLoto.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoaiLoto.FlatStyle = FlatStyle.Flat;
      this.cbbLoaiLoto.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbLoaiLoto.ForeColor = Color.White;
      this.cbbLoaiLoto.FormattingEnabled = true;
      this.cbbLoaiLoto.Items.AddRange(new object[4]
      {
        (object) "      Cầu lô cặp",
        (object) "  Cầu lô bạch thủ",
        (object) " Cầu lô trùng đầu",
        (object) " Cầu lô trùng đuôi"
      });
      this.cbbLoaiLoto.Location = new Point(236, 12);
      this.cbbLoaiLoto.Name = "cbbLoaiLoto";
      this.cbbLoaiLoto.Size = new Size(123, 23);
      this.cbbLoaiLoto.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.cbbLoaiLoto, "Loại cầu muốn xem của bạn");
      this.cbbLoaiLoto.SelectedIndexChanged += new EventHandler(this.cbbLoaiLoto_SelectedIndexChanged);
      this.cbbLoto.BackColor = Color.Teal;
      this.cbbLoto.Cursor = Cursors.Hand;
      this.cbbLoto.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoto.FlatStyle = FlatStyle.Popup;
      this.cbbLoto.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbLoto.ForeColor = Color.White;
      this.cbbLoto.FormattingEnabled = true;
      this.cbbLoto.Location = new Point(776, 12);
      this.cbbLoto.Name = "cbbLoto";
      this.cbbLoto.Size = new Size(70, 23);
      this.cbbLoto.TabIndex = 4;
      this.toolTip1.SetToolTip((Control) this.cbbLoto, "Bố số kiểm tra");
      this.cbbLoto.Visible = false;
      this.cbbLoto.SelectedIndexChanged += new EventHandler(this.cbbLoto_SelectedIndexChanged);
      this.cbbXettheo.BackColor = Color.Teal;
      this.cbbXettheo.Cursor = Cursors.Hand;
      this.cbbXettheo.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbXettheo.FlatStyle = FlatStyle.Popup;
      this.cbbXettheo.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbXettheo.ForeColor = Color.White;
      this.cbbXettheo.FormattingEnabled = true;
      this.cbbXettheo.Items.AddRange(new object[2]
      {
        (object) "độ dài cầu chạy",
        (object) "         bộ số"
      });
      this.cbbXettheo.Location = new Point(599, 12);
      this.cbbXettheo.Name = "cbbXettheo";
      this.cbbXettheo.Size = new Size(113, 23);
      this.cbbXettheo.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.cbbXettheo, "Xét theo độ dài càu chạy hoặc bộ số");
      this.cbbXettheo.SelectedIndexChanged += new EventHandler(this.CbbXettheoSelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(552, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(49, 15);
      this.label2.TabIndex = 50;
      this.label2.Text = "xét theo";
      this.cbbDodaicauchay.BackColor = Color.Teal;
      this.cbbDodaicauchay.Cursor = Cursors.Hand;
      this.cbbDodaicauchay.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbDodaicauchay.FlatStyle = FlatStyle.Popup;
      this.cbbDodaicauchay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbDodaicauchay.ForeColor = Color.White;
      this.cbbDodaicauchay.FormattingEnabled = true;
      this.cbbDodaicauchay.Items.AddRange(new object[14]
      {
        (object) "2 ngày",
        (object) "3 ngày",
        (object) "4 ngày",
        (object) "5 ngày",
        (object) "6 ngày",
        (object) "7 ngày",
        (object) "8 ngày",
        (object) "9 ngày",
        (object) "10 ngày",
        (object) "11 ngày",
        (object) "12 ngày",
        (object) "13 ngày",
        (object) "14 ngày",
        (object) "15 ngày"
      });
      this.cbbDodaicauchay.Location = new Point(714, 12);
      this.cbbDodaicauchay.Name = "cbbDodaicauchay";
      this.cbbDodaicauchay.Size = new Size(70, 23);
      this.cbbDodaicauchay.TabIndex = 3;
      this.toolTip1.SetToolTip((Control) this.cbbDodaicauchay, "Độ dài cầu chạy");
      this.cbbDodaicauchay.SelectedIndexChanged += new EventHandler(this.CbbSongaySelectedIndexChanged);
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.Black;
      this.label13.Location = new Point(3, 16);
      this.label13.Name = "label13";
      this.label13.Size = new Size(84, 16);
      this.label13.TabIndex = 42;
      this.label13.Text = "Soi cầu ngày";
      this.dtNgaykiemtra.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgaykiemtra.CalendarForeColor = Color.Red;
      this.dtNgaykiemtra.CalendarMonthBackground = SystemColors.Info;
      this.dtNgaykiemtra.CustomFormat = "dd/MM/yyyy";
      this.dtNgaykiemtra.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgaykiemtra.Format = DateTimePickerFormat.Custom;
      this.dtNgaykiemtra.Location = new Point(89, 14);
      this.dtNgaykiemtra.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgaykiemtra.Name = "dtNgaykiemtra";
      this.dtNgaykiemtra.Size = new Size(87, 21);
      this.dtNgaykiemtra.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.dtNgaykiemtra, " Ngày kiểm tra cầu");
      this.dtNgaykiemtra.ValueChanged += new EventHandler(this.DTNgaykiemtraValueChanged);
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(790, 12);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(154, 23);
      this.btnThongke.TabIndex = 5;
      this.btnThongke.Text = "XEM CẦU";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnThongke, "Tiến hành soi cầu");
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.BtnThongkeClick);
      this.panel2.Controls.Add((Control) this.panel4);
      this.panel2.Controls.Add((Control) this.panel3);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 46);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 640);
      this.panel2.TabIndex = 2;
      this.panel4.Controls.Add((Control) this.wbHienthi);
      this.panel4.Dock = DockStyle.Fill;
      this.panel4.Location = new Point(364, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(736, 640);
      this.panel4.TabIndex = 0;
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(0, -2);
      this.wbHienthi.MinimumSize = new Size(20, 20);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(751, 640);
      this.wbHienthi.TabIndex = 0;
      this.panel3.Controls.Add((Control) this.label4);
      this.panel3.Controls.Add((Control) this.picLoading);
      this.panel3.Controls.Add((Control) this.dtg_Ketqua);
      this.panel3.Dock = DockStyle.Left;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(364, 640);
      this.panel3.TabIndex = 0;
      this.label4.BackColor = Color.Gray;
      this.label4.Dock = DockStyle.Right;
      this.label4.Location = new Point(363, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(1, 640);
      this.label4.TabIndex = 60;
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(203, 285);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(25, 25);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 59;
      this.picLoading.TabStop = false;
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_Ketqua.BackgroundColor = SystemColors.ButtonHighlight;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 21;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.stt, (DataGridViewColumn) this.vt111, (DataGridViewColumn) this.vt222, (DataGridViewColumn) this.loto, (DataGridViewColumn) this.dodai, (DataGridViewColumn) this.vengay);
      this.dtg_Ketqua.ContextMenuStrip = this.contextMenuStrip1;
      this.dtg_Ketqua.Cursor = Cursors.Hand;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.GridColor = Color.WhiteSmoke;
      this.dtg_Ketqua.Location = new Point(0, 0);
      this.dtg_Ketqua.Margin = new Padding(0);
      this.dtg_Ketqua.MultiSelect = false;
      this.dtg_Ketqua.Name = "dtg_Ketqua";
      this.dtg_Ketqua.ReadOnly = true;
      this.dtg_Ketqua.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.BackColor = Color.Cornsilk;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dtg_Ketqua.RowHeadersVisible = false;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dtg_Ketqua.RowTemplate.Height = 24;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(389, 640);
      this.dtg_Ketqua.TabIndex = 0;
      this.dtg_Ketqua.CellClick += new DataGridViewCellEventHandler(this.dtg_Ketqua_CellClick);
      this.dtg_Ketqua.CellDoubleClick += new DataGridViewCellEventHandler(this.dtg_Ketqua_CellDoubleClick);
      this.dtg_Ketqua.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dtg_Ketqua_CellMouseClick);
      this.dtg_Ketqua.MouseDown += new MouseEventHandler(this.dtg_Ketqua_MouseDown);
      this.stt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.stt.DataPropertyName = "stt";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle4.ForeColor = Color.Gray;
      this.stt.DefaultCellStyle = gridViewCellStyle4;
      this.stt.HeaderText = "STT ";
      this.stt.Name = "stt";
      this.stt.ReadOnly = true;
      this.stt.ToolTipText = "Số thứ tự";
      this.stt.Width = 45;
      this.vt111.DataPropertyName = "vt111";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.vt111.DefaultCellStyle = gridViewCellStyle5;
      this.vt111.HeaderText = "VỊ TRÍ I";
      this.vt111.Name = "vt111";
      this.vt111.ReadOnly = true;
      this.vt111.ToolTipText = "Vị trí thứ I của cầu";
      this.vt111.Width = 60;
      this.vt222.DataPropertyName = "vt222";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle6.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.vt222.DefaultCellStyle = gridViewCellStyle6;
      this.vt222.HeaderText = "VỊ TRÍ II";
      this.vt222.Name = "vt222";
      this.vt222.ReadOnly = true;
      this.vt222.ToolTipText = "Vị trí thứ II của cầu";
      this.vt222.Width = 60;
      this.loto.DataPropertyName = "loto";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle7.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle7.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = Color.Red;
      this.loto.DefaultCellStyle = gridViewCellStyle7;
      this.loto.HeaderText = "       BỘ SỐ";
      this.loto.Name = "loto";
      this.loto.ReadOnly = true;
      this.loto.ToolTipText = "Bố số tạo thành từ cầu";
      this.dodai.DataPropertyName = "dodai";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle8.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dodai.DefaultCellStyle = gridViewCellStyle8;
      this.dodai.HeaderText = "ĐỘ DÀI";
      this.dodai.Name = "dodai";
      this.dodai.ReadOnly = true;
      this.dodai.ToolTipText = "Độ dài của cầu";
      this.dodai.Width = 60;
      this.vengay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.vengay.DataPropertyName = "vengay";
      gridViewCellStyle9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle9.ForeColor = Color.Red;
      this.vengay.DefaultCellStyle = gridViewCellStyle9;
      this.vengay.HeaderText = "";
      this.vengay.Name = "vengay";
      this.vengay.ReadOnly = true;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.xemChiTiếtCầuChạyToolStripMenuItem,
        (ToolStripItem) this.tầnXuấtBộSốToolStripMenuItem,
        (ToolStripItem) this.chuKỳCủaBộToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(157, 70);
      this.xemChiTiếtCầuChạyToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("xemChiTiếtCầuChạyToolStripMenuItem.Image");
      this.xemChiTiếtCầuChạyToolStripMenuItem.Name = "xemChiTiếtCầuChạyToolStripMenuItem";
      this.xemChiTiếtCầuChạyToolStripMenuItem.ShowShortcutKeys = false;
      this.xemChiTiếtCầuChạyToolStripMenuItem.Size = new Size(156, 22);
      this.xemChiTiếtCầuChạyToolStripMenuItem.Text = "Chi tiết cầu chạy";
      this.xemChiTiếtCầuChạyToolStripMenuItem.Click += new EventHandler(this.xemChiTiếtCầuChạyToolStripMenuItem_Click_1);
      this.tầnXuấtBộSốToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("tầnXuấtBộSốToolStripMenuItem.Image");
      this.tầnXuấtBộSốToolStripMenuItem.Name = "tầnXuấtBộSốToolStripMenuItem";
      this.tầnXuấtBộSốToolStripMenuItem.Size = new Size(156, 22);
      this.tầnXuấtBộSốToolStripMenuItem.Text = "Tần xuất bộ số";
      this.tầnXuấtBộSốToolStripMenuItem.Click += new EventHandler(this.tầnXuấtBộSốToolStripMenuItem_Click);
      this.chuKỳCủaBộToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("chuKỳCủaBộToolStripMenuItem.Image");
      this.chuKỳCủaBộToolStripMenuItem.Name = "chuKỳCủaBộToolStripMenuItem";
      this.chuKỳCủaBộToolStripMenuItem.Size = new Size(156, 22);
      this.chuKỳCủaBộToolStripMenuItem.Text = "Chu kỳ của bộ số";
      this.chuKỳCủaBộToolStripMenuItem.Click += new EventHandler(this.chuKỳCủaBộToolStripMenuItem_Click);
      this.bgKhoitaodulieu.DoWork += new DoWorkEventHandler(this.BgKhoitaodulieuDoWork);
      this.bgKhoitaodulieu.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgKhoitaodulieuRunWorkerCompleted);
      this.bgGetDataNgayKiemTra.DoWork += new DoWorkEventHandler(this.BgGetDataNgayKiemTraDoWork);
      this.bgGetDataNgayKiemTra.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetDataNgayKiemTra_RunWorkerCompleted);
      this.timerProcess.Enabled = true;
      this.timerProcess.Tick += new EventHandler(this.TimerProcessTick);
      this.bgChitietcauchay.DoWork += new DoWorkEventHandler(this.bgChitietcauchay_DoWork);
      this.timer1.Enabled = true;
      this.timer1.Interval = 200;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.bgLoadInfoCau.DoWork += new DoWorkEventHandler(this.bgLoadInfoCau_DoWork);
      this.bgLoadInfoCau.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgLoadInfoCau_RunWorkerCompleted);
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.cbbLoaiLoto);
      this.groupBox1.Controls.Add((Control) this.pnLuitien);
      this.groupBox1.Controls.Add((Control) this.btnThongke);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.dtNgaykiemtra);
      this.groupBox1.Controls.Add((Control) this.label13);
      this.groupBox1.Controls.Add((Control) this.cbbLoto);
      this.groupBox1.Controls.Add((Control) this.cbbDodaicauchay);
      this.groupBox1.Controls.Add((Control) this.cbbXettheo);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Location = new Point(2, -1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1096, 43);
      this.groupBox1.TabIndex = 58;
      this.groupBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabSoiCau);
      this.Size = new Size(1100, 686);
      this.panel1.ResumeLayout(false);
      this.pnLuitien.ResumeLayout(false);
      this.pnLuitien.PerformLayout();
      this.numLui.EndInit();
      this.numTien.EndInit();
      this.panel2.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    public class InfoCAU
    {
      public int STT { get; set; }

      public string Lototaothanh { get; set; }

      public int Vt1 { get; set; }

      public int Vt2 { get; set; }

      public int Dodai { get; set; }

      public int Vengay { get; set; }
    }

    public class LOTO
    {
      public string LOTO1 { get; set; }

      public string LOTO2 { get; set; }
    }

    public class LotoVitri
    {
      public string lotoVT1 { get; set; }

      public string lotoVT2 { get; set; }
    }
  }
}
