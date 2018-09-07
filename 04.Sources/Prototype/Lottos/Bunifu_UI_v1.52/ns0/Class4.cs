// Decompiled with JetBrains decompiler
// Type: ns0.Class4
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace ns0
{
  [DebuggerStepThrough]
  internal class Class4
  {
    public string string_0 = "";
    public string string_1 = "";
    public Exception exception_0 = new Exception();

    public Class4(string string_2)
    {
      this.string_0 = string_2;
    }

    public bool method_0(string string_2)
    {
      try
      {
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(this.string_0);
        httpWebRequest.Method = "POST";
        byte[] bytes = Encoding.ASCII.GetBytes(string_2);
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        httpWebRequest.ContentLength = (long) bytes.Length;
        Stream requestStream = httpWebRequest.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        response.GetResponseStream();
        this.string_1 = new StreamReader(response.GetResponseStream()).ReadToEnd();
        return true;
      }
      catch (Exception ex)
      {
        this.string_1 = "";
        this.exception_0 = ex;
        return false;
      }
    }
  }
}
