// Decompiled with JetBrains decompiler
// Type: ns1.BunifuVTrackbar
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DefaultEvent("ValueChanged")]
  public class BunifuVTrackbar : UserControl
  {
    private int int_0 = 100;
    private int int_1;
    private int int_2;
    private int int_3;
    private IContainer icontainer_0;
    private Panel bg;
    private Panel slider;

    public BunifuVTrackbar()
    {
      this.InitializeComponent();
      Bunifu.Framework.License.Check((Control) this);
    }

    public event EventHandler ValueChanged;

    public int Value
    {
      get
      {
        return this.int_1;
      }
      set
      {
        if (value <= this.int_0)
        {
          this.int_1 = value;
          double height1 = (double) this.Height;
          double height2 = (double) this.slider.Height;
          int top = this.slider.Top;
          this.slider.Top = (int) Math.Truncate((double) this.int_1 * (height1 - height2) / (double) this.MaximumValue);
        }
        else
        {
          int num = (int) MessageBox.Show("Cannot exceed maximum Value");
        }
      }
    }

    public int BorderRadius
    {
      set
      {
        this.int_2 = value;
        Elipse.Apply((Control) this.bg, this.int_2);
      }
      get
      {
        return this.int_2;
      }
    }

    public int SliderRadius
    {
      set
      {
        this.int_3 = value;
        Elipse.Apply((Control) this.slider, this.int_3);
      }
      get
      {
        return this.int_3;
      }
    }

    public int MaximumValue
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        this.slider.Top = (this.Height - 15) * this.int_1 / this.int_0;
      }
    }

    public Color IndicatorColor
    {
      set
      {
        this.slider.BackColor = value;
      }
      get
      {
        return this.slider.BackColor;
      }
    }

    public Color BackgroudColor
    {
      set
      {
        this.bg.BackColor = value;
      }
      get
      {
        return this.bg.BackColor;
      }
    }

    private void BunifuVTrackbar_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void slider_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int num = e.Y + this.slider.Top;
      if (num < 0)
      {
        this.slider.Top = 0;
        this.int_1 = 0;
      }
      else if (num + this.slider.Height > this.Height)
      {
        this.slider.Top = this.Height - this.slider.Height;
        this.int_1 = this.MaximumValue;
      }
      else
      {
        this.slider.Top = num;
        this.int_1 = (int) Math.Truncate((double) this.MaximumValue * (double) this.slider.Top / ((double) this.Height - (double) this.slider.Height));
      }
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }

    private void bg_Paint(object sender, PaintEventArgs e)
    {
    }

    private void BunifuVTrackbar_Resize(object sender, EventArgs e)
    {
      this.Width = this.slider.Width + 10;
      this.bg.Height = this.Height;
      this.bg.Top = 0;
      Elipse.Apply((Control) this.bg, this.int_2);
      Elipse.Apply((Control) this.slider, this.int_3);
    }

    private void bg_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int y = e.Y;
      if (y < 0 || y + this.slider.Height > this.Height)
        return;
      this.slider.Top = y;
      this.int_1 = (int) Math.Truncate((double) this.MaximumValue * (double) this.slider.Top / ((double) this.Height - (double) this.slider.Height));
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.bg = new Panel();
      this.slider = new Panel();
      this.SuspendLayout();
      this.bg.BackColor = Color.DarkGray;
      this.bg.Cursor = Cursors.Hand;
      this.bg.Location = new Point(9, 8);
      this.bg.Name = "bg";
      this.bg.Size = new Size(10, 408);
      this.bg.TabIndex = 0;
      this.bg.Paint += new PaintEventHandler(this.bg_Paint);
      this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
      this.slider.BackColor = Color.SeaGreen;
      this.slider.Cursor = Cursors.Hand;
      this.slider.Location = new Point(4, 0);
      this.slider.Name = "slider";
      this.slider.Size = new Size(20, 20);
      this.slider.TabIndex = 1;
      this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.slider);
      this.Controls.Add((Control) this.bg);
      this.Name = nameof (BunifuVTrackbar);
      this.Size = new Size(28, 415);
      this.Load += new EventHandler(this.BunifuVTrackbar_Load);
      this.Resize += new EventHandler(this.BunifuVTrackbar_Resize);
      this.ResumeLayout(false);
    }
  }
}
