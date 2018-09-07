// Decompiled with JetBrains decompiler
// Type: Extensions.XShortCut
// Assembly: SINH TAI SINH LOC, Version=2.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: 604FDB85-ADA0-4F31-900F-9755444F7FBB
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINH TAI SINH LOC.exe

using IWshRuntimeLibrary;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Extensions
{
  public static class XShortCut
  {
    public static string CreateShortCutInStartUpFolder(string exeName, string startIn, string description)
    {
      object Index = (object) "Desktop";
      // ISSUE: variable of a compiler-generated type
      WshShell instance = (WshShell) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
      // ISSUE: reference to a compiler-generated field
      if (XShortCut.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        XShortCut.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (XShortCut)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      string str1 = XShortCut.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) XShortCut.\u003C\u003Eo__0.\u003C\u003Ep__0, instance.SpecialFolders.Item(ref Index));
      string str2 = str1 + "\\" + exeName + "-Shortcut.lnk";
      string fullPathToTargetExe = Directory.GetCurrentDirectory() + "\\" + exeName;
      File.Delete(str2);
      XShortCut.Create(str2, fullPathToTargetExe, startIn, description);
      return str1;
    }

    public static void Create(string fullPathToLink, string fullPathToTargetExe, string startIn, string description)
    {
      // ISSUE: variable of a compiler-generated type
      WshShell instance = (WshShell) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
      // ISSUE: reference to a compiler-generated field
      if (XShortCut.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        XShortCut.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, IWshShortcut>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (IWshShortcut), typeof (XShortCut)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      IWshShortcut wshShortcut = XShortCut.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) XShortCut.\u003C\u003Eo__1.\u003C\u003Ep__0, instance.CreateShortcut(fullPathToLink));
      wshShortcut.IconLocation = fullPathToTargetExe;
      wshShortcut.TargetPath = fullPathToTargetExe;
      wshShortcut.Description = description;
      wshShortcut.WorkingDirectory = startIn;
      // ISSUE: reference to a compiler-generated method
      wshShortcut.Save();
    }

    public static string Encrypt(string strToEncrypt, string strKey)
    {
      try
      {
        TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
        byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(strKey));
        cryptoServiceProvider.Key = hash;
        cryptoServiceProvider.Mode = CipherMode.ECB;
        byte[] bytes = Encoding.Unicode.GetBytes(strToEncrypt);
        return Convert.ToBase64String(cryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
      }
      catch
      {
        return "587a8c1379f31fa657db229193abe78e";
      }
    }

    public static string Decrypt(string strEncrypted, string strKey)
    {
      try
      {
        TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
        byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(strKey));
        cryptoServiceProvider.Key = hash;
        cryptoServiceProvider.Mode = CipherMode.ECB;
        byte[] inputBuffer = Convert.FromBase64String(strEncrypted);
        return Encoding.Unicode.GetString(cryptoServiceProvider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
      }
      catch
      {
        return "587a8c1379f31fa657db229193abe78e";
      }
    }
  }
}
