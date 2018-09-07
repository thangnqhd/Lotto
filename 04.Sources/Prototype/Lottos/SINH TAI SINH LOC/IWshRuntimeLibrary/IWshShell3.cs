// Decompiled with JetBrains decompiler
// Type: IWshRuntimeLibrary.IWshShell3
// Assembly: SINH TAI SINH LOC, Version=2.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: 604FDB85-ADA0-4F31-900F-9755444F7FBB
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINH TAI SINH LOC.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IWshRuntimeLibrary
{
  [CompilerGenerated]
  [Guid("41904400-BE18-11D3-A28B-00104BD35090")]
  [TypeIdentifier]
  [ComImport]
  public interface IWshShell3 : IWshShell2
  {
    [DispId(100)]
    IWshCollection SpecialFolders { [DispId(100), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_3();

    [DispId(1002)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object CreateShortcut([MarshalAs(UnmanagedType.BStr), In] string PathLink);
  }
}
