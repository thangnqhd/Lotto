// Decompiled with JetBrains decompiler
// Type: ns0.Class5
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ns0
{
  [DebuggerStepThrough]
  internal static class Class5
  {
    private const int int_0 = 256;

    public static string smethod_0(string string_0, string string_1, string string_2 = "tu89geji340t89u2")
    {
      byte[] bytes1 = Encoding.UTF8.GetBytes(string_2);
      byte[] bytes2 = Encoding.UTF8.GetBytes(string_0);
      byte[] bytes3 = new PasswordDeriveBytes(string_1, (byte[]) null).GetBytes(32);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Mode = CipherMode.CBC;
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(bytes3, bytes1);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write);
      cryptoStream.Write(bytes2, 0, bytes2.Length);
      cryptoStream.FlushFinalBlock();
      byte[] array = memoryStream.ToArray();
      memoryStream.Close();
      cryptoStream.Close();
      return Convert.ToBase64String(array);
    }

    public static string smethod_1(string string_0, string string_1, string string_2 = "tu89geji340t89u2")
    {
      try
      {
        byte[] bytes1 = Encoding.ASCII.GetBytes(string_2);
        byte[] buffer = Convert.FromBase64String(string_0);
        byte[] bytes2 = new PasswordDeriveBytes(string_1, (byte[]) null).GetBytes(32);
        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        rijndaelManaged.Mode = CipherMode.CBC;
        ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes2, bytes1);
        MemoryStream memoryStream = new MemoryStream(buffer);
        CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] numArray = new byte[buffer.Length];
        int count = cryptoStream.Read(numArray, 0, numArray.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(numArray, 0, count);
      }
      catch (Exception ex)
      {
        return (string) null;
      }
    }
  }
}
