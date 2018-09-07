// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TBManager
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System.Data;
using System.Data.SqlClient;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TBManager
  {
    private DataTable dtTable;
    private string sqlQuerry;
    private SqlCommand cmd;

    public DataTable GetAll()
    {
      this.dtTable = new DataTable();
      this.sqlQuerry = "TBManager_Get_All_Active";
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.dtTable = DataWeb.db.GetData(this.cmd);
      }
      catch
      {
        throw;
      }
      return this.dtTable;
    }
  }
}
