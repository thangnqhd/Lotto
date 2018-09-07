// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.DoubleBitmapControl
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
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class DoubleBitmapControl : Control, IFakeControl
  {
    private Bitmap bitmap_0;
    private Bitmap bitmap_1;
    private IContainer icontainer_0;

    public DoubleBitmapControl()
    {
      this.method_1();
      this.Visible = false;
      this.SetStyle(ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    Bitmap IFakeControl.BgBmp
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

    Bitmap IFakeControl.Frame
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

    public event EventHandler<TransfromNeededEventArg> TransfromNeeded;

    public event EventHandler<PaintEventArgs> FramePainted;

    public event EventHandler<PaintEventArgs> FramePainting;

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      this.OnFramePainting(e);
      try
      {
        graphics.DrawImage((Image) this.bitmap_0, 0, 0);
        if (this.bitmap_1 != null)
        {
          TransfromNeededEventArg transfromNeededEventArg_0 = new TransfromNeededEventArg()
          {
            ClientRectangle = new Rectangle(0, 0, this.Width, this.Height)
          };
          transfromNeededEventArg_0.ClipRectangle = transfromNeededEventArg_0.ClientRectangle;
          this.method_0(transfromNeededEventArg_0);
          graphics.SetClip(transfromNeededEventArg_0.ClipRectangle);
          graphics.Transform = transfromNeededEventArg_0.Matrix;
          graphics.DrawImage((Image) this.bitmap_1, 0, 0);
        }
      }
      catch
      {
      }
      this.OnFramePainted(e);
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
      if (this.eventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_2((object) this, e);
    }

    protected virtual void OnFramePainted(PaintEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, e);
    }

    public void InitParent(Control control, Padding padding)
    {
      this.Parent = control.Parent;
      int childIndex = control.Parent.Controls.GetChildIndex(control);
      control.Parent.Controls.SetChildIndex((Control) this, childIndex);
      int x = control.Left - padding.Left;
      int y = control.Top - padding.Top;
      Size size = control.Size;
      int width = size.Width + padding.Left + padding.Right;
      size = control.Size;
      int height = size.Height + padding.Top + padding.Bottom;
      this.Bounds = new Rectangle(x, y, width, height);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_1()
    {
      this.icontainer_0 = (IContainer) new Container();
    }
  }
}
