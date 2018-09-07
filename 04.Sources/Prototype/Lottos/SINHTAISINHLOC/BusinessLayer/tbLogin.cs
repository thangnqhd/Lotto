// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbLogin
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Thống_kê_xổ_số.BusinessLayer
{
  internal class tbLogin
  {
    public static string tenDangnhap;
    public static string PublicIp;
    public static string PrivateIp;
    public static string OperationSystem;
    public static DateTime StartLogin;
    public static string MacAddress;

    public tbLogin()
    {
    }

    public tbLogin(string tenDangnhap, string public_ip, string private_ip, string operation_system, DateTime start_Login, string mac_Address)
    {
    }

    public string TenDangnhap
    {
      get
      {
        return tbLogin.tenDangnhap;
      }
      set
      {
        if (value == null)
          throw new Exception("tenDangnhap not allow nullvalue.");
        tbLogin.tenDangnhap = value;
      }
    }

    public string Public_ip
    {
      get
      {
        return tbLogin.PublicIp;
      }
      set
      {
        tbLogin.PublicIp = value;
      }
    }

    public string Private_ip
    {
      get
      {
        return tbLogin.PrivateIp;
      }
      set
      {
        tbLogin.PrivateIp = value;
      }
    }

    public string Operation_system
    {
      get
      {
        return tbLogin.OperationSystem;
      }
      set
      {
        tbLogin.OperationSystem = value;
      }
    }

    public DateTime Start_Login
    {
      get
      {
        return tbLogin.StartLogin;
      }
      set
      {
        tbLogin.StartLogin = value;
      }
    }

    public string Mac_Address
    {
      get
      {
        return tbLogin.MacAddress;
      }
      set
      {
        tbLogin.MacAddress = value;
      }
    }

    public override int GetHashCode()
    {
      return this.TenDangnhap.GetHashCode();
    }

    public static int Insert(tbLogin obj)
    {
      string cmdText = string.Format("tbLogin_Insert N'{0}', N'{1}', N'{2}', N'{3}', N'{4}'", (object) obj.TenDangnhap, (object) obj.Public_ip, (object) obj.Private_ip, (object) obj.Operation_system, (object) obj.Mac_Address);
      int num;
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        throw;
      }
      return num;
    }

    public static string getPublic_Ip()
    {
      try
      {
        return new Regex("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}").Matches(new WebClient().DownloadString("http://www.freegeoip.net/json/"))[0].ToString();
      }
      catch
      {
        return "";
      }
    }

    public static string GetLocalIPAddress()
    {
      foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
      {
        if (address.AddressFamily == AddressFamily.InterNetwork)
          return address.ToString();
      }
      throw new Exception("Local IP Address Not Found!");
    }

    public static string Get_OSVersion()
    {
      try
      {
        string name = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows NT\\CurrentVersion";
        return Registry.LocalMachine.OpenSubKey(name).GetValue("ProductName").ToString();
      }
      catch
      {
        return "Cannot get info";
      }
    }

    public static string GetMacAddress()
    {
      try
      {
        PhysicalAddress physicalAddress = ((IEnumerable<NetworkInterface>) NetworkInterface.GetAllNetworkInterfaces()).Where<NetworkInterface>((Func<NetworkInterface, bool>) (n =>
        {
          if (n.OperationalStatus == OperationalStatus.Up)
            return n.NetworkInterfaceType != NetworkInterfaceType.Loopback;
          return false;
        })).OrderByDescending<NetworkInterface, bool>((Func<NetworkInterface, bool>) (n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)).Select<NetworkInterface, PhysicalAddress>((Func<NetworkInterface, PhysicalAddress>) (n => n.GetPhysicalAddress())).FirstOrDefault<PhysicalAddress>();
        if (physicalAddress != null)
          return physicalAddress.ToString();
        return "Cannot get info";
      }
      catch
      {
        return "Cannot get info";
      }
    }
  }
}
