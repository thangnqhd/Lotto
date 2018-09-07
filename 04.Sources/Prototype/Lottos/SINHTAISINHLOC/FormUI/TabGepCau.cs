// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabGepCau
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigTN;
using ns1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabGepCau : UserControl
  {
    private string hienThiTheo = "TỈ LỆ(%)";
    private string xapXep = "ASC";
    private string soBanGhi = "5";
    private int rowIndex = 0;
    private IContainer components = (IContainer) null;
    private ArrayList DanhSachCau;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu;
    private List<TabGepCau.ListCauCap> _listCauCap;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu1;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu2;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu3;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu4;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu5;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu6;
    private List<TabGepCau.ListCauBachThu> _listCauBachThu7;
    private tbConfigBacNho _objConfigBacNho;
    private int _khungdanh;
    private Tbloto _objLoto;
    private DataTable _dtTongLoto;
    private DataTable _dtTongCau;
    private DateTime ngayBatDau;
    private DateTime ngayKetThuc;
    private DataTable dt1;
    private DataTable dt2;
    private DataTable dt3;
    private DataTable dt4;
    private DataTable dt5;
    private DataTable dt6;
    private DataTable dt7;
    private Decimal lui;
    private Decimal tien;
    private int ValueCbbLoaiCau;
    private DataTable dtOk;
    private DataTable dtTam;
    private DataGridView.HitTestInfo myHitTestDown;
    private string strTong;
    private TabName _tabName;
    private int _ngayChuaRa;
    private Panel panel2;
    private Label label1;
    private ComboBox cbbLoaiCau;
    private Label label3;
    private NumericUpDown numLui;
    private Label label5;
    private NumericUpDown numTien;
    private Label label6;
    private ComboBox cbbLocTheo;
    private Label label7;
    private DateTimePicker dtNgayKetThuc;
    private DateTimePicker dtNgayBatDau;
    private Label label2;
    private ComboBox cbbHienThi;
    private Label label9;
    private Button btnThongke;
    private BackgroundWorker bgGetNgayHienTai;
    private ComboBox cbbTangGiam;
    private BackgroundWorker bgCauBachThu;
    private BunifuElipse bunifuElipse1;
    private PictureBox picLoading;
    private Timer timer1;
    private BackgroundWorker bg1;
    private BackgroundWorker bg2;
    private BackgroundWorker bg3;
    private BackgroundWorker bg4;
    private BackgroundWorker bg5;
    private BackgroundWorker bg6;
    private BackgroundWorker bg7;
    private BackgroundWorker bgGetDataTong;
    private DataGridView dtg_Ketqua;
    private BackgroundWorker backgroundWorker1;
    private Label label8;
    private Label label4;
    private Label label11;
    private Label label12;
    private Label label10;
    private Label label13;
    private WebBrowser wbThongbao;
    private BackgroundWorker bgLocDuLieu;
    private ComboBox cbbNCR;
    private Label lblNCR;
    private Label label14;
    private Label label15;
    private GroupBox groupBox1;

    public TabGepCau()
    {
      this._objLoto = new Tbloto();
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this._tabName = new TabName();
      this.cbbLoaiCau.SelectedIndex = 0;
      this.cbbLocTheo.SelectedIndex = 0;
      this.cbbHienThi.SelectedIndex = 2;
      this.cbbTangGiam.SelectedIndex = 0;
      this.cbbNCR.SelectedIndex = 0;
      this.DanhSachCau = this._objLoto.DanhSachCau();
      this.wbThongbao.IsWebBrowserContextMenuEnabled = false;
      this.wbThongbao.AllowWebBrowserDrop = false;
      if (!this.bgCauBachThu.IsBusy)
        this.bgCauBachThu.RunWorkerAsync();
      if (!this.bgGetNgayHienTai.IsBusy)
      {
        this.StartTimer();
        this.bgGetNgayHienTai.RunWorkerAsync();
      }
      this.dtNgayKetThuc.Value = FMain.NgayKetQuaMoiNhat;
      this.dtNgayBatDau.Value = this.dtNgayKetThuc.Value.AddDays((double) -FMain.ObjConfigBacNho.ThongKeCauDep);
      this.Hien_Thi_ThongTinCau(this.wbThongbao, "<b style='color:red;'> TÌM KIẾM NHỮNG CẦU TỐT NHẤT THEO Ý BẠN TRONG (<b style='color:black;'>11.449</b>) CẦU HÀNG NGÀY </b>");
    }

    private void StartTimer()
    {
      this.timer1.Start();
    }

    private void GetNgayMoiNhat()
    {
      this._objConfigBacNho = new tbConfigBacNho();
      this._objConfigBacNho = this._objConfigBacNho.GetInfor(TbUser.Tbuser.Stt);
      this._khungdanh = this._objConfigBacNho.KhungDanhLoCapNuoi;
    }

    private void TaoDanhSachCauBachThu()
    {
      this._listCauBachThu = new List<TabGepCau.ListCauBachThu>();
      for (int index1 = 0; index1 < this.DanhSachCau.Count; ++index1)
      {
        string str1 = this.DanhSachCau[index1].ToString();
        for (int index2 = 0; index2 < this.DanhSachCau.Count; ++index2)
        {
          TabGepCau.ListCauBachThu listCauBachThu = new TabGepCau.ListCauBachThu();
          string str2 = this.DanhSachCau[index2].ToString();
          listCauBachThu.Vt1 = str1;
          listCauBachThu.Vt2 = str2;
          this._listCauBachThu.Add(listCauBachThu);
        }
      }
      this._listCauBachThu1 = new List<TabGepCau.ListCauBachThu>();
      this._listCauBachThu2 = new List<TabGepCau.ListCauBachThu>();
      this._listCauBachThu3 = new List<TabGepCau.ListCauBachThu>();
      this._listCauBachThu4 = new List<TabGepCau.ListCauBachThu>();
      this._listCauBachThu5 = new List<TabGepCau.ListCauBachThu>();
      this._listCauBachThu6 = new List<TabGepCau.ListCauBachThu>();
      this._listCauBachThu7 = new List<TabGepCau.ListCauBachThu>();
      for (int index = 0; index < this._listCauBachThu.Count; ++index)
      {
        if (index < 1620)
          this._listCauBachThu1.Add(this._listCauBachThu[index]);
        else if (index >= 1620 && index < 3240)
          this._listCauBachThu2.Add(this._listCauBachThu[index]);
        else if (index >= 3240 && index < 4860)
          this._listCauBachThu3.Add(this._listCauBachThu[index]);
        else if (index >= 4860 && index < 6480)
          this._listCauBachThu4.Add(this._listCauBachThu[index]);
        else if (index >= 6480 && index < 8100)
          this._listCauBachThu5.Add(this._listCauBachThu[index]);
        else if (index >= 8100 && index < 9720)
          this._listCauBachThu6.Add(this._listCauBachThu[index]);
        else if (index >= 9720 && index < this._listCauBachThu.Count)
          this._listCauBachThu7.Add(this._listCauBachThu[index]);
      }
    }

    private void GetDataTong(DateTime _ngayBatDau, DateTime _ngayKetThuc)
    {
      this._objLoto = new Tbloto();
      this._dtTongLoto = this._objLoto.GetLotoByNgayThang(_ngayBatDau, _ngayKetThuc);
      this._dtTongCau = this._objLoto.GetTbVitriByNgayThang(_ngayBatDau, _ngayKetThuc);
    }

    private void TaoDanhSachCauCap()
    {
      this._listCauCap = new List<TabGepCau.ListCauCap>();
      for (int index1 = 0; index1 < this.DanhSachCau.Count; ++index1)
      {
        string str1 = this.DanhSachCau[index1].ToString();
        for (int index2 = 0; index2 < this.DanhSachCau.Count; ++index2)
        {
          TabGepCau.ListCauCap listCauCap = new TabGepCau.ListCauCap();
          string str2 = this.DanhSachCau[index2].ToString();
          if (index1 != index2)
          {
            bool flag = false;
            for (int index3 = 0; index3 < this._listCauCap.Count; ++index3)
            {
              if (this._listCauCap[index3].Vt1 == str2 && this._listCauCap[index3].Vt2 == str1)
              {
                flag = true;
                break;
              }
            }
            if (!flag)
            {
              listCauCap.Vt1 = str1;
              listCauCap.Vt2 = str2;
              this._listCauCap.Add(listCauCap);
            }
          }
        }
      }
    }

    private void bgGetNgayHienTai_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetNgayMoiNhat();
    }

    private void bgGetNgayHienTai_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    private void dtNgayKetThuc_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtNgayKetThuc.Value > FMain.NgayKetQuaMoiNhat)
        this.dtNgayKetThuc.Value = FMain.NgayKetQuaMoiNhat;
      this.dtNgayBatDau.Value = this.dtNgayKetThuc.Value.AddDays((double) -FMain.ObjConfigBacNho.ThongKeCauDep);
    }

    private void dtNgayBatDau_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayBatDau.Value >= this.dtNgayKetThuc.Value))
        return;
      this.dtNgayBatDau.Value = this.dtNgayKetThuc.Value.AddDays((double) -FMain.ObjConfigBacNho.ThongKeCauDep);
    }

    private void cbbLoaiCau_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbbLoaiCau.SelectedIndex == 0 || this.cbbLoaiCau.SelectedIndex == 1)
        this.numTien.Enabled = false;
      else
        this.numTien.Enabled = true;
      if (this.cbbLoaiCau.SelectedIndex != 0)
        ;
      if (this.cbbLoaiCau.SelectedIndex != 1)
        ;
      if (this.cbbLoaiCau.SelectedIndex != 2)
        ;
      if (this.cbbLoaiCau.SelectedIndex != 3)
        ;
    }

    private void bgCauBachThu_DoWork(object sender, DoWorkEventArgs e)
    {
      this.TaoDanhSachCauBachThu();
    }

    private void tabGepCau_Load(object sender, EventArgs e)
    {
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.bgGetNgayHienTai.IsBusy || this.bgCauBachThu.IsBusy || (this.bgGetDataTong.IsBusy || this.bg1.IsBusy) || (this.bg2.IsBusy || this.bg3.IsBusy || (this.bg4.IsBusy || this.bg5.IsBusy)) || (this.bg6.IsBusy || this.bg7.IsBusy) || this.bgLocDuLieu.IsBusy)
      {
        this.picLoading.Visible = true;
        this.btnThongke.Enabled = false;
        this.panel2.Enabled = false;
      }
      else
      {
        this.panel2.Enabled = true;
        this.picLoading.Visible = false;
        this.btnThongke.Enabled = true;
        this.timer1.Stop();
      }
    }

    private void bgGetDataTong_DoWork(object sender, DoWorkEventArgs e)
    {
      if (!(this.dtNgayBatDau.Value != this.ngayBatDau) && !(this.dtNgayKetThuc.Value != this.ngayKetThuc))
        return;
      this.ngayKetThuc = this.dtNgayKetThuc.Value;
      this.ngayBatDau = this.dtNgayBatDau.Value;
      this.GetDataTong(this.ngayBatDau, this.ngayKetThuc);
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      this.cbbNCR.SelectedIndex = 0;
      this.strTong = "";
      this.dtg_Ketqua.DataSource = (object) null;
      this.StartTimer();
      this._objConfigBacNho = this._objConfigBacNho.GetInfor(TbUser.Tbuser.Stt);
      this.dtOk = new DataTable();
      this.ValueCbbLoaiCau = this.cbbLoaiCau.SelectedIndex;
      if (this.dtNgayKetThuc.Value.AddMonths(-6) > this.dtNgayBatDau.Value)
      {
        int num = (int) MessageBox.Show(Resources.TabGepCau_btnThongke_Click_BẠN_CHỈ_KIỂM_TRA_ĐƯƠC_KHOẢNG_THỜI_GIAN_TỐI_ĐA_LÀ_6_THÁNG, Resources.FLossPw_XuLy_THÔNG_BÁO);
        this.dtNgayBatDau.Value = this.dtNgayKetThuc.Value.AddMonths(-6);
      }
      else
      {
        if (this.numTien.Enabled)
        {
          if (this.numLui.Value == this.numTien.Value)
          {
            if (MessageBox.Show(Resources.tabGepCau_btnThongke_Click_LÔ_TÔ__LÙI__VÀ_LÔ_TÔ__TIẾN__BẰNG_NHAU__BẠN_CÓ_MUỐN_CHUYỂN_SANG_XEM_GÉP_CẦU_BẠCH_THỦ__, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
              this.cbbLoaiCau.SelectedIndex = 1;
              this.ValueCbbLoaiCau = 1;
            }
            else
            {
              this.numLui.Focus();
              return;
            }
          }
          else if (this.numLui.Value > this.numTien.Value)
          {
            int num = (int) MessageBox.Show(Resources.tabGepCau_btnThongke_Click_LÔ_TÔ__LÙI__PHẢI_NHỎ_HƠN_LÔ_TÔ___TIẾN__BẠN_NHÉ__, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.numLui.Focus();
            return;
          }
        }
        this.lui = this.numLui.Value;
        this.tien = this.numTien.Value;
        this._khungdanh = this._objConfigBacNho.KhungDanhLoCapNuoi;
        if (this.ValueCbbLoaiCau == 1)
          this._khungdanh = this._objConfigBacNho.KhungDanhBachThuNuoi;
        if (this.bgGetDataTong.IsBusy || this.bgGetNgayHienTai.IsBusy || (this.bgCauBachThu.IsBusy || this.bg1.IsBusy) || (this.bg2.IsBusy || this.bg3.IsBusy || (this.bg4.IsBusy || this.bg5.IsBusy)) || this.bg6.IsBusy || this.bg7.IsBusy)
          return;
        this.bgGetDataTong.RunWorkerAsync();
      }
    }

    private void bgGetDataTong_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (!this.bg1.IsBusy)
        this.bg1.RunWorkerAsync();
      if (!this.bg2.IsBusy)
        this.bg2.RunWorkerAsync();
      if (!this.bg3.IsBusy)
        this.bg3.RunWorkerAsync();
      if (!this.bg4.IsBusy)
        this.bg4.RunWorkerAsync();
      if (!this.bg5.IsBusy)
        this.bg5.RunWorkerAsync();
      if (!this.bg6.IsBusy)
        this.bg6.RunWorkerAsync();
      if (this.bg7.IsBusy)
        return;
      this.bg7.RunWorkerAsync();
    }

    private DataTable ProData1(DataTable dtTongLo, DataTable dtTongViTri, List<TabGepCau.ListCauBachThu> dtlist)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("               ");
      DateTime dateTime;
      int num1;
      for (int index = 0; index < dtTongLo.Rows.Count; ++index)
      {
        dateTime = DateTime.Parse(dtTongLo.Rows[index][1].ToString());
        num1 = dateTime.Day;
        string str1 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        num1 = dateTime.Month;
        string str2 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        dataTable.Columns.Add(str1 + " / " + str2, typeof (string));
      }
      dataTable.Columns.Add("NCR", typeof (int));
      dataTable.Columns.Add("VỀ/LẦN", typeof (string));
      dataTable.Columns.Add("TỈ LỆ(%)", typeof (Decimal));
      dataTable.Columns.Add("CẦU", typeof (string));
      if (dtlist.Count > 0)
      {
        Decimal num2 = new Decimal();
        for (int index1 = 0; index1 < dtlist.Count; ++index1)
        {
          Decimal num3 = new Decimal();
          DataRow row = dataTable.NewRow();
          string vt1 = dtlist[index1].Vt1;
          string vt2 = dtlist[index1].Vt2;
          row["CẦU"] = (object) ("[ " + vt1 + " - " + vt2 + " ]");
          string s = "0";
          for (int index2 = 0; index2 < dtTongViTri.Rows.Count; ++index2)
          {
            string[] strArray1 = this.BienDoiLoTo1(dtTongViTri.Rows[index2][vt1].ToString(), dtTongViTri.Rows[index2][vt2].ToString());
            string loto1 = strArray1[0];
            string loto2 = strArray1[1];
            string str1 = loto1 + "-" + loto2;
            if (loto1 == loto2)
              str1 = loto1;
            dateTime = DateTime.Parse(dtTongViTri.Rows[index2][1].ToString());
            num1 = dateTime.Day;
            string str2 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
            num1 = dateTime.Month;
            string str3 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
            string[] strArray2 = this.checkLotoVe1(loto1, loto2, int.Parse(dtTongViTri.Rows[index2]["STT"].ToString()));
            if (strArray2[1] == "ve")
            {
              if (int.Parse(strArray2[0]) <= this._khungdanh)
                num3 += Decimal.One;
            }
            else if (int.Parse(strArray2[0]) > int.Parse(s))
              s = strArray2[0];
            row[str2 + " / " + str3] = (object) (" " + str1 + "|" + strArray2[0] + "|" + strArray2[1] + " ");
          }
          Decimal num4 = num3 / (Decimal) (dtTongViTri.Rows.Count - 1) * new Decimal(100);
          row["TỈ LỆ(%)"] = !(num4 > Decimal.Zero) ? (object) "0" : (object) num4.ToString("##.#");
          row["NCR"] = (object) s;
          row["VỀ/LẦN"] = (object) (num3.ToString() + "/" + (object) (dtTongViTri.Rows.Count - 1));
          row["               "] = (object) "     ";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string[] checkLotoVe1(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this._dtTongLoto.Select("STT >'" + (object) soThuTuBanGhi + "'");
      DataTable dataTable1 = new DataTable();
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable2.Columns.Count; ++index2)
          {
            if (dataTable2.Rows[index1][index2].ToString() == loto1 || dataTable2.Rows[index1][index2].ToString() == loto2)
            {
              flag = true;
              break;
            }
          }
          num = index1 + 1;
          if (flag)
            break;
        }
        strArray[0] = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray[1] = !flag ? "chuave" : "ve";
      }
      return strArray;
    }

    public static bool IsNumber(string s)
    {
      return s.All<char>(new Func<char, bool>(char.IsDigit));
    }

    private string[] BienDoiLoTo1(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(this.tien - this.lui);
      string[] strArray1 = new string[2]{ "", "" };
      if (!TabGepCau.IsNumber(soVitri1))
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num1 = int.Parse(soVitri1 + soVitri2);
      if (this.ValueCbbLoaiCau == 0)
      {
        strArray1[0] = ((Decimal) num1 + this.lui).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (int.Parse(strArray1[0]) <= 0)
          strArray1[0] = "00";
        else if (int.Parse(strArray1[0]) < 10 && int.Parse(strArray1[0]) > 0)
          strArray1[0] = "0" + strArray1[0];
        else if (int.Parse(strArray1[0]) > 99)
          strArray1[0] = "99";
        strArray1[1] = this._objLoto.CheckLotoCap(strArray1[0]);
      }
      if (this.ValueCbbLoaiCau == 1)
      {
        strArray1[0] = ((Decimal) num1 + this.lui).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray1[0]) <= 0)
          strArray1[0] = "00";
        else if (int.Parse(strArray1[0]) < 10 && int.Parse(strArray1[0]) > 0)
          strArray1[0] = "0" + strArray1[0];
        else if (int.Parse(strArray1[0]) > 99)
          strArray1[0] = "99";
        strArray1[1] = strArray1[0];
      }
      Decimal num2;
      if (this.ValueCbbLoaiCau == 2)
      {
        strArray1[0] = ((Decimal) int.Parse(soVitri2) + this.lui).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        string[] strArray2 = strArray1;
        int index = 1;
        num2 = (Decimal) int.Parse(soVitri2) + this.tien;
        string str = num2.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray2[index] = str;
        if (int.Parse(strArray1[0]) <= 0)
        {
          strArray1[0] = "0";
          strArray1[1] = int32.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        }
        if (int.Parse(strArray1[1]) > 9)
        {
          strArray1[0] = "9";
          strArray1[1] = (9 - int32).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        }
        strArray1[0] = soVitri1 + strArray1[0];
        strArray1[1] = soVitri1 + strArray1[1];
      }
      if (this.ValueCbbLoaiCau == 3)
      {
        string[] strArray2 = strArray1;
        int index1 = 0;
        num2 = (Decimal) int.Parse(soVitri1) + this.lui;
        string str1 = num2.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray2[index1] = str1;
        string[] strArray3 = strArray1;
        int index2 = 1;
        num2 = (Decimal) int.Parse(soVitri1) + this.tien;
        string str2 = num2.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray3[index2] = str2;
        if (int.Parse(strArray1[0]) <= 0)
        {
          strArray1[0] = "0";
          strArray1[1] = int32.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        }
        if (int.Parse(strArray1[1]) > 9)
        {
          strArray1[0] = "9";
          strArray1[1] = (9 - int32).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        }
        strArray1[0] = strArray1[0] + soVitri2;
        strArray1[1] = strArray1[1] + soVitri2;
      }
      string str3 = strArray1[0];
      if (int.Parse(strArray1[1]) < int.Parse(strArray1[0]))
      {
        strArray1[0] = strArray1[1];
        strArray1[1] = str3;
      }
      return strArray1;
    }

    private DataTable ProData2(DataTable dtTongLo, DataTable dtTongViTri, List<TabGepCau.ListCauBachThu> dtlist)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("               ");
      DateTime dateTime;
      for (int index = 0; index < dtTongLo.Rows.Count; ++index)
      {
        dateTime = DateTime.Parse(dtTongLo.Rows[index][1].ToString());
        int num = dateTime.Day;
        string str1 = num.ToString();
        num = dateTime.Month;
        string str2 = num.ToString();
        dataTable.Columns.Add(str1 + " / " + str2, typeof (string));
      }
      dataTable.Columns.Add("NCR", typeof (int));
      dataTable.Columns.Add("VỀ/LẦN", typeof (string));
      dataTable.Columns.Add("TỈ LỆ(%)", typeof (Decimal));
      dataTable.Columns.Add("CẦU", typeof (string));
      if (dtlist.Count > 0)
      {
        Decimal num1 = new Decimal();
        for (int index1 = 0; index1 < dtlist.Count; ++index1)
        {
          Decimal num2 = new Decimal();
          DataRow row = dataTable.NewRow();
          string vt1 = dtlist[index1].Vt1;
          string vt2 = dtlist[index1].Vt2;
          row["CẦU"] = (object) ("[ " + vt1 + " - " + vt2 + " ]");
          string s = "0";
          for (int index2 = 0; index2 < dtTongViTri.Rows.Count; ++index2)
          {
            string[] strArray1 = this.BienDoiLoTo2(dtTongViTri.Rows[index2][vt1].ToString(), dtTongViTri.Rows[index2][vt2].ToString());
            string loto1 = strArray1[0];
            string loto2 = strArray1[1];
            string str1 = loto1 + "-" + loto2;
            if (loto1 == loto2)
              str1 = loto1;
            dateTime = DateTime.Parse(dtTongViTri.Rows[index2][1].ToString());
            int num3 = dateTime.Day;
            string str2 = num3.ToString((IFormatProvider) CultureInfo.InvariantCulture);
            num3 = dateTime.Month;
            string str3 = num3.ToString((IFormatProvider) CultureInfo.InvariantCulture);
            string[] strArray2 = this.checkLotoVe2(loto1, loto2, int.Parse(dtTongViTri.Rows[index2]["STT"].ToString()));
            if (strArray2[1] == "ve")
            {
              if (int.Parse(strArray2[0]) <= this._khungdanh)
                num2 += Decimal.One;
            }
            else if (int.Parse(strArray2[0]) > int.Parse(s))
              s = strArray2[0];
            row[str2 + " / " + str3] = (object) (" " + str1 + "|" + strArray2[0] + "|" + strArray2[1] + " ");
          }
          Decimal num4 = num2 / (Decimal) (dtTongViTri.Rows.Count - 1) * new Decimal(100);
          row["TỈ LỆ(%)"] = !(num4 > Decimal.Zero) ? (object) "0" : (object) num4.ToString("##.#");
          row["NCR"] = (object) s;
          row["VỀ/LẦN"] = (object) (num2.ToString() + "/" + (object) (dtTongViTri.Rows.Count - 1));
          row["               "] = (object) "     ";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string[] checkLotoVe2(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this._dtTongLoto.Select("STT >'" + (object) soThuTuBanGhi + "'");
      DataTable dataTable1 = new DataTable();
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable2.Columns.Count; ++index2)
          {
            if (dataTable2.Rows[index1][index2].ToString() == loto1 || dataTable2.Rows[index1][index2].ToString() == loto2)
            {
              flag = true;
              break;
            }
          }
          num = index1 + 1;
          if (flag)
            break;
        }
        strArray[0] = num.ToString();
        strArray[1] = !flag ? "chuave" : "ve";
      }
      return strArray;
    }

    private string[] BienDoiLoTo2(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(this.tien - this.lui);
      string[] strArray = new string[2]{ "", "" };
      if (!TabGepCau.IsNumber(soVitri1))
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num = int.Parse(soVitri1 + soVitri2);
      if (this.ValueCbbLoaiCau == 0)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString();
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = this._objLoto.CheckLotoCap(strArray[0]);
      }
      if (this.ValueCbbLoaiCau == 1)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = strArray[0];
      }
      if (this.ValueCbbLoaiCau == 2)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri2) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri2) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = soVitri1 + strArray[0];
        strArray[1] = soVitri1 + strArray[1];
      }
      if (this.ValueCbbLoaiCau == 3)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri1) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri1) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = strArray[0] + soVitri2;
        strArray[1] = strArray[1] + soVitri2;
      }
      string str = strArray[0];
      if (int.Parse(strArray[1]) < int.Parse(strArray[0]))
      {
        strArray[0] = strArray[1];
        strArray[1] = str;
      }
      return strArray;
    }

    private DataTable ProData3(DataTable dtTongLo, DataTable dtTongViTri, List<TabGepCau.ListCauBachThu> dtlist)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("               ");
      DateTime dateTime;
      for (int index = 0; index < dtTongLo.Rows.Count; ++index)
      {
        dateTime = DateTime.Parse(dtTongLo.Rows[index][1].ToString());
        int num = dateTime.Day;
        string str1 = num.ToString();
        num = dateTime.Month;
        string str2 = num.ToString();
        dataTable.Columns.Add(str1 + " / " + str2, typeof (string));
      }
      dataTable.Columns.Add("NCR", typeof (int));
      dataTable.Columns.Add("VỀ/LẦN", typeof (string));
      dataTable.Columns.Add("TỈ LỆ(%)", typeof (Decimal));
      dataTable.Columns.Add("CẦU", typeof (string));
      if (dtlist.Count > 0)
      {
        Decimal num1 = new Decimal();
        for (int index1 = 0; index1 < dtlist.Count; ++index1)
        {
          Decimal num2 = new Decimal();
          DataRow row = dataTable.NewRow();
          string vt1 = dtlist[index1].Vt1;
          string vt2 = dtlist[index1].Vt2;
          row["CẦU"] = (object) ("[ " + vt1 + " - " + vt2 + " ]");
          string s = "0";
          for (int index2 = 0; index2 < dtTongViTri.Rows.Count; ++index2)
          {
            string[] strArray1 = this.BienDoiLoTo3(dtTongViTri.Rows[index2][vt1].ToString(), dtTongViTri.Rows[index2][vt2].ToString());
            string loto1 = strArray1[0];
            string loto2 = strArray1[1];
            string str1 = loto1 + "-" + loto2;
            if (loto1 == loto2)
              str1 = loto1;
            dateTime = DateTime.Parse(dtTongViTri.Rows[index2][1].ToString());
            int num3 = dateTime.Day;
            string str2 = num3.ToString();
            num3 = dateTime.Month;
            string str3 = num3.ToString();
            string[] strArray2 = this.checkLotoVe3(loto1, loto2, int.Parse(dtTongViTri.Rows[index2]["STT"].ToString()));
            if (strArray2[1] == "ve")
            {
              if (int.Parse(strArray2[0]) <= this._khungdanh)
                num2 += Decimal.One;
            }
            else if (int.Parse(strArray2[0]) > int.Parse(s))
              s = strArray2[0];
            row[str2 + " / " + str3] = (object) (" " + str1 + "|" + strArray2[0] + "|" + strArray2[1] + " ");
          }
          Decimal num4 = num2 / (Decimal) (dtTongViTri.Rows.Count - 1) * new Decimal(100);
          row["NCR"] = (object) s;
          row["VỀ/LẦN"] = (object) (num2.ToString() + "/" + (object) (dtTongViTri.Rows.Count - 1));
          row["TỈ LỆ(%)"] = !(num4 > Decimal.Zero) ? (object) "0" : (object) num4.ToString("##.#");
          row["               "] = (object) "     ";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string[] checkLotoVe3(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this._dtTongLoto.Select("STT >'" + (object) soThuTuBanGhi + "'");
      DataTable dataTable1 = new DataTable();
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable2.Columns.Count; ++index2)
          {
            if (dataTable2.Rows[index1][index2].ToString() == loto1 || dataTable2.Rows[index1][index2].ToString() == loto2)
            {
              flag = true;
              break;
            }
          }
          num = index1 + 1;
          if (flag)
            break;
        }
        strArray[0] = num.ToString();
        strArray[1] = !flag ? "chuave" : "ve";
      }
      return strArray;
    }

    private string[] BienDoiLoTo3(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(this.tien - this.lui);
      string[] strArray = new string[2]{ "", "" };
      if (!TabGepCau.IsNumber(soVitri1))
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num = int.Parse(soVitri1 + soVitri2);
      if (this.ValueCbbLoaiCau == 0)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString();
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = this._objLoto.CheckLotoCap(strArray[0]);
      }
      if (this.ValueCbbLoaiCau == 1)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = strArray[0];
      }
      if (this.ValueCbbLoaiCau == 2)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri2) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri2) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = soVitri1 + strArray[0];
        strArray[1] = soVitri1 + strArray[1];
      }
      if (this.ValueCbbLoaiCau == 3)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri1) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri1) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = strArray[0] + soVitri2;
        strArray[1] = strArray[1] + soVitri2;
      }
      string str = strArray[0];
      if (int.Parse(strArray[1]) < int.Parse(strArray[0]))
      {
        strArray[0] = strArray[1];
        strArray[1] = str;
      }
      return strArray;
    }

    private DataTable ProData4(DataTable dtTongLo, DataTable dtTongViTri, List<TabGepCau.ListCauBachThu> dtlist)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("               ");
      DateTime dateTime;
      for (int index = 0; index < dtTongLo.Rows.Count; ++index)
      {
        dateTime = DateTime.Parse(dtTongLo.Rows[index][1].ToString());
        int num = dateTime.Day;
        string str1 = num.ToString();
        num = dateTime.Month;
        string str2 = num.ToString();
        dataTable.Columns.Add(str1 + " / " + str2, typeof (string));
      }
      dataTable.Columns.Add("NCR", typeof (int));
      dataTable.Columns.Add("VỀ/LẦN", typeof (string));
      dataTable.Columns.Add("TỈ LỆ(%)", typeof (Decimal));
      dataTable.Columns.Add("CẦU", typeof (string));
      if (dtlist.Count > 0)
      {
        for (int index1 = 0; index1 < dtlist.Count; ++index1)
        {
          Decimal num1 = new Decimal();
          DataRow row = dataTable.NewRow();
          string vt1 = dtlist[index1].Vt1;
          string vt2 = dtlist[index1].Vt2;
          row["CẦU"] = (object) ("[ " + vt1 + " - " + vt2 + " ]");
          string s = "0";
          for (int index2 = 0; index2 < dtTongViTri.Rows.Count; ++index2)
          {
            string[] strArray1 = this.BienDoiLoTo4(dtTongViTri.Rows[index2][vt1].ToString(), dtTongViTri.Rows[index2][vt2].ToString());
            string loto1 = strArray1[0];
            string loto2 = strArray1[1];
            string str1 = loto1 + "-" + loto2;
            if (loto1 == loto2)
              str1 = loto1;
            dateTime = DateTime.Parse(dtTongViTri.Rows[index2][1].ToString());
            int num2 = dateTime.Day;
            string str2 = num2.ToString();
            num2 = dateTime.Month;
            string str3 = num2.ToString();
            string[] strArray2 = this.checkLotoVe4(loto1, loto2, int.Parse(dtTongViTri.Rows[index2]["STT"].ToString()));
            if (strArray2[1] == "ve")
            {
              if (int.Parse(strArray2[0]) <= this._khungdanh)
                num1 += Decimal.One;
            }
            else if (int.Parse(strArray2[0]) > int.Parse(s))
              s = strArray2[0];
            row[str2 + " / " + str3] = (object) (" " + str1 + "|" + strArray2[0] + "|" + strArray2[1] + " ");
          }
          Decimal num3 = num1 / (Decimal) (dtTongViTri.Rows.Count - 1) * new Decimal(100);
          row["NCR"] = (object) s;
          row["VỀ/LẦN"] = (object) (num1.ToString() + "/" + (object) (dtTongViTri.Rows.Count - 1));
          row["TỈ LỆ(%)"] = !(num3 > Decimal.Zero) ? (object) "0" : (object) num3.ToString("##.#");
          row["               "] = (object) "     ";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string[] checkLotoVe4(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this._dtTongLoto.Select("STT >'" + (object) soThuTuBanGhi + "'");
      DataTable dataTable1 = new DataTable();
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable2.Columns.Count; ++index2)
          {
            if (dataTable2.Rows[index1][index2].ToString() == loto1 || dataTable2.Rows[index1][index2].ToString() == loto2)
            {
              flag = true;
              break;
            }
          }
          num = index1 + 1;
          if (flag)
            break;
        }
        strArray[0] = num.ToString();
        strArray[1] = !flag ? "chuave" : "ve";
      }
      return strArray;
    }

    private string[] BienDoiLoTo4(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(this.tien - this.lui);
      string[] strArray = new string[2]{ "", "" };
      if (!TabGepCau.IsNumber(soVitri1))
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num = int.Parse(soVitri1 + soVitri2);
      if (this.ValueCbbLoaiCau == 0)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString();
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = this._objLoto.CheckLotoCap(strArray[0]);
      }
      if (this.ValueCbbLoaiCau == 1)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = strArray[0];
      }
      if (this.ValueCbbLoaiCau == 2)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri2) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri2) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = soVitri1 + strArray[0];
        strArray[1] = soVitri1 + strArray[1];
      }
      if (this.ValueCbbLoaiCau == 3)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri1) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri1) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = strArray[0] + soVitri2;
        strArray[1] = strArray[1] + soVitri2;
      }
      string str = strArray[0];
      if (int.Parse(strArray[1]) < int.Parse(strArray[0]))
      {
        strArray[0] = strArray[1];
        strArray[1] = str;
      }
      return strArray;
    }

    private DataTable ProData5(DataTable dtTongLo, DataTable dtTongViTri, List<TabGepCau.ListCauBachThu> dtlist)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("               ");
      DateTime dateTime;
      for (int index = 0; index < dtTongLo.Rows.Count; ++index)
      {
        dateTime = DateTime.Parse(dtTongLo.Rows[index][1].ToString());
        int num = dateTime.Day;
        string str1 = num.ToString();
        num = dateTime.Month;
        string str2 = num.ToString();
        dataTable.Columns.Add(str1 + " / " + str2, typeof (string));
      }
      dataTable.Columns.Add("NCR", typeof (int));
      dataTable.Columns.Add("VỀ/LẦN", typeof (string));
      dataTable.Columns.Add("TỈ LỆ(%)", typeof (Decimal));
      dataTable.Columns.Add("CẦU", typeof (string));
      if (dtlist.Count > 0)
      {
        for (int index1 = 0; index1 < dtlist.Count; ++index1)
        {
          Decimal num1 = new Decimal();
          DataRow row = dataTable.NewRow();
          string vt1 = dtlist[index1].Vt1;
          string vt2 = dtlist[index1].Vt2;
          row["CẦU"] = (object) ("[ " + vt1 + " - " + vt2 + " ]");
          string s = "0";
          for (int index2 = 0; index2 < dtTongViTri.Rows.Count; ++index2)
          {
            string[] strArray1 = this.BienDoiLoTo5(dtTongViTri.Rows[index2][vt1].ToString(), dtTongViTri.Rows[index2][vt2].ToString());
            string loto1 = strArray1[0];
            string loto2 = strArray1[1];
            string str1 = loto1 + "-" + loto2;
            if (loto1 == loto2)
              str1 = loto1;
            dateTime = DateTime.Parse(dtTongViTri.Rows[index2][1].ToString());
            int num2 = dateTime.Day;
            string str2 = num2.ToString();
            num2 = dateTime.Month;
            string str3 = num2.ToString();
            string[] strArray2 = this.checkLotoVe5(loto1, loto2, int.Parse(dtTongViTri.Rows[index2]["STT"].ToString()));
            if (strArray2[1] == "ve")
            {
              if (int.Parse(strArray2[0]) <= this._khungdanh)
                num1 += Decimal.One;
            }
            else if (int.Parse(strArray2[0]) > int.Parse(s))
              s = strArray2[0];
            row[str2 + " / " + str3] = (object) (" " + str1 + "|" + strArray2[0] + "|" + strArray2[1] + " ");
          }
          Decimal num3 = num1 / (Decimal) (dtTongViTri.Rows.Count - 1) * new Decimal(100);
          row["NCR"] = (object) s;
          row["VỀ/LẦN"] = (object) (num1.ToString() + "/" + (object) (dtTongViTri.Rows.Count - 1));
          row["TỈ LỆ(%)"] = !(num3 > Decimal.Zero) ? (object) "0" : (object) num3.ToString("##.#");
          row["               "] = (object) "     ";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string[] checkLotoVe5(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this._dtTongLoto.Select("STT >'" + (object) soThuTuBanGhi + "'");
      DataTable dataTable1 = new DataTable();
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable2.Columns.Count; ++index2)
          {
            if (dataTable2.Rows[index1][index2].ToString() == loto1 || dataTable2.Rows[index1][index2].ToString() == loto2)
            {
              flag = true;
              break;
            }
          }
          num = index1 + 1;
          if (flag)
            break;
        }
        strArray[0] = num.ToString();
        strArray[1] = !flag ? "chuave" : "ve";
      }
      return strArray;
    }

    private string[] BienDoiLoTo5(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(this.tien - this.lui);
      string[] strArray = new string[2]{ "", "" };
      if (!TabGepCau.IsNumber(soVitri1))
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num = int.Parse(soVitri1 + soVitri2);
      if (this.ValueCbbLoaiCau == 0)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString();
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = this._objLoto.CheckLotoCap(strArray[0]);
      }
      if (this.ValueCbbLoaiCau == 1)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = strArray[0];
      }
      if (this.ValueCbbLoaiCau == 2)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri2) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri2) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = soVitri1 + strArray[0];
        strArray[1] = soVitri1 + strArray[1];
      }
      if (this.ValueCbbLoaiCau == 3)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri1) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri1) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = strArray[0] + soVitri2;
        strArray[1] = strArray[1] + soVitri2;
      }
      string str = strArray[0];
      if (int.Parse(strArray[1]) < int.Parse(strArray[0]))
      {
        strArray[0] = strArray[1];
        strArray[1] = str;
      }
      return strArray;
    }

    private DataTable ProData6(DataTable dtTongLo, DataTable dtTongViTri, List<TabGepCau.ListCauBachThu> dtlist)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("               ");
      DateTime dateTime;
      for (int index = 0; index < dtTongLo.Rows.Count; ++index)
      {
        dateTime = DateTime.Parse(dtTongLo.Rows[index][1].ToString());
        int num = dateTime.Day;
        string str1 = num.ToString();
        num = dateTime.Month;
        string str2 = num.ToString();
        dataTable.Columns.Add(str1 + " / " + str2, typeof (string));
      }
      dataTable.Columns.Add("NCR", typeof (int));
      dataTable.Columns.Add("VỀ/LẦN", typeof (string));
      dataTable.Columns.Add("TỈ LỆ(%)", typeof (Decimal));
      dataTable.Columns.Add("CẦU", typeof (string));
      if (dtlist.Count > 0)
      {
        for (int index1 = 0; index1 < dtlist.Count; ++index1)
        {
          Decimal num1 = new Decimal();
          DataRow row = dataTable.NewRow();
          string vt1 = dtlist[index1].Vt1;
          string vt2 = dtlist[index1].Vt2;
          row["CẦU"] = (object) ("[ " + vt1 + " - " + vt2 + " ]");
          string s = "0";
          for (int index2 = 0; index2 < dtTongViTri.Rows.Count; ++index2)
          {
            string[] strArray1 = this.BienDoiLoTo6(dtTongViTri.Rows[index2][vt1].ToString(), dtTongViTri.Rows[index2][vt2].ToString());
            string loto1 = strArray1[0];
            string loto2 = strArray1[1];
            string str1 = loto1 + "-" + loto2;
            if (loto1 == loto2)
              str1 = loto1;
            dateTime = DateTime.Parse(dtTongViTri.Rows[index2][1].ToString());
            int num2 = dateTime.Day;
            string str2 = num2.ToString();
            num2 = dateTime.Month;
            string str3 = num2.ToString();
            string[] strArray2 = this.checkLotoVe6(loto1, loto2, int.Parse(dtTongViTri.Rows[index2]["STT"].ToString()));
            if (strArray2[1] == "ve")
            {
              if (int.Parse(strArray2[0]) <= this._khungdanh)
                num1 += Decimal.One;
            }
            else if (int.Parse(strArray2[0]) > int.Parse(s))
              s = strArray2[0];
            row[str2 + " / " + str3] = (object) (" " + str1 + "|" + strArray2[0] + "|" + strArray2[1] + " ");
          }
          Decimal num3 = num1 / (Decimal) (dtTongViTri.Rows.Count - 1) * new Decimal(100);
          row["NCR"] = (object) s;
          row["VỀ/LẦN"] = (object) (num1.ToString() + "/" + (object) (dtTongViTri.Rows.Count - 1));
          row["TỈ LỆ(%)"] = !(num3 > Decimal.Zero) ? (object) "0" : (object) num3.ToString("##.#");
          row["               "] = (object) "     ";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string[] checkLotoVe6(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this._dtTongLoto.Select("STT >'" + (object) soThuTuBanGhi + "'");
      DataTable dataTable1 = new DataTable();
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable2.Columns.Count; ++index2)
          {
            if (dataTable2.Rows[index1][index2].ToString() == loto1 || dataTable2.Rows[index1][index2].ToString() == loto2)
            {
              flag = true;
              break;
            }
          }
          num = index1 + 1;
          if (flag)
            break;
        }
        strArray[0] = num.ToString();
        strArray[1] = !flag ? "chuave" : "ve";
      }
      return strArray;
    }

    private string[] BienDoiLoTo6(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(this.tien - this.lui);
      string[] strArray = new string[2]{ "", "" };
      if (!TabGepCau.IsNumber(soVitri1))
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num = int.Parse(soVitri1 + soVitri2);
      if (this.ValueCbbLoaiCau == 0)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString();
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = this._objLoto.CheckLotoCap(strArray[0]);
      }
      if (this.ValueCbbLoaiCau == 1)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = strArray[0];
      }
      if (this.ValueCbbLoaiCau == 2)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri2) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri2) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = soVitri1 + strArray[0];
        strArray[1] = soVitri1 + strArray[1];
      }
      if (this.ValueCbbLoaiCau == 3)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri1) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri1) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = strArray[0] + soVitri2;
        strArray[1] = strArray[1] + soVitri2;
      }
      string str = strArray[0];
      if (int.Parse(strArray[1]) < int.Parse(strArray[0]))
      {
        strArray[0] = strArray[1];
        strArray[1] = str;
      }
      return strArray;
    }

    private DataTable ProData7(DataTable dtTongLo, DataTable dtTongViTri, List<TabGepCau.ListCauBachThu> dtlist)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("               ");
      DateTime dateTime;
      for (int index = 0; index < dtTongLo.Rows.Count; ++index)
      {
        dateTime = DateTime.Parse(dtTongLo.Rows[index][1].ToString());
        int num = dateTime.Day;
        string str1 = num.ToString();
        num = dateTime.Month;
        string str2 = num.ToString();
        dataTable.Columns.Add(str1 + " / " + str2, typeof (string));
      }
      dataTable.Columns.Add("NCR", typeof (int));
      dataTable.Columns.Add("VỀ/LẦN", typeof (string));
      dataTable.Columns.Add("TỈ LỆ(%)", typeof (Decimal));
      dataTable.Columns.Add("CẦU", typeof (string));
      if (dtlist.Count > 0)
      {
        for (int index1 = 0; index1 < dtlist.Count; ++index1)
        {
          Decimal num1 = new Decimal();
          DataRow row = dataTable.NewRow();
          string vt1 = dtlist[index1].Vt1;
          string vt2 = dtlist[index1].Vt2;
          row["CẦU"] = (object) ("[ " + vt1 + " - " + vt2 + " ]");
          string s = "0";
          for (int index2 = 0; index2 < dtTongViTri.Rows.Count; ++index2)
          {
            string[] strArray1 = this.BienDoiLoTo7(dtTongViTri.Rows[index2][vt1].ToString(), dtTongViTri.Rows[index2][vt2].ToString());
            string loto1 = strArray1[0];
            string loto2 = strArray1[1];
            string str1 = loto1 + "-" + loto2;
            if (loto1 == loto2)
              str1 = loto1;
            dateTime = DateTime.Parse(dtTongViTri.Rows[index2][1].ToString());
            int num2 = dateTime.Day;
            string str2 = num2.ToString();
            num2 = dateTime.Month;
            string str3 = num2.ToString();
            string[] strArray2 = this.checkLotoVe7(loto1, loto2, int.Parse(dtTongViTri.Rows[index2]["STT"].ToString()));
            if (strArray2[1] == "ve")
            {
              if (int.Parse(strArray2[0]) <= this._khungdanh)
                num1 += Decimal.One;
            }
            else if (int.Parse(strArray2[0]) > int.Parse(s))
              s = strArray2[0];
            row[str2 + " / " + str3] = (object) (" " + str1 + "|" + strArray2[0] + "|" + strArray2[1] + " ");
          }
          Decimal num3 = num1 / (Decimal) (dtTongViTri.Rows.Count - 1) * new Decimal(100);
          row["NCR"] = (object) s;
          row["VỀ/LẦN"] = (object) (num1.ToString() + "/" + (object) (dtTongViTri.Rows.Count - 1));
          row["TỈ LỆ(%)"] = !(num3 > Decimal.Zero) ? (object) "0" : (object) num3.ToString("##.#");
          row["               "] = (object) "     ";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string[] checkLotoVe7(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this._dtTongLoto.Select("STT >'" + (object) soThuTuBanGhi + "'");
      DataTable dataTable1 = new DataTable();
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable2.Columns.Count; ++index2)
          {
            if (dataTable2.Rows[index1][index2].ToString() == loto1 || dataTable2.Rows[index1][index2].ToString() == loto2)
            {
              flag = true;
              break;
            }
          }
          num = index1 + 1;
          if (flag)
            break;
        }
        strArray[0] = num.ToString();
        strArray[1] = !flag ? "chuave" : "ve";
      }
      return strArray;
    }

    private string[] BienDoiLoTo7(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(this.tien - this.lui);
      string[] strArray = new string[2]{ "", "" };
      if (!TabGepCau.IsNumber(soVitri1))
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num = int.Parse(soVitri1 + soVitri2);
      if (this.ValueCbbLoaiCau == 0)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString();
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = this._objLoto.CheckLotoCap(strArray[0]);
      }
      if (this.ValueCbbLoaiCau == 1)
      {
        strArray[0] = ((Decimal) num + this.lui).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray[0]) <= 0)
          strArray[0] = "00";
        else if (int.Parse(strArray[0]) < 10 && int.Parse(strArray[0]) > 0)
          strArray[0] = "0" + strArray[0];
        else if (int.Parse(strArray[0]) > 99)
          strArray[0] = "99";
        strArray[1] = strArray[0];
      }
      if (this.ValueCbbLoaiCau == 2)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri2) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri2) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = soVitri1 + strArray[0];
        strArray[1] = soVitri1 + strArray[1];
      }
      if (this.ValueCbbLoaiCau == 3)
      {
        strArray[0] = ((Decimal) int.Parse(soVitri1) + this.lui).ToString();
        strArray[1] = ((Decimal) int.Parse(soVitri1) + this.tien).ToString();
        if (int.Parse(strArray[0]) <= 0)
        {
          strArray[0] = "0";
          strArray[1] = int32.ToString();
        }
        if (int.Parse(strArray[1]) > 9)
        {
          strArray[0] = "9";
          strArray[1] = (9 - int32).ToString();
        }
        strArray[0] = strArray[0] + soVitri2;
        strArray[1] = strArray[1] + soVitri2;
      }
      string str = strArray[0];
      if (int.Parse(strArray[1]) < int.Parse(strArray[0]))
      {
        strArray[0] = strArray[1];
        strArray[1] = str;
      }
      return strArray;
    }

    private void bg1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.XuLyHienThi();
    }

    private void XuLyHienThi()
    {
      if (this.bg1.IsBusy || this.bg2.IsBusy || (this.bg3.IsBusy || this.bg4.IsBusy) || (this.bg5.IsBusy || this.bg6.IsBusy) || this.bg7.IsBusy)
        return;
      this.dtOk.Merge(this.dt1);
      this.dtOk.Merge(this.dt2);
      this.dtOk.Merge(this.dt3);
      this.dtOk.Merge(this.dt4);
      this.dtOk.Merge(this.dt5);
      this.dtOk.Merge(this.dt6);
      this.dtOk.Merge(this.dt7);
      if (!this.bgLocDuLieu.IsBusy)
        this.bgLocDuLieu.RunWorkerAsync();
    }

    private void GetSoBanGhi()
    {
      if (this.dtOk == null)
        return;
      this.dtTam = new DataTable();
      this.dtTam = this.dtOk;
      if (this.cbbNCR.Enabled)
      {
        DataRow[] dataRowArray = this.dtTam.Select(this._ngayChuaRa <= 1 ? "NCR <>" + (object) this._ngayChuaRa ?? "" : "NCR=" + (object) this._ngayChuaRa ?? "");
        if ((uint) dataRowArray.Length > 0U)
          this.dtTam = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      }
      if (this.dtTam.Rows.Count > 0)
      {
        this.dtg_Ketqua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        DataView defaultView = this.dtTam.DefaultView;
        defaultView.Sort = this.hienThiTheo + " " + this.xapXep;
        this.dtTam = defaultView.ToTable();
      }
    }

    private void dtg_Ketqua_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
    }

    private void XuLy()
    {
      this.panel2.Enabled = false;
      for (int index1 = 0; index1 < this.dtg_Ketqua.Rows.Count; ++index1)
      {
        for (int index2 = 0; index2 < this.dtg_Ketqua.Columns.Count; ++index2)
        {
          this.dtg_Ketqua.Columns[index2].SortMode = DataGridViewColumnSortMode.NotSortable;
          if (index2 < this.dtg_Ketqua.Columns.Count - 4 && index2 > 0)
          {
            string str = this.dtg_Ketqua.Rows[index1].Cells[index2].Value.ToString();
            string[] strArray = str.Split('|');
            if (str.Length > 2 && strArray.Length > 1)
            {
              if (strArray[2].Trim() == "ve")
              {
                DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
                if (int.Parse(strArray[1].Trim()) == this._khungdanh + 1)
                {
                  gridViewCellStyle.BackColor = Color.FromArgb(250, 162, 0);
                  gridViewCellStyle.ForeColor = Color.White;
                  gridViewCellStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
                }
                else if (int.Parse(strArray[1].Trim()) > this._khungdanh + 1)
                {
                  gridViewCellStyle.BackColor = Color.FromArgb(201, 27, 38);
                  gridViewCellStyle.ForeColor = Color.Snow;
                  gridViewCellStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
                }
                else
                {
                  gridViewCellStyle.BackColor = Color.White;
                  gridViewCellStyle.ForeColor = Color.Black;
                  gridViewCellStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
                }
                this.dtg_Ketqua.Rows[index1].Cells[index2].Style = gridViewCellStyle;
              }
              else if (strArray[2].Trim() == "chuave")
              {
                DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle()
                {
                  BackColor = Color.DimGray,
                  ForeColor = Color.White,
                  Font = new Font("Arial", 9f, FontStyle.Regular)
                };
                this.dtg_Ketqua.Rows[index1].Cells[index2].Style = gridViewCellStyle;
              }
              this.dtg_Ketqua.Rows[index1].Cells[index2].Value = (object) ("  " + strArray[0] + "(" + strArray[1] + ")  ");
            }
          }
          else
          {
            DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle()
            {
              BackColor = Color.FromArgb(222, 24, 112),
              ForeColor = Color.White,
              Font = new Font("Arial", 9f, FontStyle.Bold),
              Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            this.dtg_Ketqua.Rows[index1].Cells[index2].Style = gridViewCellStyle;
          }
        }
      }
      this.panel2.Enabled = true;
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.XuLy();
    }

    private void bgCauBachThu_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    private void bg1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dt1 = this.ProData1(this._dtTongLoto, this._dtTongCau, this._listCauBachThu1);
    }

    private void bg2_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dt2 = this.ProData2(this._dtTongLoto, this._dtTongCau, this._listCauBachThu2);
    }

    private void bg3_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dt3 = this.ProData3(this._dtTongLoto, this._dtTongCau, this._listCauBachThu3);
    }

    private void bg4_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dt4 = this.ProData4(this._dtTongLoto, this._dtTongCau, this._listCauBachThu4);
    }

    private void bg5_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dt5 = this.ProData5(this._dtTongLoto, this._dtTongCau, this._listCauBachThu5);
    }

    private void bg6_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dt6 = this.ProData6(this._dtTongLoto, this._dtTongCau, this._listCauBachThu6);
    }

    private void bg7_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dt7 = this.ProData7(this._dtTongLoto, this._dtTongCau, this._listCauBachThu7);
    }

    private void bg2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.XuLyHienThi();
    }

    private void bg3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.XuLyHienThi();
    }

    private void bg4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.XuLyHienThi();
    }

    private void dtg_Ketqua_MouseDown(object sender, MouseEventArgs e)
    {
      this.myHitTestDown = this.dtg_Ketqua.HitTest(e.X, e.Y);
      if (e.Button != MouseButtons.Right || this.myHitTestDown.RowIndex <= -1)
        return;
      this.dtg_Ketqua.Rows[this.myHitTestDown.RowIndex].Selected = true;
    }

    private void dtg_Ketqua_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex <= -1)
        return;
      this.rowIndex = e.RowIndex;
      string str1 = this.dtg_Ketqua.Rows[e.RowIndex].Cells[this.dtg_Ketqua.Columns.Count - 1].Value.ToString();
      string str2 = this.dtg_Ketqua.Rows[e.RowIndex].Cells[this.dtg_Ketqua.Columns.Count - 3].Value.ToString();
      string[] strArray = str2.Split('/');
      string str3 = "";
      int num = int.Parse(strArray[1]) - int.Parse(strArray[0]);
      if (num == 0)
        str3 = "KHÔNG XỊT PHÁT NÀO [<b style='color:red;'> TUYỆT VỜI</b> ]";
      if (num > 0 && num < 3)
        str3 = "XỊT <b style='color:red;'>" + (object) num + "</b> PHÁT [<b style='color:red;'> VẪN CỨ LÀ OK</b> ] !!!";
      if (num >= 3)
        str3 = "XỊT <b style='color:red;'>" + (object) num + "</b> PHÁT !!!";
      this.strTong = "TRONG <b style='color:red;'>" + (object) (this._dtTongLoto.Rows.Count - 1) + "</b> NGÀY VỪA QUA. CẦU Ở VỊ TRÍ <b style='color:red;'>" + str1 + "</b> VỀ <b style='color:red;'>" + str2 + "</b> LẦN. " + str3;
      this.Hien_Thi_ThongTinCau(this.wbThongbao, this.strTong);
    }

    private void Hien_Thi_ThongTinCau(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                <title>THỐNG KÊ XỔ SỐ</title></head><body><div style='width:100%;margin-top: 0px;text-align:center;font-size:14px;'>" + strHtml + "</div></body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void dtg_Ketqua_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      this.dtg_Ketqua.FirstDisplayedScrollingColumnIndex = this.dtg_Ketqua.ColumnCount - 1;
    }

    private void xEMCHITIẾTToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string[] strArray = Regex.Replace(this.dtg_Ketqua.Rows[this.rowIndex].Cells[this.dtg_Ketqua.Columns.Count - 1].Value.ToString(), "[^\\w\\.:-]", "", RegexOptions.None).Split('-');
      TbVitri.Vitri1 = strArray[0];
      TbVitri.Vitri2 = strArray[1];
      FMain.LoadTabname = this._tabName.ChiTietCau;
    }

    private void CbbHienThiSelectedIndexChanged(object sender, EventArgs e)
    {
      this.soBanGhi = this.cbbHienThi.SelectedItem.ToString();
      if (this.bgLocDuLieu.IsBusy)
        return;
      this.bgLocDuLieu.RunWorkerAsync();
    }

    private void CbbLocTheoSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbbLocTheo.SelectedIndex == 1)
      {
        this.cbbNCR.Enabled = true;
        this.hienThiTheo = "NCR";
      }
      else
      {
        this.cbbNCR.Enabled = false;
        this.hienThiTheo = "TỈ LỆ(%)";
      }
      if (this.bgLocDuLieu.IsBusy)
        return;
      this.bgLocDuLieu.RunWorkerAsync();
    }

    private void CbbTangGiamSelectedIndexChanged(object sender, EventArgs e)
    {
      this.xapXep = this.cbbTangGiam.SelectedIndex == 0 ? "DESC" : "ASC";
      if (this.bgLocDuLieu.IsBusy)
        return;
      this.bgLocDuLieu.RunWorkerAsync();
    }

    private void BgLocDuLieuDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetSoBanGhi();
    }

    private void BgLocDuLieuRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.dtTam == null || this.dtTam.Rows.Count <= 0 || (this.bgGetNgayHienTai.IsBusy || this.bgCauBachThu.IsBusy || (this.bgGetDataTong.IsBusy || this.bg1.IsBusy) || (this.bg2.IsBusy || this.bg3.IsBusy || (this.bg4.IsBusy || this.bg5.IsBusy)) || (this.bg6.IsBusy || this.bg7.IsBusy) || this.bgLocDuLieu.IsBusy))
        return;
      this.dtg_Ketqua.DataSource = (object) this.dtTam.AsEnumerable().Take<DataRow>(int.Parse(this.soBanGhi)).CopyToDataTable<DataRow>();
      this.XuLy();
    }

    private void DtgKetquaCellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex <= -1)
        return;
      string[] strArray = Regex.Replace(this.dtg_Ketqua.Rows[this.rowIndex].Cells[this.dtg_Ketqua.Columns.Count - 1].Value.ToString(), "[^\\w\\.:-]", "", RegexOptions.None).Split('-');
      TbVitri.Vitri1 = strArray[0];
      TbVitri.Vitri2 = strArray[1];
      TbVitri.NumLui = this.lui;
      TbVitri.NumTien = this.tien;
      TbVitri.NgayBatDau = this.dtNgayBatDau.Value;
      TbVitri.NgayKetThuc = this.dtNgayKetThuc.Value;
      TbVitri.CbbLotoSelectId = this.cbbLoaiCau.SelectedIndex;
      FMain.LoadTabname = FMain.TabName.ChiTietCau;
    }

    private void CbbNcrSelectedIndexChanged(object sender, EventArgs e)
    {
      this._ngayChuaRa = this.cbbNCR.SelectedIndex + 1;
      if (this.bgLocDuLieu.IsBusy)
        return;
      this.bgLocDuLieu.RunWorkerAsync();
    }

    private void numTien_ValueChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabGepCau));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      this.panel2 = new Panel();
      this.groupBox1 = new GroupBox();
      this.lblNCR = new Label();
      this.cbbLocTheo = new ComboBox();
      this.cbbNCR = new ComboBox();
      this.label3 = new Label();
      this.label13 = new Label();
      this.label5 = new Label();
      this.cbbTangGiam = new ComboBox();
      this.label7 = new Label();
      this.btnThongke = new Button();
      this.label9 = new Label();
      this.cbbHienThi = new ComboBox();
      this.label6 = new Label();
      this.dtNgayKetThuc = new DateTimePicker();
      this.cbbLoaiCau = new ComboBox();
      this.dtNgayBatDau = new DateTimePicker();
      this.numLui = new NumericUpDown();
      this.label2 = new Label();
      this.numTien = new NumericUpDown();
      this.label1 = new Label();
      this.bgGetNgayHienTai = new BackgroundWorker();
      this.bgCauBachThu = new BackgroundWorker();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.picLoading = new PictureBox();
      this.timer1 = new Timer(this.components);
      this.bg1 = new BackgroundWorker();
      this.bg2 = new BackgroundWorker();
      this.bg3 = new BackgroundWorker();
      this.bg4 = new BackgroundWorker();
      this.bg5 = new BackgroundWorker();
      this.bg6 = new BackgroundWorker();
      this.bg7 = new BackgroundWorker();
      this.bgGetDataTong = new BackgroundWorker();
      this.dtg_Ketqua = new DataGridView();
      this.backgroundWorker1 = new BackgroundWorker();
      this.label4 = new Label();
      this.label8 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.wbThongbao = new WebBrowser();
      this.bgLocDuLieu = new BackgroundWorker();
      this.label14 = new Label();
      this.label15 = new Label();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.numLui.BeginInit();
      this.numTien.BeginInit();
      ((ISupportInitialize) this.picLoading).BeginInit();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.SuspendLayout();
      this.panel2.BackColor = Color.Transparent;
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.panel2.Location = new Point(0, 0);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 45);
      this.panel2.TabIndex = 16;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.lblNCR);
      this.groupBox1.Controls.Add((Control) this.cbbLocTheo);
      this.groupBox1.Controls.Add((Control) this.cbbNCR);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label13);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.cbbTangGiam);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.btnThongke);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.cbbHienThi);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.dtNgayKetThuc);
      this.groupBox1.Controls.Add((Control) this.cbbLoaiCau);
      this.groupBox1.Controls.Add((Control) this.dtNgayBatDau);
      this.groupBox1.Controls.Add((Control) this.numLui);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.numTien);
      this.groupBox1.Location = new Point(2, -1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1097, 43);
      this.groupBox1.TabIndex = 28;
      this.groupBox1.TabStop = false;
      this.lblNCR.AutoSize = true;
      this.lblNCR.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblNCR.Location = new Point(955, 17);
      this.lblNCR.Name = "lblNCR";
      this.lblNCR.Size = new Size(49, 15);
      this.lblNCR.TabIndex = 27;
      this.lblNCR.Text = "chưa ra";
      this.cbbLocTheo.BackColor = Color.Teal;
      this.cbbLocTheo.Cursor = Cursors.Hand;
      this.cbbLocTheo.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLocTheo.FlatStyle = FlatStyle.Popup;
      this.cbbLocTheo.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbLocTheo.ForeColor = Color.White;
      this.cbbLocTheo.FormattingEnabled = true;
      this.cbbLocTheo.Items.AddRange(new object[2]
      {
        (object) "> Tỉ lệ cầu chạy",
        (object) "> Ngày chưa ra"
      });
      this.cbbLocTheo.Location = new Point(558, 13);
      this.cbbLocTheo.Name = "cbbLocTheo";
      this.cbbLocTheo.Size = new Size(141, 23);
      this.cbbLocTheo.TabIndex = 5;
      this.cbbLocTheo.SelectedIndexChanged += new EventHandler(this.CbbLocTheoSelectedIndexChanged);
      this.cbbNCR.BackColor = Color.Teal;
      this.cbbNCR.Cursor = Cursors.Hand;
      this.cbbNCR.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbNCR.Enabled = false;
      this.cbbNCR.FlatStyle = FlatStyle.Popup;
      this.cbbNCR.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbNCR.ForeColor = Color.White;
      this.cbbNCR.FormattingEnabled = true;
      this.cbbNCR.Items.AddRange(new object[15]
      {
        (object) " -TẤT CẢ-",
        (object) "  2 ngày",
        (object) "  3 ngày",
        (object) "  4 ngày",
        (object) "  5 ngày",
        (object) "  6 ngày",
        (object) "  7 ngày",
        (object) "  8 ngày",
        (object) "  9 ngày",
        (object) "  10 ngày",
        (object) "  11 ngày",
        (object) "  12 ngày",
        (object) "  13 ngày",
        (object) "  14 ngày",
        (object) "  15 ngày"
      });
      this.cbbNCR.Location = new Point(880, 13);
      this.cbbNCR.Name = "cbbNCR";
      this.cbbNCR.Size = new Size(75, 23);
      this.cbbNCR.TabIndex = 8;
      this.cbbNCR.SelectedIndexChanged += new EventHandler(this.CbbNcrSelectedIndexChanged);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point((int) byte.MaxValue, 17);
      this.label3.Name = "label3";
      this.label3.Size = new Size(30, 15);
      this.label3.TabIndex = 7;
      this.label3.Text = "Cầu";
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label13.ForeColor = Color.Black;
      this.label13.Location = new Point(4, 16);
      this.label13.Name = "label13";
      this.label13.Size = new Size(56, 16);
      this.label13.TabIndex = 24;
      this.label13.Text = "Từ ngày";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label5.ForeColor = Color.Black;
      this.label5.Location = new Point(388, 18);
      this.label5.Name = "label5";
      this.label5.Size = new Size(20, 15);
      this.label5.TabIndex = 7;
      this.label5.Text = "lùi";
      this.cbbTangGiam.BackColor = Color.Teal;
      this.cbbTangGiam.Cursor = Cursors.Hand;
      this.cbbTangGiam.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbTangGiam.FlatStyle = FlatStyle.Popup;
      this.cbbTangGiam.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbTangGiam.ForeColor = Color.White;
      this.cbbTangGiam.FormattingEnabled = true;
      this.cbbTangGiam.Items.AddRange(new object[2]
      {
        (object) "Về nhiều",
        (object) "Về ít"
      });
      this.cbbTangGiam.Location = new Point(700, 13);
      this.cbbTangGiam.Name = "cbbTangGiam";
      this.cbbTangGiam.Size = new Size(79, 23);
      this.cbbTangGiam.TabIndex = 6;
      this.cbbTangGiam.SelectedIndexChanged += new EventHandler(this.CbbTangGiamSelectedIndexChanged);
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(511, 18);
      this.label7.Name = "label7";
      this.label7.Size = new Size(50, 15);
      this.label7.TabIndex = 7;
      this.label7.Text = "lọc theo";
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(1006, 12);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(75, 24);
      this.btnThongke.TabIndex = 9;
      this.btnThongke.Text = "TÌM CẦU";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label9.ForeColor = Color.Black;
      this.label9.Location = new Point(833, 18);
      this.label9.Name = "label9";
      this.label9.Size = new Size(48, 15);
      this.label9.TabIndex = 7;
      this.label9.Text = "bản ghi";
      this.cbbHienThi.BackColor = Color.Teal;
      this.cbbHienThi.Cursor = Cursors.Hand;
      this.cbbHienThi.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbHienThi.FlatStyle = FlatStyle.Popup;
      this.cbbHienThi.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbHienThi.ForeColor = Color.White;
      this.cbbHienThi.FormattingEnabled = true;
      this.cbbHienThi.Items.AddRange(new object[6]
      {
        (object) "10",
        (object) "15",
        (object) "23",
        (object) "35",
        (object) "50",
        (object) "75"
      });
      this.cbbHienThi.Location = new Point(780, 13);
      this.cbbHienThi.Name = "cbbHienThi";
      this.cbbHienThi.Size = new Size(50, 23);
      this.cbbHienThi.TabIndex = 7;
      this.cbbHienThi.SelectedIndexChanged += new EventHandler(this.CbbHienThiSelectedIndexChanged);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(446, 18);
      this.label6.Name = "label6";
      this.label6.Size = new Size(29, 16);
      this.label6.TabIndex = 7;
      this.label6.Text = "tiến";
      this.dtNgayKetThuc.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayKetThuc.CalendarForeColor = Color.Red;
      this.dtNgayKetThuc.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
      this.dtNgayKetThuc.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayKetThuc.Format = DateTimePickerFormat.Custom;
      this.dtNgayKetThuc.Location = new Point(161, 15);
      this.dtNgayKetThuc.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayKetThuc.Name = "dtNgayKetThuc";
      this.dtNgayKetThuc.Size = new Size(91, 21);
      this.dtNgayKetThuc.TabIndex = 1;
      this.dtNgayKetThuc.ValueChanged += new EventHandler(this.dtNgayKetThuc_ValueChanged);
      this.cbbLoaiCau.BackColor = Color.Teal;
      this.cbbLoaiCau.Cursor = Cursors.Hand;
      this.cbbLoaiCau.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoaiCau.FlatStyle = FlatStyle.Popup;
      this.cbbLoaiCau.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbLoaiCau.ForeColor = Color.White;
      this.cbbLoaiCau.FormattingEnabled = true;
      this.cbbLoaiCau.Items.AddRange(new object[4]
      {
        (object) "    lô cặp lộn",
        (object) "  lô bạch thủ",
        (object) "  lô trùng đầu",
        (object) "  lô trùng đuôi"
      });
      this.cbbLoaiCau.Location = new Point(285, 13);
      this.cbbLoaiCau.Name = "cbbLoaiCau";
      this.cbbLoaiCau.Size = new Size(101, 23);
      this.cbbLoaiCau.TabIndex = 2;
      this.cbbLoaiCau.SelectedIndexChanged += new EventHandler(this.cbbLoaiCau_SelectedIndexChanged);
      this.dtNgayBatDau.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayBatDau.CalendarForeColor = Color.Red;
      this.dtNgayBatDau.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
      this.dtNgayBatDau.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayBatDau.Format = DateTimePickerFormat.Custom;
      this.dtNgayBatDau.Location = new Point(60, 15);
      this.dtNgayBatDau.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayBatDau.Name = "dtNgayBatDau";
      this.dtNgayBatDau.Size = new Size(91, 21);
      this.dtNgayBatDau.TabIndex = 0;
      this.dtNgayBatDau.ValueChanged += new EventHandler(this.dtNgayBatDau_ValueChanged);
      this.numLui.BackColor = Color.White;
      this.numLui.BorderStyle = BorderStyle.FixedSingle;
      this.numLui.Cursor = Cursors.Hand;
      this.numLui.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numLui.ForeColor = Color.Black;
      this.numLui.Location = new Point(409, 15);
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
      this.numLui.Size = new Size(35, 21);
      this.numLui.TabIndex = 3;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkSlateGray;
      this.label2.Location = new Point(150, 18);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 16);
      this.label2.TabIndex = 23;
      this.label2.Text = "-";
      this.numTien.BackColor = Color.White;
      this.numTien.BorderStyle = BorderStyle.FixedSingle;
      this.numTien.Cursor = Cursors.Hand;
      this.numTien.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTien.ForeColor = Color.Black;
      this.numTien.Location = new Point(475, 15);
      this.numTien.Maximum = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numTien.Name = "numTien";
      this.numTien.Size = new Size(35, 21);
      this.numTien.TabIndex = 4;
      this.numTien.Value = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numTien.ValueChanged += new EventHandler(this.numTien_ValueChanged);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkSlateGray;
      this.label1.Location = new Point(208, 51);
      this.label1.Name = "label1";
      this.label1.Size = new Size(22, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "xịt";
      this.bgGetNgayHienTai.DoWork += new DoWorkEventHandler(this.bgGetNgayHienTai_DoWork);
      this.bgGetNgayHienTai.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetNgayHienTai_RunWorkerCompleted);
      this.bgCauBachThu.DoWork += new DoWorkEventHandler(this.bgCauBachThu_DoWork);
      this.bgCauBachThu.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgCauBachThu_RunWorkerCompleted);
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(623, 305);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 17;
      this.picLoading.TabStop = false;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.bg1.DoWork += new DoWorkEventHandler(this.bg1_DoWork);
      this.bg1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
      this.bg2.DoWork += new DoWorkEventHandler(this.bg2_DoWork);
      this.bg2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg2_RunWorkerCompleted);
      this.bg3.DoWork += new DoWorkEventHandler(this.bg3_DoWork);
      this.bg3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg3_RunWorkerCompleted);
      this.bg4.DoWork += new DoWorkEventHandler(this.bg4_DoWork);
      this.bg4.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg4_RunWorkerCompleted);
      this.bg5.DoWork += new DoWorkEventHandler(this.bg5_DoWork);
      this.bg5.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
      this.bg6.DoWork += new DoWorkEventHandler(this.bg6_DoWork);
      this.bg6.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
      this.bg7.DoWork += new DoWorkEventHandler(this.bg7_DoWork);
      this.bg7.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
      this.bgGetDataTong.DoWork += new DoWorkEventHandler(this.bgGetDataTong_DoWork);
      this.bgGetDataTong.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetDataTong_RunWorkerCompleted);
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_Ketqua.BackgroundColor = Color.White;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      this.dtg_Ketqua.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle1.ForeColor = Color.WhiteSmoke;
      gridViewCellStyle1.NullValue = (object) "#####";
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 26;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Cursor = Cursors.Hand;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = Color.White;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle2.ForeColor = SystemColors.ControlDarkDark;
      gridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
      gridViewCellStyle2.SelectionForeColor = Color.White;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.GridColor = Color.Gainsboro;
      this.dtg_Ketqua.Location = new Point(0, 78);
      this.dtg_Ketqua.Margin = new Padding(0);
      this.dtg_Ketqua.MultiSelect = false;
      this.dtg_Ketqua.Name = "dtg_Ketqua";
      this.dtg_Ketqua.ReadOnly = true;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dtg_Ketqua.RowHeadersVisible = false;
      this.dtg_Ketqua.RowHeadersWidth = 27;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.dtg_Ketqua.RowTemplate.Height = 27;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(1100, 512);
      this.dtg_Ketqua.TabIndex = 0;
      this.dtg_Ketqua.CellClick += new DataGridViewCellEventHandler(this.dtg_Ketqua_CellClick);
      this.dtg_Ketqua.CellDoubleClick += new DataGridViewCellEventHandler(this.DtgKetquaCellDoubleClick);
      this.dtg_Ketqua.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dtg_Ketqua_ColumnHeaderMouseClick);
      this.dtg_Ketqua.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dtg_Ketqua_DataBindingComplete);
      this.dtg_Ketqua.MouseDown += new MouseEventHandler(this.dtg_Ketqua_MouseDown);
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.label4.BackColor = Color.FromArgb(201, 27, 38);
      this.label4.BorderStyle = BorderStyle.FixedSingle;
      this.label4.Location = new Point(177, 50);
      this.label4.Name = "label4";
      this.label4.Size = new Size(30, 17);
      this.label4.TabIndex = 18;
      this.label8.BackColor = Color.White;
      this.label8.BorderStyle = BorderStyle.FixedSingle;
      this.label8.Location = new Point(252, 50);
      this.label8.Name = "label8";
      this.label8.Size = new Size(30, 17);
      this.label8.TabIndex = 19;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.DarkSlateGray;
      this.label10.Location = new Point(282, 51);
      this.label10.Name = "label10";
      this.label10.Size = new Size(20, 16);
      this.label10.TabIndex = 7;
      this.label10.Text = "về";
      this.label11.BackColor = Color.DimGray;
      this.label11.BorderStyle = BorderStyle.FixedSingle;
      this.label11.Location = new Point(8, 50);
      this.label11.Name = "label11";
      this.label11.Size = new Size(30, 17);
      this.label11.TabIndex = 21;
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.DarkSlateGray;
      this.label12.Location = new Point(37, 51);
      this.label12.Name = "label12";
      this.label12.Size = new Size(54, 16);
      this.label12.TabIndex = 20;
      this.label12.Text = "chưa về";
      this.wbThongbao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.wbThongbao.Location = new Point(348, 43);
      this.wbThongbao.MinimumSize = new Size(20, 20);
      this.wbThongbao.Name = "wbThongbao";
      this.wbThongbao.ScrollBarsEnabled = false;
      this.wbThongbao.Size = new Size(731, 33);
      this.wbThongbao.TabIndex = 22;
      this.bgLocDuLieu.DoWork += new DoWorkEventHandler(this.BgLocDuLieuDoWork);
      this.bgLocDuLieu.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgLocDuLieuRunWorkerCompleted);
      this.label14.BackColor = Color.FromArgb((int) byte.MaxValue, 162, 0);
      this.label14.BorderStyle = BorderStyle.FixedSingle;
      this.label14.Location = new Point(90, 50);
      this.label14.Name = "label14";
      this.label14.Size = new Size(30, 17);
      this.label14.TabIndex = 24;
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.DarkSlateGray;
      this.label15.Location = new Point(119, 51);
      this.label15.Name = "label15";
      this.label15.Size = new Size(53, 16);
      this.label15.TabIndex = 23;
      this.label15.Text = "vượt 1n";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.wbThongbao);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.dtg_Ketqua);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabGepCau);
      this.Size = new Size(1100, 590);
      this.Load += new EventHandler(this.tabGepCau_Load);
      this.panel2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numLui.EndInit();
      this.numTien.EndInit();
      ((ISupportInitialize) this.picLoading).EndInit();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class ListCauBachThu
    {
      public string Vt1 { get; set; }

      public string Vt2 { get; set; }
    }

    private class ListCauCap
    {
      public string Vt1 { get; set; }

      public string Vt2 { get; set; }
    }
  }
}
