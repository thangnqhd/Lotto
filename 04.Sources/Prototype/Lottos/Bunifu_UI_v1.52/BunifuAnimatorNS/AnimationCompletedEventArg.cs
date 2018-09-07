// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.AnimationCompletedEventArg
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Windows.Forms;

namespace BunifuAnimatorNS
{
  public class AnimationCompletedEventArg : EventArgs
  {
    public Animation Animation { get; set; }

    public Control Control { get; internal set; }

    public AnimateMode Mode { get; internal set; }
  }
}
