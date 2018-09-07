// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabBangvang
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabBangvang : UserControl
  {
    private IContainer components = (IContainer) null;
    private Panel panel2;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private Label label4;
    private Panel panel3;
    private Label label3;
    private Panel panel4;
    private Label label2;
    private Panel panel5;
    private Label label1;
    private Panel panel6;

    public TabBangvang()
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
      this.panel2 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel1 = new Panel();
      this.panel3 = new Panel();
      this.panel4 = new Panel();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.panel5 = new Panel();
      this.label4 = new Label();
      this.panel6 = new Panel();
      this.panel2.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel5.SuspendLayout();
      this.SuspendLayout();
      this.panel2.Controls.Add((Control) this.panel6);
      this.panel2.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1155, 590);
      this.panel2.TabIndex = 1;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel4, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel5, 1, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Bottom;
      this.tableLayoutPanel1.Location = new Point(0, 114);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Size = new Size(1155, 476);
      this.tableLayoutPanel1.TabIndex = 0;
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(571, 232);
      this.panel1.TabIndex = 0;
      this.panel3.Controls.Add((Control) this.label3);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 241);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(571, 232);
      this.panel3.TabIndex = 1;
      this.panel4.Controls.Add((Control) this.label2);
      this.panel4.Dock = DockStyle.Fill;
      this.panel4.Location = new Point(580, 3);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(572, 232);
      this.panel4.TabIndex = 3;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(262, 45);
      this.label1.Name = "label1";
      this.label1.Size = new Size(105, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "TOP ĐẦU TƯ LOTO";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(262, 48);
      this.label2.Name = "label2";
      this.label2.Size = new Size(73, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "TOP ĐẦU TƯ";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(237, 35);
      this.label3.Name = "label3";
      this.label3.Size = new Size(123, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "DANH SÁCH DỰ ĐOÁN";
      this.panel5.Controls.Add((Control) this.label1);
      this.panel5.Dock = DockStyle.Fill;
      this.panel5.Location = new Point(580, 241);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(572, 232);
      this.panel5.TabIndex = 4;
      this.label4.AutoSize = true;
      this.label4.Location = new Point((int) byte.MaxValue, 48);
      this.label4.Name = "label4";
      this.label4.Size = new Size(71, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "TOP ĐẠI GIA";
      this.panel6.Dock = DockStyle.Bottom;
      this.panel6.Location = new Point(0, 3);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(1155, 111);
      this.panel6.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel2);
      this.Name = nameof (TabBangvang);
      this.Size = new Size(1155, 590);
      this.panel2.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
