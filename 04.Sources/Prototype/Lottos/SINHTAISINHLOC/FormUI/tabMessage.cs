// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.tabMessage
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class tabMessage : UserControl
  {
    private IContainer components = (IContainer) null;
    private int _soBanghi;
    private int _loadMessage;
    private DataTable _messageTable;
    private string strHtml;
    private Panel panel1;
    private WebBrowser webBrowserMessage;
    private BackgroundWorker backgroundWorkerMeesage;
    private Timer timerLoad_Message;
    private Panel panel2;
    private BunifuElipse bunifuElipse1;
    private PictureBox picLoading;
    private Button button1;
    private Button btnThongke;
    private ComboBox cbbSotinnhan;
    private Label label1;
    private GroupBox groupBox1;

    public tabMessage()
    {
      this.InitializeComponent();
      this.cbbSotinnhan.SelectedIndex = 1;
      this.picLoading.Location = new Point(FMain.ChieurongForm / 2 - 40, this.picLoading.Location.Y);
      this.webBrowserMessage.IsWebBrowserContextMenuEnabled = false;
      this.webBrowserMessage.AllowWebBrowserDrop = false;
      this.Hien_Thi_KetQua(this.webBrowserMessage, "");
    }

    private void LoadMessage(string tenDangnhap, int soBanghi)
    {
      tbMessage tbMessage = new tbMessage();
      this._messageTable = tbMessage.GetListInfor(tenDangnhap, soBanghi, 0);
      this.strHtml = "";
      this.strHtml += "\r\n                    <div class='container'>\r\n                    <div class='row'>\r\n                    <div class='col-md-8'>\r\n                    <div class='panel panel-info'>\r\n                    <div class='panel-heading'>\r\n                    </div>\r\n                    <div class='panel-body'>\r\n                    <ul class='media-list'>\r\n                    <li class='media'>";
      if (this._messageTable.Rows.Count > 0)
      {
        for (int index = 0; index < this._messageTable.Rows.Count; ++index)
        {
          string str = Directory.GetCurrentDirectory() + "\\Image\\logo.png";
          this.strHtml += "<div class='media-body'>";
          this.strHtml += "<div class='media' >";
          this.strHtml += "<b class='pull-left'>";
          this.strHtml = this.strHtml + "<img class='media-object img-circle ' src='" + str + "' height='52px;' /></b>";
          this.strHtml = this.strHtml + "<small class='text-muted'>[ <b style='color:blue;'>" + this._messageTable.Rows[index]["tieuDe"] + "</b> ]   Gửi từ : " + this._messageTable.Rows[index]["nguoiGui"].ToString() + " ngày " + this._messageTable.Rows[index]["sendDate"] + "</small>";
          this.strHtml = this.strHtml + "<div class='media-body' style='font-size:13px;'>" + this._messageTable.Rows[index]["noiDung"] + "<br />";
          this.strHtml += "<hr /></div></div></div>";
          tbMessage.Update_Status(Convert.ToInt32(this._messageTable.Rows[index]["stt"]));
        }
      }
      this.strHtml += "</li> </ul></div><div class='panel-footer'></div></div></div></div></div>";
    }

    private string Image_Username(string userName)
    {
      return Directory.GetCurrentDirectory() + "\\Image\\user.png";
    }

    private void Hien_Thi_KetQua(WebBrowser wb, string strHtml)
    {
      string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=10' />\r\n                                     " + CssMessage.StrCss1 + "<title>BOOTSTRAP CHAT EXAMPLE</title></head><body style='font-family:Verdana;margin-right:20px;padding-top:1px;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, html);
    }

    private void tabMessage_Load(object sender, EventArgs e)
    {
      if (this.backgroundWorkerMeesage.IsBusy)
        return;
      this.backgroundWorkerMeesage.RunWorkerAsync();
    }

    private void backgroundWorkerMeesage_DoWork(object sender, DoWorkEventArgs e)
    {
      this.LoadMessage(TbUser.Tbuser.TenDangnhap, this._soBanghi);
    }

    private void backgroundWorkerMeesage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Hien_Thi_KetQua(this.webBrowserMessage, this.strHtml);
    }

    private void timerLoad_Message_Tick_1(object sender, EventArgs e)
    {
      this.picLoading.Visible = this.backgroundWorkerMeesage.IsBusy;
      if (this._loadMessage != 1)
        return;
      this._loadMessage = 0;
      if (!this.backgroundWorkerMeesage.IsBusy)
        this.backgroundWorkerMeesage.RunWorkerAsync();
    }

    private void cbbSotinnhan_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.cbbSotinnhan.SelectedItem.ToString() != ""))
        return;
      this._soBanghi = int.Parse(this.cbbSotinnhan.SelectedItem.ToString());
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (this.backgroundWorkerMeesage.IsBusy)
        return;
      this.backgroundWorkerMeesage.RunWorkerAsync();
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
      if (this._messageTable.Rows.Count <= 0)
        return;
      tbMessage tbMessage = new tbMessage();
      int num1 = 0;
      for (int index = 0; index < this._messageTable.Rows.Count; ++index)
      {
        num1 = tbMessage.Delete_By_ID(this._messageTable.Rows[index]["stt"].ToString());
        if (num1 == 0)
          break;
      }
      if (num1 == 1)
      {
        int num2 = (int) MessageBox.Show(Resources.tabMessage_btnXoa_Click_XÓA_THÀNH_CÔNG, Resources.FSignup_check_Dangki_THÔNG_BÁO);
        this.backgroundWorkerMeesage.RunWorkerAsync();
      }
    }

    private void btnThongke_Click(object sender, EventArgs e)
    {
      if (this.backgroundWorkerMeesage.IsBusy)
        return;
      this.backgroundWorkerMeesage.RunWorkerAsync();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this._messageTable.Rows.Count <= 0)
        return;
      tbMessage tbMessage = new tbMessage();
      int num1 = 0;
      for (int index = 0; index < this._messageTable.Rows.Count; ++index)
      {
        num1 = tbMessage.Delete_By_ID(this._messageTable.Rows[index]["stt"].ToString());
        if (num1 == 0)
          break;
      }
      if (num1 == 1)
      {
        int num2 = (int) MessageBox.Show(Resources.tabMessage_btnXoa_Click_XÓA_THÀNH_CÔNG, Resources.FSignup_check_Dangki_THÔNG_BÁO);
        this.backgroundWorkerMeesage.RunWorkerAsync();
      }
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (tabMessage));
      this.panel1 = new Panel();
      this.picLoading = new PictureBox();
      this.panel2 = new Panel();
      this.groupBox1 = new GroupBox();
      this.btnThongke = new Button();
      this.button1 = new Button();
      this.label1 = new Label();
      this.cbbSotinnhan = new ComboBox();
      this.webBrowserMessage = new WebBrowser();
      this.backgroundWorkerMeesage = new BackgroundWorker();
      this.timerLoad_Message = new Timer(this.components);
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picLoading).BeginInit();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.picLoading);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.webBrowserMessage);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1090, 478);
      this.panel1.TabIndex = 36;
      this.picLoading.BackColor = Color.Transparent;
      this.picLoading.BackgroundImageLayout = ImageLayout.Zoom;
      this.picLoading.ErrorImage = (Image) componentResourceManager.GetObject("picLoading.ErrorImage");
      this.picLoading.Image = (Image) componentResourceManager.GetObject("picLoading.Image");
      this.picLoading.InitialImage = (Image) null;
      this.picLoading.Location = new Point(596, 354);
      this.picLoading.Name = "picLoading";
      this.picLoading.Size = new Size(40, 40);
      this.picLoading.SizeMode = PictureBoxSizeMode.Zoom;
      this.picLoading.TabIndex = 18;
      this.picLoading.TabStop = false;
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.groupBox1);
      this.panel2.Location = new Point(-1, -1);
      this.panel2.Margin = new Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1091, 46);
      this.panel2.TabIndex = 1;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.btnThongke);
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.cbbSotinnhan);
      this.groupBox1.Location = new Point(6, 1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1080, 43);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(221, 12);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(131, 23);
      this.btnThongke.TabIndex = 2;
      this.btnThongke.Text = "XEM";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.btnThongke.Click += new EventHandler(this.btnThongke_Click);
      this.button1.BackColor = Color.Teal;
      this.button1.Cursor = Cursors.Hand;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.White;
      this.button1.Location = new Point(352, 12);
      this.button1.Margin = new Padding(3, 0, 3, 0);
      this.button1.Name = "button1";
      this.button1.Size = new Size(81, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "XÓA";
      this.button1.TextAlign = ContentAlignment.TopCenter;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(8, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(150, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Số thông báo muốn xem";
      this.cbbSotinnhan.BackColor = Color.Teal;
      this.cbbSotinnhan.Cursor = Cursors.Hand;
      this.cbbSotinnhan.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbSotinnhan.FlatStyle = FlatStyle.Flat;
      this.cbbSotinnhan.ForeColor = Color.White;
      this.cbbSotinnhan.FormattingEnabled = true;
      this.cbbSotinnhan.Items.AddRange(new object[5]
      {
        (object) "15",
        (object) "25",
        (object) "50",
        (object) "100",
        (object) "150"
      });
      this.cbbSotinnhan.Location = new Point(161, 12);
      this.cbbSotinnhan.Name = "cbbSotinnhan";
      this.cbbSotinnhan.Size = new Size(55, 23);
      this.cbbSotinnhan.TabIndex = 0;
      this.cbbSotinnhan.SelectedIndexChanged += new EventHandler(this.cbbSotinnhan_SelectedIndexChanged);
      this.webBrowserMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.webBrowserMessage.CausesValidation = false;
      this.webBrowserMessage.Location = new Point(0, 1);
      this.webBrowserMessage.Margin = new Padding(0);
      this.webBrowserMessage.MinimumSize = new Size(23, 23);
      this.webBrowserMessage.Name = "webBrowserMessage";
      this.webBrowserMessage.Size = new Size(1105, 478);
      this.webBrowserMessage.TabIndex = 0;
      this.backgroundWorkerMeesage.DoWork += new DoWorkEventHandler(this.backgroundWorkerMeesage_DoWork);
      this.backgroundWorkerMeesage.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorkerMeesage_RunWorkerCompleted);
      this.timerLoad_Message.Enabled = true;
      this.timerLoad_Message.Interval = 10;
      this.timerLoad_Message.Tick += new EventHandler(this.timerLoad_Message_Tick_1);
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.Name = nameof (tabMessage);
      this.Size = new Size(1090, 478);
      this.Load += new EventHandler(this.tabMessage_Load);
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.picLoading).EndInit();
      this.panel2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
