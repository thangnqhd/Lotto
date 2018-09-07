// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FThemXu
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class FThemXu : Form
  {
    private IContainer components = (IContainer) null;
    public tbMoneyUSER TbMoney;
    public tbConfigApp ObjConfig;
    private Decimal _vanghienco;
    private Decimal _bachienco;
    private Decimal _soBacdoiduoc;
    private Decimal _sovangmuondoi;
    private string[] _msg;
    private PictureBox picMainTop;
    private BunifuImageButton bunifuImageButton3;
    private Panel panel1;
    private Label label1;
    private TextBox txtSovangmuondoi;
    private Label lblBachienco;
    private Label lblTongsobacco;
    private Label lblVanghienco;
    private BunifuThinButton2 btnXacnhan;
    private LinkLabel lblHuybo;
    private Label lblThua_Thieu;
    private Label label4;
    private Label label5;
    private Label label2;
    private TextBox txtSobacDoiduoc;
    private Label label3;
    private BunifuElipse bunifuElipse1;
    private Label label6;

    public FThemXu()
    {
      this.InitializeComponent();
    }

    private void InfoMoney()
    {
      this.ObjConfig = new tbConfigApp();
      this.ObjConfig = this.ObjConfig.GetInfoApp();
      this.TbMoney = new tbMoneyUSER();
      this.TbMoney = this.TbMoney.GetInfor(TbUser.Tbuser.TenDangnhap);
      this._vanghienco = Convert.ToDecimal(this.TbMoney.VangHienco);
      this._bachienco = Convert.ToDecimal(this.TbMoney.XuHienco);
      this._sovangmuondoi = new Decimal();
      this._sovangmuondoi = this._vanghienco > new Decimal(1000) ? new Decimal(1000) : this._vanghienco;
    }

    private void ShowValue(Decimal soVangMuonDoi)
    {
      this._soBacdoiduoc = soVangMuonDoi * Convert.ToDecimal(this.ObjConfig.vangRaxu);
      this.lblVanghienco.Text = this._vanghienco.ToString("#,#0.") + Resources.fThemXu_show_Value__vàng;
      this.lblBachienco.Text = ClMain.QuiDoiSoLuong(this._bachienco.ToString(), "bạc");
      this.txtSovangmuondoi.Text = soVangMuonDoi.ToString();
      this.txtSobacDoiduoc.Text = ClMain.QuiDoiSoLuong(this._soBacdoiduoc.ToString(), "");
      this.lblTongsobacco.Text = ClMain.QuiDoiSoLuong((this._soBacdoiduoc + this._bachienco).ToString(), "bạc");
    }

    private void BunifuImageButton3Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void LblHuyboLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Close();
    }

    private void BtnXacnhanClick(object sender, EventArgs e)
    {
      this.XuLy();
    }

    private void XuLy()
    {
      this.InfoMoney();
      if (this.txtSovangmuondoi.Text.Length > 0 && this.IsNumber(this.txtSovangmuondoi.Text) && Convert.ToDecimal(this.txtSovangmuondoi.Text) > Decimal.Zero)
      {
        Decimal num1 = Convert.ToDecimal(this.txtSovangmuondoi.Text);
        if (this._vanghienco >= num1)
        {
          this._sovangmuondoi = num1;
          this.XuLyInsert();
          this.InfoMoney();
          this.ShowValue(Convert.ToDecimal(num1));
          FMain.LoadLaiForm = 1;
          TabInfoUser.LoadLaiFrom = 1;
        }
        else
        {
          this._msg = ClMain.Get_Msg("015");
          int num2 = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.txtSovangmuondoi.Focus();
        }
      }
      else
      {
        this._msg = ClMain.Get_Msg("015");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.txtSovangmuondoi.Focus();
      }
    }

    private void InsertMessage()
    {
      tbMessage tbMessage = new tbMessage();
      tbMessage.NguoiGui = "Administrator";
      tbMessage.NguoiNhan = TbUser.Tbuser.TenDangnhap;
      tbMessage.TieuDe = "Mua thêm xu";
      tbMessage.NoiDung = "Bạn vừa mua thêm [<b style=''color:red''>" + this.txtSobacDoiduoc.Text + "</b>] bạc thành công !!!";
      tbMessage.Insert(tbMessage);
    }

    public void XuLyInsert()
    {
      this.InsertVangsudung();
      this.InsertXusudung();
      this.UpdateMoney();
      this.InsertMessage();
    }

    public void InsertVangsudung()
    {
      tbVangsudung tbVangsudung = new tbVangsudung()
      {
        TenDangnhap = TbUser.Tbuser.TenDangnhap,
        VangSudung = (-this._sovangmuondoi).ToString(),
        CachSudung = "Mua thêm bạc (" + (object) this._sovangmuondoi + "-" + (object) this._soBacdoiduoc + ")"
      };
      tbVangsudung.Insert(tbVangsudung);
    }

    public void InsertXusudung()
    {
      tbXusudung tbXusudung = new tbXusudung()
      {
        TenDangnhap = TbUser.Tbuser.TenDangnhap,
        XuSudung = this._soBacdoiduoc.ToString(),
        CachSudung = "Mua bằng vàng (" + (object) this._sovangmuondoi + "-" + (object) this._soBacdoiduoc + ")"
      };
      tbXusudung.Insert(tbXusudung);
    }

    public void UpdateMoney()
    {
      this.TbMoney = new tbMoneyUSER();
      this.TbMoney = this.TbMoney.GetInfor(TbUser.Tbuser.TenDangnhap);
      this.TbMoney.VangHienco = (Convert.ToDecimal(this.TbMoney.VangHienco) - Convert.ToDecimal(this._sovangmuondoi)).ToString();
      this.TbMoney.XuHienco = (Convert.ToDecimal(this.TbMoney.XuHienco) + this._soBacdoiduoc).ToString();
      if (this.TbMoney.Update(this.TbMoney) == 1)
      {
        this._msg = ClMain.Get_Msg("014");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this._msg = ClMain.Get_Msg("009");
        int num = (int) MessageBox.Show(this._msg[1], this._msg[2], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Application.Exit();
      }
    }

    private void TxtSovangmuondoiTextChanged(object sender, EventArgs e)
    {
      if (this.txtSovangmuondoi.Text.Length > 0 && this.IsNumber(this.txtSovangmuondoi.Text) && Convert.ToDecimal(this.txtSovangmuondoi.Text) > Decimal.Zero)
      {
        Decimal num = Convert.ToDecimal(this.txtSovangmuondoi.Text);
        if (this._vanghienco >= num)
        {
          this.ShowValue(Convert.ToDecimal(num));
          this._sovangmuondoi = num;
        }
        else
          this.txtSovangmuondoi.Focus();
      }
      else
        this.txtSovangmuondoi.Focus();
    }

    public bool IsNumber(string number)
    {
      try
      {
        Convert.ToInt32(number);
        return true;
      }
      catch
      {
        return false;
      }
    }

    private void TxtSovangmuondoiKeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.XuLy();
    }

    private void PicMainTopClick(object sender, EventArgs e)
    {
    }

    private void FThemXuLoad(object sender, EventArgs e)
    {
      this.InfoMoney();
      this.ShowValue(this._sovangmuondoi);
    }

    private void PicMainTopMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FThemXu));
      this.picMainTop = new PictureBox();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.panel1 = new Panel();
      this.label6 = new Label();
      this.txtSobacDoiduoc = new TextBox();
      this.label1 = new Label();
      this.txtSovangmuondoi = new TextBox();
      this.label3 = new Label();
      this.lblBachienco = new Label();
      this.lblTongsobacco = new Label();
      this.lblVanghienco = new Label();
      this.btnXacnhan = new BunifuThinButton2();
      this.lblHuybo = new LinkLabel();
      this.lblThua_Thieu = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label2 = new Label();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(592, 137);
      this.picMainTop.TabIndex = 10;
      this.picMainTop.TabStop = false;
      this.picMainTop.Click += new EventHandler(this.PicMainTopClick);
      this.picMainTop.MouseDown += new MouseEventHandler(this.PicMainTopMouseDown);
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(568, 1);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(23, 23);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 11;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.BunifuImageButton3Click);
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.txtSobacDoiduoc);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.txtSovangmuondoi);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.lblBachienco);
      this.panel1.Controls.Add((Control) this.lblTongsobacco);
      this.panel1.Controls.Add((Control) this.lblVanghienco);
      this.panel1.Controls.Add((Control) this.btnXacnhan);
      this.panel1.Controls.Add((Control) this.lblHuybo);
      this.panel1.Controls.Add((Control) this.lblThua_Thieu);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel1.Location = new Point(69, 18);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(453, 201);
      this.panel1.TabIndex = 12;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(183, 10);
      this.label6.Name = "label6";
      this.label6.Size = new Size(102, 16);
      this.label6.TabIndex = 21;
      this.label6.Text = "ĐỔI THÊM BẠC";
      this.txtSobacDoiduoc.BorderStyle = BorderStyle.FixedSingle;
      this.txtSobacDoiduoc.Enabled = false;
      this.txtSobacDoiduoc.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtSobacDoiduoc.ForeColor = Color.Red;
      this.txtSobacDoiduoc.Location = new Point(288, 100);
      this.txtSobacDoiduoc.Name = "txtSobacDoiduoc";
      this.txtSobacDoiduoc.Size = new Size(70, 22);
      this.txtSobacDoiduoc.TabIndex = 20;
      this.txtSobacDoiduoc.Text = "23";
      this.txtSobacDoiduoc.TextAlign = HorizontalAlignment.Right;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(269, 103);
      this.label1.Name = "label1";
      this.label1.Size = new Size(18, 19);
      this.label1.TabIndex = 19;
      this.label1.Text = "=";
      this.txtSovangmuondoi.BorderStyle = BorderStyle.FixedSingle;
      this.txtSovangmuondoi.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtSovangmuondoi.ForeColor = Color.Black;
      this.txtSovangmuondoi.Location = new Point(213, 100);
      this.txtSovangmuondoi.Name = "txtSovangmuondoi";
      this.txtSovangmuondoi.Size = new Size(56, 22);
      this.txtSovangmuondoi.TabIndex = 18;
      this.txtSovangmuondoi.Text = "10";
      this.txtSovangmuondoi.TextAlign = HorizontalAlignment.Right;
      this.txtSovangmuondoi.TextChanged += new EventHandler(this.TxtSovangmuondoiTextChanged);
      this.txtSovangmuondoi.KeyPress += new KeyPressEventHandler(this.TxtSovangmuondoiKeyPress);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(360, 102);
      this.label3.Margin = new Padding(0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(32, 17);
      this.label3.TabIndex = 17;
      this.label3.Text = "bạc";
      this.label3.TextAlign = ContentAlignment.MiddleLeft;
      this.lblBachienco.AutoSize = true;
      this.lblBachienco.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblBachienco.ForeColor = Color.Red;
      this.lblBachienco.Location = new Point(210, 70);
      this.lblBachienco.Margin = new Padding(0);
      this.lblBachienco.Name = "lblBachienco";
      this.lblBachienco.Size = new Size(44, 17);
      this.lblBachienco.TabIndex = 17;
      this.lblBachienco.Text = "0 bạc";
      this.lblBachienco.TextAlign = ContentAlignment.MiddleLeft;
      this.lblTongsobacco.AutoSize = true;
      this.lblTongsobacco.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTongsobacco.ForeColor = Color.Red;
      this.lblTongsobacco.Location = new Point(211, 132);
      this.lblTongsobacco.Name = "lblTongsobacco";
      this.lblTongsobacco.Size = new Size(44, 17);
      this.lblTongsobacco.TabIndex = 17;
      this.lblTongsobacco.Text = "0 bạc";
      this.lblVanghienco.AutoSize = true;
      this.lblVanghienco.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVanghienco.ForeColor = Color.Red;
      this.lblVanghienco.Location = new Point(210, 41);
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
      this.btnXacnhan.Location = new Point(135, 155);
      this.btnXacnhan.Margin = new Padding(6, 5, 6, 5);
      this.btnXacnhan.Name = "btnXacnhan";
      this.btnXacnhan.Size = new Size(264, 40);
      this.btnXacnhan.TabIndex = 6;
      this.btnXacnhan.TextAlign = ContentAlignment.MiddleCenter;
      this.btnXacnhan.Click += new EventHandler(this.BtnXacnhanClick);
      this.lblHuybo.AutoSize = true;
      this.lblHuybo.Cursor = Cursors.Hand;
      this.lblHuybo.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHuybo.LinkBehavior = LinkBehavior.HoverUnderline;
      this.lblHuybo.LinkColor = Color.DodgerBlue;
      this.lblHuybo.Location = new Point(78, 168);
      this.lblHuybo.Name = "lblHuybo";
      this.lblHuybo.Size = new Size(53, 17);
      this.lblHuybo.TabIndex = 7;
      this.lblHuybo.TabStop = true;
      this.lblHuybo.Text = "Hủy bỏ";
      this.lblHuybo.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LblHuyboLinkClicked);
      this.lblThua_Thieu.AutoSize = true;
      this.lblThua_Thieu.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThua_Thieu.ForeColor = Color.DimGray;
      this.lblThua_Thieu.Location = new Point(121, 69);
      this.lblThua_Thieu.Name = "lblThua_Thieu";
      this.lblThua_Thieu.Size = new Size(93, 17);
      this.lblThua_Thieu.TabIndex = 1;
      this.lblThua_Thieu.Text = "Bạc hiện có :";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DimGray;
      this.label4.Location = new Point(82, 101);
      this.label4.Name = "label4";
      this.label4.Size = new Size(133, 17);
      this.label4.TabIndex = 1;
      this.label4.Text = "Số vàng muốn đổi :";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DimGray;
      this.label5.Location = new Point(117, 132);
      this.label5.Name = "label5";
      this.label5.Size = new Size(97, 17);
      this.label5.TabIndex = 1;
      this.label5.Text = "Tổng số bạc :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DimGray;
      this.label2.Location = new Point(94, 41);
      this.label2.Name = "label2";
      this.label2.Size = new Size(120, 17);
      this.label2.TabIndex = 1;
      this.label2.Text = "Số vàng hiện có :";
      this.bunifuElipse1.ElipseRadius = 10;
      this.bunifuElipse1.TargetControl = (Control) this.panel1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(592, 236);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.picMainTop);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FThemXu);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Đổi thêm bạc";
      this.Load += new EventHandler(this.FThemXuLoad);
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.bunifuImageButton3.EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
