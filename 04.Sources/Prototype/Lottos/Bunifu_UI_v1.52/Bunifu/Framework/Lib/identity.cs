// Decompiled with JetBrains decompiler
// Type: Bunifu.Framework.Lib.identity
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Management;

namespace Bunifu.Framework.Lib
{
  public static class identity
  {
    public static string getMotherBoardID()
    {
      string str = "";
      try
      {
        foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard").Get())
          str = managementBaseObject["SerialNumber"].ToString();
        return str;
      }
      catch (Exception ex)
      {
        return str;
      }
    }

    private static string smethod_0()
    {
      string str1 = identity.smethod_1("Win32_Processor", "UniqueId");
      if (str1 != "")
        return str1;
      string str2 = identity.smethod_1("Win32_Processor", "ProcessorId");
      if (str2 != "")
        return str2;
      string str3 = identity.smethod_1("Win32_Processor", "Name");
      if (str3 == "")
        str3 = identity.smethod_1("Win32_Processor", "Manufacturer");
      return str3 + identity.smethod_1("Win32_Processor", "MaxClockSpeed");
    }

    private static string smethod_1(string string_0, string string_1)
    {
      string str = "";
      foreach (ManagementBaseObject instance in new ManagementClass(string_0).GetInstances())
      {
        if (!(str != ""))
        {
          try
          {
            str = instance[string_1].ToString();
            break;
          }
          catch
          {
          }
        }
      }
      return str;
    }
  }
}
