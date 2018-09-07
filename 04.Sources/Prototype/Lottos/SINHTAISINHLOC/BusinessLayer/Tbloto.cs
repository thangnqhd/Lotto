// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.Tbloto
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Thống_kê_xổ_số.FormUI;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class Tbloto
  {
    private DataTable _dtTable;
    public static SqlCommand Cmd;

    public ArrayList DanhSachCau()
    {
      return new ArrayList()
      {
        (object) "G0:1:1",
        (object) "G0:1:2",
        (object) "G0:1:3",
        (object) "G0:1:4",
        (object) "G0:1:5",
        (object) "G1:1:1",
        (object) "G1:1:2",
        (object) "G1:1:3",
        (object) "G1:1:4",
        (object) "G1:1:5",
        (object) "G2:1:1",
        (object) "G2:1:2",
        (object) "G2:1:3",
        (object) "G2:1:4",
        (object) "G2:1:5",
        (object) "G2:2:1",
        (object) "G2:2:2",
        (object) "G2:2:3",
        (object) "G2:2:4",
        (object) "G2:2:5",
        (object) "G3:1:1",
        (object) "G3:1:2",
        (object) "G3:1:3",
        (object) "G3:1:4",
        (object) "G3:1:5",
        (object) "G3:2:1",
        (object) "G3:2:2",
        (object) "G3:2:3",
        (object) "G3:2:4",
        (object) "G3:2:5",
        (object) "G3:3:1",
        (object) "G3:3:2",
        (object) "G3:3:3",
        (object) "G3:3:4",
        (object) "G3:3:5",
        (object) "G3:4:1",
        (object) "G3:4:2",
        (object) "G3:4:3",
        (object) "G3:4:4",
        (object) "G3:4:5",
        (object) "G3:5:1",
        (object) "G3:5:2",
        (object) "G3:5:3",
        (object) "G3:5:4",
        (object) "G3:5:5",
        (object) "G3:6:1",
        (object) "G3:6:2",
        (object) "G3:6:3",
        (object) "G3:6:4",
        (object) "G3:6:5",
        (object) "G4:1:1",
        (object) "G4:1:2",
        (object) "G4:1:3",
        (object) "G4:1:4",
        (object) "G4:2:1",
        (object) "G4:2:2",
        (object) "G4:2:3",
        (object) "G4:2:4",
        (object) "G4:3:1",
        (object) "G4:3:2",
        (object) "G4:3:3",
        (object) "G4:3:4",
        (object) "G4:4:1",
        (object) "G4:4:2",
        (object) "G4:4:3",
        (object) "G4:4:4",
        (object) "G5:1:1",
        (object) "G5:1:2",
        (object) "G5:1:3",
        (object) "G5:1:4",
        (object) "G5:2:1",
        (object) "G5:2:2",
        (object) "G5:2:3",
        (object) "G5:2:4",
        (object) "G5:3:1",
        (object) "G5:3:2",
        (object) "G5:3:3",
        (object) "G5:3:4",
        (object) "G5:4:1",
        (object) "G5:4:2",
        (object) "G5:4:3",
        (object) "G5:4:4",
        (object) "G5:5:1",
        (object) "G5:5:2",
        (object) "G5:5:3",
        (object) "G5:5:4",
        (object) "G5:6:1",
        (object) "G5:6:2",
        (object) "G5:6:3",
        (object) "G5:6:4",
        (object) "G6:1:1",
        (object) "G6:1:2",
        (object) "G6:1:3",
        (object) "G6:2:1",
        (object) "G6:2:2",
        (object) "G6:2:3",
        (object) "G6:3:1",
        (object) "G6:3:2",
        (object) "G6:3:3",
        (object) "G7:1:1",
        (object) "G7:1:2",
        (object) "G7:2:1",
        (object) "G7:2:2",
        (object) "G7:3:1",
        (object) "G7:3:2",
        (object) "G7:4:1",
        (object) "G7:4:2"
      };
    }

    public int Cltt { get; set; }

    public DateTime Clngaythang { get; set; }

    public string G0 { get; set; }

    public string G1 { get; set; }

    public string G21 { get; set; }

    public string G22 { get; set; }

    public string G31 { get; set; }

    public string G32 { get; set; }

    public string G33 { get; set; }

    public string G34 { get; set; }

    public string G35 { get; set; }

    public string G36 { get; set; }

    public string G41 { get; set; }

    public string G42 { get; set; }

    public string G43 { get; set; }

    public string G44 { get; set; }

    public string G51 { get; set; }

    public string G52 { get; set; }

    public string G53 { get; set; }

    public string G54 { get; set; }

    public string G55 { get; set; }

    public string G56 { get; set; }

    public string G61 { get; set; }

    public string G62 { get; set; }

    public string G63 { get; set; }

    public string G71 { get; set; }

    public string G72 { get; set; }

    public string G73 { get; set; }

    public string G74 { get; set; }

    public string CheckLotoCap(string loto)
    {
      string str;
      switch (loto)
      {
        case "00":
          str = "55";
          break;
        case "11":
          str = "66";
          break;
        case "22":
          str = "77";
          break;
        case "33":
          str = "88";
          break;
        case "44":
          str = "99";
          break;
        case "55":
          str = "00";
          break;
        case "66":
          str = "11";
          break;
        case "77":
          str = "22";
          break;
        case "88":
          str = "33";
          break;
        case "99":
          str = "44";
          break;
        default:
          str = loto.Substring(1, 1) + loto.Substring(0, 1);
          break;
      }
      return str;
    }

    public DataTable GetDayNew()
    {
      this._dtTable = new DataTable();
      try
      {
        this._dtTable = DataApp.db.GetData("tbloto_Get_New_Day");
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable Get_G0_By_Date(DateTime ngaybatdau, DateTime ngayketthuc)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("Tbloto_Get_G0_By_Date N'{0}',N'{1}'", (object) ngaybatdau.ToString("yyyy-MM-dd"), (object) ngayketthuc.ToString("yyyy-MM-dd"));
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

    public DataTable GetByDate(DateTime ngayThangKiemTra)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbloto_Get_By_Day N'{0}'", (object) ngayThangKiemTra.ToString("yyyy-MM-dd"));
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

    public DataTable GetNew()
    {
      this._dtTable = new DataTable();
      try
      {
        this._dtTable = DataApp.db.GetData("tbloto_Get_New");
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable GetLotoByNgayThang(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
      this._dtTable = new DataTable();
      string cmdText = "tbloto_Get_By_Date";
      try
      {
        Tbloto.Cmd = new SqlCommand(cmdText);
        Tbloto.Cmd.CommandType = CommandType.StoredProcedure;
        Tbloto.Cmd.Parameters.AddWithValue("@ngayBatdau", (object) ngayBatDau.ToString("yyyy-MM-dd"));
        Tbloto.Cmd.Parameters.AddWithValue("@ngayKetThuc", (object) ngayKetThuc.ToString("yyyy-MM-dd"));
        this._dtTable = DataApp.db.GetData(Tbloto.Cmd);
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable GetLotoByNgayThangAndThu(DateTime ngayBatDau, DateTime ngayKetThuc, int thuKiemtra)
    {
      this._dtTable = new DataTable();
      if (thuKiemtra != 1 && (uint) thuKiemtra > 0U)
        ++thuKiemtra;
      if (thuKiemtra == 0)
        thuKiemtra = 1;
      string sql = string.Format("tbloto_Get_By_Date_And_Thu N'{0}',N'{1}',N'{2}'", (object) ngayBatDau.ToString("yyyy-MM-dd"), (object) ngayKetThuc.ToString("yyyy-MM-dd"), (object) thuKiemtra);
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

    public DataTable GetTbVitriByNgayThang(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbVitri_Get_By_Date N'{0}',N'{1}'", (object) ngayBatDau.ToString("yyyy-MM-dd"), (object) ngayKetThuc.ToString("yyyy-MM-dd"));
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

    public DataTable GetTbKetQuaByNgayThang(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbketqua_Get_By_Date N'{0}',N'{1}'", (object) ngayBatDau.ToString("yyyy-MM-dd"), (object) ngayKetThuc.ToString("yyyy-MM-dd"));
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

    public DataTable GetLotoByNgayThangSoBanGhi(DateTime ngayBatDau, int soBanghi)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbloto_Get_By_Date_SoBanGhi N'{0}',N'{1}'", (object) ngayBatDau.ToString("yyyy-MM-dd"), (object) soBanghi);
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

    public DataTable TblotoGetByDateSoBanGhiTrovetruoc(DateTime ngayketThuc, int soBanghi)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbloto_Get_By_Date_SoBanGhi_Trovetruoc N'{0}',N'{1}'", (object) ngayketThuc.ToString("yyyy-MM-dd"), (object) soBanghi);
      try
      {
        this._dtTable = DataApp.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "001";
        FLogin.LogOutStatus = "0";
      }
      return this._dtTable;
    }

    public Tbloto GetInfor(int cltt)
    {
      Tbloto tbloto = new Tbloto();
      this._dtTable = new DataTable();
      string sql = "Select * From tbloto Where cltt=N'" + (object) cltt + "' ";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataApp.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbloto.Cltt = int.Parse(this._dtTable.Rows[0][nameof (cltt)].ToString());
          }
          catch (FormatException ex)
          {
            tbloto.Cltt = 0;
          }
          try
          {
            tbloto.Clngaythang = DateTime.Parse(this._dtTable.Rows[0]["clngaythang"].ToString());
          }
          catch (FormatException ex)
          {
          }
          tbloto.G0 = this._dtTable.Rows[0]["G0"].ToString();
          tbloto.G1 = this._dtTable.Rows[0]["G1"].ToString();
          tbloto.G21 = this._dtTable.Rows[0]["G21"].ToString();
          tbloto.G22 = this._dtTable.Rows[0]["G22"].ToString();
          tbloto.G31 = this._dtTable.Rows[0]["G31"].ToString();
          tbloto.G32 = this._dtTable.Rows[0]["G32"].ToString();
          tbloto.G33 = this._dtTable.Rows[0]["G33"].ToString();
          tbloto.G34 = this._dtTable.Rows[0]["G34"].ToString();
          tbloto.G35 = this._dtTable.Rows[0]["G35"].ToString();
          tbloto.G36 = this._dtTable.Rows[0]["G36"].ToString();
          tbloto.G41 = this._dtTable.Rows[0]["G41"].ToString();
          tbloto.G42 = this._dtTable.Rows[0]["G42"].ToString();
          tbloto.G43 = this._dtTable.Rows[0]["G43"].ToString();
          tbloto.G44 = this._dtTable.Rows[0]["G44"].ToString();
          tbloto.G51 = this._dtTable.Rows[0]["G51"].ToString();
          tbloto.G52 = this._dtTable.Rows[0]["G52"].ToString();
          tbloto.G53 = this._dtTable.Rows[0]["G53"].ToString();
          tbloto.G54 = this._dtTable.Rows[0]["G54"].ToString();
          tbloto.G55 = this._dtTable.Rows[0]["G55"].ToString();
          tbloto.G56 = this._dtTable.Rows[0]["G56"].ToString();
          tbloto.G61 = this._dtTable.Rows[0]["G61"].ToString();
          tbloto.G62 = this._dtTable.Rows[0]["G62"].ToString();
          tbloto.G63 = this._dtTable.Rows[0]["G63"].ToString();
          tbloto.G71 = this._dtTable.Rows[0]["G71"].ToString();
          tbloto.G72 = this._dtTable.Rows[0]["G72"].ToString();
          tbloto.G73 = this._dtTable.Rows[0]["G73"].ToString();
          tbloto.G74 = this._dtTable.Rows[0]["G74"].ToString();
        }
      }
      catch
      {
        FLogin.MsgId = "009";
        FLogin.LogOutStatus = "1";
      }
      return tbloto;
    }

    public DataTable GetBangDacBiet_HaiSoCuoi_ByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbloto_Get_GiaiDacBiet_HaiSoCuoi_By_Ngaythang N'{0}',N'{1}'", (object) ngayBatDau.ToString("yyyy-MM-dd"), (object) ngayKetThuc.ToString("yyyy-MM-dd"));
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
