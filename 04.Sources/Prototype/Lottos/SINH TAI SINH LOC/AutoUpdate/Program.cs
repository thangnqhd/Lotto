// Decompiled with JetBrains decompiler
// Type: AutoUpdate.Program
// Assembly: SINH TAI SINH LOC, Version=2.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: 604FDB85-ADA0-4F31-900F-9755444F7FBB
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINH TAI SINH LOC.exe

using System;
using System.Windows.Forms;

namespace AutoUpdate
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
