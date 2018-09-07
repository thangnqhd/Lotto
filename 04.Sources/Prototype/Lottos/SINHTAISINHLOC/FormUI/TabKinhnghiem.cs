// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabKinhnghiem
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
  public class TabKinhnghiem : UserControl
  {
    private int _loadLaiForm = 1;
    private IContainer components = (IContainer) null;
    private DataTable _dt;
    private tbSomo_Kinhnghiem _infoSomoKinhnghiem;
    private int _valuComboBox;
    private WebBrowser webBrowserMessage;
    private Panel panel2;
    private Timer timer1;
    private BackgroundWorker backgroundWorker1;
    private ComboBox comboBoxKinhnghiem;
    private Label label1;
    private BunifuElipse bunifuElipse1;
    private BunifuThinButton2 bunifuThinButton21;
    private PictureBox picLoading;

    public TabKinhnghiem()
    {
      this._infoSomoKinhnghiem = new tbSomo_Kinhnghiem();
      this.InitializeComponent();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.webBrowserMessage.IsWebBrowserContextMenuEnabled = false;
      this.webBrowserMessage.AllowWebBrowserDrop = false;
    }

    private void GetDataComBoBox()
    {
      this._dt = new DataTable();
      this._dt = this._infoSomoKinhnghiem.GetListBy_Title("kinhnghiem");
    }

    private void add_ComboboxHinhthucThanhToan(ComboBox cb, DataTable dtTb)
    {
      ArrayList arrayList = new ArrayList();
      for (int index = 0; index < dtTb.Rows.Count; ++index)
        arrayList.Add((object) new ClMain.AddValue("  " + dtTb.Rows[index]["tieuDe"], dtTb.Rows[index]["stt"].ToString()));
      cb.DataSource = (object) arrayList;
      cb.DisplayMember = "Display";
      cb.ValueMember = "Value";
    }

    private void LoadMessage(tbSomo_Kinhnghiem obj)
    {
      string str = "" + "\r\n                    <div class='container'>\r\n                    <div class='row' >\r\n                    <div class='col-md-8'>\r\n                    <div class='panel panel-info'>\r\n                    <div class='panel-heading'>Thông tin tìm kiếm\r\n                    </div>\r\n                    <div class='panel-body'>\r\n                    <ul class='media-list'>\r\n                    <li class='media'>";
      if (obj.tieuDe != null)
        str = str + "<div class='media-body'>" + "<div class='media' >" + "<a class='pull-left' href='#'></a>" + "<div class='media-body'> Mơ " + obj.tieuDe + " | <b style='color:red'>" + obj.noiDung + "</b><br />" + "<small class='text-muted' style='font-size:11px'>Quản trị viên | " + (object) obj.ngayCapnhat + "</small>" + "<hr /></div></div></div>";
      this.Hien_Thi_KetQua(this.webBrowserMessage, str + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div>");
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=9' />\r\n                                     " + CssMessage.StrCss1 + "<title>BOOTSTRAP CHAT EXAMPLE</title></head><body  oncontextmenu='return false;'style='font-family:Verdana' >" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void ComboBoxKinhnghiemSelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.comboBoxKinhnghiem.SelectedValue.ToString() != "Thống_kê_xổ_số.BusinessLayer.ClMain+AddValue"))
        return;
      this._valuComboBox = int.Parse(this.comboBoxKinhnghiem.SelectedValue.ToString());
    }

    private void TabKinhnghiemLoad(object sender, EventArgs e)
    {
    }

    private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
    {
      this._infoSomoKinhnghiem = this._infoSomoKinhnghiem.GetInfor(this._valuComboBox.ToString());
      this.LoadMessage(this._infoSomoKinhnghiem);
    }

    private void Timer1Tick(object sender, EventArgs e)
    {
      if (this._loadLaiForm == 1)
      {
        this._loadLaiForm = 0;
        this.GetDataComBoBox();
        if (this._dt.Rows.Count > 0)
        {
          this._valuComboBox = int.Parse(this._dt.Rows[0][0].ToString());
          this.add_ComboboxHinhthucThanhToan(this.comboBoxKinhnghiem, this._dt);
        }
        if (!this.backgroundWorker1.IsBusy)
          this.backgroundWorker1.RunWorkerAsync();
      }
      this.picLoading.Visible = this.backgroundWorker1.IsBusy;
    }

    private void WebBrowserMessageDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    }

    private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    private void BunifuThinButton21Click(object sender, EventArgs e)
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabKinhnghiem));
      this.webBrowserMessage = new WebBrowser();
      this.panel2 = new Panel();
      this.bunifuThinButton21 = new BunifuThinButton2();
      this.label1 = new Label();
      this.comboBoxKinhnghiem = new ComboBox();
      this.timer1 = new Timer(this.components);
      this.backgroundWorker1 = new BackgroundWorker();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.picLoading = new PictureBox();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.webBrowserMessage.CausesValidation = false;
      this.webBrowserMessage.Dock = DockStyle.Fill;
      this.webBrowserMessage.Location = new Point(0, 0);
      this.webBrowserMessage.Margin = new Padding(0);
      this.webBrowserMessage.MinimumSize = new Size(23, 23);
      this.webBrowserMessage.Name = "webBrowserMessage";
      this.webBrowserMessage.Size = new Size(1322, 700);
      this.webBrowserMessage.TabIndex = 10;
      this.webBrowserMessage.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.WebBrowserMessageDocumentCompleted);
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.bunifuThinButton21);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.comboBoxKinhnghiem);
      this.panel2.Location = new Point(-1, 0);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1304, 38);
      this.panel2.TabIndex = 12;
      this.bunifuThinButton21.ActiveBorderThickness = 1;
      this.bunifuThinButton21.ActiveCornerRadius = 20;
      this.bunifuThinButton21.ActiveFillColor = SystemColors.ButtonFace;
      this.bunifuThinButton21.ActiveForecolor = Color.Black;
      this.bunifuThinButton21.ActiveLineColor = SystemColors.ControlDarkDark;
      this.bunifuThinButton21.BackColor = Color.White;
      this.bunifuThinButton21.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
      this.bunifuThinButton21.ButtonText = "xem kinh nghiệm";
      this.bunifuThinButton21.Cursor = Cursors.Hand;
      this.bunifuThinButton21.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton21.ForeColor = Color.Black;
      this.bunifuThinButton21.IdleBorderThickness = 1;
      this.bunifuThinButton21.IdleCornerRadius = 20;
      this.bunifuThinButton21.IdleFillColor = Color.WhiteSmoke;
      this.bunifuThinButton21.IdleForecolor = Color.Black;
      this.bunifuThinButton21.IdleLineColor = Color.DodgerBlue;
      this.bunifuThinButton21.Location = new Point(880, 1);
      this.bunifuThinButton21.Margin = new Padding(0);
      this.bunifuThinButton21.Name = "bunifuThinButton21";
      this.bunifuThinButton21.Size = new Size(189, 33);
      this.bunifuThinButton21.TabIndex = 8;
      this.bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton21.Click += new EventHandler(this.BunifuThinButton21Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkCyan;
      this.label1.Location = new Point(209, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(125, 17);
      this.label1.TabIndex = 7;
      this.label1.Text = "Chọn kinh nghiệm";
      this.comboBoxKinhnghiem.BackColor = Color.FromArgb(212, 208, 200);
      this.comboBoxKinhnghiem.Cursor = Cursors.Hand;
      this.comboBoxKinhnghiem.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxKinhnghiem.FlatStyle = FlatStyle.Popup;
      this.comboBoxKinhnghiem.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBoxKinhnghiem.FormattingEnabled = true;
      this.comboBoxKinhnghiem.Location = new Point(341, 6);
      this.comboBoxKinhnghiem.Name = "comboBoxKinhnghiem";
      this.comboBoxKinhnghiem.Size = new Size(536, 25);
      this.comboBoxKinhnghiem.TabIndex = 6;
      this.comboBoxKinhnghiem.SelectedIndexChanged += new EventHandler(this.ComboBoxKinhnghiemSelectedIndexChanged);
      this.timer1.Enabled = true;
      this.timer1.Interval = 15;
      this.timer1.Tick += new EventHandler(this.Timer1Tick);
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.BackgroundWorker1DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackgroundWorker1RunWorkerCompleted);
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(603, 305);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
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
      this.Name = nameof (TabKinhnghiem);
      this.Size = new Size(1322, 700);
      this.Load += new EventHandler(this.TabKinhnghiemLoad);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
