// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.fTransfer
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
  public class fTransfer : Form
  {
    private IContainer components = (IContainer) null;
    private tbMoneyUSER infoMoneyUser;
    private Panel panel1;
    private RichTextBox richTextBoxNoidung;
    private BunifuThinButton2 btnDangki;
    private LinkLabel linkLabel1;
    private Label label5;
    private Label lblThongbao;
    private PictureBox picMainTop;
    private BunifuImageButton bunifuImageButton3;
    private TextBox txtUsername;
    private TextBox txtBachienco;
    private Label label3;
    private Label label1;
    private TextBox txtSobacchuyen;
    private Label label4;
    private Label label8;
    private Label label7;
    private BunifuElipse bunifuElipse1;
    private Label label6;

    public fTransfer()
    {
      this.InitializeComponent();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void picMainTop_Click(object sender, EventArgs e)
    {
    }

    private void bunifuImageButton3_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.Close();
    }

    private void richTextBoxNoidung_TextChanged(object sender, EventArgs e)
    {
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void check_Info()
    {
      if (this.txtUsername.Text == TbUser.Tbuser.TenDangnhap)
      {
        this.lblThongbao.Visible = true;
        this.lblThongbao.Text = Resources.fTransfer_check_Info_Bạn_muốn_gửi_tiền_cho_chính_mình____;
        this.txtUsername.Focus();
      }
      else
      {
        if (this.txtUsername.Text != Resources.fTransfer_check_Info_Administrator && this.txtUsername.Text != "administrator")
        {
          if (this.txtUsername.Text.Length > 0)
          {
            if (TbUser.Tbuser.CheckUsername(this.txtUsername.Text))
            {
              this.lblThongbao.Visible = true;
              this.lblThongbao.Text = Resources.fTransfer_check_Info_Tên_đăng_nhập_này_không_tồn_tại____;
              this.txtUsername.Focus();
              return;
            }
            this.lblThongbao.Visible = false;
          }
          else
          {
            this.lblThongbao.Visible = true;
            this.lblThongbao.Text = Resources.fTransfer_check_Info_Nhập_vào_tên_đăng_nhập_của_người_nhận____;
            this.txtUsername.Focus();
            return;
          }
        }
        else if (this.txtSobacchuyen.Text != "")
        {
          if (ClMain.IsNumber(this.txtSobacchuyen.Text) && int.Parse(this.txtSobacchuyen.Text) > 99)
          {
            if (int.Parse(this.txtSobacchuyen.Text) > int.Parse(this.infoMoneyUser.XuHienco))
            {
              this.lblThongbao.Visible = true;
              this.lblThongbao.Text = Resources.fTransfer_check_Info_Số_bạc_muốn_chuyển_của_bạn_lớn_quá____;
              this.txtSobacchuyen.Focus();
              return;
            }
            this.lblThongbao.Visible = false;
          }
          else
          {
            this.lblThongbao.Visible = true;
            this.lblThongbao.Text = Resources.fTransfer_check_Info_Để_gửi_thông_báo_lên_hệ_thống_bạn_cần_100_bạc;
            this.txtSobacchuyen.Focus();
            return;
          }
        }
        else
        {
          this.lblThongbao.Visible = true;
          this.lblThongbao.Text = Resources.fTransfer_check_Info_Nhập_vào_số_bạc_bạn_muốn_chuyển____;
          this.txtSobacchuyen.Focus();
          return;
        }
        if (this.txtSobacchuyen.Text != "")
        {
          if (ClMain.IsNumber(this.txtSobacchuyen.Text) && int.Parse(this.txtSobacchuyen.Text) > 0)
          {
            if (int.Parse(this.txtSobacchuyen.Text) > int.Parse(this.infoMoneyUser.XuHienco))
            {
              this.lblThongbao.Visible = true;
              this.lblThongbao.Text = Resources.fTransfer_check_Info_Số_bạc_muốn_chuyển_của_bạn_lớn_quá____;
              this.txtSobacchuyen.Focus();
            }
            else
            {
              this.lblThongbao.Visible = false;
              if (this.richTextBoxNoidung.Text != "")
              {
                if (this.richTextBoxNoidung.Text.Length > 500)
                {
                  this.lblThongbao.Visible = true;
                  this.lblThongbao.Text = Resources.fTransfer_check_Info_Tin_nhắn_của_bạn_dài_quá_rồi____;
                  this.richTextBoxNoidung.Focus();
                }
                else
                {
                  this.lblThongbao.Visible = false;
                  this.lblThongbao.Visible = true;
                  this.lblThongbao.Text = Resources.fTransfer_check_Info_Gợi_ý___Nếu_bạn_ủng_hộ_quản_trị_viên_thì_tin_nhắn_của_bạn_sẽ_được_hiển_thị_trên_toàn_hệ_thống_đấy_nhé___;
                  this.XuLyInsert();
                  this.GetInfoMoneyUser();
                  FMain.LoadLaiForm = 1;
                  TabInfoUser.LoadLaiFrom = 1;
                }
              }
              else
              {
                this.lblThongbao.Visible = true;
                this.lblThongbao.Text = Resources.fTransfer_check_Info_Hãy_gửi_một_tin_nhắn_đến_cho_bạn_của_bạn_nhé___;
                this.richTextBoxNoidung.Focus();
              }
            }
          }
          else
          {
            this.lblThongbao.Visible = true;
            this.lblThongbao.Text = Resources.fTransfer_check_Info_Số_bạc_muốn_chuyển_của_bạn_chưa_chính_xác_kìa_____;
            this.txtSobacchuyen.Focus();
          }
        }
        else
        {
          this.lblThongbao.Visible = true;
          this.lblThongbao.Text = Resources.fTransfer_check_Info_Nhập_vào_số_bạc_bạn_muốn_chuyển____;
          this.txtSobacchuyen.Focus();
        }
      }
    }

    private void GetInfoMoneyUser()
    {
      this.infoMoneyUser = new tbMoneyUSER();
      this.infoMoneyUser = this.infoMoneyUser.GetInfor(TbUser.Tbuser.TenDangnhap);
      this.txtBachienco.Text = ClMain.QuiDoiSoLuong(this.infoMoneyUser.XuHienco, "");
    }

    private void btnDangki_Click(object sender, EventArgs e)
    {
      this.GetInfoMoneyUser();
      this.check_Info();
    }

    private void XuLyInsert()
    {
      this.Insert_Xusudung();
      this.Insert_Message_NguoiNhan();
      this.Insert_Message_NguoiGui();
      this.Update_Money_Nguoi_Gui();
      this.Update_Money_Nguoi_Nhan();
    }

    public void Insert_Xusudung()
    {
      tbXusudung tbXusudung = new tbXusudung();
      tbXusudung.TenDangnhap = TbUser.Tbuser.TenDangnhap;
      tbXusudung.XuSudung = (-Convert.ToDecimal(this.txtSobacchuyen.Text)).ToString();
      tbXusudung.CachSudung = "Chuyển cho [" + this.txtUsername.Text + "] -" + ClMain.QuiDoiSoLuong(this.txtSobacchuyen.Text, "bạc") ?? "";
      tbXusudung.Insert(tbXusudung);
    }

    private void Insert_Message_NguoiNhan()
    {
      tbMessage tbMessage = new tbMessage();
      tbMessage.NguoiGui = TbUser.Tbuser.TenDangnhap;
      tbMessage.NguoiNhan = this.txtUsername.Text;
      tbMessage.TieuDe = "Chuyển xu";
      tbMessage.NoiDung = "Bạn vừa nhận được [<b style=''color:red''>" + ClMain.QuiDoiSoLuong(this.txtSobacchuyen.Text, "</b>] bạc") + " từ [<b style=''color:red''>" + TbUser.Tbuser.TenDangnhap + "</b>]<br/>Lời nhắn : " + this.richTextBoxNoidung.Text;
      tbMessage.Insert(tbMessage);
    }

    private void Insert_Message_NguoiGui()
    {
      tbMessage tbMessage = new tbMessage();
      tbMessage.NguoiGui = TbUser.Tbuser.TenDangnhap;
      tbMessage.NguoiNhan = TbUser.Tbuser.TenDangnhap;
      tbMessage.TieuDe = "Chuyển xu thành công";
      tbMessage.NoiDung = "Bạn vừa chuyển thành công [<b style=''color:red''>" + ClMain.QuiDoiSoLuong(this.txtSobacchuyen.Text, "</b>] bạc") + " đến [<b style=''color:red''>" + this.txtUsername.Text + "</b>]";
      tbMessage.Insert(tbMessage);
    }

    public void Update_Money_Nguoi_Gui()
    {
      tbMoneyUSER infor = new tbMoneyUSER().GetInfor(TbUser.Tbuser.TenDangnhap);
      infor.VangHienco = infor.VangHienco;
      infor.XuHienco = (Convert.ToDecimal(infor.XuHienco) - Convert.ToDecimal(this.txtSobacchuyen.Text)).ToString();
      infor.Update(infor);
    }

    public void Update_Money_Nguoi_Nhan()
    {
      Decimal num1 = new Decimal();
      string text = this.txtUsername.Text;
      Decimal num2 = this.infoMoneyUser.Get_Bac_By_Username(text) + Convert.ToDecimal(this.txtSobacchuyen.Text);
      if (this.infoMoneyUser.Update_BacHienCo_Username(text, num2.ToString()) != 1)
        return;
      int num3 = (int) MessageBox.Show(Resources.fTransfer_Update_Money_Nguoi_Nhan_XỬ_LÝ_THÀNH_CÔNG, Resources.fGopy_btnDangki_Click_THÔNG_BÁO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void label6_Click(object sender, EventArgs e)
    {
    }

    private void label5_Click(object sender, EventArgs e)
    {
    }

    private void fTransfer_Load(object sender, EventArgs e)
    {
      this.txtUsername.Text = Resources.fTransfer_check_Info_Administrator;
      this.txtUsername.ForeColor = Color.Red;
      this.lblThongbao.Visible = true;
      this.lblThongbao.Text = Resources.fTransfer_check_Info_Gợi_ý___Nếu_bạn_ủng_hộ_quản_trị_viên_thì_tin_nhắn_của_bạn_sẽ_được_hiển_thị_trên_toàn_hệ_thống_đấy_nhé___;
      this.GetInfoMoneyUser();
    }

    private void picMainTop_MouseDown(object sender, MouseEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (fTransfer));
      this.panel1 = new Panel();
      this.label6 = new Label();
      this.txtSobacchuyen = new TextBox();
      this.txtBachienco = new TextBox();
      this.txtUsername = new TextBox();
      this.richTextBoxNoidung = new RichTextBox();
      this.btnDangki = new BunifuThinButton2();
      this.linkLabel1 = new LinkLabel();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.label3 = new Label();
      this.lblThongbao = new Label();
      this.label1 = new Label();
      this.picMainTop = new PictureBox();
      this.bunifuImageButton3 = new BunifuImageButton();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picMainTop).BeginInit();
      this.bunifuImageButton3.BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.txtSobacchuyen);
      this.panel1.Controls.Add((Control) this.txtBachienco);
      this.panel1.Controls.Add((Control) this.txtUsername);
      this.panel1.Controls.Add((Control) this.richTextBoxNoidung);
      this.panel1.Controls.Add((Control) this.btnDangki);
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.label8);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.lblThongbao);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.panel1.Location = new Point(77, 36);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(762, 408);
      this.panel1.TabIndex = 9;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9.75f, FontStyle.Bold);
      this.label6.ForeColor = SystemColors.ControlDarkDark;
      this.label6.Location = new Point(346, 35);
      this.label6.Name = "label6";
      this.label6.Size = new Size(90, 16);
      this.label6.TabIndex = 22;
      this.label6.Text = "Gửi tặng bạc";
      this.txtSobacchuyen.BorderStyle = BorderStyle.FixedSingle;
      this.txtSobacchuyen.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSobacchuyen.ForeColor = Color.Red;
      this.txtSobacchuyen.Location = new Point(179, 139);
      this.txtSobacchuyen.Name = "txtSobacchuyen";
      this.txtSobacchuyen.Size = new Size(194, 25);
      this.txtSobacchuyen.TabIndex = 2;
      this.txtSobacchuyen.TextAlign = HorizontalAlignment.Right;
      this.txtBachienco.BorderStyle = BorderStyle.FixedSingle;
      this.txtBachienco.Enabled = false;
      this.txtBachienco.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtBachienco.ForeColor = Color.Red;
      this.txtBachienco.Location = new Point(179, 101);
      this.txtBachienco.Name = "txtBachienco";
      this.txtBachienco.Size = new Size(194, 25);
      this.txtBachienco.TabIndex = 1;
      this.txtBachienco.TextAlign = HorizontalAlignment.Right;
      this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
      this.txtUsername.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtUsername.ForeColor = Color.Red;
      this.txtUsername.Location = new Point(179, 66);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new Size(515, 22);
      this.txtUsername.TabIndex = 0;
      this.richTextBoxNoidung.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBoxNoidung.Location = new Point(179, 180);
      this.richTextBoxNoidung.Name = "richTextBoxNoidung";
      this.richTextBoxNoidung.Size = new Size(515, 136);
      this.richTextBoxNoidung.TabIndex = 3;
      this.richTextBoxNoidung.Text = "";
      this.richTextBoxNoidung.TextChanged += new EventHandler(this.richTextBoxNoidung_TextChanged);
      this.btnDangki.ActiveBorderThickness = 1;
      this.btnDangki.ActiveCornerRadius = 20;
      this.btnDangki.ActiveFillColor = Color.DodgerBlue;
      this.btnDangki.ActiveForecolor = Color.White;
      this.btnDangki.ActiveLineColor = Color.DodgerBlue;
      this.btnDangki.BackColor = Color.White;
      this.btnDangki.BackgroundImage = (Image) componentResourceManager.GetObject("btnDangki.BackgroundImage");
      this.btnDangki.ButtonText = "Xác nhận";
      this.btnDangki.Cursor = Cursors.Hand;
      this.btnDangki.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDangki.ForeColor = Color.Black;
      this.btnDangki.IdleBorderThickness = 1;
      this.btnDangki.IdleCornerRadius = 20;
      this.btnDangki.IdleFillColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.IdleForecolor = Color.White;
      this.btnDangki.IdleLineColor = Color.FromArgb(81, 164, 227);
      this.btnDangki.Location = new Point(247, 345);
      this.btnDangki.Margin = new Padding(6, 5, 6, 5);
      this.btnDangki.Name = "btnDangki";
      this.btnDangki.Size = new Size(447, 50);
      this.btnDangki.TabIndex = 4;
      this.btnDangki.TextAlign = ContentAlignment.MiddleCenter;
      this.btnDangki.Click += new EventHandler(this.btnDangki_Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Cursor = Cursors.Hand;
      this.linkLabel1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.DodgerBlue;
      this.linkLabel1.Location = new Point(191, 361);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(53, 17);
      this.linkLabel1.TabIndex = 5;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Hủy bỏ";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DimGray;
      this.label4.Location = new Point(25, 143);
      this.label4.Name = "label4";
      this.label4.Size = new Size(154, 17);
      this.label4.TabIndex = 1;
      this.label4.Text = "Số bạc muốn chuyển :";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DimGray;
      this.label5.Location = new Point(51, 182);
      this.label5.Name = "label5";
      this.label5.Size = new Size(128, 17);
      this.label5.TabIndex = 1;
      this.label5.Text = "Nội dung tin nhắn :";
      this.label5.Click += new EventHandler(this.label5_Click);
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.Red;
      this.label8.Location = new Point(374, 144);
      this.label8.Name = "label8";
      this.label8.Size = new Size(32, 17);
      this.label8.TabIndex = 1;
      this.label8.Text = "bạc";
      this.label8.Click += new EventHandler(this.label3_Click);
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Red;
      this.label7.Location = new Point(374, 103);
      this.label7.Name = "label7";
      this.label7.Size = new Size(32, 17);
      this.label7.TabIndex = 1;
      this.label7.Text = "bạc";
      this.label7.Click += new EventHandler(this.label3_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DimGray;
      this.label3.Location = new Point(66, 106);
      this.label3.Name = "label3";
      this.label3.Size = new Size(113, 17);
      this.label3.TabIndex = 1;
      this.label3.Text = "Số bạc hiện có :";
      this.label3.Click += new EventHandler(this.label3_Click);
      this.lblThongbao.AutoSize = true;
      this.lblThongbao.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThongbao.ForeColor = Color.Red;
      this.lblThongbao.Location = new Point(175, 325);
      this.lblThongbao.Name = "lblThongbao";
      this.lblThongbao.Size = new Size(560, 15);
      this.lblThongbao.TabIndex = 1;
      this.lblThongbao.Text = "Gợi ý : Nếu bạn ủng hộ quản trị viên thì tin nhắn của bạn sẽ được hiển thị trên toàn hệ thống đấy nhé !!";
      this.lblThongbao.Visible = false;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DimGray;
      this.label1.Location = new Point(86, 67);
      this.label1.Name = "label1";
      this.label1.Size = new Size(93, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Người nhận :";
      this.picMainTop.BackColor = Color.FromArgb(27, 40, 61);
      this.picMainTop.Dock = DockStyle.Top;
      this.picMainTop.Location = new Point(0, 0);
      this.picMainTop.Name = "picMainTop";
      this.picMainTop.Size = new Size(917, 236);
      this.picMainTop.TabIndex = 10;
      this.picMainTop.TabStop = false;
      this.picMainTop.Click += new EventHandler(this.picMainTop_Click);
      this.picMainTop.MouseDown += new MouseEventHandler(this.picMainTop_MouseDown);
      this.bunifuImageButton3.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton3.Cursor = Cursors.Hand;
      this.bunifuImageButton3.Image = (Image) componentResourceManager.GetObject("bunifuImageButton3.Image");
      this.bunifuImageButton3.ImageActive = (Image) null;
      this.bunifuImageButton3.Location = new Point(892, 1);
      this.bunifuImageButton3.Name = "bunifuImageButton3";
      this.bunifuImageButton3.Size = new Size(23, 23);
      this.bunifuImageButton3.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton3.TabIndex = 11;
      this.bunifuImageButton3.TabStop = false;
      this.bunifuImageButton3.Zoom = 15;
      this.bunifuImageButton3.Click += new EventHandler(this.bunifuImageButton3_Click);
      this.bunifuElipse1.ElipseRadius = 10;
      this.bunifuElipse1.TargetControl = (Control) this.panel1;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(233, 235, 238);
      this.ClientSize = new Size(917, 456);
      this.Controls.Add((Control) this.bunifuImageButton3);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.picMainTop);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (fTransfer);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Gửi tiền";
      this.Load += new EventHandler(this.fTransfer_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picMainTop).EndInit();
      this.bunifuImageButton3.EndInit();
      this.ResumeLayout(false);
    }
  }
}
