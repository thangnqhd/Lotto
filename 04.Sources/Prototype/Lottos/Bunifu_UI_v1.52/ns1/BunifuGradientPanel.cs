// Decompiled with JetBrains decompiler
// Type: ns1.BunifuGradientPanel
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns0;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  public class BunifuGradientPanel : Panel
  {
    private Color color_0 = Color.White;
    private Color color_1 = Color.White;
    private Color color_2 = Color.White;
    private Color color_3 = Color.White;
    private int int_0 = 10;
    private IContainer icontainer_0;

    public BunifuGradientPanel()
    {
      this.method_1();
      this.method_0();
    }

    public Color GradientTopLeft
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

    public Color GradientTopRight
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

    public Color GradientBottomLeft
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
        this.method_0();
      }
    }

    public Color GradientBottomRight
    {
      get
      {
        return this.color_3;
      }
      set
      {
        this.color_3 = value;
        this.method_0();
      }
    }

    public int Quality
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

    private void method_0()
    {
      Bitmap bitmap = new Bitmap(this.Quality, this.Quality);
      if (this.Quality == 100)
        bitmap = new Bitmap(this.Width, this.Height);
      for (int x = 0; x < bitmap.Width; ++x)
      {
        Color colorScale1 = BunifuColorTransition.getColorScale(int.Parse(Math.Round((double) x / (double) bitmap.Width * 100.0, 0).ToString()), this.GradientTopLeft, this.GradientTopRight);
        for (int y = 0; y < bitmap.Height; ++y)
        {
          Color colorScale2 = BunifuColorTransition.getColorScale(int.Parse(Math.Round((double) y / (double) bitmap.Height * 100.0, 0).ToString()), this.GradientBottomLeft, this.GradientBottomRight);
          bitmap.SetPixel(x, y, Class7.smethod_3(colorScale1, colorScale2));
        }
      }
      if (this.BackgroundImageLayout != ImageLayout.Stretch)
        this.BackgroundImageLayout = ImageLayout.Stretch;
      this.BackgroundImage = (Image) bitmap;
    }

    private void BunifuGradientPanel_Resize(object sender, EventArgs e)
    {
      this.method_0();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_1()
    {
      this.SuspendLayout();
      this.Resize += new EventHandler(this.BunifuGradientPanel_Resize);
      this.ResumeLayout(false);
    }
  }
}
