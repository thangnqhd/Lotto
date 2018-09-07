// Decompiled with JetBrains decompiler
// Type: ns1.BunifuDropdown
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
  [DefaultEvent("onItemSelected")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DebuggerStepThrough]
  public class BunifuDropdown : UserControl
  {
    public int _BorderRadius = 3;
    private string[] string_0 = new string[0];
    private IContainer icontainer_0;
    public BunifuFlatButton Style;
    private ComboBox Collections;

    public BunifuDropdown()
    {
      this.InitializeComponent();
      if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        this.Collections.Visible = false;
      else
        this.Collections.Visible = true;
      if (this.Collections.Items.Count > 0)
        this.Collections.SelectedIndex = 0;
      this.Style.ButtonText = this.Collections.Text;
      this.OnResize((EventArgs) null);
      Bunifu.Framework.License.Check((Control) this);
    }

    public void AddItem(string Item)
    {
      this.Collections.Items.Add((object) Item);
    }

    public void RemoveItem(string Item)
    {
      this.Collections.Items.Remove((object) Item);
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, (EventArgs) null);
    }

    public void RemoveAt(int index)
    {
      this.Collections.Items.RemoveAt(index);
      if (this.selectedIndex == index)
        this.Style.Text = "";
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, (EventArgs) null);
    }

    public int BorderRadius
    {
      get
      {
        return this._BorderRadius;
      }
      set
      {
        this._BorderRadius = value;
        this.Style.BorderRadius = this._BorderRadius;
      }
    }

    public event EventHandler onItemSelected;

    public event EventHandler onItemAdded;

    public event EventHandler onItemRemoved;

    public int selectedIndex
    {
      get
      {
        return this.Collections.SelectedIndex;
      }
      set
      {
        if (this.Collections.Items.Count > value && value >= 0)
        {
          this.Collections.SelectedIndex = value;
          this.Style.ButtonText = "    " + this.Collections.Items[value].ToString();
        }
        else if (value != -1)
          throw new Exception("Out of index");
      }
    }

    public string selectedValue
    {
      get
      {
        return this.Collections.Items[this.selectedIndex].ToString().Trim();
      }
    }

    public string[] Items
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
        this.Collections.Items.Clear();
        for (int index = 0; index < this.string_0.Length; ++index)
          this.Collections.Items.Add((object) this.string_0[index]);
      }
    }

    public void Clear()
    {
      this.Collections.Items.Clear();
      this.string_0 = new string[0];
      this.Style.Text = "";
    }

    public Color onHoverColor
    {
      get
      {
        return this.Style.OnHovercolor;
      }
      set
      {
        this.Style.OnHovercolor = value;
      }
    }

    public Color NomalColor
    {
      get
      {
        return this.Style.Normalcolor;
      }
      set
      {
        this.Style.Normalcolor = value;
        this.Style.Activecolor = value;
      }
    }

    private void BunifuDropdown_Resize(object sender, EventArgs e)
    {
    }

    private void Style_Click(object sender, EventArgs e)
    {
      this.Collections.Select();
      SendKeys.Send("%{DOWN}");
    }

    private void BunifuDropdown_FontChanged(object sender, EventArgs e)
    {
      this.Style.Font = this.Font;
    }

    private void BunifuDropdown_ForeColorChanged(object sender, EventArgs e)
    {
      this.Style.Textcolor = this.ForeColor;
      this.Style.OnHoverTextColor = this.ForeColor;
      if (this.Style.Iconimage_right != null)
        this.Style.Iconimage_right = Class7.smethod_1(this.Style.Iconimage_right, this.ForeColor);
      if (this.Style.Iconimage == null)
        return;
      this.Style.Iconimage = Class7.smethod_1(this.Style.Iconimage, this.ForeColor);
    }

    private void Collections_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Style.ButtonText = "   " + this.Collections.Text;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, (EventArgs) null);
    }

    private void Collections_SelectionChangeCommitted(object sender, EventArgs e)
    {
    }

    private void BunifuDropdown_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuDropdown));
      this.Collections = new ComboBox();
      this.Style = new BunifuFlatButton();
      this.SuspendLayout();
      this.Collections.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Collections.FormattingEnabled = true;
      this.Collections.Location = new Point(7, 12);
      this.Collections.Name = "Collections";
      this.Collections.Size = new Size(201, 21);
      this.Collections.TabIndex = 1;
      this.Collections.SelectedIndexChanged += new EventHandler(this.Collections_SelectedIndexChanged);
      this.Collections.SelectionChangeCommitted += new EventHandler(this.Collections_SelectionChangeCommitted);
      this.Style.Activecolor = Color.FromArgb(46, 139, 87);
      this.Style.BackColor = Color.FromArgb(46, 139, 87);
      this.Style.BackgroundImageLayout = ImageLayout.Stretch;
      this.Style.BorderRadius = 0;
      this.Style.ButtonText = "     DropDown";
      this.Style.Cursor = Cursors.Hand;
      this.Style.DisabledColor = Color.Gray;
      this.Style.Dock = DockStyle.Fill;
      this.Style.Iconcolor = Color.Transparent;
      this.Style.Iconimage = (Image) null;
      this.Style.Iconimage_right = (Image) componentResourceManager.GetObject("Style.Iconimage_right");
      this.Style.Iconimage_right_Selected = (Image) null;
      this.Style.Iconimage_Selected = (Image) null;
      this.Style.IconRightVisible = true;
      this.Style.IconRightZoom = 0.0;
      this.Style.IconVisible = true;
      this.Style.IconZoom = 90.0;
      this.Style.IsTab = false;
      this.Style.Location = new Point(0, 0);
      this.Style.Name = "Style";
      this.Style.Normalcolor = Color.FromArgb(46, 139, 87);
      this.Style.OnHovercolor = Color.FromArgb(36, 129, 77);
      this.Style.OnHoverTextColor = Color.White;
      this.Style.selected = false;
      this.Style.Size = new Size(217, 35);
      this.Style.TabIndex = 2;
      this.Style.Text = "     DropDown";
      this.Style.TextAlign = ContentAlignment.MiddleLeft;
      this.Style.Textcolor = Color.White;
      this.Style.TextFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Style.Click += new EventHandler(this.Style_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.Style);
      this.Controls.Add((Control) this.Collections);
      this.ForeColor = Color.White;
      this.Name = nameof (BunifuDropdown);
      this.Size = new Size(217, 35);
      this.Load += new EventHandler(this.BunifuDropdown_Load);
      this.FontChanged += new EventHandler(this.BunifuDropdown_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuDropdown_ForeColorChanged);
      this.Resize += new EventHandler(this.BunifuDropdown_Resize);
      this.ResumeLayout(false);
    }
  }
}
