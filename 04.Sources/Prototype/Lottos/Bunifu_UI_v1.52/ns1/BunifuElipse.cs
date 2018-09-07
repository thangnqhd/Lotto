// Decompiled with JetBrains decompiler
// Type: ns1.BunifuElipse
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;

namespace ns1
{
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DebuggerStepThrough]
  public class BunifuElipse : Component
  {
    private int int_0 = 5;
    private ContainerControl containerControl_0;
    private Control control_0;
    private IContainer icontainer_0;
    private Timer timer_0;

    public BunifuElipse()
    {
      this.method_0();
      if (this.TargetControl != null)
        return;
      this.TargetControl = (Control) this.ContainerControl_0;
    }

    public BunifuElipse(IContainer container)
    {
      container.Add((IComponent) this);
      this.method_0();
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
        this.ApplyElipse();
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

    private void control_0_Resize(object sender, EventArgs e)
    {
      Elipse.Apply(this.control_0, this.int_0);
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
    }

    public event EventHandler TargetControlResized;

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

    public int ElipseRadius
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        this.ApplyElipse();
      }
    }

    public void ApplyElipse(int Radius)
    {
      if (this.control_0 == null)
        return;
      Elipse.Apply(this.control_0, Radius);
    }

    public void ApplyElipse()
    {
      try
      {
        if (this.control_0 == null)
          return;
        Elipse.Apply(this.control_0, this.int_0);
      }
      catch (Exception ex)
      {
      }
    }

    public void ApplyElipse(Control control, int Radius)
    {
      if (control == null)
        return;
      Elipse.Apply(control, Radius);
    }

    public void ApplyElipse(Control control)
    {
      if (control == null)
        return;
      Elipse.Apply(control, this.int_0);
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      try
      {
        this.timer_0.Stop();
        if (this.control_0 != null)
        {
          this.control_0.Resize += new EventHandler(this.control_0_Resize);
        }
        else
        {
          this.control_0 = (Control) this.ContainerControl_0;
          this.control_0.Resize += new EventHandler(this.control_0_Resize);
        }
        if (this.control_0.GetType() == typeof (Form))
          ((Form) this.control_0).FormBorderStyle = FormBorderStyle.None;
        this.ApplyElipse();
      }
      catch (Exception ex)
      {
        this.timer_0.Start();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_0()
    {
      this.icontainer_0 = (IContainer) new Container();
      this.timer_0 = new Timer(this.icontainer_0);
      this.timer_0.Enabled = true;
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    }
  }
}
