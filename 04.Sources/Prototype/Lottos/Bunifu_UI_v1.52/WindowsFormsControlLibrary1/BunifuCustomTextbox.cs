// Decompiled with JetBrains decompiler
// Type: WindowsFormsControlLibrary1.BunifuCustomTextbox
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
  public class BunifuCustomTextbox : TextBox
  {
    private Color color_0 = Color.SeaGreen;
    private IContainer icontainer_0;

    public BunifuCustomTextbox()
    {
      this.method_0();
    }

    public Color BorderColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.Refresh();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Pen pen = new Pen(this.BorderColor, 1f);
      Rectangle rect;
      ref Rectangle local1 = ref rect;
      Rectangle clipRectangle1 = e.ClipRectangle;
      int x1 = clipRectangle1.X;
      clipRectangle1 = e.ClipRectangle;
      int y1 = clipRectangle1.Y;
      clipRectangle1 = e.ClipRectangle;
      int width1 = clipRectangle1.Width - 1;
      clipRectangle1 = e.ClipRectangle;
      int height1 = clipRectangle1.Height - 1;
      local1 = new Rectangle(x1, y1, width1, height1);
      e.Graphics.DrawRectangle(pen, rect);
      Rectangle bounds;
      ref Rectangle local2 = ref bounds;
      Rectangle clipRectangle2 = e.ClipRectangle;
      int x2 = clipRectangle2.X + 1;
      clipRectangle2 = e.ClipRectangle;
      int y2 = clipRectangle2.Y + 1;
      clipRectangle2 = e.ClipRectangle;
      int width2 = clipRectangle2.Width - 1;
      clipRectangle2 = e.ClipRectangle;
      int height2 = clipRectangle2.Height - 1;
      local2 = new Rectangle(x2, y2, width2, height2);
      TextRenderer.DrawText((IDeviceContext) e.Graphics, this.Text, this.Font, bounds, this.ForeColor, this.BackColor, TextFormatFlags.Default);
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
    }
  }
}
