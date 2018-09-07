// Decompiled with JetBrains decompiler
// Type: ns1.Drag
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  public class Drag : Form
  {
    private bool bool_0;
    private int int_0;
    private int int_1;
    private Control control_0;

    public void Grab(Control a)
    {
      try
      {
        this.control_0 = a;
        this.bool_0 = true;
        this.int_0 = Control.MousePosition.X - this.control_0.Left;
        this.int_1 = Control.MousePosition.Y - this.control_0.Top;
      }
      catch (Exception ex)
      {
      }
    }

    public void Release()
    {
      this.bool_0 = false;
    }

    public void MoveObject(bool Horizontal = true, bool Vertical = true)
    {
      try
      {
        if (!this.bool_0)
          return;
        Point mousePosition = Control.MousePosition;
        int x = mousePosition.X;
        mousePosition = Control.MousePosition;
        int y = mousePosition.Y;
        if (Vertical)
          this.control_0.Top = y - this.int_1;
        if (!Horizontal)
          return;
        this.control_0.Left = x - this.int_0;
      }
      catch (Exception ex)
      {
      }
    }
  }
}
