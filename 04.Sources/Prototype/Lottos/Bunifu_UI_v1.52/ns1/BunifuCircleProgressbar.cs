// Decompiled with JetBrains decompiler
// Type: ns1.BunifuCircleProgressbar
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace ns1
{
  [DefaultEvent("ProgessChanged")]
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuCircleProgressbar : UserControl
  {
    private int int_0 = 5;
    private int int_1 = 8;
    private Color color_0 = Color.SeaGreen;
    private Color color_1 = Color.Gainsboro;
    private int int_3 = 100;
    private int int_5 = -90;
    private int int_6 = 5;
    private int int_2;
    private int int_4;
    private bool bool_0;
    private IContainer icontainer_0;
    private Label lblpass;
    private Timer timer_0;

    public BunifuCircleProgressbar()
    {
      this.InitializeComponent();
      this.lblpass.Font = this.Font;
      this.lblpass.ForeColor = this.ForeColor;
      this.lblpass.Top = this.Height / 2 - this.lblpass.Height / 2;
      this.lblpass.Left = this.Width / 2 - this.lblpass.Width / 2;
      this.Width = this.Height;
      int usageMode = (int) LicenseManager.UsageMode;
      Bunifu.Framework.License.Check((Control) this);
      this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) this, (object) true, (object[]) null);
    }

    public int GetPassentage
    {
      get
      {
        return int.Parse(this.lblpass.Text.Replace("%", ""));
      }
    }

    public Color ProgressColor
    {
      set
      {
        this.color_0 = value;
        this.Invalidate();
        this.method_2(this.int_2);
      }
      get
      {
        return this.color_0;
      }
    }

    public bool LabelVisible
    {
      get
      {
        return this.lblpass.Visible;
      }
      set
      {
        this.lblpass.Visible = value;
      }
    }

    public Color ProgressBackColor
    {
      set
      {
        this.color_1 = value;
        this.Invalidate();
        this.method_2(this.int_2);
      }
      get
      {
        return this.color_1;
      }
    }

    public int Value
    {
      set
      {
        if (value <= this.int_3)
        {
          this.int_2 = value;
          this.lblpass.Text = ((int) ((double) this.int_2 / (double) this.int_3 * 100.0)).ToString() + "%";
          this.method_2(this.int_2);
        }
        else
        {
          int num = (int) MessageBox.Show("Maximum Value Exceeded");
        }
      }
      get
      {
        return this.int_2;
      }
    }

    public int LineThickness
    {
      set
      {
        this.int_0 = value;
        this.Invalidate();
        this.method_2(this.int_2);
      }
      get
      {
        return this.int_0;
      }
    }

    public int LineProgressThickness
    {
      set
      {
        this.int_1 = value;
        this.Invalidate();
        this.method_2(this.int_2);
      }
      get
      {
        return this.int_1;
      }
    }

    public int MaxValue
    {
      set
      {
        this.int_3 = value;
        this.Invalidate();
        this.method_2(this.int_2);
      }
      get
      {
        return this.int_3;
      }
    }

    public event EventHandler ProgressChanged;

    private int method_0(int int_7)
    {
      return 360 * int_7 / this.int_3;
    }

    private void method_1()
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, (EventArgs) null);
    }

    private void method_2(int int_7)
    {
      Size size = this.Size;
      int width = size.Width;
      size = this.Size;
      int height = size.Height;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap);
      graphics1.SmoothingMode = SmoothingMode.HighQuality;
      graphics1.Clear(Color.Transparent);
      Rectangle rect = new Rectangle(10, 10, this.Width - 20, this.Width - 20);
      graphics1.DrawArc(new Pen(this.color_1)
      {
        Width = (float) this.int_0
      }, rect, 0.0f, 360f);
      Graphics graphics2 = Graphics.FromImage((Image) bitmap);
      graphics2.SmoothingMode = graphics1.SmoothingMode;
      graphics2.DrawArc(new Pen(this.color_0)
      {
        Width = (float) this.int_1
      }, new Rectangle(10, 10, this.Width - 20, this.Width - 20), (float) this.int_5, (float) this.method_0(int_7));
      this.BackgroundImage = (Image) bitmap;
      this.method_1();
    }

    public int animationIterval
    {
      get
      {
        return this.int_6;
      }
      set
      {
        this.int_6 = value;
      }
    }

    public bool animated
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
        if (this.bool_0)
        {
          this.timer_0.Start();
        }
        else
        {
          this.timer_0.Stop();
          this.int_5 = -90;
          this.method_2(this.int_2);
        }
      }
    }

    public int animationSpeed
    {
      get
      {
        return this.timer_0.Interval;
      }
      set
      {
        this.timer_0.Interval = value;
      }
    }

    private void method_3(object sender, PaintEventArgs e)
    {
    }

    private void BunifuCircleProgressbar_Resize(object sender, EventArgs e)
    {
      this.Invalidate();
      this.lblpass.Top = this.Height / 2 - this.lblpass.Height / 2;
      this.lblpass.Left = this.Width / 2 - this.lblpass.Width / 2;
      this.Width = this.Height;
      this.method_2(this.int_2);
    }

    private void BunifuCircleProgressbar_FontChanged(object sender, EventArgs e)
    {
      this.lblpass.Font = this.Font;
      this.lblpass.ForeColor = this.ForeColor;
      this.lblpass.Top = this.Height / 2 - this.lblpass.Height / 2;
      this.lblpass.Left = this.Width / 2 - this.lblpass.Width / 2;
    }

    private void BunifuCircleProgressbar_ForeColorChanged(object sender, EventArgs e)
    {
      this.lblpass.Font = this.Font;
      this.lblpass.ForeColor = this.ForeColor;
      this.lblpass.Top = this.Height / 2 - this.lblpass.Height / 2;
      this.lblpass.Left = this.Width / 2 - this.lblpass.Width / 2;
    }

    private void method_4(object sender, EventArgs e)
    {
      Elipse.Apply((Control) this.lblpass, this.lblpass.Height);
      this.lblpass.Top = this.Height / 2 - this.lblpass.Height / 2;
      this.lblpass.Left = this.Width / 2 - this.lblpass.Width / 2;
    }

    private void BunifuCircleProgressbar_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      if (this.Value == this.MaxValue || this.Value <= 0)
        return;
      this.int_5 += this.animationIterval;
      this.method_2(this.int_2);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.icontainer_0 = (IContainer) new Container();
      this.lblpass = new Label();
      this.timer_0 = new Timer(this.icontainer_0);
      this.SuspendLayout();
      this.lblpass.AutoSize = true;
      this.lblpass.BackColor = Color.Transparent;
      this.lblpass.Location = new Point(76, 72);
      this.lblpass.Name = "lblpass";
      this.lblpass.Size = new Size(67, 39);
      this.lblpass.TabIndex = 0;
      this.lblpass.Text = "0%";
      this.timer_0.Interval = 300;
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.AutoScaleDimensions = new SizeF(20f, 39f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.lblpass);
      this.Font = new Font("Microsoft Sans Serif", 26.25f);
      this.ForeColor = Color.SeaGreen;
      this.Margin = new Padding(10, 9, 10, 9);
      this.Name = nameof (BunifuCircleProgressbar);
      this.Size = new Size(205, 201);
      this.Load += new EventHandler(this.BunifuCircleProgressbar_Load);
      this.FontChanged += new EventHandler(this.BunifuCircleProgressbar_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuCircleProgressbar_ForeColorChanged);
      this.Resize += new EventHandler(this.BunifuCircleProgressbar_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
