// Decompiled with JetBrains decompiler
// Type: ns1.BunifuiOSSwitch
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns0;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DebuggerStepThrough]
  [DefaultEvent("OnValueChange")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuiOSSwitch : UserControl
  {
    private bool bool_0 = true;
    private Color color_0 = Color.FromArgb(71, 202, 94);
    private Color color_1 = Color.Gray;
    private Image image_0;
    private Image image_1;
    private IContainer icontainer_0;
    private PictureBox pictureBox1;

    public BunifuiOSSwitch()
    {
      this.InitializeComponent();
      this.image_0 = Class7.smethod_1(this.BackgroundImage, this.OnColor);
      this.image_1 = Class7.smethod_1(this.BackgroundImage, this.OffColor);
    }

    private void BunifuiOSSwitch_Resize(object sender, EventArgs e)
    {
      this.Size = new Size(43, 25);
    }

    private void BunifuiOSSwitch_Click(object sender, EventArgs e)
    {
      this.Value = !this.bool_0;
    }

    public event EventHandler OnValueChange;

    public bool Value
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
        this.method_0();
      }
    }

    private void method_0()
    {
      if (this.Value)
      {
        this.BackgroundImage = this.image_0;
        this.pictureBox1.Left = this.Width - this.pictureBox1.Width;
      }
      else
      {
        this.BackgroundImage = this.image_1;
        this.pictureBox1.Left = 0;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }

    public Color OnColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        if (this.BackgroundImage != null)
          this.image_0 = Class7.smethod_1(this.BackgroundImage, this.OnColor);
        this.method_0();
      }
    }

    public Color OffColor
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
        if (this.BackgroundImage != null)
          this.image_1 = Class7.smethod_1(this.BackgroundImage, this.OffColor);
        this.method_0();
      }
    }

    private void BunifuiOSSwitch_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuiOSSwitch));
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.pictureBox1.Enabled = false;
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(17, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(26, 25);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.Controls.Add((Control) this.pictureBox1);
      this.Cursor = Cursors.Hand;
      this.DoubleBuffered = true;
      this.Name = nameof (BunifuiOSSwitch);
      this.Size = new Size(43, 25);
      this.Load += new EventHandler(this.BunifuiOSSwitch_Load);
      this.Click += new EventHandler(this.BunifuiOSSwitch_Click);
      this.Resize += new EventHandler(this.BunifuiOSSwitch_Resize);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
