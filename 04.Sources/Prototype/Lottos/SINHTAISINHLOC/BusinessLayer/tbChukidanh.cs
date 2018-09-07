// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbChukidanh
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
  public class tbChukidanh
  {
    private DataTable _dtTable;

    public int stt { get; set; }

    public string tenDangnhap { get; set; }

    public string tenChuki { get; set; }

    public Decimal tongTienLai { get; set; }

    public Decimal tongSovon { get; set; }

    public Decimal tileLaitrenVon { get; set; }

    public Decimal muctieuChuki { get; set; }

    public Decimal hesoNhanLo { get; set; }

    public Decimal tileAnLo { get; set; }

    public Decimal hesoNhanDe { get; set; }

    public Decimal tileAnDe { get; set; }

    public string donviTien { get; set; }

    public DateTime ngayBatdau { get; set; }

    public DateTime ngayKetthuc { get; set; }

    public int status { get; set; }

    public DataTable GetList_By_Username(string tenDangnhap)
    {
      string sql = string.Format("tbChukidanh_Get_tenChuki_By_Username N'{0}'", (object) tenDangnhap);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable Get_Solai_By_Year(int year, string tenDangnhap)
    {
      string sql = string.Format("tbChukidanh_Get_Solai_By_Year {0}, N'{1}'", (object) year, (object) tenDangnhap);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        throw;
      }
      return this._dtTable;
    }

    public DataTable Get_List_By_Top(int soBanGhi, string tenDangnhap)
    {
      string sql = string.Format("tbChukidanh_Get_List_By_Top {0}, N'{1}'", (object) soBanGhi, (object) tenDangnhap);
      try
      {
        DataTable dataTable = new DataTable();
        this._dtTable = new DataTable();
        this._dtTable.Columns.Add("maChuki", typeof (int));
        this._dtTable.Columns.Add("soThutu", typeof (int));
        this._dtTable.Columns.Add("tenChuki", typeof (string));
        DataTable data = DataWeb.db.GetData(sql);
        if (data.Rows.Count > 0)
        {
          for (int index = 0; index < data.Rows.Count; ++index)
          {
            string str1 = " - Chưa chốt ]";
            DataRow row = this._dtTable.NewRow();
            row["maChuki"] = (object) data.Rows[index]["stt"].ToString();
            row["soThutu"] = (object) (index + 1).ToString();
            if (data.Rows[index]["status"].ToString() == "False" || data.Rows[index]["status"].ToString() == "0")
              str1 = " - " + Convert.ToDateTime(data.Rows[index]["ngayKetthuc"].ToString()).ToString("dd/MM") + " ]";
            string str2 = " [ " + Convert.ToDateTime(data.Rows[index]["ngayBatdau"].ToString()).ToString("dd/MM");
            row["tenChuki"] = (object) (data.Rows[index]["tenChuki"].ToString() + str2 + str1);
            this._dtTable.Rows.Add(row);
          }
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return this._dtTable;
    }

    public int GetMaChuKiByUsernameTop(string tenDangnhap)
    {
      int num = -1;
      this._dtTable = new DataTable();
      string sql = string.Format("tbChukidanh_Get_By_Username_Top N'{0}'", (object) tenDangnhap);
      try
      {
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
          num = int.Parse(this._dtTable.Rows[0][0].ToString());
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return num;
    }

    public tbChukidanh GetList_Top_By_Username(string tenDangnhap, int soBanghi)
    {
      tbChukidanh tbChukidanh = new tbChukidanh();
      this._dtTable = new DataTable();
      string sql = string.Format("tbChukidanh_Get_Top_By_Username N'{0}',{1}", (object) tenDangnhap, (object) soBanghi);
      try
      {
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbChukidanh.stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.stt = 0;
          }
          tbChukidanh.tenDangnhap = this._dtTable.Rows[0][nameof (tenDangnhap)].ToString();
          tbChukidanh.tenChuki = this._dtTable.Rows[0]["tenChuki"].ToString();
          try
          {
            tbChukidanh.tongTienLai = Decimal.Parse(this._dtTable.Rows[0]["tongTienLai"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tongTienLai = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tongSovon = Decimal.Parse(this._dtTable.Rows[0]["tongSovon"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tongSovon = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tileLaitrenVon = Decimal.Parse(this._dtTable.Rows[0]["tileLaitrenVon"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileLaitrenVon = Decimal.Zero;
          }
          try
          {
            tbChukidanh.muctieuChuki = Decimal.Parse(this._dtTable.Rows[0]["muctieuChuki"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileLaitrenVon = Decimal.Zero;
          }
          try
          {
            tbChukidanh.hesoNhanLo = Decimal.Parse(this._dtTable.Rows[0]["hesoNhanLo"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.hesoNhanLo = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tileAnLo = Decimal.Parse(this._dtTable.Rows[0]["tileAnLo"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileAnLo = Decimal.Zero;
          }
          try
          {
            tbChukidanh.hesoNhanDe = Decimal.Parse(this._dtTable.Rows[0]["hesoNhanDe"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.hesoNhanDe = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tileAnDe = Decimal.Parse(this._dtTable.Rows[0]["tileAnDe"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileAnDe = Decimal.Zero;
          }
          tbChukidanh.donviTien = this._dtTable.Rows[0]["donviTien"].ToString();
          try
          {
            tbChukidanh.ngayBatdau = DateTime.Parse(this._dtTable.Rows[0]["ngayBatdau"].ToString());
          }
          catch (FormatException ex)
          {
          }
          try
          {
            tbChukidanh.ngayKetthuc = DateTime.Parse(this._dtTable.Rows[0]["ngayKetthuc"].ToString());
          }
          catch (FormatException ex)
          {
          }
          tbChukidanh.status = this._dtTable.Rows[0]["status"].ToString() == "True" ? 1 : 0;
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return tbChukidanh;
    }

    public DataTable GetListInfor(int stt)
    {
      tbChukidanh tbChukidanh = new tbChukidanh();
      this._dtTable = new DataTable();
      string sql = "Select * From tbChukidanh Where stt Like N'%" + (object) stt + "%' ";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable GetList_By_TenChuki(string tenDangnhap, string tenChuki)
    {
      string sql = string.Format("tbChukidanh_Get_By_TenChuki_Username N'{0}',N'{1}'", (object) tenDangnhap, (object) tenChuki);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable CheckStatus(int maChuki)
    {
      string sql = string.Format("tbChukidanh_Check_Status {0}", (object) maChuki);
      this._dtTable = new DataTable();
      try
      {
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public tbChukidanh GetInfor(int maChuki)
    {
      tbChukidanh tbChukidanh = new tbChukidanh();
      this._dtTable = new DataTable();
      string sql = "Select * From tbChukidanh Where stt=N'" + (object) maChuki + "' ";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbChukidanh.stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.stt = 0;
          }
          tbChukidanh.tenDangnhap = this._dtTable.Rows[0]["tenDangnhap"].ToString();
          tbChukidanh.tenChuki = this._dtTable.Rows[0]["tenChuki"].ToString();
          try
          {
            tbChukidanh.tongTienLai = Decimal.Parse(this._dtTable.Rows[0]["tongTienLai"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tongTienLai = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tongSovon = Decimal.Parse(this._dtTable.Rows[0]["tongSovon"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tongSovon = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tileLaitrenVon = Decimal.Parse(this._dtTable.Rows[0]["tileLaitrenVon"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileLaitrenVon = Decimal.Zero;
          }
          try
          {
            tbChukidanh.muctieuChuki = Decimal.Parse(this._dtTable.Rows[0]["muctieuChuki"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileLaitrenVon = Decimal.Zero;
          }
          try
          {
            tbChukidanh.hesoNhanLo = Decimal.Parse(this._dtTable.Rows[0]["hesoNhanLo"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.hesoNhanLo = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tileAnLo = Decimal.Parse(this._dtTable.Rows[0]["tileAnLo"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileAnLo = Decimal.Zero;
          }
          try
          {
            tbChukidanh.hesoNhanDe = Decimal.Parse(this._dtTable.Rows[0]["hesoNhanDe"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.hesoNhanDe = Decimal.Zero;
          }
          try
          {
            tbChukidanh.tileAnDe = Decimal.Parse(this._dtTable.Rows[0]["tileAnDe"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.tileAnDe = Decimal.Zero;
          }
          tbChukidanh.donviTien = this._dtTable.Rows[0]["donviTien"].ToString();
          try
          {
            tbChukidanh.ngayBatdau = DateTime.Parse(this._dtTable.Rows[0]["ngayBatdau"].ToString());
          }
          catch (FormatException ex)
          {
          }
          try
          {
            tbChukidanh.ngayKetthuc = DateTime.Parse(this._dtTable.Rows[0]["ngayKetthuc"].ToString());
          }
          catch (FormatException ex)
          {
            tbChukidanh.ngayKetthuc = DateTime.Now;
          }
          tbChukidanh.status = this._dtTable.Rows[0]["status"].ToString() == "True" ? 1 : 0;
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return tbChukidanh;
    }

    public int Insert(tbChukidanh obj)
    {
      string cmdText = string.Format("tbChukidanh_Insert N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}',N'{7}'", (object) obj.tenDangnhap, (object) obj.tenChuki, (object) obj.hesoNhanLo, (object) obj.tileAnLo, (object) obj.hesoNhanDe, (object) obj.tileAnDe, (object) obj.donviTien, (object) obj.muctieuChuki);
      int num;
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
        num = 0;
      }
      return num;
    }

    public int Update_Tonglai_Tongvon(int sttMachuki, Decimal tonglai, Decimal tongvon)
    {
      int num = 0;
      string cmdText = string.Format("tbChukidanh_Update_Tonglai_Tongvon N'{0}', N'{1}', N'{2}'", (object) sttMachuki, (object) tonglai, (object) tongvon);
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

    public int Update_Status(int _stt, string _status)
    {
      int num = 0;
      string cmdText = string.Format("tbChukidanh_Update_Status {0}, N'{1}'", (object) _stt, (object) _status);
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

    public bool Delete_By_Stt(string stt)
    {
      string cmdText = string.Format("tbChukidanh_Delete {0}", (object) stt);
      try
      {
        SqlCommand sqlCommand = new SqlCommand(cmdText);
        sqlCommand.CommandType = CommandType.Text;
        SqlCommand cmd = sqlCommand;
        DataWeb.db.ExecuteNonQuery(cmd);
        return true;
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return false;
    }
  }
}
