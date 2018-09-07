// Decompiled with JetBrains decompiler
// Type: ns1.BunifuCheckbox
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using ns0;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DefaultEvent("OnChange")]
  [DebuggerStepThrough]
  public class BunifuCheckbox : UserControl
  {
    private bool bool_0 = true;
    private Color color_0 = Color.FromArgb(51, 205, 117);
    private Color color_1 = Color.FromArgb(132, 135, 140);
    private IContainer icontainer_0;
    private PictureBox check;

    public BunifuCheckbox()
    {
      this.InitializeComponent();
      Elipse.Apply((Control) this, 5);
    }

    public event EventHandler OnChange;

    public Color CheckedOnColor
    {
      set
      {
        this.color_0 = value;
        this.BackColor = this.color_0;
      }
      get
      {
        return this.color_0;
      }
    }

    public Color ChechedOffColor
    {
      set
      {
        this.color_1 = value;
      }
      get
      {
        return this.color_1;
      }
    }

    public bool Checked
    {
      set
      {
        this.bool_0 = value;
        this.check.Visible = this.bool_0;
        if (this.bool_0)
          this.BackColor = this.color_0;
        else
          this.BackColor = this.color_1;
      }
      get
      {
        return this.bool_0;
      }
    }

    private void BunifuCheckbox_Click(object sender, EventArgs e)
    {
      this.check.Visible = !this.check.Visible;
      this.Checked = this.check.Visible;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, (EventArgs) null);
    }

    private void BunifuCheckbox_Resize(object sender, EventArgs e)
    {
      this.Size = new Size(20, 20);
    }

    private void BunifuCheckbox_ForeColorChanged(object sender, EventArgs e)
    {
      this.check.Image = Class7.smethod_1(this.check.Image, this.ForeColor);
    }

    private void BunifuCheckbox_Load(object sender, EventArgs e)
    {
      if (this.bool_0)
        this.BackColor = this.color_0;
      else
        this.BackColor = this.color_1;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuCheckbox));
      this.check = new PictureBox();
      ((ISupportInitialize) this.check).BeginInit();
      this.SuspendLayout();
      this.check.BackColor = Color.Transparent;
      this.check.Dock = DockStyle.Fill;
      this.check.Image = (Image) componentResourceManager.GetObject("check.Image");
      this.check.Location = new Point(0, 0);
      this.check.Name = "check";
      this.check.Size = new Size(20, 20);
      this.check.SizeMode = PictureBoxSizeMode.StretchImage;
      this.check.TabIndex = 0;
      this.check.TabStop = false;
      this.check.Click += new EventHandler(this.BunifuCheckbox_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.SeaGreen;
      this.Controls.Add((Control) this.check);
      this.ForeColor = Color.White;
      this.Name = nameof (BunifuCheckbox);
      this.Size = new Size(20, 20);
      this.Load += new EventHandler(this.BunifuCheckbox_Load);
      this.ForeColorChanged += new EventHandler(this.BunifuCheckbox_ForeColorChanged);
      this.Click += new EventHandler(this.BunifuCheckbox_Click);
      this.Resize += new EventHandler(this.BunifuCheckbox_Resize);
      ((ISupportInitialize) this.check).EndInit();
      this.ResumeLayout(false);
    }
  }
}
