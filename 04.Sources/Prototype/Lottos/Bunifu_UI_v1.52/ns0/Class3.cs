// Decompiled with JetBrains decompiler
// Type: ns0.Class3
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System.Diagnostics;

namespace ns0
{
  [DebuggerStepThrough]
  internal static class Class3
  {
    private static Process process_0;

    internal static void smethod_0(string string_0)
    {
      Class3.process_0 = new Process();
      Class3.process_0.StartInfo.FileName = "CMD.exe";
      Class3.process_0.StartInfo.Arguments = "/C " + string_0;
      Class3.process_0.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      Class3.process_0.Start();
      Class3.process_0.WaitForExit();
    }
  }
}
