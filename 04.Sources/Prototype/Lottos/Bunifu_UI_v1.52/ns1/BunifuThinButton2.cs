// Decompiled with JetBrains decompiler
// Type: ns1.BunifuThinButton2
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
  [DefaultEvent("Click")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuThinButton2 : UserControl
  {
    private Color color_0 = Color.SeaGreen;
    private Color color_1 = Color.White;
    private Color color_2 = Color.SeaGreen;
    private int int_0 = 20;
    private int int_1 = 1;
    private Color color_3 = Color.SeaGreen;
    private Color color_4 = Color.SeaGreen;
    private Color color_5 = Color.White;
    private int int_2 = 20;
    private int int_3 = 1;
    public bool Onfocus;
    private IContainer icontainer_0;
    private BunifuCustomLabel label1;

    public BunifuThinButton2()
    {
      this.InitializeComponent();
      this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) this, (object) true, (object[]) null);
    }

    public Color ActiveLineColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.Refresh();
      }
    }

    public Color ActiveForecolor
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
        this.Refresh();
      }
    }

    public Color ActiveFillColor
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
        this.Refresh();
      }
    }

    public int ActiveCornerRadius
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        this.Refresh();
      }
    }

    public int ActiveBorderThickness
    {
      get
      {
        return this.int_1;
      }
      set
      {
        if (value <= 0)
          return;
        this.int_1 = value;
        this.Refresh();
      }
    }

    public Color IdleLineColor
    {
      get
      {
        return this.color_3;
      }
      set
      {
        this.color_3 = value;
        this.Refresh();
      }
    }

    public Color IdleForecolor
    {
      get
      {
        return this.color_4;
      }
      set
      {
        this.color_4 = value;
        this.Refresh();
      }
    }

    public Color IdleFillColor
    {
      get
      {
        return this.color_5;
      }
      set
      {
        this.color_5 = value;
        this.Refresh();
      }
    }

    public int IdleCornerRadius
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
        this.Refresh();
      }
    }

    public int IdleBorderThickness
    {
      get
      {
        return this.int_3;
      }
      set
      {
        if (value <= 0)
          return;
        this.int_3 = value;
        this.Refresh();
      }
    }

    private void method_0(Graphics graphics_0, Rectangle rectangle_0, int int_4, Pen pen_0, Color color_6)
    {
      graphics_0.Clear(this.BackColor);
      GraphicsPath path = new GraphicsPath();
      Pen pen = pen_0;
      pen_0.StartCap = LineCap.Round;
      int num = 2;
      pen.EndCap = (LineCap) num;
      path.AddArc(rectangle_0.X, rectangle_0.Y, int_4, int_4, 180f, 90f);
      path.AddArc(rectangle_0.X + rectangle_0.Width - int_4, rectangle_0.Y, int_4, int_4, 270f, 90f);
      path.AddArc(rectangle_0.X + rectangle_0.Width - int_4, rectangle_0.Y + rectangle_0.Height - int_4, int_4, int_4, 0.0f, 90f);
      path.AddArc(rectangle_0.X, rectangle_0.Y + rectangle_0.Height - int_4, int_4, int_4, 90f, 90f);
      path.CloseAllFigures();
      graphics_0.FillPath((Brush) new SolidBrush(color_6), path);
      graphics_0.SmoothingMode = SmoothingMode.HighQuality;
      graphics_0.DrawPath(pen_0, path);
      graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
    }

    public ContentAlignment TextAlign
    {
      get
      {
        return this.label1.TextAlign;
      }
      set
      {
        this.label1.TextAlign = this.label1.TextAlign;
      }
    }

    public new void Refresh()
    {
      Size size = this.Size;
      int width = size.Width;
      size = this.Size;
      int height = size.Height;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics graphics_0 = Graphics.FromImage((Image) bitmap);
      graphics_0.SmoothingMode = SmoothingMode.HighQuality;
      graphics_0.Clear(Color.Transparent);
      if (this.Onfocus)
      {
        Rectangle rectangle_0 = new Rectangle(this.int_1, this.int_1 + 5, this.Width - this.int_1 * 2, this.Height - this.int_1 * 2 - 10);
        this.label1.ForeColor = this.color_1;
        if (!this.DesignMode)
          Application.DoEvents();
        this.method_0(graphics_0, rectangle_0, this.int_0, new Pen(this.color_0, (float) this.int_1), this.color_2);
      }
      else
      {
        Rectangle rectangle_0 = new Rectangle(this.int_3, this.int_3 + 5, this.Width - this.int_3 * 2, this.Height - this.int_3 * 2 - 10);
        this.label1.ForeColor = this.color_4;
        if (!this.DesignMode)
          Application.DoEvents();
        this.method_0(graphics_0, rectangle_0, this.int_2, new Pen(this.color_3, (float) this.int_3), this.color_5);
      }
      this.BackgroundImage = (Image) bitmap;
    }

    private void BunifuThinButton2_MouseEnter(object sender, EventArgs e)
    {
      this.Onfocus = true;
      this.Refresh();
    }

    private void BunifuThinButton2_MouseLeave(object sender, EventArgs e)
    {
      this.Onfocus = false;
      this.Refresh();
    }

    private void BunifuThinButton2_Resize(object sender, EventArgs e)
    {
      this.label1.Left = this.Width / 2 - this.label1.Width / 2;
      this.label1.Top = this.Height / 2 - this.label1.Height / 2 + 2;
      this.Refresh();
    }

    private void BunifuThinButton2_FontChanged(object sender, EventArgs e)
    {
      this.label1.Font = this.Font;
    }

    private void BunifuThinButton2_ForeColorChanged(object sender, EventArgs e)
    {
      this.label1.ForeColor = this.ForeColor;
    }

    public string ButtonText
    {
      get
      {
        return this.label1.Text;
      }
      set
      {
        this.label1.Text = value;
        this.OnResize(new EventArgs());
      }
    }

    protected override void OnParentChanged(EventArgs e)
    {
      if (this.Parent != null)
        this.BackColor = this.Parent.BackColor;
      base.OnParentChanged(e);
    }

    protected override void OnParentBackColorChanged(EventArgs e)
    {
      this.BackColor = this.Parent.BackColor;
      base.OnParentBackColorChanged(e);
    }

    private void BunifuThinButton2_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    public new event EventHandler Click;

    private void label1_Click(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }

    public event EventHandler MouseDown;

    private void label1_MouseDown(object sender, MouseEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, (EventArgs) e);
    }

    public new event EventHandler MouseEnter;

    private void label1_MouseEnter(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, e);
    }

    public new event EventHandler MouseHover;

    private void label1_MouseHover(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_3 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_3((object) this, e);
    }

    public new event EventHandler MouseLeave;

    private void label1_MouseLeave(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_4 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_4((object) this, e);
    }

    public event EventHandler MouseMove;

    private void label1_MouseMove(object sender, MouseEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_5 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_5((object) this, (EventArgs) e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new BunifuCustomLabel();
      this.SuspendLayout();
      this.label1.BackColor = Color.Transparent;
      this.label1.Dock = DockStyle.Fill;
      this.label1.Location = new Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(181, 41);
      this.label1.TabIndex = 0;
      this.label1.Text = "ThinButton";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.label1.Click += new EventHandler(this.label1_Click);
      this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
      this.label1.MouseEnter += new EventHandler(this.label1_MouseEnter);
      this.label1.MouseLeave += new EventHandler(this.label1_MouseLeave);
      this.label1.MouseHover += new EventHandler(this.label1_MouseHover);
      this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
      this.AutoScaleDimensions = new SizeF(10f, 21f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.label1);
      this.Cursor = Cursors.Hand;
      this.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ForeColor = Color.SeaGreen;
      this.Margin = new Padding(5);
      this.Name = nameof (BunifuThinButton2);
      this.Size = new Size(181, 41);
      this.Load += new EventHandler(this.BunifuThinButton2_Load);
      this.FontChanged += new EventHandler(this.BunifuThinButton2_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuThinButton2_ForeColorChanged);
      this.MouseEnter += new EventHandler(this.BunifuThinButton2_MouseEnter);
      this.MouseLeave += new EventHandler(this.BunifuThinButton2_MouseLeave);
      this.Resize += new EventHandler(this.BunifuThinButton2_Resize);
      this.ResumeLayout(false);
    }
  }
}
