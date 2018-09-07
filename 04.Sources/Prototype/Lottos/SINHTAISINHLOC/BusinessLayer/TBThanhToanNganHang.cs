// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TBThanhToanNganHang
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TBThanhToanNganHang
  {
    private DataTable dtTable;
    private string sqlQuerry;
    private SqlCommand cmd;

    public DataTable GetListBank()
    {
      this.dtTable = new DataTable();
      this.sqlQuerry = "TBThanhToanNganHang_Get_InfoThanhToan";
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.Text;
        this.dtTable = DataWeb.db.GetData(this.cmd);
      }
      catch (Exception ex)
      {
        throw;
      }
      return this.dtTable;
    }

    public DataTable GetListVang_NgaySuDung()
    {
      this.dtTable = new DataTable();
      this.sqlQuerry = "TBThanhToanNganHang_Get_InfoThanhToan";
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.Text;
        this.dtTable = DataWeb.db.GetData(this.cmd);
      }
      catch (Exception ex)
      {
        throw;
      }
      return this.dtTable;
    }
  }
}
