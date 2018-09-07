// Decompiled with JetBrains decompiler
// Type: ns1.BunifuMetroTextbox
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
  [DefaultEvent("OnValueChanged")]
  [ProvideProperty("BunifuFramework", typeof (Control))]
  public class BunifuMetroTextbox : UserControl
  {
    private int int_0 = 3;
    private Color color_0 = Color.FromArgb(64, 64, 64);
    private Color color_1 = Color.Blue;
    private Color color_2 = Color.Blue;
    private Color color_3 = Color.SeaGreen;
    private Color color_4 = Color.SeaGreen;
    private Graphics graphics_0;
    private bool bool_0;
    private IContainer icontainer_0;
    private TextBox textBox1;
    private Timer timer_0;

    public BunifuMetroTextbox()
    {
      this.InitializeComponent();
    }

    public int BorderThickness
    {
      get
      {
        return this.int_0;
      }
      set
      {
        if (value <= 0)
          throw new Exception("Value shoud be grater than 0");
        this.int_0 = value;
        this.Refresh();
      }
    }

    public Color BorderColorIdle
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        if (this.DesignMode)
          this.color_3 = value;
        this.Refresh();
      }
    }

    public Color BorderColorFocused
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
        this.Refresh();
      }
    }

    public Color BorderColorMouseHover
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
        this.Refresh();
      }
    }

    private void BunifuMetroTextbox_Resize(object sender, EventArgs e)
    {
      if (this.Height < this.textBox1.Height + this.int_0 * 2)
        this.Height = this.textBox1.Height + this.int_0 * 3;
      this.Refresh();
    }

    public new void Refresh()
    {
      if (!(this.color_3 != this.color_4))
        return;
      this.graphics_0 = this.CreateGraphics();
      this.graphics_0.Clear(this.BackColor);
      this.graphics_0.DrawRectangle(new Pen(this.color_3, (float) this.int_0), new Rectangle(this.int_0, this.int_0, this.Width - this.int_0 * 2, this.Height - this.int_0 * 2));
      this.color_4 = this.color_3;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      this.color_3 = this.BorderColorIdle;
      this.graphics_0 = this.CreateGraphics();
      this.graphics_0.Clear(this.BackColor);
      this.graphics_0.DrawRectangle(new Pen(this.color_3, (float) this.int_0), new Rectangle(this.int_0, this.int_0, this.Width - this.int_0 * 2, this.Height - this.int_0 * 2));
      base.OnPaint(e);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }

    private void BunifuMetroTextbox_BackColorChanged(object sender, EventArgs e)
    {
      this.textBox1.BackColor = this.BackColor;
    }

    private void BunifuMetroTextbox_FontChanged(object sender, EventArgs e)
    {
      this.textBox1.Font = this.Font;
      this.textBox1.Left = this.int_0 + 5;
      this.textBox1.Width = this.Width - this.textBox1.Left * 2;
      this.textBox1.Top = this.Height / 2 - this.textBox1.Height / 2;
    }

    private void BunifuMetroTextbox_ForeColorChanged(object sender, EventArgs e)
    {
      this.textBox1.ForeColor = this.ForeColor;
    }

    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    public override string Text
    {
      get
      {
        return this.textBox1.Text;
      }
      set
      {
        this.textBox1.Text = value;
      }
    }

    public HorizontalAlignment TextAlign
    {
      get
      {
        return this.textBox1.TextAlign;
      }
      set
      {
        this.textBox1.TextAlign = value;
      }
    }

    public event EventHandler OnValueChanged;

    public bool isPassword
    {
      get
      {
        return this.textBox1.UseSystemPasswordChar;
      }
      set
      {
        this.textBox1.UseSystemPasswordChar = value;
      }
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      this.OnKeyDown(e);
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.OnKeyPress(e);
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
      this.OnKeyUp(e);
    }

    private void textBox1_MouseEnter(object sender, EventArgs e)
    {
      this.OnMouseEnter(e);
    }

    private void method_0(object sender, EventArgs e)
    {
      this.OnMouseLeave(e);
    }

    private void BunifuMetroTextbox_Click(object sender, EventArgs e)
    {
      this.textBox1.Focus();
    }

    private void BunifuMetroTextbox_MouseEnter(object sender, EventArgs e)
    {
    }

    private void BunifuMetroTextbox_MouseLeave(object sender, EventArgs e)
    {
    }

    private void method_1(object sender, EventArgs e)
    {
      this.textBox1.Text = "";
      this.textBox1.Focus();
    }

    private void method_2(object sender, EventArgs e)
    {
      this.OnMouseEnter(e);
    }

    private void BunifuMetroTextbox_ParentChanged(object sender, EventArgs e)
    {
    }

    public bool isOnFocused
    {
      get
      {
        return this.textBox1 == this.ActiveControl;
      }
    }

    private void BunifuMetroTextbox_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        this.timer_0.Start();
      if (!this.DesignMode)
        return;
      Bunifu.Framework.License.Check((Control) this);
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      this.timer_0.Start();
      Point screen = this.PointToScreen(Point.Empty);
      if (Control.MousePosition.X > screen.X)
      {
        Point mousePosition = Control.MousePosition;
        if (mousePosition.X < screen.X + this.Width)
        {
          mousePosition = Control.MousePosition;
          if (mousePosition.Y > screen.Y)
          {
            mousePosition = Control.MousePosition;
            if (mousePosition.Y < screen.Y + this.Height)
            {
              if (this.isOnFocused)
              {
                this.color_3 = this.BorderColorFocused;
                this.Refresh();
                goto label_10;
              }
              else
              {
                this.color_3 = this.BorderColorMouseHover;
                this.Refresh();
                goto label_10;
              }
            }
          }
        }
      }
      if (this.isOnFocused)
      {
        this.color_3 = this.BorderColorFocused;
        this.Refresh();
      }
      else
      {
        this.color_3 = this.BorderColorIdle;
        this.Refresh();
      }
label_10:
      this.timer_0.Start();
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
      this.textBox1 = new TextBox();
      this.timer_0 = new Timer(this.icontainer_0);
      this.SuspendLayout();
      this.textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.textBox1.BackColor = SystemColors.Control;
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.ForeColor = Color.FromArgb(64, 64, 64);
      this.textBox1.Location = new Point(8, 15);
      this.textBox1.Margin = new Padding(4);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(353, 16);
      this.textBox1.TabIndex = 0;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox1.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
      this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
      this.textBox1.KeyUp += new KeyEventHandler(this.textBox1_KeyUp);
      this.textBox1.MouseEnter += new EventHandler(this.textBox1_MouseEnter);
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.AutoScaleDimensions = new SizeF(8f, 17f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.textBox1);
      this.Cursor = Cursors.IBeam;
      this.Font = new Font("Century Gothic", 9.75f);
      this.ForeColor = Color.FromArgb(64, 64, 64);
      this.Margin = new Padding(4);
      this.Name = nameof (BunifuMetroTextbox);
      this.Size = new Size(370, 44);
      this.Load += new EventHandler(this.BunifuMetroTextbox_Load);
      this.BackColorChanged += new EventHandler(this.BunifuMetroTextbox_BackColorChanged);
      this.FontChanged += new EventHandler(this.BunifuMetroTextbox_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuMetroTextbox_ForeColorChanged);
      this.Click += new EventHandler(this.BunifuMetroTextbox_Click);
      this.MouseEnter += new EventHandler(this.BunifuMetroTextbox_MouseEnter);
      this.MouseLeave += new EventHandler(this.BunifuMetroTextbox_MouseLeave);
      this.Resize += new EventHandler(this.BunifuMetroTextbox_Resize);
      this.ParentChanged += new EventHandler(this.BunifuMetroTextbox_ParentChanged);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
