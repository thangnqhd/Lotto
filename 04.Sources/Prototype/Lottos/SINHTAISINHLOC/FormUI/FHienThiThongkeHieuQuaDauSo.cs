// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FHienThiThongkeHieuQuaDauSo
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class FHienThiThongkeHieuQuaDauSo : Form
  {
    private IContainer components = (IContainer) null;
    private WebBrowser webBrowser1;

    public FHienThiThongkeHieuQuaDauSo(string html)
    {
      this.InitializeComponent();
      this.Hienthi(html);
    }

    private void Hienthi(string html)
    {
      Tbketqua.HienThiKetQua(this.webBrowser1, html);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.webBrowser1 = new WebBrowser();
      this.SuspendLayout();
      this.webBrowser1.Dock = DockStyle.Fill;
      this.webBrowser1.Location = new Point(0, 0);
      this.webBrowser1.MinimumSize = new Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new Size(814, 368);
      this.webBrowser1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(814, 368);
      this.Controls.Add((Control) this.webBrowser1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FHienThiThongkeHieuQuaDauSo);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Thông tin hiệu quả thống kê đầu số";
      this.ResumeLayout(false);
    }
  }
}
