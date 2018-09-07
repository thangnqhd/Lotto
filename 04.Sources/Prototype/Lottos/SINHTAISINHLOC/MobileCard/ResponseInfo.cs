// Decompiled with JetBrains decompiler
// Type: MobileCard.ResponseInfo
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

namespace MobileCard
{
  public class ResponseInfo
  {
    private string _Errorcode = string.Empty;
    private string _TransactionID = string.Empty;
    private string _Message = string.Empty;
    private string _Card_amount = "0";
    private string _Transaction_amount = "0";
    private string _Refcode = string.Empty;

    public string Errorcode
    {
      get
      {
        return this._Errorcode;
      }
      set
      {
        this._Errorcode = value;
      }
    }

    public string TransactionID
    {
      get
      {
        return this._TransactionID;
      }
      set
      {
        this._TransactionID = value;
      }
    }

    public string Message
    {
      get
      {
        return this._Message;
      }
      set
      {
        this._Message = value;
      }
    }

    public string Card_amount
    {
      get
      {
        return this._Card_amount;
      }
      set
      {
        this._Card_amount = value;
      }
    }

    public string Transaction_amount
    {
      get
      {
        return this._Transaction_amount;
      }
      set
      {
        this._Transaction_amount = value;
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
  }
}
