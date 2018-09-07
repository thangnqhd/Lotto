// Decompiled with JetBrains decompiler
// Type: ns1.BunifuSeparator
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DebuggerStepThrough]
  public class BunifuSeparator : UserControl
  {
    private bool bool_0;
    private IContainer icontainer_0;
    private PictureBox pictureBox1;

    public BunifuSeparator()
    {
      this.InitializeComponent();
      this.OnResize(new EventArgs());
      int usageMode = (int) LicenseManager.UsageMode;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void BunifuSeparator_BackColorChanged(object sender, EventArgs e)
    {
      if (this.BackColor != Color.Transparent)
        throw new Exception("Invalid Value");
    }

    public bool Vertical
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        if (value == this.bool_0)
          return;
        this.bool_0 = value;
        int height = this.pictureBox1.Height;
        this.pictureBox1.Height = this.pictureBox1.Width;
        this.pictureBox1.Width = height;
        this.OnResize(new EventArgs());
      }
    }

    public Color LineColor
    {
      get
      {
        return this.pictureBox1.BackColor;
      }
      set
      {
        this.pictureBox1.BackColor = value;
      }
    }

    public int Transparency
    {
      get
      {
        return (int) this.pictureBox1.BackColor.A;
      }
      set
      {
        PictureBox pictureBox1 = this.pictureBox1;
        int alpha = value;
        Color backColor = this.pictureBox1.BackColor;
        int r = (int) backColor.R;
        backColor = this.pictureBox1.BackColor;
        int g = (int) backColor.G;
        backColor = this.pictureBox1.BackColor;
        int b = (int) backColor.B;
        Color color = Color.FromArgb(alpha, r, g, b);
        pictureBox1.BackColor = color;
      }
    }

    public int LineThickness
    {
      get
      {
        if (this.Vertical)
          return this.pictureBox1.Width;
        return this.pictureBox1.Height;
      }
      set
      {
        if (this.Vertical)
          this.pictureBox1.Width = value;
        else
          this.pictureBox1.Height = value;
      }
    }

    private void BunifuSeparator_Resize(object sender, EventArgs e)
    {
      if (this.Vertical)
      {
        this.pictureBox1.Top = 0;
        this.pictureBox1.Height = this.Height;
        this.pictureBox1.Left = this.Width / 2 - this.pictureBox1.Width / 2;
      }
      else
      {
        this.pictureBox1.Left = 0;
        this.pictureBox1.Width = this.Width;
        this.pictureBox1.Top = this.Height / 2 - this.pictureBox1.Height / 2;
      }
    }

    private void BunifuSeparator_Load(object sender, EventArgs e)
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
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.pictureBox1.BackColor = Color.DimGray;
      this.pictureBox1.Location = new Point(0, 15);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(639, 1);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.pictureBox1);
      this.Name = nameof (BunifuSeparator);
      this.Size = new Size(639, 35);
      this.Load += new EventHandler(this.BunifuSeparator_Load);
      this.BackColorChanged += new EventHandler(this.BunifuSeparator_BackColorChanged);
      this.Resize += new EventHandler(this.BunifuSeparator_Resize);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
