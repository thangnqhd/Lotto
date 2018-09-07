// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabBacnhoCoban
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
  public class TabBacnhoCoban : UserControl
  {
    public static int LoadLaiDtTinhNgayVe = 0;
    private int demCheckBox = 0;
    private IContainer components = (IContainer) null;
    public static Timer Timer;
    private List<TabBacnhoCoban.LOTO> _listLotoTuDo;
    public DataTable DtTong;
    private DataTable _dtLoToVe;
    public DataTable DtTheoGiai;
    public DataTable DtTheoNhay;
    public DataTable DtTheoCap;
    public DataTable DtTheoCapLienKe;
    public DataTable DtTheoDauCam;
    public DataTable DtTheoDitCam;
    public DataTable DtLoToVeNgaySau;
    public DataTable DtTinhNgayVe;
    private string _strBacNhoGiai;
    private string _strBacNhoNhay;
    private DataTable _dt;
    private Tbloto objLoto;
    private string _loCapBacThu;
    private string _strTong;
    private List<TabBacnhoCoban.BacNhoTheoGiai> _listBacnhotheogiai;
    private List<TabBacnhoCoban.BacNhoTheoNhay> _listBacnhotheonhay;
    private List<TabBacnhoCoban.BacNhoTheoCap> _listBacnhotheocap;
    private List<TabBacnhoCoban.BacNhoTheoCapCungVe> _listBacnhotheocapcungve;
    private List<TabBacnhoCoban.BacNhoTheoDauCam> _listBacnhotheodaucam;
    private List<TabBacnhoCoban.BacNhoTheoDitCam> _listBacnhotheoditcam;
    public TabBacnhoCoban.BacNhoTheoGiai ObjTheoGiai;
    public TabBacnhoCoban.BacNhoTheoNhay ObjTheoNhay;
    public TabBacnhoCoban.BacNhoTheoCap ObjTheoCap;
    public TabBacnhoCoban.BacNhoTheoCapCungVe ObjCapCungVe;
    public TabBacnhoCoban.BacNhoTheoDauCam ObjDauCam;
    public TabBacnhoCoban.BacNhoTheoDitCam ObjDitCam;
    private List<TabBacnhoCoban.LoToVeNhieu> _listLotoVeNhieu;
    public List<TabBacnhoCoban.TinhNgayVeLoCap> TinhNgayveLoCap;
    public List<TabBacnhoCoban.TinhNgayVeLoBachThu> TinhNgayveLoBachThu;
    private DataTable _dtLoToNhayVe;
    private DataTable _dtTheoCap;
    private string _strBacNhoCap;
    private DataTable _dtTheoCapLienke;
    private string _strBacNhoCapLienKe;
    private DataTable _dtDauCam;
    private string _strTheoDauCam;
    private DataTable _dtDitCam;
    private string _strTheoDitCam;
    private string strLotoDaLoai;
    private DataTable dtLotoLoai;
    private DataTable dtInfoloto;
    private BunifuElipse bunifuElipse1;
    private WebBrowser webBrowser1;
    private Panel panel2;
    private DateTimePicker dtNgayThang;
    private CheckBox cbTheogiai;
    private CheckBox cbTheocap;
    private CheckBox cbTheonhay;
    private CheckBox cbCapcungve;
    private RadioButton rdCap;
    private ToolTip toolTip1;
    private CheckBox cbDaucam;
    private Timer timer1;
    private BackgroundWorker bgGetNewDay;
    private BackgroundWorker bgListBacNho;
    private BackgroundWorker bgTheoGiai;
    private BackgroundWorker bgTheoNhay;
    private BackgroundWorker bgTheoCap;
    private BackgroundWorker bgCapCungVe;
    private BackgroundWorker bgDauCam;
    private BackgroundWorker bgDataTong;
    public BackgroundWorker bgTinhNgayVe;
    private PictureBox picLoading;
    private Button btnXem;
    private Label label1;
    private BackgroundWorker bgListLotoTuDo;
    private Label label3;
    private Label label2;
    private RadioButton rdBachThu;
    private CheckBox cbDitcam;
    private BackgroundWorker bgDitCam;
    private GroupBox groupBox1;

    public DateTime NgayThangNew { get; set; }

    public TabBacnhoCoban()
    {
      TabBacnhoCoban.Timer = new Timer();
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      TabBacnhoCoban.Timer.Tick += new EventHandler(this.TimerTick);
      this.NgayThangNew = DateTime.Now;
      this.objLoto = new Tbloto();
      if (!this.bgGetNewDay.IsBusy)
        this.bgGetNewDay.RunWorkerAsync();
      this.HienThiKetQua(this.webBrowser1, "");
      if (this.bgListLotoTuDo.IsBusy)
        return;
      this.bgListLotoTuDo.RunWorkerAsync();
    }

    public void TimerTick(object sender, EventArgs e)
    {
      if (!this.bgTinhNgayVe.IsBusy)
        this.bgTinhNgayVe.RunWorkerAsync();
      TabBacnhoCoban.Timer.Stop();
    }

    private void KetQuaDateNew()
    {
      this._loCapBacThu = "Loto [<b style='color:red;'>  Cặp  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhLoCapNuoi + " ngày sau đó :</b>";
      this.NgayThangNew = FMain.NgayKetQuaMoiNhat;
      this._dtLoToVe = new DataTable();
      this._dtLoToVe = this.TaoBangLoCap(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
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
        string loto = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          loto = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        string str1 = this.objLoto.CheckLotoCap(loto);
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
        string str = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          str = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
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

    private void TaoListLotoTuDo()
    {
      this._listLotoTuDo = new List<TabBacnhoCoban.LOTO>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        for (int index2 = 0; index2 < 100; ++index2)
        {
          if (index1 != index2)
          {
            TabBacnhoCoban.LOTO loto = new TabBacnhoCoban.LOTO()
            {
              LOTO1 = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture),
              LOTO2 = index2.ToString((IFormatProvider) CultureInfo.InvariantCulture)
            };
            if (index1 < 10)
              loto.LOTO1 = "0" + (object) index1;
            string lotO1 = loto.LOTO1;
            if (index2 < 10)
              loto.LOTO2 = "0" + (object) index2;
            if (Convert.ToInt32(loto.LOTO1) > Convert.ToInt32(loto.LOTO2))
            {
              loto.LOTO1 = loto.LOTO2;
              loto.LOTO2 = lotO1;
            }
            if (!this._listLotoTuDo.Any<TabBacnhoCoban.LOTO>((Func<TabBacnhoCoban.LOTO, bool>) (item =>
            {
              if (item.LOTO1 == loto.LOTO1)
                return item.LOTO2 == loto.LOTO2;
              return false;
            })))
              this._listLotoTuDo.Add(loto);
          }
        }
      }
    }

    private void GetDataByDate(DateTime ngayThangKiemTra)
    {
      this._listBacnhotheogiai = new List<TabBacnhoCoban.BacNhoTheoGiai>();
      this._listBacnhotheonhay = new List<TabBacnhoCoban.BacNhoTheoNhay>();
      this._listBacnhotheocap = new List<TabBacnhoCoban.BacNhoTheoCap>();
      this._listBacnhotheocapcungve = new List<TabBacnhoCoban.BacNhoTheoCapCungVe>();
      this._listBacnhotheodaucam = new List<TabBacnhoCoban.BacNhoTheoDauCam>();
      this._listBacnhotheoditcam = new List<TabBacnhoCoban.BacNhoTheoDitCam>();
      this._dt = new DataTable();
      this._dt = this.objLoto.GetByDate(ngayThangKiemTra);
      this.GetDataLoVeNgaySau(FMain.ObjConfigBacNho);
      if (!this.bgTinhNgayVe.IsBusy)
        this.bgTinhNgayVe.RunWorkerAsync();
      if (this._dt.Rows.Count > 0)
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
        for (int j = 1; j < this._dt.Columns.Count; j++)
        {
          this.ObjTheoGiai = new TabBacnhoCoban.BacNhoTheoGiai()
          {
            Text = this._dt.Columns[j].ColumnName,
            Value = this._dt.Rows[0][j].ToString()
          };
          this._listBacnhotheogiai.Add(this.ObjTheoGiai);
          if (!this._listBacnhotheonhay.Any<TabBacnhoCoban.BacNhoTheoNhay>((Func<TabBacnhoCoban.BacNhoTheoNhay, bool>) (items => items.Text == this._dt.Rows[0][j].ToString())))
          {
            this.ObjTheoNhay = new TabBacnhoCoban.BacNhoTheoNhay();
            this.ObjTheoNhay = this.TimBacNhoTheoNhay(this._dt, this._dt.Rows[0][j].ToString());
            if (this.ObjTheoNhay.Value != "")
              this._listBacnhotheonhay.Add(this.ObjTheoNhay);
          }
          lotoXuoi = this._dt.Rows[0][j].ToString();
          lotoLon = this.objLoto.CheckLotoCap(this._dt.Rows[0][j].ToString());
          string lotoXuoi;
          string lotoLon;
          if (!this._listBacnhotheocap.Any<TabBacnhoCoban.BacNhoTheoCap>(closure_0 ?? (closure_0 = (Func<TabBacnhoCoban.BacNhoTheoCap, bool>) (items =>
          {
            if (!(items.Text == lotoXuoi))
              return items.Text == lotoLon;
            return true;
          }))))
          {
            this.ObjTheoCap = new TabBacnhoCoban.BacNhoTheoCap();
            this.ObjTheoCap = this.TimBacNhoTheoCap(this._dt, lotoXuoi, lotoLon);
            if (this.ObjTheoCap.Value != "")
              this._listBacnhotheocap.Add(this.ObjTheoCap);
          }
          string lotoTien = (int.Parse(lotoXuoi) + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture);
          if (!this._listBacnhotheocapcungve.Any<TabBacnhoCoban.BacNhoTheoCapCungVe>(closure_1 ?? (closure_1 = (Func<TabBacnhoCoban.BacNhoTheoCapCungVe, bool>) (items => items.Text == lotoXuoi))))
          {
            this.ObjCapCungVe = new TabBacnhoCoban.BacNhoTheoCapCungVe();
            this.ObjCapCungVe = this.TimBacNhoTheoCapCungVe(this._dt, lotoXuoi, lotoTien);
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
            this.ObjDauCam = new TabBacnhoCoban.BacNhoTheoDauCam()
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
            this.ObjDitCam = new TabBacnhoCoban.BacNhoTheoDitCam()
            {
              Text = str,
              Value = this.Text
            };
            this._listBacnhotheoditcam.Add(this.ObjDitCam);
          }
        }
      }
      string str3 = "";
      foreach (TabBacnhoCoban.BacNhoTheoDauCam bacNhoTheoDauCam in this._listBacnhotheodaucam)
      {
        if (bacNhoTheoDauCam.Text != "" && bacNhoTheoDauCam.Value != "")
        {
          str3 += "Đầu câm";
          str3 = str3 + bacNhoTheoDauCam.Text + "-" + bacNhoTheoDauCam.Value + "\r\n";
        }
      }
      foreach (TabBacnhoCoban.BacNhoTheoDitCam bacNhoTheoDitCam in this._listBacnhotheoditcam)
      {
        if (bacNhoTheoDitCam.Text != "" && bacNhoTheoDitCam.Value != "")
          str3 = str3 + "Đít câm" + bacNhoTheoDitCam.Text + "-" + bacNhoTheoDitCam.Value + "\r\n";
      }
    }

    private TabBacnhoCoban.BacNhoTheoCapCungVe TimBacNhoTheoCapCungVe(DataTable dtTable, string lotoXuoi, string lotoTien)
    {
      this.ObjCapCungVe = new TabBacnhoCoban.BacNhoTheoCapCungVe()
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

    private TabBacnhoCoban.BacNhoTheoCap TimBacNhoTheoCap(DataTable dtTable, string lotoXuoi, string lotoLon)
    {
      this.ObjTheoCap = new TabBacnhoCoban.BacNhoTheoCap()
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

    private TabBacnhoCoban.BacNhoTheoNhay TimBacNhoTheoNhay(DataTable dtTable, string lotoSoSanh)
    {
      this.ObjTheoNhay = new TabBacnhoCoban.BacNhoTheoNhay()
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

    private void DTNgayThangValueChanged(object sender, EventArgs e)
    {
      if (this.dtNgayThang.Value > this.NgayThangNew)
        this.dtNgayThang.Value = this.NgayThangNew;
      if (this.bgListBacNho.IsBusy)
        return;
      this.btnXem.Enabled = false;
      this.bgListBacNho.RunWorkerAsync();
    }

    private void BgKetQuaByDate2DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDataByDate(this.dtNgayThang.Value);
    }

    private void GetDataTong()
    {
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
      this.DtTong = new DataTable();
      this.DtTong = this.objLoto.GetLotoByNgayThang(this.dtNgayThang.Value.AddMonths(-num), this.dtNgayThang.Value);
    }

    private void HienThiKetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.StrCss1 + "<title>THỐNG KÊ XỔ SỐ</title></head><body  style='font-family:Verdana;'><div class='container' style='margin-right:15px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ></div><div class='panel-body'><ul class='media-list'><li class='media'>" + strHtml + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void BgKeQuaMoiNhatDoWork(object sender, DoWorkEventArgs e)
    {
      this.KetQuaDateNew();
    }

    private void BgKeQuaMoiNhatRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.dtNgayThang.Value = this.NgayThangNew;
    }

    private void BgTheoNhayDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoNhay();
    }

    private void BgTheoGiaiDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoGiai();
    }

    private void BgDataTongDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDataTong();
      this._listLotoVeNhieu = new List<TabBacnhoCoban.LoToVeNhieu>();
    }

    private void BgDataTongRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.cbTheogiai.Checked && !this.bgTheoGiai.IsBusy)
        this.bgTheoGiai.RunWorkerAsync();
      if (this.cbTheonhay.Checked && !this.bgTheoNhay.IsBusy)
        this.bgTheoNhay.RunWorkerAsync();
      if (this.cbTheocap.Checked && !this.bgTheoCap.IsBusy)
        this.bgTheoCap.RunWorkerAsync();
      if (this.cbCapcungve.Checked && !this.bgCapCungVe.IsBusy)
        this.bgCapCungVe.RunWorkerAsync();
      if (this.cbDaucam.Checked && !this.bgDauCam.IsBusy)
        this.bgDauCam.RunWorkerAsync();
      if (!this.cbDitcam.Checked || this.bgDitCam.IsBusy)
        return;
      this.bgDitCam.RunWorkerAsync();
    }

    private void BgListBacNhoRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.btnXem.Enabled = true;
    }

    private void LoadDuLieuCapBachThu()
    {
      if (this.rdCap.Checked)
      {
        this._loCapBacThu = "Loto [<b style='color:red;'>  Cặp  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhLoCapNuoi + " ngày sau đó :</b>";
      }
      else
      {
        if (!this.rdBachThu.Checked)
          return;
        this._loCapBacThu = "Loto [<b style='color:red;'>  Bạch Thủ  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhBachThuNuoi + " ngày sau đó :</b>";
      }
    }

    private void XuLyLoToVeNhieu(string lotoXuoi, string lotoLon)
    {
      if (FMain.ObjConfigBacNho.HienThiNgayVe != 1)
        return;
      TabBacnhoCoban.LoToVeNhieu loToVeNhieu = new TabBacnhoCoban.LoToVeNhieu();
      string str = lotoXuoi + "-" + lotoLon;
      if (this.rdBachThu.Checked)
        str = lotoXuoi;
      if (this._listLotoVeNhieu.Count > 0)
      {
        bool flag = false;
        for (int index = 0; index < this._listLotoVeNhieu.Count; ++index)
        {
          if (this._listLotoVeNhieu[index].Loto == str)
          {
            flag = true;
            ++this._listLotoVeNhieu[index].TongSoLanVe;
            break;
          }
        }
        if (!flag)
        {
          loToVeNhieu.Loto = str;
          ++loToVeNhieu.TongSoLanVe;
        }
      }
      else
      {
        loToVeNhieu.Loto = str;
        ++loToVeNhieu.TongSoLanVe;
      }
      this._listLotoVeNhieu.Add(loToVeNhieu);
    }

    private string ChechVeNgay(string lotoXuoi, string lotoLon)
    {
      string str1 = "";
      if (this.rdCap.Checked)
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
        {
          if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi || tinhNgayVeLoCap.Lotolon == lotoLon)
          {
            string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      else if (this.rdBachThu.Checked)
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoBachThu tinhNgayVeLoBachThu in this.TinhNgayveLoBachThu)
        {
          if (tinhNgayVeLoBachThu.LotoXuoi == lotoXuoi)
          {
            string str2 = tinhNgayVeLoBachThu.SoNhayVeLotoXuoi;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoBachThu.MauSac + ";'>" + tinhNgayVeLoBachThu.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      return str1;
    }

    private void GetDataLoVeNgaySau(tbConfigBacNho objBacNho)
    {
      int num = objBacNho.KhungDanhLoCapNuoi;
      if (objBacNho.KhungDanhBachThuNuoi > objBacNho.KhungDanhLoCapNuoi)
        num = objBacNho.KhungDanhBachThuNuoi;
      this.DtLoToVeNgaySau = new DataTable();
      this.DtLoToVeNgaySau = this.objLoto.GetLotoByNgayThangSoBanGhi(this.dtNgayThang.Value, num + 2);
    }

    private void TimNgayVeLoBachThu(int soBanGhi)
    {
      this.TinhNgayveLoBachThu = new List<TabBacnhoCoban.TinhNgayVeLoBachThu>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacnhoCoban.TinhNgayVeLoBachThu tinhNgayVeLoBachThu = new TabBacnhoCoban.TinhNgayVeLoBachThu();
        string str1 = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          str1 = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        string str2 = "";
        bool flag = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.DtLoToVeNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str2 = str1;
          for (int index3 = 2; index3 < this.DtLoToVeNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.DtLoToVeNgaySau.Rows[index2][index3].ToString();
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
            str3 = " Về ngày " + (index2 + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture);
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

    private void TimNgayVeLoCap(int soBanGhi)
    {
      this.TinhNgayveLoCap = new List<TabBacnhoCoban.TinhNgayVeLoCap>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacnhoCoban.TinhNgayVeLoCap tinhNgayVeLoCap = new TabBacnhoCoban.TinhNgayVeLoCap();
        string loto = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          loto = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        string str1 = this.objLoto.CheckLotoCap(loto);
        string str2 = "";
        string str3 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str4 = " Chưa về";
        string str5 = "Black";
        int num = this.DtLoToVeNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str2 = loto;
          str3 = str1;
          for (int index3 = 2; index3 < this.DtLoToVeNgaySau.Columns.Count; ++index3)
          {
            string str6 = this.DtLoToVeNgaySau.Rows[index2][index3].ToString();
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
            str4 = " Về ngày " + (index2 + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture);
            break;
          }
        }
        if (!flag2)
          str3 = "";
        if (!flag1)
          str2 = "";
        if (!flag1 && !flag2)
          str4 = num < soBanGhi ? " Chưa về" : " Xịt";
        tinhNgayVeLoCap.LotoXuoi = loto;
        tinhNgayVeLoCap.Lotolon = str1;
        tinhNgayVeLoCap.VeNgay = str4;
        tinhNgayVeLoCap.MauSac = str5;
        tinhNgayVeLoCap.SoNhayVeLotoXuoi = str2;
        tinhNgayVeLoCap.SoNhayVeLotoLon = str3;
        this.TinhNgayveLoCap.Add(tinhNgayVeLoCap);
      }
    }

    private void BgTinhNgayVeDoWork(object sender, DoWorkEventArgs e)
    {
      this.TimNgayVeLoCap(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
      this.TimNgayVeLoBachThu(FMain.ObjConfigBacNho.KhungDanhBachThuNuoi);
    }

    public void Timer1Tick(object sender, EventArgs e)
    {
      if (this.bgGetNewDay.IsBusy || this.bgListBacNho.IsBusy || (this.bgTheoGiai.IsBusy || this.bgTheoCap.IsBusy) || (this.bgTheoNhay.IsBusy || this.bgTheoCap.IsBusy || (this.bgCapCungVe.IsBusy || this.bgDataTong.IsBusy)) || this.bgTinhNgayVe.IsBusy || this.bgDauCam.IsBusy)
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

    private void GetDaTaBacNhoTheoGiai()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoGiai);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this._strBacNhoGiai = "";
      for (int thutu = 0; thutu < this._listBacnhotheogiai.Count; ++thutu)
      {
        this._dt = new DataTable();
        this._dt = this.GetDataTungGiai(ngayBatDau, ngayKetThuc, thutu);
        this._strBacNhoGiai += this.XuLyDuLieuTungGiai(this._dt, this._listBacnhotheogiai[thutu].Text, this._listBacnhotheogiai[thutu].Value);
      }
    }

    private DataTable GetDataTungGiai(DateTime ngayBatDau, DateTime ngayKetThuc, int thutu)
    {
      this._dt = new DataTable();
      DataRow[] dataRowArray = this.DtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and " + this._listBacnhotheogiai[thutu].Text + "='" + this._listBacnhotheogiai[thutu].Value + "'");
      if ((uint) dataRowArray.Length > 0U)
        this._dt = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return this._dt;
    }

    private string XuLyDuLieuTungGiai(DataTable dtGiai, string giai, string loto)
    {
      string str1 = "";
      string str2;
      if (giai == "G0")
        str2 = str1 + "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ " + this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoGiai).ToString("dd/MM/yyyy") + " đến ngày " + this.dtNgayThang.Value.ToString("dd/MM/yyyy") + ", Giải [<b style='color:red;'> ĐẶC BIỆT </b>] về lô (<b style='color:red;'>  " + loto + "  </b>) tất cả <b style='color:red;'>  " + (object) dtGiai.Rows.Count + "  </b> lần. " + this._loCapBacThu + "</br>";
      else
        str2 = str1 + "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ " + this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoGiai).ToString("dd/MM/yyyy") + " đến ngày " + this.dtNgayThang.Value.ToString("dd/MM/yyyy") + ", Giải [<b style='color:red;'> " + giai + " </b>] về lô (<b style='color:red;'>  " + loto + "  </b>) tất cả <b style='color:red;'>  " + (object) dtGiai.Rows.Count + "  </b> lần. " + this._loCapBacThu + "</br>";
      this._dtLoToVe = new DataTable();
      int khungDanh;
      if (this.rdBachThu.Checked)
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
        this._dtLoToVe = this.TaoBangLoBachThu(khungDanh);
      }
      else
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
        this._dtLoToVe = this.TaoBangLoCap(khungDanh);
      }
      for (int index = 0; index < dtGiai.Rows.Count; ++index)
        this.XuLyLoToNgaySauTheoGiai(int.Parse(dtGiai.Rows[index]["STT"].ToString()), khungDanh);
      DataView defaultView = this._dtLoToVe.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this._dtLoToVe = defaultView.ToTable();
      float count = (float) dtGiai.Rows.Count;
      for (int index1 = 0; index1 < FMain.ObjConfigBacNho.SoBanGhi; ++index1)
      {
        string lotoXuoi = this._dtLoToVe.Rows[index1]["loto1"].ToString();
        string lotoLon = this._dtLoToVe.Rows[index1]["loto2"].ToString();
        string s = this._dtLoToVe.Rows[index1]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(lotoXuoi, lotoLon);
        string str3 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str4;
        if (lotoXuoi == lotoLon)
          str4 = str2 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str3 + ". Trong đó ";
        else
          str4 = str2 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + "-" + lotoLon + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str3 + ". Trong đó ";
        for (int index2 = 0; index2 < khungDanh; ++index2)
          str4 = str4 + " <b>" + this._dtLoToVe.Rows[index1][index2 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index2 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str4 += this.ChechVeNgay(lotoXuoi, lotoLon);
        str2 = str4 + "<br>";
      }
      return str2;
    }

    private void XuLyLoToNgaySauTheoGiai(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.DtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      DataTable dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      for (int index1 = 0; index1 < this._dtLoToVe.Rows.Count; ++index1)
      {
        string str1 = this._dtLoToVe.Rows[index1][0].ToString();
        string str2 = this._dtLoToVe.Rows[index1][1].ToString();
        bool flag = false;
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3 || str2 == str3)
            {
              index2 = index3 + 2;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if (flag)
        {
          this._dtLoToVe.Rows[index1][index2] = (object) (int.Parse(this._dtLoToVe.Rows[index1][index2].ToString()) + 1);
          this._dtLoToVe.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this._dtLoToVe.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private void GetDaTaBacNhoTheoNhay()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoNhay);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this._strBacNhoNhay = "";
      if (this._listBacnhotheonhay.Count <= 0)
        return;
      for (int thutu = 0; thutu < this._listBacnhotheonhay.Count; ++thutu)
        this._strBacNhoNhay += this.XuLyDuLieuTungNhay(this.GetDataTungNhay(ngayBatDau, ngayKetThuc, thutu), this._listBacnhotheonhay[thutu]);
    }

    private DataTable GetDataTungNhay(DateTime ngayBatDau, DateTime ngayKetThuc, int thutu)
    {
      DataTable dataTable1 = new DataTable();
      dataTable1.Columns.Add("STT");
      string text = this._listBacnhotheonhay[thutu].Text;
      DataRow[] dataRowArray = this.DtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and (G0='" + text + "' or G1='" + text + "' or G21='" + text + "' or G22='" + text + "'or G31='" + text + "' or G32='" + text + "'or G33='" + text + "'or G34='" + text + "'or G35='" + text + "'or G36='" + text + "'or G41='" + text + "'or G42='" + text + "'or G43='" + text + "'or G44='" + text + "'or G51='" + text + "'or G52='" + text + "'or G53='" + text + "'or G54='" + text + "'or G55='" + text + "'or G56='" + text + "'or G61='" + text + "'or G62='" + text + "'or G63='" + text + "'or G71='" + text + "'or G72='" + text + "'or G73='" + text + "'or G74='" + text + "')");
      if ((uint) dataRowArray.Length > 0U)
      {
        DataTable dataTable2 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        if (dataTable2.Rows.Count > 0)
        {
          for (int index1 = 0; index1 < dataTable2.Rows.Count; ++index1)
          {
            int num = 0;
            for (int index2 = 0; index2 < dataTable2.Columns.Count; ++index2)
            {
              if (dataTable2.Rows[index1][index2].ToString() == text)
                ++num;
            }
            if (num > 1)
            {
              DataRow row = dataTable1.NewRow();
              row["STT"] = (object) dataTable2.Rows[index1]["STT"].ToString();
              dataTable1.Rows.Add(row);
            }
          }
        }
      }
      return dataTable1;
    }

    private string XuLyDuLieuTungNhay(DataTable dtTheoNhay, TabBacnhoCoban.BacNhoTheoNhay objNhay)
    {
      string str1 = "";
      object[] objArray = new object[12];
      objArray[0] = (object) str1;
      objArray[1] = (object) "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ ";
      int index1 = 2;
      DateTime dateTime = this.dtNgayThang.Value;
      dateTime = dateTime.AddMonths(-FMain.ObjConfigBacNho.TheoNhay);
      string str2 = dateTime.ToString("dd/MM/yyyy");
      objArray[index1] = (object) str2;
      objArray[3] = (object) " đến ngày ";
      objArray[4] = (object) this.dtNgayThang.Value.ToString("dd/MM/yyyy");
      objArray[5] = (object) ", Loto [<b style='color:red;'> ";
      objArray[6] = (object) objNhay.Text;
      objArray[7] = (object) " </b>] về từ 2 nháy trở lên tất cả <b style='color:red;'>  ";
      objArray[8] = (object) dtTheoNhay.Rows.Count;
      objArray[9] = (object) "  </b> lần. ";
      objArray[10] = (object) this._loCapBacThu;
      objArray[11] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this._dtLoToNhayVe = new DataTable();
      int khungDanh;
      if (this.rdBachThu.Checked)
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
        this._dtLoToNhayVe = this.TaoBangLoBachThu(khungDanh);
      }
      else
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
        this._dtLoToNhayVe = this.TaoBangLoCap(khungDanh);
      }
      for (int index2 = 0; index2 < dtTheoNhay.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoNhay(int.Parse(dtTheoNhay.Rows[index2]["STT"].ToString()), khungDanh);
      DataView defaultView = this._dtLoToNhayVe.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this._dtLoToNhayVe = defaultView.ToTable();
      float count = (float) dtTheoNhay.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string lotoXuoi = this._dtLoToNhayVe.Rows[index2]["loto1"].ToString();
        string lotoLon = this._dtLoToNhayVe.Rows[index2]["loto2"].ToString();
        string s = this._dtLoToNhayVe.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(lotoXuoi, lotoLon);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5;
        if (lotoXuoi == lotoLon)
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        else
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + "-" + lotoLon + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < khungDanh; ++index3)
          str5 = str5 + " <b>" + this._dtLoToNhayVe.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoNhay(lotoXuoi, lotoLon);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoNhay(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.DtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtLoToNhayVe.Rows.Count; ++index1)
      {
        string str1 = this._dtLoToNhayVe.Rows[index1][0].ToString();
        string str2 = this._dtLoToNhayVe.Rows[index1][1].ToString();
        bool flag = false;
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3 || str2 == str3)
            {
              index2 = index3 + 2;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if (flag)
        {
          this._dtLoToNhayVe.Rows[index1][index2] = (object) (int.Parse(this._dtLoToNhayVe.Rows[index1][index2].ToString()) + 1);
          this._dtLoToNhayVe.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this._dtLoToNhayVe.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoNhay(string lotoXuoi, string lotoLon)
    {
      string str1 = "";
      if (this.rdCap.Checked)
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
        {
          if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi || tinhNgayVeLoCap.Lotolon == lotoLon)
          {
            string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      else
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoBachThu tinhNgayVeLoBachThu in this.TinhNgayveLoBachThu)
        {
          if (tinhNgayVeLoBachThu.LotoXuoi == lotoXuoi)
          {
            string str2 = tinhNgayVeLoBachThu.SoNhayVeLotoXuoi;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoBachThu.MauSac + ";'>" + tinhNgayVeLoBachThu.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      return str1;
    }

    private void GetDaTaBacNhoTheoCap()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoCap);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this._strBacNhoCap = "";
      if (this._listBacnhotheocap.Count <= 0)
        return;
      for (int index = 0; index < this._listBacnhotheocap.Count; ++index)
        this._strBacNhoCap += this.XuLyDuLieuTungCap(this.GetDataTungCap(ngayBatDau, ngayKetThuc, this._listBacnhotheocap[index]), this._listBacnhotheocap[index]);
    }

    private DataTable GetDataTungCap(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacnhoCoban.BacNhoTheoCap objNhoTheoCap)
    {
      DataTable dataTable = new DataTable();
      string text = objNhoTheoCap.Text;
      string str = objNhoTheoCap.Value;
      DataRow[] dataRowArray = this.DtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and (G0='" + text + "' or G1='" + text + "' or G21='" + text + "' or G22='" + text + "'or G31='" + text + "' or G32='" + text + "'or G33='" + text + "'or G34='" + text + "'or G35='" + text + "'or G36='" + text + "'or G41='" + text + "'or G42='" + text + "'or G43='" + text + "'or G44='" + text + "'or G51='" + text + "'or G52='" + text + "'or G53='" + text + "'or G54='" + text + "'or G55='" + text + "'or G56='" + text + "'or G61='" + text + "'or G62='" + text + "'or G63='" + text + "'or G71='" + text + "'or G72='" + text + "'or G73='" + text + "'or G74='" + text + "')and (G0='" + str + "' or G1='" + str + "' or G21='" + str + "' or G22='" + str + "'or G31='" + str + "' or G32='" + str + "'or G33='" + str + "'or G34='" + str + "'or G35='" + str + "'or G36='" + str + "'or G41='" + str + "'or G42='" + str + "'or G43='" + str + "'or G44='" + str + "'or G51='" + str + "'or G52='" + str + "'or G53='" + str + "'or G54='" + str + "'or G55='" + str + "'or G56='" + str + "'or G61='" + str + "'or G62='" + str + "'or G63='" + str + "'or G71='" + str + "'or G72='" + str + "'or G73='" + str + "'or G74='" + str + "')");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungCap(DataTable dtTam, TabBacnhoCoban.BacNhoTheoCap objCap)
    {
      string str1 = "";
      object[] objArray = new object[14];
      objArray[0] = (object) str1;
      objArray[1] = (object) "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ ";
      int index1 = 2;
      DateTime dateTime = this.dtNgayThang.Value;
      dateTime = dateTime.AddMonths(-FMain.ObjConfigBacNho.TheoCap);
      string str2 = dateTime.ToString("dd/MM/yyyy");
      objArray[index1] = (object) str2;
      objArray[3] = (object) " đến ngày ";
      objArray[4] = (object) this.dtNgayThang.Value.ToString("dd/MM/yyyy");
      objArray[5] = (object) ", Loto [<b style='color:red;'> ";
      objArray[6] = (object) objCap.Text;
      objArray[7] = (object) "-";
      objArray[8] = (object) objCap.Value;
      objArray[9] = (object) " </b>] về cùng nhau tất cả <b style='color:red;'>  ";
      objArray[10] = (object) dtTam.Rows.Count;
      objArray[11] = (object) "  </b> lần. ";
      objArray[12] = (object) this._loCapBacThu;
      objArray[13] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this._dtTheoCap = new DataTable();
      int khungDanh;
      if (this.rdBachThu.Checked)
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
        this._dtTheoCap = this.TaoBangLoBachThu(khungDanh);
      }
      else
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
        this._dtTheoCap = this.TaoBangLoCap(khungDanh);
      }
      for (int index2 = 0; index2 < dtTam.Rows.Count; ++index2)
      {
        int soThuTuBanGhi = int.Parse(dtTam.Rows[index2]["STT"].ToString());
        if (this._dtTheoCap.Rows.Count > 0)
          this.XuLyLoToNgaySauTheoCap(soThuTuBanGhi, khungDanh);
      }
      DataView defaultView = this._dtTheoCap.DefaultView;
      defaultView.Sort = "tongSOLAN desc";
      this._dtTheoCap = defaultView.ToTable();
      float count = (float) dtTam.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string lotoXuoi = this._dtTheoCap.Rows[index2]["loto1"].ToString();
        string lotoLon = this._dtTheoCap.Rows[index2]["loto2"].ToString();
        string s = this._dtTheoCap.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(lotoXuoi, lotoLon);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5;
        if (lotoXuoi == lotoLon)
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        else
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + "-" + lotoLon + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < khungDanh; ++index3)
          str5 = str5 + " <b>" + this._dtTheoCap.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoCap(lotoXuoi, lotoLon);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoCap(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.DtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtTheoCap.Rows.Count; ++index1)
      {
        string str1 = this._dtTheoCap.Rows[index1][0].ToString();
        string str2 = this._dtTheoCap.Rows[index1][1].ToString();
        bool flag = false;
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3 || str2 == str3)
            {
              index2 = index3 + 2;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if (flag)
        {
          this._dtTheoCap.Rows[index1][index2] = (object) (int.Parse(this._dtTheoCap.Rows[index1][index2].ToString()) + 1);
          this._dtTheoCap.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this._dtTheoCap.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoCap(string lotoXuoi, string lotoLon)
    {
      string str1 = "";
      if (this.rdCap.Checked)
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
        {
          if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi || tinhNgayVeLoCap.Lotolon == lotoLon)
          {
            string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      else
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoBachThu tinhNgayVeLoBachThu in this.TinhNgayveLoBachThu)
        {
          if (tinhNgayVeLoBachThu.LotoXuoi == lotoXuoi)
          {
            string str2 = tinhNgayVeLoBachThu.SoNhayVeLotoXuoi;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoBachThu.MauSac + ";'>" + tinhNgayVeLoBachThu.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      return str1;
    }

    private void GetDaTaBacNhoTheoCapLienKe()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.CapCungVe);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this._strBacNhoCapLienKe = "";
      if (this._listBacnhotheocapcungve.Count <= 0)
        return;
      for (int index = 0; index < this._listBacnhotheocapcungve.Count; ++index)
        this._strBacNhoCapLienKe += this.XuLyDuLieuTungCapLienKe(this.GetDataTungCapLienKe(ngayBatDau, ngayKetThuc, this._listBacnhotheocapcungve[index]), this._listBacnhotheocapcungve[index]);
    }

    private DataTable GetDataTungCapLienKe(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacnhoCoban.BacNhoTheoCapCungVe objNhoTheoCapCungVe)
    {
      DataTable dataTable = new DataTable();
      string text = objNhoTheoCapCungVe.Text;
      string str = objNhoTheoCapCungVe.Value;
      DataRow[] dataRowArray = this.DtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and (G0='" + text + "' or G1='" + text + "' or G21='" + text + "' or G22='" + text + "'or G31='" + text + "' or G32='" + text + "'or G33='" + text + "'or G34='" + text + "'or G35='" + text + "'or G36='" + text + "'or G41='" + text + "'or G42='" + text + "'or G43='" + text + "'or G44='" + text + "'or G51='" + text + "'or G52='" + text + "'or G53='" + text + "'or G54='" + text + "'or G55='" + text + "'or G56='" + text + "'or G61='" + text + "'or G62='" + text + "'or G63='" + text + "'or G71='" + text + "'or G72='" + text + "'or G73='" + text + "'or G74='" + text + "')and (G0='" + str + "' or G1='" + str + "' or G21='" + str + "' or G22='" + str + "'or G31='" + str + "' or G32='" + str + "'or G33='" + str + "'or G34='" + str + "'or G35='" + str + "'or G36='" + str + "'or G41='" + str + "'or G42='" + str + "'or G43='" + str + "'or G44='" + str + "'or G51='" + str + "'or G52='" + str + "'or G53='" + str + "'or G54='" + str + "'or G55='" + str + "'or G56='" + str + "'or G61='" + str + "'or G62='" + str + "'or G63='" + str + "'or G71='" + str + "'or G72='" + str + "'or G73='" + str + "'or G74='" + str + "')");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungCapLienKe(DataTable dtTam, TabBacnhoCoban.BacNhoTheoCapCungVe objNhoTheoCapCungVe)
    {
      string str1 = "";
      object[] objArray = new object[14];
      objArray[0] = (object) str1;
      objArray[1] = (object) "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ ";
      int index1 = 2;
      DateTime dateTime = this.dtNgayThang.Value;
      dateTime = dateTime.AddMonths(-FMain.ObjConfigBacNho.CapCungVe);
      string str2 = dateTime.ToString("dd/MM/yyyy");
      objArray[index1] = (object) str2;
      objArray[3] = (object) " đến ngày ";
      objArray[4] = (object) this.dtNgayThang.Value.ToString("dd/MM/yyyy");
      objArray[5] = (object) ", Loto [<b style='color:red;'> ";
      objArray[6] = (object) objNhoTheoCapCungVe.Text;
      objArray[7] = (object) "-";
      objArray[8] = (object) objNhoTheoCapCungVe.Value;
      objArray[9] = (object) " </b>] về cùng nhau tất cả <b style='color:red;'>  ";
      objArray[10] = (object) dtTam.Rows.Count;
      objArray[11] = (object) "  </b> lần. ";
      objArray[12] = (object) this._loCapBacThu;
      objArray[13] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this._dtTheoCapLienke = new DataTable();
      int khungDanh;
      if (this.rdBachThu.Checked)
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
        this._dtTheoCapLienke = this.TaoBangLoBachThu(khungDanh);
      }
      else
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
        this._dtTheoCapLienke = this.TaoBangLoCap(khungDanh);
      }
      for (int index2 = 0; index2 < dtTam.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoCapLienKe(int.Parse(dtTam.Rows[index2]["STT"].ToString()), khungDanh);
      DataView defaultView = this._dtTheoCapLienke.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this._dtTheoCapLienke = defaultView.ToTable();
      float count = (float) dtTam.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string lotoXuoi = this._dtTheoCapLienke.Rows[index2]["loto1"].ToString();
        string lotoLon = this._dtTheoCapLienke.Rows[index2]["loto2"].ToString();
        string s = this._dtTheoCapLienke.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(lotoXuoi, lotoLon);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5;
        if (lotoXuoi == lotoLon)
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        else
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + "-" + lotoLon + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < khungDanh; ++index3)
          str5 = str5 + " <b>" + this._dtTheoCapLienke.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoCapLienKe(lotoXuoi, lotoLon);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoCapLienKe(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.DtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtTheoCapLienke.Rows.Count; ++index1)
      {
        string str1 = this._dtTheoCapLienke.Rows[index1][0].ToString();
        string str2 = this._dtTheoCapLienke.Rows[index1][1].ToString();
        bool flag = false;
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3 || str2 == str3)
            {
              index2 = index3 + 2;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if (flag)
        {
          this._dtTheoCapLienke.Rows[index1][index2] = (object) (int.Parse(this._dtTheoCapLienke.Rows[index1][index2].ToString()) + 1);
          this._dtTheoCapLienke.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this._dtTheoCapLienke.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoCapLienKe(string lotoXuoi, string lotoLon)
    {
      string str1 = "";
      if (this.rdCap.Checked)
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
        {
          if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi || tinhNgayVeLoCap.Lotolon == lotoLon)
          {
            string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      else
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoBachThu tinhNgayVeLoBachThu in this.TinhNgayveLoBachThu)
        {
          if (tinhNgayVeLoBachThu.LotoXuoi == lotoXuoi)
          {
            string str2 = tinhNgayVeLoBachThu.SoNhayVeLotoXuoi;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoBachThu.MauSac + ";'>" + tinhNgayVeLoBachThu.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      return str1;
    }

    private void GetDaTaBacNhoDauCam()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.DauCam);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this._strTheoDauCam = "";
      if (this._listBacnhotheodaucam.Count <= 0)
        return;
      for (int index = 0; index < this._listBacnhotheodaucam.Count; ++index)
      {
        DataTable dataTungDauCam = this.GetDataTungDauCam(ngayBatDau, ngayKetThuc, this._listBacnhotheodaucam[index]);
        if (dataTungDauCam.Rows.Count > 0)
          this._strTheoDauCam += this.XuLyDuLieuTungDauCam(dataTungDauCam, this._listBacnhotheodaucam[index]);
      }
    }

    private DataTable GetDataTungDauCam(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacnhoCoban.BacNhoTheoDauCam objDauCam)
    {
      DataTable dataTable = new DataTable();
      string text = objDauCam.Text;
      DataRow[] dataRowArray = this.DtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and SUBSTRING(G0,1,1)<>'" + text + "'and SUBSTRING(G1,1,1)<>'" + text + "'and SUBSTRING(G21,1,1)<>'" + text + "' and SUBSTRING(G22,1,1)<>'" + text + "'and SUBSTRING(G31,1,1)<>'" + text + "' and SUBSTRING(G32,1,1)<>'" + text + "'and SUBSTRING(G33,1,1)<>'" + text + "'and SUBSTRING(G34,1,1)<>'" + text + "'and SUBSTRING(G35,1,1)<>'" + text + "'and SUBSTRING(G36,1,1)<>'" + text + "'and SUBSTRING(G41,1,1)<>'" + text + "'and SUBSTRING(G42,1,1)<>'" + text + "'and SUBSTRING(G43,1,1)<>'" + text + "'and SUBSTRING(G44,1,1)<>'" + text + "'and SUBSTRING(G51,1,1)<>'" + text + "'and SUBSTRING(G52,1,1)<>'" + text + "'and SUBSTRING(G53,1,1)<>'" + text + "'and SUBSTRING(G54,1,1)<>'" + text + "'and SUBSTRING(G55,1,1)<>'" + text + "'and SUBSTRING(G56,1,1)<>'" + text + "'and SUBSTRING(G61,1,1)<>'" + text + "'and SUBSTRING(G62,1,1)<>'" + text + "'and SUBSTRING(G63,1,1)<>'" + text + "'and SUBSTRING(G71,1,1)<>'" + text + "'and SUBSTRING(G72,1,1)<>'" + text + "'and SUBSTRING(G73,1,1)<>'" + text + "'and SUBSTRING(G74,1,1)<>'" + text + "'");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungDauCam(DataTable dtTam, TabBacnhoCoban.BacNhoTheoDauCam objDauCam)
    {
      string str1 = "";
      object[] objArray = new object[12];
      objArray[0] = (object) str1;
      objArray[1] = (object) "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ ";
      int index1 = 2;
      DateTime dateTime = this.dtNgayThang.Value;
      dateTime = dateTime.AddMonths(-FMain.ObjConfigBacNho.DauCam);
      string str2 = dateTime.ToString("dd/MM/yyyy");
      objArray[index1] = (object) str2;
      objArray[3] = (object) " đến ngày ";
      objArray[4] = (object) this.dtNgayThang.Value.ToString("dd/MM/yyyy");
      objArray[5] = (object) ", Đầu [<b style='color:red;'> ";
      objArray[6] = (object) objDauCam.Text;
      objArray[7] = (object) " </b>] câm tất cả <b style='color:red;'>  ";
      objArray[8] = (object) dtTam.Rows.Count;
      objArray[9] = (object) "  </b> lần. ";
      objArray[10] = (object) this._loCapBacThu;
      objArray[11] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this._dtDauCam = new DataTable();
      int khungDanh;
      if (this.rdBachThu.Checked)
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
        this._dtDauCam = this.TaoBangLoBachThu(khungDanh);
      }
      else
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
        this._dtDauCam = this.TaoBangLoCap(khungDanh);
      }
      for (int index2 = 0; index2 < dtTam.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoDauCam(int.Parse(dtTam.Rows[index2]["STT"].ToString()), khungDanh);
      DataView defaultView = this._dtDauCam.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this._dtDauCam = defaultView.ToTable();
      float count = (float) dtTam.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string lotoXuoi = this._dtDauCam.Rows[index2]["loto1"].ToString();
        string lotoLon = this._dtDauCam.Rows[index2]["loto2"].ToString();
        string s = this._dtDauCam.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(lotoXuoi, lotoLon);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5;
        if (lotoXuoi == lotoLon)
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        else
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + "-" + lotoLon + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < khungDanh; ++index3)
          str5 = str5 + " <b>" + this._dtDauCam.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoDauCam(lotoXuoi, lotoLon);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoDauCam(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.DtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtDauCam.Rows.Count; ++index1)
      {
        string str1 = this._dtDauCam.Rows[index1][0].ToString();
        string str2 = this._dtDauCam.Rows[index1][1].ToString();
        bool flag = false;
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3 || str2 == str3)
            {
              index2 = index3 + 2;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if (flag)
        {
          this._dtDauCam.Rows[index1][index2] = (object) (int.Parse(this._dtDauCam.Rows[index1][index2].ToString()) + 1);
          this._dtDauCam.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this._dtDauCam.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoDauCam(string lotoXuoi, string lotoLon)
    {
      string str1 = "";
      if (this.rdCap.Checked)
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
        {
          if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi || tinhNgayVeLoCap.Lotolon == lotoLon)
          {
            string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      else
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoBachThu tinhNgayVeLoBachThu in this.TinhNgayveLoBachThu)
        {
          if (tinhNgayVeLoBachThu.LotoXuoi == lotoXuoi)
          {
            string str2 = tinhNgayVeLoBachThu.SoNhayVeLotoXuoi;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoBachThu.MauSac + ";'>" + tinhNgayVeLoBachThu.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      return str1;
    }

    private void GetDaTaBacNhoDitCam()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.DuoiCam);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this._strTheoDitCam = "";
      if (this._listBacnhotheoditcam.Count <= 0)
        return;
      for (int index = 0; index < this._listBacnhotheoditcam.Count; ++index)
      {
        DataTable dataTungDitCam = this.GetDataTungDitCam(ngayBatDau, ngayKetThuc, this._listBacnhotheoditcam[index]);
        if (dataTungDitCam.Rows.Count > 0)
          this._strTheoDitCam += this.XuLyDuLieuTungDitCam(dataTungDitCam, this._listBacnhotheoditcam[index]);
      }
    }

    private DataTable GetDataTungDitCam(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacnhoCoban.BacNhoTheoDitCam bacNhoTheoDitCam)
    {
      DataTable dataTable = new DataTable();
      string text = bacNhoTheoDitCam.Text;
      DataRow[] dataRowArray = this.DtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and SUBSTRING(G0,2,1)<>'" + text + "'and SUBSTRING(G1,2,1)<>'" + text + "'and SUBSTRING(G21,2,1)<>'" + text + "' and SUBSTRING(G22,2,1)<>'" + text + "'and SUBSTRING(G31,2,1)<>'" + text + "' and SUBSTRING(G32,2,1)<>'" + text + "'and SUBSTRING(G33,2,1)<>'" + text + "'and SUBSTRING(G34,2,1)<>'" + text + "'and SUBSTRING(G35,2,1)<>'" + text + "'and SUBSTRING(G36,2,1)<>'" + text + "'and SUBSTRING(G41,2,1)<>'" + text + "'and SUBSTRING(G42,2,1)<>'" + text + "'and SUBSTRING(G43,2,1)<>'" + text + "'and SUBSTRING(G44,2,1)<>'" + text + "'and SUBSTRING(G51,2,1)<>'" + text + "'and SUBSTRING(G52,2,1)<>'" + text + "'and SUBSTRING(G53,2,1)<>'" + text + "'and SUBSTRING(G54,2,1)<>'" + text + "'and SUBSTRING(G55,2,1)<>'" + text + "'and SUBSTRING(G56,2,1)<>'" + text + "'and SUBSTRING(G61,2,1)<>'" + text + "'and SUBSTRING(G62,2,1)<>'" + text + "'and SUBSTRING(G63,2,1)<>'" + text + "'and SUBSTRING(G71,2,1)<>'" + text + "'and SUBSTRING(G72,2,1)<>'" + text + "'and SUBSTRING(G73,2,1)<>'" + text + "'and SUBSTRING(G74,2,1)<>'" + text + "'");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungDitCam(DataTable dtTam, TabBacnhoCoban.BacNhoTheoDitCam bacNhoTheoDitCam)
    {
      string str1 = "";
      object[] objArray = new object[12];
      objArray[0] = (object) str1;
      objArray[1] = (object) "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ ";
      int index1 = 2;
      DateTime dateTime = this.dtNgayThang.Value;
      dateTime = dateTime.AddMonths(-FMain.ObjConfigBacNho.DauCam);
      string str2 = dateTime.ToString("dd/MM/yyyy");
      objArray[index1] = (object) str2;
      objArray[3] = (object) " đến ngày ";
      objArray[4] = (object) this.dtNgayThang.Value.ToString("dd/MM/yyyy");
      objArray[5] = (object) ", Đuôi [<b style='color:red;'> ";
      objArray[6] = (object) bacNhoTheoDitCam.Text;
      objArray[7] = (object) " </b>] câm tất cả <b style='color:red;'>  ";
      objArray[8] = (object) dtTam.Rows.Count;
      objArray[9] = (object) "  </b> lần. ";
      objArray[10] = (object) this._loCapBacThu;
      objArray[11] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this._dtDitCam = new DataTable();
      int khungDanh;
      if (this.rdBachThu.Checked)
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
        this._dtDitCam = this.TaoBangLoBachThu(khungDanh);
      }
      else
      {
        khungDanh = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
        this._dtDitCam = this.TaoBangLoCap(khungDanh);
      }
      for (int index2 = 0; index2 < dtTam.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoDitCam(int.Parse(dtTam.Rows[index2]["STT"].ToString()), khungDanh);
      DataView defaultView = this._dtDitCam.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this._dtDitCam = defaultView.ToTable();
      float count = (float) dtTam.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string lotoXuoi = this._dtDitCam.Rows[index2]["loto1"].ToString();
        string lotoLon = this._dtDitCam.Rows[index2]["loto2"].ToString();
        string s = this._dtDitCam.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(lotoXuoi, lotoLon);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5;
        if (lotoXuoi == lotoLon)
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        else
          str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + lotoXuoi + "-" + lotoLon + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < khungDanh; ++index3)
          str5 = str5 + " <b>" + this._dtDitCam.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoDitCam(lotoXuoi, lotoLon);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoDitCam(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.DtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      DataTable dataTable = new DataTable();
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index1 = 0; index1 < this._dtDitCam.Rows.Count; ++index1)
      {
        string str1 = this._dtDitCam.Rows[index1][0].ToString();
        string str2 = this._dtDitCam.Rows[index1][1].ToString();
        bool flag = false;
        int index2 = 0;
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          for (int index4 = 2; index4 < dataTable.Columns.Count; ++index4)
          {
            string str3 = dataTable.Rows[index3][index4].ToString();
            if (str1 == str3 || str2 == str3)
            {
              index2 = index3 + 2;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if (flag)
        {
          this._dtDitCam.Rows[index1][index2] = (object) (int.Parse(this._dtDitCam.Rows[index1][index2].ToString()) + 1);
          this._dtDitCam.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this._dtDitCam.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoDitCam(string lotoXuoi, string lotoLon)
    {
      string str1 = "";
      if (this.rdCap.Checked)
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
        {
          if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi || tinhNgayVeLoCap.Lotolon == lotoLon)
          {
            string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      else
      {
        foreach (TabBacnhoCoban.TinhNgayVeLoBachThu tinhNgayVeLoBachThu in this.TinhNgayveLoBachThu)
        {
          if (tinhNgayVeLoBachThu.LotoXuoi == lotoXuoi)
          {
            string str2 = tinhNgayVeLoBachThu.SoNhayVeLotoXuoi;
            if (str2.Length > 0)
              str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
            str1 = str1 + "<b style='color:" + tinhNgayVeLoBachThu.MauSac + ";'>" + tinhNgayVeLoBachThu.VeNgay + " " + str2 + "</b>";
            break;
          }
        }
      }
      return str1;
    }

    private void BgTheoCapDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoCap();
    }

    private void BgCapCungVeDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoCapLienKe();
    }

    private void BgDauDitCamDoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoDauCam();
    }

    private string ShowLotoVeNhieu()
    {
      string str = "";
      if (!this.bgTheoGiai.IsBusy && !this.bgTheoCap.IsBusy && (!this.bgTheoNhay.IsBusy && !this.bgTheoCap.IsBusy) && (!this.bgCapCungVe.IsBusy && !this.bgDauCam.IsBusy) && !this.bgDitCam.IsBusy)
      {
        if (this._listLotoVeNhieu.Count > 0)
        {
          str = "<br><div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜ DANH SÁCH CÁC LOTO XUẤT HIỆN NHIỀU TRONG NGÀY ☞ º°”˜`”°☜♥☞</div>" + "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
          this._listLotoVeNhieu.Sort((Comparison<TabBacnhoCoban.LoToVeNhieu>) ((x, y) => y.TongSoLanVe.CompareTo(x.TongSoLanVe)));
          foreach (TabBacnhoCoban.LoToVeNhieu loToVeNhieu in this._listLotoVeNhieu)
          {
            if (loToVeNhieu.TongSoLanVe > 1)
            {
              str = str + "<div style='font-size:14ix;'>- Lô  <b style='color:blue;'> (" + loToVeNhieu.Loto + ") </b> về [ <b style='color:red;'>" + (object) loToVeNhieu.TongSoLanVe + " </b>] lần . ";
              str += this.ChechVeNgay(loToVeNhieu.Loto, this.objLoto.CheckLotoCap(loToVeNhieu.Loto));
              str += "</div>";
            }
            else
              break;
          }
        }
        this.ShowLoToDaloai(this._listLotoVeNhieu);
      }
      return str;
    }

    private void ShowLoToDaloai(List<TabBacnhoCoban.LoToVeNhieu> _listVeNhieu)
    {
      this.strLotoDaLoai = "";
      if (_listVeNhieu.Count <= 0)
        return;
      this.dtLotoLoai = new DataTable();
      this.dtLotoLoai.Columns.Add("stt", typeof (int));
      this.dtLotoLoai.Columns.Add("loto1", typeof (string));
      this.dtLotoLoai.Columns.Add("loto2", typeof (string));
      this.dtLotoLoai.Columns.Add("solanve1", typeof (int));
      this.dtLotoLoai.Columns.Add("solanve2", typeof (int));
      this.dtLotoLoai.Columns.Add("soNhayVe1", typeof (int));
      this.dtLotoLoai.Columns.Add("soNhayVe2", typeof (int));
      this.dtLotoLoai.Columns.Add("ngayChuara1", typeof (int));
      this.dtLotoLoai.Columns.Add("ngayChuara2", typeof (int));
      this.dtLotoLoai.Columns.Add("solanve", typeof (int));
      this.dtLotoLoai.Columns.Add("soNhayVe", typeof (int));
      this.dtLotoLoai.Columns.Add("ngayChuara", typeof (int));
      this.dtLotoLoai.Columns.Add("chuKi", typeof (double));
      this.dtLotoLoai.Columns.Add("maxSobanghi", typeof (int));
      this.dtLotoLoai.Columns.Add("maxGan", typeof (int));
      this.dtLotoLoai.Columns.Add("diemtanxuat", typeof (Decimal));
      this.dtLotoLoai.Columns.Add("diemGan", typeof (Decimal));
      this.dtLotoLoai.Columns.Add("veNgay", typeof (double));
      foreach (TabBacnhoCoban.LoToVeNhieu loToVeNhieu in _listVeNhieu)
        ;
    }

    private void BgTheoGiaiRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._strBacNhoGiai.Length > 0)
      {
        this._strTong += "<br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO GIẢI </b>☞ º°”˜`”°☜♥☞</div>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>giải xổ số về</b> thì những con lô, cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Cấu hình <b style='color:red;'>khung lô bạch thủ nuôi</b> để kiểm tra những con lô bạch thủ hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += this._strBacNhoGiai;
        this._strTong += this.ShowLotoVeNhieu();
      }
      this.HienThiKetQua(this.webBrowser1, this._strTong);
    }

    private void BgTheoNhayRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._strBacNhoNhay.Length > 0)
      {
        this._strTong += "<br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO NHÁY </b>☞ º°”˜`”°☜♥☞</div>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các con lô <b style='color:red;'>về từ 2 nháy trở lên</b> ra, thì những con lô, cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Cấu hình <b style='color:red;'>khung lô bạch thủ nuôi</b> để kiểm tra những con lô bạch thủ hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += this._strBacNhoNhay;
        this._strTong += this.ShowLotoVeNhieu();
      }
      this.HienThiKetQua(this.webBrowser1, this._strTong);
    }

    private void BgTheoCapRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._strBacNhoCap.Length > 0)
      {
        this._strTong += "<br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO CẶP </b>☞ º°”˜`”°☜♥☞</div>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>Cặp lô</b> cùng về, thì những con lô, cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Cấu hình <b style='color:red;'>khung lô bạch thủ nuôi</b> để kiểm tra những con lô bạch thủ hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += this._strBacNhoCap;
        this._strTong += this.ShowLotoVeNhieu();
      }
      this.HienThiKetQua(this.webBrowser1, this._strTong);
    }

    private void BgCapCungVeRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._strBacNhoCapLienKe.Length > 0)
      {
        this._strTong += "<br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO CẶP LIỀN KỀ CÙNG VỀ </b>☞ º°”˜`”°☜♥☞</div>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>cặp lô liền kề</b> cùng về, thì những con lô, cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Cấu hình <b style='color:red;'>khung lô bạch thủ nuôi</b> để kiểm tra những con lô bạch thủ hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += this._strBacNhoCapLienKe;
        this._strTong += this.ShowLotoVeNhieu();
      }
      this.HienThiKetQua(this.webBrowser1, this._strTong);
    }

    private void BgDauDitCamRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._strTheoDauCam.Length > 0)
      {
        this._strTong += "<br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO ĐẦU CÂM </b>☞ º°”˜`”°☜♥☞</div>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>Đầu lô tô</b> không về , thì những con lô, cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Cấu hình <b style='color:red;'>khung lô bạch thủ nuôi</b> để kiểm tra những con lô bạch thủ hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += this._strTheoDauCam;
        this._strTong += this.ShowLotoVeNhieu();
      }
      this.HienThiKetQua(this.webBrowser1, this._strTong);
    }

    private void BtnXemClick(object sender, EventArgs e)
    {
      if (this.demCheckBox > 1)
      {
        int num = (int) MessageBox.Show("Mỗi lần bạn chỉ nên chọn (01) loại bạc nhớ để tránh bị loạn số !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this._strTong = "";
        if (this.bgListBacNho.IsBusy || this.bgGetNewDay.IsBusy || (this.bgDataTong.IsBusy || this.bgTinhNgayVe.IsBusy || (this.bgTheoGiai.IsBusy || this.bgTheoNhay.IsBusy) || (this.bgTheoCap.IsBusy || this.bgCapCungVe.IsBusy) || this.bgDauCam.IsBusy))
          return;
        this.HienThiKetQua(this.webBrowser1, "");
        this.LoadDuLieuCapBachThu();
        this.bgDataTong.RunWorkerAsync();
      }
    }

    private void BgListLotoTuDoDoWork(object sender, DoWorkEventArgs e)
    {
      this.TaoListLotoTuDo();
    }

    private void CbTheogiaiCheckedChanged(object sender, EventArgs e)
    {
      CheckBox cb = (CheckBox) sender;
      if (cb.Checked)
      {
        cb.ForeColor = Color.Red;
        cb.Font = new Font("Arial", 9f, FontStyle.Bold);
      }
      else
      {
        cb.ForeColor = Color.Black;
        cb.Font = new Font("Arial", 9f, FontStyle.Regular);
      }
      this.DemCheckBox(cb);
    }

    private void DemCheckBox(CheckBox cb)
    {
      if (cb.Checked)
        ++this.demCheckBox;
      else
        --this.demCheckBox;
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

    private void bgDitCam_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoDitCam();
    }

    private void bgDitCam_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this._strTheoDitCam.Length > 0)
      {
        this._strTong += "<br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO ĐUÔI CÂM </b>☞ º°”˜`”°☜♥☞</div>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>Đuôi lô tô</b> không về , thì những con lô, cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Cấu hình <b style='color:red;'>khung lô bạch thủ nuôi</b> để kiểm tra những con lô bạch thủ hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this._strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this._strTong += this._strTheoDitCam;
        this._strTong += this.ShowLotoVeNhieu();
      }
      this.HienThiKetQua(this.webBrowser1, this._strTong);
    }

    private void cbDitcam_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox cb = (CheckBox) sender;
      if (cb.Checked)
      {
        cb.ForeColor = Color.Red;
        cb.Font = new Font("Arial", 9f, FontStyle.Bold);
      }
      else
      {
        cb.ForeColor = Color.Black;
        cb.Font = new Font("Arial", 9f, FontStyle.Regular);
      }
      this.DemCheckBox(cb);
    }

    private string LoaiLoto(List<TabBacnhoCoban.LoToVeNhieu> lotovenhieu)
    {
      string str = "";
      if (lotovenhieu.Count <= 0)
        ;
      return str;
    }

    public void KhoiTao_DataTableInfoLoto()
    {
      this.dtInfoloto = new DataTable();
      this.dtInfoloto.Columns.Add("stt", typeof (int));
      this.dtInfoloto.Columns.Add("loto1", typeof (string));
      this.dtInfoloto.Columns.Add("loto2", typeof (string));
      this.dtInfoloto.Columns.Add("solanve", typeof (int));
      this.dtInfoloto.Columns.Add("solanve1", typeof (int));
      this.dtInfoloto.Columns.Add("solanve2", typeof (int));
      this.dtInfoloto.Columns.Add("ngayChuara1", typeof (int));
      this.dtInfoloto.Columns.Add("ngayChuara2", typeof (int));
      this.dtInfoloto.Columns.Add("soNhayVe1", typeof (int));
      this.dtInfoloto.Columns.Add("soNhayVe2", typeof (int));
      this.dtInfoloto.Columns.Add("veCungnhau", typeof (bool));
      this.dtInfoloto.Columns.Add("colTrong", typeof (string));
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabBacnhoCoban));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.webBrowser1 = new WebBrowser();
      this.panel2 = new Panel();
      this.groupBox1 = new GroupBox();
      this.cbDitcam = new CheckBox();
      this.label3 = new Label();
      this.label1 = new Label();
      this.label2 = new Label();
      this.dtNgayThang = new DateTimePicker();
      this.btnXem = new Button();
      this.cbTheogiai = new CheckBox();
      this.rdBachThu = new RadioButton();
      this.cbTheonhay = new CheckBox();
      this.rdCap = new RadioButton();
      this.cbTheocap = new CheckBox();
      this.cbDaucam = new CheckBox();
      this.cbCapcungve = new CheckBox();
      this.toolTip1 = new ToolTip(this.components);
      this.timer1 = new Timer(this.components);
      this.bgGetNewDay = new BackgroundWorker();
      this.bgListBacNho = new BackgroundWorker();
      this.bgTheoGiai = new BackgroundWorker();
      this.bgTheoNhay = new BackgroundWorker();
      this.bgTheoCap = new BackgroundWorker();
      this.bgCapCungVe = new BackgroundWorker();
      this.bgDauCam = new BackgroundWorker();
      this.bgDataTong = new BackgroundWorker();
      this.bgTinhNgayVe = new BackgroundWorker();
      this.picLoading = new PictureBox();
      this.bgListLotoTuDo = new BackgroundWorker();
      this.bgDitCam = new BackgroundWorker();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.webBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.webBrowser1.Location = new Point(0, 2);
      this.webBrowser1.MinimumSize = new Size(23, 23);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new Size(1115, 590);
      this.webBrowser1.TabIndex = 0;
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 46);
      this.panel2.TabIndex = 13;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.cbDitcam);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.dtNgayThang);
      this.groupBox1.Controls.Add((Control) this.btnXem);
      this.groupBox1.Controls.Add((Control) this.cbTheogiai);
      this.groupBox1.Controls.Add((Control) this.rdBachThu);
      this.groupBox1.Controls.Add((Control) this.cbTheonhay);
      this.groupBox1.Controls.Add((Control) this.rdCap);
      this.groupBox1.Controls.Add((Control) this.cbTheocap);
      this.groupBox1.Controls.Add((Control) this.cbDaucam);
      this.groupBox1.Controls.Add((Control) this.cbCapcungve);
      this.groupBox1.Location = new Point(5, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1090, 43);
      this.groupBox1.TabIndex = 22;
      this.groupBox1.TabStop = false;
      this.cbDitcam.AutoSize = true;
      this.cbDitcam.BackColor = Color.Transparent;
      this.cbDitcam.Cursor = Cursors.Hand;
      this.cbDitcam.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDitcam.ForeColor = Color.Black;
      this.cbDitcam.Location = new Point(674, 16);
      this.cbDitcam.Margin = new Padding(0);
      this.cbDitcam.Name = "cbDitcam";
      this.cbDitcam.Size = new Size(68, 19);
      this.cbDitcam.TabIndex = 21;
      this.cbDitcam.Text = "Đít câm";
      this.cbDitcam.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDitcam, " Xét theo những đầu đít lô câm trong ngày");
      this.cbDitcam.UseVisualStyleBackColor = false;
      this.cbDitcam.CheckedChanged += new EventHandler(this.cbDitcam_CheckedChanged);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(747, 15);
      this.label3.Name = "label3";
      this.label3.Size = new Size(12, 18);
      this.label3.TabIndex = 20;
      this.label3.Text = "]";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(4, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(65, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Xem ngày";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(198, 15);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 18);
      this.label2.TabIndex = 19;
      this.label2.Text = "[";
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
      this.toolTip1.SetToolTip((Control) this.dtNgayThang, "Ngày kiểm tra bạc nhớ");
      this.dtNgayThang.ValueChanged += new EventHandler(this.DTNgayThangValueChanged);
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
      this.btnXem.Click += new EventHandler(this.BtnXemClick);
      this.cbTheogiai.AutoSize = true;
      this.cbTheogiai.BackColor = Color.Transparent;
      this.cbTheogiai.Cursor = Cursors.Hand;
      this.cbTheogiai.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbTheogiai.ForeColor = Color.Black;
      this.cbTheogiai.Location = new Point(218, 16);
      this.cbTheogiai.Margin = new Padding(0);
      this.cbTheogiai.Name = "cbTheogiai";
      this.cbTheogiai.Size = new Size(77, 19);
      this.cbTheogiai.TabIndex = 1;
      this.cbTheogiai.Text = "Theo giải";
      this.cbTheogiai.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbTheogiai, " Xét theo những con lô về theo giải");
      this.cbTheogiai.UseVisualStyleBackColor = false;
      this.cbTheogiai.CheckedChanged += new EventHandler(this.CbTheogiaiCheckedChanged);
      this.rdBachThu.AutoSize = true;
      this.rdBachThu.Cursor = Cursors.Hand;
      this.rdBachThu.FlatStyle = FlatStyle.Flat;
      this.rdBachThu.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdBachThu.ForeColor = Color.Black;
      this.rdBachThu.Location = new Point(875, 15);
      this.rdBachThu.Name = "rdBachThu";
      this.rdBachThu.Size = new Size(72, 19);
      this.rdBachThu.TabIndex = 7;
      this.rdBachThu.Text = "Bạch thủ";
      this.toolTip1.SetToolTip((Control) this.rdBachThu, " Hiển thị những con lô bạch thủ hay về nhất trong khung");
      this.rdBachThu.UseVisualStyleBackColor = true;
      this.rdBachThu.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.cbTheonhay.AutoSize = true;
      this.cbTheonhay.BackColor = Color.Transparent;
      this.cbTheonhay.Cursor = Cursors.Hand;
      this.cbTheonhay.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbTheonhay.ForeColor = Color.Black;
      this.cbTheonhay.Location = new Point(306, 16);
      this.cbTheonhay.Margin = new Padding(0);
      this.cbTheonhay.Name = "cbTheonhay";
      this.cbTheonhay.Size = new Size(83, 19);
      this.cbTheonhay.TabIndex = 2;
      this.cbTheonhay.Text = "Theo nháy";
      this.cbTheonhay.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbTheonhay, " Xét theo những con lô về từ 2 nháy trở lên");
      this.cbTheonhay.UseVisualStyleBackColor = false;
      this.cbTheonhay.CheckedChanged += new EventHandler(this.CbTheogiaiCheckedChanged);
      this.rdCap.AutoSize = true;
      this.rdCap.Checked = true;
      this.rdCap.Cursor = Cursors.Hand;
      this.rdCap.FlatStyle = FlatStyle.Flat;
      this.rdCap.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.rdCap.ForeColor = Color.Red;
      this.rdCap.Location = new Point(796, 15);
      this.rdCap.Name = "rdCap";
      this.rdCap.Size = new Size(62, 19);
      this.rdCap.TabIndex = 6;
      this.rdCap.TabStop = true;
      this.rdCap.Text = "Lô cặp";
      this.toolTip1.SetToolTip((Control) this.rdCap, " Hiển thị những cặp lô hay về nhất trong khung");
      this.rdCap.UseVisualStyleBackColor = true;
      this.rdCap.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.cbTheocap.AutoSize = true;
      this.cbTheocap.BackColor = Color.Transparent;
      this.cbTheocap.Cursor = Cursors.Hand;
      this.cbTheocap.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbTheocap.ForeColor = Color.Black;
      this.cbTheocap.Location = new Point(400, 16);
      this.cbTheocap.Margin = new Padding(0);
      this.cbTheocap.Name = "cbTheocap";
      this.cbTheocap.Size = new Size(77, 19);
      this.cbTheocap.TabIndex = 3;
      this.cbTheocap.Text = "Theo cặp";
      this.cbTheocap.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbTheocap, " Xét theo những cặp lô cùng về trong ngày");
      this.cbTheocap.UseVisualStyleBackColor = false;
      this.cbTheocap.CheckedChanged += new EventHandler(this.CbTheogiaiCheckedChanged);
      this.cbDaucam.AutoSize = true;
      this.cbDaucam.BackColor = Color.Transparent;
      this.cbDaucam.Cursor = Cursors.Hand;
      this.cbDaucam.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDaucam.ForeColor = Color.Black;
      this.cbDaucam.Location = new Point(587, 16);
      this.cbDaucam.Margin = new Padding(0);
      this.cbDaucam.Name = "cbDaucam";
      this.cbDaucam.Size = new Size(76, 19);
      this.cbDaucam.TabIndex = 5;
      this.cbDaucam.Text = "Đầu câm";
      this.cbDaucam.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDaucam, " Xét theo những đầu đít lô câm trong ngày");
      this.cbDaucam.UseVisualStyleBackColor = false;
      this.cbDaucam.CheckedChanged += new EventHandler(this.CbTheogiaiCheckedChanged);
      this.cbCapcungve.AutoSize = true;
      this.cbCapcungve.BackColor = Color.Transparent;
      this.cbCapcungve.Cursor = Cursors.Hand;
      this.cbCapcungve.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbCapcungve.ForeColor = Color.Black;
      this.cbCapcungve.Location = new Point(488, 16);
      this.cbCapcungve.Margin = new Padding(0);
      this.cbCapcungve.Name = "cbCapcungve";
      this.cbCapcungve.Size = new Size(88, 19);
      this.cbCapcungve.TabIndex = 4;
      this.cbCapcungve.Text = "Cặp liền kề";
      this.cbCapcungve.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbCapcungve, " Xét theo những cặp lô liền kề cùng về trong ngày");
      this.cbCapcungve.UseVisualStyleBackColor = false;
      this.cbCapcungve.CheckedChanged += new EventHandler(this.CbTheogiaiCheckedChanged);
      this.toolTip1.AutomaticDelay = 400;
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.Timer1Tick);
      this.bgGetNewDay.DoWork += new DoWorkEventHandler(this.BgKeQuaMoiNhatDoWork);
      this.bgGetNewDay.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgKeQuaMoiNhatRunWorkerCompleted);
      this.bgListBacNho.DoWork += new DoWorkEventHandler(this.BgKetQuaByDate2DoWork);
      this.bgListBacNho.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgListBacNhoRunWorkerCompleted);
      this.bgTheoGiai.DoWork += new DoWorkEventHandler(this.BgTheoGiaiDoWork);
      this.bgTheoGiai.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgTheoGiaiRunWorkerCompleted);
      this.bgTheoNhay.DoWork += new DoWorkEventHandler(this.BgTheoNhayDoWork);
      this.bgTheoNhay.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgTheoNhayRunWorkerCompleted);
      this.bgTheoCap.DoWork += new DoWorkEventHandler(this.BgTheoCapDoWork);
      this.bgTheoCap.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgTheoCapRunWorkerCompleted);
      this.bgCapCungVe.DoWork += new DoWorkEventHandler(this.BgCapCungVeDoWork);
      this.bgCapCungVe.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgCapCungVeRunWorkerCompleted);
      this.bgDauCam.DoWork += new DoWorkEventHandler(this.BgDauDitCamDoWork);
      this.bgDauCam.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgDauDitCamRunWorkerCompleted);
      this.bgDataTong.DoWork += new DoWorkEventHandler(this.BgDataTongDoWork);
      this.bgDataTong.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgDataTongRunWorkerCompleted);
      this.bgTinhNgayVe.DoWork += new DoWorkEventHandler(this.BgTinhNgayVeDoWork);
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(507, 305);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 59;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.bgListLotoTuDo.DoWork += new DoWorkEventHandler(this.BgListLotoTuDoDoWork);
      this.bgDitCam.DoWork += new DoWorkEventHandler(this.bgDitCam_DoWork);
      this.bgDitCam.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDitCam_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.webBrowser1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabBacnhoCoban);
      this.Size = new Size(1100, 590);
      this.panel2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }

    public class LOTO
    {
      public string LOTO1 { get; set; }

      public string LOTO2 { get; set; }
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

    public class LoToVeNhieu
    {
      public string Loto { get; set; }

      public int TongSoLanVe { get; set; }
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

    public delegate void ChayBgTinhNgayVe();
  }
}
