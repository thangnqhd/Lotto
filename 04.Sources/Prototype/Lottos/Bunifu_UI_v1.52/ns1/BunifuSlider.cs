// Decompiled with JetBrains decompiler
// Type: ns1.BunifuSlider
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
  [DefaultEvent("ValueChanged")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DebuggerStepThrough]
  public class BunifuSlider : UserControl
  {
    private int int_0 = 100;
    private int int_1;
    private int int_2;
    private IContainer icontainer_0;
    private Panel bg;
    private Panel slider;
    private Panel panel1;

    public BunifuSlider()
    {
      this.InitializeComponent();
      this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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
          double width1 = (double) this.Width;
          double width2 = (double) this.slider.Width;
          int left = this.slider.Left;
          this.slider.Left = (int) Math.Truncate((double) this.int_1 * (width1 - width2) / (double) this.MaximumValue);
          this.panel1.Width = this.slider.Left + this.slider.Width / 2;
        }
        else
        {
          int num = (int) MessageBox.Show("Cannot exceed maximum Value");
        }
      }
    }

    private void slider_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int num = e.X + this.slider.Left;
      if (num < 0)
      {
        this.slider.Left = 0;
        this.int_1 = 0;
      }
      else if (num + this.slider.Width > this.Width)
      {
        this.slider.Left = this.Width - this.slider.Width;
        this.int_1 = this.MaximumValue;
      }
      else
      {
        this.slider.Left = num;
        this.int_1 = (int) Math.Truncate((double) this.MaximumValue * (double) this.slider.Left / ((double) this.Width - (double) this.slider.Width));
      }
      this.panel1.Width = this.slider.Left + this.slider.Width / 2;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
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
        double width1 = (double) this.Width;
        double width2 = (double) this.slider.Width;
        int left = this.slider.Left;
        this.slider.Left = (int) Math.Truncate((double) this.int_1 * (width1 - width2) / (double) this.MaximumValue);
        this.panel1.Width = this.slider.Left + this.slider.Width / 2;
      }
    }

    public Color IndicatorColor
    {
      set
      {
        this.slider.BackColor = value;
        this.panel1.BackColor = this.slider.BackColor;
      }
      get
      {
        return this.slider.BackColor;
      }
    }

    public int BorderRadius
    {
      set
      {
        this.int_2 = value;
        Elipse.Apply((Control) this.bg, this.int_2);
        Elipse.Apply((Control) this.slider, this.int_2);
      }
      get
      {
        return this.int_2;
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

    private void BunifuSlider_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void bg_Paint(object sender, PaintEventArgs e)
    {
    }

    private void BunifuSlider_Resize(object sender, EventArgs e)
    {
      this.Height = this.slider.Height + 10;
      this.bg.Width = this.Width;
      this.bg.Left = 0;
      Elipse.Apply((Control) this.bg, this.int_2);
      Elipse.Apply((Control) this.slider, this.int_2);
    }

    private void bg_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int x = e.X;
      if (x <= 0 || x + this.slider.Width >= this.Width)
        return;
      this.slider.Left = x;
      this.int_1 = (int) Math.Truncate((double) this.MaximumValue * (double) this.slider.Left / ((double) this.Width - (double) this.slider.Width));
      this.panel1.Width = this.slider.Left + this.slider.Width / 2;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }

    public event EventHandler ValueChangeComplete;

    private void slider_MouseUp(object sender, MouseEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, new EventArgs());
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
      this.panel1 = new Panel();
      this.slider = new Panel();
      this.bg.SuspendLayout();
      this.SuspendLayout();
      this.bg.BackColor = Color.DarkGray;
      this.bg.Controls.Add((Control) this.panel1);
      this.bg.Cursor = Cursors.Hand;
      this.bg.Location = new Point(3, 8);
      this.bg.Name = "bg";
      this.bg.Size = new Size(408, 10);
      this.bg.TabIndex = 0;
      this.bg.Paint += new PaintEventHandler(this.bg_Paint);
      this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
      this.panel1.BackColor = Color.SeaGreen;
      this.panel1.Cursor = Cursors.Hand;
      this.panel1.Dock = DockStyle.Left;
      this.panel1.Enabled = false;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(0, 10);
      this.panel1.TabIndex = 2;
      this.slider.BackColor = Color.SeaGreen;
      this.slider.Cursor = Cursors.Hand;
      this.slider.Location = new Point(0, 3);
      this.slider.Name = "slider";
      this.slider.Size = new Size(20, 20);
      this.slider.TabIndex = 1;
      this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
      this.slider.MouseUp += new MouseEventHandler(this.slider_MouseUp);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.slider);
      this.Controls.Add((Control) this.bg);
      this.Name = nameof (BunifuSlider);
      this.Size = new Size(415, 28);
      this.Load += new EventHandler(this.BunifuSlider_Load);
      this.Resize += new EventHandler(this.BunifuSlider_Resize);
      this.bg.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
