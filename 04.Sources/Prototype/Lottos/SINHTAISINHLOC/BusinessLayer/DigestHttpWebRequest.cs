// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.DigestHttpWebRequest
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class DigestHttpWebRequest
  {
    private string _requestMethod = "GET";
    private string _user;
    private string _password;
    private string _realm;
    private string _nonce;
    private string _qop;
    private string _cnonce;
    private string _opaque;
    private DateTime _cnonceDate;
    private int _nc;
    private string _contentType;
    private byte[] _postData;

    public DigestHttpWebRequest(string user, string password)
    {
      this._user = user;
      this._password = password;
    }

    public DigestHttpWebRequest(string user, string password, string realm)
    {
      this._user = user;
      this._password = password;
      this._realm = realm;
    }

    public string Method
    {
      get
      {
        return this._requestMethod;
      }
      set
      {
        this._requestMethod = value;
      }
    }

    public string ContentType
    {
      get
      {
        return this._contentType;
      }
      set
      {
        this._contentType = value;
      }
    }

    public byte[] PostData
    {
      get
      {
        return this._postData;
      }
      set
      {
        this._postData = value;
      }
    }

    public HttpWebResponse GetResponse(Uri uri)
    {
      HttpWebResponse httpWebResponse = (HttpWebResponse) null;
      int num1 = 0;
      int num2 = 2;
      while ((httpWebResponse == null || httpWebResponse.StatusCode != HttpStatusCode.Accepted) && num1 < num2)
      {
        try
        {
          HttpWebRequest webRequestObject1 = this.CreateHttpWebRequestObject(uri);
          if (!string.IsNullOrEmpty(this._cnonce) && DateTime.Now.Subtract(this._cnonceDate).TotalHours < 1.0)
            webRequestObject1.Headers.Add("Authorization", this.ComputeDigestHeader(uri));
          try
          {
            httpWebResponse = (HttpWebResponse) webRequestObject1.GetResponse();
          }
          catch (WebException ex)
          {
            if (ex.Response == null || ((HttpWebResponse) ex.Response).StatusCode != HttpStatusCode.Unauthorized)
              throw ex;
            string header = ex.Response.Headers["WWW-Authenticate"];
            this._realm = this.GetDigestHeaderAttribute("realm", header);
            this._nonce = this.GetDigestHeaderAttribute("nonce", header);
            this._qop = this.GetDigestHeaderAttribute("qop", header);
            this._opaque = this.GetDigestHeaderAttribute("opaque", header);
            this._nc = 0;
            this._cnonce = new Random().Next(123400, 9999999).ToString();
            this._cnonceDate = DateTime.Now;
            HttpWebRequest webRequestObject2 = this.CreateHttpWebRequestObject(uri, true);
            ++num1;
            httpWebResponse = (HttpWebResponse) webRequestObject2.GetResponse();
          }
          switch (httpWebResponse.StatusCode)
          {
            case HttpStatusCode.OK:
            case HttpStatusCode.Accepted:
              return httpWebResponse;
            case HttpStatusCode.MovedPermanently:
            case HttpStatusCode.Found:
              uri = new Uri(httpWebResponse.Headers["Location"]);
              --num1;
              break;
          }
        }
        catch (WebException ex)
        {
          throw ex;
        }
      }
      throw new Exception("Error: Either authentication failed, authorization failed or the resource doesn't exist");
    }

    private HttpWebRequest CreateHttpWebRequestObject(Uri uri, bool addAuthenticationHeader)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
      httpWebRequest.AllowAutoRedirect = true;
      httpWebRequest.PreAuthenticate = true;
      httpWebRequest.Method = this.Method;
      if (!string.IsNullOrEmpty(this.ContentType))
        httpWebRequest.ContentType = this.ContentType;
      if (addAuthenticationHeader)
        httpWebRequest.Headers.Add("Authorization", this.ComputeDigestHeader(uri));
      if (this.PostData != null && (uint) this.PostData.Length > 0U)
      {
        httpWebRequest.ContentLength = (long) this.PostData.Length;
        Stream requestStream = httpWebRequest.GetRequestStream();
        requestStream.Write(this.PostData, 0, this.PostData.Length);
        requestStream.Close();
      }
      else if (this.Method == "POST" && (this.PostData == null || this.PostData.Length == 0))
        httpWebRequest.ContentLength = 0L;
      return httpWebRequest;
    }

    private HttpWebRequest CreateHttpWebRequestObject(Uri uri)
    {
      return this.CreateHttpWebRequestObject(uri, false);
    }

    private string ComputeDigestHeader(Uri uri)
    {
      ++this._nc;
      string md5Hash = this.ComputeMd5Hash(string.Format("{0}:{1}:{2:00000000}:{3}:{4}:{5}", (object) this.ComputeMd5Hash(string.Format("{0}:{1}:{2}", (object) this._user, (object) this._realm, (object) this._password)), (object) this._nonce, (object) this._nc, (object) this._cnonce, (object) this._qop, (object) this.ComputeMd5Hash(string.Format("{0}:{1}", (object) this.Method, (object) uri.PathAndQuery))));
      return string.Format("Digest username=\"{0}\",realm=\"{1}\",nonce=\"{2}\",uri=\"{3}\",cnonce=\"{7}\",nc={6:00000000},qop={5},response=\"{4}\",opaque=\"{8}\"", (object) this._user, (object) this._realm, (object) this._nonce, (object) uri.PathAndQuery, (object) md5Hash, (object) this._qop, (object) this._nc, (object) this._cnonce, (object) this._opaque);
    }

    private string GetDigestHeaderAttribute(string attributeName, string digestAuthHeader)
    {
      Match match = new Regex(string.Format("{0}=\"([^\"]*)\"", (object) attributeName)).Match(digestAuthHeader);
      if (match.Success)
        return match.Groups[1].Value;
      throw new ApplicationException(string.Format("Header {0} not found", (object) attributeName));
    }

    private string ComputeMd5Hash(string input)
    {
      byte[] hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input));
      StringBuilder stringBuilder = new StringBuilder();
      foreach (byte num in hash)
        stringBuilder.Append(num.ToString("x2"));
      return stringBuilder.ToString();
    }
  }
}
