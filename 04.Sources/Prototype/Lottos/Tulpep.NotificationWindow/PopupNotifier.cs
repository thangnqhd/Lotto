// Decompiled with JetBrains decompiler
// Type: Tulpep.NotificationWindow.PopupNotifier
// Assembly: Tulpep.NotificationWindow, Version=1.1.23.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F7EA38A-495D-44BC-8CE0-9C79F35F4AD3
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Tulpep.NotificationWindow.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Tulpep.NotificationWindow
{
  [ToolboxBitmap(typeof (PopupNotifier), "Icon.ico")]
  [DefaultEvent("Click")]
  public class PopupNotifier : Component
  {
    private bool isAppearing = true;
    private Size imageSize = new Size(0, 0);
    private bool disposed;
    private PopupNotifierForm frmPopup;
    private Timer tmrAnimation;
    private Timer tmrWait;
    private bool mouseIsOn;
    private int maxPosition;
    private double maxOpacity;
    private int posStart;
    private int posStop;
    private double opacityStart;
    private double opacityStop;
    private int realAnimationDuration;
    private Stopwatch sw;

    public event EventHandler Click;

    public event EventHandler Close;

    public event EventHandler Appear;

    public event EventHandler Disappear;

    [Description("Color of the window header.")]
    [Category("Header")]
    [DefaultValue(typeof (Color), "ControlDark")]
    public Color HeaderColor { get; set; }

    [Description("Color of the window background.")]
    [DefaultValue(typeof (Color), "Control")]
    [Category("Appearance")]
    public Color BodyColor { get; set; }

    [Category("Title")]
    [Description("Color of the title text.")]
    [DefaultValue(typeof (Color), "Gray")]
    public Color TitleColor { get; set; }

    [Category("Content")]
    [Description("Color of the content text.")]
    [DefaultValue(typeof (Color), "ControlText")]
    public Color ContentColor { get; set; }

    [Category("Appearance")]
    [DefaultValue(typeof (Color), "WindowFrame")]
    [Description("Color of the window border.")]
    public Color BorderColor { get; set; }

    [Category("Buttons")]
    [Description("Border color of the close and options buttons when the mouse is over them.")]
    [DefaultValue(typeof (Color), "WindowFrame")]
    public Color ButtonBorderColor { get; set; }

    [Description("Background color of the close and options buttons when the mouse is over them.")]
    [Category("Buttons")]
    [DefaultValue(typeof (Color), "Highlight")]
    public Color ButtonHoverColor { get; set; }

    [DefaultValue(typeof (Color), "HotTrack")]
    [Category("Content")]
    [Description("Color of the content text when the mouse is hovering over it.")]
    public Color ContentHoverColor { get; set; }

    [DefaultValue(50)]
    [Category("Appearance")]
    [Description("Gradient of window background color.")]
    public int GradientPower { get; set; }

    [Category("Content")]
    [Description("Font of the content text.")]
    public Font ContentFont { get; set; }

    [Category("Title")]
    [Description("Font of the title.")]
    public Font TitleFont { get; set; }

    [Category("Image")]
    [Description("Size of the icon image.")]
    public Size ImageSize
    {
      get
      {
        if (this.imageSize.Width != 0)
          return this.imageSize;
        if (this.Image != null)
          return this.Image.Size;
        return new Size(0, 0);
      }
      set
      {
        this.imageSize = value;
      }
    }

    public void ResetImageSize()
    {
      this.imageSize = Size.Empty;
    }

    private bool ShouldSerializeImageSize()
    {
      return !this.imageSize.Equals((object) Size.Empty);
    }

    [Category("Image")]
    [Description("Icon image to display.")]
    public Image Image { get; set; }

    [DefaultValue(true)]
    [Description("Whether to show a 'grip' image within the window header.")]
    [Category("Header")]
    public bool ShowGrip { get; set; }

    [DefaultValue(true)]
    [Description("Whether to scroll the window or only fade it.")]
    [Category("Behavior")]
    public bool Scroll { get; set; }

    [Description("Content text to display.")]
    [Category("Content")]
    public string ContentText { get; set; }

    [Description("Title text to display.")]
    [Category("Title")]
    public string TitleText { get; set; }

    [Description("Padding of title text.")]
    [Category("Title")]
    public Padding TitlePadding { get; set; }

    private void ResetTitlePadding()
    {
      this.TitlePadding = Padding.Empty;
    }

    private bool ShouldSerializeTitlePadding()
    {
      return !this.TitlePadding.Equals((object) Padding.Empty);
    }

    [Category("Content")]
    [Description("Padding of content text.")]
    public Padding ContentPadding { get; set; }

    private void ResetContentPadding()
    {
      this.ContentPadding = Padding.Empty;
    }

    private bool ShouldSerializeContentPadding()
    {
      return !this.ContentPadding.Equals((object) Padding.Empty);
    }

    [Description("Padding of icon image.")]
    [Category("Image")]
    public Padding ImagePadding { get; set; }

    private void ResetImagePadding()
    {
      this.ImagePadding = Padding.Empty;
    }

    private bool ShouldSerializeImagePadding()
    {
      return !this.ImagePadding.Equals((object) Padding.Empty);
    }

    [Category("Header")]
    [DefaultValue(9)]
    [Description("Height of window header.")]
    public int HeaderHeight { get; set; }

    [Description("Whether to show the close button.")]
    [Category("Buttons")]
    [DefaultValue(true)]
    public bool ShowCloseButton { get; set; }

    [Category("Buttons")]
    [DefaultValue(false)]
    [Description("Whether to show the options button.")]
    public bool ShowOptionsButton { get; set; }

    [Description("Context menu to open when clicking on the options button.")]
    [Category("Behavior")]
    public ContextMenuStrip OptionsMenu { get; set; }

    [Category("Behavior")]
    [DefaultValue(3000)]
    [Description("Time in milliseconds the window is displayed.")]
    public int Delay { get; set; }

    [DefaultValue(1000)]
    [Category("Behavior")]
    [Description("Time in milliseconds needed to make the window appear or disappear.")]
    public int AnimationDuration { get; set; }

    [Description("Interval in milliseconds used to draw the animation.")]
    [Category("Behavior")]
    [DefaultValue(10)]
    public int AnimationInterval { get; set; }

    [Category("Appearance")]
    [Description("Size of the window.")]
    public Size Size { get; set; }

    [Category("Content")]
    [Description("Show Content Right To Left,نمایش پیغام چپ به راست فعال شود")]
    public bool IsRightToLeft { get; set; }

    public PopupNotifier()
    {
      this.HeaderColor = SystemColors.ControlDark;
      this.BodyColor = SystemColors.Control;
      this.TitleColor = Color.Gray;
      this.ContentColor = SystemColors.ControlText;
      this.BorderColor = SystemColors.WindowFrame;
      this.ButtonBorderColor = SystemColors.WindowFrame;
      this.ButtonHoverColor = SystemColors.Highlight;
      this.ContentHoverColor = SystemColors.HotTrack;
      this.GradientPower = 50;
      this.ContentFont = SystemFonts.DialogFont;
      this.TitleFont = SystemFonts.CaptionFont;
      this.ShowGrip = true;
      this.Scroll = true;
      this.TitlePadding = new Padding(0);
      this.ContentPadding = new Padding(0);
      this.ImagePadding = new Padding(0);
      this.HeaderHeight = 9;
      this.ShowCloseButton = true;
      this.ShowOptionsButton = false;
      this.Delay = 3000;
      this.AnimationInterval = 10;
      this.AnimationDuration = 1000;
      this.Size = new Size(400, 100);
      this.frmPopup = new PopupNotifierForm(this);
      this.frmPopup.TopMost = true;
      this.frmPopup.FormBorderStyle = FormBorderStyle.None;
      this.frmPopup.StartPosition = FormStartPosition.Manual;
      this.frmPopup.FormBorderStyle = FormBorderStyle.None;
      this.frmPopup.MouseEnter += new EventHandler(this.frmPopup_MouseEnter);
      this.frmPopup.MouseLeave += new EventHandler(this.frmPopup_MouseLeave);
      this.frmPopup.CloseClick += new EventHandler(this.frmPopup_CloseClick);
      this.frmPopup.LinkClick += new EventHandler(this.frmPopup_LinkClick);
      this.frmPopup.ContextMenuOpened += new EventHandler(this.frmPopup_ContextMenuOpened);
      this.frmPopup.ContextMenuClosed += new EventHandler(this.frmPopup_ContextMenuClosed);
      this.frmPopup.VisibleChanged += new EventHandler(this.frmPopup_VisibleChanged);
      this.tmrAnimation = new Timer();
      this.tmrAnimation.Tick += new EventHandler(this.tmAnimation_Tick);
      this.tmrWait = new Timer();
      this.tmrWait.Tick += new EventHandler(this.tmWait_Tick);
    }

    public void Popup()
    {
      if (this.disposed)
        return;
      if (!this.frmPopup.Visible)
      {
        this.frmPopup.Size = this.Size;
        if (this.Scroll)
        {
          this.posStart = Screen.PrimaryScreen.WorkingArea.Bottom;
          this.posStop = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
        }
        else
        {
          this.posStart = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
          this.posStop = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
        }
        this.opacityStart = 0.0;
        this.opacityStop = 1.0;
        this.frmPopup.Opacity = this.opacityStart;
        this.frmPopup.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.frmPopup.Size.Width - 1, this.posStart);
        this.frmPopup.Visible = true;
        this.isAppearing = true;
        this.tmrWait.Interval = this.Delay;
        this.tmrAnimation.Interval = this.AnimationInterval;
        this.realAnimationDuration = this.AnimationDuration;
        this.tmrAnimation.Start();
        this.sw = Stopwatch.StartNew();
      }
      else
      {
        if (!this.isAppearing)
        {
          this.frmPopup.Size = this.Size;
          if (this.Scroll)
          {
            this.posStart = this.frmPopup.Top;
            this.posStop = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
          }
          else
          {
            this.posStart = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
            this.posStop = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
          }
          this.opacityStart = this.frmPopup.Opacity;
          this.opacityStop = 1.0;
          this.isAppearing = true;
          this.realAnimationDuration = Math.Max((int) this.sw.ElapsedMilliseconds, 1);
          this.sw.Restart();
        }
        this.frmPopup.Invalidate();
      }
    }

    public void Hide()
    {
      this.tmrAnimation.Stop();
      this.tmrWait.Stop();
      this.frmPopup.Hide();
    }

    private void frmPopup_ContextMenuClosed(object sender, EventArgs e)
    {
      if (this.mouseIsOn)
        return;
      this.tmrWait.Interval = this.Delay;
      this.tmrWait.Start();
    }

    private void frmPopup_ContextMenuOpened(object sender, EventArgs e)
    {
      this.tmrWait.Stop();
    }

    private void frmPopup_LinkClick(object sender, EventArgs e)
    {
      if (this.Click == null)
        return;
      this.Click((object) this, EventArgs.Empty);
    }

    private void frmPopup_CloseClick(object sender, EventArgs e)
    {
      this.Hide();
      if (this.Close == null)
        return;
      this.Close((object) this, EventArgs.Empty);
    }

    private void frmPopup_VisibleChanged(object sender, EventArgs e)
    {
      if (this.frmPopup.Visible)
      {
        if (this.Appear == null)
          return;
        this.Appear((object) this, EventArgs.Empty);
      }
      else
      {
        if (this.Disappear == null)
          return;
        this.Disappear((object) this, EventArgs.Empty);
      }
    }

    private void tmAnimation_Tick(object sender, EventArgs e)
    {
      long elapsedMilliseconds = this.sw.ElapsedMilliseconds;
      int num1 = (int) ((long) this.posStart + (long) (this.posStop - this.posStart) * elapsedMilliseconds / (long) this.realAnimationDuration);
      bool flag1 = this.posStop - this.posStart < 0;
      if (flag1 && num1 < this.posStop || !flag1 && num1 > this.posStop)
        num1 = this.posStop;
      double num2 = this.opacityStart + (this.opacityStop - this.opacityStart) * (double) elapsedMilliseconds / (double) this.realAnimationDuration;
      bool flag2 = this.opacityStop - this.opacityStart < 0.0;
      if (flag2 && num2 < this.opacityStop || !flag2 && num2 > this.opacityStop)
        num2 = this.opacityStop;
      this.frmPopup.Top = num1;
      this.frmPopup.Opacity = num2;
      if (elapsedMilliseconds <= (long) this.realAnimationDuration)
        return;
      this.sw.Reset();
      this.tmrAnimation.Stop();
      if (this.isAppearing)
      {
        if (this.Scroll)
        {
          this.posStart = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
          this.posStop = Screen.PrimaryScreen.WorkingArea.Bottom;
        }
        else
        {
          this.posStart = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
          this.posStop = Screen.PrimaryScreen.WorkingArea.Bottom - this.frmPopup.Height;
        }
        this.opacityStart = 1.0;
        this.opacityStop = 0.0;
        this.realAnimationDuration = this.AnimationDuration;
        this.isAppearing = false;
        this.maxPosition = this.frmPopup.Top;
        this.maxOpacity = this.frmPopup.Opacity;
        if (this.mouseIsOn)
          return;
        this.tmrWait.Stop();
        this.tmrWait.Start();
      }
      else
        this.frmPopup.Hide();
    }

    private void tmWait_Tick(object sender, EventArgs e)
    {
      this.tmrWait.Stop();
      this.tmrAnimation.Interval = this.AnimationInterval;
      this.tmrAnimation.Start();
      this.sw.Restart();
    }

    private void frmPopup_MouseLeave(object sender, EventArgs e)
    {
      if (this.frmPopup.Visible && (this.OptionsMenu == null || !this.OptionsMenu.Visible))
      {
        this.tmrWait.Interval = this.Delay;
        this.tmrWait.Start();
      }
      this.mouseIsOn = false;
    }

    private void frmPopup_MouseEnter(object sender, EventArgs e)
    {
      if (!this.isAppearing)
      {
        this.frmPopup.Top = this.maxPosition;
        this.frmPopup.Opacity = this.maxOpacity;
        this.tmrAnimation.Stop();
      }
      this.tmrWait.Stop();
      this.mouseIsOn = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing && this.frmPopup != null)
          this.frmPopup.Dispose();
        this.disposed = true;
      }
      base.Dispose(disposing);
    }
  }
}
