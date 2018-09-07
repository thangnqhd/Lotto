// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.BunifuTransition
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BunifuAnimatorNS
{
  [ProvideProperty("Decoration", typeof (Control))]
  [DebuggerStepThrough]
  public class BunifuTransition : Component, IExtenderProvider
  {
    protected List<BunifuTransition.QueueItem> queue = new List<BunifuTransition.QueueItem>();
    private List<BunifuTransition.QueueItem> list_0 = new List<BunifuTransition.QueueItem>();
    private readonly Dictionary<Control, DecorationControl> dictionary_0 = new Dictionary<Control, DecorationControl>();
    private IContainer icontainer_0;
    private Thread thread_0;
    private System.Windows.Forms.Timer timer_0;
    private AnimationType animationType_0;
    private Control control_0;
    private int int_2;

    public BunifuTransition()
    {
      this.Init();
    }

    public BunifuTransition(IContainer container)
    {
      container.Add((IComponent) this);
      this.Init();
    }

    public event EventHandler<AnimationCompletedEventArg> AnimationCompleted;

    public event EventHandler AllAnimationsCompleted;

    public event EventHandler<TransfromNeededEventArg> TransfromNeeded;

    public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded;

    public event EventHandler<MouseEventArgs> MouseDown;

    public event EventHandler<PaintEventArgs> FramePainted;

    [DefaultValue(1500)]
    public int MaxAnimationTime { get; set; }

    [TypeConverter(typeof (ExpandableObjectConverter))]
    public Animation DefaultAnimation { get; set; }

    [DefaultValue(typeof (Cursor), "Default")]
    public Cursor Cursor { get; set; }

    public bool IsCompleted
    {
      get
      {
        lock (this.queue)
          return this.queue.Count == 0;
      }
    }

    [DefaultValue(10)]
    public int Interval { get; set; }

    public AnimationType AnimationType
    {
      get
      {
        return this.animationType_0;
      }
      set
      {
        this.animationType_0 = value;
        this.method_6(this.animationType_0);
      }
    }

    protected virtual void Init()
    {
      this.AnimationType = AnimationType.VertSlide;
      this.DefaultAnimation = new Animation();
      this.MaxAnimationTime = 1500;
      this.TimeStep = 0.02f;
      this.Interval = 10;
      this.Disposed += new EventHandler(this.BunifuTransition_Disposed);
      this.timer_0 = new System.Windows.Forms.Timer();
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.timer_0.Interval = 1;
      this.timer_0.Start();
    }

    private void method_0()
    {
      this.thread_0 = new Thread(new ThreadStart(this.method_1));
      this.thread_0.IsBackground = true;
      this.thread_0.Name = "Animator thread";
      this.thread_0.Start();
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      this.timer_0.Stop();
      this.control_0 = new Control();
      this.control_0.CreateControl();
      this.method_0();
    }

    private void BunifuTransition_Disposed(object sender, EventArgs e)
    {
      this.ClearQueue();
      if (this.thread_0 == null)
        return;
      this.thread_0.Abort();
    }

    private void method_1()
    {
      while (true)
      {
        Thread.Sleep(this.Interval);
        try
        {
          int num = 0;
          List<BunifuTransition.QueueItem> queueItemList1 = new List<BunifuTransition.QueueItem>();
          List<BunifuTransition.QueueItem> queueItemList2 = new List<BunifuTransition.QueueItem>();
          lock (this.queue)
          {
            num = this.queue.Count;
            bool flag = false;
            foreach (BunifuTransition.QueueItem queueItem in this.queue)
            {
              if (queueItem.IsActive)
                flag = true;
              if (queueItem.controller != null && queueItem.controller.IsCompleted)
                queueItemList1.Add(queueItem);
              else if (queueItem.IsActive)
              {
                if ((DateTime.Now - queueItem.ActivateTime).TotalMilliseconds > (double) this.MaxAnimationTime)
                  queueItemList1.Add(queueItem);
                else
                  queueItemList2.Add(queueItem);
              }
            }
            if (!flag)
            {
              foreach (BunifuTransition.QueueItem queueItem in this.queue)
              {
                if (!queueItem.IsActive)
                {
                  queueItemList2.Add(queueItem);
                  queueItem.IsActive = true;
                  break;
                }
              }
            }
          }
          foreach (BunifuTransition.QueueItem queueItem_0 in queueItemList1)
            this.method_7(queueItem_0);
          foreach (BunifuTransition.QueueItem queueItem_0 in queueItemList2)
          {
            try
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: reference to a compiler-generated method
              this.control_0.BeginInvoke((Delegate) new MethodInvoker(new BunifuTransition.Class8()
              {
                bunifuTransition_0 = this,
                queueItem_0 = queueItem_0
              }.method_0));
            }
            catch
            {
              this.method_7(queueItem_0);
            }
          }
          if (num == 0)
          {
            if (queueItemList1.Count > 0)
              this.OnAllAnimationsCompleted();
            this.method_2();
          }
        }
        catch
        {
        }
      }
    }

    private void method_2()
    {
      List<BunifuTransition.QueueItem> queueItemList = new List<BunifuTransition.QueueItem>();
      lock (this.list_0)
      {
        Dictionary<Control, BunifuTransition.QueueItem> dictionary = new Dictionary<Control, BunifuTransition.QueueItem>();
        foreach (BunifuTransition.QueueItem queueItem in this.list_0)
        {
          if (queueItem.control != null)
          {
            if (dictionary.ContainsKey(queueItem.control))
              queueItemList.Add(dictionary[queueItem.control]);
            dictionary[queueItem.control] = queueItem;
          }
          else
            queueItemList.Add(queueItem);
        }
        foreach (BunifuTransition.QueueItem queueItem in dictionary.Values)
        {
          if (queueItem.control != null && !this.method_3(queueItem.control, queueItem.mode))
          {
            if (this.control_0 != null)
              this.method_4(queueItem.control, queueItem.mode);
          }
          else
            queueItemList.Add(queueItem);
        }
        foreach (BunifuTransition.QueueItem queueItem in queueItemList)
          this.list_0.Remove(queueItem);
      }
    }

    private bool method_3(Control control_1, AnimateMode animateMode_0)
    {
      if (animateMode_0 == AnimateMode.Show)
        return control_1.Visible;
      if (animateMode_0 == AnimateMode.Hide)
        return !control_1.Visible;
      return true;
    }

    private void method_4(Control control_1, AnimateMode animateMode_0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      this.control_0.Invoke((Delegate) new MethodInvoker(new BunifuTransition.Class9()
      {
        animateMode_0 = animateMode_0,
        control_0 = control_1
      }.method_0));
    }

    private void method_5(BunifuTransition.QueueItem queueItem_0)
    {
      lock (queueItem_0)
      {
        try
        {
          if (queueItem_0.controller == null)
            queueItem_0.controller = this.method_8(queueItem_0.control, queueItem_0.mode, queueItem_0.animation, queueItem_0.clipRectangle);
          if (queueItem_0.controller.IsCompleted)
            return;
          queueItem_0.controller.method_1();
        }
        catch
        {
          if (queueItem_0.controller != null)
            queueItem_0.controller.Dispose();
          this.method_7(queueItem_0);
        }
      }
    }

    private void method_6(AnimationType animationType_1)
    {
      switch (animationType_1)
      {
        case AnimationType.Rotate:
          this.DefaultAnimation = Animation.Rotate;
          break;
        case AnimationType.HorizSlide:
          this.DefaultAnimation = Animation.HorizSlide;
          break;
        case AnimationType.VertSlide:
          this.DefaultAnimation = Animation.VertSlide;
          break;
        case AnimationType.Scale:
          this.DefaultAnimation = Animation.Scale;
          break;
        case AnimationType.ScaleAndRotate:
          this.DefaultAnimation = Animation.ScaleAndRotate;
          break;
        case AnimationType.HorizSlideAndRotate:
          this.DefaultAnimation = Animation.HorizSlideAndRotate;
          break;
        case AnimationType.ScaleAndHorizSlide:
          this.DefaultAnimation = Animation.ScaleAndHorizSlide;
          break;
        case AnimationType.Transparent:
          this.DefaultAnimation = Animation.Transparent;
          break;
        case AnimationType.Leaf:
          this.DefaultAnimation = Animation.Leaf;
          break;
        case AnimationType.Mosaic:
          this.DefaultAnimation = Animation.Mosaic;
          break;
        case AnimationType.Particles:
          this.DefaultAnimation = Animation.Particles;
          break;
        case AnimationType.VertBlind:
          this.DefaultAnimation = Animation.VertBlind;
          break;
        case AnimationType.HorizBlind:
          this.DefaultAnimation = Animation.HorizBlind;
          break;
      }
    }

    [DefaultValue(0.02f)]
    public float TimeStep { get; set; }

    public void Show(Control control, bool parallel = false, Animation animation = null)
    {
      this.AddToQueue(control, AnimateMode.Show, parallel, animation, new Rectangle());
    }

    public void ShowSync(Control control, bool parallel = false, Animation animation = null)
    {
      this.Show(control, parallel, animation);
      this.WaitAnimation(control);
    }

    public void Hide(Control control, bool parallel = false, Animation animation = null)
    {
      this.AddToQueue(control, AnimateMode.Hide, parallel, animation, new Rectangle());
    }

    public void HideSync(Control control, bool parallel = false, Animation animation = null)
    {
      this.Hide(control, parallel, animation);
      this.WaitAnimation(control);
    }

    public void BeginUpdate(Control control, bool parallel = false, Animation animation = null, Rectangle clipRectangle = default (Rectangle))
    {
      this.AddToQueue(control, AnimateMode.BeginUpdate, parallel, animation, clipRectangle);
      bool flag;
      do
      {
        flag = false;
        lock (this.queue)
        {
          foreach (BunifuTransition.QueueItem queueItem in this.queue)
          {
            if (queueItem.control == control && queueItem.mode == AnimateMode.BeginUpdate && queueItem.controller == null)
              flag = true;
          }
        }
        if (flag)
          Application.DoEvents();
      }
      while (flag);
    }

    public void EndUpdate(Control control)
    {
      lock (this.queue)
      {
        foreach (BunifuTransition.QueueItem queueItem in this.queue)
        {
          if (queueItem.control == control && queueItem.mode == AnimateMode.BeginUpdate)
          {
            queueItem.controller.EndUpdate();
            queueItem.mode = AnimateMode.Update;
          }
        }
      }
    }

    public void EndUpdateSync(Control control)
    {
      this.EndUpdate(control);
      this.WaitAnimation(control);
    }

    public void WaitAllAnimations()
    {
      while (!this.IsCompleted)
        Application.DoEvents();
    }

    public void WaitAnimation(Control animatedControl)
    {
      while (true)
      {
        bool flag = false;
        lock (this.queue)
        {
          foreach (BunifuTransition.QueueItem queueItem in this.queue)
          {
            if (queueItem.control == animatedControl)
            {
              flag = true;
              break;
            }
          }
        }
        if (flag)
          Application.DoEvents();
        else
          break;
      }
    }

    private void method_7(BunifuTransition.QueueItem queueItem_0)
    {
      if (queueItem_0.controller != null)
        queueItem_0.controller.Dispose();
      lock (this.queue)
        this.queue.Remove(queueItem_0);
      this.OnAnimationCompleted(new AnimationCompletedEventArg()
      {
        Animation = queueItem_0.animation,
        Control = queueItem_0.control,
        Mode = queueItem_0.mode
      });
    }

    public void AddToQueue(Control control, AnimateMode mode, bool parallel = true, Animation animation = null, Rectangle clipRectangle = default (Rectangle))
    {
      if (animation == null)
        animation = this.DefaultAnimation;
      if (control is IFakeControl)
      {
        control.Visible = false;
      }
      else
      {
        BunifuTransition.QueueItem queueItem = new BunifuTransition.QueueItem()
        {
          animation = animation,
          control = control,
          IsActive = parallel,
          mode = mode,
          clipRectangle = clipRectangle
        };
        switch (mode)
        {
          case AnimateMode.Show:
            if (control.Visible)
            {
              this.method_7(new BunifuTransition.QueueItem()
              {
                control = control,
                mode = mode
              });
              return;
            }
            break;
          case AnimateMode.Hide:
            if (!control.Visible)
            {
              this.method_7(new BunifuTransition.QueueItem()
              {
                control = control,
                mode = mode
              });
              return;
            }
            break;
        }
        lock (this.queue)
          this.queue.Add(queueItem);
        lock (this.list_0)
          this.list_0.Add(queueItem);
      }
    }

    private Controller method_8(Control control_1, AnimateMode animateMode_0, Animation animation_1, Rectangle rectangle_0)
    {
      Controller controller = new Controller(control_1, animateMode_0, animation_1, this.TimeStep, rectangle_0);
      controller.TransfromNeeded += new EventHandler<TransfromNeededEventArg>(this.OnTransformNeeded);
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_3 != null)
        controller.NonLinearTransfromNeeded += new EventHandler<NonLinearTransfromNeededEventArg>(this.OnNonLinearTransfromNeeded);
      controller.MouseDown += new EventHandler<MouseEventArgs>(this.OnMouseDown);
      controller.DoubleBitmap.Cursor = this.Cursor;
      controller.FramePainted += new EventHandler<PaintEventArgs>(this.method_9);
      return controller;
    }

    private void method_9(object sender, PaintEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_5 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_5(sender, e);
    }

    protected virtual void OnMouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        Controller controller = (Controller) sender;
        Point location = e.Location;
        location.Offset(controller.DoubleBitmap.Left - controller.AnimatedControl.Left, controller.DoubleBitmap.Top - controller.AnimatedControl.Top);
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_4 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_4(sender, new MouseEventArgs(e.Button, e.Clicks, location.X, location.Y, e.Delta));
      }
      catch
      {
      }
    }

    protected virtual void OnNonLinearTransfromNeeded(object sender, NonLinearTransfromNeededEventArg e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_3 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_3((object) this, e);
      }
      else
        e.UseDefaultTransform = true;
    }

    protected virtual void OnTransformNeeded(object sender, TransfromNeededEventArg e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_2((object) this, e);
      }
      else
        e.UseDefaultMatrix = true;
    }

    public void ClearQueue()
    {
      List<BunifuTransition.QueueItem> queueItemList = (List<BunifuTransition.QueueItem>) null;
      lock (this.queue)
      {
        queueItemList = new List<BunifuTransition.QueueItem>((IEnumerable<BunifuTransition.QueueItem>) this.queue);
        this.queue.Clear();
      }
      foreach (BunifuTransition.QueueItem queueItem in queueItemList)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        BunifuTransition.Class10 class10 = new BunifuTransition.Class10();
        // ISSUE: reference to a compiler-generated field
        class10.queueItem_0 = queueItem;
        // ISSUE: reference to a compiler-generated field
        if (class10.queueItem_0.control != null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          class10.queueItem_0.control.BeginInvoke((Delegate) new MethodInvoker(class10.method_0));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.OnAnimationCompleted(new AnimationCompletedEventArg()
        {
          Animation = class10.queueItem_0.animation,
          Control = class10.queueItem_0.control,
          Mode = class10.queueItem_0.mode
        });
      }
      if (queueItemList.Count <= 0)
        return;
      this.OnAllAnimationsCompleted();
    }

    protected virtual void OnAnimationCompleted(AnimationCompletedEventArg e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }

    protected virtual void OnAllAnimationsCompleted()
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_1 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_1((object) this, EventArgs.Empty);
    }

    public DecorationType GetDecoration(Control control)
    {
      if (this.dictionary_0.ContainsKey(control))
        return this.dictionary_0[control].DecorationType;
      return DecorationType.None;
    }

    public void SetDecoration(Control control, DecorationType decoration)
    {
      DecorationControl decorationControl = this.dictionary_0.ContainsKey(control) ? this.dictionary_0[control] : (DecorationControl) null;
      if (decoration == DecorationType.None)
      {
        decorationControl?.Dispose();
        this.dictionary_0.Remove(control);
      }
      else
      {
        if (decorationControl == null)
          decorationControl = new DecorationControl(decoration, control);
        decorationControl.DecorationType = decoration;
        this.dictionary_0[control] = decorationControl;
      }
    }

    public bool CanExtend(object extendee)
    {
      return extendee is Control;
    }

    private void method_10()
    {
    }

    protected class QueueItem
    {
      public Animation animation;
      public Controller controller;
      public Control control;
      public AnimateMode mode;
      public Rectangle clipRectangle;
      public bool isActive;

      public DateTime ActivateTime { get; private set; }

      public bool IsActive
      {
        get
        {
          return this.isActive;
        }
        set
        {
          if (this.isActive == value)
            return;
          this.isActive = value;
          if (!value)
            return;
          this.ActivateTime = DateTime.Now;
        }
      }
    }
  }
}
