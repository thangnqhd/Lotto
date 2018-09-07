// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbConServerEmail
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using Thống_kê_xổ_số.FormUI;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class tbConServerEmail
  {
    private DataTable dtTable;

    public int stt { get; set; }

    public string email { get; set; }

    public string pass { get; set; }

    public string host { get; set; }

    public string port { get; set; }

    public string title { get; set; }

    public DateTime date { get; set; }

    public tbConServerEmail GetInfor()
    {
      tbConServerEmail tbConServerEmail = new tbConServerEmail();
      this.dtTable = new DataTable();
      string sql = "select top (1)* from [dbo].[tbConServerEmail] order by [date] desc";
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            tbConServerEmail.stt = int.Parse(this.dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbConServerEmail.stt = 0;
          }
          tbConServerEmail.email = this.dtTable.Rows[0]["email"].ToString();
          tbConServerEmail.pass = this.dtTable.Rows[0]["pass"].ToString();
          tbConServerEmail.host = this.dtTable.Rows[0]["host"].ToString();
          tbConServerEmail.port = this.dtTable.Rows[0]["port"].ToString();
          tbConServerEmail.title = this.dtTable.Rows[0]["title"].ToString();
          try
          {
            tbConServerEmail.date = DateTime.Parse(this.dtTable.Rows[0]["date"].ToString());
          }
          catch (FormatException ex)
          {
          }
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return tbConServerEmail;
    }
  }
}
