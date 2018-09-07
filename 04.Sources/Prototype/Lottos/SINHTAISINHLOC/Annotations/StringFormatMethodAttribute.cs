// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.Annotations.StringFormatMethodAttribute
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;

namespace Thống_kê_xổ_số.Annotations
{
  [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
  public sealed class StringFormatMethodAttribute : Attribute
  {
    public StringFormatMethodAttribute(string formatParameterName)
    {
      this.FormatParameterName = formatParameterName;
    }

    public string FormatParameterName { get; private set; }
  }
}
