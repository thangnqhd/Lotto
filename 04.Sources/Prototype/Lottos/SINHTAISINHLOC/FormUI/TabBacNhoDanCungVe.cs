// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabBacNhoDanCungVe
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
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabBacNhoDanCungVe : UserControl
  {
    private string boSoLoto = "2";
    private IContainer components = (IContainer) null;
    public static Timer Timer;
    private string _strChuoiLotoSau;
    private readonly Tbloto _objLoto;
    private DataTable _dtTong;
    public DataTable LoToNgaySau;
    private DataTable _dtLoToVeNgaySau;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoCap> TinhNgayveLoCap;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoBachThu> TinhNgayveLoBachThu;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDau> TinhNgayveLoTrungDau;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi> TinhNgayveLoTrungDuoi;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDauTheoLoVe> TinhNgayveLoTrungDauTheoLoVe;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoiTheoLoVe> TinhNgayveLoTrungDuoiTheoLoVe;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoCapTheoLoVe> TinhNgayveLoCapTheoLoVe;
    public List<TabBacNhoDanCungVe.TinhNgayVeLoBachThuTheoLoVe> TinhNgayveLoBachThuTheoLoVe;
    private DataTable _lotoVeTruocKhiLotoVe;
    private DataTable _dtLotoVeNgay;
    private string strTong;
    private int _khungDanh;
    private DateTime ngayVeCuoiCung;
    private ArrayList _arrLoto;
    private WebBrowser webBrowser1;
    private Panel panel2;
    private RadioButton rdTrungDuoi;
    private RadioButton rdTrungDau;
    private DateTimePicker dtNgayBatDau;
    private Label label2;
    private Label label1;
    private Label label3;
    private RadioButton rdBachThu;
    private RadioButton rdCap;
    private BackgroundWorker bgGetNewDay;
    private BackgroundWorker bgGetDataTong;
    private BackgroundWorker bgXuLy;
    private BunifuMaterialTextbox txtLoto;
    private BunifuElipse bunifuElipse1;
    private BackgroundWorker bgTinhNgayVe;
    private DateTimePicker dtNgayKetThuc;
    private PictureBox picLoading;
    private Timer timerLoading;
    private Button btnXem;
    private ToolTip toolTip1;
    private GroupBox groupBox1;

    public TabBacNhoDanCungVe()
    {
      TabBacNhoDanCungVe.Timer = new Timer();
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      TabBacNhoDanCungVe.Timer.Tick += new EventHandler(this.timer_Tick);
      this._objLoto = new Tbloto();
      this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
      this.webBrowser1.AllowWebBrowserDrop = false;
      if (!this.bgGetNewDay.IsBusy)
        this.bgGetNewDay.RunWorkerAsync();
      this.Hien_Thi_KetQua(this.webBrowser1, "");
    }

    public void timer_Tick(object sender, EventArgs e)
    {
      if (!this.bgTinhNgayVe.IsBusy)
        this.bgTinhNgayVe.RunWorkerAsync();
      TabBacNhoDanCungVe.Timer.Stop();
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.StrCss1 + "<title>THỐNG KÊ XỔ SỐ</title></head><body  oncontextmenu='return false;' style='font-family:Verdana;'><div class='container' style='margin-right:15px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ></div><div class='panel-body'><ul class='media-list'><li class='media'>" + strHtml + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void KetQuaDateNew()
    {
      FMain.ObjConfigBacNho = new tbConfigBacNho();
      FMain.ObjConfigBacNho = FMain.ObjConfigBacNho.GetInfor(TbUser.Tbuser.Stt);
      this.LoadRadioButton();
    }

    private void GetDataLoVeNgaySau(DateTime ngayVeCuoiCung, tbConfigBacNho objBacNho)
    {
      int num = objBacNho.KhungDanhLoCapNuoi;
      if (objBacNho.KhungDanhBachThuNuoi > objBacNho.KhungDanhLoCapNuoi)
        num = objBacNho.KhungDanhBachThuNuoi;
      this.LoToNgaySau = new DataTable();
      this.LoToNgaySau = this._objLoto.GetLotoByNgayThangSoBanGhi(ngayVeCuoiCung, num + 2);
    }

    private void TimNgayVeLoTrungDau(int soBanGhi)
    {
      this.TinhNgayveLoTrungDau = new List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDau>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoTrungDau ngayVeLoTrungDau = new TabBacNhoDanCungVe.TinhNgayVeLoTrungDau();
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string trungDau = this.BienDoiLoToTrungDau(loto, FMain.ObjConfigBacNho.BiendoTrungDau);
        string str1 = "";
        string str2 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str1 = loto;
          str2 = trungDau;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (loto == str5)
            {
              str1 += "*";
              flag1 = true;
            }
            if (trungDau == str5)
            {
              str2 += "*";
              flag2 = true;
            }
          }
          if (flag1 | flag2)
          {
            str4 = "Black";
            if (index2 + 1 <= soBanGhi)
              str4 = "Red";
            str3 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag2)
          str2 = "";
        if (!flag1)
          str1 = "";
        if (!flag1 && !flag2)
          str3 = num >= soBanGhi ? " Xịt" : " Chưa về";
        ngayVeLoTrungDau.Loto1 = loto;
        ngayVeLoTrungDau.Loto2 = trungDau;
        ngayVeLoTrungDau.VeNgay = str3;
        ngayVeLoTrungDau.MauSac = str4;
        ngayVeLoTrungDau.SoNhayVeLoto1 = str1;
        ngayVeLoTrungDau.SoNhayVeLoto2 = str2;
        this.TinhNgayveLoTrungDau.Add(ngayVeLoTrungDau);
      }
    }

    private void TimNgayVeLoTrungDuoi(int soBanGhi)
    {
      this.TinhNgayveLoTrungDuoi = new List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi = new TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi();
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string trungDuoi = this.BienDoiLoToTrungDuoi(loto, FMain.ObjConfigBacNho.BiendoTrungDuoi);
        string str1 = "";
        string str2 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str1 = loto;
          str2 = trungDuoi;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (loto == str5)
            {
              str1 += "*";
              flag1 = true;
            }
            if (trungDuoi == str5)
            {
              str2 += "*";
              flag2 = true;
            }
          }
          if (flag1 | flag2)
          {
            str4 = "Black";
            if (index2 + 1 <= soBanGhi)
              str4 = "Red";
            str3 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag2)
          str2 = "";
        if (!flag1)
          str1 = "";
        if (!flag1 && !flag2)
          str3 = num >= soBanGhi ? " Xịt" : " Chưa về";
        ngayVeLoTrungDuoi.Loto1 = loto;
        ngayVeLoTrungDuoi.Loto2 = trungDuoi;
        ngayVeLoTrungDuoi.VeNgay = str3;
        ngayVeLoTrungDuoi.MauSac = str4;
        ngayVeLoTrungDuoi.SoNhayVeLoto1 = str1;
        ngayVeLoTrungDuoi.SoNhayVeLoto2 = str2;
        this.TinhNgayveLoTrungDuoi.Add(ngayVeLoTrungDuoi);
      }
    }

    private void TimNgayVeLoCap(int soBanGhi)
    {
      this.TinhNgayveLoCap = new List<TabBacNhoDanCungVe.TinhNgayVeLoCap>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoCap tinhNgayVeLoCap = new TabBacNhoDanCungVe.TinhNgayVeLoCap();
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string str1 = this._objLoto.CheckLotoCap(loto);
        string str2 = "";
        string str3 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str4 = " Chưa về";
        string str5 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str2 = loto;
          str3 = str1;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str6 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (loto == str6)
            {
              str2 += "*";
              flag1 = true;
            }
            if (str1 == str6)
            {
              str3 += "*";
              flag2 = true;
            }
          }
          if (flag1 | flag2)
          {
            str5 = "Black";
            if (index2 + 1 <= soBanGhi)
              str5 = "Red";
            str4 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag2)
          str3 = "";
        if (!flag1)
          str2 = "";
        if (!flag1 && !flag2)
          str4 = num >= soBanGhi ? " Xịt" : " Chưa về";
        tinhNgayVeLoCap.LotoXuoi = loto;
        tinhNgayVeLoCap.Lotolon = str1;
        tinhNgayVeLoCap.VeNgay = str4;
        tinhNgayVeLoCap.MauSac = str5;
        tinhNgayVeLoCap.SoNhayVeLotoXuoi = str2;
        tinhNgayVeLoCap.SoNhayVeLotoLon = str3;
        this.TinhNgayveLoCap.Add(tinhNgayVeLoCap);
      }
    }

    private void TimNgayVeLoBachThu(int soBanGhi)
    {
      this.TinhNgayveLoBachThu = new List<TabBacNhoDanCungVe.TinhNgayVeLoBachThu>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoBachThu tinhNgayVeLoBachThu = new TabBacNhoDanCungVe.TinhNgayVeLoBachThu();
        string str1 = index1.ToString();
        if (index1 < 10)
          str1 = "0" + index1.ToString();
        string str2 = "";
        bool flag = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str2 = str1;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (str1 == str5)
            {
              str2 += "*";
              flag = true;
            }
          }
          if (flag)
          {
            if (index2 + 1 <= soBanGhi)
              str4 = "Red";
            str3 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag)
          str2 = "";
        if (!flag)
          str3 = num < soBanGhi ? " Chưa về" : " Xịt";
        tinhNgayVeLoBachThu.LotoXuoi = str1;
        tinhNgayVeLoBachThu.VeNgay = str3;
        tinhNgayVeLoBachThu.MauSac = str4;
        tinhNgayVeLoBachThu.SoNhayVeLotoXuoi = str2;
        this.TinhNgayveLoBachThu.Add(tinhNgayVeLoBachThu);
      }
    }

    private void TimNgayVeLoTrungDauTheoLoVe(int soBanGhi)
    {
      this.TinhNgayveLoTrungDau = new List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDau>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoTrungDau ngayVeLoTrungDau = new TabBacNhoDanCungVe.TinhNgayVeLoTrungDau();
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string trungDau = this.BienDoiLoToTrungDau(loto, FMain.ObjConfigBacNho.BiendoTrungDau);
        string str1 = "";
        string str2 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str1 = loto;
          str2 = trungDau;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (loto == str5)
            {
              str1 += "*";
              flag1 = true;
            }
            if (trungDau == str5)
            {
              str2 += "*";
              flag2 = true;
            }
          }
          if (flag1 | flag2)
          {
            str4 = "Black";
            if (index2 + 1 <= soBanGhi)
              str4 = "Red";
            str3 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag2)
          str2 = "";
        if (!flag1)
          str1 = "";
        if (!flag1 && !flag2)
          str3 = num >= soBanGhi ? " Xịt" : " Chưa về";
        ngayVeLoTrungDau.Loto1 = loto;
        ngayVeLoTrungDau.Loto2 = trungDau;
        ngayVeLoTrungDau.VeNgay = str3;
        ngayVeLoTrungDau.MauSac = str4;
        ngayVeLoTrungDau.SoNhayVeLoto1 = str1;
        ngayVeLoTrungDau.SoNhayVeLoto2 = str2;
        this.TinhNgayveLoTrungDau.Add(ngayVeLoTrungDau);
      }
    }

    private void TimNgayVeLoTrungDuoiTheoLoVe(int soBanGhi)
    {
      this.TinhNgayveLoTrungDuoi = new List<TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi = new TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi();
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string trungDuoi = this.BienDoiLoToTrungDuoi(loto, FMain.ObjConfigBacNho.BiendoTrungDuoi);
        string str1 = "";
        string str2 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str1 = loto;
          str2 = trungDuoi;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (loto == str5)
            {
              str1 += "*";
              flag1 = true;
            }
            if (trungDuoi == str5)
            {
              str2 += "*";
              flag2 = true;
            }
          }
          if (flag1 | flag2)
          {
            str4 = "Black";
            if (index2 + 1 <= soBanGhi)
              str4 = "Red";
            str3 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag2)
          str2 = "";
        if (!flag1)
          str1 = "";
        if (!flag1 && !flag2)
          str3 = num >= soBanGhi ? " Xịt" : " Chưa về";
        ngayVeLoTrungDuoi.Loto1 = loto;
        ngayVeLoTrungDuoi.Loto2 = trungDuoi;
        ngayVeLoTrungDuoi.VeNgay = str3;
        ngayVeLoTrungDuoi.MauSac = str4;
        ngayVeLoTrungDuoi.SoNhayVeLoto1 = str1;
        ngayVeLoTrungDuoi.SoNhayVeLoto2 = str2;
        this.TinhNgayveLoTrungDuoi.Add(ngayVeLoTrungDuoi);
      }
    }

    private void TimNgayVeLoCapTheoLoVe(int soBanGhi)
    {
      this.TinhNgayveLoCap = new List<TabBacNhoDanCungVe.TinhNgayVeLoCap>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoCap tinhNgayVeLoCap = new TabBacNhoDanCungVe.TinhNgayVeLoCap();
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string str1 = this._objLoto.CheckLotoCap(loto);
        string str2 = "";
        string str3 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str4 = " Chưa về";
        string str5 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str2 = loto;
          str3 = str1;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str6 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (loto == str6)
            {
              str2 += "*";
              flag1 = true;
            }
            if (str1 == str6)
            {
              str3 += "*";
              flag2 = true;
            }
          }
          if (flag1 | flag2)
          {
            str5 = "Black";
            if (index2 + 1 <= soBanGhi)
              str5 = "Red";
            str4 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag2)
          str3 = "";
        if (!flag1)
          str2 = "";
        if (!flag1 && !flag2)
          str4 = num >= soBanGhi ? " Xịt" : " Chưa về";
        tinhNgayVeLoCap.LotoXuoi = loto;
        tinhNgayVeLoCap.Lotolon = str1;
        tinhNgayVeLoCap.VeNgay = str4;
        tinhNgayVeLoCap.MauSac = str5;
        tinhNgayVeLoCap.SoNhayVeLotoXuoi = str2;
        tinhNgayVeLoCap.SoNhayVeLotoLon = str3;
        this.TinhNgayveLoCap.Add(tinhNgayVeLoCap);
      }
    }

    private void TimNgayVeLoBachThuTheoLoVe(int soBanGhi)
    {
      this.TinhNgayveLoBachThu = new List<TabBacNhoDanCungVe.TinhNgayVeLoBachThu>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoDanCungVe.TinhNgayVeLoBachThu tinhNgayVeLoBachThu = new TabBacNhoDanCungVe.TinhNgayVeLoBachThu();
        string str1 = index1.ToString();
        if (index1 < 10)
          str1 = "0" + index1.ToString();
        string str2 = "";
        bool flag = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.LoToNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str2 = str1;
          for (int index3 = 2; index3 < this.LoToNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.LoToNgaySau.Rows[index2][index3].ToString();
            if (str1 == str5)
            {
              str2 += "*";
              flag = true;
            }
          }
          if (flag)
          {
            if (index2 + 1 <= soBanGhi)
              str4 = "Red";
            str3 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag)
          str2 = "";
        if (!flag)
          str3 = num < soBanGhi ? " Chưa về" : " Xịt";
        tinhNgayVeLoBachThu.LotoXuoi = str1;
        tinhNgayVeLoBachThu.VeNgay = str3;
        tinhNgayVeLoBachThu.MauSac = str4;
        tinhNgayVeLoBachThu.SoNhayVeLotoXuoi = str2;
        this.TinhNgayveLoBachThu.Add(tinhNgayVeLoBachThu);
      }
    }

    private void LoadRadioButton()
    {
      if (this.rdCap.Checked)
      {
        this._strChuoiLotoSau = "Loto [<b style='color:red;'>  Cặp  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhLoCapNuoi + " ngày sau đó :</b>";
        this._dtLoToVeNgaySau = this.TaoBangLoCap(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
        this._lotoVeTruocKhiLotoVe = this._dtLoToVeNgaySau;
        this._khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      }
      if (this.rdBachThu.Checked)
      {
        this._strChuoiLotoSau = "Loto [<b style='color:red;'>  Bạch Thủ  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhBachThuNuoi + " ngày sau đó :</b>";
        this._dtLoToVeNgaySau = this.TaoBangLoBachThu(FMain.ObjConfigBacNho.KhungDanhBachThuNuoi);
        this._lotoVeTruocKhiLotoVe = this._dtLoToVeNgaySau;
        this._khungDanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
      }
      if (this.rdTrungDau.Checked)
      {
        this._strChuoiLotoSau = "Loto [<b style='color:red;'>  Trùng Đầu  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhLoCapNuoi + " ngày sau đó :</b>";
        this._dtLoToVeNgaySau = this.TaoBangLoTrungDau(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDau);
        this._lotoVeTruocKhiLotoVe = this._dtLoToVeNgaySau;
        this._khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      }
      if (!this.rdTrungDuoi.Checked)
        return;
      this._strChuoiLotoSau = "Loto [<b style='color:red;'>  Trùng Đuôi  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhLoCapNuoi + " ngày sau đó :</b>";
      this._dtLoToVeNgaySau = this.TaoBangLoTrungDuoi(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      this._lotoVeTruocKhiLotoVe = this._dtLoToVeNgaySau;
      this._khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
    }

    private void GetDataTong()
    {
      this._dtTong = new DataTable();
      this._dtTong = this._objLoto.GetLotoByNgayThang(this.dtNgayBatDau.Value, this.dtNgayKetThuc.Value);
    }

    private void XuLyCacNgayCungVe(string boSo)
    {
      this.strTong = "";
      string chuoiLoto = "";
      if (this._dtTong.Rows.Count <= 0)
        return;
      this._dtLotoVeNgay = new DataTable();
      string filterExpression = "";
      if (this._arrLoto.Count > 0)
      {
        filterExpression = "";
        for (int index = 0; index < this._arrLoto.Count; ++index)
        {
          string str = this._arrLoto[index].ToString();
          chuoiLoto += str;
          filterExpression = filterExpression + "(G0='" + str + "' or G1='" + str + "' or G21='" + str + "' or G22='" + str + "'or G31='" + str + "' or G32='" + str + "'or G33='" + str + "'or G34='" + str + "'or G35='" + str + "'or G36='" + str + "'or G41='" + str + "'or G42='" + str + "'or G43='" + str + "'or G44='" + str + "'or G51='" + str + "'or G52='" + str + "'or G53='" + str + "'or G54='" + str + "'or G55='" + str + "'or G56='" + str + "'or G61='" + str + "'or G62='" + str + "'or G63='" + str + "'or G71='" + str + "'or G72='" + str + "'or G73='" + str + "'or G74='" + str + "')";
          if (index + 1 < this._arrLoto.Count)
          {
            filterExpression += "and";
            chuoiLoto += "-";
          }
        }
      }
      DataRow[] dataRowArray = this._dtTong.Select(filterExpression);
      if ((uint) dataRowArray.Length > 0U)
      {
        this._dtLotoVeNgay = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        DataView defaultView = this._dtLotoVeNgay.DefaultView;
        defaultView.Sort = "STT ASC";
        this._dtLotoVeNgay = defaultView.ToTable();
        this.ngayVeCuoiCung = DateTime.Parse(this._dtLotoVeNgay.Rows[this._dtLotoVeNgay.Rows.Count - 1]["clngaythang"].ToString());
        this.GetDataLoVeNgaySau(this.ngayVeCuoiCung, FMain.ObjConfigBacNho);
        this.RadioCheck();
        this.strTong += this.XuLyDuLieuCacLanVe(this._dtLotoVeNgay, chuoiLoto);
      }
    }

    private string XuLyDuLieuCacLanVe(DataTable dtLotoVe, string chuoiLoto)
    {
      string str1 = "";
      float num = (float) (dtLotoVe.Rows.Count - 1);
      if (this.dtNgayKetThuc.Value >= this.ngayVeCuoiCung.AddDays(3.0))
        num = (float) dtLotoVe.Rows.Count;
      string str2 = str1 + "<b style='color:rgb(43, 60, 80);font-size:13px;'>☞ Từ " + this.dtNgayBatDau.Value.ToString("dd/MM/yyyy") + " đến ngày " + this.dtNgayKetThuc.Value.ToString("dd/MM/yyyy") + ", Lô [<b style='color:red;'> " + chuoiLoto + " </b>] về cùng nhau tất cả (<b style='color:red;'>  " + (object) num + "  </b>) lần. Không tính ngày về gần nhất. " + this._strChuoiLotoSau + "</br>";
      for (int index = 0; (double) index < (double) num; ++index)
        this.XuLyLoToVeNgaySau(int.Parse(dtLotoVe.Rows[index]["STT"].ToString()), this._khungDanh);
      DataView defaultView = this._dtLoToVeNgaySau.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this._dtLoToVeNgaySau = defaultView.ToTable();
      for (int index1 = 0; index1 < FMain.ObjConfigBacNho.SoBanGhi; ++index1)
      {
        string loto1 = this._dtLoToVeNgaySau.Rows[index1]["loto1"].ToString();
        string loto2 = this._dtLoToVeNgaySau.Rows[index1]["loto2"].ToString();
        string s = this._dtLoToVeNgaySau.Rows[index1]["tongSOLAN"].ToString();
        string str3 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) num * 100.0, 1) + "%</b>]";
        string str4 = loto1;
        if (loto1 != loto2)
          str4 = loto1 + "-" + loto2;
        string str5 = str2 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + str4 + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str3 + ". Trong đó ";
        for (int index2 = 0; index2 < this._khungDanh; ++index2)
          str5 = str5 + " <b>" + this._dtLoToVeNgaySau.Rows[index1][index2 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index2 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgay(loto1, loto2);
        str2 = str5 + "<br>";
      }
      return str2;
    }

    private void XuLyLoToVeNgaySau(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this._dtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtLoToVeNgaySau.Rows.Count; ++index1)
      {
        string str1 = this._dtLoToVeNgaySau.Rows[index1][0].ToString();
        string str2 = this._dtLoToVeNgaySau.Rows[index1][1].ToString();
        bool flag = false;
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str3 != "")
            {
              if (str1 == str3 || str2 == str3)
              {
                index2 = index3 + 2;
                flag = true;
                break;
              }
            }
            else
              break;
          }
          if (flag)
            break;
        }
        if (flag)
        {
          this._dtLoToVeNgaySau.Rows[index1][index2] = (object) (int.Parse(this._dtLoToVeNgaySau.Rows[index1][index2].ToString()) + 1);
          this._dtLoToVeNgaySau.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this._dtLoToVeNgaySau.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgay(string loto1, string loto2)
    {
      string str1 = "";
      if (this.rdCap.Checked)
      {
        foreach (TabBacNhoDanCungVe.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
        {
          if (tinhNgayVeLoCap.LotoXuoi == loto1 || tinhNgayVeLoCap.Lotolon == loto2)
          {
            string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      if (this.rdBachThu.Checked)
      {
        foreach (TabBacNhoDanCungVe.TinhNgayVeLoBachThu tinhNgayVeLoBachThu in this.TinhNgayveLoBachThu)
        {
          if (tinhNgayVeLoBachThu.LotoXuoi == loto1)
          {
            string str2 = tinhNgayVeLoBachThu.SoNhayVeLotoXuoi;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoBachThu.MauSac + ";'>" + tinhNgayVeLoBachThu.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      if (this.rdTrungDau.Checked)
      {
        foreach (TabBacNhoDanCungVe.TinhNgayVeLoTrungDau ngayVeLoTrungDau in this.TinhNgayveLoTrungDau)
        {
          if (ngayVeLoTrungDau.Loto1 == loto1 && ngayVeLoTrungDau.Loto2 == loto2)
          {
            string str2 = ngayVeLoTrungDau.SoNhayVeLoto1 + ngayVeLoTrungDau.SoNhayVeLoto2;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + ngayVeLoTrungDau.MauSac + ";'>" + ngayVeLoTrungDau.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      if (this.rdTrungDuoi.Checked)
      {
        foreach (TabBacNhoDanCungVe.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi in this.TinhNgayveLoTrungDuoi)
        {
          if (ngayVeLoTrungDuoi.Loto1 == loto1 && ngayVeLoTrungDuoi.Loto2 == loto2)
          {
            string str2 = ngayVeLoTrungDuoi.SoNhayVeLoto1 + ngayVeLoTrungDuoi.SoNhayVeLoto2;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + ngayVeLoTrungDuoi.MauSac + ";'>" + ngayVeLoTrungDuoi.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      return str1;
    }

    private DataTable TaoBangLoCap(int khungDanh)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("loto1", typeof (string));
      dataTable.Columns.Add("loto2", typeof (string));
      for (int index = 1; index < khungDanh + 1; ++index)
        dataTable.Columns.Add("ngay" + (object) index ?? "", typeof (int));
      dataTable.Columns.Add("tongSOLAN", typeof (int));
      for (int index1 = 0; index1 < 100; ++index1)
      {
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string str1 = this._objLoto.CheckLotoCap(loto);
        if (dataTable.Rows.Count > 0)
        {
          bool flag = true;
          for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
          {
            string str2 = dataTable.Rows[index2][0].ToString();
            string str3 = dataTable.Rows[index2][1].ToString();
            if (str2 == loto || str3 == loto)
            {
              flag = false;
              break;
            }
          }
          if (flag)
          {
            DataRow row = dataTable.NewRow();
            row[0] = (object) loto;
            row[1] = (object) str1;
            for (int index2 = 2; index2 < khungDanh + 2; ++index2)
              row[index2] = (object) "0";
            row["tongSOLAN"] = (object) "0";
            dataTable.Rows.Add(row);
          }
        }
        else
        {
          DataRow row = dataTable.NewRow();
          row[0] = (object) loto;
          row[1] = (object) str1;
          for (int index2 = 2; index2 < khungDanh + 2; ++index2)
            row[index2] = (object) "0";
          row["tongSOLAN"] = (object) "0";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private DataTable TaoBangLoBachThu(int khungDanh)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("loto1", typeof (string));
      dataTable.Columns.Add("loto2", typeof (string));
      for (int index = 1; index < khungDanh + 1; ++index)
        dataTable.Columns.Add("ngay" + (object) index ?? "", typeof (int));
      dataTable.Columns.Add("tongSOLAN", typeof (int));
      for (int index1 = 0; index1 < 100; ++index1)
      {
        string str = index1.ToString();
        if (index1 < 10)
          str = "0" + index1.ToString();
        DataRow row = dataTable.NewRow();
        row[0] = (object) str;
        row[1] = (object) str;
        for (int index2 = 2; index2 < khungDanh + 2; ++index2)
          row[index2] = (object) "0";
        row["tongSOLAN"] = (object) "0";
        dataTable.Rows.Add(row);
      }
      return dataTable;
    }

    private DataTable TaoBangLoTrungDau(int khungDanh, int bienDo)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("loto1", typeof (string));
      dataTable.Columns.Add("loto2", typeof (string));
      for (int index = 1; index < khungDanh + 1; ++index)
        dataTable.Columns.Add("ngay" + (object) index ?? "", typeof (int));
      dataTable.Columns.Add("tongSOLAN", typeof (int));
      for (int index1 = 0; index1 < 100; ++index1)
      {
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string trungDau = this.BienDoiLoToTrungDau(loto, bienDo);
        if (!(trungDau == ""))
        {
          DataRow row = dataTable.NewRow();
          row[0] = (object) loto;
          row[1] = (object) trungDau;
          for (int index2 = 2; index2 < khungDanh + 2; ++index2)
            row[index2] = (object) "0";
          row["tongSOLAN"] = (object) "0";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private DataTable TaoBangLoTrungDuoi(int khungDanh, int bienDo)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("loto1", typeof (string));
      dataTable.Columns.Add("loto2", typeof (string));
      for (int index = 1; index < khungDanh + 1; ++index)
        dataTable.Columns.Add("ngay" + (object) index ?? "", typeof (int));
      dataTable.Columns.Add("tongSOLAN", typeof (int));
      for (int index1 = 0; index1 < 100; ++index1)
      {
        string loto = index1.ToString();
        if (index1 < 10)
          loto = "0" + index1.ToString();
        string trungDuoi = this.BienDoiLoToTrungDuoi(loto, bienDo);
        if (!(trungDuoi == ""))
        {
          DataRow row = dataTable.NewRow();
          row[0] = (object) loto;
          row[1] = (object) trungDuoi;
          for (int index2 = 2; index2 < khungDanh + 2; ++index2)
            row[index2] = (object) "0";
          row["tongSOLAN"] = (object) "0";
          dataTable.Rows.Add(row);
        }
      }
      return dataTable;
    }

    private string BienDoiLoToTrungDau(string loto, int bienDo)
    {
      string str = (int.Parse(loto) + bienDo).ToString();
      if (str.Length < 2)
        str = "0" + str;
      if (loto.ToString().Substring(0, 1) != str.Substring(0, 1))
        str = "";
      return str;
    }

    private string BienDoiLoToTrungDuoi(string loto, int bienDo)
    {
      string s = (int.Parse(loto.Substring(0, 1)) + bienDo).ToString() + loto.Substring(1, 1);
      if (loto.ToString().Substring(1, 1) != s.Substring(1, 1))
        s = "";
      else if (int.Parse(s) > 99)
        s = "";
      return s;
    }

    private void bgGetNewDay_DoWork(object sender, DoWorkEventArgs e)
    {
      this.KetQuaDateNew();
    }

    private void bgGetNewDay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.dtNgayBatDau.Value = FMain.NgayKetQuaMoiNhat.AddMonths(-FMain.ObjConfigBacNho.DanCungVe);
      this.dtNgayKetThuc.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void dtNgayKetThuc_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtNgayKetThuc.Value > FMain.NgayKetQuaMoiNhat)
        this.dtNgayKetThuc.Value = FMain.NgayKetQuaMoiNhat;
      this.dtNgayBatDau.Value = this.dtNgayKetThuc.Value.AddMonths(-FMain.ObjConfigBacNho.DanCungVe);
    }

    private void dtNgayBatDau_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayBatDau.Value >= this.dtNgayKetThuc.Value))
        return;
      this.dtNgayBatDau.Value = this.dtNgayKetThuc.Value.AddMonths(-FMain.ObjConfigBacNho.DanCungVe);
    }

    private string Get_Str_Loto(string strTxtLoto)
    {
      string str = strTxtLoto;
      string empty = string.Empty;
      int length = 2;
      for (int index = 0; index < str.Length; ++index)
      {
        if (char.IsDigit(str[index]))
          empty += str[index].ToString();
      }
      if (empty.Length >= length)
      {
        str = "";
        int startIndex = 0;
        while (startIndex < empty.Length)
        {
          try
          {
            if (empty.Substring(startIndex, length).Length % length == 0)
            {
              str += empty.Substring(startIndex, length);
              this._arrLoto.Add((object) empty.Substring(startIndex, length));
            }
            if (empty.Substring(startIndex + length, length).Length % length == 0)
              str += ",";
          }
          catch
          {
            break;
          }
          startIndex += length;
        }
      }
      return str;
    }

    private void bgGetDataTong_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDataTong();
    }

    private void bgGetDataTong_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.bgXuLy.IsBusy)
        return;
      this.bgXuLy.RunWorkerAsync();
    }

    private void bgXuLy_DoWork(object sender, DoWorkEventArgs e)
    {
      this.XuLyCacNgayCungVe(this.boSoLoto);
    }

    private void bgXuLy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      string strHtml = "";
      if (this.strTong.Length > 0)
        strHtml = strHtml + "<br>" + "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ DÀN LOTO CÙNG VỀ </b>☞ º°”˜`”°☜♥☞</div>" + "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>" + "<span style='font-size:13px;'>+Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>con lô bất kỳ</b> (những bộ số bạn kiểm tra) cùng về , thì những con lô, cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Cấu hình <b style='color:red;'>khung lô bạch thủ nuôi</b> để kiểm tra những con lô bạch thủ hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>" + "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>" + this.strTong;
      this.Hien_Thi_KetQua(this.webBrowser1, strHtml);
    }

    private void bgTinhNgayVe_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void RadioCheck()
    {
      if (this.rdCap.Checked)
        this.TimNgayVeLoCap(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
      if (this.rdBachThu.Checked)
        this.TimNgayVeLoBachThu(FMain.ObjConfigBacNho.KhungDanhBachThuNuoi);
      if (this.rdTrungDau.Checked)
        this.TimNgayVeLoTrungDau(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
      if (!this.rdTrungDuoi.Checked)
        return;
      this.TimNgayVeLoTrungDuoi(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
    }

    private void TimerLoadingTick(object sender, EventArgs e)
    {
      if (this.bgGetDataTong.IsBusy || this.bgGetNewDay.IsBusy || this.bgXuLy.IsBusy || this.bgTinhNgayVe.IsBusy)
      {
        this.picLoading.Visible = true;
        this.btnXem.Enabled = false;
      }
      else
      {
        this.picLoading.Visible = false;
        this.btnXem.Enabled = true;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Hien_Thi_KetQua(this.webBrowser1, "");
      if (this.txtLoto.Text.Length >= int.Parse(this.boSoLoto))
      {
        this._arrLoto = new ArrayList();
        this.txtLoto.Text = this.Get_Str_Loto(this.txtLoto.Text);
        this.LoadRadioButton();
        if (this.bgGetNewDay.IsBusy || this.bgGetDataTong.IsBusy || this.bgTinhNgayVe.IsBusy)
          return;
        this.bgGetDataTong.RunWorkerAsync();
      }
      else
        this.txtLoto.Focus();
    }

    private void txtLoto_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnXem.PerformClick();
    }

    private void rdCap_CheckedChanged(object sender, EventArgs e)
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

    private void txtLoto_OnValueChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabBacNhoDanCungVe));
      this.webBrowser1 = new WebBrowser();
      this.panel2 = new Panel();
      this.groupBox1 = new GroupBox();
      this.dtNgayBatDau = new DateTimePicker();
      this.btnXem = new Button();
      this.label1 = new Label();
      this.txtLoto = new BunifuMaterialTextbox();
      this.label3 = new Label();
      this.rdBachThu = new RadioButton();
      this.label2 = new Label();
      this.rdCap = new RadioButton();
      this.dtNgayKetThuc = new DateTimePicker();
      this.rdTrungDuoi = new RadioButton();
      this.rdTrungDau = new RadioButton();
      this.bgGetNewDay = new BackgroundWorker();
      this.bgGetDataTong = new BackgroundWorker();
      this.bgXuLy = new BackgroundWorker();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.bgTinhNgayVe = new BackgroundWorker();
      this.picLoading = new PictureBox();
      this.timerLoading = new Timer(this.components);
      this.toolTip1 = new ToolTip(this.components);
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.webBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.webBrowser1.Location = new Point(0, 2);
      this.webBrowser1.MinimumSize = new Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new Size(1115, 590);
      this.webBrowser1.TabIndex = 2;
      this.panel2.BackColor = Color.White;
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.panel2.Location = new Point(0, 0);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 46);
      this.panel2.TabIndex = 15;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.dtNgayBatDau);
      this.groupBox1.Controls.Add((Control) this.btnXem);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.txtLoto);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.rdBachThu);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.rdCap);
      this.groupBox1.Controls.Add((Control) this.dtNgayKetThuc);
      this.groupBox1.Controls.Add((Control) this.rdTrungDuoi);
      this.groupBox1.Controls.Add((Control) this.rdTrungDau);
      this.groupBox1.Location = new Point(5, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1090, 43);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.dtNgayBatDau.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayBatDau.CalendarForeColor = Color.Red;
      this.dtNgayBatDau.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
      this.dtNgayBatDau.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayBatDau.Format = DateTimePickerFormat.Custom;
      this.dtNgayBatDau.Location = new Point(69, 15);
      this.dtNgayBatDau.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayBatDau.Name = "dtNgayBatDau";
      this.dtNgayBatDau.Size = new Size(91, 21);
      this.dtNgayBatDau.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.dtNgayBatDau, "Ngày bắt đầu kiểm tra");
      this.dtNgayBatDau.ValueChanged += new EventHandler(this.dtNgayBatDau_ValueChanged);
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(990, 12);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(75, 24);
      this.btnXem.TabIndex = 7;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.button1_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(11, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(56, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Từ ngày";
      this.txtLoto.BorderStyle = BorderStyle.FixedSingle;
      this.txtLoto.Cursor = Cursors.IBeam;
      this.txtLoto.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.txtLoto.ForeColor = Color.FromArgb(64, 64, 64);
      this.txtLoto.HintForeColor = SystemColors.Highlight;
      this.txtLoto.HintText = "Nhập vào dàn 2 số bất kì (20,21,23,56)";
      this.txtLoto.isPassword = false;
      this.txtLoto.LineFocusedColor = Color.White;
      this.txtLoto.LineIdleColor = Color.White;
      this.txtLoto.LineMouseHoverColor = Color.White;
      this.txtLoto.LineThickness = 3;
      this.txtLoto.Location = new Point(315, 12);
      this.txtLoto.Margin = new Padding(0);
      this.txtLoto.Name = "txtLoto";
      this.txtLoto.Size = new Size(345, 25);
      this.txtLoto.TabIndex = 2;
      this.txtLoto.TextAlign = HorizontalAlignment.Center;
      this.toolTip1.SetToolTip((Control) this.txtLoto, "Nhập vào dàn 2 số bất kỳ (20,21,23,56)");
      this.txtLoto.OnValueChanged += new EventHandler(this.txtLoto_OnValueChanged);
      this.txtLoto.KeyDown += new KeyEventHandler(this.txtLoto_KeyDown);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(269, 16);
      this.label3.Name = "label3";
      this.label3.Size = new Size(47, 16);
      this.label3.TabIndex = 7;
      this.label3.Text = "dàn số";
      this.rdBachThu.AutoSize = true;
      this.rdBachThu.Cursor = Cursors.Hand;
      this.rdBachThu.FlatStyle = FlatStyle.Flat;
      this.rdBachThu.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdBachThu.ForeColor = Color.Black;
      this.rdBachThu.Location = new Point(742, 15);
      this.rdBachThu.Name = "rdBachThu";
      this.rdBachThu.Size = new Size(72, 19);
      this.rdBachThu.TabIndex = 4;
      this.rdBachThu.Text = "Bạch thủ";
      this.toolTip1.SetToolTip((Control) this.rdBachThu, "Chỉ xét lô bạch thủ");
      this.rdBachThu.UseVisualStyleBackColor = true;
      this.rdBachThu.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkSlateGray;
      this.label2.Location = new Point(160, 15);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 16);
      this.label2.TabIndex = 7;
      this.label2.Text = "-";
      this.rdCap.AutoSize = true;
      this.rdCap.Checked = true;
      this.rdCap.Cursor = Cursors.Hand;
      this.rdCap.FlatStyle = FlatStyle.Flat;
      this.rdCap.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.rdCap.ForeColor = Color.Red;
      this.rdCap.Location = new Point(677, 15);
      this.rdCap.Name = "rdCap";
      this.rdCap.Size = new Size(62, 19);
      this.rdCap.TabIndex = 3;
      this.rdCap.TabStop = true;
      this.rdCap.Text = "Lô cặp";
      this.toolTip1.SetToolTip((Control) this.rdCap, "Chỉ xét lô cặp lộn");
      this.rdCap.UseVisualStyleBackColor = true;
      this.rdCap.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.dtNgayKetThuc.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayKetThuc.CalendarForeColor = Color.Red;
      this.dtNgayKetThuc.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
      this.dtNgayKetThuc.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayKetThuc.Format = DateTimePickerFormat.Custom;
      this.dtNgayKetThuc.Location = new Point(173, 15);
      this.dtNgayKetThuc.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayKetThuc.Name = "dtNgayKetThuc";
      this.dtNgayKetThuc.Size = new Size(91, 21);
      this.dtNgayKetThuc.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.dtNgayKetThuc, "Kiểm tra đến ngày");
      this.dtNgayKetThuc.ValueChanged += new EventHandler(this.dtNgayKetThuc_ValueChanged);
      this.rdTrungDuoi.AutoSize = true;
      this.rdTrungDuoi.Cursor = Cursors.Hand;
      this.rdTrungDuoi.FlatStyle = FlatStyle.Flat;
      this.rdTrungDuoi.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDuoi.ForeColor = Color.Black;
      this.rdTrungDuoi.Location = new Point(901, 15);
      this.rdTrungDuoi.Name = "rdTrungDuoi";
      this.rdTrungDuoi.Size = new Size(83, 19);
      this.rdTrungDuoi.TabIndex = 6;
      this.rdTrungDuoi.Text = "Trùng đuôi";
      this.toolTip1.SetToolTip((Control) this.rdTrungDuoi, "Chỉ xét lô trùng đuôi");
      this.rdTrungDuoi.UseVisualStyleBackColor = true;
      this.rdTrungDuoi.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdTrungDau.AutoSize = true;
      this.rdTrungDau.Cursor = Cursors.Hand;
      this.rdTrungDau.FlatStyle = FlatStyle.Flat;
      this.rdTrungDau.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDau.ForeColor = Color.Black;
      this.rdTrungDau.Location = new Point(819, 15);
      this.rdTrungDau.Name = "rdTrungDau";
      this.rdTrungDau.Size = new Size(80, 19);
      this.rdTrungDau.TabIndex = 5;
      this.rdTrungDau.Text = "Trùng đầu";
      this.toolTip1.SetToolTip((Control) this.rdTrungDau, "Chỉ xét lô trùng đầu");
      this.rdTrungDau.UseVisualStyleBackColor = true;
      this.rdTrungDau.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.bgGetNewDay.DoWork += new DoWorkEventHandler(this.bgGetNewDay_DoWork);
      this.bgGetNewDay.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetNewDay_RunWorkerCompleted);
      this.bgGetDataTong.DoWork += new DoWorkEventHandler(this.bgGetDataTong_DoWork);
      this.bgGetDataTong.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetDataTong_RunWorkerCompleted);
      this.bgXuLy.DoWork += new DoWorkEventHandler(this.bgXuLy_DoWork);
      this.bgXuLy.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgXuLy_RunWorkerCompleted);
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.bgTinhNgayVe.DoWork += new DoWorkEventHandler(this.bgTinhNgayVe_DoWork);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(515, 311);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 60;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.timerLoading.Enabled = true;
      this.timerLoading.Tick += new EventHandler(this.TimerLoadingTick);
      this.toolTip1.ToolTipTitle = "Thông báo";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.webBrowser1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabBacNhoDanCungVe);
      this.Size = new Size(1100, 590);
      this.panel2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }

    public class TinhNgayVeLoTrungDau
    {
      public string Loto1 { get; set; }

      public string Loto2 { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLoto1 { get; set; }

      public string SoNhayVeLoto2 { get; set; }
    }

    public class TinhNgayVeLoCap
    {
      public string LotoXuoi { get; set; }

      public string Lotolon { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLotoXuoi { get; set; }

      public string SoNhayVeLotoLon { get; set; }
    }

    public class TinhNgayVeLoBachThu
    {
      public string LotoXuoi { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLotoXuoi { get; set; }
    }

    public class TinhNgayVeLoTrungDuoi
    {
      public string Loto1 { get; set; }

      public string Loto2 { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLoto1 { get; set; }

      public string SoNhayVeLoto2 { get; set; }
    }

    public class TinhNgayVeLoTrungDauTheoLoVe
    {
      public string Loto1 { get; set; }

      public string Loto2 { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLoto1 { get; set; }

      public string SoNhayVeLoto2 { get; set; }
    }

    public class TinhNgayVeLoCapTheoLoVe
    {
      public string LotoXuoi { get; set; }

      public string Lotolon { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLotoXuoi { get; set; }

      public string SoNhayVeLotoLon { get; set; }
    }

    public class TinhNgayVeLoBachThuTheoLoVe
    {
      public string LotoXuoi { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLotoXuoi { get; set; }
    }

    public class TinhNgayVeLoTrungDuoiTheoLoVe
    {
      public string Loto1 { get; set; }

      public string Loto2 { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLoto1 { get; set; }

      public string SoNhayVeLoto2 { get; set; }
    }
  }
}
