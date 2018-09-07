// Decompiled with JetBrains decompiler
// Type: ns1.BunifuRange
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
  [DefaultEvent("RangeChanged")]
  public class BunifuRange : UserControl
  {
    private int int_0 = 100;
    private int int_1;
    private int int_2;
    private int int_3;
    private IContainer icontainer_0;
    private Panel bg;
    private Panel slider;
    private Panel slider2;
    private Panel FILL;

    public BunifuRange()
    {
      this.InitializeComponent();
      this.RangeMax = this.int_0 * this.slider2.Left / (this.Width - 15);
      this.RangeMin = this.int_0 * this.slider.Left / (this.Width - 15);
      this.FILL.Left = this.slider.Left + this.slider.Width / 2;
      this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
      Bunifu.Framework.License.Check((Control) this);
    }

    public event EventHandler RangeChanged;

    public event EventHandler RangeMaxChanged;

    public event EventHandler RangeMinChanged;

    public int BorderRadius
    {
      set
      {
        this.int_3 = value;
        Elipse.Apply((Control) this.bg, this.int_3);
        Elipse.Apply((Control) this.slider, this.int_3);
        Elipse.Apply((Control) this.slider2, this.int_3);
      }
      get
      {
        return this.int_3;
      }
    }

    public int RangeMax
    {
      get
      {
        return this.int_2;
      }
      set
      {
        int left = this.slider2.Left;
        if (value > this.int_0)
          throw new Exception("Maximum Value Reached");
        this.int_2 = value;
        this.slider2.Left = (this.Width - 15) * this.int_2 / this.int_0;
        if (this.slider2.Left < this.slider.Left)
        {
          this.slider2.Left = left;
          throw new Exception("Minium Value Reached");
        }
        this.FILL.Left = this.slider.Left + this.slider.Width / 2;
        this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
      }
    }

    public int RangeMin
    {
      get
      {
        return this.int_1;
      }
      set
      {
        int left = this.slider.Left;
        if (value > this.int_0)
          throw new Exception("Minium Value Reached");
        this.int_1 = value;
        this.slider.Left = (this.Width - 15) * this.int_1 / this.int_0;
        if (this.slider.Left > this.slider2.Left)
        {
          this.slider.Left = left;
          throw new Exception("Minium Value Reached");
        }
        this.FILL.Left = this.slider.Left + this.slider.Width / 2;
        this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
      }
    }

    public int MaximumRange
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        this.RangeMax = this.int_0 * this.slider2.Left / (this.Width - 15);
        this.RangeMin = this.int_0 * this.slider.Left / (this.Width - 15);
        this.FILL.Left = this.slider.Left + this.slider.Width / 2;
        this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
      }
    }

    public Color IndicatorColor
    {
      set
      {
        this.slider.BackColor = this.FILL.BackColor = this.slider2.BackColor = value;
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

    private void BunifuRange_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void slider_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int num = e.X + this.slider.Left;
      if (num >= this.slider2.Left || num <= 0 || num + this.slider.Width >= this.Width)
        return;
      this.slider.Left = num;
      this.FILL.Left = this.slider.Left + this.slider.Width / 2;
      this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
      this.RangeMin = this.int_0 * this.slider.Left / (this.Width - 15);
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_0((object) this, new EventArgs());
      }
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, new EventArgs());
    }

    private void slider2_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int num = e.X + this.slider2.Left;
      if (num <= this.slider.Left || num + this.slider2.Width >= this.Width)
        return;
      this.slider2.Left = num;
      this.FILL.Left = this.slider.Left + this.slider.Width / 2;
      this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
      this.RangeMax = this.int_0 * this.slider2.Left / (this.Width - 15);
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_0((object) this, new EventArgs());
      }
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, new EventArgs());
    }

    private void bg_Paint(object sender, PaintEventArgs e)
    {
    }

    private void BunifuRange_Resize(object sender, EventArgs e)
    {
      this.Height = this.slider.Height + 10;
      this.bg.Width = this.Width;
      this.bg.Left = 0;
      Elipse.Apply((Control) this.bg, this.int_3);
      Elipse.Apply((Control) this.slider, this.int_3);
      Elipse.Apply((Control) this.slider2, this.int_3);
    }

    private void bg_MouseDown(object sender, MouseEventArgs e)
    {
    }

    private void bg_Resize(object sender, EventArgs e)
    {
      this.FILL.Height = this.bg.Height + 1;
      this.FILL.Top = -1;
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
      this.FILL = new Panel();
      this.slider = new Panel();
      this.slider2 = new Panel();
      this.bg.SuspendLayout();
      this.SuspendLayout();
      this.bg.BackColor = Color.DarkGray;
      this.bg.Controls.Add((Control) this.FILL);
      this.bg.Location = new Point(3, 8);
      this.bg.Name = "bg";
      this.bg.Size = new Size(408, 10);
      this.bg.TabIndex = 0;
      this.bg.Paint += new PaintEventHandler(this.bg_Paint);
      this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
      this.bg.Resize += new EventHandler(this.bg_Resize);
      this.FILL.BackColor = Color.SeaGreen;
      this.FILL.Cursor = Cursors.Hand;
      this.FILL.Location = new Point(18, -5);
      this.FILL.Name = "FILL";
      this.FILL.Size = new Size(183, 20);
      this.FILL.TabIndex = 3;
      this.slider.BackColor = Color.SeaGreen;
      this.slider.Cursor = Cursors.Hand;
      this.slider.Location = new Point(0, 3);
      this.slider.Name = "slider";
      this.slider.Size = new Size(20, 20);
      this.slider.TabIndex = 1;
      this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
      this.slider2.BackColor = Color.SeaGreen;
      this.slider2.Cursor = Cursors.Hand;
      this.slider2.Location = new Point(197, 3);
      this.slider2.Name = "slider2";
      this.slider2.Size = new Size(20, 20);
      this.slider2.TabIndex = 2;
      this.slider2.MouseMove += new MouseEventHandler(this.slider2_MouseMove);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.slider2);
      this.Controls.Add((Control) this.slider);
      this.Controls.Add((Control) this.bg);
      this.Name = nameof (BunifuRange);
      this.Size = new Size(415, 28);
      this.Load += new EventHandler(this.BunifuRange_Load);
      this.Resize += new EventHandler(this.BunifuRange_Resize);
      this.bg.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
