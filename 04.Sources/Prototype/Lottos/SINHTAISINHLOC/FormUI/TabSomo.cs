// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabSomo
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabSomo : UserControl
  {
    private IContainer components = (IContainer) null;
    private tbSomo_Kinhnghiem infoSomoKinhnghiem;
    private DataTable _dt;
    private Panel panel2;
    private BunifuThinButton2 btnXem;
    private WebBrowser webBrowserMessage;
    private Timer timer1;
    private BackgroundWorker backgroundWorker1;
    private TextBox txtSeach;
    private BunifuElipse bunifuElipse1;
    private PictureBox picLoading;

    public TabSomo()
    {
      this.infoSomoKinhnghiem = new tbSomo_Kinhnghiem();
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.webBrowserMessage.IsWebBrowserContextMenuEnabled = false;
      this.webBrowserMessage.AllowWebBrowserDrop = false;
      this._dt = this.infoSomoKinhnghiem.GetAll(25, "somo", 1);
      this.LoadMessage(this._dt);
      this.ShowDataSearch();
      this.timer1.Start();
    }

    private void ShowDataSearch()
    {
      List<string> stringList = this.Data();
      this.txtSeach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
      stringCollection.AddRange(stringList.ToArray());
      this.txtSeach.AutoCompleteCustomSource = stringCollection;
      this.txtSeach.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    private List<string> Data()
    {
      this._dt = this.infoSomoKinhnghiem.GetListBy_Title("somo");
      List<string> stringList = new List<string>();
      for (int index = 0; index < this._dt.Rows.Count; ++index)
      {
        string[] strArray = this._dt.Rows[index][1].ToString().Split(' ');
        stringList.AddRange((IEnumerable<string>) strArray);
      }
      return stringList;
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void show_Info()
    {
      if (this.txtSeach.Text.Length <= 0)
        return;
      this._dt = this.infoSomoKinhnghiem.GetListBy_KeySearch(this.txtSeach.Text, "somo", 1);
      this.LoadMessage(this._dt);
    }

    private void LoadMessage(DataTable dataTable)
    {
      string str = "" + "\r\n                    <div class='container'>\r\n                    <div class='row ' style='padding-top:40px;'>\r\n                    <div class='col-md-8'>\r\n                    <div class='panel panel-info'>\r\n                    <div class='panel-heading'>Thông tin tìm kiếm\r\n                    </div>\r\n                    <div class='panel-body'>\r\n                    <ul class='media-list'>\r\n                    <li class='media'>";
      if (dataTable.Rows.Count > 0)
      {
        for (int index = 0; index < dataTable.Rows.Count; ++index)
          str = str + "<div class='media-body'>" + "<div class='media' >" + "<a class='pull-left' href='#'></a>" + "<div class='media-body'> Mơ " + dataTable.Rows[index]["tieuDe"] + " | <b style='color:red'>" + dataTable.Rows[index]["noiDung"] + "</b><br />" + "<small class='text-muted' style='font-size:11px'>Quản trị viên | " + dataTable.Rows[index]["ngayCapnhat"] + "</small>" + "<hr /></div></div></div>";
      }
      else
        str = str + "<div class='media-body'>" + "<div class='media' >" + "<div class='media-body'>Không tìm thấy nội dung phù hợp<br />" + "<hr /></div></div></div>";
      this.Hien_Thi_KetQua(this.webBrowserMessage, str + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div>");
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=9' />\r\n                                     " + CssMessage.StrCss1 + "<title>BOOTSTRAP CHAT EXAMPLE</title></head><body  style='font-family:Verdana' oncontextmenu='return false;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void tabSomo_Load(object sender, EventArgs e)
    {
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.backgroundWorker1.IsBusy;
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.show_Info();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabSomo));
      this.panel2 = new Panel();
      this.txtSeach = new TextBox();
      this.btnXem = new BunifuThinButton2();
      this.webBrowserMessage = new WebBrowser();
      this.timer1 = new Timer(this.components);
      this.backgroundWorker1 = new BackgroundWorker();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.picLoading = new PictureBox();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.txtSeach);
      this.panel2.Controls.Add((Control) this.btnXem);
      this.panel2.Location = new Point(0, -1);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1372, 38);
      this.panel2.TabIndex = 8;
      this.txtSeach.BorderStyle = BorderStyle.FixedSingle;
      this.txtSeach.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSeach.Location = new Point(325, 8);
      this.txtSeach.Name = "txtSeach";
      this.txtSeach.Size = new Size(494, 22);
      this.txtSeach.TabIndex = 11;
      this.txtSeach.TextAlign = HorizontalAlignment.Center;
      this.btnXem.ActiveBorderThickness = 1;
      this.btnXem.ActiveCornerRadius = 20;
      this.btnXem.ActiveFillColor = SystemColors.ButtonFace;
      this.btnXem.ActiveForecolor = Color.Black;
      this.btnXem.ActiveLineColor = SystemColors.ControlDarkDark;
      this.btnXem.BackColor = Color.White;
      this.btnXem.BackgroundImage = (Image) componentResourceManager.GetObject("btnXem.BackgroundImage");
      this.btnXem.ButtonText = "Tìm kiếm";
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.Black;
      this.btnXem.IdleBorderThickness = 1;
      this.btnXem.IdleCornerRadius = 20;
      this.btnXem.IdleFillColor = Color.WhiteSmoke;
      this.btnXem.IdleForecolor = Color.Black;
      this.btnXem.IdleLineColor = Color.DodgerBlue;
      this.btnXem.Location = new Point(824, 2);
      this.btnXem.Margin = new Padding(0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(206, 33);
      this.btnXem.TabIndex = 5;
      this.btnXem.TextAlign = ContentAlignment.MiddleCenter;
      this.btnXem.Click += new EventHandler(this.btnXem_Click);
      this.webBrowserMessage.CausesValidation = false;
      this.webBrowserMessage.Dock = DockStyle.Fill;
      this.webBrowserMessage.Location = new Point(0, 0);
      this.webBrowserMessage.Margin = new Padding(0);
      this.webBrowserMessage.MinimumSize = new Size(23, 23);
      this.webBrowserMessage.Name = "webBrowserMessage";
      this.webBrowserMessage.Size = new Size(1391, 760);
      this.webBrowserMessage.TabIndex = 7;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(616, 287);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(47, 46);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 18;
      this.picLoading.TabStop = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.webBrowserMessage);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabSomo);
      this.Size = new Size(1391, 760);
      this.Load += new EventHandler(this.tabSomo_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
