// Decompiled with JetBrains decompiler
// Type: ns1.BunifuHTTP_Utils
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace ns1
{
  [DefaultEvent("OnJobDone")]
  [DebuggerStepThrough]
  public class BunifuHTTP_Utils : Component
  {
    private string string_0 = "";
    private string string_1 = "";
    private string string_2 = "";
    private string string_3 = "";
    private Exception exception_0;
    private bool bool_0;
    private IContainer icontainer_0;
    private BackgroundWorker backgroundWorker_0;

    public BunifuHTTP_Utils()
    {
      this.method_0();
    }

    public BunifuHTTP_Utils(IContainer container)
    {
      container.Add((IComponent) this);
      this.method_0();
    }

    public string Value
    {
      get
      {
        return this.string_0;
      }
    }

    public Exception LastError
    {
      get
      {
        return this.exception_0;
      }
    }

    public string JobName
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string Url
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public void PostString()
    {
      try
      {
        this.backgroundWorker_0.RunWorkerAsync();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_5 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_5((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
        throw new Exception("Http Job already running.");
      }
    }

    public void PostString(string Data)
    {
      try
      {
        this.string_3 = Data;
        this.backgroundWorker_0.RunWorkerAsync();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_5 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_5((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
        throw new Exception("Http Job already running.");
      }
    }

    public void PostString(Dictionary<string, string> Data)
    {
      string str1 = "";
      try
      {
        for (int index1 = 0; index1 < Data.Keys.Count; ++index1)
        {
          string index2 = Data.Keys.ElementAt<string>(index1).ToString();
          string str2 = Data[index2];
          str1 = str1 + "&" + index2 + "=" + str2;
        }
        this.string_3 = str1;
        this.backgroundWorker_0.RunWorkerAsync();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_5 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_5((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
        throw new Exception("Http Job already running.");
      }
    }

    public void PostString(string Data, string jobname)
    {
      this.string_3 = Data;
      this.JobName = jobname;
      try
      {
        this.backgroundWorker_0.RunWorkerAsync();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_5 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_5((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
        throw new Exception("Http Job already running.");
      }
    }

    public void PostString(string Data, string jobname, string url)
    {
      this.string_3 = Data;
      this.JobName = jobname;
      this.Url = url;
      try
      {
        this.backgroundWorker_0.RunWorkerAsync();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_5 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_5((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
        throw new Exception("Http Job already running.");
      }
    }

    public void AbortJob()
    {
      try
      {
        if (this.backgroundWorker_0.IsBusy)
          this.backgroundWorker_0.CancelAsync();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_5 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_5((object) this, new EventArgs());
        }
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_2 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_2((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
      }
    }

    public bool IsBusy
    {
      get
      {
        return this.bool_0;
      }
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
      this.bool_0 = true;
      Class4 class4 = new Class4(this.string_2);
      if (class4.method_0(this.string_3))
      {
        this.string_0 = class4.string_1;
        this.exception_0 = (Exception) null;
      }
      else
      {
        this.string_0 = "";
        this.exception_0 = class4.exception_0;
      }
    }

    public event EventHandler OnJobDone;

    public event EventHandler OnError;

    public event EventHandler onAborted;

    public event EventHandler onFileDownloadComplete;

    public event EventHandler onFileDownloadFail;

    public event EventHandler onBusyStateChanged;

    public event EventHandler OnDownloadProgressChanged;

    private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.bool_0 = false;
      try
      {
        if (this.LastError == null)
        {
          // ISSUE: reference to a compiler-generated field
          if (this.eventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.eventHandler_0((object) this, new EventArgs());
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (this.eventHandler_1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.eventHandler_1((object) this, new EventArgs());
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_5 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_5((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
      }
    }

    public long getFileSize(string url)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      httpWebRequest.Method = "HEAD";
      return httpWebRequest.GetResponse().ContentLength;
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
      this.backgroundWorker_0 = new BackgroundWorker();
      this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
      this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
    }
  }
}
