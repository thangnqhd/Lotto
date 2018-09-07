// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.Annotations.PathReferenceAttribute
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;

namespace Thống_kê_xổ_số.Annotations
{
  [AttributeUsage(AttributeTargets.Parameter)]
  public class PathReferenceAttribute : Attribute
  {
    public PathReferenceAttribute()
    {
    }

    public PathReferenceAttribute([PathReference] string basePath)
    {
      this.BasePath = basePath;
    }

    [NotNull]
    public string BasePath { get; private set; }
  }
}
