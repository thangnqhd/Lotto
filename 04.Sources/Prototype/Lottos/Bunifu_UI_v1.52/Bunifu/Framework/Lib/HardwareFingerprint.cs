// Decompiled with JetBrains decompiler
// Type: Bunifu.Framework.Lib.HardwareFingerprint
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Bunifu.Framework.Lib
{
  public static class HardwareFingerprint
  {
    private static string string_0 = "";
    private static string string_1 = string.Empty;

    public static string Value()
    {
      if (string.IsNullOrEmpty(HardwareFingerprint.string_1))
        HardwareFingerprint.string_1 = HardwareFingerprint.smethod_5("CPU: " + HardwareFingerprint.smethod_8() + " BIOS: " + HardwareFingerprint.smethod_9() + " BASE: " + HardwareFingerprint.smethod_7() + " VIDEO: " + HardwareFingerprint.smethod_3());
      return HardwareFingerprint.string_1;
    }

    private static string smethod_0(string string_2, string string_3, string string_4)
    {
      string str = "";
      foreach (ManagementBaseObject instance in new ManagementClass(string_2).GetInstances())
      {
        if (!(instance[string_4].ToString() != "True"))
        {
          if (!(str != ""))
          {
            try
            {
              str = instance[string_3].ToString();
              break;
            }
            catch
            {
            }
          }
        }
      }
      return str;
    }

    private static string smethod_1(string string_2, string string_3)
    {
      string str = "";
      foreach (ManagementBaseObject instance in new ManagementClass(string_2).GetInstances())
      {
        if (!(str != ""))
        {
          try
          {
            str = instance[string_3].ToString();
            break;
          }
          catch
          {
          }
        }
      }
      return str;
    }

    private static string smethod_2()
    {
      return HardwareFingerprint.smethod_1("Win32_DiskDrive", "Model") + HardwareFingerprint.smethod_1("Win32_DiskDrive", "Manufacturer") + HardwareFingerprint.smethod_1("Win32_DiskDrive", "Signature") + HardwareFingerprint.smethod_1("Win32_DiskDrive", "TotalHeads");
    }

    private static string smethod_3()
    {
      return HardwareFingerprint.smethod_1("Win32_VideoController", "DriverVersion") + HardwareFingerprint.smethod_1("Win32_VideoController", "Name");
    }

    private static string smethod_4()
    {
      return HardwareFingerprint.smethod_0("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
    }

    private static string smethod_5(string string_2)
    {
      return HardwareFingerprint.smethod_6((IList<byte>) new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(string_2)));
    }

    private static string smethod_6(IList<byte> ilist_0)
    {
      string str1 = string.Empty;
      for (int index = 0; index < ilist_0.Count; ++index)
      {
        int num1 = (int) ilist_0[index];
        int num2 = num1 & 15;
        int num3 = num1 >> 4 & 15;
        string str2 = num3 <= 9 ? str1 + num3.ToString((IFormatProvider) CultureInfo.InvariantCulture) : str1 + ((char) (num3 - 10 + 65)).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        str1 = num2 <= 9 ? str2 + num2.ToString((IFormatProvider) CultureInfo.InvariantCulture) : str2 + ((char) (num2 - 10 + 65)).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (index + 1 != ilist_0.Count && (index + 1) % 2 == 0)
          str1 += "-";
      }
      return str1;
    }

    private static string smethod_7()
    {
      return HardwareFingerprint.smethod_1("Win32_BaseBoard", "Model") + HardwareFingerprint.smethod_1("Win32_BaseBoard", "Manufacturer") + HardwareFingerprint.smethod_1("Win32_BaseBoard", "Name") + HardwareFingerprint.smethod_1("Win32_BaseBoard", "SerialNumber");
    }

    private static string smethod_8()
    {
      string str1 = HardwareFingerprint.smethod_1("Win32_Processor", "UniqueId");
      if (str1 != "")
        return str1;
      string str2 = HardwareFingerprint.smethod_1("Win32_Processor", "ProcessorId");
      if (str2 != "")
        return str2;
      string str3 = HardwareFingerprint.smethod_1("Win32_Processor", "Name");
      if (str3 == "")
        str3 = HardwareFingerprint.smethod_1("Win32_Processor", "Manufacturer");
      return str3 + HardwareFingerprint.smethod_1("Win32_Processor", "MaxClockSpeed");
    }

    private static string smethod_9()
    {
      return HardwareFingerprint.smethod_1("Win32_BIOS", "Manufacturer") + HardwareFingerprint.smethod_1("Win32_BIOS", "SMBIOSBIOSVersion") + HardwareFingerprint.smethod_1("Win32_BIOS", "IdentificationCode") + HardwareFingerprint.smethod_1("Win32_BIOS", "SerialNumber") + HardwareFingerprint.smethod_1("Win32_BIOS", "ReleaseDate") + HardwareFingerprint.smethod_1("Win32_BIOS", "Version");
    }
  }
}
