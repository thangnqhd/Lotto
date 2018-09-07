// Decompiled with JetBrains decompiler
// Type: Bunifu.Framework.License
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using ns0;
using System;
using System.Windows.Forms;

namespace Bunifu.Framework
{
  public static class License
  {
    public static string myidentity = "";

    static License()
    {
      if (!License.IsInDesignMode())
        return;
      License.Check(true);
    }

    public static void Check(Control sender)
    {
    }

    public static void Check(bool firstTime)
    {
      if (!License.IsInDesignMode() || !(License.ValidateLicense().ToLower().Trim() != "true"))
        return;
      DialogResult dialogResult;
      if (dialogResult == DialogResult.Abort)
        Class3.smethod_0("taskkill /im devenv.exe /f");
      if (dialogResult != DialogResult.Ignore || !firstTime)
        return;
      Timer timer = new Timer();
      timer.Interval = 5000;
      timer.Tick += new EventHandler(License.smethod_0);
      timer.Start();
    }

    private static void smethod_0(object sender, EventArgs e)
    {
      ((Timer) sender).Enabled = false;
      License.Check(false);
      ((Timer) sender).Enabled = true;
    }

    public static string ValidateLicense()
    {
      if (License.myidentity.Trim().Length == 0)
        License.myidentity = HardwareFingerprint.Value().ToString();
      try
      {
        string str1 = Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.product", EnvironmentVariableTarget.Machine).Trim(), License.myidentity, "tu89geji340t89u2");
        if (Environment.GetEnvironmentVariable("BunifuFramework.product", EnvironmentVariableTarget.Machine).Trim() == "Blocked")
          return "Bunifu framework installation blocked";
        if (str1.Trim().Length <= 0)
          return "Bunifu Framework not installed";
        string str2 = Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.token", EnvironmentVariableTarget.Machine).Trim(), License.myidentity, "tu89geji340t89u2");
        string s1 = Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.date", EnvironmentVariableTarget.Machine).Trim(), License.myidentity, "tu89geji340t89u2");
        string s2 = Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.days", EnvironmentVariableTarget.Machine).Trim(), License.myidentity, "tu89geji340t89u2");
        string s3 = Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.expiry", EnvironmentVariableTarget.Machine).Trim(), License.myidentity, "tu89geji340t89u2");
        Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.email", EnvironmentVariableTarget.Machine).Trim(), License.myidentity, "tu89geji340t89u2");
        Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.key", EnvironmentVariableTarget.Machine).Trim(), License.myidentity, "tu89geji340t89u2");
        string s4 = DateTime.Now.Ticks.ToString();
        try
        {
          s4 = Class5.smethod_1(Environment.GetEnvironmentVariable("BunifuFramework.lastseen", EnvironmentVariableTarget.User).Trim(), License.myidentity, "tu89geji340t89u2");
        }
        catch
        {
        }
        if (s4.ToLower() == "blocked" || str2.ToLower() == "blocked")
          return "Bunifu Framework Blocked";
        if (License.myidentity != str2)
          return "-Bunifu License Rejected, Contact Bunifu for support";
        DateTime dateTime1 = new DateTime(long.Parse(s1));
        DateTime dateTime2 = new DateTime(long.Parse(s4));
        DateTime dateTime3 = new DateTime(long.Parse(s3));
        if (DateTime.Now < dateTime1)
          return "-Please Correct the system date to proceed [DI]";
        if (DateTime.Now < dateTime2)
          return "-Please Correct the system date to proceed [LS]";
        string variable = "BunifuFramework.stat.lastseen";
        DateTime dateTime4 = DateTime.Today;
        string str3 = Class5.smethod_0(dateTime4.Ticks.ToString(), License.myidentity, "tu89geji340t89u2");
        int num = 1;
        Environment.SetEnvironmentVariable(variable, str3, (EnvironmentVariableTarget) num);
        if (DateTime.Now > dateTime3)
          return "Design Time License expired :(";
        TimeSpan timeSpan;
        ref TimeSpan local = ref timeSpan;
        long ticks1 = dateTime3.Ticks;
        dateTime4 = DateTime.Now;
        long ticks2 = dateTime4.Ticks;
        long ticks3 = ticks1 - ticks2;
        local = new TimeSpan(ticks3);
        if (int.Parse(s2) - timeSpan.Days <= 0)
          return "License Expired.";
        return true.ToString();
      }
      catch (Exception ex)
      {
        return "[M] Bunifu Framework not installed ";
      }
    }

    public static bool IsInDesignMode()
    {
      return Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1;
    }

    public static void Authenticate(string email, string token)
    {
      if (Class5.smethod_1(token, "dMyKVp19z6", "tu89geji340t89u2") == email)
        Class1.bool_0 = true;
      else
        Class1.bool_0 = false;
    }

    public static void ViewLicenseAgreement()
    {
      int num = (int) MessageBox.Show("IMPORTANT – PLEASE READ THIS END USER LICENSE AGREEMENT (THE “AGREEMENT”) CAREFULLY\r\n\r\nBEFORE ATTEMPTING TO DOWNLOAD OR USE ANY SOFTWARE, DOCUMENTATION, OR OTHER\r\n\r\nMATERIALS MADE AVAILABLE THROUGH THIS WEB SITE (devtools.bunifu.co.ke).\r\n\r\nTHIS AGREEMENT CONSTITUTES A LEGALLY BINDING AGREEMENT BETWEEN YOU OR THE COMPANY\r\n\r\nWHICH YOU REPRESENT AND ARE AUTHORIZED TO BIND (the “Licensee” or “You”), AND BUNIFU\r\n\r\nTECHNOLOGIES LTD. AD (“Bunifu Technologies Ltd.” or “Licensor”).\r\n\r\nPLEASE CHECK THE “I HAVE READ AND AGREE TO THE LICENSE AGREEMENT” BOX AT THE BOTTOM\r\n\r\nOF THIS AGREEMENT IF YOU AGREE TO BE BOUND BY THE TERMS AND CONDITIONS OF THIS\r\n\r\nAGREEMENT. BY CHECKING THE “I HAVE READ AND AGREE TO THE LICENSE AGREEMENT” BOX\r\n\r\nAND/OR BY PURCHASING, DOWNLOADING, INSTALLING OR OTHERWISE USING THE SOFTWARE\r\n\r\nMADE AVAILABLE BY BUNIFU THROUGH THIS WEB SITE, YOU ACKNOWLEDGE:\r\n\r\n(1) THAT YOU HAVE READ THIS AGREEMENT,\r\n\r\n(2) THAT YOU UNDERSTAND IT,\r\n\r\n(3) THAT YOU AGREE TO BE BOUND BY ITS TERMS AND CONDITIONS, AND\r\n\r\n(4) TO THE EXTENT YOU ARE ENTERING INTO THIS AGREEMENT ON BEHALF OF A COMPANY, YOU\r\n\r\nHAVE THE POWER AND AUTHORITY TO BIND THAT COMPANY.\r\n\r\nContent Management System and/or .NET component vendors are not allowed to use the Software\r\n\r\n(as defined below) without the express permission of Bunifu Technologies Ltd. If you or the company\r\n\r\nyou represent is a Content Management System or .NET component vendor, you may not purchase a\r\n\r\nlicense for or use the Software unless you contact Bunifu Technologies Ltd. directly and obtain\r\n\r\npermission.\r\n\r\nThis License does not grant You a license or any rights to the “2007 Microsoft Office System User\r\n\r\nInterface” and You must contact Microsoft directly to obtain such a license. Any and all rights in the\r\n\r\nSoftware not expressly granted to You as part of the License hereunder are reserved in all respects by\r\n\r\nBunifu.");
    }
  }
}
