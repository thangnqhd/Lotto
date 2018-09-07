// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabHieuquadauso
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabHieuquadauso : UserControl
  {
    private int songaykiemtra = 30;
    private int khungkiemtralove = 1;
    private int khungktTemp = 0;
    private string _vitrixuathien = nameof (tongsolan);
    private string _xapxeptheo = "DESC";
    private IContainer components = (IContainer) null;
    private Tbloto objloto;
    private DataTable dtDauso;
    private TbVitri objVitri;
    private DataRow row;
    private DataTable dtBangketqua;
    private DataTable dtLoto;
    private DataTable _dtLotoNgayKiemTra;
    private DataRow[] _rows;
    private DataView _view;
    private DataTable dtKetqua;
    private string vengay;
    private DataTable dtLovengaysau;
    private string _dau_duong;
    private string _dau_am;
    private string _dau_nguhanh;
    private string _dau_bonglon;
    private string _duong_am;
    private string _duong_nguhanh;
    private string _am_nguhanh;
    private string _haisocuoi;
    private string _longbongso8;
    private string _longbongso9;
    private string _tongsolan;
    private int cbbThuDai;
    private string _phantram;
    private FHienThiThongkeHieuQuaDauSo fHienThiThongkeHieuQua;
    private DataGridViewCellStyle style;
    private BunifuElipse bunifuElipse1;
    private GroupBox groupBox6;
    private Button btnThongke;
    private DateTimePicker dateTungay;
    private Label label2;
    private Label label1;
    private ComboBox cbb_Thu_Dai;
    private DateTimePicker dateDenngay;
    private Label label3;
    private Timer timer1;
    private BackgroundWorker bgProccess;
    private ComboBox cbbKhungkiemtra;
    private Label label4;
    private DataGridView dtg_Ketqua;
    private PictureBox picLoading;
    private ComboBox cbbVitrixuathien;
    private Label label5;
    private ComboBox cbbLon_Nho;
    private DataGridViewTextBoxColumn ngaythang;
    private DataGridViewTextBoxColumn dau_duong;
    private DataGridViewTextBoxColumn dau_am;
    private DataGridViewTextBoxColumn dau_nguhanh;
    private DataGridViewTextBoxColumn dongcongbonglon;
    private DataGridViewTextBoxColumn duong_am;
    private DataGridViewTextBoxColumn duong_nguhanh;
    private DataGridViewTextBoxColumn am_nguhanh;
    private DataGridViewTextBoxColumn haisocuoi;
    private DataGridViewTextBoxColumn longbongso8;
    private DataGridViewTextBoxColumn longbongso9;
    private DataGridViewTextBoxColumn tongsolan;
    private DataGridViewTextBoxColumn coltrong;

    public TabHieuquadauso()
    {
      this.InitializeComponent();
      Tbketqua.AddGiaTriCbbThu(this.cbb_Thu_Dai);
      this.cbb_Thu_Dai.SelectedIndex = 0;
      this.dateDenngay.Value = FMain.NgayKetQuaMoiNhat;
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.objloto = new Tbloto();
      this.cbbKhungkiemtra.SelectedIndex = 1;
      this.objVitri = new TbVitri();
      this.cbbVitrixuathien.SelectedIndex = 0;
      this.cbbLon_Nho.SelectedIndex = 0;
    }

    private void CreateDataTableDauso()
    {
      this.dtDauso = new DataTable();
      this.dtDauso.Columns.Add("dauso", typeof (string));
      this.dtDauso.Columns.Add("bongduong", typeof (int));
      this.dtDauso.Columns.Add("bongam", typeof (int));
      this.dtDauso.Columns.Add("tuongsinh", typeof (int));
      this.dtDauso.Columns.Add("bonglon", typeof (int));
      this.dtDauso.Columns.Add("tatcavitri", typeof (int));
      this.dtDauso.Columns.Add("longso8", typeof (int));
      this.dtDauso.Columns.Add("longso9", typeof (int));
      this.dtDauso.Columns.Add("haisocuoi", typeof (int));
      this.dtDauso.Columns.Add("tongsolan", typeof (int));
      for (int index = 0; index < 10; ++index)
      {
        string dauso = index.ToString();
        string str = Biendoiloto.BiendoiTuongSinh1Vitri(dauso);
        DataRow row = this.dtDauso.NewRow();
        row["dauso"] = (object) dauso;
        row["bongduong"] = (object) Biendoiloto.BiendoiBongduong1Vitri(dauso);
        row["bongam"] = (object) Biendoiloto.BiendoiBongAm1Vitri(dauso);
        row["tuongsinh"] = (object) str;
        row["bonglon"] = (object) "0";
        row["longso8"] = (object) 0;
        row["longso9"] = (object) 0;
        row["tatcavitri"] = (object) 0;
        row["haisocuoi"] = (object) 0;
        row["tongsolan"] = (object) 0;
        this.dtDauso.Rows.Add(row);
      }
    }

    private void CreateDatatable_Ketqua()
    {
      this.dtKetqua = new DataTable();
      this.dtKetqua.Columns.Add("ngaythang", typeof (string));
      this.dtKetqua.Columns.Add("dau_duong", typeof (string));
      this.dtKetqua.Columns.Add("dau_am", typeof (string));
      this.dtKetqua.Columns.Add("dau_nguhanh", typeof (string));
      this.dtKetqua.Columns.Add("dongcongbonglon", typeof (string));
      this.dtKetqua.Columns.Add("duong_am", typeof (string));
      this.dtKetqua.Columns.Add("duong_nguhanh", typeof (string));
      this.dtKetqua.Columns.Add("am_nguhanh", typeof (string));
      this.dtKetqua.Columns.Add("haisocuoi", typeof (string));
      this.dtKetqua.Columns.Add("longbongso8", typeof (string));
      this.dtKetqua.Columns.Add("longbongso9", typeof (string));
      this.dtKetqua.Columns.Add("tongsolan", typeof (string));
    }

    private void AddRows_TbKetqua(DateTime ngaythang, string dau_duong, string dau_am, string daucongbonglon, string dau_nguhanh, string duong_am, string duong_nguhanh, string am_nguhanh, string haisocuoi, string longbongso8, string longbongso9, string tongsolan)
    {
      if (this.dtKetqua == null)
        return;
      this.row = this.dtKetqua.NewRow();
      this.row[nameof (ngaythang)] = (object) ngaythang.ToString("dd/MM/yyyy");
      this.row[nameof (dau_duong)] = (object) dau_duong;
      this.row[nameof (dau_am)] = (object) dau_am;
      this.row[nameof (dau_nguhanh)] = (object) dau_nguhanh;
      this.row[nameof (duong_am)] = (object) duong_am;
      this.row["dongcongbonglon"] = (object) daucongbonglon;
      this.row[nameof (duong_nguhanh)] = (object) duong_nguhanh;
      this.row[nameof (am_nguhanh)] = (object) am_nguhanh;
      this.row[nameof (haisocuoi)] = (object) haisocuoi;
      this.row[nameof (longbongso8)] = (object) longbongso8;
      this.row[nameof (longbongso9)] = (object) longbongso9;
      this.row[nameof (tongsolan)] = (object) tongsolan;
      this.dtKetqua.Rows.Add(this.row);
    }

    private void dateDenngay_ValueChanged(object sender, EventArgs e)
    {
      if (this.dateDenngay.Value > FMain.NgayKetQuaMoiNhat)
        this.dateDenngay.Value = FMain.NgayKetQuaMoiNhat;
      this.dateTungay.Value = this.dateDenngay.Value.AddDays((double) -this.songaykiemtra);
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      if (this.bgProccess.IsBusy)
        return;
      this.bgProccess.RunWorkerAsync();
    }

    private void Process()
    {
      this.CreateDatatable_Ketqua();
      this.dtBangketqua = this.objVitri.GetTbVitriByNgayThangThu(this.dateTungay.Value, this.dateDenngay.Value, this.cbbThuDai);
      this.dtLoto = this.objloto.GetLotoByNgayThang(this.dateTungay.Value, this.dateDenngay.Value);
      if (this.dtBangketqua.Rows.Count <= 0 || this.dtLoto.Rows.Count <= 0)
        return;
      for (int index = 0; index < this.dtBangketqua.Rows.Count; ++index)
      {
        this.CreateDataTableDauso();
        this.DemTongSoLanVeTungNgay(this.dtBangketqua.Rows[index], this.dtLoto, Convert.ToDateTime(this.dtBangketqua.Rows[index]["clngaythang"]));
      }
    }

    private string CheckVeNgay(DataTable _dtLoto, DateTime _ngaykiemtra, string _caplokiemtra)
    {
      this.dtLovengaysau = new DataTable();
      this.vengay = "Đang đợi";
      string filterExpression = "clngaythang >'" + (object) _ngaykiemtra + "'";
      this._rows = _dtLoto.Select(filterExpression);
      if ((uint) this._rows.Length > 0U)
        this.dtLovengaysau = ((IEnumerable<DataRow>) this._rows).CopyToDataTable<DataRow>();
      if (this.dtLovengaysau.Rows.Count > 0)
      {
        this.khungktTemp = this.dtLovengaysau.Rows.Count < this.khungkiemtralove ? this.dtLovengaysau.Rows.Count : this.khungkiemtralove;
        string str1 = _caplokiemtra;
        string str2 = _caplokiemtra;
        string[] strArray = _caplokiemtra.Split('-');
        if ((uint) strArray.Length > 0U)
        {
          str1 = strArray[0];
          str2 = strArray[1];
        }
        bool flag = false;
        for (int index1 = 0; index1 < this.khungktTemp; ++index1)
        {
          for (int index2 = 2; index2 < this.dtLovengaysau.Columns.Count; ++index2)
          {
            string str3 = this.dtLovengaysau.Rows[index1][index2].ToString();
            if (str1 == str3 || str2 == str3)
            {
              flag = true;
              break;
            }
          }
          if (flag)
          {
            this.vengay = (index1 + 1).ToString();
            break;
          }
        }
        if (!flag)
          this.vengay = "0";
      }
      return this.vengay;
    }

    private void DemTongSoLanVeTungNgay(DataRow _dtvitri, DataTable _dtLoto, DateTime _ngaythang)
    {
      string filterExpression = "clngaythang='" + (object) _ngaythang + "'";
      this._rows = _dtLoto.Select(filterExpression);
      if ((uint) this._rows.Length <= 0U)
        return;
      this._dtLotoNgayKiemTra = ((IEnumerable<DataRow>) this._rows).CopyToDataTable<DataRow>();
      for (int index1 = 4; index1 < _dtvitri.ItemArray.Length; ++index1)
      {
        string str1 = _dtvitri.ItemArray[index1].ToString();
        for (int index2 = 0; index2 < this.dtDauso.Rows.Count; ++index2)
        {
          string str2 = this.dtDauso.Rows[index2]["dauso"].ToString();
          if (str1 == str2)
            this.dtDauso.Rows[index2]["tatcavitri"] = (object) (Convert.ToInt32(this.dtDauso.Rows[index2]["tatcavitri"]) + 1);
        }
      }
      for (int index1 = 2; index1 < this._dtLotoNgayKiemTra.Columns.Count; ++index1)
      {
        char[] charArray = this._dtLotoNgayKiemTra.Rows[0][index1].ToString().ToCharArray();
        if ((uint) charArray.Length > 0U)
        {
          for (int index2 = 0; index2 < charArray.Length; ++index2)
          {
            for (int index3 = 0; index3 < this.dtDauso.Rows.Count; ++index3)
            {
              string str = this.dtDauso.Rows[index3]["dauso"].ToString();
              if (charArray[index2].ToString() == str)
                this.dtDauso.Rows[index3]["haisocuoi"] = (object) (Convert.ToInt32(this.dtDauso.Rows[index3]["haisocuoi"]) + 1);
            }
          }
        }
      }
      for (int index1 = 2; index1 < this._dtLotoNgayKiemTra.Columns.Count; ++index1)
      {
        char[] charArray = this._dtLotoNgayKiemTra.Rows[0][index1].ToString().ToCharArray();
        if ((uint) charArray.Length > 0U)
        {
          for (int index2 = 0; index2 < this.dtDauso.Rows.Count; ++index2)
          {
            string str = this.dtDauso.Rows[index2]["dauso"].ToString();
            if (charArray[0].ToString() == str)
              this.dtDauso.Rows[index2]["longso8"] = (object) (Convert.ToInt32(this.dtDauso.Rows[index2]["longso8"]) + 1);
            if (charArray[1].ToString() == str)
              this.dtDauso.Rows[index2]["longso9"] = (object) (Convert.ToInt32(this.dtDauso.Rows[index2]["longso9"]) + 1);
          }
        }
      }
      for (int index = 0; index < this.dtDauso.Rows.Count; ++index)
        this.dtDauso.Rows[index]["tongsolan"] = (object) (Convert.ToInt32(this.dtDauso.Rows[index]["tatcavitri"].ToString()) + Convert.ToInt32(this.dtDauso.Rows[index]["haisocuoi"].ToString()));
      this._view = this.dtDauso.DefaultView;
      this._view.Sort = this._vitrixuathien + " " + this._xapxeptheo ?? "";
      this.dtDauso = this._view.ToTable();
      int num = 9;
      for (int index1 = 0; index1 < this.dtDauso.Columns.Count; ++index1)
      {
        string str1 = this.dtDauso.Columns[index1].ToString();
        if (str1 == "bongduong" || str1 == "bongam" || str1 == "tuongsinh")
        {
          string str2 = this.dtDauso.Rows[0][index1].ToString();
          for (int index2 = 0; index2 < this.dtDauso.Rows.Count; ++index2)
          {
            if (str2 == this.dtDauso.Rows[index2]["dauso"].ToString() && index2 < num)
            {
              num = index2;
              this.dtDauso.Rows[0]["bonglon"] = (object) this.dtDauso.Rows[index2]["dauso"].ToString();
            }
          }
        }
      }
      if (this.dtDauso.Rows[0]["tongsolan"] != this.dtDauso.Rows[1]["tongsolan"])
      {
        this._dau_duong = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["bongduong"].ToString();
        this._dau_am = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["bongam"].ToString();
        this._dau_nguhanh = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._dau_bonglon = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["bonglon"].ToString();
        this._duong_am = this.dtDauso.Rows[0]["bongduong"].ToString() + this.dtDauso.Rows[0]["bongam"].ToString();
        this._duong_nguhanh = this.dtDauso.Rows[0]["bongduong"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._am_nguhanh = this.dtDauso.Rows[0]["bongam"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._haisocuoi = this.dtDauso.Rows[0]["haisocuoi"].ToString();
        this._longbongso8 = this.dtDauso.Rows[0]["longso8"].ToString();
        this._longbongso9 = this.dtDauso.Rows[0]["longso9"].ToString();
        this._tongsolan = this.dtDauso.Rows[0]["tongsolan"].ToString();
      }
      else if (Convert.ToInt32(this.dtDauso.Rows[0]["haisocuoi"]) >= Convert.ToInt32(this.dtDauso.Rows[1]["haisocuoi"]))
      {
        this._dau_duong = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["bongduong"].ToString();
        this._dau_am = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["bongam"].ToString();
        this._dau_nguhanh = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._dau_bonglon = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["bonglon"].ToString();
        this._duong_am = this.dtDauso.Rows[0]["bongduong"].ToString() + this.dtDauso.Rows[0]["bongam"].ToString();
        this._duong_nguhanh = this.dtDauso.Rows[0]["bongduong"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._am_nguhanh = this.dtDauso.Rows[0]["bongam"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._haisocuoi = this.dtDauso.Rows[0]["haisocuoi"].ToString();
        this._longbongso8 = this.dtDauso.Rows[0]["longso8"].ToString();
        this._longbongso9 = this.dtDauso.Rows[0]["longso9"].ToString();
        this._tongsolan = this.dtDauso.Rows[0]["tongsolan"].ToString();
      }
      else if (Convert.ToInt32(this.dtDauso.Rows[0]["haisocuoi"]) < Convert.ToInt32(this.dtDauso.Rows[1]["haisocuoi"]))
      {
        this._dau_duong = this.dtDauso.Rows[1]["dauso"].ToString() + this.dtDauso.Rows[0]["bongduong"].ToString();
        this._dau_am = this.dtDauso.Rows[1]["dauso"].ToString() + this.dtDauso.Rows[0]["bongam"].ToString();
        this._dau_nguhanh = this.dtDauso.Rows[1]["dauso"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._dau_bonglon = this.dtDauso.Rows[0]["dauso"].ToString() + this.dtDauso.Rows[0]["bonglon"].ToString();
        this._duong_am = this.dtDauso.Rows[1]["bongduong"].ToString() + this.dtDauso.Rows[0]["bongam"].ToString();
        this._duong_nguhanh = this.dtDauso.Rows[1]["bongduong"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._am_nguhanh = this.dtDauso.Rows[1]["bongam"].ToString() + this.dtDauso.Rows[0]["tuongsinh"].ToString();
        this._haisocuoi = this.dtDauso.Rows[1]["haisocuoi"].ToString();
        this._longbongso8 = this.dtDauso.Rows[1]["longso8"].ToString();
        this._longbongso9 = this.dtDauso.Rows[1]["longso9"].ToString();
        this._tongsolan = this.dtDauso.Rows[1]["tongsolan"].ToString();
      }
      this._dau_duong = this._dau_duong + "-" + Biendoiloto.Biendoilocap_BongDuong(this._dau_duong);
      this._dau_am = this._dau_am + "-" + Biendoiloto.Biendoilocap_BongDuong(this._dau_am);
      this._dau_nguhanh = this._dau_nguhanh + "-" + Biendoiloto.Biendoilocap_BongDuong(this._dau_nguhanh);
      this._dau_bonglon = this._dau_bonglon + "-" + Biendoiloto.Biendoilocap_BongDuong(this._dau_bonglon);
      this._duong_am = this._duong_am + "-" + Biendoiloto.Biendoilocap_BongDuong(this._duong_am);
      this._duong_nguhanh = this._duong_nguhanh + "-" + Biendoiloto.Biendoilocap_BongDuong(this._duong_nguhanh);
      this._am_nguhanh = this._am_nguhanh + "-" + Biendoiloto.Biendoilocap_BongDuong(this._am_nguhanh);
      this._dau_duong = Biendoiloto.XapXepLoCapTuBeLon(this._dau_duong);
      this._dau_am = Biendoiloto.XapXepLoCapTuBeLon(this._dau_am);
      this._dau_nguhanh = Biendoiloto.XapXepLoCapTuBeLon(this._dau_nguhanh);
      this._dau_bonglon = Biendoiloto.XapXepLoCapTuBeLon(this._dau_bonglon);
      this._duong_am = Biendoiloto.XapXepLoCapTuBeLon(this._duong_am);
      this._duong_nguhanh = Biendoiloto.XapXepLoCapTuBeLon(this._duong_nguhanh);
      this._am_nguhanh = Biendoiloto.XapXepLoCapTuBeLon(this._am_nguhanh);
      this._dau_duong = this._dau_duong + " (" + this.CheckVeNgay(this.dtLoto, _ngaythang, this._dau_duong) + ")";
      this._dau_am = this._dau_am + " (" + this.CheckVeNgay(this.dtLoto, _ngaythang, this._dau_am) + ")";
      this._dau_nguhanh = this._dau_nguhanh + " (" + this.CheckVeNgay(this.dtLoto, _ngaythang, this._dau_nguhanh) + ")";
      this._dau_bonglon = this._dau_bonglon + " (" + this.CheckVeNgay(this.dtLoto, _ngaythang, this._dau_bonglon) + ")";
      this._duong_am = this._duong_am + " (" + this.CheckVeNgay(this.dtLoto, _ngaythang, this._duong_am) + ")";
      this._duong_nguhanh = this._duong_nguhanh + " (" + this.CheckVeNgay(this.dtLoto, _ngaythang, this._duong_nguhanh) + ")";
      this._am_nguhanh = this._am_nguhanh + " (" + this.CheckVeNgay(this.dtLoto, _ngaythang, this._am_nguhanh) + ")";
      this.AddRows_TbKetqua(_ngaythang, this._dau_duong, this._dau_am, this._dau_bonglon, this._dau_nguhanh, this._duong_am, this._duong_nguhanh, this._am_nguhanh, this._haisocuoi, this._longbongso8, this._longbongso9, this._tongsolan);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.bgProccess.IsBusy;
    }

    private void cbb_Thu_Dai_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        this.cbbThuDai = Convert.ToInt32(this.cbb_Thu_Dai.SelectedValue);
      }
      catch (Exception ex)
      {
        this.cbbThuDai = 0;
      }
    }

    private void bgProccess_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Process();
    }

    private void rdTongsolanlonnhat_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton) sender;
      if (radioButton.Checked)
      {
        radioButton.ForeColor = Color.Red;
        radioButton.Font = new Font("Arial", 9f, FontStyle.Bold);
      }
      else
      {
        radioButton.ForeColor = Color.Black;
        radioButton.Font = new Font("Arial", 9f, FontStyle.Regular);
      }
    }

    private void cbbKhungkiemtra_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.khungkiemtralove = Convert.ToInt32(this.cbbKhungkiemtra.SelectedIndex.ToString()) + 1;
    }

    private string HienThiThongKe()
    {
      string str1 = "";
      if (this.dtKetqua.Rows.Count > 0)
      {
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        int num7 = 0;
        int num8 = 0;
        int num9 = 0;
        int num10 = 0;
        int num11 = 0;
        int num12 = 0;
        int num13 = 0;
        int num14 = 0;
        int num15 = 0;
        int num16 = 0;
        int num17 = 0;
        int num18 = 0;
        int num19 = 0;
        int num20 = 0;
        int num21 = 0;
        int num22 = 0;
        int num23 = 0;
        int num24 = 0;
        int num25 = 0;
        int num26 = 0;
        int num27 = 0;
        int num28 = 0;
        string pattern = "\\((.+?)\\)";
        for (int index = 0; index < this.dtKetqua.Rows.Count - 1; ++index)
        {
          string str2 = Regex.Match(this.dtKetqua.Rows[index]["dau_duong"].ToString(), pattern).Groups[1].ToString();
          string str3 = Regex.Match(this.dtKetqua.Rows[index]["dau_am"].ToString(), pattern).Groups[1].ToString();
          string str4 = Regex.Match(this.dtKetqua.Rows[index]["dau_nguhanh"].ToString(), pattern).Groups[1].ToString();
          string str5 = Regex.Match(this.dtKetqua.Rows[index]["dongcongbonglon"].ToString(), pattern).Groups[1].ToString();
          string str6 = Regex.Match(this.dtKetqua.Rows[index]["duong_am"].ToString(), pattern).Groups[1].ToString();
          string str7 = Regex.Match(this.dtKetqua.Rows[index]["duong_nguhanh"].ToString(), pattern).Groups[1].ToString();
          string str8 = Regex.Match(this.dtKetqua.Rows[index]["am_nguhanh"].ToString(), pattern).Groups[1].ToString();
          if (str2 != "0")
            ++num22;
          if (str3 != "0")
            ++num23;
          if (str4 != "0")
            ++num24;
          if (str5 != "0")
            ++num25;
          if (str6 != "0")
            ++num27;
          if (str7 != "0")
            ++num26;
          if (str8 != "0")
            ++num28;
          if (str2 == "1")
          {
            ++num1;
            num15 = 0;
          }
          else
          {
            ++num15;
            if (num15 > num8)
              num8 = num15;
          }
          if (str3 == "1")
          {
            ++num2;
            num16 = 0;
          }
          else
          {
            ++num16;
            if (num16 > num9)
              num9 = num16;
          }
          if (str4 == "1")
          {
            ++num3;
            num17 = 0;
          }
          else
          {
            ++num17;
            if (num17 > num10)
              num10 = num17;
          }
          if (str5 != "1")
          {
            ++num4;
            num18 = 0;
          }
          else
          {
            ++num18;
            if (num18 > num11)
              num11 = num18;
          }
          if (str6 == "1")
          {
            ++num6;
            num20 = 0;
          }
          else
          {
            ++num20;
            if (num20 > num13)
              num13 = num20;
          }
          if (str7 == "1")
          {
            ++num5;
            num19 = 0;
          }
          else
          {
            ++num19;
            if (num19 > num12)
              num12 = num19;
          }
          if (str8 == "1")
          {
            ++num7;
            num21 = 0;
          }
          else
          {
            ++num21;
            if (num21 > num14)
              num14 = num21;
          }
        }
        int num29 = this.dtKetqua.Rows.Count - 1;
        str1 = str1 + ">>Trong (<b style='color:red;font-size:16px;'>" + num29.ToString() + ")</b> ngày vừa qua. Các cặp lô được tạo thành về như sau : <br>- <b > Đầu + Bóng dương</b> về trong khung : <b style='color:blue;font-size:20px;'>" + (object) num22 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num22), 2) + "</b> . Về luôn ngày (<b style='font-size:16px;'>1</b>) : <b style='color:red;font-size:20px;'>" + (object) num1 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num1), 2) + "</b>.<br>-> Max ra lại ngày một của phương pháp là (<b style='color:red;font-size:16px;'> " + (object) num8 + " </b>) ngày, hiện tại là (" + (object) num15 + ") ngày chưa ra. </br>- <b > Đầu + Bóng âm</b> về trong khung : <b style='color:blue;font-size:20px;'>" + (object) num23 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num23), 2) + "</b> . Về luôn ngày (<b style='font-size:16px;'>1</b>) : <b style='color:red;font-size:20px;'>" + (object) num2 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num2), 2) + "</b><br>-> Max ra lại ngày một của phương pháp là (<b style='color:red;font-size:16px;'> " + (object) num9 + " </b>) ngày, hiện tại là (" + (object) num16 + ") ngày chưa ra. </br>- <b > Đầu + Ngũ hành</b> về trong khung : <b style='color:blue;font-size:20px;'>" + (object) num24 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num24), 2) + "</b> . Về luôn ngày (<b style='font-size:16px;'>1</b>) : <b style='color:red;font-size:20px;'>" + (object) num3 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num3), 2) + "</b><br>-> Max ra lại ngày một của phương pháp là (<b style='color:red;font-size:16px;'> " + (object) num10 + " </b>) ngày, hiện tại là (" + (object) num17 + ") ngày chưa ra. </br>- <b > Đầu + Bóng lớn</b> về trong khung : <b style='color:blue;font-size:20px;'>" + (object) num25 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num25), 2) + "</b> . Về luôn ngày (<b style='font-size:16px;'>1</b>) : <b style='color:red;font-size:20px;'>" + (object) num4 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num4), 2) + "</b><br>-> Max ra lại ngày một của phương pháp là (<b style='color:red;font-size:16px;'> " + (object) num11 + " </b>) ngày, hiện tại là (" + (object) num18 + ") ngày chưa ra. </br>- <b > Bóng dương + Bóng âm</b> về trong khung : <b style='color:blue;font-size:20px;'>" + (object) num27 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num27), 2) + "</b> . Về luôn ngày (<b style='font-size:16px;'>1</b>) : <b style='color:red;font-size:20px;'>" + (object) num6 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num6), 2) + "</b><br>-> Max ra lại ngày một của phương pháp là (<b style='color:red;font-size:16px;'> " + (object) num13 + " </b>) ngày, hiện tại là (" + (object) num20 + ") ngày chưa ra. </br>- <b > Bóng dương + Ngũ hành</b> về trong khung : <b style='color:blue;font-size:20px;'>" + (object) num26 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num26), 2) + "</b> . Về luôn ngày (<b style='font-size:16px;'>1</b>) : <b style='color:red;font-size:20px;'>" + (object) num5 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num5), 2) + "</b><br>-> Max ra lại ngày một của phương pháp là (<b style='color:red;font-size:16px;'> " + (object) num12 + " </b>) ngày, hiện tại là (" + (object) num19 + ") ngày chưa ra. </br>- <b > Bóng âm + Ngũ hành</b> về trong khung : <b style='color:blue;font-size:20px;'>" + (object) num28 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num28), 2) + "</b> . Về luôn ngày (<b style='font-size:16px;'>1</b>) : <b style='color:red;font-size:20px;'>" + (object) num7 + "</b>/" + (object) num29 + " lần đạt <b style='color:red;font-size:16px;'>" + this.TinhPhanTram(Convert.ToDecimal(num29), Convert.ToDecimal(num7), 2) + "</b><br>-> Max ra lại ngày một của phương pháp là (<b style='color:red;font-size:16px;'> " + (object) num14 + " </b>) ngày, hiện tại là (" + (object) num21 + ") ngày chưa ra. </br>";
      }
      return str1;
    }

    private string TinhPhanTram(Decimal _tongsolanve, Decimal _solanxuathien, int _sokytusaudayphay)
    {
      this._phantram = "";
      this._phantram = Math.Round(_solanxuathien / _tongsolanve * new Decimal(100), _sokytusaudayphay).ToString() + "%";
      return this._phantram;
    }

    private void bgProccess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.dtg_Ketqua.DataSource = (object) this.dtKetqua;
      if (Application.OpenForms.OfType<FHienThiThongkeHieuQuaDauSo>().Count<FHienThiThongkeHieuQuaDauSo>() > 0)
        this.fHienThiThongkeHieuQua.Close();
      this.fHienThiThongkeHieuQua = new FHienThiThongkeHieuQuaDauSo(this.HienThiThongKe());
      this.fHienThiThongkeHieuQua.Show();
    }

    private void cbbVitrixuathien_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbbVitrixuathien.SelectedIndex == 0)
        this._vitrixuathien = "tongsolan";
      if (this.cbbVitrixuathien.SelectedIndex == 1)
        this._vitrixuathien = "haisocuoi";
      if (this.cbbVitrixuathien.SelectedIndex == 2)
        this._vitrixuathien = "longso8";
      if (this.cbbVitrixuathien.SelectedIndex != 3)
        return;
      this._vitrixuathien = "longso9";
    }

    private void cbbLon_Nho_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbbLon_Nho.SelectedIndex == 0)
        this._xapxeptheo = "DESC";
      else
        this._xapxeptheo = "ASC";
    }

    private DataGridViewCellStyle Style_Vengay1()
    {
      this.style = new DataGridViewCellStyle();
      this.style.BackColor = Color.Green;
      this.style.ForeColor = Color.Black;
      return this.style;
    }

    private DataGridViewCellStyle Style_Vengay2()
    {
      this.style = new DataGridViewCellStyle();
      this.style.BackColor = Color.Yellow;
      this.style.ForeColor = Color.Black;
      return this.style;
    }

    private DataGridViewCellStyle Style_Khongve()
    {
      this.style = new DataGridViewCellStyle();
      this.style.BackColor = Color.Red;
      this.style.ForeColor = Color.Black;
      return this.style;
    }

    private void dtg_Ketqua_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      string pattern = "\\((.+?)\\)";
      for (int index1 = 0; index1 < this.dtg_Ketqua.Rows.Count; ++index1)
      {
        for (int index2 = 1; index2 < this.dtg_Ketqua.Columns.Count - 1; ++index2)
        {
          string str = Regex.Match(this.dtg_Ketqua.Rows[index1].Cells[index2].Value.ToString(), pattern).Groups[1].ToString();
          if (str == "1")
            this.dtg_Ketqua.Rows[index1].Cells[index2].Style = this.Style_Vengay1();
          if (str == "0")
            this.dtg_Ketqua.Rows[index1].Cells[index2].Style = this.Style_Khongve();
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabHieuquadauso));
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.groupBox6 = new GroupBox();
      this.cbbLon_Nho = new ComboBox();
      this.cbbVitrixuathien = new ComboBox();
      this.label5 = new Label();
      this.cbbKhungkiemtra = new ComboBox();
      this.label4 = new Label();
      this.dateDenngay = new DateTimePicker();
      this.label3 = new Label();
      this.cbb_Thu_Dai = new ComboBox();
      this.label1 = new Label();
      this.btnThongke = new Button();
      this.dateTungay = new DateTimePicker();
      this.label2 = new Label();
      this.timer1 = new Timer(this.components);
      this.bgProccess = new BackgroundWorker();
      this.dtg_Ketqua = new DataGridView();
      this.picLoading = new PictureBox();
      this.ngaythang = new DataGridViewTextBoxColumn();
      this.dau_duong = new DataGridViewTextBoxColumn();
      this.dau_am = new DataGridViewTextBoxColumn();
      this.dau_nguhanh = new DataGridViewTextBoxColumn();
      this.dongcongbonglon = new DataGridViewTextBoxColumn();
      this.duong_am = new DataGridViewTextBoxColumn();
      this.duong_nguhanh = new DataGridViewTextBoxColumn();
      this.am_nguhanh = new DataGridViewTextBoxColumn();
      this.haisocuoi = new DataGridViewTextBoxColumn();
      this.longbongso8 = new DataGridViewTextBoxColumn();
      this.longbongso9 = new DataGridViewTextBoxColumn();
      this.tongsolan = new DataGridViewTextBoxColumn();
      this.coltrong = new DataGridViewTextBoxColumn();
      this.groupBox6.SuspendLayout();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox6.Controls.Add((Control) this.cbbLon_Nho);
      this.groupBox6.Controls.Add((Control) this.cbbVitrixuathien);
      this.groupBox6.Controls.Add((Control) this.label5);
      this.groupBox6.Controls.Add((Control) this.cbbKhungkiemtra);
      this.groupBox6.Controls.Add((Control) this.label4);
      this.groupBox6.Controls.Add((Control) this.dateDenngay);
      this.groupBox6.Controls.Add((Control) this.label3);
      this.groupBox6.Controls.Add((Control) this.cbb_Thu_Dai);
      this.groupBox6.Controls.Add((Control) this.label1);
      this.groupBox6.Controls.Add((Control) this.btnThongke);
      this.groupBox6.Controls.Add((Control) this.dateTungay);
      this.groupBox6.Controls.Add((Control) this.label2);
      this.groupBox6.Location = new Point(5, 0);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(1090, 45);
      this.groupBox6.TabIndex = 3;
      this.groupBox6.TabStop = false;
      this.cbbLon_Nho.BackColor = Color.Teal;
      this.cbbLon_Nho.Cursor = Cursors.Hand;
      this.cbbLon_Nho.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLon_Nho.FlatStyle = FlatStyle.Popup;
      this.cbbLon_Nho.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbLon_Nho.ForeColor = Color.White;
      this.cbbLon_Nho.FormattingEnabled = true;
      this.cbbLon_Nho.Items.AddRange(new object[2]
      {
        (object) "Lớn nhất",
        (object) "Nhỏ nhất"
      });
      this.cbbLon_Nho.Location = new Point(869, 13);
      this.cbbLon_Nho.Margin = new Padding(2, 5, 3, 3);
      this.cbbLon_Nho.Name = "cbbLon_Nho";
      this.cbbLon_Nho.Size = new Size(85, 23);
      this.cbbLon_Nho.TabIndex = 49;
      this.cbbLon_Nho.SelectedIndexChanged += new EventHandler(this.cbbLon_Nho_SelectedIndexChanged);
      this.cbbVitrixuathien.BackColor = Color.Teal;
      this.cbbVitrixuathien.Cursor = Cursors.Hand;
      this.cbbVitrixuathien.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbVitrixuathien.FlatStyle = FlatStyle.Popup;
      this.cbbVitrixuathien.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbVitrixuathien.ForeColor = Color.White;
      this.cbbVitrixuathien.FormattingEnabled = true;
      this.cbbVitrixuathien.Items.AddRange(new object[4]
      {
        (object) "-- Tất cả vị trí ---",
        (object) "--- Hai số cuối ---",
        (object) "--- Hàng chục ----",
        (object) "-- Hàng đơn vị---"
      });
      this.cbbVitrixuathien.Location = new Point(748, 13);
      this.cbbVitrixuathien.Margin = new Padding(2, 5, 3, 3);
      this.cbbVitrixuathien.Name = "cbbVitrixuathien";
      this.cbbVitrixuathien.Size = new Size(119, 23);
      this.cbbVitrixuathien.TabIndex = 48;
      this.cbbVitrixuathien.SelectedIndexChanged += new EventHandler(this.cbbVitrixuathien_SelectedIndexChanged);
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.Black;
      this.label5.Location = new Point(599, 16);
      this.label5.Name = "label5";
      this.label5.Size = new Size(151, 16);
      this.label5.TabIndex = 47;
      this.label5.Text = "Xắp xếp theo số lần về ở";
      this.cbbKhungkiemtra.BackColor = Color.Teal;
      this.cbbKhungkiemtra.Cursor = Cursors.Hand;
      this.cbbKhungkiemtra.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbKhungkiemtra.FlatStyle = FlatStyle.Popup;
      this.cbbKhungkiemtra.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbKhungkiemtra.ForeColor = Color.White;
      this.cbbKhungkiemtra.FormattingEnabled = true;
      this.cbbKhungkiemtra.Items.AddRange(new object[6]
      {
        (object) "1 ngày",
        (object) "2 ngày",
        (object) "3 ngày",
        (object) "4 ngày",
        (object) "5 ngày",
        (object) "6 ngày"
      });
      this.cbbKhungkiemtra.Location = new Point(505, 13);
      this.cbbKhungkiemtra.Margin = new Padding(2, 5, 3, 3);
      this.cbbKhungkiemtra.Name = "cbbKhungkiemtra";
      this.cbbKhungkiemtra.Size = new Size(79, 23);
      this.cbbKhungkiemtra.TabIndex = 46;
      this.cbbKhungkiemtra.SelectedIndexChanged += new EventHandler(this.cbbKhungkiemtra_SelectedIndexChanged);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(460, 16);
      this.label4.Name = "label4";
      this.label4.Size = new Size(43, 16);
      this.label4.TabIndex = 45;
      this.label4.Text = "khung";
      this.dateDenngay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dateDenngay.CalendarForeColor = Color.Red;
      this.dateDenngay.CalendarMonthBackground = SystemColors.Info;
      this.dateDenngay.CustomFormat = "dd/MM/yyyy";
      this.dateDenngay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dateDenngay.Format = DateTimePickerFormat.Custom;
      this.dateDenngay.Location = new Point(184, 15);
      this.dateDenngay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dateDenngay.Name = "dateDenngay";
      this.dateDenngay.Size = new Size(98, 21);
      this.dateDenngay.TabIndex = 44;
      this.dateDenngay.ValueChanged += new EventHandler(this.dateDenngay_ValueChanged);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(169, 16);
      this.label3.Name = "label3";
      this.label3.Size = new Size(12, 16);
      this.label3.TabIndex = 43;
      this.label3.Text = "-";
      this.cbb_Thu_Dai.BackColor = Color.Teal;
      this.cbb_Thu_Dai.Cursor = Cursors.Hand;
      this.cbb_Thu_Dai.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbb_Thu_Dai.FlatStyle = FlatStyle.Popup;
      this.cbb_Thu_Dai.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbb_Thu_Dai.ForeColor = Color.White;
      this.cbb_Thu_Dai.FormattingEnabled = true;
      this.cbb_Thu_Dai.Location = new Point(343, 13);
      this.cbb_Thu_Dai.Margin = new Padding(2, 5, 3, 3);
      this.cbb_Thu_Dai.Name = "cbb_Thu_Dai";
      this.cbb_Thu_Dai.Size = new Size(110, 23);
      this.cbb_Thu_Dai.TabIndex = 42;
      this.cbb_Thu_Dai.SelectedIndexChanged += new EventHandler(this.cbb_Thu_Dai_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(281, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(60, 16);
      this.label1.TabIndex = 41;
      this.label1.Text = "chọn thứ";
      this.btnThongke.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(988, 13);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(95, 24);
      this.btnThongke.TabIndex = 7;
      this.btnThongke.Text = "Thống Kê";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.dateTungay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dateTungay.CalendarForeColor = Color.Red;
      this.dateTungay.CalendarMonthBackground = SystemColors.Info;
      this.dateTungay.CustomFormat = "dd/MM/yyyy";
      this.dateTungay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dateTungay.Format = DateTimePickerFormat.Custom;
      this.dateTungay.Location = new Point(69, 15);
      this.dateTungay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dateTungay.Name = "dateTungay";
      this.dateTungay.Size = new Size(98, 21);
      this.dateTungay.TabIndex = 0;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(11, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(56, 16);
      this.label2.TabIndex = 39;
      this.label2.Text = "Từ ngày";
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.bgProccess.DoWork += new DoWorkEventHandler(this.bgProccess_DoWork);
      this.bgProccess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgProccess_RunWorkerCompleted);
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_Ketqua.BackgroundColor = SystemColors.ButtonHighlight;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 24;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.ngaythang, (DataGridViewColumn) this.dau_duong, (DataGridViewColumn) this.dau_am, (DataGridViewColumn) this.dau_nguhanh, (DataGridViewColumn) this.dongcongbonglon, (DataGridViewColumn) this.duong_am, (DataGridViewColumn) this.duong_nguhanh, (DataGridViewColumn) this.am_nguhanh, (DataGridViewColumn) this.haisocuoi, (DataGridViewColumn) this.longbongso8, (DataGridViewColumn) this.longbongso9, (DataGridViewColumn) this.tongsolan, (DataGridViewColumn) this.coltrong);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.GridColor = Color.WhiteSmoke;
      this.dtg_Ketqua.Location = new Point(4, 48);
      this.dtg_Ketqua.Margin = new Padding(0);
      this.dtg_Ketqua.MultiSelect = false;
      this.dtg_Ketqua.Name = "dtg_Ketqua";
      this.dtg_Ketqua.ReadOnly = true;
      this.dtg_Ketqua.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.BackColor = Color.Cornsilk;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dtg_Ketqua.RowHeadersVisible = false;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dtg_Ketqua.RowTemplate.Height = 24;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(1091, 525);
      this.dtg_Ketqua.TabIndex = 63;
      this.dtg_Ketqua.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dtg_Ketqua_DataBindingComplete);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(500, 367);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 64;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.ngaythang.DataPropertyName = "ngaythang";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.DimGray;
      this.ngaythang.DefaultCellStyle = gridViewCellStyle4;
      this.ngaythang.HeaderText = "Ngày";
      this.ngaythang.Name = "ngaythang";
      this.ngaythang.ReadOnly = true;
      this.ngaythang.ToolTipText = "Đầu số xuất hiện";
      this.dau_duong.DataPropertyName = "dau_duong";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dau_duong.DefaultCellStyle = gridViewCellStyle5;
      this.dau_duong.HeaderText = "Đầu+B.Dương";
      this.dau_duong.Name = "dau_duong";
      this.dau_duong.ReadOnly = true;
      this.dau_duong.ToolTipText = "Bóng dương của đầu số";
      this.dau_duong.Width = 110;
      this.dau_am.DataPropertyName = "dau_am";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle6.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dau_am.DefaultCellStyle = gridViewCellStyle6;
      this.dau_am.HeaderText = "Đầu+B.Âm";
      this.dau_am.Name = "dau_am";
      this.dau_am.ReadOnly = true;
      this.dau_am.ToolTipText = "Bóng âm của đầu số";
      this.dau_am.Width = 110;
      this.dau_nguhanh.DataPropertyName = "dau_nguhanh";
      this.dau_nguhanh.HeaderText = "Đầu Ngũ hành";
      this.dau_nguhanh.Name = "dau_nguhanh";
      this.dau_nguhanh.ReadOnly = true;
      this.dau_nguhanh.ToolTipText = "Số tương sinh tương khắc của đầu số";
      this.dau_nguhanh.Width = 110;
      this.dongcongbonglon.DataPropertyName = "dongcongbonglon";
      this.dongcongbonglon.HeaderText = "Đầu+Bóng lớn";
      this.dongcongbonglon.Name = "dongcongbonglon";
      this.dongcongbonglon.ReadOnly = true;
      this.dongcongbonglon.Width = 110;
      this.duong_am.DataPropertyName = "duong_am";
      this.duong_am.HeaderText = "B.Dương+B.Âm";
      this.duong_am.Name = "duong_am";
      this.duong_am.ReadOnly = true;
      this.duong_am.ToolTipText = "Thông tin ngũ hành đầu số và tương sinh";
      this.duong_am.Width = 110;
      this.duong_nguhanh.DataPropertyName = "duong_nguhanh";
      this.duong_nguhanh.HeaderText = "B.Dương+Ngũ hành";
      this.duong_nguhanh.Name = "duong_nguhanh";
      this.duong_nguhanh.ReadOnly = true;
      this.duong_nguhanh.Width = 125;
      this.am_nguhanh.DataPropertyName = "am_nguhanh";
      this.am_nguhanh.HeaderText = "B.Âm+Ngũ hành";
      this.am_nguhanh.Name = "am_nguhanh";
      this.am_nguhanh.ReadOnly = true;
      this.am_nguhanh.Width = 110;
      this.haisocuoi.DataPropertyName = "haisocuoi";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle7.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle7.ForeColor = Color.Red;
      this.haisocuoi.DefaultCellStyle = gridViewCellStyle7;
      this.haisocuoi.HeaderText = "Hai số cuối";
      this.haisocuoi.Name = "haisocuoi";
      this.haisocuoi.ReadOnly = true;
      this.haisocuoi.ToolTipText = "Số lần xuất hiện của đầu số trong tất cả các vị trí";
      this.longbongso8.DataPropertyName = "longbongso8";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle8.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      gridViewCellStyle8.ForeColor = Color.Red;
      this.longbongso8.DefaultCellStyle = gridViewCellStyle8;
      this.longbongso8.HeaderText = "Hàng chục";
      this.longbongso8.Name = "longbongso8";
      this.longbongso8.ReadOnly = true;
      this.longbongso8.ToolTipText = "Số lần xuất hiện của đầu số trong 2 số cuối của các giải";
      this.longbongso9.DataPropertyName = "longbongso9";
      this.longbongso9.HeaderText = "Hàng đơn vị";
      this.longbongso9.Name = "longbongso9";
      this.longbongso9.ReadOnly = true;
      this.tongsolan.DataPropertyName = "tongsolan";
      this.tongsolan.HeaderText = "Tổng số lần";
      this.tongsolan.Name = "tongsolan";
      this.tongsolan.ReadOnly = true;
      this.tongsolan.Width = 110;
      this.coltrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.coltrong.HeaderText = "";
      this.coltrong.Name = "coltrong";
      this.coltrong.ReadOnly = true;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.picLoading);
      this.Controls.Add((Control) this.dtg_Ketqua);
      this.Controls.Add((Control) this.groupBox6);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabHieuquadauso);
      this.Size = new Size(1100, 573);
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.ResumeLayout(false);
    }
  }
}
