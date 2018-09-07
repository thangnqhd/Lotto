// Decompiled with JetBrains decompiler
// Type: ns1.BunifuMaterialTextbox
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
  public class BunifuMaterialTextbox : UserControl
  {
    private Color color_0 = Color.Gray;
    private Color color_1 = Color.Blue;
    private Color color_2 = Color.Blue;
    private string string_0 = "";
    private Color color_3;
    private bool bool_0;
    private bool bool_1;
    private IContainer icontainer_0;
    private TextBox textBox1;
    private Timer timer_0;
    private Panel panel1;
    private PictureBox line;

    public BunifuMaterialTextbox()
    {
      this.InitializeComponent();
    }

    public int LineThickness
    {
      get
      {
        return this.line.Height;
      }
      set
      {
        if (value <= 0)
          throw new Exception("Value shoud be grater than 0");
        this.line.Height = value;
      }
    }

    public Color LineIdleColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.Refresh();
      }
    }

    public Color LineMouseHoverColor
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

    public Color LineFocusedColor
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

    private void BunifuMaterialTextbox_Resize(object sender, EventArgs e)
    {
      if (this.Height < this.textBox1.Height + 5)
        this.Height = this.textBox1.Height + 5;
      this.Refresh();
    }

    public new void Refresh()
    {
      if (this.isOnFocused)
        this.line.BackColor = this.color_1;
      else
        this.line.BackColor = this.LineIdleColor;
    }

    public Color HintForeColor
    {
      get
      {
        return this.color_3;
      }
      set
      {
        this.color_3 = value;
        if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
        {
          this.textBox1.ForeColor = this.ForeColor;
        }
        else
        {
          this.textBox1.ForeColor = this.HintForeColor;
          this.textBox1.Text = this.HintText;
        }
      }
    }

    public string HintText
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
        if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
        {
          this.textBox1.ForeColor = this.ForeColor;
        }
        else
        {
          this.textBox1.ForeColor = this.HintForeColor;
          this.textBox1.Text = this.HintText;
        }
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }

    private void BunifuMaterialTextbox_BackColorChanged(object sender, EventArgs e)
    {
      this.textBox1.BackColor = this.BackColor;
    }

    private void BunifuMaterialTextbox_FontChanged(object sender, EventArgs e)
    {
      this.textBox1.Font = this.Font;
      this.textBox1.Left = 5;
      this.textBox1.Width = this.Width - this.textBox1.Left * 2;
      this.textBox1.Top = this.Height / 2 - this.textBox1.Height / 2;
    }

    private void BunifuMaterialTextbox_ForeColorChanged(object sender, EventArgs e)
    {
      this.textBox1.ForeColor = this.ForeColor;
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    public override string Text
    {
      get
      {
        if (this.textBox1.Text != this.HintText)
          return this.textBox1.Text;
        return "";
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
        this.bool_0 = this.textBox1.UseSystemPasswordChar;
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

    private void BunifuMaterialTextbox_Click(object sender, EventArgs e)
    {
      this.textBox1.Focus();
    }

    private void BunifuMaterialTextbox_MouseEnter(object sender, EventArgs e)
    {
    }

    private void BunifuMaterialTextbox_MouseLeave(object sender, EventArgs e)
    {
    }

    private void BunifuMaterialTextbox_ParentChanged(object sender, EventArgs e)
    {
    }

    public bool isOnFocused
    {
      get
      {
        return this.textBox1 == this.ActiveControl;
      }
    }

    private void method_1(object sender, EventArgs e)
    {
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
                this.line.BackColor = this.LineFocusedColor;
                if (this.textBox1.Text == this.HintText)
                {
                  this.textBox1.Text = "";
                  goto label_16;
                }
                else
                  goto label_16;
              }
              else
              {
                this.line.BackColor = this.LineMouseHoverColor;
                goto label_16;
              }
            }
          }
        }
      }
      if (this.isOnFocused)
      {
        this.line.BackColor = this.LineFocusedColor;
      }
      else
      {
        this.line.BackColor = this.LineIdleColor;
        if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
        {
          this.textBox1.ForeColor = this.ForeColor;
          if (this.bool_0)
          {
            this.textBox1.UseSystemPasswordChar = true;
            this.bool_0 = false;
          }
        }
        else if (!this.textBox1.Focused)
        {
          this.textBox1.ForeColor = this.HintForeColor;
          this.textBox1.Text = this.HintText;
          if (this.isPassword)
          {
            this.textBox1.UseSystemPasswordChar = false;
            this.bool_0 = true;
          }
        }
      }
label_16:
      this.timer_0.Start();
    }

    private void BunifuMaterialTextbox_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        this.timer_0.Start();
      if (this.DesignMode)
        Bunifu.Framework.License.Check((Control) this);
      if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
      {
        this.textBox1.ForeColor = this.ForeColor;
      }
      else
      {
        this.textBox1.ForeColor = this.HintForeColor;
        this.textBox1.Text = this.HintText;
      }
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
      this.panel1 = new Panel();
      this.line = new PictureBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.line).BeginInit();
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
      this.panel1.BackColor = Color.Gray;
      this.panel1.Controls.Add((Control) this.line);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 41);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(370, 3);
      this.panel1.TabIndex = 1;
      this.line.BackColor = Color.Gray;
      this.line.Dock = DockStyle.Bottom;
      this.line.Enabled = false;
      this.line.Location = new Point(0, 0);
      this.line.Name = "line";
      this.line.Size = new Size(370, 3);
      this.line.TabIndex = 2;
      this.line.TabStop = false;
      this.AutoScaleDimensions = new SizeF(8f, 17f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.textBox1);
      this.Cursor = Cursors.IBeam;
      this.Font = new Font("Century Gothic", 9.75f);
      this.ForeColor = Color.FromArgb(64, 64, 64);
      this.Margin = new Padding(4);
      this.Name = nameof (BunifuMaterialTextbox);
      this.Size = new Size(370, 44);
      this.Load += new EventHandler(this.BunifuMaterialTextbox_Load);
      this.BackColorChanged += new EventHandler(this.BunifuMaterialTextbox_BackColorChanged);
      this.FontChanged += new EventHandler(this.BunifuMaterialTextbox_FontChanged);
      this.ForeColorChanged += new EventHandler(this.BunifuMaterialTextbox_ForeColorChanged);
      this.Click += new EventHandler(this.BunifuMaterialTextbox_Click);
      this.MouseEnter += new EventHandler(this.BunifuMaterialTextbox_MouseEnter);
      this.MouseLeave += new EventHandler(this.BunifuMaterialTextbox_MouseLeave);
      this.Resize += new EventHandler(this.BunifuMaterialTextbox_Resize);
      this.ParentChanged += new EventHandler(this.BunifuMaterialTextbox_ParentChanged);
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.line).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
