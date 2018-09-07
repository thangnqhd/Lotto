// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbQuidoiVangNgaySuDung
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
  public class TbQuidoiVangNgaySuDung
  {
    private DataTable _dtTable;

    public string Stt { get; set; }

    public string Name { get; set; }

    public string VangCan { get; set; }

    public string NgayDoiduoc { get; set; }

    public DateTime NgayThem { get; set; }

    public DataTable GetListInfor()
    {
      this._dtTable = new DataTable();
      string cmdText = "tbQuidoiVang_NgaySuDung_GetInfo";
      this._dtTable = new DataTable();
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.StoredProcedure;
        this._dtTable = DataWeb.db.GetData(cmd);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public TbQuidoiVangNgaySuDung GetInfor(string id)
    {
      TbQuidoiVangNgaySuDung quidoiVangNgaySuDung = new TbQuidoiVangNgaySuDung();
      this._dtTable = new DataTable();
      string sql = string.Format("tbQuidoiVang_NgaySuDung_get_by_ID {0}", (object) id);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          quidoiVangNgaySuDung.Stt = this._dtTable.Rows[0]["stt"].ToString();
          quidoiVangNgaySuDung.Name = this._dtTable.Rows[0]["name"].ToString();
          quidoiVangNgaySuDung.VangCan = this._dtTable.Rows[0]["vangCan"].ToString();
          quidoiVangNgaySuDung.NgayDoiduoc = this._dtTable.Rows[0]["ngayDoiduoc"].ToString();
          try
          {
            quidoiVangNgaySuDung.NgayThem = DateTime.Parse(this._dtTable.Rows[0]["ngayThem"].ToString());
          }
          catch (FormatException ex)
          {
          }
        }
      }
      catch
      {
        FLogin.MsgId = "014";
        FLogin.LogOutStatus = "1";
      }
      return quidoiVangNgaySuDung;
    }
  }
}
