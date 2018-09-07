// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbMoneyUSER
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
  [Serializable]
  public class tbMoneyUSER
  {
    public string[] msg;
    public int stt;
    public string tenDangnhap;
    public string vangHienco;
    public string xuHienco;
    public DateTime suDungtu_Ngay;
    public DateTime suDungden_Ngay;
    public DateTime capNhatNgay;
    private DataTable dtTable;
    private string sqlQuerry;
    private SqlCommand cmd;

    public tbMoneyUSER()
    {
    }

    public tbMoneyUSER(int stt, string tenDangnhap, string vangHienco, string xuHienco, DateTime suDungtu_Ngay, DateTime suDungden_Ngay, DateTime capNhatNgay)
    {
      this.stt = stt;
      this.tenDangnhap = tenDangnhap;
      this.vangHienco = vangHienco;
      this.xuHienco = xuHienco;
      this.suDungtu_Ngay = suDungtu_Ngay;
      this.suDungden_Ngay = suDungden_Ngay;
      this.capNhatNgay = capNhatNgay;
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

    public string VangHienco
    {
      get
      {
        return this.vangHienco;
      }
      set
      {
        this.vangHienco = value;
      }
    }

    public string XuHienco
    {
      get
      {
        return this.xuHienco;
      }
      set
      {
        this.xuHienco = value;
      }
    }

    public DateTime SuDungtu_Ngay
    {
      get
      {
        return this.suDungtu_Ngay;
      }
      set
      {
        this.suDungtu_Ngay = value;
      }
    }

    public DateTime SuDungden_Ngay
    {
      get
      {
        return this.suDungden_Ngay;
      }
      set
      {
        this.suDungden_Ngay = value;
      }
    }

    public DateTime CapNhatNgay
    {
      get
      {
        return this.capNhatNgay;
      }
      set
      {
        this.capNhatNgay = value;
      }
    }

    public override string ToString()
    {
      return this.stt.ToString() + "; " + this.tenDangnhap + "; " + this.vangHienco + "; " + this.xuHienco + "; " + (object) this.suDungtu_Ngay + "; " + (object) this.suDungden_Ngay + "; " + (object) this.capNhatNgay + "; ";
    }

    public override bool Equals(object obj)
    {
      return this.Stt.Equals(((tbMoneyUSER) obj).Stt);
    }

    public override int GetHashCode()
    {
      return this.Stt.GetHashCode();
    }

    public int Insert(tbMoneyUSER obj)
    {
      int num = 0;
      string cmdText = string.Format("tbMoneyUSER_Insert N'{0}', N'{1}', N'{2}', N'{3}', N'{4}'", (object) obj.TenDangnhap, (object) obj.VangHienco, (object) obj.XuHienco, (object) obj.SuDungtu_Ngay.ToString("yyyy-MM-dd hh:mm:ss"), (object) obj.SuDungden_Ngay.ToString("yyyy-MM-dd hh:mm:ss"));
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

    public int Update(tbMoneyUSER obj)
    {
      int num = 0;
      string cmdText = string.Format("tbMoneyUSER_Update N'{0}', N'{1}', N'{2}', N'{3}', N'{4}'", (object) obj.TenDangnhap, (object) obj.VangHienco, (object) obj.XuHienco, (object) obj.SuDungtu_Ngay.ToString("yyyy-MM-dd hh:mm:ss"), (object) obj.SuDungden_Ngay.ToString("yyyy-MM-dd hh:mm:ss"));
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

    public int Update_BacHienCo_Username(string Username, string bacUpdate)
    {
      int num = 0;
      string cmdText = string.Format("tbMoneyUSER_Update_BacHienCo_Username N'{0}',N'{1}'", (object) Username, (object) bacUpdate);
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

    public tbMoneyUSER GetInfor(string tenDangnhap)
    {
      tbMoneyUSER tbMoneyUser = new tbMoneyUSER();
      this.dtTable = new DataTable();
      string sql = "Select top(1) * From tbMoneyUSER Where tenDangnhap=N'" + tenDangnhap + "' ";
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            tbMoneyUser.Stt = int.Parse(this.dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbMoneyUser.Stt = 0;
          }
          tbMoneyUser.TenDangnhap = this.dtTable.Rows[0][nameof (tenDangnhap)].ToString();
          tbMoneyUser.VangHienco = this.dtTable.Rows[0]["vangHienco"].ToString();
          tbMoneyUser.XuHienco = this.dtTable.Rows[0]["XuHienco"].ToString();
          try
          {
            this.dtTable.Rows[0]["suDungtu_Ngay"].ToString();
            tbMoneyUser.SuDungtu_Ngay = Convert.ToDateTime(this.dtTable.Rows[0]["suDungtu_Ngay"].ToString());
          }
          catch (FormatException ex)
          {
          }
          try
          {
            tbMoneyUser.SuDungden_Ngay = Convert.ToDateTime(this.dtTable.Rows[0]["suDungden_Ngay"].ToString());
          }
          catch (FormatException ex)
          {
          }
          try
          {
            tbMoneyUser.CapNhatNgay = Convert.ToDateTime(this.dtTable.Rows[0]["capNhatNgay"].ToString());
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
      return tbMoneyUser;
    }

    public Decimal Get_Bac_By_Username(string userName)
    {
      Decimal num = new Decimal();
      this.dtTable = new DataTable();
      string sql = string.Format("tbMoneyUSER_Get_XuHienCo_By_Username N'{0}'", (object) userName);
      try
      {
        this.dtTable = DataWeb.db.GetData(sql);
        if (this.dtTable.Rows.Count > 0)
          num = Convert.ToDecimal(this.dtTable.Rows[0][0].ToString());
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public int GetVangHienCoByUsername(string username)
    {
      int num = 0;
      this.sqlQuerry = "TBMoneyUser_Get_VangHienCo_By_Username";
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.cmd.Parameters.AddWithValue("@username", (object) username);
        this.dtTable = DataWeb.db.GetData(this.cmd);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            num = Convert.ToInt32(this.dtTable.Rows[0][0].ToString());
          }
          catch (Exception ex)
          {
            num = 0;
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
      return num;
    }

    public bool Update_VangHienCo(string username, string vang)
    {
      this.sqlQuerry = "TBMoneyUSER_Update_VangHienCo";
      bool flag;
      try
      {
        this.cmd = new SqlCommand(this.sqlQuerry);
        this.cmd.CommandType = CommandType.StoredProcedure;
        this.cmd.Parameters.AddWithValue("@username", (object) username);
        this.cmd.Parameters.AddWithValue("@vanghienco", (object) vang);
        DataWeb.db.ExecuteNonQuery(this.cmd);
        flag = true;
      }
      catch (Exception ex)
      {
        throw;
      }
      return flag;
    }
  }
}
