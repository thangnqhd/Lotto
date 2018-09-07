// Decompiled with JetBrains decompiler
// Type: IWshRuntimeLibrary.IWshCollection
// Assembly: SINH TAI SINH LOC, Version=2.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: 604FDB85-ADA0-4F31-900F-9755444F7FBB
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINH TAI SINH LOC.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IWshRuntimeLibrary
{
  [CompilerGenerated]
  [Guid("F935DC27-1CF0-11D0-ADB9-00C04FD58A0B")]
  [TypeIdentifier]
  [ComImport]
  public interface IWshCollection : IEnumerable
  {
    [DispId(0)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Struct)]
    object Item([MarshalAs(UnmanagedType.Struct), In] ref object Index);
  }
}
