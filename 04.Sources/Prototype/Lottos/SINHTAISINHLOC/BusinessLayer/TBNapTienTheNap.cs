// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TBNapTienTheNap
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TBNapTienTheNap
  {
    private DataTable dtTable;
    private string sqlQuerry;
    private SqlCommand cmd;

    public bool Insert(string MaGiaoDich, string TenDangNhap, string NhaMang, string MaTheNap, string SeriTheNap, string MenhGia, string TrietKhau, string ThucNhan, string SoVangNhan)
    {
      this.sqlQuerry = "TBNapTienTheNap_Insert";
      bool flag;
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.cmd.Parameters.AddWithValue("@MaGiaoDich", (object) MaGiaoDich);
        this.cmd.Parameters.AddWithValue("@TenDangNhap", (object) TenDangNhap);
        this.cmd.Parameters.AddWithValue("@NhaMang", (object) NhaMang);
        this.cmd.Parameters.AddWithValue("@MaTheNap", (object) MaTheNap);
        this.cmd.Parameters.AddWithValue("@SeriTheNap", (object) SeriTheNap);
        this.cmd.Parameters.AddWithValue("@MenhGia", (object) MenhGia);
        this.cmd.Parameters.AddWithValue("@TrietKhau", (object) TrietKhau);
        this.cmd.Parameters.AddWithValue("@ThucNhan", (object) ThucNhan);
        this.cmd.Parameters.AddWithValue("@SoVangNhan", (object) SoVangNhan);
        DataWeb.db.ExecuteNonQuery(this.cmd);
        flag = true;
      }
      catch (Exception ex)
      {
        throw;
      }
      return flag;
    }
  }
}
