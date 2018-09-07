// Decompiled with JetBrains decompiler
// Type: ns1.BunifuFlatButton
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace ns1
{
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DefaultEvent("Click")]
  public class BunifuFlatButton : UserControl
  {
    public Color colbackground = Color.FromArgb(46, 139, 87);
    public Color colhover = Color.FromArgb(36, 129, 77);
    public Color colselected = Color.FromArgb(46, 139, 87);
    private bool bool_1 = true;
    private Color color_0 = Color.Gray;
    private Color color_1 = Color.Transparent;
    private double double_0 = 90.0;
    private Color color_2 = Color.White;
    private Color color_3 = Color.White;
    private Image image_0;
    private bool bool_0;
    private int int_0;
    private int int_1;
    private int int_2;
    private double double_1;
    private bool bool_2;
    private Image image_1;
    private Image image_2;
    private IContainer icontainer_0;
    private ImageList imageList_0;
    public PictureBox limage;
    public PictureBox rimage;
    private BunifuCustomLabel txttext;

    public BunifuFlatButton()
    {
      this.InitializeComponent();
      if (!this.selected)
        return;
      this.selected = true;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ButtonText
    {
      get
      {
        return this.txttext.Text;
      }
      set
      {
        this.txttext.Text = value;
      }
    }

    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text
    {
      get
      {
        return this.ButtonText;
      }
      set
      {
        this.ButtonText = value;
      }
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    public new bool Enabled
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
        if (value)
          this.BackColor = this.Normalcolor;
        else
          this.BackColor = this.color_0;
      }
    }

    public Color DisabledColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public ContentAlignment TextAlign
    {
      get
      {
        return this.txttext.TextAlign;
      }
      set
      {
        this.txttext.TextAlign = value;
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
        if (value >= 8)
          return;
        this.int_0 = value;
        Elipse.Apply((Control) this, this.int_0);
      }
    }

    public Color Iconcolor
    {
      get
      {
        return this.limage.BackColor;
      }
      set
      {
        this.color_1 = value;
        this.limage.BackColor = value;
      }
    }

    public bool IsTab
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public Image Iconimage
    {
      get
      {
        return this.limage.Image;
      }
      set
      {
        this.limage.Image = value;
        this.image_1 = value;
        this.OnResize(new EventArgs());
      }
    }

    public bool IconVisible
    {
      get
      {
        return this.limage.Visible;
      }
      set
      {
        this.limage.Visible = value;
        this.method_0();
      }
    }

    private void method_0()
    {
      if (this.limage.Visible)
        this.txttext.Left = this.limage.Right;
      else
        this.txttext.Left = 0;
      if (this.rimage.Visible)
        this.txttext.Width = this.rimage.Left - this.txttext.Left;
      else
        this.txttext.Width = this.Width - this.txttext.Left;
    }

    public bool IconRightVisible
    {
      get
      {
        return this.rimage.Visible;
      }
      set
      {
        this.rimage.Visible = value;
        this.method_0();
      }
    }

    public int IconMarginLeft
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
        this.BunifuFlatButton_Resize((object) this, new EventArgs());
      }
    }

    public int IconMarginRight
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
        this.BunifuFlatButton_Resize((object) this, new EventArgs());
      }
    }

    public Image Iconimage_Selected
    {
      get
      {
        return (Image) this.limage.Tag;
      }
      set
      {
        this.limage.Tag = (object) value;
        this.OnResize(new EventArgs());
      }
    }

    public Image Iconimage_right
    {
      get
      {
        return this.rimage.Image;
      }
      set
      {
        this.rimage.Image = value;
        this.image_2 = value;
        this.OnResize(new EventArgs());
      }
    }

    public Image Iconimage_right_Selected
    {
      get
      {
        return (Image) this.rimage.Tag;
      }
      set
      {
        this.rimage.Tag = (object) value;
        this.OnResize(new EventArgs());
      }
    }

    public Font TextFont
    {
      get
      {
        return this.txttext.Font;
      }
      set
      {
        this.txttext.Font = value;
        this.method_0();
      }
    }

    public Color Textcolor
    {
      get
      {
        return this.txttext.ForeColor;
      }
      set
      {
        this.color_3 = value;
        this.txttext.ForeColor = value;
      }
    }

    public Color Normalcolor
    {
      get
      {
        return this.colbackground;
      }
      set
      {
        this.BackColor = value;
        this.colbackground = value;
      }
    }

    public double IconZoom
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
        this.method_1();
      }
    }

    public double IconRightZoom
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
        this.method_2();
      }
    }

    private void method_1()
    {
      this.limage.Height = this.rimage.Height = int.Parse(Math.Round(this.double_0 / 100.0 * (double) this.Height, 0).ToString());
      this.OnResize(new EventArgs());
    }

    private void method_2()
    {
      this.rimage.Height = this.rimage.Height = int.Parse(Math.Round(this.double_1 / 100.0 * (double) this.Height, 0).ToString());
      this.OnResize(new EventArgs());
    }

    public Color OnHovercolor
    {
      get
      {
        return this.colhover;
      }
      set
      {
        this.colhover = value;
      }
    }

    public Color Activecolor
    {
      get
      {
        return this.colselected;
      }
      set
      {
        this.colselected = value;
      }
    }

    public bool selected
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
        if (this.bool_2)
        {
          this.BackColor = this.colselected;
          if (this.Iconimage_Selected != null)
            this.limage.Image = this.Iconimage_Selected;
          if (this.Iconimage_right_Selected == null)
            return;
          this.rimage.Image = this.Iconimage_right_Selected;
        }
        else
        {
          this.BackColor = this.colbackground;
          if (this.Iconimage_Selected != null)
            this.limage.Image = this.image_1;
          if (this.Iconimage_right_Selected == null)
            return;
          this.rimage.Image = this.image_2;
        }
      }
    }

    public Color OnHoverTextColor
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
      }
    }

    public void reset()
    {
      this.bool_2 = false;
      this.BackColor = this.colbackground;
    }

    private void BunifuFlatButton_Load(object sender, EventArgs e)
    {
      Bunifu.Framework.License.Check((Control) this);
      if (this.bool_1)
        this.BackColor = this.Normalcolor;
      else
        this.BackColor = this.DisabledColor;
    }

    private void BunifuFlatButton_MouseEnter(object sender, EventArgs e)
    {
      if (!this.bool_1)
      {
        this.BackColor = this.DisabledColor;
      }
      else
      {
        this.txttext.ForeColor = this.color_2;
        this.limage.BackColor = Color.Transparent;
        this.BackColor = this.colhover;
      }
    }

    private void BunifuFlatButton_MouseLeave(object sender, EventArgs e)
    {
      if (!this.bool_1)
      {
        this.BackColor = this.DisabledColor;
      }
      else
      {
        if (this.bool_0)
        {
          if (this.bool_2)
          {
            this.BackColor = this.colselected;
            if (this.Iconimage_Selected != null)
              this.limage.Image = this.Iconimage_Selected;
            if (this.Iconimage_right_Selected != null)
              this.rimage.Image = this.Iconimage_right_Selected;
          }
          else
          {
            this.BackColor = this.colbackground;
            if (this.Iconimage_Selected != null)
              this.limage.Image = this.image_1;
            if (this.Iconimage_right_Selected != null)
              this.rimage.Image = this.image_2;
          }
        }
        else
          this.BackColor = this.colbackground;
        this.txttext.ForeColor = this.color_3;
        this.limage.BackColor = this.color_1;
      }
    }

    private void BunifuFlatButton_MouseClick(object sender, MouseEventArgs e)
    {
      if (!this.bool_1)
        return;
      this.bool_2 = true;
      this.BackColor = this.colselected;
      this.method_5();
    }

    private void method_3(object sender, PaintEventArgs e)
    {
    }

    private void BunifuFlatButton_Resize(object sender, EventArgs e)
    {
      if (this.limage.Image == null)
        this.limage.Width = 0;
      else
        this.limage.Width = this.limage.Height;
      if (this.rimage.Image == null)
        this.rimage.Width = 0;
      else
        this.rimage.Width = this.rimage.Height;
      this.rimage.Top = this.Height / 2 - this.rimage.Height / 2;
      this.limage.Top = this.rimage.Top;
      if (this.IconMarginLeft > 0)
        this.limage.Left = this.IconMarginLeft;
      else
        this.limage.Left = this.limage.Top;
      if (this.IconMarginRight > 0)
        this.rimage.Left = this.IconMarginRight;
      else
        this.rimage.Left = this.Width - this.rimage.Width - this.rimage.Top;
      this.txttext.Top = this.Height / 2 - this.txttext.Height / 2;
      this.method_0();
      Elipse.Apply((Control) this, this.int_0);
    }

    private void txttext_Click(object sender, EventArgs e)
    {
      if (!this.bool_1)
        return;
      this.OnClick(e);
    }

    public event EventHandler MouseDown;

    private void txttext_MouseDown(object sender, MouseEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, (EventArgs) e);
    }

    public event EventHandler MouseUp;

    private void txttext_MouseUp(object sender, MouseEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, (EventArgs) e);
    }

    private void method_4(object sender, EventArgs e)
    {
    }

    private void method_5()
    {
      foreach (Control control in (ArrangedElementCollection) this.Parent.Controls)
      {
        if (control.GetType() == typeof (BunifuFlatButton) && ((BunifuFlatButton) control).IsTab && (control.Name != this.Name && this.Parent == control.Parent))
          ((BunifuFlatButton) control).selected = false;
      }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuFlatButton));
      this.imageList_0 = new ImageList(this.icontainer_0);
      this.limage = new PictureBox();
      this.rimage = new PictureBox();
      this.txttext = new BunifuCustomLabel();
      ((ISupportInitialize) this.limage).BeginInit();
      ((ISupportInitialize) this.rimage).BeginInit();
      this.SuspendLayout();
      this.imageList_0.ColorDepth = ColorDepth.Depth8Bit;
      this.imageList_0.ImageSize = new Size(16, 16);
      this.imageList_0.TransparentColor = Color.Transparent;
      this.limage.BackColor = Color.Transparent;
      this.limage.BackgroundImageLayout = ImageLayout.Stretch;
      this.limage.Enabled = false;
      this.limage.Image = (Image) componentResourceManager.GetObject("limage.Image");
      this.limage.Location = new Point(0, 0);
      this.limage.Name = "limage";
      this.limage.Size = new Size(50, 48);
      this.limage.SizeMode = PictureBoxSizeMode.StretchImage;
      this.limage.TabIndex = 1;
      this.limage.TabStop = false;
      this.limage.Click += new EventHandler(this.txttext_Click);
      this.limage.MouseClick += new MouseEventHandler(this.BunifuFlatButton_MouseClick);
      this.limage.MouseDown += new MouseEventHandler(this.txttext_MouseDown);
      this.limage.MouseEnter += new EventHandler(this.BunifuFlatButton_MouseEnter);
      this.limage.MouseLeave += new EventHandler(this.BunifuFlatButton_MouseLeave);
      this.limage.MouseUp += new MouseEventHandler(this.txttext_MouseUp);
      this.rimage.BackColor = Color.Transparent;
      this.rimage.BackgroundImageLayout = ImageLayout.Stretch;
      this.rimage.Enabled = false;
      this.rimage.Location = new Point(191, 0);
      this.rimage.Name = "rimage";
      this.rimage.Size = new Size(50, 48);
      this.rimage.SizeMode = PictureBoxSizeMode.StretchImage;
      this.rimage.TabIndex = 3;
      this.rimage.TabStop = false;
      this.rimage.Click += new EventHandler(this.txttext_Click);
      this.rimage.MouseDown += new MouseEventHandler(this.txttext_MouseDown);
      this.rimage.MouseUp += new MouseEventHandler(this.txttext_MouseUp);
      this.txttext.AutoEllipsis = true;
      this.txttext.BackColor = Color.Transparent;
      this.txttext.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txttext.ForeColor = Color.White;
      this.txttext.Location = new Point(50, 0);
      this.txttext.Name = "txttext";
      this.txttext.Size = new Size(188, 48);
      this.txttext.TabIndex = 4;
      this.txttext.Text = "     Bunifu Flat Button";
      this.txttext.TextAlign = ContentAlignment.MiddleLeft;
      this.txttext.Click += new EventHandler(this.txttext_Click);
      this.txttext.MouseClick += new MouseEventHandler(this.BunifuFlatButton_MouseClick);
      this.txttext.MouseDown += new MouseEventHandler(this.txttext_MouseDown);
      this.txttext.MouseEnter += new EventHandler(this.BunifuFlatButton_MouseEnter);
      this.txttext.MouseLeave += new EventHandler(this.BunifuFlatButton_MouseLeave);
      this.txttext.MouseUp += new MouseEventHandler(this.txttext_MouseUp);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.SeaGreen;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.Controls.Add((Control) this.limage);
      this.Controls.Add((Control) this.rimage);
      this.Controls.Add((Control) this.txttext);
      this.Cursor = Cursors.Hand;
      this.DoubleBuffered = true;
      this.Name = nameof (BunifuFlatButton);
      this.Size = new Size(241, 48);
      this.Load += new EventHandler(this.BunifuFlatButton_Load);
      this.MouseClick += new MouseEventHandler(this.BunifuFlatButton_MouseClick);
      this.MouseEnter += new EventHandler(this.BunifuFlatButton_MouseEnter);
      this.MouseLeave += new EventHandler(this.BunifuFlatButton_MouseLeave);
      this.Resize += new EventHandler(this.BunifuFlatButton_Resize);
      ((ISupportInitialize) this.limage).EndInit();
      ((ISupportInitialize) this.rimage).EndInit();
      this.ResumeLayout(false);
    }
  }
}
