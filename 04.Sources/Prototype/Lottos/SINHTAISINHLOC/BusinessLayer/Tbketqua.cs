// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.Tbketqua
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class Tbketqua
  {
    public static DateTime NgayBatdau;
    public static DateTime NgayKetthuc;

    public int Clthutu { get; set; }

    public DateTime Clngaythang { get; set; }

    public string Cldai { get; set; }

    public string ClNguoithem { get; set; }

    public string G0 { get; set; }

    public string G1 { get; set; }

    public string G21 { get; set; }

    public string G22 { get; set; }

    public string G31 { get; set; }

    public string G32 { get; set; }

    public string G33 { get; set; }

    public string G34 { get; set; }

    public string G35 { get; set; }

    public string G36 { get; set; }

    public string G41 { get; set; }

    public string G42 { get; set; }

    public string G43 { get; set; }

    public string G44 { get; set; }

    public string G51 { get; set; }

    public string G52 { get; set; }

    public string G53 { get; set; }

    public string G54 { get; set; }

    public string G55 { get; set; }

    public string G56 { get; set; }

    public string G61 { get; set; }

    public string G62 { get; set; }

    public string G63 { get; set; }

    public string G71 { get; set; }

    public string G72 { get; set; }

    public string G73 { get; set; }

    public string G74 { get; set; }

    public static void AddGiaTriCbbThu(ComboBox cb)
    {
      cb.DataSource = (object) new ArrayList()
      {
        (object) new Tbketqua.AddValue("     TẤT CẢ     ", "0"),
        (object) new Tbketqua.AddValue("     THỨ HAI    ", "2"),
        (object) new Tbketqua.AddValue("     THỨ BA     ", "3"),
        (object) new Tbketqua.AddValue("     THỨ TƯ     ", "4"),
        (object) new Tbketqua.AddValue("     THỨ NĂM    ", "5"),
        (object) new Tbketqua.AddValue("     THỨ SÁU    ", "6"),
        (object) new Tbketqua.AddValue("     THỨ BẢY    ", "7"),
        (object) new Tbketqua.AddValue("     CHỦ NHẬT   ", "1")
      };
      cb.DisplayMember = "Display";
      cb.ValueMember = "Value";
    }

    public static void AddGiaTriCbbThuTrongTuan(ComboBox cb)
    {
      cb.DataSource = (object) new ArrayList()
      {
        (object) new Tbketqua.AddValue("          CHỦ NHẬT        ", "1"),
        (object) new Tbketqua.AddValue("          THỨ HAI         ", "2"),
        (object) new Tbketqua.AddValue("          THỨ BA          ", "3"),
        (object) new Tbketqua.AddValue("          THỨ TƯ          ", "4"),
        (object) new Tbketqua.AddValue("          THỨ NĂM         ", "5"),
        (object) new Tbketqua.AddValue("          THỨ SÁU         ", "6"),
        (object) new Tbketqua.AddValue("          THỨ BẢY         ", "7")
      };
      cb.DisplayMember = "Display";
      cb.ValueMember = "Value";
    }

    public static void DisplayHtml(WebBrowser wb, string html)
    {
      try
      {
        if (!wb.IsDisposed)
        {
          wb.Navigate("about:blank");
        }
        else
        {
          wb = new WebBrowser();
          wb.Navigate("about:blank");
        }
        if (wb.Document != (HtmlDocument) null)
          wb.Document.Write(string.Empty);
      }
      finally
      {
      }
      wb.DocumentText = html;
    }

    public static void HienThiKetQua(WebBrowser wb, string strHtml)
    {
      string html = "<html><head>\r\n            <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n            <meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\" />\r\n            <style type=\"text/css\">\r\n            .style1{width: 18%;height: 30px;border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;border-bottom-width: 1px;font-size:16px;text-align:center;}\r\n            .style2 {width: 500px;text-align: center;height: 31px;font-size: 19px;border-bottom-style: dotted;border-bottom-width:1px;border-color: orangered;}\r\n            .style3{border-color: red;width: 45px; height: 21px; border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;font-size:15px;}\r\n            .style4 {border-color: red;border-bottom-style: dotted; border-bottom-width: 1px;font-size:15px;}\r\n            .main{width:97%;float:right;margin-right:1%;height: 268px; margin-left: auto; margin-top: 0;padding-bottom: 50px;}\r\n            .table_KQ {border: 1px dotted #FF6600; width: 56%; float: left;}\r\n            .title_XS { text-align:center;margin:0px auto;width:60%;float:left;font-size:20px;color:red;}\r\n             </style>\r\n            \r\n            </head>\r\n            <body  oncontextmenu='return false;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    public static string GetThuTrongtuan(DateTime ngayCantim)
    {
      string str = "";
      if (ngayCantim.DayOfWeek == DayOfWeek.Sunday)
        str = "Chủ nhật - Ngày " + ngayCantim.ToString("dd/MM/yyyy") ?? "";
      if (ngayCantim.DayOfWeek == DayOfWeek.Monday)
        str = "Thứ hai - Ngày " + ngayCantim.ToString("dd/MM/yyyy") ?? "";
      if (ngayCantim.DayOfWeek == DayOfWeek.Tuesday)
        str = "Thứ ba - Ngày " + ngayCantim.ToString("dd/MM/yyyy") ?? "";
      if (ngayCantim.DayOfWeek == DayOfWeek.Wednesday)
        str = "Thứ tư - Ngày " + ngayCantim.ToString("dd/MM/yyyy") ?? "";
      if (ngayCantim.DayOfWeek == DayOfWeek.Thursday)
        str = "Thứ năm - Ngày " + ngayCantim.ToString("dd/MM/yyyy") ?? "";
      if (ngayCantim.DayOfWeek == DayOfWeek.Friday)
        str = "Thứ sáu - Ngày " + ngayCantim.ToString("dd/MM/yyyy") ?? "";
      if (ngayCantim.DayOfWeek == DayOfWeek.Saturday)
        str = "Thứ bảy - Ngày " + ngayCantim.ToString("dd/MM/yyyy") ?? "";
      return str;
    }

    public static string GetThuTrongtuan_Thu(int thutrongtuan)
    {
      string str = "";
      if (thutrongtuan == 0)
        str = "Chủ Nhật";
      if (thutrongtuan == 1)
        str = "Thứ Hai";
      if (thutrongtuan == 2)
        str = "Thứ Ba";
      if (thutrongtuan == 3)
        str = "Thứ Tư";
      if (thutrongtuan == 4)
        str = "Thứ Năm";
      if (thutrongtuan == 5)
        str = "Thứ Sáu";
      if (thutrongtuan == 6)
        str = "Thứ Bảy";
      return str;
    }

    public static string XapXepMangTangdan(string str, string lotoDb, string lotoLon)
    {
      string str1 = "";
      string[] array = str.Split(new char[1]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
      Array.Sort<string>(array);
      foreach (string str2 in array)
        str1 = !(str2 == lotoDb) && !(str2 == lotoLon) ? str1 + str2 + " " : str1 + "(<b style='color:red;'>" + str2 + "</b>) ";
      return str1;
    }

    public static string XapXepMangTangdanCau(string str, string lotoDb, string lotoLon)
    {
      string str1 = "";
      string[] array = str.Split(new char[1]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
      Array.Sort<string>(array);
      foreach (string str2 in array)
        str1 = !(str2 == lotoDb) ? (!(str2 == lotoLon) ? str1 + str2 + " " : str1 + "(<b style='color:red;'>" + str2 + "</b>)<sup style='color:blue;'>2</sup> ") : str1 + "(<b style='color:red;'>" + str2 + "</b>)<sup style='color:red;'>1</sup> ";
      return str1;
    }

    public static string GetLotoTheoDau(Tbketqua obj, string dauDitLoto, string truyVanDauDit)
    {
      string str = "";
      int startIndex = 0;
      if (truyVanDauDit != "dau")
        startIndex = 1;
      if (obj.G0.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G0.Substring(3, 2) + " ";
      if (obj.G1.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G1.Substring(3, 2) + " ";
      if (obj.G21.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G21.Substring(3, 2) + " ";
      if (obj.G22.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G22.Substring(3, 2) + " ";
      if (obj.G31.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G31.Substring(3, 2) + " ";
      if (obj.G32.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G32.Substring(3, 2) + " ";
      if (obj.G33.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G33.Substring(3, 2) + " ";
      if (obj.G34.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G34.Substring(3, 2) + " ";
      if (obj.G35.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G35.Substring(3, 2) + " ";
      if (obj.G36.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G36.Substring(3, 2) + " ";
      if (obj.G41.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G41.Substring(2, 2) + " ";
      if (obj.G42.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G42.Substring(2, 2) + " ";
      if (obj.G43.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G43.Substring(2, 2) + " ";
      if (obj.G44.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G44.Substring(2, 2) + " ";
      if (obj.G51.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G51.Substring(2, 2) + " ";
      if (obj.G52.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G52.Substring(2, 2) + " ";
      if (obj.G53.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G53.Substring(2, 2) + " ";
      if (obj.G54.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G54.Substring(2, 2) + " ";
      if (obj.G55.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G55.Substring(2, 2) + " ";
      if (obj.G56.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G56.Substring(2, 2) + " ";
      if (obj.G61.Substring(1 + startIndex, 1) == dauDitLoto)
        str = str + obj.G61.Substring(1, 2) + " ";
      if (obj.G62.Substring(1 + startIndex, 1) == dauDitLoto)
        str = str + obj.G62.Substring(1, 2) + " ";
      if (obj.G63.Substring(1 + startIndex, 1) == dauDitLoto)
        str = str + obj.G63.Substring(1, 2) + " ";
      if (obj.G71.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G71.Substring(0, 2) + " ";
      if (obj.G72.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G72.Substring(0, 2) + " ";
      if (obj.G73.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G73.Substring(0, 2) + " ";
      if (obj.G74.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G74.Substring(0, 2) + " ";
      return Tbketqua.XapXepMangTangdan(str, obj.G0.Substring(3, 2), "");
    }

    public static string GetLotoTheoDauCau(Tbketqua obj, string dauDitLoto, string truyVanDauDit, string loto1, string loto2)
    {
      string str = "";
      int startIndex = 0;
      if (truyVanDauDit != "dau")
        startIndex = 1;
      if (obj.G0.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G0.Substring(3, 2) + " ";
      if (obj.G1.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G1.Substring(3, 2) + " ";
      if (obj.G21.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G21.Substring(3, 2) + " ";
      if (obj.G22.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G22.Substring(3, 2) + " ";
      if (obj.G31.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G31.Substring(3, 2) + " ";
      if (obj.G32.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G32.Substring(3, 2) + " ";
      if (obj.G33.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G33.Substring(3, 2) + " ";
      if (obj.G34.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G34.Substring(3, 2) + " ";
      if (obj.G35.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G35.Substring(3, 2) + " ";
      if (obj.G36.Substring(3 + startIndex, 1) == dauDitLoto)
        str = str + obj.G36.Substring(3, 2) + " ";
      if (obj.G41.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G41.Substring(2, 2) + " ";
      if (obj.G42.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G42.Substring(2, 2) + " ";
      if (obj.G43.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G43.Substring(2, 2) + " ";
      if (obj.G44.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G44.Substring(2, 2) + " ";
      if (obj.G51.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G51.Substring(2, 2) + " ";
      if (obj.G52.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G52.Substring(2, 2) + " ";
      if (obj.G53.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G53.Substring(2, 2) + " ";
      if (obj.G54.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G54.Substring(2, 2) + " ";
      if (obj.G55.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G55.Substring(2, 2) + " ";
      if (obj.G56.Substring(2 + startIndex, 1) == dauDitLoto)
        str = str + obj.G56.Substring(2, 2) + " ";
      if (obj.G61.Substring(1 + startIndex, 1) == dauDitLoto)
        str = str + obj.G61.Substring(1, 2) + " ";
      if (obj.G62.Substring(1 + startIndex, 1) == dauDitLoto)
        str = str + obj.G62.Substring(1, 2) + " ";
      if (obj.G63.Substring(1 + startIndex, 1) == dauDitLoto)
        str = str + obj.G63.Substring(1, 2) + " ";
      if (obj.G71.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G71.Substring(0, 2) + " ";
      if (obj.G72.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G72.Substring(0, 2) + " ";
      if (obj.G73.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G73.Substring(0, 2) + " ";
      if (obj.G74.Substring(startIndex, 1) == dauDitLoto)
        str = str + obj.G74.Substring(0, 2) + " ";
      return Tbketqua.XapXepMangTangdanCau(str, loto1, loto2);
    }

    public static DataTable GetTbketquaNgayThangThu(DateTime ngayBatdau, DateTime ngayKetthuc, int thu)
    {
      string sql = string.Format("get_tbketqua_NgayThang_Thu N'{0}',N'{1}',N'{2}'", (object) ngayBatdau.ToString("yyyy-MM-dd"), (object) ngayKetthuc.ToString("yyyy-MM-dd"), (object) thu);
      return DataApp.db.GetData(sql);
    }

    public static DataTable GetKetquaNgayKetthucSobanghi(DateTime ngayKetthuc, int sobanghi)
    {
      string sql = string.Format("tbketqua_Get_By_Day_Sobanghivetruoc N'{0}',N'{1}'", (object) ngayKetthuc.ToString("yyyy-MM-dd"), (object) sobanghi);
      return DataApp.db.GetData(sql);
    }

    public class AddValue
    {
      private readonly string _mDisplay;
      private readonly string _mValue;

      public AddValue(string display, string value)
      {
        this._mDisplay = display;
        this._mValue = value;
      }

      public string Display
      {
        get
        {
          return this._mDisplay;
        }
      }

      public string Value
      {
        get
        {
          return this._mValue;
        }
      }
    }
  }
}
