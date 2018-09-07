// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbGopy
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
  public class tbGopy
  {
    private int stt;
    private string tenDangnhap;
    private string chuyenMuc;
    private string noiDung;
    private DateTime ngayThem;
    public static tbGopy infoGopy;
    public DataTable dtTable;

    public tbGopy()
    {
    }

    public tbGopy(int stt, string tenDangnhap, string chuyenMuc, string noiDung, DateTime ngayThem)
    {
      this.stt = stt;
      this.tenDangnhap = tenDangnhap;
      this.chuyenMuc = chuyenMuc;
      this.noiDung = noiDung;
      this.ngayThem = ngayThem;
    }

    public int Stt
    {
      get
      {
        return this.stt;
      }
      set
      {
        this.stt = value;
      }
    }

    public string TenDangnhap
    {
      get
      {
        return this.tenDangnhap;
      }
      set
      {
        this.tenDangnhap = value;
      }
    }

    public string ChuyenMuc
    {
      get
      {
        return this.chuyenMuc;
      }
      set
      {
        this.chuyenMuc = value;
      }
    }

    public string NoiDung
    {
      get
      {
        return this.noiDung;
      }
      set
      {
        this.noiDung = value;
      }
    }

    public DateTime NgayThem
    {
      get
      {
        return this.ngayThem;
      }
      set
      {
        this.ngayThem = value;
      }
    }

    public int Insert(tbGopy obj)
    {
      int num = 0;
      string cmdText = string.Format("tbGopy_Insert N'{0}', N'{1}', N'{2}'", (object) obj.tenDangnhap, (object) obj.chuyenMuc, (object) obj.noiDung);
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        FLogin.MsgId = "016";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }
  }
}
