// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabBoxloto
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

namespace Thống_kê_xổ_số.FormUI
{
  public class TabBoxloto : UserControl
  {
    private string _htmlKetqua = "";
    private int _khungdanhCapBachThu = 3;
    private IContainer components = (IContainer) null;
    private int _biendotrungdauCu;
    private int _biendotrungduoiCu;
    private DataTable _dt;
    private Tbketqua _infoKetqua;
    private DataTable _dtLoto;
    private readonly Tbloto _infoLoto;
    private string _loaiLoto;
    public List<TabBoxloto.LOTO> ListLotoCap;
    public List<TabBoxloto.LOTO> ListLotoBachThu;
    public List<TabBoxloto.LOTO> ListLotoTrungDau;
    public List<TabBoxloto.LOTO> ListLotoTrungDuoi;
    public List<TabBoxloto.LOTO> ListLotoChuan;
    private DataTable _dataTable1;
    private DataTable _dtDauloto;
    private DataTable _dtDitloto;
    private DataRow _row;
    private const int SoNgayTinhGan = 36;
    private const int SoNgayTinhDauDit = 21;
    private const int SobanghiHienthi = 15;
    private BunifuElipse bunifuElipse1;
    private WebBrowser wbHienthi;
    private Button btnXem;
    private DateTimePicker dtNgayThang;
    private BackgroundWorker bgXuly;
    private Panel panel1;
    private ComboBox cbbLoaiLoto;
    private Timer timer1;
    private PictureBox picLoading;

    public TabBoxloto()
    {
      this.InitializeComponent();
      this.dtNgayThang.Value = FMain.NgayKetQuaMoiNhat;
      this._infoLoto = new Tbloto();
      this._dtLoto = new DataTable();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.TaoListLotoCap();
      this.TaoListLotoBachThu();
      this._biendotrungdauCu = FMain.ObjConfigBacNho.BiendoTrungDau;
      this.TaoListLotoTrungDau(this._biendotrungdauCu);
      this._biendotrungduoiCu = FMain.ObjConfigBacNho.BiendoTrungDuoi;
      this.TaoListLotoTrungDuoi(this._biendotrungduoiCu);
      this.cbbLoaiLoto.SelectedIndex = 0;
      if (this.bgXuly.IsBusy)
        return;
      this.btnXem.PerformClick();
      this.timer1.Start();
    }

    public static void HienThiKetQua(WebBrowser wb, string strHtml)
    {
      string html = "<html><head>\r\n            <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n            <meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\" />\r\n            <style type=\"text/css\">\r\n            .style1{width: 18%;height: 30px;border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;border-bottom-width: 1px;font-size:16px;text-align:center;}\r\n            .style2 {width: 500px;text-align: center;height: 31px;font-size: 19px;border-bottom-style: dotted;border-bottom-width:1px;border-color: orangered;}\r\n            .style3{border-color: red;width: 45px; height: 21px; border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;font-size:15px;}\r\n            .style4 {border-color: red;border-bottom-style: dotted; border-bottom-width: 1px;font-size:15px;}\r\n            .main{width:97%;float:right;margin-right:1%;height: 268px; margin-left: auto; margin-top: 0;padding-bottom: 50px;}\r\n            .table_KQ {border: 1px dotted #FF6600; width: 56%; float: left;}\r\n            .title_XS { text-align:center;margin:0px auto;width:60%;float:left;font-size:20px;color:red;}\r\n            .header {color: White;}\r\n            .lotoHeader {color: red; font-weight: bold; }\r\n.borderVien\r\n{\r\nborder-style:dotted;\r\n\tborder-width:1px;\r\nborder-color:DarkGray;\r\n\r\n}\r\n.botTable{\r\ncolor:black;\r\nfont-weight: normal;\r\n    font-style: italic;\r\n}\r\n             </style>\r\n            \r\n            </head>\r\n            <body oncontextmenu='return false;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    public void Xulyketqua()
    {
      this._htmlKetqua = "";
      this._dt = Tbketqua.GetTbketquaNgayThangThu(this.dtNgayThang.Value, this.dtNgayThang.Value, 0);
      if (this._dt.Rows.Count <= 0)
        return;
      this._infoKetqua = new Tbketqua();
      this._infoKetqua.Clngaythang = DateTime.Parse(this._dt.Rows[0]["clngaythang"].ToString());
      this._infoKetqua.G0 = this._dt.Rows[0]["G0"].ToString();
      this._infoKetqua.G1 = this._dt.Rows[0]["G1"].ToString();
      this._infoKetqua.G21 = this._dt.Rows[0]["G21"].ToString();
      this._infoKetqua.G22 = this._dt.Rows[0]["G22"].ToString();
      this._infoKetqua.G31 = this._dt.Rows[0]["G31"].ToString();
      this._infoKetqua.G32 = this._dt.Rows[0]["G32"].ToString();
      this._infoKetqua.G33 = this._dt.Rows[0]["G33"].ToString();
      this._infoKetqua.G34 = this._dt.Rows[0]["G34"].ToString();
      this._infoKetqua.G35 = this._dt.Rows[0]["G35"].ToString();
      this._infoKetqua.G36 = this._dt.Rows[0]["G36"].ToString();
      this._infoKetqua.G41 = this._dt.Rows[0]["G41"].ToString();
      this._infoKetqua.G42 = this._dt.Rows[0]["G42"].ToString();
      this._infoKetqua.G43 = this._dt.Rows[0]["G43"].ToString();
      this._infoKetqua.G44 = this._dt.Rows[0]["G44"].ToString();
      this._infoKetqua.G51 = this._dt.Rows[0]["G51"].ToString();
      this._infoKetqua.G52 = this._dt.Rows[0]["G52"].ToString();
      this._infoKetqua.G53 = this._dt.Rows[0]["G53"].ToString();
      this._infoKetqua.G54 = this._dt.Rows[0]["G54"].ToString();
      this._infoKetqua.G55 = this._dt.Rows[0]["G55"].ToString();
      this._infoKetqua.G56 = this._dt.Rows[0]["G56"].ToString();
      this._infoKetqua.G61 = this._dt.Rows[0]["G61"].ToString();
      this._infoKetqua.G62 = this._dt.Rows[0]["G62"].ToString();
      this._infoKetqua.G63 = this._dt.Rows[0]["G63"].ToString();
      this._infoKetqua.G71 = this._dt.Rows[0]["G71"].ToString();
      this._infoKetqua.G72 = this._dt.Rows[0]["G72"].ToString();
      this._infoKetqua.G73 = this._dt.Rows[0]["G73"].ToString();
      this._infoKetqua.G74 = this._dt.Rows[0]["G74"].ToString();
      this._htmlKetqua = this._htmlKetqua + "<div class=\"main\"><span class=\"title_XS\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thông tin kết quả xổ số " + Tbketqua.GetThuTrongtuan(Convert.ToDateTime(this._dt.Rows[0]["clngaythang"].ToString())) + "</span>";
      this._htmlKetqua += "<table class=\"table_KQ\"><tr><td class=\"style1\" style=\"color:Red;font-weight:bold;font-size:14px;\"  >&nbsp; Giải đặc biệt</td>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style2\" style=\"color:Red;font-weight:bold;font-size:24px;\" >&nbsp; " + this._infoKetqua.G0 + "</td></tr><tr>";
      this._htmlKetqua += "<td class=\"style1\" >&nbsp; Giải nhất</td>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style2\" >&nbsp; " + this._infoKetqua.G1 + "</td>";
      this._htmlKetqua += "</tr><tr><td class=\"style1\" >&nbsp; Giải nhì</td>";
      this._htmlKetqua = this._htmlKetqua + "<td  class=\"style2\">&nbsp; " + this._infoKetqua.G21 + " - " + this._infoKetqua.G22 + "</td></tr><tr>";
      this._htmlKetqua += "<td class=\"style1\" >&nbsp; Giải ba</td>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style2\" >&nbsp; " + this._infoKetqua.G31 + " - " + this._infoKetqua.G32 + " - " + this._infoKetqua.G33 + " - " + this._infoKetqua.G34 + " - " + this._infoKetqua.G35 + " - " + this._infoKetqua.G36 + "</td></tr><tr>";
      this._htmlKetqua += "<td class=\"style1\" >&nbsp; Giải tư</td>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style2\">&nbsp; " + this._infoKetqua.G41 + " - " + this._infoKetqua.G42 + " - " + this._infoKetqua.G43 + " - " + this._infoKetqua.G44 + "</td></tr><tr>";
      this._htmlKetqua += "<td class=\"style1\" >&nbsp; Giải năm</td>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style2\"  >&nbsp; " + this._infoKetqua.G51 + " - " + this._infoKetqua.G52 + " - " + this._infoKetqua.G53 + " - " + this._infoKetqua.G54 + " - " + this._infoKetqua.G55 + " - " + this._infoKetqua.G56 + "</td></tr><tr>";
      this._htmlKetqua += "<td class=\"style1\">&nbsp; Giải sáu</td>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style2\">&nbsp; " + this._infoKetqua.G61 + " - " + this._infoKetqua.G62 + " - " + this._infoKetqua.G63 + "</td></tr><tr>";
      this._htmlKetqua += "<td class=\"style1\" style=\"border-bottom-width: 0px;\">&nbsp; Giải bảy</td>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style2\" style=\"border-bottom-width: 0px;\">&nbsp; " + this._infoKetqua.G71 + " - " + this._infoKetqua.G72 + " - " + this._infoKetqua.G73 + " - " + this._infoKetqua.G74 + "</td></tr></table>";
      this._htmlKetqua += "<table style=\"border: 1px dotted #FF9933; width: 20%; float: left; margin-bottom: 0px; margin-left: 15px;\" bgcolor=\"Transparent\"><tr><td class=\"style3\" >ĐẦU</td><td  class=\"style4\">LOTO</td>";
      this._htmlKetqua = this._htmlKetqua + "</tr><tr><td class=\"style3\" >0</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "0", "dau") + "</td>";
      this._htmlKetqua = this._htmlKetqua + "</tr><tr><td class=\"style3\" >1</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "1", "dau") + "</td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >2</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "2", "dau") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >3</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "3", "dau") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >4</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "4", "dau") + "</td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >5</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "5", "dau") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\">6</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "6", "dau") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >7</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "7", "dau") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >8</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "8", "dau") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" style=\"border-bottom-width: 0px;\">9</td><td class=\"style4\"style=\"border-bottom-width: 0px;\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "9", "dau") + " </td></tr></table>";
      this._htmlKetqua += "<table style=\"border: 1px dotted #FF9933; width: 20%; float: left; margin-bottom: 0px; margin-left: 15px;\" bgcolor=\"Transparent\"><tr><td class=\"style3\" >ĐÍT</td><td  class=\"style4\">LOTO</td>";
      this._htmlKetqua = this._htmlKetqua + "</tr><tr><td class=\"style3\" >0</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "0", "dit") + "</td>";
      this._htmlKetqua = this._htmlKetqua + "</tr><tr><td class=\"style3\" >1</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "1", "dit") + "</td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >2</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "2", "dit") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >3</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "3", "dit") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >4</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "4", "dit") + "</td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >5</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "5", "dit") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\">6</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "6", "dit") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >7</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "7", "dit") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" >8</td><td class=\"style4\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "8", "dit") + " </td></tr><tr>";
      this._htmlKetqua = this._htmlKetqua + "<td class=\"style3\" style=\"border-bottom-width: 0px;\">9</td><td class=\"style4\"style=\"border-bottom-width: 0px;\">&nbsp;" + Tbketqua.GetLotoTheoDau(this._infoKetqua, "9", "dit") + " </td></tr></table></div></br></br></br></br></br>";
    }

    private void DTNgayThangValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayThang.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dtNgayThang.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void BtnXemClick(object sender, EventArgs e)
    {
      if (this.cbbLoaiLoto.SelectedIndex == 0)
      {
        this.ListLotoChuan = new List<TabBoxloto.LOTO>((IEnumerable<TabBoxloto.LOTO>) this.ListLotoCap);
        this._loaiLoto = "Top (" + (object) 15 + ") lô Cặp ";
        this._khungdanhCapBachThu = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      }
      if (this.cbbLoaiLoto.SelectedIndex == 1)
      {
        this.ListLotoChuan = new List<TabBoxloto.LOTO>((IEnumerable<TabBoxloto.LOTO>) this.ListLotoBachThu);
        this._loaiLoto = "Top (" + (object) 15 + ") lô Bạch Thủ ";
        this._khungdanhCapBachThu = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
      }
      if (this.cbbLoaiLoto.SelectedIndex == 2)
      {
        this.ListLotoChuan = new List<TabBoxloto.LOTO>((IEnumerable<TabBoxloto.LOTO>) this.ListLotoTrungDau);
        this._loaiLoto = "Top (" + (object) 15 + ") lô Cặp Trùng Đầu";
        this._khungdanhCapBachThu = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      }
      if (this.cbbLoaiLoto.SelectedIndex == 3)
      {
        this.ListLotoChuan = new List<TabBoxloto.LOTO>((IEnumerable<TabBoxloto.LOTO>) this.ListLotoTrungDuoi);
        this._loaiLoto = "Top (" + (object) 15 + ") lô Cặp Trùng Đuôi";
        this._khungdanhCapBachThu = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      }
      if (this.bgXuly.IsBusy)
        return;
      this.bgXuly.RunWorkerAsync();
    }

    private void BgXulyDoWork(object sender, DoWorkEventArgs e)
    {
      this._htmlKetqua = "";
      this.KhoiTaoDataTable1();
      if (this._biendotrungdauCu != FMain.ObjConfigBacNho.BiendoTrungDau)
      {
        this.TaoListLotoTrungDau(this._biendotrungdauCu);
        this._biendotrungdauCu = FMain.ObjConfigBacNho.BiendoTrungDau;
      }
      if (this._biendotrungduoiCu != FMain.ObjConfigBacNho.BiendoTrungDuoi)
      {
        this.TaoListLotoTrungDuoi(this._biendotrungduoiCu);
        this._biendotrungduoiCu = FMain.ObjConfigBacNho.BiendoTrungDuoi;
      }
      this.XulyThongke();
    }

    public void TaoListLotoCap()
    {
      this.ListLotoCap = new List<TabBoxloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBoxloto.LOTO loto = new TabBoxloto.LOTO()
        {
          LOTO1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.LOTO1 = "0" + (object) index;
        loto.LOTO2 = ClMain.check_Loto_Cap(loto.LOTO1);
        if (Convert.ToInt32(loto.LOTO1) > Convert.ToInt32(loto.LOTO2))
        {
          loto.LOTO1 = loto.LOTO2;
          loto.LOTO2 = ClMain.check_Loto_Cap(loto.LOTO1);
        }
        if (this.ListLotoCap.Count > 0)
        {
          if (!this.ListLotoCap.Any<TabBoxloto.LOTO>((Func<TabBoxloto.LOTO, bool>) (lo => loto.LOTO1 == lo.LOTO1)))
            this.ListLotoCap.Add(loto);
        }
        else
          this.ListLotoCap.Add(loto);
      }
    }

    private void TaoListLotoBachThu()
    {
      this.ListLotoBachThu = new List<TabBoxloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBoxloto.LOTO loto = new TabBoxloto.LOTO()
        {
          LOTO1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.LOTO1 = "0" + (object) index;
        loto.LOTO2 = "aa";
        this.ListLotoBachThu.Add(loto);
      }
    }

    private void TaoListLotoTrungDau(int biendo)
    {
      this.ListLotoTrungDau = new List<TabBoxloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBoxloto.LOTO loto = new TabBoxloto.LOTO()
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
      this.ListLotoTrungDuoi = new List<TabBoxloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBoxloto.LOTO loto = new TabBoxloto.LOTO()
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

    private void XulyThongke()
    {
      this._dtLoto = this._infoLoto.TblotoGetByDateSoBanGhiTrovetruoc(this.dtNgayThang.Value, 365);
      if (this._dtLoto.Rows.Count <= 0)
        return;
      this.Process(this.ListLotoChuan);
    }

    public void KhoiTaoDataTable1()
    {
      this._dataTable1 = new DataTable();
      this._dataTable1.Columns.Add("loto", typeof (string));
      this._dataTable1.Columns.Add("solanve", typeof (int));
      this._dataTable1.Columns.Add("ngayChuara", typeof (int));
      this._dataTable1.Columns.Add("chuKi", typeof (double));
      this._dataTable1.Columns.Add("maxGan", typeof (int));
      this._dataTable1.Columns.Add("maxSoBanGhi", typeof (int));
      this._dataTable1.Columns.Add("diemtanxuat", typeof (double));
      this._dataTable1.Columns.Add("diemGan", typeof (double));
      this._dataTable1.Columns.Add("veNgay", typeof (double));
    }

    public void KhoiTaoDataTableDauLoto(DataTable dtLoto)
    {
      this._dtDauloto = new DataTable();
      this._dtDauloto.Columns.Add("DauLoto", typeof (string));
      for (int index = 0; index < dtLoto.Rows.Count && index < 21; ++index)
        this._dtDauloto.Columns.Add(Convert.ToDateTime(dtLoto.Rows[index]["clngaythang"]).ToString("dd/MM"), typeof (string));
      this._dtDauloto.Columns.Add("tongSolan", typeof (int));
      for (int index1 = 0; index1 < 10; ++index1)
      {
        DataRow row = this._dtDauloto.NewRow();
        row[0] = (object) index1;
        for (int index2 = 1; index2 <= 22; ++index2)
          row[index2] = (object) "0";
        this._dtDauloto.Rows.Add(row);
      }
    }

    public void KhoiTaoDataTableDitLoto(DataTable dtLoto)
    {
      this._dtDitloto = new DataTable();
      this._dtDitloto.Columns.Add("DitLoto", typeof (string));
      for (int index = 0; index < dtLoto.Rows.Count && index < 21; ++index)
        this._dtDitloto.Columns.Add(Convert.ToDateTime(dtLoto.Rows[index]["clngaythang"]).ToString("dd/MM"), typeof (string));
      this._dtDitloto.Columns.Add("tongSolan", typeof (int));
      for (int index1 = 0; index1 < 10; ++index1)
      {
        DataRow row = this._dtDitloto.NewRow();
        row[0] = (object) index1;
        for (int index2 = 1; index2 <= 22; ++index2)
          row[index2] = (object) "0";
        this._dtDitloto.Rows.Add(row);
      }
    }

    private void Process(List<TabBoxloto.LOTO> listLoto)
    {
      this.KhoiTaoDataTableDauLoto(this._dtLoto);
      this.KhoiTaoDataTableDitLoto(this._dtLoto);
      for (int index1 = 0; index1 < listLoto.Count; ++index1)
      {
        string lotO1 = listLoto[index1].LOTO1;
        string lotO2 = listLoto[index1].LOTO2;
        TabBoxloto.DataRowTable dataRowTable = new TabBoxloto.DataRowTable()
        {
          Solanve = 0,
          NgayChuara = 0,
          ChuKi = Decimal.Zero,
          MaxSobanghi = 0,
          MaxGan = 0,
          DiemGan = Decimal.Zero,
          Diemtanxuat = Decimal.Zero,
          VeNgay = 0
        };
        dataRowTable.Loto = !(lotO2 != "aa") ? lotO1 : lotO1 + "-" + lotO2;
        int num1 = 0;
        int num2 = 0;
        bool flag1 = false;
        for (int index2 = 0; index2 < this._dtLoto.Rows.Count; ++index2)
        {
          bool flag2 = false;
          for (int index3 = 2; index3 < this._dtLoto.Columns.Count; ++index3)
          {
            string str = this._dtLoto.Rows[index2][index3].ToString();
            if (lotO1 == str || lotO2 == str)
            {
              flag2 = true;
              break;
            }
          }
          if (flag2)
          {
            if (index2 < 36)
            {
              ++dataRowTable.Solanve;
              num1 = 0;
              flag1 = true;
            }
            num2 = 0;
          }
          else
          {
            if (index2 < 36)
            {
              ++num1;
              if (num1 > dataRowTable.MaxSobanghi)
                dataRowTable.MaxSobanghi = num1;
              if (!flag1)
                ++dataRowTable.NgayChuara;
            }
            ++num2;
            if (num2 > dataRowTable.MaxGan)
              dataRowTable.MaxGan = num2;
          }
        }
        int num3 = dataRowTable.Solanve;
        if (num3 == 1)
          num3 = 2;
        if ((uint) num3 > 0U)
          dataRowTable.ChuKi = Math.Round(Convert.ToDecimal(36) / (Decimal) num3, 1);
        dataRowTable.DiemGan = Convert.ToDecimal(dataRowTable.NgayChuara) / (Decimal) dataRowTable.MaxGan * new Decimal(10);
        dataRowTable.DiemGan = Math.Round(dataRowTable.DiemGan, 1);
        dataRowTable.Diemtanxuat = ((Decimal) dataRowTable.NgayChuara + dataRowTable.ChuKi) / new Decimal(2);
        dataRowTable.Diemtanxuat = dataRowTable.Diemtanxuat / (Decimal) dataRowTable.MaxSobanghi * new Decimal(10);
        dataRowTable.Diemtanxuat = Math.Round(dataRowTable.Diemtanxuat, 1);
        this._row = this._dataTable1.NewRow();
        this._row["loto"] = (object) dataRowTable.Loto;
        this._row["solanve"] = (object) dataRowTable.Solanve;
        this._row["ngayChuara"] = (object) dataRowTable.NgayChuara;
        this._row["chuKi"] = (object) dataRowTable.ChuKi;
        this._row["maxGan"] = (object) dataRowTable.MaxGan;
        this._row["maxSoBanGhi"] = (object) dataRowTable.MaxSobanghi;
        this._row["diemtanxuat"] = (object) dataRowTable.Diemtanxuat;
        this._row["diemGan"] = (object) dataRowTable.DiemGan;
        this._dataTable1.Rows.Add(this._row);
      }
      for (int index1 = 0; index1 < this._dtLoto.Rows.Count; ++index1)
      {
        string index2 = Convert.ToDateTime(this._dtLoto.Rows[index1]["clngaythang"]).ToString("dd/MM");
        for (int index3 = 2; index3 < this._dtLoto.Columns.Count; ++index3)
        {
          string str = this._dtLoto.Rows[index1][index3].ToString();
          if (index1 < 21)
          {
            for (int index4 = 0; index4 < this._dtDauloto.Rows.Count; ++index4)
            {
              if (str.Substring(0, 1) == this._dtDauloto.Rows[index4][0].ToString())
              {
                this._dtDauloto.Rows[index4][index2] = (object) (Convert.ToInt32(this._dtDauloto.Rows[index4][index2]) + 1);
                this._dtDauloto.Rows[index4]["tongSolan"] = (object) (Convert.ToInt32(this._dtDauloto.Rows[index4]["tongSolan"]) + 1);
              }
              if (str.Substring(1, 1) == this._dtDitloto.Rows[index4][0].ToString())
              {
                this._dtDitloto.Rows[index4][index2] = (object) (Convert.ToInt32(this._dtDitloto.Rows[index4][index2]) + 1);
                this._dtDitloto.Rows[index4]["tongSolan"] = (object) (Convert.ToInt32(this._dtDitloto.Rows[index4]["tongSolan"]) + 1);
              }
            }
          }
          else
            break;
        }
      }
      this.TimLotoTanXuatDep();
      this.TimLotoDiemGanDep();
      this.TimLotoRaNhieu();
      this.TimLotoKhan();
      this.TinhTanxuatDauLoTo();
      this.TinhTanxuatDitLoTo();
    }

    private void TimLotoDiemGanDep()
    {
      DataView defaultView = this._dataTable1.DefaultView;
      defaultView.Sort = "diemGan DESC";
      this._dataTable1 = defaultView.ToTable();
      this._htmlKetqua += "<div style='width:95.5%;float:right;align:center;margin-right:36px;'>";
      this._htmlKetqua = this._htmlKetqua + "<br /><table width='100%'><tr><th bgcolor='Teal' colspan='" + (object) 16 + "' scope='col' class='borderVien'><span class='header'>" + this._loaiLoto + " có điểm gan đẹp trong (" + (object) this._dtLoto.Rows.Count + ") ngày vừa qua </span></th></tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Bộ số</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center' class='lotoHeader'>(" + this._dataTable1.Rows[index]["loto"] + ")</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Điểm gan </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["diemGan"] + " điểm </div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr><td class='borderVien'>Max gan(<b style='color:red;'> trong " + (object) this._dtLoto.Rows.Count + " ngày</b>)</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["maxGan"] + " ngày</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Số ngày chưa ra </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + ((double) Convert.ToInt32(this._dataTable1.Rows[index]["ngayChuara"].ToString()) >= Convert.ToDouble(this._dataTable1.Rows[index]["maxGan"].ToString()) || (double) (Convert.ToInt32(this._dataTable1.Rows[index]["ngayChuara"].ToString()) + this._khungdanhCapBachThu - 1) < Convert.ToDouble(this._dataTable1.Rows[index]["maxGan"].ToString()) ? "<b>(" + this._dataTable1.Rows[index]["ngayChuara"] + ")</b> ngày" : "<b style='color:red;'>(" + this._dataTable1.Rows[index]["ngayChuara"] + ") ngày</b>") + "</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr> <th colspan='" + (object) 16 + "' scope='col' class='borderVien'><div align='left' class='botTable'>Gợi ý : điểm gan lớn sẽ cho biết bộ số đó đang chạm dần đến maxgan trong (" + (object) this._dtLoto.Rows.Count + ") ngày, bộ số có <b style='color:red;'>ngày chưa ra màu đỏ</b> là bộ số xắp hoặc đã chạm max trong (<b style='color:red;'>" + (object) this._dtLoto.Rows.Count + "</b>) ngày, với khung (<b style='color:red;'>" + (object) this._khungdanhCapBachThu + "</b>) ngày của bạn </div></th></tr></table></div>";
    }

    private void TinhTanxuatDauLoTo()
    {
      int num = this._dtDauloto.Columns.Count - 1;
      this._htmlKetqua += "<div style='width:95.5%;float:right;align:center;margin-right:36px;margin-top:-5px;'>";
      this._htmlKetqua = this._htmlKetqua + "<table width='100%'><tr><th bgcolor='Teal' colspan='" + (object) (num + 1) + "' scope='col' class='borderVien'><span class='header'>Tần Xuất Đầu Lô Trong (" + (object) 21 + ") vừa qua</span></th></tr>";
      this._htmlKetqua += "<tr>";
      this._htmlKetqua += "<td class='borderVien' align='center'>Đầu/Ngày</td>";
      for (int index = 1; index < this._dtDauloto.Columns.Count - 1; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center'>" + (object) this._dtDauloto.Columns[index] + "</td>";
      this._htmlKetqua += "<td class='borderVien' align='center'>Số Lần</td>";
      this._htmlKetqua += "</tr>";
      for (int index1 = 0; index1 < this._dtDauloto.Rows.Count; ++index1)
      {
        this._htmlKetqua += "<tr>";
        for (int index2 = 0; index2 < this._dtDauloto.Columns.Count; ++index2)
        {
          if (index2 == 0)
            this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center'><b>( " + this._dtDauloto.Rows[index1][index2] + " )</b></td>";
          else if (this._dtDauloto.Rows[index1][index2].ToString() != "0")
            this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center'>" + this._dtDauloto.Rows[index1][index2] + "</td>";
          else
            this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center' bgcolor='#999999' style='color:white;'>" + this._dtDauloto.Rows[index1][index2] + "</td>";
        }
        this._htmlKetqua += "</tr>";
      }
      this._htmlKetqua = this._htmlKetqua + "<tr> <th colspan='" + (object) (num + 1) + "' scope='col' class='borderVien'><div align='left' class='botTable'>Gợi ý : những đầu ra nhiều trong mấy hôm gần đây sẽ khó có thể ra nhiều trong mấy hôm tiếp theo, trọn bộ số ở những đầu có thể ra nhiều sẽ giúp tăng tỷ lệ chiến thắng của bạn </div></th></tr></table></div>";
    }

    private void TinhTanxuatDitLoTo()
    {
      int num = this._dtDitloto.Columns.Count - 1;
      this._htmlKetqua += "<div style='width:95.5%;float:right;align:center;margin-right:36px;'>";
      this._htmlKetqua = this._htmlKetqua + "<br /><table width='100%'><tr><th bgcolor='Teal' colspan='" + (object) (num + 1) + "' scope='col' class='borderVien'><span class='header'>Tần Xuất Đuôi Lô Trong (" + (object) 21 + ") vừa qua</span></th></tr>";
      this._htmlKetqua += "<tr>";
      this._htmlKetqua += "<td class='borderVien' align='center'>Đầu/Ngày</td>";
      for (int index = 1; index < this._dtDitloto.Columns.Count - 1; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center'>" + (object) this._dtDitloto.Columns[index] + "</td>";
      this._htmlKetqua += "<td class='borderVien' align='center'>Số Lần</td>";
      this._htmlKetqua += "</tr>";
      for (int index1 = 0; index1 < this._dtDitloto.Rows.Count; ++index1)
      {
        this._htmlKetqua += "<tr>";
        for (int index2 = 0; index2 < this._dtDitloto.Columns.Count; ++index2)
        {
          if (index2 == 0)
            this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center'>(<b> " + this._dtDitloto.Rows[index1][index2] + " </b>)</td>";
          else if (this._dtDitloto.Rows[index1][index2].ToString() != "0")
            this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center'>" + this._dtDitloto.Rows[index1][index2] + "</td>";
          else
            this._htmlKetqua = this._htmlKetqua + "<td class='borderVien' align='center' bgcolor='#999999' style='color:white;'>" + this._dtDitloto.Rows[index1][index2] + "</td>";
        }
        this._htmlKetqua += "</tr>";
      }
      this._htmlKetqua = this._htmlKetqua + "<tr> <th colspan='" + (object) (num + 1) + "' scope='col' class='borderVien'><div align='left' class='botTable'>Gợi ý : những đuôi ra nhiều trong mấy hôm gần đây sẽ khó có thể ra nhiều trong mấy hôm tiếp theo, trọn bộ số ở những đuôi có thể ra nhiều sẽ giúp tăng tỷ lệ chiến thắng của bạn </div></th></tr></table></div>";
    }

    private void TimLotoRaNhieu()
    {
      DataView defaultView = this._dataTable1.DefaultView;
      defaultView.Sort = "solanve DESC";
      this._dataTable1 = defaultView.ToTable();
      this._htmlKetqua += "<div style='width:95.5%;float:right;align:center;margin-right:36px;'>";
      this._htmlKetqua = this._htmlKetqua + "<br /><table width='100%'><tr><th bgcolor='Teal' colspan='" + (object) 16 + "' scope='col' class='borderVien'><span class='header'>" + this._loaiLoto + " ra nhiều trong (" + (object) 36 + ") ngày vừa qua </span></th></tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Bộ số</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center' class='lotoHeader'>(" + this._dataTable1.Rows[index]["loto"] + ")</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Tổng số lần về </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["solanve"] + " lần </div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Chu kỳ trung bình </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["chuKi"] + " ngày</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr><td class='borderVien'>Max gan(<b style='color:red;'> trong " + (object) 36 + " ngày</b>)</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["maxSoBanGhi"] + " ngày</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Số ngày chưa ra </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + (Convert.ToDouble(Convert.ToInt32(this._dataTable1.Rows[index]["ngayChuara"].ToString()) + this._khungdanhCapBachThu) / Convert.ToDouble(this._dataTable1.Rows[index]["maxSoBanGhi"].ToString()) < 1.0 ? "<b>(" + this._dataTable1.Rows[index]["ngayChuara"] + ")</b> ngày" : "<b style='color:red;'>(" + this._dataTable1.Rows[index]["ngayChuara"] + ") ngày</b>") + "</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr> <th colspan='" + (object) 16 + "' scope='col' class='borderVien'><div align='left' class='botTable'>Gợi ý : bạn có thể dựa vào các thông tin trên để dự đoán khung về cho loto, bộ số có <b style='color:red;'>ngày chưa ra màu đỏ</b> là bộ số xắp hoặc đã chạm max trong (<b style='color:red;'>" + (object) 36 + "</b>) ngày, với khung (<b style='color:red;'>" + (object) this._khungdanhCapBachThu + "</b>) ngày của bạn </div></th></tr></table></div>";
    }

    private void TimLotoKhan()
    {
      DataView defaultView = this._dataTable1.DefaultView;
      defaultView.Sort = "ngayChuara DESC";
      this._dataTable1 = defaultView.ToTable();
      this._htmlKetqua += "<div style='width:95.5%;float:right;align:center;margin-right:36px;'>";
      this._htmlKetqua = this._htmlKetqua + "<br /><table width='100%'><tr><th bgcolor='Teal' colspan='" + (object) 16 + "' scope='col' class='borderVien'><span class='header'>" + this._loaiLoto + " có số ngày chưa ra lớn giảm dần(Từ khan -> Chưa khan) </span></th></tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Bộ số</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center' class='lotoHeader'>(" + this._dataTable1.Rows[index]["loto"] + ")</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Điểm gan</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["diemGan"] + " điểm</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr><td class='borderVien'>Max gan(<b style='color:red;'> trong " + (object) this._dtLoto.Rows.Count + " ngày</b>)</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["maxGan"] + " ngày</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Số ngày chưa ra </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + ((double) (Convert.ToInt32(this._dataTable1.Rows[index]["maxGan"].ToString()) - this._khungdanhCapBachThu) > Convert.ToDouble(this._dataTable1.Rows[index]["ngayChuara"].ToString()) ? "<b>(" + this._dataTable1.Rows[index]["ngayChuara"] + ")</b> ngày" : "<b style='color:red;'>(" + this._dataTable1.Rows[index]["ngayChuara"] + ") ngày</b>") + "</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr> <th colspan='" + (object) 16 + "' scope='col' class='borderVien'><div align='left' class='botTable'>Gợi ý : điểm gan lớn cho biết bộ số đó đang chạm dần đến maxgan trong (" + (object) this._dtLoto.Rows.Count + ") ngày, bộ số có <b style='color:red;'>ngày chưa ra màu đỏ</b> là bộ số xắp hoặc đã chạm max trong (<b style='color:red;'>" + (object) this._dtLoto.Rows.Count + "</b>) ngày, với khung (<b style='color:red;'>" + (object) this._khungdanhCapBachThu + "</b>) ngày của bạn</div></th></tr></table><br></div>";
    }

    private void TimLotoTanXuatDep()
    {
      DataView defaultView = this._dataTable1.DefaultView;
      defaultView.Sort = "diemtanxuat DESC";
      this._dataTable1 = defaultView.ToTable();
      this._htmlKetqua += "<div style='width:95.5%;float:right;align:center;margin-right:36px;'>";
      this._htmlKetqua = this._htmlKetqua + "<br /><table width='100%'><tr><th bgcolor='Teal' colspan='" + (object) 16 + "' scope='col' class='borderVien'><span class='header'>" + this._loaiLoto + " có điểm tần xuất đẹp trong (" + (object) 36 + ") ngày vừa qua </span></th></tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Bộ số</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center' class='lotoHeader'>(" + this._dataTable1.Rows[index]["loto"] + ")</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Điểm tần xuất </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["diemtanxuat"] + " điểm </div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Chu kỳ trung bình </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["chuKi"] + " ngày</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr><td class='borderVien'>Max gan(<b style='color:red;'> trong " + (object) 36 + " ngày</b>)</td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + this._dataTable1.Rows[index]["maxSoBanGhi"] + " ngày</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua += "<tr><td class='borderVien'>Số ngày chưa ra </td>";
      for (int index = 0; index < 15; ++index)
        this._htmlKetqua = this._htmlKetqua + "<td class='borderVien'><div align='center'>" + ((double) Convert.ToInt32(this._dataTable1.Rows[index]["ngayChuara"].ToString()) <= Convert.ToDouble(this._dataTable1.Rows[index]["maxSoBanGhi"].ToString()) - (double) this._khungdanhCapBachThu ? "<b>(" + this._dataTable1.Rows[index]["ngayChuara"] + ")</b> ngày" : "<b style='color:red;'>(" + this._dataTable1.Rows[index]["ngayChuara"] + ") ngày</b>") + "</div></td>";
      this._htmlKetqua += "</tr>";
      this._htmlKetqua = this._htmlKetqua + "<tr> <th colspan='" + (object) 16 + "' scope='col' class='borderVien'><div align='left' class='botTable'>Gợi ý : điểm tần xuất thể hiện chu kỳ và tần xuất của của bộ số đó , bộ số có <b style='color:red;'>ngày chưa ra màu đỏ</b> là bộ số xắp hoặc đã chạm max trong (<b style='color:red;'>" + (object) 36 + "</b>) ngày, với khung (<b style='color:red;'>" + (object) this._khungdanhCapBachThu + "</b>) ngày của bạn </div></th></tr></table></div>";
    }

    private void BgXulyRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      TabBoxloto.HienThiKetQua(this.wbHienthi, this._htmlKetqua);
    }

    private void CbbLoaiLotoSelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void Timer1Tick(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabBoxloto));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.wbHienthi = new WebBrowser();
      this.btnXem = new Button();
      this.dtNgayThang = new DateTimePicker();
      this.bgXuly = new BackgroundWorker();
      this.panel1 = new Panel();
      this.cbbLoaiLoto = new ComboBox();
      this.timer1 = new Timer(this.components);
      this.picLoading = new PictureBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(0, 0);
      this.wbHienthi.MinimumSize = new Size(20, 20);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1306, 583);
      this.wbHienthi.TabIndex = 0;
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(256, 6);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(61, 23);
      this.btnXem.TabIndex = 2;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.BtnXemClick);
      this.dtNgayThang.CustomFormat = "dd/MM/yyyy";
      this.dtNgayThang.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayThang.Format = DateTimePickerFormat.Custom;
      this.dtNgayThang.Location = new Point(36, 8);
      this.dtNgayThang.Name = "dtNgayThang";
      this.dtNgayThang.Size = new Size(107, 21);
      this.dtNgayThang.TabIndex = 0;
      this.dtNgayThang.ValueChanged += new EventHandler(this.DTNgayThangValueChanged);
      this.bgXuly.DoWork += new DoWorkEventHandler(this.BgXulyDoWork);
      this.bgXuly.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgXulyRunWorkerCompleted);
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.cbbLoaiLoto);
      this.panel1.Controls.Add((Control) this.dtNgayThang);
      this.panel1.Controls.Add((Control) this.btnXem);
      this.panel1.Location = new Point(0, -1);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(319, 29);
      this.panel1.TabIndex = 20;
      this.cbbLoaiLoto.BackColor = Color.Teal;
      this.cbbLoaiLoto.Cursor = Cursors.Hand;
      this.cbbLoaiLoto.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoaiLoto.FlatStyle = FlatStyle.Flat;
      this.cbbLoaiLoto.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbLoaiLoto.ForeColor = Color.White;
      this.cbbLoaiLoto.FormattingEnabled = true;
      this.cbbLoaiLoto.Items.AddRange(new object[4]
      {
        (object) "     Lô Cặp",
        (object) "  Lô Bạch Thủ",
        (object) "Cặp Trung Đầu",
        (object) "Cặp Trùng Đuôi"
      });
      this.cbbLoaiLoto.Location = new Point(143, 6);
      this.cbbLoaiLoto.Name = "cbbLoaiLoto";
      this.cbbLoaiLoto.Size = new Size(113, 23);
      this.cbbLoaiLoto.TabIndex = 1;
      this.cbbLoaiLoto.SelectedIndexChanged += new EventHandler(this.CbbLoaiLotoSelectedIndexChanged);
      this.timer1.Tick += new EventHandler(this.Timer1Tick);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(594, 280);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 62;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.wbHienthi);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabBoxloto);
      this.Size = new Size(1291, 583);
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }

    public class LOTO
    {
      public string LOTO1 { get; set; }

      public string LOTO2 { get; set; }
    }

    public class DataRowTable
    {
      public string Loto { get; set; }

      public int Solanve { get; set; }

      public int NgayChuara { get; set; }

      public Decimal ChuKi { get; set; }

      public int MaxSobanghi { get; set; }

      public int MaxGan { get; set; }

      public Decimal DiemGan { get; set; }

      public Decimal Diemtanxuat { get; set; }

      public int VeNgay { get; set; }
    }
  }
}
