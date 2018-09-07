// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbLoxien
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TbLoxien
  {
    private DataTable dataTable;

    public int stt { get; set; }

    public string loai { get; set; }

    public string boSo { get; set; }

    public int soLanve { get; set; }

    public Decimal chuKy { get; set; }

    public int ngayChuaRa { get; set; }

    public int max365ngay { get; set; }

    public int maxGan { get; set; }

    public Decimal diemGan { get; set; }

    public int veNgay { get; set; }

    public DateTime creatDate { get; set; }

    public bool InsertBoSo(string _loai, string _boSo, string _soLanve, string _chuKy, string _ngayChuaRa, string _max365ngay, string _maxGan, string _diemGan, string _diemTanXuat, string _veNgay)
    {
      string cmdText = string.Format("TbLoxien_Insert N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}',N'{7}',N'{8}',N'{9}'", (object) _loai, (object) _boSo, (object) _soLanve, (object) _chuKy, (object) _ngayChuaRa, (object) _max365ngay, (object) _maxGan, (object) _diemGan, (object) _diemTanXuat, (object) _veNgay);
      try
      {
        SqlCommand sqlCommand = new SqlCommand(cmdText);
        sqlCommand.CommandType = CommandType.Text;
        SqlCommand cmd = sqlCommand;
        DataApp.db.ExecuteNonQuery(cmd);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public DataTable GetAllByLoaiLoto(string loaiLoto)
    {
      this.dataTable = new DataTable();
      string sql = string.Format("TbLoxien_Get_All N'{0}'", (object) loaiLoto);
      try
      {
        this.dataTable = DataApp.db.GetData(sql);
      }
      catch
      {
        throw;
      }
      return this.dataTable;
    }

    public DataTable GetAllByLoaiLoto_Sql(string _sql)
    {
      this.dataTable = new DataTable();
      try
      {
        this.dataTable = DataApp.db.GetData(_sql);
      }
      catch
      {
        throw;
      }
      return this.dataTable;
    }

    public DataTable GetAllForBacNho()
    {
      this.dataTable = new DataTable();
      string sql = string.Format("TbLoxien_Get_All_For_BacNho");
      try
      {
        this.dataTable = DataApp.db.GetData(sql);
      }
      catch
      {
        throw;
      }
      return this.dataTable;
    }
  }
}
