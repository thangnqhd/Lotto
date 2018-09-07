// Decompiled with JetBrains decompiler
// Type: ns1.BunifuTrackbar
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
  [DefaultEvent("ValueChanged")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuTrackbar : UserControl
  {
    private int int_0 = 100;
    private Drag drag_0 = new Drag();
    private int int_1;
    private int int_2;
    private int int_3;
    private IContainer icontainer_0;
    private Panel bg;
    private Panel slider;

    public BunifuTrackbar()
    {
      this.InitializeComponent();
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
          this.slider.Left = (this.Width - 15) * this.int_1 / this.int_0;
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
        this.slider.Left = (this.Width - this.slider.Width) * this.int_1 / this.int_0;
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

    private void BunifuTrackbar_Load(object sender, EventArgs e)
    {
      Bunifu.Framework.License.Check((Control) this);
    }

    private void slider_MouseMove(object sender, MouseEventArgs e)
    {
      int left = this.slider.Left;
      if (left < 0 || left + this.slider.Width > this.Width)
        return;
      this.drag_0.MoveObject(true, false);
      int num = this.int_0 * this.slider.Left / (this.Width - this.slider.Width);
      this.int_1 = num;
      if (num < 0)
        this.Value = 0;
      else if (num > this.int_0)
        this.Value = this.MaximumValue;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }

    private void bg_Paint(object sender, PaintEventArgs e)
    {
    }

    private void BunifuTrackbar_Resize(object sender, EventArgs e)
    {
      this.Height = this.slider.Height + 10;
      this.bg.Width = this.Width;
      this.bg.Left = 0;
      Elipse.Apply((Control) this.bg, this.int_2);
      Elipse.Apply((Control) this.slider, this.int_3);
    }

    private void bg_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int x = e.X;
      if (x <= 0 || x + this.slider.Width >= this.Width)
        return;
      this.slider.Left = x;
      this.Value = this.int_0 * this.slider.Left / (this.Width - 15);
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }

    private void slider_MouseUp(object sender, MouseEventArgs e)
    {
      this.drag_0.Release();
    }

    private void slider_MouseDown(object sender, MouseEventArgs e)
    {
      this.drag_0.Grab((Control) this.slider);
    }

    private void bg_MouseMove(object sender, MouseEventArgs e)
    {
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
      this.bg.Location = new Point(0, 8);
      this.bg.Name = "bg";
      this.bg.Size = new Size(415, 10);
      this.bg.TabIndex = 0;
      this.bg.Paint += new PaintEventHandler(this.bg_Paint);
      this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
      this.bg.MouseMove += new MouseEventHandler(this.bg_MouseMove);
      this.slider.BackColor = Color.SeaGreen;
      this.slider.Cursor = Cursors.Hand;
      this.slider.Location = new Point(0, 3);
      this.slider.Name = "slider";
      this.slider.Size = new Size(20, 20);
      this.slider.TabIndex = 1;
      this.slider.MouseDown += new MouseEventHandler(this.slider_MouseDown);
      this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
      this.slider.MouseUp += new MouseEventHandler(this.slider_MouseUp);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.slider);
      this.Controls.Add((Control) this.bg);
      this.Name = nameof (BunifuTrackbar);
      this.Size = new Size(415, 28);
      this.Load += new EventHandler(this.BunifuTrackbar_Load);
      this.Resize += new EventHandler(this.BunifuTrackbar_Resize);
      this.ResumeLayout(false);
    }
  }
}
