// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabGepDanDacBiet
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ns1;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabGepDanDacBiet : UserControl
  {
    private IContainer components = (IContainer) null;
    private BunifuElipse bunifuElipse1;
    private Panel panel1;
    private Label label6;
    private Panel panel3;
    private Panel pnDan;

    public TabGepDanDacBiet()
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
      this.components = (IContainer) new Container();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.panel1 = new Panel();
      this.label6 = new Label();
      this.pnDan = new Panel();
      this.panel3 = new Panel();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.panel1.BackColor = Color.White;
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 423);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 29);
      this.panel1.TabIndex = 25;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Red;
      this.label6.Location = new Point(10, 7);
      this.label6.Name = "label6";
      this.label6.Size = new Size(980, 15);
      this.label6.TabIndex = 20;
      this.label6.Text = "Chức năng này cho phép bạn gép 2 hay nhiều dàn bất kỳ để lấy ra những con số trùng nhau hoặc loại những con trùng nhau từ các dàn bạn biết tỷ lệ cao là về, hoặc không về";
      this.pnDan.Dock = DockStyle.Top;
      this.pnDan.Location = new Point(0, 0);
      this.pnDan.Name = "pnDan";
      this.pnDan.Size = new Size(1100, 174);
      this.pnDan.TabIndex = 26;
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(0, 174);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1100, 249);
      this.panel3.TabIndex = 27;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.pnDan);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabGepDanDacBiet);
      this.Size = new Size(1100, 452);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
