// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabBacNhoLoXien
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

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
  public class TabBacNhoLoXien : UserControl
  {
    private int _khungnuoiloxien = FMain.ObjConfigBacNho.KhungLoXien2;
    private string strHtmlTong = "";
    private IContainer components = (IContainer) null;
    private Tbloto objLoto;
    private DateTime _ngayduochon;
    private TbLoxien objLoXien;
    private string _title;
    private string _loaiLoto;
    private DataTable _dtNgayDuocChon;
    private DataTable _dtLoToTong;
    private DataTable _dtLoToVeNgaySau;
    private DataTable dtLoaiLoToTong;
    private List<TabBacNhoLoXien.BacNhoTheoGiai> _listBacnhotheogiai;
    private List<TabBacNhoLoXien.BacNhoTheoNhay> _listBacnhotheonhay;
    private List<TabBacNhoLoXien.BacNhoTheoCap> _listBacnhotheocap;
    private List<TabBacNhoLoXien.BacNhoTheoCapCungVe> _listBacnhotheocapcungve;
    private List<TabBacNhoLoXien.BacNhoTheoDauCam> _listBacnhotheodaucam;
    private List<TabBacNhoLoXien.BacNhoTheoDitCam> _listBacnhotheoditcam;
    public TabBacNhoLoXien.BacNhoTheoGiai ObjTheoGiai;
    public TabBacNhoLoXien.BacNhoTheoNhay ObjTheoNhay;
    public TabBacNhoLoXien.BacNhoTheoCap ObjTheoCap;
    public TabBacNhoLoXien.BacNhoTheoCapCungVe ObjCapCungVe;
    public TabBacNhoLoXien.BacNhoTheoDauCam ObjDauCam;
    public TabBacNhoLoXien.BacNhoTheoDitCam ObjDitCam;
    private DataTable _dtTheoCap;
    private string _strBacNhoCap;
    private string _loCapBacThu;
    private DataTable dtLoaiLotoKiemTra;
    private DataTable _dtDanhSachLoToVe;
    private string _strBacNhoTheoGiai;
    private DataTable _dtTheoGiai;
    private WebBrowser wbHienthi;
    private Panel panel2;
    private Label label3;
    private Label label2;
    private Button btnXem;
    private CheckBox cbDaudit;
    private CheckBox cbCapcungve;
    private CheckBox cbTheocap;
    private CheckBox cbTheonhay;
    private CheckBox cbTheogiai;
    private DateTimePicker dtNgayThang;
    private Label label1;
    private RadioButton rdCap;
    private RadioButton rdTrungDuoi;
    private RadioButton rdTrungDau;
    private PictureBox picLoading;
    private BackgroundWorker bgListBacNho;
    private BackgroundWorker bgDataTong;
    private RadioButton rdTudo;
    private BackgroundWorker bgTheoCap;
    private Timer timer1;
    private BackgroundWorker bgGetLoaiBacNho;
    private BackgroundWorker bgTimNgayVe;
    private BackgroundWorker bgTheogiai;
    private BackgroundWorker bgTheonhay;
    private BackgroundWorker bgTheocaplienke;
    private BackgroundWorker bgDauditcam;
    private GroupBox groupBox1;

    public TabBacNhoLoXien()
    {
      this.InitializeComponent();
      this.dtNgayThang.Value = FMain.NgayKetQuaMoiNhat;
      this.objLoto = new Tbloto();
      this.objLoXien = new TbLoxien();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this._loaiLoto = "locap";
      if (!this.bgGetLoaiBacNho.IsBusy)
        this.bgGetLoaiBacNho.RunWorkerAsync();
      this.HienThiKetQua(this.wbHienthi, "");
    }

    private void dtNgayThang_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtNgayThang.Value > FMain.NgayKetQuaMoiNhat)
        this.dtNgayThang.Value = FMain.NgayKetQuaMoiNhat;
      this._ngayduochon = this.dtNgayThang.Value;
      if (!this.bgListBacNho.IsBusy)
      {
        this.btnXem.Enabled = false;
        this.bgListBacNho.RunWorkerAsync();
      }
      if (this.bgDataTong.IsBusy)
        return;
      this.bgDataTong.RunWorkerAsync();
    }

    private void rdTrungDuoi_CheckedChanged(object sender, EventArgs e)
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

    private void cbTheogiai_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      if (checkBox.Checked)
      {
        checkBox.ForeColor = Color.Red;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Bold);
      }
      else
      {
        checkBox.ForeColor = Color.Black;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Regular);
      }
    }

    private void HienThiKetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.StrCss1 + "<title>THỐNG KÊ XỔ SỐ</title></head><body  style='font-family:Verdana;'><div class='container' style='margin-right:15px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ><b style='color:rgb(43, 60, 80);'>THỐNG KÊ BẠC NHỚ LÔ XIÊN ĐÔI - CẢ HAI SỐ CÙNG VỀ NGÀY " + this.dtNgayThang.Value.ToString("dd/MM/yyyy") + "</b></div><div class='panel-body'><ul class='media-list'><li class='media'>" + strHtml + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (this.bgDataTong.IsBusy || this.bgListBacNho.IsBusy || this.bgGetLoaiBacNho.IsBusy)
        return;
      this.strHtmlTong = "";
      if (this.rdCap.Checked)
      {
        this._loCapBacThu = "Lô cặp lộn cùng về, về nhiều trong <b style='color:red;'>" + (object) FMain.ObjConfigBacNho.KhungLoXien2 + "</b> ngày sau đó";
        this._loaiLoto = "locap";
      }
      if (this.rdTrungDau.Checked)
      {
        this._loCapBacThu = "Lô trùng đầu cùng về, về nhiều trong <b style='color:red;'>" + (object) FMain.ObjConfigBacNho.KhungLoXien2 + "</b> ngày sau đó";
        this._loaiLoto = "trungdau";
      }
      if (this.rdTrungDuoi.Checked)
      {
        this._loCapBacThu = "Lô trùng đuôi cùng về, về nhiều trong <b style='color:red;'>" + (object) FMain.ObjConfigBacNho.KhungLoXien2 + "</b> ngày sau đó";
        this._loaiLoto = "trungduoi";
      }
      if (this.rdTudo.Checked)
      {
        this._loCapBacThu = "Lô tự do cùng về, về nhiều trong <b style='color:red;'>" + (object) FMain.ObjConfigBacNho.KhungLoXien2 + "</b> ngày sau đó";
        this._loaiLoto = "tudo";
      }
      this._dtLoToVeNgaySau = this.objLoto.GetLotoByNgayThangSoBanGhi(this._ngayduochon, FMain.ObjConfigBacNho.KhungLoXien2);
      this.TimNgayVeCuaTatCaCapSo();
      if (this.cbTheogiai.Checked && !this.bgTheogiai.IsBusy)
        this.bgTheogiai.RunWorkerAsync();
      if (this.cbTheonhay.Checked && !this.bgTheonhay.IsBusy)
        this.bgTheonhay.RunWorkerAsync();
      if (this.cbTheocap.Checked && !this.bgTheoCap.IsBusy)
        this.bgTheoCap.RunWorkerAsync();
      if (this.cbCapcungve.Checked && !this.bgTheocaplienke.IsBusy)
        this.bgTheocaplienke.RunWorkerAsync();
      if (this.cbDaudit.Checked && !this.bgDauditcam.IsBusy)
        this.bgDauditcam.RunWorkerAsync();
    }

    private void LayDuLieuNgayDuocChon(DateTime ngayduocchon)
    {
      this._dtNgayDuocChon = new DataTable();
      this._dtLoToTong = new DataTable();
      int num = FMain.ObjConfigBacNho.TheoGiai;
      if (FMain.ObjConfigBacNho.TheoNhay > num)
        num = FMain.ObjConfigBacNho.TheoNhay;
      if (FMain.ObjConfigBacNho.TheoCap > num)
        num = FMain.ObjConfigBacNho.TheoCap;
      if (FMain.ObjConfigBacNho.CapCungVe > num)
        num = FMain.ObjConfigBacNho.CapCungVe;
      if (FMain.ObjConfigBacNho.DauCam > num)
        num = FMain.ObjConfigBacNho.DauCam;
      if (FMain.ObjConfigBacNho.DuoiCam > num)
        num = FMain.ObjConfigBacNho.DuoiCam;
      this._dtLoToTong = this.objLoto.GetLotoByNgayThang(ngayduocchon.AddMonths(-num), ngayduocchon);
    }

    private void GetDuLieuLoXien()
    {
      this.dtLoaiLoToTong = this.objLoXien.GetAllForBacNho();
    }

    private void bgListBacNho_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetListCacLoaiBacNhoByDate(this._ngayduochon);
    }

    private void GetListCacLoaiBacNhoByDate(DateTime _ngayduocchon)
    {
      this._listBacnhotheogiai = new List<TabBacNhoLoXien.BacNhoTheoGiai>();
      this._listBacnhotheonhay = new List<TabBacNhoLoXien.BacNhoTheoNhay>();
      this._listBacnhotheocap = new List<TabBacNhoLoXien.BacNhoTheoCap>();
      this._listBacnhotheocapcungve = new List<TabBacNhoLoXien.BacNhoTheoCapCungVe>();
      this._listBacnhotheodaucam = new List<TabBacNhoLoXien.BacNhoTheoDauCam>();
      this._listBacnhotheoditcam = new List<TabBacNhoLoXien.BacNhoTheoDitCam>();
      this._dtNgayDuocChon = this.objLoto.GetByDate(_ngayduocchon);
      if (this._dtNgayDuocChon.Rows.Count > 0)
      {
        List<string> stringList1 = new List<string>()
        {
          "0",
          "1",
          "2",
          "3",
          "4",
          "5",
          "6",
          "7",
          "8",
          "9"
        };
        List<string> stringList2 = new List<string>()
        {
          "0",
          "1",
          "2",
          "3",
          "4",
          "5",
          "6",
          "7",
          "8",
          "9"
        };
        for (int j = 1; j < this._dtNgayDuocChon.Columns.Count; j++)
        {
          this.ObjTheoGiai = new TabBacNhoLoXien.BacNhoTheoGiai()
          {
            Text = this._dtNgayDuocChon.Columns[j].ColumnName,
            Value = this._dtNgayDuocChon.Rows[0][j].ToString()
          };
          this._listBacnhotheogiai.Add(this.ObjTheoGiai);
          if (!this._listBacnhotheonhay.Any<TabBacNhoLoXien.BacNhoTheoNhay>((Func<TabBacNhoLoXien.BacNhoTheoNhay, bool>) (items => items.Text == this._dtNgayDuocChon.Rows[0][j].ToString())))
          {
            this.ObjTheoNhay = new TabBacNhoLoXien.BacNhoTheoNhay();
            this.ObjTheoNhay = this.TimBacNhoTheoNhay(this._dtNgayDuocChon, this._dtNgayDuocChon.Rows[0][j].ToString());
            if (this.ObjTheoNhay.Value != "")
              this._listBacnhotheonhay.Add(this.ObjTheoNhay);
          }
          lotoXuoi = this._dtNgayDuocChon.Rows[0][j].ToString();
          lotoLon = this.objLoto.CheckLotoCap(this._dtNgayDuocChon.Rows[0][j].ToString());
          string lotoXuoi;
          string lotoLon;
          if (!this._listBacnhotheocap.Any<TabBacNhoLoXien.BacNhoTheoCap>(closure_0 ?? (closure_0 = (Func<TabBacNhoLoXien.BacNhoTheoCap, bool>) (items =>
          {
            if (!(items.Text == lotoXuoi))
              return items.Text == lotoLon;
            return true;
          }))))
          {
            this.ObjTheoCap = new TabBacNhoLoXien.BacNhoTheoCap();
            this.ObjTheoCap = this.TimBacNhoTheoCap(this._dtNgayDuocChon, lotoXuoi, lotoLon);
            if (this.ObjTheoCap.Value != "")
              this._listBacnhotheocap.Add(this.ObjTheoCap);
          }
          string lotoTien = (int.Parse(lotoXuoi) + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture);
          if (!this._listBacnhotheocapcungve.Any<TabBacNhoLoXien.BacNhoTheoCapCungVe>(closure_1 ?? (closure_1 = (Func<TabBacNhoLoXien.BacNhoTheoCapCungVe, bool>) (items => items.Text == lotoXuoi))))
          {
            this.ObjCapCungVe = new TabBacNhoLoXien.BacNhoTheoCapCungVe();
            this.ObjCapCungVe = this.TimBacNhoTheoCapCungVe(this._dtNgayDuocChon, lotoXuoi, lotoTien);
            if (this.ObjCapCungVe.Value != "")
              this._listBacnhotheocapcungve.Add(this.ObjCapCungVe);
          }
          string str1 = lotoXuoi.Substring(0, 1);
          string str2 = lotoXuoi.Substring(1, 1);
          stringList1.Remove(str1);
          stringList2.Remove(str2);
        }
        if (stringList1.Count > 0)
        {
          foreach (string str in stringList1)
          {
            this.ObjDauCam = new TabBacNhoLoXien.BacNhoTheoDauCam()
            {
              Text = str,
              Value = this.Text
            };
            this._listBacnhotheodaucam.Add(this.ObjDauCam);
          }
        }
        if (stringList2.Count > 0)
        {
          foreach (string str in stringList2)
          {
            this.ObjDitCam = new TabBacNhoLoXien.BacNhoTheoDitCam()
            {
              Text = str,
              Value = this.Text
            };
            this._listBacnhotheoditcam.Add(this.ObjDitCam);
          }
        }
      }
      string str3 = "";
      foreach (TabBacNhoLoXien.BacNhoTheoDauCam bacNhoTheoDauCam in this._listBacnhotheodaucam)
      {
        if (bacNhoTheoDauCam.Text != "" && bacNhoTheoDauCam.Value != "")
        {
          str3 += "Đầu câm";
          str3 = str3 + bacNhoTheoDauCam.Text + "-" + bacNhoTheoDauCam.Value + "\r\n";
        }
      }
      foreach (TabBacNhoLoXien.BacNhoTheoDitCam bacNhoTheoDitCam in this._listBacnhotheoditcam)
      {
        if (bacNhoTheoDitCam.Text != "" && bacNhoTheoDitCam.Value != "")
          str3 = str3 + "Đít câm" + bacNhoTheoDitCam.Text + "-" + bacNhoTheoDitCam.Value + "\r\n";
      }
    }

    private TabBacNhoLoXien.BacNhoTheoCapCungVe TimBacNhoTheoCapCungVe(DataTable dtTable, string lotoXuoi, string lotoTien)
    {
      this.ObjCapCungVe = new TabBacNhoLoXien.BacNhoTheoCapCungVe()
      {
        Text = "",
        Value = ""
      };
      bool flag = false;
      for (int index = 1; index < dtTable.Columns.Count; ++index)
      {
        if (lotoTien == dtTable.Rows[0][index].ToString())
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        this.ObjCapCungVe.Text = lotoXuoi;
        this.ObjCapCungVe.Value = lotoTien;
        if (int.Parse(lotoTien) < int.Parse(lotoXuoi))
        {
          this.ObjCapCungVe.Text = lotoTien;
          this.ObjCapCungVe.Value = lotoXuoi;
        }
      }
      return this.ObjCapCungVe;
    }

    private TabBacNhoLoXien.BacNhoTheoCap TimBacNhoTheoCap(DataTable dtTable, string lotoXuoi, string lotoLon)
    {
      this.ObjTheoCap = new TabBacNhoLoXien.BacNhoTheoCap()
      {
        Text = "",
        Value = ""
      };
      bool flag = false;
      for (int index = 1; index < dtTable.Columns.Count; ++index)
      {
        if (lotoLon == dtTable.Rows[0][index].ToString())
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        this.ObjTheoCap.Text = lotoXuoi;
        this.ObjTheoCap.Value = lotoLon;
        if (int.Parse(lotoXuoi) > int.Parse(lotoLon))
        {
          this.ObjTheoCap.Text = lotoLon;
          this.ObjTheoCap.Value = lotoXuoi;
        }
      }
      return this.ObjTheoCap;
    }

    private TabBacNhoLoXien.BacNhoTheoNhay TimBacNhoTheoNhay(DataTable dtTable, string lotoSoSanh)
    {
      this.ObjTheoNhay = new TabBacNhoLoXien.BacNhoTheoNhay()
      {
        Text = "",
        Value = ""
      };
      int num = 0;
      for (int index = 1; index < dtTable.Columns.Count; ++index)
      {
        if (lotoSoSanh == dtTable.Rows[0][index].ToString())
          ++num;
      }
      if (num > 1)
      {
        this.ObjTheoNhay.Text = lotoSoSanh;
        this.ObjTheoNhay.Value = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      return this.ObjTheoNhay;
    }

    private void bgListBacNho_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.btnXem.Enabled = true;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.bgListBacNho.IsBusy || this.bgDataTong.IsBusy || (this.bgGetLoaiBacNho.IsBusy || this.bgTheoCap.IsBusy) || (this.bgTheogiai.IsBusy || this.bgTheonhay.IsBusy || this.bgTheocaplienke.IsBusy) || this.bgDauditcam.IsBusy)
        this.picLoading.Visible = true;
      else
        this.picLoading.Visible = false;
    }

    private void bgDataTong_DoWork(object sender, DoWorkEventArgs e)
    {
      this.LayDuLieuNgayDuocChon(this._ngayduochon);
    }

    private void bgGetLoaiBacNho_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDuLieuLoXien();
    }

    private void bgGetLoaiBacNho_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    private void bgTheoCap_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoCap();
    }

    private void GetDaTaBacNhoTheoCap()
    {
      DateTime ngayBatDau = this._ngayduochon.AddMonths(-FMain.ObjConfigBacNho.TheoCap);
      DateTime ngayduochon = this._ngayduochon;
      this._strBacNhoCap = "";
      if (this._listBacnhotheocap.Count <= 0)
        return;
      for (int index = 0; index < this._listBacnhotheocap.Count; ++index)
      {
        string text = this._listBacnhotheocap[index].Text;
        string _loto2 = this._listBacnhotheocap[index].Value;
        this._strBacNhoCap += this.XuLyDuLieuTungCap(this.GetDataTungCap(ngayBatDau, ngayduochon, text, _loto2), text, _loto2);
      }
    }

    private DataTable GetDataTungCap(DateTime ngayBatDau, DateTime ngayKetThuc, string _loto1, string _loto2)
    {
      DataTable dataTable = new DataTable();
      DataRow[] dataRowArray = this._dtLoToTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and (G0='" + _loto1 + "' or G1='" + _loto1 + "' or G21='" + _loto1 + "' or G22='" + _loto1 + "'or G31='" + _loto1 + "' or G32='" + _loto1 + "'or G33='" + _loto1 + "'or G34='" + _loto1 + "'or G35='" + _loto1 + "'or G36='" + _loto1 + "'or G41='" + _loto1 + "'or G42='" + _loto1 + "'or G43='" + _loto1 + "'or G44='" + _loto1 + "'or G51='" + _loto1 + "'or G52='" + _loto1 + "'or G53='" + _loto1 + "'or G54='" + _loto1 + "'or G55='" + _loto1 + "'or G56='" + _loto1 + "'or G61='" + _loto1 + "'or G62='" + _loto1 + "'or G63='" + _loto1 + "'or G71='" + _loto1 + "'or G72='" + _loto1 + "'or G73='" + _loto1 + "'or G74='" + _loto1 + "')and (G0='" + _loto2 + "' or G1='" + _loto2 + "' or G21='" + _loto2 + "' or G22='" + _loto2 + "'or G31='" + _loto2 + "' or G32='" + _loto2 + "'or G33='" + _loto2 + "'or G34='" + _loto2 + "'or G35='" + _loto2 + "'or G36='" + _loto2 + "'or G41='" + _loto2 + "'or G42='" + _loto2 + "'or G43='" + _loto2 + "'or G44='" + _loto2 + "'or G51='" + _loto2 + "'or G52='" + _loto2 + "'or G53='" + _loto2 + "'or G54='" + _loto2 + "'or G55='" + _loto2 + "'or G56='" + _loto2 + "'or G61='" + _loto2 + "'or G62='" + _loto2 + "'or G63='" + _loto2 + "'or G71='" + _loto2 + "'or G72='" + _loto2 + "'or G73='" + _loto2 + "'or G74='" + _loto2 + "')");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private DataTable GetLoaiLoto(string loaiLoto)
    {
      this.dtLoaiLotoKiemTra = new DataTable();
      this.dtLoaiLotoKiemTra = ((IEnumerable<DataRow>) this.dtLoaiLoToTong.Select("loai='" + loaiLoto + "'")).CopyToDataTable<DataRow>();
      for (int index = 0; index < this.dtLoaiLotoKiemTra.Rows.Count; ++index)
        this.dtLoaiLotoKiemTra.Rows[index]["STT"] = (object) (index + 1).ToString();
      return this.dtLoaiLotoKiemTra;
    }

    private string XuLyDuLieuTungCap(DataTable dtTam, string _loto1, string _loto2)
    {
      int khungLoXien2 = FMain.ObjConfigBacNho.KhungLoXien2;
      string str1 = "" + "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ " + this._ngayduochon.AddMonths(-FMain.ObjConfigBacNho.TheoCap).ToString("dd-MM-yyyy") + " đến nay, Loto [<b style='color:red;'> " + _loto1 + "-" + _loto2 + " </b>] về cùng nhau tất cả (<b style='color:red;'>  " + (object) dtTam.Rows.Count + "  </b>) lần. " + this._loCapBacThu + "</b></br>";
      this._dtTheoCap = this.GetLoaiLoto(this._loaiLoto);
      for (int index = 0; index < dtTam.Rows.Count; ++index)
      {
        int soThuTuBanGhi = int.Parse(dtTam.Rows[index]["STT"].ToString());
        if (this.dtLoaiLotoKiemTra.Rows.Count > 0)
          this.XuLyLoToNgaySauTheoCap(soThuTuBanGhi, khungLoXien2);
      }
      DataView defaultView = this._dtTheoCap.DefaultView;
      defaultView.Sort = "soLanve DESC";
      this._dtTheoCap = defaultView.ToTable();
      float count = (float) dtTam.Rows.Count;
      for (int index = 0; index < FMain.ObjConfigBacNho.SoBanGhi; ++index)
      {
        string[] strArray = this._dtTheoCap.Rows[index]["boSo"].ToString().Split('-');
        string _loto1_1 = strArray[0];
        string _loto2_1 = strArray[1];
        string s = this._dtTheoCap.Rows[index]["soLanve"].ToString();
        string str2 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        if (Convert.ToInt32(s) < 10)
          s = "0" + s;
        string str3 = str1 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + _loto1_1 + "-" + _loto2_1 + " )</b>  về cùng nhau tất cả  [<b style='color:red;'> " + s + " </b>] lần - " + str2 + ". Trong đó ";
        int num = 0;
        while (num < FMain.ObjConfigBacNho.KhungLoXien2)
          ++num;
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str3 += this.TimNgayVeLoCap(_loto1_1, _loto2_1);
        str1 = str3 + "<br>";
      }
      return str1;
    }

    private void XuLyLoToNgaySauTheoCap(int soThuTuBanGhi, int khungDanh)
    {
      bool flag1 = false;
      bool flag2 = false;
      DataRow[] dataRowArray = this._dtLoToTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtTheoCap.Rows.Count; ++index1)
      {
        string[] strArray = this._dtTheoCap.Rows[index1]["boSo"].ToString().Split('-');
        string str1 = strArray[0];
        string str2 = strArray[1];
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          flag1 = false;
          flag2 = false;
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3)
              flag1 = true;
            if (str2 == str3)
              flag2 = true;
          }
          if (flag1 & flag2)
          {
            index2 = index3 + 4;
            break;
          }
        }
        if (flag1 & flag2)
        {
          this._dtTheoCap.Rows[index1][index2] = (object) (int.Parse(this._dtTheoCap.Rows[index1][index2].ToString()) + 1);
          this._dtTheoCap.Rows[index1]["soLanve"] = (object) (int.Parse(this._dtTheoCap.Rows[index1]["soLanve"].ToString()) + 1);
        }
      }
    }

    private string TimNgayVeLoCap(string _loto1, string _loto2)
    {
      string str = "<b style='color:black;'>Chưa về</b>";
      if (this._dtDanhSachLoToVe.Rows.Count > 0)
      {
        DataRow[] dataRowArray = this._dtDanhSachLoToVe.Select("boSo='" + (_loto1 + "-" + _loto2) + "'");
        if ((uint) dataRowArray.Length > 0U)
          str = " " + dataRowArray[0]["veNgay"];
      }
      return str;
    }

    private void bgTheoCap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.strHtmlTong += this._strBacNhoCap;
      this.HienThiKetQua(this.wbHienthi, this.strHtmlTong);
    }

    private void TimNgayVeCuaTatCaCapSo()
    {
      bool flag1 = false;
      bool flag2 = false;
      this._dtDanhSachLoToVe = new DataTable();
      DataTable loaiLoto = this.GetLoaiLoto(this._loaiLoto);
      int num = FMain.ObjConfigBacNho.KhungLoXien2;
      if (num > this._dtLoToVeNgaySau.Rows.Count)
        num = this._dtLoToVeNgaySau.Rows.Count;
      if (FMain.ObjConfigBacNho.HienThiNgayVe != 1 || this._dtLoToVeNgaySau.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < loaiLoto.Rows.Count; ++index1)
      {
        string str1 = "<b style='color:black;'>Chưa về</b>";
        string[] strArray = loaiLoto.Rows[index1]["boSo"].ToString().Split('-');
        string str2 = strArray[0];
        string str3 = strArray[1];
        for (int index2 = 0; index2 < num; ++index2)
        {
          flag1 = false;
          flag2 = false;
          for (int index3 = 2; index3 < this._dtLoToVeNgaySau.Columns.Count; ++index3)
          {
            string str4 = this._dtLoToVeNgaySau.Rows[index2][index3].ToString();
            if (str2 == str4)
              flag1 = true;
            if (str3 == str4)
              flag2 = true;
          }
          if (flag1 & flag2)
          {
            str1 = "<b style='color:red;'>Về ngày " + (index2 + 1).ToString() + "</b>";
            break;
          }
        }
        if (!flag1 || !flag2)
          str1 = "<b>Xịt</b>";
        loaiLoto.Rows[index1]["veNgay"] = (object) str1;
      }
      this._dtDanhSachLoToVe = loaiLoto;
    }

    private void bgTimNgayVe_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void bgDataTong_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    private void GetDaTaBacNhoTheoGiai()
    {
      DateTime ngayBatDau = this._ngayduochon.AddMonths(-FMain.ObjConfigBacNho.TheoGiai);
      DateTime ngayduochon = this._ngayduochon;
      this._strBacNhoTheoGiai = "";
      if (this._listBacnhotheogiai.Count <= 0)
        return;
      for (int index = 0; index < this._listBacnhotheogiai.Count; ++index)
      {
        string text = this._listBacnhotheogiai[index].Text;
        string str = this._listBacnhotheogiai[index].Value;
        this._strBacNhoTheoGiai += this.XuLyDuLieuTungGiai(this.GetDataTungGiai(ngayBatDau, ngayduochon, text, str), text, str);
      }
    }

    private string XuLyDuLieuTungGiai(DataTable dtTam, string _giai, string loto)
    {
      int khungLoXien2 = FMain.ObjConfigBacNho.KhungLoXien2;
      string str1 = "" + "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ " + this._ngayduochon.AddMonths(-FMain.ObjConfigBacNho.TheoGiai).ToString("dd-MM-yyyy") + " đến nay, Giải [<b style='color:red;'> " + _giai + "</b>] về " + loto + " tất cả (<b style='color:red;'>  " + (object) dtTam.Rows.Count + "  </b>) lần. " + this._loCapBacThu + "</b></br>";
      this._dtTheoGiai = this.GetLoaiLoto(this._loaiLoto);
      for (int index = 0; index < dtTam.Rows.Count; ++index)
      {
        int soThuTuBanGhi = int.Parse(dtTam.Rows[index]["STT"].ToString());
        if (this.dtLoaiLotoKiemTra.Rows.Count > 0)
          this.XuLyLoToNgaySauTheoGiai(soThuTuBanGhi, khungLoXien2);
      }
      DataView defaultView = this._dtTheoGiai.DefaultView;
      defaultView.Sort = "soLanve DESC";
      this._dtTheoGiai = defaultView.ToTable();
      float count = (float) dtTam.Rows.Count;
      if (this.dtLoaiLotoKiemTra.Rows.Count > 0)
      {
        for (int index = 0; index < FMain.ObjConfigBacNho.SoBanGhi; ++index)
        {
          string[] strArray = this._dtTheoGiai.Rows[index]["boSo"].ToString().Split('-');
          string _loto1 = strArray[0];
          string _loto2 = strArray[1];
          string s = this._dtTheoGiai.Rows[index]["soLanve"].ToString();
          string str2 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
          if (Convert.ToInt32(s) < 10)
            s = "0" + s;
          string str3 = str1 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + _loto1 + "-" + _loto2 + " )</b>  về cùng nhau tất cả  [<b style='color:red;'> " + s + " </b>] lần - " + str2 + ". Trong đó ";
          int num = 0;
          while (num < FMain.ObjConfigBacNho.KhungLoXien2)
            ++num;
          if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
            str3 += this.TimNgayVeLoCap(_loto1, _loto2);
          str1 = str3 + "<br>";
        }
      }
      return str1;
    }

    private void XuLyLoToNgaySauTheoGiai(int soThuTuBanGhi, int khungDanh)
    {
      bool flag1 = false;
      bool flag2 = false;
      DataRow[] dataRowArray = this._dtLoToTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtTheoGiai.Rows.Count; ++index1)
      {
        string[] strArray = this._dtTheoGiai.Rows[index1]["boSo"].ToString().Split('-');
        string str1 = strArray[0];
        string str2 = strArray[1];
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          flag1 = false;
          flag2 = false;
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3)
              flag1 = true;
            if (str2 == str3)
              flag2 = true;
          }
          if (flag1 & flag2)
          {
            index2 = index3 + 4;
            break;
          }
        }
        if (flag1 & flag2)
        {
          this._dtTheoGiai.Rows[index1][index2] = (object) (int.Parse(this._dtTheoGiai.Rows[index1][index2].ToString()) + 1);
          this._dtTheoGiai.Rows[index1]["soLanve"] = (object) (int.Parse(this._dtTheoGiai.Rows[index1]["soLanve"].ToString()) + 1);
        }
      }
    }

    private DataTable GetDataTungGiai(DateTime ngayBatDau, DateTime ngayKetThuc, string _giai, string _loto2)
    {
      DataTable dataTable = new DataTable();
      DataRow[] dataRowArray = this._dtLoToTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and " + _giai + "='" + _loto2 + "'");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private void bgTheogiai_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoGiai();
    }

    private void bgTheonhay_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void bgTheocaplienke_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void bgDauditcam_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void bgTheogiai_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.strHtmlTong += this._strBacNhoTheoGiai;
      this.HienThiKetQua(this.wbHienthi, this.strHtmlTong);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabBacNhoLoXien));
      this.wbHienthi = new WebBrowser();
      this.panel2 = new Panel();
      this.groupBox1 = new GroupBox();
      this.cbTheocap = new CheckBox();
      this.rdTudo = new RadioButton();
      this.label1 = new Label();
      this.rdCap = new RadioButton();
      this.dtNgayThang = new DateTimePicker();
      this.rdTrungDuoi = new RadioButton();
      this.cbTheogiai = new CheckBox();
      this.rdTrungDau = new RadioButton();
      this.cbTheonhay = new CheckBox();
      this.label3 = new Label();
      this.cbCapcungve = new CheckBox();
      this.label2 = new Label();
      this.cbDaudit = new CheckBox();
      this.btnXem = new Button();
      this.picLoading = new PictureBox();
      this.bgListBacNho = new BackgroundWorker();
      this.bgDataTong = new BackgroundWorker();
      this.bgTheoCap = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.bgGetLoaiBacNho = new BackgroundWorker();
      this.bgTimNgayVe = new BackgroundWorker();
      this.bgTheogiai = new BackgroundWorker();
      this.bgTheonhay = new BackgroundWorker();
      this.bgTheocaplienke = new BackgroundWorker();
      this.bgDauditcam = new BackgroundWorker();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(-1, 2);
      this.wbHienthi.MinimumSize = new Size(23, 23);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1116, 530);
      this.wbHienthi.TabIndex = 1;
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 46);
      this.panel2.TabIndex = 14;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.cbTheocap);
      this.groupBox1.Controls.Add((Control) this.rdTudo);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.rdCap);
      this.groupBox1.Controls.Add((Control) this.dtNgayThang);
      this.groupBox1.Controls.Add((Control) this.rdTrungDuoi);
      this.groupBox1.Controls.Add((Control) this.cbTheogiai);
      this.groupBox1.Controls.Add((Control) this.rdTrungDau);
      this.groupBox1.Controls.Add((Control) this.cbTheonhay);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.cbCapcungve);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.cbDaudit);
      this.groupBox1.Controls.Add((Control) this.btnXem);
      this.groupBox1.Location = new Point(5, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1090, 43);
      this.groupBox1.TabIndex = 26;
      this.groupBox1.TabStop = false;
      this.cbTheocap.AutoSize = true;
      this.cbTheocap.BackColor = Color.Transparent;
      this.cbTheocap.Cursor = Cursors.Hand;
      this.cbTheocap.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbTheocap.ForeColor = Color.Black;
      this.cbTheocap.Location = new Point(368, 17);
      this.cbTheocap.Margin = new Padding(0);
      this.cbTheocap.Name = "cbTheocap";
      this.cbTheocap.Size = new Size(77, 19);
      this.cbTheocap.TabIndex = 3;
      this.cbTheocap.Text = "Theo cặp";
      this.cbTheocap.TextAlign = ContentAlignment.TopLeft;
      this.cbTheocap.UseVisualStyleBackColor = false;
      this.cbTheocap.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
      this.rdTudo.AutoSize = true;
      this.rdTudo.Cursor = Cursors.Hand;
      this.rdTudo.FlatStyle = FlatStyle.Flat;
      this.rdTudo.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTudo.ForeColor = Color.Black;
      this.rdTudo.Location = new Point(914, 15);
      this.rdTudo.Name = "rdTudo";
      this.rdTudo.Size = new Size(56, 19);
      this.rdTudo.TabIndex = 25;
      this.rdTudo.Text = "Tự do";
      this.rdTudo.UseVisualStyleBackColor = true;
      this.rdTudo.CheckedChanged += new EventHandler(this.rdTrungDuoi_CheckedChanged);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(4, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(65, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Xem ngày";
      this.rdCap.AutoSize = true;
      this.rdCap.Checked = true;
      this.rdCap.Cursor = Cursors.Hand;
      this.rdCap.FlatStyle = FlatStyle.Flat;
      this.rdCap.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.rdCap.ForeColor = Color.Red;
      this.rdCap.Location = new Point(681, 15);
      this.rdCap.Name = "rdCap";
      this.rdCap.Size = new Size(62, 19);
      this.rdCap.TabIndex = 21;
      this.rdCap.TabStop = true;
      this.rdCap.Text = "Lô cặp";
      this.rdCap.UseVisualStyleBackColor = true;
      this.rdCap.CheckedChanged += new EventHandler(this.rdTrungDuoi_CheckedChanged);
      this.dtNgayThang.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayThang.CalendarForeColor = Color.Red;
      this.dtNgayThang.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayThang.CustomFormat = "dd/MM/yyyy";
      this.dtNgayThang.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayThang.Format = DateTimePickerFormat.Custom;
      this.dtNgayThang.Location = new Point(69, 15);
      this.dtNgayThang.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayThang.Name = "dtNgayThang";
      this.dtNgayThang.Size = new Size(91, 21);
      this.dtNgayThang.TabIndex = 0;
      this.dtNgayThang.ValueChanged += new EventHandler(this.dtNgayThang_ValueChanged);
      this.rdTrungDuoi.AutoSize = true;
      this.rdTrungDuoi.Cursor = Cursors.Hand;
      this.rdTrungDuoi.FlatStyle = FlatStyle.Flat;
      this.rdTrungDuoi.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDuoi.ForeColor = Color.Black;
      this.rdTrungDuoi.Location = new Point(827, 15);
      this.rdTrungDuoi.Name = "rdTrungDuoi";
      this.rdTrungDuoi.Size = new Size(83, 19);
      this.rdTrungDuoi.TabIndex = 24;
      this.rdTrungDuoi.Text = "Trùng đuôi";
      this.rdTrungDuoi.UseVisualStyleBackColor = true;
      this.rdTrungDuoi.CheckedChanged += new EventHandler(this.rdTrungDuoi_CheckedChanged);
      this.cbTheogiai.AutoSize = true;
      this.cbTheogiai.BackColor = Color.Transparent;
      this.cbTheogiai.Cursor = Cursors.Hand;
      this.cbTheogiai.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbTheogiai.ForeColor = Color.Black;
      this.cbTheogiai.Location = new Point(182, 17);
      this.cbTheogiai.Margin = new Padding(0);
      this.cbTheogiai.Name = "cbTheogiai";
      this.cbTheogiai.Size = new Size(77, 19);
      this.cbTheogiai.TabIndex = 1;
      this.cbTheogiai.Text = "Theo giải";
      this.cbTheogiai.TextAlign = ContentAlignment.TopLeft;
      this.cbTheogiai.UseVisualStyleBackColor = false;
      this.cbTheogiai.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
      this.rdTrungDau.AutoSize = true;
      this.rdTrungDau.Cursor = Cursors.Hand;
      this.rdTrungDau.FlatStyle = FlatStyle.Flat;
      this.rdTrungDau.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDau.ForeColor = Color.Black;
      this.rdTrungDau.Location = new Point(745, 15);
      this.rdTrungDau.Name = "rdTrungDau";
      this.rdTrungDau.Size = new Size(80, 19);
      this.rdTrungDau.TabIndex = 23;
      this.rdTrungDau.Text = "Trùng đầu";
      this.rdTrungDau.UseVisualStyleBackColor = true;
      this.rdTrungDau.CheckedChanged += new EventHandler(this.rdTrungDuoi_CheckedChanged);
      this.cbTheonhay.AutoSize = true;
      this.cbTheonhay.BackColor = Color.Transparent;
      this.cbTheonhay.Cursor = Cursors.Hand;
      this.cbTheonhay.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbTheonhay.ForeColor = Color.Black;
      this.cbTheonhay.Location = new Point(272, 17);
      this.cbTheonhay.Margin = new Padding(0);
      this.cbTheonhay.Name = "cbTheonhay";
      this.cbTheonhay.Size = new Size(83, 19);
      this.cbTheonhay.TabIndex = 2;
      this.cbTheonhay.Text = "Theo nháy";
      this.cbTheonhay.TextAlign = ContentAlignment.TopLeft;
      this.cbTheonhay.UseVisualStyleBackColor = false;
      this.cbTheonhay.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(662, 15);
      this.label3.Name = "label3";
      this.label3.Size = new Size(12, 18);
      this.label3.TabIndex = 20;
      this.label3.Text = "]";
      this.cbCapcungve.AutoSize = true;
      this.cbCapcungve.BackColor = Color.Transparent;
      this.cbCapcungve.Cursor = Cursors.Hand;
      this.cbCapcungve.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbCapcungve.ForeColor = Color.Black;
      this.cbCapcungve.Location = new Point(458, 17);
      this.cbCapcungve.Margin = new Padding(0);
      this.cbCapcungve.Name = "cbCapcungve";
      this.cbCapcungve.Size = new Size(88, 19);
      this.cbCapcungve.TabIndex = 4;
      this.cbCapcungve.Text = "Cặp liền kề";
      this.cbCapcungve.TextAlign = ContentAlignment.TopLeft;
      this.cbCapcungve.UseVisualStyleBackColor = false;
      this.cbCapcungve.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(163, 15);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 18);
      this.label2.TabIndex = 19;
      this.label2.Text = "[";
      this.cbDaudit.AutoSize = true;
      this.cbDaudit.BackColor = Color.Transparent;
      this.cbDaudit.Cursor = Cursors.Hand;
      this.cbDaudit.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDaudit.ForeColor = Color.Black;
      this.cbDaudit.Location = new Point(559, 17);
      this.cbDaudit.Margin = new Padding(0);
      this.cbDaudit.Name = "cbDaudit";
      this.cbDaudit.Size = new Size(101, 19);
      this.cbDaudit.TabIndex = 5;
      this.cbDaudit.Text = "Đầu - Đít câm";
      this.cbDaudit.TextAlign = ContentAlignment.TopLeft;
      this.cbDaudit.UseVisualStyleBackColor = false;
      this.cbDaudit.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(990, 12);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(75, 24);
      this.btnXem.TabIndex = 8;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.btnXem_Click);
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(528, 287);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 60;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.bgListBacNho.DoWork += new DoWorkEventHandler(this.bgListBacNho_DoWork);
      this.bgListBacNho.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgListBacNho_RunWorkerCompleted);
      this.bgDataTong.DoWork += new DoWorkEventHandler(this.bgDataTong_DoWork);
      this.bgDataTong.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDataTong_RunWorkerCompleted);
      this.bgTheoCap.DoWork += new DoWorkEventHandler(this.bgTheoCap_DoWork);
      this.bgTheoCap.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgTheoCap_RunWorkerCompleted);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.bgGetLoaiBacNho.DoWork += new DoWorkEventHandler(this.bgGetLoaiBacNho_DoWork);
      this.bgGetLoaiBacNho.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetLoaiBacNho_RunWorkerCompleted);
      this.bgTimNgayVe.DoWork += new DoWorkEventHandler(this.bgTimNgayVe_DoWork);
      this.bgTheogiai.DoWork += new DoWorkEventHandler(this.bgTheogiai_DoWork);
      this.bgTheogiai.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgTheogiai_RunWorkerCompleted);
      this.bgTheonhay.DoWork += new DoWorkEventHandler(this.bgTheonhay_DoWork);
      this.bgTheocaplienke.DoWork += new DoWorkEventHandler(this.bgTheocaplienke_DoWork);
      this.bgDauditcam.DoWork += new DoWorkEventHandler(this.bgDauditcam_DoWork);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.wbHienthi);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabBacNhoLoXien);
      this.Size = new Size(1100, 532);
      this.panel2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }

    public class BacNhoTheoGiai
    {
      public string Text { get; set; }

      public string Value { get; set; }
    }

    public class BacNhoTheoNhay
    {
      public string Text { get; set; }

      public string Value { get; set; }
    }

    public class BacNhoTheoCap
    {
      public string Text { get; set; }

      public string Value { get; set; }
    }

    public class BacNhoTheoCapCungVe
    {
      public string Text { get; set; }

      public string Value { get; set; }
    }

    public class BacNhoTheoDauCam
    {
      public string Text { get; set; }

      public string Value { get; set; }
    }

    public class BacNhoTheoDitCam
    {
      public string Text { get; set; }

      public string Value { get; set; }
    }
  }
}
