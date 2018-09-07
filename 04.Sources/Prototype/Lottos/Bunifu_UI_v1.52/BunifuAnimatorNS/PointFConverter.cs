// Decompiled with JetBrains decompiler
// Type: BunifuAnimatorNS.PointFConverter
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace BunifuAnimatorNS
{
  [DebuggerStepThrough]
  public class PointFConverter : ExpandableObjectConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (!(value is string))
        return base.ConvertFrom(context, culture, value);
      try
      {
        string[] strArray = ((string) value).Split(',');
        float x;
        float y;
        if (strArray.Length > 1)
        {
          x = float.Parse(strArray[0].Trim().Trim('{', 'X', 'x', '='));
          y = float.Parse(strArray[1].Trim().Trim('}', 'Y', 'y', '='));
        }
        else if (strArray.Length == 1)
        {
          x = float.Parse(strArray[0].Trim());
          y = 0.0f;
        }
        else
        {
          x = 0.0f;
          y = 0.0f;
        }
        return (object) new PointF(x, y);
      }
      catch
      {
        throw new ArgumentException("Cannot convert [" + value.ToString() + "] to pointF");
      }
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (!(destinationType == typeof (string)) || !(value.GetType() == typeof (PointF)))
        return base.ConvertTo(context, culture, value, destinationType);
      PointF pointF = (PointF) value;
      return (object) string.Format("{{X={0}, Y={1}}}", (object) pointF.X, (object) pointF.Y);
    }
  }
}
