// Decompiled with JetBrains decompiler
// Type: ns1.BunifuCards
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using Bunifu.Framework.Lib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DebuggerStepThrough]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuCards : Panel
  {
    private int int_0 = 5;
    private int int_1 = 20;
    private IContainer icontainer_0;
    private PictureBox topLine;
    private PictureBox BottomLine;
    private PictureBox leftLine;
    private PictureBox rightLine;

    public BunifuCards()
    {
      this.InitializeComponent();
      this.Controls.Add((Control) this.topLine);
      this.topLine.Dock = DockStyle.Top;
      this.topLine.Height = 5;
      this.topLine.BackColor = Color.Tomato;
      this.Controls.Add((Control) this.BottomLine);
      this.BottomLine.Dock = DockStyle.Bottom;
      this.BottomLine.Height = 3;
      this.Controls.Add((Control) this.leftLine);
      this.leftLine.Dock = DockStyle.Left;
      this.leftLine.Width = 2;
      this.Controls.Add((Control) this.rightLine);
      this.rightLine.Dock = DockStyle.Right;
      this.rightLine.Width = 2;
      this.topLine.BringToFront();
      Elipse.Apply((Control) this, this.BorderRadius);
      this.method_0();
    }

    public Color color
    {
      get
      {
        return this.topLine.BackColor;
      }
      set
      {
        this.topLine.BackColor = value;
      }
    }

    public int BorderRadius
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        Elipse.Apply((Control) this, this.int_0);
      }
    }

    public bool RightSahddow
    {
      get
      {
        return this.rightLine.Visible;
      }
      set
      {
        this.rightLine.Visible = value;
      }
    }

    public bool LeftSahddow
    {
      get
      {
        return this.leftLine.Visible;
      }
      set
      {
        this.leftLine.Visible = value;
      }
    }

    public bool BottomSahddow
    {
      get
      {
        return this.BottomLine.Visible;
      }
      set
      {
        this.BottomLine.Visible = value;
      }
    }

    public int ShadowDepth
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
        this.method_0();
      }
    }

    private void BunifuCards_BackColorChanged(object sender, EventArgs e)
    {
      this.method_0();
    }

    private void method_0()
    {
      int r = (int) this.BackColor.R;
      int red = r - this.int_1 < 0 ? 0 : r - this.int_1;
      int g = (int) this.BackColor.G;
      int green = g - this.int_1 < 0 ? 0 : g - this.int_1;
      int b = (int) this.BackColor.B;
      int blue = b - this.int_1 < 0 ? 0 : b - this.int_1;
      this.BottomLine.BackColor = Color.FromArgb(red, green, blue);
    }

    private void BunifuCards_Resize(object sender, EventArgs e)
    {
      Elipse.Apply((Control) this, this.int_0);
    }

    private void BottomLine_BackColorChanged(object sender, EventArgs e)
    {
      this.leftLine.BackColor = this.rightLine.BackColor = this.BottomLine.BackColor;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.topLine = new PictureBox();
      this.BottomLine = new PictureBox();
      this.leftLine = new PictureBox();
      this.rightLine = new PictureBox();
      ((ISupportInitialize) this.topLine).BeginInit();
      ((ISupportInitialize) this.BottomLine).BeginInit();
      ((ISupportInitialize) this.leftLine).BeginInit();
      ((ISupportInitialize) this.rightLine).BeginInit();
      this.SuspendLayout();
      this.topLine.Location = new Point(0, 0);
      this.topLine.Name = "topLine";
      this.topLine.Size = new Size(100, 50);
      this.topLine.TabIndex = 0;
      this.topLine.TabStop = false;
      this.BottomLine.Location = new Point(0, 0);
      this.BottomLine.Name = "BottomLine";
      this.BottomLine.Size = new Size(100, 50);
      this.BottomLine.TabIndex = 0;
      this.BottomLine.TabStop = false;
      this.BottomLine.BackColorChanged += new EventHandler(this.BottomLine_BackColorChanged);
      this.leftLine.Location = new Point(0, 0);
      this.leftLine.Name = "leftLine";
      this.leftLine.Size = new Size(100, 50);
      this.leftLine.TabIndex = 0;
      this.leftLine.TabStop = false;
      this.leftLine.Visible = false;
      this.rightLine.Location = new Point(0, 0);
      this.rightLine.Name = "rightLine";
      this.rightLine.Size = new Size(100, 50);
      this.rightLine.TabIndex = 0;
      this.rightLine.TabStop = false;
      this.BackColor = Color.White;
      this.Name = "BunifuPaperPanel";
      this.Size = new Size(605, 397);
      this.BackColorChanged += new EventHandler(this.BunifuCards_BackColorChanged);
      this.Resize += new EventHandler(this.BunifuCards_Resize);
      ((ISupportInitialize) this.topLine).EndInit();
      ((ISupportInitialize) this.BottomLine).EndInit();
      ((ISupportInitialize) this.leftLine).EndInit();
      ((ISupportInitialize) this.rightLine).EndInit();
      this.ResumeLayout(false);
    }
  }
}
