// Decompiled with JetBrains decompiler
// Type: ns1.BunifuTextbox
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
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DefaultEvent("OnTextChange")]
  [DebuggerStepThrough]
  public class BunifuTextbox : UserControl
  {
    private IContainer icontainer_0;
    private PictureBox _Picture;
    public TextBox _TextBox;

    public BunifuTextbox()
    {
      this.InitializeComponent();
      this._Picture.Top = this.Height / 2 - this._Picture.Height / 2;
      this._TextBox.Top = this.Height / 2 - this._TextBox.Height / 2;
      this._TextBox.Width = this.Width - this._TextBox.Left - 10;
      this.BackgroundImage = Class7.smethod_1(this.BackgroundImage, this.ForeColor);
      this._Picture.Image = Class7.smethod_1(this._Picture.Image, this.ForeColor);
      Bunifu.Framework.License.Check((Control) this);
    }

    public event EventHandler OnTextChange;

    public Image Icon
    {
      get
      {
        return this._Picture.Image;
      }
      set
      {
        this._Picture.Image = value;
        this._Picture.Image = Class7.smethod_1(this._Picture.Image, this.ForeColor);
      }
    }

    public string text
    {
      get
      {
        return this._TextBox.Text;
      }
      set
      {
        this._TextBox.Text = value;
      }
    }

    private void BunifuTextbox_ForeColorChanged(object sender, EventArgs e)
    {
      this._TextBox.ForeColor = this.ForeColor;
      this.BackgroundImage = Class7.smethod_1(this.BackgroundImage, this.ForeColor);
      this._Picture.Image = Class7.smethod_1(this._Picture.Image, this.ForeColor);
    }

    private void BunifuTextbox_Resize(object sender, EventArgs e)
    {
      this._Picture.Top = this.Height / 2 - this._Picture.Height / 2;
      this._TextBox.Top = this.Height / 2 - this._TextBox.Height / 2;
      this._TextBox.Width = this.Width - this._TextBox.Left - 10;
    }

    private void BunifuTextbox_BackColorChanged(object sender, EventArgs e)
    {
      this._TextBox.BackColor = this.BackColor;
    }

    private void _TextBox_TextChanged(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }

    private void BunifuTextbox_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    public event EventHandler KeyDown;

    private void _TextBox_KeyDown(object sender, KeyEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, (EventArgs) e);
    }

    public event EventHandler KeyPress;

    private void _TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, (EventArgs) e);
    }

    public event EventHandler KeyUp;

    private void _TextBox_KeyUp(object sender, KeyEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_3 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_3((object) this, (EventArgs) e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuTextbox));
      this._TextBox = new TextBox();
      this._Picture = new PictureBox();
      ((ISupportInitialize) this._Picture).BeginInit();
      this.SuspendLayout();
      this._TextBox.BackColor = Color.Silver;
      this._TextBox.BorderStyle = BorderStyle.None;
      this._TextBox.Font = new Font("Microsoft Sans Serif", 11f);
      this._TextBox.ForeColor = Color.SeaGreen;
      this._TextBox.Location = new Point(40, 13);
      this._TextBox.Multiline = true;
      this._TextBox.Name = "_TextBox";
      this._TextBox.Size = new Size(195, 20);
      this._TextBox.TabIndex = 0;
      this._TextBox.Text = "Bunifu TextBox";
      this._TextBox.TextChanged += new EventHandler(this._TextBox_TextChanged);
      this._TextBox.KeyDown += new KeyEventHandler(this._TextBox_KeyDown);
      this._TextBox.KeyPress += new KeyPressEventHandler(this._TextBox_KeyPress);
      this._TextBox.KeyUp += new KeyEventHandler(this._TextBox_KeyUp);
      this._Picture.BackColor = Color.Transparent;
      this._Picture.Image = (Image) componentResourceManager.GetObject("_Picture.Image");
      this._Picture.Location = new Point(9, 7);
      this._Picture.Name = "_Picture";
      this._Picture.Size = new Size(23, 25);
      this._Picture.SizeMode = PictureBoxSizeMode.Zoom;
      this._Picture.TabIndex = 1;
      this._Picture.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Silver;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.Controls.Add((Control) this._Picture);
      this.Controls.Add((Control) this._TextBox);
      this.DoubleBuffered = true;
      this.ForeColor = Color.SeaGreen;
      this.Name = nameof (BunifuTextbox);
      this.Size = new Size(250, 42);
      this.Load += new EventHandler(this.BunifuTextbox_Load);
      this.BackColorChanged += new EventHandler(this.BunifuTextbox_BackColorChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuTextbox_ForeColorChanged);
      this.Resize += new EventHandler(this.BunifuTextbox_Resize);
      ((ISupportInitialize) this._Picture).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
