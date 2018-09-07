// Decompiled with JetBrains decompiler
// Type: ns1.BunifuCustomLabel
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  public class BunifuCustomLabel : Label
  {
    public BunifuCustomLabel()
    {
      this.SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (!this.Enabled)
      {
        SolidBrush solidBrush = new SolidBrush(this.ForeColor);
        e.Graphics.DrawString(this.Text, this.Font, (Brush) solidBrush, 0.0f, 0.0f);
      }
      else
        base.OnPaint(e);
    }
  }
}
