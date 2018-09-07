// Decompiled with JetBrains decompiler
// Type: ns0.Class6
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ns0
{
  [DebuggerStepThrough]
  internal static class Class6
  {
    private static bool bool_0 = true;
    private static int int_0;
    private static int int_1;
    private static int int_2;
    private static int int_3;

    public static void smethod_0(Control control_0, int int_4)
    {
      if (!Class6.bool_0)
        return;
      Class6.int_0 = control_0.Height;
      Class6.int_1 = control_0.Width;
      int int32_1 = Convert.ToInt32(Math.Round((double) int_4 * 0.01 * (double) Class6.int_0) * 0.5);
      int int32_2 = Convert.ToInt32(Math.Round((double) int_4 * 0.01 * (double) Class6.int_1) * 0.5);
      int num1 = Class6.int_0 + int32_1 * 2;
      int num2 = Class6.int_1 + int32_2 * 2;
      Class6.int_2 = int32_1;
      Class6.int_3 = int32_2;
      control_0.Width = num2;
      control_0.Height = num1;
      control_0.Top -= Class6.int_2;
      control_0.Left -= Class6.int_3;
      Class6.bool_0 = false;
    }

    public static void smethod_1(Control control_0)
    {
      if (Class6.bool_0)
        return;
      control_0.SuspendLayout();
      control_0.Width = Class6.int_1;
      control_0.Left += Class6.int_3;
      control_0.Height = Class6.int_0;
      control_0.Top += Class6.int_2;
      control_0.ResumeLayout();
      Class6.bool_0 = true;
    }

    public static void smethod_2(Control control_0)
    {
      Class6.smethod_1(control_0);
    }

    public static void smethod_3(Control control_0)
    {
    }
  }
}
