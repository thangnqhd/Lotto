// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbLoOffline
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Thống_kê_xổ_số.FormUI;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TbLoOffline
  {
    private DataTable _dtTable;
    private List<TbLoOffline> _listItemLoOfflines;

    public int Stt { get; set; }

    public int Sothutu { get; set; }

    public int MaChuki { get; set; }

    public string SoChot { get; set; }

    public DateTime NgayChot { get; set; }

    public Decimal TongDiem { get; set; }

    public Decimal SoLove { get; set; }

    public string SoVon { get; set; }

    public string SoLai { get; set; }

    public string NgayDanh { get; set; }

    public string DuNo { get; set; }

    public string HinhThucDanh { get; set; }

    public string Nguonloto { get; set; }

    public string TenDangnhap { get; set; }

    public string TenChuki { get; set; }

    public DataTable GetListInfor()
    {
      this._dtTable = new DataTable();
      string sql = "SELECT ROW_NUMBER() OVER(ORDER BY stt) AS STT,* From tbLoOffline";
      this._dtTable = DataWeb.db.GetData(sql);
      return this._dtTable;
    }

    public DataTable GetSolaiByMonth(int month, int year, string tenDangnhap)
    {
      string sql = string.Format("tbLoOffline_Get_Solai_By_Month {0}, {1}, N'{2}'", (object) month, (object) year, (object) tenDangnhap);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return this._dtTable;
    }

    public DataTable GetByChuKiUsername(string tenChuki, string tenDangnhap)
    {
      string sql = string.Format("tbLoOffline_Get_By_ChuKi_Username N'{0}', N'{1}'", (object) tenChuki, (object) tenDangnhap);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return this._dtTable;
    }

    public DataTable GetListByMaChuKi(int maChuki)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbLoOffline_Get_By_MaChuki {0}", (object) maChuki);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return this._dtTable;
    }

    public DataTable GetSoVonSolaiByMaChuKi(int maChuki)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbLoOffline_Get_TongThu_Loto_DacBiet_By_Machuki {0}", (object) maChuki);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return this._dtTable;
    }

    public List<TbLoOffline> GetListByMaChuKiObj(int maChuki, string donVitienTe)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbLoOffline_Get_By_MaChuki {0}", (object) maChuki);
      try
      {
        this._listItemLoOfflines = new List<TbLoOffline>();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          for (int index = 0; index < this._dtTable.Rows.Count; ++index)
          {
            string str = "";
            TbLoOffline tbLoOffline = new TbLoOffline()
            {
              Sothutu = index + 1,
              Stt = int.Parse(this._dtTable.Rows[index]["stt"].ToString()),
              MaChuki = int.Parse(this._dtTable.Rows[index]["macChuki"].ToString()),
              SoChot = this._dtTable.Rows[index]["soChot"].ToString(),
              NgayChot = DateTime.Parse(this._dtTable.Rows[index]["ngayChot"].ToString()),
              TongDiem = (Decimal) int.Parse(this._dtTable.Rows[index]["tongDiem"].ToString()),
              SoLove = (Decimal) int.Parse(this._dtTable.Rows[index]["soLove"].ToString()),
              SoVon = ClMain.QuiDoiSoLuong(this._dtTable.Rows[index]["soVon"].ToString(), donVitienTe),
              SoLai = ClMain.QuiDoiSoLuong(this._dtTable.Rows[index]["soLai"].ToString(), donVitienTe),
              DuNo = ClMain.QuiDoiSoLuong(this._dtTable.Rows[index]["duNo"].ToString(), donVitienTe),
              Nguonloto = this._dtTable.Rows[index]["nguonloto"].ToString()
            };
            tbLoOffline.NgayDanh = "nuôi ngày [ " + this._dtTable.Rows[index]["ngayDanh"] + " ]";
            if (int.Parse(this._dtTable.Rows[index]["hinhThucDanh"].ToString()) == 0)
            {
              str = "Lô ngày";
              tbLoOffline.NgayDanh = "lô ngày";
            }
            if (int.Parse(this._dtTable.Rows[index]["hinhThucDanh"].ToString()) == 1)
              str = "Lô nuôi";
            if (int.Parse(this._dtTable.Rows[index]["hinhThucDanh"].ToString()) == 2)
            {
              str = "Đặc biệt ngày";
              tbLoOffline.NgayDanh = "đặc biệt ngày";
            }
            if (int.Parse(this._dtTable.Rows[index]["hinhThucDanh"].ToString()) == 3)
              str = "Đặc biệt nuôi";
            tbLoOffline.HinhThucDanh = str;
            this._listItemLoOfflines.Add(tbLoOffline);
          }
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._listItemLoOfflines;
    }

    public TbLoOffline GetInfor(int stt)
    {
      TbLoOffline tbLoOffline = new TbLoOffline();
      this._dtTable = new DataTable();
      string sql = "Select * From tbLoOffline Where stt=N'" + (object) stt + "' ";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbLoOffline.Stt = int.Parse(this._dtTable.Rows[0][nameof (stt)].ToString());
          }
          catch (FormatException ex)
          {
            tbLoOffline.Stt = 0;
          }
          try
          {
            tbLoOffline.MaChuki = int.Parse(this._dtTable.Rows[0]["macChuki"].ToString());
          }
          catch (FormatException ex)
          {
            tbLoOffline.MaChuki = 0;
          }
          tbLoOffline.SoChot = this._dtTable.Rows[0]["soChot"].ToString();
          try
          {
            tbLoOffline.NgayChot = DateTime.Parse(this._dtTable.Rows[0]["ngayChot"].ToString());
          }
          catch (FormatException ex)
          {
          }
          try
          {
            tbLoOffline.TongDiem = (Decimal) int.Parse(this._dtTable.Rows[0]["tongDiem"].ToString());
          }
          catch (FormatException ex)
          {
            tbLoOffline.TongDiem = Decimal.Zero;
          }
          try
          {
            tbLoOffline.SoLove = (Decimal) int.Parse(this._dtTable.Rows[0]["soLove"].ToString());
          }
          catch (FormatException ex)
          {
            tbLoOffline.SoLove = Decimal.Zero;
          }
          tbLoOffline.SoVon = this._dtTable.Rows[0]["soVon"].ToString();
          tbLoOffline.SoLai = this._dtTable.Rows[0]["soLai"].ToString();
          tbLoOffline.NgayDanh = this._dtTable.Rows[0]["ngayDanh"].ToString();
          tbLoOffline.DuNo = this._dtTable.Rows[0]["duNo"].ToString();
          tbLoOffline.HinhThucDanh = this._dtTable.Rows[0]["hinhThucDanh"].ToString();
          tbLoOffline.Nguonloto = this._dtTable.Rows[0]["nguonloto"].ToString();
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "0";
      }
      return tbLoOffline;
    }

    public bool Insert(TbLoOffline obj)
    {
      string cmdText = string.Format("tbLoOffline_Insert {0}, N'{1}', N'{2}', N'{3}', {4}, {5}, N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}'", (object) obj.MaChuki, (object) obj.TenChuki, (object) obj.TenDangnhap, (object) obj.SoChot, (object) obj.TongDiem, (object) obj.SoLove, (object) obj.SoVon, (object) obj.SoLai, (object) obj.NgayDanh, (object) obj.DuNo, (object) obj.HinhThucDanh, (object) obj.Nguonloto);
      bool flag;
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        flag = true;
      }
      catch (Exception ex)
      {
        flag = false;
      }
      return flag;
    }

    public bool Update(TbLoOffline obj)
    {
      string cmdText = string.Format("tbLoOffline_Update N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}'", (object) obj.Stt, (object) obj.SoChot, (object) obj.TongDiem, (object) obj.SoLove, (object) obj.SoVon, (object) obj.SoLai, (object) obj.NgayDanh, (object) obj.DuNo, (object) obj.HinhThucDanh, (object) obj.Nguonloto);
      bool flag;
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        flag = true;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    public bool Delete(int maChotLoto)
    {
      string cmdText = string.Format("tbLoOffline_Delete {0}", (object) maChotLoto);
      bool flag;
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        flag = true;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }
  }
}
