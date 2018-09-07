// Decompiled with JetBrains decompiler
// Type: ns1.BunifuWebClient
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System.ComponentModel;
using System.Net;

namespace ns1
{
  public class BunifuWebClient : WebClient
  {
    private IContainer icontainer_0;

    public BunifuWebClient()
    {
      this.method_0();
    }

    public BunifuWebClient(IContainer container)
    {
      container.Add((IComponent) this);
      this.method_0();
    }

    [Browsable(false)]
    public bool AllowWriteStreamBuffering
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    [Browsable(false)]
    public bool AllowReadStreamBuffering
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_0()
    {
      this.icontainer_0 = (IContainer) new Container();
    }
  }
}
