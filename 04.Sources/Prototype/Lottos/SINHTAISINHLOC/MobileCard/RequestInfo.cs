// Decompiled with JetBrains decompiler
// Type: MobileCard.RequestInfo
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

namespace MobileCard
{
  public class RequestInfo
  {
    private string _Funtion = "CardCharge";
    private string _Version = "2.0";
    private string _Merchant_id = string.Empty;
    private string _Merchant_acount = string.Empty;
    private string _Merchant_password = string.Empty;
    private string _Pincard = string.Empty;
    private string _SerialCard = string.Empty;
    private string _CardType = string.Empty;
    private string _Refcode = string.Empty;
    private string _Client_fullname = string.Empty;
    private string _Client_email = string.Empty;
    private string _Client_mobile = string.Empty;

    public string Funtion
    {
      get
      {
        return this._Funtion;
      }
    }

    public string Version
    {
      get
      {
        return this._Version;
      }
    }

    public string Merchant_id
    {
      get
      {
        return this._Merchant_id;
      }
      set
      {
        this._Merchant_id = value;
      }
    }

    public string Merchant_acount
    {
      get
      {
        return this._Merchant_acount;
      }
      set
      {
        this._Merchant_acount = value;
      }
    }

    public string Merchant_password
    {
      get
      {
        return this._Merchant_password;
      }
      set
      {
        this._Merchant_password = value;
      }
    }

    public string Pincard
    {
      get
      {
        return this._Pincard;
      }
      set
      {
        this._Pincard = value;
      }
    }

    public string SerialCard
    {
      get
      {
        return this._SerialCard;
      }
      set
      {
        this._SerialCard = value;
      }
    }

    public string CardType
    {
      get
      {
        return this._CardType;
      }
      set
      {
        this._CardType = value;
      }
    }

    public string Refcode
    {
      get
      {
        return this._Refcode;
      }
      set
      {
        this._Refcode = value;
      }
    }

    public string Client_fullname
    {
      get
      {
        return this._Client_fullname;
      }
      set
      {
        this._Client_fullname = value;
      }
    }

    public string Client_email
    {
      get
      {
        return this._Client_email;
      }
      set
      {
        this._Client_email = value;
      }
    }

    public string Client_mobile
    {
      get
      {
        return this._Client_mobile;
      }
      set
      {
        this._Client_mobile = value;
      }
    }
  }
}
