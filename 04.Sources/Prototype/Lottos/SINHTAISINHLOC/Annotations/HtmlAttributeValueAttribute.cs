// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.Annotations.HtmlAttributeValueAttribute
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;

namespace Thống_kê_xổ_số.Annotations
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited = true)]
  public sealed class HtmlAttributeValueAttribute : Attribute
  {
    public HtmlAttributeValueAttribute([NotNull] string name)
    {
      this.Name = name;
    }

    [NotNull]
    public string Name { get; private set; }
  }
}
