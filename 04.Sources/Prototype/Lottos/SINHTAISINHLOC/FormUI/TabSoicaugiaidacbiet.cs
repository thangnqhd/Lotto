// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabSoicaugiaidacbiet
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabSoicaugiaidacbiet : UserControl
  {
    private IContainer components = (IContainer) null;
    private GroupBox groupBox1;
    private Panel panel1;
    private Label label1;
    private Label label8;
    private ComboBox cbbVitri2;
    private Button btnThongke;
    private DateTimePicker dtDenNgay;
    private DateTimePicker dtTuNgay;
    private Label label9;
    private NumericUpDown numTien;
    private NumericUpDown numLui;
    public ComboBox cbbVitri1;
    private ComboBox cbbLoto;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label14;

    public TabSoicaugiaidacbiet()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox1 = new GroupBox();
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.label8 = new Label();
      this.cbbVitri2 = new ComboBox();
      this.btnThongke = new Button();
      this.dtDenNgay = new DateTimePicker();
      this.dtTuNgay = new DateTimePicker();
      this.label9 = new Label();
      this.numTien = new NumericUpDown();
      this.numLui = new NumericUpDown();
      this.cbbVitri1 = new ComboBox();
      this.cbbLoto = new ComboBox();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.label14 = new Label();
      this.groupBox1.SuspendLayout();
      this.numTien.BeginInit();
      this.numLui.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.label8);
      this.groupBox1.Controls.Add((Control) this.cbbVitri2);
      this.groupBox1.Controls.Add((Control) this.btnThongke);
      this.groupBox1.Controls.Add((Control) this.dtDenNgay);
      this.groupBox1.Controls.Add((Control) this.dtTuNgay);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.numTien);
      this.groupBox1.Controls.Add((Control) this.numLui);
      this.groupBox1.Controls.Add((Control) this.cbbVitri1);
      this.groupBox1.Controls.Add((Control) this.cbbLoto);
      this.groupBox1.Controls.Add((Control) this.label10);
      this.groupBox1.Controls.Add((Control) this.label11);
      this.groupBox1.Controls.Add((Control) this.label12);
      this.groupBox1.Controls.Add((Control) this.label14);
      this.groupBox1.Dock = DockStyle.Top;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(1100, 46);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 46);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 508);
      this.panel1.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkSlateGray;
      this.label1.Location = new Point(395, 17);
      this.label1.Name = "label1";
      this.label1.Size = new Size(45, 16);
      this.label1.TabIndex = 57;
      this.label1.Text = "Vị trí II";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DarkSlateGray;
      this.label8.Location = new Point(6, 17);
      this.label8.Name = "label8";
      this.label8.Size = new Size(56, 16);
      this.label8.TabIndex = 56;
      this.label8.Text = "Từ ngày";
      this.cbbVitri2.BackColor = Color.Teal;
      this.cbbVitri2.Cursor = Cursors.Hand;
      this.cbbVitri2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbVitri2.FlatStyle = FlatStyle.Popup;
      this.cbbVitri2.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbVitri2.ForeColor = Color.White;
      this.cbbVitri2.Items.AddRange(new object[107]
      {
        (object) "G0:1:1",
        (object) "G0:1:2",
        (object) "G0:1:3",
        (object) "G0:1:4",
        (object) "G0:1:5",
        (object) "G1:1:1",
        (object) "G1:1:2",
        (object) "G1:1:3",
        (object) "G1:1:4",
        (object) "G1:1:5",
        (object) "G2:1:1",
        (object) "G2:1:2",
        (object) "G2:1:3",
        (object) "G2:1:4",
        (object) "G2:1:5",
        (object) "G2:2:1",
        (object) "G2:2:2",
        (object) "G2:2:3",
        (object) "G2:2:4",
        (object) "G2:2:5",
        (object) "G3:1:1",
        (object) "G3:1:2",
        (object) "G3:1:3",
        (object) "G3:1:4",
        (object) "G3:1:5",
        (object) "G3:2:1",
        (object) "G3:2:2",
        (object) "G3:2:3",
        (object) "G3:2:4",
        (object) "G3:2:5",
        (object) "G3:3:1",
        (object) "G3:3:2",
        (object) "G3:3:3",
        (object) "G3:3:4",
        (object) "G3:3:5",
        (object) "G3:4:1",
        (object) "G3:4:2",
        (object) "G3:4:3",
        (object) "G3:4:4",
        (object) "G3:4:5",
        (object) "G3:5:1",
        (object) "G3:5:2",
        (object) "G3:5:3",
        (object) "G3:5:4",
        (object) "G3:5:5",
        (object) "G3:6:1",
        (object) "G3:6:2",
        (object) "G3:6:3",
        (object) "G3:6:4",
        (object) "G3:6:5",
        (object) "G4:1:1",
        (object) "G4:1:2",
        (object) "G4:1:3",
        (object) "G4:1:4",
        (object) "G4:2:1",
        (object) "G4:2:2",
        (object) "G4:2:3",
        (object) "G4:2:4",
        (object) "G4:3:1",
        (object) "G4:3:2",
        (object) "G4:3:3",
        (object) "G4:3:4",
        (object) "G4:4:1",
        (object) "G4:4:2",
        (object) "G4:4:3",
        (object) "G4:4:4",
        (object) "G5:1:1",
        (object) "G5:1:2",
        (object) "G5:1:3",
        (object) "G5:1:4",
        (object) "G5:2:1",
        (object) "G5:2:2",
        (object) "G5:2:3",
        (object) "G5:2:4",
        (object) "G5:3:1",
        (object) "G5:3:2",
        (object) "G5:3:3",
        (object) "G5:3:4",
        (object) "G5:4:1",
        (object) "G5:4:2",
        (object) "G5:4:3",
        (object) "G5:4:4",
        (object) "G5:5:1",
        (object) "G5:5:2",
        (object) "G5:5:3",
        (object) "G5:5:4",
        (object) "G5:6:1",
        (object) "G5:6:2",
        (object) "G5:6:3",
        (object) "G5:6:4",
        (object) "G6:1:1",
        (object) "G6:1:2",
        (object) "G6:1:3",
        (object) "G6:2:1",
        (object) "G6:2:2",
        (object) "G6:2:3",
        (object) "G6:3:1",
        (object) "G6:3:2",
        (object) "G6:3:3",
        (object) "G7:1:1",
        (object) "G7:1:2",
        (object) "G7:2:1",
        (object) "G7:2:2",
        (object) "G7:3:1",
        (object) "G7:3:2",
        (object) "G7:4:1",
        (object) "G7:4:2"
      });
      this.cbbVitri2.Location = new Point(442, 13);
      this.cbbVitri2.Name = "cbbVitri2";
      this.cbbVitri2.Size = new Size(70, 23);
      this.cbbVitri2.TabIndex = 46;
      this.btnThongke.BackColor = Color.Teal;
      this.btnThongke.Cursor = Cursors.Hand;
      this.btnThongke.FlatStyle = FlatStyle.Flat;
      this.btnThongke.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThongke.ForeColor = Color.White;
      this.btnThongke.Location = new Point(881, 13);
      this.btnThongke.Margin = new Padding(3, 0, 3, 0);
      this.btnThongke.Name = "btnThongke";
      this.btnThongke.Size = new Size(131, 24);
      this.btnThongke.TabIndex = 50;
      this.btnThongke.Text = "XEM CHI TIẾT";
      this.btnThongke.TextAlign = ContentAlignment.TopCenter;
      this.btnThongke.UseVisualStyleBackColor = true;
      this.dtDenNgay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtDenNgay.CalendarForeColor = Color.Red;
      this.dtDenNgay.CalendarMonthBackground = SystemColors.Info;
      this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
      this.dtDenNgay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtDenNgay.Format = DateTimePickerFormat.Custom;
      this.dtDenNgay.Location = new Point(163, 15);
      this.dtDenNgay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtDenNgay.Name = "dtDenNgay";
      this.dtDenNgay.Size = new Size(91, 21);
      this.dtDenNgay.TabIndex = 44;
      this.dtTuNgay.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtTuNgay.CalendarForeColor = Color.Red;
      this.dtTuNgay.CalendarMonthBackground = SystemColors.Info;
      this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
      this.dtTuNgay.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtTuNgay.Format = DateTimePickerFormat.Custom;
      this.dtTuNgay.Location = new Point(62, 15);
      this.dtTuNgay.MinDate = new DateTime(2005, 1, 5, 0, 0, 0, 0);
      this.dtTuNgay.Name = "dtTuNgay";
      this.dtTuNgay.Size = new Size(91, 21);
      this.dtTuNgay.TabIndex = 43;
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.DarkSlateGray;
      this.label9.Location = new Point(152, 18);
      this.label9.Name = "label9";
      this.label9.Size = new Size(12, 16);
      this.label9.TabIndex = 55;
      this.label9.Text = "-";
      this.numTien.BackColor = Color.White;
      this.numTien.BorderStyle = BorderStyle.FixedSingle;
      this.numTien.Cursor = Cursors.Hand;
      this.numTien.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numTien.ForeColor = Color.Black;
      this.numTien.Location = new Point(820, 15);
      this.numTien.Maximum = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numTien.Name = "numTien";
      this.numTien.Size = new Size(43, 21);
      this.numTien.TabIndex = 49;
      this.numTien.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numLui.BackColor = Color.White;
      this.numLui.BorderStyle = BorderStyle.FixedSingle;
      this.numLui.Cursor = Cursors.Hand;
      this.numLui.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.numLui.ForeColor = Color.Black;
      this.numLui.Location = new Point(747, 15);
      this.numLui.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numLui.Minimum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        int.MinValue
      });
      this.numLui.Name = "numLui";
      this.numLui.Size = new Size(43, 21);
      this.numLui.TabIndex = 48;
      this.numLui.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.cbbVitri1.BackColor = Color.Teal;
      this.cbbVitri1.Cursor = Cursors.Hand;
      this.cbbVitri1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbVitri1.FlatStyle = FlatStyle.Popup;
      this.cbbVitri1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbVitri1.ForeColor = Color.White;
      this.cbbVitri1.Items.AddRange(new object[107]
      {
        (object) "G0:1:1",
        (object) "G0:1:2",
        (object) "G0:1:3",
        (object) "G0:1:4",
        (object) "G0:1:5",
        (object) "G1:1:1",
        (object) "G1:1:2",
        (object) "G1:1:3",
        (object) "G1:1:4",
        (object) "G1:1:5",
        (object) "G2:1:1",
        (object) "G2:1:2",
        (object) "G2:1:3",
        (object) "G2:1:4",
        (object) "G2:1:5",
        (object) "G2:2:1",
        (object) "G2:2:2",
        (object) "G2:2:3",
        (object) "G2:2:4",
        (object) "G2:2:5",
        (object) "G3:1:1",
        (object) "G3:1:2",
        (object) "G3:1:3",
        (object) "G3:1:4",
        (object) "G3:1:5",
        (object) "G3:2:1",
        (object) "G3:2:2",
        (object) "G3:2:3",
        (object) "G3:2:4",
        (object) "G3:2:5",
        (object) "G3:3:1",
        (object) "G3:3:2",
        (object) "G3:3:3",
        (object) "G3:3:4",
        (object) "G3:3:5",
        (object) "G3:4:1",
        (object) "G3:4:2",
        (object) "G3:4:3",
        (object) "G3:4:4",
        (object) "G3:4:5",
        (object) "G3:5:1",
        (object) "G3:5:2",
        (object) "G3:5:3",
        (object) "G3:5:4",
        (object) "G3:5:5",
        (object) "G3:6:1",
        (object) "G3:6:2",
        (object) "G3:6:3",
        (object) "G3:6:4",
        (object) "G3:6:5",
        (object) "G4:1:1",
        (object) "G4:1:2",
        (object) "G4:1:3",
        (object) "G4:1:4",
        (object) "G4:2:1",
        (object) "G4:2:2",
        (object) "G4:2:3",
        (object) "G4:2:4",
        (object) "G4:3:1",
        (object) "G4:3:2",
        (object) "G4:3:3",
        (object) "G4:3:4",
        (object) "G4:4:1",
        (object) "G4:4:2",
        (object) "G4:4:3",
        (object) "G4:4:4",
        (object) "G5:1:1",
        (object) "G5:1:2",
        (object) "G5:1:3",
        (object) "G5:1:4",
        (object) "G5:2:1",
        (object) "G5:2:2",
        (object) "G5:2:3",
        (object) "G5:2:4",
        (object) "G5:3:1",
        (object) "G5:3:2",
        (object) "G5:3:3",
        (object) "G5:3:4",
        (object) "G5:4:1",
        (object) "G5:4:2",
        (object) "G5:4:3",
        (object) "G5:4:4",
        (object) "G5:5:1",
        (object) "G5:5:2",
        (object) "G5:5:3",
        (object) "G5:5:4",
        (object) "G5:6:1",
        (object) "G5:6:2",
        (object) "G5:6:3",
        (object) "G5:6:4",
        (object) "G6:1:1",
        (object) "G6:1:2",
        (object) "G6:1:3",
        (object) "G6:2:1",
        (object) "G6:2:2",
        (object) "G6:2:3",
        (object) "G6:3:1",
        (object) "G6:3:2",
        (object) "G6:3:3",
        (object) "G7:1:1",
        (object) "G7:1:2",
        (object) "G7:2:1",
        (object) "G7:2:2",
        (object) "G7:3:1",
        (object) "G7:3:2",
        (object) "G7:4:1",
        (object) "G7:4:2"
      });
      this.cbbVitri1.Location = new Point(319, 13);
      this.cbbVitri1.MaxDropDownItems = 15;
      this.cbbVitri1.Name = "cbbVitri1";
      this.cbbVitri1.Size = new Size(70, 23);
      this.cbbVitri1.TabIndex = 45;
      this.cbbLoto.BackColor = Color.Teal;
      this.cbbLoto.Cursor = Cursors.Hand;
      this.cbbLoto.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbLoto.FlatStyle = FlatStyle.Popup;
      this.cbbLoto.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.cbbLoto.ForeColor = Color.White;
      this.cbbLoto.FormattingEnabled = true;
      this.cbbLoto.Items.AddRange(new object[4]
      {
        (object) "Cầu chạm (Chính bóng)",
        (object) "Cầu chạm (Chạm bóng)",
        (object) "Cầu tổng (Chính bóng)",
        (object) "Cầu tổng (Tổng bóng)"
      });
      this.cbbLoto.Location = new Point(556, 13);
      this.cbbLoto.Name = "cbbLoto";
      this.cbbLoto.Size = new Size(123, 23);
      this.cbbLoto.TabIndex = 47;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.DarkSlateGray;
      this.label10.Location = new Point(793, 17);
      this.label10.Name = "label10";
      this.label10.Size = new Size(29, 16);
      this.label10.TabIndex = 51;
      this.label10.Text = "tiến";
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.DarkSlateGray;
      this.label11.Location = new Point(275, 17);
      this.label11.Name = "label11";
      this.label11.Size = new Size(42, 16);
      this.label11.TabIndex = 52;
      this.label11.Text = "Vị trí I";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.DarkSlateGray;
      this.label12.Location = new Point(727, 17);
      this.label12.Name = "label12";
      this.label12.Size = new Size(21, 16);
      this.label12.TabIndex = 53;
      this.label12.Text = "lùi";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.DarkSlateGray;
      this.label14.Location = new Point(527, 17);
      this.label14.Name = "label14";
      this.label14.Size = new Size(28, 16);
      this.label14.TabIndex = 54;
      this.label14.Text = "loại";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.groupBox1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabSoicaugiaidacbiet);
      this.Size = new Size(1100, 554);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numTien.EndInit();
      this.numLui.EndInit();
      this.ResumeLayout(false);
    }
  }
}
