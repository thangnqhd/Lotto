// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbNgaysudung
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
  public class TbNgaysudung
  {
    public int stt;
    public string tenDangnhap;
    public string ngaySudung;
    public string cachSudung;
    public DateTime ngayChuyendoi;
    public DateTime ngayHethan;
    public DateTime ngayCapNhat;
    private DataTable dtTable;

    public TbNgaysudung()
    {
    }

    public TbNgaysudung(int stt, string tenDangnhap, string ngaySudung, string cachSudung, DateTime ngayChuyendoi, DateTime ngayHethan, DateTime ngayCapNhat)
    {
      this.stt = stt;
      this.tenDangnhap = tenDangnhap;
      this.ngaySudung = ngaySudung;
      this.cachSudung = cachSudung;
      this.ngayChuyendoi = ngayChuyendoi;
      this.ngayHethan = ngayHethan;
      this.ngayCapNhat = ngayCapNhat;
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
        if (value == null)
          throw new Exception("tenDangnhap not allow nullvalue.");
        this.tenDangnhap = value;
      }
    }

    public string NgaySudung
    {
      get
      {
        return this.ngaySudung;
      }
      set
      {
        if (value == null)
          throw new Exception("ngaySudung not allow nullvalue.");
        this.ngaySudung = value;
      }
    }

    public string CachSudung
    {
      get
      {
        return this.cachSudung;
      }
      set
      {
        if (value == null)
          throw new Exception("cachSudung not allow nullvalue.");
        this.cachSudung = value;
      }
    }

    public DateTime NgayChuyendoi
    {
      get
      {
        return this.ngayChuyendoi;
      }
      set
      {
        this.ngayChuyendoi = value;
      }
    }

    public DateTime NgayHethan
    {
      get
      {
        return this.ngayHethan;
      }
      set
      {
        this.ngayHethan = value;
      }
    }

    public DateTime NgayCapNhat
    {
      get
      {
        return this.ngayCapNhat;
      }
      set
      {
        this.ngayCapNhat = value;
      }
    }

    public int Insert(TbNgaysudung obj)
    {
      int num = 0;
      string cmdText = string.Format("tbNgaysudung_Insert N'{0}', N'{1}', N'{2}', N'{3}', N'{4}'", (object) obj.TenDangnhap, (object) obj.NgaySudung, (object) obj.CachSudung, (object) obj.NgayChuyendoi.ToString("yyyy-MM-dd hh:mm:ss"), (object) obj.NgayHethan.ToString("yyyy-MM-dd hh:mm:ss"));
      try
      {
        SqlCommand sqlCommand = new SqlCommand(cmdText);
        sqlCommand.CommandType = CommandType.Text;
        SqlCommand cmd = sqlCommand;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return num;
    }

    public TbNgaysudung TbNgaysudungGetTopNewByUsername(string TenDangnhap)
    {
      TbNgaysudung tbNgaysudung = new TbNgaysudung();
      this.dtTable = new DataTable();
      string sql = string.Format("tbNgaysudung_get_top_new_by_username N'{0}'", (object) TenDangnhap);
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            tbNgaysudung.stt = int.Parse(this.dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbNgaysudung.stt = 0;
          }
          tbNgaysudung.tenDangnhap = this.dtTable.Rows[0]["tenDangnhap"].ToString();
          tbNgaysudung.ngaySudung = this.dtTable.Rows[0]["ngaySudung"].ToString();
          tbNgaysudung.cachSudung = this.dtTable.Rows[0]["cachSudung"].ToString();
          try
          {
            tbNgaysudung.ngayChuyendoi = DateTime.Parse(this.dtTable.Rows[0]["ngayChuyendoi"].ToString());
          }
          catch (FormatException ex)
          {
          }
          try
          {
            tbNgaysudung.ngayHethan = DateTime.Parse(this.dtTable.Rows[0]["ngayHethan"].ToString());
          }
          catch (FormatException ex)
          {
          }
          try
          {
            tbNgaysudung.ngayCapNhat = DateTime.Parse(this.dtTable.Rows[0]["ngayCapNhat"].ToString());
          }
          catch (FormatException ex)
          {
          }
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return tbNgaysudung;
    }
  }
}
