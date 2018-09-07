// Decompiled with JetBrains decompiler
// Type: ns1.BunifuGauge
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace ns1
{
  public class BunifuGauge : UserControl
  {
    private Color color_0 = Color.Gray;
    private Color color_1 = Color.SeaGreen;
    private int int_1 = 30;
    private Color color_2 = Color.SeaGreen;
    private Color color_3 = Color.Tomato;
    private int int_0;
    private IContainer icontainer_0;
    private Label lblpass;
    private Label lblmin;
    private Label lblmax;
    private BunifuColorTransition bunifuColorTransition_0;

    public BunifuGauge()
    {
      this.InitializeComponent();
      this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) this, (object) true, (object[]) null);
      this.BunifuGauge_Resize((object) this, new EventArgs());
      this.method_0(this.int_0);
    }

    public Color ProgressColor1
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
        this.bunifuColorTransition_0.Color1 = this.color_2;
        this.method_0(this.int_0);
      }
    }

    public Color ProgressColor2
    {
      get
      {
        return this.color_3;
      }
      set
      {
        this.color_3 = value;
        this.bunifuColorTransition_0.Color2 = this.color_3;
        this.method_0(this.int_0);
      }
    }

    public Color ProgressBgColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.method_0(this.int_0);
      }
    }

    public int Value
    {
      get
      {
        return this.int_0;
      }
      set
      {
        if (value > 100)
          return;
        this.int_0 = value;
        this.bunifuColorTransition_0.ProgessValue = this.int_0;
        this.method_0(this.int_0);
      }
    }

    public int Thickness
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
        this.method_0(this.int_0);
      }
    }

    private void method_0(int int_2)
    {
      Size size = this.Size;
      int width = size.Width;
      size = this.Size;
      int height = size.Height;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap);
      graphics1.SmoothingMode = SmoothingMode.HighQuality;
      graphics1.Clear(Color.Transparent);
      Pen pen1 = new Pen(this.color_0, (float) this.int_1);
      int num = this.Size.Width - this.int_1 * 2;
      Rectangle rect = new Rectangle(this.int_1, this.Size.Height / 4, num, num);
      Pen pen2 = new Pen(this.color_1, (float) this.int_1);
      Graphics graphics2 = Graphics.FromImage((Image) bitmap);
      graphics2.SmoothingMode = SmoothingMode.HighQuality;
      graphics2.DrawArc(pen1, rect, 180f, 180f);
      this.lblpass.Text = int_2.ToString() + "%";
      graphics2.DrawArc(pen2, rect, 180f, (float) this.method_1(int_2));
      this.BackgroundImage = (Image) bitmap;
    }

    private int method_1(int int_2)
    {
      return int.Parse(Math.Round((double) int_2 * 180.0 / 100.0, 0).ToString());
    }

    private void BunifuGauge_Resize(object sender, EventArgs e)
    {
      this.method_0(this.int_0);
      this.lblpass.Top = this.Height - this.lblpass.Height - 30;
      this.lblmin.Top = this.lblmax.Top = this.Height - this.lblmax.Height - 10;
      this.lblmin.Left = 20;
      this.lblmax.Left = this.Size.Width - this.lblmax.Width - 20;
      this.lblpass.Left = this.Width / 2 - this.lblpass.Width / 2;
    }

    private void BunifuGauge_ForeColorChanged(object sender, EventArgs e)
    {
      this.lblpass.ForeColor = this.lblmin.ForeColor = this.lblmax.ForeColor = this.ForeColor;
      this.method_0(this.int_0);
    }

    private void BunifuGauge_FontChanged(object sender, EventArgs e)
    {
      this.lblpass.Font = this.Font;
      this.method_0(this.int_0);
    }

    private void bunifuColorTransition_0_OnValueChange(object sender, EventArgs e)
    {
      this.color_1 = this.bunifuColorTransition_0.Value;
    }

    private void BunifuGauge_Load(object sender, EventArgs e)
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
      this.icontainer_0 = (IContainer) new Container();
      this.lblpass = new Label();
      this.lblmin = new Label();
      this.lblmax = new Label();
      this.bunifuColorTransition_0 = new BunifuColorTransition(this.icontainer_0);
      this.SuspendLayout();
      this.lblpass.AutoSize = true;
      this.lblpass.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblpass.Location = new Point(83, 34);
      this.lblpass.Margin = new Padding(6, 0, 6, 0);
      this.lblpass.Name = "lblpass";
      this.lblpass.Size = new Size(38, 24);
      this.lblpass.TabIndex = 1;
      this.lblpass.Text = "0%";
      this.lblmin.AutoSize = true;
      this.lblmin.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblmin.Location = new Point(26, 86);
      this.lblmin.Margin = new Padding(6, 0, 6, 0);
      this.lblmin.Name = "lblmin";
      this.lblmin.Size = new Size(15, 17);
      this.lblmin.TabIndex = 2;
      this.lblmin.Text = "0";
      this.lblmax.AutoSize = true;
      this.lblmax.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblmax.Location = new Point(145, 86);
      this.lblmax.Margin = new Padding(6, 0, 6, 0);
      this.lblmax.Name = "lblmax";
      this.lblmax.Size = new Size(29, 17);
      this.lblmax.TabIndex = 3;
      this.lblmax.Text = "100";
      this.bunifuColorTransition_0.Color1 = Color.SeaGreen;
      this.bunifuColorTransition_0.Color2 = Color.Tomato;
      this.bunifuColorTransition_0.ProgessValue = 0;
      this.bunifuColorTransition_0.OnValueChange += new EventHandler(this.bunifuColorTransition_0_OnValueChange);
      this.AutoScaleDimensions = new SizeF(12f, 24f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.lblmax);
      this.Controls.Add((Control) this.lblmin);
      this.Controls.Add((Control) this.lblpass);
      this.Font = new Font("Century Gothic", 15.75f);
      this.Margin = new Padding(6);
      this.Name = nameof (BunifuGauge);
      this.Size = new Size(174, 117);
      this.Load += new EventHandler(this.BunifuGauge_Load);
      this.FontChanged += new EventHandler(this.BunifuGauge_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuGauge_ForeColorChanged);
      this.Resize += new EventHandler(this.BunifuGauge_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
