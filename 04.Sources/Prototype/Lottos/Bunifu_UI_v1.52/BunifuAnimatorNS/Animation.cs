// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.Animation
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BunifuAnimatorNS
{
  [DebuggerStepThrough]
  public class Animation
  {
    public Animation()
    {
      this.MinTime = 0.0f;
      this.MaxTime = 1f;
      this.AnimateOnlyDifferences = true;
    }

    [TypeConverter(typeof (PointFConverter))]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public PointF SlideCoeff { get; set; }

    public float RotateCoeff { get; set; }

    public float RotateLimit { get; set; }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [TypeConverter(typeof (PointFConverter))]
    public PointF ScaleCoeff { get; set; }

    public float TransparencyCoeff { get; set; }

    public float LeafCoeff { get; set; }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [TypeConverter(typeof (PointFConverter))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public PointF MosaicShift { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [TypeConverter(typeof (PointFConverter))]
    public PointF MosaicCoeff { get; set; }

    public int MosaicSize { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [TypeConverter(typeof (PointFConverter))]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public PointF BlindCoeff { get; set; }

    public float TimeCoeff { get; set; }

    public float MinTime { get; set; }

    public float MaxTime { get; set; }

    public Padding Padding { get; set; }

    public bool AnimateOnlyDifferences { get; set; }

    public bool IsNonLinearTransformNeeded
    {
      get
      {
        return !(this.BlindCoeff == PointF.Empty) || !(this.MosaicCoeff == PointF.Empty) && this.MosaicSize != 0 || ((double) this.TransparencyCoeff != 0.0 || (double) this.LeafCoeff != 0.0);
      }
    }

    public Animation Clone()
    {
      return (Animation) this.MemberwiseClone();
    }

    public static Animation Rotate
    {
      get
      {
        return new Animation()
        {
          RotateCoeff = 1f,
          TransparencyCoeff = 1f,
          Padding = new Padding(50, 50, 50, 50)
        };
      }
    }

    public static Animation HorizSlide
    {
      get
      {
        return new Animation()
        {
          SlideCoeff = new PointF(1f, 0.0f)
        };
      }
    }

    public static Animation VertSlide
    {
      get
      {
        return new Animation()
        {
          SlideCoeff = new PointF(0.0f, 1f)
        };
      }
    }

    public static Animation Scale
    {
      get
      {
        return new Animation()
        {
          ScaleCoeff = new PointF(1f, 1f)
        };
      }
    }

    public static Animation ScaleAndRotate
    {
      get
      {
        return new Animation()
        {
          ScaleCoeff = new PointF(1f, 1f),
          RotateCoeff = 0.5f,
          RotateLimit = 0.2f,
          Padding = new Padding(30, 30, 30, 30)
        };
      }
    }

    public static Animation HorizSlideAndRotate
    {
      get
      {
        return new Animation()
        {
          SlideCoeff = new PointF(1f, 0.0f),
          RotateCoeff = 0.3f,
          RotateLimit = 0.2f,
          Padding = new Padding(50, 50, 50, 50)
        };
      }
    }

    public static Animation ScaleAndHorizSlide
    {
      get
      {
        return new Animation()
        {
          ScaleCoeff = new PointF(1f, 1f),
          SlideCoeff = new PointF(1f, 0.0f),
          Padding = new Padding(30, 0, 0, 0)
        };
      }
    }

    public static Animation Transparent
    {
      get
      {
        return new Animation() { TransparencyCoeff = 1f };
      }
    }

    public static Animation Leaf
    {
      get
      {
        return new Animation() { LeafCoeff = 1f };
      }
    }

    public static Animation Mosaic
    {
      get
      {
        return new Animation()
        {
          MosaicCoeff = new PointF(100f, 100f),
          MosaicSize = 20,
          Padding = new Padding(30, 30, 30, 30)
        };
      }
    }

    public static Animation Particles
    {
      get
      {
        return new Animation()
        {
          MosaicCoeff = new PointF(200f, 200f),
          MosaicSize = 1,
          MosaicShift = new PointF(0.0f, 0.5f),
          Padding = new Padding(100, 50, 100, 150),
          TimeCoeff = 2f
        };
      }
    }

    public static Animation VertBlind
    {
      get
      {
        return new Animation()
        {
          BlindCoeff = new PointF(0.0f, 1f)
        };
      }
    }

    public static Animation HorizBlind
    {
      get
      {
        return new Animation()
        {
          BlindCoeff = new PointF(1f, 0.0f)
        };
      }
    }

    public void Add(Animation a)
    {
      PointF slideCoeff = this.SlideCoeff;
      double x1 = (double) slideCoeff.X;
      slideCoeff = a.SlideCoeff;
      double x2 = (double) slideCoeff.X;
      double num1 = x1 + x2;
      slideCoeff = this.SlideCoeff;
      double y1 = (double) slideCoeff.Y;
      slideCoeff = a.SlideCoeff;
      double y2 = (double) slideCoeff.Y;
      double num2 = y1 + y2;
      this.SlideCoeff = new PointF((float) num1, (float) num2);
      this.RotateCoeff += a.RotateCoeff;
      this.RotateLimit += a.RotateLimit;
      PointF scaleCoeff = this.ScaleCoeff;
      double x3 = (double) scaleCoeff.X;
      scaleCoeff = a.ScaleCoeff;
      double x4 = (double) scaleCoeff.X;
      double num3 = x3 + x4;
      scaleCoeff = this.ScaleCoeff;
      double y3 = (double) scaleCoeff.Y;
      scaleCoeff = a.ScaleCoeff;
      double y4 = (double) scaleCoeff.Y;
      double num4 = y3 + y4;
      this.ScaleCoeff = new PointF((float) num3, (float) num4);
      this.TransparencyCoeff += a.TransparencyCoeff;
      this.LeafCoeff += a.LeafCoeff;
      PointF mosaicShift = this.MosaicShift;
      double x5 = (double) mosaicShift.X;
      mosaicShift = a.MosaicShift;
      double x6 = (double) mosaicShift.X;
      double num5 = x5 + x6;
      mosaicShift = this.MosaicShift;
      double y5 = (double) mosaicShift.Y;
      mosaicShift = a.MosaicShift;
      double y6 = (double) mosaicShift.Y;
      double num6 = y5 + y6;
      this.MosaicShift = new PointF((float) num5, (float) num6);
      PointF mosaicCoeff = this.MosaicCoeff;
      double x7 = (double) mosaicCoeff.X;
      mosaicCoeff = a.MosaicCoeff;
      double x8 = (double) mosaicCoeff.X;
      double num7 = x7 + x8;
      mosaicCoeff = this.MosaicCoeff;
      double y7 = (double) mosaicCoeff.Y;
      mosaicCoeff = a.MosaicCoeff;
      double y8 = (double) mosaicCoeff.Y;
      double num8 = y7 + y8;
      this.MosaicCoeff = new PointF((float) num7, (float) num8);
      this.MosaicSize += a.MosaicSize;
      PointF blindCoeff = this.BlindCoeff;
      double x9 = (double) blindCoeff.X;
      blindCoeff = a.BlindCoeff;
      double x10 = (double) blindCoeff.X;
      double num9 = x9 + x10;
      blindCoeff = this.BlindCoeff;
      double y9 = (double) blindCoeff.Y;
      blindCoeff = a.BlindCoeff;
      double y10 = (double) blindCoeff.Y;
      double num10 = y9 + y10;
      this.BlindCoeff = new PointF((float) num9, (float) num10);
      this.TimeCoeff += a.TimeCoeff;
      this.Padding += a.Padding;
    }
  }
}
