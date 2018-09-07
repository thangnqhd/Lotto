// Decompiled with JetBrains decompiler
// Type: ns0.Class0
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;

namespace ns0
{
  internal class Class0
  {
    private readonly SemaphoreSlim semaphoreSlim_0 = new SemaphoreSlim(0);
    private readonly string string_0;
    private readonly string string_1;
    private bool bool_0;
    public int int_0;

    public Class0(string string_2, string string_3)
    {
      if (string.IsNullOrEmpty(string_2))
        throw new ArgumentNullException("url");
      if (string.IsNullOrEmpty(string_3))
        throw new ArgumentNullException("fullPathWhereToSave");
      this.string_0 = string_2;
      this.string_1 = string_3;
    }

    public bool method_0(int int_1)
    {
      try
      {
        Directory.CreateDirectory(Path.GetDirectoryName(this.string_1));
        if (System.IO.File.Exists(this.string_1))
          System.IO.File.Delete(this.string_1);
        using (WebClient webClient = new WebClient())
        {
          Uri address = new Uri(this.string_0);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.method_1);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.method_2);
          Console.WriteLine("Downloading file:");
          webClient.DownloadFileAsync(address, this.string_1);
          this.semaphoreSlim_0.Wait(int_1);
          return this.bool_0 && System.IO.File.Exists(this.string_1);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Was not able to download file!");
        Console.Write((object) ex);
        return false;
      }
      finally
      {
        this.semaphoreSlim_0.Dispose();
      }
    }

    private void method_1(object sender, DownloadProgressChangedEventArgs e)
    {
      Console.Write("\r     -->    {0}%.", (object) e.ProgressPercentage);
      this.int_0 = e.ProgressPercentage;
    }

    private void method_2(object sender, AsyncCompletedEventArgs e)
    {
      this.int_0 = 0;
      this.bool_0 = !e.Cancelled;
      if (!this.bool_0)
        Console.Write(e.Error.ToString());
      Console.WriteLine(Environment.NewLine + "Download finished!");
      this.semaphoreSlim_0.Release();
    }

    public static bool smethod_0(string string_2, string string_3, int int_1)
    {
      return new Class0(string_2, string_3).method_0(int_1);
    }
  }
}
