// Decompiled with JetBrains decompiler
// Type: Bunifu.Framework.Lib.RestAPI
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.IO;
using System.Net;
using System.Text;

namespace Bunifu.Framework.Lib
{
  public static class RestAPI
  {
    public static string smethod_0(string url)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      try
      {
        using (Stream responseStream = httpWebRequest.GetResponse().GetResponseStream())
          return new StreamReader(responseStream, Encoding.UTF8).ReadToEnd();
      }
      catch (WebException ex1)
      {
        try
        {
          using (Stream responseStream = ex1.Response.GetResponseStream())
            new StreamReader(responseStream, Encoding.GetEncoding("utf-8")).ReadToEnd();
          throw;
        }
        catch (Exception ex2)
        {
          return "{\"error\": \"" + ex2.Message + "\"  }";
        }
      }
    }

    public static string POST(string url, string jsonContent)
    {
      try
      {
        string str = "";
        using (WebClient webClient = new WebClient())
        {
          webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
          str = webClient.UploadString(url, nameof (POST), jsonContent);
        }
        return str;
      }
      catch (Exception ex)
      {
        return "{\"error\": \"" + ex.Message + "\"  }";
      }
    }

    public static string PATCH(string url, string jsonContent)
    {
      try
      {
        string str = "";
        using (WebClient webClient = new WebClient())
        {
          webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
          str = webClient.UploadString(url, nameof (PATCH), jsonContent);
        }
        return str;
      }
      catch (Exception ex)
      {
        return "{\"error\": \"" + ex.Message + "\"  }";
      }
    }

    public static string DELETE(string url, string jsonContent)
    {
      try
      {
        string str = "";
        using (WebClient webClient = new WebClient())
        {
          webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
          str = webClient.UploadString(url, nameof (DELETE), jsonContent);
        }
        return str;
      }
      catch (Exception ex)
      {
        return "{\"error\": \"" + ex.Message + "\"  }";
      }
    }
  }
}
