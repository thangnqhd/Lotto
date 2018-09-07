// Decompiled with JetBrains decompiler
// Type: Bunifu.Framework.Lib.Elipse
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bunifu.Framework.Lib
{
  [DebuggerStepThrough]
  public static class Elipse
  {
    [DllImport("Gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

    public static void Apply(Form Form, int _Elipse)
    {
      try
      {
        Form.FormBorderStyle = FormBorderStyle.None;
        Form.Region = Region.FromHrgn(Elipse.CreateRoundRectRgn(0, 0, Form.Width, Form.Height, _Elipse, _Elipse));
      }
      catch (Exception ex)
      {
      }
    }

    public static void Apply(Control ctrl, int Elipse)
    {
      try
      {
        ctrl.Region = Region.FromHrgn(Elipse.CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, Elipse, Elipse));
      }
      catch (Exception ex)
      {
      }
    }
  }
}
