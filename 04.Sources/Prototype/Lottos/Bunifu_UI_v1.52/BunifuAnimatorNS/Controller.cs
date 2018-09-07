// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.Controller
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns0;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BunifuAnimatorNS
{
  [DebuggerStepThrough]
  public class Controller
  {
    protected Bitmap ctrlBmp;
    private Point[] point_0;
    private byte[] byte_0;
    protected Rectangle CustomClipRect;
    private AnimateMode animateMode_0;
    private Animation animation_0;

    public Controller(Control control, AnimateMode mode, Animation animation, float timeStep, Rectangle controlClipRect)
    {
      this.DoubleBitmap = !(control is Form) ? (Control) new DoubleBitmapControl() : (Control) new DoubleBitmapForm();
      (this.DoubleBitmap as IFakeControl).FramePainting += new EventHandler<PaintEventArgs>(this.OnFramePainting);
      (this.DoubleBitmap as IFakeControl).FramePainted += new EventHandler<PaintEventArgs>(this.OnFramePainting);
      (this.DoubleBitmap as IFakeControl).TransfromNeeded += new EventHandler<TransfromNeededEventArg>(this.OnTransfromNeeded);
      this.DoubleBitmap.MouseDown += new MouseEventHandler(this.OnMouseDown);
      this.animation_0 = animation;
      this.AnimatedControl = control;
      this.animateMode_0 = mode;
      this.CustomClipRect = controlClipRect;
      if (mode == AnimateMode.Show || mode == AnimateMode.BeginUpdate)
        timeStep = -timeStep;
      this.TimeStep = timeStep * ((double) animation.TimeCoeff == 0.0 ? 1f : animation.TimeCoeff);
      if ((double) this.TimeStep == 0.0)
        timeStep = 0.01f;
      try
      {
        switch (mode)
        {
          case AnimateMode.Show:
            this.BgBmp = this.GetBackground(control, false, false);
            (this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
            this.DoubleBitmap.Visible = true;
            this.DoubleBitmap.Refresh();
            control.Visible = true;
            this.ctrlBmp = this.GetForeground(control);
            break;
          case AnimateMode.Hide:
            this.BgBmp = this.GetBackground(control, false, false);
            (this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
            this.ctrlBmp = this.GetForeground(control);
            this.DoubleBitmap.Visible = true;
            control.Visible = false;
            break;
          case AnimateMode.Update:
          case AnimateMode.BeginUpdate:
            (this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
            this.BgBmp = this.GetBackground(control, true, false);
            this.DoubleBitmap.Visible = true;
            break;
        }
      }
      catch
      {
        this.Dispose();
      }
      this.CurrentTime = (double) timeStep > 0.0 ? animation.MinTime : animation.MaxTime;
    }

    protected Bitmap BgBmp
    {
      get
      {
        return (this.DoubleBitmap as IFakeControl).BgBmp;
      }
      set
      {
        (this.DoubleBitmap as IFakeControl).BgBmp = value;
      }
    }

    public Bitmap Frame
    {
      get
      {
        return (this.DoubleBitmap as IFakeControl).Frame;
      }
      set
      {
        (this.DoubleBitmap as IFakeControl).Frame = value;
      }
    }

    public float CurrentTime { get; private set; }

    protected float TimeStep { get; private set; }

    public event EventHandler<TransfromNeededEventArg> TransfromNeeded;

    public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded;

    public event EventHandler<PaintEventArgs> FramePainting;

    public event EventHandler<PaintEventArgs> FramePainted;

    public event EventHandler<MouseEventArgs> MouseDown;

    public Control DoubleBitmap { get; private set; }

    public Control AnimatedControl { get; set; }

    public void Dispose()
    {
      if (this.ctrlBmp != null)
        this.BgBmp.Dispose();
      if (this.ctrlBmp != null)
        this.ctrlBmp.Dispose();
      if (this.Frame != null)
        this.Frame.Dispose();
      this.AnimatedControl = (Control) null;
      this.Hide();
    }

    public void Hide()
    {
      if (this.DoubleBitmap == null)
        return;
      try
      {
        this.DoubleBitmap.BeginInvoke((Delegate) (() =>
        {
          if (this.DoubleBitmap.Visible)
            this.DoubleBitmap.Hide();
          this.DoubleBitmap.Parent = (Control) null;
        }));
      }
      catch
      {
      }
    }

    protected virtual Rectangle GetBounds()
    {
      int x = this.AnimatedControl.Left - this.animation_0.Padding.Left;
      int y = this.AnimatedControl.Top - this.animation_0.Padding.Top;
      Size size = this.AnimatedControl.Size;
      int width = size.Width + this.animation_0.Padding.Left + this.animation_0.Padding.Right;
      size = this.AnimatedControl.Size;
      int height = size.Height + this.animation_0.Padding.Top + this.animation_0.Padding.Bottom;
      return new Rectangle(x, y, width, height);
    }

    protected virtual Rectangle ControlRectToMyRect(Rectangle rect)
    {
      Padding padding = this.animation_0.Padding;
      int x = padding.Left + rect.Left;
      padding = this.animation_0.Padding;
      int y = padding.Top + rect.Top;
      int width1 = rect.Width;
      padding = this.animation_0.Padding;
      int left = padding.Left;
      int num1 = width1 + left;
      padding = this.animation_0.Padding;
      int right = padding.Right;
      int width2 = num1 + right;
      int height1 = rect.Height;
      padding = this.animation_0.Padding;
      int top = padding.Top;
      int num2 = height1 + top;
      padding = this.animation_0.Padding;
      int bottom = padding.Bottom;
      int height2 = num2 + bottom;
      return new Rectangle(x, y, width2, height2);
    }

    protected virtual void OnMouseDown(object sender, MouseEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_4 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_4((object) this, e);
    }

    protected virtual void OnFramePainting(object sender, PaintEventArgs e)
    {
      Bitmap frame = this.Frame;
      this.Frame = (Bitmap) null;
      if (this.animateMode_0 == AnimateMode.BeginUpdate)
        return;
      this.Frame = this.OnNonLinearTransfromNeeded();
      if (frame != this.Frame && frame != null)
        frame.Dispose();
      float num = this.CurrentTime + this.TimeStep;
      if ((double) num > (double) this.animation_0.MaxTime)
        num = this.animation_0.MaxTime;
      if ((double) num < (double) this.animation_0.MinTime)
        num = this.animation_0.MinTime;
      this.CurrentTime = num;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, e);
    }

    protected virtual void OnFramePainted(object sender, PaintEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_3 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_3((object) this, e);
    }

    protected virtual Bitmap GetBackground(Control ctrl, bool includeForeground = false, bool clip = false)
    {
      if (ctrl is Form)
        return this.method_0(ctrl, includeForeground, clip);
      Rectangle bounds = this.GetBounds();
      int width = bounds.Width;
      int height = bounds.Height;
      if (width == 0)
        width = 1;
      if (height == 1)
        height = 1;
      Bitmap bitmap1 = new Bitmap(width, height);
      Rectangle clipRect = new Rectangle(0, 0, bitmap1.Width, bitmap1.Height);
      PaintEventArgs paintEventArgs = new PaintEventArgs(Graphics.FromImage((Image) bitmap1), clipRect);
      if (clip)
      {
        if (this.CustomClipRect == new Rectangle())
          paintEventArgs.Graphics.SetClip(new Rectangle(0, 0, width, height));
        else
          paintEventArgs.Graphics.SetClip(this.CustomClipRect);
      }
      for (int index = ctrl.Parent.Controls.Count - 1; index >= 0; --index)
      {
        Control control = ctrl.Parent.Controls[index];
        if (control != ctrl || includeForeground)
        {
          if (control.Visible && !control.IsDisposed && control.Bounds.IntersectsWith(bounds))
          {
            using (Bitmap bitmap2 = new Bitmap(control.Width, control.Height))
            {
              control.DrawToBitmap(bitmap2, new Rectangle(0, 0, control.Width, control.Height));
              paintEventArgs.Graphics.DrawImage((Image) bitmap2, control.Left - bounds.Left, control.Top - bounds.Top, control.Width, control.Height);
            }
          }
          if (control == ctrl)
            break;
        }
        else
          break;
      }
      paintEventArgs.Graphics.Dispose();
      return bitmap1;
    }

    private Bitmap method_0(Control control_2, bool bool_0, bool bool_1)
    {
      Size size = Screen.PrimaryScreen.Bounds.Size;
      Graphics graphics = this.DoubleBitmap.CreateGraphics();
      Bitmap bitmap = new Bitmap(size.Width, size.Height, graphics);
      Graphics.FromImage((Image) bitmap).CopyFromScreen(0, 0, 0, 0, size);
      return bitmap;
    }

    protected virtual Bitmap GetForeground(Control ctrl)
    {
      Bitmap bitmap = (Bitmap) null;
      if (!ctrl.IsDisposed)
      {
        if (ctrl.Parent == null)
        {
          bitmap = new Bitmap(ctrl.Width + this.animation_0.Padding.Horizontal, ctrl.Height + this.animation_0.Padding.Vertical);
          ctrl.DrawToBitmap(bitmap, new Rectangle(this.animation_0.Padding.Left, this.animation_0.Padding.Top, ctrl.Width, ctrl.Height));
        }
        else
        {
          bitmap = new Bitmap(this.DoubleBitmap.Width, this.DoubleBitmap.Height);
          ctrl.DrawToBitmap(bitmap, new Rectangle(ctrl.Left - this.DoubleBitmap.Left, ctrl.Top - this.DoubleBitmap.Top, ctrl.Width, ctrl.Height));
        }
      }
      return bitmap;
    }

    protected virtual void OnTransfromNeeded(object sender, TransfromNeededEventArg e)
    {
      try
      {
        if (this.CustomClipRect != new Rectangle())
          e.ClipRectangle = this.ControlRectToMyRect(this.CustomClipRect);
        e.CurrentTime = this.CurrentTime;
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, e);
        }
        else
          e.UseDefaultMatrix = true;
        if (!e.UseDefaultMatrix)
          return;
        Class11.smethod_0(e, this.animation_0);
        Class11.smethod_7(e, this.animation_0);
        Class11.smethod_1(e, this.animation_0);
      }
      catch
      {
      }
    }

    protected virtual Bitmap OnNonLinearTransfromNeeded()
    {
      Bitmap bitmap = (Bitmap) null;
      if (this.ctrlBmp == null)
        return (Bitmap) null;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null && !this.animation_0.IsNonLinearTransformNeeded)
        return this.ctrlBmp;
      try
      {
        bitmap = (Bitmap) this.ctrlBmp.Clone();
        Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        IntPtr scan0 = bitmapdata.Scan0;
        int length = bitmap.Width * bitmap.Height * 4;
        byte[] numArray = new byte[length];
        Marshal.Copy(scan0, numArray, 0, length);
        NonLinearTransfromNeededEventArg transfromNeededEventArg = new NonLinearTransfromNeededEventArg()
        {
          CurrentTime = this.CurrentTime,
          ClientRectangle = this.DoubleBitmap.ClientRectangle,
          Pixels = numArray,
          Stride = bitmapdata.Stride
        };
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_1((object) this, transfromNeededEventArg);
        }
        else
          transfromNeededEventArg.UseDefaultTransform = true;
        if (transfromNeededEventArg.UseDefaultTransform)
        {
          Class11.smethod_2(transfromNeededEventArg, this.animation_0);
          Class11.smethod_3(transfromNeededEventArg, this.animation_0, ref this.point_0, ref this.byte_0);
          Class11.smethod_5(transfromNeededEventArg, this.animation_0);
          Class11.smethod_4(transfromNeededEventArg, this.animation_0);
        }
        Marshal.Copy(numArray, 0, scan0, length);
        bitmap.UnlockBits(bitmapdata);
      }
      catch
      {
      }
      return bitmap;
    }

    public void EndUpdate()
    {
      Bitmap background = this.GetBackground(this.AnimatedControl, true, true);
      if (this.animation_0.AnimateOnlyDifferences)
        Class11.smethod_6(background, this.BgBmp);
      this.ctrlBmp = background;
      this.animateMode_0 = AnimateMode.Update;
    }

    public bool IsCompleted
    {
      get
      {
        if ((double) this.TimeStep >= 0.0 && (double) this.CurrentTime >= (double) this.animation_0.MaxTime)
          return true;
        if ((double) this.TimeStep <= 0.0)
          return (double) this.CurrentTime <= (double) this.animation_0.MinTime;
        return false;
      }
    }

    internal void method_1()
    {
      if (this.animateMode_0 == AnimateMode.BeginUpdate)
        return;
      this.DoubleBitmap.Invalidate();
    }
  }
}
