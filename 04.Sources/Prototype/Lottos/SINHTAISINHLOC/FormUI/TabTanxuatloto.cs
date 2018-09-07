// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabTanxuatloto
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
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabTanxuatloto : UserControl
  {
    private string strInfoNhomLoto = "";
    private IContainer components = (IContainer) null;
    private readonly ArrayList listItem;
    private readonly Tbloto objloto;
    private bool cbState0;
    private bool cbState1;
    private bool cbState2;
    private bool cbState3;
    private bool cbState4;
    private bool cbState5;
    private bool cbState6;
    private bool cbState7;
    private bool cbState8;
    private bool cbState9;
    private readonly ArrayList arrItemsChoice;
    private bool checkTron;
    private string strHtml;
    private DataTable dataTable;
    private DateTime ngayThangCu;
    private int soBanGhiCu;
    private List<TabTanxuatloto.InfoLoto> listInfoLoto;
    private int widthHtml;
    private BunifuElipse bunifuElipse1;
    private Panel panel2;
    private Label label13;
    private Button btnThongke;
    private DateTimePicker dtNgayXem;
    private Label label3;
    private Label label1;
    private TextBox txtBiendongay;
    private Label label4;
    private TextBox txtGialapngaychuara;
    private Label label2;
    private Label label5;
    private BunifuImageButton bunifuImageButton1;
    private ToolTip toolTip1;
    private CheckBox cb09;
    private CheckBox cb08;
    private CheckBox cb07;
    private CheckBox cb06;
    private CheckBox cb05;
    private CheckBox cb04;
    private CheckBox cb03;
    private CheckBox cb02;
    private CheckBox cb01;
    private CheckBox cb19;
    private CheckBox cb18;
    private CheckBox cb17;
    private CheckBox cb16;
    private CheckBox cb15;
    private CheckBox cb14;
    private CheckBox cb13;
    private CheckBox cb12;
    private CheckBox cb11;
    private BunifuImageButton bunifuImageButton2;
    private CheckBox cb29;
    private CheckBox cb28;
    private CheckBox cb27;
    private CheckBox cb26;
    private CheckBox cb25;
    private CheckBox cb24;
    private CheckBox cb23;
    private CheckBox cb22;
    private CheckBox cb21;
    private BunifuImageButton bunifuImageButton3;
    private CheckBox cb39;
    private CheckBox cb38;
    private CheckBox cb37;
    private CheckBox cb36;
    private CheckBox cb35;
    private CheckBox cb34;
    private CheckBox cb33;
    private CheckBox cb32;
    private CheckBox cb31;
    private BunifuImageButton bunifuImageButton4;
    private CheckBox cb49;
    private CheckBox cb48;
    private CheckBox cb47;
    private CheckBox cb46;
    private CheckBox cb45;
    private CheckBox cb44;
    private CheckBox cb43;
    private CheckBox cb42;
    private CheckBox cb41;
    private BunifuImageButton bunifuImageButton5;
    private CheckBox cb59;
    private CheckBox cb58;
    private CheckBox cb57;
    private CheckBox cb56;
    private CheckBox cb55;
    private CheckBox cb54;
    private CheckBox cb53;
    private CheckBox cb52;
    private CheckBox cb51;
    private BunifuImageButton bunifuImageButton6;
    private CheckBox cb69;
    private CheckBox cb68;
    private CheckBox cb67;
    private CheckBox cb66;
    private CheckBox cb65;
    private CheckBox cb64;
    private CheckBox cb63;
    private CheckBox cb62;
    private CheckBox cb61;
    private BunifuImageButton bunifuImageButton7;
    private CheckBox cb79;
    private CheckBox cb78;
    private CheckBox cb77;
    private CheckBox cb76;
    private CheckBox cb75;
    private CheckBox cb74;
    private CheckBox cb73;
    private CheckBox cb72;
    private CheckBox cb71;
    private BunifuImageButton bunifuImageButton8;
    private CheckBox cb99;
    private CheckBox cb98;
    private CheckBox cb97;
    private CheckBox cb96;
    private CheckBox cb95;
    private CheckBox cb94;
    private CheckBox cb93;
    private CheckBox cb92;
    private CheckBox cb91;
    private BunifuImageButton bunifuImageButton10;
    private CheckBox cb89;
    private CheckBox cb88;
    private CheckBox cb87;
    private CheckBox cb86;
    private CheckBox cb85;
    private CheckBox cb84;
    private CheckBox cb83;
    private CheckBox cb82;
    private CheckBox cb81;
    private BunifuImageButton bunifuImageButton9;
    private CheckBox cb80;
    private CheckBox cb60;
    private CheckBox cb40;
    private CheckBox cb20;
    private CheckBox cb00;
    private CheckBox cb90;
    private CheckBox cb70;
    private CheckBox cb50;
    private CheckBox cb30;
    private CheckBox cb10;
    private Button btnTronhet;
    private Label label6;
    private BackgroundWorker bgProcess;
    private Timer timerLoading;
    private WebBrowser wbHienthi;
    private PictureBox picLoading;
    private BackgroundWorker bgDudoanngayve;

    public TabTanxuatloto()
    {
      this.listItem = new ArrayList();
      this.arrItemsChoice = new ArrayList();
      this.objloto = new Tbloto();
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.ngayThangCu = DateTime.Now.AddYears(3);
      this.soBanGhiCu = 36;
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      this.wbHienthi.IsWebBrowserContextMenuEnabled = false;
      this.wbHienthi.AllowWebBrowserDrop = false;
      this.strHtml += "<table class='tbMain'>";
      this.strHtml += "<tr><th>NGÀY<br/>-<br/>THÁNG</th>";
      DateTime dateTime = FMain.NgayKetQuaMoiNhat;
      this.widthHtml += 37;
      for (int index = 0; index < 36; ++index)
      {
        this.widthHtml += 35;
        dateTime = dateTime.AddDays(-1.0);
        string str1 = dateTime.Day.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (Convert.ToInt32(str1) < 10)
          str1 = "0" + str1;
        string str2 = dateTime.Month.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        this.strHtml = this.strHtml + "<th>" + str1 + "<br/>-<br/>" + str2 + "</th>";
      }
      this.widthHtml += 37;
      this.strHtml += "<th>Tổng<br/>-<br/>Nháy</th></tr></table>";
      this.Hien_Thi_KetQua(this.wbHienthi, this.strHtml);
    }

    private void bunifuImageButton1_Click(object sender, EventArgs e)
    {
      if (!this.cbState0)
      {
        this.cb00.Checked = true;
        this.cb01.Checked = true;
        this.cb02.Checked = true;
        this.cb03.Checked = true;
        this.cb04.Checked = true;
        this.cb05.Checked = true;
        this.cb06.Checked = true;
        this.cb07.Checked = true;
        this.cb08.Checked = true;
        this.cb09.Checked = true;
        this.cbState0 = true;
      }
      else
      {
        this.cbState0 = false;
        this.cb00.Checked = false;
        this.cb01.Checked = false;
        this.cb02.Checked = false;
        this.cb03.Checked = false;
        this.cb04.Checked = false;
        this.cb05.Checked = false;
        this.cb06.Checked = false;
        this.cb07.Checked = false;
        this.cb08.Checked = false;
        this.cb09.Checked = false;
      }
    }

    private void bunifuImageButton2_Click(object sender, EventArgs e)
    {
      if (!this.cbState1)
      {
        this.cbState1 = true;
        this.cb10.Checked = true;
        this.cb11.Checked = true;
        this.cb12.Checked = true;
        this.cb13.Checked = true;
        this.cb14.Checked = true;
        this.cb15.Checked = true;
        this.cb16.Checked = true;
        this.cb17.Checked = true;
        this.cb18.Checked = true;
        this.cb19.Checked = true;
      }
      else
      {
        this.cbState1 = false;
        this.cb10.Checked = false;
        this.cb11.Checked = false;
        this.cb12.Checked = false;
        this.cb13.Checked = false;
        this.cb14.Checked = false;
        this.cb15.Checked = false;
        this.cb16.Checked = false;
        this.cb17.Checked = false;
        this.cb18.Checked = false;
        this.cb19.Checked = false;
      }
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      if (!this.cbState2)
      {
        this.cbState2 = true;
        this.cb20.Checked = true;
        this.cb21.Checked = true;
        this.cb22.Checked = true;
        this.cb23.Checked = true;
        this.cb24.Checked = true;
        this.cb25.Checked = true;
        this.cb26.Checked = true;
        this.cb27.Checked = true;
        this.cb28.Checked = true;
        this.cb29.Checked = true;
      }
      else
      {
        this.cbState2 = false;
        this.cb20.Checked = false;
        this.cb21.Checked = false;
        this.cb22.Checked = false;
        this.cb23.Checked = false;
        this.cb24.Checked = false;
        this.cb25.Checked = false;
        this.cb26.Checked = false;
        this.cb27.Checked = false;
        this.cb28.Checked = false;
        this.cb29.Checked = false;
      }
    }

    private void CheckItem(object sender)
    {
      CheckBox checkBox = (CheckBox) sender;
      if (checkBox.Checked)
      {
        this.listItem.Add((object) checkBox.Text);
        checkBox.BackColor = Color.Red;
        checkBox.ForeColor = Color.Yellow;
      }
      else
      {
        this.listItem.Remove((object) checkBox.Text);
        checkBox.BackColor = Color.White;
        checkBox.ForeColor = Color.DimGray;
      }
      if (this.listItem.Count > 0)
      {
        this.btnTronhet.Text = Resources.TabTanxuatloto_CheckItem_Bỏ_trọn;
        this.checkTron = true;
      }
      else
      {
        this.btnTronhet.Text = Resources.TabTanxuatloto_CheckItem_Trọn_hết;
        this.checkTron = false;
      }
    }

    private void HoverItem(object sender)
    {
      this.arrItemsChoice.Clear();
      CheckBox checkBox = (CheckBox) sender;
      if (!checkBox.Checked)
      {
        checkBox.BackColor = Color.Red;
        checkBox.ForeColor = Color.Yellow;
      }
      this.arrItemsChoice.Add((object) ClMain.check_Loto_Cap(checkBox.Text));
      string trungDau = this.BienDoiLoToTrungDau(checkBox.Text, FMain.ObjConfigBacNho.BiendoTrungDau);
      if (trungDau != "")
        this.arrItemsChoice.Add((object) trungDau);
      string trungDuoi = this.BienDoiLoToTrungDuoi(checkBox.Text, FMain.ObjConfigBacNho.BiendoTrungDuoi);
      if (trungDuoi != "")
        this.arrItemsChoice.Add((object) trungDuoi);
      foreach (Control control in (ArrangedElementCollection) this.panel2.Controls)
      {
        if (control is CheckBox && this.arrItemsChoice.Count > 0)
        {
          for (int index = 0; index < this.arrItemsChoice.Count; ++index)
          {
            if ((control as CheckBox).Text == this.arrItemsChoice[index].ToString() && !(control as CheckBox).Checked)
            {
              (control as CheckBox).BackColor = Color.DimGray;
              (control as CheckBox).ForeColor = Color.White;
            }
          }
        }
      }
    }

    private void LeaveItem(object sender)
    {
      CheckBox checkBox = (CheckBox) sender;
      if (!checkBox.Checked)
      {
        checkBox.BackColor = Color.White;
        checkBox.ForeColor = Color.DimGray;
      }
      foreach (Control control in (ArrangedElementCollection) this.panel2.Controls)
      {
        if (control is CheckBox && this.arrItemsChoice.Count > 0)
        {
          for (int index = 0; index < this.arrItemsChoice.Count; ++index)
          {
            if ((control as CheckBox).Text == this.arrItemsChoice[index].ToString() && !(control as CheckBox).Checked)
            {
              (control as CheckBox).BackColor = Color.White;
              (control as CheckBox).ForeColor = Color.DimGray;
            }
          }
        }
      }
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

    private void checkBox5_CheckedChanged(object sender, EventArgs e)
    {
      this.CheckItem(sender);
    }

    private void bunifuImageButton4_Click(object sender, EventArgs e)
    {
      if (!this.cbState3)
      {
        this.cbState3 = true;
        this.cb30.Checked = true;
        this.cb31.Checked = true;
        this.cb32.Checked = true;
        this.cb33.Checked = true;
        this.cb34.Checked = true;
        this.cb35.Checked = true;
        this.cb36.Checked = true;
        this.cb37.Checked = true;
        this.cb38.Checked = true;
        this.cb39.Checked = true;
      }
      else
      {
        this.cbState3 = false;
        this.cb30.Checked = false;
        this.cb31.Checked = false;
        this.cb32.Checked = false;
        this.cb33.Checked = false;
        this.cb34.Checked = false;
        this.cb35.Checked = false;
        this.cb36.Checked = false;
        this.cb37.Checked = false;
        this.cb38.Checked = false;
        this.cb39.Checked = false;
      }
    }

    private void bunifuImageButton5_Click(object sender, EventArgs e)
    {
      if (!this.cbState4)
      {
        this.cbState4 = true;
        this.cb40.Checked = true;
        this.cb41.Checked = true;
        this.cb42.Checked = true;
        this.cb43.Checked = true;
        this.cb44.Checked = true;
        this.cb45.Checked = true;
        this.cb46.Checked = true;
        this.cb47.Checked = true;
        this.cb48.Checked = true;
        this.cb49.Checked = true;
      }
      else
      {
        this.cbState4 = false;
        this.cb40.Checked = false;
        this.cb41.Checked = false;
        this.cb42.Checked = false;
        this.cb43.Checked = false;
        this.cb44.Checked = false;
        this.cb45.Checked = false;
        this.cb46.Checked = false;
        this.cb47.Checked = false;
        this.cb48.Checked = false;
        this.cb49.Checked = false;
      }
    }

    private void bunifuImageButton6_Click(object sender, EventArgs e)
    {
      if (!this.cbState5)
      {
        this.cbState5 = true;
        this.cb50.Checked = true;
        this.cb51.Checked = true;
        this.cb52.Checked = true;
        this.cb53.Checked = true;
        this.cb54.Checked = true;
        this.cb55.Checked = true;
        this.cb56.Checked = true;
        this.cb57.Checked = true;
        this.cb58.Checked = true;
        this.cb59.Checked = true;
      }
      else
      {
        this.cbState5 = false;
        this.cb50.Checked = false;
        this.cb51.Checked = false;
        this.cb52.Checked = false;
        this.cb53.Checked = false;
        this.cb54.Checked = false;
        this.cb55.Checked = false;
        this.cb56.Checked = false;
        this.cb57.Checked = false;
        this.cb58.Checked = false;
        this.cb59.Checked = false;
      }
    }

    private void bunifuImageButton7_Click(object sender, EventArgs e)
    {
      if (!this.cbState6)
      {
        this.cbState6 = true;
        this.cb60.Checked = true;
        this.cb61.Checked = true;
        this.cb62.Checked = true;
        this.cb63.Checked = true;
        this.cb64.Checked = true;
        this.cb65.Checked = true;
        this.cb66.Checked = true;
        this.cb67.Checked = true;
        this.cb68.Checked = true;
        this.cb69.Checked = true;
      }
      else
      {
        this.cbState6 = false;
        this.cb60.Checked = false;
        this.cb61.Checked = false;
        this.cb62.Checked = false;
        this.cb63.Checked = false;
        this.cb64.Checked = false;
        this.cb65.Checked = false;
        this.cb66.Checked = false;
        this.cb67.Checked = false;
        this.cb68.Checked = false;
        this.cb69.Checked = false;
      }
    }

    private void bunifuImageButton8_Click(object sender, EventArgs e)
    {
      if (!this.cbState7)
      {
        this.cbState7 = true;
        this.cb70.Checked = true;
        this.cb71.Checked = true;
        this.cb72.Checked = true;
        this.cb73.Checked = true;
        this.cb74.Checked = true;
        this.cb75.Checked = true;
        this.cb76.Checked = true;
        this.cb77.Checked = true;
        this.cb78.Checked = true;
        this.cb79.Checked = true;
      }
      else
      {
        this.cbState7 = false;
        this.cb70.Checked = false;
        this.cb71.Checked = false;
        this.cb72.Checked = false;
        this.cb73.Checked = false;
        this.cb74.Checked = false;
        this.cb75.Checked = false;
        this.cb76.Checked = false;
        this.cb77.Checked = false;
        this.cb78.Checked = false;
        this.cb79.Checked = false;
      }
    }

    private void bunifuImageButton9_Click(object sender, EventArgs e)
    {
      if (!this.cbState8)
      {
        this.cbState8 = true;
        this.cb80.Checked = true;
        this.cb81.Checked = true;
        this.cb82.Checked = true;
        this.cb83.Checked = true;
        this.cb84.Checked = true;
        this.cb85.Checked = true;
        this.cb86.Checked = true;
        this.cb87.Checked = true;
        this.cb88.Checked = true;
        this.cb89.Checked = true;
      }
      else
      {
        this.cbState8 = false;
        this.cb80.Checked = false;
        this.cb81.Checked = false;
        this.cb82.Checked = false;
        this.cb83.Checked = false;
        this.cb84.Checked = false;
        this.cb85.Checked = false;
        this.cb86.Checked = false;
        this.cb87.Checked = false;
        this.cb88.Checked = false;
        this.cb89.Checked = false;
      }
    }

    private void bunifuImageButton10_Click(object sender, EventArgs e)
    {
      if (!this.cbState9)
      {
        this.cbState9 = true;
        this.cb90.Checked = true;
        this.cb91.Checked = true;
        this.cb92.Checked = true;
        this.cb93.Checked = true;
        this.cb94.Checked = true;
        this.cb95.Checked = true;
        this.cb96.Checked = true;
        this.cb97.Checked = true;
        this.cb98.Checked = true;
        this.cb99.Checked = true;
      }
      else
      {
        this.cbState9 = false;
        this.cb90.Checked = false;
        this.cb91.Checked = false;
        this.cb92.Checked = false;
        this.cb93.Checked = false;
        this.cb94.Checked = false;
        this.cb95.Checked = false;
        this.cb96.Checked = false;
        this.cb97.Checked = false;
        this.cb98.Checked = false;
        this.cb99.Checked = false;
      }
    }

    private void btnTronhet_Click(object sender, EventArgs e)
    {
      if (this.checkTron)
      {
        this.cbState0 = false;
        this.cb00.Checked = false;
        this.cb01.Checked = false;
        this.cb02.Checked = false;
        this.cb03.Checked = false;
        this.cb04.Checked = false;
        this.cb05.Checked = false;
        this.cb06.Checked = false;
        this.cb07.Checked = false;
        this.cb08.Checked = false;
        this.cb09.Checked = false;
        this.cbState1 = false;
        this.cb10.Checked = false;
        this.cb11.Checked = false;
        this.cb12.Checked = false;
        this.cb13.Checked = false;
        this.cb14.Checked = false;
        this.cb15.Checked = false;
        this.cb16.Checked = false;
        this.cb17.Checked = false;
        this.cb18.Checked = false;
        this.cb19.Checked = false;
        this.cbState2 = false;
        this.cb20.Checked = false;
        this.cb21.Checked = false;
        this.cb22.Checked = false;
        this.cb23.Checked = false;
        this.cb24.Checked = false;
        this.cb25.Checked = false;
        this.cb26.Checked = false;
        this.cb27.Checked = false;
        this.cb28.Checked = false;
        this.cb29.Checked = false;
        this.cbState3 = false;
        this.cb30.Checked = false;
        this.cb31.Checked = false;
        this.cb32.Checked = false;
        this.cb33.Checked = false;
        this.cb34.Checked = false;
        this.cb35.Checked = false;
        this.cb36.Checked = false;
        this.cb37.Checked = false;
        this.cb38.Checked = false;
        this.cb39.Checked = false;
        this.cbState4 = false;
        this.cb40.Checked = false;
        this.cb41.Checked = false;
        this.cb42.Checked = false;
        this.cb43.Checked = false;
        this.cb44.Checked = false;
        this.cb45.Checked = false;
        this.cb46.Checked = false;
        this.cb47.Checked = false;
        this.cb48.Checked = false;
        this.cb49.Checked = false;
        this.cbState5 = false;
        this.cb50.Checked = false;
        this.cb51.Checked = false;
        this.cb52.Checked = false;
        this.cb53.Checked = false;
        this.cb54.Checked = false;
        this.cb55.Checked = false;
        this.cb56.Checked = false;
        this.cb57.Checked = false;
        this.cb58.Checked = false;
        this.cb59.Checked = false;
        this.cbState6 = false;
        this.cb60.Checked = false;
        this.cb61.Checked = false;
        this.cb62.Checked = false;
        this.cb63.Checked = false;
        this.cb64.Checked = false;
        this.cb65.Checked = false;
        this.cb66.Checked = false;
        this.cb67.Checked = false;
        this.cb68.Checked = false;
        this.cb69.Checked = false;
        this.cbState7 = false;
        this.cb70.Checked = false;
        this.cb71.Checked = false;
        this.cb72.Checked = false;
        this.cb73.Checked = false;
        this.cb74.Checked = false;
        this.cb75.Checked = false;
        this.cb76.Checked = false;
        this.cb77.Checked = false;
        this.cb78.Checked = false;
        this.cb79.Checked = false;
        this.cbState8 = false;
        this.cb80.Checked = false;
        this.cb81.Checked = false;
        this.cb82.Checked = false;
        this.cb83.Checked = false;
        this.cb84.Checked = false;
        this.cb85.Checked = false;
        this.cb86.Checked = false;
        this.cb87.Checked = false;
        this.cb88.Checked = false;
        this.cb89.Checked = false;
        this.cbState9 = false;
        this.cb90.Checked = false;
        this.cb91.Checked = false;
        this.cb92.Checked = false;
        this.cb93.Checked = false;
        this.cb94.Checked = false;
        this.cb95.Checked = false;
        this.cb96.Checked = false;
        this.cb97.Checked = false;
        this.cb98.Checked = false;
        this.cb99.Checked = false;
      }
      else
      {
        this.cbState0 = true;
        this.cb00.Checked = true;
        this.cb01.Checked = true;
        this.cb02.Checked = true;
        this.cb03.Checked = true;
        this.cb04.Checked = true;
        this.cb05.Checked = true;
        this.cb06.Checked = true;
        this.cb07.Checked = true;
        this.cb08.Checked = true;
        this.cb09.Checked = true;
        this.cbState1 = true;
        this.cb10.Checked = true;
        this.cb11.Checked = true;
        this.cb12.Checked = true;
        this.cb13.Checked = true;
        this.cb14.Checked = true;
        this.cb15.Checked = true;
        this.cb16.Checked = true;
        this.cb17.Checked = true;
        this.cb18.Checked = true;
        this.cb19.Checked = true;
        this.cbState2 = true;
        this.cb20.Checked = true;
        this.cb21.Checked = true;
        this.cb22.Checked = true;
        this.cb23.Checked = true;
        this.cb24.Checked = true;
        this.cb25.Checked = true;
        this.cb26.Checked = true;
        this.cb27.Checked = true;
        this.cb28.Checked = true;
        this.cb29.Checked = true;
        this.cbState3 = true;
        this.cb30.Checked = true;
        this.cb31.Checked = true;
        this.cb32.Checked = true;
        this.cb33.Checked = true;
        this.cb34.Checked = true;
        this.cb35.Checked = true;
        this.cb36.Checked = true;
        this.cb37.Checked = true;
        this.cb38.Checked = true;
        this.cb39.Checked = true;
        this.cbState4 = true;
        this.cb40.Checked = true;
        this.cb41.Checked = true;
        this.cb42.Checked = true;
        this.cb43.Checked = true;
        this.cb44.Checked = true;
        this.cb45.Checked = true;
        this.cb46.Checked = true;
        this.cb47.Checked = true;
        this.cb48.Checked = true;
        this.cb49.Checked = true;
        this.cbState5 = true;
        this.cb50.Checked = true;
        this.cb51.Checked = true;
        this.cb52.Checked = true;
        this.cb53.Checked = true;
        this.cb54.Checked = true;
        this.cb55.Checked = true;
        this.cb56.Checked = true;
        this.cb57.Checked = true;
        this.cb58.Checked = true;
        this.cb59.Checked = true;
        this.cbState6 = true;
        this.cb60.Checked = true;
        this.cb61.Checked = true;
        this.cb62.Checked = true;
        this.cb63.Checked = true;
        this.cb64.Checked = true;
        this.cb65.Checked = true;
        this.cb66.Checked = true;
        this.cb67.Checked = true;
        this.cb68.Checked = true;
        this.cb69.Checked = true;
        this.cbState7 = true;
        this.cb70.Checked = true;
        this.cb71.Checked = true;
        this.cb72.Checked = true;
        this.cb73.Checked = true;
        this.cb74.Checked = true;
        this.cb75.Checked = true;
        this.cb76.Checked = true;
        this.cb77.Checked = true;
        this.cb78.Checked = true;
        this.cb79.Checked = true;
        this.cbState8 = true;
        this.cb80.Checked = true;
        this.cb81.Checked = true;
        this.cb82.Checked = true;
        this.cb83.Checked = true;
        this.cb84.Checked = true;
        this.cb85.Checked = true;
        this.cb86.Checked = true;
        this.cb87.Checked = true;
        this.cb88.Checked = true;
        this.cb89.Checked = true;
        this.cbState9 = true;
        this.cb90.Checked = true;
        this.cb91.Checked = true;
        this.cb92.Checked = true;
        this.cb93.Checked = true;
        this.cb94.Checked = true;
        this.cb95.Checked = true;
        this.cb96.Checked = true;
        this.cb97.Checked = true;
        this.cb98.Checked = true;
        this.cb99.Checked = true;
      }
    }

    private void cb90_MouseHover(object sender, EventArgs e)
    {
      this.HoverItem(sender);
    }

    private void cb90_MouseLeave(object sender, EventArgs e)
    {
      this.LeaveItem(sender);
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      this.txtBiendongay.BackColor = Color.White;
      this.txtBiendongay.ForeColor = Color.Red;
      this.txtGialapngaychuara.BackColor = Color.White;
      this.txtGialapngaychuara.ForeColor = Color.Red;
      if (this.txtBiendongay.Text.Length < 1 || this.txtBiendongay.Text.Length > 5)
        this.DoiMauTXT(this.txtBiendongay, false);
      else if (this.txtGialapngaychuara.Text.Length < 1 || this.txtGialapngaychuara.Text.Length > 3)
      {
        this.DoiMauTXT(this.txtGialapngaychuara, false);
      }
      else
      {
        this.txtBiendongay.Text = this.Get_Str_Loto(this.txtBiendongay.Text);
        this.txtGialapngaychuara.Text = this.Get_Str_Loto(this.txtGialapngaychuara.Text);
        if (this.txtBiendongay.Text.Length < 1)
          this.txtBiendongay.Text = Resources.TabTanxuatloto_btnThongke_Click__45;
        if (this.txtGialapngaychuara.Text.Length < 1)
          this.txtGialapngaychuara.Text = Resources.FLotoOffline_tinhVon_Lai__0;
        if (Convert.ToInt32(this.txtBiendongay.Text) > 995 || Convert.ToInt32(this.txtBiendongay.Text) < 10)
        {
          int num = (int) MessageBox.Show(Resources.TabTanxuatloto_btnThongke_Click_BIÊN_ĐỘ_NGÀY_MUỐN_XEM_PHẢI_LỚN_HƠN_10_VÀ_NHỎ_HƠN_1095_NGÀY____, Resources.TabTanxuatloto_btnThongke_Click_GỢI_Ý, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.DoiMauTXT(this.txtBiendongay, false);
        }
        else if (Convert.ToInt32(this.txtGialapngaychuara.Text) < 0 || Convert.ToInt32(this.txtGialapngaychuara.Text) > 44)
        {
          int num = (int) MessageBox.Show(Resources.TabTanxuatloto_btnThongke_Click_GIẢ_LẬP_NGÀY_CHƯA_RA_PHẢI_LỚN_HƠN_HOẶC_BẲNG_0_VÀ_NHỎ_HƠN_45_NGÀY____, Resources.TabTanxuatloto_btnThongke_Click_GỢI_Ý, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.DoiMauTXT(this.txtGialapngaychuara, false);
        }
        else if (this.listItem.Count < 1)
        {
          int num1 = (int) MessageBox.Show(Resources.TabTanxuatloto_btnThongke_Click_HÃY_TRỌN_LẤY_MỘT_CON_LÔ_ĐỂ_XEM_BẠN_NHÉ___, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          if (this.bgProcess.IsBusy)
            return;
          this.bgProcess.RunWorkerAsync();
        }
      }
    }

    private void Process(DateTime ngayXem, int sobanghi, int gialapngaychuara)
    {
      this.listInfoLoto = new List<TabTanxuatloto.InfoLoto>();
      this.widthHtml = 26;
      this.strHtml = "";
      if (this.dtNgayXem.Value != this.ngayThangCu || this.soBanGhiCu != sobanghi)
      {
        this.dataTable = new DataTable();
        this.dataTable = this.objloto.TblotoGetByDateSoBanGhiTrovetruoc(ngayXem, sobanghi);
        this.ngayThangCu = this.dtNgayXem.Value;
        this.soBanGhiCu = sobanghi;
      }
      if (this.dataTable == null || this.dataTable.Rows.Count <= 0)
        return;
      this.strHtml += "<table class='tbMain'>";
      this.strHtml += "<tr><th>NGÀY<br>-<br>THÁNG</th>";
      int num1;
      if (gialapngaychuara > 0)
      {
        for (int index = 0; index < gialapngaychuara; ++index)
        {
          num1 = Convert.ToDateTime(this.dtNgayXem.Value.AddDays((double) (gialapngaychuara - index))).Day;
          string str1 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
          num1 = Convert.ToDateTime(this.dtNgayXem.Value.AddDays((double) (gialapngaychuara - index))).Month;
          string str2 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
          this.strHtml = this.strHtml + "<th>" + str1 + "<br>-<br>" + str2 + "</th>";
        }
      }
      for (int index = 0; index < this.dataTable.Rows.Count; ++index)
      {
        this.widthHtml += 36;
        DateTime dateTime = Convert.ToDateTime(this.dataTable.Rows[index]["clngaythang"].ToString().Trim());
        num1 = dateTime.Day;
        string str1 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (Convert.ToInt32(str1) < 10)
          str1 = "0" + str1;
        dateTime = Convert.ToDateTime(this.dataTable.Rows[index]["clngaythang"].ToString().Trim());
        num1 = dateTime.Month;
        string str2 = num1.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        this.strHtml = this.strHtml + "<th>" + str1 + "<br>-<br>" + str2 + "</th>";
      }
      this.widthHtml += 26;
      this.strHtml += "<th>Tổng<br/>-<br/>Nháy</th></tr>";
      int num2 = this.dataTable.Rows.Count + gialapngaychuara;
      for (int index1 = 0; index1 < this.listItem.Count; ++index1)
      {
        string str1 = this.listItem[index1].ToString();
        TabTanxuatloto.InfoLoto infoLoto = new TabTanxuatloto.InfoLoto()
        {
          Loto = str1,
          MaxGan = Decimal.Zero,
          Tongsonhay = Decimal.Zero,
          Ngaychuara = Decimal.Zero,
          Chukitrungbinhsolan = Decimal.Zero,
          Chukitrungbinhsonhay = Decimal.Zero
        };
        this.strHtml += "<tr>";
        this.strHtml = this.strHtml + "<td class='tdVe'>" + str1 + "</td>";
        int num3 = 0;
        if (gialapngaychuara > 0)
        {
          for (int index2 = 0; index2 < gialapngaychuara; ++index2)
            this.strHtml += "<td class='tdXit'></td>";
        }
        bool flag1 = false;
        int num4 = 0;
        for (int index2 = 0; index2 < this.dataTable.Rows.Count; ++index2)
        {
          int num5 = 0;
          bool flag2 = false;
          for (int index3 = 2; index3 < this.dataTable.Columns.Count; ++index3)
          {
            string str2 = this.dataTable.Rows[index2][index3].ToString().Trim();
            if (str1 == str2)
            {
              ++num5;
              ++infoLoto.Tongsonhay;
              num3 = str1 == this.dataTable.Rows[index2]["G0"].ToString().Trim() ? 1 : 0;
              flag2 = true;
            }
          }
          if (flag2)
          {
            flag1 = true;
            ++infoLoto.Tongsolan;
            num4 = 0;
            if (num3 == 1)
              this.strHtml = this.strHtml + "<td class='tdVe' style='background:yellow;'><b style='color:red;'>" + (object) num5 + "</b></td>";
            else
              this.strHtml = this.strHtml + "<td class='tdVe'>" + (object) num5 + "</td>";
          }
          else
          {
            ++num4;
            if ((Decimal) num4 > infoLoto.MaxGan)
              infoLoto.MaxGan = (Decimal) num4;
            if (!flag1)
              ++infoLoto.Ngaychuara;
            this.strHtml += "<td class='tdXit'></td>";
          }
        }
        this.strHtml = this.strHtml + "<td class='tdVe'><b>" + (object) infoLoto.Tongsonhay + "</b></td>";
        this.strHtml += "</tr>";
        Decimal num6 = infoLoto.Tongsolan;
        Decimal num7 = infoLoto.Tongsonhay;
        if (infoLoto.Tongsolan == Decimal.One)
          num6 = new Decimal(2);
        if (infoLoto.Tongsonhay == Decimal.One)
          num7 = new Decimal(2);
        if (num6 != Decimal.Zero)
        {
          infoLoto.Chukitrungbinhsolan = (Decimal) num2 / num6;
          infoLoto.Chukitrungbinhsonhay = (Decimal) num2 / num7;
          infoLoto.Ngaychuara += (Decimal) gialapngaychuara;
        }
        if (infoLoto.Ngaychuara > infoLoto.MaxGan)
          infoLoto.MaxGan = infoLoto.Ngaychuara;
        this.listInfoLoto.Add(infoLoto);
      }
      this.strHtml += this.KiemTraCap(gialapngaychuara);
      this.strHtml += "</table>";
      if (this.listInfoLoto.Count > 0)
      {
        this.strHtml = this.strHtml + "<div style='width:1300px;text-align:center;margin-top:20px;'>☜♥☞ º°”˜`”°º☜ <b style='color:black;'>THÔNG TIN LÔ TÔ TRONG (<b style='color:red;'>" + (object) num2 + "</b>) NGÀY VỪA QUA</b> ☞ º°”˜`”°☜♥☞</div><div style='width:1300px;'>";
        foreach (TabTanxuatloto.InfoLoto infoLoto in this.listInfoLoto)
        {
          string str;
          if (infoLoto.Ngaychuara == Decimal.Zero)
            str = "vừa về hôm qua";
          else if (infoLoto.Ngaychuara == Decimal.One)
          {
            str = "vừa về hôm kia";
          }
          else
          {
            str = "đến nay là (<b style='color:red;'>" + (object) infoLoto.Ngaychuara + "</b>) ngày chưa ra";
            if (infoLoto.Ngaychuara == infoLoto.MaxGan)
              str = "đến nay đã (<b style='color:red;'> CHẠM MAX </b>)";
            else if (infoLoto.Ngaychuara == infoLoto.MaxGan - Decimal.One)
              str = " (<b style='color:red;'> CHUẨN BỊ CHẠM MAX </b>)";
          }
          this.strHtml = this.strHtml + "<br><b style='color:red;'>+</b> Lô (<b style='color:red;'>" + infoLoto.Loto + "</b>) ";
          if (infoLoto.Chukitrungbinhsolan == Decimal.Zero)
            this.strHtml += "không có thông tin.<br>";
          else
            this.strHtml = this.strHtml + "về (<b style='color:black;'>" + (object) infoLoto.Tongsolan + "</b>) lần (<b style='color:black;'>" + (object) infoLoto.Tongsonhay + "</b>) nháy trung bình cứ (<b style='color:red;'>" + (object) Math.Round(infoLoto.Chukitrungbinhsolan, 1) + "</b>) ngày sẽ về 1 lần (<b style='color:red;'>" + (object) Math.Round(infoLoto.Chukitrungbinhsonhay, 1) + "</b>) ngày sẽ về 1 nháy, gan lớn nhất trong khung kiểm tra là (<b style='color:red;'>" + (object) infoLoto.MaxGan + "</b>) ngày,  " + str + ".<br>";
        }
        this.strHtml = this.strHtml + "<br/>" + this.strInfoNhomLoto + "</div>";
      }
    }

    private string KiemTraCap(int gialapngaychuara)
    {
      string str1 = "";
      this.strInfoNhomLoto = "";
      if (this.listItem.Count > 1)
      {
        ArrayList arrayList = new ArrayList((ICollection) this.listItem);
        string str2 = str1 + "<tr><td></td><td></td><td></td><td></td><td></td></tr>" + "<tr>";
        string str3;
        if (this.listItem.Count == 2)
          str3 = str2 + "<td class='tdVe' style='border-color:red;'>" + arrayList[0] + "-" + arrayList[1] + "</td>";
        else
          str3 = str2 + "<td class='tdVe' style='border-color:red;'>All</td>";
        int num1 = 0;
        if (gialapngaychuara > 0)
        {
          for (int index = 0; index < gialapngaychuara; ++index)
            str3 += "<td class='tdXit' style='border-color:red;'></td>";
        }
        Decimal num2 = new Decimal();
        Decimal num3 = new Decimal();
        Decimal num4 = (Decimal) (this.dataTable.Rows.Count + gialapngaychuara);
        bool flag = false;
        int num5 = 0;
        int num6 = 0;
        for (int index1 = 0; index1 < this.dataTable.Rows.Count; ++index1)
        {
          int num7 = 0;
          for (int index2 = 2; index2 < this.dataTable.Columns.Count; ++index2)
          {
            string str4 = this.dataTable.Rows[index1][index2].ToString();
            for (int index3 = 0; index3 < arrayList.Count; ++index3)
            {
              if (arrayList[index3].ToString() == str4)
              {
                ++num7;
                ++num1;
                break;
              }
            }
          }
          if ((uint) num7 > 0U)
          {
            flag = true;
            str3 = str3 + "<td class='tdVe' style='border-color:red;'>" + (object) num7 + "</td>";
            ++num2;
            if (num6 > num5)
              num5 = num6;
            num6 = 0;
          }
          else
          {
            ++num6;
            str3 += "<td class='tdXit' style='border-color:red;'></td>";
            if (!flag)
              ++num3;
          }
        }
        str1 = str3 + "<td class='tdVe' style='border-color:red;'><b>" + (object) num1 + "</b></td>" + "</tr>";
        string str5 = "";
        for (int index = 0; index < this.listItem.Count; ++index)
        {
          str5 = str5 + "<b style='color:red;'>" + this.listItem[index] + "</b>";
          if (index <= this.listItem.Count - 2)
            str5 += " - ";
        }
        Decimal d1 = new Decimal();
        Decimal d2 = new Decimal();
        if (num2 != Decimal.Zero)
        {
          d1 = num4 / num2;
          d2 = num4 / (Decimal) num1;
          num3 += (Decimal) gialapngaychuara;
        }
        string str6;
        if (num3 == Decimal.Zero)
          str6 = "vừa về hôm qua";
        else if (num3 == Decimal.One)
        {
          str6 = "vừa về hôm kia";
        }
        else
        {
          str6 = "đến nay là (<b style='color:red;'>" + (object) num3 + "</b>) ngày chưa ra";
          if (num3 == (Decimal) num5)
            str6 = "đến nay đã (<b style='color:red;'> CHẠM MAX </b>)";
          else if (num3 == (Decimal) (num5 - 1))
            str6 = " (<b style='color:red;'> CHUẨN BỊ CHẠM MAX </b>)";
        }
        if (this.listItem.Count > 1)
          this.strInfoNhomLoto = "=>Tần xuất tổng hợp của lô  " + str5 + " về tất cả (<b style='color:black;'>" + (object) num2 + "</b>) lần, (<b style='color:black;'>" + (object) num1 + "</b>) nháy. Trung bình cứ (<b style='color:red;'>" + (object) Math.Round(d1, 1) + "</b>) ngày về 1 lần, (<b style='color:red;'>" + (object) Math.Round(d2, 1) + "</b>) ngày về 1 nháy. Gan lớn nhất trong khung kiểm tra là <b style='color:red;'>" + (object) num5 + " ngày</b>. " + str6 ?? "";
      }
      return str1;
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string str)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                    <style type='text/css'>\r\n\r\n    .tbMain{\r\n\t\t\tfont-family: tahoma;\r\n\t\t\tfont-size: 11px;\r\n            margin-right: 10px;\r\nborder-collapse: collapse;\r\n\t\t\t}\r\n\t\t\tth{\r\n\t\t\tborder-style: solid;\r\n\t\t\tborder-width:1px;\r\n\t\t\ttext-align:center;\r\n\t\t\twidth:36px;\r\n        border-color:#696969;\r\n\t\t\t}\r\n\t\t\t.tdTieude{\r\n\t\t\tborder-style: solid;\r\n\t\t\tborder-color:#696969;\r\n\t\t\twidth:36px;\r\n\t\t\ttext-align:center;\r\n\t\t\tborder-width:1px;\r\n\t\t\ttext-align:center;\r\n\t\t\t}\r\n\t\t\t.tdVe{\r\n\t\t\tborder-style: solid;\r\n\t\t\tborder-width:1px;\r\n\t\t\ttext-align:center;\r\n\t\t\tbackground:white;\r\nborder-color:#696969;\r\n\t\t\t}\r\n\t\t\t.tdXit\r\n\t\t\t{\r\n\t\t\tborder-style: solid;\r\n\t\t\tborder-width:1px;\r\n\t\t\ttext-align:center;\r\n\t\t\tbackground:#999999;\r\nborder-color:#696969;\r\n\t\t\t}\r\n\t\t\ttd{\r\n\t\t\tfont-weight:bold;\r\n            height:20px;\r\n            }\r\n             </style><title>THỐNG KÊ XỔ SỐ</title></head><body style='width:" + (object) this.widthHtml + "px;color:#696969;' oncontextmenu='return false;'>" + str + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void DoiMauTXT(TextBox sender, bool check)
    {
      if (check)
        return;
      sender.Focus();
      sender.BackColor = Color.Red;
      sender.ForeColor = Color.Black;
    }

    private string Get_Str_Loto(string strTxtLoto)
    {
      string str = strTxtLoto;
      string empty = string.Empty;
      for (int index = 0; index < str.Length; ++index)
      {
        if (char.IsDigit(str[index]))
          empty += str[index].ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      return empty;
    }

    private void timerLoading_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.bgProcess.IsBusy;
    }

    private void bgProcess_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Process(this.dtNgayXem.Value, Convert.ToInt32(this.txtBiendongay.Text), Convert.ToInt32(this.txtGialapngaychuara.Text));
    }

    private void bgProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Hien_Thi_KetQua(this.wbHienthi, this.strHtml);
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabTanxuatloto));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel2 = new Panel();
      this.label6 = new Label();
      this.label5 = new Label();
      this.btnTronhet = new Button();
      this.cb90 = new CheckBox();
      this.cb70 = new CheckBox();
      this.cb50 = new CheckBox();
      this.cb30 = new CheckBox();
      this.cb10 = new CheckBox();
      this.cb80 = new CheckBox();
      this.cb60 = new CheckBox();
      this.cb40 = new CheckBox();
      this.cb20 = new CheckBox();
      this.cb00 = new CheckBox();
      this.cb99 = new CheckBox();
      this.cb98 = new CheckBox();
      this.cb97 = new CheckBox();
      this.cb96 = new CheckBox();
      this.cb95 = new CheckBox();
      this.cb94 = new CheckBox();
      this.cb93 = new CheckBox();
      this.cb92 = new CheckBox();
      this.cb91 = new CheckBox();
      this.bunifuImageButton10 = new BunifuImageButton();
      this.cb89 = new CheckBox();
      this.cb88 = new CheckBox();
      this.cb87 = new CheckBox();
      this.cb86 = new CheckBox();
      this.cb85 = new CheckBox();
      this.cb84 = new CheckBox();
      this.cb83 = new CheckBox();
      this.cb82 = new CheckBox();
      this.cb81 = new CheckBox();
      this.bunifuImageButton9 = new BunifuImageButton();
      this.cb79 = new CheckBox();
      this.cb78 = new CheckBox();
      this.cb77 = new CheckBox();
      this.cb76 = new CheckBox();
      this.cb75 = new CheckBox();
      this.cb74 = new CheckBox();
      this.cb73 = new CheckBox();
      this.cb72 = new CheckBox();
      this.cb71 = new CheckBox();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.cb69 = new CheckBox();
      this.cb68 = new CheckBox();
      this.cb67 = new CheckBox();
      this.cb66 = new CheckBox();
      this.cb65 = new CheckBox();
      this.cb64 = new CheckBox();
      this.cb63 = new CheckBox();
      this.cb62 = new CheckBox();
      this.cb61 = new CheckBox();
      this.bunifuImageButton7 = new BunifuImageButton();
      this.cb59 = new CheckBox();
      this.cb58 = new CheckBox();
      this.cb57 = new CheckBox();
      this.cb56 = new CheckBox();
      this.cb55 = new CheckBox();
      this.cb54 = new CheckBox();
      this.cb53 = new CheckBox();
      this.cb52 = new CheckBox();
      this.cb51 = new CheckBox();
      this.bunifuImageButton6 = new BunifuImageButton();
      this.cb49 = new CheckBox();
      this.cb48 = new CheckBox();
      this.cb47 = new CheckBox();
      this.cb46 = new CheckBox();
      this.cb45 = new CheckBox();
      this.cb44 = new CheckBox();
      this.cb43 = new CheckBox();
      this.cb42 = new CheckBox();
      this.cb41 = new CheckBox();
      this.bunifuImageButton5 = new BunifuImageButton();
      this.cb39 = new CheckBox();
      this.cb38 = new CheckBox();
      this.cb37 = new CheckBox();
      this.cb36 = new CheckBox();
      this.cb35 = new CheckBox();
      this.cb34 = new CheckBox();
      this.cb33 = new CheckBox();
      this.cb32 = new CheckBox();
      this.cb31 = new CheckBox();
      this.bunifuImageButton4 = new BunifuImageButton();
      this.cb29 = new CheckBox();
      this.cb28 = new CheckBox();
      this.cb27 = new CheckBox();
      this.cb26 = new CheckBox();
      this.cb25 = new CheckBox();
      this.cb24 = new CheckBox();
      this.cb23 = new CheckBox();
      this.cb22 = new CheckBox();
      this.cb21 = new CheckBox();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.cb19 = new CheckBox();
      this.cb18 = new CheckBox();
      this.cb17 = new CheckBox();
      this.cb16 = new CheckBox();
      this.cb15 = new CheckBox();
      this.cb14 = new CheckBox();
      this.cb13 = new CheckBox();
      this.cb12 = new CheckBox();
      this.cb11 = new CheckBox();
      this.bunifuImageButton2 = new BunifuImageButton();
      this.cb09 = new CheckBox();
      this.cb08 = new CheckBox();
      this.cb07 = new CheckBox();
      this.cb06 = new CheckBox();
      this.cb05 = new CheckBox();
      this.cb04 = new CheckBox();
      this.cb03 = new CheckBox();
      this.cb02 = new CheckBox();
      this.cb01 = new CheckBox();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.label4 = new Label();
      this.txtGialapngaychuara = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.txtBiendongay = new TextBox();
      this.label13 = new Label();
      this.btnThongke = new Button();
      this.dtNgayXem = new DateTimePicker();
      this.label3 = new Label();
      this.toolTip1 = new ToolTip(this.components);
      this.bgProcess = new BackgroundWorker();
      this.timerLoading = new Timer(this.components);
      this.wbHienthi = new WebBrowser();
      this.picLoading = new PictureBox();
      this.bgDudoanngayve = new BackgroundWorker();
      this.panel2.SuspendLayout();
      this.bunifuImageButton10.BeginInit();
      this.bunifuImageButton9.BeginInit();
      this.bunifuImageButton8.BeginInit();
      this.bunifuImageButton7.BeginInit();
      this.bunifuImageButton6.BeginInit();
      this.bunifuImageButton5.BeginInit();
      this.bunifuImageButton4.BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.bunifuImageButton2.BeginInit();
      this.bunifuImageButton1.BeginInit();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.panel2.BackColor = Color.Transparent;
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.label5);
      this.panel2.Controls.Add((Control) this.btnTronhet);
      this.panel2.Controls.Add((Control) this.cb90);
      this.panel2.Controls.Add((Control) this.cb70);
      this.panel2.Controls.Add((Control) this.cb50);
      this.panel2.Controls.Add((Control) this.cb30);
      this.panel2.Controls.Add((Control) this.cb10);
      this.panel2.Controls.Add((Control) this.cb80);
      this.panel2.Controls.Add((Control) this.cb60);
      this.panel2.Controls.Add((Control) this.cb40);
      this.panel2.Controls.Add((Control) this.cb20);
      this.panel2.Controls.Add((Control) this.cb00);
      this.panel2.Controls.Add((Control) this.cb99);
      this.panel2.Controls.Add((Control) this.cb98);
      this.panel2.Controls.Add((Control) this.cb97);
      this.panel2.Controls.Add((Control) this.cb96);
      this.panel2.Controls.Add((Control) this.cb95);
      this.panel2.Controls.Add((Control) this.cb94);
      this.panel2.Controls.Add((Control) this.cb93);
      this.panel2.Controls.Add((Control) this.cb92);
      this.panel2.Controls.Add((Control) this.cb91);
      this.panel2.Controls.Add((Control) this.bunifuImageButton10);
      this.panel2.Controls.Add((Control) this.cb89);
      this.panel2.Controls.Add((Control) this.cb88);
      this.panel2.Controls.Add((Control) this.cb87);
      this.panel2.Controls.Add((Control) this.cb86);
      this.panel2.Controls.Add((Control) this.cb85);
      this.panel2.Controls.Add((Control) this.cb84);
      this.panel2.Controls.Add((Control) this.cb83);
      this.panel2.Controls.Add((Control) this.cb82);
      this.panel2.Controls.Add((Control) this.cb81);
      this.panel2.Controls.Add((Control) this.bunifuImageButton9);
      this.panel2.Controls.Add((Control) this.cb79);
      this.panel2.Controls.Add((Control) this.cb78);
      this.panel2.Controls.Add((Control) this.cb77);
      this.panel2.Controls.Add((Control) this.cb76);
      this.panel2.Controls.Add((Control) this.cb75);
      this.panel2.Controls.Add((Control) this.cb74);
      this.panel2.Controls.Add((Control) this.cb73);
      this.panel2.Controls.Add((Control) this.cb72);
      this.panel2.Controls.Add((Control) this.cb71);
      this.panel2.Controls.Add((Control) this.bunifuImageButton8);
      this.panel2.Controls.Add((Control) this.cb69);
      this.panel2.Controls.Add((Control) this.cb68);
      this.panel2.Controls.Add((Control) this.cb67);
      this.panel2.Controls.Add((Control) this.cb66);
      this.panel2.Controls.Add((Control) this.cb65);
      this.panel2.Controls.Add((Control) this.cb64);
      this.panel2.Controls.Add((Control) this.cb63);
      this.panel2.Controls.Add((Control) this.cb62);
      this.panel2.Controls.Add((Control) this.cb61);
      this.panel2.Controls.Add((Control) this.bunifuImageButton7);
      this.panel2.Controls.Add((Control) this.cb59);
      this.panel2.Controls.Add((Control) this.cb58);
      this.panel2.Controls.Add((Control) this.cb57);
      this.panel2.Controls.Add((Control) this.cb56);
      this.panel2.Controls.Add((Control) this.cb55);
      this.panel2.Controls.Add((Control) this.cb54);
      this.panel2.Controls.Add((Control) this.cb53);
      this.panel2.Controls.Add((Control) this.cb52);
      this.panel2.Controls.Add((Control) this.cb51);
      this.panel2.Controls.Add((Control) this.bunifuImageButton6);
      this.panel2.Controls.Add((Control) this.cb49);
      this.panel2.Controls.Add((Control) this.cb48);
      this.panel2.Controls.Add((Control) this.cb47);
      this.panel2.Controls.Add((Control) this.cb46);
      this.panel2.Controls.Add((Control) this.cb45);
      this.panel2.Controls.Add((Control) this.cb44);
      this.panel2.Controls.Add((Control) this.cb43);
      this.panel2.Controls.Add((Control) this.cb42);
      this.panel2.Controls.Add((Control) this.cb41);
      this.panel2.Controls.Add((Control) this.bunifuImageButton5);
      this.panel2.Controls.Add((Control) this.cb39);
      this.panel2.Controls.Add((Control) this.cb38);
      this.panel2.Controls.Add((Control) this.cb37);
      this.panel2.Controls.Add((Control) this.cb36);
      this.panel2.Controls.Add((Control) this.cb35);
      this.panel2.Controls.Add((Control) this.cb34);
      this.panel2.Controls.Add((Control) this.cb33);
      this.panel2.Controls.Add((Control) this.cb32);
      this.panel2.Controls.Add((Control) this.cb31);
      this.panel2.Controls.Add((Control) this.bunifuImageButton4);
      this.panel2.Controls.Add((Control) this.cb29);
      this.panel2.Controls.Add((Control) this.cb28);
      this.panel2.Controls.Add((Control) this.cb27);
      this.panel2.Controls.Add((Control) this.cb26);
      this.panel2.Controls.Add((Control) this.cb25);
      this.panel2.Controls.Add((Control) this.cb24);
      this.panel2.Controls.Add((Control) this.cb23);
      this.panel2.Controls.Add((Control) this.cb22);
      this.panel2.Controls.Add((Control) this.cb21);
      this.panel2.Controls.Add((Control) this.bunifuImageButton3);
      this.panel2.Controls.Add((Control) this.cb19);
      this.panel2.Controls.Add((Control) this.cb18);
      this.panel2.Controls.Add((Control) this.cb17);
      this.panel2.Controls.Add((Control) this.cb16);
      this.panel2.Controls.Add((Control) this.cb15);
      this.panel2.Controls.Add((Control) this.cb14);
      this.panel2.Controls.Add((Control) this.cb13);
      this.panel2.Controls.Add((Control) this.cb12);
      this.panel2.Controls.Add((Control) this.cb11);
      this.panel2.Controls.Add((Control) this.bunifuImageButton2);
      this.panel2.Controls.Add((Control) this.cb09);
      this.panel2.Controls.Add((Control) this.cb08);
      this.panel2.Controls.Add((Control) this.cb07);
      this.panel2.Controls.Add((Control) this.cb06);
      this.panel2.Controls.Add((Control) this.cb05);
      this.panel2.Controls.Add((Control) this.cb04);
      this.panel2.Controls.Add((Control) this.cb03);
      this.panel2.Controls.Add((Control) this.cb02);
      this.panel2.Controls.Add((Control) this.cb01);
      this.panel2.Controls.Add((Control) this.bunifuImageButton1);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.txtGialapngaychuara);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.txtBiendongay);
      this.panel2.Controls.Add((Control) this.label13);
      this.panel2.Controls.Add((Control) this.btnThongke);
      this.panel2.Controls.Add((Control) this.dtNgayXem);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.panel2.Location = new Point(0, 0);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 181);
      this.panel2.TabIndex = 1;
      this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
      this.label6.BackColor = Color.WhiteSmoke;
      this.label6.Font = new Font("Arial", 11.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 163);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(5, 158);
      this.label6.Name = "label6";
      this.label6.Size = new Size(72, 18);
      this.label6.TabIndex = 124;
      this.label6.Text = "☞ Gợi ý :";
      this.label6.TextAlign = ContentAlignment.MiddleLeft;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 11.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 163);
      this.label5.ForeColor = Color.DimGray;
      this.label5.Location = new Point(6, 161);
      this.label5.Name = "label5";
      this.label5.Size = new Size(893, 17);
      this.label5.TabIndex = 31;
      this.label5.Text = "                  Giả lập ngày chưa ra giúp cho việc nhìn nhận lô tô được tổng quan hơn, dự đoán khung được chuẩn xác hơn, tránh xa bờ !!!!!";
      this.btnTronhet.BackColor = Color.Teal;
      this.btnTronhet.Cursor = Cursors.Hand;
      this.btnTronhet.FlatStyle = FlatStyle.Flat;
      this.btnTronhet.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnTronhet.ForeColor = Color.White;
      this.btnTronhet.Location = new Point(718, 5);
      this.btnTronhet.Margin = new Padding(3, 0, 3, 0);
      this.btnTronhet.Name = "btnTronhet";
      this.btnTronhet.Size = new Size(77, 24);
      this.btnTronhet.TabIndex = 3;
      this.btnTronhet.Text = "Chọn hết";
      this.btnTronhet.TextAlign = ContentAlignment.TopCenter;
      this.btnTronhet.UseVisualStyleBackColor = false;
      this.btnTronhet.Click += new EventHandler(this.btnTronhet_Click);
      this.cb90.AutoSize = true;
      this.cb90.BackColor = Color.White;
      this.cb90.Cursor = Cursors.Hand;
      this.cb90.FlatStyle = FlatStyle.Flat;
      this.cb90.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb90.ForeColor = Color.DimGray;
      this.cb90.Location = new Point(492, 135);
      this.cb90.Name = "cb90";
      this.cb90.Size = new Size(38, 20);
      this.cb90.TabIndex = 95;
      this.cb90.Text = "90";
      this.cb90.UseVisualStyleBackColor = false;
      this.cb90.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb90.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb90.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb70.AutoSize = true;
      this.cb70.BackColor = Color.White;
      this.cb70.Cursor = Cursors.Hand;
      this.cb70.FlatStyle = FlatStyle.Flat;
      this.cb70.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb70.ForeColor = Color.DimGray;
      this.cb70.Location = new Point(492, 111);
      this.cb70.Name = "cb70";
      this.cb70.Size = new Size(38, 20);
      this.cb70.TabIndex = 75;
      this.cb70.Text = "70";
      this.cb70.UseVisualStyleBackColor = false;
      this.cb70.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb70.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb70.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb50.AutoSize = true;
      this.cb50.BackColor = Color.White;
      this.cb50.Cursor = Cursors.Hand;
      this.cb50.FlatStyle = FlatStyle.Flat;
      this.cb50.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb50.ForeColor = Color.DimGray;
      this.cb50.Location = new Point(492, 87);
      this.cb50.Name = "cb50";
      this.cb50.Size = new Size(38, 20);
      this.cb50.TabIndex = 55;
      this.cb50.Text = "50";
      this.cb50.UseVisualStyleBackColor = false;
      this.cb50.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb50.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb50.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb30.AutoSize = true;
      this.cb30.BackColor = Color.White;
      this.cb30.Cursor = Cursors.Hand;
      this.cb30.FlatStyle = FlatStyle.Flat;
      this.cb30.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb30.ForeColor = Color.DimGray;
      this.cb30.Location = new Point(492, 63);
      this.cb30.Name = "cb30";
      this.cb30.Size = new Size(38, 20);
      this.cb30.TabIndex = 35;
      this.cb30.Text = "30";
      this.cb30.UseVisualStyleBackColor = false;
      this.cb30.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb30.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb30.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb10.AutoSize = true;
      this.cb10.BackColor = Color.White;
      this.cb10.Cursor = Cursors.Hand;
      this.cb10.FlatStyle = FlatStyle.Flat;
      this.cb10.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb10.ForeColor = Color.DimGray;
      this.cb10.Location = new Point(492, 39);
      this.cb10.Name = "cb10";
      this.cb10.Size = new Size(38, 20);
      this.cb10.TabIndex = 15;
      this.cb10.Text = "10";
      this.cb10.UseVisualStyleBackColor = false;
      this.cb10.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb10.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb10.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb80.AutoSize = true;
      this.cb80.BackColor = Color.White;
      this.cb80.Cursor = Cursors.Hand;
      this.cb80.FlatStyle = FlatStyle.Flat;
      this.cb80.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb80.ForeColor = Color.DimGray;
      this.cb80.Location = new Point(31, 135);
      this.cb80.Name = "cb80";
      this.cb80.Size = new Size(38, 20);
      this.cb80.TabIndex = 85;
      this.cb80.Text = "80";
      this.cb80.UseVisualStyleBackColor = false;
      this.cb80.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb80.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb80.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb60.AutoSize = true;
      this.cb60.BackColor = Color.White;
      this.cb60.Cursor = Cursors.Hand;
      this.cb60.FlatStyle = FlatStyle.Flat;
      this.cb60.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb60.ForeColor = Color.DimGray;
      this.cb60.Location = new Point(31, 111);
      this.cb60.Name = "cb60";
      this.cb60.Size = new Size(38, 20);
      this.cb60.TabIndex = 65;
      this.cb60.Text = "60";
      this.cb60.UseVisualStyleBackColor = false;
      this.cb60.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb60.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb60.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb40.AutoSize = true;
      this.cb40.BackColor = Color.White;
      this.cb40.Cursor = Cursors.Hand;
      this.cb40.FlatStyle = FlatStyle.Flat;
      this.cb40.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb40.ForeColor = Color.DimGray;
      this.cb40.Location = new Point(31, 87);
      this.cb40.Name = "cb40";
      this.cb40.Size = new Size(38, 20);
      this.cb40.TabIndex = 45;
      this.cb40.Text = "40";
      this.cb40.UseVisualStyleBackColor = false;
      this.cb40.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb40.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb40.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb20.AutoSize = true;
      this.cb20.BackColor = Color.White;
      this.cb20.Cursor = Cursors.Hand;
      this.cb20.FlatStyle = FlatStyle.Flat;
      this.cb20.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb20.ForeColor = Color.DimGray;
      this.cb20.Location = new Point(31, 63);
      this.cb20.Name = "cb20";
      this.cb20.Size = new Size(38, 20);
      this.cb20.TabIndex = 25;
      this.cb20.Text = "20";
      this.cb20.UseVisualStyleBackColor = false;
      this.cb20.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb20.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb20.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb00.AutoSize = true;
      this.cb00.BackColor = Color.White;
      this.cb00.Cursor = Cursors.Hand;
      this.cb00.FlatStyle = FlatStyle.Flat;
      this.cb00.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb00.ForeColor = Color.DimGray;
      this.cb00.Location = new Point(31, 39);
      this.cb00.Name = "cb00";
      this.cb00.Size = new Size(38, 20);
      this.cb00.TabIndex = 5;
      this.cb00.Text = "00";
      this.cb00.UseVisualStyleBackColor = false;
      this.cb00.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb00.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb00.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb99.AutoSize = true;
      this.cb99.BackColor = Color.White;
      this.cb99.Cursor = Cursors.Hand;
      this.cb99.FlatStyle = FlatStyle.Flat;
      this.cb99.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb99.ForeColor = Color.DimGray;
      this.cb99.Location = new Point(870, 135);
      this.cb99.Name = "cb99";
      this.cb99.Size = new Size(38, 20);
      this.cb99.TabIndex = 104;
      this.cb99.Text = "99";
      this.cb99.UseVisualStyleBackColor = false;
      this.cb99.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb99.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb99.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb98.AutoSize = true;
      this.cb98.BackColor = Color.White;
      this.cb98.Cursor = Cursors.Hand;
      this.cb98.FlatStyle = FlatStyle.Flat;
      this.cb98.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb98.ForeColor = Color.DimGray;
      this.cb98.Location = new Point(828, 135);
      this.cb98.Name = "cb98";
      this.cb98.Size = new Size(38, 20);
      this.cb98.TabIndex = 103;
      this.cb98.Text = "98";
      this.cb98.UseVisualStyleBackColor = false;
      this.cb98.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb98.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb98.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb97.AutoSize = true;
      this.cb97.BackColor = Color.White;
      this.cb97.Cursor = Cursors.Hand;
      this.cb97.FlatStyle = FlatStyle.Flat;
      this.cb97.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb97.ForeColor = Color.DimGray;
      this.cb97.Location = new Point(786, 135);
      this.cb97.Name = "cb97";
      this.cb97.Size = new Size(38, 20);
      this.cb97.TabIndex = 102;
      this.cb97.Text = "97";
      this.cb97.UseVisualStyleBackColor = false;
      this.cb97.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb97.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb97.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb96.AutoSize = true;
      this.cb96.BackColor = Color.White;
      this.cb96.Cursor = Cursors.Hand;
      this.cb96.FlatStyle = FlatStyle.Flat;
      this.cb96.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb96.ForeColor = Color.DimGray;
      this.cb96.Location = new Point(744, 135);
      this.cb96.Name = "cb96";
      this.cb96.Size = new Size(38, 20);
      this.cb96.TabIndex = 101;
      this.cb96.Text = "96";
      this.cb96.UseVisualStyleBackColor = false;
      this.cb96.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb96.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb96.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb95.AutoSize = true;
      this.cb95.BackColor = Color.White;
      this.cb95.Cursor = Cursors.Hand;
      this.cb95.FlatStyle = FlatStyle.Flat;
      this.cb95.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb95.ForeColor = Color.DimGray;
      this.cb95.Location = new Point(702, 135);
      this.cb95.Name = "cb95";
      this.cb95.Size = new Size(38, 20);
      this.cb95.TabIndex = 100;
      this.cb95.Text = "95";
      this.cb95.UseVisualStyleBackColor = false;
      this.cb95.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb95.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb95.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb94.AutoSize = true;
      this.cb94.BackColor = Color.White;
      this.cb94.Cursor = Cursors.Hand;
      this.cb94.FlatStyle = FlatStyle.Flat;
      this.cb94.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb94.ForeColor = Color.DimGray;
      this.cb94.Location = new Point(660, 135);
      this.cb94.Name = "cb94";
      this.cb94.Size = new Size(38, 20);
      this.cb94.TabIndex = 99;
      this.cb94.Text = "94";
      this.cb94.UseVisualStyleBackColor = false;
      this.cb94.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb94.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb94.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb93.AutoSize = true;
      this.cb93.BackColor = Color.White;
      this.cb93.Cursor = Cursors.Hand;
      this.cb93.FlatStyle = FlatStyle.Flat;
      this.cb93.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb93.ForeColor = Color.DimGray;
      this.cb93.Location = new Point(618, 135);
      this.cb93.Name = "cb93";
      this.cb93.Size = new Size(38, 20);
      this.cb93.TabIndex = 98;
      this.cb93.Text = "93";
      this.cb93.UseVisualStyleBackColor = false;
      this.cb93.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb93.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb93.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb92.AutoSize = true;
      this.cb92.BackColor = Color.White;
      this.cb92.Cursor = Cursors.Hand;
      this.cb92.FlatStyle = FlatStyle.Flat;
      this.cb92.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb92.ForeColor = Color.DimGray;
      this.cb92.Location = new Point(576, 135);
      this.cb92.Name = "cb92";
      this.cb92.Size = new Size(38, 20);
      this.cb92.TabIndex = 97;
      this.cb92.Text = "92";
      this.cb92.UseVisualStyleBackColor = false;
      this.cb92.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb92.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb92.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb91.AutoSize = true;
      this.cb91.BackColor = Color.White;
      this.cb91.Cursor = Cursors.Hand;
      this.cb91.FlatStyle = FlatStyle.Flat;
      this.cb91.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb91.ForeColor = Color.DimGray;
      this.cb91.Location = new Point(534, 135);
      this.cb91.Name = "cb91";
      this.cb91.Size = new Size(38, 20);
      this.cb91.TabIndex = 96;
      this.cb91.Text = "91";
      this.cb91.UseVisualStyleBackColor = false;
      this.cb91.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb91.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb91.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton10.BackColor = Color.Transparent;
      this.bunifuImageButton10.Cursor = Cursors.Hand;
      this.bunifuImageButton10.ErrorImage = (Image) null;
      this.bunifuImageButton10.Image = (Image) componentResourceManager.GetObject("bunifuImageButton10.Image");
      this.bunifuImageButton10.ImageActive = (Image) null;
      this.bunifuImageButton10.Location = new Point(465, 133);
      this.bunifuImageButton10.Name = "bunifuImageButton10";
      this.bunifuImageButton10.Size = new Size(22, 22);
      this.bunifuImageButton10.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton10.TabIndex = 123;
      this.bunifuImageButton10.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton10, " Trọn/Bỏ trọn hết đầu 9");
      this.bunifuImageButton10.Zoom = 8;
      this.bunifuImageButton10.Click += new EventHandler(this.bunifuImageButton10_Click);
      this.cb89.AutoSize = true;
      this.cb89.BackColor = Color.White;
      this.cb89.Cursor = Cursors.Hand;
      this.cb89.FlatStyle = FlatStyle.Flat;
      this.cb89.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb89.ForeColor = Color.DimGray;
      this.cb89.Location = new Point(409, 135);
      this.cb89.Name = "cb89";
      this.cb89.Size = new Size(38, 20);
      this.cb89.TabIndex = 94;
      this.cb89.Text = "89";
      this.cb89.UseVisualStyleBackColor = false;
      this.cb89.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb89.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb89.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb88.AutoSize = true;
      this.cb88.BackColor = Color.White;
      this.cb88.Cursor = Cursors.Hand;
      this.cb88.FlatStyle = FlatStyle.Flat;
      this.cb88.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb88.ForeColor = Color.DimGray;
      this.cb88.Location = new Point(367, 135);
      this.cb88.Name = "cb88";
      this.cb88.Size = new Size(38, 20);
      this.cb88.TabIndex = 93;
      this.cb88.Text = "88";
      this.cb88.UseVisualStyleBackColor = false;
      this.cb88.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb88.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb88.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb87.AutoSize = true;
      this.cb87.BackColor = Color.White;
      this.cb87.Cursor = Cursors.Hand;
      this.cb87.FlatStyle = FlatStyle.Flat;
      this.cb87.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb87.ForeColor = Color.DimGray;
      this.cb87.Location = new Point(325, 135);
      this.cb87.Name = "cb87";
      this.cb87.Size = new Size(38, 20);
      this.cb87.TabIndex = 92;
      this.cb87.Text = "87";
      this.cb87.UseVisualStyleBackColor = false;
      this.cb87.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb87.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb87.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb86.AutoSize = true;
      this.cb86.BackColor = Color.White;
      this.cb86.Cursor = Cursors.Hand;
      this.cb86.FlatStyle = FlatStyle.Flat;
      this.cb86.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb86.ForeColor = Color.DimGray;
      this.cb86.Location = new Point(283, 135);
      this.cb86.Name = "cb86";
      this.cb86.Size = new Size(38, 20);
      this.cb86.TabIndex = 91;
      this.cb86.Text = "86";
      this.cb86.UseVisualStyleBackColor = false;
      this.cb86.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb86.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb86.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb85.AutoSize = true;
      this.cb85.BackColor = Color.White;
      this.cb85.Cursor = Cursors.Hand;
      this.cb85.FlatStyle = FlatStyle.Flat;
      this.cb85.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb85.ForeColor = Color.DimGray;
      this.cb85.Location = new Point(241, 135);
      this.cb85.Name = "cb85";
      this.cb85.Size = new Size(38, 20);
      this.cb85.TabIndex = 90;
      this.cb85.Text = "85";
      this.cb85.UseVisualStyleBackColor = false;
      this.cb85.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb85.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb85.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb84.AutoSize = true;
      this.cb84.BackColor = Color.White;
      this.cb84.Cursor = Cursors.Hand;
      this.cb84.FlatStyle = FlatStyle.Flat;
      this.cb84.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb84.ForeColor = Color.DimGray;
      this.cb84.Location = new Point(199, 135);
      this.cb84.Name = "cb84";
      this.cb84.Size = new Size(38, 20);
      this.cb84.TabIndex = 89;
      this.cb84.Text = "84";
      this.cb84.UseVisualStyleBackColor = false;
      this.cb84.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb84.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb84.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb83.AutoSize = true;
      this.cb83.BackColor = Color.White;
      this.cb83.Cursor = Cursors.Hand;
      this.cb83.FlatStyle = FlatStyle.Flat;
      this.cb83.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb83.ForeColor = Color.DimGray;
      this.cb83.Location = new Point(157, 135);
      this.cb83.Name = "cb83";
      this.cb83.Size = new Size(38, 20);
      this.cb83.TabIndex = 88;
      this.cb83.Text = "83";
      this.cb83.UseVisualStyleBackColor = false;
      this.cb83.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb83.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb83.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb82.AutoSize = true;
      this.cb82.BackColor = Color.White;
      this.cb82.Cursor = Cursors.Hand;
      this.cb82.FlatStyle = FlatStyle.Flat;
      this.cb82.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb82.ForeColor = Color.DimGray;
      this.cb82.Location = new Point(115, 135);
      this.cb82.Name = "cb82";
      this.cb82.Size = new Size(38, 20);
      this.cb82.TabIndex = 87;
      this.cb82.Text = "82";
      this.cb82.UseVisualStyleBackColor = false;
      this.cb82.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb82.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb82.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb81.AutoSize = true;
      this.cb81.BackColor = Color.White;
      this.cb81.Cursor = Cursors.Hand;
      this.cb81.FlatStyle = FlatStyle.Flat;
      this.cb81.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb81.ForeColor = Color.DimGray;
      this.cb81.Location = new Point(73, 135);
      this.cb81.Name = "cb81";
      this.cb81.Size = new Size(38, 20);
      this.cb81.TabIndex = 86;
      this.cb81.Text = "81";
      this.cb81.UseVisualStyleBackColor = false;
      this.cb81.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb81.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb81.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton9.BackColor = Color.Transparent;
      this.bunifuImageButton9.Cursor = Cursors.Hand;
      this.bunifuImageButton9.ErrorImage = (Image) null;
      this.bunifuImageButton9.Image = (Image) componentResourceManager.GetObject("bunifuImageButton9.Image");
      this.bunifuImageButton9.ImageActive = (Image) null;
      this.bunifuImageButton9.Location = new Point(4, 133);
      this.bunifuImageButton9.Name = "bunifuImageButton9";
      this.bunifuImageButton9.Size = new Size(22, 22);
      this.bunifuImageButton9.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton9.TabIndex = 113;
      this.bunifuImageButton9.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton9, " Trọn/Bỏ trọn hết đầu 8");
      this.bunifuImageButton9.Zoom = 8;
      this.bunifuImageButton9.Click += new EventHandler(this.bunifuImageButton9_Click);
      this.cb79.AutoSize = true;
      this.cb79.BackColor = Color.White;
      this.cb79.Cursor = Cursors.Hand;
      this.cb79.FlatStyle = FlatStyle.Flat;
      this.cb79.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb79.ForeColor = Color.DimGray;
      this.cb79.Location = new Point(870, 111);
      this.cb79.Name = "cb79";
      this.cb79.Size = new Size(38, 20);
      this.cb79.TabIndex = 84;
      this.cb79.Text = "79";
      this.cb79.UseVisualStyleBackColor = false;
      this.cb79.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb79.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb79.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb78.AutoSize = true;
      this.cb78.BackColor = Color.White;
      this.cb78.Cursor = Cursors.Hand;
      this.cb78.FlatStyle = FlatStyle.Flat;
      this.cb78.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb78.ForeColor = Color.DimGray;
      this.cb78.Location = new Point(828, 111);
      this.cb78.Name = "cb78";
      this.cb78.Size = new Size(38, 20);
      this.cb78.TabIndex = 83;
      this.cb78.Text = "78";
      this.cb78.UseVisualStyleBackColor = false;
      this.cb78.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb78.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb78.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb77.AutoSize = true;
      this.cb77.BackColor = Color.White;
      this.cb77.Cursor = Cursors.Hand;
      this.cb77.FlatStyle = FlatStyle.Flat;
      this.cb77.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb77.ForeColor = Color.DimGray;
      this.cb77.Location = new Point(786, 111);
      this.cb77.Name = "cb77";
      this.cb77.Size = new Size(38, 20);
      this.cb77.TabIndex = 82;
      this.cb77.Text = "77";
      this.cb77.UseVisualStyleBackColor = false;
      this.cb77.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb77.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb77.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb76.AutoSize = true;
      this.cb76.BackColor = Color.White;
      this.cb76.Cursor = Cursors.Hand;
      this.cb76.FlatStyle = FlatStyle.Flat;
      this.cb76.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb76.ForeColor = Color.DimGray;
      this.cb76.Location = new Point(744, 111);
      this.cb76.Name = "cb76";
      this.cb76.Size = new Size(38, 20);
      this.cb76.TabIndex = 81;
      this.cb76.Text = "76";
      this.cb76.UseVisualStyleBackColor = false;
      this.cb76.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb76.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb76.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb75.AutoSize = true;
      this.cb75.BackColor = Color.White;
      this.cb75.Cursor = Cursors.Hand;
      this.cb75.FlatStyle = FlatStyle.Flat;
      this.cb75.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb75.ForeColor = Color.DimGray;
      this.cb75.Location = new Point(702, 111);
      this.cb75.Name = "cb75";
      this.cb75.Size = new Size(38, 20);
      this.cb75.TabIndex = 80;
      this.cb75.Text = "75";
      this.cb75.UseVisualStyleBackColor = false;
      this.cb75.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb75.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb75.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb74.AutoSize = true;
      this.cb74.BackColor = Color.White;
      this.cb74.Cursor = Cursors.Hand;
      this.cb74.FlatStyle = FlatStyle.Flat;
      this.cb74.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb74.ForeColor = Color.DimGray;
      this.cb74.Location = new Point(660, 111);
      this.cb74.Name = "cb74";
      this.cb74.Size = new Size(38, 20);
      this.cb74.TabIndex = 79;
      this.cb74.Text = "74";
      this.cb74.UseVisualStyleBackColor = false;
      this.cb74.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb74.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb74.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb73.AutoSize = true;
      this.cb73.BackColor = Color.White;
      this.cb73.Cursor = Cursors.Hand;
      this.cb73.FlatStyle = FlatStyle.Flat;
      this.cb73.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb73.ForeColor = Color.DimGray;
      this.cb73.Location = new Point(618, 111);
      this.cb73.Name = "cb73";
      this.cb73.Size = new Size(38, 20);
      this.cb73.TabIndex = 78;
      this.cb73.Text = "73";
      this.cb73.UseVisualStyleBackColor = false;
      this.cb73.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb73.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb73.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb72.AutoSize = true;
      this.cb72.BackColor = Color.White;
      this.cb72.Cursor = Cursors.Hand;
      this.cb72.FlatStyle = FlatStyle.Flat;
      this.cb72.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb72.ForeColor = Color.DimGray;
      this.cb72.Location = new Point(576, 111);
      this.cb72.Name = "cb72";
      this.cb72.Size = new Size(38, 20);
      this.cb72.TabIndex = 77;
      this.cb72.Text = "72";
      this.cb72.UseVisualStyleBackColor = false;
      this.cb72.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb72.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb72.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb71.AutoSize = true;
      this.cb71.BackColor = Color.White;
      this.cb71.Cursor = Cursors.Hand;
      this.cb71.FlatStyle = FlatStyle.Flat;
      this.cb71.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb71.ForeColor = Color.DimGray;
      this.cb71.Location = new Point(534, 111);
      this.cb71.Name = "cb71";
      this.cb71.Size = new Size(38, 20);
      this.cb71.TabIndex = 76;
      this.cb71.Text = "71";
      this.cb71.UseVisualStyleBackColor = false;
      this.cb71.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb71.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb71.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton8.BackColor = Color.Transparent;
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.ErrorImage = (Image) null;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(465, 109);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(22, 22);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 103;
      this.bunifuImageButton8.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton8, " Trọn/Bỏ trọn hết đầu 7");
      this.bunifuImageButton8.Zoom = 8;
      this.bunifuImageButton8.Click += new EventHandler(this.bunifuImageButton8_Click);
      this.cb69.AutoSize = true;
      this.cb69.BackColor = Color.White;
      this.cb69.Cursor = Cursors.Hand;
      this.cb69.FlatStyle = FlatStyle.Flat;
      this.cb69.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb69.ForeColor = Color.DimGray;
      this.cb69.Location = new Point(409, 111);
      this.cb69.Name = "cb69";
      this.cb69.Size = new Size(38, 20);
      this.cb69.TabIndex = 74;
      this.cb69.Text = "69";
      this.cb69.UseVisualStyleBackColor = false;
      this.cb69.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb69.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb69.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb68.AutoSize = true;
      this.cb68.BackColor = Color.White;
      this.cb68.Cursor = Cursors.Hand;
      this.cb68.FlatStyle = FlatStyle.Flat;
      this.cb68.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb68.ForeColor = Color.DimGray;
      this.cb68.Location = new Point(367, 111);
      this.cb68.Name = "cb68";
      this.cb68.Size = new Size(38, 20);
      this.cb68.TabIndex = 73;
      this.cb68.Text = "68";
      this.cb68.UseVisualStyleBackColor = false;
      this.cb68.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb68.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb68.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb67.AutoSize = true;
      this.cb67.BackColor = Color.White;
      this.cb67.Cursor = Cursors.Hand;
      this.cb67.FlatStyle = FlatStyle.Flat;
      this.cb67.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb67.ForeColor = Color.DimGray;
      this.cb67.Location = new Point(325, 111);
      this.cb67.Name = "cb67";
      this.cb67.Size = new Size(38, 20);
      this.cb67.TabIndex = 72;
      this.cb67.Text = "67";
      this.cb67.UseVisualStyleBackColor = false;
      this.cb67.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb67.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb67.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb66.AutoSize = true;
      this.cb66.BackColor = Color.White;
      this.cb66.Cursor = Cursors.Hand;
      this.cb66.FlatStyle = FlatStyle.Flat;
      this.cb66.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb66.ForeColor = Color.DimGray;
      this.cb66.Location = new Point(283, 111);
      this.cb66.Name = "cb66";
      this.cb66.Size = new Size(38, 20);
      this.cb66.TabIndex = 71;
      this.cb66.Text = "66";
      this.cb66.UseVisualStyleBackColor = false;
      this.cb66.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb66.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb66.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb65.AutoSize = true;
      this.cb65.BackColor = Color.White;
      this.cb65.Cursor = Cursors.Hand;
      this.cb65.FlatStyle = FlatStyle.Flat;
      this.cb65.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb65.ForeColor = Color.DimGray;
      this.cb65.Location = new Point(241, 111);
      this.cb65.Name = "cb65";
      this.cb65.Size = new Size(38, 20);
      this.cb65.TabIndex = 70;
      this.cb65.Text = "65";
      this.cb65.UseVisualStyleBackColor = false;
      this.cb65.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb65.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb65.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb64.AutoSize = true;
      this.cb64.BackColor = Color.White;
      this.cb64.Cursor = Cursors.Hand;
      this.cb64.FlatStyle = FlatStyle.Flat;
      this.cb64.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb64.ForeColor = Color.DimGray;
      this.cb64.Location = new Point(199, 111);
      this.cb64.Name = "cb64";
      this.cb64.Size = new Size(38, 20);
      this.cb64.TabIndex = 69;
      this.cb64.Text = "64";
      this.cb64.UseVisualStyleBackColor = false;
      this.cb64.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb64.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb64.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb63.AutoSize = true;
      this.cb63.BackColor = Color.White;
      this.cb63.Cursor = Cursors.Hand;
      this.cb63.FlatStyle = FlatStyle.Flat;
      this.cb63.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb63.ForeColor = Color.DimGray;
      this.cb63.Location = new Point(157, 111);
      this.cb63.Name = "cb63";
      this.cb63.Size = new Size(38, 20);
      this.cb63.TabIndex = 68;
      this.cb63.Text = "63";
      this.cb63.UseVisualStyleBackColor = false;
      this.cb63.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb63.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb63.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb62.AutoSize = true;
      this.cb62.BackColor = Color.White;
      this.cb62.Cursor = Cursors.Hand;
      this.cb62.FlatStyle = FlatStyle.Flat;
      this.cb62.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb62.ForeColor = Color.DimGray;
      this.cb62.Location = new Point(115, 111);
      this.cb62.Name = "cb62";
      this.cb62.Size = new Size(38, 20);
      this.cb62.TabIndex = 67;
      this.cb62.Text = "62";
      this.cb62.UseVisualStyleBackColor = false;
      this.cb62.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb62.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb62.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb61.AutoSize = true;
      this.cb61.BackColor = Color.White;
      this.cb61.Cursor = Cursors.Hand;
      this.cb61.FlatStyle = FlatStyle.Flat;
      this.cb61.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb61.ForeColor = Color.DimGray;
      this.cb61.Location = new Point(73, 111);
      this.cb61.Name = "cb61";
      this.cb61.Size = new Size(38, 20);
      this.cb61.TabIndex = 66;
      this.cb61.Text = "61";
      this.cb61.UseVisualStyleBackColor = false;
      this.cb61.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb61.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb61.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton7.BackColor = Color.Transparent;
      this.bunifuImageButton7.Cursor = Cursors.Hand;
      this.bunifuImageButton7.ErrorImage = (Image) null;
      this.bunifuImageButton7.Image = (Image) componentResourceManager.GetObject("bunifuImageButton7.Image");
      this.bunifuImageButton7.ImageActive = (Image) null;
      this.bunifuImageButton7.Location = new Point(4, 109);
      this.bunifuImageButton7.Name = "bunifuImageButton7";
      this.bunifuImageButton7.Size = new Size(22, 22);
      this.bunifuImageButton7.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton7.TabIndex = 93;
      this.bunifuImageButton7.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton7, " Trọn/Bỏ trọn hết đầu 6");
      this.bunifuImageButton7.Zoom = 8;
      this.bunifuImageButton7.Click += new EventHandler(this.bunifuImageButton7_Click);
      this.cb59.AutoSize = true;
      this.cb59.BackColor = Color.White;
      this.cb59.Cursor = Cursors.Hand;
      this.cb59.FlatStyle = FlatStyle.Flat;
      this.cb59.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb59.ForeColor = Color.DimGray;
      this.cb59.Location = new Point(870, 87);
      this.cb59.Name = "cb59";
      this.cb59.Size = new Size(38, 20);
      this.cb59.TabIndex = 64;
      this.cb59.Text = "59";
      this.cb59.UseVisualStyleBackColor = false;
      this.cb59.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb59.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb59.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb58.AutoSize = true;
      this.cb58.BackColor = Color.White;
      this.cb58.Cursor = Cursors.Hand;
      this.cb58.FlatStyle = FlatStyle.Flat;
      this.cb58.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb58.ForeColor = Color.DimGray;
      this.cb58.Location = new Point(828, 87);
      this.cb58.Name = "cb58";
      this.cb58.Size = new Size(38, 20);
      this.cb58.TabIndex = 63;
      this.cb58.Text = "58";
      this.cb58.UseVisualStyleBackColor = false;
      this.cb58.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb58.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb58.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb57.AutoSize = true;
      this.cb57.BackColor = Color.White;
      this.cb57.Cursor = Cursors.Hand;
      this.cb57.FlatStyle = FlatStyle.Flat;
      this.cb57.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb57.ForeColor = Color.DimGray;
      this.cb57.Location = new Point(786, 87);
      this.cb57.Name = "cb57";
      this.cb57.Size = new Size(38, 20);
      this.cb57.TabIndex = 62;
      this.cb57.Text = "57";
      this.cb57.UseVisualStyleBackColor = false;
      this.cb57.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb57.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb57.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb56.AutoSize = true;
      this.cb56.BackColor = Color.White;
      this.cb56.Cursor = Cursors.Hand;
      this.cb56.FlatStyle = FlatStyle.Flat;
      this.cb56.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb56.ForeColor = Color.DimGray;
      this.cb56.Location = new Point(744, 87);
      this.cb56.Name = "cb56";
      this.cb56.Size = new Size(38, 20);
      this.cb56.TabIndex = 61;
      this.cb56.Text = "56";
      this.cb56.UseVisualStyleBackColor = false;
      this.cb56.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb56.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb56.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb55.AutoSize = true;
      this.cb55.BackColor = Color.White;
      this.cb55.Cursor = Cursors.Hand;
      this.cb55.FlatStyle = FlatStyle.Flat;
      this.cb55.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb55.ForeColor = Color.DimGray;
      this.cb55.Location = new Point(702, 87);
      this.cb55.Name = "cb55";
      this.cb55.Size = new Size(38, 20);
      this.cb55.TabIndex = 60;
      this.cb55.Text = "55";
      this.cb55.UseVisualStyleBackColor = false;
      this.cb55.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb55.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb55.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb54.AutoSize = true;
      this.cb54.BackColor = Color.White;
      this.cb54.Cursor = Cursors.Hand;
      this.cb54.FlatStyle = FlatStyle.Flat;
      this.cb54.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb54.ForeColor = Color.DimGray;
      this.cb54.Location = new Point(660, 87);
      this.cb54.Name = "cb54";
      this.cb54.Size = new Size(38, 20);
      this.cb54.TabIndex = 59;
      this.cb54.Text = "54";
      this.cb54.UseVisualStyleBackColor = false;
      this.cb54.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb54.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb54.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb53.AutoSize = true;
      this.cb53.BackColor = Color.White;
      this.cb53.Cursor = Cursors.Hand;
      this.cb53.FlatStyle = FlatStyle.Flat;
      this.cb53.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb53.ForeColor = Color.DimGray;
      this.cb53.Location = new Point(618, 87);
      this.cb53.Name = "cb53";
      this.cb53.Size = new Size(38, 20);
      this.cb53.TabIndex = 58;
      this.cb53.Text = "53";
      this.cb53.UseVisualStyleBackColor = false;
      this.cb53.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb53.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb53.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb52.AutoSize = true;
      this.cb52.BackColor = Color.White;
      this.cb52.Cursor = Cursors.Hand;
      this.cb52.FlatStyle = FlatStyle.Flat;
      this.cb52.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb52.ForeColor = Color.DimGray;
      this.cb52.Location = new Point(576, 87);
      this.cb52.Name = "cb52";
      this.cb52.Size = new Size(38, 20);
      this.cb52.TabIndex = 57;
      this.cb52.Text = "52";
      this.cb52.UseVisualStyleBackColor = false;
      this.cb52.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb52.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb52.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb51.AutoSize = true;
      this.cb51.BackColor = Color.White;
      this.cb51.Cursor = Cursors.Hand;
      this.cb51.FlatStyle = FlatStyle.Flat;
      this.cb51.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb51.ForeColor = Color.DimGray;
      this.cb51.Location = new Point(534, 87);
      this.cb51.Name = "cb51";
      this.cb51.Size = new Size(38, 20);
      this.cb51.TabIndex = 56;
      this.cb51.Text = "51";
      this.cb51.UseVisualStyleBackColor = false;
      this.cb51.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb51.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb51.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton6.BackColor = Color.Transparent;
      this.bunifuImageButton6.Cursor = Cursors.Hand;
      this.bunifuImageButton6.ErrorImage = (Image) null;
      this.bunifuImageButton6.Image = (Image) componentResourceManager.GetObject("bunifuImageButton6.Image");
      this.bunifuImageButton6.ImageActive = (Image) null;
      this.bunifuImageButton6.Location = new Point(465, 85);
      this.bunifuImageButton6.Name = "bunifuImageButton6";
      this.bunifuImageButton6.Size = new Size(22, 22);
      this.bunifuImageButton6.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton6.TabIndex = 83;
      this.bunifuImageButton6.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton6, " Trọn/Bỏ trọn hết đầu 5");
      this.bunifuImageButton6.Zoom = 8;
      this.bunifuImageButton6.Click += new EventHandler(this.bunifuImageButton6_Click);
      this.cb49.AutoSize = true;
      this.cb49.BackColor = Color.White;
      this.cb49.Cursor = Cursors.Hand;
      this.cb49.FlatStyle = FlatStyle.Flat;
      this.cb49.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb49.ForeColor = Color.DimGray;
      this.cb49.Location = new Point(409, 87);
      this.cb49.Name = "cb49";
      this.cb49.Size = new Size(38, 20);
      this.cb49.TabIndex = 54;
      this.cb49.Text = "49";
      this.cb49.UseVisualStyleBackColor = false;
      this.cb49.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb49.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb49.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb48.AutoSize = true;
      this.cb48.BackColor = Color.White;
      this.cb48.Cursor = Cursors.Hand;
      this.cb48.FlatStyle = FlatStyle.Flat;
      this.cb48.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb48.ForeColor = Color.DimGray;
      this.cb48.Location = new Point(367, 87);
      this.cb48.Name = "cb48";
      this.cb48.Size = new Size(38, 20);
      this.cb48.TabIndex = 53;
      this.cb48.Text = "48";
      this.cb48.UseVisualStyleBackColor = false;
      this.cb48.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb48.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb48.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb47.AutoSize = true;
      this.cb47.BackColor = Color.White;
      this.cb47.Cursor = Cursors.Hand;
      this.cb47.FlatStyle = FlatStyle.Flat;
      this.cb47.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb47.ForeColor = Color.DimGray;
      this.cb47.Location = new Point(325, 87);
      this.cb47.Name = "cb47";
      this.cb47.Size = new Size(38, 20);
      this.cb47.TabIndex = 52;
      this.cb47.Text = "47";
      this.cb47.UseVisualStyleBackColor = false;
      this.cb47.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb47.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb47.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb46.AutoSize = true;
      this.cb46.BackColor = Color.White;
      this.cb46.Cursor = Cursors.Hand;
      this.cb46.FlatStyle = FlatStyle.Flat;
      this.cb46.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb46.ForeColor = Color.DimGray;
      this.cb46.Location = new Point(283, 87);
      this.cb46.Name = "cb46";
      this.cb46.Size = new Size(38, 20);
      this.cb46.TabIndex = 51;
      this.cb46.Text = "46";
      this.cb46.UseVisualStyleBackColor = false;
      this.cb46.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb46.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb46.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb45.AutoSize = true;
      this.cb45.BackColor = Color.White;
      this.cb45.Cursor = Cursors.Hand;
      this.cb45.FlatStyle = FlatStyle.Flat;
      this.cb45.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb45.ForeColor = Color.DimGray;
      this.cb45.Location = new Point(241, 87);
      this.cb45.Name = "cb45";
      this.cb45.Size = new Size(38, 20);
      this.cb45.TabIndex = 50;
      this.cb45.Text = "45";
      this.cb45.UseVisualStyleBackColor = false;
      this.cb45.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb45.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb45.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb44.AutoSize = true;
      this.cb44.BackColor = Color.White;
      this.cb44.Cursor = Cursors.Hand;
      this.cb44.FlatStyle = FlatStyle.Flat;
      this.cb44.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb44.ForeColor = Color.DimGray;
      this.cb44.Location = new Point(199, 87);
      this.cb44.Name = "cb44";
      this.cb44.Size = new Size(38, 20);
      this.cb44.TabIndex = 49;
      this.cb44.Text = "44";
      this.cb44.UseVisualStyleBackColor = false;
      this.cb44.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb44.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb44.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb43.AutoSize = true;
      this.cb43.BackColor = Color.White;
      this.cb43.Cursor = Cursors.Hand;
      this.cb43.FlatStyle = FlatStyle.Flat;
      this.cb43.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb43.ForeColor = Color.DimGray;
      this.cb43.Location = new Point(157, 87);
      this.cb43.Name = "cb43";
      this.cb43.Size = new Size(38, 20);
      this.cb43.TabIndex = 48;
      this.cb43.Text = "43";
      this.cb43.UseVisualStyleBackColor = false;
      this.cb43.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb43.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb43.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb42.AutoSize = true;
      this.cb42.BackColor = Color.White;
      this.cb42.Cursor = Cursors.Hand;
      this.cb42.FlatStyle = FlatStyle.Flat;
      this.cb42.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb42.ForeColor = Color.DimGray;
      this.cb42.Location = new Point(115, 87);
      this.cb42.Name = "cb42";
      this.cb42.Size = new Size(38, 20);
      this.cb42.TabIndex = 47;
      this.cb42.Text = "42";
      this.cb42.UseVisualStyleBackColor = false;
      this.cb42.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb42.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb42.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb41.AutoSize = true;
      this.cb41.BackColor = Color.White;
      this.cb41.Cursor = Cursors.Hand;
      this.cb41.FlatStyle = FlatStyle.Flat;
      this.cb41.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb41.ForeColor = Color.DimGray;
      this.cb41.Location = new Point(73, 87);
      this.cb41.Name = "cb41";
      this.cb41.Size = new Size(38, 20);
      this.cb41.TabIndex = 46;
      this.cb41.Text = "41";
      this.cb41.UseVisualStyleBackColor = false;
      this.cb41.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb41.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb41.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton5.BackColor = Color.Transparent;
      this.bunifuImageButton5.Cursor = Cursors.Hand;
      this.bunifuImageButton5.ErrorImage = (Image) null;
      this.bunifuImageButton5.Image = (Image) componentResourceManager.GetObject("bunifuImageButton5.Image");
      this.bunifuImageButton5.ImageActive = (Image) null;
      this.bunifuImageButton5.Location = new Point(4, 85);
      this.bunifuImageButton5.Name = "bunifuImageButton5";
      this.bunifuImageButton5.Size = new Size(22, 22);
      this.bunifuImageButton5.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton5.TabIndex = 73;
      this.bunifuImageButton5.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton5, " Trọn/Bỏ trọn hết đầu 4");
      this.bunifuImageButton5.Zoom = 8;
      this.bunifuImageButton5.Click += new EventHandler(this.bunifuImageButton5_Click);
      this.cb39.AutoSize = true;
      this.cb39.BackColor = Color.White;
      this.cb39.Cursor = Cursors.Hand;
      this.cb39.FlatStyle = FlatStyle.Flat;
      this.cb39.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb39.ForeColor = Color.DimGray;
      this.cb39.Location = new Point(870, 63);
      this.cb39.Name = "cb39";
      this.cb39.Size = new Size(38, 20);
      this.cb39.TabIndex = 44;
      this.cb39.Text = "39";
      this.cb39.UseVisualStyleBackColor = false;
      this.cb39.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb39.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb39.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb38.AutoSize = true;
      this.cb38.BackColor = Color.White;
      this.cb38.Cursor = Cursors.Hand;
      this.cb38.FlatStyle = FlatStyle.Flat;
      this.cb38.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb38.ForeColor = Color.DimGray;
      this.cb38.Location = new Point(828, 63);
      this.cb38.Name = "cb38";
      this.cb38.Size = new Size(38, 20);
      this.cb38.TabIndex = 43;
      this.cb38.Text = "38";
      this.cb38.UseVisualStyleBackColor = false;
      this.cb38.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb38.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb38.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb37.AutoSize = true;
      this.cb37.BackColor = Color.White;
      this.cb37.Cursor = Cursors.Hand;
      this.cb37.FlatStyle = FlatStyle.Flat;
      this.cb37.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb37.ForeColor = Color.DimGray;
      this.cb37.Location = new Point(786, 63);
      this.cb37.Name = "cb37";
      this.cb37.Size = new Size(38, 20);
      this.cb37.TabIndex = 42;
      this.cb37.Text = "37";
      this.cb37.UseVisualStyleBackColor = false;
      this.cb37.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb37.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb37.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb36.AutoSize = true;
      this.cb36.BackColor = Color.White;
      this.cb36.Cursor = Cursors.Hand;
      this.cb36.FlatStyle = FlatStyle.Flat;
      this.cb36.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb36.ForeColor = Color.DimGray;
      this.cb36.Location = new Point(744, 63);
      this.cb36.Name = "cb36";
      this.cb36.Size = new Size(38, 20);
      this.cb36.TabIndex = 41;
      this.cb36.Text = "36";
      this.cb36.UseVisualStyleBackColor = false;
      this.cb36.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb36.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb36.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb35.AutoSize = true;
      this.cb35.BackColor = Color.White;
      this.cb35.Cursor = Cursors.Hand;
      this.cb35.FlatStyle = FlatStyle.Flat;
      this.cb35.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb35.ForeColor = Color.DimGray;
      this.cb35.Location = new Point(702, 63);
      this.cb35.Name = "cb35";
      this.cb35.Size = new Size(38, 20);
      this.cb35.TabIndex = 40;
      this.cb35.Text = "35";
      this.cb35.UseVisualStyleBackColor = false;
      this.cb35.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb35.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb35.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb34.AutoSize = true;
      this.cb34.BackColor = Color.White;
      this.cb34.Cursor = Cursors.Hand;
      this.cb34.FlatStyle = FlatStyle.Flat;
      this.cb34.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb34.ForeColor = Color.DimGray;
      this.cb34.Location = new Point(660, 63);
      this.cb34.Name = "cb34";
      this.cb34.Size = new Size(38, 20);
      this.cb34.TabIndex = 39;
      this.cb34.Text = "34";
      this.cb34.UseVisualStyleBackColor = false;
      this.cb34.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb34.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb34.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb33.AutoSize = true;
      this.cb33.BackColor = Color.White;
      this.cb33.Cursor = Cursors.Hand;
      this.cb33.FlatStyle = FlatStyle.Flat;
      this.cb33.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb33.ForeColor = Color.DimGray;
      this.cb33.Location = new Point(618, 63);
      this.cb33.Name = "cb33";
      this.cb33.Size = new Size(38, 20);
      this.cb33.TabIndex = 38;
      this.cb33.Text = "33";
      this.cb33.UseVisualStyleBackColor = false;
      this.cb33.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb33.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb33.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb32.AutoSize = true;
      this.cb32.BackColor = Color.White;
      this.cb32.Cursor = Cursors.Hand;
      this.cb32.FlatStyle = FlatStyle.Flat;
      this.cb32.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb32.ForeColor = Color.DimGray;
      this.cb32.Location = new Point(576, 63);
      this.cb32.Name = "cb32";
      this.cb32.Size = new Size(38, 20);
      this.cb32.TabIndex = 37;
      this.cb32.Text = "32";
      this.cb32.UseVisualStyleBackColor = false;
      this.cb32.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb32.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb32.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb31.AutoSize = true;
      this.cb31.BackColor = Color.White;
      this.cb31.Cursor = Cursors.Hand;
      this.cb31.FlatStyle = FlatStyle.Flat;
      this.cb31.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb31.ForeColor = Color.DimGray;
      this.cb31.Location = new Point(534, 63);
      this.cb31.Name = "cb31";
      this.cb31.Size = new Size(38, 20);
      this.cb31.TabIndex = 36;
      this.cb31.Text = "31";
      this.cb31.UseVisualStyleBackColor = false;
      this.cb31.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb31.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb31.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton4.BackColor = Color.Transparent;
      this.bunifuImageButton4.Cursor = Cursors.Hand;
      this.bunifuImageButton4.ErrorImage = (Image) null;
      this.bunifuImageButton4.Image = (Image) componentResourceManager.GetObject("bunifuImageButton4.Image");
      this.bunifuImageButton4.ImageActive = (Image) null;
      this.bunifuImageButton4.Location = new Point(465, 61);
      this.bunifuImageButton4.Name = "bunifuImageButton4";
      this.bunifuImageButton4.Size = new Size(22, 22);
      this.bunifuImageButton4.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton4.TabIndex = 63;
      this.bunifuImageButton4.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton4, " Trọn/Bỏ trọn hết đầu 3");
      this.bunifuImageButton4.Zoom = 8;
      this.bunifuImageButton4.Click += new EventHandler(this.bunifuImageButton4_Click);
      this.cb29.AutoSize = true;
      this.cb29.BackColor = Color.White;
      this.cb29.Cursor = Cursors.Hand;
      this.cb29.FlatStyle = FlatStyle.Flat;
      this.cb29.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb29.ForeColor = Color.DimGray;
      this.cb29.Location = new Point(409, 63);
      this.cb29.Name = "cb29";
      this.cb29.Size = new Size(38, 20);
      this.cb29.TabIndex = 34;
      this.cb29.Text = "29";
      this.cb29.UseVisualStyleBackColor = false;
      this.cb29.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb29.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb29.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb28.AutoSize = true;
      this.cb28.BackColor = Color.White;
      this.cb28.Cursor = Cursors.Hand;
      this.cb28.FlatStyle = FlatStyle.Flat;
      this.cb28.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb28.ForeColor = Color.DimGray;
      this.cb28.Location = new Point(367, 63);
      this.cb28.Name = "cb28";
      this.cb28.Size = new Size(38, 20);
      this.cb28.TabIndex = 33;
      this.cb28.Text = "28";
      this.cb28.UseVisualStyleBackColor = false;
      this.cb28.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb28.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb28.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb27.AutoSize = true;
      this.cb27.BackColor = Color.White;
      this.cb27.Cursor = Cursors.Hand;
      this.cb27.FlatStyle = FlatStyle.Flat;
      this.cb27.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb27.ForeColor = Color.DimGray;
      this.cb27.Location = new Point(325, 63);
      this.cb27.Name = "cb27";
      this.cb27.Size = new Size(38, 20);
      this.cb27.TabIndex = 32;
      this.cb27.Text = "27";
      this.cb27.UseVisualStyleBackColor = false;
      this.cb27.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb27.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb27.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb26.AutoSize = true;
      this.cb26.BackColor = Color.White;
      this.cb26.Cursor = Cursors.Hand;
      this.cb26.FlatStyle = FlatStyle.Flat;
      this.cb26.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb26.ForeColor = Color.DimGray;
      this.cb26.Location = new Point(283, 63);
      this.cb26.Name = "cb26";
      this.cb26.Size = new Size(38, 20);
      this.cb26.TabIndex = 31;
      this.cb26.Text = "26";
      this.cb26.UseVisualStyleBackColor = false;
      this.cb26.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb26.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb26.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb25.AutoSize = true;
      this.cb25.BackColor = Color.White;
      this.cb25.Cursor = Cursors.Hand;
      this.cb25.FlatStyle = FlatStyle.Flat;
      this.cb25.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb25.ForeColor = Color.DimGray;
      this.cb25.Location = new Point(241, 63);
      this.cb25.Name = "cb25";
      this.cb25.Size = new Size(38, 20);
      this.cb25.TabIndex = 30;
      this.cb25.Text = "25";
      this.cb25.UseVisualStyleBackColor = false;
      this.cb25.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb25.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb25.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb24.AutoSize = true;
      this.cb24.BackColor = Color.White;
      this.cb24.Cursor = Cursors.Hand;
      this.cb24.FlatStyle = FlatStyle.Flat;
      this.cb24.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb24.ForeColor = Color.DimGray;
      this.cb24.Location = new Point(199, 63);
      this.cb24.Name = "cb24";
      this.cb24.Size = new Size(38, 20);
      this.cb24.TabIndex = 29;
      this.cb24.Text = "24";
      this.cb24.UseVisualStyleBackColor = false;
      this.cb24.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb24.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb24.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb23.AutoSize = true;
      this.cb23.BackColor = Color.White;
      this.cb23.Cursor = Cursors.Hand;
      this.cb23.FlatStyle = FlatStyle.Flat;
      this.cb23.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb23.ForeColor = Color.DimGray;
      this.cb23.Location = new Point(157, 63);
      this.cb23.Name = "cb23";
      this.cb23.Size = new Size(38, 20);
      this.cb23.TabIndex = 28;
      this.cb23.Text = "23";
      this.cb23.UseVisualStyleBackColor = false;
      this.cb23.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb23.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb23.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb22.AutoSize = true;
      this.cb22.BackColor = Color.White;
      this.cb22.Cursor = Cursors.Hand;
      this.cb22.FlatStyle = FlatStyle.Flat;
      this.cb22.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb22.ForeColor = Color.DimGray;
      this.cb22.Location = new Point(115, 63);
      this.cb22.Name = "cb22";
      this.cb22.Size = new Size(38, 20);
      this.cb22.TabIndex = 27;
      this.cb22.Text = "22";
      this.cb22.UseVisualStyleBackColor = false;
      this.cb22.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb22.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb22.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb21.AutoSize = true;
      this.cb21.BackColor = Color.White;
      this.cb21.Cursor = Cursors.Hand;
      this.cb21.FlatStyle = FlatStyle.Flat;
      this.cb21.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb21.ForeColor = Color.DimGray;
      this.cb21.Location = new Point(73, 63);
      this.cb21.Name = "cb21";
      this.cb21.Size = new Size(38, 20);
      this.cb21.TabIndex = 26;
      this.cb21.Text = "21";
      this.cb21.UseVisualStyleBackColor = false;
      this.cb21.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb21.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb21.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton3.BackColor = Color.Transparent;
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.ErrorImage = (Image) null;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(4, 61);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(22, 22);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 53;
      this.bunifuImageButton3.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton3, " Trọn/Bỏ trọn hết đầu 2");
      this.bunifuImageButton3.Zoom = 8;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.cb19.AutoSize = true;
      this.cb19.BackColor = Color.White;
      this.cb19.Cursor = Cursors.Hand;
      this.cb19.FlatStyle = FlatStyle.Flat;
      this.cb19.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb19.ForeColor = Color.DimGray;
      this.cb19.Location = new Point(869, 39);
      this.cb19.Name = "cb19";
      this.cb19.Size = new Size(38, 20);
      this.cb19.TabIndex = 24;
      this.cb19.Text = "19";
      this.cb19.UseVisualStyleBackColor = false;
      this.cb19.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb19.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb19.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb18.AutoSize = true;
      this.cb18.BackColor = Color.White;
      this.cb18.Cursor = Cursors.Hand;
      this.cb18.FlatStyle = FlatStyle.Flat;
      this.cb18.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb18.ForeColor = Color.DimGray;
      this.cb18.Location = new Point(827, 39);
      this.cb18.Name = "cb18";
      this.cb18.Size = new Size(38, 20);
      this.cb18.TabIndex = 23;
      this.cb18.Text = "18";
      this.cb18.UseVisualStyleBackColor = false;
      this.cb18.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb18.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb18.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb17.AutoSize = true;
      this.cb17.BackColor = Color.White;
      this.cb17.Cursor = Cursors.Hand;
      this.cb17.FlatStyle = FlatStyle.Flat;
      this.cb17.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb17.ForeColor = Color.DimGray;
      this.cb17.Location = new Point(785, 39);
      this.cb17.Name = "cb17";
      this.cb17.Size = new Size(38, 20);
      this.cb17.TabIndex = 22;
      this.cb17.Text = "17";
      this.cb17.UseVisualStyleBackColor = false;
      this.cb17.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb17.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb17.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb16.AutoSize = true;
      this.cb16.BackColor = Color.White;
      this.cb16.Cursor = Cursors.Hand;
      this.cb16.FlatStyle = FlatStyle.Flat;
      this.cb16.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb16.ForeColor = Color.DimGray;
      this.cb16.Location = new Point(743, 39);
      this.cb16.Name = "cb16";
      this.cb16.Size = new Size(38, 20);
      this.cb16.TabIndex = 21;
      this.cb16.Text = "16";
      this.cb16.UseVisualStyleBackColor = false;
      this.cb16.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb16.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb16.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb15.AutoSize = true;
      this.cb15.BackColor = Color.White;
      this.cb15.Cursor = Cursors.Hand;
      this.cb15.FlatStyle = FlatStyle.Flat;
      this.cb15.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb15.ForeColor = Color.DimGray;
      this.cb15.Location = new Point(701, 39);
      this.cb15.Name = "cb15";
      this.cb15.Size = new Size(38, 20);
      this.cb15.TabIndex = 20;
      this.cb15.Text = "15";
      this.cb15.UseVisualStyleBackColor = false;
      this.cb15.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb15.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb15.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb14.AutoSize = true;
      this.cb14.BackColor = Color.White;
      this.cb14.Cursor = Cursors.Hand;
      this.cb14.FlatStyle = FlatStyle.Flat;
      this.cb14.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb14.ForeColor = Color.DimGray;
      this.cb14.Location = new Point(659, 39);
      this.cb14.Name = "cb14";
      this.cb14.Size = new Size(38, 20);
      this.cb14.TabIndex = 19;
      this.cb14.Text = "14";
      this.cb14.UseVisualStyleBackColor = false;
      this.cb14.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb14.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb14.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb13.AutoSize = true;
      this.cb13.BackColor = Color.White;
      this.cb13.Cursor = Cursors.Hand;
      this.cb13.FlatStyle = FlatStyle.Flat;
      this.cb13.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb13.ForeColor = Color.DimGray;
      this.cb13.Location = new Point(617, 39);
      this.cb13.Name = "cb13";
      this.cb13.Size = new Size(38, 20);
      this.cb13.TabIndex = 18;
      this.cb13.Text = "13";
      this.cb13.UseVisualStyleBackColor = false;
      this.cb13.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb13.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb13.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb12.AutoSize = true;
      this.cb12.BackColor = Color.White;
      this.cb12.Cursor = Cursors.Hand;
      this.cb12.FlatStyle = FlatStyle.Flat;
      this.cb12.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb12.ForeColor = Color.DimGray;
      this.cb12.Location = new Point(575, 39);
      this.cb12.Name = "cb12";
      this.cb12.Size = new Size(38, 20);
      this.cb12.TabIndex = 17;
      this.cb12.Text = "12";
      this.cb12.UseVisualStyleBackColor = false;
      this.cb12.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb12.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb12.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb11.AutoSize = true;
      this.cb11.BackColor = Color.White;
      this.cb11.Cursor = Cursors.Hand;
      this.cb11.FlatStyle = FlatStyle.Flat;
      this.cb11.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb11.ForeColor = Color.DimGray;
      this.cb11.Location = new Point(534, 39);
      this.cb11.Name = "cb11";
      this.cb11.Size = new Size(37, 20);
      this.cb11.TabIndex = 16;
      this.cb11.Text = "11";
      this.cb11.UseVisualStyleBackColor = false;
      this.cb11.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb11.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb11.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton2.BackColor = Color.Transparent;
      this.bunifuImageButton2.Cursor = Cursors.Hand;
      this.bunifuImageButton2.ErrorImage = (Image) null;
      this.bunifuImageButton2.Image = (Image) componentResourceManager.GetObject("bunifuImageButton2.Image");
      this.bunifuImageButton2.ImageActive = (Image) null;
      this.bunifuImageButton2.Location = new Point(465, 37);
      this.bunifuImageButton2.Name = "bunifuImageButton2";
      this.bunifuImageButton2.Size = new Size(22, 22);
      this.bunifuImageButton2.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton2.TabIndex = 43;
      this.bunifuImageButton2.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton2, " Trọn/Bỏ trọn hết đầu 1");
      this.bunifuImageButton2.Zoom = 8;
      this.bunifuImageButton2.Click += new EventHandler(this.bunifuImageButton2_Click);
      this.cb09.AutoSize = true;
      this.cb09.BackColor = Color.White;
      this.cb09.Cursor = Cursors.Hand;
      this.cb09.FlatStyle = FlatStyle.Flat;
      this.cb09.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb09.ForeColor = Color.DimGray;
      this.cb09.Location = new Point(409, 39);
      this.cb09.Name = "cb09";
      this.cb09.Size = new Size(38, 20);
      this.cb09.TabIndex = 14;
      this.cb09.Text = "09";
      this.cb09.UseVisualStyleBackColor = false;
      this.cb09.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb09.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb09.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb08.AutoSize = true;
      this.cb08.BackColor = Color.White;
      this.cb08.Cursor = Cursors.Hand;
      this.cb08.FlatStyle = FlatStyle.Flat;
      this.cb08.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb08.ForeColor = Color.DimGray;
      this.cb08.Location = new Point(367, 39);
      this.cb08.Name = "cb08";
      this.cb08.Size = new Size(38, 20);
      this.cb08.TabIndex = 13;
      this.cb08.Text = "08";
      this.cb08.UseVisualStyleBackColor = false;
      this.cb08.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb08.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb08.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb07.AutoSize = true;
      this.cb07.BackColor = Color.White;
      this.cb07.Cursor = Cursors.Hand;
      this.cb07.FlatStyle = FlatStyle.Flat;
      this.cb07.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb07.ForeColor = Color.DimGray;
      this.cb07.Location = new Point(325, 39);
      this.cb07.Name = "cb07";
      this.cb07.Size = new Size(38, 20);
      this.cb07.TabIndex = 12;
      this.cb07.Text = "07";
      this.cb07.UseVisualStyleBackColor = false;
      this.cb07.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb07.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb07.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb06.AutoSize = true;
      this.cb06.BackColor = Color.White;
      this.cb06.Cursor = Cursors.Hand;
      this.cb06.FlatStyle = FlatStyle.Flat;
      this.cb06.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb06.ForeColor = Color.DimGray;
      this.cb06.Location = new Point(283, 39);
      this.cb06.Name = "cb06";
      this.cb06.Size = new Size(38, 20);
      this.cb06.TabIndex = 11;
      this.cb06.Text = "06";
      this.cb06.UseVisualStyleBackColor = false;
      this.cb06.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb06.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb06.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb05.AutoSize = true;
      this.cb05.BackColor = Color.White;
      this.cb05.Cursor = Cursors.Hand;
      this.cb05.FlatStyle = FlatStyle.Flat;
      this.cb05.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb05.ForeColor = Color.DimGray;
      this.cb05.Location = new Point(241, 39);
      this.cb05.Name = "cb05";
      this.cb05.Size = new Size(38, 20);
      this.cb05.TabIndex = 10;
      this.cb05.Text = "05";
      this.cb05.UseVisualStyleBackColor = false;
      this.cb05.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb05.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb05.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb04.AutoSize = true;
      this.cb04.BackColor = Color.White;
      this.cb04.Cursor = Cursors.Hand;
      this.cb04.FlatStyle = FlatStyle.Flat;
      this.cb04.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb04.ForeColor = Color.DimGray;
      this.cb04.Location = new Point(199, 39);
      this.cb04.Name = "cb04";
      this.cb04.Size = new Size(38, 20);
      this.cb04.TabIndex = 9;
      this.cb04.Text = "04";
      this.cb04.UseVisualStyleBackColor = false;
      this.cb04.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb04.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb04.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb03.AutoSize = true;
      this.cb03.BackColor = Color.White;
      this.cb03.Cursor = Cursors.Hand;
      this.cb03.FlatStyle = FlatStyle.Flat;
      this.cb03.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb03.ForeColor = Color.DimGray;
      this.cb03.Location = new Point(157, 39);
      this.cb03.Name = "cb03";
      this.cb03.Size = new Size(38, 20);
      this.cb03.TabIndex = 8;
      this.cb03.Text = "03";
      this.cb03.UseVisualStyleBackColor = false;
      this.cb03.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb03.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb03.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb02.AutoSize = true;
      this.cb02.BackColor = Color.White;
      this.cb02.Cursor = Cursors.Hand;
      this.cb02.FlatStyle = FlatStyle.Flat;
      this.cb02.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb02.ForeColor = Color.DimGray;
      this.cb02.Location = new Point(115, 39);
      this.cb02.Name = "cb02";
      this.cb02.Size = new Size(38, 20);
      this.cb02.TabIndex = 7;
      this.cb02.Text = "02";
      this.cb02.UseVisualStyleBackColor = false;
      this.cb02.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb02.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb02.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.cb01.AutoSize = true;
      this.cb01.BackColor = Color.White;
      this.cb01.Cursor = Cursors.Hand;
      this.cb01.FlatStyle = FlatStyle.Flat;
      this.cb01.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cb01.ForeColor = Color.DimGray;
      this.cb01.Location = new Point(73, 39);
      this.cb01.Name = "cb01";
      this.cb01.Size = new Size(38, 20);
      this.cb01.TabIndex = 6;
      this.cb01.Text = "01";
      this.cb01.UseVisualStyleBackColor = false;
      this.cb01.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.cb01.MouseLeave += new EventHandler(this.cb90_MouseLeave);
      this.cb01.MouseHover += new EventHandler(this.cb90_MouseHover);
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Cursor = Cursors.Hand;
      this.bunifuImageButton1.ErrorImage = (Image) null;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(4, 37);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(22, 22);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 33;
      this.bunifuImageButton1.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton1, " Trọn/Bỏ trọn hết đầu 0");
      this.bunifuImageButton1.Zoom = 8;
      this.bunifuImageButton1.Click += new EventHandler(this.bunifuImageButton1_Click);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(632, 10);
      this.label4.Name = "label4";
      this.label4.Size = new Size(36, 16);
      this.label4.TabIndex = 30;
      this.label4.Text = "ngày";
      this.txtGialapngaychuara.BorderStyle = BorderStyle.FixedSingle;
      this.txtGialapngaychuara.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.txtGialapngaychuara.ForeColor = Color.Red;
      this.txtGialapngaychuara.Location = new Point(574, 8);
      this.txtGialapngaychuara.Name = "txtGialapngaychuara";
      this.txtGialapngaychuara.Size = new Size(58, 21);
      this.txtGialapngaychuara.TabIndex = 2;
      this.txtGialapngaychuara.Text = "0";
      this.toolTip1.SetToolTip((Control) this.txtGialapngaychuara, " Là số ngày giả sử lô tô chưa ra trong tương lai, thì tần xuất của nó còn đẹp không đã có khả năng về chưa");
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(448, 10);
      this.label2.Name = "label2";
      this.label2.Size = new Size((int) sbyte.MaxValue, 16);
      this.label2.TabIndex = 28;
      this.label2.Text = "giả lập ngày chưa ra";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(312, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(89, 16);
      this.label1.TabIndex = 27;
      this.label1.Text = "ngày về trước";
      this.txtBiendongay.BorderStyle = BorderStyle.FixedSingle;
      this.txtBiendongay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.txtBiendongay.ForeColor = Color.Red;
      this.txtBiendongay.Location = new Point(261, 8);
      this.txtBiendongay.Name = "txtBiendongay";
      this.txtBiendongay.Size = new Size(51, 21);
      this.txtBiendongay.TabIndex = 1;
      this.txtBiendongay.Text = "36";
      this.toolTip1.SetToolTip((Control) this.txtBiendongay, "Khoảng thời gian kiểm tra lô tô. Tính từ ngày kiểm tra");
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.Black;
      this.label13.Location = new Point(7, 10);
      this.label13.Name = "label13";
      this.label13.Size = new Size(65, 16);
      this.label13.TabIndex = 24;
      this.label13.Text = "Xem ngày";
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(795, 5);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(105, 24);
      this.btnThongke.TabIndex = 4;
      this.btnThongke.Text = "Thống kê";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.dtNgayXem.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.CalendarForeColor = Color.Red;
      this.dtNgayXem.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayXem.CustomFormat = "dd/MM/yyyy";
      this.dtNgayXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.Format = DateTimePickerFormat.Custom;
      this.dtNgayXem.Location = new Point(72, 8);
      this.dtNgayXem.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayXem.Name = "dtNgayXem";
      this.dtNgayXem.Size = new Size(103, 21);
      this.dtNgayXem.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.dtNgayXem, "Ngày kiểm tra lô tô");
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(211, 10);
      this.label3.Name = "label3";
      this.label3.Size = new Size(50, 16);
      this.label3.TabIndex = 7;
      this.label3.Text = "biên độ";
      this.toolTip1.AutomaticDelay = 200;
      this.bgProcess.DoWork += new DoWorkEventHandler(this.bgProcess_DoWork);
      this.bgProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgProcess_RunWorkerCompleted);
      this.timerLoading.Enabled = true;
      this.timerLoading.Interval = 20;
      this.timerLoading.Tick += new EventHandler(this.timerLoading_Tick);
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(0, 181);
      this.wbHienthi.MinimumSize = new Size(20, 20);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1115, 409);
      this.wbHienthi.TabIndex = 61;
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(577, 336);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 63;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.wbHienthi);
      this.Controls.Add((Control) this.panel2);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabTanxuatloto);
      this.Size = new Size(1100, 590);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.bunifuImageButton10.EndInit();
      this.bunifuImageButton9.EndInit();
      this.bunifuImageButton8.EndInit();
      this.bunifuImageButton7.EndInit();
      this.bunifuImageButton6.EndInit();
      this.bunifuImageButton5.EndInit();
      this.bunifuImageButton4.EndInit();
      this.bunifuImageButton3.EndInit();
      this.bunifuImageButton2.EndInit();
      this.bunifuImageButton1.EndInit();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }

    public class InfoLoto
    {
      public string Loto { get; set; }

      public Decimal Tongsolan { get; set; }

      public Decimal Tongsonhay { get; set; }

      public Decimal Chukitrungbinhsolan { get; set; }

      public Decimal Chukitrungbinhsonhay { get; set; }

      public Decimal Ngaychuara { get; set; }

      public Decimal MaxGan { get; set; }

      public DateTime Ngaybatdau { get; set; }

      public DateTime Ngayketthuc { get; set; }
    }
  }
}
