// Decompiled with JetBrains decompiler
// Type: ns1.BunifuTileButton
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DefaultEvent("Click")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  [DebuggerStepThrough]
  public class BunifuTileButton : UserControl
  {
    private int int_0 = 50;
    private Color color_0 = Color.SeaGreen;
    private Color color_1 = Color.MediumSeaGreen;
    private IContainer icontainer_0;
    private PictureBox img;
    private Label lbl;

    public BunifuTileButton()
    {
      this.InitializeComponent();
      Bunifu.Framework.License.Check((Control) this);
      this.method_0();
    }

    public Image Image
    {
      get
      {
        return this.img.Image;
      }
      set
      {
        this.img.Image = value;
      }
    }

    public string LabelText
    {
      get
      {
        return this.lbl.Text;
      }
      set
      {
        this.lbl.Text = value;
      }
    }

    public int LabelPosition
    {
      get
      {
        return this.lbl.Height;
      }
      set
      {
        this.lbl.Height = value;
      }
    }

    public int ImageZoom
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        this.method_0();
      }
    }

    public int ImagePosition
    {
      get
      {
        return this.img.Top;
      }
      set
      {
        this.img.Top = value;
        this.method_0();
      }
    }

    public Color color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.BackColor = this.color_0;
      }
    }

    public Color colorActive
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
      }
    }

    private void BunifuTileButton_Resize(object sender, EventArgs e)
    {
      this.method_0();
    }

    protected override void OnClick(EventArgs e)
    {
      this.BackColor = this.color_0;
      base.OnClick(e);
    }

    private void lbl_Click(object sender, EventArgs e)
    {
      this.BackColor = this.color_0;
      base.OnClick(e);
    }

    private void BunifuTileButton_MouseEnter(object sender, EventArgs e)
    {
      this.BackColor = this.color_1;
    }

    private void BunifuTileButton_MouseLeave(object sender, EventArgs e)
    {
      this.BackColor = this.color_0;
    }

    private void lbl_MouseLeave(object sender, EventArgs e)
    {
      this.BackColor = this.color_0;
    }

    private void lbl_MouseEnter(object sender, EventArgs e)
    {
      this.BackColor = this.color_1;
    }

    private void img_SizeChanged(object sender, EventArgs e)
    {
      this.method_0();
    }

    private void BunifuTileButton_FontChanged(object sender, EventArgs e)
    {
      this.lbl.Font = this.Font;
      this.method_0();
    }

    private void BunifuTileButton_ForeColorChanged(object sender, EventArgs e)
    {
      this.lbl.ForeColor = this.ForeColor;
    }

    private void method_0()
    {
      this.img.Width = int.Parse(Math.Round((double) this.Width / 100.0 * (double) this.int_0, 0).ToString());
      this.img.Height = this.img.Width;
      this.img.Left = this.Width / 2 - this.img.Width / 2;
    }

    private void BunifuTileButton_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BunifuTileButton));
      this.img = new PictureBox();
      this.lbl = new Label();
      ((ISupportInitialize) this.img).BeginInit();
      this.SuspendLayout();
      this.img.Cursor = Cursors.Hand;
      this.img.Enabled = false;
      this.img.Image = (Image) componentResourceManager.GetObject("img.Image");
      this.img.Location = new Point(33, 20);
      this.img.Margin = new Padding(6);
      this.img.Name = "img";
      this.img.Size = new Size(64, 56);
      this.img.SizeMode = PictureBoxSizeMode.Zoom;
      this.img.TabIndex = 0;
      this.img.TabStop = false;
      this.img.SizeChanged += new EventHandler(this.img_SizeChanged);
      this.lbl.Cursor = Cursors.Hand;
      this.lbl.Dock = DockStyle.Bottom;
      this.lbl.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbl.ForeColor = Color.White;
      this.lbl.Location = new Point(0, 88);
      this.lbl.Margin = new Padding(6, 0, 6, 0);
      this.lbl.Name = "lbl";
      this.lbl.Size = new Size(128, 41);
      this.lbl.TabIndex = 1;
      this.lbl.Text = "Tile 1";
      this.lbl.TextAlign = ContentAlignment.TopCenter;
      this.lbl.Click += new EventHandler(this.lbl_Click);
      this.lbl.MouseEnter += new EventHandler(this.lbl_MouseEnter);
      this.lbl.MouseLeave += new EventHandler(this.lbl_MouseLeave);
      this.AutoScaleDimensions = new SizeF(12f, 24f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.SeaGreen;
      this.Controls.Add((Control) this.lbl);
      this.Controls.Add((Control) this.img);
      this.Cursor = Cursors.Hand;
      this.Font = new Font("Century Gothic", 15.75f);
      this.ForeColor = Color.White;
      this.Margin = new Padding(6);
      this.Name = nameof (BunifuTileButton);
      this.Size = new Size(128, 129);
      this.Load += new EventHandler(this.BunifuTileButton_Load);
      this.FontChanged += new EventHandler(this.BunifuTileButton_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuTileButton_ForeColorChanged);
      this.MouseEnter += new EventHandler(this.BunifuTileButton_MouseEnter);
      this.MouseLeave += new EventHandler(this.BunifuTileButton_MouseLeave);
      this.Resize += new EventHandler(this.BunifuTileButton_Resize);
      ((ISupportInitialize) this.img).EndInit();
      this.ResumeLayout(false);
    }
  }
}
