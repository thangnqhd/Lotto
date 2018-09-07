// Decompiled with JetBrains decompiler
// Type: ns1.BunifuSwitch
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
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DebuggerStepThrough]
  [DefaultEvent("Click")]
  public class BunifuSwitch : UserControl
  {
    private bool bool_0 = true;
    private Color color_0 = Color.SeaGreen;
    private Color color_1 = Color.DarkGray;
    private int int_0;
    private int int_1;
    private int int_2;
    private IContainer icontainer_0;
    private Panel panel1;
    private BunifuCustomLabel customLabel1;

    public BunifuSwitch()
    {
      this.InitializeComponent();
      this.int_0 = this.Width;
      this.int_1 = this.Height;
      Bunifu.Framework.License.Check((Control) this);
    }

    public int BorderRadius
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
        Elipse.Apply((Control) this, this.int_2);
      }
    }

    public bool Value
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        if (value)
        {
          this.panel1.Dock = DockStyle.Left;
          this.panel1.BackColor = this.color_0;
          this.customLabel1.Dock = DockStyle.Right;
          this.customLabel1.Text = "On";
        }
        else
        {
          this.panel1.Dock = DockStyle.Right;
          this.panel1.BackColor = this.color_1;
          this.customLabel1.Dock = DockStyle.Left;
          this.customLabel1.Text = "Off";
        }
        this.bool_0 = value;
      }
    }

    public Color Textcolor
    {
      get
      {
        return this.customLabel1.ForeColor;
      }
      set
      {
        this.customLabel1.ForeColor = value;
      }
    }

    public Color Oncolor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        if (this.bool_0)
          this.panel1.BackColor = value;
        this.color_0 = value;
      }
    }

    public Color Onoffcolor
    {
      get
      {
        return this.color_1;
      }
      set
      {
        if (!this.bool_0)
          this.panel1.BackColor = value;
        this.color_1 = value;
      }
    }

    private void BunifuSwitch_Click(object sender, EventArgs e)
    {
      this.Value = !this.Value;
    }

    private void BunifuSwitch_Resize(object sender, EventArgs e)
    {
      Elipse.Apply((Control) this, this.int_2);
      this.Width = this.int_0;
      this.Height = this.int_1;
    }

    private void BunifuSwitch_ForeColorChanged(object sender, EventArgs e)
    {
      this.customLabel1.ForeColor = this.ForeColor;
    }

    private void BunifuSwitch_Load(object sender, EventArgs e)
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
      this.panel1 = new Panel();
      this.customLabel1 = new BunifuCustomLabel();
      this.SuspendLayout();
      this.panel1.BackColor = Color.SeaGreen;
      this.panel1.Cursor = Cursors.Hand;
      this.panel1.Dock = DockStyle.Left;
      this.panel1.Enabled = false;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(37, 19);
      this.panel1.TabIndex = 0;
      this.panel1.Click += new EventHandler(this.BunifuSwitch_Click);
      this.customLabel1.Dock = DockStyle.Right;
      this.customLabel1.Enabled = false;
      this.customLabel1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.customLabel1.ForeColor = Color.FromArgb(224, 224, 224);
      this.customLabel1.Location = new Point(26, 0);
      this.customLabel1.Name = "customLabel1";
      this.customLabel1.Size = new Size(25, 19);
      this.customLabel1.TabIndex = 1;
      this.customLabel1.Text = "On";
      this.customLabel1.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(64, 64, 64);
      this.Controls.Add((Control) this.customLabel1);
      this.Controls.Add((Control) this.panel1);
      this.Cursor = Cursors.Hand;
      this.ForeColor = Color.FromArgb(224, 224, 224);
      this.Name = nameof (BunifuSwitch);
      this.Size = new Size(51, 19);
      this.Load += new EventHandler(this.BunifuSwitch_Load);
      this.ForeColorChanged += new EventHandler(this.BunifuSwitch_ForeColorChanged);
      this.Click += new EventHandler(this.BunifuSwitch_Click);
      this.Resize += new EventHandler(this.BunifuSwitch_Resize);
      this.ResumeLayout(false);
    }
  }
}
