// Decompiled with JetBrains decompiler
// Type: Tulpep.NotificationWindow.PopupNotifierForm
// Assembly: Tulpep.NotificationWindow, Version=1.1.23.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F7EA38A-495D-44BC-8CE0-9C79F35F4AD3
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Tulpep.NotificationWindow.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Tulpep.NotificationWindow.Properties;

namespace Tulpep.NotificationWindow
{
  internal class PopupNotifierForm : Form
  {
    private bool mouseOnClose;
    private bool mouseOnLink;
    private bool mouseOnOptions;
    private int heightOfTitle;
    private bool gdiInitialized;
    private Rectangle rcBody;
    private Rectangle rcHeader;
    private Rectangle rcForm;
    private LinearGradientBrush brushBody;
    private LinearGradientBrush brushHeader;
    private Brush brushButtonHover;
    private Pen penButtonBorder;
    private Pen penContent;
    private Pen penBorder;
    private Brush brushForeColor;
    private Brush brushLinkHover;
    private Brush brushContent;
    private Brush brushTitle;

    protected override bool ShowWithoutActivation
    {
      get
      {
        return true;
      }
    }

    protected override CreateParams CreateParams
    {
      get
      {
        int num = 8;
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= num;
        return createParams;
      }
    }

    public event EventHandler LinkClick;

    public event EventHandler CloseClick;

    internal event EventHandler ContextMenuOpened;

    internal event EventHandler ContextMenuClosed;

    public PopupNotifierForm(PopupNotifier parent)
    {
      this.Parent = parent;
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.ShowInTaskbar = false;
      this.VisibleChanged += new EventHandler(this.PopupNotifierForm_VisibleChanged);
      this.MouseMove += new MouseEventHandler(this.PopupNotifierForm_MouseMove);
      this.MouseUp += new MouseEventHandler(this.PopupNotifierForm_MouseUp);
      this.Paint += new PaintEventHandler(this.PopupNotifierForm_Paint);
    }

    private void PopupNotifierForm_VisibleChanged(object sender, EventArgs e)
    {
      if (!this.Visible)
        return;
      this.mouseOnClose = false;
      this.mouseOnLink = false;
      this.mouseOnOptions = false;
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.ClientSize = new Size(392, 66);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (PopupNotifierForm);
      this.StartPosition = FormStartPosition.Manual;
      this.TopMost = true;
      this.ResumeLayout(false);
    }

    public PopupNotifier Parent { get; set; }

    private int AddValueMax255(int input, int add)
    {
      if (input + add >= 256)
        return (int) byte.MaxValue;
      return input + add;
    }

    private int DedValueMin0(int input, int ded)
    {
      if (input - ded <= 0)
        return 0;
      return input - ded;
    }

    private Color GetDarkerColor(Color color)
    {
      return Color.FromArgb((int) byte.MaxValue, this.DedValueMin0((int) color.R, this.Parent.GradientPower), this.DedValueMin0((int) color.G, this.Parent.GradientPower), this.DedValueMin0((int) color.B, this.Parent.GradientPower));
    }

    private Color GetLighterColor(Color color)
    {
      return Color.FromArgb((int) byte.MaxValue, this.AddValueMax255((int) color.R, this.Parent.GradientPower), this.AddValueMax255((int) color.G, this.Parent.GradientPower), this.AddValueMax255((int) color.B, this.Parent.GradientPower));
    }

    private RectangleF RectContentText
    {
      get
      {
        if (this.Parent.Image != null)
          return new RectangleF((float) (this.Parent.ImagePadding.Left + this.Parent.ImageSize.Width + this.Parent.ImagePadding.Right + this.Parent.ContentPadding.Left), (float) (this.Parent.HeaderHeight + this.Parent.TitlePadding.Top + this.heightOfTitle + this.Parent.TitlePadding.Bottom + this.Parent.ContentPadding.Top), (float) (this.Width - this.Parent.ImagePadding.Left - this.Parent.ImageSize.Width - this.Parent.ImagePadding.Right - this.Parent.ContentPadding.Left - this.Parent.ContentPadding.Right - 16 - 5), (float) (this.Height - this.Parent.HeaderHeight - this.Parent.TitlePadding.Top - this.heightOfTitle - this.Parent.TitlePadding.Bottom - this.Parent.ContentPadding.Top - this.Parent.ContentPadding.Bottom - 1));
        return new RectangleF((float) this.Parent.ContentPadding.Left, (float) (this.Parent.HeaderHeight + this.Parent.TitlePadding.Top + this.heightOfTitle + this.Parent.TitlePadding.Bottom + this.Parent.ContentPadding.Top), (float) (this.Width - this.Parent.ContentPadding.Left - this.Parent.ContentPadding.Right - 16 - 5), (float) (this.Height - this.Parent.HeaderHeight - this.Parent.TitlePadding.Top - this.heightOfTitle - this.Parent.TitlePadding.Bottom - this.Parent.ContentPadding.Top - this.Parent.ContentPadding.Bottom - 1));
      }
    }

    private Rectangle RectClose
    {
      get
      {
        return new Rectangle(this.Width - 5 - 16, this.Parent.HeaderHeight + 3, 16, 16);
      }
    }

    private Rectangle RectOptions
    {
      get
      {
        return new Rectangle(this.Width - 5 - 16, this.Parent.HeaderHeight + 3 + 16 + 5, 16, 16);
      }
    }

    private void PopupNotifierForm_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.Parent.ShowCloseButton)
        this.mouseOnClose = this.RectClose.Contains(e.X, e.Y);
      if (this.Parent.ShowOptionsButton)
        this.mouseOnOptions = this.RectOptions.Contains(e.X, e.Y);
      this.mouseOnLink = this.RectContentText.Contains((float) e.X, (float) e.Y);
      this.Invalidate();
    }

    private void PopupNotifierForm_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      if (this.RectClose.Contains(e.X, e.Y) && this.CloseClick != null)
        this.CloseClick((object) this, EventArgs.Empty);
      if (this.RectContentText.Contains((float) e.X, (float) e.Y) && this.LinkClick != null)
        this.LinkClick((object) this, EventArgs.Empty);
      if (!this.RectOptions.Contains(e.X, e.Y) || this.Parent.OptionsMenu == null)
        return;
      if (this.ContextMenuOpened != null)
        this.ContextMenuOpened((object) this, EventArgs.Empty);
      this.Parent.OptionsMenu.Show((Control) this, new Point(this.RectOptions.Right - this.Parent.OptionsMenu.Width, this.RectOptions.Bottom));
      this.Parent.OptionsMenu.Closed += new ToolStripDropDownClosedEventHandler(this.OptionsMenu_Closed);
    }

    private void OptionsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
    {
      this.Parent.OptionsMenu.Closed -= new ToolStripDropDownClosedEventHandler(this.OptionsMenu_Closed);
      if (this.ContextMenuClosed == null)
        return;
      this.ContextMenuClosed((object) this, EventArgs.Empty);
    }

    private void AllocateGDIObjects()
    {
      this.rcBody = new Rectangle(0, 0, this.Width, this.Height);
      this.rcHeader = new Rectangle(0, 0, this.Width, this.Parent.HeaderHeight);
      this.rcForm = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
      this.brushBody = new LinearGradientBrush(this.rcBody, this.Parent.BodyColor, this.GetLighterColor(this.Parent.BodyColor), LinearGradientMode.Vertical);
      this.brushHeader = new LinearGradientBrush(this.rcHeader, this.Parent.HeaderColor, this.GetDarkerColor(this.Parent.HeaderColor), LinearGradientMode.Vertical);
      this.brushButtonHover = (Brush) new SolidBrush(this.Parent.ButtonHoverColor);
      this.penButtonBorder = new Pen(this.Parent.ButtonBorderColor);
      this.penContent = new Pen(this.Parent.ContentColor, 2f);
      this.penBorder = new Pen(this.Parent.BorderColor);
      this.brushForeColor = (Brush) new SolidBrush(this.ForeColor);
      this.brushLinkHover = (Brush) new SolidBrush(this.Parent.ContentHoverColor);
      this.brushContent = (Brush) new SolidBrush(this.Parent.ContentColor);
      this.brushTitle = (Brush) new SolidBrush(this.Parent.TitleColor);
      this.gdiInitialized = true;
    }

    private void DisposeGDIObjects()
    {
      if (!this.gdiInitialized)
        return;
      this.brushBody.Dispose();
      this.brushHeader.Dispose();
      this.brushButtonHover.Dispose();
      this.penButtonBorder.Dispose();
      this.penContent.Dispose();
      this.penBorder.Dispose();
      this.brushForeColor.Dispose();
      this.brushLinkHover.Dispose();
      this.brushContent.Dispose();
      this.brushTitle.Dispose();
    }

    private void PopupNotifierForm_Paint(object sender, PaintEventArgs e)
    {
      if (!this.gdiInitialized)
        this.AllocateGDIObjects();
      e.Graphics.FillRectangle((Brush) this.brushBody, this.rcBody);
      e.Graphics.FillRectangle((Brush) this.brushHeader, this.rcHeader);
      e.Graphics.DrawRectangle(this.penBorder, this.rcForm);
      if (this.Parent.ShowGrip)
        e.Graphics.DrawImage((Image) Resources.Grip, (this.Width - Resources.Grip.Width) / 2, (this.Parent.HeaderHeight - 3) / 2);
      if (this.Parent.ShowCloseButton)
      {
        if (this.mouseOnClose)
        {
          e.Graphics.FillRectangle(this.brushButtonHover, this.RectClose);
          e.Graphics.DrawRectangle(this.penButtonBorder, this.RectClose);
        }
        e.Graphics.DrawLine(this.penContent, this.RectClose.Left + 4, this.RectClose.Top + 4, this.RectClose.Right - 4, this.RectClose.Bottom - 4);
        e.Graphics.DrawLine(this.penContent, this.RectClose.Left + 4, this.RectClose.Bottom - 4, this.RectClose.Right - 4, this.RectClose.Top + 4);
      }
      if (this.Parent.ShowOptionsButton)
      {
        if (this.mouseOnOptions)
        {
          e.Graphics.FillRectangle(this.brushButtonHover, this.RectOptions);
          e.Graphics.DrawRectangle(this.penButtonBorder, this.RectOptions);
        }
        e.Graphics.FillPolygon(this.brushForeColor, new Point[3]
        {
          new Point(this.RectOptions.Left + 4, this.RectOptions.Top + 6),
          new Point(this.RectOptions.Left + 12, this.RectOptions.Top + 6),
          new Point(this.RectOptions.Left + 8, this.RectOptions.Top + 4 + 6)
        });
      }
      if (this.Parent.Image != null)
        e.Graphics.DrawImage(this.Parent.Image, this.Parent.ImagePadding.Left, this.Parent.HeaderHeight + this.Parent.ImagePadding.Top, this.Parent.ImageSize.Width, this.Parent.ImageSize.Height);
      if (this.Parent.IsRightToLeft)
      {
        this.heightOfTitle = (int) e.Graphics.MeasureString("A", this.Parent.TitleFont).Height;
        int num = this.Width - 30;
        StringFormat format1 = new StringFormat(StringFormatFlags.DirectionRightToLeft);
        e.Graphics.DrawString(this.Parent.TitleText, this.Parent.TitleFont, this.brushTitle, (float) num, (float) (this.Parent.HeaderHeight + this.Parent.TitlePadding.Top), format1);
        this.Cursor = this.mouseOnLink ? Cursors.Hand : Cursors.Default;
        Brush brush = this.mouseOnLink ? this.brushLinkHover : this.brushContent;
        StringFormat format2 = new StringFormat(StringFormatFlags.DirectionRightToLeft);
        e.Graphics.DrawString(this.Parent.ContentText, this.Parent.ContentFont, brush, this.RectContentText, format2);
      }
      else
      {
        this.heightOfTitle = (int) e.Graphics.MeasureString("A", this.Parent.TitleFont).Height;
        int left = this.Parent.TitlePadding.Left;
        if (this.Parent.Image != null)
          left += this.Parent.ImagePadding.Left + this.Parent.ImageSize.Width + this.Parent.ImagePadding.Right;
        e.Graphics.DrawString(this.Parent.TitleText, this.Parent.TitleFont, this.brushTitle, (float) left, (float) (this.Parent.HeaderHeight + this.Parent.TitlePadding.Top));
        this.Cursor = this.mouseOnLink ? Cursors.Hand : Cursors.Default;
        Brush brush = this.mouseOnLink ? this.brushLinkHover : this.brushContent;
        e.Graphics.DrawString(this.Parent.ContentText, this.Parent.ContentFont, brush, this.RectContentText);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.DisposeGDIObjects();
      base.Dispose(disposing);
    }
  }
}
