// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbVitri
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
  public class TbVitri
  {
    public static string Vitri1 = "G0:1:1";
    public static string Vitri2 = "G0:1:1";
    public static int CbbLotoSelectId = 0;
    public static Decimal NumLui = Decimal.MinusOne;
    public static Decimal NumTien = Decimal.One;
    public static int Sothangkiemtra = 12;
    public static DateTime NgayBatDau = FMain.NgayKetQuaMoiNhat.AddMonths(-TbVitri.Sothangkiemtra);
    public static DateTime NgayKetThuc = FMain.NgayKetQuaMoiNhat;
    public SqlCommand cmd;
    private DataTable _dtTable;
    private string[] _msg;

    public int Clthutu { get; set; }

    public DateTime Clngaythang { get; set; }

    public string Cldai { get; set; }

    public string ClNguoithem { get; set; }

    public string G011 { get; set; }

    public string G012 { get; set; }

    public string G013 { get; set; }

    public string G014 { get; set; }

    public string G015 { get; set; }

    public string G111 { get; set; }

    public string G112 { get; set; }

    public string G113 { get; set; }

    public string G114 { get; set; }

    public string G115 { get; set; }

    public string G211 { get; set; }

    public string G212 { get; set; }

    public string G213 { get; set; }

    public string G214 { get; set; }

    public string G215 { get; set; }

    public string G221 { get; set; }

    public string G222 { get; set; }

    public string G223 { get; set; }

    public string G224 { get; set; }

    public string G225 { get; set; }

    public string G311 { get; set; }

    public string G312 { get; set; }

    public string G313 { get; set; }

    public string G314 { get; set; }

    public string G315 { get; set; }

    public string G321 { get; set; }

    public string G322 { get; set; }

    public string G323 { get; set; }

    public string G324 { get; set; }

    public string G325 { get; set; }

    public string G331 { get; set; }

    public string G332 { get; set; }

    public string G333 { get; set; }

    public string G334 { get; set; }

    public string G335 { get; set; }

    public string G341 { get; set; }

    public string G342 { get; set; }

    public string G343 { get; set; }

    public string G344 { get; set; }

    public string G345 { get; set; }

    public string G351 { get; set; }

    public string G352 { get; set; }

    public string G353 { get; set; }

    public string G354 { get; set; }

    public string G355 { get; set; }

    public string G361 { get; set; }

    public string G362 { get; set; }

    public string G363 { get; set; }

    public string G364 { get; set; }

    public string G365 { get; set; }

    public string G411 { get; set; }

    public string G412 { get; set; }

    public string G413 { get; set; }

    public string G414 { get; set; }

    public string G421 { get; set; }

    public string G422 { get; set; }

    public string G423 { get; set; }

    public string G424 { get; set; }

    public string G431 { get; set; }

    public string G432 { get; set; }

    public string G433 { get; set; }

    public string G434 { get; set; }

    public string G441 { get; set; }

    public string G442 { get; set; }

    public string G443 { get; set; }

    public string G444 { get; set; }

    public string G511 { get; set; }

    public string G512 { get; set; }

    public string G513 { get; set; }

    public string G514 { get; set; }

    public string G521 { get; set; }

    public string G522 { get; set; }

    public string G523 { get; set; }

    public string G524 { get; set; }

    public string G531 { get; set; }

    public string G532 { get; set; }

    public string G533 { get; set; }

    public string G534 { get; set; }

    public string G541 { get; set; }

    public string G542 { get; set; }

    public string G543 { get; set; }

    public string G544 { get; set; }

    public string G551 { get; set; }

    public string G552 { get; set; }

    public string G553 { get; set; }

    public string G554 { get; set; }

    public string G561 { get; set; }

    public string G562 { get; set; }

    public string G563 { get; set; }

    public string G564 { get; set; }

    public string G611 { get; set; }

    public string G612 { get; set; }

    public string G613 { get; set; }

    public string G621 { get; set; }

    public string G622 { get; set; }

    public string G623 { get; set; }

    public string G631 { get; set; }

    public string G632 { get; set; }

    public string G633 { get; set; }

    public string G711 { get; set; }

    public string G712 { get; set; }

    public string G721 { get; set; }

    public string G722 { get; set; }

    public string G731 { get; set; }

    public string G732 { get; set; }

    public string G741 { get; set; }

    public string G742 { get; set; }

    public DataTable GetListInfor()
    {
      this._dtTable = new DataTable();
      try
      {
        this._dtTable = DataApp.db.GetData("SELECT ROW_NUMBER() OVER(ORDER BY clthutu) AS STT,* From tbVitri");
      }
      catch
      {
      }
      return this._dtTable;
    }

    public DataTable GetListInfor(int clthutu)
    {
      this._dtTable = new DataTable();
      string sql = "Select * From tbVitri Where clthutu Like N'%" + (object) clthutu + "%' ";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataApp.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable GetBangDacBietByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbketqua_Get_GiaiDacBiet_By_Ngaythang N'{0}',N'{1}'", (object) ngayBatDau.ToString("yyyy-MM-dd"), (object) ngayKetThuc.ToString("yyyy-MM-dd"));
      try
      {
        this._dtTable = DataApp.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable GetTbVitriByNgayThangThu(DateTime ngayBatdau, DateTime ngayKetthuc, int thu)
    {
      this.cmd = new SqlCommand("TbVitri_GetBy_NgayThang_Thu");
      this.cmd.CommandType = CommandType.StoredProcedure;
      this.cmd.Parameters.AddWithValue("@ngay_Batdau", (object) ngayBatdau.ToString("yyyy-MM-dd"));
      this.cmd.Parameters.AddWithValue("@ngay_Ketthuc", (object) ngayKetthuc.ToString("yyyy-MM-dd"));
      this.cmd.Parameters.AddWithValue("@thu_Cantim", (object) thu);
      return DataApp.db.GetData(this.cmd);
    }

    public DataTable GetBangDacBiet_HaiSoCuoi_ByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbketqua_Get_GiaiDacBiet_HaiSoCuoi_By_Ngaythang N'{0}',N'{1}'", (object) ngayBatDau.ToString("yyyy-MM-dd"), (object) ngayKetThuc.ToString("yyyy-MM-dd"));
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

    public TbVitri GetTopNewInfo()
    {
      TbVitri tbVitri = new TbVitri();
      string sql = "tbVitri_Get_Top_New";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataApp.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbVitri.Clthutu = int.Parse(this._dtTable.Rows[0]["clthutu"].ToString());
          }
          catch (FormatException ex)
          {
            tbVitri.Clthutu = 0;
          }
          try
          {
            tbVitri.Clngaythang = DateTime.Parse(this._dtTable.Rows[0]["clngaythang"].ToString());
          }
          catch (FormatException ex)
          {
          }
          tbVitri.Cldai = this._dtTable.Rows[0]["cldai"].ToString();
          tbVitri.G011 = this._dtTable.Rows[0]["G0:1:1"].ToString();
          tbVitri.G012 = this._dtTable.Rows[0]["G0:1:2"].ToString();
          tbVitri.G013 = this._dtTable.Rows[0]["G0:1:3"].ToString();
          tbVitri.G014 = this._dtTable.Rows[0]["G0:1:4"].ToString();
          tbVitri.G015 = this._dtTable.Rows[0]["G0:1:5"].ToString();
          tbVitri.G111 = this._dtTable.Rows[0]["G1:1:1"].ToString();
          tbVitri.G112 = this._dtTable.Rows[0]["G1:1:2"].ToString();
          tbVitri.G113 = this._dtTable.Rows[0]["G1:1:3"].ToString();
          tbVitri.G114 = this._dtTable.Rows[0]["G1:1:4"].ToString();
          tbVitri.G115 = this._dtTable.Rows[0]["G1:1:5"].ToString();
          tbVitri.G211 = this._dtTable.Rows[0]["G2:1:1"].ToString();
          tbVitri.G212 = this._dtTable.Rows[0]["G2:1:2"].ToString();
          tbVitri.G213 = this._dtTable.Rows[0]["G2:1:3"].ToString();
          tbVitri.G214 = this._dtTable.Rows[0]["G2:1:4"].ToString();
          tbVitri.G215 = this._dtTable.Rows[0]["G2:1:5"].ToString();
          tbVitri.G221 = this._dtTable.Rows[0]["G2:2:1"].ToString();
          tbVitri.G222 = this._dtTable.Rows[0]["G2:2:2"].ToString();
          tbVitri.G223 = this._dtTable.Rows[0]["G2:2:3"].ToString();
          tbVitri.G224 = this._dtTable.Rows[0]["G2:2:4"].ToString();
          tbVitri.G225 = this._dtTable.Rows[0]["G2:2:5"].ToString();
          tbVitri.G311 = this._dtTable.Rows[0]["G3:1:1"].ToString();
          tbVitri.G312 = this._dtTable.Rows[0]["G3:1:2"].ToString();
          tbVitri.G313 = this._dtTable.Rows[0]["G3:1:3"].ToString();
          tbVitri.G314 = this._dtTable.Rows[0]["G3:1:4"].ToString();
          tbVitri.G315 = this._dtTable.Rows[0]["G3:1:5"].ToString();
          tbVitri.G321 = this._dtTable.Rows[0]["G3:2:1"].ToString();
          tbVitri.G322 = this._dtTable.Rows[0]["G3:2:2"].ToString();
          tbVitri.G323 = this._dtTable.Rows[0]["G3:2:3"].ToString();
          tbVitri.G324 = this._dtTable.Rows[0]["G3:2:4"].ToString();
          tbVitri.G325 = this._dtTable.Rows[0]["G3:2:5"].ToString();
          tbVitri.G331 = this._dtTable.Rows[0]["G3:3:1"].ToString();
          tbVitri.G332 = this._dtTable.Rows[0]["G3:3:2"].ToString();
          tbVitri.G333 = this._dtTable.Rows[0]["G3:3:3"].ToString();
          tbVitri.G334 = this._dtTable.Rows[0]["G3:3:4"].ToString();
          tbVitri.G335 = this._dtTable.Rows[0]["G3:3:5"].ToString();
          tbVitri.G341 = this._dtTable.Rows[0]["G3:4:1"].ToString();
          tbVitri.G342 = this._dtTable.Rows[0]["G3:4:2"].ToString();
          tbVitri.G343 = this._dtTable.Rows[0]["G3:4:3"].ToString();
          tbVitri.G344 = this._dtTable.Rows[0]["G3:4:4"].ToString();
          tbVitri.G345 = this._dtTable.Rows[0]["G3:4:5"].ToString();
          tbVitri.G351 = this._dtTable.Rows[0]["G3:5:1"].ToString();
          tbVitri.G352 = this._dtTable.Rows[0]["G3:5:2"].ToString();
          tbVitri.G353 = this._dtTable.Rows[0]["G3:5:3"].ToString();
          tbVitri.G354 = this._dtTable.Rows[0]["G3:5:4"].ToString();
          tbVitri.G355 = this._dtTable.Rows[0]["G3:5:5"].ToString();
          tbVitri.G361 = this._dtTable.Rows[0]["G3:6:1"].ToString();
          tbVitri.G362 = this._dtTable.Rows[0]["G3:6:2"].ToString();
          tbVitri.G363 = this._dtTable.Rows[0]["G3:6:3"].ToString();
          tbVitri.G364 = this._dtTable.Rows[0]["G3:6:4"].ToString();
          tbVitri.G365 = this._dtTable.Rows[0]["G3:6:5"].ToString();
          tbVitri.G411 = this._dtTable.Rows[0]["G4:1:1"].ToString();
          tbVitri.G412 = this._dtTable.Rows[0]["G4:1:2"].ToString();
          tbVitri.G413 = this._dtTable.Rows[0]["G4:1:3"].ToString();
          tbVitri.G414 = this._dtTable.Rows[0]["G4:1:4"].ToString();
          tbVitri.G421 = this._dtTable.Rows[0]["G4:2:1"].ToString();
          tbVitri.G422 = this._dtTable.Rows[0]["G4:2:2"].ToString();
          tbVitri.G423 = this._dtTable.Rows[0]["G4:2:3"].ToString();
          tbVitri.G424 = this._dtTable.Rows[0]["G4:2:4"].ToString();
          tbVitri.G431 = this._dtTable.Rows[0]["G4:3:1"].ToString();
          tbVitri.G432 = this._dtTable.Rows[0]["G4:3:2"].ToString();
          tbVitri.G433 = this._dtTable.Rows[0]["G4:3:3"].ToString();
          tbVitri.G434 = this._dtTable.Rows[0]["G4:3:4"].ToString();
          tbVitri.G441 = this._dtTable.Rows[0]["G4:4:1"].ToString();
          tbVitri.G442 = this._dtTable.Rows[0]["G4:4:2"].ToString();
          tbVitri.G443 = this._dtTable.Rows[0]["G4:4:3"].ToString();
          tbVitri.G444 = this._dtTable.Rows[0]["G4:4:4"].ToString();
          tbVitri.G511 = this._dtTable.Rows[0]["G5:1:1"].ToString();
          tbVitri.G512 = this._dtTable.Rows[0]["G5:1:2"].ToString();
          tbVitri.G513 = this._dtTable.Rows[0]["G5:1:3"].ToString();
          tbVitri.G514 = this._dtTable.Rows[0]["G5:1:4"].ToString();
          tbVitri.G521 = this._dtTable.Rows[0]["G5:2:1"].ToString();
          tbVitri.G522 = this._dtTable.Rows[0]["G5:2:2"].ToString();
          tbVitri.G523 = this._dtTable.Rows[0]["G5:2:3"].ToString();
          tbVitri.G524 = this._dtTable.Rows[0]["G5:2:4"].ToString();
          tbVitri.G531 = this._dtTable.Rows[0]["G5:3:1"].ToString();
          tbVitri.G532 = this._dtTable.Rows[0]["G5:3:2"].ToString();
          tbVitri.G533 = this._dtTable.Rows[0]["G5:3:3"].ToString();
          tbVitri.G534 = this._dtTable.Rows[0]["G5:3:4"].ToString();
          tbVitri.G541 = this._dtTable.Rows[0]["G5:4:1"].ToString();
          tbVitri.G542 = this._dtTable.Rows[0]["G5:4:2"].ToString();
          tbVitri.G543 = this._dtTable.Rows[0]["G5:4:3"].ToString();
          tbVitri.G544 = this._dtTable.Rows[0]["G5:4:4"].ToString();
          tbVitri.G551 = this._dtTable.Rows[0]["G5:5:1"].ToString();
          tbVitri.G552 = this._dtTable.Rows[0]["G5:5:2"].ToString();
          tbVitri.G553 = this._dtTable.Rows[0]["G5:5:3"].ToString();
          tbVitri.G554 = this._dtTable.Rows[0]["G5:5:4"].ToString();
          tbVitri.G561 = this._dtTable.Rows[0]["G5:6:1"].ToString();
          tbVitri.G562 = this._dtTable.Rows[0]["G5:6:2"].ToString();
          tbVitri.G563 = this._dtTable.Rows[0]["G5:6:3"].ToString();
          tbVitri.G564 = this._dtTable.Rows[0]["G5:6:4"].ToString();
          tbVitri.G611 = this._dtTable.Rows[0]["G6:1:1"].ToString();
          tbVitri.G612 = this._dtTable.Rows[0]["G6:1:2"].ToString();
          tbVitri.G613 = this._dtTable.Rows[0]["G6:1:3"].ToString();
          tbVitri.G621 = this._dtTable.Rows[0]["G6:2:1"].ToString();
          tbVitri.G622 = this._dtTable.Rows[0]["G6:2:2"].ToString();
          tbVitri.G623 = this._dtTable.Rows[0]["G6:2:3"].ToString();
          tbVitri.G631 = this._dtTable.Rows[0]["G6:3:1"].ToString();
          tbVitri.G632 = this._dtTable.Rows[0]["G6:3:2"].ToString();
          tbVitri.G633 = this._dtTable.Rows[0]["G6:3:3"].ToString();
          tbVitri.G711 = this._dtTable.Rows[0]["G7:1:1"].ToString();
          tbVitri.G712 = this._dtTable.Rows[0]["G7:1:2"].ToString();
          tbVitri.G721 = this._dtTable.Rows[0]["G7:2:1"].ToString();
          tbVitri.G722 = this._dtTable.Rows[0]["G7:2:2"].ToString();
          tbVitri.G731 = this._dtTable.Rows[0]["G7:3:1"].ToString();
          tbVitri.G732 = this._dtTable.Rows[0]["G7:3:2"].ToString();
          tbVitri.G741 = this._dtTable.Rows[0]["G7:4:1"].ToString();
          tbVitri.G742 = this._dtTable.Rows[0]["G7:4:2"].ToString();
        }
      }
      catch
      {
        this._msg = ClMain.Get_Msg("009");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Application.Exit();
      }
      return tbVitri;
    }

    public DataTable GetTopNew()
    {
      this._dtTable = new DataTable();
      string sql = "tbVitri_Get_Top_New";
      try
      {
        this._dtTable = DataApp.db.GetData(sql);
      }
      catch
      {
        this._msg = ClMain.Get_Msg("009");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Application.Exit();
      }
      return this._dtTable;
    }

    public DataTable GetVitriByDateAndSobanghi(DateTime ngayKiemTra, int sobanghi)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbVitri_Get_By_Date_and_sobanghi N'{0}',{1}", (object) ngayKiemTra.ToString("yyyy-MM-dd"), (object) sobanghi);
      try
      {
        this._dtTable = DataApp.db.GetData(sql);
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this._dtTable;
    }

    public DataTable GetByDay(DateTime ngayKiemTra)
    {
      this._dtTable = new DataTable();
      string sql = string.Format("tbVitri_Get_By_Day N'{0}'", (object) ngayKiemTra.ToString("yyyy-MM-dd"));
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

    public DataTable GetByDateAndVt1Vt2(DateTime ngayBatDau, DateTime ngayKetThuc, string vt1, string vt2)
    {
      this._dtTable = new DataTable();
      string sql = "select ROW_NUMBER() OVER(ORDER BY clthutu) as STT, clngaythang,[" + vt1 + "], [" + vt2 + "] from tbVitri where clngaythang between N'" + ngayBatDau.ToString("yyyy-MM-dd") + "' and N'" + ngayKetThuc.ToString("yyyy-MM-dd") + "' order by clngaythang asc";
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
