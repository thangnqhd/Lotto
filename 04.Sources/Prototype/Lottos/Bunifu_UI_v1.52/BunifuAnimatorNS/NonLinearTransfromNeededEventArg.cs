// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.NonLinearTransfromNeededEventArg
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace BunifuAnimatorNS
{
  public class NonLinearTransfromNeededEventArg : EventArgs
  {
    public float CurrentTime { get; internal set; }

    public Rectangle ClientRectangle { get; internal set; }

    public byte[] Pixels { get; internal set; }

    public int Stride { get; internal set; }

    public Rectangle SourceClientRectangle { get; internal set; }

    public byte[] SourcePixels { get; internal set; }

    public int SourceStride { get; set; }

    public Animation Animation { get; set; }

    public Control Control { get; internal set; }

    public AnimateMode Mode { get; internal set; }

    public bool UseDefaultTransform { get; set; }
  }
}
