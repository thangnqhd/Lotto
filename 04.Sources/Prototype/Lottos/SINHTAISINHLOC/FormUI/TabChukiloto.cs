// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabChukiloto
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabChukiloto : UserControl
  {
    private int soBanGhiVe = 3;
    private IContainer components = (IContainer) null;
    private TbLoaiLoto objLoailoto;
    private const int SONAMKIEMTRA = 726;
    public List<TabChukiloto.LOTO> listLotoCap;
    public List<TabChukiloto.LOTO> listLotoBachThu;
    public List<TabChukiloto.LOTO> listLotoTrungDau;
    public List<TabChukiloto.LOTO> listLotoTrungDuoi;
    public List<TabChukiloto.LOTO> listLotoTuDo;
    public List<TabChukiloto.LOTO> listLotoChuan;
    private DataTable dataTable1;
    private DataTable dataTable2;
    private DataTable dataTable3;
    private DataTable dataTable4;
    private DataTable dataTable5;
    private int biendotrungdau;
    private int biendotrungduoi;
    private readonly Tbloto objLoto;
    private DateTime ngayThangCu;
    private int soBanGhiCu;
    private int sobanghi;
    private int solotomoiphan;
    private int soBanGhiVeCu;
    private DataTable dtLoto;
    private DataTable dtLOTO_NGAYSAU;
    private DataTable dt;
    private BunifuElipse bunifuElipse1;
    private Panel panel1;
    private Label label1;
    private TextBox txtBiendongay;
    private Button btnThongke;
    private DateTimePicker dtNgayXem;
    private Label label3;
    private RadioButton rdCap;
    private RadioButton rdTuDo;
    private RadioButton rdTrungDuoi;
    private RadioButton rdTrungDau;
    private RadioButton rdBachThu;
    private ToolTip toolTip1;
    private BackgroundWorker bgKhoitaodulieu;
    private BackgroundWorker bgKhoitaolotudo;
    private Timer timer1;
    private BackgroundWorker bgProcess;
    private BackgroundWorker bg1;
    private BackgroundWorker bg2;
    private BackgroundWorker bg3;
    private BackgroundWorker bg4;
    private BackgroundWorker bg5;
    private Panel panel2;
    private PictureBox picLoading;
    private DataGridView dtg_Ketqua;
    private Label label2;
    private Timer timer2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem xemTầnXuấtBộSốToolStripMenuItem;
    private ToolStripMenuItem soiCầuBạchThủToolStripMenuItem;
    private GroupBox groupBox1;
    private CheckBox cbSolanve;
    private NumericUpDown numSolanveLon;
    private Label label5;
    private NumericUpDown numSolanveBe;
    private Label label4;
    private GroupBox groupBox2;
    private CheckBox cbNgaychuara;
    private NumericUpDown numNgaychuaraLon;
    private Label label6;
    private NumericUpDown numNgaychuaraBe;
    private Label label7;
    private GroupBox groupBox3;
    private CheckBox cbGantrongkhung;
    private NumericUpDown numGantrongkhungLon;
    private Label label8;
    private NumericUpDown numGantrongkhungBe;
    private Label label9;
    private GroupBox groupBox5;
    private CheckBox cbSoNhayve;
    private NumericUpDown numSonhayveLon;
    private Label label12;
    private NumericUpDown numSonhayveBe;
    private Label label13;
    private GroupBox groupBox4;
    private CheckBox cbDiemtanxuat;
    private NumericUpDown numTanxuatLon;
    private Label label10;
    private NumericUpDown numTanxuatBe;
    private Label label11;
    private DataGridViewTextBoxColumn stt;
    private DataGridViewTextBoxColumn loto;
    private DataGridViewTextBoxColumn solanve;
    private DataGridViewTextBoxColumn soNhayVe;
    private DataGridViewTextBoxColumn chuKi;
    private DataGridViewTextBoxColumn ngayChuara;
    private DataGridViewTextBoxColumn maxSobanghi;
    private DataGridViewTextBoxColumn maxGan;
    private DataGridViewTextBoxColumn diemtanxuat;
    private DataGridViewTextBoxColumn diemGan;
    private DataGridViewTextBoxColumn veNgay;
    private DataGridViewTextBoxColumn colTrong;
    private GroupBox groupBox6;
    private GroupBox groupBox7;
    private CheckBox cbDiemgan;
    private NumericUpDown numDiemganLon;
    private Label label14;
    private NumericUpDown numDiemganNho;
    private Label label15;
    private GroupBox groupBox8;
    private CheckBox cbGan2nam;
    private NumericUpDown numGan2namLon;
    private Label label16;
    private NumericUpDown numGan2namNho;
    private Label label17;
    private BackgroundWorker bgGetCauHinh;

    public TabChukiloto()
    {
      this.objLoto = new Tbloto();
      this.InitializeComponent();
      this.objLoailoto = new TbLoaiLoto();
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.biendotrungdau = FMain.ObjConfigBacNho.BiendoTrungDau;
      this.biendotrungduoi = FMain.ObjConfigBacNho.BiendoTrungDuoi;
      this.ngayThangCu = DateTime.Now.AddYears(3);
      if (!this.bgGetCauHinh.IsBusy)
        this.bgGetCauHinh.RunWorkerAsync();
      this.soBanGhiCu = 35;
      if (!this.bgKhoitaodulieu.IsBusy)
        this.bgKhoitaodulieu.RunWorkerAsync();
      if (this.bgKhoitaolotudo.IsBusy)
        return;
      this.bgKhoitaolotudo.RunWorkerAsync();
    }

    private void GetLoaiLoto(string tendangnhap)
    {
      this.objLoailoto = this.objLoailoto.GetBuyUsername(tendangnhap);
    }

    public void KhoiTao_DataTable1()
    {
      this.dataTable1 = new DataTable();
      this.dataTable1.Columns.Add("stt", typeof (int));
      this.dataTable1.Columns.Add("loto", typeof (string));
      this.dataTable1.Columns.Add("solanve", typeof (int));
      this.dataTable1.Columns.Add("ngayChuara", typeof (int));
      this.dataTable1.Columns.Add("chuKi", typeof (double));
      this.dataTable1.Columns.Add("maxSobanghi", typeof (int));
      this.dataTable1.Columns.Add("maxGan", typeof (int));
      this.dataTable1.Columns.Add("diemtanxuat", typeof (double));
      this.dataTable1.Columns.Add("diemGan", typeof (double));
      this.dataTable1.Columns.Add("soNhayVe", typeof (int));
      this.dataTable1.Columns.Add("veNgay", typeof (double));
      this.dataTable1.Columns.Add("colTrong", typeof (string));
    }

    public void KhoiTao_DataTable2()
    {
      this.dataTable2 = new DataTable();
      this.dataTable2.Columns.Add("stt", typeof (int));
      this.dataTable2.Columns.Add("loto", typeof (string));
      this.dataTable2.Columns.Add("solanve", typeof (int));
      this.dataTable2.Columns.Add("ngayChuara", typeof (int));
      this.dataTable2.Columns.Add("chuKi", typeof (double));
      this.dataTable2.Columns.Add("maxSobanghi", typeof (int));
      this.dataTable2.Columns.Add("maxGan", typeof (int));
      this.dataTable2.Columns.Add("diemtanxuat", typeof (double));
      this.dataTable2.Columns.Add("diemGan", typeof (double));
      this.dataTable2.Columns.Add("soNhayVe", typeof (int));
      this.dataTable2.Columns.Add("veNgay", typeof (double));
      this.dataTable2.Columns.Add("colTrong", typeof (string));
    }

    public void KhoiTao_DataTable3()
    {
      this.dataTable3 = new DataTable();
      this.dataTable3.Columns.Add("stt", typeof (int));
      this.dataTable3.Columns.Add("loto", typeof (string));
      this.dataTable3.Columns.Add("solanve", typeof (int));
      this.dataTable3.Columns.Add("ngayChuara", typeof (int));
      this.dataTable3.Columns.Add("chuKi", typeof (double));
      this.dataTable3.Columns.Add("maxSobanghi", typeof (int));
      this.dataTable3.Columns.Add("maxGan", typeof (int));
      this.dataTable3.Columns.Add("diemtanxuat", typeof (double));
      this.dataTable3.Columns.Add("diemGan", typeof (double));
      this.dataTable3.Columns.Add("soNhayVe", typeof (int));
      this.dataTable3.Columns.Add("veNgay", typeof (double));
      this.dataTable3.Columns.Add("colTrong", typeof (string));
    }

    public void KhoiTao_DataTable4()
    {
      this.dataTable4 = new DataTable();
      this.dataTable4.Columns.Add("stt", typeof (int));
      this.dataTable4.Columns.Add("loto", typeof (string));
      this.dataTable4.Columns.Add("solanve", typeof (int));
      this.dataTable4.Columns.Add("ngayChuara", typeof (int));
      this.dataTable4.Columns.Add("chuKi", typeof (double));
      this.dataTable4.Columns.Add("maxSobanghi", typeof (int));
      this.dataTable4.Columns.Add("maxGan", typeof (int));
      this.dataTable4.Columns.Add("diemtanxuat", typeof (double));
      this.dataTable4.Columns.Add("diemGan", typeof (double));
      this.dataTable4.Columns.Add("veNgay", typeof (double));
      this.dataTable4.Columns.Add("soNhayVe", typeof (int));
      this.dataTable4.Columns.Add("colTrong", typeof (string));
    }

    public void KhoiTao_DataTable5()
    {
      this.dataTable5 = new DataTable();
      this.dataTable5.Columns.Add("stt", typeof (int));
      this.dataTable5.Columns.Add("loto", typeof (string));
      this.dataTable5.Columns.Add("solanve", typeof (int));
      this.dataTable5.Columns.Add("ngayChuara", typeof (int));
      this.dataTable5.Columns.Add("chuKi", typeof (double));
      this.dataTable5.Columns.Add("maxSobanghi", typeof (int));
      this.dataTable5.Columns.Add("maxGan", typeof (int));
      this.dataTable5.Columns.Add("diemtanxuat", typeof (double));
      this.dataTable5.Columns.Add("diemGan", typeof (double));
      this.dataTable5.Columns.Add("veNgay", typeof (double));
      this.dataTable5.Columns.Add("soNhayVe", typeof (int));
      this.dataTable5.Columns.Add("colTrong", typeof (string));
    }

    private void dtNgayXem_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dtNgayXem.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
    }

    public void TaoListLotoCap()
    {
      this.listLotoCap = new List<TabChukiloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabChukiloto.LOTO LOTO = new TabChukiloto.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          LOTO.loto1 = "0" + (object) index;
        LOTO.loto2 = ClMain.check_Loto_Cap(LOTO.loto1);
        if (Convert.ToInt32(LOTO.loto1) > Convert.ToInt32(LOTO.loto2))
        {
          LOTO.loto1 = LOTO.loto2;
          LOTO.loto2 = ClMain.check_Loto_Cap(LOTO.loto1);
        }
        if (this.listLotoCap.Count > 0)
        {
          if (!this.listLotoCap.Any<TabChukiloto.LOTO>((Func<TabChukiloto.LOTO, bool>) (lo => LOTO.loto1 == lo.loto1)))
            this.listLotoCap.Add(LOTO);
        }
        else
          this.listLotoCap.Add(LOTO);
      }
    }

    private void TaoListLotoBachThu()
    {
      this.listLotoBachThu = new List<TabChukiloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabChukiloto.LOTO loto = new TabChukiloto.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.loto1 = "0" + (object) index;
        loto.loto2 = "aa";
        this.listLotoBachThu.Add(loto);
      }
    }

    private void TaoListLotoTrungDau(int biendo)
    {
      this.listLotoTrungDau = new List<TabChukiloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabChukiloto.LOTO loto = new TabChukiloto.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.loto1 = "0" + (object) index;
        loto.loto2 = this.BienDoiLoToTrungDau(loto.loto1, biendo);
        if (!(loto.loto2 == ""))
          this.listLotoTrungDau.Add(loto);
      }
    }

    private void TaoListLotoTrungDuoi(int biendo)
    {
      this.listLotoTrungDuoi = new List<TabChukiloto.LOTO>();
      for (int index = 0; index < 100; ++index)
      {
        TabChukiloto.LOTO loto = new TabChukiloto.LOTO()
        {
          loto1 = index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        };
        if (index < 10)
          loto.loto1 = "0" + (object) index;
        loto.loto2 = this.BienDoiLoToTrungDuoi(loto.loto1, biendo);
        if (!(loto.loto2 == ""))
          this.listLotoTrungDuoi.Add(loto);
      }
    }

    private void TaoListLotoTuDo()
    {
      this.listLotoTuDo = new List<TabChukiloto.LOTO>();
      for (int index1 = 0; index1 < 100; ++index1)
      {
        for (int index2 = 0; index2 < 100; ++index2)
        {
          if (index1 != index2)
          {
            TabChukiloto.LOTO LOTO = new TabChukiloto.LOTO()
            {
              loto1 = index1.ToString((IFormatProvider) CultureInfo.InvariantCulture),
              loto2 = index2.ToString((IFormatProvider) CultureInfo.InvariantCulture)
            };
            if (index1 < 10)
              LOTO.loto1 = "0" + (object) index1;
            string loto1 = LOTO.loto1;
            if (index2 < 10)
              LOTO.loto2 = "0" + (object) index2;
            if (Convert.ToInt32(LOTO.loto1) > Convert.ToInt32(LOTO.loto2))
            {
              LOTO.loto1 = LOTO.loto2;
              LOTO.loto2 = loto1;
            }
            if (!this.listLotoTuDo.Any<TabChukiloto.LOTO>((Func<TabChukiloto.LOTO, bool>) (item =>
            {
              if (item.loto1 == LOTO.loto1)
                return item.loto2 == LOTO.loto2;
              return false;
            })))
              this.listLotoTuDo.Add(LOTO);
          }
        }
      }
    }

    private string BienDoiLoToTrungDau(string lototrungdau, int bienDo)
    {
      string str = (int.Parse(lototrungdau) + bienDo).ToString((IFormatProvider) CultureInfo.InvariantCulture);
      if (str.Length < 2)
        str = "0" + str;
      if (lototrungdau.Substring(0, 1) != str.Substring(0, 1))
        str = "";
      return str;
    }

    private string BienDoiLoToTrungDuoi(string lotoTam, int bienDo)
    {
      string s = (int.Parse(lotoTam.Substring(0, 1)) + bienDo).ToString((IFormatProvider) CultureInfo.InvariantCulture) + lotoTam.Substring(1, 1);
      if (lotoTam.Substring(1, 1) != s.Substring(1, 1))
        s = "";
      else if (int.Parse(s) > 99)
        s = "";
      return s;
    }

    private void bgKhoitaodulieu_DoWork(object sender, DoWorkEventArgs e)
    {
      this.dtNgayXem.Value = FMain.NgayKetQuaMoiNhat;
      this.TaoListLotoCap();
      this.TaoListLotoBachThu();
      this.TaoListLotoTrungDau(this.biendotrungdau);
      this.TaoListLotoTrungDuoi(this.biendotrungduoi);
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      this.soBanGhiVe = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
    }

    private void bgKhoitaolotudo_DoWork(object sender, DoWorkEventArgs e)
    {
      this.TaoListLotoTuDo();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.bgGetCauHinh.IsBusy || this.bgKhoitaodulieu.IsBusy || (this.bgProcess.IsBusy || this.bg1.IsBusy) || (this.bg2.IsBusy || this.bg3.IsBusy || this.bg4.IsBusy) || this.bg5.IsBusy)
      {
        this.picLoading.Visible = true;
        this.btnThongke.Enabled = false;
      }
      else
      {
        this.picLoading.Visible = false;
        this.btnThongke.Enabled = true;
      }
    }

    private void DoiMauTXT(TextBox sender, bool check)
    {
      if (check)
        return;
      sender.Focus();
      sender.BackColor = Color.Red;
      sender.ForeColor = Color.Black;
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      if (this.bgProcess.IsBusy)
        return;
      this.GetSoBanGhiVe();
      this.txtBiendongay.Text = this.Get_Str_Loto(this.txtBiendongay.Text);
      this.txtBiendongay.BackColor = Color.White;
      this.txtBiendongay.ForeColor = Color.Red;
      if (this.txtBiendongay.Text.Length < 1 || this.txtBiendongay.Text.Length > 5)
        this.DoiMauTXT(this.txtBiendongay, false);
      else if (Convert.ToInt32(this.txtBiendongay.Text) > 723 || Convert.ToInt32(this.txtBiendongay.Text) < 10)
      {
        int num = (int) MessageBox.Show(Resources.TabChukiloto_btnThongke_Click_BIÊN_ĐỘ_NGÀY_MUỐN_XEM_PHẢI_LỚN_HƠN_20_NGÀY_VÀ_NHỎ_HƠN_365_NGÀY_, Resources.TabTanxuatloto_btnThongke_Click_GỢI_Ý, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.DoiMauTXT(this.txtBiendongay, false);
      }
      else
      {
        this.objLoailoto.Solanve = this.cbSolanve.Checked;
        this.objLoailoto.Sonhayve = this.cbSoNhayve.Checked;
        this.objLoailoto.Ngaychuara = this.cbNgaychuara.Checked;
        this.objLoailoto.Gantrongkhung = this.cbGantrongkhung.Checked;
        this.objLoailoto.Gan2nam = this.cbGan2nam.Checked;
        this.objLoailoto.Diemtanxuat = this.cbDiemtanxuat.Checked;
        this.objLoailoto.Diemgan = this.cbDiemgan.Checked;
        this.objLoailoto.SolanveNho = Convert.ToInt32(this.numSolanveBe.Value);
        this.objLoailoto.SolanveLon = Convert.ToInt32(this.numSolanveLon.Value);
        this.objLoailoto.SonhayveNho = Convert.ToInt32(this.numSonhayveBe.Value);
        this.objLoailoto.SonhayveLon = Convert.ToInt32(this.numSonhayveLon.Value);
        this.objLoailoto.NgaychuaraNho = Convert.ToInt32(this.numNgaychuaraBe.Value);
        this.objLoailoto.NgaychuaraLon = Convert.ToInt32(this.numNgaychuaraLon.Value);
        this.objLoailoto.GantrongkhungNho = Convert.ToInt32(this.numGantrongkhungBe.Value);
        this.objLoailoto.GantrongkhungLon = Convert.ToInt32(this.numGantrongkhungLon.Value);
        this.objLoailoto.Gan2namNho = Convert.ToInt32(this.numGan2namNho.Value);
        this.objLoailoto.Gan2namLon = Convert.ToInt32(this.numGan2namLon.Value);
        this.objLoailoto.DiemtanxuatNho = this.numTanxuatBe.Value;
        this.objLoailoto.DiemtanxuatLon = this.numTanxuatLon.Value;
        this.objLoailoto.DiemganNho = this.numDiemganNho.Value;
        this.objLoailoto.DiemganLon = this.numDiemganLon.Value;
        this.objLoailoto.Biendongaykiemtra = Convert.ToInt32(this.txtBiendongay.Text);
        this.objLoailoto.Insert(this.objLoailoto);
        if (this.biendotrungdau != FMain.ObjConfigBacNho.BiendoTrungDau || this.biendotrungduoi != FMain.ObjConfigBacNho.BiendoTrungDuoi)
        {
          this.biendotrungdau = FMain.ObjConfigBacNho.BiendoTrungDau;
          this.biendotrungduoi = FMain.ObjConfigBacNho.BiendoTrungDuoi;
          this.TaoListLotoTrungDau(this.biendotrungdau);
          this.TaoListLotoTrungDuoi(this.biendotrungduoi);
        }
        if (this.rdCap.Checked)
          this.listLotoChuan = new List<TabChukiloto.LOTO>((IEnumerable<TabChukiloto.LOTO>) this.listLotoCap);
        else if (this.rdBachThu.Checked)
          this.listLotoChuan = new List<TabChukiloto.LOTO>((IEnumerable<TabChukiloto.LOTO>) this.listLotoBachThu);
        else if (this.rdTrungDau.Checked)
          this.listLotoChuan = new List<TabChukiloto.LOTO>((IEnumerable<TabChukiloto.LOTO>) this.listLotoTrungDau);
        else if (this.rdTrungDuoi.Checked)
          this.listLotoChuan = new List<TabChukiloto.LOTO>((IEnumerable<TabChukiloto.LOTO>) this.listLotoTrungDuoi);
        else if (this.rdTuDo.Checked)
          this.listLotoChuan = new List<TabChukiloto.LOTO>((IEnumerable<TabChukiloto.LOTO>) this.listLotoTuDo);
        this.bgProcess.RunWorkerAsync();
      }
    }

    private string Get_Str_Loto(string strTxtLoto)
    {
      string str = strTxtLoto;
      string empty = string.Empty;
      for (int index = 0; index < str.Length; ++index)
      {
        if (char.IsDigit(str[index]))
          empty += str[index].ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      return empty;
    }

    private void bgProcess_DoWork(object sender, DoWorkEventArgs e)
    {
      this.sobanghi = Convert.ToInt32(this.txtBiendongay.Text);
      DateTime dateTime = this.dtNgayXem.Value;
      if (this.soBanGhiVeCu != this.soBanGhiVe || this.dtNgayXem.Value != this.ngayThangCu)
      {
        this.dtLOTO_NGAYSAU = new DataTable();
        this.dtLOTO_NGAYSAU = this.objLoto.GetLotoByNgayThangSoBanGhi(dateTime, this.soBanGhiVe);
        this.soBanGhiVeCu = this.soBanGhiVe;
      }
      if (this.dtNgayXem.Value != this.ngayThangCu || this.soBanGhiCu != this.sobanghi)
      {
        this.dtLoto = new DataTable();
        this.dtLoto = this.objLoto.TblotoGetByDateSoBanGhiTrovetruoc(dateTime, this.sobanghi + 726);
        this.ngayThangCu = this.dtNgayXem.Value;
        this.soBanGhiCu = this.sobanghi;
      }
      this.solotomoiphan = this.listLotoChuan.Count / 5;
      if (this.bg1.IsBusy || this.bg2.IsBusy || (this.bg3.IsBusy || this.bg4.IsBusy) || (this.bg5.IsBusy || this.bgKhoitaodulieu.IsBusy) || this.bgKhoitaolotudo.IsBusy)
        return;
      this.KhoiTao_DataTable1();
      this.KhoiTao_DataTable2();
      this.KhoiTao_DataTable3();
      this.KhoiTao_DataTable4();
      this.KhoiTao_DataTable5();
      this.dt = new DataTable();
      this.bg1.RunWorkerAsync();
      this.bg2.RunWorkerAsync();
      this.bg3.RunWorkerAsync();
      this.bg4.RunWorkerAsync();
      this.bg5.RunWorkerAsync();
    }

    private void Process1(int soThuThuListLoTo, int sobanListLoTo, int sobanghiKT)
    {
      for (int index1 = soThuThuListLoTo; index1 < sobanListLoTo; ++index1)
      {
        string loto1 = this.listLotoChuan[index1].loto1;
        string loto2 = this.listLotoChuan[index1].loto2;
        TabChukiloto.DataRowTable dataRowTable = new TabChukiloto.DataRowTable()
        {
          stt = index1 + 1,
          loto = loto1 + "-" + loto2,
          solanve = 0,
          ngayChuara = 0,
          chuKi = Decimal.Zero,
          maxSobanghi = 0,
          maxGan = 0,
          diemGan = Decimal.Zero,
          diemtanxuat = Decimal.Zero,
          veNgay = 0,
          colTrong = "   "
        };
        if (this.rdBachThu.Checked)
          dataRowTable.loto = loto1;
        int num1 = 0;
        int num2 = 0;
        bool flag1 = false;
        int num3 = 0;
        for (int index2 = 0; index2 < this.dtLoto.Rows.Count; ++index2)
        {
          bool flag2 = false;
          for (int index3 = 2; index3 < this.dtLoto.Columns.Count; ++index3)
          {
            if (loto1 == this.dtLoto.Rows[index2][index3].ToString() || loto2 == this.dtLoto.Rows[index2][index3].ToString())
            {
              flag2 = true;
              if (index2 < sobanghiKT)
                ++num3;
            }
          }
          if (flag2)
          {
            if (index2 < sobanghiKT)
            {
              ++dataRowTable.solanve;
              num1 = 0;
              flag1 = true;
            }
            num2 = 0;
          }
          else
          {
            if (index2 < sobanghiKT)
            {
              ++num1;
              if (num1 > dataRowTable.maxSobanghi)
                dataRowTable.maxSobanghi = num1;
              if (!flag1)
                ++dataRowTable.ngayChuara;
            }
            ++num2;
            if (num2 > dataRowTable.maxGan)
              dataRowTable.maxGan = num2;
          }
        }
        int num4 = dataRowTable.solanve;
        if (num4 == 1)
          num4 = 2;
        if ((uint) num4 > 0U)
          dataRowTable.chuKi = Math.Round(Convert.ToDecimal(sobanghiKT) / (Decimal) num4, 1);
        dataRowTable.diemGan = Convert.ToDecimal(dataRowTable.ngayChuara) / (Decimal) dataRowTable.maxGan * new Decimal(10);
        dataRowTable.diemGan = Math.Round(dataRowTable.diemGan, 1);
        dataRowTable.diemtanxuat = ((Decimal) dataRowTable.ngayChuara + dataRowTable.chuKi) / new Decimal(2);
        dataRowTable.diemtanxuat = dataRowTable.diemtanxuat / (Decimal) dataRowTable.maxSobanghi * new Decimal(10);
        dataRowTable.diemtanxuat = Math.Round(dataRowTable.diemtanxuat, 1);
        dataRowTable.veNgay = this.CheckVENGAY1(this.listLotoChuan[index1]);
        DataRow row = this.dataTable1.NewRow();
        row["stt"] = (object) dataRowTable.stt;
        row["loto"] = (object) dataRowTable.loto;
        row["solanve"] = (object) dataRowTable.solanve;
        row["ngayChuara"] = (object) dataRowTable.ngayChuara;
        row["chuKi"] = (object) dataRowTable.chuKi;
        row["maxSobanghi"] = (object) dataRowTable.maxSobanghi;
        row["maxGan"] = (object) dataRowTable.maxGan;
        row["diemtanxuat"] = (object) dataRowTable.diemtanxuat;
        row["diemGan"] = (object) dataRowTable.diemGan;
        row["veNgay"] = (object) dataRowTable.veNgay;
        row["soNhayVe"] = (object) num3;
        row["colTrong"] = (object) dataRowTable.colTrong;
        this.dataTable1.Rows.Add(row);
      }
    }

    private void Process2(int soThuThuListLoTo, int sobanListLoTo, int sobanghiKT)
    {
      for (int index1 = soThuThuListLoTo; index1 < sobanListLoTo; ++index1)
      {
        string loto1 = this.listLotoChuan[index1].loto1;
        string loto2 = this.listLotoChuan[index1].loto2;
        TabChukiloto.DataRowTable dataRowTable = new TabChukiloto.DataRowTable()
        {
          stt = index1 + 1,
          loto = loto1 + "-" + loto2,
          solanve = 0,
          ngayChuara = 0,
          chuKi = Decimal.Zero,
          maxSobanghi = 0,
          maxGan = 0,
          diemGan = Decimal.Zero,
          diemtanxuat = Decimal.Zero,
          veNgay = 0,
          colTrong = "   "
        };
        if (this.rdBachThu.Checked)
          dataRowTable.loto = loto1;
        int num1 = 0;
        int num2 = 0;
        bool flag1 = false;
        int num3 = 0;
        for (int index2 = 0; index2 < this.dtLoto.Rows.Count; ++index2)
        {
          bool flag2 = false;
          for (int index3 = 2; index3 < this.dtLoto.Columns.Count; ++index3)
          {
            if (loto1 == this.dtLoto.Rows[index2][index3].ToString() || loto2 == this.dtLoto.Rows[index2][index3].ToString())
            {
              flag2 = true;
              if (index2 < sobanghiKT)
                ++num3;
            }
          }
          if (flag2)
          {
            if (index2 < sobanghiKT)
            {
              ++dataRowTable.solanve;
              num1 = 0;
              flag1 = true;
            }
            num2 = 0;
          }
          else
          {
            if (index2 < sobanghiKT)
            {
              ++num1;
              if (num1 > dataRowTable.maxSobanghi)
                dataRowTable.maxSobanghi = num1;
              if (!flag1)
                ++dataRowTable.ngayChuara;
            }
            ++num2;
            if (num2 > dataRowTable.maxGan)
              dataRowTable.maxGan = num2;
          }
        }
        int num4 = dataRowTable.solanve;
        if (num4 == 1)
          num4 = 2;
        if ((uint) num4 > 0U)
          dataRowTable.chuKi = Math.Round(Convert.ToDecimal(sobanghiKT) / (Decimal) num4, 1);
        dataRowTable.diemGan = Convert.ToDecimal(dataRowTable.ngayChuara) / (Decimal) dataRowTable.maxGan * new Decimal(10);
        dataRowTable.diemGan = Math.Round(dataRowTable.diemGan, 1);
        dataRowTable.diemtanxuat = ((Decimal) dataRowTable.ngayChuara + dataRowTable.chuKi) / new Decimal(2);
        dataRowTable.diemtanxuat = dataRowTable.maxSobanghi <= 0 ? Decimal.Zero : dataRowTable.diemtanxuat / (Decimal) dataRowTable.maxSobanghi * new Decimal(10);
        dataRowTable.diemtanxuat = Math.Round(dataRowTable.diemtanxuat, 1);
        dataRowTable.veNgay = this.CheckVENGAY1(this.listLotoChuan[index1]);
        DataRow row = this.dataTable2.NewRow();
        row["stt"] = (object) dataRowTable.stt;
        row["loto"] = (object) dataRowTable.loto;
        row["solanve"] = (object) dataRowTable.solanve;
        row["ngayChuara"] = (object) dataRowTable.ngayChuara;
        row["chuKi"] = (object) dataRowTable.chuKi;
        row["maxSobanghi"] = (object) dataRowTable.maxSobanghi;
        row["maxGan"] = (object) dataRowTable.maxGan;
        row["diemtanxuat"] = (object) dataRowTable.diemtanxuat;
        row["diemGan"] = (object) dataRowTable.diemGan;
        row["veNgay"] = (object) dataRowTable.veNgay;
        row["soNhayVe"] = (object) num3;
        row["colTrong"] = (object) dataRowTable.colTrong;
        this.dataTable2.Rows.Add(row);
      }
    }

    private void Process3(int soThuThuListLoTo, int sobanListLoTo, int sobanghiKT)
    {
      for (int index1 = soThuThuListLoTo; index1 < sobanListLoTo; ++index1)
      {
        string loto1 = this.listLotoChuan[index1].loto1;
        string loto2 = this.listLotoChuan[index1].loto2;
        TabChukiloto.DataRowTable dataRowTable = new TabChukiloto.DataRowTable()
        {
          stt = index1 + 1,
          loto = loto1 + "-" + loto2,
          solanve = 0,
          ngayChuara = 0,
          chuKi = Decimal.Zero,
          maxSobanghi = 0,
          maxGan = 0,
          diemGan = Decimal.Zero,
          diemtanxuat = Decimal.Zero,
          veNgay = 0,
          colTrong = "   "
        };
        if (this.rdBachThu.Checked)
          dataRowTable.loto = loto1;
        int num1 = 0;
        int num2 = 0;
        bool flag1 = false;
        int num3 = 0;
        for (int index2 = 0; index2 < this.dtLoto.Rows.Count; ++index2)
        {
          bool flag2 = false;
          for (int index3 = 2; index3 < this.dtLoto.Columns.Count; ++index3)
          {
            if (loto1 == this.dtLoto.Rows[index2][index3].ToString() || loto2 == this.dtLoto.Rows[index2][index3].ToString())
            {
              flag2 = true;
              if (index2 < sobanghiKT)
                ++num3;
            }
          }
          if (flag2)
          {
            if (index2 < sobanghiKT)
            {
              ++dataRowTable.solanve;
              num1 = 0;
              flag1 = true;
            }
            num2 = 0;
          }
          else
          {
            if (index2 < sobanghiKT)
            {
              ++num1;
              if (num1 > dataRowTable.maxSobanghi)
                dataRowTable.maxSobanghi = num1;
              if (!flag1)
                ++dataRowTable.ngayChuara;
            }
            ++num2;
            if (num2 > dataRowTable.maxGan)
              dataRowTable.maxGan = num2;
          }
        }
        int num4 = dataRowTable.solanve;
        if (num4 == 1)
          num4 = 2;
        if ((uint) num4 > 0U)
          dataRowTable.chuKi = Math.Round(Convert.ToDecimal(sobanghiKT) / (Decimal) num4, 1);
        dataRowTable.diemGan = Convert.ToDecimal(dataRowTable.ngayChuara) / (Decimal) dataRowTable.maxGan * new Decimal(10);
        dataRowTable.diemGan = Math.Round(dataRowTable.diemGan, 1);
        dataRowTable.diemtanxuat = ((Decimal) dataRowTable.ngayChuara + dataRowTable.chuKi) / new Decimal(2);
        dataRowTable.diemtanxuat = dataRowTable.diemtanxuat / (Decimal) dataRowTable.maxSobanghi * new Decimal(10);
        dataRowTable.diemtanxuat = Math.Round(dataRowTable.diemtanxuat, 1);
        dataRowTable.veNgay = this.CheckVENGAY1(this.listLotoChuan[index1]);
        DataRow row = this.dataTable3.NewRow();
        row["stt"] = (object) dataRowTable.stt;
        row["loto"] = (object) dataRowTable.loto;
        row["solanve"] = (object) dataRowTable.solanve;
        row["ngayChuara"] = (object) dataRowTable.ngayChuara;
        row["chuKi"] = (object) dataRowTable.chuKi;
        row["maxSobanghi"] = (object) dataRowTable.maxSobanghi;
        row["maxGan"] = (object) dataRowTable.maxGan;
        row["diemtanxuat"] = (object) dataRowTable.diemtanxuat;
        row["diemGan"] = (object) dataRowTable.diemGan;
        row["veNgay"] = (object) dataRowTable.veNgay;
        row["soNhayVe"] = (object) num3;
        row["colTrong"] = (object) dataRowTable.colTrong;
        this.dataTable3.Rows.Add(row);
      }
    }

    private void Process4(int soThuThuListLoTo, int sobanListLoTo, int sobanghiKT)
    {
      for (int index1 = soThuThuListLoTo; index1 < sobanListLoTo; ++index1)
      {
        string loto1 = this.listLotoChuan[index1].loto1;
        string loto2 = this.listLotoChuan[index1].loto2;
        TabChukiloto.DataRowTable dataRowTable = new TabChukiloto.DataRowTable()
        {
          stt = index1 + 1,
          loto = loto1 + "-" + loto2,
          solanve = 0,
          ngayChuara = 0,
          chuKi = Decimal.Zero,
          maxSobanghi = 0,
          maxGan = 0,
          diemGan = Decimal.Zero,
          diemtanxuat = Decimal.Zero,
          veNgay = 0,
          colTrong = "   "
        };
        if (this.rdBachThu.Checked)
          dataRowTable.loto = loto1;
        int num1 = 0;
        int num2 = 0;
        bool flag1 = false;
        int num3 = 0;
        for (int index2 = 0; index2 < this.dtLoto.Rows.Count; ++index2)
        {
          bool flag2 = false;
          for (int index3 = 2; index3 < this.dtLoto.Columns.Count; ++index3)
          {
            if (loto1 == this.dtLoto.Rows[index2][index3].ToString() || loto2 == this.dtLoto.Rows[index2][index3].ToString())
            {
              flag2 = true;
              if (index2 < sobanghiKT)
                ++num3;
            }
          }
          if (flag2)
          {
            if (index2 < sobanghiKT)
            {
              ++dataRowTable.solanve;
              num1 = 0;
              flag1 = true;
            }
            num2 = 0;
          }
          else
          {
            if (index2 < sobanghiKT)
            {
              ++num1;
              if (num1 > dataRowTable.maxSobanghi)
                dataRowTable.maxSobanghi = num1;
              if (!flag1)
                ++dataRowTable.ngayChuara;
            }
            ++num2;
            if (num2 > dataRowTable.maxGan)
              dataRowTable.maxGan = num2;
          }
        }
        int num4 = dataRowTable.solanve;
        if (num4 == 1)
          num4 = 2;
        if ((uint) num4 > 0U)
          dataRowTable.chuKi = Math.Round(Convert.ToDecimal(sobanghiKT) / (Decimal) num4, 1);
        dataRowTable.diemGan = Convert.ToDecimal(dataRowTable.ngayChuara) / (Decimal) dataRowTable.maxGan * new Decimal(10);
        dataRowTable.diemGan = Math.Round(dataRowTable.diemGan, 1);
        dataRowTable.diemtanxuat = ((Decimal) dataRowTable.ngayChuara + dataRowTable.chuKi) / new Decimal(2);
        dataRowTable.diemtanxuat = dataRowTable.diemtanxuat / (Decimal) dataRowTable.maxSobanghi * new Decimal(10);
        dataRowTable.diemtanxuat = Math.Round(dataRowTable.diemtanxuat, 1);
        dataRowTable.veNgay = this.CheckVENGAY1(this.listLotoChuan[index1]);
        DataRow row = this.dataTable4.NewRow();
        row["stt"] = (object) dataRowTable.stt;
        row["loto"] = (object) dataRowTable.loto;
        row["solanve"] = (object) dataRowTable.solanve;
        row["ngayChuara"] = (object) dataRowTable.ngayChuara;
        row["chuKi"] = (object) dataRowTable.chuKi;
        row["maxSobanghi"] = (object) dataRowTable.maxSobanghi;
        row["maxGan"] = (object) dataRowTable.maxGan;
        row["diemtanxuat"] = (object) dataRowTable.diemtanxuat;
        row["diemGan"] = (object) dataRowTable.diemGan;
        row["veNgay"] = (object) dataRowTable.veNgay;
        row["soNhayVe"] = (object) num3;
        row["colTrong"] = (object) dataRowTable.colTrong;
        this.dataTable4.Rows.Add(row);
      }
    }

    private void Process5(int soThuThuListLoTo, int sobanListLoTo, int sobanghiKT)
    {
      for (int index1 = soThuThuListLoTo; index1 < sobanListLoTo; ++index1)
      {
        string loto1 = this.listLotoChuan[index1].loto1;
        string loto2 = this.listLotoChuan[index1].loto2;
        TabChukiloto.DataRowTable dataRowTable = new TabChukiloto.DataRowTable()
        {
          stt = index1 + 1,
          loto = loto1 + "-" + loto2,
          solanve = 0,
          ngayChuara = 0,
          chuKi = Decimal.Zero,
          maxSobanghi = 0,
          maxGan = 0,
          diemGan = Decimal.Zero,
          diemtanxuat = Decimal.Zero,
          veNgay = 0,
          colTrong = "   "
        };
        if (this.rdBachThu.Checked)
          dataRowTable.loto = loto1;
        int num1 = 0;
        int num2 = 0;
        bool flag1 = false;
        int num3 = 0;
        for (int index2 = 0; index2 < this.dtLoto.Rows.Count; ++index2)
        {
          bool flag2 = false;
          for (int index3 = 2; index3 < this.dtLoto.Columns.Count; ++index3)
          {
            if (loto1 == this.dtLoto.Rows[index2][index3].ToString() || loto2 == this.dtLoto.Rows[index2][index3].ToString())
            {
              flag2 = true;
              if (index2 < sobanghiKT)
                ++num3;
            }
          }
          if (flag2)
          {
            if (index2 < sobanghiKT)
            {
              ++dataRowTable.solanve;
              num1 = 0;
              flag1 = true;
            }
            num2 = 0;
          }
          else
          {
            if (index2 < sobanghiKT)
            {
              ++num1;
              if (num1 > dataRowTable.maxSobanghi)
                dataRowTable.maxSobanghi = num1;
              if (!flag1)
                ++dataRowTable.ngayChuara;
            }
            ++num2;
            if (num2 > dataRowTable.maxGan)
              dataRowTable.maxGan = num2;
          }
        }
        int num4 = dataRowTable.solanve;
        if (num4 == 1)
          num4 = 2;
        if ((uint) num4 > 0U)
          dataRowTable.chuKi = Math.Round(Convert.ToDecimal(sobanghiKT) / (Decimal) num4, 1);
        dataRowTable.diemGan = Convert.ToDecimal(dataRowTable.ngayChuara) / (Decimal) dataRowTable.maxGan * new Decimal(10);
        dataRowTable.diemGan = Math.Round(dataRowTable.diemGan, 1);
        dataRowTable.diemtanxuat = ((Decimal) dataRowTable.ngayChuara + dataRowTable.chuKi) / new Decimal(2);
        dataRowTable.diemtanxuat = dataRowTable.diemtanxuat / (Decimal) dataRowTable.maxSobanghi * new Decimal(10);
        dataRowTable.diemtanxuat = Math.Round(dataRowTable.diemtanxuat, 1);
        dataRowTable.veNgay = this.CheckVENGAY1(this.listLotoChuan[index1]);
        DataRow row = this.dataTable5.NewRow();
        row["stt"] = (object) dataRowTable.stt;
        row["loto"] = (object) dataRowTable.loto;
        row["solanve"] = (object) dataRowTable.solanve;
        row["ngayChuara"] = (object) dataRowTable.ngayChuara;
        row["chuKi"] = (object) dataRowTable.chuKi;
        row["maxSobanghi"] = (object) dataRowTable.maxSobanghi;
        row["maxGan"] = (object) dataRowTable.maxGan;
        row["diemtanxuat"] = (object) dataRowTable.diemtanxuat;
        row["diemGan"] = (object) dataRowTable.diemGan;
        row["veNgay"] = (object) dataRowTable.veNgay;
        row["soNhayVe"] = (object) num3;
        row["colTrong"] = (object) dataRowTable.colTrong;
        this.dataTable5.Rows.Add(row);
      }
    }

    public int CheckVENGAY1(TabChukiloto.LOTO lotoCheck)
    {
      int num1 = 0;
      if (FMain.ObjConfigBacNho.HienThiNgayVe == 1 && this.dtLOTO_NGAYSAU.Rows.Count > 0)
      {
        int num2 = 0;
        bool flag = false;
        for (int index1 = 0; index1 < this.dtLOTO_NGAYSAU.Rows.Count; ++index1)
        {
          for (int index2 = 2; index2 < this.dtLOTO_NGAYSAU.Columns.Count; ++index2)
          {
            string str = this.dtLOTO_NGAYSAU.Rows[index1][index2].ToString().Trim();
            if (str == lotoCheck.loto1 || str == lotoCheck.loto2)
            {
              num2 = index1 + 1;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if ((uint) num2 > 0U)
          num1 = num2;
      }
      return num1;
    }

    public int CheckVENGAY2(TabChukiloto.LOTO lotoCheck)
    {
      int num1 = 0;
      if (FMain.ObjConfigBacNho.HienThiNgayVe == 1 && this.dtLOTO_NGAYSAU.Rows.Count > 0)
      {
        int num2 = 0;
        bool flag = false;
        for (int index1 = 0; index1 < this.dtLOTO_NGAYSAU.Rows.Count; ++index1)
        {
          for (int index2 = 2; index2 < this.dtLOTO_NGAYSAU.Columns.Count; ++index2)
          {
            string str = this.dtLOTO_NGAYSAU.Rows[index1][index2].ToString().Trim();
            if (str == lotoCheck.loto1 || str == lotoCheck.loto2)
            {
              num2 = index1 + 1;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if ((uint) num2 > 0U)
          num1 = num2;
      }
      return num1;
    }

    public int CheckVENGAY3(TabChukiloto.LOTO lotoCheck)
    {
      int num1 = 0;
      if (FMain.ObjConfigBacNho.HienThiNgayVe == 1 && this.dtLOTO_NGAYSAU.Rows.Count > 0)
      {
        int num2 = 0;
        bool flag = false;
        for (int index1 = 0; index1 < this.dtLOTO_NGAYSAU.Rows.Count; ++index1)
        {
          for (int index2 = 2; index2 < this.dtLOTO_NGAYSAU.Columns.Count; ++index2)
          {
            string str = this.dtLOTO_NGAYSAU.Rows[index1][index2].ToString().Trim();
            if (str == lotoCheck.loto1 || str == lotoCheck.loto2)
            {
              num2 = index1 + 1;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if ((uint) num2 > 0U)
          num1 = num2;
      }
      return num1;
    }

    public int CheckVENGAY4(TabChukiloto.LOTO lotoCheck)
    {
      int num1 = 0;
      if (FMain.ObjConfigBacNho.HienThiNgayVe == 1 && this.dtLOTO_NGAYSAU.Rows.Count > 0)
      {
        int num2 = 0;
        bool flag = false;
        for (int index1 = 0; index1 < this.dtLOTO_NGAYSAU.Rows.Count; ++index1)
        {
          for (int index2 = 2; index2 < this.dtLOTO_NGAYSAU.Columns.Count; ++index2)
          {
            string str = this.dtLOTO_NGAYSAU.Rows[index1][index2].ToString().Trim();
            if (str == lotoCheck.loto1 || str == lotoCheck.loto2)
            {
              num2 = index1 + 1;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if ((uint) num2 > 0U)
          num1 = num2;
      }
      return num1;
    }

    public int CheckVENGAY5(TabChukiloto.LOTO lotoCheck)
    {
      int num1 = 0;
      if (FMain.ObjConfigBacNho.HienThiNgayVe == 1 && this.dtLOTO_NGAYSAU.Rows.Count > 0)
      {
        int num2 = 0;
        bool flag = false;
        for (int index1 = 0; index1 < this.dtLOTO_NGAYSAU.Rows.Count; ++index1)
        {
          for (int index2 = 2; index2 < this.dtLOTO_NGAYSAU.Columns.Count; ++index2)
          {
            string str = this.dtLOTO_NGAYSAU.Rows[index1][index2].ToString().Trim();
            if (str == lotoCheck.loto1 || str == lotoCheck.loto2)
            {
              num2 = index1 + 1;
              flag = true;
              break;
            }
          }
          if (flag)
            break;
        }
        if ((uint) num2 > 0U)
          num1 = num2;
      }
      return num1;
    }

    private void bg1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Process1(0, this.solotomoiphan, this.sobanghi);
    }

    private void bg2_DoWork(object sender, DoWorkEventArgs e)
    {
      int solotomoiphan = this.solotomoiphan;
      int sobanListLoTo = solotomoiphan + this.solotomoiphan;
      this.Process2(solotomoiphan, sobanListLoTo, this.sobanghi);
    }

    private void bg3_DoWork(object sender, DoWorkEventArgs e)
    {
      int soThuThuListLoTo = 2 * this.solotomoiphan;
      int sobanListLoTo = soThuThuListLoTo + this.solotomoiphan;
      this.Process3(soThuThuListLoTo, sobanListLoTo, this.sobanghi);
    }

    private void bg4_DoWork(object sender, DoWorkEventArgs e)
    {
      int soThuThuListLoTo = 3 * this.solotomoiphan;
      int sobanListLoTo = soThuThuListLoTo + this.solotomoiphan;
      this.Process4(soThuThuListLoTo, sobanListLoTo, this.sobanghi);
    }

    private void bg5_DoWork(object sender, DoWorkEventArgs e)
    {
      this.Process5(4 * this.solotomoiphan, this.listLotoChuan.Count, this.sobanghi);
    }

    private void bg1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.bg1.IsBusy || this.bg2.IsBusy || (this.bg3.IsBusy || this.bg4.IsBusy) || this.bg5.IsBusy)
        return;
      this.HienThi();
    }

    private void bg2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.bg1.IsBusy || this.bg2.IsBusy || (this.bg3.IsBusy || this.bg4.IsBusy) || this.bg5.IsBusy)
        return;
      this.HienThi();
    }

    private void bg3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.bg1.IsBusy || this.bg2.IsBusy || (this.bg3.IsBusy || this.bg4.IsBusy) || this.bg5.IsBusy)
        return;
      this.HienThi();
    }

    private void bg4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.bg1.IsBusy || this.bg2.IsBusy || (this.bg3.IsBusy || this.bg4.IsBusy) || this.bg5.IsBusy)
        return;
      this.HienThi();
    }

    private void bg5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (this.bg1.IsBusy || this.bg2.IsBusy || (this.bg3.IsBusy || this.bg4.IsBusy) || this.bg5.IsBusy)
        return;
      this.HienThi();
    }

    private void HienThi()
    {
      try
      {
        this.dt = new DataTable();
        this.dt.Merge(this.dataTable1);
        this.dt.Merge(this.dataTable2);
        this.dt.Merge(this.dataTable3);
        this.dt.Merge(this.dataTable4);
        this.dt.Merge(this.dataTable5);
        DataTable dtTemp = this.dt;
        if (this.dt.Rows.Count > 0)
        {
          if (this.cbSolanve.Checked)
          {
            string filterExpression = "solanve>='" + (object) this.numSolanveBe.Value + "' and solanve<='" + (object) this.numSolanveLon.Value + "' ";
            DataRow[] dataRowArray = dtTemp.Select(filterExpression);
            if ((uint) dataRowArray.Length > 0U)
              dtTemp = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
            else
              dtTemp.Rows.Clear();
          }
          if (this.cbSoNhayve.Checked)
          {
            string filterExpression = "soNhayVe>='" + (object) this.numSonhayveBe.Value + "' and soNhayVe<='" + (object) this.numSonhayveLon.Value + "' ";
            DataRow[] dataRowArray = dtTemp.Select(filterExpression);
            if ((uint) dataRowArray.Length > 0U)
              dtTemp = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
            else
              dtTemp.Rows.Clear();
          }
          if (this.cbNgaychuara.Checked)
          {
            string filterExpression = "ngayChuara>='" + (object) this.numNgaychuaraBe.Value + "' and ngayChuara<='" + (object) this.numNgaychuaraLon.Value + "' ";
            DataRow[] dataRowArray = dtTemp.Select(filterExpression);
            if ((uint) dataRowArray.Length > 0U)
              dtTemp = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
            else
              dtTemp.Rows.Clear();
          }
          if (this.cbGantrongkhung.Checked)
          {
            string filterExpression = "maxSobanghi>='" + (object) this.numGantrongkhungBe.Value + "' and maxSobanghi<='" + (object) this.numGantrongkhungLon.Value + "' ";
            DataRow[] dataRowArray = dtTemp.Select(filterExpression);
            if ((uint) dataRowArray.Length > 0U)
              dtTemp = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
            else
              dtTemp.Rows.Clear();
          }
          if (this.cbGan2nam.Checked)
          {
            string filterExpression = "maxGan>='" + (object) this.numGan2namNho.Value + "' and maxGan<='" + (object) this.numGan2namLon.Value + "' ";
            DataRow[] dataRowArray = dtTemp.Select(filterExpression);
            if ((uint) dataRowArray.Length > 0U)
              dtTemp = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
            else
              dtTemp.Rows.Clear();
          }
          if (this.cbDiemtanxuat.Checked)
          {
            string filterExpression = "diemtanxuat>='" + (object) this.numTanxuatBe.Value + "' and diemtanxuat<='" + (object) this.numTanxuatLon.Value + "' ";
            DataRow[] dataRowArray = dtTemp.Select(filterExpression);
            if ((uint) dataRowArray.Length > 0U)
              dtTemp = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
            else
              dtTemp.Rows.Clear();
          }
          if (this.cbDiemgan.Checked)
          {
            string filterExpression = "diemGan>='" + (object) this.numDiemganNho.Value + "' and diemGan<='" + (object) this.numDiemganLon.Value + "' ";
            DataRow[] dataRowArray = dtTemp.Select(filterExpression);
            if ((uint) dataRowArray.Length > 0U)
              dtTemp = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
            else
              dtTemp.Rows.Clear();
          }
          for (int index = 0; index < dtTemp.Rows.Count; ++index)
            dtTemp.Rows[index]["stt"] = (object) (index + 1).ToString();
        }
        DataView defaultView = dtTemp.DefaultView;
        defaultView.Sort = "diemtanxuat DESC";
        dtTemp = defaultView.ToTable();
        this.Invoke((Delegate) (() => this.dtg_Ketqua.DataSource = (object) dtTemp));
      }
      catch
      {
      }
    }

    private void GetSoBanGhiVe()
    {
      if (this.rdBachThu.Checked)
        this.soBanGhiVe = FMain.ObjConfigBacNho.KhungDanhBachThuNuoi;
      else
        this.soBanGhiVe = FMain.ObjConfigBacNho.KhungDanhLoCapNuoi;
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      this.rdTuDo.Enabled = !this.bgKhoitaolotudo.IsBusy;
      if (this.bgKhoitaolotudo.IsBusy)
        return;
      this.timer2.Stop();
    }

    private void xemTầnXuấtBộSốToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Tanxuatloto;
    }

    private void soiCầuBạchThủToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.SoicauLoto;
    }

    private void rdCap_CheckedChanged(object sender, EventArgs e)
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

    private void cbSolanve_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      if (checkBox.Checked)
      {
        checkBox.Text = "Bật";
        checkBox.ForeColor = Color.Red;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Bold);
      }
      else
      {
        checkBox.Text = "Tắt";
        checkBox.ForeColor = Color.Black;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Regular);
      }
    }

    private void bgGetCauHinh_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetLoaiLoto(TbUser.Tbuser.TenDangnhap);
    }

    private void bgGetCauHinh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.cbSolanve.Checked = this.objLoailoto.Solanve;
      this.cbSoNhayve.Checked = this.objLoailoto.Sonhayve;
      this.cbNgaychuara.Checked = this.objLoailoto.Ngaychuara;
      this.cbGantrongkhung.Checked = this.objLoailoto.Gantrongkhung;
      this.cbGan2nam.Checked = this.objLoailoto.Gan2nam;
      this.cbDiemtanxuat.Checked = this.objLoailoto.Diemtanxuat;
      this.cbDiemgan.Checked = this.objLoailoto.Diemgan;
      this.numSolanveBe.Value = (Decimal) this.objLoailoto.SolanveNho;
      this.numSolanveLon.Value = (Decimal) this.objLoailoto.SolanveLon;
      this.numSonhayveBe.Value = (Decimal) this.objLoailoto.SonhayveNho;
      this.numSonhayveLon.Value = (Decimal) this.objLoailoto.SonhayveLon;
      this.numNgaychuaraBe.Value = (Decimal) this.objLoailoto.NgaychuaraNho;
      this.numNgaychuaraLon.Value = (Decimal) this.objLoailoto.NgaychuaraLon;
      this.numGantrongkhungBe.Value = (Decimal) this.objLoailoto.GantrongkhungNho;
      this.numGantrongkhungLon.Value = (Decimal) this.objLoailoto.GantrongkhungLon;
      this.numGan2namNho.Value = (Decimal) this.objLoailoto.Gan2namNho;
      this.numGan2namLon.Value = (Decimal) this.objLoailoto.Gan2namLon;
      this.numTanxuatBe.Value = this.objLoailoto.DiemtanxuatNho;
      this.numTanxuatLon.Value = this.objLoailoto.DiemtanxuatLon;
      this.numDiemganNho.Value = this.objLoailoto.DiemganNho;
      this.numDiemganLon.Value = this.objLoailoto.DiemganLon;
      this.txtBiendongay.Text = this.objLoailoto.Biendongaykiemtra.ToString();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabChukiloto));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1 = new Panel();
      this.groupBox8 = new GroupBox();
      this.cbGan2nam = new CheckBox();
      this.numGan2namLon = new NumericUpDown();
      this.label16 = new Label();
      this.numGan2namNho = new NumericUpDown();
      this.label17 = new Label();
      this.groupBox7 = new GroupBox();
      this.cbDiemgan = new CheckBox();
      this.numDiemganLon = new NumericUpDown();
      this.label14 = new Label();
      this.numDiemganNho = new NumericUpDown();
      this.label15 = new Label();
      this.groupBox6 = new GroupBox();
      this.btnThongke = new Button();
      this.label3 = new Label();
      this.dtNgayXem = new DateTimePicker();
      this.label2 = new Label();
      this.txtBiendongay = new TextBox();
      this.label1 = new Label();
      this.rdTuDo = new RadioButton();
      this.rdCap = new RadioButton();
      this.rdBachThu = new RadioButton();
      this.rdTrungDuoi = new RadioButton();
      this.rdTrungDau = new RadioButton();
      this.groupBox1 = new GroupBox();
      this.cbSolanve = new CheckBox();
      this.numSolanveLon = new NumericUpDown();
      this.label5 = new Label();
      this.numSolanveBe = new NumericUpDown();
      this.label4 = new Label();
      this.groupBox4 = new GroupBox();
      this.cbDiemtanxuat = new CheckBox();
      this.numTanxuatLon = new NumericUpDown();
      this.label10 = new Label();
      this.numTanxuatBe = new NumericUpDown();
      this.label11 = new Label();
      this.groupBox5 = new GroupBox();
      this.cbSoNhayve = new CheckBox();
      this.numSonhayveLon = new NumericUpDown();
      this.label12 = new Label();
      this.numSonhayveBe = new NumericUpDown();
      this.label13 = new Label();
      this.groupBox3 = new GroupBox();
      this.cbGantrongkhung = new CheckBox();
      this.numGantrongkhungLon = new NumericUpDown();
      this.label8 = new Label();
      this.numGantrongkhungBe = new NumericUpDown();
      this.label9 = new Label();
      this.groupBox2 = new GroupBox();
      this.cbNgaychuara = new CheckBox();
      this.numNgaychuaraLon = new NumericUpDown();
      this.label6 = new Label();
      this.numNgaychuaraBe = new NumericUpDown();
      this.label7 = new Label();
      this.toolTip1 = new ToolTip(this.components);
      this.bgKhoitaodulieu = new BackgroundWorker();
      this.bgKhoitaolotudo = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.bgProcess = new BackgroundWorker();
      this.bg1 = new BackgroundWorker();
      this.bg2 = new BackgroundWorker();
      this.bg3 = new BackgroundWorker();
      this.bg4 = new BackgroundWorker();
      this.bg5 = new BackgroundWorker();
      this.picLoading = new PictureBox();
      this.panel2 = new Panel();
      this.dtg_Ketqua = new DataGridView();
      this.stt = new DataGridViewTextBoxColumn();
      this.loto = new DataGridViewTextBoxColumn();
      this.solanve = new DataGridViewTextBoxColumn();
      this.soNhayVe = new DataGridViewTextBoxColumn();
      this.chuKi = new DataGridViewTextBoxColumn();
      this.ngayChuara = new DataGridViewTextBoxColumn();
      this.maxSobanghi = new DataGridViewTextBoxColumn();
      this.maxGan = new DataGridViewTextBoxColumn();
      this.diemtanxuat = new DataGridViewTextBoxColumn();
      this.diemGan = new DataGridViewTextBoxColumn();
      this.veNgay = new DataGridViewTextBoxColumn();
      this.colTrong = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.xemTầnXuấtBộSốToolStripMenuItem = new ToolStripMenuItem();
      this.soiCầuBạchThủToolStripMenuItem = new ToolStripMenuItem();
      this.timer2 = new Timer(this.components);
      this.bgGetCauHinh = new BackgroundWorker();
      this.panel1.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.numGan2namLon.BeginInit();
      this.numGan2namNho.BeginInit();
      this.groupBox7.SuspendLayout();
      this.numDiemganLon.BeginInit();
      this.numDiemganNho.BeginInit();
      this.groupBox6.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.numSolanveLon.BeginInit();
      this.numSolanveBe.BeginInit();
      this.groupBox4.SuspendLayout();
      this.numTanxuatLon.BeginInit();
      this.numTanxuatBe.BeginInit();
      this.groupBox5.SuspendLayout();
      this.numSonhayveLon.BeginInit();
      this.numSonhayveBe.BeginInit();
      this.groupBox3.SuspendLayout();
      this.numGantrongkhungLon.BeginInit();
      this.numGantrongkhungBe.BeginInit();
      this.groupBox2.SuspendLayout();
      this.numNgaychuaraLon.BeginInit();
      this.numNgaychuaraBe.BeginInit();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.dtg_Ketqua).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.panel1.Controls.Add((Control) this.groupBox8);
      this.panel1.Controls.Add((Control) this.groupBox7);
      this.panel1.Controls.Add((Control) this.groupBox6);
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Controls.Add((Control) this.groupBox4);
      this.panel1.Controls.Add((Control) this.groupBox5);
      this.panel1.Controls.Add((Control) this.groupBox3);
      this.panel1.Controls.Add((Control) this.groupBox2);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 124);
      this.panel1.TabIndex = 0;
      this.groupBox8.BackColor = Color.Transparent;
      this.groupBox8.Controls.Add((Control) this.cbGan2nam);
      this.groupBox8.Controls.Add((Control) this.numGan2namLon);
      this.groupBox8.Controls.Add((Control) this.label16);
      this.groupBox8.Controls.Add((Control) this.numGan2namNho);
      this.groupBox8.Controls.Add((Control) this.label17);
      this.groupBox8.Location = new Point(605, 48);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new Size(150, 69);
      this.groupBox8.TabIndex = 48;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Loại  gan (+2năm)";
      this.cbGan2nam.AutoSize = true;
      this.cbGan2nam.Cursor = Cursors.Hand;
      this.cbGan2nam.Location = new Point(8, 18);
      this.cbGan2nam.Name = "cbGan2nam";
      this.cbGan2nam.Size = new Size(43, 19);
      this.cbGan2nam.TabIndex = 0;
      this.cbGan2nam.Text = "Tắt";
      this.toolTip1.SetToolTip((Control) this.cbGan2nam, "Bật/Tắt loại điểm tần xuất");
      this.cbGan2nam.UseVisualStyleBackColor = true;
      this.cbGan2nam.CheckedChanged += new EventHandler(this.cbSolanve_CheckedChanged);
      this.numGan2namLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGan2namLon.Location = new Point(104, 42);
      this.numGan2namLon.Name = "numGan2namLon";
      this.numGan2namLon.Size = new Size(40, 21);
      this.numGan2namLon.TabIndex = 2;
      this.numGan2namLon.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.label16.AutoSize = true;
      this.label16.Location = new Point(71, 46);
      this.label16.Name = "label16";
      this.label16.Size = new Size(30, 15);
      this.label16.TabIndex = 2;
      this.label16.Text = "Đến";
      this.numGan2namNho.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGan2namNho.Location = new Point(27, 42);
      this.numGan2namNho.Name = "numGan2namNho";
      this.numGan2namNho.Size = new Size(40, 21);
      this.numGan2namNho.TabIndex = 1;
      this.label17.AutoSize = true;
      this.label17.Location = new Point(4, 46);
      this.label17.Name = "label17";
      this.label17.Size = new Size(22, 15);
      this.label17.TabIndex = 0;
      this.label17.Text = "Từ";
      this.groupBox7.BackColor = Color.Transparent;
      this.groupBox7.Controls.Add((Control) this.cbDiemgan);
      this.groupBox7.Controls.Add((Control) this.numDiemganLon);
      this.groupBox7.Controls.Add((Control) this.label14);
      this.groupBox7.Controls.Add((Control) this.numDiemganNho);
      this.groupBox7.Controls.Add((Control) this.label15);
      this.groupBox7.Location = new Point(930, 48);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(165, 69);
      this.groupBox7.TabIndex = 47;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Loại điểm gan";
      this.cbDiemgan.AutoSize = true;
      this.cbDiemgan.Cursor = Cursors.Hand;
      this.cbDiemgan.Location = new Point(8, 18);
      this.cbDiemgan.Name = "cbDiemgan";
      this.cbDiemgan.Size = new Size(43, 19);
      this.cbDiemgan.TabIndex = 0;
      this.cbDiemgan.Text = "Tắt";
      this.toolTip1.SetToolTip((Control) this.cbDiemgan, "Bật/Tắt loại điểm tần xuất");
      this.cbDiemgan.UseVisualStyleBackColor = true;
      this.cbDiemgan.CheckedChanged += new EventHandler(this.cbSolanve_CheckedChanged);
      this.numDiemganLon.DecimalPlaces = 1;
      this.numDiemganLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numDiemganLon.Location = new Point(111, 42);
      this.numDiemganLon.Name = "numDiemganLon";
      this.numDiemganLon.Size = new Size(50, 21);
      this.numDiemganLon.TabIndex = 2;
      this.numDiemganLon.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.label14.AutoSize = true;
      this.label14.Location = new Point(78, 46);
      this.label14.Name = "label14";
      this.label14.Size = new Size(30, 15);
      this.label14.TabIndex = 2;
      this.label14.Text = "Đến";
      this.numDiemganNho.DecimalPlaces = 1;
      this.numDiemganNho.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numDiemganNho.Location = new Point(26, 42);
      this.numDiemganNho.Name = "numDiemganNho";
      this.numDiemganNho.Size = new Size(50, 21);
      this.numDiemganNho.TabIndex = 1;
      this.label15.AutoSize = true;
      this.label15.Location = new Point(4, 46);
      this.label15.Name = "label15";
      this.label15.Size = new Size(22, 15);
      this.label15.TabIndex = 0;
      this.label15.Text = "Từ";
      this.groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox6.Controls.Add((Control) this.btnThongke);
      this.groupBox6.Controls.Add((Control) this.label3);
      this.groupBox6.Controls.Add((Control) this.dtNgayXem);
      this.groupBox6.Controls.Add((Control) this.label2);
      this.groupBox6.Controls.Add((Control) this.txtBiendongay);
      this.groupBox6.Controls.Add((Control) this.label1);
      this.groupBox6.Controls.Add((Control) this.rdTuDo);
      this.groupBox6.Controls.Add((Control) this.rdCap);
      this.groupBox6.Controls.Add((Control) this.rdBachThu);
      this.groupBox6.Controls.Add((Control) this.rdTrungDuoi);
      this.groupBox6.Controls.Add((Control) this.rdTrungDau);
      this.groupBox6.Location = new Point(5, 0);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(1090, 45);
      this.groupBox6.TabIndex = 1;
      this.groupBox6.TabStop = false;
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(943, 13);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(100, 24);
      this.btnThongke.TabIndex = 7;
      this.btnThongke.Text = "Thống Kê";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(214, 16);
      this.label3.Name = "label3";
      this.label3.Size = new Size(50, 16);
      this.label3.TabIndex = 36;
      this.label3.Text = "biên độ";
      this.dtNgayXem.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.CalendarForeColor = Color.Red;
      this.dtNgayXem.CalendarMonthBackground = SystemColors.Info;
      this.dtNgayXem.CustomFormat = "dd/MM/yyyy";
      this.dtNgayXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtNgayXem.Format = DateTimePickerFormat.Custom;
      this.dtNgayXem.Location = new Point(69, 15);
      this.dtNgayXem.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtNgayXem.Name = "dtNgayXem";
      this.dtNgayXem.Size = new Size(91, 21);
      this.dtNgayXem.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.dtNgayXem, " Ngày kiểm tra chu kì lô tô");
      this.dtNgayXem.ValueChanged += new EventHandler(this.dtNgayXem_ValueChanged);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(4, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(65, 16);
      this.label2.TabIndex = 39;
      this.label2.Text = "Xem ngày";
      this.txtBiendongay.BorderStyle = BorderStyle.FixedSingle;
      this.txtBiendongay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.txtBiendongay.ForeColor = Color.Red;
      this.txtBiendongay.Location = new Point(266, 14);
      this.txtBiendongay.Name = "txtBiendongay";
      this.txtBiendongay.Size = new Size(51, 21);
      this.txtBiendongay.TabIndex = 1;
      this.txtBiendongay.Text = "36";
      this.toolTip1.SetToolTip((Control) this.txtBiendongay, " Số ngày mà bạn muốn kiểm tra");
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(320, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(89, 16);
      this.label1.TabIndex = 38;
      this.label1.Text = "ngày về trước";
      this.rdTuDo.AutoSize = true;
      this.rdTuDo.Cursor = Cursors.Hand;
      this.rdTuDo.FlatStyle = FlatStyle.Flat;
      this.rdTuDo.ForeColor = Color.Black;
      this.rdTuDo.Location = new Point(794, 16);
      this.rdTuDo.Name = "rdTuDo";
      this.rdTuDo.Size = new Size(101, 19);
      this.rdTuDo.TabIndex = 6;
      this.rdTuDo.Text = "Lô Cặp Tự Do";
      this.toolTip1.SetToolTip((Control) this.rdTuDo, " Kiểm tra tất cả những cặp lô bất kỳ gép với nhau");
      this.rdTuDo.UseVisualStyleBackColor = true;
      this.rdTuDo.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdCap.AutoSize = true;
      this.rdCap.Checked = true;
      this.rdCap.Cursor = Cursors.Hand;
      this.rdCap.FlatStyle = FlatStyle.Flat;
      this.rdCap.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.rdCap.ForeColor = Color.Red;
      this.rdCap.Location = new Point(449, 16);
      this.rdCap.Name = "rdCap";
      this.rdCap.Size = new Size(62, 19);
      this.rdCap.TabIndex = 2;
      this.rdCap.TabStop = true;
      this.rdCap.Text = "Lô cặp";
      this.toolTip1.SetToolTip((Control) this.rdCap, " Kiểm tra tất cả những lô tô cặp cơ bản");
      this.rdCap.UseVisualStyleBackColor = true;
      this.rdCap.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdBachThu.AutoSize = true;
      this.rdBachThu.Cursor = Cursors.Hand;
      this.rdBachThu.FlatStyle = FlatStyle.Flat;
      this.rdBachThu.ForeColor = Color.Black;
      this.rdBachThu.Location = new Point(524, 16);
      this.rdBachThu.Name = "rdBachThu";
      this.rdBachThu.Size = new Size(72, 19);
      this.rdBachThu.TabIndex = 3;
      this.rdBachThu.Text = "Bạch thủ";
      this.toolTip1.SetToolTip((Control) this.rdBachThu, " Kiểm tra tất cả những con lô bạch thủ");
      this.rdBachThu.UseVisualStyleBackColor = true;
      this.rdBachThu.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdTrungDuoi.AutoSize = true;
      this.rdTrungDuoi.Cursor = Cursors.Hand;
      this.rdTrungDuoi.FlatStyle = FlatStyle.Flat;
      this.rdTrungDuoi.ForeColor = Color.Black;
      this.rdTrungDuoi.Location = new Point(700, 16);
      this.rdTrungDuoi.Name = "rdTrungDuoi";
      this.rdTrungDuoi.Size = new Size(85, 19);
      this.rdTrungDuoi.TabIndex = 5;
      this.rdTrungDuoi.Text = "Trùng Đuôi";
      this.toolTip1.SetToolTip((Control) this.rdTrungDuoi, " Kiểm tra tất cả những cặp lô trùng đuôi");
      this.rdTrungDuoi.UseVisualStyleBackColor = true;
      this.rdTrungDuoi.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.rdTrungDau.AutoSize = true;
      this.rdTrungDau.Cursor = Cursors.Hand;
      this.rdTrungDau.FlatStyle = FlatStyle.Flat;
      this.rdTrungDau.ForeColor = Color.Black;
      this.rdTrungDau.Location = new Point(609, 16);
      this.rdTrungDau.Name = "rdTrungDau";
      this.rdTrungDau.Size = new Size(80, 19);
      this.rdTrungDau.TabIndex = 4;
      this.rdTrungDau.Text = "Trùng đầu";
      this.toolTip1.SetToolTip((Control) this.rdTrungDau, " Kiểm tra tất cả những cặp lô trùng đầu");
      this.rdTrungDau.UseVisualStyleBackColor = true;
      this.rdTrungDau.CheckedChanged += new EventHandler(this.rdCap_CheckedChanged);
      this.groupBox1.BackColor = Color.Transparent;
      this.groupBox1.Controls.Add((Control) this.cbSolanve);
      this.groupBox1.Controls.Add((Control) this.numSolanveLon);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.numSolanveBe);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Location = new Point(5, 48);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(145, 69);
      this.groupBox1.TabIndex = 40;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Loại số lần về";
      this.cbSolanve.AutoSize = true;
      this.cbSolanve.Cursor = Cursors.Hand;
      this.cbSolanve.Location = new Point(9, 16);
      this.cbSolanve.Name = "cbSolanve";
      this.cbSolanve.Size = new Size(43, 19);
      this.cbSolanve.TabIndex = 0;
      this.cbSolanve.Text = "Tắt";
      this.toolTip1.SetToolTip((Control) this.cbSolanve, "Bật/Tắt loại số lần về");
      this.cbSolanve.UseVisualStyleBackColor = true;
      this.cbSolanve.CheckedChanged += new EventHandler(this.cbSolanve_CheckedChanged);
      this.numSolanveLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numSolanveLon.Location = new Point(101, 42);
      this.numSolanveLon.Name = "numSolanveLon";
      this.numSolanveLon.Size = new Size(40, 21);
      this.numSolanveLon.TabIndex = 2;
      this.numSolanveLon.Value = new Decimal(new int[4]
      {
        13,
        0,
        0,
        0
      });
      this.label5.AutoSize = true;
      this.label5.Location = new Point(68, 46);
      this.label5.Name = "label5";
      this.label5.Size = new Size(30, 15);
      this.label5.TabIndex = 2;
      this.label5.Text = "Đến";
      this.numSolanveBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numSolanveBe.Location = new Point(27, 42);
      this.numSolanveBe.Name = "numSolanveBe";
      this.numSolanveBe.Size = new Size(40, 21);
      this.numSolanveBe.TabIndex = 1;
      this.numSolanveBe.Value = new Decimal(new int[4]
      {
        6,
        0,
        0,
        0
      });
      this.label4.AutoSize = true;
      this.label4.Location = new Point(4, 46);
      this.label4.Name = "label4";
      this.label4.Size = new Size(22, 15);
      this.label4.TabIndex = 0;
      this.label4.Text = "Từ";
      this.groupBox4.BackColor = Color.Transparent;
      this.groupBox4.Controls.Add((Control) this.cbDiemtanxuat);
      this.groupBox4.Controls.Add((Control) this.numTanxuatLon);
      this.groupBox4.Controls.Add((Control) this.label10);
      this.groupBox4.Controls.Add((Control) this.numTanxuatBe);
      this.groupBox4.Controls.Add((Control) this.label11);
      this.groupBox4.Location = new Point(760, 48);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(165, 69);
      this.groupBox4.TabIndex = 45;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Loại điểm tần xuất";
      this.cbDiemtanxuat.AutoSize = true;
      this.cbDiemtanxuat.Cursor = Cursors.Hand;
      this.cbDiemtanxuat.Location = new Point(8, 18);
      this.cbDiemtanxuat.Name = "cbDiemtanxuat";
      this.cbDiemtanxuat.Size = new Size(43, 19);
      this.cbDiemtanxuat.TabIndex = 0;
      this.cbDiemtanxuat.Text = "Tắt";
      this.toolTip1.SetToolTip((Control) this.cbDiemtanxuat, "Bật/Tắt loại điểm tần xuất");
      this.cbDiemtanxuat.UseVisualStyleBackColor = true;
      this.cbDiemtanxuat.CheckedChanged += new EventHandler(this.cbSolanve_CheckedChanged);
      this.numTanxuatLon.DecimalPlaces = 1;
      this.numTanxuatLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTanxuatLon.Location = new Point(108, 42);
      this.numTanxuatLon.Name = "numTanxuatLon";
      this.numTanxuatLon.Size = new Size(50, 21);
      this.numTanxuatLon.TabIndex = 2;
      this.numTanxuatLon.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.label10.AutoSize = true;
      this.label10.Location = new Point(75, 46);
      this.label10.Name = "label10";
      this.label10.Size = new Size(30, 15);
      this.label10.TabIndex = 2;
      this.label10.Text = "Đến";
      this.numTanxuatBe.DecimalPlaces = 1;
      this.numTanxuatBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTanxuatBe.Location = new Point(26, 42);
      this.numTanxuatBe.Name = "numTanxuatBe";
      this.numTanxuatBe.Size = new Size(50, 21);
      this.numTanxuatBe.TabIndex = 1;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(4, 46);
      this.label11.Name = "label11";
      this.label11.Size = new Size(22, 15);
      this.label11.TabIndex = 0;
      this.label11.Text = "Từ";
      this.groupBox5.BackColor = Color.Transparent;
      this.groupBox5.Controls.Add((Control) this.cbSoNhayve);
      this.groupBox5.Controls.Add((Control) this.numSonhayveLon);
      this.groupBox5.Controls.Add((Control) this.label12);
      this.groupBox5.Controls.Add((Control) this.numSonhayveBe);
      this.groupBox5.Controls.Add((Control) this.label13);
      this.groupBox5.Location = new Point(153, 48);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(145, 69);
      this.groupBox5.TabIndex = 44;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Loại số nháy về";
      this.cbSoNhayve.AutoSize = true;
      this.cbSoNhayve.Cursor = Cursors.Hand;
      this.cbSoNhayve.Location = new Point(9, 17);
      this.cbSoNhayve.Name = "cbSoNhayve";
      this.cbSoNhayve.Size = new Size(43, 19);
      this.cbSoNhayve.TabIndex = 0;
      this.cbSoNhayve.Text = "Tắt";
      this.toolTip1.SetToolTip((Control) this.cbSoNhayve, "Bật/Tắt loại số nháy về");
      this.cbSoNhayve.UseVisualStyleBackColor = true;
      this.cbSoNhayve.CheckedChanged += new EventHandler(this.cbSolanve_CheckedChanged);
      this.numSonhayveLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numSonhayveLon.Location = new Point(100, 42);
      this.numSonhayveLon.Name = "numSonhayveLon";
      this.numSonhayveLon.Size = new Size(40, 21);
      this.numSonhayveLon.TabIndex = 2;
      this.numSonhayveLon.Value = new Decimal(new int[4]
      {
        8,
        0,
        0,
        0
      });
      this.label12.AutoSize = true;
      this.label12.Location = new Point(71, 46);
      this.label12.Name = "label12";
      this.label12.Size = new Size(30, 15);
      this.label12.TabIndex = 2;
      this.label12.Text = "Đến";
      this.numSonhayveBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numSonhayveBe.Location = new Point(27, 42);
      this.numSonhayveBe.Name = "numSonhayveBe";
      this.numSonhayveBe.Size = new Size(40, 21);
      this.numSonhayveBe.TabIndex = 1;
      this.numSonhayveBe.Value = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.label13.AutoSize = true;
      this.label13.Location = new Point(4, 46);
      this.label13.Name = "label13";
      this.label13.Size = new Size(22, 15);
      this.label13.TabIndex = 1;
      this.label13.Text = "Từ";
      this.groupBox3.BackColor = Color.Transparent;
      this.groupBox3.Controls.Add((Control) this.cbGantrongkhung);
      this.groupBox3.Controls.Add((Control) this.numGantrongkhungLon);
      this.groupBox3.Controls.Add((Control) this.label8);
      this.groupBox3.Controls.Add((Control) this.numGantrongkhungBe);
      this.groupBox3.Controls.Add((Control) this.label9);
      this.groupBox3.Location = new Point(449, 48);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(152, 69);
      this.groupBox3.TabIndex = 42;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Loại gan khung";
      this.cbGantrongkhung.AutoSize = true;
      this.cbGantrongkhung.Cursor = Cursors.Hand;
      this.cbGantrongkhung.Location = new Point(8, 17);
      this.cbGantrongkhung.Name = "cbGantrongkhung";
      this.cbGantrongkhung.Size = new Size(43, 19);
      this.cbGantrongkhung.TabIndex = 0;
      this.cbGantrongkhung.Text = "Tắt";
      this.toolTip1.SetToolTip((Control) this.cbGantrongkhung, "Bật/Tắt loại gan trong khung");
      this.cbGantrongkhung.UseVisualStyleBackColor = true;
      this.cbGantrongkhung.CheckedChanged += new EventHandler(this.cbSolanve_CheckedChanged);
      this.numGantrongkhungLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGantrongkhungLon.Location = new Point(104, 42);
      this.numGantrongkhungLon.Name = "numGantrongkhungLon";
      this.numGantrongkhungLon.Size = new Size(40, 21);
      this.numGantrongkhungLon.TabIndex = 2;
      this.numGantrongkhungLon.Value = new Decimal(new int[4]
      {
        8,
        0,
        0,
        0
      });
      this.label8.AutoSize = true;
      this.label8.Location = new Point(74, 46);
      this.label8.Name = "label8";
      this.label8.Size = new Size(30, 15);
      this.label8.TabIndex = 2;
      this.label8.Text = "Đến";
      this.numGantrongkhungBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numGantrongkhungBe.Location = new Point(28, 42);
      this.numGantrongkhungBe.Name = "numGantrongkhungBe";
      this.numGantrongkhungBe.Size = new Size(40, 21);
      this.numGantrongkhungBe.TabIndex = 1;
      this.numGantrongkhungBe.Value = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.label9.AutoSize = true;
      this.label9.Location = new Point(4, 46);
      this.label9.Name = "label9";
      this.label9.Size = new Size(22, 15);
      this.label9.TabIndex = 0;
      this.label9.Text = "Từ";
      this.groupBox2.BackColor = Color.Transparent;
      this.groupBox2.Controls.Add((Control) this.cbNgaychuara);
      this.groupBox2.Controls.Add((Control) this.numNgaychuaraLon);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.numNgaychuaraBe);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Location = new Point(301, 48);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(145, 69);
      this.groupBox2.TabIndex = 41;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Loại ngày chưa ra";
      this.cbNgaychuara.AutoSize = true;
      this.cbNgaychuara.Cursor = Cursors.Hand;
      this.cbNgaychuara.Location = new Point(9, 18);
      this.cbNgaychuara.Name = "cbNgaychuara";
      this.cbNgaychuara.Size = new Size(43, 19);
      this.cbNgaychuara.TabIndex = 0;
      this.cbNgaychuara.Text = "Tắt";
      this.toolTip1.SetToolTip((Control) this.cbNgaychuara, "Bật/Tắt loại ngày chưa ra");
      this.cbNgaychuara.UseVisualStyleBackColor = true;
      this.cbNgaychuara.CheckedChanged += new EventHandler(this.cbSolanve_CheckedChanged);
      this.numNgaychuaraLon.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numNgaychuaraLon.Location = new Point(100, 42);
      this.numNgaychuaraLon.Name = "numNgaychuaraLon";
      this.numNgaychuaraLon.Size = new Size(40, 21);
      this.numNgaychuaraLon.TabIndex = 2;
      this.numNgaychuaraLon.Value = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.label6.AutoSize = true;
      this.label6.Location = new Point(70, 46);
      this.label6.Name = "label6";
      this.label6.Size = new Size(30, 15);
      this.label6.TabIndex = 2;
      this.label6.Text = "Đến";
      this.numNgaychuaraBe.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numNgaychuaraBe.Location = new Point(28, 42);
      this.numNgaychuaraBe.Name = "numNgaychuaraBe";
      this.numNgaychuaraBe.Size = new Size(40, 21);
      this.numNgaychuaraBe.TabIndex = 1;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(4, 46);
      this.label7.Name = "label7";
      this.label7.Size = new Size(22, 15);
      this.label7.TabIndex = 0;
      this.label7.Text = "Từ";
      this.toolTip1.AutomaticDelay = 400;
      this.toolTip1.ToolTipTitle = "Thông tin";
      this.bgKhoitaodulieu.DoWork += new DoWorkEventHandler(this.bgKhoitaodulieu_DoWork);
      this.bgKhoitaolotudo.DoWork += new DoWorkEventHandler(this.bgKhoitaolotudo_DoWork);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.bgProcess.DoWork += new DoWorkEventHandler(this.bgProcess_DoWork);
      this.bg1.DoWork += new DoWorkEventHandler(this.bg1_DoWork);
      this.bg1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
      this.bg2.DoWork += new DoWorkEventHandler(this.bg2_DoWork);
      this.bg2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg2_RunWorkerCompleted);
      this.bg3.DoWork += new DoWorkEventHandler(this.bg3_DoWork);
      this.bg3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg3_RunWorkerCompleted);
      this.bg4.DoWork += new DoWorkEventHandler(this.bg4_DoWork);
      this.bg4.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg4_RunWorkerCompleted);
      this.bg5.DoWork += new DoWorkEventHandler(this.bg5_DoWork);
      this.bg5.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bg5_RunWorkerCompleted);
      this.picLoading.BackColor = Color.White;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(552, 270);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 61;
      this.picLoading.TabStop = false;
      this.picLoading.Visible = false;
      this.panel2.Controls.Add((Control) this.picLoading);
      this.panel2.Controls.Add((Control) this.dtg_Ketqua);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 124);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 466);
      this.panel2.TabIndex = 1;
      this.dtg_Ketqua.AllowUserToAddRows = false;
      this.dtg_Ketqua.AllowUserToDeleteRows = false;
      this.dtg_Ketqua.AllowUserToResizeRows = false;
      this.dtg_Ketqua.BackgroundColor = SystemColors.ButtonHighlight;
      this.dtg_Ketqua.BorderStyle = BorderStyle.None;
      this.dtg_Ketqua.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.Teal;
      gridViewCellStyle1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dtg_Ketqua.ColumnHeadersHeight = 24;
      this.dtg_Ketqua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtg_Ketqua.Columns.AddRange((DataGridViewColumn) this.stt, (DataGridViewColumn) this.loto, (DataGridViewColumn) this.solanve, (DataGridViewColumn) this.soNhayVe, (DataGridViewColumn) this.chuKi, (DataGridViewColumn) this.ngayChuara, (DataGridViewColumn) this.maxSobanghi, (DataGridViewColumn) this.maxGan, (DataGridViewColumn) this.diemtanxuat, (DataGridViewColumn) this.diemGan, (DataGridViewColumn) this.veNgay, (DataGridViewColumn) this.colTrong);
      this.dtg_Ketqua.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dtg_Ketqua.DefaultCellStyle = gridViewCellStyle2;
      this.dtg_Ketqua.Dock = DockStyle.Fill;
      this.dtg_Ketqua.GridColor = Color.WhiteSmoke;
      this.dtg_Ketqua.Location = new Point(0, 0);
      this.dtg_Ketqua.Margin = new Padding(0);
      this.dtg_Ketqua.MultiSelect = false;
      this.dtg_Ketqua.Name = "dtg_Ketqua";
      this.dtg_Ketqua.ReadOnly = true;
      this.dtg_Ketqua.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.BackColor = Color.Cornsilk;
      gridViewCellStyle3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dtg_Ketqua.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dtg_Ketqua.RowHeadersVisible = false;
      this.dtg_Ketqua.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dtg_Ketqua.RowTemplate.Height = 24;
      this.dtg_Ketqua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dtg_Ketqua.Size = new Size(1100, 466);
      this.dtg_Ketqua.TabIndex = 0;
      this.stt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.stt.DataPropertyName = "stt";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle4.ForeColor = Color.Gray;
      this.stt.DefaultCellStyle = gridViewCellStyle4;
      this.stt.HeaderText = "STT ";
      this.stt.Name = "stt";
      this.stt.ReadOnly = true;
      this.stt.Width = 45;
      this.loto.DataPropertyName = "loto";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.BackColor = SystemColors.ButtonHighlight;
      gridViewCellStyle5.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = Color.Red;
      this.loto.DefaultCellStyle = gridViewCellStyle5;
      this.loto.HeaderText = "Bộ số";
      this.loto.Name = "loto";
      this.loto.ReadOnly = true;
      this.loto.ToolTipText = "Lô tạo thành";
      this.loto.Width = 90;
      this.solanve.DataPropertyName = "solanve";
      gridViewCellStyle6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.solanve.DefaultCellStyle = gridViewCellStyle6;
      this.solanve.HeaderText = "Số lần về";
      this.solanve.Name = "solanve";
      this.solanve.ReadOnly = true;
      this.solanve.ToolTipText = "Số lần về của lô tô trong khung kiểm tra";
      this.solanve.Width = 80;
      this.soNhayVe.DataPropertyName = "soNhayVe";
      this.soNhayVe.HeaderText = "Số nháy về";
      this.soNhayVe.Name = "soNhayVe";
      this.soNhayVe.ReadOnly = true;
      this.soNhayVe.Width = 85;
      this.chuKi.DataPropertyName = "chuKi";
      gridViewCellStyle7.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.chuKi.DefaultCellStyle = gridViewCellStyle7;
      this.chuKi.HeaderText = "Chu kỳ (ngày)";
      this.chuKi.Name = "chuKi";
      this.chuKi.ReadOnly = true;
      this.chuKi.ToolTipText = "Chu kỳ trung bình để lô tô về lại";
      this.ngayChuara.DataPropertyName = "ngayChuara";
      gridViewCellStyle8.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      gridViewCellStyle8.ForeColor = Color.Red;
      this.ngayChuara.DefaultCellStyle = gridViewCellStyle8;
      this.ngayChuara.HeaderText = "Ngày chưa ra";
      this.ngayChuara.Name = "ngayChuara";
      this.ngayChuara.ReadOnly = true;
      this.ngayChuara.ToolTipText = "Số ngày chưa ra của lô tô";
      this.ngayChuara.Width = 120;
      this.maxSobanghi.DataPropertyName = "maxSobanghi";
      gridViewCellStyle9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.maxSobanghi.DefaultCellStyle = gridViewCellStyle9;
      this.maxSobanghi.HeaderText = "Gan trong khung";
      this.maxSobanghi.Name = "maxSobanghi";
      this.maxSobanghi.ReadOnly = true;
      this.maxSobanghi.ToolTipText = "Khoảng ngày chưa ra lớn nhất trong khung kiểm tra";
      this.maxSobanghi.Width = 110;
      this.maxGan.DataPropertyName = "maxGan";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.maxGan.DefaultCellStyle = gridViewCellStyle10;
      this.maxGan.HeaderText = "Gan (+2năm)";
      this.maxGan.Name = "maxGan";
      this.maxGan.ReadOnly = true;
      this.maxGan.ToolTipText = "Khoảng ngày chưa ra lớn nhất trong khung kiểm tra + 2 năm";
      this.diemtanxuat.DataPropertyName = "diemtanxuat";
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle11.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle11.ForeColor = Color.Red;
      this.diemtanxuat.DefaultCellStyle = gridViewCellStyle11;
      this.diemtanxuat.HeaderText = "Điểm tần xuất";
      this.diemtanxuat.Name = "diemtanxuat";
      this.diemtanxuat.ReadOnly = true;
      this.diemtanxuat.ToolTipText = "Điểm tần xuất đạt được trong MAX I";
      this.diemtanxuat.Width = 130;
      this.diemGan.DataPropertyName = "diemGan";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle12.Font = new Font("Arial Narrow", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle12.ForeColor = Color.Red;
      this.diemGan.DefaultCellStyle = gridViewCellStyle12;
      this.diemGan.HeaderText = "Điểm gan";
      this.diemGan.Name = "diemGan";
      this.diemGan.ReadOnly = true;
      this.diemGan.ToolTipText = "Điểm gan đạt được trong MAX II";
      this.diemGan.Width = 130;
      this.veNgay.DataPropertyName = "veNgay";
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle13.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle13.ForeColor = Color.Blue;
      this.veNgay.DefaultCellStyle = gridViewCellStyle13;
      this.veNgay.HeaderText = "Về ngày";
      this.veNgay.Name = "veNgay";
      this.veNgay.ReadOnly = true;
      this.veNgay.ToolTipText = "Ngày về của lô tô";
      this.colTrong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.colTrong.DataPropertyName = "colTrong";
      this.colTrong.HeaderText = "";
      this.colTrong.Name = "colTrong";
      this.colTrong.ReadOnly = true;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.xemTầnXuấtBộSốToolStripMenuItem,
        (ToolStripItem) this.soiCầuBạchThủToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(154, 48);
      this.xemTầnXuấtBộSốToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("xemTầnXuấtBộSốToolStripMenuItem.Image");
      this.xemTầnXuấtBộSốToolStripMenuItem.Name = "xemTầnXuấtBộSốToolStripMenuItem";
      this.xemTầnXuấtBộSốToolStripMenuItem.Size = new Size(153, 22);
      this.xemTầnXuấtBộSốToolStripMenuItem.Text = "Tần xuất bộ số";
      this.xemTầnXuấtBộSốToolStripMenuItem.Click += new EventHandler(this.xemTầnXuấtBộSốToolStripMenuItem_Click);
      this.soiCầuBạchThủToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("soiCầuBạchThủToolStripMenuItem.Image");
      this.soiCầuBạchThủToolStripMenuItem.Name = "soiCầuBạchThủToolStripMenuItem";
      this.soiCầuBạchThủToolStripMenuItem.Size = new Size(153, 22);
      this.soiCầuBạchThủToolStripMenuItem.Text = "Soi cầu bạch thủ";
      this.soiCầuBạchThủToolStripMenuItem.Click += new EventHandler(this.soiCầuBạchThủToolStripMenuItem_Click);
      this.timer2.Enabled = true;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.bgGetCauHinh.DoWork += new DoWorkEventHandler(this.bgGetCauHinh_DoWork);
      this.bgGetCauHinh.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgGetCauHinh_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (TabChukiloto);
      this.Size = new Size(1100, 590);
      this.panel1.ResumeLayout(false);
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.numGan2namLon.EndInit();
      this.numGan2namNho.EndInit();
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.numDiemganLon.EndInit();
      this.numDiemganNho.EndInit();
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numSolanveLon.EndInit();
      this.numSolanveBe.EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.numTanxuatLon.EndInit();
      this.numTanxuatBe.EndInit();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.numSonhayveLon.EndInit();
      this.numSonhayveBe.EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.numGantrongkhungLon.EndInit();
      this.numGantrongkhungBe.EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.numNgaychuaraLon.EndInit();
      this.numNgaychuaraBe.EndInit();
      ((ISupportInitialize) this.picLoading).EndInit();
      this.panel2.ResumeLayout(false);
      ((ISupportInitialize) this.dtg_Ketqua).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public class LOTO
    {
      public string loto1 { get; set; }

      public string loto2 { get; set; }
    }

    public class DataRowTable
    {
      public int stt { get; set; }

      public string loto { get; set; }

      public int solanve { get; set; }

      public int ngayChuara { get; set; }

      public Decimal chuKi { get; set; }

      public int maxSobanghi { get; set; }

      public int maxGan { get; set; }

      public Decimal diemGan { get; set; }

      public Decimal diemtanxuat { get; set; }

      public int veNgay { get; set; }

      public string colTrong { get; set; }
    }
  }
}
