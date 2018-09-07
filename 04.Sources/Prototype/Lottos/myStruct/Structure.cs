// Decompiled with JetBrains decompiler
// Type: myStruct.Structure
// Assembly: myStruct, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 28CAE858-B6BF-4108-B53C-7EBDCF38B7DA
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\myStruct.dll

using System;
using System.Runtime.Serialization;

namespace myStruct
{
  [Serializable]
  public class Structure : ISerializable
  {
    private string _timeSend;
    private string _userName;
    private string _textChat;
    private int _fontSize;
    private string _foreColor;
    private string _fontWeight;
    private string _font;
    private string _image;
    private string _sendTo;
    private string _sendType;
    private string _accountType;
    private string _logOutStatus;
    private string _versionClient;

    public string TimeSend
    {
      get
      {
        return this._timeSend;
      }
      set
      {
        this._timeSend = value;
      }
    }

    public string Username
    {
      get
      {
        return this._userName;
      }
      set
      {
        this._userName = value;
      }
    }

    public string TextChat
    {
      get
      {
        return this._textChat;
      }
      set
      {
        this._textChat = value;
      }
    }

    public int FontSize
    {
      get
      {
        return this._fontSize;
      }
      set
      {
        this._fontSize = value;
      }
    }

    public string ForColor
    {
      get
      {
        return this._foreColor;
      }
      set
      {
        this._foreColor = value;
      }
    }

    public string FontWeight
    {
      get
      {
        return this._fontWeight;
      }
      set
      {
        this._fontWeight = value;
      }
    }

    public string Font
    {
      get
      {
        return this._font;
      }
      set
      {
        this._font = value;
      }
    }

    public string Image
    {
      get
      {
        return this._image;
      }
      set
      {
        this._image = value;
      }
    }

    public string SendTo
    {
      get
      {
        return this._sendTo;
      }
      set
      {
        this._sendTo = value;
      }
    }

    public string SendType
    {
      get
      {
        return this._sendType;
      }
      set
      {
        this._sendType = value;
      }
    }

    public string AccountType
    {
      get
      {
        return this._accountType;
      }
      set
      {
        this._accountType = value;
      }
    }

    public string LogOutStatus
    {
      get
      {
        return this._logOutStatus;
      }
      set
      {
        this._logOutStatus = value;
      }
    }

    public string VersionClient
    {
      get
      {
        return this._versionClient;
      }
      set
      {
        this._versionClient = value;
      }
    }

    public Structure()
    {
      this.TimeSend = "";
      this.Username = (string) null;
      this.TextChat = (string) null;
      this.Font = "Arial";
      this.ForColor = "Black";
      this.FontSize = 9;
      this.FontWeight = "Regular";
      this.SendTo = (string) null;
      this.SendType = (string) null;
      this.AccountType = (string) null;
      this.Image = "";
      this.LogOutStatus = "";
      this.VersionClient = "1.0.0.1";
    }

    public Structure(string timeSend, string userName, string textChat, string font, string forceColor, int fontSize, string fontWeight, string sendTo, string sendType, string accountType, string image, string logoutstatus, string versionClient)
    {
      this.TimeSend = timeSend;
      this.Username = userName;
      this.TextChat = textChat;
      this.Font = font;
      this.ForColor = forceColor;
      this.FontSize = fontSize;
      this.FontWeight = fontWeight;
      this.SendTo = sendTo;
      this.SendType = sendType;
      this.AccountType = accountType;
      this.Image = image;
      this.LogOutStatus = logoutstatus;
      this.VersionClient = versionClient;
    }

    public Structure(Structure structure)
    {
      this.TimeSend = structure.TimeSend;
      this.Username = structure.Username;
      this.TextChat = structure.TextChat;
      this.Font = structure.Font;
      this.ForColor = structure.ForColor;
      this.FontSize = structure.FontSize;
      this.FontWeight = structure.FontWeight;
      this.SendTo = structure.SendTo;
      this.SendType = structure.SendType;
      this.AccountType = structure.AccountType;
      this.Image = structure.Image;
      this.LogOutStatus = structure.LogOutStatus;
      this.VersionClient = structure.VersionClient;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("timeSend", (object) this.TimeSend);
      info.AddValue("userName", (object) this.Username);
      info.AddValue("textChat", (object) this.TextChat);
      info.AddValue("font", (object) this.Font);
      info.AddValue("forColor", (object) this.ForColor);
      info.AddValue("fontSize", this.FontSize);
      info.AddValue("fontWeight", (object) this.FontWeight);
      info.AddValue("sendTo", (object) this.SendTo);
      info.AddValue("sendType", (object) this.SendType);
      info.AddValue("accountType", (object) this.AccountType);
      info.AddValue("image", (object) this.Image);
      info.AddValue("logOutStatus", (object) this.LogOutStatus);
      info.AddValue("versionClient", (object) this.VersionClient);
    }

    public Structure(SerializationInfo info, StreamingContext context)
    {
      this.TimeSend = (string) info.GetValue("timeSend", typeof (string));
      this.Username = (string) info.GetValue("userName", typeof (string));
      this.TextChat = (string) info.GetValue("textChat", typeof (string));
      this.Font = (string) info.GetValue("font", typeof (string));
      this.ForColor = (string) info.GetValue("forColor", typeof (string));
      this.FontSize = (int) info.GetValue("fontSize", typeof (int));
      this.FontWeight = (string) info.GetValue("fontWeight", typeof (string));
      this.SendTo = (string) info.GetValue("sendTo", typeof (string));
      this.SendType = (string) info.GetValue("sendType", typeof (string));
      this.AccountType = (string) info.GetValue("accountType", typeof (string));
      this.Image = (string) info.GetValue("image", typeof (string));
      this.LogOutStatus = (string) info.GetValue("logOutStatus", typeof (string));
      this.VersionClient = (string) info.GetValue("versionClient", typeof (string));
    }
  }
}
