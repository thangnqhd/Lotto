// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabBangdacbiet
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabBangdacbiet : UserControl
  {
    private bool _cDau = false;
    private bool _cDuoi = false;
    private bool _cDTong = true;
    private bool _cNgayThang = false;
    private IContainer components = (IContainer) null;
    private TbVitri objVitri;
    private DataTable dt;
    private string strHtml;
    private DateTime _ngayBatdau;
    private DateTime _ngayKetThuc;
    private BunifuElipse bunifuElipse1;
    private Panel panel1;
    private Label label1;
    private Button btnXem;
    private DateTimePicker dt_tu_ngay;
    private Label label6;
    private DateTimePicker dt_den_ngay;
    private Label label10;
    private CheckBox cbDuoi;
    private CheckBox cbDau;
    private CheckBox cbTong;
    private Label label2;
    private BackgroundWorker backgroundWorker1;
    private CheckBox cbNgaythang;
    private WebBrowser wbHhienthi;
    private ToolTip toolTip1;

    public TabBangdacbiet()
    {
      this.InitializeComponent();
      this.dt_den_ngay.Value = FMain.NgayKetQuaMoiNhat;
      this.dt_tu_ngay.Value = this.dt_den_ngay.Value.AddDays(-30.0);
      this.objVitri = new TbVitri();
      this.btnXem.PerformClick();
    }

    private void dt_den_ngay_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dt_den_ngay.Value > FMain.NgayKetQuaMoiNhat))
        return;
      this.dt_den_ngay.Value = FMain.NgayKetQuaMoiNhat;
    }

    private void dt_tu_ngay_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dt_tu_ngay.Value >= this.dt_den_ngay.Value))
        return;
      this.dt_tu_ngay.Value = this.dt_den_ngay.Value.AddDays(-30.0);
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void XuLy()
    {
      this.strHtml = "";
      if (this._ngayBatdau != this.dt_tu_ngay.Value || this._ngayKetThuc != this.dt_den_ngay.Value)
      {
        this.dt = new DataTable();
        this.dt = this.objVitri.GetBangDacBietByDate(this.dt_tu_ngay.Value, this.dt_den_ngay.Value);
        this._ngayBatdau = this.dt_tu_ngay.Value;
        this._ngayKetThuc = this.dt_den_ngay.Value;
      }
      if (this.dt.Rows.Count <= 0)
        return;
      this.strHtml = "<div style='margin-right:15px;font-size:12px;'><table width='100%' class='table'>";
      this.strHtml += "<tr class='trTitle'>\r\n                        <td height='18px'>\r\n                            <div align='center'>Chủ Nhật</div></td><td>\r\n                            <div align='center'>Thứ Hai</div></td><td>\r\n                            <div align='center'>Thứ Ba</div></td>\r\n                            <td><div align='center'>Thứ Tư</div></td>\r\n                            <td><div align='center'>Thứ Năm</div></td>\r\n                            <td><div align='center'>Thứ Sáu</div></td>\r\n                            <td><div align='center'>Thứ Bảy</div></td>\r\n                        </tr>";
      int num1 = 0;
      bool flag = false;
      for (int index1 = 0; index1 < this.dt.Rows.Count; ++index1)
      {
        if (num1 == 0)
          this.strHtml += "<tr>";
        ++num1;
        string str1 = Convert.ToDateTime(this.dt.Rows[index1]["clngaythang"].ToString()).ToString("dd/MM/yyyy");
        string str2 = this.dt.Rows[index1]["G0:1:1"].ToString();
        string str3 = this.dt.Rows[index1]["G0:1:2"].ToString();
        string str4 = this.dt.Rows[index1]["G0:1:3"].ToString();
        string str5 = this.dt.Rows[index1]["G0:1:4"].ToString();
        string str6 = this.dt.Rows[index1]["G0:1:5"].ToString();
        string str7 = str2 + str3 + str4 + "<span style='color:darkblue;'>" + str5 + str6 + "</span>";
        string str8 = (Convert.ToInt32(str5) + Convert.ToInt32(str6)).ToString();
        string str9 = str8.Length <= 1 ? "<div class='itemsCol'><span class='tong'>" + str8 + "</span></div>" : "<div class='itemsCol'><span class='tong'>" + str8.Substring(1, 1) + "</span></div>";
        int num2 = Convert.ToInt32(this.dt.Rows[index1]["dayofweek"].ToString());
        string str10 = "<div class='itemsCol'><b class='ketqua'>" + str7 + "</b></div>";
        string str11 = "<div class='itemsCol'><span class='ngaythang'>" + str1 + "</span></div>";
        string str12 = "<div class='itemsCol'><span class='dau'>" + str5 + "</span></div>";
        string str13 = "<div class='itemsCol'><span class='dit'>" + str6 + "</span></div>";
        if (!this.cbNgaythang.Checked)
          str11 = "";
        if (!this.cbDau.Checked)
          str12 = "";
        if (!this.cbDuoi.Checked)
          str13 = "";
        if (!this.cbTong.Checked)
          str9 = "";
        if (!flag)
        {
          for (int index2 = 1; index2 < 8 && num2 != index2; ++index2)
          {
            ++num1;
            this.strHtml += "<td>\r\n\t\t                       </td>";
          }
          flag = true;
        }
        this.strHtml = this.strHtml + "<td class='tdCol'>" + str10 + str11 + str12 + str13 + str9 + "</td>";
        if (index1 < this.dt.Rows.Count - 1 && (num2 + 1 != Convert.ToInt32(this.dt.Rows[index1 + 1]["dayofweek"].ToString()) && num2 != 7))
        {
          for (int index2 = 1; index2 < 8; ++index2)
          {
            if (num2 >= 7)
              num2 = 0;
            if (num2 + 1 != Convert.ToInt32(this.dt.Rows[index1 + 1]["dayofweek"].ToString()))
            {
              ++num2;
              ++num1;
              this.strHtml += "<td></td>";
              if (num1 == 7)
              {
                this.strHtml += "</tr>";
                num1 = 0;
              }
            }
            else
              break;
          }
        }
        if (num1 == 7)
        {
          this.strHtml += "</tr>";
          num1 = 0;
        }
      }
      this.strHtml += "</table></div>";
    }

    private void HienThiKetQua(WebBrowser wb, string html)
    {
      string html1 = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + CssMessage.cssBangdacbiet + "</head><body  oncontextmenu='return false;' style='font-family:Verdana;'>" + html + "</body></html>";
      Tbketqua.DisplayHtml(wb, html1);
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      this.XuLy();
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.HienThiKetQua(this.wbHhienthi, this.strHtml);
    }

    private void cbNgaythang_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      if (checkBox.Checked)
      {
        checkBox.ForeColor = Color.Red;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Bold);
      }
      else
      {
        checkBox.ForeColor = Color.Black;
        checkBox.Font = new Font("Arial", 9f, FontStyle.Regular);
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
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1 = new Panel();
      this.cbNgaythang = new CheckBox();
      this.cbTong = new CheckBox();
      this.label2 = new Label();
      this.cbDuoi = new CheckBox();
      this.cbDau = new CheckBox();
      this.label1 = new Label();
      this.btnXem = new Button();
      this.dt_tu_ngay = new DateTimePicker();
      this.label6 = new Label();
      this.dt_den_ngay = new DateTimePicker();
      this.label10 = new Label();
      this.backgroundWorker1 = new BackgroundWorker();
      this.wbHhienthi = new WebBrowser();
      this.toolTip1 = new ToolTip(this.components);
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.cbNgaythang);
      this.panel1.Controls.Add((Control) this.cbTong);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.cbDuoi);
      this.panel1.Controls.Add((Control) this.cbDau);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btnXem);
      this.panel1.Controls.Add((Control) this.dt_tu_ngay);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.dt_den_ngay);
      this.panel1.Controls.Add((Control) this.label10);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1099, 31);
      this.panel1.TabIndex = 21;
      this.cbNgaythang.AutoSize = true;
      this.cbNgaythang.BackColor = Color.Transparent;
      this.cbNgaythang.Checked = true;
      this.cbNgaythang.CheckState = CheckState.Checked;
      this.cbNgaythang.Cursor = Cursors.Hand;
      this.cbNgaythang.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbNgaythang.ForeColor = Color.Red;
      this.cbNgaythang.Location = new Point(361, 8);
      this.cbNgaythang.Margin = new Padding(0);
      this.cbNgaythang.Name = "cbNgaythang";
      this.cbNgaythang.Size = new Size(54, 19);
      this.cbNgaythang.TabIndex = 2;
      this.cbNgaythang.Text = "Ngày";
      this.cbNgaythang.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbNgaythang, "Hiển thị ngày tháng");
      this.cbNgaythang.UseVisualStyleBackColor = false;
      this.cbNgaythang.CheckedChanged += new EventHandler(this.cbNgaythang_CheckedChanged);
      this.cbTong.AutoSize = true;
      this.cbTong.BackColor = Color.Transparent;
      this.cbTong.Checked = true;
      this.cbTong.CheckState = CheckState.Checked;
      this.cbTong.Cursor = Cursors.Hand;
      this.cbTong.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbTong.ForeColor = Color.Red;
      this.cbTong.Location = new Point(623, 8);
      this.cbTong.Margin = new Padding(0);
      this.cbTong.Name = "cbTong";
      this.cbTong.Size = new Size(54, 19);
      this.cbTong.TabIndex = 5;
      this.cbTong.Text = "Tổng";
      this.cbTong.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbTong, "Hiển thị tổng của giải đặc biệt");
      this.cbTong.UseVisualStyleBackColor = false;
      this.cbTong.CheckedChanged += new EventHandler(this.cbNgaythang_CheckedChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(301, 9);
      this.label2.Name = "label2";
      this.label2.Size = new Size(49, 15);
      this.label2.TabIndex = 30;
      this.label2.Text = "Hiển thị";
      this.cbDuoi.AutoSize = true;
      this.cbDuoi.BackColor = Color.Transparent;
      this.cbDuoi.Cursor = Cursors.Hand;
      this.cbDuoi.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDuoi.ForeColor = Color.Black;
      this.cbDuoi.Location = new Point(537, 8);
      this.cbDuoi.Margin = new Padding(0);
      this.cbDuoi.Name = "cbDuoi";
      this.cbDuoi.Size = new Size(52, 19);
      this.cbDuoi.TabIndex = 4;
      this.cbDuoi.Text = "Đuôi";
      this.cbDuoi.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDuoi, "Hiển thị đuôi của giải đặc biệt");
      this.cbDuoi.UseVisualStyleBackColor = false;
      this.cbDuoi.CheckedChanged += new EventHandler(this.cbNgaythang_CheckedChanged);
      this.cbDau.AutoSize = true;
      this.cbDau.BackColor = Color.Transparent;
      this.cbDau.Cursor = Cursors.Hand;
      this.cbDau.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbDau.ForeColor = Color.Black;
      this.cbDau.Location = new Point(451, 8);
      this.cbDau.Margin = new Padding(0);
      this.cbDau.Name = "cbDau";
      this.cbDau.Size = new Size(49, 19);
      this.cbDau.TabIndex = 3;
      this.cbDau.Text = "Đầu";
      this.cbDau.TextAlign = ContentAlignment.TopLeft;
      this.toolTip1.SetToolTip((Control) this.cbDau, "Hiển thị đầu của giải đặc biệt");
      this.cbDau.UseVisualStyleBackColor = false;
      this.cbDau.CheckedChanged += new EventHandler(this.cbNgaythang_CheckedChanged);
      this.label1.BackColor = Color.DimGray;
      this.label1.Dock = DockStyle.Bottom;
      this.label1.Location = new Point(0, 30);
      this.label1.Name = "label1";
      this.label1.Size = new Size(1099, 1);
      this.label1.TabIndex = 27;
      this.btnXem.BackColor = Color.Teal;
      this.btnXem.Cursor = Cursors.Hand;
      this.btnXem.FlatStyle = FlatStyle.Flat;
      this.btnXem.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnXem.ForeColor = Color.White;
      this.btnXem.Location = new Point(712, 4);
      this.btnXem.Margin = new Padding(3, 0, 3, 0);
      this.btnXem.Name = "btnXem";
      this.btnXem.Size = new Size(168, 23);
      this.btnXem.TabIndex = 26;
      this.btnXem.Text = "XEM";
      this.btnXem.TextAlign = ContentAlignment.TopCenter;
      this.btnXem.UseVisualStyleBackColor = true;
      this.btnXem.Click += new EventHandler(this.btnXem_Click);
      this.dt_tu_ngay.CalendarFont = new Font("Arial", 9f, FontStyle.Bold);
      this.dt_tu_ngay.CalendarForeColor = Color.Red;
      this.dt_tu_ngay.CustomFormat = "dd/MM/yyyy";
      this.dt_tu_ngay.Font = new Font("Arial", 9f, FontStyle.Bold);
      this.dt_tu_ngay.Format = DateTimePickerFormat.Custom;
      this.dt_tu_ngay.Location = new Point(52, 6);
      this.dt_tu_ngay.Margin = new Padding(3, 5, 3, 5);
      this.dt_tu_ngay.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
      this.dt_tu_ngay.Name = "dt_tu_ngay";
      this.dt_tu_ngay.Size = new Size(100, 21);
      this.dt_tu_ngay.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.dt_tu_ngay, "Ngày bắt đầu mà bạn muốn xem");
      this.dt_tu_ngay.ValueChanged += new EventHandler(this.dt_tu_ngay_ValueChanged);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(5, 9);
      this.label6.Name = "label6";
      this.label6.Size = new Size(46, 15);
      this.label6.TabIndex = 20;
      this.label6.Text = "Xem từ";
      this.dt_den_ngay.CalendarFont = new Font("Arial", 9f, FontStyle.Bold);
      this.dt_den_ngay.CalendarForeColor = Color.Red;
      this.dt_den_ngay.Cursor = Cursors.Hand;
      this.dt_den_ngay.CustomFormat = "dd/MM/yyyy";
      this.dt_den_ngay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dt_den_ngay.Format = DateTimePickerFormat.Custom;
      this.dt_den_ngay.Location = new Point(182, 6);
      this.dt_den_ngay.Margin = new Padding(3, 5, 3, 5);
      this.dt_den_ngay.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
      this.dt_den_ngay.Name = "dt_den_ngay";
      this.dt_den_ngay.Size = new Size(100, 21);
      this.dt_den_ngay.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.dt_den_ngay, "Ngày kết thúc mà bạn muốn xem");
      this.dt_den_ngay.ValueChanged += new EventHandler(this.dt_den_ngay_ValueChanged);
      this.label10.AutoSize = true;
      this.label10.Location = new Point(151, 9);
      this.label10.Name = "label10";
      this.label10.Size = new Size(28, 15);
      this.label10.TabIndex = 21;
      this.label10.Text = "đến";
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.wbHhienthi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbHhienthi.Location = new Point(0, 31);
      this.wbHhienthi.MinimumSize = new Size(20, 20);
      this.wbHhienthi.Name = "wbHhienthi";
      this.wbHhienthi.Size = new Size(1114, 636);
      this.wbHhienthi.TabIndex = 22;
      this.toolTip1.ToolTipTitle = "Thông tin chi tiết";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.wbHhienthi);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (TabBangdacbiet);
      this.Size = new Size(1099, 670);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
