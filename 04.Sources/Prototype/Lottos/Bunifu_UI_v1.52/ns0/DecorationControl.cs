// Decompiled with JetBrains decompiler
// Type: ns0.DecorationControl
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework;
using BunifuAnimatorNS;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ns0
{
  [DebuggerStepThrough]
  internal class DecorationControl : UserControl
  {
    private Timer timer_0;
    private bool bool_0;

    public DecorationControl(DecorationType decorationType_1, Control control_1)
    {
      this.DecorationType = decorationType_1;
      this.DecoratedControl = control_1;
      control_1.VisibleChanged += new EventHandler(this.method_2);
      control_1.ParentChanged += new EventHandler(this.method_2);
      control_1.LocationChanged += new EventHandler(this.method_2);
      control_1.Paint += new PaintEventHandler(this.method_1);
      this.SetStyle(ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.method_0();
      this.timer_0 = new Timer();
      this.timer_0.Interval = 100;
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.timer_0.Enabled = true;
    }

    public DecorationType DecorationType { get; set; }

    public Control DecoratedControl { get; set; }

    public new Padding Padding { get; set; }

    public Bitmap CtrlBmp { get; set; }

    public byte[] CtrlPixels { get; set; }

    public int CtrlStride { get; set; }

    public Bitmap Frame { get; set; }

    public float CurrentTime { get; set; }

    private void method_0()
    {
      if (this.DecorationType != DecorationType.BottomMirror)
        return;
      this.Padding = new Padding(0, 0, 0, 20);
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      switch (this.DecorationType)
      {
        case DecorationType.BottomMirror:
        case DecorationType.Custom:
          this.Invalidate();
          break;
      }
    }

    private void method_1(object sender, PaintEventArgs e)
    {
      if (this.bool_0)
        return;
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      this.CtrlBmp = this.vmethod_0(this.DecoratedControl);
      this.CtrlPixels = this.method_4(this.CtrlBmp);
      if (this.Frame != null)
        this.Frame.Dispose();
      this.Frame = this.vmethod_1();
      if (this.Frame == null)
        return;
      e.Graphics.DrawImage((Image) this.Frame, Point.Empty);
    }

    private void method_2(object sender, EventArgs e)
    {
      this.method_3();
    }

    private void method_3()
    {
      this.Parent = this.DecoratedControl.Parent;
      this.Visible = this.DecoratedControl.Visible;
      this.Location = new Point(this.DecoratedControl.Left - this.Padding.Left, this.DecoratedControl.Top - this.Padding.Top);
      if (this.Parent != null)
        this.Parent.Controls.SetChildIndex((Control) this, this.Parent.Controls.GetChildIndex(this.DecoratedControl) + 1);
      Size size;
      ref Size local = ref size;
      int num1 = this.DecoratedControl.Width + this.Padding.Left;
      Padding padding = this.Padding;
      int right = padding.Right;
      int width = num1 + right;
      int height1 = this.DecoratedControl.Height;
      padding = this.Padding;
      int top = padding.Top;
      int num2 = height1 + top;
      padding = this.Padding;
      int bottom = padding.Bottom;
      int height2 = num2 + bottom;
      local = new Size(width, height2);
      if (!(size != this.Size))
        return;
      this.Size = size;
    }

    protected virtual Bitmap vmethod_0(Control control_1)
    {
      Bitmap bitmap1 = new Bitmap(this.Width, this.Height);
      if (!control_1.IsDisposed)
      {
        this.bool_0 = true;
        Control control = control_1;
        Bitmap bitmap2 = bitmap1;
        Padding padding = this.Padding;
        int left = padding.Left;
        padding = this.Padding;
        int top = padding.Top;
        int width = control_1.Width;
        int height = control_1.Height;
        Rectangle targetBounds = new Rectangle(left, top, width, height);
        control.DrawToBitmap(bitmap2, targetBounds);
        this.bool_0 = false;
      }
      return bitmap1;
    }

    private byte[] method_4(Bitmap bitmap_2)
    {
      Rectangle rect = new Rectangle(0, 0, bitmap_2.Width, bitmap_2.Height);
      BitmapData bitmapdata = bitmap_2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      int length1 = bitmap_2.Width * bitmap_2.Height * 4;
      byte[] numArray = new byte[length1];
      byte[] destination = numArray;
      int startIndex = 0;
      int length2 = length1;
      Marshal.Copy(scan0, destination, startIndex, length2);
      bitmap_2.UnlockBits(bitmapdata);
      return numArray;
    }

    public event EventHandler<NonLinearTransfromNeededEventArg> Event_0;

    protected virtual Bitmap vmethod_1()
    {
      Bitmap bitmap = (Bitmap) null;
      if (this.CtrlBmp == null)
        return (Bitmap) null;
      try
      {
        bitmap = new Bitmap(this.Width, this.Height);
        Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        IntPtr scan0 = bitmapdata.Scan0;
        int length = bitmap.Width * bitmap.Height * 4;
        byte[] numArray = new byte[length];
        Marshal.Copy(scan0, numArray, 0, length);
        NonLinearTransfromNeededEventArg transfromNeededEventArg = new NonLinearTransfromNeededEventArg()
        {
          CurrentTime = this.CurrentTime,
          ClientRectangle = this.ClientRectangle,
          Pixels = numArray,
          Stride = bitmapdata.Stride,
          SourcePixels = this.CtrlPixels,
          SourceClientRectangle = new Rectangle(this.Padding.Left, this.Padding.Top, this.DecoratedControl.Width, this.DecoratedControl.Height),
          SourceStride = this.CtrlStride
        };
        try
        {
          // ISSUE: reference to a compiler-generated field
          if (this.eventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.eventHandler_0((object) this, transfromNeededEventArg);
          }
          else
            transfromNeededEventArg.UseDefaultTransform = true;
          if (transfromNeededEventArg.UseDefaultTransform)
          {
            if (this.DecorationType == DecorationType.BottomMirror)
              Class11.smethod_8(transfromNeededEventArg);
          }
        }
        catch
        {
        }
        Marshal.Copy(numArray, 0, scan0, length);
        bitmap.UnlockBits(bitmapdata);
      }
      catch
      {
      }
      return bitmap;
    }

    protected override void Dispose(bool disposing)
    {
      this.timer_0.Stop();
      this.timer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_5()
    {
      this.SuspendLayout();
      this.Name = nameof (DecorationControl);
      this.Load += new EventHandler(this.DecorationControl_Load);
      this.ResumeLayout(false);
    }

    private void DecorationControl_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      License.Check((Control) this);
    }
  }
}
