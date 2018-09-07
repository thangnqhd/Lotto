// Decompiled with JetBrains decompiler
// Type: ns1.BunifuDragControl
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;

namespace ns1
{
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuDragControl : Component
  {
    private Drag drag_0 = new Drag();
    private bool bool_0 = true;
    private bool bool_1 = true;
    private bool bool_2 = true;
    private Control control_0;
    private ContainerControl containerControl_0;
    private IContainer icontainer_0;
    private Timer timer_0;

    public BunifuDragControl()
    {
      this.method_3();
      int usageMode = (int) LicenseManager.UsageMode;
    }

    public BunifuDragControl(IContainer container)
    {
      container.Add((IComponent) this);
      this.method_3();
    }

    public void Grab(Control _control)
    {
      this.drag_0.Grab(_control);
    }

    public void Grab()
    {
      this.drag_0.Grab((Control) this.containerControl_0);
    }

    public void Release()
    {
      this.drag_0.Release();
    }

    public void Drag(bool horixontal = true, bool Vertical = true)
    {
      this.drag_0.MoveObject(Vertical, horixontal);
    }

    public Control TargetControl
    {
      get
      {
        return this.control_0;
      }
      set
      {
        this.control_0 = value;
      }
    }

    private ContainerControl ContainerControl_0
    {
      get
      {
        return this.containerControl_0;
      }
      set
      {
        this.containerControl_0 = value;
      }
    }

    public override ISite Site
    {
      get
      {
        return base.Site;
      }
      set
      {
        base.Site = value;
        if (value == null)
          return;
        IDesignerHost service = value.GetService(typeof (IDesignerHost)) as IDesignerHost;
        if (service == null)
          return;
        IComponent rootComponent = service.RootComponent;
        if (!(rootComponent is ContainerControl))
          return;
        this.ContainerControl_0 = rootComponent as ContainerControl;
      }
    }

    public bool Fixed
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

    public bool Vertical
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public bool Horizontal
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      try
      {
        this.timer_0.Stop();
        Control control = (Control) this.ContainerControl_0;
        if (this.control_0 != null)
          control = this.control_0;
        control.MouseDown += new MouseEventHandler(this.method_2);
        control.MouseMove += new MouseEventHandler(this.method_0);
        control.MouseUp += new MouseEventHandler(this.method_1);
      }
      catch (Exception ex)
      {
      }
    }

    private void method_0(object sender, MouseEventArgs e)
    {
      this.Drag(this.Vertical, this.Horizontal);
    }

    private void method_1(object sender, MouseEventArgs e)
    {
      this.Release();
    }

    private void method_2(object sender, MouseEventArgs e)
    {
      if (this.bool_0)
      {
        Control _control = (Control) sender;
        while (_control.Parent != null)
          _control = _control.Parent;
        this.Grab(_control);
      }
      else
        this.Grab((Control) sender);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_3()
    {
      this.icontainer_0 = (IContainer) new Container();
      this.timer_0 = new Timer(this.icontainer_0);
      this.timer_0.Enabled = true;
      this.timer_0.Interval = 1;
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    }
  }
}
