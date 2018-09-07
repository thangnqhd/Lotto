// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbDuDoanLoTo
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using Thống_kê_xổ_số.FormUI;

namespace Thống_kê_xổ_số.BusinessLayer
{
  internal class TbDuDoanLoTo
  {
    private DataTable _dtTable;

    public DataTable GetByDate(DateTime ngayDuDoan)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("TbDuDoanLoTo_Get_All N'{0}'", (object) ngayDuDoan.ToString("yyyy-MM-dd"));
      try
      {
        this._dtTable = DataApp.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }
  }
}
