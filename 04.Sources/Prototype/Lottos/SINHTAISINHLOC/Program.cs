// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.Program
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số
{
  internal static class Program
  {
    public static IAsyncResult result;

    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      new ClMain().Load_Data_Msg();
      Application.Run((Form) new FMain());
    }

    public static void Invoke(this Control control, Action action)
    {
      if (control.InvokeRequired)
        control.Invoke((Delegate) action);
      else
        action();
    }
  }
}
