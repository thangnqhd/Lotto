// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabNhandinhloto
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabNhandinhloto : UserControl
  {
    private DateTime _ngayKiemTraCu = DateTime.Now.AddDays(12.0);
    private int tuan = 7;
    private int ngay15 = 15;
    private int ngay30 = 30;
    private int ngay55 = 55;
    private int ngay85 = 85;
    private int solanGanTren7ngay = 7;
    private int solanGanTren10ngay = 10;
    private int solanGanTren13ngay = 13;
    private int solanGanTren16ngay = 16;
    private int solanGanTren20ngay = 20;
    private int gan1Thang = 30;
    private int gan2Thang = 60;
    private int gan3Thang = 90;
    private int gan6Thang = 180;
    private int gan9Thang = 270;
    private int gan12Thang = 363;
    private int gan18Thang = 540;
    private IContainer components = (IContainer) null;
    private Tbloto objLoto;
    private DataTable _dtLoToTong;
    private DataTable _dtTemp;
    private ArrayList _arrLoto;
    private const int _biendongay = 360;
    private string _strHtmlTong;
    private Panel panel1;
    private DateTimePicker dtNgayXem;
    private Label label2;
    private Button btnXem;
    private Label label1;
    private BunifuMaterialTextbox txtLoto;
    private Label label5;
    private BackgroundWorker bgGetData;
    private Timer timer1;
    private WebBrowser wbHienthi;
    private PictureBox picLoading;

    public TabNhandinhloto()
    {
      this.InitializeComponent();
      this.objLoto = new Tbloto();
      this.timer1.Start();
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.txtLoto.Focus();
    }

    private static void HienThiKetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.StrCss1 + "<title>THỐNG KÊ XỔ SỐ</title></head><body  oncontextmenu='return false;'style='font-family:Verdana;'><div class='container' style='margin-right:15px;margin-top:-35px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ></div><div class='panel-body'><ul class='media-list'><li class='media'>" + strHtml + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void dtNgayXem_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayXem.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      this._arrLoto = new ArrayList();
      if (this.txtLoto.Text.Length >= 2)
        this.txtLoto.Text = this.Get_Str_Loto(this.txtLoto.Text);
      else
        this.txtLoto.Focus();
      if (this._arrLoto.Count < 1)
      {
        int num = (int) MessageBox.Show("Bạn cần nhập vào một bộ số hoặc một cặp số để kiểm tra !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.txtLoto.Focus();
      }
      else
      {
        this._strHtmlTong = "<div align='center'>☜♥☞ º°”˜`”°º☜ <b style='color:rgb(43, 60, 80);'>KẾT QUẢ NHẬN ĐỊNH BỘ SỐ [ <b style='color:red;'>" + (this._arrLoto.Count != 1 ? this._arrLoto[0].ToString() + "-" + this._arrLoto[1] : this._arrLoto[0].ToString()) + "</b> ] NGÀY " + this.dtNgayXem.Value.ToString("dd-MM-yyyy") + "</b> ☞ º°”˜`”°☜♥☞</div>";
        if (!this.bgGetData.IsBusy)
          this.bgGetData.RunWorkerAsync();
      }
    }

    private void GetData()
    {
      if (this._ngayKiemTraCu != this.dtNgayXem.Value)
      {
        this._ngayKiemTraCu = this.dtNgayXem.Value;
        this._dtLoToTong = new DataTable();
        this._dtLoToTong = this.objLoto.TblotoGetByDateSoBanGhiTrovetruoc(this._ngayKiemTraCu, 360);
      }
      if (this._arrLoto.Count <= 0)
        return;
      this._dtTemp = new DataTable();
      this._dtTemp.Columns.Add("boSo", typeof (string));
      this._dtTemp.Columns.Add("dauLo", typeof (string));
      this._dtTemp.Columns.Add("duoiLo", typeof (string));
      this._dtTemp.Columns.Add("ngayChuaRa", typeof (string));
      this._dtTemp.Columns.Add("soLanVeTuan", typeof (int));
      this._dtTemp.Columns.Add("soLanVe15Ngay", typeof (int));
      this._dtTemp.Columns.Add("soLanVe30Ngay", typeof (int));
      this._dtTemp.Columns.Add("soLanVe55Ngay", typeof (int));
      this._dtTemp.Columns.Add("soLanVe85Ngay", typeof (int));
      this._dtTemp.Columns.Add("soNhayVeTuan", typeof (int));
      this._dtTemp.Columns.Add("soNhayVe15Ngay", typeof (int));
      this._dtTemp.Columns.Add("soNhayVe30Ngay", typeof (int));
      this._dtTemp.Columns.Add("soNhayVe55Ngay", typeof (int));
      this._dtTemp.Columns.Add("soNhayVe85Ngay", typeof (int));
      this._dtTemp.Columns.Add("max1Thang", typeof (int));
      this._dtTemp.Columns.Add("max2Thang", typeof (int));
      this._dtTemp.Columns.Add("max3Thang", typeof (int));
      this._dtTemp.Columns.Add("max6Thang", typeof (int));
      this._dtTemp.Columns.Add("max9Thang", typeof (int));
      this._dtTemp.Columns.Add("max12Thang", typeof (int));
      this._dtTemp.Columns.Add("max18Thang", typeof (int));
      this._dtTemp.Columns.Add("soLanTren7Ngay", typeof (int));
      this._dtTemp.Columns.Add("soLanTren10Ngay", typeof (int));
      this._dtTemp.Columns.Add("soLanTren13Ngay", typeof (int));
      this._dtTemp.Columns.Add("soLanTren16Ngay", typeof (int));
      this._dtTemp.Columns.Add("soLanTren20Ngay", typeof (int));
      this._dtTemp.Columns.Add("tongSoLanVe", typeof (int));
      this._dtTemp.Columns.Add("tongSoNhayVe", typeof (int));
      this._dtTemp.Columns.Add("diemTanXuat", typeof (int));
      this._dtTemp.Columns.Add("diemGan", typeof (int));
      for (int index1 = 0; index1 < this._arrLoto.Count; ++index1)
      {
        Decimal num1 = new Decimal();
        Decimal num2 = new Decimal();
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = -1;
        int num7 = -1;
        int num8 = -1;
        int num9 = -1;
        int num10 = -1;
        int num11 = -1;
        int num12 = -1;
        int num13 = -1;
        int num14 = -1;
        int num15 = -1;
        int num16 = -1;
        int num17 = -1;
        int num18 = -1;
        int num19 = -1;
        int num20 = -1;
        int num21 = -1;
        int num22 = -1;
        int num23 = -1;
        int num24 = 0;
        int num25 = 0;
        int num26 = 0;
        int num27 = 0;
        int num28 = 0;
        string str1 = this._arrLoto[index1].ToString();
        string str2 = str1.Substring(0, 1);
        string str3 = str1.Substring(1, 1);
        for (int index2 = 0; index2 < this._dtLoToTong.Rows.Count; ++index2)
        {
          bool flag = false;
          for (int index3 = 2; index3 < this._dtLoToTong.Columns.Count; ++index3)
          {
            string str4 = this._dtLoToTong.Rows[index2][index3].ToString();
            if (str1 == str4)
            {
              flag = true;
              ++num5;
            }
          }
          if (flag)
          {
            ++num4;
            if (index2 <= this.gan1Thang && num3 > num17)
              num17 = num3;
            if (index2 <= this.gan2Thang && num3 > num18)
              num18 = num3;
            if (index2 <= this.gan3Thang && num3 > num19)
              num19 = num3;
            if (index2 <= this.gan6Thang && num3 > num20)
              num20 = num3;
            if (index2 <= this.gan9Thang && num3 > num21)
              num21 = num3;
            if (index2 <= this.gan12Thang && num3 > num22)
              num22 = num3;
            if (index2 <= this.gan18Thang && num3 > num23)
              num23 = num3;
            if (num3 >= this.solanGanTren7ngay && num3 < this.solanGanTren10ngay)
              ++num24;
            if (num3 >= this.solanGanTren10ngay && num3 < this.solanGanTren13ngay)
              ++num25;
            if (num3 >= this.solanGanTren13ngay && num3 < this.solanGanTren16ngay)
              ++num26;
            if (num3 >= this.solanGanTren16ngay && num3 < this.solanGanTren20ngay)
              ++num27;
            if (num3 >= this.solanGanTren20ngay)
              ++num28;
            if (num6 == -1)
              num6 = num3;
            num3 = 0;
          }
          else
            ++num3;
          if (index2 == this.tuan - 1)
          {
            num7 = num4;
            num12 = num5;
          }
          if (index2 == this.ngay15 - 1)
          {
            num8 = num4;
            num13 = num5;
          }
          if (index2 == this.ngay30 - 1)
          {
            num9 = num4;
            num14 = num5;
          }
          if (index2 == this.ngay55 - 1)
          {
            num10 = num4;
            num15 = num5;
          }
          if (index2 == this.ngay85 - 1)
          {
            num11 = num4;
            num16 = num5;
          }
        }
        DataRow row = this._dtTemp.NewRow();
        row["boSo"] = (object) str1;
        row["dauLo"] = (object) str2;
        row["duoiLo"] = (object) str3;
        row["ngayChuaRa"] = (object) num6;
        row["soLanVeTuan"] = (object) num7;
        row["soLanVe15Ngay"] = (object) num8;
        row["soLanVe30Ngay"] = (object) num9;
        row["soLanVe55Ngay"] = (object) num10;
        row["soLanVe85Ngay"] = (object) num11;
        row["soNhayVeTuan"] = (object) num12;
        row["soNhayVe15Ngay"] = (object) num13;
        row["soNhayVe30Ngay"] = (object) num14;
        row["soNhayVe55Ngay"] = (object) num15;
        row["soNhayVe85Ngay"] = (object) num16;
        row["max1Thang"] = (object) num17;
        row["max2Thang"] = (object) num18;
        row["max3Thang"] = (object) num19;
        row["max6Thang"] = (object) num20;
        row["max9Thang"] = (object) num21;
        row["max12Thang"] = (object) num22;
        row["max18Thang"] = (object) num23;
        row["soLanTren7Ngay"] = (object) num24;
        row["soLanTren10Ngay"] = (object) num25;
        row["soLanTren13Ngay"] = (object) num26;
        row["soLanTren16Ngay"] = (object) num27;
        row["soLanTren20Ngay"] = (object) num28;
        row["tongSoLanVe"] = (object) num4;
        row["tongSoNhayVe"] = (object) num5;
        row["diemGan"] = (object) num1;
        row["diemTanXuat"] = (object) num2;
        this._dtTemp.Rows.Add(row);
      }
      this._strHtmlTong += this.XuLyThongTin(this._dtTemp);
    }

    private string XuLyThongTin(DataTable dtThongTinLoTo)
    {
      string str1 = "";
      string str2 = "";
      string str3 = "";
      if (dtThongTinLoTo.Rows.Count > 1)
        str1 = "<br><div><b style='color:red;'>Gợi ý</b> : để một cặp lô ra được và đạt tỷ lệ chiến thắng cao thì ít nhất một trong hai con lô bạn xét phải có khả năng ra cao trong mấy ngày xắp tới .<br></div>";
      for (int index = 0; index < dtThongTinLoTo.Rows.Count; ++index)
      {
        int int32_1 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["max1Thang"].ToString());
        int int32_2 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["ngayChuaRa"].ToString());
        int int32_3 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["soLanVe30Ngay"].ToString());
        int int32_4 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["soNhayVe30Ngay"].ToString());
        int int32_5 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["tongSoLanVe"].ToString());
        int int32_6 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["soLanTren7Ngay"].ToString());
        int int32_7 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["soLanTren10Ngay"].ToString());
        int int32_8 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["soLanTren13Ngay"].ToString());
        int int32_9 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["soLanTren16Ngay"].ToString());
        int int32_10 = Convert.ToInt32(dtThongTinLoTo.Rows[index]["soLanTren20Ngay"].ToString());
        if (int32_9 > 0)
          str2 = "Từ <b style='color:blue;'>17-20</b> ngày <b style='color:black;'>" + (object) int32_9 + "</b> lần <b style='color:black;'>" + (object) this.tinhTyle(int32_5, int32_9) + "%</b>. ";
        if (int32_10 > 0)
          str3 = "Trên <b style='color:blue;'>20</b> ngày <b style='color:black;'>" + (object) int32_10 + "</b> lần <b style='color:black;'>" + (object) this.tinhTyle(int32_5, int32_10) + "%</b>.";
        int solan = int32_5 - int32_6 - int32_7 - int32_8 - int32_9 - int32_10;
        Decimal num1 = this.tinhTyle(int32_5, solan) + this.tinhTyle(int32_5, int32_6);
        Decimal num2 = num1 + this.tinhTyle(int32_5, int32_7);
        Decimal num3 = num2 + this.tinhTyle(int32_5, int32_8);
        Decimal num4 = Math.Round(Convert.ToDecimal(this.gan1Thang) / (Decimal) int32_3, 1);
        string str4 = dtThongTinLoTo.Rows[index]["boSo"].ToString();
        str1 = str1 + "<div>☞ Trong <b>" + (object) this.gan1Thang + "</b> ngày vừa qua lô (<b style='color:blue;'>" + str4 + "</b>) về tất cả <b style='color:blue;'>" + (object) int32_3 + "</b> lần, <b style='color:blue;'>" + (object) int32_4 + "</b> nháy, trung bình cứ <b style='color:blue;'>" + (object) num4 + "</b> ngày về 1 lần. Gan trong khung này là <b style='color:blue;'>" + (object) int32_1 + "</b> ngày. Hiện tại là (<b style='color:red;'>" + (object) int32_2 + "</b>) ngày chưa ra.<br>" + "<span style='font-size:12px;'> - Trong <b style='color:black;'>" + int32_5.ToString() + "</b> lần về gần nhất, các ngày lô về có tỷ lệ như sau : dưới <b style='color:red;'>7</b> ngày <b style='color:black;'>" + (object) solan + "</b> lần <b style='color:red;'>" + (object) this.tinhTyle(int32_5, solan) + "%</b>. Từ <b style='color:blue;'>7-10</b> ngày <b style='color:black;'>" + (object) int32_6 + "</b> lần <b style='color:black;'>" + (object) this.tinhTyle(int32_5, int32_6) + "%</b>. Từ <b style='color:blue;'>11-13</b> ngày <b style='color:black;'>" + (object) int32_7 + "</b> lần <b style='color:black;'>" + (object) this.tinhTyle(int32_5, int32_7) + "%</b>. Từ <b style='color:blue;'>14-16</b> ngày <b style='color:black;'>" + (object) int32_8 + "</b> lần <b style='color:black;'>" + (object) this.tinhTyle(int32_5, int32_8) + "%</b>. " + str2 + str3 + "</br>Từ các thông số trên cho thấy lô (<b style='color:red;'>" + str4 + "</b>) - <b style='color:red;'>" + (object) num1 + "%</b> sẽ về trong 10 ngày. <b style='color:red;'>" + (object) num2 + "%</b> sẽ về trong 13 ngày, <b style='color:red;'>" + (object) num3 + "%</b> sẽ về trong 16 ngày. Tính từ ngày ra gần nhất </br></br>" + "</span></div>";
      }
      return str1;
    }

    private Decimal tinhTyle(int tong, int solan)
    {
      return solan >= 1 && tong >= 1 ? Math.Round(Convert.ToDecimal(solan) / Convert.ToDecimal(tong) * new Decimal(100), 1) : new Decimal();
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
              if (this._arrLoto.Count <= 1)
              {
                str += empty.Substring(startIndex, length);
                this._arrLoto.Add((object) empty.Substring(startIndex, length));
                if (empty.Substring(startIndex + length, length).Length % length == 0 && this._arrLoto.Count <= 1)
                  str += ",";
              }
              else
                break;
            }
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

    private void txtLoto_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnXem.PerformClick();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.bgGetData.IsBusy)
        this.picLoading.Visible = true;
      else
        this.picLoading.Visible = false;
    }

    private void bgGetData_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetData();
    }

    private void bgGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      TabNhandinhloto.HienThiKetQua(this.wbHienthi, this._strHtmlTong);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabNhandinhloto));
      this.panel1 = new Panel();
      this.label5 = new Label();
      this.txtLoto = new BunifuMaterialTextbox();
      this.label1 = new Label();
      this.dtNgayXem = new DateTimePicker();
      this.label2 = new Label();
      this.btnXem = new Button();
      this.bgGetData = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.wbHienthi = new WebBrowser();
      this.picLoading = new PictureBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.txtLoto);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.dtNgayXem);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.btnXem);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 37);
      this.panel1.TabIndex = 2;
      this.label5.BackColor = Color.DimGray;
      this.label5.Dock = DockStyle.Bottom;
      this.label5.Location = new Point(0, 36);
      this.label5.Name = "label5";
      this.label5.Size = new Size(1100, 1);
      this.label5.TabIndex = 50;
      this.label5.Text = "label5";
      this.txtLoto.BorderStyle = BorderStyle.FixedSingle;
      this.txtLoto.Cursor = Cursors.IBeam;
      this.txtLoto.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.txtLoto.ForeColor = Color.Red;
      this.txtLoto.HintForeColor = SystemColors.Highlight;
      this.txtLoto.HintText = "Nhập vào lô bạch thủ hoặc lô cặp muốn xem";
      this.txtLoto.isPassword = false;
      this.txtLoto.LineFocusedColor = Color.White;
      this.txtLoto.LineIdleColor = Color.White;
      this.txtLoto.LineMouseHoverColor = Color.White;
      this.txtLoto.LineThickness = 3;
      this.txtLoto.Location = new Point(347, 6);
      this.txtLoto.Margin = new Padding(0);
      this.txtLoto.Name = "txtLoto";
      this.txtLoto.Size = new Size(371, 25);
      this.txtLoto.TabIndex = 2;
      this.txtLoto.TextAlign = HorizontalAlignment.Center;
      this.txtLoto.KeyDown += new KeyEventHandler(this.txtLoto_KeyDown);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(261, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(85, 15);
      this.label1.TabIndex = 48;
      this.label1.Text = "bộ số kiểm tra";
      this.dtNgayXem.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.CalendarForeColor = Color.Red;
      this.dtNgayXem.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayXem.CustomFormat = "dd/MM/yyyy";
      this.dtNgayXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.Format = DateTimePickerFormat.Custom;
      this.dtNgayXem.Location = new Point(98, 9);
      this.dtNgayXem.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayXem.Name = "dtNgayXem";
      this.dtNgayXem.Size = new Size(91, 21);
      this.dtNgayXem.TabIndex = 0;
      this.dtNgayXem.ValueChanged += new EventHandler(this.dtNgayXem_ValueChanged);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(7, 10);
      this.label2.Name = "label2";
      this.label2.Size = new Size(89, 16);
      this.label2.TabIndex = 39;
      this.label2.Text = "Ngày kiểm tra";
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(812, 6);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(131, 24);
      this.btnXem.TabIndex = 3;
      this.btnXem.Text = "Xem dự đoán";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.btnThongke_Click);
      this.bgGetData.DoWork += new DoWorkEventHandler(this.bgGetData_DoWork);
      this.bgGetData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetData_RunWorkerCompleted);
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(0, 37);
      this.wbHienthi.MinimumSize = new Size(20, 20);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1116, 486);
      this.wbHienthi.TabIndex = 63;
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(530, 245);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 64;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.wbHienthi);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (TabNhandinhloto);
      this.Size = new Size(1100, 523);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
