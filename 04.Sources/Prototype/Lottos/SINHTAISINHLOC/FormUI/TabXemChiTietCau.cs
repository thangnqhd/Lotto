// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabXemChiTietCau
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
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabXemChiTietCau : UserControl
  {
    private DateTime NgayBatDauCu = DateTime.Now.AddYears(4);
    private DateTime NgayKetThucCu = DateTime.Now.AddYears(4);
    private string VT1Cu = "aaaa";
    private string VT2Cu = "bbbb";
    private string strTong = "";
    private IContainer components = (IContainer) null;
    private TbVitri _objVitri;
    private readonly Tbloto objLoto;
    private DataTable _dtLotoNgay;
    private DateTime NgayKetThuc;
    private int khungdanh;
    private DateTime ngayBatDau;
    private DataTable dtVitriLotTo;
    private DataTable dtLotoTong;
    private int width;
    private string thongTinCau;
    private Panel panel1;
    private Panel panel2;
    private GroupBox groupBox2;
    private GroupBox groupBox1;
    private Label label8;
    private Button btnThongke;
    private DateTimePicker dtDenNgay;
    private DateTimePicker dtTuNgay;
    private Label label9;
    private NumericUpDown numTien;
    private NumericUpDown numLui;
    private ComboBox cbbLoto;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label14;
    private BunifuElipse bunifuElipse1;
    private BackgroundWorker bg2;
    private BackgroundWorker bg3;
    private WebBrowser wbChiTietCau;
    private WebBrowser wbThongtinCau;
    private Timer timeBtnThongKe;
    private PictureBox picLoading;
    private PictureBox picLoading1;
    private ComboBox cbbVitri2;
    private Timer timer1;
    public ComboBox cbbVitri1;
    private Label label1;
    private Timer timerLoadForm;
    private ToolTip toolTip1;
    private WebBrowser webBKetQua;
    private GroupBox groupBox3;

    public TabXemChiTietCau()
    {
      this.InitializeComponent();
      this.picLoading.Location = new Point((FMain.ChieurongForm + 345) / 2 - 40, this.picLoading.Location.Y);
      this.VT1Cu = "";
      this.VT2Cu = "";
      this.wbChiTietCau.IsWebBrowserContextMenuEnabled = false;
      this.wbChiTietCau.AllowWebBrowserDrop = false;
      this.wbThongtinCau.IsWebBrowserContextMenuEnabled = false;
      this.wbThongtinCau.AllowWebBrowserDrop = false;
      this.webBKetQua.IsWebBrowserContextMenuEnabled = false;
      this.webBKetQua.AllowWebBrowserDrop = false;
      this.NgayBatDauCu = DateTime.Now.AddYears(-10);
      this.NgayKetThucCu = DateTime.Now.AddYears(-10);
      this.objLoto = new Tbloto();
      this.NgayThangNew = FMain.NgayKetQuaMoiNhat;
      this.dtDenNgay.Value = TbVitri.NgayKetThuc;
      this.dtTuNgay.Value = TbVitri.NgayKetThuc.AddMonths(-TbVitri.Sothangkiemtra);
      this.cbbVitri1.SelectedItem = (object) TbVitri.Vitri1;
      this.cbbVitri2.SelectedItem = (object) TbVitri.Vitri2;
      this.cbbLoto.SelectedIndex = TbVitri.CbbLotoSelectId;
      this.numLui.Value = TbVitri.NumLui;
      this.numTien.Value = TbVitri.NumTien;
      this.timerLoadForm.Start();
    }

    private DateTime NgayThangNew { get; set; }

    private void GetByDay(DateTime ngayKiemTra)
    {
      this._objVitri = new TbVitri();
      if (!(this.NgayKetThucCu != this.NgayKetThuc) && this._dtLotoNgay != null)
        return;
      this._dtLotoNgay = this._objVitri.GetByDay(ngayKiemTra);
      this.NgayKetThucCu = this.NgayKetThuc;
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                <style type='text/css'>\r\n                                    \r\n                                     .style1{width: 25%;border-bottom-style: dotted;border-bottom-width: 1px;border-bottom-width: 1px;text-align:center;font-family:Arial;font-size:11px;color:#162538;}\r\n                                    .style2 {width: 75%;text-align: center;font-size: 12px;border-bottom-style: dotted;border-bottom-width:1px;font-family: arial;color:black;}\r\n                                    .style3{border-color: red;width: 45px; height: 22px; border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;}\r\n                                    .style4 {border-color: red;border-bottom-style: dotted; border-bottom-width: 1px;}\r\n                                    .table_KQ {float: left;margin-top:-5px;}\r\n                                    .title_XS { text-align:center;margin:0px auto;float:left;font-size:10px;}\r\n                                    .main{text-align:center;}\r\n                                    .vt1{color:red;font-size:15px;}\r\n                                    .vt2{color:blue;font-size:15px;}\r\n                                     </style>\r\n                                <title>THỐNG KÊ XỔ SỐ</title></head><body>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private string StrKetQuaXoSo(DataTable dtTable, string vt1, string vt2)
    {
      string soVitri1 = "0";
      string soVitri2 = "0";
      this._objVitri.G011 = dtTable.Rows[0]["G0:1:1"].ToString();
      if ("G0:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G011;
        this._objVitri.G011 = "<b class='vt1'>(" + this._objVitri.G011 + ")<sup>1</sup></b>";
      }
      if ("G0:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G011;
        this._objVitri.G011 = "<b class='vt2'>(" + this._objVitri.G011 + ")<sup>2</sup></b>";
      }
      this._objVitri.G012 = dtTable.Rows[0]["G0:1:2"].ToString();
      if ("G0:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G012;
        this._objVitri.G012 = "<b class='vt1'>(" + this._objVitri.G012 + ")<sup>1</sup></b>";
      }
      if ("G0:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G012;
        this._objVitri.G012 = "<b class='vt2'>(" + this._objVitri.G012 + ")<sup>2</sup></b>";
      }
      this._objVitri.G013 = dtTable.Rows[0]["G0:1:3"].ToString();
      if ("G0:1:3" == vt1)
      {
        soVitri1 = this._objVitri.G013;
        this._objVitri.G013 = "<b class='vt1'>(" + this._objVitri.G013 + ")<sup>1</sup></b>";
      }
      if ("G0:1:3" == vt2)
      {
        soVitri2 = this._objVitri.G013;
        this._objVitri.G013 = "<b class='vt2'>(" + this._objVitri.G013 + ")<sup>2</sup></b>";
      }
      this._objVitri.G014 = dtTable.Rows[0]["G0:1:4"].ToString();
      if ("G0:1:4" == vt1)
      {
        soVitri1 = this._objVitri.G014;
        this._objVitri.G014 = "<b class='vt1'>(" + this._objVitri.G014 + ")<sup>1</sup></b>";
      }
      if ("G0:1:4" == vt2)
      {
        soVitri2 = this._objVitri.G014;
        this._objVitri.G014 = "<b class='vt2'>(" + this._objVitri.G014 + ")<sup>2</sup></b>";
      }
      this._objVitri.G015 = dtTable.Rows[0]["G0:1:5"].ToString();
      if ("G0:1:5" == vt1)
      {
        soVitri1 = this._objVitri.G015;
        this._objVitri.G015 = "<b class='vt1'>(" + this._objVitri.G015 + ")<sup>1</sup></b>";
      }
      if ("G0:1:5" == vt2)
      {
        soVitri2 = this._objVitri.G015;
        this._objVitri.G015 = "<b class='vt2'>(" + this._objVitri.G015 + ")<sup>2</sup></b>";
      }
      this._objVitri.G111 = dtTable.Rows[0]["G1:1:1"].ToString();
      if ("G1:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G111;
        this._objVitri.G111 = "<b class='vt1'>(" + this._objVitri.G111 + ")<sup>1</sup></b>";
      }
      if ("G1:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G111;
        this._objVitri.G111 = "<b class='vt2'>(" + this._objVitri.G111 + ")<sup>2</sup></b>";
      }
      this._objVitri.G112 = dtTable.Rows[0]["G1:1:2"].ToString();
      if ("G1:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G112;
        this._objVitri.G112 = "<b class='vt1'>(" + this._objVitri.G112 + ")<sup>1</sup></b>";
      }
      if ("G1:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G112;
        this._objVitri.G112 = "<b class='vt2'>(" + this._objVitri.G112 + ")<sup>2</sup></b>";
      }
      this._objVitri.G113 = dtTable.Rows[0]["G1:1:3"].ToString();
      if ("G1:1:3" == vt1)
      {
        soVitri1 = this._objVitri.G113;
        this._objVitri.G113 = "<b class='vt1'>(" + this._objVitri.G113 + ")<sup>1</sup></b>";
      }
      if ("G1:1:3" == vt2)
      {
        soVitri2 = this._objVitri.G113;
        this._objVitri.G113 = "<b class='vt2'>(" + this._objVitri.G113 + ")<sup>2</sup></b>";
      }
      this._objVitri.G114 = dtTable.Rows[0]["G1:1:4"].ToString();
      if ("G1:1:4" == vt1)
      {
        soVitri1 = this._objVitri.G114;
        this._objVitri.G114 = "<b class='vt1'>(" + this._objVitri.G114 + ")<sup>1</sup></b>";
      }
      if ("G1:1:4" == vt2)
      {
        soVitri2 = this._objVitri.G114;
        this._objVitri.G114 = "<b class='vt2'>(" + this._objVitri.G114 + ")<sup>2</sup></b>";
      }
      this._objVitri.G115 = dtTable.Rows[0]["G1:1:5"].ToString();
      if ("G1:1:5" == vt1)
      {
        soVitri1 = this._objVitri.G115;
        this._objVitri.G115 = "<b class='vt1'>(" + this._objVitri.G115 + ")<sup>1</sup></b>";
      }
      if ("G1:1:5" == vt2)
      {
        soVitri2 = this._objVitri.G115;
        this._objVitri.G115 = "<b class='vt2'>(" + this._objVitri.G115 + ")<sup>2</sup></b>";
      }
      this._objVitri.G211 = dtTable.Rows[0]["G2:1:1"].ToString();
      if ("G2:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G211;
        this._objVitri.G211 = "<b class='vt1'>(" + this._objVitri.G211 + ")<sup>1</sup></b>";
      }
      if ("G2:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G211;
        this._objVitri.G211 = "<b class='vt2'>(" + this._objVitri.G211 + ")<sup>2</sup></b>";
      }
      this._objVitri.G212 = dtTable.Rows[0]["G2:1:2"].ToString();
      if ("G2:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G212;
        this._objVitri.G212 = "<b class='vt1'>(" + this._objVitri.G212 + ")<sup>1</sup></b>";
      }
      if ("G2:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G212;
        this._objVitri.G212 = "<b class='vt2'>(" + this._objVitri.G212 + ")<sup>2</sup></b>";
      }
      this._objVitri.G213 = dtTable.Rows[0]["G2:1:3"].ToString();
      if ("G2:1:3" == vt1)
      {
        soVitri1 = this._objVitri.G213;
        this._objVitri.G213 = "<b class='vt1'>(" + this._objVitri.G213 + ")<sup>1</sup></b>";
      }
      if ("G2:1:3" == vt2)
      {
        soVitri2 = this._objVitri.G213;
        this._objVitri.G213 = "<b class='vt2'>(" + this._objVitri.G213 + ")<sup>2</sup></b>";
      }
      this._objVitri.G214 = dtTable.Rows[0]["G2:1:4"].ToString();
      if ("G2:1:4" == vt1)
      {
        soVitri1 = this._objVitri.G214;
        this._objVitri.G214 = "<b class='vt1'>(" + this._objVitri.G214 + ")<sup>1</sup></b>";
      }
      if ("G2:1:4" == vt2)
      {
        soVitri2 = this._objVitri.G214;
        this._objVitri.G214 = "<b class='vt2'>(" + this._objVitri.G214 + ")<sup>2</sup></b>";
      }
      this._objVitri.G215 = dtTable.Rows[0]["G2:1:5"].ToString();
      if ("G2:1:5" == vt1)
      {
        soVitri1 = this._objVitri.G215;
        this._objVitri.G215 = "<b class='vt1'>(" + this._objVitri.G215 + ")<sup>1</sup></b>";
      }
      if ("G2:1:5" == vt2)
      {
        soVitri2 = this._objVitri.G215;
        this._objVitri.G215 = "<b class='vt2'>(" + this._objVitri.G215 + ")<sup>2</sup></b>";
      }
      this._objVitri.G221 = dtTable.Rows[0]["G2:2:1"].ToString();
      if ("G2:2:1" == vt1)
      {
        soVitri1 = this._objVitri.G221;
        this._objVitri.G221 = "<b class='vt1'>(" + this._objVitri.G221 + ")<sup>1</sup></b>";
      }
      if ("G2:2:1" == vt2)
      {
        soVitri2 = this._objVitri.G221;
        this._objVitri.G221 = "<b class='vt2'>(" + this._objVitri.G221 + ")<sup>2</sup></b>";
      }
      this._objVitri.G222 = dtTable.Rows[0]["G2:2:2"].ToString();
      if ("G2:2:2" == vt1)
      {
        soVitri1 = this._objVitri.G222;
        this._objVitri.G222 = "<b class='vt1'>(" + this._objVitri.G222 + ")<sup>1</sup></b>";
      }
      if ("G2:2:2" == vt2)
      {
        soVitri2 = this._objVitri.G222;
        this._objVitri.G222 = "<b class='vt2'>(" + this._objVitri.G222 + ")<sup>2</sup></b>";
      }
      this._objVitri.G223 = dtTable.Rows[0]["G2:2:3"].ToString();
      if ("G2:2:3" == vt1)
      {
        soVitri1 = this._objVitri.G223;
        this._objVitri.G223 = "<b class='vt1'>(" + this._objVitri.G223 + ")<sup>1</sup></b>";
      }
      if ("G2:2:3" == vt2)
      {
        soVitri2 = this._objVitri.G223;
        this._objVitri.G223 = "<b class='vt2'>(" + this._objVitri.G223 + ")<sup>2</sup></b>";
      }
      this._objVitri.G224 = dtTable.Rows[0]["G2:2:4"].ToString();
      if ("G2:2:4" == vt1)
      {
        soVitri1 = this._objVitri.G224;
        this._objVitri.G224 = "<b class='vt1'>(" + this._objVitri.G224 + ")<sup>1</sup></b>";
      }
      if ("G2:2:4" == vt2)
      {
        soVitri2 = this._objVitri.G224;
        this._objVitri.G224 = "<b class='vt2'>(" + this._objVitri.G224 + ")<sup>2</sup></b>";
      }
      this._objVitri.G225 = dtTable.Rows[0]["G2:2:5"].ToString();
      if ("G2:2:5" == vt1)
      {
        soVitri1 = this._objVitri.G225;
        this._objVitri.G225 = "<b class='vt1'>(" + this._objVitri.G225 + ")<sup>1</sup></b>";
      }
      if ("G2:2:5" == vt2)
      {
        soVitri2 = this._objVitri.G225;
        this._objVitri.G225 = "<b class='vt2'>(" + this._objVitri.G225 + ")<sup>2</sup></b>";
      }
      this._objVitri.G311 = dtTable.Rows[0]["G3:1:1"].ToString();
      if ("G3:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G311;
        this._objVitri.G311 = "<b class='vt1'>(" + this._objVitri.G311 + ")<sup>1</sup></b>";
      }
      if ("G3:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G311;
        this._objVitri.G311 = "<b class='vt2'>(" + this._objVitri.G311 + ")<sup>2</sup></b>";
      }
      this._objVitri.G312 = dtTable.Rows[0]["G3:1:2"].ToString();
      if ("G3:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G312;
        this._objVitri.G312 = "<b class='vt1'>(" + this._objVitri.G312 + ")<sup>1</sup></b>";
      }
      if ("G3:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G312;
        this._objVitri.G312 = "<b class='vt2'>(" + this._objVitri.G312 + ")<sup>2</sup></b>";
      }
      this._objVitri.G313 = dtTable.Rows[0]["G3:1:3"].ToString();
      if ("G3:1:3" == vt1)
      {
        soVitri1 = this._objVitri.G313;
        this._objVitri.G313 = "<b class='vt1'>(" + this._objVitri.G313 + ")<sup>1</sup></b>";
      }
      if ("G3:1:3" == vt2)
      {
        soVitri2 = this._objVitri.G313;
        this._objVitri.G313 = "<b class='vt2'>(" + this._objVitri.G313 + ")<sup>2</sup></b>";
      }
      this._objVitri.G314 = dtTable.Rows[0]["G3:1:4"].ToString();
      if ("G3:1:4" == vt1)
      {
        soVitri1 = this._objVitri.G314;
        this._objVitri.G314 = "<b class='vt1'>(" + this._objVitri.G314 + ")<sup>1</sup></b>";
      }
      if ("G3:1:4" == vt2)
      {
        soVitri2 = this._objVitri.G314;
        this._objVitri.G314 = "<b class='vt2'>(" + this._objVitri.G314 + ")<sup>2</sup></b>";
      }
      this._objVitri.G315 = dtTable.Rows[0]["G3:1:5"].ToString();
      if ("G3:1:5" == vt1)
      {
        soVitri1 = this._objVitri.G315;
        this._objVitri.G315 = "<b class='vt1'>(" + this._objVitri.G315 + ")<sup>1</sup></b>";
      }
      if ("G3:1:5" == vt2)
      {
        soVitri2 = this._objVitri.G315;
        this._objVitri.G315 = "<b class='vt2'>(" + this._objVitri.G315 + ")<sup>2</sup></b>";
      }
      this._objVitri.G321 = dtTable.Rows[0]["G3:2:1"].ToString();
      if ("G3:2:1" == vt1)
      {
        soVitri1 = this._objVitri.G321;
        this._objVitri.G321 = "<b class='vt1'>(" + this._objVitri.G321 + ")<sup>1</sup></b>";
      }
      if ("G3:2:1" == vt2)
      {
        soVitri2 = this._objVitri.G321;
        this._objVitri.G321 = "<b class='vt2'>(" + this._objVitri.G321 + ")<sup>2</sup></b>";
      }
      this._objVitri.G322 = dtTable.Rows[0]["G3:2:2"].ToString();
      if ("G3:2:2" == vt1)
      {
        soVitri1 = this._objVitri.G322;
        this._objVitri.G322 = "<b class='vt1'>(" + this._objVitri.G322 + ")<sup>1</sup></b>";
      }
      if ("G3:2:2" == vt2)
      {
        soVitri2 = this._objVitri.G322;
        this._objVitri.G322 = "<b class='vt2'>(" + this._objVitri.G322 + ")<sup>2</sup></b>";
      }
      this._objVitri.G323 = dtTable.Rows[0]["G3:2:3"].ToString();
      if ("G3:2:3" == vt1)
      {
        soVitri1 = this._objVitri.G323;
        this._objVitri.G323 = "<b class='vt1'>(" + this._objVitri.G323 + ")<sup>1</sup></b>";
      }
      if ("G3:2:3" == vt2)
      {
        soVitri2 = this._objVitri.G323;
        this._objVitri.G323 = "<b class='vt2'>(" + this._objVitri.G323 + ")<sup>2</sup></b>";
      }
      this._objVitri.G324 = dtTable.Rows[0]["G3:2:4"].ToString();
      if ("G3:2:4" == vt1)
      {
        soVitri1 = this._objVitri.G324;
        this._objVitri.G324 = "<b class='vt1'>(" + this._objVitri.G324 + ")<sup>1</sup></b>";
      }
      if ("G3:2:4" == vt2)
      {
        soVitri2 = this._objVitri.G324;
        this._objVitri.G324 = "<b class='vt2'>(" + this._objVitri.G324 + ")<sup>2</sup></b>";
      }
      this._objVitri.G325 = dtTable.Rows[0]["G3:2:5"].ToString();
      if ("G3:2:5" == vt1)
      {
        soVitri1 = this._objVitri.G325;
        this._objVitri.G325 = "<b class='vt1'>(" + this._objVitri.G325 + ")<sup>1</sup></b>";
      }
      if ("G3:2:5" == vt2)
      {
        soVitri2 = this._objVitri.G325;
        this._objVitri.G325 = "<b class='vt2'>(" + this._objVitri.G325 + ")<sup>2</sup></b>";
      }
      this._objVitri.G331 = dtTable.Rows[0]["G3:3:1"].ToString();
      if ("G3:3:1" == vt1)
      {
        soVitri1 = this._objVitri.G331;
        this._objVitri.G331 = "<b class='vt1'>(" + this._objVitri.G331 + ")<sup>1</sup></b>";
      }
      if ("G3:3:1" == vt2)
      {
        soVitri2 = this._objVitri.G331;
        this._objVitri.G331 = "<b class='vt2'>(" + this._objVitri.G331 + ")<sup>2</sup></b>";
      }
      this._objVitri.G332 = dtTable.Rows[0]["G3:3:2"].ToString();
      if ("G3:3:2" == vt1)
      {
        soVitri1 = this._objVitri.G332;
        this._objVitri.G332 = "<b class='vt1'>(" + this._objVitri.G332 + ")<sup>1</sup></b>";
      }
      if ("G3:3:2" == vt2)
      {
        soVitri2 = this._objVitri.G332;
        this._objVitri.G332 = "<b class='vt2'>(" + this._objVitri.G332 + ")<sup>2</sup></b>";
      }
      this._objVitri.G333 = dtTable.Rows[0]["G3:3:3"].ToString();
      if ("G3:3:3" == vt1)
      {
        soVitri1 = this._objVitri.G333;
        this._objVitri.G333 = "<b class='vt1'>(" + this._objVitri.G333 + ")<sup>1</sup></b>";
      }
      if ("G3:3:3" == vt2)
      {
        soVitri2 = this._objVitri.G333;
        this._objVitri.G333 = "<b class='vt2'>(" + this._objVitri.G333 + ")<sup>2</sup></b>";
      }
      this._objVitri.G334 = dtTable.Rows[0]["G3:3:4"].ToString();
      if ("G3:3:4" == vt1)
      {
        soVitri1 = this._objVitri.G334;
        this._objVitri.G334 = "<b class='vt1'>(" + this._objVitri.G334 + ")<sup>1</sup></b>";
      }
      if ("G3:3:4" == vt2)
      {
        soVitri2 = this._objVitri.G334;
        this._objVitri.G334 = "<b class='vt2'>(" + this._objVitri.G334 + ")<sup>2</sup></b>";
      }
      this._objVitri.G335 = dtTable.Rows[0]["G3:3:5"].ToString();
      if ("G3:3:5" == vt1)
      {
        soVitri1 = this._objVitri.G335;
        this._objVitri.G335 = "<b class='vt1'>(" + this._objVitri.G335 + ")<sup>1</sup></b>";
      }
      if ("G3:3:5" == vt2)
      {
        soVitri2 = this._objVitri.G335;
        this._objVitri.G335 = "<b class='vt2'>(" + this._objVitri.G335 + ")<sup>2</sup></b>";
      }
      this._objVitri.G341 = dtTable.Rows[0]["G3:4:1"].ToString();
      if ("G3:4:1" == vt1)
      {
        soVitri1 = this._objVitri.G341;
        this._objVitri.G341 = "<b class='vt1'>(" + this._objVitri.G341 + ")<sup>1</sup></b>";
      }
      if ("G3:4:1" == vt2)
      {
        soVitri2 = this._objVitri.G341;
        this._objVitri.G341 = "<b class='vt2'>(" + this._objVitri.G341 + ")<sup>2</sup></b>";
      }
      this._objVitri.G342 = dtTable.Rows[0]["G3:4:2"].ToString();
      if ("G3:4:2" == vt1)
      {
        soVitri1 = this._objVitri.G342;
        this._objVitri.G342 = "<b class='vt1'>(" + this._objVitri.G342 + ")<sup>1</sup></b>";
      }
      if ("G3:4:2" == vt2)
      {
        soVitri2 = this._objVitri.G342;
        this._objVitri.G342 = "<b class='vt2'>(" + this._objVitri.G342 + ")<sup>2</sup></b>";
      }
      this._objVitri.G343 = dtTable.Rows[0]["G3:4:3"].ToString();
      if ("G3:4:3" == vt1)
      {
        soVitri1 = this._objVitri.G343;
        this._objVitri.G343 = "<b class='vt1'>(" + this._objVitri.G343 + ")<sup>1</sup></b>";
      }
      if ("G3:4:3" == vt2)
      {
        soVitri2 = this._objVitri.G343;
        this._objVitri.G343 = "<b class='vt2'>(" + this._objVitri.G343 + ")<sup>2</sup></b>";
      }
      this._objVitri.G344 = dtTable.Rows[0]["G3:4:4"].ToString();
      if ("G3:4:4" == vt1)
      {
        soVitri1 = this._objVitri.G344;
        this._objVitri.G344 = "<b class='vt1'>(" + this._objVitri.G344 + ")<sup>1</sup></b>";
      }
      if ("G3:4:4" == vt2)
      {
        soVitri2 = this._objVitri.G344;
        this._objVitri.G344 = "<b class='vt2'>(" + this._objVitri.G344 + ")<sup>2</sup></b>";
      }
      this._objVitri.G345 = dtTable.Rows[0]["G3:4:5"].ToString();
      if ("G3:4:5" == vt1)
      {
        soVitri1 = this._objVitri.G345;
        this._objVitri.G345 = "<b class='vt1'>(" + this._objVitri.G345 + ")<sup>1</sup></b>";
      }
      if ("G3:4:5" == vt2)
      {
        soVitri2 = this._objVitri.G345;
        this._objVitri.G345 = "<b class='vt2'>(" + this._objVitri.G345 + ")<sup>2</sup></b>";
      }
      this._objVitri.G351 = dtTable.Rows[0]["G3:5:1"].ToString();
      if ("G3:5:1" == vt1)
      {
        soVitri1 = this._objVitri.G351;
        this._objVitri.G351 = "<b class='vt1'>(" + this._objVitri.G351 + ")<sup>1</sup></b>";
      }
      if ("G3:5:1" == vt2)
      {
        soVitri2 = this._objVitri.G351;
        this._objVitri.G351 = "<b class='vt2'>(" + this._objVitri.G351 + ")<sup>2</sup></b>";
      }
      this._objVitri.G352 = dtTable.Rows[0]["G3:5:2"].ToString();
      if ("G3:5:2" == vt1)
      {
        soVitri1 = this._objVitri.G352;
        this._objVitri.G352 = "<b class='vt1'>(" + this._objVitri.G352 + ")<sup>1</sup></b>";
      }
      if ("G3:5:2" == vt2)
      {
        soVitri2 = this._objVitri.G352;
        this._objVitri.G352 = "<b class='vt2'>(" + this._objVitri.G352 + ")<sup>2</sup></b>";
      }
      this._objVitri.G353 = dtTable.Rows[0]["G3:5:3"].ToString();
      if ("G3:5:3" == vt1)
      {
        soVitri1 = this._objVitri.G353;
        this._objVitri.G353 = "<b class='vt1'>(" + this._objVitri.G353 + ")<sup>1</sup></b>";
      }
      if ("G3:5:3" == vt2)
      {
        soVitri2 = this._objVitri.G353;
        this._objVitri.G353 = "<b class='vt2'>(" + this._objVitri.G353 + ")<sup>2</sup></b>";
      }
      this._objVitri.G354 = dtTable.Rows[0]["G3:5:4"].ToString();
      if ("G3:5:4" == vt1)
      {
        soVitri1 = this._objVitri.G354;
        this._objVitri.G354 = "<b class='vt1'>(" + this._objVitri.G354 + ")<sup>1</sup></b>";
      }
      if ("G3:5:4" == vt2)
      {
        soVitri2 = this._objVitri.G354;
        this._objVitri.G354 = "<b class='vt2'>(" + this._objVitri.G354 + ")<sup>2</sup></b>";
      }
      this._objVitri.G355 = dtTable.Rows[0]["G3:5:5"].ToString();
      if ("G3:5:5" == vt1)
      {
        soVitri1 = this._objVitri.G355;
        this._objVitri.G355 = "<b class='vt1'>(" + this._objVitri.G355 + ")<sup>1</sup></b>";
      }
      if ("G3:5:5" == vt2)
      {
        soVitri2 = this._objVitri.G355;
        this._objVitri.G355 = "<b class='vt2'>(" + this._objVitri.G355 + ")<sup>2</sup></b>";
      }
      this._objVitri.G361 = dtTable.Rows[0]["G3:6:1"].ToString();
      if ("G3:6:1" == vt1)
      {
        soVitri1 = this._objVitri.G361;
        this._objVitri.G361 = "<b class='vt1'>(" + this._objVitri.G361 + ")<sup>1</sup></b>";
      }
      if ("G3:6:1" == vt2)
      {
        soVitri2 = this._objVitri.G361;
        this._objVitri.G361 = "<b class='vt2'>(" + this._objVitri.G361 + ")<sup>2</sup></b>";
      }
      this._objVitri.G362 = dtTable.Rows[0]["G3:6:2"].ToString();
      if ("G3:6:2" == vt1)
      {
        soVitri1 = this._objVitri.G362;
        this._objVitri.G362 = "<b class='vt1'>(" + this._objVitri.G362 + ")<sup>1</sup></b>";
      }
      if ("G3:6:2" == vt2)
      {
        soVitri2 = this._objVitri.G362;
        this._objVitri.G362 = "<b class='vt2'>(" + this._objVitri.G362 + ")<sup>2</sup></b>";
      }
      this._objVitri.G363 = dtTable.Rows[0]["G3:6:3"].ToString();
      if ("G3:6:3" == vt1)
      {
        soVitri1 = this._objVitri.G363;
        this._objVitri.G363 = "<b class='vt1'>(" + this._objVitri.G363 + ")<sup>1</sup></b>";
      }
      if ("G3:6:3" == vt2)
      {
        soVitri2 = this._objVitri.G363;
        this._objVitri.G363 = "<b class='vt2'>(" + this._objVitri.G363 + ")<sup>2</sup></b>";
      }
      this._objVitri.G364 = dtTable.Rows[0]["G3:6:4"].ToString();
      if ("G3:6:4" == vt1)
      {
        soVitri1 = this._objVitri.G364;
        this._objVitri.G364 = "<b class='vt1'>(" + this._objVitri.G364 + ")<sup>1</sup></b>";
      }
      if ("G3:6:4" == vt2)
      {
        soVitri2 = this._objVitri.G364;
        this._objVitri.G364 = "<b class='vt2'>(" + this._objVitri.G364 + ")<sup>2</sup></b>";
      }
      this._objVitri.G365 = dtTable.Rows[0]["G3:6:5"].ToString();
      if ("G3:6:5" == vt1)
      {
        soVitri1 = this._objVitri.G365;
        this._objVitri.G365 = "<b class='vt1'>(" + this._objVitri.G365 + ")<sup>1</sup></b>";
      }
      if ("G3:6:5" == vt2)
      {
        soVitri2 = this._objVitri.G365;
        this._objVitri.G365 = "<b class='vt2'>(" + this._objVitri.G365 + ")<sup>2</sup></b>";
      }
      this._objVitri.G411 = dtTable.Rows[0]["G4:1:1"].ToString();
      if ("G4:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G411;
        this._objVitri.G411 = "<b class='vt1'>(" + this._objVitri.G411 + ")<sup>1</sup></b>";
      }
      if ("G4:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G411;
        this._objVitri.G411 = "<b class='vt2'>(" + this._objVitri.G411 + ")<sup>2</sup></b>";
      }
      this._objVitri.G412 = dtTable.Rows[0]["G4:1:2"].ToString();
      if ("G4:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G412;
        this._objVitri.G412 = "<b class='vt1'>(" + this._objVitri.G412 + ")<sup>1</sup></b>";
      }
      if ("G4:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G412;
        this._objVitri.G412 = "<b class='vt2'>(" + this._objVitri.G412 + ")<sup>2</sup></b>";
      }
      this._objVitri.G413 = dtTable.Rows[0]["G4:1:3"].ToString();
      if ("G4:1:3" == vt1)
      {
        soVitri1 = this._objVitri.G413;
        this._objVitri.G413 = "<b class='vt1'>(" + this._objVitri.G413 + ")<sup>1</sup></b>";
      }
      if ("G4:1:3" == vt2)
      {
        soVitri2 = this._objVitri.G413;
        this._objVitri.G413 = "<b class='vt2'>(" + this._objVitri.G413 + ")<sup>2</sup></b>";
      }
      this._objVitri.G414 = dtTable.Rows[0]["G4:1:4"].ToString();
      if ("G4:1:4" == vt1)
      {
        soVitri1 = this._objVitri.G414;
        this._objVitri.G414 = "<b class='vt1'>(" + this._objVitri.G414 + ")<sup>1</sup></b>";
      }
      if ("G4:1:4" == vt2)
      {
        soVitri2 = this._objVitri.G414;
        this._objVitri.G414 = "<b class='vt2'>(" + this._objVitri.G414 + ")<sup>2</sup></b>";
      }
      this._objVitri.G421 = dtTable.Rows[0]["G4:2:1"].ToString();
      if ("G4:2:1" == vt1)
      {
        soVitri1 = this._objVitri.G421;
        this._objVitri.G421 = "<b class='vt1'>(" + this._objVitri.G421 + ")<sup>1</sup></b>";
      }
      if ("G4:2:1" == vt2)
      {
        soVitri2 = this._objVitri.G421;
        this._objVitri.G421 = "<b class='vt2'>(" + this._objVitri.G421 + ")<sup>2</sup></b>";
      }
      this._objVitri.G422 = dtTable.Rows[0]["G4:2:2"].ToString();
      if ("G4:2:2" == vt1)
      {
        soVitri1 = this._objVitri.G422;
        this._objVitri.G422 = "<b class='vt1'>(" + this._objVitri.G422 + ")<sup>1</sup></b>";
      }
      if ("G4:2:2" == vt2)
      {
        soVitri2 = this._objVitri.G422;
        this._objVitri.G422 = "<b class='vt2'>(" + this._objVitri.G422 + ")<sup>2</sup></b>";
      }
      this._objVitri.G423 = dtTable.Rows[0]["G4:2:3"].ToString();
      if ("G4:2:3" == vt1)
      {
        soVitri1 = this._objVitri.G423;
        this._objVitri.G423 = "<b class='vt1'>(" + this._objVitri.G423 + ")<sup>1</sup></b>";
      }
      if ("G4:2:3" == vt2)
      {
        soVitri2 = this._objVitri.G423;
        this._objVitri.G423 = "<b class='vt2'>(" + this._objVitri.G423 + ")<sup>2</sup></b>";
      }
      this._objVitri.G424 = dtTable.Rows[0]["G4:2:4"].ToString();
      if ("G4:2:4" == vt1)
      {
        soVitri1 = this._objVitri.G424;
        this._objVitri.G424 = "<b class='vt1'>(" + this._objVitri.G424 + ")<sup>1</sup></b>";
      }
      if ("G4:2:4" == vt2)
      {
        soVitri2 = this._objVitri.G424;
        this._objVitri.G424 = "<b class='vt2'>(" + this._objVitri.G424 + ")<sup>2</sup></b>";
      }
      this._objVitri.G431 = dtTable.Rows[0]["G4:3:1"].ToString();
      if ("G4:3:1" == vt1)
      {
        soVitri1 = this._objVitri.G431;
        this._objVitri.G431 = "<b class='vt1'>(" + this._objVitri.G431 + ")<sup>1</sup></b>";
      }
      if ("G4:3:1" == vt2)
      {
        soVitri2 = this._objVitri.G431;
        this._objVitri.G431 = "<b class='vt2'>(" + this._objVitri.G431 + ")<sup>2</sup></b>";
      }
      this._objVitri.G432 = dtTable.Rows[0]["G4:3:2"].ToString();
      if ("G4:3:2" == vt1)
      {
        soVitri1 = this._objVitri.G432;
        this._objVitri.G432 = "<b class='vt1'>(" + this._objVitri.G432 + ")<sup>1</sup></b>";
      }
      if ("G4:3:2" == vt2)
      {
        soVitri2 = this._objVitri.G432;
        this._objVitri.G432 = "<b class='vt2'>(" + this._objVitri.G432 + ")<sup>2</sup></b>";
      }
      this._objVitri.G433 = dtTable.Rows[0]["G4:3:3"].ToString();
      if ("G4:3:3" == vt1)
      {
        soVitri1 = this._objVitri.G433;
        this._objVitri.G433 = "<b class='vt1'>(" + this._objVitri.G433 + ")<sup>1</sup></b>";
      }
      if ("G4:3:3" == vt2)
      {
        soVitri2 = this._objVitri.G433;
        this._objVitri.G433 = "<b class='vt2'>(" + this._objVitri.G433 + ")<sup>2</sup></b>";
      }
      this._objVitri.G434 = dtTable.Rows[0]["G4:3:4"].ToString();
      if ("G4:3:4" == vt1)
      {
        soVitri1 = this._objVitri.G434;
        this._objVitri.G434 = "<b class='vt1'>(" + this._objVitri.G434 + ")<sup>1</sup></b>";
      }
      if ("G4:3:4" == vt2)
      {
        soVitri2 = this._objVitri.G434;
        this._objVitri.G434 = "<b class='vt2'>(" + this._objVitri.G434 + ")<sup>2</sup></b>";
      }
      this._objVitri.G441 = dtTable.Rows[0]["G4:4:1"].ToString();
      if ("G4:4:1" == vt1)
      {
        soVitri1 = this._objVitri.G441;
        this._objVitri.G441 = "<b class='vt1'>(" + this._objVitri.G441 + ")<sup>1</sup></b>";
      }
      if ("G4:4:1" == vt2)
      {
        soVitri2 = this._objVitri.G441;
        this._objVitri.G441 = "<b class='vt2'>(" + this._objVitri.G441 + ")<sup>2</sup></b>";
      }
      this._objVitri.G442 = dtTable.Rows[0]["G4:4:2"].ToString();
      if ("G4:4:2" == vt1)
      {
        soVitri1 = this._objVitri.G442;
        this._objVitri.G442 = "<b class='vt1'>(" + this._objVitri.G442 + ")<sup>1</sup></b>";
      }
      if ("G4:4:2" == vt2)
      {
        soVitri2 = this._objVitri.G442;
        this._objVitri.G442 = "<b class='vt2'>(" + this._objVitri.G442 + ")<sup>2</sup></b>";
      }
      this._objVitri.G443 = dtTable.Rows[0]["G4:4:3"].ToString();
      if ("G4:4:3" == vt1)
      {
        soVitri1 = this._objVitri.G443;
        this._objVitri.G443 = "<b class='vt1'>(" + this._objVitri.G443 + ")<sup>1</sup></b>";
      }
      if ("G4:4:3" == vt2)
      {
        soVitri2 = this._objVitri.G443;
        this._objVitri.G443 = "<b class='vt2'>(" + this._objVitri.G443 + ")<sup>2</sup></b>";
      }
      this._objVitri.G444 = dtTable.Rows[0]["G4:4:4"].ToString();
      if ("G4:4:4" == vt1)
      {
        soVitri1 = this._objVitri.G444;
        this._objVitri.G444 = "<b class='vt1'>(" + this._objVitri.G444 + ")<sup>1</sup></b>";
      }
      if ("G4:4:4" == vt2)
      {
        soVitri2 = this._objVitri.G444;
        this._objVitri.G444 = "<b class='vt2'>(" + this._objVitri.G444 + ")<sup>2</sup></b>";
      }
      this._objVitri.G511 = dtTable.Rows[0]["G5:1:1"].ToString();
      if ("G5:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G511;
        this._objVitri.G511 = "<b class='vt1'>(" + this._objVitri.G511 + ")<sup>1</sup></b>";
      }
      if ("G5:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G511;
        this._objVitri.G511 = "<b class='vt2'>(" + this._objVitri.G511 + ")<sup>2</sup></b>";
      }
      this._objVitri.G512 = dtTable.Rows[0]["G5:1:2"].ToString();
      if ("G5:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G512;
        this._objVitri.G512 = "<b class='vt1'>(" + this._objVitri.G512 + ")<sup>1</sup></b>";
      }
      if ("G5:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G512;
        this._objVitri.G512 = "<b class='vt2'>(" + this._objVitri.G512 + ")<sup>2</sup></b>";
      }
      this._objVitri.G513 = dtTable.Rows[0]["G5:1:3"].ToString();
      if ("G5:1:3" == vt1)
      {
        soVitri1 = this._objVitri.G513;
        this._objVitri.G513 = "<b class='vt1'>(" + this._objVitri.G513 + ")<sup>1</sup></b>";
      }
      if ("G5:1:3" == vt2)
      {
        soVitri2 = this._objVitri.G513;
        this._objVitri.G513 = "<b class='vt2'>(" + this._objVitri.G513 + ")<sup>2</sup></b>";
      }
      this._objVitri.G514 = dtTable.Rows[0]["G5:1:4"].ToString();
      if ("G5:1:4" == vt1)
      {
        soVitri1 = this._objVitri.G514;
        this._objVitri.G514 = "<b class='vt1'>(" + this._objVitri.G514 + ")<sup>1</sup></b>";
      }
      if ("G5:1:4" == vt2)
      {
        soVitri2 = this._objVitri.G514;
        this._objVitri.G514 = "<b class='vt2'>(" + this._objVitri.G514 + ")<sup>2</sup></b>";
      }
      this._objVitri.G521 = dtTable.Rows[0]["G5:2:1"].ToString();
      if ("G5:2:1" == vt1)
      {
        soVitri1 = this._objVitri.G521;
        this._objVitri.G521 = "<b class='vt1'>(" + this._objVitri.G521 + ")<sup>1</sup></b>";
      }
      if ("G5:2:1" == vt2)
      {
        soVitri2 = this._objVitri.G521;
        this._objVitri.G521 = "<b class='vt2'>(" + this._objVitri.G521 + ")<sup>2</sup></b>";
      }
      this._objVitri.G522 = dtTable.Rows[0]["G5:2:2"].ToString();
      if ("G5:2:2" == vt1)
      {
        soVitri1 = this._objVitri.G522;
        this._objVitri.G522 = "<b class='vt1'>(" + this._objVitri.G522 + ")<sup>1</sup></b>";
      }
      if ("G5:2:2" == vt2)
      {
        soVitri2 = this._objVitri.G522;
        this._objVitri.G522 = "<b class='vt2'>(" + this._objVitri.G522 + ")<sup>2</sup></b>";
      }
      this._objVitri.G523 = dtTable.Rows[0]["G5:2:3"].ToString();
      if ("G5:2:3" == vt1)
      {
        soVitri1 = this._objVitri.G523;
        this._objVitri.G523 = "<b class='vt1'>(" + this._objVitri.G523 + ")<sup>1</sup></b>";
      }
      if ("G5:2:3" == vt2)
      {
        soVitri2 = this._objVitri.G523;
        this._objVitri.G523 = "<b class='vt2'>(" + this._objVitri.G523 + ")<sup>2</sup></b>";
      }
      this._objVitri.G524 = dtTable.Rows[0]["G5:2:4"].ToString();
      if ("G5:2:4" == vt1)
      {
        soVitri1 = this._objVitri.G524;
        this._objVitri.G524 = "<b class='vt1'>(" + this._objVitri.G524 + ")<sup>1</sup></b>";
      }
      if ("G5:2:4" == vt2)
      {
        soVitri2 = this._objVitri.G524;
        this._objVitri.G524 = "<b class='vt2'>(" + this._objVitri.G524 + ")<sup>2</sup></b>";
      }
      this._objVitri.G531 = dtTable.Rows[0]["G5:3:1"].ToString();
      if ("G5:3:1" == vt1)
      {
        soVitri1 = this._objVitri.G531;
        this._objVitri.G531 = "<b class='vt1'>(" + this._objVitri.G531 + ")<sup>1</sup></b>";
      }
      if ("G5:3:1" == vt2)
      {
        soVitri2 = this._objVitri.G531;
        this._objVitri.G531 = "<b class='vt2'>(" + this._objVitri.G531 + ")<sup>2</sup></b>";
      }
      this._objVitri.G532 = dtTable.Rows[0]["G5:3:2"].ToString();
      if ("G5:3:2" == vt1)
      {
        soVitri1 = this._objVitri.G532;
        this._objVitri.G532 = "<b class='vt1'>(" + this._objVitri.G532 + ")<sup>1</sup></b>";
      }
      if ("G5:3:2" == vt2)
      {
        soVitri2 = this._objVitri.G532;
        this._objVitri.G532 = "<b class='vt2'>(" + this._objVitri.G532 + ")<sup>2</sup></b>";
      }
      this._objVitri.G533 = dtTable.Rows[0]["G5:3:3"].ToString();
      if ("G5:3:3" == vt1)
      {
        soVitri1 = this._objVitri.G533;
        this._objVitri.G533 = "<b class='vt1'>(" + this._objVitri.G533 + ")<sup>1</sup></b>";
      }
      if ("G5:3:3" == vt2)
      {
        soVitri2 = this._objVitri.G533;
        this._objVitri.G533 = "<b class='vt2'>(" + this._objVitri.G533 + ")<sup>2</sup></b>";
      }
      this._objVitri.G534 = dtTable.Rows[0]["G5:3:4"].ToString();
      if ("G5:3:4" == vt1)
      {
        soVitri1 = this._objVitri.G534;
        this._objVitri.G534 = "<b class='vt1'>(" + this._objVitri.G534 + ")<sup>1</sup></b>";
      }
      if ("G5:3:4" == vt2)
      {
        soVitri2 = this._objVitri.G534;
        this._objVitri.G534 = "<b class='vt2'>(" + this._objVitri.G534 + ")<sup>2</sup></b>";
      }
      this._objVitri.G541 = dtTable.Rows[0]["G5:4:1"].ToString();
      if ("G5:4:1" == vt1)
      {
        soVitri1 = this._objVitri.G541;
        this._objVitri.G541 = "<b class='vt1'>(" + this._objVitri.G541 + ")<sup>1</sup></b>";
      }
      if ("G5:4:1" == vt2)
      {
        soVitri2 = this._objVitri.G541;
        this._objVitri.G541 = "<b class='vt2'>(" + this._objVitri.G541 + ")<sup>2</sup></b>";
      }
      this._objVitri.G542 = dtTable.Rows[0]["G5:4:2"].ToString();
      if ("G5:4:2" == vt1)
      {
        soVitri1 = this._objVitri.G542;
        this._objVitri.G542 = "<b class='vt1'>(" + this._objVitri.G542 + ")<sup>1</sup></b>";
      }
      if ("G5:4:2" == vt2)
      {
        soVitri2 = this._objVitri.G542;
        this._objVitri.G542 = "<b class='vt2'>(" + this._objVitri.G542 + ")<sup>2</sup></b>";
      }
      this._objVitri.G543 = dtTable.Rows[0]["G5:4:3"].ToString();
      if ("G5:4:3" == vt1)
      {
        soVitri1 = this._objVitri.G543;
        this._objVitri.G543 = "<b class='vt1'>(" + this._objVitri.G543 + ")<sup>1</sup></b>";
      }
      if ("G5:4:3" == vt2)
      {
        soVitri2 = this._objVitri.G543;
        this._objVitri.G543 = "<b class='vt2'>(" + this._objVitri.G543 + ")<sup>2</sup></b>";
      }
      this._objVitri.G544 = dtTable.Rows[0]["G5:4:4"].ToString();
      if ("G5:4:4" == vt1)
      {
        soVitri1 = this._objVitri.G544;
        this._objVitri.G544 = "<b class='vt1'>(" + this._objVitri.G544 + ")<sup>1</sup></b>";
      }
      if ("G5:4:4" == vt2)
      {
        soVitri2 = this._objVitri.G544;
        this._objVitri.G544 = "<b class='vt2'>(" + this._objVitri.G544 + ")<sup>2</sup></b>";
      }
      this._objVitri.G551 = dtTable.Rows[0]["G5:5:1"].ToString();
      if ("G5:5:1" == vt1)
      {
        soVitri1 = this._objVitri.G551;
        this._objVitri.G551 = "<b class='vt1'>(" + this._objVitri.G551 + ")<sup>1</sup></b>";
      }
      if ("G5:5:1" == vt2)
      {
        soVitri2 = this._objVitri.G551;
        this._objVitri.G551 = "<b class='vt2'>(" + this._objVitri.G551 + ")<sup>2</sup></b>";
      }
      this._objVitri.G552 = dtTable.Rows[0]["G5:5:2"].ToString();
      if ("G5:5:2" == vt1)
      {
        soVitri1 = this._objVitri.G552;
        this._objVitri.G552 = "<b class='vt1'>(" + this._objVitri.G552 + ")<sup>1</sup></b>";
      }
      if ("G5:5:2" == vt2)
      {
        soVitri2 = this._objVitri.G552;
        this._objVitri.G552 = "<b class='vt2'>(" + this._objVitri.G552 + ")<sup>2</sup></b>";
      }
      this._objVitri.G553 = dtTable.Rows[0]["G5:5:3"].ToString();
      if ("G5:5:3" == vt1)
      {
        soVitri1 = this._objVitri.G553;
        this._objVitri.G553 = "<b class='vt1'>(" + this._objVitri.G553 + ")<sup>1</sup></b>";
      }
      if ("G5:5:3" == vt2)
      {
        soVitri2 = this._objVitri.G553;
        this._objVitri.G553 = "<b class='vt2'>(" + this._objVitri.G553 + ")<sup>2</sup></b>";
      }
      this._objVitri.G554 = dtTable.Rows[0]["G5:5:4"].ToString();
      if ("G5:5:4" == vt1)
      {
        soVitri1 = this._objVitri.G554;
        this._objVitri.G554 = "<b class='vt1'>(" + this._objVitri.G554 + ")<sup>1</sup></b>";
      }
      if ("G5:5:4" == vt2)
      {
        soVitri2 = this._objVitri.G554;
        this._objVitri.G554 = "<b class='vt2'>(" + this._objVitri.G554 + ")<sup>2</sup></b>";
      }
      this._objVitri.G561 = dtTable.Rows[0]["G5:6:1"].ToString();
      if ("G5:6:1" == vt1)
      {
        soVitri1 = this._objVitri.G561;
        this._objVitri.G561 = "<b class='vt1'>(" + this._objVitri.G561 + ")<sup>1</sup></b>";
      }
      if ("G5:6:1" == vt2)
      {
        soVitri2 = this._objVitri.G561;
        this._objVitri.G561 = "<b class='vt2'>(" + this._objVitri.G561 + ")<sup>2</sup></b>";
      }
      this._objVitri.G562 = dtTable.Rows[0]["G5:6:2"].ToString();
      if ("G5:6:2" == vt1)
      {
        soVitri1 = this._objVitri.G562;
        this._objVitri.G562 = "<b class='vt1'>(" + this._objVitri.G562 + ")<sup>1</sup></b>";
      }
      if ("G5:6:2" == vt2)
      {
        soVitri2 = this._objVitri.G562;
        this._objVitri.G562 = "<b class='vt2'>(" + this._objVitri.G562 + ")<sup>2</sup></b>";
      }
      this._objVitri.G563 = dtTable.Rows[0]["G5:6:3"].ToString();
      if ("G5:6:3" == vt1)
      {
        soVitri1 = this._objVitri.G563;
        this._objVitri.G563 = "<b class='vt1'>(" + this._objVitri.G563 + ")<sup>1</sup></b>";
      }
      if ("G5:6:3" == vt2)
      {
        soVitri2 = this._objVitri.G563;
        this._objVitri.G563 = "<b class='vt2'>(" + this._objVitri.G563 + ")<sup>2</sup></b>";
      }
      this._objVitri.G564 = dtTable.Rows[0]["G5:6:4"].ToString();
      if ("G5:6:4" == vt1)
      {
        soVitri1 = this._objVitri.G564;
        this._objVitri.G564 = "<b class='vt1'>(" + this._objVitri.G564 + ")<sup>1</sup></b>";
      }
      if ("G5:6:4" == vt2)
      {
        soVitri2 = this._objVitri.G564;
        this._objVitri.G564 = "<b class='vt2'>(" + this._objVitri.G564 + ")<sup>2</sup></b>";
      }
      this._objVitri.G611 = dtTable.Rows[0]["G6:1:1"].ToString();
      if ("G6:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G611;
        this._objVitri.G611 = "<b class='vt1'>(" + this._objVitri.G611 + ")<sup>1</sup></b>";
      }
      if ("G6:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G611;
        this._objVitri.G611 = "<b class='vt2'>(" + this._objVitri.G611 + ")<sup>2</sup></b>";
      }
      this._objVitri.G612 = dtTable.Rows[0]["G6:1:2"].ToString();
      if ("G6:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G612;
        this._objVitri.G612 = "<b class='vt1'>(" + this._objVitri.G612 + ")<sup>1</sup></b>";
      }
      if ("G6:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G612;
        this._objVitri.G612 = "<b class='vt2'>(" + this._objVitri.G612 + ")<sup>2</sup></b>";
      }
      this._objVitri.G613 = dtTable.Rows[0]["G6:1:3"].ToString();
      if ("G6:1:3" == vt1)
      {
        soVitri1 = this._objVitri.G613;
        this._objVitri.G613 = "<b class='vt1'>(" + this._objVitri.G613 + ")<sup>1</sup></b>";
      }
      if ("G6:1:3" == vt2)
      {
        soVitri2 = this._objVitri.G613;
        this._objVitri.G613 = "<b class='vt2'>(" + this._objVitri.G613 + ")<sup>2</sup></b>";
      }
      this._objVitri.G621 = dtTable.Rows[0]["G6:2:1"].ToString();
      if ("G6:2:1" == vt1)
      {
        soVitri1 = this._objVitri.G621;
        this._objVitri.G621 = "<b class='vt1'>(" + this._objVitri.G621 + ")<sup>1</sup></b>";
      }
      if ("G6:2:1" == vt2)
      {
        soVitri2 = this._objVitri.G621;
        this._objVitri.G621 = "<b class='vt2'>(" + this._objVitri.G621 + ")<sup>2</sup></b>";
      }
      this._objVitri.G622 = dtTable.Rows[0]["G6:2:2"].ToString();
      if ("G6:2:2" == vt1)
      {
        soVitri1 = this._objVitri.G622;
        this._objVitri.G622 = "<b class='vt1'>(" + this._objVitri.G622 + ")<sup>1</sup></b>";
      }
      if ("G6:2:2" == vt2)
      {
        soVitri2 = this._objVitri.G622;
        this._objVitri.G622 = "<b class='vt2'>(" + this._objVitri.G622 + ")<sup>2</sup></b>";
      }
      this._objVitri.G623 = dtTable.Rows[0]["G6:2:3"].ToString();
      if ("G6:2:3" == vt1)
      {
        soVitri1 = this._objVitri.G623;
        this._objVitri.G623 = "<b class='vt1'>(" + this._objVitri.G623 + ")<sup>1</sup></b>";
      }
      if ("G6:2:3" == vt2)
      {
        soVitri2 = this._objVitri.G623;
        this._objVitri.G623 = "<b class='vt2'>(" + this._objVitri.G623 + ")<sup>2</sup></b>";
      }
      this._objVitri.G631 = dtTable.Rows[0]["G6:3:1"].ToString();
      if ("G6:3:1" == vt1)
      {
        soVitri1 = this._objVitri.G631;
        this._objVitri.G631 = "<b class='vt1'>(" + this._objVitri.G631 + ")<sup>1</sup></b>";
      }
      if ("G6:3:1" == vt2)
      {
        soVitri2 = this._objVitri.G631;
        this._objVitri.G631 = "<b class='vt2'>(" + this._objVitri.G631 + ")<sup>2</sup></b>";
      }
      this._objVitri.G632 = dtTable.Rows[0]["G6:3:2"].ToString();
      if ("G6:3:2" == vt1)
      {
        soVitri1 = this._objVitri.G632;
        this._objVitri.G632 = "<b class='vt1'>(" + this._objVitri.G632 + ")<sup>1</sup></b>";
      }
      if ("G6:3:2" == vt2)
      {
        soVitri2 = this._objVitri.G632;
        this._objVitri.G632 = "<b class='vt2'>(" + this._objVitri.G632 + ")<sup>2</sup></b>";
      }
      this._objVitri.G633 = dtTable.Rows[0]["G6:3:3"].ToString();
      if ("G6:3:3" == vt1)
      {
        soVitri1 = this._objVitri.G633;
        this._objVitri.G633 = "<b class='vt1'>(" + this._objVitri.G633 + ")<sup>1</sup></b>";
      }
      if ("G6:3:3" == vt2)
      {
        soVitri2 = this._objVitri.G633;
        this._objVitri.G633 = "<b class='vt2'>(" + this._objVitri.G633 + ")<sup>2</sup></b>";
      }
      this._objVitri.G711 = dtTable.Rows[0]["G7:1:1"].ToString();
      if ("G7:1:1" == vt1)
      {
        soVitri1 = this._objVitri.G711;
        this._objVitri.G711 = "<b class='vt1'>(" + this._objVitri.G711 + ")<sup>1</sup></b>";
      }
      if ("G7:1:1" == vt2)
      {
        soVitri2 = this._objVitri.G711;
        this._objVitri.G711 = "<b class='vt2'>(" + this._objVitri.G711 + ")<sup>2</sup></b>";
      }
      this._objVitri.G712 = dtTable.Rows[0]["G7:1:2"].ToString();
      if ("G7:1:2" == vt1)
      {
        soVitri1 = this._objVitri.G712;
        this._objVitri.G712 = "<b class='vt1'>(" + this._objVitri.G712 + ")<sup>1</sup></b>";
      }
      if ("G7:1:2" == vt2)
      {
        soVitri2 = this._objVitri.G712;
        this._objVitri.G712 = "<b class='vt2'>(" + this._objVitri.G712 + ")<sup>2</sup></b>";
      }
      this._objVitri.G721 = dtTable.Rows[0]["G7:2:1"].ToString();
      if ("G7:2:1" == vt1)
      {
        soVitri1 = this._objVitri.G721;
        this._objVitri.G721 = "<b class='vt1'>(" + this._objVitri.G721 + ")<sup>1</sup></b>";
      }
      if ("G7:2:1" == vt2)
      {
        soVitri2 = this._objVitri.G721;
        this._objVitri.G721 = "<b class='vt2'>(" + this._objVitri.G721 + ")<sup>2</sup></b>";
      }
      this._objVitri.G722 = dtTable.Rows[0]["G7:2:2"].ToString();
      if ("G7:2:2" == vt1)
      {
        soVitri1 = this._objVitri.G722;
        this._objVitri.G722 = "<b class='vt1'>(" + this._objVitri.G722 + ")<sup>1</sup></b>";
      }
      if ("G7:2:2" == vt2)
      {
        soVitri2 = this._objVitri.G722;
        this._objVitri.G722 = "<b class='vt2'>(" + this._objVitri.G722 + ")<sup>2</sup></b>";
      }
      this._objVitri.G731 = dtTable.Rows[0]["G7:3:1"].ToString();
      if ("G7:3:1" == vt1)
      {
        soVitri1 = this._objVitri.G731;
        this._objVitri.G731 = "<b class='vt1'>(" + this._objVitri.G731 + ")<sup>1</sup></b>";
      }
      if ("G7:3:1" == vt2)
      {
        soVitri2 = this._objVitri.G731;
        this._objVitri.G731 = "<b class='vt2'>(" + this._objVitri.G731 + ")<sup>2</sup></b>";
      }
      this._objVitri.G732 = dtTable.Rows[0]["G7:3:2"].ToString();
      if ("G7:3:2" == vt1)
      {
        soVitri1 = this._objVitri.G732;
        this._objVitri.G732 = "<b class='vt1'>(" + this._objVitri.G732 + ")<sup>1</sup></b>";
      }
      if ("G7:3:2" == vt2)
      {
        soVitri2 = this._objVitri.G732;
        this._objVitri.G732 = "<b class='vt2'>(" + this._objVitri.G732 + ")<sup>2</sup></b>";
      }
      this._objVitri.G741 = dtTable.Rows[0]["G7:4:1"].ToString();
      if ("G7:4:1" == vt1)
      {
        soVitri1 = this._objVitri.G741;
        this._objVitri.G741 = "<b class='vt1'>(" + this._objVitri.G741 + ")<sup>1</sup></b>";
      }
      if ("G7:4:1" == vt2)
      {
        soVitri2 = this._objVitri.G741;
        this._objVitri.G741 = "<b class='vt2'>(" + this._objVitri.G741 + ")<sup>2</sup></b>";
      }
      this._objVitri.G742 = dtTable.Rows[0]["G7:4:2"].ToString();
      if ("G7:4:2" == vt1)
      {
        soVitri1 = this._objVitri.G742;
        this._objVitri.G742 = "<b class='vt1'>(" + this._objVitri.G742 + ")<sup>1</sup></b>";
      }
      if ("G7:4:2" == vt2)
      {
        soVitri2 = this._objVitri.G742;
        this._objVitri.G742 = "<b class='vt2'>(" + this._objVitri.G742 + ")<sup>2</sup></b>";
      }
      if (vt1 == vt2)
        soVitri2 = soVitri1;
      string[] strArray = this.BienDoiLoTo(soVitri1, soVitri2);
      string str = "<div style ='font-size:12px;font-family:Arial;text-align:center;margin-left:10px;'><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ஜ۩۞۩ஜ (<b class='vt1'>" + strArray[0] + "</b>) ஜ۩۞۩ஜ</div>";
      if (strArray[0] != strArray[1])
        str = "<div style ='font-size:12px;font-family:Arial;text-align:center;margin-left:10px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ஜ۩۞۩ஜ (<b class='vt1'>" + strArray[0] + "</b>) - (<b class='vt2'>" + strArray[1] + "</b>) ஜ۩۞۩ஜ</div>";
      return "\r\n                  <table class='table_KQ' width='100%'>\r\n                <tr>\r\n                <td class='style1'>Đặc Biệt</td>\r\n                <td class='style2' style='color:Red;font-weight:bold;font-size:15px;'>" + this._objVitri.G011 + this._objVitri.G012 + this._objVitri.G013 + this._objVitri.G014 + this._objVitri.G015 + "</td></tr><tr><td class='style1' >Giải nhất</td><td class='style2' >" + this._objVitri.G111 + this._objVitri.G112 + this._objVitri.G113 + this._objVitri.G114 + this._objVitri.G115 + "</td></tr><tr><td class='style1'bgcolor='Moccasin' >Giải nhì</td><td bgcolor = 'Moccasin' class='style2'>" + this._objVitri.G211 + this._objVitri.G212 + this._objVitri.G213 + this._objVitri.G214 + this._objVitri.G215 + "  &nbsp;&nbsp;&nbsp;  -&nbsp;&nbsp;&nbsp;    " + this._objVitri.G221 + this._objVitri.G222 + this._objVitri.G223 + this._objVitri.G224 + this._objVitri.G225 + "</td></tr><tr><td class='style1' >Giải ba</td><td class='style2' >" + this._objVitri.G311 + this._objVitri.G312 + this._objVitri.G313 + this._objVitri.G314 + this._objVitri.G315 + " &nbsp;&nbsp;-&nbsp;&nbsp; " + this._objVitri.G321 + this._objVitri.G322 + this._objVitri.G323 + this._objVitri.G324 + this._objVitri.G325 + " &nbsp;&nbsp;-&nbsp;&nbsp; " + this._objVitri.G331 + this._objVitri.G332 + this._objVitri.G333 + this._objVitri.G334 + this._objVitri.G335 + "<br>" + this._objVitri.G341 + this._objVitri.G342 + this._objVitri.G343 + this._objVitri.G344 + this._objVitri.G345 + "  &nbsp;&nbsp;  -  &nbsp;&nbsp; " + this._objVitri.G351 + this._objVitri.G352 + this._objVitri.G353 + this._objVitri.G354 + this._objVitri.G355 + "&nbsp;&nbsp;   -  &nbsp;&nbsp;  " + this._objVitri.G361 + this._objVitri.G362 + this._objVitri.G363 + this._objVitri.G364 + this._objVitri.G365 + "</td></tr><tr><td class='style1'bgcolor='Moccasin' >Giải tư</td><td class='style2' bgcolor='Moccasin'  >&nbsp;" + this._objVitri.G411 + this._objVitri.G412 + this._objVitri.G413 + this._objVitri.G414 + "&nbsp;-&nbsp;" + this._objVitri.G421 + this._objVitri.G422 + this._objVitri.G423 + this._objVitri.G424 + "&nbsp;-&nbsp;" + this._objVitri.G431 + this._objVitri.G432 + this._objVitri.G433 + this._objVitri.G434 + "&nbsp;-&nbsp;" + this._objVitri.G441 + this._objVitri.G442 + this._objVitri.G443 + this._objVitri.G444 + "&nbsp;</td></tr><tr><td class='style1' >Giải năm</td><td class='style2'  >" + this._objVitri.G511 + this._objVitri.G512 + this._objVitri.G513 + this._objVitri.G514 + "  &nbsp;&nbsp; -   &nbsp;" + this._objVitri.G521 + this._objVitri.G522 + this._objVitri.G523 + this._objVitri.G524 + "  &nbsp; - &nbsp;&nbsp;  " + this._objVitri.G531 + this._objVitri.G532 + this._objVitri.G533 + this._objVitri.G534 + " <br> " + this._objVitri.G541 + this._objVitri.G542 + this._objVitri.G543 + this._objVitri.G544 + "  &nbsp;&nbsp; -   &nbsp;" + this._objVitri.G551 + this._objVitri.G552 + this._objVitri.G553 + this._objVitri.G554 + " &nbsp;  - &nbsp;" + this._objVitri.G561 + this._objVitri.G562 + this._objVitri.G563 + this._objVitri.G564 + "</td></tr><tr><td class='style1' bgcolor='Moccasin'>Giải sáu</td><td class='style2'bgcolor='Moccasin' >" + this._objVitri.G611 + this._objVitri.G612 + this._objVitri.G613 + "  &nbsp;&nbsp; - &nbsp;&nbsp;  " + this._objVitri.G621 + this._objVitri.G622 + this._objVitri.G623 + " &nbsp;&nbsp;  - &nbsp;&nbsp;  " + this._objVitri.G631 + this._objVitri.G632 + this._objVitri.G633 + "</td></tr><tr><td class='style1' style='border-bottom-width: 0px;'>Giải bảy</td><td class='style2' style='border-bottom-width: 0px;'>" + this._objVitri.G711 + this._objVitri.G712 + " &nbsp;&nbsp;  - &nbsp;&nbsp;  " + this._objVitri.G721 + this._objVitri.G722 + "&nbsp;&nbsp;   -  &nbsp;&nbsp; " + this._objVitri.G731 + this._objVitri.G732 + " &nbsp;&nbsp;  -  &nbsp;&nbsp; " + this._objVitri.G741 + this._objVitri.G742 + "</td></tr></table></br>" + str ?? "";
    }

    private string[] BienDoiLoTo(string soVitri1, string soVitri2)
    {
      int int32 = Convert.ToInt32(TbVitri.NumTien - TbVitri.NumLui);
      string[] strArray1 = new string[2]{ "", "" };
      try
      {
        Convert.ToInt32(soVitri1);
        Convert.ToInt32(soVitri2);
      }
      catch
      {
        soVitri1 = "0";
        soVitri2 = "0";
      }
      int num1 = int.Parse(soVitri1 + soVitri2);
      if (TbVitri.CbbLotoSelectId == 0)
      {
        strArray1[0] = ((Decimal) num1 + this.numLui.Value).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (int.Parse(strArray1[0]) <= 0)
          strArray1[0] = "00";
        else if (int.Parse(strArray1[0]) < 10 && int.Parse(strArray1[0]) > 0)
          strArray1[0] = "0" + strArray1[0];
        else if (int.Parse(strArray1[0]) > 99)
          strArray1[0] = "99";
        strArray1[1] = this.objLoto.CheckLotoCap(strArray1[0]);
      }
      if (TbVitri.CbbLotoSelectId == 1)
      {
        strArray1[0] = ((Decimal) num1 + this.numLui.Value).ToString((IFormatProvider) CultureInfo.CurrentCulture);
        if (int.Parse(strArray1[0]) <= 0)
          strArray1[0] = "00";
        else if (int.Parse(strArray1[0]) < 10 && int.Parse(strArray1[0]) > 0)
          strArray1[0] = "0" + strArray1[0];
        else if (int.Parse(strArray1[0]) > 99)
          strArray1[0] = "99";
        strArray1[1] = strArray1[0];
      }
      int num2;
      if (TbVitri.CbbLotoSelectId == 2)
      {
        strArray1[0] = ((Decimal) int.Parse(soVitri2) + this.numLui.Value).ToString();
        strArray1[1] = ((Decimal) int.Parse(soVitri2) + this.numTien.Value).ToString();
        if (int.Parse(strArray1[0]) <= 0)
        {
          strArray1[0] = "0";
          strArray1[1] = int32.ToString();
        }
        if (int.Parse(strArray1[1]) > 9)
        {
          strArray1[0] = "9";
          string[] strArray2 = strArray1;
          int index = 1;
          num2 = 9 - int32;
          string str = num2.ToString();
          strArray2[index] = str;
        }
        strArray1[0] = soVitri1 + strArray1[0];
        strArray1[1] = soVitri1 + strArray1[1];
      }
      if (TbVitri.CbbLotoSelectId == 3)
      {
        strArray1[0] = ((Decimal) int.Parse(soVitri1) + this.numLui.Value).ToString();
        strArray1[1] = ((Decimal) int.Parse(soVitri1) + this.numTien.Value).ToString();
        if (int.Parse(strArray1[0]) <= 0)
        {
          strArray1[0] = "0";
          strArray1[1] = int32.ToString();
        }
        if (int.Parse(strArray1[1]) > 9)
        {
          strArray1[0] = "9";
          string[] strArray2 = strArray1;
          int index = 1;
          num2 = 9 - int32;
          string str = num2.ToString();
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

    private void cbbLoto_SelectedIndexChanged(object sender, EventArgs e)
    {
      TbVitri.CbbLotoSelectId = this.cbbLoto.SelectedIndex;
      if (this.cbbLoto.SelectedIndex == 0 || this.cbbLoto.SelectedIndex == 1)
        this.numTien.Enabled = false;
      else
        this.numTien.Enabled = true;
      this.Show();
    }

    private void CbbVitri1SelectedIndexChanged(object sender, EventArgs e)
    {
      TbVitri.Vitri1 = this.cbbVitri1.SelectedItem.ToString();
      this.Show();
    }

    private void cbbVitri2_SelectedIndexChanged(object sender, EventArgs e)
    {
      TbVitri.Vitri2 = this.cbbVitri2.SelectedItem.ToString();
      this.Show();
    }

    private new void Show()
    {
      if (this._dtLotoNgay == null || this._dtLotoNgay.Rows.Count <= 0)
        return;
      this.Hien_Thi_KetQua(this.webBKetQua, this.StrKetQuaXoSo(this._dtLotoNgay, TbVitri.Vitri1, TbVitri.Vitri2));
    }

    private void numLui_ValueChanged(object sender, EventArgs e)
    {
      this.Show();
    }

    private void numTien_ValueChanged(object sender, EventArgs e)
    {
      this.Show();
    }

    private void bg2_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetByDay(this.NgayKetThuc);
    }

    private void bg2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Show();
      this.ClickBTN();
    }

    private void dtDenNgay_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtDenNgay.Value > FMain.NgayKetQuaMoiNhat)
      {
        this.NgayThangNew = FMain.NgayKetQuaMoiNhat;
        this.dtDenNgay.Value = this.NgayThangNew;
      }
      this.NgayKetThuc = this.dtDenNgay.Value;
      this.dtTuNgay.Value = this.NgayKetThuc.AddMonths(-TbVitri.Sothangkiemtra);
    }

    private void ClickBTN()
    {
      DateTime dateTime1;
      if (this.dtTuNgay.Value.Day != 1)
      {
        DateTimePicker dtTuNgay = this.dtTuNgay;
        int year = this.dtTuNgay.Value.Year;
        dateTime1 = this.dtTuNgay.Value;
        int month = dateTime1.Month;
        int day = 1;
        DateTime dateTime2 = new DateTime(year, month, day);
        dtTuNgay.Value = dateTime2;
      }
      dateTime1 = this.dtDenNgay.Value;
      DateTime dateTime3 = dateTime1.AddMonths(-3);
      dateTime1 = this.dtTuNgay.Value;
      DateTime dateTime4 = dateTime1.AddDays(2.0);
      if (dateTime3 > dateTime4)
      {
        this.Hien_Thi_ChiTietCau(this.wbChiTietCau, "");
        this.Hien_Thi_ThongTinCau(this.wbThongtinCau, "");
        if (this.numTien.Enabled)
        {
          if (this.numLui.Value == this.numTien.Value)
          {
            if (MessageBox.Show(Resources.tabGepCau_btnThongke_Click_LÔ_TÔ__LÙI__VÀ_LÔ_TÔ__TIẾN__BẰNG_NHAU__BẠN_CÓ_MUỐN_CHUYỂN_SANG_XEM_GÉP_CẦU_BẠCH_THỦ__, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
              this.cbbLoto.SelectedIndex = 1;
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
        TbVitri.NumLui = this.numLui.Value;
        TbVitri.NumTien = this.numTien.Value;
        TbVitri.CbbLotoSelectId = this.cbbLoto.SelectedIndex;
        this.ngayBatDau = this.dtTuNgay.Value;
        this.NgayKetThuc = this.dtDenNgay.Value;
        if (this.bg3.IsBusy)
          return;
        this.bg3.RunWorkerAsync();
      }
      else
      {
        DateTimePicker dtTuNgay = this.dtTuNgay;
        dateTime1 = this.dtDenNgay.Value;
        DateTime dateTime2 = dateTime1.AddMonths(-3);
        dtTuNgay.Value = dateTime2;
        int num = (int) MessageBox.Show(Resources.TabXemChiTietCau_btnThongke_Click_1_BẠN_NÊN_TRỌN_KHOẢNG_THỜI_GIAN_KIỂM_TRA_NHỎ_NHẤT_LÀ_5_THÁNG, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void Hien_Thi_ChiTietCau(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                <style type='text/css'>\r\n                                    table {\tfont-family: Arial;width: 260px;border - collapse: collapse;float:left;text - align: center;margin-top: -10px;}\r\n        td, th {\r\n\tfont-size: 12px;\r\n\tborder-style:dotted;\r\nborder-width:1px;\r\n\tborder-color:#C1C1C1;\r\n\twidth: 100px;\r\n    text-align: center;\r\n}\r\n.thang {\r\n\twidth:40px;\r\n\t\tbackground-color: #F7F7F7;\r\n\tcolor: black;\r\n\tpadding-left:1px;\r\n\tpadding-right:1px;\r\n\tborder-style:dotted;\r\n\tborder-width:1px;\r\n\tfont-weight : bold;\r\n\ttext-align: center;\r\n}\r\nth {\r\nwidth: 55px;\r\n\tfont-family:Arial, Helvetica, sans-serif;\r\n\tfont-size:11px;\r\n    \ttext-align: center;\r\n    \tpadding-top: 2px;\r\n    \tpadding-bottom: 2px;\r\n    \tbackground-color: #F3F3F3;\r\n    color: #162538;\r\n}\r\ntr {\r\nborder-style:dotted;\r\n\tborder-width:1px;\r\n\tborder-color:#000000;\r\n}\r\n.chuave {\r\n\tbackground-color: #7F7F7F;\r\n\tcolor: #ffffff;\r\n}\r\n.veVuotKhung1 {\r\n\tbackground-color: #FFA200;\r\n\tcolor: #ffffff;\r\n}\r\n.veVuotKhung {\r\n\tbackground-color: #C91B26;\r\n\tcolor: #ffffff;\r\n}\r\n                                     </style>\r\n                                <title>THỐNG KÊ XỔ SỐ</title></head><body style='width:" + (object) this.width + "px;' >" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void GetDataSearch()
    {
      this.width = 0;
      this.khungdanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      if (TbVitri.CbbLotoSelectId == 1)
        this.khungdanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
      this._objVitri = new TbVitri();
      if (this.VT1Cu != TbVitri.Vitri1 || this.VT2Cu != TbVitri.Vitri2 || this.NgayBatDauCu != this.ngayBatDau || this.NgayKetThucCu != this.NgayKetThuc)
      {
        this.dtVitriLotTo = new DataTable();
        this.dtVitriLotTo = this._objVitri.GetByDateAndVt1Vt2(this.ngayBatDau, this.NgayKetThuc, TbVitri.Vitri1, TbVitri.Vitri2);
        this.VT1Cu = TbVitri.Vitri1;
        this.VT2Cu = TbVitri.Vitri2;
      }
      if (this.NgayBatDauCu != this.ngayBatDau || this.NgayKetThucCu != this.NgayKetThuc)
      {
        this.dtLotoTong = new DataTable();
        this.dtLotoTong = this.objLoto.GetLotoByNgayThang(this.ngayBatDau, this.NgayKetThuc);
      }
      this.NgayBatDauCu = this.ngayBatDau;
      this.NgayKetThucCu = this.NgayKetThuc;
      this.strTong = "";
      this.thongTinCau = "";
      if (this.dtVitriLotTo.Rows.Count <= 0)
        return;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      Decimal num6 = new Decimal();
      DataTable dataTable1 = new DataTable();
      dataTable1.Columns.Add("VeNgay", typeof (int));
      dataTable1.Columns.Add("tongSoLan", typeof (int));
      DataRow row1 = dataTable1.NewRow();
      row1[0] = (object) "0";
      row1[1] = (object) "0";
      dataTable1.Rows.Add(row1);
      DataTable dataTable2 = new DataTable();
      dataTable2.Columns.Add("ngay", typeof (int));
      dataTable2.Columns.Add("tongSoLan", typeof (Decimal));
      dataTable2.Columns.Add("tongSoThang", typeof (Decimal));
      dataTable2.Columns.Add("tyleCauChay", typeof (Decimal));
      for (int index = 1; index < 32; ++index)
      {
        DataRow row2 = dataTable2.NewRow();
        row2[0] = (object) index;
        row2[1] = (object) 0;
        row2[2] = (object) 0;
        row2[3] = (object) 0;
        dataTable2.Rows.Add(row2);
      }
      DataTable dataTable3 = new DataTable();
      dataTable3.Columns.Add("thu", typeof (Decimal));
      dataTable3.Columns.Add("tongSoVe", typeof (Decimal));
      dataTable3.Columns.Add("tongSoThuChay", typeof (Decimal));
      for (int index = 0; index < 7; ++index)
      {
        DataRow row2 = dataTable3.NewRow();
        row2[0] = (object) index;
        row2[1] = (object) 0;
        row2[2] = (object) 0;
        dataTable3.Rows.Add(row2);
      }
      for (int index1 = 0; index1 < this.dtVitriLotTo.Rows.Count; ++index1)
      {
        num5 = this.dtVitriLotTo.Rows.Count - 1;
        string soVitri1 = this.dtVitriLotTo.Rows[index1][2].ToString();
        string soVitri2 = this.dtVitriLotTo.Rows[index1][3].ToString();
        int index2 = index1 + 1;
        DateTime dateTime = DateTime.Parse(this.dtVitriLotTo.Rows[index1]["clngaythang"].ToString());
        if (index1 != this.dtVitriLotTo.Rows.Count - 1)
        {
          for (int index3 = 0; index3 < dataTable2.Rows.Count; ++index3)
          {
            if (int.Parse(dataTable2.Rows[index3][0].ToString()) == dateTime.Day)
            {
              dataTable2.Rows[index3][2] = (object) (int.Parse(dataTable2.Rows[index3][2].ToString()) + 1);
              break;
            }
          }
        }
        int dayOfWeek1 = (int) dateTime.DayOfWeek;
        for (int index3 = 0; index3 < dataTable3.Rows.Count; ++index3)
        {
          if (dayOfWeek1 == Convert.ToInt32(dataTable3.Rows[index3][0]))
            dataTable3.Rows[index3][2] = (object) (Convert.ToInt32(dataTable3.Rows[index3][2]) + 1);
        }
        if (dateTime.Month != num1)
        {
          if (num2 == 0)
          {
            this.width += 260;
            this.strTong = this.strTong + "<table style='float:left;'><tr><th>T" + (object) dateTime.Month + "/" + (object) dateTime.Year + "</th><th> LOTO </th>\r\n                                <th> VỀ NGÀY</th>\r\n                            </tr>";
            num2 = 1;
            num6 += Decimal.One;
          }
          num1 = dateTime.Month;
        }
        string[] strArray1 = this.BienDoiLoTo(soVitri1, soVitri2);
        if (dateTime.Month == num1)
        {
          int day = dateTime.Day;
          string[] strArray2 = this.checkLotoVe(strArray1[0], strArray1[1], int.Parse(this.dtVitriLotTo.Rows[index1]["STT"].ToString()));
          int dayOfWeek2 = (int) dateTime.DayOfWeek;
          string str;
          if (strArray2[1] == "ve")
          {
            DataRow row2 = dataTable1.NewRow();
            if (int.Parse(strArray2[0]) > this.khungdanh)
            {
              str = "<td class='veVuotKhung'>" + strArray2[0] + "</td>";
              if (int.Parse(strArray2[0]) == this.khungdanh + 1)
                str = "<td class='veVuotKhung1'>" + strArray2[0] + "</td>";
              bool flag = false;
              int index3 = 0;
              for (int index4 = 0; index4 < dataTable1.Rows.Count; ++index4)
              {
                if (dataTable1.Rows[index4][0].ToString() == strArray2[0])
                {
                  index3 = index4;
                  flag = true;
                  break;
                }
              }
              if (flag)
              {
                dataTable1.Rows[index3]["tongSoLan"] = (object) (int.Parse(dataTable1.Rows[index3]["tongSoLan"].ToString()) + 1);
              }
              else
              {
                row2[0] = (object) strArray2[0];
                row2[1] = (object) 1;
                dataTable1.Rows.Add(row2);
              }
              ++num4;
            }
            else
            {
              for (int index3 = 0; index3 < dataTable3.Rows.Count; ++index3)
              {
                if (dayOfWeek2 == Convert.ToInt32(dataTable3.Rows[index3][0]))
                  dataTable3.Rows[index3][1] = (object) (Convert.ToInt32(dataTable3.Rows[index3][1]) + 1);
              }
              if (int.Parse(strArray2[0]) != 1)
              {
                ++num4;
              }
              else
              {
                if (num4 > num3)
                  num3 = num4;
                num4 = 0;
              }
              dataTable1.Rows[0]["tongSoLan"] = (object) (int.Parse(dataTable1.Rows[0]["tongSoLan"].ToString()) + 1);
              str = "<td >" + strArray2[0] + "</td>";
              for (int index3 = 0; index3 < dataTable2.Rows.Count; ++index3)
              {
                if (int.Parse(dataTable2.Rows[index3][0].ToString()) == day)
                  dataTable2.Rows[index3][1] = (object) (int.Parse(dataTable2.Rows[index3][1].ToString()) + 1);
              }
            }
          }
          else
            str = !(strArray2[0] == "0") ? "<td class='chuave'>(" + strArray2[0] + "n) chưa về </td>" : "<td class='chuave'>Đang đợi...</td>";
          if (strArray1[0] != strArray1[1])
            this.strTong = this.strTong + "<tr><td class='thang'>" + (object) day + "</td><td>" + strArray1[0] + "-" + strArray1[1] + "</td>" + str + "</tr>";
          else
            this.strTong = this.strTong + "<tr><td class='thang'>" + (object) day + "</td><td>" + strArray1[0] + "</td>" + str + "</tr>";
        }
        if (index2 < this.dtVitriLotTo.Rows.Count)
        {
          dateTime = DateTime.Parse(this.dtVitriLotTo.Rows[index2]["clngaythang"].ToString());
          if (dateTime.Month != num1)
          {
            this.strTong += " </table>";
            this.width += 260;
            this.strTong = this.strTong + "<table style='float:left;'><tr><th>T" + (object) dateTime.Month + "/" + (object) dateTime.Year + "</th><th> LOTO </th>\r\n                                <th> VỀ NGÀY</th>\r\n                            </tr>";
            num2 = 1;
            num6 += Decimal.One;
          }
        }
        else
          this.strTong += " </table><br>";
      }
      this.strTong = this.strTong ?? "";
      string str1 = "0";
      DataView defaultView1 = dataTable1.DefaultView;
      defaultView1.Sort = "VeNgay desc";
      DataTable table1 = defaultView1.ToTable();
      string str2 = table1.Rows[0][0].ToString();
      string s = table1.Rows[0][1].ToString();
      if (Convert.ToDecimal(s) > Decimal.Zero && Convert.ToDecimal(num5) > Decimal.Zero)
        str1 = (Convert.ToDecimal(s) / Convert.ToDecimal(num5)).ToString("P");
      string str3;
      if (int.Parse(s) == 1)
        str3 = ", <i>duy nhất <b style='color:red;'>" + s + "</b> lần</i> chiếm <b style='color:red;'>" + str1 + "</b>. Chi tiết các lần như sau";
      else
        str3 = " chỉ có <b style='color:red;'>" + s + "</b> lần chiếm <b style='color:red;'>" + str1 + "</b>. Chi tiết các lần như sau";
      for (int index = 0; index < dataTable2.Rows.Count; ++index)
      {
        try
        {
          dataTable2.Rows[index][3] = (object) (Convert.ToDecimal(dataTable2.Rows[index][1]) / Convert.ToDecimal(dataTable2.Rows[index][2]));
          dataTable2.Rows[index][3] = (object) Math.Round(Convert.ToDecimal(dataTable2.Rows[index][3]) * new Decimal(100), 1);
        }
        catch
        {
        }
      }
      string str4 = "";
      DataView defaultView2 = dataTable2.DefaultView;
      defaultView2.Sort = "tyleCauChay DESC";
      DataTable table2 = defaultView2.ToTable();
      int num7 = 85;
      int num8 = 75;
      for (int index = 0; index < table2.Rows.Count; ++index)
      {
        Decimal num9 = Convert.ToDecimal(table2.Rows[index][3].ToString());
        int int32_1 = Convert.ToInt32(table2.Rows[index][1].ToString());
        int int32_2 = Convert.ToInt32(table2.Rows[index][2].ToString());
        int int32_3 = Convert.ToInt32(table2.Rows[index][0].ToString());
        if (num9 >= (Decimal) num7)
        {
          string str5 = int32_1 != int32_2 ? (int32_1 != int32_2 - 1 ? "Teal" : "Blue") : "Green";
          if (int32_3 < 10)
            str4 = str4 + "<b style='color:" + str5 + ";'>0" + (object) int32_3 + "</b>";
          else
            str4 = str4 + "<b style='color:" + str5 + ";'>" + (object) int32_3 + "</b>";
          try
          {
            if (Convert.ToDecimal(table2.Rows[index + 1][3].ToString()) >= (Decimal) num7)
              str4 += ", ";
            else
              break;
          }
          catch
          {
            break;
          }
        }
      }
      if (str4 != "")
        str4 = "<b style='color:red;'>☞</b> Cầu hay chạy ở ngày " + str4 + "</br>";
      string str6 = "";
      DataView defaultView3 = table2.DefaultView;
      defaultView3.Sort = "tyleCauChay ASC";
      DataTable table3 = defaultView3.ToTable();
      int num10 = 0;
      for (int index = 0; index < table3.Rows.Count; ++index)
      {
        ++num10;
        Decimal num9 = Convert.ToDecimal(table3.Rows[index][3].ToString());
        int int32 = Convert.ToInt32(table3.Rows[index][0].ToString());
        if (num9 <= (Decimal) num8)
        {
          string str5 = "Black";
          if (int32 < 10)
            str6 = str6 + "<b style='color:" + str5 + ";'>0" + (object) int32 + "</b>";
          else
            str6 = str6 + "<b style='color:" + str5 + ";'>" + (object) int32 + "</b>";
          try
          {
            if (Convert.ToDecimal(table3.Rows[index + 1][3].ToString()) <= (Decimal) num8 && num10 < 7)
              str6 += ", ";
            else
              break;
          }
          catch
          {
            break;
          }
        }
      }
      if (str6 != "")
        str6 = "<b style='color:red;'>☞</b> Cầu ít chạy ở ngày " + str6 + "</br>";
      int num11 = int.Parse(table1.Rows[table1.Rows.Count - 1][1].ToString());
      int num12 = num5 - num11;
      Decimal num13 = new Decimal();
      if (num11 != 0 && (uint) num5 > 0U)
        num13 = Convert.ToDecimal(num11) / Convert.ToDecimal(num5);
      string str7 = "";
      Decimal num14 = new Decimal();
      string str8 = "";
      Decimal num15 = new Decimal();
      for (int index = table1.Rows.Count - 2; index > 0; --index)
      {
        if (int.Parse(table1.Rows[index][0].ToString()) <= this.khungdanh + 3)
        {
          Decimal num9 = Convert.ToDecimal(table1.Rows[index][1]) / Convert.ToDecimal(num5);
          str7 = str7 + "➣Có [<b class='vt2'>" + table1.Rows[index][1] + "</b>] lần cầu về ngày " + table1.Rows[index][0] + ", chiếm <b style='color:red;'>" + num9.ToString("P") + "</b><br>";
          num15 += num9;
          str8 = str8 + "➣Tỉ lệ chiến thắng của bạn ở ngày <b class='vt2'>" + table1.Rows[index][0] + "</b> đạt <b style='color:red;'>" + (num13 + num15).ToString("P") + "</b></br>";
        }
        else
          num14 += Convert.ToDecimal(table1.Rows[index][1]) / Convert.ToDecimal(num5);
      }
      if (num14 > Decimal.Zero)
        str7 = str7 + "<b style='color:red;'>☞</b> Tổng các ngày còn lại chiếm <b style='color:red;'>" + num14.ToString("P") + "</b><br>";
      this.thongTinCau = this.thongTinCau + "Trong <b style='color:red;'>" + (object) num5 + "</b> ngày vừa qua. Cầu <b class='vt1'>" + TbVitri.Vitri1 + "</b>-<b class='vt2'>" + TbVitri.Vitri2 + "</b> về tất cả <b style='color:red;'>" + (object) num11 + "</b> lần. Đạt <b style='color:red;'>" + num13.ToString("P") + "</b>. Vượt khung <b style='color:red;'>" + (object) num12 + "</b> lần, đỉnh điểm gan bộ số của cầu là <b style='color:red;'>" + str2 + "</b> ngày" + str3 + "</br>" + str7 + str8 + str4 + str6 + "<b style='color:red;'>☞</b> Gan lớn nhất để cầu chạy lại ngày (1) là <b style='color:red;'>" + (object) num3 + "</b> ngày";
      this.thongTinCau += "<br><b style='color:red;'>Gợi ý: </b>vào tiền muộn sẽ giúp tăng tỷ lệ chiến thắng";
      this.thongTinCau += "<br><b style='color:black;'>➣</b>Ngày cầu hay chạy được xắp xếp từ nhiều - ít ";
      this.thongTinCau += "<br><b style='color:black;'>➣</b>Ngày cầu hay chạy cũng không thể chạy mãi";
      this.thongTinCau += "<br><b style='color:black;'>➣</b>Ngày cầu ít chạy cũng không thể ít chạy mãi";
      this.thongTinCau += "<br><b style='color:black;'>➣</b>Nắm bắt được khung chạy của cầu là một yếu tố rất quan trọng để chiến thắng";
    }

    private string[] checkLotoVe(string loto1, string loto2, int soThuTuBanGhi)
    {
      string[] strArray = new string[2]{ "0", "chuave" };
      DataRow[] dataRowArray = this.dtLotoTong.Select("STT >'" + (object) soThuTuBanGhi + "'");
      int num = 0;
      if ((uint) dataRowArray.Length > 0U)
      {
        bool flag = false;
        DataTable dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        for (int index1 = 0; index1 < dataTable.Rows.Count; ++index1)
        {
          for (int index2 = 1; index2 < dataTable.Columns.Count; ++index2)
          {
            if (dataTable.Rows[index1][index2].ToString() == loto1 || dataTable.Rows[index1][index2].ToString() == loto2)
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

    private void dtTuNgay_ValueChanged(object sender, EventArgs e)
    {
      this.ngayBatDau = this.dtTuNgay.Value;
    }

    private void bg3_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDataSearch();
    }

    private void bg3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Hien_Thi_ChiTietCau(this.wbChiTietCau, this.strTong);
      this.Hien_Thi_ThongTinCau(this.wbThongtinCau, this.thongTinCau);
    }

    private void Hien_Thi_ThongTinCau(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                <style type='text/css'>\r\n                                    .vt1{\r\n                                    color:green;font-size:15px;}\r\n                                    .vt2{\r\n                                    color:blue;font-size:15px;}\r\n                                     </style>\r\n                                <title>THỐNG KÊ XỔ SỐ</title></head><body style='margin-top:-2px'><div style='width:100%;text-align:center;'>☜♥☞ º°”˜`”°º☜ <b style='color:red;font-size:13px;'>THÔNG TIN</b> ☞ º°”˜`”°☜♥☞</div>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void timeBtnThongKe_Tick(object sender, EventArgs e)
    {
      if (this.bg2.IsBusy || this.bg3.IsBusy)
      {
        this.btnThongke.Enabled = false;
        this.picLoading.Visible = true;
        this.picLoading1.Visible = true;
      }
      else
      {
        this.btnThongke.Enabled = true;
        this.picLoading.Visible = false;
        this.picLoading1.Visible = false;
      }
    }

    private void wbChiTietCau_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (!(this.wbChiTietCau.Document != (HtmlDocument) null) || !(this.wbChiTietCau.Document.Window != (HtmlWindow) null))
        return;
      this.wbChiTietCau.Document.Window.ScrollTo(this.wbChiTietCau.Document.Window.Size.Width, 0);
    }

    private void TabXemChiTietCau_Load(object sender, EventArgs e)
    {
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
    }

    private void btnThongke_Click_1(object sender, EventArgs e)
    {
      TbVitri.NumTien = this.numTien.Value;
      TbVitri.NumLui = this.numLui.Value;
      this.ClickBTN();
    }

    private void label10_Click(object sender, EventArgs e)
    {
    }

    private void label12_Click(object sender, EventArgs e)
    {
    }

    private void timerLoadForm_Tick(object sender, EventArgs e)
    {
      if (this.bg2.IsBusy)
        return;
      this.bg2.RunWorkerAsync();
      this.timerLoadForm.Stop();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabXemChiTietCau));
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.label8 = new Label();
      this.cbbVitri2 = new ComboBox();
      this.btnThongke = new Button();
      this.dtDenNgay = new DateTimePicker();
      this.dtTuNgay = new DateTimePicker();
      this.label9 = new Label();
      this.numTien = new NumericUpDown();
      this.numLui = new NumericUpDown();
      this.cbbVitri1 = new ComboBox();
      this.cbbLoto = new ComboBox();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.label14 = new Label();
      this.panel2 = new Panel();
      this.groupBox2 = new GroupBox();
      this.picLoading1 = new PictureBox();
      this.wbThongtinCau = new WebBrowser();
      this.groupBox1 = new GroupBox();
      this.webBKetQua = new WebBrowser();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.bg2 = new BackgroundWorker();
      this.bg3 = new BackgroundWorker();
      this.wbChiTietCau = new WebBrowser();
      this.timeBtnThongKe = new Timer(this.components);
      this.picLoading = new PictureBox();
      this.timer1 = new Timer(this.components);
      this.timerLoadForm = new Timer(this.components);
      this.toolTip1 = new ToolTip(this.components);
      this.groupBox3 = new GroupBox();
      this.panel1.SuspendLayout();
      this.numTien.BeginInit();
      this.numLui.BeginInit();
      this.panel2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.picLoading1).BeginInit();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.groupBox3);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 44);
      this.panel1.TabIndex = 0;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkSlateGray;
      this.label1.Location = new Point(396, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(45, 16);
      this.label1.TabIndex = 42;
      this.label1.Text = "Vị trí II";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DarkSlateGray;
      this.label8.Location = new Point(4, 16);
      this.label8.Name = "label8";
      this.label8.Size = new Size(56, 16);
      this.label8.TabIndex = 40;
      this.label8.Text = "Từ ngày";
      this.cbbVitri2.BackColor = Color.Teal;
      this.cbbVitri2.Cursor = Cursors.Hand;
      this.cbbVitri2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbVitri2.FlatStyle = FlatStyle.Popup;
      this.cbbVitri2.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbVitri2.ForeColor = Color.White;
      this.cbbVitri2.Items.AddRange(new object[107]
      {
        (object) "G0:1:1",
        (object) "G0:1:2",
        (object) "G0:1:3",
        (object) "G0:1:4",
        (object) "G0:1:5",
        (object) "G1:1:1",
        (object) "G1:1:2",
        (object) "G1:1:3",
        (object) "G1:1:4",
        (object) "G1:1:5",
        (object) "G2:1:1",
        (object) "G2:1:2",
        (object) "G2:1:3",
        (object) "G2:1:4",
        (object) "G2:1:5",
        (object) "G2:2:1",
        (object) "G2:2:2",
        (object) "G2:2:3",
        (object) "G2:2:4",
        (object) "G2:2:5",
        (object) "G3:1:1",
        (object) "G3:1:2",
        (object) "G3:1:3",
        (object) "G3:1:4",
        (object) "G3:1:5",
        (object) "G3:2:1",
        (object) "G3:2:2",
        (object) "G3:2:3",
        (object) "G3:2:4",
        (object) "G3:2:5",
        (object) "G3:3:1",
        (object) "G3:3:2",
        (object) "G3:3:3",
        (object) "G3:3:4",
        (object) "G3:3:5",
        (object) "G3:4:1",
        (object) "G3:4:2",
        (object) "G3:4:3",
        (object) "G3:4:4",
        (object) "G3:4:5",
        (object) "G3:5:1",
        (object) "G3:5:2",
        (object) "G3:5:3",
        (object) "G3:5:4",
        (object) "G3:5:5",
        (object) "G3:6:1",
        (object) "G3:6:2",
        (object) "G3:6:3",
        (object) "G3:6:4",
        (object) "G3:6:5",
        (object) "G4:1:1",
        (object) "G4:1:2",
        (object) "G4:1:3",
        (object) "G4:1:4",
        (object) "G4:2:1",
        (object) "G4:2:2",
        (object) "G4:2:3",
        (object) "G4:2:4",
        (object) "G4:3:1",
        (object) "G4:3:2",
        (object) "G4:3:3",
        (object) "G4:3:4",
        (object) "G4:4:1",
        (object) "G4:4:2",
        (object) "G4:4:3",
        (object) "G4:4:4",
        (object) "G5:1:1",
        (object) "G5:1:2",
        (object) "G5:1:3",
        (object) "G5:1:4",
        (object) "G5:2:1",
        (object) "G5:2:2",
        (object) "G5:2:3",
        (object) "G5:2:4",
        (object) "G5:3:1",
        (object) "G5:3:2",
        (object) "G5:3:3",
        (object) "G5:3:4",
        (object) "G5:4:1",
        (object) "G5:4:2",
        (object) "G5:4:3",
        (object) "G5:4:4",
        (object) "G5:5:1",
        (object) "G5:5:2",
        (object) "G5:5:3",
        (object) "G5:5:4",
        (object) "G5:6:1",
        (object) "G5:6:2",
        (object) "G5:6:3",
        (object) "G5:6:4",
        (object) "G6:1:1",
        (object) "G6:1:2",
        (object) "G6:1:3",
        (object) "G6:2:1",
        (object) "G6:2:2",
        (object) "G6:2:3",
        (object) "G6:3:1",
        (object) "G6:3:2",
        (object) "G6:3:3",
        (object) "G7:1:1",
        (object) "G7:1:2",
        (object) "G7:2:1",
        (object) "G7:2:2",
        (object) "G7:3:1",
        (object) "G7:3:2",
        (object) "G7:4:1",
        (object) "G7:4:2"
      });
      this.cbbVitri2.Location = new Point(443, 13);
      this.cbbVitri2.Name = "cbbVitri2";
      this.cbbVitri2.Size = new Size(70, 23);
      this.cbbVitri2.TabIndex = 3;
      this.toolTip1.SetToolTip((Control) this.cbbVitri2, "Vị trí số 2 của cầu");
      this.cbbVitri2.SelectedIndexChanged += new EventHandler(this.cbbVitri2_SelectedIndexChanged);
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(839, 13);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(131, 24);
      this.btnThongke.TabIndex = 7;
      this.btnThongke.Text = "XEM CHI TIẾT";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnThongke, "Xem chi tiết cầu chạy");
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click_1);
      this.dtDenNgay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtDenNgay.CalendarForeColor = Color.Red;
      this.dtDenNgay.CalendarMonthBackground = SystemColors.Info;
      this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
      this.dtDenNgay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtDenNgay.Format = DateTimePickerFormat.Custom;
      this.dtDenNgay.Location = new Point(161, 15);
      this.dtDenNgay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtDenNgay.Name = "dtDenNgay";
      this.dtDenNgay.Size = new Size(91, 21);
      this.dtDenNgay.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.dtDenNgay, "Ngày kết thúc");
      this.dtDenNgay.ValueChanged += new EventHandler(this.dtDenNgay_ValueChanged);
      this.dtTuNgay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtTuNgay.CalendarForeColor = Color.Red;
      this.dtTuNgay.CalendarMonthBackground = SystemColors.Info;
      this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
      this.dtTuNgay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtTuNgay.Format = DateTimePickerFormat.Custom;
      this.dtTuNgay.Location = new Point(60, 15);
      this.dtTuNgay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtTuNgay.Name = "dtTuNgay";
      this.dtTuNgay.Size = new Size(91, 21);
      this.dtTuNgay.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.dtTuNgay, "Ngày bắt đầu");
      this.dtTuNgay.ValueChanged += new EventHandler(this.dtTuNgay_ValueChanged);
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.DarkSlateGray;
      this.label9.Location = new Point(150, 18);
      this.label9.Name = "label9";
      this.label9.Size = new Size(12, 16);
      this.label9.TabIndex = 39;
      this.label9.Text = "-";
      this.numTien.BackColor = Color.White;
      this.numTien.BorderStyle = BorderStyle.FixedSingle;
      this.numTien.Cursor = Cursors.Hand;
      this.numTien.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTien.ForeColor = Color.Black;
      this.numTien.Location = new Point(787, 15);
      this.numTien.Maximum = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numTien.Name = "numTien";
      this.numTien.Size = new Size(43, 21);
      this.numTien.TabIndex = 6;
      this.toolTip1.SetToolTip((Control) this.numTien, "Biên độ tiến của bộ số");
      this.numTien.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numTien.ValueChanged += new EventHandler(this.numTien_ValueChanged);
      this.numLui.BackColor = Color.White;
      this.numLui.BorderStyle = BorderStyle.FixedSingle;
      this.numLui.Cursor = Cursors.Hand;
      this.numLui.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numLui.ForeColor = Color.Black;
      this.numLui.Location = new Point(709, 15);
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
      this.numLui.TabIndex = 5;
      this.toolTip1.SetToolTip((Control) this.numLui, "Biên độ lùi của bộ số");
      this.numLui.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numLui.ValueChanged += new EventHandler(this.numLui_ValueChanged);
      this.cbbVitri1.BackColor = Color.Teal;
      this.cbbVitri1.Cursor = Cursors.Hand;
      this.cbbVitri1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbVitri1.FlatStyle = FlatStyle.Popup;
      this.cbbVitri1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbVitri1.ForeColor = Color.White;
      this.cbbVitri1.Items.AddRange(new object[107]
      {
        (object) "G0:1:1",
        (object) "G0:1:2",
        (object) "G0:1:3",
        (object) "G0:1:4",
        (object) "G0:1:5",
        (object) "G1:1:1",
        (object) "G1:1:2",
        (object) "G1:1:3",
        (object) "G1:1:4",
        (object) "G1:1:5",
        (object) "G2:1:1",
        (object) "G2:1:2",
        (object) "G2:1:3",
        (object) "G2:1:4",
        (object) "G2:1:5",
        (object) "G2:2:1",
        (object) "G2:2:2",
        (object) "G2:2:3",
        (object) "G2:2:4",
        (object) "G2:2:5",
        (object) "G3:1:1",
        (object) "G3:1:2",
        (object) "G3:1:3",
        (object) "G3:1:4",
        (object) "G3:1:5",
        (object) "G3:2:1",
        (object) "G3:2:2",
        (object) "G3:2:3",
        (object) "G3:2:4",
        (object) "G3:2:5",
        (object) "G3:3:1",
        (object) "G3:3:2",
        (object) "G3:3:3",
        (object) "G3:3:4",
        (object) "G3:3:5",
        (object) "G3:4:1",
        (object) "G3:4:2",
        (object) "G3:4:3",
        (object) "G3:4:4",
        (object) "G3:4:5",
        (object) "G3:5:1",
        (object) "G3:5:2",
        (object) "G3:5:3",
        (object) "G3:5:4",
        (object) "G3:5:5",
        (object) "G3:6:1",
        (object) "G3:6:2",
        (object) "G3:6:3",
        (object) "G3:6:4",
        (object) "G3:6:5",
        (object) "G4:1:1",
        (object) "G4:1:2",
        (object) "G4:1:3",
        (object) "G4:1:4",
        (object) "G4:2:1",
        (object) "G4:2:2",
        (object) "G4:2:3",
        (object) "G4:2:4",
        (object) "G4:3:1",
        (object) "G4:3:2",
        (object) "G4:3:3",
        (object) "G4:3:4",
        (object) "G4:4:1",
        (object) "G4:4:2",
        (object) "G4:4:3",
        (object) "G4:4:4",
        (object) "G5:1:1",
        (object) "G5:1:2",
        (object) "G5:1:3",
        (object) "G5:1:4",
        (object) "G5:2:1",
        (object) "G5:2:2",
        (object) "G5:2:3",
        (object) "G5:2:4",
        (object) "G5:3:1",
        (object) "G5:3:2",
        (object) "G5:3:3",
        (object) "G5:3:4",
        (object) "G5:4:1",
        (object) "G5:4:2",
        (object) "G5:4:3",
        (object) "G5:4:4",
        (object) "G5:5:1",
        (object) "G5:5:2",
        (object) "G5:5:3",
        (object) "G5:5:4",
        (object) "G5:6:1",
        (object) "G5:6:2",
        (object) "G5:6:3",
        (object) "G5:6:4",
        (object) "G6:1:1",
        (object) "G6:1:2",
        (object) "G6:1:3",
        (object) "G6:2:1",
        (object) "G6:2:2",
        (object) "G6:2:3",
        (object) "G6:3:1",
        (object) "G6:3:2",
        (object) "G6:3:3",
        (object) "G7:1:1",
        (object) "G7:1:2",
        (object) "G7:2:1",
        (object) "G7:2:2",
        (object) "G7:3:1",
        (object) "G7:3:2",
        (object) "G7:4:1",
        (object) "G7:4:2"
      });
      this.cbbVitri1.Location = new Point(320, 13);
      this.cbbVitri1.MaxDropDownItems = 15;
      this.cbbVitri1.Name = "cbbVitri1";
      this.cbbVitri1.Size = new Size(70, 23);
      this.cbbVitri1.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.cbbVitri1, "Vị trí số 1 của cầu");
      this.cbbVitri1.SelectedIndexChanged += new EventHandler(this.CbbVitri1SelectedIndexChanged);
      this.cbbLoto.BackColor = Color.Teal;
      this.cbbLoto.Cursor = Cursors.Hand;
      this.cbbLoto.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoto.FlatStyle = FlatStyle.Popup;
      this.cbbLoto.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbLoto.ForeColor = Color.White;
      this.cbbLoto.FormattingEnabled = true;
      this.cbbLoto.Items.AddRange(new object[4]
      {
        (object) "      Cầu lô cặp",
        (object) "  Cầu lô bạch thủ",
        (object) " Cầu lô trùng đầu",
        (object) " Cầu lô trùng đuôi"
      });
      this.cbbLoto.Location = new Point(557, 13);
      this.cbbLoto.Name = "cbbLoto";
      this.cbbLoto.Size = new Size(123, 23);
      this.cbbLoto.TabIndex = 4;
      this.toolTip1.SetToolTip((Control) this.cbbLoto, "Loại cầu muốn xem của bạn");
      this.cbbLoto.SelectedIndexChanged += new EventHandler(this.cbbLoto_SelectedIndexChanged);
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.DarkSlateGray;
      this.label10.Location = new Point(757, 17);
      this.label10.Name = "label10";
      this.label10.Size = new Size(29, 16);
      this.label10.TabIndex = 34;
      this.label10.Text = "tiến";
      this.label10.Click += new EventHandler(this.label10_Click);
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.DarkSlateGray;
      this.label11.Location = new Point(276, 16);
      this.label11.Name = "label11";
      this.label11.Size = new Size(42, 16);
      this.label11.TabIndex = 35;
      this.label11.Text = "Vị trí I";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.DarkSlateGray;
      this.label12.Location = new Point(685, 17);
      this.label12.Name = "label12";
      this.label12.Size = new Size(21, 16);
      this.label12.TabIndex = 36;
      this.label12.Text = "lùi";
      this.label12.Click += new EventHandler(this.label12_Click);
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.DarkSlateGray;
      this.label14.Location = new Point(528, 17);
      this.label14.Name = "label14";
      this.label14.Size = new Size(28, 16);
      this.label14.TabIndex = 37;
      this.label14.Text = "loại";
      this.panel2.Controls.Add((Control) this.groupBox2);
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Dock = DockStyle.Left;
      this.panel2.Location = new Point(0, 44);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(364, 546);
      this.panel2.TabIndex = 1;
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.picLoading1);
      this.groupBox2.Controls.Add((Control) this.wbThongtinCau);
      this.groupBox2.Location = new Point(2, 256);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(360, 287);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.picLoading1.BackColor = Color.Transparent;
      this.picLoading1.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading1.ErrorImage = (Image) componentResourceManager.GetObject("picLoading1.ErrorImage");
      this.picLoading1.Image = (Image) componentResourceManager.GetObject("picLoading1.Image");
      this.picLoading1.InitialImage = (Image) null;
      this.picLoading1.Location = new Point(155, 188);
      this.picLoading1.Name = "picLoading1";
      this.picLoading1.Size = new Size(30, 30);
      this.picLoading1.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading1.TabIndex = 19;
      this.picLoading1.TabStop = false;
      this.wbThongtinCau.Dock = DockStyle.Fill;
      this.wbThongtinCau.Location = new Point(3, 17);
      this.wbThongtinCau.MinimumSize = new Size(20, 20);
      this.wbThongtinCau.Name = "wbThongtinCau";
      this.wbThongtinCau.Size = new Size(354, 267);
      this.wbThongtinCau.TabIndex = 2;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.webBKetQua);
      this.groupBox1.ForeColor = Color.White;
      this.groupBox1.Location = new Point(2, -4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(360, 259);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.webBKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.webBKetQua.Location = new Point(3, 17);
      this.webBKetQua.MinimumSize = new Size(20, 20);
      this.webBKetQua.Name = "webBKetQua";
      this.webBKetQua.ScrollBarsEnabled = false;
      this.webBKetQua.Size = new Size(350, 239);
      this.webBKetQua.TabIndex = 1;
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.bg2.DoWork += new DoWorkEventHandler(this.bg2_DoWork);
      this.bg2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg2_RunWorkerCompleted);
      this.bg3.DoWork += new DoWorkEventHandler(this.bg3_DoWork);
      this.bg3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg3_RunWorkerCompleted);
      this.wbChiTietCau.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbChiTietCau.Location = new Point(365, 47);
      this.wbChiTietCau.MinimumSize = new Size(20, 20);
      this.wbChiTietCau.Name = "wbChiTietCau";
      this.wbChiTietCau.Size = new Size(733, 540);
      this.wbChiTietCau.TabIndex = 2;
      this.wbChiTietCau.WebBrowserShortcutsEnabled = false;
      this.wbChiTietCau.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.wbChiTietCau_DocumentCompleted);
      this.timeBtnThongKe.Enabled = true;
      this.timeBtnThongKe.Tick += new EventHandler(this.timeBtnThongKe_Tick);
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(799, 305);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 18;
      this.picLoading.TabStop = false;
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.timerLoadForm.Interval = 200;
      this.timerLoadForm.Tick += new EventHandler(this.timerLoadForm_Tick);
      this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox3.Controls.Add((Control) this.cbbVitri1);
      this.groupBox3.Controls.Add((Control) this.label1);
      this.groupBox3.Controls.Add((Control) this.label14);
      this.groupBox3.Controls.Add((Control) this.label12);
      this.groupBox3.Controls.Add((Control) this.label8);
      this.groupBox3.Controls.Add((Control) this.label11);
      this.groupBox3.Controls.Add((Control) this.cbbVitri2);
      this.groupBox3.Controls.Add((Control) this.label10);
      this.groupBox3.Controls.Add((Control) this.btnThongke);
      this.groupBox3.Controls.Add((Control) this.cbbLoto);
      this.groupBox3.Controls.Add((Control) this.dtDenNgay);
      this.groupBox3.Controls.Add((Control) this.numLui);
      this.groupBox3.Controls.Add((Control) this.dtTuNgay);
      this.groupBox3.Controls.Add((Control) this.numTien);
      this.groupBox3.Controls.Add((Control) this.label9);
      this.groupBox3.Location = new Point(2, -1);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(1097, 43);
      this.groupBox3.TabIndex = 43;
      this.groupBox3.TabStop = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.wbChiTietCau);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabXemChiTietCau);
      this.Size = new Size(1100, 590);
      this.Load += new EventHandler(this.TabXemChiTietCau_Load);
      this.panel1.ResumeLayout(false);
      this.numTien.EndInit();
      this.numLui.EndInit();
      this.panel2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading1).EndInit();
      this.groupBox1.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
