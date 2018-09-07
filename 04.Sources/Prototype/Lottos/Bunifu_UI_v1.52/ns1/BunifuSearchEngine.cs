// Decompiled with JetBrains decompiler
// Type: ns1.BunifuSearchEngine
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ns1
{
  [DebuggerStepThrough]
  [DefaultEvent("onScanComlete")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuSearchEngine : UserControl
  {
    public string lastError = "";
    public string curFolder = "";
    public List<FileInfo> Files = new List<FileInfo>();
    public List<DirectoryInfo> Folders = new List<DirectoryInfo>();
    public int Passentage;
    public string path;
    public string curFile;
    public bool pause;
    private IContainer icontainer_0;
    private BackgroundWorker backgroundWorker_0;

    public BunifuSearchEngine()
    {
      this.InitializeComponent();
      int usageMode = (int) LicenseManager.UsageMode;
      Bunifu.Framework.License.Check((Control) this);
    }

    public event EventHandler onFileScan;

    public event EventHandler onScanError;

    public event EventHandler onFolderScan;

    public event EventHandler onFailed;

    public event EventHandler onAborted;

    public event EventHandler onScanComplete;

    public void startScan(string _path)
    {
      this.path = _path;
      if (!this.backgroundWorker_0.IsBusy)
      {
        this.backgroundWorker_0.RunWorkerAsync();
      }
      else
      {
        int num = (int) MessageBox.Show("Scan Engine Busy");
      }
    }

    public void abortScan()
    {
    }

    public void restartScan()
    {
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
      List<string> stringList = new List<string>();
      stringList.Add(this.path);
      this.Folders.Add(new DirectoryInfo(this.path));
      while (stringList.Count > 0)
      {
        this.curFolder = stringList[0];
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_2 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.Invoke((Delegate) (() => this.eventHandler_2((object) this, (EventArgs) null)));
        }
        try
        {
          foreach (string directory in Directory.GetDirectories(this.curFolder))
            stringList.Add(directory);
        }
        catch (Exception ex)
        {
          this.lastError = ex.Message;
          // ISSUE: reference to a compiler-generated field
          if (this.eventHandler_1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.Invoke((Delegate) (() => this.eventHandler_1((object) this, (EventArgs) null)));
          }
        }
        try
        {
          foreach (string file in Directory.GetFiles(this.curFolder))
          {
            this.curFile = file;
            this.Files.Add(new FileInfo(this.curFile));
            // ISSUE: reference to a compiler-generated field
            if (this.eventHandler_0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.Invoke((Delegate) (() => this.eventHandler_0((object) this, (EventArgs) null)));
            }
          }
        }
        catch (Exception ex)
        {
          this.lastError = ex.Message;
          // ISSUE: reference to a compiler-generated field
          if (this.eventHandler_1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.Invoke((Delegate) (() => this.eventHandler_1((object) this, (EventArgs) null)));
          }
        }
        stringList.RemoveAt(0);
      }
    }

    private void BunifuSearchEngine_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    }

    private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_5 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_5((object) this, (EventArgs) null);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.backgroundWorker_0 = new BackgroundWorker();
      this.SuspendLayout();
      this.backgroundWorker_0.WorkerReportsProgress = true;
      this.backgroundWorker_0.WorkerSupportsCancellation = true;
      this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
      this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
      this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.DoubleBuffered = true;
      this.Name = nameof (BunifuSearchEngine);
      this.Size = new Size(43, 44);
      this.Load += new EventHandler(this.BunifuSearchEngine_Load);
      this.ResumeLayout(false);
    }
  }
}
