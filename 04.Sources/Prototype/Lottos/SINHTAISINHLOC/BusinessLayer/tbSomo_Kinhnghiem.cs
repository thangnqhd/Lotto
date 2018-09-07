// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbSomo_Kinhnghiem
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
  public class tbSomo_Kinhnghiem
  {
    private DataTable dtTable;

    public int stt { get; set; }

    public string tieuDe { get; set; }

    public string noiDung { get; set; }

    public string loai { get; set; }

    public int trangThai { get; set; }

    public DateTime ngayCapnhat { get; set; }

    public DataTable GetListBy_KeySearch(string keySearch, string loai, int trangThai)
    {
      string sql = string.Format("tbSomo_Kinhnghiem_Get_By_Name N'{0}',N'{1}',{2}", (object) keySearch, (object) loai, (object) trangThai);
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this.dtTable;
    }

    public DataTable GetListBy_Title(string loai)
    {
      string sql = string.Format("tbSomo_Kinhnghiem_Get_All_Title N'{0}'", (object) loai);
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this.dtTable;
    }

    public DataTable GetAll(int soBanghi, string loai, int trangthai)
    {
      this.dtTable = new DataTable();
      string sql = string.Format("tbSomo_Kinhnghiem_Get_All {0},N'{1}',{2}", (object) soBanghi, (object) loai, (object) this.trangThai);
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this.dtTable;
    }

    public tbSomo_Kinhnghiem GetInfor(string stt)
    {
      tbSomo_Kinhnghiem tbSomoKinhnghiem = new tbSomo_Kinhnghiem();
      this.dtTable = new DataTable();
      try
      {
        int.Parse(stt);
      }
      catch (FormatException ex)
      {
        stt = "0";
      }
      string sql = "Select * From tbSomo_Kinhnghiem Where stt=" + stt + " ";
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            tbSomoKinhnghiem.stt = int.Parse(this.dtTable.Rows[0][nameof (stt)].ToString());
          }
          catch (FormatException ex)
          {
            tbSomoKinhnghiem.stt = 0;
          }
          tbSomoKinhnghiem.tieuDe = this.dtTable.Rows[0]["tieuDe"].ToString();
          tbSomoKinhnghiem.noiDung = this.dtTable.Rows[0]["noiDung"].ToString();
          tbSomoKinhnghiem.loai = this.dtTable.Rows[0]["loai"].ToString();
          tbSomoKinhnghiem.trangThai = this.dtTable.Rows[0]["trangThai"].ToString() == "True" ? 1 : 0;
          try
          {
            tbSomoKinhnghiem.ngayCapnhat = DateTime.Parse(this.dtTable.Rows[0]["ngayCapnhat"].ToString());
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
      return tbSomoKinhnghiem;
    }

    public int Insert(tbSomo_Kinhnghiem obj)
    {
      int num = 0;
      string cmdText = string.Format("tbSomo_Kinhnghiem_Insert N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}'", (object) obj.stt, (object) obj.tieuDe, (object) obj.noiDung, (object) obj.loai, (object) obj.trangThai, (object) obj.ngayCapnhat);
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
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public int Update(tbSomo_Kinhnghiem obj)
    {
      int num = 0;
      string cmdText = string.Format("tbSomo_Kinhnghiem_Update N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}'", (object) obj.stt, (object) obj.tieuDe, (object) obj.noiDung, (object) obj.loai, (object) obj.trangThai, (object) obj.ngayCapnhat);
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public int Delete(tbSomo_Kinhnghiem obj)
    {
      int num = 0;
      string cmdText = string.Format("tbSomo_Kinhnghiem_Delete N'{0}'", (object) obj.stt);
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        num = 1;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }
  }
}
