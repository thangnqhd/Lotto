// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FThemNgaysudung
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class FThemNgaysudung : Form
  {
    private IContainer components = (IContainer) null;
    private Decimal vangConthieu = new Decimal();
    private string[] _msg;
    public DataTable Dt;
    public TbNgaysudung ObjNgaysudung;
    public tbMoneyUSER TbMoney;
    private Panel panel1;
    private BunifuThinButton2 btnXacnhan;
    private LinkLabel lblHuybo;
    private PictureBox picMainTop;
    private BunifuImageButton bunifuImageButton3;
    private Label label2;
    private Label lblVanghienco;
    private Label label4;
    private Label lblHSD;
    private Label label5;
    private BunifuElipse bunifuElipsepanel1;
    private Label lblVangconthieu;
    private Timer timerHSD;
    private Label lblThua_Thieu;
    private ComboBox cbbNgaysudung;
    private Label label1;
    private Panel panel2;
    private Label label3;
    private PictureBox pictureBox1;
    private Label label6;

    public FThemNgaysudung()
    {
      this.InitializeComponent();
    }

    private void GetInfoMoney()
    {
      this.TbMoney = new tbMoneyUSER();
      this.TbMoney = this.TbMoney.GetInfor(TbUser.Tbuser.TenDangnhap);
      this.lblVanghienco.Text = Convert.ToDecimal(this.TbMoney.VangHienco).ToString("#,#0.") + Resources.fThemXu_show_Value__vàng;
    }

    private void GetAll()
    {
      this.Dt = new DataTable();
      this.Dt = new TbQuidoiVangNgaySuDung().GetListInfor();
      if (this.Dt.Rows.Count < 1)
      {
        Application.Exit();
      }
      else
      {
        this.AddCombobox(this.Dt);
        this.cbbNgaysudung.SelectedIndex = 0;
      }
    }

    private void HienThiInfo(string id)
    {
      try
      {
        int.Parse(id);
        TbQuidoiVangNgaySuDung infor = new TbQuidoiVangNgaySuDung().GetInfor(id);
        this.GetInfoMoney();
        this.vangConthieu = Convert.ToDecimal(this.TbMoney.VangHienco) - Convert.ToDecimal(infor.VangCan);
        if (this.vangConthieu >= Decimal.Zero)
          this.lblThua_Thieu.Text = Resources.FThemNgaysudung_hienThiInfo_Còn_lại__;
        else
          this.lblThua_Thieu.Text = Resources.FThemNgaysudung_HienThiInfo___Thiếu__;
        this.lblVangconthieu.Text = ClMain.QuiDoiSoLuong(this.vangConthieu.ToString(), "vàng");
      }
      catch (Exception ex)
      {
      }
    }

    private void AddCombobox(DataTable dtTb)
    {
      ArrayList arrayList = new ArrayList();
      for (int index = 0; index < dtTb.Rows.Count; ++index)
      {
        string display = dtTb.Rows[index]["name"].ToString() + "(" + ClMain.QuiDoiSoLuong(dtTb.Rows[index]["vangCan"].ToString(), "vàng") + ")";
        arrayList.Add((object) new ClMain.AddValue(display, dtTb.Rows[index]["stt"].ToString()));
      }
      this.cbbNgaysudung.DataSource = (object) arrayList;
      this.cbbNgaysudung.DisplayMember = "Display";
      this.cbbNgaysudung.ValueMember = "Value";
    }

    private void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
    {
      this.HienThiInfo(this.cbbNgaysudung.SelectedValue.ToString());
    }

    private void LblHuyboLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Close();
      this.timerHSD.Stop();
    }

    private void BunifuImageButton3Click(object sender, EventArgs e)
    {
      this.Close();
      this.timerHSD.Stop();
    }

    private void TimerHsdTick(object sender, EventArgs e)
    {
      this.lblHSD.Text = FMain.HanSuDung;
    }

    private void BtnXacnhanClick(object sender, EventArgs e)
    {
      this.XuLy();
      this.HienThiInfo(this.cbbNgaysudung.SelectedValue.ToString());
      this.Close();
    }

    private void XuLy()
    {
      this.vangConthieu = new Decimal();
      TbQuidoiVangNgaySuDung infor = new TbQuidoiVangNgaySuDung().GetInfor(this.cbbNgaysudung.SelectedValue.ToString());
      this.GetInfoMoney();
      this.vangConthieu = Convert.ToDecimal(this.TbMoney.VangHienco) - Convert.ToDecimal(infor.VangCan);
      if (this.vangConthieu >= Decimal.Zero)
      {
        this.XuLyInsert(infor, this.TbMoney.SuDungden_Ngay);
        TabInfoUser.LoadLaiFrom = 1;
        FMain.LoadLaiForm = 1;
        FMain.LoadLai_napTien = 1;
      }
      else
      {
        this._msg = ClMain.Get_Msg("015");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void InsertMessage(TbQuidoiVangNgaySuDung objVangquidoi)
    {
      tbMessage tbMessage = new tbMessage()
      {
        NguoiGui = "Administrator",
        NguoiNhan = TbUser.Tbuser.TenDangnhap,
        TieuDe = "Mua thêm ngày sử dụng",
        NoiDung = "Bạn vừa ủng hộ thêm [<b style=''color:red''>" + objVangquidoi.NgayDoiduoc + "</b>] ngày sử dụng thành công !!! Thời hạn sử dụng mới của bạn đến [<b style=''color:red''>" + (object) this.ObjNgaysudung.NgayHethan + "</b>]"
      };
      tbMessage.Insert(tbMessage);
    }

    public void XuLyInsert(TbQuidoiVangNgaySuDung obj, DateTime sudungdenngay)
    {
      this.InsertNgaysudung(obj);
      this.InsertVangsudung(obj);
      this.UpdateMoney(obj);
      this.InsertMessage(obj);
      FMain.LoadLaiForm = 1;
      TabInfoUser.LoadLaiFrom = 1;
    }

    public void InsertNgaysudung(TbQuidoiVangNgaySuDung obj)
    {
      this.ObjNgaysudung = new TbNgaysudung();
      this.ObjNgaysudung = this.ObjNgaysudung.TbNgaysudungGetTopNewByUsername(TbUser.Tbuser.TenDangnhap);
      DateTime suDungdenNgay = this.TbMoney.SuDungden_Ngay;
      this.ObjNgaysudung = new TbNgaysudung();
      this.ObjNgaysudung.TenDangnhap = TbUser.Tbuser.TenDangnhap;
      this.ObjNgaysudung.NgaySudung = obj.NgayDoiduoc;
      this.ObjNgaysudung.CachSudung = "Mua bằng vàng (" + obj.VangCan + "-" + obj.NgayDoiduoc + ")";
      DateTime dateTime = Convert.ToDateTime(ClMain.getTime_Server_CheckConnection().Rows[0][0].ToString());
      this.ObjNgaysudung.NgayChuyendoi = dateTime;
      this.ObjNgaysudung.NgayHethan = !(dateTime > suDungdenNgay) ? suDungdenNgay.AddDays((double) Convert.ToInt32(this.ObjNgaysudung.NgaySudung)) : this.ObjNgaysudung.NgayChuyendoi.AddDays((double) Convert.ToInt32(this.ObjNgaysudung.NgaySudung));
      this.ObjNgaysudung.Insert(this.ObjNgaysudung);
    }

    public void InsertVangsudung(TbQuidoiVangNgaySuDung objVangquidoi)
    {
      tbVangsudung tbVangsudung = new tbVangsudung();
      tbVangsudung.TenDangnhap = TbUser.Tbuser.TenDangnhap;
      tbVangsudung.VangSudung = (-Convert.ToDecimal(objVangquidoi.VangCan)).ToString();
      tbVangsudung.CachSudung = "Mua thêm ngày sử dụng (" + objVangquidoi.VangCan + "-" + objVangquidoi.NgayDoiduoc + ")";
      tbVangsudung.Insert(tbVangsudung);
    }

    public void UpdateMoney(TbQuidoiVangNgaySuDung objVangquidoi)
    {
      this.TbMoney = new tbMoneyUSER();
      this.TbMoney = this.TbMoney.GetInfor(TbUser.Tbuser.TenDangnhap);
      this.TbMoney.VangHienco = (Convert.ToDecimal(this.TbMoney.VangHienco) - Convert.ToDecimal(objVangquidoi.VangCan)).ToString();
      this.TbMoney.XuHienco = this.TbMoney.XuHienco;
      this.TbMoney.SuDungtu_Ngay = this.ObjNgaysudung.NgayChuyendoi;
      this.TbMoney.SuDungden_Ngay = this.ObjNgaysudung.NgayHethan;
      if (this.TbMoney.Update(this.TbMoney) == 1)
      {
        this._msg = ClMain.Get_Msg("021");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this._msg = ClMain.Get_Msg("009");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Application.Exit();
      }
    }

    private void CbbNgaysudungKeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.XuLy();
    }

    private void FThemNgaysudungLoad(object sender, EventArgs e)
    {
      this.GetAll();
      this.timerHSD.Start();
      this.GetInfoMoney();
      this.HienThiInfo(this.cbbNgaysudung.SelectedValue.ToString());
      this.cbbNgaysudung.Focus();
    }

    private void PicMainTopMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      FMain.LinkToNapToNapTien();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FThemNgaysudung));
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.lblVangconthieu = new Label();
      this.cbbNgaysudung = new ComboBox();
      this.lblHSD = new Label();
      this.lblVanghienco = new Label();
      this.btnXacnhan = new BunifuThinButton2();
      this.lblHuybo = new LinkLabel();
      this.lblThua_Thieu = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label2 = new Label();
      this.picMainTop = new PictureBox();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.bunifuElipsepanel1 = new BunifuElipse(this.components);
      this.timerHSD = new Timer(this.components);
      this.panel2 = new Panel();
      this.label3 = new Label();
      this.label6 = new Label();
      this.pictureBox1 = new PictureBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.lblVangconthieu);
      this.panel1.Controls.Add((Control) this.cbbNgaysudung);
      this.panel1.Controls.Add((Control) this.lblHSD);
      this.panel1.Controls.Add((Control) this.lblVanghienco);
      this.panel1.Controls.Add((Control) this.btnXacnhan);
      this.panel1.Controls.Add((Control) this.lblHuybo);
      this.panel1.Controls.Add((Control) this.lblThua_Thieu);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel1.Location = new Point(33, 151);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(72, 210);
      this.panel1.TabIndex = 7;
      this.panel1.Visible = false;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(193, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(144, 16);
      this.label1.TabIndex = 19;
      this.label1.Text = "GIA HẠN THÀNH VIÊN";
      this.lblVangconthieu.AutoSize = true;
      this.lblVangconthieu.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVangconthieu.ForeColor = Color.Red;
      this.lblVangconthieu.Location = new Point(184, 134);
      this.lblVangconthieu.Margin = new Padding(0);
      this.lblVangconthieu.Name = "lblVangconthieu";
      this.lblVangconthieu.Size = new Size(51, 17);
      this.lblVangconthieu.TabIndex = 17;
      this.lblVangconthieu.Text = "0 vàng";
      this.lblVangconthieu.TextAlign = ContentAlignment.MiddleLeft;
      this.cbbNgaysudung.BackColor = Color.Teal;
      this.cbbNgaysudung.Cursor = Cursors.Hand;
      this.cbbNgaysudung.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbNgaysudung.FlatStyle = FlatStyle.Popup;
      this.cbbNgaysudung.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbNgaysudung.ForeColor = Color.White;
      this.cbbNgaysudung.FormattingEnabled = true;
      this.cbbNgaysudung.Location = new Point(184, 99);
      this.cbbNgaysudung.Name = "cbbNgaysudung";
      this.cbbNgaysudung.Size = new Size(297, 24);
      this.cbbNgaysudung.TabIndex = 0;
      this.cbbNgaysudung.SelectedIndexChanged += new EventHandler(this.ComboBox1SelectedIndexChanged);
      this.cbbNgaysudung.KeyPress += new KeyPressEventHandler(this.CbbNgaysudungKeyPress);
      this.lblHSD.AutoSize = true;
      this.lblHSD.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHSD.ForeColor = Color.Red;
      this.lblHSD.Location = new Point(184, 73);
      this.lblHSD.Name = "lblHSD";
      this.lblHSD.Size = new Size(102, 17);
      this.lblHSD.TabIndex = 17;
      this.lblHSD.Text = "3d 12-23-2017";
      this.lblVanghienco.AutoSize = true;
      this.lblVanghienco.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVanghienco.ForeColor = Color.Red;
      this.lblVanghienco.Location = new Point(184, 42);
      this.lblVanghienco.Name = "lblVanghienco";
      this.lblVanghienco.Size = new Size(51, 17);
      this.lblVanghienco.TabIndex = 17;
      this.lblVanghienco.Text = "0 vàng";
      this.btnXacnhan.ActiveBorderThickness = 1;
      this.btnXacnhan.ActiveCornerRadius = 20;
      this.btnXacnhan.ActiveFillColor = Color.DodgerBlue;
      this.btnXacnhan.ActiveForecolor = Color.White;
      this.btnXacnhan.ActiveLineColor = Color.DodgerBlue;
      this.btnXacnhan.BackColor = Color.White;
      this.btnXacnhan.BackgroundImage = (Image) componentResourceManager.GetObject("btnXacnhan.BackgroundImage");
      this.btnXacnhan.ButtonText = "Xác nhận";
      this.btnXacnhan.Cursor = Cursors.Hand;
      this.btnXacnhan.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnXacnhan.ForeColor = Color.Black;
      this.btnXacnhan.IdleBorderThickness = 1;
      this.btnXacnhan.IdleCornerRadius = 20;
      this.btnXacnhan.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnXacnhan.IdleForecolor = Color.White;
      this.btnXacnhan.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnXacnhan.Location = new Point(166, 158);
      this.btnXacnhan.Margin = new Padding(6, 5, 6, 5);
      this.btnXacnhan.Name = "btnXacnhan";
      this.btnXacnhan.Size = new Size(309, 40);
      this.btnXacnhan.TabIndex = 1;
      this.btnXacnhan.TextAlign = ContentAlignment.MiddleCenter;
      this.btnXacnhan.Click += new EventHandler(this.BtnXacnhanClick);
      this.lblHuybo.AutoSize = true;
      this.lblHuybo.Cursor = Cursors.Hand;
      this.lblHuybo.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHuybo.LinkBehavior = LinkBehavior.HoverUnderline;
      this.lblHuybo.LinkColor = Color.DodgerBlue;
      this.lblHuybo.Location = new Point(115, 170);
      this.lblHuybo.Name = "lblHuybo";
      this.lblHuybo.Size = new Size(45, 15);
      this.lblHuybo.TabIndex = 2;
      this.lblHuybo.TabStop = true;
      this.lblHuybo.Text = "Hủy bỏ";
      this.lblHuybo.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LblHuyboLinkClicked);
      this.lblThua_Thieu.AutoSize = true;
      this.lblThua_Thieu.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThua_Thieu.ForeColor = Color.DimGray;
      this.lblThua_Thieu.Location = new Point((int) sbyte.MaxValue, 134);
      this.lblThua_Thieu.Name = "lblThua_Thieu";
      this.lblThua_Thieu.Size = new Size(61, 17);
      this.lblThua_Thieu.TabIndex = 1;
      this.lblThua_Thieu.Text = "Còn lại :";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DimGray;
      this.label4.Location = new Point(16, 103);
      this.label4.Name = "label4";
      this.label4.Size = new Size(171, 17);
      this.label4.TabIndex = 1;
      this.label4.Text = "Bạn muốn gia hạn thêm :";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DimGray;
      this.label5.Location = new Point(60, 72);
      this.label5.Name = "label5";
      this.label5.Size = new Size(128, 17);
      this.label5.TabIndex = 1;
      this.label5.Text = "Thời gian hiện có :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DimGray;
      this.label2.Location = new Point(68, 41);
      this.label2.Name = "label2";
      this.label2.Size = new Size(120, 17);
      this.label2.TabIndex = 1;
      this.label2.Text = "Số vàng hiện có :";
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(752, 189);
      this.picMainTop.TabIndex = 8;
      this.picMainTop.TabStop = false;
      this.picMainTop.MouseDown += new MouseEventHandler(this.PicMainTopMouseDown);
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(732, 0);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(20, 20);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 9;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.BunifuImageButton3Click);
      this.bunifuElipsepanel1.ElipseRadius = 10;
      this.bunifuElipsepanel1.TargetControl = (Control) this.panel1;
      this.timerHSD.Enabled = true;
      this.timerHSD.Interval = 50;
      this.timerHSD.Tick += new EventHandler(this.TimerHsdTick);
      this.panel2.BackColor = Color.White;
      this.panel2.Controls.Add((Control) this.pictureBox1);
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Location = new Point(111, 57);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(540, 261);
      this.panel2.TabIndex = 10;
      this.label3.Font = new Font("Arial", 26.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(3, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(537, 119);
      this.label3.TabIndex = 0;
      this.label3.Text = "Tài khoản của bạn đã \r\nhết hạn sử dụng !";
      this.label3.TextAlign = ContentAlignment.MiddleCenter;
      this.label6.Font = new Font("Tahoma", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Red;
      this.label6.Location = new Point(3, 99);
      this.label6.Name = "label6";
      this.label6.Size = new Size(534, 72);
      this.label6.TabIndex = 1;
      this.label6.Text = "Hay tham gia cộng đồng Sinh Tài Sinh Lộc \r\nđể có được những kinh nghiệm và trợ giúp tốt nhất từ ban quản trị\r\n cùng các thành viên đã sử dụng phần mềm lâu năm.";
      this.label6.TextAlign = ContentAlignment.MiddleCenter;
      this.pictureBox1.Cursor = Cursors.Hand;
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(121, 180);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(304, 69);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(752, 362);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.picMainTop);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FThemNgaysudung);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Gia hạn thành viên";
      this.Load += new EventHandler(this.FThemNgaysudungLoad);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.bunifuImageButton3.EndInit();
      this.panel2.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
