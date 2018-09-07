// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.tbConfigApp
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System;
using System.Data;

namespace Thống_kê_xổ_số.BusinessLayer
{
  [Serializable]
  public class tbConfigApp
  {
    public static tbConfigApp configApp;
    public int stt;
    public string homePage;
    public string linkyoutube;
    public string linkfacebook;
    public string linkgoogleplus;
    public string ngayDangkiMoi;
    public string tileKhuyenMai;
    public string thuongXuDangkimoi;
    public string thuongVangDangkimoi;
    public string doiVangRaNgaySuDung;
    public string vangRaxu;
    public string trietKhauThanhToan;
    public string keyUser;
    public string keyAdmin;
    public string nguoiCapNhat;
    public string linkApp;
    public string dieukhoansudung;
    public string linkKinhnghiemchoi;
    public DateTime ngayCapNhat;
    public string useIDC;
    public DataTable dtTable;

    public tbConfigApp()
    {
    }

    public tbConfigApp(int stt, string homPage, string linkyoutube, string linkfacebook, string linkgoogleplus, string ngayDangkiMoi, string tileKhuyenMai, string thuongXuDangkimoi, string thuongVangDangkimoi, string doiVangRaNgaySuDung, string vangRaxu, string trietKhauThanhToan, string keyUser, string keyAdmin, string nguoiCapNhat, DateTime ngayCapNhat, string linkApp, string dieukhoansudung, string _linkKinhnghiemchoi)
    {
      this.stt = stt;
      this.homePage = homPage;
      this.linkyoutube = linkyoutube;
      this.linkfacebook = linkfacebook;
      this.linkgoogleplus = linkgoogleplus;
      this.ngayDangkiMoi = ngayDangkiMoi;
      this.tileKhuyenMai = tileKhuyenMai;
      this.thuongXuDangkimoi = thuongXuDangkimoi;
      this.thuongVangDangkimoi = thuongVangDangkimoi;
      this.doiVangRaNgaySuDung = doiVangRaNgaySuDung;
      this.vangRaxu = vangRaxu;
      this.trietKhauThanhToan = trietKhauThanhToan;
      this.keyUser = keyUser;
      this.keyAdmin = keyAdmin;
      this.nguoiCapNhat = nguoiCapNhat;
      this.ngayCapNhat = ngayCapNhat;
      this.linkApp = linkApp;
      this.dieukhoansudung = dieukhoansudung;
      this.linkKinhnghiemchoi = _linkKinhnghiemchoi;
    }

    public string LinkKinhnghiemchoi
    {
      get
      {
        return this.linkKinhnghiemchoi;
      }
      set
      {
        this.linkKinhnghiemchoi = value;
      }
    }

    public string LinkApp
    {
      get
      {
        return this.linkApp;
      }
      set
      {
        this.linkApp = value;
      }
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

    public string Dieukhoansudung
    {
      get
      {
        return this.dieukhoansudung;
      }
      set
      {
        this.dieukhoansudung = value;
      }
    }

    public string HomePage
    {
      get
      {
        return this.homePage;
      }
      set
      {
        this.homePage = value;
      }
    }

    public string LinkYoutube
    {
      get
      {
        return this.linkyoutube;
      }
      set
      {
        this.linkyoutube = value;
      }
    }

    public string LinkFacebook
    {
      get
      {
        return this.linkfacebook;
      }
      set
      {
        this.linkfacebook = value;
      }
    }

    public string LinkGooglePlus
    {
      get
      {
        return this.linkgoogleplus;
      }
      set
      {
        this.linkgoogleplus = value;
      }
    }

    public string NgayDangkiMoi
    {
      get
      {
        return this.ngayDangkiMoi;
      }
      set
      {
        this.ngayDangkiMoi = value;
      }
    }

    public string TileKhuyenMai
    {
      get
      {
        return this.tileKhuyenMai;
      }
      set
      {
        this.tileKhuyenMai = value;
      }
    }

    public string ThuongXuDangkimoi
    {
      get
      {
        return this.thuongXuDangkimoi;
      }
      set
      {
        this.thuongXuDangkimoi = value;
      }
    }

    public string ThuongVangDangkimoi
    {
      get
      {
        return this.thuongVangDangkimoi;
      }
      set
      {
        this.thuongVangDangkimoi = value;
      }
    }

    public string DoitienRavang
    {
      get
      {
        return this.doiVangRaNgaySuDung;
      }
      set
      {
        this.doiVangRaNgaySuDung = value;
      }
    }

    public string VangRaxu
    {
      get
      {
        return this.vangRaxu;
      }
      set
      {
        this.vangRaxu = value;
      }
    }

    public string TrietKhauThanhToan
    {
      get
      {
        return this.trietKhauThanhToan;
      }
      set
      {
        this.trietKhauThanhToan = value;
      }
    }

    public string KeyUser
    {
      get
      {
        return this.keyUser;
      }
      set
      {
        this.keyUser = value;
      }
    }

    public string KeyAdmin
    {
      get
      {
        return this.keyAdmin;
      }
      set
      {
        this.keyAdmin = value;
      }
    }

    public string NguoiCapNhat
    {
      get
      {
        return this.nguoiCapNhat;
      }
      set
      {
        this.nguoiCapNhat = value;
      }
    }

    public DateTime NgayCapNhat
    {
      get
      {
        return this.ngayCapNhat;
      }
      set
      {
        this.ngayCapNhat = value;
      }
    }

    public tbConfigApp GetInfoApp()
    {
      tbConfigApp tbConfigApp = new tbConfigApp();
      this.dtTable = new DataTable();
      string sql = "tbConfigApp_GetBy_Top_New";
      try
      {
        this.dtTable = new DataTable();
        this.dtTable = DataWeb.db.GetData(sql);
        if (this.dtTable.Rows.Count > 0)
        {
          try
          {
            tbConfigApp.Stt = int.Parse(this.dtTable.Rows[0]["stt"].ToString());
          }
          catch (FormatException ex)
          {
            tbConfigApp.Stt = 0;
          }
          tbConfigApp.KeyUser = this.dtTable.Rows[0]["keyUser"].ToString();
          tbConfigApp.KeyAdmin = this.dtTable.Rows[0]["keyAdmin"].ToString();
          tbConfigApp.HomePage = this.dtTable.Rows[0]["homePage"].ToString();
          tbConfigApp.LinkYoutube = this.dtTable.Rows[0]["Linkyoutube"].ToString();
          tbConfigApp.LinkFacebook = this.dtTable.Rows[0]["Linkfacebook"].ToString();
          tbConfigApp.LinkGooglePlus = this.dtTable.Rows[0]["Linkgoogleplus"].ToString();
          tbConfigApp.NgayDangkiMoi = this.dtTable.Rows[0]["ngayDangkiMoi"].ToString();
          tbConfigApp.TileKhuyenMai = this.dtTable.Rows[0]["tileKhuyenMai"].ToString();
          tbConfigApp.ThuongXuDangkimoi = this.dtTable.Rows[0]["thuongXuDangkimoi"].ToString();
          tbConfigApp.ThuongVangDangkimoi = this.dtTable.Rows[0]["thuongVangDangkimoi"].ToString();
          tbConfigApp.DoitienRavang = this.dtTable.Rows[0]["doiVangRaNgaySuDung"].ToString();
          tbConfigApp.VangRaxu = this.dtTable.Rows[0]["vangRaxu"].ToString();
          tbConfigApp.TrietKhauThanhToan = this.dtTable.Rows[0]["trietKhauThanhToan"].ToString();
          tbConfigApp.NguoiCapNhat = this.dtTable.Rows[0]["nguoiCapNhat"].ToString();
          try
          {
            tbConfigApp.NgayCapNhat = DateTime.Parse(this.dtTable.Rows[0]["ngayCapNhat"].ToString());
          }
          catch (FormatException ex)
          {
          }
          tbConfigApp.LinkApp = this.dtTable.Rows[0]["linkApp"].ToString();
          tbConfigApp.Dieukhoansudung = this.dtTable.Rows[0]["dieukhoansudung"].ToString();
          tbConfigApp.LinkKinhnghiemchoi = this.dtTable.Rows[0]["linkKinhnghiemchoi"].ToString();
          tbConfigApp.useIDC = this.dtTable.Rows[0]["useIDC"].ToString();
          tbConfigApp.configApp = tbConfigApp;
        }
      }
      catch (Exception ex)
      {
        throw;
      }
      return tbConfigApp;
    }
  }
}
