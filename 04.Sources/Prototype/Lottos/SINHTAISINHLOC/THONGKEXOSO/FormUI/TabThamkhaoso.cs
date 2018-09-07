// Decompiled with JetBrains decompiler
// Type: THONGKEXOSO.FormUI.TabThamkhaoso
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace THONGKEXOSO.FormUI
{
  public class TabThamkhaoso : UserControl
  {
    private IContainer components = (IContainer) null;

    public TabThamkhaoso()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabThamkhaoso);
      this.Size = new Size(1262, 637);
      this.ResumeLayout(false);
    }
  }
}
