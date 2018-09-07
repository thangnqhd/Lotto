// Decompiled with JetBrains decompiler
// Type: ns0.Class11
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using BunifuAnimatorNS;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ns0
{
  [DebuggerStepThrough]
  internal static class Class11
  {
    private static Random random_0 = new Random();
    private const int int_0 = 4;

    public static void smethod_0(TransfromNeededEventArg transfromNeededEventArg_0, Animation animation_0)
    {
      Rectangle clientRectangle = transfromNeededEventArg_0.ClientRectangle;
      PointF pointF = new PointF((float) (clientRectangle.Left + clientRectangle.Width / 2), (float) (clientRectangle.Top + clientRectangle.Height / 2));
      transfromNeededEventArg_0.Matrix.Translate(pointF.X, pointF.Y);
      float scaleX = (float) (1.0 - (double) animation_0.ScaleCoeff.X * (double) transfromNeededEventArg_0.CurrentTime);
      float scaleY = (float) (1.0 - (double) animation_0.ScaleCoeff.X * (double) transfromNeededEventArg_0.CurrentTime);
      if ((double) Math.Abs(scaleX) <= 1.0 / 1000.0)
        scaleX = 1f / 1000f;
      if ((double) Math.Abs(scaleY) <= 1.0 / 1000.0)
        scaleY = 1f / 1000f;
      transfromNeededEventArg_0.Matrix.Scale(scaleX, scaleY);
      transfromNeededEventArg_0.Matrix.Translate(-pointF.X, -pointF.Y);
    }

    public static void smethod_1(TransfromNeededEventArg transfromNeededEventArg_0, Animation animation_0)
    {
      float currentTime = transfromNeededEventArg_0.CurrentTime;
      Matrix matrix = transfromNeededEventArg_0.Matrix;
      Rectangle clientRectangle = transfromNeededEventArg_0.ClientRectangle;
      double num1 = (double) -clientRectangle.Width * (double) currentTime * (double) animation_0.SlideCoeff.X;
      clientRectangle = transfromNeededEventArg_0.ClientRectangle;
      double num2 = (double) -clientRectangle.Height * (double) currentTime * (double) animation_0.SlideCoeff.Y;
      matrix.Translate((float) num1, (float) num2);
    }

    public static void smethod_2(NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg_0, Animation animation_0)
    {
      if (animation_0.BlindCoeff == PointF.Empty)
        return;
      byte[] pixels = nonLinearTransfromNeededEventArg_0.Pixels;
      int width = nonLinearTransfromNeededEventArg_0.ClientRectangle.Width;
      int height = nonLinearTransfromNeededEventArg_0.ClientRectangle.Height;
      int stride = nonLinearTransfromNeededEventArg_0.Stride;
      float x = animation_0.BlindCoeff.X;
      float y = animation_0.BlindCoeff.Y;
      int num1 = (int) (((double) width * (double) x + (double) height * (double) y) * (1.0 - (double) nonLinearTransfromNeededEventArg_0.CurrentTime));
      for (int index1 = 0; index1 < width; ++index1)
      {
        for (int index2 = 0; index2 < height; ++index2)
        {
          int num2 = index2 * stride + index1 * 4;
          if ((double) index1 * (double) x + (double) index2 * (double) y - (double) num1 >= 0.0)
            pixels[num2 + 3] = (byte) 0;
        }
      }
    }

    public static void smethod_3(NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg_0, Animation animation_0, ref Point[] point_0, ref byte[] byte_0)
    {
      if (animation_0.MosaicCoeff == PointF.Empty || animation_0.MosaicSize == 0)
        return;
      byte[] pixels = nonLinearTransfromNeededEventArg_0.Pixels;
      int width = nonLinearTransfromNeededEventArg_0.ClientRectangle.Width;
      int height = nonLinearTransfromNeededEventArg_0.ClientRectangle.Height;
      int stride = nonLinearTransfromNeededEventArg_0.Stride;
      float currentTime = nonLinearTransfromNeededEventArg_0.CurrentTime;
      int length = pixels.Length;
      float num1 = 1f - nonLinearTransfromNeededEventArg_0.CurrentTime;
      if ((double) num1 < 0.0)
        num1 = 0.0f;
      if ((double) num1 > 1.0)
        num1 = 1f;
      float x1 = animation_0.MosaicCoeff.X;
      float y1 = animation_0.MosaicCoeff.Y;
      if (point_0 == null)
      {
        point_0 = new Point[pixels.Length];
        for (int index = 0; index < pixels.Length; ++index)
          point_0[index] = new Point((int) ((double) x1 * (Class11.random_0.NextDouble() - 0.5)), (int) ((double) y1 * (Class11.random_0.NextDouble() - 0.5)));
      }
      if (byte_0 == null)
        byte_0 = (byte[]) pixels.Clone();
      int index1 = 0;
      while (index1 < length)
      {
        pixels[index1] = byte.MaxValue;
        pixels[index1 + 1] = byte.MaxValue;
        pixels[index1 + 2] = byte.MaxValue;
        pixels[index1 + 3] = (byte) 0;
        index1 += 4;
      }
      int mosaicSize = animation_0.MosaicSize;
      float x2 = animation_0.MosaicShift.X;
      float y2 = animation_0.MosaicShift.Y;
      for (int index2 = 0; index2 < height; ++index2)
      {
        for (int index3 = 0; index3 < width; ++index3)
        {
          int num2 = index2 / mosaicSize;
          int num3 = index3 / mosaicSize;
          int index4 = index2 * stride + index3 * 4;
          int index5 = num2 * stride + num3 * 4;
          int num4 = index3 + (int) ((double) currentTime * ((double) point_0[index5].X + (double) num3 * (double) x2));
          int num5 = index2 + (int) ((double) currentTime * ((double) point_0[index5].Y + (double) num2 * (double) y2));
          if (num4 >= 0 && num4 < width && (num5 >= 0 && num5 < height))
          {
            int index6 = num5 * stride + num4 * 4;
            pixels[index6] = byte_0[index4];
            pixels[index6 + 1] = byte_0[index4 + 1];
            pixels[index6 + 2] = byte_0[index4 + 2];
            pixels[index6 + 3] = (byte) ((double) byte_0[index4 + 3] * (double) num1);
          }
        }
      }
    }

    public static void smethod_4(NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg_0, Animation animation_0)
    {
      if ((double) animation_0.LeafCoeff == 0.0)
        return;
      byte[] pixels = nonLinearTransfromNeededEventArg_0.Pixels;
      int width = nonLinearTransfromNeededEventArg_0.ClientRectangle.Width;
      int height = nonLinearTransfromNeededEventArg_0.ClientRectangle.Height;
      int stride = nonLinearTransfromNeededEventArg_0.Stride;
      int num1 = (int) ((double) (width + height) * (1.0 - (double) nonLinearTransfromNeededEventArg_0.CurrentTime * (double) nonLinearTransfromNeededEventArg_0.CurrentTime));
      int length = pixels.Length;
      for (int index1 = 0; index1 < width; ++index1)
      {
        for (int index2 = 0; index2 < height; ++index2)
        {
          int index3 = index2 * stride + index1 * 4;
          if (index1 + index2 >= num1)
          {
            int num2 = num1 - index2;
            int num3 = num1 - index1;
            int num4 = num1 - index1 - index2;
            if (num4 < -20)
              num4 = -20;
            int index4 = num3 * stride + num2 * 4;
            if (num2 >= 0 && num3 >= 0 && (index4 >= 0 && index4 < length) && pixels[index3 + 3] > (byte) 0)
            {
              pixels[index4] = (byte) Math.Min((int) byte.MaxValue, num4 + 250 + (int) pixels[index3] / 10);
              pixels[index4 + 1] = (byte) Math.Min((int) byte.MaxValue, num4 + 250 + (int) pixels[index3 + 1] / 10);
              pixels[index4 + 2] = (byte) Math.Min((int) byte.MaxValue, num4 + 250 + (int) pixels[index3 + 2] / 10);
              pixels[index4 + 3] = (byte) 230;
            }
            pixels[index3 + 3] = (byte) 0;
          }
        }
      }
    }

    public static void smethod_5(NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg_0, Animation animation_0)
    {
      if ((double) animation_0.TransparencyCoeff == 0.0)
        return;
      float num1 = (float) (1.0 - (double) animation_0.TransparencyCoeff * (double) nonLinearTransfromNeededEventArg_0.CurrentTime);
      if ((double) num1 < 0.0)
        num1 = 0.0f;
      if ((double) num1 > 1.0)
        num1 = 1f;
      byte[] pixels = nonLinearTransfromNeededEventArg_0.Pixels;
      int num2 = 0;
      while (num2 < pixels.Length)
      {
        pixels[num2 + 3] = (byte) ((double) pixels[num2 + 3] * (double) num1);
        num2 += 4;
      }
    }

    public static void smethod_6(Bitmap bitmap_0, Bitmap bitmap_1)
    {
      Rectangle rect = new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height);
      BitmapData bitmapdata1 = bitmap_0.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      IntPtr scan0_1 = bitmapdata1.Scan0;
      BitmapData bitmapdata2 = bitmap_1.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      IntPtr scan0_2 = bitmapdata2.Scan0;
      int length1 = bitmap_0.Width * bitmap_0.Height * 4;
      byte[] numArray1 = new byte[length1];
      byte[] numArray2 = new byte[length1];
      Marshal.Copy(scan0_1, numArray1, 0, length1);
      byte[] destination = numArray2;
      int startIndex = 0;
      int length2 = length1;
      Marshal.Copy(scan0_2, destination, startIndex, length2);
      int index = 0;
      while (index < length1)
      {
        if ((int) numArray1[index] == (int) numArray2[index] && (int) numArray1[index + 1] == (int) numArray2[index + 1] && (int) numArray1[index + 2] == (int) numArray2[index + 2])
        {
          numArray1[index] = byte.MaxValue;
          numArray1[index + 1] = byte.MaxValue;
          numArray1[index + 2] = byte.MaxValue;
          numArray1[index + 3] = (byte) 0;
        }
        index += 4;
      }
      Marshal.Copy(numArray1, 0, scan0_1, length1);
      bitmap_0.UnlockBits(bitmapdata1);
      bitmap_1.UnlockBits(bitmapdata2);
    }

    public static void smethod_7(TransfromNeededEventArg transfromNeededEventArg_0, Animation animation_0)
    {
      Rectangle clientRectangle = transfromNeededEventArg_0.ClientRectangle;
      PointF pointF = new PointF((float) (clientRectangle.Left + clientRectangle.Width / 2), (float) (clientRectangle.Top + clientRectangle.Height / 2));
      transfromNeededEventArg_0.Matrix.Translate(pointF.X, pointF.Y);
      if ((double) transfromNeededEventArg_0.CurrentTime > (double) animation_0.RotateLimit)
        transfromNeededEventArg_0.Matrix.Rotate((float) (360.0 * ((double) transfromNeededEventArg_0.CurrentTime - (double) animation_0.RotateLimit)) * animation_0.RotateCoeff);
      transfromNeededEventArg_0.Matrix.Translate(-pointF.X, -pointF.Y);
    }

    public static void smethod_8(NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg_0)
    {
      byte[] sourcePixels = nonLinearTransfromNeededEventArg_0.SourcePixels;
      byte[] pixels = nonLinearTransfromNeededEventArg_0.Pixels;
      int stride = nonLinearTransfromNeededEventArg_0.Stride;
      int num1 = 1;
      int num2 = nonLinearTransfromNeededEventArg_0.SourceClientRectangle.Bottom + 1;
      int height = nonLinearTransfromNeededEventArg_0.ClientRectangle.Height;
      Rectangle sourceClientRectangle = nonLinearTransfromNeededEventArg_0.SourceClientRectangle;
      int left = sourceClientRectangle.Left;
      sourceClientRectangle = nonLinearTransfromNeededEventArg_0.SourceClientRectangle;
      int right = sourceClientRectangle.Right;
      int num3 = height - num2;
      for (int index1 = left; index1 < right; ++index1)
      {
        for (int index2 = num2; index2 < height; ++index2)
        {
          int num4 = num2 - 1 - num1 - (index2 - num2);
          if (num4 >= 0)
          {
            int num5 = index1;
            int index3 = num4 * stride + num5 * 4;
            int index4 = index2 * stride + index1 * 4;
            pixels[index4] = sourcePixels[index3];
            pixels[index4 + 1] = sourcePixels[index3 + 1];
            pixels[index4 + 2] = sourcePixels[index3 + 2];
            pixels[index4 + 3] = (byte) ((1.0 - 1.0 * (double) (index2 - num2) / (double) num3) * 90.0);
          }
          else
            break;
        }
      }
    }

    public static void smethod_9(NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg_0, int int_1)
    {
      byte[] pixels = nonLinearTransfromNeededEventArg_0.Pixels;
      byte[] sourcePixels = nonLinearTransfromNeededEventArg_0.SourcePixels;
      int stride = nonLinearTransfromNeededEventArg_0.Stride;
      int height = nonLinearTransfromNeededEventArg_0.ClientRectangle.Height;
      int width = nonLinearTransfromNeededEventArg_0.ClientRectangle.Width;
      int num1 = sourcePixels.Length - 4;
      for (int index1 = int_1; index1 < width - int_1; ++index1)
      {
        for (int index2 = int_1; index2 < height - int_1; ++index2)
        {
          int index3 = index2 * stride + index1 * 4;
          int num2 = 0;
          int num3 = 0;
          int num4 = 0;
          int num5 = 0;
          int num6 = 0;
          for (int index4 = index1 - int_1; index4 < index1 + int_1; ++index4)
          {
            for (int index5 = index2 - int_1; index5 < index2 + int_1; ++index5)
            {
              int index6 = index5 * stride + index4 * 4;
              if (index6 >= 0 && index6 < num1 && sourcePixels[index6 + 3] > (byte) 0)
              {
                num4 += (int) sourcePixels[index6];
                num3 += (int) sourcePixels[index6 + 1];
                num2 += (int) sourcePixels[index6 + 2];
                num5 += (int) sourcePixels[index6 + 3];
                ++num6;
              }
            }
          }
          if (index3 < num1 && num6 > 5)
          {
            pixels[index3] = (byte) (num4 / num6);
            pixels[index3 + 1] = (byte) (num3 / num6);
            pixels[index3 + 2] = (byte) (num2 / num6);
            pixels[index3 + 3] = (byte) (num5 / num6);
          }
        }
      }
    }
  }
}
