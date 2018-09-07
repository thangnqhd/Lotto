// Decompiled with JetBrains decompiler
// Type: ns1.BunifuForm
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DebuggerStepThrough]
  public class BunifuForm : Form
  {
    private int int_0;
    private IContainer icontainer_0;

    public BunifuForm()
    {
      this.InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.None;
    }

    public int BorderRadius
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        Elipse.Apply((Form) this, this.int_0);
      }
    }

    protected override void OnResize(EventArgs e)
    {
      Elipse.Apply((Form) this, this.int_0);
      base.OnResize(e);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ClassStyle |= 131072;
        createParams.ExStyle |= 33554432;
        return createParams;
      }
    }

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
      this.ClientSize = new Size(284, 261);
      this.Name = nameof (BunifuForm);
      this.Text = nameof (BunifuForm);
      this.ResumeLayout(false);
    }
  }
}
