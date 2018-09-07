// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbMessage
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
  public class tbMessage
  {
    public static tbMessage InfoMessage;
    private DataTable _dtTable;

    public int Stt { get; set; }

    public string NguoiGui { get; set; }

    public string NguoiNhan { get; set; }

    public string TieuDe { get; set; }

    public string NoiDung { get; set; }

    public int Status { get; set; }

    public DateTime SendDate { get; set; }

    public DataTable GetListInfor(string tenDangnhap, int soBanghi, int _status)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbMessage_get_Message_by_New N'{0}',{1},{2}", (object) tenDangnhap, (object) soBanghi, (object) _status);
      try
      {
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable Get_Count(string tenDangnhap, int trangThai)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbMessage_Count_New N'{0}',{1}", (object) tenDangnhap, (object) trangThai);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable GetListInfor_Message_Old(string tenDangnhap, int soBanghi)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbMessage_get_Message_by_Old N'{0}',{1}", (object) tenDangnhap, (object) soBanghi);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public tbMessage GetInfor(string tenDangnhap)
    {
      tbMessage tbMessage = new tbMessage();
      this._dtTable = new DataTable();
      string sql = string.Format("tbMessage_get_Message_by_User N'{0}'", (object) tenDangnhap);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbMessage.Stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbMessage.Stt = 0;
          }
          tbMessage.NguoiGui = this._dtTable.Rows[0]["nguoiGui"].ToString();
          tbMessage.NguoiNhan = this._dtTable.Rows[0]["nguoiNhan"].ToString();
          tbMessage.TieuDe = this._dtTable.Rows[0]["tieuDe"].ToString();
          tbMessage.NoiDung = this._dtTable.Rows[0]["noiDung"].ToString();
          tbMessage.Status = this._dtTable.Rows[0]["status"].ToString() == "True" ? 1 : 0;
          try
          {
            tbMessage.SendDate = DateTime.Parse(this._dtTable.Rows[0]["sendDate"].ToString());
          }
          catch (FormatException ex)
          {
          }
        }
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return tbMessage;
    }

    public int Insert(tbMessage obj)
    {
      int num = 0;
      string cmdText = string.Format("tbMessage_Insert N'{0}', N'{1}', N'{2}', N'{3}'", (object) obj.NguoiGui, (object) obj.NguoiNhan, (object) obj.TieuDe, (object) obj.NoiDung);
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public int Delete_By_ID(string stt)
    {
      int num = 0;
      string cmdText = string.Format("tbMessage_Delete_byID {0}", (object) stt);
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
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public int Update(tbMessage obj)
    {
      int num = 0;
      string cmdText = string.Format("tbMessage_Update N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}'", (object) obj.Stt, (object) obj.NguoiGui, (object) obj.NguoiNhan, (object) obj.TieuDe, (object) obj.NoiDung, (object) obj.Status, (object) obj.SendDate);
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
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public void Update_Status(int stt)
    {
      string cmdText = string.Format("tbUser_Update_Status_By_ID {0}", (object) stt);
      try
      {
        SqlCommand sqlCommand = new SqlCommand(cmdText);
        sqlCommand.CommandType = CommandType.Text;
        SqlCommand cmd = sqlCommand;
        DataWeb.db.ExecuteNonQuery(cmd);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
    }
  }
}
