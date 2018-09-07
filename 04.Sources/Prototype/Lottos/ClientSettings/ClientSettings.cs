// Decompiled with JetBrains decompiler
// Type: ClientSettings.ClientSettings
// Assembly: ClientSettings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0588CC96-5C3F-4B43-ADC3-42A854F6069E
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\ClientSettings.dll

using myStruct;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientSettings
{
  public class ClientSettings
  {
    public Socket _s;
    public bool _connected;
    private Structure structure;
    private MemoryStream stream;
    private BinaryFormatter binaryFormatter;
    private IAsyncResult result;

    public event ClientSettings.ReceivedEventHandler Received = (_param1, _param2) => {};

    public event EventHandler Connected = (_param1, _param2) => {};

    public event ClientSettings.DisconnectedEventHandler Disconnected = _param1 => {};

    public bool Connect(string ip, int port)
    {
      bool flag = false;
      try
      {
        this._s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        this.result = this._s.BeginConnect((EndPoint) new IPEndPoint(IPAddress.Parse(ip), port), new AsyncCallback(this.ConnectCallback), (object) this._s);
        this.result.AsyncWaitHandle.WaitOne();
        if (this.result.IsCompleted)
          flag = this._s.Connected;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    public void Close()
    {
      this._s.Dispose();
      this._s.Close();
    }

    private void ConnectCallback(IAsyncResult ar)
    {
      if (this._s.Connected)
      {
        this._s.EndConnect(ar);
        this._connected = true;
        // ISSUE: reference to a compiler-generated field
        this.Connected((object) this, EventArgs.Empty);
        byte[] buffer = new byte[this._s.ReceiveBufferSize];
        this._s.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.ReadCallback), (object) buffer);
      }
      else
        this._connected = false;
    }

    private void ReadCallback(IAsyncResult ar)
    {
      try
      {
        byte[] asyncState = (byte[]) ar.AsyncState;
        if ((uint) this._s.EndReceive(ar) > 0U)
        {
          this.stream = new MemoryStream(asyncState);
          this.binaryFormatter = new BinaryFormatter();
          this.structure = (Structure) this.binaryFormatter.Deserialize((Stream) this.stream);
          // ISSUE: reference to a compiler-generated field
          this.Received(this, this.structure);
          this._s.BeginReceive(asyncState, 0, asyncState.Length, SocketFlags.None, new AsyncCallback(this.ReadCallback), (object) asyncState);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          this.Disconnected(this);
          this._connected = false;
          this.Close();
        }
      }
      catch (Exception ex)
      {
        this._connected = false;
      }
    }

    public bool Send(Structure _structure)
    {
      bool flag = false;
      try
      {
        this.stream = new MemoryStream();
        this.binaryFormatter = new BinaryFormatter();
        this.binaryFormatter.Serialize((Stream) this.stream, (object) _structure);
        byte[] array = this.stream.ToArray();
        this.result = this._s.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), (object) array);
        if (this.result == null || !this.result.AsyncWaitHandle.WaitOne(6000, true))
          this._s.Close();
        else
          flag = true;
      }
      catch
      {
        // ISSUE: reference to a compiler-generated field
        this.Disconnected(this);
        flag = false;
      }
      return flag;
    }

    private void SendCallback(IAsyncResult ar)
    {
      this._s.EndSend(ar);
    }

    public delegate void ReceivedEventHandler(ClientSettings cs, Structure structure);

    public delegate void DisconnectedEventHandler(ClientSettings cs);
  }
}
