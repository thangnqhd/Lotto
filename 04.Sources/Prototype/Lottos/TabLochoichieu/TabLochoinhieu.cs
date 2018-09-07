// Decompiled with JetBrains decompiler
// Type: TabLochoichieu.TabLochoinhieu
// Assembly: TabLochoichieu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6A9D96F1-0C0A-4C85-A1C8-BA2D6BA6F6BB
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\TabLochoichieu.dll

using ns1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TabLochoichieu
{
  public class TabLochoinhieu : UserControl
  {
    private IContainer components = (IContainer) null;
    private string strHtml;
    private string UrlAddress;
    private BunifuElipse bunifuElipse1;
    private BackgroundWorker backgroundWorker1;
    private Timer timer1;
    private WebBrowser wbHienthi;
    private GroupBox groupBox1;
    private Label label1;
    private DateTimePicker dtNgayThang;
    private Button btnXem;

    public TabLochoinhieu()
    {
      this.InitializeComponent();
      this.strHtml = "Chao anh em";
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void XuLy()
    {
      this.strHtml = this.DownLoadHtml(this.dtNgayThang.Value);
    }

    private void HienThiKetQua(WebBrowser wb, string htmlCode)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.StrCss1 + "<title>THỐNG KÊ XỔ SỐ</title></head><body  style='font-family:Verdana;'><div class='container' style='margin-right:15px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ></div><div class='panel-body'><ul class='media-list'><li class='media'>" + htmlCode + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
      TabLochoinhieu.DisplayHtml(wb, html);
    }

    public string DownLoadHtml(DateTime ngayThem)
    {
      WebClient webClient = new WebClient();
      this.UrlAddress = "https://rongbachkim.com/trend.php?list&alone&day=" + ngayThem.ToString("yyyy-MM-dd");
      return TabLochoinhieu.StripHTML(webClient.DownloadString(this.UrlAddress)).Trim();
    }

    public static string StripHTML(string inputText)
    {
      string str = "";
      string pattern = "<a.*?>(.*?)<\\/a>";
      MatchCollection matchCollection = Regex.Matches(inputText, pattern);
      if (matchCollection.Count > 0)
      {
        foreach (Match match in matchCollection)
          str += (string) (object) match.Groups[1];
      }
      return str;
    }

    public static void DisplayHtml(WebBrowser wb, string html)
    {
      if (!wb.IsDisposed)
      {
        wb.Navigate("about:blank");
      }
      else
      {
        wb = new WebBrowser();
        wb.Navigate("about:blank");
      }
      try
      {
        if (wb.Document != (HtmlDocument) null)
          wb.Document.Write(string.Empty);
      }
      catch
      {
      }
      wb.DocumentText = html;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.HienThiKetQua(this.wbHienthi, this.strHtml);
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.XuLy();
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
    }

    private void btnXem_Click_1(object sender, EventArgs e)
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
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.backgroundWorker1 = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.wbHienthi = new WebBrowser();
      this.groupBox1 = new GroupBox();
      this.label1 = new Label();
      this.dtNgayThang = new DateTimePicker();
      this.btnXem = new Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.timer1.Enabled = true;
      this.timer1.Interval = 600000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.wbHienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHienthi.Location = new Point(0, 2);
      this.wbHienthi.MinimumSize = new Size(20, 20);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1115, 590);
      this.wbHienthi.TabIndex = 24;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.dtNgayThang);
      this.groupBox1.Controls.Add((Control) this.btnXem);
      this.groupBox1.Location = new Point(5, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1090, 43);
      this.groupBox1.TabIndex = 25;
      this.groupBox1.TabStop = false;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(4, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(65, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Xem ngày";
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
      this.btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(177, 13);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(907, 24);
      this.btnXem.TabIndex = 8;
      this.btnXem.Text = "XEM DANH SÁCH LÔ TÔ ĐƯỢC CHƠI NHIỀU NHẤT";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.btnXem_Click_1);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.wbHienthi);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabLochoinhieu);
      this.Size = new Size(1100, 590);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
