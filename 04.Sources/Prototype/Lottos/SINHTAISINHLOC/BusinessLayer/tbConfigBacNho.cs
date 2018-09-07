// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbConfigBacNho
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
  public class tbConfigBacNho
  {
    private DataTable _dtTable;

    public int Stt { get; set; }

    public string MaTaiKhoan { get; set; }

    public int KhungDanhLoCapNuoi { get; set; }

    public int KhungDanhBachThuNuoi { get; set; }

    public int KhungDanhDacBietNuoi { get; set; }

    public int KhungLoXien2 { get; set; }

    public int HienThiNgayVe { get; set; }

    public int BiendoTrungDau { get; set; }

    public int BiendoTrungDuoi { get; set; }

    public int SoBanGhi { get; set; }

    public int TheoGiai { get; set; }

    public int TheoNhay { get; set; }

    public int TheoCap { get; set; }

    public int DauCam { get; set; }

    public int DuoiCam { get; set; }

    public int CapCungVe { get; set; }

    public int DanCungVe { get; set; }

    public int BacNhoTheoThu { get; set; }

    public int ThongKeCauDep { get; set; }

    public DateTime NgayThem { get; set; }

    public DataTable GetListInfor(int stt)
    {
      this._dtTable = new DataTable();
      string sql = "Select * From tbConfigBacNho Where stt Like N'%" + (object) stt + "%' ";
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

    public tbConfigBacNho GetInfor(int maTaiKhoan)
    {
      tbConfigBacNho tbConfigBacNho = new tbConfigBacNho();
      this._dtTable = new DataTable();
      string sql = string.Format("tbConfigBacNho_Get_Info_By_UserID {0}", (object) maTaiKhoan);
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            tbConfigBacNho.Stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.Stt = 1;
          }
          tbConfigBacNho.MaTaiKhoan = this._dtTable.Rows[0][nameof (maTaiKhoan)].ToString();
          try
          {
            tbConfigBacNho.KhungDanhLoCapNuoi = int.Parse(this._dtTable.Rows[0]["khungDanhLoCapNuoi"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.KhungDanhLoCapNuoi = 1;
          }
          try
          {
            tbConfigBacNho.KhungDanhBachThuNuoi = int.Parse(this._dtTable.Rows[0]["KhungDanhBacThuNuoi"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.KhungDanhBachThuNuoi = 1;
          }
          try
          {
            tbConfigBacNho.KhungDanhDacBietNuoi = int.Parse(this._dtTable.Rows[0]["khungDanhDacBietNuoi"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.KhungDanhDacBietNuoi = 1;
          }
          try
          {
            tbConfigBacNho.KhungLoXien2 = int.Parse(this._dtTable.Rows[0]["khungLoXien"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.KhungLoXien2 = 1;
          }
          tbConfigBacNho.HienThiNgayVe = this._dtTable.Rows[0]["hienThiNgayVe"].ToString() == "True" ? 1 : 0;
          try
          {
            tbConfigBacNho.BiendoTrungDau = int.Parse(this._dtTable.Rows[0]["biendoTrungDau"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.BiendoTrungDau = 1;
          }
          try
          {
            tbConfigBacNho.BiendoTrungDuoi = int.Parse(this._dtTable.Rows[0]["biendoTrungDuoi"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.BiendoTrungDuoi = 1;
          }
          try
          {
            tbConfigBacNho.SoBanGhi = int.Parse(this._dtTable.Rows[0]["soBanGhi"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.SoBanGhi = 1;
          }
          try
          {
            tbConfigBacNho.TheoGiai = int.Parse(this._dtTable.Rows[0]["theoGiai"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.TheoGiai = 1;
          }
          try
          {
            tbConfigBacNho.TheoNhay = int.Parse(this._dtTable.Rows[0]["theoNhay"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.TheoNhay = 1;
          }
          try
          {
            tbConfigBacNho.TheoCap = int.Parse(this._dtTable.Rows[0]["theoCap"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.TheoCap = 1;
          }
          try
          {
            tbConfigBacNho.DauCam = int.Parse(this._dtTable.Rows[0]["dauCam"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.DauCam = 1;
          }
          try
          {
            tbConfigBacNho.DuoiCam = int.Parse(this._dtTable.Rows[0]["duoiCam"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.DuoiCam = 1;
          }
          try
          {
            tbConfigBacNho.CapCungVe = int.Parse(this._dtTable.Rows[0]["capCungVe"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.CapCungVe = 1;
          }
          try
          {
            tbConfigBacNho.DanCungVe = int.Parse(this._dtTable.Rows[0]["dancungve"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.DanCungVe = 12;
          }
          try
          {
            tbConfigBacNho.BacNhoTheoThu = int.Parse(this._dtTable.Rows[0]["bacnhotheothu"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.BacNhoTheoThu = 21;
          }
          try
          {
            tbConfigBacNho.ThongKeCauDep = int.Parse(this._dtTable.Rows[0]["thongkecaudep"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigBacNho.ThongKeCauDep = 28;
          }
          try
          {
            tbConfigBacNho.NgayThem = DateTime.Parse(this._dtTable.Rows[0]["ngayThem"].ToString());
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
      return tbConfigBacNho;
    }

    public int Update(tbConfigBacNho obj)
    {
      int num = 0;
      string cmdText = string.Format("tbConfigBacNho_Update N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}', N'{13}',N'{14}',N'{15}',N'{16}',N'{17}'", (object) obj.Stt, (object) obj.KhungDanhLoCapNuoi, (object) obj.KhungDanhBachThuNuoi, (object) obj.KhungDanhDacBietNuoi, (object) obj.HienThiNgayVe, (object) obj.BiendoTrungDau, (object) obj.BiendoTrungDuoi, (object) obj.SoBanGhi, (object) obj.TheoGiai, (object) obj.TheoNhay, (object) obj.TheoCap, (object) obj.DauCam, (object) obj.DuoiCam, (object) obj.CapCungVe, (object) obj.KhungLoXien2, (object) obj.DanCungVe, (object) obj.BacNhoTheoThu, (object) obj.ThongKeCauDep);
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

    public int Delete(tbConfigBacNho obj)
    {
      int num = 0;
      string cmdText = string.Format("tbConfigBacNho_Delete N'{0}'", (object) obj.Stt);
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
  }
}
