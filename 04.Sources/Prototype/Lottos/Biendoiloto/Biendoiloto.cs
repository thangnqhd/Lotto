// Decompiled with JetBrains decompiler
// Type: Biendoiloto
// Assembly: Biendoiloto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C3A9300D-0164-43F9-9E17-95EF9D83FC16
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Biendoiloto.dll

using System;

public class Biendoiloto
{
  public static string caploto;
  public static string[] loto;

  public static string BiendoiBongduong1Vitri(string dauso)
  {
    string str;
    switch (dauso)
    {
      case "0":
        str = "5";
        break;
      case "1":
        str = "6";
        break;
      case "2":
        str = "7";
        break;
      case "3":
        str = "8";
        break;
      case "4":
        str = "9";
        break;
      case "5":
        str = "0";
        break;
      case "6":
        str = "1";
        break;
      case "7":
        str = "2";
        break;
      case "8":
        str = "3";
        break;
      case "9":
        str = "4";
        break;
      default:
        str = dauso;
        break;
    }
    return str;
  }

  public static string BiendoiBongAm1Vitri(string dauso)
  {
    string str;
    switch (dauso)
    {
      case "0":
        str = "7";
        break;
      case "1":
        str = "4";
        break;
      case "2":
        str = "9";
        break;
      case "3":
        str = "6";
        break;
      case "4":
        str = "1";
        break;
      case "5":
        str = "8";
        break;
      case "6":
        str = "3";
        break;
      case "7":
        str = "0";
        break;
      case "8":
        str = "5";
        break;
      case "9":
        str = "2";
        break;
      default:
        str = dauso;
        break;
    }
    return str;
  }

  public static string BiendoiTuongSinh1Vitri(string dauso)
  {
    string str;
    switch (dauso)
    {
      case "0":
        str = "8";
        break;
      case "1":
        str = "4";
        break;
      case "2":
        str = "5";
        break;
      case "3":
        str = "1";
        break;
      case "4":
        str = "2";
        break;
      case "5":
        str = "3";
        break;
      case "6":
        str = "9";
        break;
      case "7":
        str = "0";
        break;
      case "8":
        str = "6";
        break;
      case "9":
        str = "7";
        break;
      default:
        str = dauso;
        break;
    }
    return str;
  }

  public static string BiendoiTenNguHanh1Vitri(string dauso)
  {
    string str;
    switch (dauso)
    {
      case "0":
        str = "Mộc";
        break;
      case "1":
        str = "Thủy";
        break;
      case "2":
        str = "Kim";
        break;
      case "3":
        str = "Hỏa";
        break;
      case "4":
        str = "Thổ";
        break;
      case "5":
        str = "Mộc";
        break;
      case "6":
        str = "Thủy";
        break;
      case "7":
        str = "Kim";
        break;
      case "8":
        str = "Hỏa";
        break;
      case "9":
        str = "Thổ";
        break;
      default:
        str = dauso;
        break;
    }
    return str;
  }

  public static string Biendoilocap_BongDuong(string loto)
  {
    string str;
    switch (loto)
    {
      case "00":
        str = "55";
        break;
      case "11":
        str = "66";
        break;
      case "22":
        str = "77";
        break;
      case "33":
        str = "88";
        break;
      case "44":
        str = "99";
        break;
      case "55":
        str = "00";
        break;
      case "66":
        str = "11";
        break;
      case "77":
        str = "22";
        break;
      case "88":
        str = "33";
        break;
      case "99":
        str = "44";
        break;
      default:
        str = loto.Substring(1, 1) + loto.Substring(0, 1);
        break;
    }
    return str;
  }

  public static string XapXepLoCapTuBeLon(string _caploto)
  {
    Biendoiloto.caploto = _caploto;
    try
    {
      Biendoiloto.loto = _caploto.Split('-');
      if ((uint) Biendoiloto.loto.Length > 0U)
      {
        if (Convert.ToInt32(Biendoiloto.loto[0].ToString()) > Convert.ToInt32(Biendoiloto.loto[1].ToString()))
          Biendoiloto.caploto = Biendoiloto.loto[1].ToString() + "-" + Biendoiloto.loto[0].ToString();
        else if (Convert.ToInt32(Biendoiloto.loto[0].ToString()) < Convert.ToInt32(Biendoiloto.loto[1].ToString()))
          Biendoiloto.caploto = Biendoiloto.loto[0].ToString() + "-" + Biendoiloto.loto[1].ToString();
      }
    }
    catch (Exception ex)
    {
      Biendoiloto.caploto = _caploto;
    }
    return Biendoiloto.caploto;
  }
}
