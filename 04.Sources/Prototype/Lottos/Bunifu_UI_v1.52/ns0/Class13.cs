// Decompiled with JetBrains decompiler
// Type: ns0.Class13
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns0
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Class13
  {
    private static ResourceManager resourceManager_0;
    private static CultureInfo cultureInfo_0;

    internal Class13()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Class13.resourceManager_0 == null)
          Class13.resourceManager_0 = new ResourceManager("ns0.Class13", typeof (Class13).Assembly);
        return Class13.resourceManager_0;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Class13.cultureInfo_0;
      }
      set
      {
        Class13.cultureInfo_0 = value;
      }
    }
  }
}
