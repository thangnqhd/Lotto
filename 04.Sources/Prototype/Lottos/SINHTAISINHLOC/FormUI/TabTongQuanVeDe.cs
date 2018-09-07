// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabTongQuanVeDe
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabTongQuanVeDe : UserControl
  {
    private IContainer components = (IContainer) null;
    private string _htmlKetqua;
    private DataTable dtTong;
    private DateTime _ngayKiemTraCu;
    private readonly Tbloto objLoto;
    private string _htmlDau;
    private string _htmlDuoi;
    private string _htmlTong;
    private string _htmlBo;
    private string _htmlCham;
    private string _htmlChanLe;
    private string _htmlNhoTo;
    private string _htmlBongDuong;
    private string _htmlHieu;
    private string _htmlChiaBa;
    private DataTable dtDan;
    private tbDan objDan;
    private BunifuElipse bunifuElipse1;
    private Panel panel1;
    private CheckBox cbTong;
    private CheckBox cbDuoi;
    private CheckBox cbDau;
    private Label label1;
    private Button btnXem;
    private Label label6;
    private DateTimePicker dtNgayKiemTra;
    private CheckBox cbCham;
    private ToolTip toolTip1;
    private CheckBox cbDanbo;
    private CheckBox cbDanChanLe;
    private CheckBox cbDanNhoTo;
    private CheckBox cbDanBongDuong;
    private CheckBox cbDanHieu;
    private CheckBox cbDanChiaBa;
    private BackgroundWorker bgDau;
    private BackgroundWorker bgDuoi;
    private BackgroundWorker bgGetKetQua;
    private WebBrowser wbHienthi;
    private Timer timerLoading;
    private PictureBox picLoading;
    private BackgroundWorker bgTong;
    private BackgroundWorker bgCham;
    private BackgroundWorker bgBo;
    private BackgroundWorker bgChanLe;
    private BackgroundWorker bgNhoTo;
    private BackgroundWorker bgBongDuong;
    private BackgroundWorker bgHieu;
    private BackgroundWorker bgChiaBa;

    public TabTongQuanVeDe()
    {
      this.InitializeComponent();
      this.dtNgayKiemTra.Value = FMain.NgayKetQuaMoiNhat;
      this.objLoto = new Tbloto();
      this.objDan = new tbDan();
    }

    private void dtNgayKiemTra_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayKiemTra.Value >= FMain.NgayKetQuaMoiNhat))
        return;
      this.dtNgayKiemTra.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void cbDuoi_CheckedChanged(object sender, EventArgs e)
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

    private void btnXem_Click(object sender, EventArgs e)
    {
      TabTongQuanVeDe.HienThiKetQua(this.wbHienthi, "");
      if (this.bgGetKetQua.IsBusy)
        return;
      this.bgGetKetQua.RunWorkerAsync();
    }

    private string ThongKeDauLo(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;' >Dàn Đầu</td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private string ThongKeDuoiLo(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Đuôi</td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private string ThongKeTong(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Tổng</td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private string TinhNgayChuaRa(int ngayChuaRa, int maxGan)
    {
      string str1 = "";
      string str2;
      if (ngayChuaRa + (FMain.ObjConfigBacNho.KhungDanhDacBietNuoi - 2) >= maxGan || ngayChuaRa < 3)
        str2 = str1 + "<td class='borderVien' align='center' style='color:red;'><b>" + (object) ngayChuaRa + "</td>";
      else
        str2 = str1 + "<td class='borderVien' align='center'>" + (object) ngayChuaRa + "</td>";
      return str2;
    }

    private void bgDau_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='dandau'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlDau = this.ThongKeDauLo(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Các Dàn Đầu Giải Đặc Biệt Trong 1 Năm Qua");
    }

    private void bgDuoi_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='danduoi'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlDuoi = this.ThongKeDuoiLo(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Các Dàn Đuôi Giải Đặc Biệt Trong 1 Năm Qua");
    }

    private void bgGetKetQua_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        if (!(this._ngayKiemTraCu != this.dtNgayKiemTra.Value))
          return;
        this._ngayKiemTraCu = this.dtNgayKiemTra.Value;
        this.dtTong = new DataTable();
        this.dtDan = new DataTable();
        this.dtDan = this.objDan.GetAll();
        this.dtTong = this.objLoto.GetBangDacBiet_HaiSoCuoi_ByDate(this._ngayKiemTraCu.AddYears(-1), this._ngayKiemTraCu);
        if (this.dtDan.Rows.Count > 0)
        {
          for (int index1 = 0; index1 < this.dtDan.Rows.Count; ++index1)
          {
            bool flag = false;
            int num1 = 0;
            string[] strArray = this.dtDan.Rows[index1]["danSo"].ToString().Split(',');
            int num2 = 0;
            for (int index2 = 0; index2 < this.dtTong.Rows.Count; ++index2)
            {
              string _giaiDacBiet = this.dtTong.Rows[index2]["G0"].ToString();
              if (((IEnumerable<string>) strArray).Any<string>((Func<string, bool>) (t => _giaiDacBiet == t)))
              {
                ++num1;
                flag = true;
              }
              else if (!flag)
                ++num2;
            }
            this.dtDan.Rows[index1]["soLanVe"] = (object) num1;
            this.dtDan.Rows[index1]["tongSoNgayXet"] = (object) (this.dtTong.Rows.Count - num1);
            this.dtDan.Rows[index1]["chuKyTrungBinh"] = (object) Math.Round(Convert.ToDecimal(this.dtTong.Rows.Count) / (Decimal) num1, 1);
            this.dtDan.Rows[index1]["ngayChuaRa"] = (object) num2;
          }
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
    }

    private void bgGetKetQua_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.dtTong.Rows.Count > 0)
      {
        this._htmlDau = "";
        this._htmlDuoi = "";
        this._htmlTong = "";
        this._htmlCham = "";
        this._htmlBo = "";
        this._htmlChanLe = "";
        this._htmlNhoTo = "";
        this._htmlBongDuong = "";
        this._htmlHieu = "";
        this._htmlChiaBa = "";
        if (this.cbDau.Checked && !this.bgDau.IsBusy)
          this.bgDau.RunWorkerAsync();
        if (this.cbDuoi.Checked && !this.bgDuoi.IsBusy)
          this.bgDuoi.RunWorkerAsync();
        if (this.cbTong.Checked && !this.bgTong.IsBusy)
          this.bgTong.RunWorkerAsync();
        if (this.cbCham.Checked && !this.bgCham.IsBusy)
          this.bgCham.RunWorkerAsync();
        if (this.cbDanbo.Checked && !this.bgBo.IsBusy)
          this.bgBo.RunWorkerAsync();
        if (this.cbDanChanLe.Checked && !this.bgChanLe.IsBusy)
          this.bgChanLe.RunWorkerAsync();
        if (this.cbDanNhoTo.Checked && !this.bgNhoTo.IsBusy)
          this.bgNhoTo.RunWorkerAsync();
        if (this.cbDanBongDuong.Checked && !this.bgBongDuong.IsBusy)
          this.bgBongDuong.RunWorkerAsync();
        if (this.cbDanHieu.Checked && !this.bgHieu.IsBusy)
          this.bgHieu.RunWorkerAsync();
        if (!this.cbDanChiaBa.Checked || this.bgChiaBa.IsBusy)
          return;
        this.bgChiaBa.RunWorkerAsync();
      }
      else
      {
        int num = (int) MessageBox.Show("KHÔNG TÌM THẤY DỮ LIỆU CẦN TÌM", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    public static void HienThiKetQua(WebBrowser wb, string strHtml)
    {
      string html = "<html><head>\r\n            <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n            <meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\" />\r\n            <style type=\"text/css\">\r\n            .style1{width: 18%;height: 30px;border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;border-bottom-width: 1px;font-size:16px;text-align:center;}\r\n            .style2 {width: 500px;text-align: center;height: 31px;font-size: 19px;border-bottom-style: dotted;border-bottom-width:1px;border-color: orangered;}\r\n            .style3{border-color: red;width: 45px; height: 21px; border-right:1px dotted #FF6600;border-bottom-style: dotted;border-bottom-width: 1px;font-size:15px;}\r\n            .style4 {border-color: red;border-bottom-style: dotted; border-bottom-width: 1px;font-size:15px;}\r\n            .main{width:97%;float:right;margin-right:1%;height: 268px; margin-left: auto; margin-top: 0;padding-bottom: 50px;}\r\n            .table_KQ {border: 1px dotted #FF6600; width: 56%; float: left;}\r\n            .title_XS { text-align:center;margin:0px auto;width:60%;float:left;font-size:20px;color:red;}\r\n            .header {color: White;}\r\n            .lotoHeader {color: red; font-weight: bold; }\r\n            .borderVien\r\n            {\r\n            border-style:dotted;\r\n\t            border-width:1px;\r\n            border-color:DarkGray;\r\n            }\r\n            .maunen{\r\n            border-style:dotted;\r\n\t            border-width:1px;\r\n                border-color:DarkGray;\r\n                 background: teal;\r\n             color:white;\r\n            }\r\n            .botTable{\r\n            color:black;\r\n            font-weight: normal;\r\n                font-style: italic;\r\n            }\r\n             </style>\r\n            \r\n            </head>\r\n            <body oncontextmenu='return false;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void bgDau_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.HienThi();
    }

    private void bgDuoi_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.HienThi();
    }

    private void HienThi()
    {
      if (this.bgDau.IsBusy || this.bgDuoi.IsBusy)
        return;
      this._htmlKetqua = this._htmlDau + this._htmlDuoi + this._htmlTong + this._htmlCham + this._htmlBo + this._htmlChanLe + this._htmlNhoTo + this._htmlBongDuong + this._htmlHieu + this._htmlChiaBa;
      TabTongQuanVeDe.HienThiKetQua(this.wbHienthi, this._htmlKetqua);
    }

    private void timerLoading_Tick(object sender, EventArgs e)
    {
      if (this.bgGetKetQua.IsBusy || this.bgDau.IsBusy || this.bgDuoi.IsBusy)
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

    private void bgTong_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='dantong'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlTong = this.ThongKeTong(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Dàn Tổng 2 Số Cuối Giải Đặc Biệt Trong 1 Năm Qua");
    }

    private void bgCham_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='dancham'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlCham = this.ThongKeDanCham(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Dàn Chạm 2 Số Cuối Giải Đặc Biệt Trong 1 Năm Qua");
    }

    private string ThongKeDanCham(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Chạm </td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private void bgBo_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='danbo'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlBo = this.ThongKeDanBo(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Dàn Các Bộ Trong 1 Năm Qua");
    }

    private string ThongKeDanBo(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Bộ </td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private void bgChanLe_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='danchanle'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlChanLe = this.ThongKeDanChanLe(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Các Dàn Chẵn Lẻ Trong 1 Năm Qua");
    }

    private string ThongKeDanChanLe(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Chẵn Lẻ </td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private void bgNhoTo_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='dannhoto'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlNhoTo = this.ThongKeDanNhoTo(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Các Dàn Nhỏ To, To Nhỏ, Nhỏ Nhỏ, To To Trong 1 Năm Qua");
    }

    private string ThongKeDanNhoTo(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Nhỏ To </td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private void bgBongDuong_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='danbong'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlBongDuong = this.ThongKeDanBongDuong(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Các Dàn Bóng Dương 0-5,1-6,2-7,3-8,4-9, Trong 1 Năm Qua");
    }

    private string ThongKeDanBongDuong(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Bóng </td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private void bgHieu_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='danhieu'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlHieu = this.ThongKeDanHieu(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Các Dàn Có Hiệu Là 0-1-2-3-4-5 Trong 1 Năm Vừa Qua");
    }

    private string ThongKeDanHieu(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Hiệu </td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
    }

    private void bgChiaBa_DoWork(object sender, DoWorkEventArgs e)
    {
      DataRow[] dataRowArray = this.dtDan.Select("loai='danchiaba'");
      if ((uint) dataRowArray.Length <= 0U)
        return;
      this._htmlChiaBa = this.ThongKeDanChiaBa(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>(), "Các Dàn Chia 3 Dư 0-1-2 Trong 1 Năm Qua");
    }

    private string ThongKeDanChiaBa(DataTable _dtDan, string title)
    {
      string str1 = "<div style='width:99%;float:right;align:center;margin-right:1%;'><table width='100%'>" + "<tr><td class='maunen' align='center' style='width:85px;'>Dàn Chia Ba </td><td class='maunen' align='center' style='width:55%;'>" + title + "</td><td class='maunen' align='center' >Dàn</td><td class='maunen' align='center' >Số Lần Về</td><td class='maunen' align='center' >Chu Kỳ</td><td class='maunen' align='center' >Max Gan</td><td class='maunen' align='center' style='width:105px;'>Ngày Chưa Ra</td></tr>";
      string str2 = "";
      for (int index1 = 0; index1 < _dtDan.Rows.Count; ++index1)
      {
        string[] strArray = _dtDan.Rows[index1]["danSo"].ToString().Split(',');
        string str3 = strArray.Length.ToString();
        if (str3.Length < 2)
          str3 = "0" + str3;
        if (strArray.Length > 25)
        {
          _dtDan.Rows[index1]["danSo"] = (object) "";
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (index2 != 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + strArray[index2]);
            }
            else if (index2 == 25)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + "<br>" + strArray[index2]);
            }
            if (index2 < strArray.Length - 1)
            {
              DataRow row = _dtDan.Rows[index1];
              row["danSo"] = (object) (row["danSo"].ToString() + ",");
            }
          }
        }
        str2 = str2 + "<tr>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["loaiDan"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["danSo"] + "</td>" + "<td class='borderVien' align='center'>" + str3 + " số</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["soLanVe"] + "</td>" + "<td class='borderVien' align='center' >" + _dtDan.Rows[index1]["chuKyTrungBinh"] + "</td>" + "<td class='borderVien' align='center'>" + _dtDan.Rows[index1]["maxGan"] + "</td>" + this.TinhNgayChuaRa(Convert.ToInt32(_dtDan.Rows[index1]["ngayChuaRa"].ToString()), Convert.ToInt32(_dtDan.Rows[index1]["maxGan"].ToString())) + "</tr>";
      }
      return str1 + str2 + "</table></br></div>";
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabTongQuanVeDe));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1 = new Panel();
      this.cbDanChiaBa = new CheckBox();
      this.cbDanHieu = new CheckBox();
      this.cbDanBongDuong = new CheckBox();
      this.cbDanNhoTo = new CheckBox();
      this.cbDanChanLe = new CheckBox();
      this.cbDanbo = new CheckBox();
      this.cbCham = new CheckBox();
      this.cbTong = new CheckBox();
      this.cbDuoi = new CheckBox();
      this.cbDau = new CheckBox();
      this.label1 = new Label();
      this.btnXem = new Button();
      this.label6 = new Label();
      this.dtNgayKiemTra = new DateTimePicker();
      this.toolTip1 = new ToolTip(this.components);
      this.bgDau = new BackgroundWorker();
      this.bgDuoi = new BackgroundWorker();
      this.bgGetKetQua = new BackgroundWorker();
      this.wbHienthi = new WebBrowser();
      this.timerLoading = new Timer(this.components);
      this.picLoading = new PictureBox();
      this.bgTong = new BackgroundWorker();
      this.bgCham = new BackgroundWorker();
      this.bgBo = new BackgroundWorker();
      this.bgChanLe = new BackgroundWorker();
      this.bgNhoTo = new BackgroundWorker();
      this.bgBongDuong = new BackgroundWorker();
      this.bgHieu = new BackgroundWorker();
      this.bgChiaBa = new BackgroundWorker();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.cbDanChiaBa);
      this.panel1.Controls.Add((Control) this.cbDanHieu);
      this.panel1.Controls.Add((Control) this.cbDanBongDuong);
      this.panel1.Controls.Add((Control) this.cbDanNhoTo);
      this.panel1.Controls.Add((Control) this.cbDanChanLe);
      this.panel1.Controls.Add((Control) this.cbDanbo);
      this.panel1.Controls.Add((Control) this.cbCham);
      this.panel1.Controls.Add((Control) this.cbTong);
      this.panel1.Controls.Add((Control) this.cbDuoi);
      this.panel1.Controls.Add((Control) this.cbDau);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btnXem);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.dtNgayKiemTra);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 35);
      this.panel1.TabIndex = 0;
      this.cbDanChiaBa.AutoSize = true;
      this.cbDanChiaBa.BackColor = Color.Transparent;
      this.cbDanChiaBa.Cursor = Cursors.Hand;
      this.cbDanChiaBa.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDanChiaBa.ForeColor = Color.Black;
      this.cbDanChiaBa.Location = new Point(871, 10);
      this.cbDanChiaBa.Margin = new Padding(0);
      this.cbDanChiaBa.Name = "cbDanChiaBa";
      this.cbDanChiaBa.Size = new Size(81, 19);
      this.cbDanChiaBa.TabIndex = 10;
      this.cbDanChiaBa.Text = "D.Chia ba";
      this.cbDanChiaBa.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDanChiaBa, "Thống kê thông tin của tất cả các dàn chia 3 dư 0, dư 1, dư 2");
      this.cbDanChiaBa.UseVisualStyleBackColor = false;
      this.cbDanChiaBa.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbDanHieu.AutoSize = true;
      this.cbDanHieu.BackColor = Color.Transparent;
      this.cbDanHieu.Cursor = Cursors.Hand;
      this.cbDanHieu.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDanHieu.ForeColor = Color.Black;
      this.cbDanHieu.Location = new Point(801, 10);
      this.cbDanHieu.Margin = new Padding(0);
      this.cbDanHieu.Name = "cbDanHieu";
      this.cbDanHieu.Size = new Size(64, 19);
      this.cbDanHieu.TabIndex = 9;
      this.cbDanHieu.Text = "D.Hiệu";
      this.cbDanHieu.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDanHieu, "Thống kê thông tin của tất cả các dàn có hiệu 0,1,2,3,4,5");
      this.cbDanHieu.UseVisualStyleBackColor = false;
      this.cbDanHieu.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbDanBongDuong.AutoSize = true;
      this.cbDanBongDuong.BackColor = Color.Transparent;
      this.cbDanBongDuong.Cursor = Cursors.Hand;
      this.cbDanBongDuong.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDanBongDuong.ForeColor = Color.Black;
      this.cbDanBongDuong.Location = new Point(688, 10);
      this.cbDanBongDuong.Margin = new Padding(0);
      this.cbDanBongDuong.Name = "cbDanBongDuong";
      this.cbDanBongDuong.Size = new Size(107, 19);
      this.cbDanBongDuong.TabIndex = 8;
      this.cbDanBongDuong.Text = "D.Bóng dương";
      this.cbDanBongDuong.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDanBongDuong, "Thống kê thông tin của tất cả các dàn bóng dương 0-5,1-6,2-7,3-8,4-9");
      this.cbDanBongDuong.UseVisualStyleBackColor = false;
      this.cbDanBongDuong.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbDanNhoTo.AutoSize = true;
      this.cbDanNhoTo.BackColor = Color.Transparent;
      this.cbDanNhoTo.Cursor = Cursors.Hand;
      this.cbDanNhoTo.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDanNhoTo.ForeColor = Color.Black;
      this.cbDanNhoTo.Location = new Point(608, 10);
      this.cbDanNhoTo.Margin = new Padding(0);
      this.cbDanNhoTo.Name = "cbDanNhoTo";
      this.cbDanNhoTo.Size = new Size(74, 19);
      this.cbDanNhoTo.TabIndex = 7;
      this.cbDanNhoTo.Text = "D.Nhỏ to";
      this.cbDanNhoTo.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDanNhoTo, "Thống kê thông tin của tất cả các dàn nhỏ to, to nhỏ, nhỏ nhỏ, to to");
      this.cbDanNhoTo.UseVisualStyleBackColor = false;
      this.cbDanNhoTo.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbDanChanLe.AutoSize = true;
      this.cbDanChanLe.BackColor = Color.Transparent;
      this.cbDanChanLe.Cursor = Cursors.Hand;
      this.cbDanChanLe.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDanChanLe.ForeColor = Color.Black;
      this.cbDanChanLe.Location = new Point(521, 10);
      this.cbDanChanLe.Margin = new Padding(0);
      this.cbDanChanLe.Name = "cbDanChanLe";
      this.cbDanChanLe.Size = new Size(81, 19);
      this.cbDanChanLe.TabIndex = 6;
      this.cbDanChanLe.Text = "D.Chẵn lẻ";
      this.cbDanChanLe.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDanChanLe, "Thống kê thông tin của tất cả các dàn chẵn lẻ, chẵn chẵn, lẻ lẻ, chẵn lẻ, lẻ chẵn");
      this.cbDanChanLe.UseVisualStyleBackColor = false;
      this.cbDanChanLe.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbDanbo.AutoSize = true;
      this.cbDanbo.BackColor = Color.Transparent;
      this.cbDanbo.Cursor = Cursors.Hand;
      this.cbDanbo.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDanbo.ForeColor = Color.Black;
      this.cbDanbo.Location = new Point(462, 10);
      this.cbDanbo.Margin = new Padding(0);
      this.cbDanbo.Name = "cbDanbo";
      this.cbDanbo.Size = new Size(53, 19);
      this.cbDanbo.TabIndex = 5;
      this.cbDanbo.Text = "D.Bộ";
      this.cbDanbo.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDanbo, "Thống kê thông tin của tất cả các chạm 2 số cuối giải đặc biệt");
      this.cbDanbo.UseVisualStyleBackColor = false;
      this.cbDanbo.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbCham.AutoSize = true;
      this.cbCham.BackColor = Color.Transparent;
      this.cbCham.Cursor = Cursors.Hand;
      this.cbCham.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbCham.ForeColor = Color.Black;
      this.cbCham.Location = new Point(384, 10);
      this.cbCham.Margin = new Padding(0);
      this.cbCham.Name = "cbCham";
      this.cbCham.Size = new Size(72, 19);
      this.cbCham.TabIndex = 4;
      this.cbCham.Text = "D.Chạm";
      this.cbCham.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbCham, "Thống kê thông tin của tất cả các chạm 2 số cuối giải đặc biệt chạm 0,1,2,3,4,5,6,7,8,9");
      this.cbCham.UseVisualStyleBackColor = false;
      this.cbCham.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbTong.AutoSize = true;
      this.cbTong.BackColor = Color.Transparent;
      this.cbTong.Checked = true;
      this.cbTong.CheckState = CheckState.Checked;
      this.cbTong.Cursor = Cursors.Hand;
      this.cbTong.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbTong.ForeColor = Color.Red;
      this.cbTong.Location = new Point(313, 10);
      this.cbTong.Margin = new Padding(0);
      this.cbTong.Name = "cbTong";
      this.cbTong.Size = new Size(65, 19);
      this.cbTong.TabIndex = 3;
      this.cbTong.Text = "D.Tổng";
      this.cbTong.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbTong, "Thống kê thông tin của tất cả các tổng 2 số cuối giải đặc biệt");
      this.cbTong.UseVisualStyleBackColor = false;
      this.cbTong.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbDuoi.AutoSize = true;
      this.cbDuoi.BackColor = Color.White;
      this.cbDuoi.Checked = true;
      this.cbDuoi.CheckState = CheckState.Checked;
      this.cbDuoi.Cursor = Cursors.Hand;
      this.cbDuoi.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbDuoi.ForeColor = Color.Red;
      this.cbDuoi.Location = new Point(244, 10);
      this.cbDuoi.Margin = new Padding(0);
      this.cbDuoi.Name = "cbDuoi";
      this.cbDuoi.Size = new Size(63, 19);
      this.cbDuoi.TabIndex = 2;
      this.cbDuoi.Text = "D.Đuôi";
      this.cbDuoi.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDuoi, "Thống kê thông tin của tất cả các dàn đuôi giải đặc biệt dàn đuôi 0,1,2,3,4,5,6,7,8,9");
      this.cbDuoi.UseVisualStyleBackColor = false;
      this.cbDuoi.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.cbDau.AutoSize = true;
      this.cbDau.BackColor = Color.Transparent;
      this.cbDau.Checked = true;
      this.cbDau.CheckState = CheckState.Checked;
      this.cbDau.Cursor = Cursors.Hand;
      this.cbDau.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbDau.ForeColor = Color.Red;
      this.cbDau.Location = new Point(178, 10);
      this.cbDau.Margin = new Padding(0);
      this.cbDau.Name = "cbDau";
      this.cbDau.Size = new Size(60, 19);
      this.cbDau.TabIndex = 1;
      this.cbDau.Text = "D.Đầu";
      this.cbDau.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDau, "Thống kê thông tin của tất cả các đầu giải đặc biệt dàn đầu 0,1,2,3,4,5,6,7,8,9");
      this.cbDau.UseVisualStyleBackColor = false;
      this.cbDau.CheckedChanged += new EventHandler(this.cbDuoi_CheckedChanged);
      this.label1.BackColor = Color.DimGray;
      this.label1.Dock = DockStyle.Bottom;
      this.label1.Location = new Point(0, 34);
      this.label1.Name = "label1";
      this.label1.Size = new Size(1100, 1);
      this.label1.TabIndex = 27;
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(966, 6);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(85, 23);
      this.btnXem.TabIndex = 11;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.btnXem_Click);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(5, 10);
      this.label6.Name = "label6";
      this.label6.Size = new Size(61, 15);
      this.label6.TabIndex = 20;
      this.label6.Text = "Xem ngày";
      this.dtNgayKiemTra.CalendarFont = new Font("Arial", 9f, FontStyle.Bold);
      this.dtNgayKiemTra.CalendarForeColor = Color.Red;
      this.dtNgayKiemTra.Cursor = Cursors.Hand;
      this.dtNgayKiemTra.CustomFormat = "dd/MM/yyyy";
      this.dtNgayKiemTra.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayKiemTra.Format = DateTimePickerFormat.Custom;
      this.dtNgayKiemTra.Location = new Point(67, 8);
      this.dtNgayKiemTra.Margin = new Padding(3, 5, 3, 5);
      this.dtNgayKiemTra.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
      this.dtNgayKiemTra.Name = "dtNgayKiemTra";
      this.dtNgayKiemTra.Size = new Size(100, 21);
      this.dtNgayKiemTra.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.dtNgayKiemTra, "Ngày thống kê dàn");
      this.dtNgayKiemTra.ValueChanged += new EventHandler(this.dtNgayKiemTra_ValueChanged);
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.bgDau.DoWork += new DoWorkEventHandler(this.bgDau_DoWork);
      this.bgDau.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgDuoi.DoWork += new DoWorkEventHandler(this.bgDuoi_DoWork);
      this.bgDuoi.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDuoi_RunWorkerCompleted);
      this.bgGetKetQua.DoWork += new DoWorkEventHandler(this.bgGetKetQua_DoWork);
      this.bgGetKetQua.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetKetQua_RunWorkerCompleted);
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(0, 36);
      this.wbHienthi.MinimumSize = new Size(20, 20);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1115, 561);
      this.wbHienthi.TabIndex = 23;
      this.timerLoading.Enabled = true;
      this.timerLoading.Tick += new EventHandler(this.timerLoading_Tick);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(492, 287);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 63;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.bgTong.DoWork += new DoWorkEventHandler(this.bgTong_DoWork);
      this.bgTong.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgCham.DoWork += new DoWorkEventHandler(this.bgCham_DoWork);
      this.bgCham.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgBo.DoWork += new DoWorkEventHandler(this.bgBo_DoWork);
      this.bgBo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgChanLe.DoWork += new DoWorkEventHandler(this.bgChanLe_DoWork);
      this.bgChanLe.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgNhoTo.DoWork += new DoWorkEventHandler(this.bgNhoTo_DoWork);
      this.bgNhoTo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgBongDuong.DoWork += new DoWorkEventHandler(this.bgBongDuong_DoWork);
      this.bgBongDuong.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgHieu.DoWork += new DoWorkEventHandler(this.bgHieu_DoWork);
      this.bgHieu.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.bgChiaBa.DoWork += new DoWorkEventHandler(this.bgChiaBa_DoWork);
      this.bgChiaBa.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgDau_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.wbHienthi);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabTongQuanVeDe);
      this.Size = new Size(1100, 600);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
