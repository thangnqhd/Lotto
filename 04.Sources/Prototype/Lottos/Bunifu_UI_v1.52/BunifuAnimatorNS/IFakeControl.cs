// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.IFakeControl
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace BunifuAnimatorNS
{
  public interface IFakeControl
  {
    Bitmap BgBmp { get; set; }

    Bitmap Frame { get; set; }

    event EventHandler<TransfromNeededEventArg> TransfromNeeded;

    event EventHandler<PaintEventArgs> FramePainting;

    event EventHandler<PaintEventArgs> FramePainted;

    void InitParent(Control animatedControl, Padding padding);
  }
}
