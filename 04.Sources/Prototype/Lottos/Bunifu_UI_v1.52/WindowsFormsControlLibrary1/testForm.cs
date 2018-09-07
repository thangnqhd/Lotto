// Decompiled with JetBrains decompiler
// Type: WindowsFormsControlLibrary1.testForm
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using ns1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
  public class testForm : Form
  {
    private int int_0 = 1;
    private Drag drag_0 = new Drag();
    private bool bool_0;
    private IContainer icontainer_0;
    private BunifuMetroTextbox bunifuMetroTextbox_0;
    private BunifuTrackbar bunifuTrackbar_0;
    private BunifuVTrackbar bunifuVTrackbar_0;
    private Label label1;
    private BunifuVTrackbar bunifuVTrackbar2;
    private BunifuGauge bunifuGauge1;
    private Button button1;
    private System.Windows.Forms.Timer timer_0;
    private BackgroundWorker backgroundWorker_0;
    private Panel panel1;
    private BunifuMaterialTextbox bunifuMaterialTextbox1;
    private BunifuMaterialTextbox bunifuMaterialTextbox2;
    private BunifuDropdown bunifuDropdown1;
    private BunifuThinButton2 bunifuThinButton21;
    private BunifuFormFadeTransition bunifuFormFadeTransition_0;

    public testForm()
    {
      this.InitializeComponent();
    }

    private void method_0(object sender, EventArgs e)
    {
    }

    private void testForm_Paint(object sender, PaintEventArgs e)
    {
    }

    private void method_1(object sender, PaintEventArgs e)
    {
    }

    private void method_2(object sender, EventArgs e)
    {
      this.Close();
    }

    private void method_3(object sender, EventArgs e)
    {
    }

    private void method_4(object sender, EventArgs e)
    {
    }

    private void method_5(object sender, EventArgs e)
    {
    }

    private void method_6(object sender, EventArgs e)
    {
    }

    private void method_7(object sender, EventArgs e)
    {
    }

    private void method_8(object sender, EventArgs e)
    {
    }

    private void method_9(object sender, EventArgs e)
    {
    }

    private void method_10(object sender, EventArgs e)
    {
    }

    private void testForm_Load(object sender, EventArgs e)
    {
    }

    private void method_11(object sender, EventArgs e)
    {
    }

    private void method_12(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Hello World");
    }

    private void method_13(object sender, EventArgs e)
    {
    }

    private void method_14(object sender, EventArgs e)
    {
    }

    private void method_15(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Yeeeeah");
    }

    private void method_16(object sender, EventArgs e)
    {
    }

    private void method_17(object sender, MouseEventArgs e)
    {
      this.drag_0.Grab((Control) sender);
    }

    private void method_18(object sender, MouseEventArgs e)
    {
      this.drag_0.Release();
    }

    private void bunifuVTrackbar2_ValueChanged(object sender, EventArgs e)
    {
      this.label1.Text = this.bunifuVTrackbar2.Value.ToString();
    }

    private void bunifuGauge1_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.bunifuFormFadeTransition_0.ShowAsyc((Form) this);
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      this.panel1.Width = 250;
      this.panel1.Height = 250;
      try
      {
        this.backgroundWorker_0.RunWorkerAsync();
      }
      catch (Exception ex)
      {
        this.backgroundWorker_0.CancelAsync();
      }
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
      int width = this.panel1.Width;
      while (this.panel1.Width > 10)
      {
        Thread.Sleep(1);
        this.backgroundWorker_0.ReportProgress(width);
        --width;
      }
    }

    private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.panel1.Width = e.ProgressPercentage;
      this.panel1.Height = e.ProgressPercentage;
    }

    private void bunifuThinButton21_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Clicked");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.icontainer_0 = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (testForm));
      this.label1 = new Label();
      this.button1 = new Button();
      this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
      this.backgroundWorker_0 = new BackgroundWorker();
      this.panel1 = new Panel();
      this.bunifuThinButton21 = new BunifuThinButton2();
      this.bunifuDropdown1 = new BunifuDropdown();
      this.bunifuMaterialTextbox2 = new BunifuMaterialTextbox();
      this.bunifuMaterialTextbox1 = new BunifuMaterialTextbox();
      this.bunifuGauge1 = new BunifuGauge();
      this.bunifuVTrackbar2 = new BunifuVTrackbar();
      this.bunifuFormFadeTransition_0 = new BunifuFormFadeTransition(this.icontainer_0);
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(40, 539);
      this.label1.Name = "label1";
      this.label1.Size = new Size(35, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "label1";
      this.button1.Location = new Point(199, 312);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 4;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.backgroundWorker_0.WorkerReportsProgress = true;
      this.backgroundWorker_0.WorkerSupportsCancellation = true;
      this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
      this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
      this.panel1.BackColor = Color.Indigo;
      this.panel1.Location = new Point(669, 312);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(409, (int) byte.MaxValue);
      this.panel1.TabIndex = 6;
      this.bunifuThinButton21.ActiveBorderThickness = 1;
      this.bunifuThinButton21.ActiveCornerRadius = 20;
      this.bunifuThinButton21.ActiveFillColor = Color.SpringGreen;
      this.bunifuThinButton21.ActiveForecolor = Color.White;
      this.bunifuThinButton21.ActiveLineColor = Color.SkyBlue;
      this.bunifuThinButton21.BackColor = Color.White;
      this.bunifuThinButton21.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
      this.bunifuThinButton21.ButtonText = "ThinButton";
      this.bunifuThinButton21.Cursor = Cursors.Hand;
      this.bunifuThinButton21.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bunifuThinButton21.ForeColor = Color.SeaGreen;
      this.bunifuThinButton21.IdleBorderThickness = 1;
      this.bunifuThinButton21.IdleCornerRadius = 20;
      this.bunifuThinButton21.IdleFillColor = Color.White;
      this.bunifuThinButton21.IdleForecolor = Color.SlateBlue;
      this.bunifuThinButton21.IdleLineColor = Color.SteelBlue;
      this.bunifuThinButton21.Location = new Point(359, 347);
      this.bunifuThinButton21.Margin = new Padding(5);
      this.bunifuThinButton21.Name = "bunifuThinButton21";
      this.bunifuThinButton21.Size = new Size(147, 46);
      this.bunifuThinButton21.TabIndex = 10;
      this.bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
      this.bunifuThinButton21.Click += new EventHandler(this.bunifuThinButton21_Click);
      this.bunifuDropdown1.BackColor = Color.Transparent;
      this.bunifuDropdown1.BorderRadius = 5;
      this.bunifuDropdown1.ForeColor = Color.White;
      this.bunifuDropdown1.Items = new string[3]
      {
        "All",
        "Male",
        "Female"
      };
      this.bunifuDropdown1.Location = new Point(199, 68);
      this.bunifuDropdown1.Name = "bunifuDropdown1";
      this.bunifuDropdown1.NomalColor = Color.Indigo;
      this.bunifuDropdown1.onHoverColor = Color.Indigo;
      this.bunifuDropdown1.selectedIndex = 0;
      this.bunifuDropdown1.Size = new Size(217, 35);
      this.bunifuDropdown1.TabIndex = 9;
      this.bunifuMaterialTextbox2.Cursor = Cursors.IBeam;
      this.bunifuMaterialTextbox2.Font = new Font("Century Gothic", 9.75f);
      this.bunifuMaterialTextbox2.ForeColor = Color.FromArgb(64, 64, 64);
      this.bunifuMaterialTextbox2.HintForeColor = Color.Silver;
      this.bunifuMaterialTextbox2.HintText = "Password";
      this.bunifuMaterialTextbox2.isPassword = true;
      this.bunifuMaterialTextbox2.LineFocusedColor = Color.Indigo;
      this.bunifuMaterialTextbox2.LineIdleColor = Color.Gray;
      this.bunifuMaterialTextbox2.LineMouseHoverColor = Color.Indigo;
      this.bunifuMaterialTextbox2.LineThickness = 3;
      this.bunifuMaterialTextbox2.Location = new Point(617, 143);
      this.bunifuMaterialTextbox2.Margin = new Padding(4);
      this.bunifuMaterialTextbox2.Name = "bunifuMaterialTextbox2";
      this.bunifuMaterialTextbox2.Size = new Size(370, 44);
      this.bunifuMaterialTextbox2.TabIndex = 8;
      this.bunifuMaterialTextbox2.TextAlign = HorizontalAlignment.Left;
      this.bunifuMaterialTextbox1.Cursor = Cursors.IBeam;
      this.bunifuMaterialTextbox1.Font = new Font("Century Gothic", 9.75f);
      this.bunifuMaterialTextbox1.ForeColor = Color.FromArgb(64, 64, 64);
      this.bunifuMaterialTextbox1.HintForeColor = Color.Maroon;
      this.bunifuMaterialTextbox1.HintText = "Username or Email";
      this.bunifuMaterialTextbox1.isPassword = false;
      this.bunifuMaterialTextbox1.LineFocusedColor = Color.Indigo;
      this.bunifuMaterialTextbox1.LineIdleColor = Color.Gray;
      this.bunifuMaterialTextbox1.LineMouseHoverColor = Color.Indigo;
      this.bunifuMaterialTextbox1.LineThickness = 3;
      this.bunifuMaterialTextbox1.Location = new Point(617, 47);
      this.bunifuMaterialTextbox1.Margin = new Padding(4);
      this.bunifuMaterialTextbox1.Name = "bunifuMaterialTextbox1";
      this.bunifuMaterialTextbox1.Size = new Size(370, 44);
      this.bunifuMaterialTextbox1.TabIndex = 7;
      this.bunifuMaterialTextbox1.TextAlign = HorizontalAlignment.Left;
      this.bunifuGauge1.BackgroundImage = (Image) componentResourceManager.GetObject("bunifuGauge1.BackgroundImage");
      this.bunifuGauge1.Font = new Font("Century Gothic", 15.75f);
      this.bunifuGauge1.Location = new Point(171, 143);
      this.bunifuGauge1.Margin = new Padding(6);
      this.bunifuGauge1.Name = "bunifuGauge1";
      this.bunifuGauge1.ProgressBgColor = Color.Gray;
      this.bunifuGauge1.ProgressColor1 = Color.SeaGreen;
      this.bunifuGauge1.ProgressColor2 = Color.Tomato;
      this.bunifuGauge1.Size = new Size(174, 117);
      this.bunifuGauge1.TabIndex = 3;
      this.bunifuGauge1.Thickness = 30;
      this.bunifuGauge1.Value = 0;
      this.bunifuGauge1.Load += new EventHandler(this.bunifuGauge1_Load);
      this.bunifuVTrackbar2.BackColor = Color.Transparent;
      this.bunifuVTrackbar2.BackgroudColor = Color.DarkGray;
      this.bunifuVTrackbar2.BorderRadius = 0;
      this.bunifuVTrackbar2.IndicatorColor = Color.Indigo;
      this.bunifuVTrackbar2.Location = new Point(47, 99);
      this.bunifuVTrackbar2.MaximumValue = 100;
      this.bunifuVTrackbar2.Name = "bunifuVTrackbar2";
      this.bunifuVTrackbar2.Size = new Size(28, 415);
      this.bunifuVTrackbar2.SliderRadius = 5;
      this.bunifuVTrackbar2.TabIndex = 2;
      this.bunifuVTrackbar2.Value = 50;
      this.bunifuVTrackbar2.ValueChanged += new EventHandler(this.bunifuVTrackbar2_ValueChanged);
      this.bunifuFormFadeTransition_0.Delay = 1;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1079, 579);
      this.Controls.Add((Control) this.bunifuThinButton21);
      this.Controls.Add((Control) this.bunifuDropdown1);
      this.Controls.Add((Control) this.bunifuMaterialTextbox2);
      this.Controls.Add((Control) this.bunifuMaterialTextbox1);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.bunifuGauge1);
      this.Controls.Add((Control) this.bunifuVTrackbar2);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (testForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Load += new EventHandler(this.testForm_Load);
      this.Paint += new PaintEventHandler(this.testForm_Paint);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
