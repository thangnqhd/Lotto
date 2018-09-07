// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.TabBacnhotheothu
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

namespace Thống_kê_xổ_số
{
  public class TabBacnhotheothu : UserControl
  {
    private int sobanghikiemtravengay = 3;
    private IContainer components = (IContainer) null;
    public List<TabBacnhotheothu.LOTO> listLotoCap;
    public List<TabBacnhotheothu.LOTO> listLotoBachThu;
    public List<TabBacnhotheothu.LOTO> listLotoTrungDau;
    public List<TabBacnhotheothu.LOTO> listLotoTrungDuoi;
    public List<TabBacnhotheothu.LOTO> listLotoTuDo;
    public List<TabBacnhotheothu.LOTO> listLotoChuan;
    private string loaiLoto;
    private string biendongay;
    private int thukiemtratrongtuan;
    private DataTable _dtLongaysau;
    private Tbloto objLoto;
    private DataTable dtlotoThu;
    private int thukiemtra;
    private string _strHtml;
    private DataTable dtKetqua;
    private DataRow _rows;
    private string loKiemtra;
    private string thutrongtuan;
    public List<TabBacnhotheothu.TinhNgayVeLoCap> TinhNgayveLoCap;
    public List<TabBacnhotheothu.TinhNgayVeLoBachThu> TinhNgayveLoBachThu;
    private GroupBox groupBox1;
    private Label label1;
    private DateTimePicker dtTungay;
    private Button btnXem;
    private WebBrowser wbHienthi;
    private RadioButton rdBachThu;
    private RadioButton rdCap;
    private RadioButton rdTrungDuoi;
    private RadioButton rdTrungDau;
    private DateTimePicker dtDenngay;
    private Label label2;
    private RadioButton rdTudo;
    private ToolTip toolTip1;
    private PictureBox picLoading;
    private BackgroundWorker bgKhoitaodulieu;
    private BackgroundWorker bgKhoitaolotudo;
    private Timer timer1;
    private BackgroundWorker bgXuly;

    public TabBacnhotheothu()
    {
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.dtDenngay.Value = FMain.NgayKetQuaMoiNhat;
      this.dtTungay.Value = FMain.NgayKetQuaMoiNhat.AddDays((double) -FMain.ObjConfigBacNho.BacNhoTheoThu);
      this.Hien_Thi_KetQua(this.wbHienthi, "");
      this.objLoto = new Tbloto();
      if (!this.bgKhoitaodulieu.IsBusy)
        this.bgKhoitaodulieu.RunWorkerAsync();
      if (this.bgKhoitaolotudo.IsBusy)
        return;
      this.bgKhoitaolotudo.RunWorkerAsync();
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.StrCss1 + "<title>THỐNG KÊ XỔ SỐ</title></head><body  oncontextmenu='return false;' style='font-family:Verdana;'><div class='container' style='margin-right:15px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ></div><div class='panel-body'><ul class='media-list'><li class='media'>" + strHtml + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void dtDenngay_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtDenngay.Value > FMain.NgayKetQuaMoiNhat)
        this.dtDenngay.Value = FMain.NgayKetQuaMoiNhat;
      DateTimePicker dtTungay = this.dtTungay;
      DateTime dateTime1 = this.dtDenngay.Value;
      DateTime dateTime2 = dateTime1.AddDays((double) -FMain.ObjConfigBacNho.BacNhoTheoThu);
      dtTungay.Value = dateTime2;
      dateTime1 = this.dtDenngay.Value;
      dateTime1 = dateTime1.AddDays(1.0);
      this.thukiemtra = (int) dateTime1.DayOfWeek;
    }

    private void dtTungay_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtTungay.Value > this.dtDenngay.Value))
        return;
      this.dtTungay.Value = this.dtDenngay.Value.AddDays((double) -FMain.ObjConfigBacNho.BacNhoTheoThu);
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

    public void TaoListLotoCap()
    {
      this.listLotoCap = new List<TabBacnhotheothu.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBacnhotheothu.LOTO LOTO = new TabBacnhotheothu.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          LOTO.loto1 = "0" + (object) index;
        LOTO.loto2 = ClMain.check_Loto_Cap(LOTO.loto1);
        if (Convert.ToInt32(LOTO.loto1) > Convert.ToInt32(LOTO.loto2))
        {
          LOTO.loto1 = LOTO.loto2;
          LOTO.loto2 = ClMain.check_Loto_Cap(LOTO.loto1);
        }
        if (this.listLotoCap.Count > 0)
        {
          if (!this.listLotoCap.Any<TabBacnhotheothu.LOTO>((Func<TabBacnhotheothu.LOTO, bool>) (lo => LOTO.loto1 == lo.loto1)))
            this.listLotoCap.Add(LOTO);
        }
        else
          this.listLotoCap.Add(LOTO);
      }
    }

    private void TaoListLotoBachThu()
    {
      this.listLotoBachThu = new List<TabBacnhotheothu.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBacnhotheothu.LOTO loto = new TabBacnhotheothu.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.loto1 = "0" + (object) index;
        loto.loto2 = "aa";
        this.listLotoBachThu.Add(loto);
      }
    }

    private void TaoListLotoTrungDau(int biendo)
    {
      this.listLotoTrungDau = new List<TabBacnhotheothu.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBacnhotheothu.LOTO loto = new TabBacnhotheothu.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.loto1 = "0" + (object) index;
        loto.loto2 = this.BienDoiLoToTrungDau(loto.loto1, biendo);
        if (!(loto.loto2 == ""))
          this.listLotoTrungDau.Add(loto);
      }
    }

    private void TaoListLotoTrungDuoi(int biendo)
    {
      this.listLotoTrungDuoi = new List<TabBacnhotheothu.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabBacnhotheothu.LOTO loto = new TabBacnhotheothu.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.loto1 = "0" + (object) index;
        loto.loto2 = this.BienDoiLoToTrungDuoi(loto.loto1, biendo);
        if (!(loto.loto2 == ""))
          this.listLotoTrungDuoi.Add(loto);
      }
    }

    private void TaoListLotoTuDo()
    {
      this.listLotoTuDo = new List<TabBacnhotheothu.LOTO>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        for (int index2 = 0; index2 < 100; ++index2)
        {
          if (index1 != index2)
          {
            TabBacnhotheothu.LOTO LOTO = new TabBacnhotheothu.LOTO()
            {
              loto1 = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture),
              loto2 = index2.ToString((IFormatProvider) CultureInfo.InvariantCulture)
            };
            if (index1 < 10)
              LOTO.loto1 = "0" + (object) index1;
            string loto1 = LOTO.loto1;
            if (index2 < 10)
              LOTO.loto2 = "0" + (object) index2;
            if (Convert.ToInt32(LOTO.loto1) > Convert.ToInt32(LOTO.loto2))
            {
              LOTO.loto1 = LOTO.loto2;
              LOTO.loto2 = loto1;
            }
            if (!this.listLotoTuDo.Any<TabBacnhotheothu.LOTO>((Func<TabBacnhotheothu.LOTO, bool>) (item =>
            {
              if (item.loto1 == LOTO.loto1)
                return item.loto2 == LOTO.loto2;
              return false;
            })))
              this.listLotoTuDo.Add(LOTO);
          }
        }
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

    private void bgKhoitaodulieu_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Khoitaodulieu();
    }

    private void Khoitaodulieu()
    {
      this.TaoListLotoCap();
      this.TaoListLotoBachThu();
      this.TaoListLotoTrungDau(FMain.ObjConfigBacNho.BiendoTrungDau);
      this.TaoListLotoTrungDuoi(FMain.ObjConfigBacNho.BiendoTrungDuoi);
    }

    private void bgKhoitaolotudo_DoWork(object sender, DoWorkEventArgs e)
    {
      this.TaoListLotoTuDo();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.bgKhoitaodulieu.IsBusy || this.bgKhoitaolotudo.IsBusy)
        this.btnXem.Enabled = false;
      else
        this.btnXem.Enabled = true;
      if (this.bgKhoitaodulieu.IsBusy || this.bgKhoitaolotudo.IsBusy || this.bgXuly.IsBusy)
        this.picLoading.Visible = true;
      else
        this.picLoading.Visible = false;
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (this.rdCap.Checked)
      {
        this.loaiLoto = "Lô Cặp";
        this.listLotoChuan = new List<TabBacnhotheothu.LOTO>((IEnumerable<TabBacnhotheothu.LOTO>) this.listLotoCap);
      }
      this.sobanghikiemtravengay = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
      if (this.rdBachThu.Checked)
      {
        this.loaiLoto = "Lô Bạch Thủ";
        this.listLotoChuan = new List<TabBacnhotheothu.LOTO>((IEnumerable<TabBacnhotheothu.LOTO>) this.listLotoBachThu);
        this.sobanghikiemtravengay = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
      }
      if (this.rdTrungDau.Checked)
      {
        this.loaiLoto = "Lô Trùng Đầu";
        this.TaoListLotoTrungDau(FMain.ObjConfigBacNho.BiendoTrungDau);
        this.listLotoChuan = new List<TabBacnhotheothu.LOTO>((IEnumerable<TabBacnhotheothu.LOTO>) this.listLotoTrungDau);
      }
      if (this.rdTrungDuoi.Checked)
      {
        this.loaiLoto = "Lô Trùng Đuôi";
        this.TaoListLotoTrungDuoi(FMain.ObjConfigBacNho.BiendoTrungDuoi);
        this.listLotoChuan = new List<TabBacnhotheothu.LOTO>((IEnumerable<TabBacnhotheothu.LOTO>) this.listLotoTrungDuoi);
      }
      if (this.rdTudo.Checked)
      {
        this.loaiLoto = "Lô Cặp Tự Do";
        this.listLotoChuan = new List<TabBacnhotheothu.LOTO>((IEnumerable<TabBacnhotheothu.LOTO>) this.listLotoTuDo);
      }
      if (this.dtDenngay.Value.Subtract(this.dtTungay.Value).Days < 14)
      {
        int num = (int) MessageBox.Show("Bạn cần kiểm tra ít nhất là 2 tuần để có kết quả chính xác nhất !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (this.bgXuly.IsBusy)
          return;
        this.bgXuly.RunWorkerAsync();
      }
    }

    private void bgXuly_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetData(this.thukiemtra);
    }

    public void KhoiTaoDataBacNho()
    {
      this.dtKetqua = new DataTable();
      this.dtKetqua.Columns.Add("loto", typeof (string));
      this.dtKetqua.Columns.Add("solanve", typeof (int));
    }

    private void GetData(int _thutrongtuan)
    {
      try
      {
        this.KhoiTaoDataBacNho();
        this.dtlotoThu = this.objLoto.GetLotoByNgayThangAndThu(this.dtTungay.Value, this.dtDenngay.Value, _thutrongtuan);
        this.GetDataLoVeNgaySau(FMain.ObjConfigBacNho);
        if (this.dtlotoThu.Rows.Count <= 0 || this.listLotoChuan.Count <= 0)
          return;
        this._strHtml = "";
        for (int index1 = 0; index1 < this.listLotoChuan.Count; ++index1)
        {
          int num = 0;
          for (int index2 = 0; index2 < this.dtlotoThu.Rows.Count; ++index2)
          {
            bool flag = false;
            for (int index3 = 2; index3 < this.dtlotoThu.Columns.Count; ++index3)
            {
              this.loKiemtra = this.dtlotoThu.Rows[index2][index3].ToString();
              if (this.loKiemtra == this.listLotoChuan[index1].loto1 || this.loKiemtra == this.listLotoChuan[index1].loto2)
              {
                flag = true;
                break;
              }
            }
            if (flag)
              ++num;
          }
          this._rows = this.dtKetqua.NewRow();
          this._rows["loto"] = (object) (this.listLotoChuan[index1].loto1 + "-" + this.listLotoChuan[index1].loto2);
          if (this.rdBachThu.Checked)
            this._rows["loto"] = (object) this.listLotoChuan[index1].loto1;
          this._rows["solanve"] = (object) num;
          this.dtKetqua.Rows.Add(this._rows);
        }
        this.thutrongtuan = Tbketqua.GetThuTrongtuan_Thu(_thutrongtuan);
        DataView defaultView = this.dtKetqua.DefaultView;
        defaultView.Sort = "solanve desc";
        this.dtKetqua = defaultView.ToTable();
        this._strHtml += "<br>";
        this._strHtml += (this._strHtml += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>");
        this._strHtml = this._strHtml + "<span style='font-size:13px;'>+ Chức năng này sẽ cho bạn biết dạo gần đây <b style='color:red;'>" + this.thutrongtuan + "</b> hay về những con lô, cặp lô nào, về ở những ngày nào sau đó .</span></br>";
        this._strHtml = this._strHtml + "<span style='font-size:13px;'>+ Thứ kiểm tra sẽ được tính sau ngày có kết quả <b style='color:red;'>" + this.dtDenngay.Value.ToString("dd/MM/yyyy") + "</b> mà bạn kiểm tra. </span></br>";
        this._strHtml += "<div style='text-align:center;font-size:14px;font-weight:bold;width:100%;color:rgb(43, 60, 80);'>  &nbsp;&nbsp;******************************</div>";
        object[] objArray = new object[12];
        objArray[0] = (object) this._strHtml;
        objArray[1] = (object) "<b style='color:rgb(43, 60, 80);font-size:14px;'>☞ Từ ";
        int index4 = 2;
        DateTime dateTime = this.dtTungay.Value;
        string str1 = dateTime.ToString("dd/MM/yyyy");
        objArray[index4] = (object) str1;
        objArray[3] = (object) " đến ngày ";
        int index5 = 4;
        dateTime = this.dtDenngay.Value;
        string str2 = dateTime.ToString("dd/MM/yyyy");
        objArray[index5] = (object) str2;
        objArray[5] = (object) ", Có tất cả <b style='color:blue;'>(";
        objArray[6] = (object) this.dtlotoThu.Rows.Count;
        objArray[7] = (object) ")</b> - <b style='color:red;'> ";
        objArray[8] = (object) this.thutrongtuan;
        objArray[9] = (object) " </b>, Dạo gần đây những lô hay về vào <b style='color:red;'> ";
        objArray[10] = (object) this.thutrongtuan;
        objArray[11] = (object) " </b> là .</b></br>";
        this._strHtml = string.Concat(objArray);
        if (this.rdBachThu.Checked)
          this.TimNgayVe(FMain.ObjConfigBacNho.KhungDanhBachThuNuoi);
        else
          this.TimNgayVe(FMain.ObjConfigBacNho.KhungDanhLoCapNuoi);
        for (int index1 = 0; index1 < FMain.ObjConfigBacNho.SoBanGhi; ++index1)
        {
          string lotoXuoi;
          string lotoLon;
          try
          {
            lotoXuoi = this.dtKetqua.Rows[index1]["loto"].ToString().Split('-')[0];
            lotoLon = this.dtKetqua.Rows[index1]["loto"].ToString().Split('-')[1];
          }
          catch (Exception ex)
          {
            lotoXuoi = this.dtKetqua.Rows[index1]["loto"].ToString();
            lotoLon = this.dtKetqua.Rows[index1]["loto"].ToString();
          }
          Decimal num = Convert.ToDecimal(this.dtKetqua.Rows[index1]["solanve"].ToString());
          string str3 = "[<b style='color:red;'>" + (object) Math.Round(num / Convert.ToDecimal(this.dtlotoThu.Rows.Count) * new Decimal(100), 1) + "%</b>]";
          this._strHtml = this._strHtml + "<div style='font-size:14px;'>- Lô  <b style='color:blue;'>( " + this.dtKetqua.Rows[index1]["loto"] + " )</b>  về  [<b style='color:red;'> " + (object) num + " </b>] lần - " + str3 + ". " + this.ChechVeNgay(lotoXuoi, lotoLon) + "</br>";
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void TimNgayVe(int soBanGhi)
    {
      this.TinhNgayveLoCap = new List<TabBacnhotheothu.TinhNgayVeLoCap>();
      for (int index1 = 0; index1 < FMain.ObjConfigBacNho.SoBanGhi; ++index1)
      {
        string str1;
        string str2;
        try
        {
          str1 = this.dtKetqua.Rows[index1]["loto"].ToString().Split('-')[0];
          str2 = this.dtKetqua.Rows[index1]["loto"].ToString().Split('-')[1];
        }
        catch (Exception ex)
        {
          str1 = this.dtKetqua.Rows[index1]["loto"].ToString().Split('-')[0];
          str2 = str1;
        }
        TabBacnhotheothu.TinhNgayVeLoCap tinhNgayVeLoCap = new TabBacnhotheothu.TinhNgayVeLoCap();
        string str3 = "";
        string str4 = "";
        bool flag1 = false;
        bool flag2 = false;
        string str5 = " Chưa về";
        string str6 = "Black";
        int num = this._dtLongaysau.Rows.Count;
        if (num >= soBanGhi + 1)
          num = soBanGhi + 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          str3 = str1;
          str4 = str2;
          for (int index3 = 2; index3 < this._dtLongaysau.Columns.Count; ++index3)
          {
            string str7 = this._dtLongaysau.Rows[index2][index3].ToString();
            if (str1 == str7)
            {
              str3 += "*";
              flag1 = true;
            }
            if (str2 == str7)
            {
              str4 += "*";
              flag2 = true;
            }
          }
          if (flag1 | flag2)
          {
            str6 = "Black";
            if (index2 + 1 <= soBanGhi)
              str6 = "Red";
            str5 = " Về ngày " + (index2 + 1).ToString();
            break;
          }
        }
        if (!flag2)
          str4 = "";
        if (!flag1)
          str3 = "";
        if (!flag1 && !flag2)
          str5 = num >= soBanGhi ? " Xịt" : " Chưa về";
        tinhNgayVeLoCap.LotoXuoi = str1;
        tinhNgayVeLoCap.Lotolon = str2;
        tinhNgayVeLoCap.VeNgay = str5;
        tinhNgayVeLoCap.MauSac = str6;
        tinhNgayVeLoCap.SoNhayVeLotoXuoi = str3;
        tinhNgayVeLoCap.SoNhayVeLotoLon = str4;
        this.TinhNgayveLoCap.Add(tinhNgayVeLoCap);
      }
    }

    private void GetDataLoVeNgaySau(tbConfigBacNho objBacNho)
    {
      int num = objBacNho.KhungDanhLoCapNuoi;
      if (objBacNho.KhungDanhBachThuNuoi > objBacNho.KhungDanhLoCapNuoi)
        num = objBacNho.KhungDanhBachThuNuoi;
      this._dtLongaysau = new DataTable();
      this._dtLongaysau = this.objLoto.GetLotoByNgayThangSoBanGhi(this.dtDenngay.Value, num + 2);
    }

    private string ChechVeNgay(string lotoXuoi, string lotoLon)
    {
      string str1 = "";
      if (FMain.ObjConfigBacNho.HienThiNgayVe == 1)
      {
        if (this.rdBachThu.Checked)
        {
          foreach (TabBacnhotheothu.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
          {
            if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi)
            {
              string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi;
              if (str2.Length > 0)
                str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
              str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
              break;
            }
          }
        }
        else
        {
          foreach (TabBacnhotheothu.TinhNgayVeLoCap tinhNgayVeLoCap in this.TinhNgayveLoCap)
          {
            if (tinhNgayVeLoCap.LotoXuoi == lotoXuoi && tinhNgayVeLoCap.Lotolon == lotoLon)
            {
              string str2 = tinhNgayVeLoCap.SoNhayVeLotoXuoi + tinhNgayVeLoCap.SoNhayVeLotoLon;
              if (str2.Length > 0)
                str2 = "<b style='color:Black;'>(</b>" + str2 + "<b style='color:Black;'>)</b>";
              str1 = str1 + "<b style='color:" + tinhNgayVeLoCap.MauSac + ";'>" + tinhNgayVeLoCap.VeNgay + " " + str2 + "</b>";
              break;
            }
          }
        }
      }
      return str1;
    }

    private void bgKhoitaolotudo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    private void cbbThu_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void bgXuly_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Hien_Thi_KetQua(this.wbHienthi, this._strHtml);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabBacnhotheothu));
      this.groupBox1 = new GroupBox();
      this.rdTudo = new RadioButton();
      this.dtDenngay = new DateTimePicker();
      this.label2 = new Label();
      this.rdBachThu = new RadioButton();
      this.rdCap = new RadioButton();
      this.rdTrungDuoi = new RadioButton();
      this.rdTrungDau = new RadioButton();
      this.label1 = new Label();
      this.dtTungay = new DateTimePicker();
      this.btnXem = new Button();
      this.wbHienthi = new WebBrowser();
      this.toolTip1 = new ToolTip(this.components);
      this.picLoading = new PictureBox();
      this.bgKhoitaodulieu = new BackgroundWorker();
      this.bgKhoitaolotudo = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.bgXuly = new BackgroundWorker();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.rdTudo);
      this.groupBox1.Controls.Add((Control) this.dtDenngay);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.rdBachThu);
      this.groupBox1.Controls.Add((Control) this.rdCap);
      this.groupBox1.Controls.Add((Control) this.rdTrungDuoi);
      this.groupBox1.Controls.Add((Control) this.rdTrungDau);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.dtTungay);
      this.groupBox1.Controls.Add((Control) this.btnXem);
      this.groupBox1.Location = new Point(5, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1090, 43);
      this.groupBox1.TabIndex = 24;
      this.groupBox1.TabStop = false;
      this.rdTudo.AutoSize = true;
      this.rdTudo.Cursor = Cursors.Hand;
      this.rdTudo.FlatStyle = FlatStyle.Flat;
      this.rdTudo.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTudo.ForeColor = Color.Black;
      this.rdTudo.Location = new Point(647, 15);
      this.rdTudo.Name = "rdTudo";
      this.rdTudo.Size = new Size(78, 19);
      this.rdTudo.TabIndex = 15;
      this.rdTudo.Text = "Cặp tự do";
      this.toolTip1.SetToolTip((Control) this.rdTudo, "Kiểm tra các cặp lô tự do hay về trong thời gian gần đây");
      this.rdTudo.UseVisualStyleBackColor = true;
      this.rdTudo.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.dtDenngay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtDenngay.CalendarForeColor = Color.Red;
      this.dtDenngay.CalendarMonthBackground = SystemColors.Info;
      this.dtDenngay.CustomFormat = "dd/MM/yyyy";
      this.dtDenngay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtDenngay.Format = DateTimePickerFormat.Custom;
      this.dtDenngay.Location = new Point(173, 15);
      this.dtDenngay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtDenngay.Name = "dtDenngay";
      this.dtDenngay.Size = new Size(91, 21);
      this.dtDenngay.TabIndex = 14;
      this.dtDenngay.ValueChanged += new EventHandler(this.dtDenngay_ValueChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(160, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(12, 16);
      this.label2.TabIndex = 13;
      this.label2.Text = "-";
      this.rdBachThu.AutoSize = true;
      this.rdBachThu.Cursor = Cursors.Hand;
      this.rdBachThu.FlatStyle = FlatStyle.Flat;
      this.rdBachThu.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdBachThu.ForeColor = Color.Black;
      this.rdBachThu.Location = new Point(394, 15);
      this.rdBachThu.Name = "rdBachThu";
      this.rdBachThu.Size = new Size(72, 19);
      this.rdBachThu.TabIndex = 10;
      this.rdBachThu.Text = "Bạch thủ";
      this.toolTip1.SetToolTip((Control) this.rdBachThu, "Kiểm tra các lô bạch thủ hay về trong thời gian gần đây");
      this.rdBachThu.UseVisualStyleBackColor = true;
      this.rdBachThu.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdCap.AutoSize = true;
      this.rdCap.Checked = true;
      this.rdCap.Cursor = Cursors.Hand;
      this.rdCap.FlatStyle = FlatStyle.Flat;
      this.rdCap.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.rdCap.ForeColor = Color.Red;
      this.rdCap.Location = new Point(326, 15);
      this.rdCap.Name = "rdCap";
      this.rdCap.Size = new Size(62, 19);
      this.rdCap.TabIndex = 9;
      this.rdCap.TabStop = true;
      this.rdCap.Text = "Lô cặp";
      this.toolTip1.SetToolTip((Control) this.rdCap, "Kiểm tra các cặp lô lộn hay về trong thời gian gần đây");
      this.rdCap.UseVisualStyleBackColor = true;
      this.rdCap.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdTrungDuoi.AutoSize = true;
      this.rdTrungDuoi.Cursor = Cursors.Hand;
      this.rdTrungDuoi.FlatStyle = FlatStyle.Flat;
      this.rdTrungDuoi.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDuoi.ForeColor = Color.Black;
      this.rdTrungDuoi.Location = new Point(558, 15);
      this.rdTrungDuoi.Name = "rdTrungDuoi";
      this.rdTrungDuoi.Size = new Size(83, 19);
      this.rdTrungDuoi.TabIndex = 12;
      this.rdTrungDuoi.Text = "Trùng đuôi";
      this.toolTip1.SetToolTip((Control) this.rdTrungDuoi, "Kiểm tra các cặp lô trùng đuôi hay về trong thời gian gần đây");
      this.rdTrungDuoi.UseVisualStyleBackColor = true;
      this.rdTrungDuoi.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdTrungDau.AutoSize = true;
      this.rdTrungDau.Cursor = Cursors.Hand;
      this.rdTrungDau.FlatStyle = FlatStyle.Flat;
      this.rdTrungDau.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rdTrungDau.ForeColor = Color.Black;
      this.rdTrungDau.Location = new Point(472, 15);
      this.rdTrungDau.Name = "rdTrungDau";
      this.rdTrungDau.Size = new Size(80, 19);
      this.rdTrungDau.TabIndex = 11;
      this.rdTrungDau.Text = "Trùng đầu";
      this.toolTip1.SetToolTip((Control) this.rdTrungDau, "Kiểm tra các cặp lô trùng đầu hay về trong thời gian gần đây");
      this.rdTrungDau.UseVisualStyleBackColor = true;
      this.rdTrungDau.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(11, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(56, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Từ ngày";
      this.dtTungay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtTungay.CalendarForeColor = Color.Red;
      this.dtTungay.CalendarMonthBackground = SystemColors.Info;
      this.dtTungay.CustomFormat = "dd/MM/yyyy";
      this.dtTungay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtTungay.Format = DateTimePickerFormat.Custom;
      this.dtTungay.Location = new Point(69, 15);
      this.dtTungay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtTungay.Name = "dtTungay";
      this.dtTungay.Size = new Size(91, 21);
      this.dtTungay.TabIndex = 0;
      this.dtTungay.ValueChanged += new EventHandler(this.dtTungay_ValueChanged);
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(789, 12);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(75, 24);
      this.btnXem.TabIndex = 8;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.btnXem_Click);
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(0, 2);
      this.wbHienthi.MinimumSize = new Size(23, 23);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1115, 513);
      this.wbHienthi.TabIndex = 23;
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(525, 349);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 60;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.bgKhoitaodulieu.DoWork += new DoWorkEventHandler(this.bgKhoitaodulieu_DoWork);
      this.bgKhoitaolotudo.DoWork += new DoWorkEventHandler(this.bgKhoitaolotudo_DoWork);
      this.bgKhoitaolotudo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgKhoitaolotudo_RunWorkerCompleted);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.bgXuly.DoWork += new DoWorkEventHandler(this.bgXuly_DoWork);
      this.bgXuly.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgXuly_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.wbHienthi);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabBacnhotheothu);
      this.Size = new Size(1100, 513);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }

    public class LOTO
    {
      public string loto1 { get; set; }

      public string loto2 { get; set; }
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
  }
}
