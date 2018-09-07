// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbVangsudung
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Thống_kê_xổ_số.FormUI;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class tbVangsudung
  {
    public static tbVangsudung infoVangSudung;
    private int stt;
    private string tenDangnhap;
    private string vangSudung;
    private string cachSudung;
    private DateTime ngaySudung;
    private DataTable dtTable;
    private string[] _msg;

    public tbVangsudung()
    {
    }

    public tbVangsudung(int stt, string tenDangnhap, string vangSudung, string cachSudung, DateTime ngaySudung)
    {
      this.stt = stt;
      this.tenDangnhap = tenDangnhap;
      this.vangSudung = vangSudung;
      this.cachSudung = cachSudung;
      this.ngaySudung = ngaySudung;
    }

    public int Stt
    {
      get
      {
        return this.stt;
      }
      set
      {
        this.stt = value;
      }
    }

    public string TenDangnhap
    {
      get
      {
        return this.tenDangnhap;
      }
      set
      {
        this.tenDangnhap = value;
      }
    }

    public string VangSudung
    {
      get
      {
        return this.vangSudung;
      }
      set
      {
        this.vangSudung = value;
      }
    }

    public string CachSudung
    {
      get
      {
        return this.cachSudung;
      }
      set
      {
        this.cachSudung = value;
      }
    }

    public DateTime NgaySudung
    {
      get
      {
        return this.ngaySudung;
      }
      set
      {
        this.ngaySudung = value;
      }
    }

    public override string ToString()
    {
      return this.stt.ToString() + "; " + this.tenDangnhap + "; " + this.vangSudung + "; " + this.cachSudung + "; " + (object) this.ngaySudung + "; ";
    }

    public override bool Equals(object obj)
    {
      return this.Stt.Equals(((tbVangsudung) obj).Stt);
    }

    public override int GetHashCode()
    {
      return this.Stt.GetHashCode();
    }

    public DataTable GetListInfor()
    {
      this.dtTable = new DataTable();
      string sql = "SELECT ROW_NUMBER() OVER(ORDER BY stt) AS STT,* From tbVangsudung";
      try
      {
        this.dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        this._msg = ClMain.Get_Msg("009");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Application.Exit();
      }
      return this.dtTable;
    }

    public DataTable GetListInfor(int stt)
    {
      tbVangsudung tbVangsudung = new tbVangsudung();
      this.dtTable = new DataTable();
      string sql = "Select * From tbVangsudung Where stt Like N'%" + (object) stt + "%' ";
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

    public tbVangsudung GetInfor(int stt)
    {
      tbVangsudung tbVangsudung = new tbVangsudung();
      this.dtTable = new DataTable();
      string sql = "Select * From tbVangsudung Where stt=N'" + (object) stt + "' ";
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            tbVangsudung.Stt = int.Parse(this.dtTable.Rows[0][nameof (stt)].ToString());
          }
          catch (FormatException ex)
          {
            tbVangsudung.Stt = 0;
          }
          tbVangsudung.TenDangnhap = this.dtTable.Rows[0]["tenDangnhap"].ToString();
          tbVangsudung.VangSudung = this.dtTable.Rows[0]["vangSudung"].ToString();
          tbVangsudung.CachSudung = this.dtTable.Rows[0]["cachSudung"].ToString();
          try
          {
            tbVangsudung.NgaySudung = DateTime.Parse(this.dtTable.Rows[0]["ngaySudung"].ToString());
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
      return tbVangsudung;
    }

    public int Insert(tbVangsudung obj)
    {
      int num = 0;
      string cmdText = string.Format("tbVangsudung_Insert N'{0}', N'{1}', N'{2}'", (object) obj.TenDangnhap, (object) obj.VangSudung, (object) obj.CachSudung);
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

    public int Update(tbVangsudung obj)
    {
      int num = 0;
      string cmdText = string.Format("tbVangsudung_Update N'{0}', N'{1}', N'{2}', N'{3}', N'{4}'", (object) obj.Stt, (object) obj.TenDangnhap, (object) obj.VangSudung, (object) obj.CachSudung, (object) obj.NgaySudung);
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
