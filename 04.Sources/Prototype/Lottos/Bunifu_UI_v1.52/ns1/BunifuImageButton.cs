// Decompiled with JetBrains decompiler
// Type: ns1.BunifuImageButton
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns0;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DefaultEvent("Click")]
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuImageButton : PictureBox
  {
    private int int_0 = 10;
    private Image image_0;
    private Image image_1;
    private IContainer icontainer_0;

    public BunifuImageButton()
    {
      this.method_0();
    }

    public int Zoom
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

    public Image ImageActive
    {
      get
      {
        return this.image_0;
      }
      set
      {
        this.image_0 = value;
      }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      if (this.image_0 != null)
      {
        this.image_1 = this.Image;
        this.Image = this.image_0;
      }
      Class6.smethod_0((Control) this, this.int_0);
      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      if (this.image_0 != null)
        this.Image = this.image_1;
      Class6.smethod_1((Control) this);
      base.OnMouseLeave(e);
    }

    protected override void OnClick(EventArgs e)
    {
      if (this.image_0 != null)
        this.Image = this.image_1;
      Class6.smethod_1((Control) this);
      base.OnClick(e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_0()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuImageButton));
      this.BeginInit();
      this.SuspendLayout();
      this.BackColor = Color.SeaGreen;
      this.Image = (Image) componentResourceManager.GetObject("$this.Image");
      this.Size = new Size(71, 71);
      this.SizeMode = PictureBoxSizeMode.Zoom;
      this.EndInit();
      this.ResumeLayout(false);
    }
  }
}
