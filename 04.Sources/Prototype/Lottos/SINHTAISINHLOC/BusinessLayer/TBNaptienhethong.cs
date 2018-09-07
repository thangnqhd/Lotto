// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TBNaptienhethong
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TBNaptienhethong
  {
    private DataTable dtTable;
    private SqlCommand cmd;
    private string sqlQuerry;

    public int Demsolannaptien(string usename)
    {
      this.sqlQuerry = "TBNapTienHeThong_Get_SoLanNap_TongSoTien_TongSoVang_By_Username";
      int num = 0;
      this.dtTable = new DataTable();
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.cmd.Parameters.AddWithValue("@username", (object) usename);
        this.dtTable = DataWeb.db.GetData(this.cmd);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            num = this.dtTable.Rows.Count;
          }
          catch (Exception ex)
          {
            throw;
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
      return num;
    }

    public bool NapTienHeThong(string SoTaiKhoanNap, string Taikhoannhan, string Sotiennap, string Sovangnhanduoc, string Nguoixacnhan, string Tinhvaotong)
    {
      this.sqlQuerry = "TBNapTienHeThong_Insert";
      bool flag;
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.cmd.Parameters.AddWithValue("@SoTaiKhoanNap", (object) SoTaiKhoanNap);
        this.cmd.Parameters.AddWithValue("@Taikhoannhan", (object) Taikhoannhan);
        this.cmd.Parameters.AddWithValue("@Sotiennap", (object) Sotiennap);
        this.cmd.Parameters.AddWithValue("@Sovangnhanduoc", (object) Sovangnhanduoc);
        this.cmd.Parameters.AddWithValue("@Nguoixacnhan", (object) Nguoixacnhan);
        this.cmd.Parameters.AddWithValue("@Tinhvaotong", (object) Tinhvaotong);
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
