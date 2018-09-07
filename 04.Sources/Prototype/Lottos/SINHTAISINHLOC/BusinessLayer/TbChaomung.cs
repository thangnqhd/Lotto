// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbChaomung
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System.Data;

namespace Thống_kê_xổ_số.BusinessLayer
{
  internal class TbChaomung
  {
    private DataTable _dtTable;

    public DataTable GetByStatus()
    {
      this._dtTable = new DataTable();
      string sql = "TbChaomung_Get_By_Status";
      try
      {
        this._dtTable = DataApp.db.GetData(sql);
      }
      catch
      {
        throw;
      }
      return this._dtTable;
    }
  }
}
