// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FConfigBacNho
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
  public class FConfigBacNho : Form
  {
    private IContainer components = (IContainer) null;
    private int _maConfig;
    private Panel panel1;
    private Label label1;
    private BunifuImageButton bunifuImageButton8;
    private Label label2;
    private BunifuCheckbox CheckboxHienthi;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private NumericUpDown numTrungDau;
    private Label label9;
    private Label label10;
    private Label label11;
    private NumericUpDown numTrungDuoi;
    private Label label12;
    private Label label13;
    private NumericUpDown numSobanghi;
    private BunifuThinButton2 bunifuThinButton21;
    private NumericUpDown numKhungLoCap;
    private NumericUpDown numKhungBachThuNuoi;
    private Label label14;
    private Label label15;
    private NumericUpDown numDacBiet;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label19;
    private Label label20;
    private Label label21;
    private TextBox txtTheogiai;
    private TextBox txtTheonhay;
    private TextBox txtTheocap;
    private TextBox txtDaucam;
    private TextBox txtDuoicam;
    private TextBox txtCapcungve;
    private Label lblTheogiai;
    private Label lblTheonhay;
    private Label lblTheocap;
    private Label lblDaucam;
    private Label lblDuoicam;
    private Label lblCapcungve;
    private Label label28;
    private BunifuSeparator bunifuSeparator1;
    private Panel panel2;
    private Label label22;
    private LinkLabel linkLabel1;
    private ToolTip toolTip1;
    private BunifuImageButton bunifuImageButton1;
    private NumericUpDown numKhungLoXien;
    private Label label23;
    private Label label24;
    private TextBox txtBacnhotheothu;
    private Label label25;
    private Label label26;
    private TextBox txtDancungve;
    private Label label27;
    private Label label29;
    private TextBox txtThongkecaudep;
    private Label label30;
    private Label label31;

    public FConfigBacNho()
    {
      this.InitializeComponent();
    }

    private void ShowValue()
    {
      tbConfigBacNho objConfigBacNho = FMain.ObjConfigBacNho;
      if (!string.IsNullOrEmpty(objConfigBacNho.MaTaiKhoan))
      {
        this.CheckboxHienthi.Checked = objConfigBacNho.HienThiNgayVe == 1;
        this.numKhungLoCap.Value = (Decimal) objConfigBacNho.KhungDanhLoCapNuoi;
        this.numKhungBachThuNuoi.Value = (Decimal) objConfigBacNho.KhungDanhBachThuNuoi;
        this.numDacBiet.Value = (Decimal) objConfigBacNho.KhungDanhDacBietNuoi;
        this.numKhungLoXien.Value = (Decimal) objConfigBacNho.KhungLoXien2;
        this.numTrungDau.Value = (Decimal) objConfigBacNho.BiendoTrungDau;
        this.numTrungDuoi.Value = (Decimal) objConfigBacNho.BiendoTrungDuoi;
        this.numSobanghi.Value = (Decimal) objConfigBacNho.SoBanGhi;
        this.txtTheogiai.Text = objConfigBacNho.TheoGiai.ToString();
        this.txtTheocap.Text = objConfigBacNho.TheoCap.ToString();
        this.txtTheonhay.Text = objConfigBacNho.TheoNhay.ToString();
        this.txtDaucam.Text = objConfigBacNho.DauCam.ToString();
        this.txtDuoicam.Text = objConfigBacNho.DuoiCam.ToString();
        this.txtCapcungve.Text = objConfigBacNho.CapCungVe.ToString();
        this.txtDancungve.Text = objConfigBacNho.DanCungVe.ToString();
        this.txtBacnhotheothu.Text = objConfigBacNho.BacNhoTheoThu.ToString();
        this.txtThongkecaudep.Text = objConfigBacNho.ThongKeCauDep.ToString();
        this._maConfig = objConfigBacNho.Stt;
      }
      else
      {
        objConfigBacNho.HienThiNgayVe = 3;
        objConfigBacNho.KhungDanhLoCapNuoi = 3;
        objConfigBacNho.KhungDanhBachThuNuoi = 5;
        objConfigBacNho.KhungLoXien2 = 10;
        objConfigBacNho.BiendoTrungDau = 2;
        objConfigBacNho.BiendoTrungDuoi = 2;
        objConfigBacNho.SoBanGhi = 4;
        this.CheckboxHienthi.Checked = true;
        this.numKhungLoCap.Value = new Decimal(3);
        this.numKhungBachThuNuoi.Value = new Decimal(4);
        this.numTrungDau.Value = new Decimal(2);
        this.numTrungDuoi.Value = new Decimal(2);
        this.numSobanghi.Value = new Decimal(4);
        this.txtTheogiai.Text = "24";
        this.txtTheocap.Text = "24";
        this.txtTheonhay.Text = "12";
        this.txtDaucam.Text = "6";
        this.txtDuoicam.Text = "6";
        this.txtCapcungve.Text = "12";
        this.txtDancungve.Text = "12";
        this.txtBacnhotheothu.Text = "21";
        this.txtThongkecaudep.Text = "28";
      }
    }

    private void BunifuImageButton8Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Panel1MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void BunifuThinButton21Click(object sender, EventArgs e)
    {
      tbConfigBacNho tbConfigBacNho1 = new tbConfigBacNho()
      {
        Stt = this._maConfig,
        HienThiNgayVe = 0
      };
      if (this.CheckboxHienthi.Checked)
        tbConfigBacNho1.HienThiNgayVe = 1;
      tbConfigBacNho1.MaTaiKhoan = TbUser.Tbuser.Stt.ToString();
      tbConfigBacNho1.KhungDanhLoCapNuoi = int.Parse(this.numKhungLoCap.Value.ToString());
      tbConfigBacNho tbConfigBacNho2 = tbConfigBacNho1;
      Decimal num1 = this.numKhungBachThuNuoi.Value;
      int num2 = int.Parse(num1.ToString());
      tbConfigBacNho2.KhungDanhBachThuNuoi = num2;
      tbConfigBacNho tbConfigBacNho3 = tbConfigBacNho1;
      num1 = this.numDacBiet.Value;
      int num3 = int.Parse(num1.ToString());
      tbConfigBacNho3.KhungDanhDacBietNuoi = num3;
      tbConfigBacNho tbConfigBacNho4 = tbConfigBacNho1;
      num1 = this.numKhungLoXien.Value;
      int num4 = int.Parse(num1.ToString());
      tbConfigBacNho4.KhungLoXien2 = num4;
      tbConfigBacNho tbConfigBacNho5 = tbConfigBacNho1;
      num1 = this.numTrungDau.Value;
      int num5 = int.Parse(num1.ToString());
      tbConfigBacNho5.BiendoTrungDau = num5;
      tbConfigBacNho tbConfigBacNho6 = tbConfigBacNho1;
      num1 = this.numTrungDuoi.Value;
      int num6 = int.Parse(num1.ToString());
      tbConfigBacNho6.BiendoTrungDuoi = num6;
      tbConfigBacNho tbConfigBacNho7 = tbConfigBacNho1;
      num1 = this.numSobanghi.Value;
      int num7 = int.Parse(num1.ToString());
      tbConfigBacNho7.SoBanGhi = num7;
      tbConfigBacNho1.TheoGiai = 24;
      tbConfigBacNho1.TheoNhay = 24;
      tbConfigBacNho1.TheoCap = 12;
      tbConfigBacNho1.DauCam = 6;
      tbConfigBacNho1.DuoiCam = 6;
      tbConfigBacNho1.CapCungVe = 8;
      tbConfigBacNho1.DanCungVe = 12;
      tbConfigBacNho1.BacNhoTheoThu = 21;
      tbConfigBacNho1.ThongKeCauDep = 28;
      if (ClMain.IsNumber(this.txtTheogiai.Text) && int.Parse(this.txtTheogiai.Text) >= 5 && int.Parse(this.txtTheogiai.Text) < 49)
      {
        tbConfigBacNho1.TheoGiai = int.Parse(this.txtTheogiai.Text);
        if (ClMain.IsNumber(this.txtTheonhay.Text) && int.Parse(this.txtTheonhay.Text) >= 3 && int.Parse(this.txtTheonhay.Text) < 49)
        {
          tbConfigBacNho1.TheoNhay = int.Parse(this.txtTheonhay.Text);
          if (ClMain.IsNumber(this.txtTheocap.Text) && int.Parse(this.txtTheocap.Text) >= 2 && int.Parse(this.txtTheocap.Text) < 49)
          {
            tbConfigBacNho1.TheoCap = int.Parse(this.txtTheocap.Text);
            if (ClMain.IsNumber(this.txtDaucam.Text) && int.Parse(this.txtDaucam.Text) >= 2 && int.Parse(this.txtDaucam.Text) < 49)
            {
              tbConfigBacNho1.DauCam = int.Parse(this.txtDaucam.Text);
              if (ClMain.IsNumber(this.txtDuoicam.Text) && int.Parse(this.txtDuoicam.Text) >= 2 && int.Parse(this.txtDuoicam.Text) < 49)
              {
                tbConfigBacNho1.DuoiCam = int.Parse(this.txtDuoicam.Text);
                if (ClMain.IsNumber(this.txtCapcungve.Text) && int.Parse(this.txtCapcungve.Text) >= 2 && int.Parse(this.txtCapcungve.Text) < 49)
                {
                  tbConfigBacNho1.CapCungVe = int.Parse(this.txtCapcungve.Text);
                  if (ClMain.IsNumber(this.txtDancungve.Text) && int.Parse(this.txtDancungve.Text) >= 3 && int.Parse(this.txtDancungve.Text) < 49)
                  {
                    tbConfigBacNho1.DanCungVe = int.Parse(this.txtDancungve.Text);
                    if (ClMain.IsNumber(this.txtBacnhotheothu.Text) && int.Parse(this.txtBacnhotheothu.Text) >= 14 && int.Parse(this.txtBacnhotheothu.Text) <= 180)
                    {
                      tbConfigBacNho1.BacNhoTheoThu = int.Parse(this.txtBacnhotheothu.Text);
                      if (ClMain.IsNumber(this.txtThongkecaudep.Text) && int.Parse(this.txtThongkecaudep.Text) >= 7 && int.Parse(this.txtThongkecaudep.Text) <= 180)
                      {
                        tbConfigBacNho1.ThongKeCauDep = int.Parse(this.txtThongkecaudep.Text);
                        if (tbConfigBacNho1.Update(tbConfigBacNho1) == 1)
                        {
                          if (TabBacnhoCoban.Timer != null)
                            TabBacnhoCoban.Timer.Start();
                          if (TabBacNhoTrungDauTrungDuoi.timer != null)
                            TabBacNhoTrungDauTrungDuoi.timer.Start();
                          if (TabBacNhoDanCungVe.Timer != null)
                            TabBacNhoDanCungVe.Timer.Start();
                          FMain.ObjConfigBacNho = tbConfigBacNho1;
                          int num8 = (int) MessageBox.Show(Resources.FLotoOffline_btnDangki_Click_CẬP_NHẬT_THÔNG_TIN_THÀNH_CÔNG, Resources.tabInfoUser_show_InfoUser_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                          this.Close();
                        }
                        else
                        {
                          int num9 = (int) MessageBox.Show(Resources.FLotoOffline_btnDangki_Click_CẬP_NHẬT_THÔNG_TIN_KHÔNG_THÀNH_CÔNG, Resources.tabInfoUser_show_InfoUser_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                      }
                      else
                        this.txtThongkecaudep.Focus();
                    }
                    else
                      this.txtBacnhotheothu.Focus();
                  }
                  else
                    this.txtDancungve.Focus();
                }
                else
                  this.txtCapcungve.Focus();
              }
              else
                this.txtDuoicam.Focus();
            }
            else
              this.txtDaucam.Focus();
          }
          else
            this.txtTheocap.Focus();
        }
        else
          this.txtTheonhay.Focus();
      }
      else
        this.txtTheogiai.Focus();
    }

    private void FConfigBacNhoLoad(object sender, EventArgs e)
    {
      this.ShowValue();
    }

    private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.CheckboxHienthi.Checked = true;
      this.numKhungLoCap.Value = new Decimal(3);
      this.numKhungBachThuNuoi.Value = new Decimal(6);
      this.numDacBiet.Value = new Decimal(3);
      this.numKhungLoXien.Value = new Decimal(10);
      this.numTrungDau.Value = new Decimal(2);
      this.numTrungDuoi.Value = new Decimal(2);
      this.numSobanghi.Value = new Decimal(4);
      this.txtTheogiai.Text = "36";
      this.txtTheocap.Text = "12";
      this.txtTheonhay.Text = "12";
      this.txtDaucam.Text = "8";
      this.txtDuoicam.Text = "8";
      this.txtCapcungve.Text = "12";
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FConfigBacNho));
      this.panel1 = new Panel();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.label1 = new Label();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.label2 = new Label();
      this.CheckboxHienthi = new BunifuCheckbox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.numTrungDau = new NumericUpDown();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.numTrungDuoi = new NumericUpDown();
      this.label12 = new Label();
      this.label13 = new Label();
      this.numSobanghi = new NumericUpDown();
      this.bunifuThinButton21 = new BunifuThinButton2();
      this.numKhungLoCap = new NumericUpDown();
      this.numKhungBachThuNuoi = new NumericUpDown();
      this.label14 = new Label();
      this.label15 = new Label();
      this.numDacBiet = new NumericUpDown();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label18 = new Label();
      this.label19 = new Label();
      this.label20 = new Label();
      this.label21 = new Label();
      this.txtTheogiai = new TextBox();
      this.txtTheonhay = new TextBox();
      this.txtTheocap = new TextBox();
      this.txtDaucam = new TextBox();
      this.txtDuoicam = new TextBox();
      this.txtCapcungve = new TextBox();
      this.lblTheogiai = new Label();
      this.lblTheonhay = new Label();
      this.lblTheocap = new Label();
      this.lblDaucam = new Label();
      this.lblDuoicam = new Label();
      this.lblCapcungve = new Label();
      this.label28 = new Label();
      this.bunifuSeparator1 = new BunifuSeparator();
      this.panel2 = new Panel();
      this.label22 = new Label();
      this.linkLabel1 = new LinkLabel();
      this.toolTip1 = new ToolTip(this.components);
      this.numKhungLoXien = new NumericUpDown();
      this.label23 = new Label();
      this.label24 = new Label();
      this.txtBacnhotheothu = new TextBox();
      this.label25 = new Label();
      this.label26 = new Label();
      this.txtDancungve = new TextBox();
      this.label27 = new Label();
      this.label29 = new Label();
      this.txtThongkecaudep = new TextBox();
      this.label30 = new Label();
      this.label31 = new Label();
      this.panel1.SuspendLayout();
      this.bunifuImageButton1.BeginInit();
      this.bunifuImageButton8.BeginInit();
      this.numTrungDau.BeginInit();
      this.numTrungDuoi.BeginInit();
      this.numSobanghi.BeginInit();
      this.numKhungLoCap.BeginInit();
      this.numKhungBachThuNuoi.BeginInit();
      this.numDacBiet.BeginInit();
      this.numKhungLoXien.BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(27, 40, 61);
      this.panel1.Controls.Add((Control) this.bunifuImageButton1);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.bunifuImageButton8);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(923, 25);
      this.panel1.TabIndex = 1;
      this.panel1.MouseDown += new MouseEventHandler(this.Panel1MouseDown);
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Cursor = Cursors.Hand;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(3, 3);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(20, 20);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.bunifuImageButton1.TabIndex = 29;
      this.bunifuImageButton1.TabStop = false;
      this.bunifuImageButton1.Zoom = 10;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(24, 5);
      this.label1.Name = "label1";
      this.label1.Size = new Size(113, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Cấu hình hệ thống";
      this.bunifuImageButton8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.bunifuImageButton8.BackColor = Color.Transparent;
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(898, 2);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(21, 21);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 28;
      this.bunifuImageButton8.TabStop = false;
      this.bunifuImageButton8.Zoom = 5;
      this.bunifuImageButton8.Click += new EventHandler(this.BunifuImageButton8Click);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(39, 44);
      this.label2.Name = "label2";
      this.label2.Size = new Size(108, 16);
      this.label2.TabIndex = 8;
      this.label2.Text = "Hiển thị ngày về :";
      this.CheckboxHienthi.BackColor = Color.FromArgb(51, 205, 117);
      this.CheckboxHienthi.ChechedOffColor = Color.FromArgb(132, 135, 140);
      this.CheckboxHienthi.Checked = true;
      this.CheckboxHienthi.CheckedOnColor = Color.FromArgb(51, 205, 117);
      this.CheckboxHienthi.Cursor = Cursors.Hand;
      this.CheckboxHienthi.ForeColor = Color.White;
      this.CheckboxHienthi.Location = new Point(146, 42);
      this.CheckboxHienthi.Name = "CheckboxHienthi";
      this.CheckboxHienthi.Size = new Size(20, 20);
      this.CheckboxHienthi.TabIndex = 0;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(167, 44);
      this.label3.Name = "label3";
      this.label3.Size = new Size(50, 16);
      this.label3.TabIndex = 8;
      this.label3.Text = "Bật/Tắt";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(27, 79);
      this.label4.Name = "label4";
      this.label4.Size = new Size(120, 16);
      this.label4.TabIndex = 8;
      this.label4.Text = "Khung lô cặp nuôi :";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.Black;
      this.label5.Location = new Point(228, 79);
      this.label5.Name = "label5";
      this.label5.Size = new Size(76, 16);
      this.label5.TabIndex = 8;
      this.label5.Text = "Max 5 ngày";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(12, 117);
      this.label6.Name = "label6";
      this.label6.Size = new Size(135, 16);
      this.label6.TabIndex = 8;
      this.label6.Text = "Khung bạch thủ nuôi :";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(228, 117);
      this.label7.Name = "label7";
      this.label7.Size = new Size(83, 16);
      this.label7.TabIndex = 8;
      this.label7.Text = "Max 10 ngày";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.Black;
      this.label8.Location = new Point(19, 231);
      this.label8.Name = "label8";
      this.label8.Size = new Size(128, 16);
      this.label8.TabIndex = 8;
      this.label8.Text = "Biên độ lô trùng đầu:";
      this.numTrungDau.BorderStyle = BorderStyle.FixedSingle;
      this.numTrungDau.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numTrungDau.ForeColor = Color.Red;
      this.numTrungDau.Location = new Point(145, 228);
      this.numTrungDau.Maximum = new Decimal(new int[4]
      {
        4,
        0,
        0,
        0
      });
      this.numTrungDau.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numTrungDau.Name = "numTrungDau";
      this.numTrungDau.Size = new Size(81, 22);
      this.numTrungDau.TabIndex = 5;
      this.toolTip1.SetToolTip((Control) this.numTrungDau, "Là khoảng cách tịnh tiến giữa 2 con lô tô trùng đầu (65-67)");
      this.numTrungDau.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9.75f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.Black;
      this.label9.Location = new Point(228, 231);
      this.label9.Name = "label9";
      this.label9.Size = new Size(186, 16);
      this.label9.TabIndex = 8;
      this.label9.Text = "vd : +2 -> 61-63,75-77  (Max 4)";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.Black;
      this.label10.Location = new Point(16, 269);
      this.label10.Name = "label10";
      this.label10.Size = new Size(131, 16);
      this.label10.TabIndex = 8;
      this.label10.Text = "Biên độ lô trùng đuôi:";
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Arial", 9.75f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.Black;
      this.label11.Location = new Point(228, 269);
      this.label11.Name = "label11";
      this.label11.Size = new Size(190, 16);
      this.label11.TabIndex = 8;
      this.label11.Text = "vd : +2 ->16-36,57-77  (Max =4)";
      this.numTrungDuoi.BorderStyle = BorderStyle.FixedSingle;
      this.numTrungDuoi.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numTrungDuoi.ForeColor = Color.Red;
      this.numTrungDuoi.Location = new Point(145, 266);
      this.numTrungDuoi.Maximum = new Decimal(new int[4]
      {
        4,
        0,
        0,
        0
      });
      this.numTrungDuoi.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numTrungDuoi.Name = "numTrungDuoi";
      this.numTrungDuoi.Size = new Size(81, 22);
      this.numTrungDuoi.TabIndex = 6;
      this.toolTip1.SetToolTip((Control) this.numTrungDuoi, "Là khoảng cách tịnh tiến giữa 2 con lô tô trùng đuôi (56-76)");
      this.numTrungDuoi.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.Black;
      this.label12.Location = new Point(24, 307);
      this.label12.Name = "label12";
      this.label12.Size = new Size(124, 16);
      this.label12.TabIndex = 8;
      this.label12.Text = "Số bản ghi hiển thị :";
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.Black;
      this.label13.Location = new Point(229, 307);
      this.label13.Name = "label13";
      this.label13.Size = new Size(98, 16);
      this.label13.TabIndex = 8;
      this.label13.Text = "bản ghi (Max 8)";
      this.numSobanghi.BorderStyle = BorderStyle.FixedSingle;
      this.numSobanghi.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numSobanghi.ForeColor = Color.Red;
      this.numSobanghi.Location = new Point(146, 304);
      this.numSobanghi.Maximum = new Decimal(new int[4]
      {
        8,
        0,
        0,
        0
      });
      this.numSobanghi.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numSobanghi.Name = "numSobanghi";
      this.numSobanghi.Size = new Size(81, 22);
      this.numSobanghi.TabIndex = 7;
      this.toolTip1.SetToolTip((Control) this.numSobanghi, "Là số bản hiển thị của kết quả bạc nhớ");
      this.numSobanghi.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.bunifuThinButton21.ActiveBorderThickness = 1;
      this.bunifuThinButton21.ActiveCornerRadius = 20;
      this.bunifuThinButton21.ActiveFillColor = Color.DodgerBlue;
      this.bunifuThinButton21.ActiveForecolor = Color.White;
      this.bunifuThinButton21.ActiveLineColor = Color.DodgerBlue;
      this.bunifuThinButton21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.bunifuThinButton21.BackColor = Color.FromArgb(233, 235, 238);
      this.bunifuThinButton21.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
      this.bunifuThinButton21.ButtonText = "Cập nhật";
      this.bunifuThinButton21.Cursor = Cursors.Hand;
      this.bunifuThinButton21.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton21.ForeColor = Color.Black;
      this.bunifuThinButton21.IdleBorderThickness = 1;
      this.bunifuThinButton21.IdleCornerRadius = 20;
      this.bunifuThinButton21.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.IdleForecolor = Color.White;
      this.bunifuThinButton21.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.bunifuThinButton21.Location = new Point(799, 334);
      this.bunifuThinButton21.Margin = new Padding(0);
      this.bunifuThinButton21.Name = "bunifuThinButton21";
      this.bunifuThinButton21.Size = new Size(109, 33);
      this.bunifuThinButton21.TabIndex = 14;
      this.bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.bunifuThinButton21, "Lưu cấu hình");
      this.bunifuThinButton21.Click += new EventHandler(this.BunifuThinButton21Click);
      this.numKhungLoCap.BorderStyle = BorderStyle.FixedSingle;
      this.numKhungLoCap.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numKhungLoCap.ForeColor = Color.Red;
      this.numKhungLoCap.Location = new Point(145, 76);
      this.numKhungLoCap.Maximum = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numKhungLoCap.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numKhungLoCap.Name = "numKhungLoCap";
      this.numKhungLoCap.Size = new Size(81, 22);
      this.numKhungLoCap.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.numKhungLoCap, "Khung ngày đánh của lô cặp mà bạn muốn");
      this.numKhungLoCap.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numKhungBachThuNuoi.BorderStyle = BorderStyle.FixedSingle;
      this.numKhungBachThuNuoi.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numKhungBachThuNuoi.ForeColor = Color.Red;
      this.numKhungBachThuNuoi.Location = new Point(145, 114);
      this.numKhungBachThuNuoi.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numKhungBachThuNuoi.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numKhungBachThuNuoi.Name = "numKhungBachThuNuoi";
      this.numKhungBachThuNuoi.Size = new Size(81, 22);
      this.numKhungBachThuNuoi.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.numKhungBachThuNuoi, "Khung ngày đánh của bạch thủ nuôi mà bạn muốn");
      this.numKhungBachThuNuoi.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.Black;
      this.label14.Location = new Point(16, 155);
      this.label14.Name = "label14";
      this.label14.Size = new Size(131, 16);
      this.label14.TabIndex = 8;
      this.label14.Text = "Khung đặc biêt nuôi :";
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.Black;
      this.label15.Location = new Point(228, 155);
      this.label15.Name = "label15";
      this.label15.Size = new Size(83, 16);
      this.label15.TabIndex = 8;
      this.label15.Text = "Max 10 ngày";
      this.numDacBiet.BorderStyle = BorderStyle.FixedSingle;
      this.numDacBiet.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numDacBiet.ForeColor = Color.Red;
      this.numDacBiet.Location = new Point(145, 152);
      this.numDacBiet.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numDacBiet.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numDacBiet.Name = "numDacBiet";
      this.numDacBiet.Size = new Size(81, 22);
      this.numDacBiet.TabIndex = 3;
      this.toolTip1.SetToolTip((Control) this.numDacBiet, "Khung đặc biệt nuôi mà bạn muốn");
      this.numDacBiet.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.ForeColor = Color.Black;
      this.label16.Location = new Point(513, 63);
      this.label16.Name = "label16";
      this.label16.Size = new Size(119, 16);
      this.label16.TabIndex = 8;
      this.label16.Text = "Bạc nhớ theo giải :";
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.ForeColor = Color.Black;
      this.label17.Location = new Point(505, 94);
      this.label17.Name = "label17";
      this.label17.Size = new Size((int) sbyte.MaxValue, 16);
      this.label17.TabIndex = 8;
      this.label17.Text = "Bạc nhớ theo nháy :";
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.ForeColor = Color.Black;
      this.label18.Location = new Point(512, 125);
      this.label18.Name = "label18";
      this.label18.Size = new Size(120, 16);
      this.label18.TabIndex = 8;
      this.label18.Text = "Bạc nhớ theo cặp :";
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.ForeColor = Color.Black;
      this.label19.Location = new Point(513, 190);
      this.label19.Name = "label19";
      this.label19.Size = new Size(119, 16);
      this.label19.TabIndex = 8;
      this.label19.Text = "Bạc nhớ đuôi câm:";
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.ForeColor = Color.Black;
      this.label20.Location = new Point(512, 157);
      this.label20.Name = "label20";
      this.label20.Size = new Size(120, 16);
      this.label20.TabIndex = 8;
      this.label20.Text = "Bạc nhớ đầu câm :";
      this.label21.AutoSize = true;
      this.label21.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.ForeColor = Color.Black;
      this.label21.Location = new Point(499, 223);
      this.label21.Name = "label21";
      this.label21.Size = new Size(133, 16);
      this.label21.TabIndex = 8;
      this.label21.Text = "Bạc nhớ cặp liền kề :";
      this.txtTheogiai.BorderStyle = BorderStyle.FixedSingle;
      this.txtTheogiai.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTheogiai.ForeColor = Color.Red;
      this.txtTheogiai.Location = new Point(630, 60);
      this.txtTheogiai.Name = "txtTheogiai";
      this.txtTheogiai.Size = new Size(129, 22);
      this.txtTheogiai.TabIndex = 8;
      this.toolTip1.SetToolTip((Control) this.txtTheogiai, "Là thời gian kiểm tra bạc nhớ theo giải tính đến ngày kiểm tra (vd : 24 tháng)");
      this.txtTheonhay.BorderStyle = BorderStyle.FixedSingle;
      this.txtTheonhay.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTheonhay.ForeColor = Color.Red;
      this.txtTheonhay.Location = new Point(630, 91);
      this.txtTheonhay.Name = "txtTheonhay";
      this.txtTheonhay.Size = new Size(129, 22);
      this.txtTheonhay.TabIndex = 9;
      this.toolTip1.SetToolTip((Control) this.txtTheonhay, "Là thời gian kiểm tra bạc nhớ theo nháy tính đến ngày kiểm tra (vd : 12 tháng)");
      this.txtTheocap.BorderStyle = BorderStyle.FixedSingle;
      this.txtTheocap.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtTheocap.ForeColor = Color.Red;
      this.txtTheocap.Location = new Point(630, 122);
      this.txtTheocap.Name = "txtTheocap";
      this.txtTheocap.Size = new Size(129, 22);
      this.txtTheocap.TabIndex = 10;
      this.toolTip1.SetToolTip((Control) this.txtTheocap, "Là thời gian kiểm tra bạc nhớ theo vặp tính đến ngày kiểm tra (vd : 8 tháng)");
      this.txtDaucam.BorderStyle = BorderStyle.FixedSingle;
      this.txtDaucam.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDaucam.ForeColor = Color.Red;
      this.txtDaucam.Location = new Point(630, 154);
      this.txtDaucam.Name = "txtDaucam";
      this.txtDaucam.Size = new Size(129, 22);
      this.txtDaucam.TabIndex = 11;
      this.toolTip1.SetToolTip((Control) this.txtDaucam, "Là thời gian kiểm tra bạc nhớ theo đầu câm tính đến ngày kiểm tra (vd : 8 tháng)");
      this.txtDuoicam.BorderStyle = BorderStyle.FixedSingle;
      this.txtDuoicam.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDuoicam.ForeColor = Color.Red;
      this.txtDuoicam.Location = new Point(630, 187);
      this.txtDuoicam.Name = "txtDuoicam";
      this.txtDuoicam.Size = new Size(129, 22);
      this.txtDuoicam.TabIndex = 12;
      this.toolTip1.SetToolTip((Control) this.txtDuoicam, "Là thời gian kiểm tra bạc nhớ theo đít câm tính đến ngày kiểm tra (vd : 8 tháng)");
      this.txtCapcungve.BorderStyle = BorderStyle.FixedSingle;
      this.txtCapcungve.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtCapcungve.ForeColor = Color.Red;
      this.txtCapcungve.Location = new Point(630, 220);
      this.txtCapcungve.Name = "txtCapcungve";
      this.txtCapcungve.Size = new Size(129, 22);
      this.txtCapcungve.TabIndex = 13;
      this.toolTip1.SetToolTip((Control) this.txtCapcungve, "Là thời gian kiểm tra bạc nhớ theo cặp cùng về tính đến ngày kiểm tra (vd : 8 tháng)");
      this.lblTheogiai.AutoSize = true;
      this.lblTheogiai.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTheogiai.ForeColor = Color.Black;
      this.lblTheogiai.Location = new Point(760, 63);
      this.lblTheogiai.Name = "lblTheogiai";
      this.lblTheogiai.Size = new Size(139, 16);
      this.lblTheogiai.TabIndex = 8;
      this.lblTheogiai.Text = "tháng (Min=5,Max=48)";
      this.lblTheonhay.AutoSize = true;
      this.lblTheonhay.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTheonhay.ForeColor = Color.Black;
      this.lblTheonhay.Location = new Point(760, 94);
      this.lblTheonhay.Name = "lblTheonhay";
      this.lblTheonhay.Size = new Size(139, 16);
      this.lblTheonhay.TabIndex = 8;
      this.lblTheonhay.Text = "tháng (Min=3,Max=48)";
      this.lblTheocap.AutoSize = true;
      this.lblTheocap.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTheocap.ForeColor = Color.Black;
      this.lblTheocap.Location = new Point(760, 125);
      this.lblTheocap.Name = "lblTheocap";
      this.lblTheocap.Size = new Size(139, 16);
      this.lblTheocap.TabIndex = 8;
      this.lblTheocap.Text = "tháng (Min=2,Max=48)";
      this.lblDaucam.AutoSize = true;
      this.lblDaucam.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblDaucam.ForeColor = Color.Black;
      this.lblDaucam.Location = new Point(760, 157);
      this.lblDaucam.Name = "lblDaucam";
      this.lblDaucam.Size = new Size(139, 16);
      this.lblDaucam.TabIndex = 8;
      this.lblDaucam.Text = "tháng (Min=2,Max=48)";
      this.lblDuoicam.AutoSize = true;
      this.lblDuoicam.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblDuoicam.ForeColor = Color.Black;
      this.lblDuoicam.Location = new Point(760, 190);
      this.lblDuoicam.Name = "lblDuoicam";
      this.lblDuoicam.Size = new Size(139, 16);
      this.lblDuoicam.TabIndex = 8;
      this.lblDuoicam.Text = "tháng (Min=2,Max=48)";
      this.lblCapcungve.AutoSize = true;
      this.lblCapcungve.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblCapcungve.ForeColor = Color.Black;
      this.lblCapcungve.Location = new Point(760, 223);
      this.lblCapcungve.Name = "lblCapcungve";
      this.lblCapcungve.Size = new Size(139, 16);
      this.lblCapcungve.TabIndex = 8;
      this.lblCapcungve.Text = "tháng (Min=2,Max=48)";
      this.label28.AutoSize = true;
      this.label28.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label28.ForeColor = Color.Black;
      this.label28.Location = new Point(542, 33);
      this.label28.Name = "label28";
      this.label28.Size = new Size(294, 16);
      this.label28.TabIndex = 8;
      this.label28.Text = "Cài đặt thời gian kiểm tra của các chức năng";
      this.bunifuSeparator1.BackColor = Color.Transparent;
      this.bunifuSeparator1.LineColor = Color.FromArgb(105, 105, 105);
      this.bunifuSeparator1.LineThickness = 1;
      this.bunifuSeparator1.Location = new Point(454, 35);
      this.bunifuSeparator1.Name = "bunifuSeparator1";
      this.bunifuSeparator1.Size = new Size(9, 296);
      this.bunifuSeparator1.TabIndex = 10;
      this.bunifuSeparator1.Transparency = (int) byte.MaxValue;
      this.bunifuSeparator1.Vertical = true;
      this.panel2.BackColor = Color.FromArgb(27, 40, 61);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 367);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(923, 1);
      this.panel2.TabIndex = 11;
      this.label22.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label22.AutoSize = true;
      this.label22.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.label22.ForeColor = Color.Red;
      this.label22.Location = new Point(1, 343);
      this.label22.Name = "label22";
      this.label22.Size = new Size(753, 16);
      this.label22.TabIndex = 8;
      this.label22.Text = ">> Với những cấu hình khác nhau thì kết quả sẽ khác nhau. Anh em hãy chọn cho mình một cấu hình phù hợp nhé<<";
      this.linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(758, 344);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(40, 15);
      this.linkLabel1.TabIndex = 15;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Reset";
      this.toolTip1.SetToolTip((Control) this.linkLabel1, "Khôi phục về mặc định");
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
      this.numKhungLoXien.BorderStyle = BorderStyle.FixedSingle;
      this.numKhungLoXien.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numKhungLoXien.ForeColor = Color.Red;
      this.numKhungLoXien.Location = new Point(145, 190);
      this.numKhungLoXien.Maximum = new Decimal(new int[4]
      {
        30,
        0,
        0,
        0
      });
      this.numKhungLoXien.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numKhungLoXien.Name = "numKhungLoXien";
      this.numKhungLoXien.Size = new Size(81, 22);
      this.numKhungLoXien.TabIndex = 4;
      this.toolTip1.SetToolTip((Control) this.numKhungLoXien, "Khung kiểm tra lô xiên 2 của bạn");
      this.numKhungLoXien.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label23.AutoSize = true;
      this.label23.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label23.ForeColor = Color.Black;
      this.label23.Location = new Point(228, 193);
      this.label23.Name = "label23";
      this.label23.Size = new Size(83, 16);
      this.label23.TabIndex = 16;
      this.label23.Text = "Max 30 ngày";
      this.label24.AutoSize = true;
      this.label24.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label24.ForeColor = Color.Black;
      this.label24.Location = new Point(41, 193);
      this.label24.Name = "label24";
      this.label24.Size = new Size(106, 16);
      this.label24.TabIndex = 17;
      this.label24.Text = "Khung lô xiên 2 :";
      this.txtBacnhotheothu.BorderStyle = BorderStyle.FixedSingle;
      this.txtBacnhotheothu.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtBacnhotheothu.ForeColor = Color.Red;
      this.txtBacnhotheothu.Location = new Point(630, 281);
      this.txtBacnhotheothu.Name = "txtBacnhotheothu";
      this.txtBacnhotheothu.Size = new Size(129, 22);
      this.txtBacnhotheothu.TabIndex = 20;
      this.txtBacnhotheothu.Text = "21";
      this.toolTip1.SetToolTip((Control) this.txtBacnhotheothu, "Khoảng thời gian kiểm tra bạc nhớ theo thứ mà bạn muốn (vd : 21 ngày)");
      this.label25.AutoSize = true;
      this.label25.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label25.ForeColor = Color.Black;
      this.label25.Location = new Point(513, 284);
      this.label25.Name = "label25";
      this.label25.Size = new Size(119, 16);
      this.label25.TabIndex = 18;
      this.label25.Text = "Bạc nhớ theo thứ :";
      this.label26.AutoSize = true;
      this.label26.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label26.ForeColor = Color.Black;
      this.label26.Location = new Point(760, 284);
      this.label26.Name = "label26";
      this.label26.Size = new Size(149, 16);
      this.label26.TabIndex = 19;
      this.label26.Text = "ngày (Min=14,Max=180)";
      this.txtDancungve.BorderStyle = BorderStyle.FixedSingle;
      this.txtDancungve.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDancungve.ForeColor = Color.Red;
      this.txtDancungve.Location = new Point(630, 252);
      this.txtDancungve.Name = "txtDancungve";
      this.txtDancungve.Size = new Size(129, 22);
      this.txtDancungve.TabIndex = 23;
      this.txtDancungve.Text = "12";
      this.toolTip1.SetToolTip((Control) this.txtDancungve, "Khoảng thời gian kiểm tra dàn cùng về mà bạn muốn (vd : 8 tháng)");
      this.label27.AutoSize = true;
      this.label27.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label27.ForeColor = Color.Black;
      this.label27.Location = new Point(493, (int) byte.MaxValue);
      this.label27.Name = "label27";
      this.label27.Size = new Size(139, 16);
      this.label27.TabIndex = 21;
      this.label27.Text = "Bạc nhớ dàn cùng về :";
      this.label29.AutoSize = true;
      this.label29.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label29.ForeColor = Color.Black;
      this.label29.Location = new Point(760, (int) byte.MaxValue);
      this.label29.Name = "label29";
      this.label29.Size = new Size(139, 16);
      this.label29.TabIndex = 22;
      this.label29.Text = "tháng (Min=3,Max=48)";
      this.txtThongkecaudep.BorderStyle = BorderStyle.FixedSingle;
      this.txtThongkecaudep.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtThongkecaudep.ForeColor = Color.Red;
      this.txtThongkecaudep.Location = new Point(630, 309);
      this.txtThongkecaudep.Name = "txtThongkecaudep";
      this.txtThongkecaudep.Size = new Size(129, 22);
      this.txtThongkecaudep.TabIndex = 26;
      this.txtThongkecaudep.Text = "28";
      this.toolTip1.SetToolTip((Control) this.txtThongkecaudep, "Khoảng thời gian thống kê cầu đẹp mà bạn muốn (vd : 21 ngày)");
      this.label30.AutoSize = true;
      this.label30.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label30.ForeColor = Color.Black;
      this.label30.Location = new Point(513, 312);
      this.label30.Name = "label30";
      this.label30.Size = new Size(119, 16);
      this.label30.TabIndex = 24;
      this.label30.Text = "Thống kê cầu đẹp :";
      this.label31.AutoSize = true;
      this.label31.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label31.ForeColor = Color.Black;
      this.label31.Location = new Point(760, 312);
      this.label31.Name = "label31";
      this.label31.Size = new Size(142, 16);
      this.label31.TabIndex = 25;
      this.label31.Text = "ngày (Min=7,Max=180)";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(923, 368);
      this.Controls.Add((Control) this.txtThongkecaudep);
      this.Controls.Add((Control) this.label30);
      this.Controls.Add((Control) this.label31);
      this.Controls.Add((Control) this.txtDancungve);
      this.Controls.Add((Control) this.label27);
      this.Controls.Add((Control) this.label29);
      this.Controls.Add((Control) this.txtBacnhotheothu);
      this.Controls.Add((Control) this.label25);
      this.Controls.Add((Control) this.label26);
      this.Controls.Add((Control) this.numKhungLoXien);
      this.Controls.Add((Control) this.label23);
      this.Controls.Add((Control) this.label24);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.bunifuSeparator1);
      this.Controls.Add((Control) this.txtCapcungve);
      this.Controls.Add((Control) this.txtDuoicam);
      this.Controls.Add((Control) this.txtDaucam);
      this.Controls.Add((Control) this.txtTheocap);
      this.Controls.Add((Control) this.txtTheonhay);
      this.Controls.Add((Control) this.txtTheogiai);
      this.Controls.Add((Control) this.bunifuThinButton21);
      this.Controls.Add((Control) this.numSobanghi);
      this.Controls.Add((Control) this.numTrungDuoi);
      this.Controls.Add((Control) this.numDacBiet);
      this.Controls.Add((Control) this.numKhungBachThuNuoi);
      this.Controls.Add((Control) this.numKhungLoCap);
      this.Controls.Add((Control) this.numTrungDau);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.CheckboxHienthi);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.label22);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label21);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label20);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.label19);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label18);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.lblCapcungve);
      this.Controls.Add((Control) this.lblDuoicam);
      this.Controls.Add((Control) this.lblDaucam);
      this.Controls.Add((Control) this.lblTheocap);
      this.Controls.Add((Control) this.lblTheonhay);
      this.Controls.Add((Control) this.lblTheogiai);
      this.Controls.Add((Control) this.label28);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f);
      this.ForeColor = Color.DimGray;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FConfigBacNho);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Cấu hình hệ thống";
      this.Load += new EventHandler(this.FConfigBacNhoLoad);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.bunifuImageButton1.EndInit();
      this.bunifuImageButton8.EndInit();
      this.numTrungDau.EndInit();
      this.numTrungDuoi.EndInit();
      this.numSobanghi.EndInit();
      this.numKhungLoCap.EndInit();
      this.numKhungBachThuNuoi.EndInit();
      this.numDacBiet.EndInit();
      this.numKhungLoXien.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
