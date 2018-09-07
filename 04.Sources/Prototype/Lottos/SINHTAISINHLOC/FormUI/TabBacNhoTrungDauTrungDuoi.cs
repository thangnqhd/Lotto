// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabBacNhoTrungDauTrungDuoi
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
  public class TabBacNhoTrungDauTrungDuoi : UserControl
  {
    private int demCheckBox = 0;
    private IContainer components = (IContainer) null;
    private readonly Tbloto objLoto;
    private DataTable _dt;
    private string _loTuDoTrungDauTrungDuoi;
    private int _soNgay;
    private DataTable _dtLoToVe;
    public static Timer timer;
    private DataTable dtLoToVeNgaySau;
    private string strTong;
    private DataTable dtTong;
    private List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoGiai> listBacnhotheogiai;
    private List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay> listBacnhotheonhay;
    private List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap> listBacnhotheocap;
    private List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe> listBacnhotheocapcungve;
    private List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoDauCam> listBacnhotheodaucam;
    private List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoDitCam> listBacnhotheoditcam;
    public List<TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau> tinhNgayveLoTrungDau;
    public List<TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi> tinhNgayveLoTrungDuoi;
    public List<TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTuDo> tinhNgayveLoTuDo;
    private List<TabBacNhoTrungDauTrungDuoi.LoToVeNhieu> listLotoVeNhieu;
    public TabBacNhoTrungDauTrungDuoi.BacNhoTheoGiai objTheoGiai;
    public TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay objTheoNhay;
    public TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap objTheoCap;
    public TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe objCapCungVe;
    public TabBacNhoTrungDauTrungDuoi.BacNhoTheoDauCam objDauCam;
    public TabBacNhoTrungDauTrungDuoi.BacNhoTheoDitCam objDitCam;
    private string strBacNhoGiai;
    private DataTable dtLoToTheoNhay;
    private string strBacNhoTheoNhay;
    private DataTable dtLoToTheoCap;
    private string strBacNhoTheoCap;
    private DataTable dtLoToTheoCapLienKe;
    private string strBacNhoTheoCapLienKe;
    private DataTable dtLoToTheoDauCam;
    private string strBacNhoTheoDauCam;
    private DataTable dtLoToTheoDitCam;
    private string strBacNhoTheoDitCam;
    private WebBrowser webBrowser1;
    private Panel panel2;
    private Label label3;
    private RadioButton rdTrungDau;
    private CheckBox cbDaucam;
    private CheckBox cbCapcungve;
    private CheckBox cbTheocap;
    private CheckBox cbTheonhay;
    private CheckBox cbTheogiai;
    private DateTimePicker dtNgayThang;
    private Label label2;
    private Label label1;
    private RadioButton rdTrungDuoi;
    private BunifuElipse bunifuElipse1;
    private ToolTip toolTip1;
    private BackgroundWorker bgGetNewDay;
    private BackgroundWorker bgListBacNho;
    public BackgroundWorker bgTinhNgayVe;
    private BackgroundWorker bgDataTong;
    private BackgroundWorker bgTheoGiai;
    private BackgroundWorker bgTheoNhay;
    private BackgroundWorker bgTheoCap;
    private BackgroundWorker bgCapCungVe;
    private BackgroundWorker bgDauCam;
    private PictureBox picLoading;
    private Timer timerLoading;
    private Button btnXem;
    private CheckBox cbDitcam;
    private BackgroundWorker bgDitcam;
    private GroupBox groupBox1;

    public DateTime NgayThangNew { get; set; }

    public TabBacNhoTrungDauTrungDuoi()
    {
      TabBacNhoTrungDauTrungDuoi.timer = new Timer();
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      TabBacNhoTrungDauTrungDuoi.timer.Tick += new EventHandler(this.timer_Tick);
      this.NgayThangNew = DateTime.Now;
      this.objLoto = new Tbloto();
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
      TabBacNhoTrungDauTrungDuoi.timer.Stop();
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.StrCss1 + "<title>THỐNG KÊ XỔ SỐ</title></head><body  oncontextmenu='return false;'style='font-family:Verdana;'><div class='container' style='margin-right:15px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ></div><div class='panel-body'><ul class='media-list'><li class='media'>" + strHtml + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void bgGetNewDay_DoWork(object sender, DoWorkEventArgs e)
    {
      this.KetQuaDateNew();
    }

    private void KetQuaDateNew()
    {
      this._loTuDoTrungDauTrungDuoi = "Loto [<b style='color:red;'>  Trùng Đầu  </b>] về nhiều " + (object) FMain.ObjConfigBacNho.KhungDanhLoCapNuoi + " ngày sau đó :</b>";
      this._soNgay = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      this.NgayThangNew = FMain.NgayKetQuaMoiNhat;
    }

    private void LoadDuLieuRadioButton()
    {
      this._soNgay = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      if (this.rdTrungDau.Checked)
        this._loTuDoTrungDauTrungDuoi = "Loto [<b style='color:red;'>  Trùng Đầu  </b>] về nhiều " + (object) this._soNgay + " ngày sau đó :</b>";
      if (!this.rdTrungDuoi.Checked)
        return;
      this._loTuDoTrungDauTrungDuoi = "Loto [<b style='color:red;'>  Trùng Đuôi  </b>] về nhiều " + (object) this._soNgay + " ngày sau đó :</b>";
    }

    private void XuLyLoToVeNhieu(string loto1, string loto2)
    {
      if (FMain.ObjConfigBacNho.HienThiNgayVe != 1)
        return;
      TabBacNhoTrungDauTrungDuoi.LoToVeNhieu loToVeNhieu = new TabBacNhoTrungDauTrungDuoi.LoToVeNhieu();
      if (this.listLotoVeNhieu.Count > 0)
      {
        bool flag = false;
        for (int index = 0; index < this.listLotoVeNhieu.Count; ++index)
        {
          if (this.listLotoVeNhieu[index].Loto1 == loto1 && this.listLotoVeNhieu[index].Loto2 == loto2)
          {
            flag = true;
            ++this.listLotoVeNhieu[index].TongSoLanVe;
            break;
          }
        }
        if (!flag)
        {
          loToVeNhieu.Loto1 = loto1;
          loToVeNhieu.Loto2 = loto2;
          ++loToVeNhieu.TongSoLanVe;
        }
      }
      else
      {
        loToVeNhieu.Loto1 = loto1;
        loToVeNhieu.Loto2 = loto2;
        ++loToVeNhieu.TongSoLanVe;
      }
      this.listLotoVeNhieu.Add(loToVeNhieu);
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
        string loto = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          loto = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
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
        string loto = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          loto = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
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
      string str = (int.Parse(loto) + bienDo).ToString((IFormatProvider) CultureInfo.InvariantCulture);
      if (str.Length < 2)
        str = "0" + str;
      if (loto.Substring(0, 1) != str.Substring(0, 1))
        str = "";
      return str;
    }

    private string BienDoiLoToTrungDuoi(string loto, int bienDo)
    {
      string s = (int.Parse(loto.Substring(0, 1)) + bienDo).ToString((IFormatProvider) CultureInfo.InvariantCulture) + loto.Substring(1, 1);
      if (loto.Substring(1, 1) != s.Substring(1, 1))
        s = "";
      else if (int.Parse(s) > 99)
        s = "";
      return s;
    }

    private void rdTrungDau_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadDuLieuRadioButton();
    }

    private void rdTrungDuoi_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadDuLieuRadioButton();
    }

    private void bgGetNewDay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.dtNgayThang.Value = this.NgayThangNew;
    }

    private void dtNgayThang_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtNgayThang.Value > this.NgayThangNew)
        this.dtNgayThang.Value = this.NgayThangNew;
      if (this.bgListBacNho.IsBusy)
        return;
      this.btnXem.Enabled = false;
      this.bgListBacNho.RunWorkerAsync();
    }

    private void bgListBacNho_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Get_Data_ByDate(this.dtNgayThang.Value);
    }

    private DataTable CreateDTLoVETRUOC()
    {
      return new DataTable()
      {
        Columns = {
          {
            "lotoGoc1",
            typeof (string)
          },
          {
            "lotoGoc2",
            typeof (string)
          },
          {
            "lotoXet1",
            typeof (string)
          },
          {
            "lotoXet2",
            typeof (string)
          },
          {
            "ngayve",
            typeof (DateTime)
          },
          {
            "tongsolanve",
            typeof (int)
          }
        }
      };
    }

    private void Get_Data_ByDate(DateTime ngayThangKiemTra)
    {
      this.listBacnhotheogiai = new List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoGiai>();
      this.listBacnhotheonhay = new List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay>();
      this.listBacnhotheocap = new List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap>();
      this.listBacnhotheocapcungve = new List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe>();
      this.listBacnhotheodaucam = new List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoDauCam>();
      this.listBacnhotheoditcam = new List<TabBacNhoTrungDauTrungDuoi.BacNhoTheoDitCam>();
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
          this.objTheoGiai = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoGiai()
          {
            Text = this._dt.Columns[j].ColumnName,
            Value = this._dt.Rows[0][j].ToString()
          };
          this.listBacnhotheogiai.Add(this.objTheoGiai);
          if (!this.listBacnhotheonhay.Any<TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay>((Func<TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay, bool>) (items => items.Text == this._dt.Rows[0][j].ToString())))
          {
            this.objTheoNhay = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay();
            this.objTheoNhay = this.TimBacNhoTheoNhay(this._dt, this._dt.Rows[0][j].ToString());
            if (this.objTheoNhay.Value != "")
              this.listBacnhotheonhay.Add(this.objTheoNhay);
          }
          lotoXuoi = this._dt.Rows[0][j].ToString();
          lotoLon = this.objLoto.CheckLotoCap(this._dt.Rows[0][j].ToString());
          string lotoXuoi;
          string lotoLon;
          if (!this.listBacnhotheocap.Any<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap>(closure_0 ?? (closure_0 = (Func<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap, bool>) (items =>
          {
            if (!(items.Text == lotoXuoi))
              return items.Text == lotoLon;
            return true;
          }))))
          {
            this.objTheoCap = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap();
            this.objTheoCap = this.TimBacNhoTheoCap(this._dt, lotoXuoi, lotoLon);
            if (this.objTheoCap.Value != "")
              this.listBacnhotheocap.Add(this.objTheoCap);
          }
          string lotoTien = (int.Parse(lotoXuoi) + 1).ToString();
          if (!this.listBacnhotheocapcungve.Any<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe>(closure_1 ?? (closure_1 = (Func<TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe, bool>) (items => items.Text == lotoXuoi))))
          {
            this.objCapCungVe = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe();
            this.objCapCungVe = this.TimBacNhoTheoCapCungVe(this._dt, lotoXuoi, lotoTien);
            if (this.objCapCungVe.Value != "")
              this.listBacnhotheocapcungve.Add(this.objCapCungVe);
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
            this.objDauCam = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoDauCam()
            {
              Text = str.ToString(),
              Value = this.Text
            };
            this.listBacnhotheodaucam.Add(this.objDauCam);
          }
        }
        if (stringList2.Count > 0)
        {
          foreach (string str in stringList2)
          {
            this.objDitCam = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoDitCam()
            {
              Text = str.ToString(),
              Value = this.Text
            };
            this.listBacnhotheoditcam.Add(this.objDitCam);
          }
        }
      }
      string str3 = "";
      foreach (TabBacNhoTrungDauTrungDuoi.BacNhoTheoDauCam bacNhoTheoDauCam in this.listBacnhotheodaucam)
      {
        if (bacNhoTheoDauCam.Text != "" && bacNhoTheoDauCam.Value != "")
        {
          str3 += "Đầu câm";
          str3 = str3 + bacNhoTheoDauCam.Text + "-" + bacNhoTheoDauCam.Value + "\r\n";
        }
      }
      foreach (TabBacNhoTrungDauTrungDuoi.BacNhoTheoDitCam bacNhoTheoDitCam in this.listBacnhotheoditcam)
      {
        if (bacNhoTheoDitCam.Text != "" && bacNhoTheoDitCam.Value != "")
          str3 = str3 + "Đít câm" + bacNhoTheoDitCam.Text + "-" + bacNhoTheoDitCam.Value + "\r\n";
      }
    }

    private TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay TimBacNhoTheoNhay(DataTable dtTable, string lotoSoSanh)
    {
      this.objTheoNhay = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay()
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
        this.objTheoNhay.Text = lotoSoSanh;
        this.objTheoNhay.Value = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      return this.objTheoNhay;
    }

    private TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap TimBacNhoTheoCap(DataTable dtTable, string lotoXuoi, string lotoLon)
    {
      this.objTheoCap = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap()
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
        this.objTheoCap.Text = lotoXuoi;
        this.objTheoCap.Value = lotoLon;
        if (int.Parse(lotoXuoi) > int.Parse(lotoLon))
        {
          this.objTheoCap.Text = lotoLon;
          this.objTheoCap.Value = lotoXuoi;
        }
      }
      return this.objTheoCap;
    }

    private TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe TimBacNhoTheoCapCungVe(DataTable dtTable, string lotoXuoi, string lotoTien)
    {
      this.objCapCungVe = new TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe()
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
        this.objCapCungVe.Text = lotoXuoi;
        this.objCapCungVe.Value = lotoTien;
        if (int.Parse(lotoTien) < int.Parse(lotoXuoi))
        {
          this.objCapCungVe.Text = lotoTien;
          this.objCapCungVe.Value = lotoXuoi;
        }
      }
      return this.objCapCungVe;
    }

    private void GetDataLoVeNgaySau(tbConfigBacNho objBacNho)
    {
      int khungDanhLoCapNuoi = objBacNho.KhungDanhLoCapNuoi;
      this.dtLoToVeNgaySau = new DataTable();
      this.dtLoToVeNgaySau = this.objLoto.GetLotoByNgayThangSoBanGhi(this.dtNgayThang.Value, khungDanhLoCapNuoi + 2);
    }

    private void TimNgayVeLoTrungDau(int soBanGhi)
    {
      this.tinhNgayveLoTrungDau = new List<TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau ngayVeLoTrungDau = new TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau();
        string loto = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          loto = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        string trungDau = this.BienDoiLoToTrungDau(loto, FMain.ObjConfigBacNho.BiendoTrungDau);
        string str1 = "";
        string str2 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.dtLoToVeNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str1 = loto;
          str2 = trungDau;
          for (int index3 = 2; index3 < this.dtLoToVeNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.dtLoToVeNgaySau.Rows[index2][index3].ToString();
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
            str3 = " Về ngày " + (index2 + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture);
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
        this.tinhNgayveLoTrungDau.Add(ngayVeLoTrungDau);
      }
    }

    private void TimNgayVeLoTrungDuoi(int soBanGhi)
    {
      this.tinhNgayveLoTrungDuoi = new List<TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi = new TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi();
        string loto = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index1 < 10)
          loto = "0" + index1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        string trungDuoi = this.BienDoiLoToTrungDuoi(loto, FMain.ObjConfigBacNho.BiendoTrungDuoi);
        string str1 = "";
        string str2 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str3 = " Chưa về";
        string str4 = "Black";
        int num = this.dtLoToVeNgaySau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str1 = loto;
          str2 = trungDuoi;
          for (int index3 = 2; index3 < this.dtLoToVeNgaySau.Columns.Count; ++index3)
          {
            string str5 = this.dtLoToVeNgaySau.Rows[index2][index3].ToString();
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
            str3 = " Về ngày " + (index2 + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture);
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
        this.tinhNgayveLoTrungDuoi.Add(ngayVeLoTrungDuoi);
      }
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
      this.dtTong = new DataTable();
      this.dtTong = this.objLoto.GetLotoByNgayThang(this.dtNgayThang.Value.AddMonths(-num), this.dtNgayThang.Value);
    }

    private void bgTinhNgayVe_DoWork(object sender, DoWorkEventArgs e)
    {
      this.TimNgayVeLoTrungDau(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
      this.TimNgayVeLoTrungDuoi(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
    }

    private void bgListBacNho_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.btnXem.Enabled = true;
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
    }

    private void bgDataTong_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDataTong();
      this.listLotoVeNhieu = new List<TabBacNhoTrungDauTrungDuoi.LoToVeNhieu>();
    }

    private void bgDataTong_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
      if (!this.cbDitcam.Checked || this.bgDitcam.IsBusy)
        return;
      this.bgDitcam.RunWorkerAsync();
    }

    private void GetDaTaBacNhoTheoGiai()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoGiai);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this.strBacNhoGiai = "";
      for (int index = 0; index < this.listBacnhotheogiai.Count; ++index)
      {
        this._dt = new DataTable();
        this._dt = this.GetDataTungGiai(ngayBatDau, ngayKetThuc, this.listBacnhotheogiai[index]);
        this.strBacNhoGiai += this.XuLyDuLieuTungGiai(this._dt, this.listBacnhotheogiai[index].Text, this.listBacnhotheogiai[index].Value);
      }
    }

    private DataTable GetDataTungGiai(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacNhoTrungDauTrungDuoi.BacNhoTheoGiai objBacNhoTheoGiai)
    {
      this._dt = new DataTable();
      DataRow[] dataRowArray = this.dtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and " + objBacNhoTheoGiai.Text + "='" + objBacNhoTheoGiai.Value + "'");
      if ((uint) dataRowArray.Length > 0U)
        this._dt = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return this._dt;
    }

    private string XuLyDuLieuTungGiai(DataTable dtGiai, string giai, string loto)
    {
      string str1 = "";
      string str2;
      if (giai == "G0")
        str2 = str1 + "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ " + this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoGiai).ToString("dd/MM/yyyy") + " đến ngày " + this.dtNgayThang.Value.ToString("dd/MM/yyyy") + ", Giải [<b style='color:red;'> ĐẶC BIỆT </b>] về lô (<b style='color:red;'>  " + loto + "  </b>) tất cả (<b style='color:red;'>  " + (object) dtGiai.Rows.Count + "  </b>) lần. " + this._loTuDoTrungDauTrungDuoi + "</br>";
      else
        str2 = str1 + "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ " + this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoGiai).ToString("dd/MM/yyyy") + " đến ngày " + this.dtNgayThang.Value.ToString("dd/MM/yyyy") + ", Giải [<b style='color:red;'> " + giai + " </b>] về lô (<b style='color:red;'>  " + loto + "  </b>) tất cả (<b style='color:red;'>  " + (object) dtGiai.Rows.Count + "  </b>) lần. " + this._loTuDoTrungDauTrungDuoi + "</br>";
      this._dtLoToVe = new DataTable();
      if (this.rdTrungDau.Checked)
        this._dtLoToVe = this.TaoBangLoTrungDau(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDau);
      if (this.rdTrungDuoi.Checked)
        this._dtLoToVe = this.TaoBangLoTrungDuoi(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      for (int index = 0; index < dtGiai.Rows.Count; ++index)
        this.XuLyLoToNgaySauTheoGiai(int.Parse(dtGiai.Rows[index]["STT"].ToString()), this._soNgay);
      DataView defaultView = this._dtLoToVe.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this._dtLoToVe = defaultView.ToTable();
      float count = (float) dtGiai.Rows.Count;
      for (int index1 = 0; index1 < FMain.ObjConfigBacNho.SoBanGhi; ++index1)
      {
        string loto1 = this._dtLoToVe.Rows[index1]["loto1"].ToString();
        string loto2 = this._dtLoToVe.Rows[index1]["loto2"].ToString();
        string s = this._dtLoToVe.Rows[index1]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(loto1, loto2);
        string str3 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str4 = str2 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + loto1 + "-" + loto2 + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str3 + ". Trong đó ";
        for (int index2 = 0; index2 < this._soNgay; ++index2)
          str4 = str4 + " <b>" + this._dtLoToVe.Rows[index1][index2 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index2 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str4 += this.ChechVeNgayTheoGiai(loto1, loto2);
        str2 = str4 + "<br>";
      }
      return str2;
    }

    private void XuLyLoToNgaySauTheoGiai(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.dtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
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

    private string ChechVeNgayTheoGiai(string loto1, string loto2)
    {
      string str1 = "";
      if (this.rdTrungDau.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau ngayVeLoTrungDau in this.tinhNgayveLoTrungDau)
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
      else if (this.rdTrungDuoi.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi in this.tinhNgayveLoTrungDuoi)
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

    private string Show_LotoVeNhieu()
    {
      string str = "";
      if (!this.bgTheoGiai.IsBusy && !this.bgTheoCap.IsBusy && (!this.bgTheoNhay.IsBusy && !this.bgTheoCap.IsBusy) && !this.bgCapCungVe.IsBusy && !this.bgDauCam.IsBusy && this.listLotoVeNhieu.Count > 0)
      {
        str = str + "<br><div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜ DANH SÁCH CÁC LOTO XUẤT HIỆN NHIỀU TRONG NGÀY ☞ º°”˜`”°☜♥☞</div>" + "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.listLotoVeNhieu.Sort((Comparison<TabBacNhoTrungDauTrungDuoi.LoToVeNhieu>) ((x, y) => y.TongSoLanVe.CompareTo(x.TongSoLanVe)));
        foreach (TabBacNhoTrungDauTrungDuoi.LoToVeNhieu loToVeNhieu in this.listLotoVeNhieu)
        {
          if (loToVeNhieu.TongSoLanVe > 1)
          {
            str = str + "<div style='font-size:14ix;'>- Lô  <b style='color:blue;'> (" + loToVeNhieu.Loto1 + "-" + loToVeNhieu.Loto2 + ") </b> về [ <b style='color:red;'>" + (object) loToVeNhieu.TongSoLanVe + " </b>] lần . ";
            str += this.ChechVeNgayTheoGiai(loToVeNhieu.Loto1, loToVeNhieu.Loto2);
            str += "</div>";
          }
          else
            break;
        }
      }
      return str;
    }

    private void GetDaTaBacNhoTheoNhay()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoNhay);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this.strBacNhoTheoNhay = "";
      for (int index = 0; index < this.listBacnhotheonhay.Count; ++index)
        this.strBacNhoTheoNhay += this.XuLyDuLieuTungNhay(this.GetDataTungNhay(ngayBatDau, ngayKetThuc, this.listBacnhotheonhay[index]), this.listBacnhotheonhay[index]);
    }

    private DataTable GetDataTungNhay(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay objBacNho)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      dataTable2.Columns.Add("STT");
      string text = objBacNho.Text;
      DataRow[] dataRowArray = this.dtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and (G0='" + text + "' or G1='" + text + "' or G21='" + text + "' or G22='" + text + "'or G31='" + text + "' or G32='" + text + "'or G33='" + text + "'or G34='" + text + "'or G35='" + text + "'or G36='" + text + "'or G41='" + text + "'or G42='" + text + "'or G43='" + text + "'or G44='" + text + "'or G51='" + text + "'or G52='" + text + "'or G53='" + text + "'or G54='" + text + "'or G55='" + text + "'or G56='" + text + "'or G61='" + text + "'or G62='" + text + "'or G63='" + text + "'or G71='" + text + "'or G72='" + text + "'or G73='" + text + "'or G74='" + text + "')");
      if ((uint) dataRowArray.Length > 0U)
      {
        DataTable dataTable3 = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
        if (dataTable3.Rows.Count > 0)
        {
          for (int index1 = 0; index1 < dataTable3.Rows.Count; ++index1)
          {
            int num = 0;
            for (int index2 = 0; index2 < dataTable3.Columns.Count; ++index2)
            {
              if (dataTable3.Rows[index1][index2].ToString() == text)
                ++num;
            }
            if (num > 1)
            {
              DataRow row = dataTable2.NewRow();
              row["STT"] = (object) dataTable3.Rows[index1]["STT"].ToString();
              dataTable2.Rows.Add(row);
            }
          }
        }
      }
      return dataTable2;
    }

    private string XuLyDuLieuTungNhay(DataTable dtGiai, TabBacNhoTrungDauTrungDuoi.BacNhoTheoNhay objBacNho)
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
      objArray[5] = (object) ",  Loto [<b style='color:red;'> ";
      objArray[6] = (object) objBacNho.Text;
      objArray[7] = (object) " </b>] về từ 2 nháy trở lên tất cả (<b style='color:red;'>  ";
      objArray[8] = (object) dtGiai.Rows.Count;
      objArray[9] = (object) "  </b>) lần. ";
      objArray[10] = (object) this._loTuDoTrungDauTrungDuoi;
      objArray[11] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this.dtLoToTheoNhay = new DataTable();
      if (this.rdTrungDau.Checked)
        this.dtLoToTheoNhay = this.TaoBangLoTrungDauTheoNhay(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDau);
      if (this.rdTrungDuoi.Checked)
        this.dtLoToTheoNhay = this.TaoBangLoTrungDuoiTheoNhay(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      for (int index2 = 0; index2 < dtGiai.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoNhay(int.Parse(dtGiai.Rows[index2]["STT"].ToString()), this._soNgay);
      DataView defaultView = this.dtLoToTheoNhay.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this.dtLoToTheoNhay = defaultView.ToTable();
      float count = (float) dtGiai.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string loto1 = this.dtLoToTheoNhay.Rows[index2]["loto1"].ToString();
        string loto2 = this.dtLoToTheoNhay.Rows[index2]["loto2"].ToString();
        string s = this.dtLoToTheoNhay.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(loto1, loto2);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + loto1 + "-" + loto2 + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < this._soNgay; ++index3)
          str5 = str5 + " <b>" + this.dtLoToTheoNhay.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoNhay(loto1, loto2);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoNhay(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.dtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      DataTable dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      for (int index1 = 0; index1 < this.dtLoToTheoNhay.Rows.Count; ++index1)
      {
        string str1 = this.dtLoToTheoNhay.Rows[index1][0].ToString();
        string str2 = this.dtLoToTheoNhay.Rows[index1][1].ToString();
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
          this.dtLoToTheoNhay.Rows[index1][index2] = (object) (int.Parse(this.dtLoToTheoNhay.Rows[index1][index2].ToString()) + 1);
          this.dtLoToTheoNhay.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this.dtLoToTheoNhay.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoNhay(string loto1, string loto2)
    {
      string str1 = "";
      if (this.rdTrungDau.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau ngayVeLoTrungDau in this.tinhNgayveLoTrungDau)
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
      else if (this.rdTrungDuoi.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi in this.tinhNgayveLoTrungDuoi)
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

    private DataTable TaoBangLoTrungDauTheoNhay(int khungDanh, int bienDo)
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

    private DataTable TaoBangLoTrungDuoiTheoNhay(int khungDanh, int bienDo)
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

    private void GetDaTaBacNhoTheoCap()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.TheoCap);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this.strBacNhoTheoCap = "";
      for (int index = 0; index < this.listBacnhotheocap.Count; ++index)
        this.strBacNhoTheoCap += this.XuLyDuLieuTungCap(this.GetDataTungCap(ngayBatDau, ngayKetThuc, this.listBacnhotheocap[index]), this.listBacnhotheocap[index]);
    }

    private DataTable GetDataTungCap(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap objBacNho)
    {
      DataTable dataTable = new DataTable();
      string text = objBacNho.Text;
      string str = objBacNho.Value;
      DataRow[] dataRowArray = this.dtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and (G0='" + text + "' or G1='" + text + "' or G21='" + text + "' or G22='" + text + "'or G31='" + text + "' or G32='" + text + "'or G33='" + text + "'or G34='" + text + "'or G35='" + text + "'or G36='" + text + "'or G41='" + text + "'or G42='" + text + "'or G43='" + text + "'or G44='" + text + "'or G51='" + text + "'or G52='" + text + "'or G53='" + text + "'or G54='" + text + "'or G55='" + text + "'or G56='" + text + "'or G61='" + text + "'or G62='" + text + "'or G63='" + text + "'or G71='" + text + "'or G72='" + text + "'or G73='" + text + "'or G74='" + text + "')and (G0='" + str + "' or G1='" + str + "' or G21='" + str + "' or G22='" + str + "'or G31='" + str + "' or G32='" + str + "'or G33='" + str + "'or G34='" + str + "'or G35='" + str + "'or G36='" + str + "'or G41='" + str + "'or G42='" + str + "'or G43='" + str + "'or G44='" + str + "'or G51='" + str + "'or G52='" + str + "'or G53='" + str + "'or G54='" + str + "'or G55='" + str + "'or G56='" + str + "'or G61='" + str + "'or G62='" + str + "'or G63='" + str + "'or G71='" + str + "'or G72='" + str + "'or G73='" + str + "'or G74='" + str + "')");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungCap(DataTable dtGiai, TabBacNhoTrungDauTrungDuoi.BacNhoTheoCap objBacNho)
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
      objArray[5] = (object) ",  Loto [<b style='color:red;'> ";
      objArray[6] = (object) objBacNho.Text;
      objArray[7] = (object) "-";
      objArray[8] = (object) objBacNho.Value;
      objArray[9] = (object) " </b>] về cùng nhau tất cả (<b style='color:red;'>  ";
      objArray[10] = (object) dtGiai.Rows.Count;
      objArray[11] = (object) "  </b>) lần. ";
      objArray[12] = (object) this._loTuDoTrungDauTrungDuoi;
      objArray[13] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this.dtLoToTheoCap = new DataTable();
      if (this.rdTrungDau.Checked)
        this.dtLoToTheoCap = this.TaoBangLoTrungDauTheoCap(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDau);
      if (this.rdTrungDuoi.Checked)
        this.dtLoToTheoCap = this.TaoBangLoTrungDuoiTheoCap(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      for (int index2 = 0; index2 < dtGiai.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoCap(int.Parse(dtGiai.Rows[index2]["STT"].ToString()), this._soNgay);
      DataView defaultView = this.dtLoToTheoCap.DefaultView;
      defaultView.Sort = "tongSOLAN desc";
      this.dtLoToTheoCap = defaultView.ToTable();
      float count = (float) dtGiai.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string loto1 = this.dtLoToTheoCap.Rows[index2]["loto1"].ToString();
        string loto2 = this.dtLoToTheoCap.Rows[index2]["loto2"].ToString();
        string s = this.dtLoToTheoCap.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(loto1, loto2);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + loto1 + "-" + loto2 + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < this._soNgay; ++index3)
          str5 = str5 + " <b>" + this.dtLoToTheoCap.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoCap(loto1, loto2);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoCap(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.dtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      DataTable dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      for (int index1 = 0; index1 < this.dtLoToTheoCap.Rows.Count; ++index1)
      {
        string str1 = this.dtLoToTheoCap.Rows[index1][0].ToString();
        string str2 = this.dtLoToTheoCap.Rows[index1][1].ToString();
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
          this.dtLoToTheoCap.Rows[index1][index2] = (object) (int.Parse(this.dtLoToTheoCap.Rows[index1][index2].ToString()) + 1);
          this.dtLoToTheoCap.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this.dtLoToTheoCap.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoCap(string loto1, string loto2)
    {
      string str1 = "";
      if (this.rdTrungDau.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau ngayVeLoTrungDau in this.tinhNgayveLoTrungDau)
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
      else if (this.rdTrungDuoi.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi in this.tinhNgayveLoTrungDuoi)
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

    private DataTable TaoBangLoTrungDauTheoCap(int khungDanh, int bienDo)
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

    private DataTable TaoBangLoTrungDuoiTheoCap(int khungDanh, int bienDo)
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

    private void GetDaTaBacNhoTheoCapLienKe()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.CapCungVe);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this.strBacNhoTheoCapLienKe = "";
      for (int index = 0; index < this.listBacnhotheocapcungve.Count; ++index)
        this.strBacNhoTheoCapLienKe += this.XuLyDuLieuTungCapLienKe(this.GetDataTungCapLienKe(ngayBatDau, ngayKetThuc, this.listBacnhotheocapcungve[index]), this.listBacnhotheocapcungve[index]);
    }

    private DataTable GetDataTungCapLienKe(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe objBacNho)
    {
      DataTable dataTable = new DataTable();
      string text = objBacNho.Text;
      string str = objBacNho.Value;
      DataRow[] dataRowArray = this.dtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and (G0='" + text + "' or G1='" + text + "' or G21='" + text + "' or G22='" + text + "'or G31='" + text + "' or G32='" + text + "'or G33='" + text + "'or G34='" + text + "'or G35='" + text + "'or G36='" + text + "'or G41='" + text + "'or G42='" + text + "'or G43='" + text + "'or G44='" + text + "'or G51='" + text + "'or G52='" + text + "'or G53='" + text + "'or G54='" + text + "'or G55='" + text + "'or G56='" + text + "'or G61='" + text + "'or G62='" + text + "'or G63='" + text + "'or G71='" + text + "'or G72='" + text + "'or G73='" + text + "'or G74='" + text + "')and (G0='" + str + "' or G1='" + str + "' or G21='" + str + "' or G22='" + str + "'or G31='" + str + "' or G32='" + str + "'or G33='" + str + "'or G34='" + str + "'or G35='" + str + "'or G36='" + str + "'or G41='" + str + "'or G42='" + str + "'or G43='" + str + "'or G44='" + str + "'or G51='" + str + "'or G52='" + str + "'or G53='" + str + "'or G54='" + str + "'or G55='" + str + "'or G56='" + str + "'or G61='" + str + "'or G62='" + str + "'or G63='" + str + "'or G71='" + str + "'or G72='" + str + "'or G73='" + str + "'or G74='" + str + "')");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungCapLienKe(DataTable dtGiai, TabBacNhoTrungDauTrungDuoi.BacNhoTheoCapCungVe objBacNho)
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
      objArray[5] = (object) ",  Loto [<b style='color:red;'> ";
      objArray[6] = (object) objBacNho.Text;
      objArray[7] = (object) "-";
      objArray[8] = (object) objBacNho.Value;
      objArray[9] = (object) " </b>] về cùng nhau tất cả (<b style='color:red;'>  ";
      objArray[10] = (object) dtGiai.Rows.Count;
      objArray[11] = (object) "  </b>) lần. ";
      objArray[12] = (object) this._loTuDoTrungDauTrungDuoi;
      objArray[13] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this.dtLoToTheoCapLienKe = new DataTable();
      if (this.rdTrungDau.Checked)
        this.dtLoToTheoCapLienKe = this.TaoBangLoTrungDauTheoCapLienKe(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDau);
      if (this.rdTrungDuoi.Checked)
        this.dtLoToTheoCapLienKe = this.TaoBangLoTrungDuoiTheoCapLienKe(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      for (int index2 = 0; index2 < dtGiai.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoCapLienKe(int.Parse(dtGiai.Rows[index2]["STT"].ToString()), this._soNgay);
      DataView defaultView = this.dtLoToTheoCapLienKe.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this.dtLoToTheoCapLienKe = defaultView.ToTable();
      float count = (float) dtGiai.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string loto1 = this.dtLoToTheoCapLienKe.Rows[index2]["loto1"].ToString();
        string loto2 = this.dtLoToTheoCapLienKe.Rows[index2]["loto2"].ToString();
        string s = this.dtLoToTheoCapLienKe.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(loto1, loto2);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + loto1 + "-" + loto2 + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < this._soNgay; ++index3)
          str5 = str5 + " <b>" + this.dtLoToTheoCapLienKe.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoCapLienKe(loto1, loto2);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoCapLienKe(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.dtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      DataTable dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      for (int index1 = 0; index1 < this.dtLoToTheoCapLienKe.Rows.Count; ++index1)
      {
        string str1 = this.dtLoToTheoCapLienKe.Rows[index1][0].ToString();
        string str2 = this.dtLoToTheoCapLienKe.Rows[index1][1].ToString();
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
          this.dtLoToTheoCapLienKe.Rows[index1][index2] = (object) (int.Parse(this.dtLoToTheoCapLienKe.Rows[index1][index2].ToString()) + 1);
          this.dtLoToTheoCapLienKe.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this.dtLoToTheoCapLienKe.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoCapLienKe(string loto1, string loto2)
    {
      string str1 = "";
      if (this.rdTrungDau.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau ngayVeLoTrungDau in this.tinhNgayveLoTrungDau)
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
      else if (this.rdTrungDuoi.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi in this.tinhNgayveLoTrungDuoi)
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

    private DataTable TaoBangLoTrungDauTheoCapLienKe(int khungDanh, int bienDo)
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

    private DataTable TaoBangLoTrungDuoiTheoCapLienKe(int khungDanh, int bienDo)
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

    private void GetDaTaBacNhoTheoDauCam()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.DauCam);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this.strBacNhoTheoDauCam = "";
      for (int index = 0; index < this.listBacnhotheodaucam.Count; ++index)
        this.strBacNhoTheoDauCam += this.XuLyDuLieuTungDauCam(this.GetDataTungCapDauCam(ngayBatDau, ngayKetThuc, this.listBacnhotheodaucam[index]), this.listBacnhotheodaucam[index]);
    }

    private DataTable GetDataTungCapDauCam(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacNhoTrungDauTrungDuoi.BacNhoTheoDauCam objBacNho)
    {
      DataTable dataTable = new DataTable();
      string text = objBacNho.Text;
      DataRow[] dataRowArray = this.dtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and SUBSTRING(G0,1,1)<>'" + text + "'and SUBSTRING(G1,1,1)<>'" + text + "'and SUBSTRING(G21,1,1)<>'" + text + "' and SUBSTRING(G22,1,1)<>'" + text + "'and SUBSTRING(G31,1,1)<>'" + text + "' and SUBSTRING(G32,1,1)<>'" + text + "'and SUBSTRING(G33,1,1)<>'" + text + "'and SUBSTRING(G34,1,1)<>'" + text + "'and SUBSTRING(G35,1,1)<>'" + text + "'and SUBSTRING(G36,1,1)<>'" + text + "'and SUBSTRING(G41,1,1)<>'" + text + "'and SUBSTRING(G42,1,1)<>'" + text + "'and SUBSTRING(G43,1,1)<>'" + text + "'and SUBSTRING(G44,1,1)<>'" + text + "'and SUBSTRING(G51,1,1)<>'" + text + "'and SUBSTRING(G52,1,1)<>'" + text + "'and SUBSTRING(G53,1,1)<>'" + text + "'and SUBSTRING(G54,1,1)<>'" + text + "'and SUBSTRING(G55,1,1)<>'" + text + "'and SUBSTRING(G56,1,1)<>'" + text + "'and SUBSTRING(G61,1,1)<>'" + text + "'and SUBSTRING(G62,1,1)<>'" + text + "'and SUBSTRING(G63,1,1)<>'" + text + "'and SUBSTRING(G71,1,1)<>'" + text + "'and SUBSTRING(G72,1,1)<>'" + text + "'and SUBSTRING(G73,1,1)<>'" + text + "'and SUBSTRING(G74,1,1)<>'" + text + "'");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungDauCam(DataTable dtGiai, TabBacNhoTrungDauTrungDuoi.BacNhoTheoDauCam objBacNho)
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
      objArray[5] = (object) ",  Đầu [<b style='color:red;'> ";
      objArray[6] = (object) objBacNho.Text;
      objArray[7] = (object) " </b>] câm tất cả (<b style='color:red;'>  ";
      objArray[8] = (object) dtGiai.Rows.Count;
      objArray[9] = (object) "  </b>) lần. ";
      objArray[10] = (object) this._loTuDoTrungDauTrungDuoi;
      objArray[11] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this.dtLoToTheoDauCam = new DataTable();
      if (this.rdTrungDau.Checked)
        this.dtLoToTheoDauCam = this.TaoBangLoTrungDauTheoDauCam(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDau);
      if (this.rdTrungDuoi.Checked)
        this.dtLoToTheoDauCam = this.TaoBangLoTrungDuoiTheoDauCam(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      for (int index2 = 0; index2 < dtGiai.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoDauCam(int.Parse(dtGiai.Rows[index2]["STT"].ToString()), this._soNgay);
      DataView defaultView = this.dtLoToTheoDauCam.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this.dtLoToTheoDauCam = defaultView.ToTable();
      float count = (float) dtGiai.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string loto1 = this.dtLoToTheoDauCam.Rows[index2]["loto1"].ToString();
        string loto2 = this.dtLoToTheoDauCam.Rows[index2]["loto2"].ToString();
        string s = this.dtLoToTheoDauCam.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(loto1, loto2);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + loto1 + "-" + loto2 + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < this._soNgay; ++index3)
          str5 = str5 + " <b>" + this.dtLoToTheoDauCam.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoDauCam(loto1, loto2);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoDauCam(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.dtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      DataTable dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      for (int index1 = 0; index1 < this.dtLoToTheoDauCam.Rows.Count; ++index1)
      {
        string str1 = this.dtLoToTheoDauCam.Rows[index1][0].ToString();
        string str2 = this.dtLoToTheoDauCam.Rows[index1][1].ToString();
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
          this.dtLoToTheoDauCam.Rows[index1][index2] = (object) (int.Parse(this.dtLoToTheoDauCam.Rows[index1][index2].ToString()) + 1);
          this.dtLoToTheoDauCam.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this.dtLoToTheoDauCam.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoDauCam(string loto1, string loto2)
    {
      string str1 = "";
      if (this.rdTrungDau.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau ngayVeLoTrungDau in this.tinhNgayveLoTrungDau)
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
      else if (this.rdTrungDuoi.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi in this.tinhNgayveLoTrungDuoi)
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

    private DataTable TaoBangLoTrungDauTheoDauCam(int khungDanh, int bienDo)
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

    private DataTable TaoBangLoTrungDuoiTheoDauCam(int khungDanh, int bienDo)
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

    private void GetDaTaBacNhoTheoDitCam()
    {
      DateTime ngayBatDau = this.dtNgayThang.Value.AddMonths(-FMain.ObjConfigBacNho.DuoiCam);
      DateTime ngayKetThuc = this.dtNgayThang.Value;
      this.strBacNhoTheoDitCam = "";
      for (int index = 0; index < this.listBacnhotheoditcam.Count; ++index)
        this.strBacNhoTheoDitCam += this.XuLyDuLieuTungDitCam(this.GetDataTungCapDitCam(ngayBatDau, ngayKetThuc, this.listBacnhotheoditcam[index]), this.listBacnhotheoditcam[index]);
    }

    private DataTable GetDataTungCapDitCam(DateTime ngayBatDau, DateTime ngayKetThuc, TabBacNhoTrungDauTrungDuoi.BacNhoTheoDitCam objBacNho)
    {
      DataTable dataTable = new DataTable();
      string text = objBacNho.Text;
      DataRow[] dataRowArray = this.dtTong.Select("clngaythang >='" + (object) ngayBatDau + "' and clngaythang < '" + (object) ngayKetThuc + "' and SUBSTRING(G0,2,1)<>'" + text + "'and SUBSTRING(G1,2,1)<>'" + text + "'and SUBSTRING(G21,2,1)<>'" + text + "' and SUBSTRING(G22,2,1)<>'" + text + "'and SUBSTRING(G31,2,1)<>'" + text + "' and SUBSTRING(G32,2,1)<>'" + text + "'and SUBSTRING(G33,2,1)<>'" + text + "'and SUBSTRING(G34,2,1)<>'" + text + "'and SUBSTRING(G35,2,1)<>'" + text + "'and SUBSTRING(G36,2,1)<>'" + text + "'and SUBSTRING(G41,2,1)<>'" + text + "'and SUBSTRING(G42,2,1)<>'" + text + "'and SUBSTRING(G43,2,1)<>'" + text + "'and SUBSTRING(G44,2,1)<>'" + text + "'and SUBSTRING(G51,2,1)<>'" + text + "'and SUBSTRING(G52,2,1)<>'" + text + "'and SUBSTRING(G53,2,1)<>'" + text + "'and SUBSTRING(G54,2,1)<>'" + text + "'and SUBSTRING(G55,2,1)<>'" + text + "'and SUBSTRING(G56,2,1)<>'" + text + "'and SUBSTRING(G61,2,1)<>'" + text + "'and SUBSTRING(G62,2,1)<>'" + text + "'and SUBSTRING(G63,2,1)<>'" + text + "'and SUBSTRING(G71,2,1)<>'" + text + "'and SUBSTRING(G72,2,1)<>'" + text + "'and SUBSTRING(G73,2,1)<>'" + text + "'and SUBSTRING(G74,2,1)<>'" + text + "'");
      if ((uint) dataRowArray.Length > 0U)
        dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      return dataTable;
    }

    private string XuLyDuLieuTungDitCam(DataTable dtGiai, TabBacNhoTrungDauTrungDuoi.BacNhoTheoDitCam objBacNho)
    {
      string str1 = "";
      object[] objArray = new object[12];
      objArray[0] = (object) str1;
      objArray[1] = (object) "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ ";
      int index1 = 2;
      DateTime dateTime = this.dtNgayThang.Value;
      dateTime = dateTime.AddMonths(-FMain.ObjConfigBacNho.DuoiCam);
      string str2 = dateTime.ToString("dd/MM/yyyy");
      objArray[index1] = (object) str2;
      objArray[3] = (object) " đến ngày ";
      objArray[4] = (object) this.dtNgayThang.Value.ToString("dd/MM/yyyy");
      objArray[5] = (object) ",  Đuôi [<b style='color:red;'> ";
      objArray[6] = (object) objBacNho.Text;
      objArray[7] = (object) " </b>] câm tất cả (<b style='color:red;'>  ";
      objArray[8] = (object) dtGiai.Rows.Count;
      objArray[9] = (object) "  </b>) lần. ";
      objArray[10] = (object) this._loTuDoTrungDauTrungDuoi;
      objArray[11] = (object) "</br>";
      string str3 = string.Concat(objArray);
      this.dtLoToTheoDitCam = new DataTable();
      if (this.rdTrungDau.Checked)
        this.dtLoToTheoDitCam = this.TaoBangLoTrungDauTheoDitCam(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDau);
      if (this.rdTrungDuoi.Checked)
        this.dtLoToTheoDitCam = this.TaoBangLoTrungDuoiTheoDitCam(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      for (int index2 = 0; index2 < dtGiai.Rows.Count; ++index2)
        this.XuLyLoToNgaySauTheoDitCam(int.Parse(dtGiai.Rows[index2]["STT"].ToString()), this._soNgay);
      DataView defaultView = this.dtLoToTheoDitCam.DefaultView;
      defaultView.Sort = "tongSOLAN DESC";
      this.dtLoToTheoDitCam = defaultView.ToTable();
      float count = (float) dtGiai.Rows.Count;
      for (int index2 = 0; index2 < FMain.ObjConfigBacNho.SoBanGhi; ++index2)
      {
        string loto1 = this.dtLoToTheoDitCam.Rows[index2]["loto1"].ToString();
        string loto2 = this.dtLoToTheoDitCam.Rows[index2]["loto2"].ToString();
        string s = this.dtLoToTheoDitCam.Rows[index2]["tongSOLAN"].ToString();
        this.XuLyLoToVeNhieu(loto1, loto2);
        string str4 = "[<b style='color:red;'>" + (object) Math.Round(double.Parse(s) / (double) count * 100.0, 1) + "%</b>]";
        string str5 = str3 + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + loto1 + "-" + loto2 + " )</b>  về  [<b style='color:red;'> " + s + " </b>] lần - " + str4 + ". Trong đó ";
        for (int index3 = 0; index3 < this._soNgay; ++index3)
          str5 = str5 + " <b>" + this.dtLoToTheoDitCam.Rows[index2][index3 + 2].ToString().Trim() + "</b> lần ngày " + (object) (index3 + 1) + ".";
        if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
          str5 += this.ChechVeNgayTheoDitCam(loto1, loto2);
        str3 = str5 + "<br>";
      }
      return str3;
    }

    private void XuLyLoToNgaySauTheoDitCam(int soThuTuBanGhi, int khungDanh)
    {
      DataRow[] dataRowArray = this.dtTong.Select("STT >'" + (object) soThuTuBanGhi + "' and STT<='" + (object) (soThuTuBanGhi + khungDanh) + "'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      DataTable dataTable = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      for (int index1 = 0; index1 < this.dtLoToTheoDitCam.Rows.Count; ++index1)
      {
        string str1 = this.dtLoToTheoDitCam.Rows[index1][0].ToString();
        string str2 = this.dtLoToTheoDitCam.Rows[index1][1].ToString();
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
          this.dtLoToTheoDitCam.Rows[index1][index2] = (object) (int.Parse(this.dtLoToTheoDitCam.Rows[index1][index2].ToString()) + 1);
          this.dtLoToTheoDitCam.Rows[index1]["tongSOLAN"] = (object) (int.Parse(this.dtLoToTheoDitCam.Rows[index1]["tongSOLAN"].ToString()) + 1);
        }
      }
    }

    private string ChechVeNgayTheoDitCam(string loto1, string loto2)
    {
      string str1 = "";
      if (this.rdTrungDau.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDau ngayVeLoTrungDau in this.tinhNgayveLoTrungDau)
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
      else if (this.rdTrungDuoi.Checked)
      {
        foreach (TabBacNhoTrungDauTrungDuoi.TinhNgayVeLoTrungDuoi ngayVeLoTrungDuoi in this.tinhNgayveLoTrungDuoi)
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

    private DataTable TaoBangLoTrungDauTheoDitCam(int khungDanh, int bienDo)
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

    private DataTable TaoBangLoTrungDuoiTheoDitCam(int khungDanh, int bienDo)
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

    private void bgTheoGiai_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoGiai();
    }

    private void bgTheoNhay_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoNhay();
    }

    private void bgTheoGiai_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.strBacNhoGiai.Length > 0)
      {
        this.strTong += "<br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO GIẢI </b>☞ º°”˜`”°☜♥☞</div>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>giải xổ số về</b> thì những cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += this.strBacNhoGiai;
        this.strTong += this.Show_LotoVeNhieu();
      }
      this.Hien_Thi_KetQua(this.webBrowser1, this.strTong);
    }

    private void bgTheoNhay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.strBacNhoTheoNhay.Length > 0)
      {
        this.strTong += "<br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO NHÁY </b>☞ º°”˜`”°☜♥☞</div>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các con lô <b style='color:red;'>về từ 2 nháy trở lên</b> ra, thì những cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += this.strBacNhoTheoNhay;
        this.strTong += this.Show_LotoVeNhieu();
      }
      this.Hien_Thi_KetQua(this.webBrowser1, this.strTong);
    }

    private void bgTheoCap_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoCap();
    }

    private void bgTheoCap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.strBacNhoTheoCap.Length > 0)
      {
        this.strTong += "<br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO CẶP </b>☞ º°”˜`”°☜♥☞</div>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>Cặp lô</b> cùng về, thì những cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += this.strBacNhoTheoCap;
        this.strTong += this.Show_LotoVeNhieu();
      }
      this.Hien_Thi_KetQua(this.webBrowser1, this.strTong);
    }

    private void bgCapCungVe_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoCapLienKe();
    }

    private void bgCapCungVe_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.strBacNhoTheoCapLienKe.Length > 0)
      {
        this.strTong += "<br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO CẶP LIỀN KỀ CÙNG VỀ </b>☞ º°”˜`”°☜♥☞</div>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi <b style='color:red;'>cặp lô liền kề</b> cùng về, thì những cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += this.strBacNhoTheoCapLienKe;
        this.strTong += this.Show_LotoVeNhieu();
      }
      this.Hien_Thi_KetQua(this.webBrowser1, this.strTong);
    }

    private void bgDauDitCam_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoDauCam();
    }

    private void BgDauDitCamRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.strBacNhoTheoDauCam.Length > 0)
      {
        this.strTong += "<br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO ĐẦU CÂM </b>☞ º°”˜`”°☜♥☞</div>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>Đầu lô tô</b> không về, thì những cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += this.strBacNhoTheoDauCam;
        this.strTong += this.Show_LotoVeNhieu();
      }
      this.Hien_Thi_KetQua(this.webBrowser1, this.strTong);
    }

    private void TimerLoadingTick(object sender, EventArgs e)
    {
      if (this.bgGetNewDay.IsBusy || this.bgListBacNho.IsBusy || (this.bgDataTong.IsBusy || this.bgTheoGiai.IsBusy) || (this.bgTheoNhay.IsBusy || this.bgTheoCap.IsBusy || (this.bgCapCungVe.IsBusy || this.bgDauCam.IsBusy)) || this.bgTinhNgayVe.IsBusy)
        this.picLoading.Visible = true;
      else
        this.picLoading.Visible = false;
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadDuLieuRadioButton();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.demCheckBox > 1)
      {
        int num = (int) MessageBox.Show("Mỗi lần bạn chỉ nên chọn (01) loại bạc nhớ để tránh bị loạn số !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this.LoadDuLieuRadioButton();
        this.strTong = "";
        if (this.bgListBacNho.IsBusy || this.bgGetNewDay.IsBusy || (this.bgDataTong.IsBusy || this.bgTinhNgayVe.IsBusy || (this.bgTheoGiai.IsBusy || this.bgTheoNhay.IsBusy) || (this.bgTheoCap.IsBusy || this.bgCapCungVe.IsBusy) || this.bgDauCam.IsBusy))
          return;
        this.bgDataTong.RunWorkerAsync();
      }
    }

    private void cbTheogiai_CheckedChanged(object sender, EventArgs e)
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

    private void rdTrungDau_CheckedChanged_1(object sender, EventArgs e)
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

    private void bgDitcam_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetDaTaBacNhoTheoDitCam();
    }

    private void bgDitcam_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.strBacNhoTheoDitCam.Length > 0)
      {
        this.strTong += "<br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>☜♥☞ º°”˜`”°º☜<b style='color:red;'> BẠC NHỚ THEO ĐÍT CÂM </b>☞ º°”˜`”°☜♥☞</div>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết khi các <b style='color:red;'>Đuôi lô tô</b> không về, thì những cặp lô nào hay về theo .</span></br><span style='font-size:12px;'>- Cấu hình <b style='color:red;'>khung lô cặp nuôi</b> để kiểm tra những cặp lô hay về nhiều những ngày sau đó .</br>- Khung kiểm tra lô về nhiều những ngày sau đó 3 ngày, 4 ngày ,5 ngày, 7 ngày cũng được miễn sao là bạn biết <b style='color:red;'>99,9%</b> là những lô tô đó sẽ về trong khoảng đó .</br>- Hãy cấu hình <b style='color:red;'>khoảng thời gian kiểm tra</b> của từng loại bạc nhớ và <b style='color:red;'>số ngày kiểm tra</b> để tìm cho mình một loại bạc nhớ hiệu quả nhất .</br>- Hãy tìm những cấu hình có tỷ lệ <b style='color:red;'>những ngày lô về</b> và <b style='color:red;'>số lô về trong ngày</b> khoảng <b style='color:red;'>90-95%</b> để đạt hiệu quả chiến thắng cao nhất .</span></br>";
        this.strTong += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        this.strTong += this.strBacNhoTheoDitCam;
        this.strTong += this.Show_LotoVeNhieu();
      }
      this.Hien_Thi_KetQua(this.webBrowser1, this.strTong);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabBacNhoTrungDauTrungDuoi));
      this.webBrowser1 = new WebBrowser();
      this.panel2 = new Panel();
      this.cbDitcam = new CheckBox();
      this.btnXem = new Button();
      this.label3 = new Label();
      this.rdTrungDuoi = new RadioButton();
      this.rdTrungDau = new RadioButton();
      this.cbDaucam = new CheckBox();
      this.cbCapcungve = new CheckBox();
      this.cbTheocap = new CheckBox();
      this.cbTheonhay = new CheckBox();
      this.cbTheogiai = new CheckBox();
      this.dtNgayThang = new DateTimePicker();
      this.label2 = new Label();
      this.label1 = new Label();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.toolTip1 = new ToolTip(this.components);
      this.bgGetNewDay = new BackgroundWorker();
      this.bgListBacNho = new BackgroundWorker();
      this.bgTinhNgayVe = new BackgroundWorker();
      this.bgDataTong = new BackgroundWorker();
      this.bgTheoGiai = new BackgroundWorker();
      this.bgTheoNhay = new BackgroundWorker();
      this.bgTheoCap = new BackgroundWorker();
      this.bgCapCungVe = new BackgroundWorker();
      this.bgDauCam = new BackgroundWorker();
      this.picLoading = new PictureBox();
      this.timerLoading = new Timer(this.components);
      this.bgDitcam = new BackgroundWorker();
      this.groupBox1 = new GroupBox();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.webBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.webBrowser1.Location = new Point(0, 2);
      this.webBrowser1.MinimumSize = new Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new Size(1115, 590);
      this.webBrowser1.TabIndex = 1;
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.panel2.Location = new Point(0, 0);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 46);
      this.panel2.TabIndex = 14;
      this.cbDitcam.AutoSize = true;
      this.cbDitcam.BackColor = Color.Transparent;
      this.cbDitcam.Cursor = Cursors.Hand;
      this.cbDitcam.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDitcam.ForeColor = Color.Black;
      this.cbDitcam.Location = new Point(674, 16);
      this.cbDitcam.Margin = new Padding(0);
      this.cbDitcam.Name = "cbDitcam";
      this.cbDitcam.Size = new Size(68, 19);
      this.cbDitcam.TabIndex = 22;
      this.cbDitcam.Text = "Đít câm";
      this.cbDitcam.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDitcam, " Xét theo những đầu đít lô câm trong ngày");
      this.cbDitcam.UseVisualStyleBackColor = false;
      this.cbDitcam.CheckedChanged += new EventHandler(this.cbDitcam_CheckedChanged);
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
      this.btnXem.Click += new EventHandler(this.button1_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(747, 15);
      this.label3.Name = "label3";
      this.label3.Size = new Size(12, 18);
      this.label3.TabIndex = 14;
      this.label3.Text = "]";
      this.rdTrungDuoi.AutoSize = true;
      this.rdTrungDuoi.Cursor = Cursors.Hand;
      this.rdTrungDuoi.FlatStyle = FlatStyle.Flat;
      this.rdTrungDuoi.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDuoi.ForeColor = Color.Black;
      this.rdTrungDuoi.Location = new Point(874, 15);
      this.rdTrungDuoi.Name = "rdTrungDuoi";
      this.rdTrungDuoi.Size = new Size(83, 19);
      this.rdTrungDuoi.TabIndex = 7;
      this.rdTrungDuoi.Text = "Trùng đuôi";
      this.toolTip1.SetToolTip((Control) this.rdTrungDuoi, " Hiển thị những cặp lô trùng đuôi hay về nhất trong khung");
      this.rdTrungDuoi.UseVisualStyleBackColor = true;
      this.rdTrungDuoi.CheckedChanged += new EventHandler(this.rdTrungDau_CheckedChanged_1);
      this.rdTrungDau.AutoSize = true;
      this.rdTrungDau.Checked = true;
      this.rdTrungDau.Cursor = Cursors.Hand;
      this.rdTrungDau.FlatStyle = FlatStyle.Flat;
      this.rdTrungDau.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDau.ForeColor = Color.Red;
      this.rdTrungDau.Location = new Point(790, 15);
      this.rdTrungDau.Name = "rdTrungDau";
      this.rdTrungDau.Size = new Size(80, 19);
      this.rdTrungDau.TabIndex = 6;
      this.rdTrungDau.TabStop = true;
      this.rdTrungDau.Text = "Trùng đầu";
      this.toolTip1.SetToolTip((Control) this.rdTrungDau, " Hiển thị những cặp lô trùng đầu hay về nhất trong khung");
      this.rdTrungDau.UseVisualStyleBackColor = true;
      this.rdTrungDau.CheckedChanged += new EventHandler(this.rdTrungDau_CheckedChanged_1);
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
      this.cbDaucam.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
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
      this.cbCapcungve.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
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
      this.cbTheocap.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
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
      this.cbTheonhay.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
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
      this.cbTheogiai.CheckedChanged += new EventHandler(this.cbTheogiai_CheckedChanged);
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
      this.dtNgayThang.ValueChanged += new EventHandler(this.dtNgayThang_ValueChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(198, 15);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 18);
      this.label2.TabIndex = 7;
      this.label2.Text = "[";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(4, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(65, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Xem ngày";
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.bgGetNewDay.DoWork += new DoWorkEventHandler(this.bgGetNewDay_DoWork);
      this.bgGetNewDay.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetNewDay_RunWorkerCompleted);
      this.bgListBacNho.DoWork += new DoWorkEventHandler(this.bgListBacNho_DoWork);
      this.bgListBacNho.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgListBacNho_RunWorkerCompleted);
      this.bgTinhNgayVe.DoWork += new DoWorkEventHandler(this.bgTinhNgayVe_DoWork);
      this.bgDataTong.DoWork += new DoWorkEventHandler(this.bgDataTong_DoWork);
      this.bgDataTong.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDataTong_RunWorkerCompleted);
      this.bgTheoGiai.DoWork += new DoWorkEventHandler(this.bgTheoGiai_DoWork);
      this.bgTheoGiai.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgTheoGiai_RunWorkerCompleted);
      this.bgTheoNhay.DoWork += new DoWorkEventHandler(this.bgTheoNhay_DoWork);
      this.bgTheoNhay.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgTheoNhay_RunWorkerCompleted);
      this.bgTheoCap.DoWork += new DoWorkEventHandler(this.bgTheoCap_DoWork);
      this.bgTheoCap.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgTheoCap_RunWorkerCompleted);
      this.bgCapCungVe.DoWork += new DoWorkEventHandler(this.bgCapCungVe_DoWork);
      this.bgCapCungVe.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgCapCungVe_RunWorkerCompleted);
      this.bgDauCam.DoWork += new DoWorkEventHandler(this.bgDauDitCam_DoWork);
      this.bgDauCam.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BgDauDitCamRunWorkerCompleted);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(648, 305);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 61;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.timerLoading.Enabled = true;
      this.timerLoading.Tick += new EventHandler(this.TimerLoadingTick);
      this.bgDitcam.DoWork += new DoWorkEventHandler(this.bgDitcam_DoWork);
      this.bgDitcam.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDitcam_RunWorkerCompleted);
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.dtNgayThang);
      this.groupBox1.Controls.Add((Control) this.cbDitcam);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.btnXem);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.cbTheogiai);
      this.groupBox1.Controls.Add((Control) this.rdTrungDuoi);
      this.groupBox1.Controls.Add((Control) this.cbTheonhay);
      this.groupBox1.Controls.Add((Control) this.rdTrungDau);
      this.groupBox1.Controls.Add((Control) this.cbTheocap);
      this.groupBox1.Controls.Add((Control) this.cbDaucam);
      this.groupBox1.Controls.Add((Control) this.cbCapcungve);
      this.groupBox1.Location = new Point(5, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1090, 43);
      this.groupBox1.TabIndex = 23;
      this.groupBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.webBrowser1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabBacNhoTrungDauTrungDuoi);
      this.Size = new Size(1100, 590);
      this.panel2.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
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

    public class TinhNgayVeLoTrungDuoi
    {
      public string Loto1 { get; set; }

      public string Loto2 { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLoto1 { get; set; }

      public string SoNhayVeLoto2 { get; set; }
    }

    public class TinhNgayVeLoTuDo
    {
      public string Loto1 { get; set; }

      public string Loto2 { get; set; }

      public string VeNgay { get; set; }

      public string MauSac { get; set; }

      public string SoNhayVeLoto1 { get; set; }

      public string SoNhayVeLoto2 { get; set; }
    }

    public class LoToVeNhieu
    {
      public string Loto1 { get; set; }

      public string Loto2 { get; set; }

      public int TongSoLanVe { get; set; }
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
