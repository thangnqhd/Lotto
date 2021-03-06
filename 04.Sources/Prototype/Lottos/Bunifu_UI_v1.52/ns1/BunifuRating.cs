﻿// Decompiled with JetBrains decompiler
// Type: ns1.BunifuRating
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns0;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DefaultEvent("onValueChanged")]
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuRating : UserControl
  {
    private int int_0;
    private IContainer icontainer_0;
    private PictureBox star1;
    private PictureBox star2;
    private PictureBox star3;
    private PictureBox star4;
    private PictureBox star5;
    private PictureBox off;
    private PictureBox on;
    private PictureBox offOrig;
    private PictureBox onOrig;

    public BunifuRating()
    {
      this.InitializeComponent();
      this.OnForeColorChanged((EventArgs) null);
      int usageMode = (int) LicenseManager.UsageMode;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void BunifuRating_Resize(object sender, EventArgs e)
    {
      this.star1.Height = this.star2.Height = this.star3.Height = this.star4.Height = this.star5.Height = this.Height;
      this.star1.Width = this.star2.Width = this.star3.Width = this.star4.Width = this.star5.Width = this.Height;
      int num = (this.Width - this.Height * 5) / 4;
      this.star2.Left = this.star1.Right + num;
      this.star3.Left = this.star2.Right + num;
      this.star4.Left = this.star3.Right + num;
      this.star5.Left = this.star4.Right + num;
    }

    private void BunifuRating_ForeColorChanged(object sender, EventArgs e)
    {
      this.on.Image = this.onOrig.Image;
      this.off.Image = this.offOrig.Image;
      this.on.Image = Class7.smethod_1(this.on.Image, this.ForeColor);
      this.off.Image = Class7.smethod_1(this.off.Image, this.ForeColor);
      this.star1.Image = !(this.star1.Tag.ToString() == "on") ? this.off.Image : this.on.Image;
      this.star2.Image = !(this.star2.Tag.ToString() == "on") ? this.off.Image : this.on.Image;
      this.star3.Image = !(this.star3.Tag.ToString() == "on") ? this.off.Image : this.on.Image;
      this.star4.Image = !(this.star4.Tag.ToString() == "on") ? this.off.Image : this.on.Image;
      if (this.star5.Tag.ToString() == "on")
        this.star5.Image = this.on.Image;
      else
        this.star5.Image = this.off.Image;
    }

    public int Value
    {
      get
      {
        return this.int_0;
      }
      set
      {
        if (value < 0 && value > 5)
          throw new Exception("Invalid Value ( >=0 || <=5)");
        this.int_0 = value;
        this.method_0();
        this.method_1();
      }
    }

    private void method_0()
    {
      switch (this.int_0)
      {
        case 0:
          this.star1.Image = this.off.Image;
          this.star2.Image = this.off.Image;
          this.star3.Image = this.off.Image;
          this.star4.Image = this.off.Image;
          this.star5.Image = this.off.Image;
          break;
        case 1:
          this.star1.Image = this.on.Image;
          this.star2.Image = this.off.Image;
          this.star3.Image = this.off.Image;
          this.star4.Image = this.off.Image;
          this.star5.Image = this.off.Image;
          break;
        case 2:
          this.star1.Image = this.on.Image;
          this.star2.Image = this.on.Image;
          this.star3.Image = this.off.Image;
          this.star4.Image = this.off.Image;
          this.star5.Image = this.off.Image;
          break;
        case 3:
          this.star1.Image = this.on.Image;
          this.star2.Image = this.on.Image;
          this.star3.Image = this.on.Image;
          this.star4.Image = this.off.Image;
          this.star5.Image = this.off.Image;
          break;
        case 4:
          this.star1.Image = this.on.Image;
          this.star2.Image = this.on.Image;
          this.star3.Image = this.on.Image;
          this.star4.Image = this.on.Image;
          this.star5.Image = this.off.Image;
          break;
        case 5:
          this.star1.Image = this.on.Image;
          this.star2.Image = this.on.Image;
          this.star3.Image = this.on.Image;
          this.star4.Image = this.on.Image;
          this.star5.Image = this.on.Image;
          break;
      }
    }

    private void star5_Click(object sender, EventArgs e)
    {
      int num = int.Parse(((Control) sender).Tag.ToString());
      if (((PictureBox) sender).Image == this.on.Image)
      {
        this.int_0 = num - 1;
        this.method_0();
        this.method_1();
      }
      else
      {
        this.int_0 = num;
        this.method_0();
        this.method_1();
      }
    }

    public event EventHandler onValueChanged;

    private void method_1()
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, (EventArgs) null);
    }

    private void BunifuRating_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuRating));
      this.star1 = new PictureBox();
      this.star2 = new PictureBox();
      this.star3 = new PictureBox();
      this.star4 = new PictureBox();
      this.star5 = new PictureBox();
      this.off = new PictureBox();
      this.on = new PictureBox();
      this.offOrig = new PictureBox();
      this.onOrig = new PictureBox();
      ((ISupportInitialize) this.star1).BeginInit();
      ((ISupportInitialize) this.star2).BeginInit();
      ((ISupportInitialize) this.star3).BeginInit();
      ((ISupportInitialize) this.star4).BeginInit();
      ((ISupportInitialize) this.star5).BeginInit();
      ((ISupportInitialize) this.off).BeginInit();
      ((ISupportInitialize) this.on).BeginInit();
      ((ISupportInitialize) this.offOrig).BeginInit();
      ((ISupportInitialize) this.onOrig).BeginInit();
      this.SuspendLayout();
      this.star1.BackColor = Color.Transparent;
      this.star1.Cursor = Cursors.Hand;
      this.star1.Image = (Image) componentResourceManager.GetObject("star1.Image");
      this.star1.Location = new Point(0, 1);
      this.star1.Name = "star1";
      this.star1.Size = new Size(50, 46);
      this.star1.SizeMode = PictureBoxSizeMode.Zoom;
      this.star1.TabIndex = 0;
      this.star1.TabStop = false;
      this.star1.Tag = (object) "1";
      this.star1.Click += new EventHandler(this.star5_Click);
      this.star2.BackColor = Color.Transparent;
      this.star2.Cursor = Cursors.Hand;
      this.star2.Image = (Image) componentResourceManager.GetObject("star2.Image");
      this.star2.Location = new Point(66, 1);
      this.star2.Name = "star2";
      this.star2.Size = new Size(50, 46);
      this.star2.SizeMode = PictureBoxSizeMode.Zoom;
      this.star2.TabIndex = 1;
      this.star2.TabStop = false;
      this.star2.Tag = (object) "2";
      this.star2.Click += new EventHandler(this.star5_Click);
      this.star3.BackColor = Color.Transparent;
      this.star3.Cursor = Cursors.Hand;
      this.star3.Image = (Image) componentResourceManager.GetObject("star3.Image");
      this.star3.Location = new Point(132, 1);
      this.star3.Name = "star3";
      this.star3.Size = new Size(50, 46);
      this.star3.SizeMode = PictureBoxSizeMode.Zoom;
      this.star3.TabIndex = 2;
      this.star3.TabStop = false;
      this.star3.Tag = (object) "3";
      this.star3.Click += new EventHandler(this.star5_Click);
      this.star4.BackColor = Color.Transparent;
      this.star4.Cursor = Cursors.Hand;
      this.star4.Image = (Image) componentResourceManager.GetObject("star4.Image");
      this.star4.Location = new Point(198, 1);
      this.star4.Name = "star4";
      this.star4.Size = new Size(50, 46);
      this.star4.SizeMode = PictureBoxSizeMode.Zoom;
      this.star4.TabIndex = 3;
      this.star4.TabStop = false;
      this.star4.Tag = (object) "4";
      this.star4.Click += new EventHandler(this.star5_Click);
      this.star5.BackColor = Color.Transparent;
      this.star5.Cursor = Cursors.Hand;
      this.star5.Image = (Image) componentResourceManager.GetObject("star5.Image");
      this.star5.Location = new Point(264, 1);
      this.star5.Name = "star5";
      this.star5.Size = new Size(50, 46);
      this.star5.SizeMode = PictureBoxSizeMode.Zoom;
      this.star5.TabIndex = 4;
      this.star5.TabStop = false;
      this.star5.Tag = (object) "5";
      this.star5.Click += new EventHandler(this.star5_Click);
      this.off.Cursor = Cursors.Hand;
      this.off.Image = (Image) componentResourceManager.GetObject("off.Image");
      this.off.Location = new Point(44, 46);
      this.off.Name = "off";
      this.off.Size = new Size(82, 36);
      this.off.SizeMode = PictureBoxSizeMode.Zoom;
      this.off.TabIndex = 6;
      this.off.TabStop = false;
      this.off.Tag = (object) "false";
      this.off.Visible = false;
      this.on.Cursor = Cursors.Hand;
      this.on.Image = (Image) componentResourceManager.GetObject("on.Image");
      this.on.Location = new Point(-22, 46);
      this.on.Name = "on";
      this.on.Size = new Size(82, 36);
      this.on.SizeMode = PictureBoxSizeMode.Zoom;
      this.on.TabIndex = 5;
      this.on.TabStop = false;
      this.on.Tag = (object) "false";
      this.on.Visible = false;
      this.offOrig.Cursor = Cursors.Hand;
      this.offOrig.Image = (Image) componentResourceManager.GetObject("offOrig.Image");
      this.offOrig.Location = new Point(122, 51);
      this.offOrig.Name = "offOrig";
      this.offOrig.Size = new Size(82, 36);
      this.offOrig.SizeMode = PictureBoxSizeMode.Zoom;
      this.offOrig.TabIndex = 8;
      this.offOrig.TabStop = false;
      this.offOrig.Tag = (object) "false";
      this.offOrig.Visible = false;
      this.onOrig.Cursor = Cursors.Hand;
      this.onOrig.Image = (Image) componentResourceManager.GetObject("onOrig.Image");
      this.onOrig.Location = new Point(44, 58);
      this.onOrig.Name = "onOrig";
      this.onOrig.Size = new Size(82, 36);
      this.onOrig.SizeMode = PictureBoxSizeMode.Zoom;
      this.onOrig.TabIndex = 7;
      this.onOrig.TabStop = false;
      this.onOrig.Tag = (object) "false";
      this.onOrig.Visible = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.offOrig);
      this.Controls.Add((Control) this.onOrig);
      this.Controls.Add((Control) this.off);
      this.Controls.Add((Control) this.on);
      this.Controls.Add((Control) this.star5);
      this.Controls.Add((Control) this.star4);
      this.Controls.Add((Control) this.star3);
      this.Controls.Add((Control) this.star2);
      this.Controls.Add((Control) this.star1);
      this.ForeColor = Color.SeaGreen;
      this.Name = nameof (BunifuRating);
      this.Size = new Size(316, 50);
      this.Load += new EventHandler(this.BunifuRating_Load);
      this.ForeColorChanged += new EventHandler(this.BunifuRating_ForeColorChanged);
      this.Resize += new EventHandler(this.BunifuRating_Resize);
      ((ISupportInitialize) this.star1).EndInit();
      ((ISupportInitialize) this.star2).EndInit();
      ((ISupportInitialize) this.star3).EndInit();
      ((ISupportInitialize) this.star4).EndInit();
      ((ISupportInitialize) this.star5).EndInit();
      ((ISupportInitialize) this.off).EndInit();
      ((ISupportInitialize) this.on).EndInit();
      ((ISupportInitialize) this.offOrig).EndInit();
      ((ISupportInitialize) this.onOrig).EndInit();
      this.ResumeLayout(false);
    }
  }
}
