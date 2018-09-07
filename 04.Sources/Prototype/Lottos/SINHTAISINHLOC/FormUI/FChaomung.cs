// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FChaomung
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class FChaomung : Form
  {
    private string tieuDe = "";
    private string noidung = "";
    private IContainer components = (IContainer) null;
    private TbChaomung objChaomung;
    private DataTable dt;
    private WebBrowser wbHienthi;
    private BunifuImageButton bunifuImageButton8;
    private BackgroundWorker backgroundWorker1;
    private BunifuElipse bunifuElipse1;

    public FChaomung()
    {
      this.InitializeComponent();
      this.objChaomung = new TbChaomung();
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void Xuly()
    {
      this.dt = this.objChaomung.GetByStatus();
      if (this.dt.Rows.Count <= 0)
        return;
      this.tieuDe = this.dt.Rows[0]["tieuDe"].ToString();
      this.noidung = this.dt.Rows[0]["noiDung"].ToString();
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=10' />\r\n                                     " + CssMessage.StrCss1 + "<title>BOOTSTRAP CHAT EXAMPLE</title></head><body style='margin-right:25px;font-family:Verdana;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Xuly();
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.dt.Rows.Count > 0)
        this.Hien_Thi_KetQua(this.wbHienthi, this.noidung);
      else
        this.Close();
    }

    private void bunifuImageButton8_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FChaomung_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FChaomung));
      this.wbHienthi = new WebBrowser();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.backgroundWorker1 = new BackgroundWorker();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.bunifuImageButton8.BeginInit();
      this.SuspendLayout();
      this.wbHienthi.Location = new Point(1, 1);
      this.wbHienthi.MinimumSize = new Size(20, 20);
      this.wbHienthi.Name = "wbHienthi";
      this.wbHienthi.Size = new Size(1027, 471);
      this.wbHienthi.TabIndex = 30;
      this.bunifuImageButton8.BackColor = Color.White;
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(3, 2);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(19, 19);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 31;
      this.bunifuImageButton8.TabStop = false;
      this.bunifuImageButton8.Zoom = 8;
      this.bunifuImageButton8.Click += new EventHandler(this.bunifuImageButton8_Click);
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.bunifuElipse1.ElipseRadius = 0;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(43, 60, 80);
      this.ClientSize = new Size(1030, 474);
      this.Controls.Add((Control) this.bunifuImageButton8);
      this.Controls.Add((Control) this.wbHienthi);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FChaomung);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Chào mừng";
      this.MouseDown += new MouseEventHandler(this.FChaomung_MouseDown);
      this.bunifuImageButton8.EndInit();
      this.ResumeLayout(false);
    }
  }
}
