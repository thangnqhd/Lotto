// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbLoaiLoto
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
  internal class TbLoaiLoto
  {
    private DataTable _dtTable;
    public TbLoaiLoto obj;

    public string Tendangnhap { get; set; }

    public bool Solanve { get; set; }

    public bool Sonhayve { get; set; }

    public bool Ngaychuara { get; set; }

    public bool Gantrongkhung { get; set; }

    public bool Gan2nam { get; set; }

    public bool Diemtanxuat { get; set; }

    public bool Diemgan { get; set; }

    public int SolanveNho { get; set; }

    public int SolanveLon { get; set; }

    public int SonhayveNho { get; set; }

    public int SonhayveLon { get; set; }

    public int NgaychuaraNho { get; set; }

    public int NgaychuaraLon { get; set; }

    public int GantrongkhungNho { get; set; }

    public int GantrongkhungLon { get; set; }

    public int Gan2namNho { get; set; }

    public int Gan2namLon { get; set; }

    public Decimal DiemtanxuatNho { get; set; }

    public Decimal DiemtanxuatLon { get; set; }

    public Decimal DiemganNho { get; set; }

    public Decimal DiemganLon { get; set; }

    public int Biendongaykiemtra { get; set; }

    public TbLoaiLoto()
    {
    }

    public TbLoaiLoto(string tendangnhap, bool solanve, bool sonhayve, bool ngaychuara, bool gantrongkhung, bool gan2nam, bool diemtanxuat, bool diemgan, int solanveNho, int solanveLon, int sonhayveNho, int sonhayveLon, int ngaychuaraNho, int ngaychuaraLon, int gantrongkhungNho, int gantrongkhungLon, int gan2namNho, int gan2namLon, Decimal diemtanxuatNho, Decimal diemtanxuatLon, Decimal diemgannho, Decimal diemganLon, int biendongaykiemtra)
    {
      this.Tendangnhap = tendangnhap;
      this.Solanve = solanve;
      this.Sonhayve = sonhayve;
      this.Ngaychuara = ngaychuara;
      this.Gantrongkhung = gantrongkhung;
      this.Gan2nam = gan2nam;
      this.Diemtanxuat = diemtanxuat;
      this.Diemgan = diemgan;
      this.SolanveNho = solanveNho;
      this.SolanveLon = solanveLon;
      this.SonhayveNho = sonhayveNho;
      this.SonhayveLon = sonhayveLon;
      this.NgaychuaraNho = ngaychuaraNho;
      this.NgaychuaraLon = ngaychuaraLon;
      this.GantrongkhungNho = gantrongkhungNho;
      this.GantrongkhungLon = gantrongkhungLon;
      this.Gan2namNho = gan2namNho;
      this.Gan2namLon = gan2namLon;
      this.DiemtanxuatNho = diemtanxuatNho;
      this.DiemtanxuatLon = diemtanxuatLon;
      this.DiemganNho = diemgannho;
      this.DiemganLon = diemganLon;
      this.Biendongaykiemtra = biendongaykiemtra;
    }

    public TbLoaiLoto(TbLoaiLoto obj)
    {
      this.Tendangnhap = obj.Tendangnhap;
      this.Solanve = obj.Solanve;
      this.Sonhayve = obj.Sonhayve;
      this.Ngaychuara = obj.Ngaychuara;
      this.Gantrongkhung = obj.Gantrongkhung;
      this.Gan2nam = obj.Gan2nam;
      this.Diemtanxuat = obj.Diemtanxuat;
      this.Diemgan = obj.Diemgan;
      this.SolanveNho = obj.SolanveNho;
      this.SolanveLon = obj.SolanveLon;
      this.SonhayveNho = obj.SonhayveNho;
      this.SonhayveLon = obj.SonhayveLon;
      this.NgaychuaraNho = obj.NgaychuaraNho;
      this.NgaychuaraLon = obj.NgaychuaraLon;
      this.GantrongkhungNho = obj.GantrongkhungNho;
      this.GantrongkhungLon = obj.GantrongkhungLon;
      this.Gan2namNho = obj.Gan2namNho;
      this.Gan2namLon = obj.Gan2namLon;
      this.DiemtanxuatNho = obj.DiemtanxuatNho;
      this.DiemtanxuatLon = obj.DiemtanxuatLon;
      this.DiemganNho = obj.DiemganNho;
      this.DiemganLon = obj.DiemganLon;
      this.Biendongaykiemtra = obj.Biendongaykiemtra;
    }

    public bool Insert(TbLoaiLoto obj)
    {
      string cmdText = string.Format("TBloailoto_Insert N'{0}', N'{1}', N'{2}', N'{3}', N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}',N'{20}',N'{21}',N'{22}'", (object) obj.Tendangnhap, (object) obj.SolanveNho, (object) obj.SolanveLon, (object) obj.SonhayveNho, (object) obj.SonhayveLon, (object) obj.NgaychuaraNho, (object) obj.NgaychuaraLon, (object) obj.GantrongkhungNho, (object) obj.GantrongkhungLon, (object) obj.Gan2namNho, (object) obj.Gan2namLon, (object) obj.DiemtanxuatNho, (object) obj.DiemtanxuatLon, (object) obj.DiemganNho, (object) obj.DiemganLon, (object) obj.Solanve, (object) obj.Sonhayve, (object) obj.Ngaychuara, (object) obj.Gantrongkhung, (object) obj.Gan2nam, (object) obj.Diemtanxuat, (object) obj.Diemgan, (object) obj.Biendongaykiemtra);
      try
      {
        SqlCommand cmd = new SqlCommand(cmdText);
        cmd.CommandType = CommandType.Text;
        DataWeb.db.ExecuteNonQuery(cmd);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public TbLoaiLoto GetBuyUsername(string tenDangnhap)
    {
      this.obj = new TbLoaiLoto();
      this._dtTable = new DataTable();
      string sql = string.Format("TbLoailoto_Get_By_tendangnhap N'{0}'", (object) tenDangnhap);
      try
      {
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          this.obj.Tendangnhap = this._dtTable.Rows[0]["tendangnhap"].ToString();
          try
          {
            this.obj.Solanve = Convert.ToBoolean(this._dtTable.Rows[0]["solanve"].ToString());
          }
          catch (Exception ex)
          {
            this.obj.Solanve = false;
          }
          try
          {
            this.obj.Sonhayve = Convert.ToBoolean(this._dtTable.Rows[0]["sonhayve"].ToString());
          }
          catch (Exception ex)
          {
            this.obj.Sonhayve = false;
          }
          try
          {
            this.obj.Ngaychuara = Convert.ToBoolean(this._dtTable.Rows[0]["ngaychuara"].ToString());
          }
          catch (Exception ex)
          {
            this.obj.Ngaychuara = false;
          }
          try
          {
            this.obj.Gantrongkhung = Convert.ToBoolean(this._dtTable.Rows[0]["gantrongkhung"].ToString());
          }
          catch (Exception ex)
          {
            this.obj.Gantrongkhung = false;
          }
          try
          {
            this.obj.Gan2nam = Convert.ToBoolean(this._dtTable.Rows[0]["gan2nam"].ToString());
          }
          catch (Exception ex)
          {
            this.obj.Gan2nam = false;
          }
          try
          {
            this.obj.Diemtanxuat = Convert.ToBoolean(this._dtTable.Rows[0]["diemtanxuat"].ToString());
          }
          catch (Exception ex)
          {
            this.obj.Diemtanxuat = false;
          }
          try
          {
            this.obj.Diemgan = Convert.ToBoolean(this._dtTable.Rows[0]["diemgan"].ToString());
          }
          catch (Exception ex)
          {
            this.obj.Diemgan = false;
          }
          this.obj.SolanveNho = Convert.ToInt32(this._dtTable.Rows[0]["solanveNho"].ToString());
          this.obj.SolanveLon = Convert.ToInt32(this._dtTable.Rows[0]["solanveLon"].ToString());
          this.obj.SonhayveNho = Convert.ToInt32(this._dtTable.Rows[0]["sonhayveNho"].ToString());
          this.obj.SonhayveLon = Convert.ToInt32(this._dtTable.Rows[0]["sonhayveLon"].ToString());
          this.obj.NgaychuaraNho = Convert.ToInt32(this._dtTable.Rows[0]["ngaychuaraNho"].ToString());
          this.obj.NgaychuaraLon = Convert.ToInt32(this._dtTable.Rows[0]["ngaychuaraLon"].ToString());
          this.obj.GantrongkhungNho = Convert.ToInt32(this._dtTable.Rows[0]["gantrongkhungNho"].ToString());
          this.obj.GantrongkhungLon = Convert.ToInt32(this._dtTable.Rows[0]["gantrongkhungLon"].ToString());
          this.obj.Gan2namNho = Convert.ToInt32(this._dtTable.Rows[0]["gan2namNho"].ToString());
          this.obj.Gan2namLon = Convert.ToInt32(this._dtTable.Rows[0]["gan2namLon"].ToString());
          this.obj.DiemtanxuatNho = Convert.ToDecimal(this._dtTable.Rows[0]["diemtanxuatNho"].ToString());
          this.obj.DiemtanxuatLon = Convert.ToDecimal(this._dtTable.Rows[0]["diemtanxuatLon"].ToString());
          this.obj.DiemganNho = Convert.ToDecimal(this._dtTable.Rows[0]["diemganNho"].ToString());
          this.obj.DiemganLon = Convert.ToDecimal(this._dtTable.Rows[0]["diemganLon"].ToString());
          this.obj.Biendongaykiemtra = Convert.ToInt32(this._dtTable.Rows[0]["biendongaykiemtra"].ToString());
        }
        else
        {
          this.obj.Tendangnhap = tenDangnhap;
          this.obj.Solanve = false;
          this.obj.Sonhayve = false;
          this.obj.Ngaychuara = false;
          this.obj.Gantrongkhung = false;
          this.obj.Gan2nam = false;
          this.obj.Diemtanxuat = false;
          this.obj.Diemgan = false;
          this.obj.SolanveNho = 0;
          this.obj.SolanveLon = 10;
          this.obj.SonhayveNho = 0;
          this.obj.SonhayveLon = 10;
          this.obj.NgaychuaraNho = 0;
          this.obj.NgaychuaraLon = 10;
          this.obj.GantrongkhungNho = 0;
          this.obj.GantrongkhungLon = 10;
          this.obj.Gan2namNho = 0;
          this.obj.Gan2namLon = 10;
          this.obj.DiemtanxuatNho = Decimal.Zero;
          this.obj.DiemtanxuatLon = new Decimal(10);
          this.obj.DiemganNho = Decimal.Zero;
          this.obj.DiemganLon = new Decimal(11);
          this.obj.Biendongaykiemtra = 36;
        }
      }
      catch
      {
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
      return this.obj;
    }
  }
}
