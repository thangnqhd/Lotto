// Decompiled with JetBrains decompiler
// Type: ns1.BunifuFormFadeTransition
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace ns1
{
  public class BunifuFormFadeTransition : Component
  {
    private int int_0 = 1;
    private Form form_0;
    private double double_0;
    private IContainer icontainer_0;
    private BackgroundWorker backgroundWorker_0;

    public BunifuFormFadeTransition()
    {
      this.method_0();
    }

    public BunifuFormFadeTransition(IContainer container)
    {
      container.Add((IComponent) this);
      this.method_0();
    }

    public void ShowAsyc(Form frm)
    {
      try
      {
        this.form_0 = frm;
        this.backgroundWorker_0.RunWorkerAsync();
      }
      catch (Exception ex)
      {
      }
    }

    public void HideAsyc(Form frm, bool Close)
    {
      this.form_0 = frm;
    }

    public int Delay
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public event EventHandler TransitionEnd;

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
      this.double_0 = 0.0;
      while (this.double_0 < 1.0)
      {
        this.backgroundWorker_0.ReportProgress(0);
        Thread.Sleep(this.Delay);
        this.double_0 += 0.001;
      }
    }

    private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.form_0.Opacity = this.double_0;
    }

    private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.form_0.Opacity = 1.0;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, (EventArgs) e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_0()
    {
      this.backgroundWorker_0 = new BackgroundWorker();
      this.backgroundWorker_0.WorkerReportsProgress = true;
      this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
      this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
      this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
    }
  }
}
