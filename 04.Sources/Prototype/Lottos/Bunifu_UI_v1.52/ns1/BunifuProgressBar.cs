// Decompiled with JetBrains decompiler
// Type: ns1.BunifuProgressBar
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
  [DefaultEvent("progressChanged")]
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuProgressBar : UserControl
  {
    public int Maximum_Value = 100;
    private int int_0 = 5;
    public int _Value;
    private IContainer icontainer_0;
    private Panel slider;

    public BunifuProgressBar()
    {
      this.InitializeComponent();
    }

    public event EventHandler progressChanged;

    public int BorderRadius
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        Elipse.Apply((Control) this.slider, this.int_0);
        Elipse.Apply((Control) this, this.int_0);
      }
    }

    private void BunifuProgressBar_Resize(object sender, EventArgs e)
    {
      this.slider.Width = this.Width * this._Value / this.Maximum_Value;
      Elipse.Apply((Control) this.slider, this.int_0);
      Elipse.Apply((Control) this, this.int_0);
    }

    public Color ProgressColor
    {
      get
      {
        return this.slider.BackColor;
      }
      set
      {
        this.slider.BackColor = value;
      }
    }

    public int Value
    {
      get
      {
        return this._Value;
      }
      set
      {
        if (value > this.Maximum_Value)
          throw new Exception("Maxium Value Rached");
        this._Value = value;
        this.slider.Width = this.Width * this._Value / this.Maximum_Value;
        Elipse.Apply((Control) this.slider, this.int_0);
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, new EventArgs());
      }
    }

    public int MaximumValue
    {
      get
      {
        return this.Maximum_Value;
      }
      set
      {
        this.Maximum_Value = value;
        try
        {
          this.slider.Width = this.Width * this._Value / this.Maximum_Value;
          Elipse.Apply((Control) this.slider, this.int_0);
        }
        catch (Exception ex)
        {
        }
      }
    }

    private void BunifuProgressBar_Load(object sender, EventArgs e)
    {
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
      this.slider = new Panel();
      this.SuspendLayout();
      this.slider.BackColor = Color.Teal;
      this.slider.Dock = DockStyle.Left;
      this.slider.Location = new Point(0, 0);
      this.slider.Name = "slider";
      this.slider.Size = new Size(0, 10);
      this.slider.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Silver;
      this.Controls.Add((Control) this.slider);
      this.Name = nameof (BunifuProgressBar);
      this.Size = new Size(410, 10);
      this.Load += new EventHandler(this.BunifuProgressBar_Load);
      this.Resize += new EventHandler(this.BunifuProgressBar_Resize);
      this.ResumeLayout(false);
    }
  }
}
