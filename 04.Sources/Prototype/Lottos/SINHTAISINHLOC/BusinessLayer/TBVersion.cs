// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TBVersion
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System.Data;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TBVersion
  {
    private DataTable _dtTable;
    private string _version;

    public string GetNewVersion()
    {
      this._dtTable = new DataTable();
      this._version = "1.0.0.1";
      string sql = "Select top(1) * From tbVersion order by dateAdd desc";
      try
      {
        this._dtTable = DataApp.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
          this._version = this._dtTable.Rows[0]["version"].ToString();
      }
      catch
      {
      }
      return this._version;
    }
  }
}
