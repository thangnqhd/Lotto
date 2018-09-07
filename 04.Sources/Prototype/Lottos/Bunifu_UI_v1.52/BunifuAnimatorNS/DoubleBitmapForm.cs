// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.DoubleBitmapForm
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BunifuAnimatorNS
{
  [DebuggerStepThrough]
  public class DoubleBitmapForm : Form, IFakeControl
  {
    private Bitmap bitmap_0;
    private Bitmap bitmap_1;
    private Padding padding_0;
    private Control control_0;
    private Point point_0;
    private IContainer icontainer_0;

    public DoubleBitmapForm()
    {
      this.InitializeComponent();
      this.Visible = false;
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.TopMost = true;
      this.FormBorderStyle = FormBorderStyle.None;
      this.WindowState = FormWindowState.Maximized;
    }

    public event EventHandler<TransfromNeededEventArg> TransfromNeeded;

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.Style = int.MinValue;
        createParams.ExStyle |= 134217856;
        createParams.X = this.Location.X;
        createParams.Y = this.Location.Y;
        return createParams;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics1 = e.Graphics;
      this.OnFramePainting(e);
      try
      {
        Graphics graphics2 = graphics1;
        Bitmap bitmap0 = this.bitmap_0;
        Point location1 = this.Location;
        int x1 = -location1.X;
        location1 = this.Location;
        int y1 = -location1.Y;
        graphics2.DrawImage((Image) bitmap0, x1, y1);
        if (this.bitmap_1 != null)
        {
          TransfromNeededEventArg transfromNeededEventArg_0 = new TransfromNeededEventArg();
          TransfromNeededEventArg transfromNeededEventArg1 = transfromNeededEventArg_0;
          TransfromNeededEventArg transfromNeededEventArg2 = transfromNeededEventArg_0;
          Rectangle bounds1 = this.control_0.Bounds;
          int x2 = bounds1.Left - this.padding_0.Left;
          bounds1 = this.control_0.Bounds;
          int y2 = bounds1.Top - this.padding_0.Top;
          Rectangle bounds2 = this.control_0.Bounds;
          int width = bounds2.Width + this.padding_0.Horizontal;
          bounds2 = this.control_0.Bounds;
          int height = bounds2.Height + this.padding_0.Vertical;
          Rectangle rectangle1;
          Rectangle rectangle2 = rectangle1 = new Rectangle(x2, y2, width, height);
          transfromNeededEventArg2.ClipRectangle = rectangle1;
          Rectangle rectangle3 = rectangle2;
          transfromNeededEventArg1.ClientRectangle = rectangle3;
          this.method_0(transfromNeededEventArg_0);
          graphics1.SetClip(transfromNeededEventArg_0.ClipRectangle);
          graphics1.Transform = transfromNeededEventArg_0.Matrix;
          Point location2 = this.control_0.Location;
          graphics1.DrawImage((Image) this.bitmap_1, location2.X - this.padding_0.Left, location2.Y - this.padding_0.Top);
        }
        this.OnFramePainted(e);
      }
      catch
      {
      }
    }

    private void method_0(TransfromNeededEventArg transfromNeededEventArg_0)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, transfromNeededEventArg_0);
    }

    protected virtual void OnFramePainting(PaintEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, e);
    }

    protected virtual void OnFramePainted(PaintEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, e);
    }

    public void InitParent(Control control, Padding padding)
    {
      this.control_0 = control;
      this.Location = new Point(0, 0);
      this.Size = Screen.PrimaryScreen.Bounds.Size;
      control.VisibleChanged += new EventHandler(this.method_1);
      this.padding_0 = padding;
    }

    private void method_1(object sender, EventArgs e)
    {
      this.point_0 = (sender as Control).Location;
      Size size = (sender as Control).Size;
    }

    public Bitmap BgBmp
    {
      get
      {
        return this.bitmap_0;
      }
      set
      {
        this.bitmap_0 = value;
      }
    }

    public Bitmap Frame
    {
      get
      {
        return this.bitmap_1;
      }
      set
      {
        this.bitmap_1 = value;
      }
    }

    public event EventHandler<PaintEventArgs> FramePainting;

    public event EventHandler<PaintEventArgs> FramePainted;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 262);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (DoubleBitmapForm);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = nameof (DoubleBitmapForm);
      this.ResumeLayout(false);
    }
  }
}
