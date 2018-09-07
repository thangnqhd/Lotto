// Decompiled with JetBrains decompiler
// Type: ns1.BunifuDatepicker
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
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DefaultEvent("onValueChanged")]
  public class BunifuDatepicker : UserControl
  {
    private DateTime dateTime_0;
    private int int_0;
    private IContainer icontainer_0;
    public BunifuFlatButton Style;
    private DateTimePicker datp;

    public BunifuDatepicker()
    {
      this.InitializeComponent();
      if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        this.datp.Visible = false;
      else
        this.datp.Visible = true;
      this.Style.Text = this.datp.Value.ToLongDateString();
      this.OnResize((EventArgs) null);
      this.dateTime_0 = this.datp.Value;
      this.Style.ButtonText = this.datp.Text;
      this.dateTime_0 = this.datp.Value;
      Bunifu.Framework.License.Check((Control) this);
    }

    public event EventHandler onValueChanged;

    public DateTime Value
    {
      get
      {
        return this.dateTime_0;
      }
      set
      {
        this.dateTime_0 = value;
        this.datp.Value = this.dateTime_0;
        this.Style.ButtonText = this.datp.Text;
      }
    }

    public int BorderRadius
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        Elipse.Apply((Control) this, this.int_0);
      }
    }

    public DateTimePickerFormat Format
    {
      get
      {
        return this.datp.Format;
      }
      set
      {
        this.datp.Format = value;
        this.Style.ButtonText = this.datp.Text;
        this.dateTime_0 = this.datp.Value;
      }
    }

    public string FormatCustom
    {
      get
      {
        return this.datp.CustomFormat;
      }
      set
      {
        this.datp.CustomFormat = value;
        this.Style.ButtonText = this.datp.Text;
        this.dateTime_0 = this.datp.Value;
      }
    }

    private void BunifuDatepicker_Resize(object sender, EventArgs e)
    {
      this.datp.Width = this.Width - this.datp.Left - 50;
      this.datp.Left = 0;
      this.datp.Top = this.Style.Top + this.Style.Height - this.datp.Height;
      Elipse.Apply((Control) this, this.int_0);
    }

    private void Style_Click(object sender, EventArgs e)
    {
      this.datp.Select();
      SendKeys.Send("%{DOWN}");
    }

    private void BunifuDatepicker_FontChanged(object sender, EventArgs e)
    {
      this.Style.Font = this.Font;
    }

    private void BunifuDatepicker_ForeColorChanged(object sender, EventArgs e)
    {
      this.Style.Textcolor = this.ForeColor;
      this.Style.OnHoverTextColor = this.ForeColor;
      this.Style.Iconimage_right = Class7.smethod_1(this.Style.Iconimage_right, this.ForeColor);
      this.Style.Iconimage = Class7.smethod_1(this.Style.Iconimage, this.ForeColor);
    }

    private void datp_ValueChanged(object sender, EventArgs e)
    {
      this.Style.ButtonText = this.datp.Text;
      this.dateTime_0 = this.datp.Value;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, (EventArgs) null);
    }

    private void BunifuDatepicker_BackColorChanged(object sender, EventArgs e)
    {
      this.Style.Activecolor = this.BackColor;
      this.Style.Normalcolor = this.BackColor;
      int r = (int) this.BackColor.R;
      int red = r + 10 <= (int) byte.MaxValue ? r + 10 : (int) byte.MaxValue;
      int g = (int) this.BackColor.G;
      int green = g + 10 <= (int) byte.MaxValue ? g + 10 : (int) byte.MaxValue;
      int b = (int) this.BackColor.B;
      int blue = b + 10 <= (int) byte.MaxValue ? b + 10 : (int) byte.MaxValue;
      this.Style.OnHovercolor = Color.FromArgb(red, green, blue);
    }

    private void BunifuDatepicker_Load(object sender, EventArgs e)
    {
      this.Style.Text = this.datp.Text;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuDatepicker));
      this.datp = new DateTimePicker();
      this.Style = new BunifuFlatButton();
      this.SuspendLayout();
      this.datp.Location = new Point(3, 13);
      this.datp.Name = "datp";
      this.datp.Size = new Size(241, 20);
      this.datp.TabIndex = 3;
      this.datp.ValueChanged += new EventHandler(this.datp_ValueChanged);
      this.Style.Activecolor = Color.FromArgb(46, 139, 87);
      this.Style.BackColor = Color.FromArgb(46, 139, 87);
      this.Style.BackgroundImageLayout = ImageLayout.Stretch;
      this.Style.BorderRadius = 0;
      this.Style.ButtonText = "BunifuCalendar";
      this.Style.Cursor = Cursors.Hand;
      this.Style.DisabledColor = Color.Gray;
      this.Style.Dock = DockStyle.Fill;
      this.Style.Iconcolor = Color.Transparent;
      this.Style.Iconimage = (Image) componentResourceManager.GetObject("Style.Iconimage");
      this.Style.Iconimage_right = (Image) componentResourceManager.GetObject("Style.Iconimage_right");
      this.Style.Iconimage_right_Selected = (Image) null;
      this.Style.Iconimage_Selected = (Image) null;
      this.Style.IconRightVisible = true;
      this.Style.IconRightZoom = 0.0;
      this.Style.IconVisible = true;
      this.Style.IconZoom = 100.0;
      this.Style.IsTab = false;
      this.Style.Location = new Point(0, 0);
      this.Style.Name = "Style";
      this.Style.Normalcolor = Color.FromArgb(46, 139, 87);
      this.Style.OnHovercolor = Color.FromArgb(36, 129, 77);
      this.Style.OnHoverTextColor = Color.White;
      this.Style.selected = false;
      this.Style.Size = new Size(303, 36);
      this.Style.TabIndex = 2;
      this.Style.Text = "BunifuCalendar";
      this.Style.TextAlign = ContentAlignment.MiddleLeft;
      this.Style.Textcolor = Color.White;
      this.Style.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Style.Click += new EventHandler(this.Style_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.SeaGreen;
      this.Controls.Add((Control) this.Style);
      this.Controls.Add((Control) this.datp);
      this.ForeColor = Color.White;
      this.Name = nameof (BunifuDatepicker);
      this.Size = new Size(303, 36);
      this.Load += new EventHandler(this.BunifuDatepicker_Load);
      this.BackColorChanged += new EventHandler(this.BunifuDatepicker_BackColorChanged);
      this.FontChanged += new EventHandler(this.BunifuDatepicker_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuDatepicker_ForeColorChanged);
      this.Resize += new EventHandler(this.BunifuDatepicker_Resize);
      this.ResumeLayout(false);
    }
  }
}
