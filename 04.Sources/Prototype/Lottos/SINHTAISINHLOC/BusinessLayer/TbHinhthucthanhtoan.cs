// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbHinhthucthanhtoan
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;
using System.Windows.Forms;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.BusinessLayer
{
  public class TbHinhthucthanhtoan
  {
    private DataTable _dtTable;

    public int stt { get; set; }

    public string HinhthucThanhToan { get; set; }

    public string Mota { get; set; }

    public string MaTiente { get; set; }

    public string HesoQuyDoi { get; set; }

    public string TiGia { get; set; }

    public int Status { get; set; }

    public DateTime NgayCapnhat { get; set; }

    public DataTable GetAll()
    {
      this._dtTable = new DataTable();
      string sql = "Select * From tbHinhthucthanhtoan Where status=1";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
      }
      catch
      {
        int num = (int) MessageBox.Show(Resources.tbHinhthucthanhtoan_GetInfor_KHÔNG_LẤY_ĐƯỢC_THÔNG_TIN, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      return this._dtTable;
    }

    public TbHinhthucthanhtoan GetInfor(string maTiente)
    {
      TbHinhthucthanhtoan hinhthucthanhtoan = new TbHinhthucthanhtoan();
      this._dtTable = new DataTable();
      string sql = "Select * From tbHinhthucthanhtoan Where maTiente=N'" + maTiente + "' ";
      try
      {
        this._dtTable = new DataTable();
        this._dtTable = DataWeb.db.GetData(sql);
        if (this._dtTable.Rows.Count > 0)
        {
          try
          {
            hinhthucthanhtoan.stt = int.Parse(this._dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            hinhthucthanhtoan.stt = 0;
          }
          hinhthucthanhtoan.HinhthucThanhToan = this._dtTable.Rows[0]["hinhthucThanhToan"].ToString();
          hinhthucthanhtoan.Mota = this._dtTable.Rows[0]["mota"].ToString();
          hinhthucthanhtoan.MaTiente = this._dtTable.Rows[0][nameof (maTiente)].ToString();
          hinhthucthanhtoan.HesoQuyDoi = this._dtTable.Rows[0]["hesoQuyDoi"].ToString();
          hinhthucthanhtoan.TiGia = this._dtTable.Rows[0]["tiGia"].ToString();
          hinhthucthanhtoan.Status = this._dtTable.Rows[0]["status"].ToString() == "True" ? 1 : 0;
          try
          {
            hinhthucthanhtoan.NgayCapnhat = DateTime.Parse(this._dtTable.Rows[0]["ngayCapnhat"].ToString());
          }
          catch (FormatException ex)
          {
          }
        }
      }
      catch
      {
        int num = (int) MessageBox.Show(Resources.tbHinhthucthanhtoan_GetInfor_KHÔNG_LẤY_ĐƯỢC_THÔNG_TIN, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      return hinhthucthanhtoan;
    }
  }
}
