// Decompiled with JetBrains decompiler
// Type: ns1.BunifuColorTransition
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Drawing;

namespace ns1
{
  public class BunifuColorTransition : Component
  {
    private Color color_0 = Color.White;
    private Color color_1 = Color.White;
    private Color color_2 = Color.White;
    private int int_0;
    private IContainer icontainer_0;

    public BunifuColorTransition()
    {
      this.method_1();
    }

    public BunifuColorTransition(IContainer container)
    {
      container.Add((IComponent) this);
      this.method_1();
    }

    public int ProgessValue
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        this.method_0();
      }
    }

    public Color Value
    {
      get
      {
        return this.color_2;
      }
    }

    public Color Color1
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.method_0();
      }
    }

    public Color Color2
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
        this.method_0();
      }
    }

    private void method_0()
    {
      Color colorScale = BunifuColorTransition.getColorScale(this.ProgessValue, this.Color1, this.Color2);
      if (!(colorScale != this.Value))
        return;
      this.color_2 = colorScale;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }

    public event EventHandler OnValueChange;

    public static Color getColorScale(int Passentage, Color startColor, Color endColor)
    {
      try
      {
        return Color.FromArgb((int) byte.MaxValue, int.Parse(Math.Round((double) startColor.R + (double) (((int) endColor.R - (int) startColor.R) * Passentage) * 0.01, 0).ToString()), int.Parse(Math.Round((double) startColor.G + (double) (((int) endColor.G - (int) startColor.G) * Passentage) * 0.01, 0).ToString()), int.Parse(Math.Round((double) startColor.B + (double) (((int) endColor.B - (int) startColor.B) * Passentage) * 0.01, 0).ToString()));
      }
      catch (Exception ex)
      {
        return startColor;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_1()
    {
      this.icontainer_0 = (IContainer) new Container();
    }
  }
}
