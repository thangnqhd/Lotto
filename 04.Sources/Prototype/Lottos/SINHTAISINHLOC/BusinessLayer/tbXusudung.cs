// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbXusudung
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Data.SqlClient;
using Thống_kê_xổ_số.FormUI;

namespace Thống_kê_xổ_số.BusinessLayer
{
  internal class tbXusudung
  {
    public static int stt;
    public static string tenDangnhap;
    public static string xuSudung;
    public static string cachSudung;
    public static DateTime ngayThang;

    public tbXusudung()
    {
    }

    public tbXusudung(int stt, string tenDangnhap, string xuSudung, string cachSudung, DateTime ngayThang)
    {
      tbXusudung.stt = stt;
      tbXusudung.tenDangnhap = tenDangnhap;
      tbXusudung.xuSudung = xuSudung;
      tbXusudung.cachSudung = cachSudung;
      tbXusudung.ngayThang = ngayThang;
    }

    public int Stt
    {
      get
      {
        return tbXusudung.stt;
      }
      set
      {
        tbXusudung.stt = value;
      }
    }

    public string TenDangnhap
    {
      get
      {
        return tbXusudung.tenDangnhap;
      }
      set
      {
        if (value == null)
          throw new Exception("tenDangnhap not allow nullvalue.");
        tbXusudung.tenDangnhap = value;
      }
    }

    public string XuSudung
    {
      get
      {
        return tbXusudung.xuSudung;
      }
      set
      {
        tbXusudung.xuSudung = value;
      }
    }

    public string CachSudung
    {
      get
      {
        return tbXusudung.cachSudung;
      }
      set
      {
        tbXusudung.cachSudung = value;
      }
    }

    public DateTime NgayThang
    {
      get
      {
        return tbXusudung.ngayThang;
      }
      set
      {
        tbXusudung.ngayThang = value;
      }
    }

    public override string ToString()
    {
      return tbXusudung.stt.ToString() + "; " + tbXusudung.tenDangnhap + "; " + tbXusudung.xuSudung + "; " + tbXusudung.cachSudung + "; " + (object) tbXusudung.ngayThang + "; ";
    }

    public int Insert(tbXusudung obj)
    {
      int num = 0;
      string cmdText = string.Format("tbXusudung_Insert N'{0}', N'{1}', N'{2}'", (object) obj.TenDangnhap, (object) obj.XuSudung, (object) obj.CachSudung);
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }
  }
}
