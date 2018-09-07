// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FMain
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigTN;
using myStruct;
using ns1;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TabLochoichieu;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.FormUI;
using Thống_kê_xổ_số.Properties;
using Tulpep.NotificationWindow;

namespace Thống_kê_xổ_số
{
  public class FMain : Form
  {
    public static int LoadLaiForm = 0;
    public static string IpServer = "107.191.52.85";
    public static int PortServer = 4500;
    public static string Loai_Tai_Khoan = "old";
    public static string HanSuDung = "";
    public static int _sudung = 1;
    public static int LoadLai_napTien = 0;
    private static int _chan = 4;
    private string _strTime = "";
    private string _ngay = "";
    private string _gio = "";
    private string _phut = "";
    private string _giay = "";
    public readonly FLogin FormLogin = new FLogin();
    private bool _maxSize = true;
    private readonly int _xWidth = SystemInformation.VirtualScreen.Width;
    private readonly int _yHeight = SystemInformation.VirtualScreen.Height;
    private int _le = 3;
    private int _dem = FMain._chan;
    private string _onlineText = "Online";
    private IContainer components = (IContainer) null;
    public static TabName TabName;
    public string[] Msg;
    public static DataTable DtTime;
    public static TimeSpan DemThoihan;
    public static string LoadTabname;
    public static int SoLanNapThe;
    private DataTable _messageTable;
    public tbMoneyUSER TbMoney;
    public static tbConfigApp ConfigApp;
    private TbThongbao objThongbao;
    public static tbConfigBacNho ObjConfigBacNho;
    public static DateTime NgayKetQuaMoiNhat;
    public static Tbloto _objLoto;
    public static string UserName;
    public static string AccountType;
    public static int ChieurongForm;
    public static int ChieurongManhinh;
    public static int ChieuCaoManhinh;
    public static TBVersion _infoVersion;
    private DateTime _gioHeThong;
    private Point _lastClickPosPoint;
    private readonly ContextMenuStrip _cms;
    private int _xFirst;
    private int _yFirst;
    public static Decimal VanghienCo;
    public static Decimal BacHienco;
    public static DateTime ThoiHanSuDung;
    public FThemNgaysudung themngaysudung;
    private TabChat _tabChat;
    private TabNaptien _tabNaptien;
    private TabInfoUser _tabInfoUser;
    private TabThongkeCanhan _tabThongkeCanhan;
    private TabVaotienChukiDanh _tabVaotienChukiDanh;
    private tabMessage _tabMessage;
    private TabSomo _tabSomo;
    private TabKinhnghiem _tabKinhnghiem;
    private TabBacnhoCoban _tabBacnhoCoban;
    private TabBacNhoTrungDauTrungDuoi _tabBacNhoTrungDauTrungDuoi;
    private TabBacNhoDanCungVe _tabBacNhoDanCungVe;
    private TabGepCau _tabgepcau;
    private TabXemChiTietCau _tabXemChiTietCau;
    private FConfigBacNho _fConfigBacNho;
    private TabTanxuatloto _tanxuatloto;
    private TabChukiloto _chukiloto;
    private TabSoiCau _soicauloto;
    private TabBoxloto _boxloto;
    private TabThamkhaocaothu _thamkhaoso;
    private TabLochoinhieu _tablochoinhieu;
    private Structure _structure;
    private FVaotien _fVaotien;
    private tbChukidanh _infoChuki;
    private AppInfo infoApp;
    public static PopupNotifier popup;
    private TabBangvang _bangvang;
    private TabBangdacbiet _bangdacbiet;
    private TabTongQuanVeDe _tongquanvede;
    private TabGepDanDacBiet _gepdandacbiet;
    private TabLoxien _thongkeloxien;
    private TabBacNhoLoXien _bacnholoxien;
    private TabNhandinhloto _nhandinhloto;
    public static Size size;
    private FKiemtraloxien fKiemtraloxien;
    private TabChukygiaiDacBiet _chukydacbiet;
    private TabBacnhotheothu _bacnhotheothu;
    private TabThongkedauso _tabthongkedauso;
    private TabThongkenguhanh _thongkenguhanh;
    private TabHieuquadauso _tabhieuquadauso;
    private Panel pnRight;
    private Panel pnBottum;
    private Panel headMenu;
    private BunifuImageButton bunifuImageButton6;
    private BunifuImageButton bunifuImageButton3;
    private BunifuImageButton bunifuImageButton2;
    private BunifuImageButton bunifuImageButton1;
    private Panel panel2;
    private BunifuImageButton bunifuImageButton4;
    private Panel panel5;
    private BunifuImageButton btnPhongto;
    private Panel panel4;
    private ToolTip toolTip1;
    private BunifuImageButton bunifuImageButton8;
    private ImageList imageListMenu;
    private BunifuElipse bunifuElipseAvartar;
    private Label label1;
    private Label lblVang;
    public Timer tmThongbao;
    private Panel panel11;
    private BunifuImageButton bunifuImageButton9;
    private Panel panel7;
    private Panel panel9;
    private Label lblTimeHientai;
    private MenuStrip menuMaintop;
    private ToolStripMenuItem thốngKêToolStripMenuItem;
    private ToolStripMenuItem boxLotoToolStripMenuItem;
    private ToolStripMenuItem bạcNhớToolStripMenuItem;
    private ToolStripMenuItem soiCầuToolStripMenuItem;
    private Panel panel3;
    private BunifuSeparator bunifuSeparator1;
    private LinkLabel lblUser;
    private TabControl tabControlMain;
    private BunifuImageButton _imgIsMessage;
    private Timer tmMessage;
    private BunifuImageButton bunifuImageButton7;
    private LinkLabel linkLabel1;
    private Panel panel10;
    private BackgroundWorker backgroundWorkerAddTab;
    private ToolStripMenuItem dànBấtKìCùngVềToolStripMenuItem;
    private BunifuImageButton bunifuImageButton13;
    private BunifuImageButton bunifuImageButton12;
    private BunifuImageButton bunifuImageButton11;
    private BunifuImageButton bunifuImageButton10;
    private BunifuImageButton picAvartar1;
    private BunifuImageButton imgOnline;
    private BackgroundWorker bgBuzz;
    private Timer timerOnline;
    private ToolStripMenuItem thốngKêCầuĐẹpToolStripMenuItem;
    private ToolStripMenuItem thốngKêCầuĐẹpToolStripMenuItem1;
    private ToolStripMenuItem xemChiTiếtCầuChạyToolStripMenuItem;
    private ToolStripMenuItem cầuBạchThủToolStripMenuItem;
    private ToolStripMenuItem tầnXuấtLôToolStripMenuItem;
    private ToolStripMenuItem tầnXuấtLôToolStripMenuItem1;
    private ToolStripMenuItem chuKỳLôToolStripMenuItem;
    private ToolStripMenuItem nhậnĐịnhLôTôToolStripMenuItem;
    private ToolStripMenuItem càiĐặtToolStripMenuItem;
    private ToolStripMenuItem bảngVàoTiềnToolStripMenuItem;
    private ToolStripMenuItem thốngKêTổngHợpToolStripMenuItem;
    private BunifuFlatButton bunifuFlatButton4;
    private BunifuFlatButton bunifuFlatButton1;
    private BunifuFlatButton bunifuFlatButton6;
    private BunifuFlatButton bunifuFlatButton5;
    private BunifuFlatButton bunifuFlatButton3;
    private BunifuFlatButton btnDacbiet;
    private BunifuFlatButton b1;
    private BunifuFlatButton bunifuFlatButton2;
    private BunifuFlatButton bunifuFlatButton7;
    private BunifuFlatButton bunifuFlatButton8;
    private ToolStripMenuItem bảngĐặcBiệtToolStripMenuItem;
    private ToolStripMenuItem tầnXuấtCácLoạiDànToolStripMenuItem;
    private ToolStripMenuItem loạiDànToolStripMenuItem;
    private ToolStripMenuItem gépDànĐặcBiệtToolStripMenuItem;
    private ToolStripMenuItem thốngKêLôXiên2ToolStripMenuItem;
    private ToolStripMenuItem bạcNhớLôXiênToolStripMenuItem;
    private ToolStripMenuItem nhậnĐịnhLôTôToolStripMenuItem1;
    private Timer timerGet_Message_TinhTime;
    private Timer timeNaptien;
    private BackgroundWorker bgThongbaoLink;
    private ToolStripMenuItem chuKỳGiảiĐặcBiệtToolStripMenuItem;
    private ToolStripMenuItem bạcNhớTheoThứToolStripMenuItem;
    private BunifuFlatButton bunifuFlatButton9;
    private BunifuFlatButton bunifuFlatButton10;
    private ToolStripMenuItem bóngSốLồngCầuToolStripMenuItem;
    private ToolStripMenuItem thốngKêĐầuSốToolStripMenuItem1;
    private ToolStripMenuItem thốngKêNgũHànhToolStripMenuItem1;
    private ToolStripMenuItem xemHiệuQuảBóngSốToolStripMenuItem;

    public FMain()
    {
      FMain.SoLanNapThe = 0;
      this._maxSize = false;
      FMain.DtTime = new DataTable();
      FMain.TabName = new TabName();
      FMain.ObjConfigBacNho = new tbConfigBacNho();
      FMain._objLoto = new Tbloto();
      this.objThongbao = new TbThongbao();
      FMain._infoVersion = new TBVersion();
      this.InitializeComponent();
      FMain.ChieurongManhinh = this._xWidth - 4;
      FMain.ChieuCaoManhinh = this._yHeight - 40;
      FMain.ChieurongForm = FMain.ChieurongManhinh - 184;
      this.Size = new Size(FMain.ChieurongManhinh, FMain.ChieuCaoManhinh);
      FMain.size = new Size();
      FMain.size.Height = 15;
      FMain.size.Width = 15;
      ClMain.timeHientai = DateTime.Now;
      this._cms = this.GetCms();
    }

    protected override void OnLoad(EventArgs e)
    {
      try
      {
        base.OnLoad(e);
        int num1 = (int) this.FormLogin.ShowDialog();
        if (FLogin._version != FLogin._newVersion)
        {
          if (MessageBox.Show("Đã có phiên bản Sinh Tài Sinh Lộc mới. Hãy cập nhật ngay để tận hưởng những tính năng mới nhất nhé !", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
          {
            try
            {
              Process.Start(Directory.GetCurrentDirectory() + "/SINH TAI SINH LOC.exe");
            }
            catch
            {
              int num2 = (int) MessageBox.Show("Không thể cập nhật phiên bản mới. Vui lòng liên hệ quản trị viên để được hỗ trợ !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
          }
          Environment.Exit(1);
        }
        DataTable dayNew = FMain._objLoto.GetDayNew();
        if (dayNew.Rows.Count > 0)
        {
          FMain.NgayKetQuaMoiNhat = DateTime.Parse(dayNew.Rows[0][0].ToString());
          this.timerGet_Message_TinhTime.Start();
          this.tmMessage.Start();
          this.tmThongbao.Start();
          this.ShowInfoUser();
          this.LoadMessage();
          this.GetTimeServer();
          this.timerOnline.Start();
          if (!this.bgThongbaoLink.IsBusy)
            this.bgThongbaoLink.RunWorkerAsync();
          this.AddTabChat();
        }
        else
          this.DisconnectedServerProc();
      }
      catch (Exception ex)
      {
        Environment.Exit(1);
      }
    }

    private void GetThongbao()
    {
      if (this._gioHeThong <= TbUser.Tbuser.NgayDangki.AddDays(5.0))
        FMain.Loai_Tai_Khoan = "new";
      DataTable linkThongBao = this.objThongbao.GetLinkThongBao();
      if (linkThongBao.Rows.Count <= 0)
        return;
      for (int index = 0; index < linkThongBao.Rows.Count; ++index)
      {
        if (linkThongBao.Rows[index]["thongbaocho"].ToString() == FMain.Loai_Tai_Khoan)
          Process.Start(linkThongBao.Rows[index]["noiDung"].ToString());
      }
    }

    public static void UpdateKetqua()
    {
      FMain.NgayKetQuaMoiNhat = DateTime.Parse(FMain._objLoto.GetDayNew().Rows[0][0].ToString());
    }

    private void GetTimeServer()
    {
      FMain.DtTime = ClMain.getTime_Server_CheckConnection();
      if (FMain.DtTime.Rows.Count > 0)
        this._gioHeThong = Convert.ToDateTime(FMain.DtTime.Rows[0][0]);
      else
        this.DisconnectedServerProc();
    }

    private ContextMenuStrip GetCms()
    {
      ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
      contextMenuStrip.Items.Add("Đóng", (Image) Resources.Close_Window_25px, new EventHandler(this.ItemClicked));
      return contextMenuStrip;
    }

    private void ItemClicked(object sender, EventArgs e)
    {
      if (!(this.tabControlMain.SelectedTab.Text == FMain.TabName.Phongchat))
        ;
      if ((uint) this.tabControlMain.SelectedIndex <= 0U)
        return;
      this.tabControlMain.SelectedTab.Dispose();
      this.tabControlMain.SelectedIndex = this.tabControlMain.TabCount - 1;
    }

    private void TabControlMainMouseClick(object sender, MouseEventArgs e)
    {
      this.OnMouseClick(e);
      if (e.Button == MouseButtons.Right && (uint) this.tabControlMain.SelectedIndex > 0U)
      {
        this._lastClickPosPoint = Cursor.Position;
        this._cms.Show(this._lastClickPosPoint);
      }
      if (e.Button != MouseButtons.Middle || (uint) this.tabControlMain.SelectedIndex <= 0U)
        return;
      this._lastClickPosPoint = Cursor.Position;
      this._cms.Show(this._lastClickPosPoint);
    }

    private void LoadMessage()
    {
      this._messageTable = new tbMessage().Get_Count(TbUser.Tbuser.TenDangnhap, 1);
      if (this._messageTable.Rows.Count > 0)
      {
        this.toolTip1.SetToolTip((Control) this._imgIsMessage, "Có " + (object) this._messageTable.Rows.Count + " thông báo mới !!!");
        if (this._messageTable.Rows.Count <= 10)
          return;
        this.toolTip1.SetToolTip((Control) this._imgIsMessage, "Có [10+] thông báo mới !!!");
      }
      else
        this.toolTip1.SetToolTip((Control) this._imgIsMessage, "Không có thông báo mới nào !!!");
    }

    private void ImageMessageChange(Decimal twStopwatch)
    {
      if (this._messageTable == null || this._messageTable.Rows.Count <= 0)
        return;
      this._imgIsMessage.Image = twStopwatch % new Decimal(2) == Decimal.Zero ? (Image) Resources.MessagePopular_Topic_64px : (Image) Resources.noMessage;
    }

    private void AddTabKinhnghiem()
    {
      TabKinhnghiem tabKinhnghiem = new TabKinhnghiem();
      tabKinhnghiem.Dock = DockStyle.Fill;
      this._tabKinhnghiem = tabKinhnghiem;
      this.AddTab((Control) this._tabKinhnghiem, FMain.TabName.KinhNghiem, 0);
    }

    private void AddTabKetqua()
    {
      TabKetqua tabKetqua = new TabKetqua();
      tabKetqua.Dock = DockStyle.Fill;
      this.AddTab((Control) tabKetqua, FMain.TabName.KetQua, 0);
    }

    public void AddTabInfoUser()
    {
      TabInfoUser tabInfoUser = new TabInfoUser();
      tabInfoUser.Dock = DockStyle.Fill;
      this._tabInfoUser = tabInfoUser;
      this.AddTab((Control) this._tabInfoUser, FMain.TabName.ThongTinTaiKhoan, 1);
    }

    public void AddTabNaptien()
    {
      TabNaptien tabNaptien = new TabNaptien();
      tabNaptien.Dock = DockStyle.Fill;
      this._tabNaptien = tabNaptien;
      this.AddTab((Control) this._tabNaptien, FMain.TabName.NapTien, 1);
    }

    public void AddTab(Control myUserControl, string nameTab, int imageStt)
    {
      if (FMain._sudung != 1 && !(nameTab == FMain.TabName.ThongTinTaiKhoan) && !(nameTab == FMain.TabName.NapTien) && !(nameTab == FMain.TabName.ThongBao))
        return;
      TabPage tabPage1 = new TabPage();
      tabPage1.Text = nameTab;
      TabPage tabPage2 = tabPage1;
      if (this.CheckTabPage(nameTab))
      {
        tabPage2.ImageIndex = imageStt;
        tabPage2.Controls.Add(myUserControl);
        this.tabControlMain.TabPages.Add(tabPage2);
        this.tabControlMain.SelectedTab = tabPage2;
      }
      else
        this.ActiveTabname(nameTab);
    }

    private void BunifuImageButton3Click(object sender, EventArgs e)
    {
      this.Msg = ClMain.Get_Msg("001");
      if (MessageBox.Show(this.Msg[1], this.Msg[2], MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
        return;
      ClMain.tune_Thongbao("offline.wav");
      Application.Exit();
    }

    private void BunifuImageButton6Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ThongTinTaiKhoan;
    }

    private bool CheckTabPage(string tabName)
    {
      bool flag = true;
      for (int index = 0; index < this.tabControlMain.TabCount; ++index)
      {
        if (this.tabControlMain.TabPages[index].Text == tabName)
        {
          flag = false;
          break;
        }
      }
      return flag;
    }

    private void ActiveTabname(string tabName)
    {
      for (int index = 0; index < this.tabControlMain.TabCount; ++index)
      {
        if (this.tabControlMain.TabPages[index].Text == tabName)
          this.tabControlMain.SelectedTab = this.tabControlMain.TabPages[index];
      }
    }

    private void BunifuImageButton5Click(object sender, EventArgs e)
    {
      if (!this._maxSize)
      {
        this.Location = new Point(this._xFirst, this._yFirst);
        this.Size = new Size(1360, 840);
        this._maxSize = true;
      }
      else
      {
        this.Location = new Point(2, this._yFirst);
        this.Size = new Size(this._xWidth - 4, 840);
        this._maxSize = false;
      }
    }

    public void ShowInfoUser()
    {
      this.TbMoney = new tbMoneyUSER();
      this.TbMoney = this.TbMoney.GetInfor(TbUser.Tbuser.TenDangnhap);
      FMain.ObjConfigBacNho = FMain.ObjConfigBacNho.GetInfor(TbUser.Tbuser.Stt);
      FMain.DemThoihan = TimeSpan.FromSeconds(1.0);
      FMain.ThoiHanSuDung = this.TbMoney.SuDungden_Ngay;
      try
      {
        FMain.VanghienCo = Decimal.Parse(this.TbMoney.VangHienco);
      }
      catch (Exception ex)
      {
        FMain.VanghienCo = new Decimal();
      }
      try
      {
        FMain.BacHienco = Decimal.Parse(this.TbMoney.XuHienco);
      }
      catch (Exception ex)
      {
        FMain.BacHienco = new Decimal();
      }
      this.lblVang.Text = ClMain.chuyenDoiVang_Xu(FMain.VanghienCo);
      FMain.UserName = TbUser.Tbuser.TenDangnhap;
      FMain.AccountType = TbUser.Tbuser.PhanQuyen;
      this.lblUser.Text = Resources.FMain_show_Info_User__ + FMain.UserName;
      this.toolTip1.SetToolTip((Control) this.lblVang, "Bạn hiện có " + ClMain.QuiDoiSoLuong(FMain.VanghienCo.ToString((IFormatProvider) CultureInfo.InvariantCulture), "vàng"));
    }

    public string TinhThoiHanSuDung(DateTime time)
    {
      FMain.DemThoihan = new TimeSpan();
      FMain.DemThoihan = this.TbMoney.SuDungden_Ngay - time;
      if (FMain.DemThoihan.TotalSeconds > 0.0)
      {
        this.menuMaintop.Enabled = true;
        this._strTime = "";
        this._ngay = "";
        this._gio = "";
        this._phut = "";
        this._giay = "";
        FMain.HanSuDung = string.Concat((object) FMain.DemThoihan.Days) ?? "";
        this._ngay = FMain.DemThoihan.Days.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        int num = FMain.DemThoihan.Hours;
        this._gio = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        num = FMain.DemThoihan.Minutes;
        this._phut = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        num = FMain.DemThoihan.Seconds;
        this._giay = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (int.Parse(this._gio) < 10)
          this._gio = "0" + this._gio;
        if (int.Parse(this._phut) < 10)
          this._phut = "0" + this._phut;
        if (int.Parse(this._giay) < 10)
          this._giay = "0" + this._giay;
        this._strTime = "[" + this._ngay + "d " + this._gio + ":" + this._phut + ":" + this._giay + "]";
        FMain.HanSuDung = this._ngay + " ngày " + this._gio + " giờ " + this._phut + " phút " + this._giay + " giây";
      }
      else
      {
        this.timerGet_Message_TinhTime.Enabled = false;
        this._strTime = "[0d 00:00:00]";
        FMain.HanSuDung = "[0d 00:00:00]";
        this.ActiveFormManager();
        this.Msg = ClMain.Get_Msg("011");
        if (MessageBox.Show(this.Msg[1], this.Msg[2], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        {
          if (Convert.ToInt32(this.TbMoney.vangHienco) >= 37000)
          {
            if (Application.OpenForms.OfType<FThemNgaysudung>().Count<FThemNgaysudung>() > 0)
            {
              this.themngaysudung.Show();
              this.themngaysudung.Focus();
            }
            else
            {
              this.themngaysudung = new FThemNgaysudung();
              this.themngaysudung.Show();
            }
          }
          else
            FMain.LinkToNapToNapTien();
        }
        else
          FLogin.LogOutStatus = "1";
      }
      return this._strTime;
    }

    private void ActiveFormManager()
    {
      if (!(TbUser.Tbuser.PhanQuyen != "user") && !(TbUser.Tbuser.PhanQuyen != "cms") && FMain.DemThoihan.TotalSeconds >= 1.0 && !(TbUser.Tbuser.TrangthaiSudung != "sudung"))
        return;
      this.menuMaintop.Enabled = false;
      FMain._sudung = 0;
    }

    private void TimerGetMessageTick(object sender, EventArgs e)
    {
      this.ShowThoiGianHienTai();
      ClMain.timeHientai = this._gioHeThong.AddSeconds(1.0);
      this._gioHeThong = ClMain.timeHientai;
      this.TinhThoiHanSuDung(ClMain.timeHientai);
      if (FMain.LoadLaiForm != 1)
        return;
      FMain.LoadLaiForm = 0;
      this.ShowInfoUser();
      this.tmMessage.Start();
      this.LoadMessage();
    }

    public void ShowThoiGianHienTai()
    {
      this.lblTimeHientai.Text = ClMain.timeHientai.ToString("HH:mm:ss JP");
    }

    public static void LinkToNapToNapTien()
    {
      Process.Start("http://www.sinhtaisinhloc.com/mua-phan-mem-xo-sinh-tai-sinh-loc/");
    }

    private void BunifuImageButton2Click(object sender, EventArgs e)
    {
      FMain.LinkToNapToNapTien();
    }

    private void ThốngKêToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ThongkeCanhan;
    }

    private void BunifuImageButton9Click(object sender, EventArgs e)
    {
      Process.Start(tbConfigApp.configApp.HomePage);
    }

    private void BunifuImageButton1Click(object sender, EventArgs e)
    {
      int num = (int) new fGopy().ShowDialog();
    }

    private void BunifuImageButton8Click(object sender, EventArgs e)
    {
      int num = (int) new fTransfer().ShowDialog();
    }

    private void TmMessageTick(object sender, EventArgs e)
    {
      this._dem = FMain._chan;
      if (this._dem == 4)
      {
        FMain._chan = this._le;
        this._le = 4;
      }
      else
      {
        this._le = FMain._chan;
        FMain._chan = 4;
      }
      this.ImageMessageChange((Decimal) this._dem);
    }

    private void BunifuImageButton9MouseHover(object sender, EventArgs e)
    {
      ClMain.tune_Thongbao("message.wav");
    }

    private void ImgIsMessageClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ThongBao;
      this.tmMessage.Stop();
      this.toolTip1.SetToolTip((Control) this._imgIsMessage, "Không có thông báo mới nào !!!");
    }

    public void AddTabMessage()
    {
      tabMessage tabMessage = new tabMessage();
      tabMessage.Dock = DockStyle.Fill;
      this._tabMessage = tabMessage;
      this.AddTab((Control) this._tabMessage, FMain.TabName.ThongBao, 0);
    }

    public void AddTabBacNhoCoBan()
    {
      TabBacnhoCoban tabBacnhoCoban = new TabBacnhoCoban();
      tabBacnhoCoban.Dock = DockStyle.Fill;
      this._tabBacnhoCoban = tabBacnhoCoban;
      this.AddTab((Control) this._tabBacnhoCoban, FMain.TabName.BacNhoCoBan, 0);
    }

    public void AddTabBacNhoNangCao()
    {
      TabBacNhoTrungDauTrungDuoi trungDauTrungDuoi = new TabBacNhoTrungDauTrungDuoi();
      trungDauTrungDuoi.Dock = DockStyle.Fill;
      this._tabBacNhoTrungDauTrungDuoi = trungDauTrungDuoi;
      this.AddTab((Control) this._tabBacNhoTrungDauTrungDuoi, FMain.TabName.BacNhoNangCao, 0);
    }

    private void BunifuImageButton7Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ThongTinTaiKhoan;
    }

    private void LinkLabel1LinkClicked1(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(tbConfigApp.configApp.HomePage);
    }

    public void AddTabSomo()
    {
      TabSomo tabSomo = new TabSomo();
      tabSomo.Dock = DockStyle.Fill;
      this._tabSomo = tabSomo;
      this.AddTab((Control) this._tabSomo, FMain.TabName.SoMo, 0);
    }

    public void AddTabVaotienChukiDanh()
    {
      TabVaotienChukiDanh vaotienChukiDanh = new TabVaotienChukiDanh();
      vaotienChukiDanh.Dock = DockStyle.Fill;
      this._tabVaotienChukiDanh = vaotienChukiDanh;
      this.AddTab((Control) this._tabVaotienChukiDanh, FMain.TabName.ChotSo, 0);
    }

    public void AddTabBacNhoDanCungVe()
    {
      TabBacNhoDanCungVe tabBacNhoDanCungVe = new TabBacNhoDanCungVe();
      tabBacNhoDanCungVe.Dock = DockStyle.Fill;
      this._tabBacNhoDanCungVe = tabBacNhoDanCungVe;
      this.AddTab((Control) this._tabBacNhoDanCungVe, FMain.TabName.BacNhoNangDanCungVe, 0);
    }

    public void AddTabGepCauTuDo()
    {
      TabGepCau tabGepCau = new TabGepCau();
      tabGepCau.Dock = DockStyle.Fill;
      this._tabgepcau = tabGepCau;
      this.AddTab((Control) this._tabgepcau, FMain.TabName.GepCauTuDo, 0);
    }

    public void AddTabChiTietCau()
    {
      if (!this.CheckTabPage(Resources.FMain_AddTabChiTietCau_Chi_tiết_cầu))
      {
        for (int index = 0; index < this.tabControlMain.TabCount; ++index)
        {
          if (this.tabControlMain.TabPages[index].Text == Resources.FMain_AddTabChiTietCau_Chi_tiết_cầu)
          {
            this.tabControlMain.TabPages.RemoveAt(index);
            break;
          }
        }
      }
      TabXemChiTietCau tabXemChiTietCau = new TabXemChiTietCau();
      tabXemChiTietCau.Dock = DockStyle.Fill;
      this._tabXemChiTietCau = tabXemChiTietCau;
      this.AddTab((Control) this._tabXemChiTietCau, FMain.TabName.ChiTietCau, 0);
    }

    public void ThongkeCanhan()
    {
      TabThongkeCanhan tabThongkeCanhan = new TabThongkeCanhan();
      tabThongkeCanhan.Dock = DockStyle.Fill;
      this._tabThongkeCanhan = tabThongkeCanhan;
      this.AddTab((Control) this._tabThongkeCanhan, FMain.TabName.ThongkeCanhan, 0);
    }

    private void BạcNhớToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BacNhoCoBan;
    }

    private void SoiCầuToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BacNhoNangCao;
    }

    private void DànBấtKìCùngVềToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BacNhoNangDanCungVe;
    }

    public void AddTabChat()
    {
      TabChat tabChat = new TabChat();
      tabChat.Dock = DockStyle.Fill;
      this._tabChat = tabChat;
      this.AddTab((Control) this._tabChat, FMain.TabName.Phongchat, 0);
    }

    private void TmThongbaoTick1(object sender, EventArgs e)
    {
      if (FMain.LoadTabname == "")
        return;
      string loadTabname = FMain.LoadTabname;
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(loadTabname))
      {
        case 145145546:
          if (!(loadTabname == "Chi tiết cầu"))
            break;
          FMain.LoadTabname = "";
          this.AddTabChiTietCau();
          break;
        case 148633733:
          if (!(loadTabname == "Chốt số"))
            break;
          FMain.LoadTabname = "";
          this.AddTabVaotienChukiDanh();
          break;
        case 221088880:
          if (!(loadTabname == "Tần xuất lô tô"))
            break;
          FMain.LoadTabname = "";
          this.AddTabTanXuatLoto();
          break;
        case 493262389:
          if (!(loadTabname == "Gép dàn"))
            break;
          FMain.LoadTabname = "";
          this.AddTabGepDanDacBiet();
          break;
        case 813086817:
          if (!(loadTabname == "Bạc nhớ theo thứ"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBacNhoTheoThu();
          break;
        case 830664652:
          if (!(loadTabname == "Nạp tiền"))
            break;
          FMain.LoadTabname = "";
          this.AddTabNaptien();
          break;
        case 958730312:
          if (!(loadTabname == "Tần xuất dàn đề"))
            break;
          FMain.LoadTabname = "";
          this.AddTabTongQuanVeDe();
          break;
        case 1173218981:
          if (!(loadTabname == "Bạc nhớ cơ bản"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBacNhoCoBan();
          break;
        case 1178852152:
          if (!(loadTabname == "Dự đoán kết quả"))
            break;
          FMain.LoadTabname = "";
          this.AddTabThamKhaoSo();
          break;
        case 1185828632:
          if (!(loadTabname == "Sổ Kết Quả"))
            break;
          FMain.LoadTabname = "";
          this.AddTabKetqua();
          break;
        case 1252264249:
          if (!(loadTabname == "Lô chơi nhiều"))
            break;
          FMain.LoadTabname = "";
          this.AddTabLoChoiNhieu();
          break;
        case 1415903957:
          if (!(loadTabname == "Thống kê đầu số"))
            break;
          FMain.LoadTabname = "";
          this.AddTabThongKeDauSo();
          break;
        case 1976145750:
          if (!(loadTabname == "Bảng đặc biệt"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBangDacBiet();
          break;
        case 2240162178:
          if (!(loadTabname == "Soi cầu bạch thủ"))
            break;
          FMain.LoadTabname = "";
          this.AddTabSoiCauLoto();
          break;
        case 2268279176:
          if (!(loadTabname == "Phòng Chat"))
            break;
          FMain.LoadTabname = "";
          this.AddTabChat();
          break;
        case 2481057502:
          if (!(loadTabname == "Nhận định lô"))
            break;
          FMain.LoadTabname = "";
          this.AddTabNhanDinhLoTo();
          break;
        case 2589290318:
          if (!(loadTabname == "Chu kỳ đặc biệt"))
            break;
          FMain.LoadTabname = "";
          this.AddTabChuKyDacBiet();
          break;
        case 2689442384:
          if (!(loadTabname == "Thống kê ngũ hành"))
            break;
          FMain.LoadTabname = "";
          this.AddTabThongKeNguHanh();
          break;
        case 2835102866:
          if (!(loadTabname == "Thông báo"))
            break;
          FMain.LoadTabname = "";
          this.AddTabMessage();
          break;
        case 2907756374:
          if (!(loadTabname == "Hiệu quả đầu số"))
            break;
          FMain.LoadTabname = "";
          this.AddTabHieuQuaDauSo();
          break;
        case 2929642797:
          if (!(loadTabname == "Dàn cùng về"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBacNhoDanCungVe();
          break;
        case 3042573665:
          if (!(loadTabname == "Thông tin tài khoản"))
            break;
          FMain.LoadTabname = "";
          this.AddTabInfoUser();
          break;
        case 3059372513:
          if (!(loadTabname == "Kinh nghiệm"))
            break;
          FMain.LoadTabname = "";
          this.AddTabKinhnghiem();
          break;
        case 3226480137:
          if (!(loadTabname == "Tổng quan về lô"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBoxLoto();
          break;
        case 3433035507:
          if (!(loadTabname == "Thống kê cầu đẹp"))
            break;
          FMain.LoadTabname = "";
          this.AddTabGepCauTuDo();
          break;
        case 3465224014:
          if (!(loadTabname == "Chu kỳ lô xiên"))
            break;
          FMain.LoadTabname = "";
          this.AddTabThongKeLoXien();
          break;
        case 3568646981:
          if (!(loadTabname == "Sổ mơ"))
            break;
          FMain.LoadTabname = "";
          this.AddTabSomo();
          break;
        case 3665735341:
          if (!(loadTabname == "Bạc nhớ lô xiên"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBacNhoLoXien();
          break;
        case 3896690203:
          if (!(loadTabname == "Chu kỳ lô"))
            break;
          FMain.LoadTabname = "";
          this.AddTabChuKiLoTo();
          break;
        case 3964594270:
          if (!(loadTabname == "Thống kê cá nhân"))
            break;
          FMain.LoadTabname = "";
          this.ThongkeCanhan();
          break;
        case 3967346220:
          if (!(loadTabname == "Bạc nhớ nâng cao"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBacNhoNangCao();
          break;
        case 4003093474:
          if (!(loadTabname == "Bảng vàng"))
            break;
          FMain.LoadTabname = "";
          this.AddTabBangvang();
          break;
      }
    }

    private void AddTabHieuQuaDauSo()
    {
      TabHieuquadauso tabHieuquadauso = new TabHieuquadauso();
      tabHieuquadauso.Dock = DockStyle.Fill;
      this._tabhieuquadauso = tabHieuquadauso;
      this.AddTab((Control) this._tabhieuquadauso, FMain.TabName.Hieuquadauso, 0);
    }

    private void AddTabLoChoiNhieu()
    {
      TabLochoinhieu tabLochoinhieu = new TabLochoinhieu();
      tabLochoinhieu.Dock = DockStyle.Fill;
      this._tablochoinhieu = tabLochoinhieu;
      this.AddTab((Control) this._tablochoinhieu, FMain.TabName.Lochoinhieu, 0);
    }

    private void AddTabThongKeNguHanh()
    {
      TabThongkenguhanh tabThongkenguhanh = new TabThongkenguhanh();
      tabThongkenguhanh.Dock = DockStyle.Fill;
      this._thongkenguhanh = tabThongkenguhanh;
      this.AddTab((Control) this._thongkenguhanh, FMain.TabName.Thongkenguhanh, 0);
    }

    private void AddTabThongKeDauSo()
    {
      TabThongkedauso tabThongkedauso = new TabThongkedauso();
      tabThongkedauso.Dock = DockStyle.Fill;
      this._tabthongkedauso = tabThongkedauso;
      this.AddTab((Control) this._tabthongkedauso, FMain.TabName.Thongkedauso, 0);
    }

    private void AddTabBacNhoTheoThu()
    {
      TabBacnhotheothu tabBacnhotheothu = new TabBacnhotheothu();
      tabBacnhotheothu.Dock = DockStyle.Fill;
      this._bacnhotheothu = tabBacnhotheothu;
      this.AddTab((Control) this._bacnhotheothu, FMain.TabName.Bacnhotheothu, 0);
    }

    private void AddTabChuKyDacBiet()
    {
      TabChukygiaiDacBiet chukygiaiDacBiet = new TabChukygiaiDacBiet();
      chukygiaiDacBiet.Dock = DockStyle.Fill;
      this._chukydacbiet = chukygiaiDacBiet;
      this.AddTab((Control) this._chukydacbiet, FMain.TabName.Chukydacbiet, 0);
    }

    private void AddTabNhanDinhLoTo()
    {
      TabNhandinhloto tabNhandinhloto = new TabNhandinhloto();
      tabNhandinhloto.Dock = DockStyle.Fill;
      this._nhandinhloto = tabNhandinhloto;
      this.AddTab((Control) this._nhandinhloto, FMain.TabName.Nhandinh, 0);
    }

    private void AddTabBacNhoLoXien()
    {
      TabBacNhoLoXien tabBacNhoLoXien = new TabBacNhoLoXien();
      tabBacNhoLoXien.Dock = DockStyle.Fill;
      this._bacnholoxien = tabBacNhoLoXien;
      this.AddTab((Control) this._bacnholoxien, FMain.TabName.BacNhoLoXien, 0);
    }

    private void AddTabThongKeLoXien()
    {
      TabLoxien tabLoxien = new TabLoxien();
      tabLoxien.Dock = DockStyle.Fill;
      this._thongkeloxien = tabLoxien;
      this.AddTab((Control) this._thongkeloxien, FMain.TabName.ThongKeLoXien, 0);
    }

    private void AddTabGepDanDacBiet()
    {
      TabGepDanDacBiet tabGepDanDacBiet = new TabGepDanDacBiet();
      tabGepDanDacBiet.Dock = DockStyle.Fill;
      this._gepdandacbiet = tabGepDanDacBiet;
      this.AddTab((Control) this._gepdandacbiet, FMain.TabName.GepDanDacBiet, 0);
    }

    private void AddTabTongQuanVeDe()
    {
      TabTongQuanVeDe tabTongQuanVeDe = new TabTongQuanVeDe();
      tabTongQuanVeDe.Dock = DockStyle.Fill;
      this._tongquanvede = tabTongQuanVeDe;
      this.AddTab((Control) this._tongquanvede, FMain.TabName.TanXuatDanDe, 0);
    }

    private void AddTabBangDacBiet()
    {
      TabBangdacbiet tabBangdacbiet = new TabBangdacbiet();
      tabBangdacbiet.Dock = DockStyle.Fill;
      this._bangdacbiet = tabBangdacbiet;
      this.AddTab((Control) this._bangdacbiet, FMain.TabName.BangDacBiet, 0);
    }

    private void AddTabBangvang()
    {
      TabBangvang tabBangvang = new TabBangvang();
      tabBangvang.Dock = DockStyle.Fill;
      this._bangvang = tabBangvang;
      this.AddTab((Control) this._bangvang, FMain.TabName.Bangvang, 0);
    }

    private void AddTabThamKhaoSo()
    {
      TabThamkhaocaothu tabThamkhaocaothu = new TabThamkhaocaothu();
      tabThamkhaocaothu.Dock = DockStyle.Fill;
      this._thamkhaoso = tabThamkhaocaothu;
      this.AddTab((Control) this._thamkhaoso, FMain.TabName.Thamkhaoso, 0);
    }

    private void AddTabBoxLoto()
    {
      TabBoxloto tabBoxloto = new TabBoxloto();
      tabBoxloto.Dock = DockStyle.Fill;
      this._boxloto = tabBoxloto;
      this.AddTab((Control) this._boxloto, FMain.TabName.BoxLoto, 0);
    }

    private void AddTabSoiCauLoto()
    {
      TabSoiCau tabSoiCau = new TabSoiCau();
      tabSoiCau.Dock = DockStyle.Fill;
      this._soicauloto = tabSoiCau;
      this.AddTab((Control) this._soicauloto, FMain.TabName.SoicauLoto, 0);
    }

    private void AddTabChuKiLoTo()
    {
      TabChukiloto tabChukiloto = new TabChukiloto();
      tabChukiloto.Dock = DockStyle.Fill;
      this._chukiloto = tabChukiloto;
      this.AddTab((Control) this._chukiloto, FMain.TabName.Chukiloto, 0);
    }

    private void AddTabTanXuatLoto()
    {
      TabTanxuatloto tabTanxuatloto = new TabTanxuatloto();
      tabTanxuatloto.Dock = DockStyle.Fill;
      this._tanxuatloto = tabTanxuatloto;
      this.AddTab((Control) this._tanxuatloto, FMain.TabName.Tanxuatloto, 0);
    }

    private void HeadMenuMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void BunifuImageButton10Click(object sender, EventArgs e)
    {
      Process.Start(tbConfigApp.configApp.LinkFacebook);
    }

    private void BunifuImageButton13Click(object sender, EventArgs e)
    {
      Process.Start(tbConfigApp.configApp.HomePage);
    }

    private void BunifuImageButton11Click(object sender, EventArgs e)
    {
      Process.Start(tbConfigApp.configApp.LinkYoutube);
    }

    private void BunifuImageButton12Click(object sender, EventArgs e)
    {
      Process.Start(tbConfigApp.configApp.LinkGooglePlus);
    }

    private void PicAvartar1Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ThongTinTaiKhoan;
    }

    private void FMainLoad(object sender, EventArgs e)
    {
      this._xFirst = this.Location.X;
      this._yFirst = this.Location.Y;
    }

    public bool CheckConnectionServer()
    {
      bool flag = true;
      if (FLogin.Client._s.Connected)
      {
        try
        {
          this._structure = new Structure();
          this._structure.Username = FMain.UserName;
          this._structure.SendTo = FLogin.IDC + "|" + FLogin.MacAddress;
          this._structure.SendType = "Reconnection";
          this._structure.TextChat = "Reconnection";
          if (!FLogin.Client.Send(this._structure))
            flag = false;
        }
        catch
        {
          flag = false;
        }
      }
      return flag;
    }

    private void TimerOnlineTick1(object sender, EventArgs e)
    {
      if (FLogin.ConnectStatus)
      {
        if (this.CheckConnectionServer() && FLogin.Client._s.Connected)
        {
          this.imgOnline.Image = (Image) Resources.Onlinepx;
          this._onlineText = "Online";
        }
        else
          this.DisconnectedServerProc();
      }
      else
        this.DisconnectedServerProc();
    }

    private void DisconnectedServerProc()
    {
      try
      {
        FLogin.Client = new ClientSettings.ClientSettings();
        FLogin.Client.Connect(FMain.IpServer, FMain.PortServer);
        this._structure = new Structure();
        this._structure.Username = FMain.UserName;
        this._structure.SendTo = FLogin.IDC + "|" + FLogin.MacAddress;
        this._structure.SendType = "Reconnection";
        this._structure.TextChat = "Reconnection";
        if (FLogin.Client.Send(this._structure))
        {
          FLogin.StatusChat = 1;
          FLogin._reconnectochat = true;
        }
        else
        {
          FLogin.ConnectStatus = false;
          this.timerOnline.Stop();
          this.imgOnline.Image = (Image) Resources.Offline;
          this._onlineText = "Offline";
          FLogin.MsgId = "010";
          FLogin.LogOutStatus = "1";
        }
      }
      catch (Exception ex)
      {
        FLogin.ConnectStatus = false;
        this.timerOnline.Stop();
        this.imgOnline.Image = (Image) Resources.Offline;
        this._onlineText = "Offline";
        FLogin.MsgId = "010";
        FLogin.LogOutStatus = "1";
      }
    }

    private void ImgOnlineClick(object sender, EventArgs e)
    {
    }

    private void ImgOnlineMouseHover(object sender, EventArgs e)
    {
      this.toolTip1.SetToolTip((Control) this.imgOnline, this._onlineText);
    }

    private void FMainFormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void BgBuzzDoWork(object sender, DoWorkEventArgs e)
    {
      ClMain.tune_Thongbao("messenger_buzz.wav");
    }

    private void ThốngKêCầuĐẹpToolStripMenuItem1Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.GepCauTuDo;
    }

    private void XemChiTiếtCầuChạyToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ChiTietCau;
    }

    private void CầuBạchThủToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.SoicauLoto;
    }

    private void TầnXuấtLôToolStripMenuItem1Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Tanxuatloto;
    }

    private void ChuKỳLôToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Chukiloto;
    }

    private void CàiĐặtToolStripMenuItemClick(object sender, EventArgs e)
    {
      this._fConfigBacNho = new FConfigBacNho();
      int num = (int) this._fConfigBacNho.ShowDialog();
    }

    private void BảngVàoTiềnToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (Application.OpenForms.OfType<FVaotien>().Count<FVaotien>() == 1)
      {
        this._fVaotien.WindowState = FormWindowState.Normal;
        this._fVaotien.Show();
        this._fVaotien.Focus();
      }
      else
      {
        this._infoChuki = new tbChukidanh();
        DataTable listByUsername = this._infoChuki.GetList_By_Username(TbUser.Tbuser.TenDangnhap);
        if (listByUsername.Rows.Count > 0)
        {
          this._fVaotien = new FVaotien(Decimal.Parse(listByUsername.Rows[0]["hesoNhanLo"].ToString()), Decimal.Parse(listByUsername.Rows[0]["tileAnLo"].ToString()), Decimal.Parse(listByUsername.Rows[0]["hesoNhanDe"].ToString()), Decimal.Parse(listByUsername.Rows[0]["tileAnDe"].ToString()), listByUsername.Rows[0]["donviTien"].ToString());
          this._fVaotien.Show();
        }
        else
        {
          this._fVaotien = new FVaotien(Decimal.Parse("2300"), Decimal.Parse("8000"), Decimal.Parse("1000"), Decimal.Parse("80000"), "VND");
          this._fVaotien.Show();
        }
      }
    }

    private void ThốngKêTổngHợpToolStripMenuItemClick(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BoxLoto;
    }

    private void b1_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.KetQua;
    }

    private void btnDacbiet_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BoxLoto;
    }

    private void bunifuFlatButton3_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.SoicauLoto;
    }

    private void bunifuFlatButton5_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BacNhoNangDanCungVe;
    }

    private void bunifuFlatButton6_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Chukiloto;
    }

    private void bunifuFlatButton1_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Nhandinh;
    }

    private void bunifuFlatButton4_Click(object sender, EventArgs e)
    {
      Process.Start(tbConfigApp.configApp.LinkKinhnghiemchoi);
    }

    private void showToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.ShowMessageInPopup("THÔNG BÁO", "Bạn vừa nhận được 5.000 vàng từ Administrator.");
    }

    public static void ShowMessageInPopup(string titleMesg, string msg)
    {
      FMain.popup = new PopupNotifier();
      FMain.popup.Image = (Image) Resources.Facebook_Messenger_25px;
      FMain.popup.TitleText = titleMesg;
      FMain.popup.ContentText = msg;
      FMain.popup.Popup();
    }

    private void bunifuFlatButton2_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Thamkhaoso;
    }

    private void bunifuFlatButton7_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.messenger.com/t/phanmemxososinhtaisinhloc");
    }

    private void bunifuFlatButton8_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Bangvang;
    }

    private void FMain_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void bảngĐặcBiệtToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BangDacBiet;
    }

    private void tầnXuấtCácLoạiDànToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.TanXuatDanDe;
    }

    private void gépDànĐặcBiệtToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.GepDanDacBiet;
    }

    private void thốngKêLôXiên2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.ThongKeLoXien;
    }

    private void bạcNhớLôXiênToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.BacNhoLoXien;
    }

    private void nhậnĐịnhLôTôToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Nhandinh;
    }

    private void loạiDànToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void tiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.fKiemtraloxien = new FKiemtraloxien();
      this.fKiemtraloxien.Show();
    }

    private void timeNaptien_Tick(object sender, EventArgs e)
    {
      if (FMain.LoadLai_napTien != 1)
        return;
      FMain.LoadLai_napTien = 0;
      this.tmMessage.Start();
      this.tmThongbao.Start();
      this.timerGet_Message_TinhTime.Start();
      this.ShowInfoUser();
      this.LoadMessage();
      this.GetTimeServer();
      this.menuMaintop.Enabled = true;
      FMain._sudung = 1;
    }

    private void bgThongbaoLink_DoWork(object sender, DoWorkEventArgs e)
    {
      this.GetThongbao();
    }

    private void chuKỳGiảiĐặcBiệtToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Chukydacbiet;
    }

    private void bạcNhớTheoThứToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Bacnhotheothu;
    }

    private void bunifuFlatButton9_Click(object sender, EventArgs e)
    {
      FMain.LinkToNapToNapTien();
    }

    private void thốngKêĐầuSốToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Thongkedauso;
    }

    private void thốngKêNgũHànhToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Thongkenguhanh;
    }

    private void bunifuFlatButton10_Click(object sender, EventArgs e)
    {
      if (Application.OpenForms.OfType<AppInfo>().Count<AppInfo>() > 0)
      {
        this.infoApp.Show();
        this.infoApp.Focus();
      }
      else
      {
        this.infoApp = new AppInfo();
        this.infoApp.Show();
      }
    }

    private void hiệuQuảĐầuSốToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Hieuquadauso;
    }

    private void thốngKêĐầuSốToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Thongkedauso;
    }

    private void thốngKêNgũHànhToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Thongkenguhanh;
    }

    private void xemHiệuQuảBóngSốToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FMain.LoadTabname = FMain.TabName.Hieuquadauso;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FMain));
      this.pnRight = new Panel();
      this.bunifuFlatButton10 = new BunifuFlatButton();
      this.bunifuFlatButton9 = new BunifuFlatButton();
      this.bunifuFlatButton7 = new BunifuFlatButton();
      this.bunifuFlatButton8 = new BunifuFlatButton();
      this.bunifuFlatButton2 = new BunifuFlatButton();
      this.bunifuFlatButton4 = new BunifuFlatButton();
      this.bunifuFlatButton1 = new BunifuFlatButton();
      this.bunifuFlatButton6 = new BunifuFlatButton();
      this.bunifuFlatButton5 = new BunifuFlatButton();
      this.bunifuFlatButton3 = new BunifuFlatButton();
      this.btnDacbiet = new BunifuFlatButton();
      this.b1 = new BunifuFlatButton();
      this.panel11 = new Panel();
      this.bunifuImageButton13 = new BunifuImageButton();
      this.bunifuImageButton12 = new BunifuImageButton();
      this.bunifuImageButton11 = new BunifuImageButton();
      this.bunifuImageButton10 = new BunifuImageButton();
      this.pnBottum = new Panel();
      this.panel10 = new Panel();
      this.label1 = new Label();
      this.lblVang = new Label();
      this.panel3 = new Panel();
      this.picAvartar1 = new BunifuImageButton();
      this.bunifuSeparator1 = new BunifuSeparator();
      this.linkLabel1 = new LinkLabel();
      this.lblUser = new LinkLabel();
      this.headMenu = new Panel();
      this.bunifuImageButton7 = new BunifuImageButton();
      this._imgIsMessage = new BunifuImageButton();
      this.bunifuImageButton9 = new BunifuImageButton();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.panel4 = new Panel();
      this.btnPhongto = new BunifuImageButton();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.bunifuImageButton6 = new BunifuImageButton();
      this.bunifuImageButton2 = new BunifuImageButton();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.panel2 = new Panel();
      this.panel5 = new Panel();
      this.tabControlMain = new TabControl();
      this.imageListMenu = new ImageList(this.components);
      this.panel7 = new Panel();
      this.imgOnline = new BunifuImageButton();
      this.panel9 = new Panel();
      this.lblTimeHientai = new Label();
      this.menuMaintop = new MenuStrip();
      this.thốngKêToolStripMenuItem = new ToolStripMenuItem();
      this.boxLotoToolStripMenuItem = new ToolStripMenuItem();
      this.bạcNhớToolStripMenuItem = new ToolStripMenuItem();
      this.soiCầuToolStripMenuItem = new ToolStripMenuItem();
      this.dànBấtKìCùngVềToolStripMenuItem = new ToolStripMenuItem();
      this.bạcNhớLôXiênToolStripMenuItem = new ToolStripMenuItem();
      this.bạcNhớTheoThứToolStripMenuItem = new ToolStripMenuItem();
      this.thốngKêCầuĐẹpToolStripMenuItem = new ToolStripMenuItem();
      this.thốngKêCầuĐẹpToolStripMenuItem1 = new ToolStripMenuItem();
      this.xemChiTiếtCầuChạyToolStripMenuItem = new ToolStripMenuItem();
      this.cầuBạchThủToolStripMenuItem = new ToolStripMenuItem();
      this.tầnXuấtLôToolStripMenuItem = new ToolStripMenuItem();
      this.chuKỳLôToolStripMenuItem = new ToolStripMenuItem();
      this.tầnXuấtLôToolStripMenuItem1 = new ToolStripMenuItem();
      this.thốngKêLôXiên2ToolStripMenuItem = new ToolStripMenuItem();
      this.thốngKêTổngHợpToolStripMenuItem = new ToolStripMenuItem();
      this.bóngSốLồngCầuToolStripMenuItem = new ToolStripMenuItem();
      this.thốngKêĐầuSốToolStripMenuItem1 = new ToolStripMenuItem();
      this.thốngKêNgũHànhToolStripMenuItem1 = new ToolStripMenuItem();
      this.xemHiệuQuảBóngSốToolStripMenuItem = new ToolStripMenuItem();
      this.nhậnĐịnhLôTôToolStripMenuItem = new ToolStripMenuItem();
      this.bảngĐặcBiệtToolStripMenuItem = new ToolStripMenuItem();
      this.tầnXuấtCácLoạiDànToolStripMenuItem = new ToolStripMenuItem();
      this.loạiDànToolStripMenuItem = new ToolStripMenuItem();
      this.gépDànĐặcBiệtToolStripMenuItem = new ToolStripMenuItem();
      this.chuKỳGiảiĐặcBiệtToolStripMenuItem = new ToolStripMenuItem();
      this.nhậnĐịnhLôTôToolStripMenuItem1 = new ToolStripMenuItem();
      this.bảngVàoTiềnToolStripMenuItem = new ToolStripMenuItem();
      this.càiĐặtToolStripMenuItem = new ToolStripMenuItem();
      this.bunifuImageButton4 = new BunifuImageButton();
      this.toolTip1 = new ToolTip(this.components);
      this.bunifuElipseAvartar = new BunifuElipse(this.components);
      this.tmThongbao = new Timer(this.components);
      this.tmMessage = new Timer(this.components);
      this.timerGet_Message_TinhTime = new Timer(this.components);
      this.backgroundWorkerAddTab = new BackgroundWorker();
      this.bgBuzz = new BackgroundWorker();
      this.timerOnline = new Timer(this.components);
      this.timeNaptien = new Timer(this.components);
      this.bgThongbaoLink = new BackgroundWorker();
      this.pnRight.SuspendLayout();
      this.panel11.SuspendLayout();
      this.bunifuImageButton13.BeginInit();
      this.bunifuImageButton12.BeginInit();
      this.bunifuImageButton11.BeginInit();
      this.bunifuImageButton10.BeginInit();
      this.pnBottum.SuspendLayout();
      this.panel10.SuspendLayout();
      this.panel3.SuspendLayout();
      this.picAvartar1.BeginInit();
      this.headMenu.SuspendLayout();
      this.bunifuImageButton7.BeginInit();
      this._imgIsMessage.BeginInit();
      this.bunifuImageButton9.BeginInit();
      this.bunifuImageButton8.BeginInit();
      this.panel4.SuspendLayout();
      this.btnPhongto.BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.bunifuImageButton6.BeginInit();
      this.bunifuImageButton2.BeginInit();
      this.bunifuImageButton1.BeginInit();
      this.panel2.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel7.SuspendLayout();
      this.imgOnline.BeginInit();
      this.panel9.SuspendLayout();
      this.menuMaintop.SuspendLayout();
      this.bunifuImageButton4.BeginInit();
      this.SuspendLayout();
      this.pnRight.BackColor = Color.FromArgb(22, 37, 56);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton10);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton9);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton7);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton8);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton2);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton4);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton1);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton6);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton5);
      this.pnRight.Controls.Add((Control) this.bunifuFlatButton3);
      this.pnRight.Controls.Add((Control) this.btnDacbiet);
      this.pnRight.Controls.Add((Control) this.b1);
      this.pnRight.Controls.Add((Control) this.panel11);
      this.pnRight.Controls.Add((Control) this.pnBottum);
      this.pnRight.Controls.Add((Control) this.panel3);
      this.pnRight.Dock = DockStyle.Left;
      this.pnRight.Location = new Point(0, 0);
      this.pnRight.Name = "pnRight";
      this.pnRight.Size = new Size(184, 840);
      this.pnRight.TabIndex = 0;
      this.bunifuFlatButton10.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton10.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton10.BorderRadius = 0;
      this.bunifuFlatButton10.ButtonText = "  Giới thiệu";
      this.bunifuFlatButton10.Cursor = Cursors.Hand;
      this.bunifuFlatButton10.DisabledColor = Color.Gray;
      this.bunifuFlatButton10.Dock = DockStyle.Top;
      this.bunifuFlatButton10.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton10.Iconcolor = Color.Transparent;
      this.bunifuFlatButton10.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton10.Iconimage");
      this.bunifuFlatButton10.Iconimage_right = (Image) null;
      this.bunifuFlatButton10.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton10.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton10.IconMarginLeft = 0;
      this.bunifuFlatButton10.IconMarginRight = 0;
      this.bunifuFlatButton10.IconRightVisible = true;
      this.bunifuFlatButton10.IconRightZoom = 0.0;
      this.bunifuFlatButton10.IconVisible = true;
      this.bunifuFlatButton10.IconZoom = 55.0;
      this.bunifuFlatButton10.IsTab = true;
      this.bunifuFlatButton10.Location = new Point(0, 716);
      this.bunifuFlatButton10.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton10.Name = "bunifuFlatButton10";
      this.bunifuFlatButton10.Normalcolor = Color.Empty;
      this.bunifuFlatButton10.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton10.OnHoverTextColor = Color.White;
      this.bunifuFlatButton10.selected = false;
      this.bunifuFlatButton10.Size = new Size(184, 52);
      this.bunifuFlatButton10.TabIndex = 27;
      this.bunifuFlatButton10.Text = "  Giới thiệu";
      this.bunifuFlatButton10.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton10.Textcolor = Color.White;
      this.bunifuFlatButton10.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton10, "Thông tin về phần mềm Sinh Tài Sinh Lộc");
      this.bunifuFlatButton10.Click += new EventHandler(this.bunifuFlatButton10_Click);
      this.bunifuFlatButton9.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton9.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton9.BorderRadius = 0;
      this.bunifuFlatButton9.ButtonText = "  Nạp Tiền";
      this.bunifuFlatButton9.Cursor = Cursors.Hand;
      this.bunifuFlatButton9.DisabledColor = Color.Gray;
      this.bunifuFlatButton9.Dock = DockStyle.Top;
      this.bunifuFlatButton9.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton9.Iconcolor = Color.Transparent;
      this.bunifuFlatButton9.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton9.Iconimage");
      this.bunifuFlatButton9.Iconimage_right = (Image) null;
      this.bunifuFlatButton9.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton9.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton9.IconMarginLeft = 0;
      this.bunifuFlatButton9.IconMarginRight = 0;
      this.bunifuFlatButton9.IconRightVisible = true;
      this.bunifuFlatButton9.IconRightZoom = 0.0;
      this.bunifuFlatButton9.IconVisible = true;
      this.bunifuFlatButton9.IconZoom = 55.0;
      this.bunifuFlatButton9.IsTab = true;
      this.bunifuFlatButton9.Location = new Point(0, 664);
      this.bunifuFlatButton9.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton9.Name = "bunifuFlatButton9";
      this.bunifuFlatButton9.Normalcolor = Color.Empty;
      this.bunifuFlatButton9.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton9.OnHoverTextColor = Color.White;
      this.bunifuFlatButton9.selected = false;
      this.bunifuFlatButton9.Size = new Size(184, 52);
      this.bunifuFlatButton9.TabIndex = 26;
      this.bunifuFlatButton9.Text = "  Nạp Tiền";
      this.bunifuFlatButton9.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton9.Textcolor = Color.White;
      this.bunifuFlatButton9.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton9, "Thông tin về phần mềm Sinh Tài Sinh Lộc");
      this.bunifuFlatButton9.Visible = false;
      this.bunifuFlatButton9.Click += new EventHandler(this.bunifuFlatButton9_Click);
      this.bunifuFlatButton7.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton7.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton7.BorderRadius = 0;
      this.bunifuFlatButton7.ButtonText = "  Yêu cầu hỗ trợ";
      this.bunifuFlatButton7.Cursor = Cursors.Hand;
      this.bunifuFlatButton7.DisabledColor = Color.Gray;
      this.bunifuFlatButton7.Dock = DockStyle.Top;
      this.bunifuFlatButton7.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton7.Iconcolor = Color.Transparent;
      this.bunifuFlatButton7.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton7.Iconimage");
      this.bunifuFlatButton7.Iconimage_right = (Image) null;
      this.bunifuFlatButton7.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton7.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton7.IconMarginLeft = 0;
      this.bunifuFlatButton7.IconMarginRight = 0;
      this.bunifuFlatButton7.IconRightVisible = true;
      this.bunifuFlatButton7.IconRightZoom = 0.0;
      this.bunifuFlatButton7.IconVisible = true;
      this.bunifuFlatButton7.IconZoom = 55.0;
      this.bunifuFlatButton7.IsTab = true;
      this.bunifuFlatButton7.Location = new Point(0, 612);
      this.bunifuFlatButton7.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton7.Name = "bunifuFlatButton7";
      this.bunifuFlatButton7.Normalcolor = Color.Empty;
      this.bunifuFlatButton7.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton7.OnHoverTextColor = Color.White;
      this.bunifuFlatButton7.selected = false;
      this.bunifuFlatButton7.Size = new Size(184, 52);
      this.bunifuFlatButton7.TabIndex = 25;
      this.bunifuFlatButton7.Text = "  Yêu cầu hỗ trợ";
      this.bunifuFlatButton7.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton7.Textcolor = Color.White;
      this.bunifuFlatButton7.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton7, "Thông tin về phần mềm Sinh Tài Sinh Lộc");
      this.bunifuFlatButton7.Click += new EventHandler(this.bunifuFlatButton7_Click);
      this.bunifuFlatButton8.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton8.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton8.BorderRadius = 0;
      this.bunifuFlatButton8.ButtonText = "  Bảng vàng";
      this.bunifuFlatButton8.Cursor = Cursors.Hand;
      this.bunifuFlatButton8.DisabledColor = Color.Gray;
      this.bunifuFlatButton8.Dock = DockStyle.Top;
      this.bunifuFlatButton8.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton8.Iconcolor = Color.Transparent;
      this.bunifuFlatButton8.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton8.Iconimage");
      this.bunifuFlatButton8.Iconimage_right = (Image) null;
      this.bunifuFlatButton8.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton8.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton8.IconMarginLeft = 0;
      this.bunifuFlatButton8.IconMarginRight = 0;
      this.bunifuFlatButton8.IconRightVisible = true;
      this.bunifuFlatButton8.IconRightZoom = 0.0;
      this.bunifuFlatButton8.IconVisible = true;
      this.bunifuFlatButton8.IconZoom = 60.0;
      this.bunifuFlatButton8.IsTab = true;
      this.bunifuFlatButton8.Location = new Point(0, 560);
      this.bunifuFlatButton8.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton8.Name = "bunifuFlatButton8";
      this.bunifuFlatButton8.Normalcolor = Color.Empty;
      this.bunifuFlatButton8.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton8.OnHoverTextColor = Color.White;
      this.bunifuFlatButton8.selected = false;
      this.bunifuFlatButton8.Size = new Size(184, 52);
      this.bunifuFlatButton8.TabIndex = 24;
      this.bunifuFlatButton8.Text = "  Bảng vàng";
      this.bunifuFlatButton8.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton8.Textcolor = Color.White;
      this.bunifuFlatButton8.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton8.Visible = false;
      this.bunifuFlatButton8.Click += new EventHandler(this.bunifuFlatButton8_Click);
      this.bunifuFlatButton2.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton2.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton2.BorderRadius = 0;
      this.bunifuFlatButton2.ButtonText = "  Dự đoán kết quả";
      this.bunifuFlatButton2.Cursor = Cursors.Hand;
      this.bunifuFlatButton2.DisabledColor = Color.Gray;
      this.bunifuFlatButton2.Dock = DockStyle.Top;
      this.bunifuFlatButton2.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton2.Iconcolor = Color.Transparent;
      this.bunifuFlatButton2.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton2.Iconimage");
      this.bunifuFlatButton2.Iconimage_right = (Image) null;
      this.bunifuFlatButton2.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton2.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton2.IconMarginLeft = 0;
      this.bunifuFlatButton2.IconMarginRight = 0;
      this.bunifuFlatButton2.IconRightVisible = true;
      this.bunifuFlatButton2.IconRightZoom = 0.0;
      this.bunifuFlatButton2.IconVisible = true;
      this.bunifuFlatButton2.IconZoom = 60.0;
      this.bunifuFlatButton2.IsTab = true;
      this.bunifuFlatButton2.Location = new Point(0, 508);
      this.bunifuFlatButton2.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton2.Name = "bunifuFlatButton2";
      this.bunifuFlatButton2.Normalcolor = Color.Empty;
      this.bunifuFlatButton2.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton2.OnHoverTextColor = Color.White;
      this.bunifuFlatButton2.selected = false;
      this.bunifuFlatButton2.Size = new Size(184, 52);
      this.bunifuFlatButton2.TabIndex = 23;
      this.bunifuFlatButton2.Text = "  Dự đoán kết quả";
      this.bunifuFlatButton2.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton2.Textcolor = Color.White;
      this.bunifuFlatButton2.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton2.Visible = false;
      this.bunifuFlatButton2.Click += new EventHandler(this.bunifuFlatButton2_Click);
      this.bunifuFlatButton4.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton4.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton4.BorderRadius = 0;
      this.bunifuFlatButton4.ButtonText = "  Kinh nghiệm chơi";
      this.bunifuFlatButton4.Cursor = Cursors.Hand;
      this.bunifuFlatButton4.DisabledColor = Color.Gray;
      this.bunifuFlatButton4.Dock = DockStyle.Top;
      this.bunifuFlatButton4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton4.Iconcolor = Color.Transparent;
      this.bunifuFlatButton4.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton4.Iconimage");
      this.bunifuFlatButton4.Iconimage_right = (Image) null;
      this.bunifuFlatButton4.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton4.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton4.IconMarginLeft = 0;
      this.bunifuFlatButton4.IconMarginRight = 0;
      this.bunifuFlatButton4.IconRightVisible = true;
      this.bunifuFlatButton4.IconRightZoom = 0.0;
      this.bunifuFlatButton4.IconVisible = true;
      this.bunifuFlatButton4.IconZoom = 55.0;
      this.bunifuFlatButton4.IsTab = true;
      this.bunifuFlatButton4.Location = new Point(0, 456);
      this.bunifuFlatButton4.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton4.Name = "bunifuFlatButton4";
      this.bunifuFlatButton4.Normalcolor = Color.Empty;
      this.bunifuFlatButton4.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton4.OnHoverTextColor = Color.White;
      this.bunifuFlatButton4.selected = false;
      this.bunifuFlatButton4.Size = new Size(184, 52);
      this.bunifuFlatButton4.TabIndex = 21;
      this.bunifuFlatButton4.Text = "  Kinh nghiệm chơi";
      this.bunifuFlatButton4.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton4.Textcolor = Color.White;
      this.bunifuFlatButton4.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton4, "Những kinh nghiệm thực chiến - hữu ích cho bạn");
      this.bunifuFlatButton4.Click += new EventHandler(this.bunifuFlatButton4_Click);
      this.bunifuFlatButton1.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton1.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton1.BorderRadius = 0;
      this.bunifuFlatButton1.ButtonText = "  Nhận định lô tô";
      this.bunifuFlatButton1.Cursor = Cursors.Hand;
      this.bunifuFlatButton1.DisabledColor = Color.Gray;
      this.bunifuFlatButton1.Dock = DockStyle.Top;
      this.bunifuFlatButton1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton1.Iconcolor = Color.Transparent;
      this.bunifuFlatButton1.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton1.Iconimage");
      this.bunifuFlatButton1.Iconimage_right = (Image) null;
      this.bunifuFlatButton1.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton1.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton1.IconMarginLeft = 0;
      this.bunifuFlatButton1.IconMarginRight = 0;
      this.bunifuFlatButton1.IconRightVisible = true;
      this.bunifuFlatButton1.IconRightZoom = 0.0;
      this.bunifuFlatButton1.IconVisible = true;
      this.bunifuFlatButton1.IconZoom = 58.0;
      this.bunifuFlatButton1.IsTab = true;
      this.bunifuFlatButton1.Location = new Point(0, 404);
      this.bunifuFlatButton1.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton1.Name = "bunifuFlatButton1";
      this.bunifuFlatButton1.Normalcolor = Color.Empty;
      this.bunifuFlatButton1.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton1.OnHoverTextColor = Color.White;
      this.bunifuFlatButton1.selected = false;
      this.bunifuFlatButton1.Size = new Size(184, 52);
      this.bunifuFlatButton1.TabIndex = 20;
      this.bunifuFlatButton1.Text = "  Nhận định lô tô";
      this.bunifuFlatButton1.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton1.Textcolor = Color.White;
      this.bunifuFlatButton1.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton1, "Phòng Chat chung");
      this.bunifuFlatButton1.Click += new EventHandler(this.bunifuFlatButton1_Click);
      this.bunifuFlatButton6.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton6.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton6.BorderRadius = 0;
      this.bunifuFlatButton6.ButtonText = "  Chu kỳ lô tô";
      this.bunifuFlatButton6.Cursor = Cursors.Hand;
      this.bunifuFlatButton6.DisabledColor = Color.Gray;
      this.bunifuFlatButton6.Dock = DockStyle.Top;
      this.bunifuFlatButton6.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton6.Iconcolor = Color.Transparent;
      this.bunifuFlatButton6.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton6.Iconimage");
      this.bunifuFlatButton6.Iconimage_right = (Image) null;
      this.bunifuFlatButton6.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton6.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton6.IconMarginLeft = 0;
      this.bunifuFlatButton6.IconMarginRight = 0;
      this.bunifuFlatButton6.IconRightVisible = true;
      this.bunifuFlatButton6.IconRightZoom = 0.0;
      this.bunifuFlatButton6.IconVisible = true;
      this.bunifuFlatButton6.IconZoom = 50.0;
      this.bunifuFlatButton6.IsTab = true;
      this.bunifuFlatButton6.Location = new Point(0, 352);
      this.bunifuFlatButton6.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton6.Name = "bunifuFlatButton6";
      this.bunifuFlatButton6.Normalcolor = Color.Empty;
      this.bunifuFlatButton6.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton6.OnHoverTextColor = Color.White;
      this.bunifuFlatButton6.selected = false;
      this.bunifuFlatButton6.Size = new Size(184, 52);
      this.bunifuFlatButton6.TabIndex = 16;
      this.bunifuFlatButton6.Text = "  Chu kỳ lô tô";
      this.bunifuFlatButton6.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton6.Textcolor = Color.White;
      this.bunifuFlatButton6.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton6, "Nhận định từng bộ số dựa trên kết quả thống kê");
      this.bunifuFlatButton6.Click += new EventHandler(this.bunifuFlatButton6_Click);
      this.bunifuFlatButton5.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton5.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton5.BorderRadius = 0;
      this.bunifuFlatButton5.ButtonText = "  Dàn lô cùng về";
      this.bunifuFlatButton5.Cursor = Cursors.Hand;
      this.bunifuFlatButton5.DisabledColor = Color.Gray;
      this.bunifuFlatButton5.Dock = DockStyle.Top;
      this.bunifuFlatButton5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton5.Iconcolor = Color.Transparent;
      this.bunifuFlatButton5.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton5.Iconimage");
      this.bunifuFlatButton5.Iconimage_right = (Image) null;
      this.bunifuFlatButton5.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton5.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton5.IconMarginLeft = 0;
      this.bunifuFlatButton5.IconMarginRight = 0;
      this.bunifuFlatButton5.IconRightVisible = true;
      this.bunifuFlatButton5.IconRightZoom = 0.0;
      this.bunifuFlatButton5.IconVisible = true;
      this.bunifuFlatButton5.IconZoom = 56.0;
      this.bunifuFlatButton5.IsTab = true;
      this.bunifuFlatButton5.Location = new Point(0, 300);
      this.bunifuFlatButton5.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton5.Name = "bunifuFlatButton5";
      this.bunifuFlatButton5.Normalcolor = Color.Empty;
      this.bunifuFlatButton5.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton5.OnHoverTextColor = Color.White;
      this.bunifuFlatButton5.selected = false;
      this.bunifuFlatButton5.Size = new Size(184, 52);
      this.bunifuFlatButton5.TabIndex = 19;
      this.bunifuFlatButton5.Text = "  Dàn lô cùng về";
      this.bunifuFlatButton5.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton5.Textcolor = Color.White;
      this.bunifuFlatButton5.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton5, "Thống kê khi dàn các con lô cùng về thì bộ số nào hay ra");
      this.bunifuFlatButton5.Click += new EventHandler(this.bunifuFlatButton5_Click);
      this.bunifuFlatButton3.Activecolor = Color.FromArgb(80, 164, 226);
      this.bunifuFlatButton3.BackgroundImageLayout = ImageLayout.Stretch;
      this.bunifuFlatButton3.BorderRadius = 0;
      this.bunifuFlatButton3.ButtonText = "  Soi cầu bạch thủ";
      this.bunifuFlatButton3.Cursor = Cursors.Hand;
      this.bunifuFlatButton3.DisabledColor = Color.Gray;
      this.bunifuFlatButton3.Dock = DockStyle.Top;
      this.bunifuFlatButton3.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuFlatButton3.Iconcolor = Color.Transparent;
      this.bunifuFlatButton3.Iconimage = (Image) componentResourceManager.GetObject("bunifuFlatButton3.Iconimage");
      this.bunifuFlatButton3.Iconimage_right = (Image) null;
      this.bunifuFlatButton3.Iconimage_right_Selected = (Image) null;
      this.bunifuFlatButton3.Iconimage_Selected = (Image) null;
      this.bunifuFlatButton3.IconMarginLeft = 0;
      this.bunifuFlatButton3.IconMarginRight = 0;
      this.bunifuFlatButton3.IconRightVisible = true;
      this.bunifuFlatButton3.IconRightZoom = 0.0;
      this.bunifuFlatButton3.IconVisible = true;
      this.bunifuFlatButton3.IconZoom = 58.0;
      this.bunifuFlatButton3.IsTab = true;
      this.bunifuFlatButton3.Location = new Point(0, 248);
      this.bunifuFlatButton3.Margin = new Padding(4, 4, 4, 4);
      this.bunifuFlatButton3.Name = "bunifuFlatButton3";
      this.bunifuFlatButton3.Normalcolor = Color.Empty;
      this.bunifuFlatButton3.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.bunifuFlatButton3.OnHoverTextColor = Color.White;
      this.bunifuFlatButton3.selected = false;
      this.bunifuFlatButton3.Size = new Size(184, 52);
      this.bunifuFlatButton3.TabIndex = 18;
      this.bunifuFlatButton3.Text = "  Soi cầu bạch thủ";
      this.bunifuFlatButton3.TextAlign = ContentAlignment.MiddleLeft;
      this.bunifuFlatButton3.Textcolor = Color.White;
      this.bunifuFlatButton3.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.bunifuFlatButton3, "Soi cầu bạch thủ ra trong ngày");
      this.bunifuFlatButton3.Click += new EventHandler(this.bunifuFlatButton3_Click);
      this.btnDacbiet.Activecolor = Color.FromArgb(80, 164, 226);
      this.btnDacbiet.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnDacbiet.BorderRadius = 0;
      this.btnDacbiet.ButtonText = "  Tổng quan về lô";
      this.btnDacbiet.Cursor = Cursors.Hand;
      this.btnDacbiet.DisabledColor = Color.Gray;
      this.btnDacbiet.Dock = DockStyle.Top;
      this.btnDacbiet.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDacbiet.Iconcolor = Color.Transparent;
      this.btnDacbiet.Iconimage = (Image) componentResourceManager.GetObject("btnDacbiet.Iconimage");
      this.btnDacbiet.Iconimage_right = (Image) null;
      this.btnDacbiet.Iconimage_right_Selected = (Image) null;
      this.btnDacbiet.Iconimage_Selected = (Image) null;
      this.btnDacbiet.IconMarginLeft = 0;
      this.btnDacbiet.IconMarginRight = 0;
      this.btnDacbiet.IconRightVisible = true;
      this.btnDacbiet.IconRightZoom = 0.0;
      this.btnDacbiet.IconVisible = true;
      this.btnDacbiet.IconZoom = 50.0;
      this.btnDacbiet.IsTab = true;
      this.btnDacbiet.Location = new Point(0, 196);
      this.btnDacbiet.Margin = new Padding(4, 4, 4, 4);
      this.btnDacbiet.Name = "btnDacbiet";
      this.btnDacbiet.Normalcolor = Color.Empty;
      this.btnDacbiet.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.btnDacbiet.OnHoverTextColor = Color.White;
      this.btnDacbiet.selected = false;
      this.btnDacbiet.Size = new Size(184, 52);
      this.btnDacbiet.TabIndex = 17;
      this.btnDacbiet.Text = "  Tổng quan về lô";
      this.btnDacbiet.TextAlign = ContentAlignment.MiddleLeft;
      this.btnDacbiet.Textcolor = Color.White;
      this.btnDacbiet.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.btnDacbiet, "Nhìn nhận tổng quan về lô tô hôm nay");
      this.btnDacbiet.Click += new EventHandler(this.btnDacbiet_Click);
      this.b1.Activecolor = Color.FromArgb(80, 164, 226);
      this.b1.BackgroundImageLayout = ImageLayout.Stretch;
      this.b1.BorderRadius = 0;
      this.b1.ButtonText = "  Sổ kết quả";
      this.b1.Cursor = Cursors.Hand;
      this.b1.DisabledColor = Color.Gray;
      this.b1.Dock = DockStyle.Top;
      this.b1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.b1.Iconcolor = Color.Transparent;
      this.b1.Iconimage = (Image) componentResourceManager.GetObject("b1.Iconimage");
      this.b1.Iconimage_right = (Image) null;
      this.b1.Iconimage_right_Selected = (Image) null;
      this.b1.Iconimage_Selected = (Image) null;
      this.b1.IconMarginLeft = 0;
      this.b1.IconMarginRight = 0;
      this.b1.IconRightVisible = true;
      this.b1.IconRightZoom = 0.0;
      this.b1.IconVisible = true;
      this.b1.IconZoom = 45.0;
      this.b1.IsTab = true;
      this.b1.Location = new Point(0, 144);
      this.b1.Margin = new Padding(4, 4, 4, 4);
      this.b1.Name = "b1";
      this.b1.Normalcolor = Color.Empty;
      this.b1.OnHovercolor = Color.FromArgb(43, 60, 80);
      this.b1.OnHoverTextColor = Color.White;
      this.b1.selected = false;
      this.b1.Size = new Size(184, 52);
      this.b1.TabIndex = 15;
      this.b1.Text = "  Sổ kết quả";
      this.b1.TextAlign = ContentAlignment.MiddleLeft;
      this.b1.Textcolor = Color.White;
      this.b1.TextFont = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolTip1.SetToolTip((Control) this.b1, "Sổ kết quả xổ số miền bắc");
      this.b1.Click += new EventHandler(this.b1_Click);
      this.panel11.Controls.Add((Control) this.bunifuImageButton13);
      this.panel11.Controls.Add((Control) this.bunifuImageButton12);
      this.panel11.Controls.Add((Control) this.bunifuImageButton11);
      this.panel11.Controls.Add((Control) this.bunifuImageButton10);
      this.panel11.Dock = DockStyle.Bottom;
      this.panel11.Location = new Point(0, 790);
      this.panel11.Name = "panel11";
      this.panel11.Size = new Size(184, 50);
      this.panel11.TabIndex = 9;
      this.bunifuImageButton13.BackColor = Color.FromArgb(22, 37, 56);
      this.bunifuImageButton13.Cursor = Cursors.Hand;
      this.bunifuImageButton13.Image = (Image) componentResourceManager.GetObject("bunifuImageButton13.Image");
      this.bunifuImageButton13.ImageActive = (Image) null;
      this.bunifuImageButton13.Location = new Point(7, 12);
      this.bunifuImageButton13.Margin = new Padding(0);
      this.bunifuImageButton13.Name = "bunifuImageButton13";
      this.bunifuImageButton13.Size = new Size(27, 27);
      this.bunifuImageButton13.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton13.TabIndex = 18;
      this.bunifuImageButton13.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton13, "Trang chủ");
      this.bunifuImageButton13.Zoom = 22;
      this.bunifuImageButton13.Click += new EventHandler(this.BunifuImageButton13Click);
      this.bunifuImageButton12.BackColor = Color.FromArgb(22, 37, 56);
      this.bunifuImageButton12.Cursor = Cursors.Hand;
      this.bunifuImageButton12.Image = (Image) componentResourceManager.GetObject("bunifuImageButton12.Image");
      this.bunifuImageButton12.ImageActive = (Image) null;
      this.bunifuImageButton12.Location = new Point(143, 12);
      this.bunifuImageButton12.Margin = new Padding(0);
      this.bunifuImageButton12.Name = "bunifuImageButton12";
      this.bunifuImageButton12.Size = new Size(26, 26);
      this.bunifuImageButton12.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton12.TabIndex = 17;
      this.bunifuImageButton12.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton12, " Google +");
      this.bunifuImageButton12.Zoom = 22;
      this.bunifuImageButton12.Click += new EventHandler(this.BunifuImageButton12Click);
      this.bunifuImageButton11.BackColor = Color.FromArgb(22, 37, 56);
      this.bunifuImageButton11.Cursor = Cursors.Hand;
      this.bunifuImageButton11.Image = (Image) componentResourceManager.GetObject("bunifuImageButton11.Image");
      this.bunifuImageButton11.ImageActive = (Image) null;
      this.bunifuImageButton11.Location = new Point(96, 10);
      this.bunifuImageButton11.Margin = new Padding(0);
      this.bunifuImageButton11.Name = "bunifuImageButton11";
      this.bunifuImageButton11.Size = new Size(32, 32);
      this.bunifuImageButton11.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton11.TabIndex = 16;
      this.bunifuImageButton11.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton11, " Youtube");
      this.bunifuImageButton11.Zoom = 22;
      this.bunifuImageButton11.Click += new EventHandler(this.BunifuImageButton11Click);
      this.bunifuImageButton10.BackColor = Color.FromArgb(22, 37, 56);
      this.bunifuImageButton10.Cursor = Cursors.Hand;
      this.bunifuImageButton10.Image = (Image) componentResourceManager.GetObject("bunifuImageButton10.Image");
      this.bunifuImageButton10.ImageActive = (Image) null;
      this.bunifuImageButton10.Location = new Point(55, 15);
      this.bunifuImageButton10.Margin = new Padding(0);
      this.bunifuImageButton10.Name = "bunifuImageButton10";
      this.bunifuImageButton10.Size = new Size(22, 22);
      this.bunifuImageButton10.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton10.TabIndex = 15;
      this.bunifuImageButton10.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton10, " Facebook");
      this.bunifuImageButton10.Zoom = 22;
      this.bunifuImageButton10.Click += new EventHandler(this.BunifuImageButton10Click);
      this.pnBottum.BackColor = Color.FromArgb(27, 40, 61);
      this.pnBottum.Controls.Add((Control) this.panel10);
      this.pnBottum.Dock = DockStyle.Top;
      this.pnBottum.Location = new Point(0, 55);
      this.pnBottum.Name = "pnBottum";
      this.pnBottum.Size = new Size(184, 89);
      this.pnBottum.TabIndex = 1;
      this.panel10.Controls.Add((Control) this.label1);
      this.panel10.Controls.Add((Control) this.lblVang);
      this.panel10.Dock = DockStyle.Fill;
      this.panel10.Location = new Point(0, 0);
      this.panel10.Name = "panel10";
      this.panel10.Size = new Size(184, 89);
      this.panel10.TabIndex = 6;
      this.label1.BackColor = Color.FromArgb(27, 40, 61);
      this.label1.Dock = DockStyle.Top;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.FromArgb(37, 140, 143);
      this.label1.Location = new Point(0, 55);
      this.label1.Name = "label1";
      this.label1.Size = new Size(184, 24);
      this.label1.TabIndex = 5;
      this.label1.Text = "  vàng hiện có";
      this.label1.TextAlign = ContentAlignment.TopCenter;
      this.lblVang.AutoEllipsis = true;
      this.lblVang.BackColor = Color.FromArgb(27, 40, 61);
      this.lblVang.Dock = DockStyle.Top;
      this.lblVang.Font = new Font("Comic Sans MS", 26.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVang.ForeColor = Color.FromArgb(214, 219, 233);
      this.lblVang.Location = new Point(0, 0);
      this.lblVang.Name = "lblVang";
      this.lblVang.Size = new Size(184, 55);
      this.lblVang.TabIndex = 3;
      this.lblVang.Tag = (object) "";
      this.lblVang.Text = " 312k";
      this.lblVang.TextAlign = ContentAlignment.BottomCenter;
      this.toolTip1.SetToolTip((Control) this.lblVang, "\r\n");
      this.panel3.BackColor = Color.FromArgb(22, 37, 56);
      this.panel3.Controls.Add((Control) this.picAvartar1);
      this.panel3.Controls.Add((Control) this.bunifuSeparator1);
      this.panel3.Controls.Add((Control) this.linkLabel1);
      this.panel3.Controls.Add((Control) this.lblUser);
      this.panel3.Dock = DockStyle.Top;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(184, 55);
      this.panel3.TabIndex = 0;
      this.picAvartar1.BackColor = Color.FromArgb(22, 37, 56);
      this.picAvartar1.Cursor = Cursors.Hand;
      this.picAvartar1.ErrorImage = (Image) null;
      this.picAvartar1.Image = (Image) componentResourceManager.GetObject("picAvartar1.Image");
      this.picAvartar1.ImageActive = (Image) null;
      this.picAvartar1.InitialImage = (Image) null;
      this.picAvartar1.Location = new Point(2, 8);
      this.picAvartar1.Name = "picAvartar1";
      this.picAvartar1.Size = new Size(50, 40);
      this.picAvartar1.SizeMode = PictureBoxSizeMode.Zoom;
      this.picAvartar1.TabIndex = 10;
      this.picAvartar1.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.picAvartar1, " Thông tin tài khoản");
      this.picAvartar1.Zoom = 5;
      this.picAvartar1.Click += new EventHandler(this.PicAvartar1Click);
      this.bunifuSeparator1.BackColor = Color.Transparent;
      this.bunifuSeparator1.Dock = DockStyle.Bottom;
      this.bunifuSeparator1.LineColor = Color.FromArgb(245, 245, 245);
      this.bunifuSeparator1.LineThickness = 3;
      this.bunifuSeparator1.Location = new Point(0, 54);
      this.bunifuSeparator1.Margin = new Padding(0);
      this.bunifuSeparator1.Name = "bunifuSeparator1";
      this.bunifuSeparator1.Size = new Size(184, 1);
      this.bunifuSeparator1.TabIndex = 9;
      this.bunifuSeparator1.Transparency = (int) byte.MaxValue;
      this.bunifuSeparator1.Vertical = false;
      this.linkLabel1.ActiveLinkColor = Color.White;
      this.linkLabel1.Font = new Font("Century", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
      this.linkLabel1.LinkColor = Color.FromArgb(214, 219, 233);
      this.linkLabel1.Location = new Point(52, 31);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(133, 20);
      this.linkLabel1.TabIndex = 7;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Sinh Tài Sinh Lộc";
      this.linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.linkLabel1, "Trang Chủ");
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked1);
      this.lblUser.ActiveLinkColor = Color.White;
      this.lblUser.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblUser.LinkBehavior = LinkBehavior.NeverUnderline;
      this.lblUser.LinkColor = Color.FromArgb(37, 140, 143);
      this.lblUser.Location = new Point(52, 6);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new Size(129, 20);
      this.lblUser.TabIndex = 7;
      this.lblUser.TabStop = true;
      this.lblUser.Text = "@Administrator";
      this.lblUser.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.lblUser, " Thông tin tài khoản");
      this.lblUser.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
      this.lblUser.MouseHover += new EventHandler(this.BunifuImageButton9MouseHover);
      this.headMenu.BackColor = Color.FromArgb(80, 164, 226);
      this.headMenu.Controls.Add((Control) this.bunifuImageButton7);
      this.headMenu.Controls.Add((Control) this._imgIsMessage);
      this.headMenu.Controls.Add((Control) this.bunifuImageButton9);
      this.headMenu.Controls.Add((Control) this.bunifuImageButton8);
      this.headMenu.Controls.Add((Control) this.panel4);
      this.headMenu.Controls.Add((Control) this.bunifuImageButton2);
      this.headMenu.Controls.Add((Control) this.bunifuImageButton1);
      this.headMenu.Dock = DockStyle.Top;
      this.headMenu.Location = new Point(184, 0);
      this.headMenu.Name = "headMenu";
      this.headMenu.Size = new Size(1176, 30);
      this.headMenu.TabIndex = 0;
      this.headMenu.MouseDown += new MouseEventHandler(this.HeadMenuMouseDown);
      this.bunifuImageButton7.BackColor = Color.FromArgb(80, 164, 226);
      this.bunifuImageButton7.Cursor = Cursors.Hand;
      this.bunifuImageButton7.Image = (Image) componentResourceManager.GetObject("bunifuImageButton7.Image");
      this.bunifuImageButton7.ImageActive = (Image) null;
      this.bunifuImageButton7.Location = new Point(161, 3);
      this.bunifuImageButton7.Margin = new Padding(0);
      this.bunifuImageButton7.Name = "bunifuImageButton7";
      this.bunifuImageButton7.Size = new Size(24, 24);
      this.bunifuImageButton7.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton7.TabIndex = 14;
      this.bunifuImageButton7.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton7, "  Thông tin tài khoản  ");
      this.bunifuImageButton7.Zoom = 15;
      this.bunifuImageButton7.Click += new EventHandler(this.BunifuImageButton7Click);
      this.bunifuImageButton7.MouseHover += new EventHandler(this.BunifuImageButton9MouseHover);
      this._imgIsMessage.BackColor = Color.FromArgb(80, 164, 226);
      this._imgIsMessage.Cursor = Cursors.Hand;
      this._imgIsMessage.Image = (Image) componentResourceManager.GetObject("_imgIsMessage.Image");
      this._imgIsMessage.ImageActive = (Image) null;
      this._imgIsMessage.Location = new Point(123, 2);
      this._imgIsMessage.Margin = new Padding(0);
      this._imgIsMessage.Name = "_imgIsMessage";
      this._imgIsMessage.Size = new Size(24, 24);
      this._imgIsMessage.SizeMode = PictureBoxSizeMode.Zoom;
      this._imgIsMessage.TabIndex = 13;
      this._imgIsMessage.TabStop = false;
      this.toolTip1.SetToolTip((Control) this._imgIsMessage, "  Thông báo  ");
      this._imgIsMessage.Zoom = 15;
      this._imgIsMessage.Click += new EventHandler(this.ImgIsMessageClick);
      this._imgIsMessage.MouseHover += new EventHandler(this.BunifuImageButton9MouseHover);
      this.bunifuImageButton9.BackColor = Color.FromArgb(80, 164, 226);
      this.bunifuImageButton9.Cursor = Cursors.Hand;
      this.bunifuImageButton9.Image = (Image) componentResourceManager.GetObject("bunifuImageButton9.Image");
      this.bunifuImageButton9.ImageActive = (Image) null;
      this.bunifuImageButton9.Location = new Point(4, 3);
      this.bunifuImageButton9.Margin = new Padding(0);
      this.bunifuImageButton9.Name = "bunifuImageButton9";
      this.bunifuImageButton9.Size = new Size(23, 23);
      this.bunifuImageButton9.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton9.TabIndex = 12;
      this.bunifuImageButton9.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton9, "  Trang chủ  ");
      this.bunifuImageButton9.Zoom = 15;
      this.bunifuImageButton9.Click += new EventHandler(this.BunifuImageButton9Click);
      this.bunifuImageButton9.MouseHover += new EventHandler(this.BunifuImageButton9MouseHover);
      this.bunifuImageButton8.BackColor = Color.FromArgb(80, 164, 226);
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(250, 4);
      this.bunifuImageButton8.Margin = new Padding(0);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(23, 23);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 9;
      this.bunifuImageButton8.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton8, "  Chuyển tiền  ");
      this.bunifuImageButton8.Visible = false;
      this.bunifuImageButton8.Zoom = 15;
      this.bunifuImageButton8.Click += new EventHandler(this.BunifuImageButton8Click);
      this.bunifuImageButton8.MouseHover += new EventHandler(this.BunifuImageButton9MouseHover);
      this.panel4.Controls.Add((Control) this.btnPhongto);
      this.panel4.Controls.Add((Control) this.bunifuImageButton3);
      this.panel4.Controls.Add((Control) this.bunifuImageButton6);
      this.panel4.Dock = DockStyle.Right;
      this.panel4.Location = new Point(1061, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(115, 30);
      this.panel4.TabIndex = 7;
      this.btnPhongto.BackColor = Color.FromArgb(80, 164, 226);
      this.btnPhongto.Cursor = Cursors.Hand;
      this.btnPhongto.Image = (Image) componentResourceManager.GetObject("btnPhongto.Image");
      this.btnPhongto.ImageActive = (Image) null;
      this.btnPhongto.Location = new Point(3, 8);
      this.btnPhongto.Name = "btnPhongto";
      this.btnPhongto.Size = new Size(21, 21);
      this.btnPhongto.SizeMode = PictureBoxSizeMode.Zoom;
      this.btnPhongto.TabIndex = 6;
      this.btnPhongto.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.btnPhongto, "Phóng to/Thu nhỏ");
      this.btnPhongto.Visible = false;
      this.btnPhongto.Zoom = 15;
      this.btnPhongto.Click += new EventHandler(this.BunifuImageButton5Click);
      this.bunifuImageButton3.BackColor = Color.FromArgb(80, 164, 226);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(88, 6);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(20, 20);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 2;
      this.bunifuImageButton3.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton3, " Thoát ");
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.BunifuImageButton3Click);
      this.bunifuImageButton6.BackColor = Color.FromArgb(80, 164, 226);
      this.bunifuImageButton6.Cursor = Cursors.Hand;
      this.bunifuImageButton6.Image = (Image) componentResourceManager.GetObject("bunifuImageButton6.Image");
      this.bunifuImageButton6.ImageActive = (Image) null;
      this.bunifuImageButton6.Location = new Point(68, 14);
      this.bunifuImageButton6.Name = "bunifuImageButton6";
      this.bunifuImageButton6.Size = new Size(13, 13);
      this.bunifuImageButton6.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton6.TabIndex = 5;
      this.bunifuImageButton6.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton6, " Ẩn");
      this.bunifuImageButton6.Zoom = 10;
      this.bunifuImageButton6.Click += new EventHandler(this.BunifuImageButton6Click);
      this.bunifuImageButton2.BackColor = Color.FromArgb(80, 164, 226);
      this.bunifuImageButton2.Cursor = Cursors.Hand;
      this.bunifuImageButton2.Image = (Image) componentResourceManager.GetObject("bunifuImageButton2.Image");
      this.bunifuImageButton2.ImageActive = (Image) null;
      this.bunifuImageButton2.Location = new Point(43, 3);
      this.bunifuImageButton2.Margin = new Padding(0);
      this.bunifuImageButton2.Name = "bunifuImageButton2";
      this.bunifuImageButton2.Size = new Size(23, 23);
      this.bunifuImageButton2.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton2.TabIndex = 1;
      this.bunifuImageButton2.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton2, "  Nạp tiền");
      this.bunifuImageButton2.Zoom = 15;
      this.bunifuImageButton2.Click += new EventHandler(this.BunifuImageButton2Click);
      this.bunifuImageButton2.MouseHover += new EventHandler(this.BunifuImageButton9MouseHover);
      this.bunifuImageButton1.BackColor = Color.FromArgb(80, 164, 226);
      this.bunifuImageButton1.Cursor = Cursors.Hand;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(82, 3);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(24, 24);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 0;
      this.bunifuImageButton1.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton1, "  Góp ý  ");
      this.bunifuImageButton1.Zoom = 15;
      this.bunifuImageButton1.Click += new EventHandler(this.BunifuImageButton1Click);
      this.bunifuImageButton1.MouseHover += new EventHandler(this.BunifuImageButton9MouseHover);
      this.panel2.Controls.Add((Control) this.panel5);
      this.panel2.Controls.Add((Control) this.bunifuImageButton4);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(184, 30);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1176, 810);
      this.panel2.TabIndex = 2;
      this.panel5.BackColor = Color.White;
      this.panel5.Controls.Add((Control) this.tabControlMain);
      this.panel5.Controls.Add((Control) this.panel7);
      this.panel5.Dock = DockStyle.Fill;
      this.panel5.Location = new Point(0, 0);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(1176, 810);
      this.panel5.TabIndex = 3;
      this.tabControlMain.AllowDrop = true;
      this.tabControlMain.Appearance = TabAppearance.Buttons;
      this.tabControlMain.Dock = DockStyle.Fill;
      this.tabControlMain.ImageList = this.imageListMenu;
      this.tabControlMain.ImeMode = ImeMode.Off;
      this.tabControlMain.ItemSize = new Size(65, 23);
      this.tabControlMain.Location = new Point(0, 25);
      this.tabControlMain.Margin = new Padding(0);
      this.tabControlMain.Name = "tabControlMain";
      this.tabControlMain.Padding = new Point(0, 0);
      this.tabControlMain.SelectedIndex = 0;
      this.tabControlMain.Size = new Size(1176, 785);
      this.tabControlMain.SizeMode = TabSizeMode.FillToRight;
      this.tabControlMain.TabIndex = 1;
      this.tabControlMain.SelectedIndexChanged += new EventHandler(this.tabControlMain_SelectedIndexChanged);
      this.tabControlMain.MouseClick += new MouseEventHandler(this.TabControlMainMouseClick);
      this.imageListMenu.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageListMenu.ImageStream");
      this.imageListMenu.Tag = (object) "1";
      this.imageListMenu.TransparentColor = Color.Transparent;
      this.imageListMenu.Images.SetKeyName(0, "Activity Grid 2_30px.png");
      this.imageListMenu.Images.SetKeyName(1, "Page Overview 2_30px.png");
      this.panel7.Controls.Add((Control) this.imgOnline);
      this.panel7.Controls.Add((Control) this.panel9);
      this.panel7.Controls.Add((Control) this.menuMaintop);
      this.panel7.Dock = DockStyle.Top;
      this.panel7.Location = new Point(0, 0);
      this.panel7.Name = "panel7";
      this.panel7.Padding = new Padding(0, 2, 0, 2);
      this.panel7.Size = new Size(1176, 25);
      this.panel7.TabIndex = 0;
      this.imgOnline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.imgOnline.BackColor = Color.White;
      this.imgOnline.Cursor = Cursors.Hand;
      this.imgOnline.Image = (Image) componentResourceManager.GetObject("imgOnline.Image");
      this.imgOnline.ImageActive = (Image) null;
      this.imgOnline.Location = new Point(1073, 4);
      this.imgOnline.Margin = new Padding(0);
      this.imgOnline.Name = "imgOnline";
      this.imgOnline.Size = new Size(17, 17);
      this.imgOnline.SizeMode = PictureBoxSizeMode.Zoom;
      this.imgOnline.TabIndex = 14;
      this.imgOnline.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.imgOnline, "  Online");
      this.imgOnline.Zoom = 8;
      this.imgOnline.Click += new EventHandler(this.ImgOnlineClick);
      this.imgOnline.MouseHover += new EventHandler(this.ImgOnlineMouseHover);
      this.panel9.BackColor = Color.White;
      this.panel9.Controls.Add((Control) this.lblTimeHientai);
      this.panel9.Dock = DockStyle.Right;
      this.panel9.Location = new Point(1091, 2);
      this.panel9.Name = "panel9";
      this.panel9.Size = new Size(85, 21);
      this.panel9.TabIndex = 1;
      this.lblTimeHientai.AutoSize = true;
      this.lblTimeHientai.BackColor = Color.Transparent;
      this.lblTimeHientai.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblTimeHientai.ForeColor = Color.Red;
      this.lblTimeHientai.Location = new Point(4, 3);
      this.lblTimeHientai.Name = "lblTimeHientai";
      this.lblTimeHientai.Size = new Size(43, 15);
      this.lblTimeHientai.TabIndex = 3;
      this.lblTimeHientai.Text = "            ";
      this.lblTimeHientai.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.lblTimeHientai, "Giờ hệ thống");
      this.menuMaintop.AutoSize = false;
      this.menuMaintop.BackColor = Color.White;
      this.menuMaintop.Dock = DockStyle.Fill;
      this.menuMaintop.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.menuMaintop.ImageScalingSize = new Size(17, 17);
      this.menuMaintop.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.thốngKêToolStripMenuItem,
        (ToolStripItem) this.boxLotoToolStripMenuItem,
        (ToolStripItem) this.thốngKêCầuĐẹpToolStripMenuItem,
        (ToolStripItem) this.tầnXuấtLôToolStripMenuItem,
        (ToolStripItem) this.bóngSốLồngCầuToolStripMenuItem,
        (ToolStripItem) this.nhậnĐịnhLôTôToolStripMenuItem,
        (ToolStripItem) this.nhậnĐịnhLôTôToolStripMenuItem1,
        (ToolStripItem) this.bảngVàoTiềnToolStripMenuItem,
        (ToolStripItem) this.càiĐặtToolStripMenuItem
      });
      this.menuMaintop.Location = new Point(0, 2);
      this.menuMaintop.Name = "menuMaintop";
      this.menuMaintop.Padding = new Padding(0, 1, 0, 0);
      this.menuMaintop.Size = new Size(1176, 21);
      this.menuMaintop.TabIndex = 0;
      this.menuMaintop.Text = "menuStrip1";
      this.thốngKêToolStripMenuItem.BackColor = Color.WhiteSmoke;
      this.thốngKêToolStripMenuItem.ForeColor = Color.Black;
      this.thốngKêToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("thốngKêToolStripMenuItem.Image");
      this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
      this.thốngKêToolStripMenuItem.Size = new Size(148, 20);
      this.thốngKêToolStripMenuItem.Text = "Thống kê cá nhân";
      this.thốngKêToolStripMenuItem.ToolTipText = " Sổ kết quả";
      this.thốngKêToolStripMenuItem.Click += new EventHandler(this.ThốngKêToolStripMenuItemClick);
      this.boxLotoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.bạcNhớToolStripMenuItem,
        (ToolStripItem) this.soiCầuToolStripMenuItem,
        (ToolStripItem) this.dànBấtKìCùngVềToolStripMenuItem,
        (ToolStripItem) this.bạcNhớLôXiênToolStripMenuItem,
        (ToolStripItem) this.bạcNhớTheoThứToolStripMenuItem
      });
      this.boxLotoToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("boxLotoToolStripMenuItem.Image");
      this.boxLotoToolStripMenuItem.Name = "boxLotoToolStripMenuItem";
      this.boxLotoToolStripMenuItem.Size = new Size(86, 20);
      this.boxLotoToolStripMenuItem.Text = "Bạc nhớ";
      this.boxLotoToolStripMenuItem.ToolTipText = " Xem xét các sự kiện đặc biệt xảy ra trong quá khứ thì có những lô gì hay ra";
      this.bạcNhớToolStripMenuItem.Name = "bạcNhớToolStripMenuItem";
      this.bạcNhớToolStripMenuItem.Size = new Size(195, 22);
      this.bạcNhớToolStripMenuItem.Text = "Bạc nhớ cơ bản";
      this.bạcNhớToolStripMenuItem.Click += new EventHandler(this.BạcNhớToolStripMenuItemClick);
      this.soiCầuToolStripMenuItem.Name = "soiCầuToolStripMenuItem";
      this.soiCầuToolStripMenuItem.Size = new Size(195, 22);
      this.soiCầuToolStripMenuItem.Text = "Bạc nhớ nâng cao";
      this.soiCầuToolStripMenuItem.Click += new EventHandler(this.SoiCầuToolStripMenuItemClick);
      this.dànBấtKìCùngVềToolStripMenuItem.Name = "dànBấtKìCùngVềToolStripMenuItem";
      this.dànBấtKìCùngVềToolStripMenuItem.Size = new Size(195, 22);
      this.dànBấtKìCùngVềToolStripMenuItem.Text = "Dàn bất kỳ cùng về";
      this.dànBấtKìCùngVềToolStripMenuItem.Click += new EventHandler(this.DànBấtKìCùngVềToolStripMenuItemClick);
      this.bạcNhớLôXiênToolStripMenuItem.Name = "bạcNhớLôXiênToolStripMenuItem";
      this.bạcNhớLôXiênToolStripMenuItem.Size = new Size(195, 22);
      this.bạcNhớLôXiênToolStripMenuItem.Text = "Bạc nhớ lô xiên";
      this.bạcNhớLôXiênToolStripMenuItem.Visible = false;
      this.bạcNhớLôXiênToolStripMenuItem.Click += new EventHandler(this.bạcNhớLôXiênToolStripMenuItem_Click);
      this.bạcNhớTheoThứToolStripMenuItem.Name = "bạcNhớTheoThứToolStripMenuItem";
      this.bạcNhớTheoThứToolStripMenuItem.Size = new Size(195, 22);
      this.bạcNhớTheoThứToolStripMenuItem.Text = "Bạc nhớ theo thứ";
      this.bạcNhớTheoThứToolStripMenuItem.Click += new EventHandler(this.bạcNhớTheoThứToolStripMenuItem_Click);
      this.thốngKêCầuĐẹpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.thốngKêCầuĐẹpToolStripMenuItem1,
        (ToolStripItem) this.xemChiTiếtCầuChạyToolStripMenuItem,
        (ToolStripItem) this.cầuBạchThủToolStripMenuItem
      });
      this.thốngKêCầuĐẹpToolStripMenuItem.Name = "thốngKêCầuĐẹpToolStripMenuItem";
      this.thốngKêCầuĐẹpToolStripMenuItem.Size = new Size(79, 20);
      this.thốngKêCầuĐẹpToolStripMenuItem.Text = "Soi cầu lô";
      this.thốngKêCầuĐẹpToolStripMenuItem.ToolTipText = " Xem tất cả các cầu đẹp theo ý bạn trong 11.449 cầu hàng ngày";
      this.thốngKêCầuĐẹpToolStripMenuItem1.Name = "thốngKêCầuĐẹpToolStripMenuItem1";
      this.thốngKêCầuĐẹpToolStripMenuItem1.Size = new Size(206, 22);
      this.thốngKêCầuĐẹpToolStripMenuItem1.Text = "Thống kê cầu đẹp";
      this.thốngKêCầuĐẹpToolStripMenuItem1.Click += new EventHandler(this.ThốngKêCầuĐẹpToolStripMenuItem1Click);
      this.xemChiTiếtCầuChạyToolStripMenuItem.Name = "xemChiTiếtCầuChạyToolStripMenuItem";
      this.xemChiTiếtCầuChạyToolStripMenuItem.Size = new Size(206, 22);
      this.xemChiTiếtCầuChạyToolStripMenuItem.Text = "Xem chi tiết cầu chạy";
      this.xemChiTiếtCầuChạyToolStripMenuItem.Click += new EventHandler(this.XemChiTiếtCầuChạyToolStripMenuItemClick);
      this.cầuBạchThủToolStripMenuItem.Name = "cầuBạchThủToolStripMenuItem";
      this.cầuBạchThủToolStripMenuItem.Size = new Size(206, 22);
      this.cầuBạchThủToolStripMenuItem.Text = "Soi cầu bạch thủ";
      this.cầuBạchThủToolStripMenuItem.Click += new EventHandler(this.CầuBạchThủToolStripMenuItemClick);
      this.tầnXuấtLôToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.chuKỳLôToolStripMenuItem,
        (ToolStripItem) this.tầnXuấtLôToolStripMenuItem1,
        (ToolStripItem) this.thốngKêLôXiên2ToolStripMenuItem,
        (ToolStripItem) this.thốngKêTổngHợpToolStripMenuItem
      });
      this.tầnXuấtLôToolStripMenuItem.Name = "tầnXuấtLôToolStripMenuItem";
      this.tầnXuấtLôToolStripMenuItem.Size = new Size(109, 20);
      this.tầnXuấtLôToolStripMenuItem.Text = "Thống kê lô tô";
      this.tầnXuấtLôToolStripMenuItem.ToolTipText = " Thống kê các thông tin liên quan đến một lô bất kỳ";
      this.chuKỳLôToolStripMenuItem.Name = "chuKỳLôToolStripMenuItem";
      this.chuKỳLôToolStripMenuItem.Size = new Size(175, 22);
      this.chuKỳLôToolStripMenuItem.Text = "Chu kỳ lô tô";
      this.chuKỳLôToolStripMenuItem.Click += new EventHandler(this.ChuKỳLôToolStripMenuItemClick);
      this.tầnXuấtLôToolStripMenuItem1.Name = "tầnXuấtLôToolStripMenuItem1";
      this.tầnXuấtLôToolStripMenuItem1.Size = new Size(175, 22);
      this.tầnXuấtLôToolStripMenuItem1.Text = "Tần xuất lô tô";
      this.tầnXuấtLôToolStripMenuItem1.Click += new EventHandler(this.TầnXuấtLôToolStripMenuItem1Click);
      this.thốngKêLôXiên2ToolStripMenuItem.Name = "thốngKêLôXiên2ToolStripMenuItem";
      this.thốngKêLôXiên2ToolStripMenuItem.Size = new Size(175, 22);
      this.thốngKêLôXiên2ToolStripMenuItem.Text = "Chu kỳ lô xiên";
      this.thốngKêLôXiên2ToolStripMenuItem.Click += new EventHandler(this.thốngKêLôXiên2ToolStripMenuItem_Click);
      this.thốngKêTổngHợpToolStripMenuItem.Name = "thốngKêTổngHợpToolStripMenuItem";
      this.thốngKêTổngHợpToolStripMenuItem.Size = new Size(175, 22);
      this.thốngKêTổngHợpToolStripMenuItem.Text = "Tồng quan về lô";
      this.thốngKêTổngHợpToolStripMenuItem.Click += new EventHandler(this.ThốngKêTổngHợpToolStripMenuItemClick);
      this.bóngSốLồngCầuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.thốngKêĐầuSốToolStripMenuItem1,
        (ToolStripItem) this.thốngKêNgũHànhToolStripMenuItem1,
        (ToolStripItem) this.xemHiệuQuảBóngSốToolStripMenuItem
      });
      this.bóngSốLồngCầuToolStripMenuItem.Name = "bóngSốLồngCầuToolStripMenuItem";
      this.bóngSốLồngCầuToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 20);
      this.bóngSốLồngCầuToolStripMenuItem.Text = "Bóng số lồng cầu";
      this.thốngKêĐầuSốToolStripMenuItem1.Name = "thốngKêĐầuSốToolStripMenuItem1";
      this.thốngKêĐầuSốToolStripMenuItem1.Size = new Size(215, 22);
      this.thốngKêĐầuSốToolStripMenuItem1.Text = "Thống kê đầu số";
      this.thốngKêĐầuSốToolStripMenuItem1.Click += new EventHandler(this.thốngKêĐầuSốToolStripMenuItem1_Click);
      this.thốngKêNgũHànhToolStripMenuItem1.Name = "thốngKêNgũHànhToolStripMenuItem1";
      this.thốngKêNgũHànhToolStripMenuItem1.Size = new Size(215, 22);
      this.thốngKêNgũHànhToolStripMenuItem1.Text = "Thống kê ngũ hành";
      this.thốngKêNgũHànhToolStripMenuItem1.Click += new EventHandler(this.thốngKêNgũHànhToolStripMenuItem1_Click);
      this.xemHiệuQuảBóngSốToolStripMenuItem.Name = "xemHiệuQuảBóngSốToolStripMenuItem";
      this.xemHiệuQuảBóngSốToolStripMenuItem.Size = new Size(215, 22);
      this.xemHiệuQuảBóngSốToolStripMenuItem.Text = "Xem hiệu quả bóng số";
      this.xemHiệuQuảBóngSốToolStripMenuItem.Click += new EventHandler(this.xemHiệuQuảBóngSốToolStripMenuItem_Click);
      this.nhậnĐịnhLôTôToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.bảngĐặcBiệtToolStripMenuItem,
        (ToolStripItem) this.tầnXuấtCácLoạiDànToolStripMenuItem,
        (ToolStripItem) this.loạiDànToolStripMenuItem,
        (ToolStripItem) this.gépDànĐặcBiệtToolStripMenuItem,
        (ToolStripItem) this.chuKỳGiảiĐặcBiệtToolStripMenuItem
      });
      this.nhậnĐịnhLôTôToolStripMenuItem.Name = "nhậnĐịnhLôTôToolStripMenuItem";
      this.nhậnĐịnhLôTôToolStripMenuItem.Size = new Size(131, 20);
      this.nhậnĐịnhLôTôToolStripMenuItem.Text = "Thống kê đặc biệt";
      this.bảngĐặcBiệtToolStripMenuItem.Name = "bảngĐặcBiệtToolStripMenuItem";
      this.bảngĐặcBiệtToolStripMenuItem.Size = new Size(207, 22);
      this.bảngĐặcBiệtToolStripMenuItem.Text = "Bảng đặc biệt";
      this.bảngĐặcBiệtToolStripMenuItem.Click += new EventHandler(this.bảngĐặcBiệtToolStripMenuItem_Click);
      this.tầnXuấtCácLoạiDànToolStripMenuItem.Name = "tầnXuấtCácLoạiDànToolStripMenuItem";
      this.tầnXuấtCácLoạiDànToolStripMenuItem.Size = new Size(207, 22);
      this.tầnXuấtCácLoạiDànToolStripMenuItem.Text = "Tần xuất các loại dàn";
      this.tầnXuấtCácLoạiDànToolStripMenuItem.Click += new EventHandler(this.tầnXuấtCácLoạiDànToolStripMenuItem_Click);
      this.loạiDànToolStripMenuItem.Name = "loạiDànToolStripMenuItem";
      this.loạiDànToolStripMenuItem.Size = new Size(207, 22);
      this.loạiDànToolStripMenuItem.Text = "Loại dàn đặc biệt";
      this.loạiDànToolStripMenuItem.Visible = false;
      this.loạiDànToolStripMenuItem.Click += new EventHandler(this.loạiDànToolStripMenuItem_Click);
      this.gépDànĐặcBiệtToolStripMenuItem.Name = "gépDànĐặcBiệtToolStripMenuItem";
      this.gépDànĐặcBiệtToolStripMenuItem.Size = new Size(207, 22);
      this.gépDànĐặcBiệtToolStripMenuItem.Text = "Gép dàn đặc biệt";
      this.gépDànĐặcBiệtToolStripMenuItem.Visible = false;
      this.gépDànĐặcBiệtToolStripMenuItem.Click += new EventHandler(this.gépDànĐặcBiệtToolStripMenuItem_Click);
      this.chuKỳGiảiĐặcBiệtToolStripMenuItem.Name = "chuKỳGiảiĐặcBiệtToolStripMenuItem";
      this.chuKỳGiảiĐặcBiệtToolStripMenuItem.Size = new Size(207, 22);
      this.chuKỳGiảiĐặcBiệtToolStripMenuItem.Text = "Chu kỳ giải đặc biệt";
      this.chuKỳGiảiĐặcBiệtToolStripMenuItem.Visible = false;
      this.chuKỳGiảiĐặcBiệtToolStripMenuItem.Click += new EventHandler(this.chuKỳGiảiĐặcBiệtToolStripMenuItem_Click);
      this.nhậnĐịnhLôTôToolStripMenuItem1.Name = "nhậnĐịnhLôTôToolStripMenuItem1";
      this.nhậnĐịnhLôTôToolStripMenuItem1.Size = new Size(98, 20);
      this.nhậnĐịnhLôTôToolStripMenuItem1.Text = "Nhận định lô";
      this.nhậnĐịnhLôTôToolStripMenuItem1.Click += new EventHandler(this.nhậnĐịnhLôTôToolStripMenuItem1_Click);
      this.bảngVàoTiềnToolStripMenuItem.Name = "bảngVàoTiềnToolStripMenuItem";
      this.bảngVàoTiềnToolStripMenuItem.Size = new Size(106, 20);
      this.bảngVàoTiềnToolStripMenuItem.Text = "Bảng vào tiền";
      this.bảngVàoTiềnToolStripMenuItem.Click += new EventHandler(this.BảngVàoTiềnToolStripMenuItemClick);
      this.càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
      this.càiĐặtToolStripMenuItem.Size = new Size(75, 20);
      this.càiĐặtToolStripMenuItem.Text = "Cấu hình";
      this.càiĐặtToolStripMenuItem.Click += new EventHandler(this.CàiĐặtToolStripMenuItemClick);
      this.bunifuImageButton4.BackColor = Color.SeaGreen;
      this.bunifuImageButton4.Image = (Image) componentResourceManager.GetObject("bunifuImageButton4.Image");
      this.bunifuImageButton4.ImageActive = (Image) null;
      this.bunifuImageButton4.Location = new Point(1206, 1);
      this.bunifuImageButton4.Name = "bunifuImageButton4";
      this.bunifuImageButton4.Size = new Size(39, 19);
      this.bunifuImageButton4.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton4.TabIndex = 1;
      this.bunifuImageButton4.TabStop = false;
      this.bunifuImageButton4.Zoom = 10;
      this.toolTip1.AutoPopDelay = 5000;
      this.toolTip1.BackColor = Color.White;
      this.toolTip1.ForeColor = Color.Black;
      this.toolTip1.InitialDelay = 200;
      this.toolTip1.ReshowDelay = 50;
      this.bunifuElipseAvartar.ElipseRadius = 10;
      this.bunifuElipseAvartar.TargetControl = (Control) this;
      this.tmThongbao.Interval = 17;
      this.tmThongbao.Tick += new EventHandler(this.TmThongbaoTick1);
      this.tmMessage.Interval = 300;
      this.tmMessage.Tick += new EventHandler(this.TmMessageTick);
      this.timerGet_Message_TinhTime.Interval = 1000;
      this.timerGet_Message_TinhTime.Tick += new EventHandler(this.TimerGetMessageTick);
      this.bgBuzz.DoWork += new DoWorkEventHandler(this.BgBuzzDoWork);
      this.timerOnline.Interval = 10000;
      this.timerOnline.Tick += new EventHandler(this.TimerOnlineTick1);
      this.timeNaptien.Enabled = true;
      this.timeNaptien.Tick += new EventHandler(this.timeNaptien_Tick);
      this.bgThongbaoLink.DoWork += new DoWorkEventHandler(this.bgThongbaoLink_DoWork);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1360, 840);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.headMenu);
      this.Controls.Add((Control) this.pnRight);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Location = new Point(2, 0);
      this.Name = nameof (FMain);
      this.SizeGripStyle = SizeGripStyle.Show;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Tag = (object) "Ủng hộ";
      this.Text = "Thống kê xổ số";
      this.FormClosing += new FormClosingEventHandler(this.FMainFormClosing);
      this.FormClosed += new FormClosedEventHandler(this.FMain_FormClosed);
      this.Load += new EventHandler(this.FMainLoad);
      this.pnRight.ResumeLayout(false);
      this.panel11.ResumeLayout(false);
      this.bunifuImageButton13.EndInit();
      this.bunifuImageButton12.EndInit();
      this.bunifuImageButton11.EndInit();
      this.bunifuImageButton10.EndInit();
      this.pnBottum.ResumeLayout(false);
      this.panel10.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.picAvartar1.EndInit();
      this.headMenu.ResumeLayout(false);
      this.bunifuImageButton7.EndInit();
      this._imgIsMessage.EndInit();
      this.bunifuImageButton9.EndInit();
      this.bunifuImageButton8.EndInit();
      this.panel4.ResumeLayout(false);
      this.btnPhongto.EndInit();
      this.bunifuImageButton3.EndInit();
      this.bunifuImageButton6.EndInit();
      this.bunifuImageButton2.EndInit();
      this.bunifuImageButton1.EndInit();
      this.panel2.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.panel7.ResumeLayout(false);
      this.imgOnline.EndInit();
      this.panel9.ResumeLayout(false);
      this.panel9.PerformLayout();
      this.menuMaintop.ResumeLayout(false);
      this.menuMaintop.PerformLayout();
      this.bunifuImageButton4.EndInit();
      this.ResumeLayout(false);
    }
  }
}
