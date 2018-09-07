// Decompiled with JetBrains decompiler
// Type: ns0.Class7
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace ns0
{
  [DebuggerStepThrough]
  internal class Class7
  {
    public static Image smethod_0(Image image_0, Color color_0, Color color_1)
    {
      Bitmap bitmap = new Bitmap(image_0);
      for (int y = 0; y < bitmap.Height; ++y)
      {
        for (int x = 0; x < bitmap.Width; ++x)
        {
          if (!Class7.smethod_4(bitmap.GetPixel(x, y)))
            bitmap.SetPixel(x, y, color_1);
        }
      }
      return (Image) bitmap;
    }

    public static Image smethod_1(Image image_0, Color color_0)
    {
      Bitmap bitmap = new Bitmap(image_0);
      for (int y = 0; y < bitmap.Height; ++y)
      {
        for (int x = 0; x < bitmap.Width; ++x)
        {
          if (!Class7.smethod_4(bitmap.GetPixel(x, y)))
            bitmap.SetPixel(x, y, color_0);
        }
      }
      return (Image) bitmap;
    }

    public static Image smethod_2(Image image_0)
    {
      Bitmap bitmap = new Bitmap(image_0);
      List<int[]> numArrayList = new List<int[]>();
      for (int y = 0; y < bitmap.Height - 1; ++y)
      {
        for (int x = 0; x < bitmap.Width - 1; ++x)
        {
          Color[] colorArray = new Color[4];
          colorArray[0] = bitmap.GetPixel(x, y);
          colorArray[2] = bitmap.GetPixel(x, y + 1);
          colorArray[1] = bitmap.GetPixel(x + 1, y);
          colorArray[3] = bitmap.GetPixel(x + 1, y + 1);
          if (colorArray[1] == colorArray[2] && !Class7.smethod_4(colorArray[1]) && Class7.smethod_4(colorArray[0]))
            numArrayList.Add(new int[2]{ x, y });
          if (colorArray[0] == colorArray[3] && !Class7.smethod_4(colorArray[0]) && Class7.smethod_4(colorArray[2]))
            numArrayList.Add(new int[2]{ x, y + 1 });
          if (colorArray[0] == colorArray[3] && !Class7.smethod_4(colorArray[0]) && Class7.smethod_4(colorArray[1]))
            numArrayList.Add(new int[2]{ x + 1, y });
          if (colorArray[1] == colorArray[2] && !Class7.smethod_4(colorArray[1]) && Class7.smethod_4(colorArray[3]))
            numArrayList.Add(new int[2]{ x + 1, y + 1 });
        }
      }
      for (int index = 0; index < numArrayList.Count; ++index)
        bitmap.SetPixel(numArrayList[index][0], numArrayList[index][1], Class7.smethod_3(Color.Yellow, Color.FromArgb(211, 211, 211)));
      return (Image) bitmap;
    }

    public static Color smethod_3(Color color_0, Color color_1)
    {
      return Color.FromArgb(((int) color_0.R + (int) color_1.R) / 2, ((int) color_0.G + (int) color_1.G) / 2, ((int) color_0.B + (int) color_1.B) / 2);
    }

    private static bool smethod_4(Color color_0)
    {
      if (color_0.R == (byte) 0 && color_0.G == (byte) 0)
        return color_0.B == (byte) 0;
      return false;
    }

    public static Color smethod_5(int int_0, Color color_0, Color color_1)
    {
      return Color.FromArgb((int) byte.MaxValue, int.Parse(Math.Round((double) color_0.R + (double) (((int) color_1.R - (int) color_0.R) * int_0) * 0.01, 0).ToString()), int.Parse(Math.Round((double) color_0.G + (double) (((int) color_1.G - (int) color_0.G) * int_0) * 0.01, 0).ToString()), int.Parse(Math.Round((double) color_0.B + (double) (((int) color_1.B - (int) color_0.B) * int_0) * 0.01, 0).ToString()));
    }
  }
}
