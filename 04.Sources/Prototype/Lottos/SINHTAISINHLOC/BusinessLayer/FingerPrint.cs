// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.FingerPrint
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class FingerPrint
  {
    private static string fingerPrint = string.Empty;

    public static string GetIDCValue()
    {
      if (string.IsNullOrEmpty(FingerPrint.fingerPrint))
        FingerPrint.fingerPrint = FingerPrint.GetHash("\nDISK >> " + FingerPrint.diskId() + "\nMAC >> " + FingerPrint.macId());
      return FingerPrint.fingerPrint;
    }

    private static string GetHash(string s)
    {
      return FingerPrint.GetHexString(new MD5CryptoServiceProvider().ComputeHash(new ASCIIEncoding().GetBytes(s)));
    }

    private static string GetHexString(byte[] bt)
    {
      string str1 = string.Empty;
      for (int index = 0; index < bt.Length; ++index)
      {
        int num1 = (int) bt[index];
        int num2 = num1 & 15;
        int num3 = num1 >> 4 & 15;
        string str2 = num3 <= 9 ? str1 + num3.ToString() : str1 + ((char) (num3 - 10 + 65)).ToString();
        str1 = num2 <= 9 ? str2 + num2.ToString() : str2 + ((char) (num2 - 10 + 65)).ToString();
        if (index + 1 != bt.Length && (index + 1) % 2 == 0)
          str1 += "-";
      }
      return str1;
    }

    private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
    {
      string str = "";
      foreach (ManagementObject instance in new ManagementClass(wmiClass).GetInstances())
      {
        if (instance[wmiMustBeTrue].ToString() == "True")
        {
          if (str == "")
          {
            try
            {
              str = instance[wmiProperty].ToString();
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

    private static string identifier(string wmiClass, string wmiProperty)
    {
      string str = "";
      foreach (ManagementObject instance in new ManagementClass(wmiClass).GetInstances())
      {
        if (str == "")
        {
          try
          {
            str = instance[wmiProperty].ToString();
            break;
          }
          catch
          {
          }
        }
      }
      return str;
    }

    private static string cpuId()
    {
      string str1 = FingerPrint.identifier("Win32_Processor", "UniqueId");
      if (str1 == "")
      {
        str1 = FingerPrint.identifier("Win32_Processor", "ProcessorId");
        if (str1 == "")
        {
          string str2 = FingerPrint.identifier("Win32_Processor", "Name");
          if (str2 == "")
            str2 = FingerPrint.identifier("Win32_Processor", "Manufacturer");
          str1 = str2 + FingerPrint.identifier("Win32_Processor", "MaxClockSpeed");
        }
      }
      return str1;
    }

    private static string biosId()
    {
      return FingerPrint.identifier("Win32_BIOS", "Manufacturer") + FingerPrint.identifier("Win32_BIOS", "SMBIOSBIOSVersion") + FingerPrint.identifier("Win32_BIOS", "IdentificationCode") + FingerPrint.identifier("Win32_BIOS", "SerialNumber") + FingerPrint.identifier("Win32_BIOS", "ReleaseDate") + FingerPrint.identifier("Win32_BIOS", "Version");
    }

    private static string diskId()
    {
      return FingerPrint.identifier("Win32_DiskDrive", "Model") + FingerPrint.identifier("Win32_DiskDrive", "Manufacturer") + FingerPrint.identifier("Win32_DiskDrive", "Signature") + FingerPrint.identifier("Win32_DiskDrive", "TotalHeads");
    }

    private static string baseId()
    {
      return FingerPrint.identifier("Win32_BaseBoard", "Model") + FingerPrint.identifier("Win32_BaseBoard", "Manufacturer") + FingerPrint.identifier("Win32_BaseBoard", "Name") + FingerPrint.identifier("Win32_BaseBoard", "SerialNumber");
    }

    private static string videoId()
    {
      return FingerPrint.identifier("Win32_VideoController", "DriverVersion") + FingerPrint.identifier("Win32_VideoController", "Name");
    }

    private static string macId()
    {
      return FingerPrint.identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
    }
  }
}
