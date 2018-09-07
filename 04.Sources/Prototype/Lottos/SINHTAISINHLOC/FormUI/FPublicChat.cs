// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.FPublicChat
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using myStruct;
using ns1;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class FPublicChat : Form
  {
    private string _strMsg = "";
    private IContainer components = (IContainer) null;
    private Structure _structure;
    private bool checkChat;
    private string[] demChat;
    private bool _checkB;
    private bool _checkI;
    private bool _checkU;
    private FontStyle _fontStyle;
    private string _strEmotion;
    private Panel panel1;
    private Panel panel2;
    private BunifuImageButton bunifuImageButton8;
    private BunifuImageButton bunifuImageButton6;
    private ToolTip toolTip1;
    private Label label1;
    private BunifuImageButton bunifuImageButton1;
    private Panel panel3;
    private Panel pnMainTop;
    private Panel pnMainBot;
    private Panel pnEmotion;
    private Panel pnTextInput;
    private Panel pnChatLog;
    private TextBox txtInput;
    public WebBrowser wbChat;
    private BunifuElipse bunifuElipse1;
    private BunifuElipse bunifuElipse2;
    private BunifuImageButton btnSend;
    private Button btnU;
    private Button btnI;
    private Button btnB;
    private BunifuImageButton btnColor;
    private ColorDialog colorDialog1;
    private BunifuImageButton emtion3;
    private BunifuImageButton emtion2;
    private BunifuImageButton emtion1;
    private BunifuImageButton emtion7;
    private BunifuImageButton emtion6;
    private BunifuImageButton emtion5;
    private BunifuImageButton emtion4;
    private BunifuImageButton emtion25;
    private BunifuImageButton emtion24;
    private BunifuImageButton emtion23;
    private BunifuImageButton emtion22;
    private BunifuImageButton emtion21;
    private BunifuImageButton emtion20;
    private BunifuImageButton emtion19;
    private BunifuImageButton emtion16;
    private BunifuImageButton emtion15;
    private BunifuImageButton emtion14;
    private BunifuImageButton emtion13;
    private BunifuImageButton emtion12;
    private BunifuImageButton emtion11;
    private BunifuImageButton emtion10;
    private BunifuImageButton bunifuImageButton31;
    private Panel pnUrlImage;
    private Button btnImage;
    private Label label2;
    private TextBox txtUrlImage;
    private Panel pnEmo;
    private BunifuImageButton emtion70;
    private BunifuImageButton emtion69;
    private BunifuImageButton emtion68;
    private BunifuImageButton emtion67;
    private BunifuImageButton emtion66;
    private BunifuImageButton emtion65;
    private BunifuImageButton emtion64;
    private BunifuImageButton emtion61;
    private BunifuImageButton emtion60;
    private BunifuImageButton emtion59;
    private BunifuImageButton emtion58;
    private BunifuImageButton emtion56;
    private BunifuImageButton emtion55;
    private BunifuImageButton emtion52;
    private BunifuImageButton emtion50;
    private BunifuImageButton emtion49;
    private BunifuImageButton emtion48;
    private BunifuImageButton emtion46;
    private BunifuImageButton emtion43;
    private BunifuImageButton emtion42;
    private BunifuImageButton emtion40;
    private BunifuImageButton emtion39;
    private BunifuImageButton emtion38;
    private BunifuImageButton emtion37;
    private BunifuImageButton emtion34;
    private BunifuImageButton emtion33;
    private BunifuImageButton emtion32;
    private BunifuImageButton emtion31;
    private BunifuImageButton emtion30;
    private BunifuImageButton emtion29;
    private BunifuImageButton emtion28;
    private BunifuImageButton bunifuImageButton61;
    private BunifuImageButton emtion71;
    private BunifuImageButton emtion62;
    private BunifuImageButton emtion53;
    private BunifuImageButton emtion44;
    private BunifuImageButton emtion35;
    private BunifuImageButton emtion26;
    private BunifuImageButton emtion8;
    private BunifuImageButton emtion17;
    private BunifuImageButton emtion41;
    private BunifuImageButton emtion57;
    private BunifuImageButton emtion47;
    private BunifuImageButton emtion72;
    private BunifuImageButton emtion63;
    private BunifuImageButton emtion54;
    private BunifuImageButton emtion45;
    private BunifuImageButton emtion36;
    private BunifuImageButton emtion27;
    private BunifuImageButton emtion9;
    private BunifuImageButton emtion18;
    private ComboBox cbbFontSize;
    private Label lblCount;

    public FPublicChat()
    {
      this._structure = new Structure();
      this.InitializeComponent();
      this._structure.Username = FMain.UserName;
      this._structure.AccountType = FMain.AccountType;
      this.cbbFontSize.SelectedIndex = 0;
      this.wbChat.IsWebBrowserContextMenuEnabled = false;
      this.wbChat.AllowWebBrowserDrop = false;
      this.ConnectChat();
    }

    private void BunifuImageButton6Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void BunifuImageButton8Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.FPublicChat_BunifuImageButton8Click_Bạn_có_chắc_chắn_muốn_thoát_khỏi_phòng_chat__, Resources.FLossPw_XuLy_THÔNG_BÁO, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
        return;
      this._structure.SendTo = "Server";
      this._structure.SendType = "LeaveChat";
      this._structure.TextChat = "connected";
      FLogin.Client.Send(this._structure);
      FLogin.StatusChat = 0;
      this.Close();
    }

    private void ConnectChat()
    {
      if (FLogin.StatusChat != 0)
        return;
      this._structure.SendTo = "Server";
      this._structure.SendType = "JoinChat";
      this._structure.TextChat = "Joined Chat";
      FLogin.Client.Send(this._structure);
      FLogin.StatusChat = 1;
    }

    private void Panel1MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      ClMain.ReleaseCapture();
      ClMain.SendMessage(this.Handle, 161, 2, 0);
    }

    private void TxtInputKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        this.SendMsg();
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
      if (this.txtInput.Text.Length > 119)
      {
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
      if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
        return;
      e.Handled = false;
      e.SuppressKeyPress = false;
    }

    private void WbChatDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (!(this.wbChat.Document != (HtmlDocument) null))
        return;
      Debug.Assert(this.wbChat.Document.Window != (HtmlWindow) null, "wbChat.Document.Window != null");
      Debug.Assert(this.wbChat.Document.Body != (HtmlElement) null, "wbChat.Document.Body != null");
      this.wbChat.Document.Window.ScrollTo(0, this.wbChat.Document.Body.ScrollRectangle.Height);
    }

    private void BtnSendClick1(object sender, EventArgs e)
    {
      this.SendMsg();
    }

    private void SendMsg()
    {
      this.checkChat = true;
      if (this.txtInput.Text != string.Empty && this.txtInput.Text.Length < 121)
      {
        this._strMsg = FPublicChat.StripHTML(this.txtInput.Text);
        if (this._strMsg.Length > 0)
        {
          if (this._strMsg.Length > 44)
          {
            this.demChat = this._strMsg.Split(' ');
            if (this.demChat.Length < 2)
              this.checkChat = false;
          }
        }
        else
          this.checkChat = false;
        if (this.checkChat)
        {
          this._structure.SendTo = "Client";
          this._structure.SendType = "Message";
          this._structure.TextChat = this._strMsg;
          FLogin.Client.Send(this._structure);
        }
      }
      this._structure.Image = "";
      this.txtInput.Text = (string) null;
      this.txtInput.Clear();
    }

    public static string StripHTML(string inputText)
    {
      return Regex.Replace(inputText, "<.*?>", string.Empty);
    }

    private void BtnColorClick(object sender, EventArgs e)
    {
      if (this.colorDialog1.ShowDialog() == DialogResult.OK)
        this._structure.ForColor = "#" + (this.colorDialog1.Color.ToArgb() & 16777215).ToString("X6");
      this.txtInput.ForeColor = this.colorDialog1.Color;
    }

    private void BtnBClick(object sender, EventArgs e)
    {
      if (!this._checkB)
      {
        this._checkB = true;
        this._checkI = false;
        this._checkU = false;
        this._structure.FontWeight = "bold";
        this._fontStyle = FontStyle.Bold;
        this.btnB.BackColor = Color.Teal;
        this.btnB.ForeColor = Color.White;
        this.btnI.BackColor = Color.FromArgb(236, 238, 245);
        this.btnI.ForeColor = Color.Black;
        this.btnU.BackColor = Color.FromArgb(236, 238, 245);
        this.btnU.ForeColor = Color.Black;
      }
      else
      {
        this._checkB = false;
        this._structure.FontWeight = "normal";
        this._fontStyle = FontStyle.Regular;
        this.btnB.BackColor = Color.FromArgb(236, 238, 245);
        this.btnB.ForeColor = Color.Black;
      }
      this.txtInput.Focus();
      this.txtInput.Font = new Font(this._structure.Font, (float) this._structure.FontSize, this._fontStyle);
    }

    private void BtnIClick(object sender, EventArgs e)
    {
      if (!this._checkI)
      {
        this._checkI = true;
        this._checkU = false;
        this._checkB = false;
        this._structure.FontWeight = "italic";
        this._fontStyle = FontStyle.Italic;
        this.btnI.BackColor = Color.Teal;
        this.btnI.ForeColor = Color.White;
        this.btnB.BackColor = Color.FromArgb(236, 238, 245);
        this.btnB.ForeColor = Color.Black;
        this.btnU.BackColor = Color.FromArgb(236, 238, 245);
        this.btnU.ForeColor = Color.Black;
      }
      else
      {
        this._checkI = false;
        this._structure.FontWeight = "normal";
        this._fontStyle = FontStyle.Regular;
        this.btnI.BackColor = Color.FromArgb(236, 238, 245);
        this.btnI.ForeColor = Color.Black;
      }
      this.txtInput.Focus();
      this.txtInput.Font = new Font(this._structure.Font, (float) this._structure.FontSize, this._fontStyle);
    }

    private void BtnUClick(object sender, EventArgs e)
    {
      if (!this._checkU)
      {
        this._checkU = true;
        this._checkI = false;
        this._checkB = false;
        this._structure.FontWeight = "underline";
        this._fontStyle = FontStyle.Underline;
        this.btnU.BackColor = Color.Teal;
        this.btnU.ForeColor = Color.White;
        this.btnI.BackColor = Color.FromArgb(236, 238, 245);
        this.btnI.ForeColor = Color.Black;
        this.btnB.BackColor = Color.FromArgb(236, 238, 245);
        this.btnB.ForeColor = Color.Black;
      }
      else
      {
        this._checkU = false;
        this._structure.FontWeight = "normal";
        this._fontStyle = FontStyle.Regular;
        this.btnU.BackColor = Color.FromArgb(236, 238, 245);
        this.btnU.ForeColor = Color.Black;
      }
      this.txtInput.Focus();
      this.txtInput.Font = new Font(this._structure.Font, (float) this._structure.FontSize, this._fontStyle);
    }

    private void BunifuImageButton31Click(object sender, EventArgs e)
    {
      if (!this.pnUrlImage.Visible)
      {
        if (this.pnEmo.Visible)
          this.pnEmo.Visible = false;
        this.pnUrlImage.Visible = true;
        this.txtUrlImage.Focus();
      }
      else
      {
        this.txtUrlImage.Text = string.Empty;
        this.pnUrlImage.Visible = false;
        this.txtInput.Focus();
        this.txtInput.SelectionStart = this.txtInput.Text.Length;
      }
    }

    private void Button1Click(object sender, EventArgs e)
    {
      if (this.txtUrlImage.Text.Length > 14)
      {
        string[] strArray = this.txtUrlImage.Text.Split('.');
        string str = strArray[strArray.Length - 1];
        if (str == "jpg" || str == "gif" || str == "png")
        {
          this.txtInput.Text += Resources.FPublicChat_Button1Click___img_;
          this._structure.Image = this.txtUrlImage.Text;
        }
      }
      this.txtUrlImage.Text = string.Empty;
      this.pnUrlImage.Visible = false;
      this.txtInput.Focus();
      this.txtInput.SelectionStart = this.txtInput.Text.Length;
    }

    private void TxtInputMouseClick(object sender, MouseEventArgs e)
    {
      this.pnUrlImage.Visible = false;
      this.pnEmo.Visible = false;
      this.txtUrlImage.Text = string.Empty;
    }

    private void BunifuImageButton61Click(object sender, EventArgs e)
    {
      if (!this.pnEmo.Visible)
      {
        if (this.pnUrlImage.Visible)
          this.pnUrlImage.Visible = false;
        this.pnEmo.Visible = true;
      }
      else
        this.pnEmo.Visible = false;
    }

    private void Emtion1Click(object sender, EventArgs e)
    {
      BunifuImageButton bunifuImageButton = (BunifuImageButton) sender;
      TextBox txtInput = this.txtInput;
      txtInput.Text = txtInput.Text + Resources.FPublicChat_Emtion1Click__ + this.InsertEmotion(bunifuImageButton.Name) + Resources.FPublicChat_Emtion1Click__;
      this.txtInput.SelectionStart = this.txtInput.Text.Length;
    }

    private string InsertEmotion(string strEmotion)
    {
      switch (strEmotion)
      {
        case "emtion1":
          this._strEmotion = ":)";
          break;
        case "emtion10":
          this._strEmotion = ":P";
          break;
        case "emtion11":
          this._strEmotion = ":-*";
          break;
        case "emtion12":
          this._strEmotion = "=((";
          break;
        case "emtion13":
          this._strEmotion = ":-0";
          break;
        case "emtion14":
          this._strEmotion = "X(";
          break;
        case "emtion15":
          this._strEmotion = ":}";
          break;
        case "emtion16":
          this._strEmotion = "B-)";
          break;
        case "emtion17":
          this._strEmotion = ":-S";
          break;
        case "emtion18":
          this._strEmotion = ":((";
          break;
        case "emtion19":
          this._strEmotion = ":))";
          break;
        case "emtion2":
          this._strEmotion = ":(";
          break;
        case "emtion20":
          this._strEmotion = ":|";
          break;
        case "emtion21":
          this._strEmotion = "/:)";
          break;
        case "emtion22":
          this._strEmotion = "=))";
          break;
        case "emtion23":
          this._strEmotion = "0:-)";
          break;
        case "emtion24":
          this._strEmotion = ":-B";
          break;
        case "emtion25":
          this._strEmotion = "=;";
          break;
        case "emtion26":
          this._strEmotion = "|-)";
          break;
        case "emtion27":
          this._strEmotion = "8-|";
          break;
        case "emtion28":
          this._strEmotion = "L-)";
          break;
        case "emtion29":
          this._strEmotion = ":-$";
          break;
        case "emtion3":
          this._strEmotion = ";)";
          break;
        case "emtion30":
          this._strEmotion = "[-(";
          break;
        case "emtion31":
          this._strEmotion = "8-}";
          break;
        case "emtion32":
          this._strEmotion = "(:|";
          break;
        case "emtion33":
          this._strEmotion = "=P~";
          break;
        case "emtion34":
          this._strEmotion = ":-?";
          break;
        case "emtion35":
          this._strEmotion = "#-(";
          break;
        case "emtion36":
          this._strEmotion = "=D]";
          break;
        case "emtion37":
          this._strEmotion = ":-SS";
          break;
        case "emtion38":
          this._strEmotion = "@-)";
          break;
        case "emtion39":
          this._strEmotion = ":^o";
          break;
        case "emtion4":
          this._strEmotion = ":D";
          break;
        case "emtion40":
          this._strEmotion = ":-w";
          break;
        case "emtion41":
          this._strEmotion = ":ar!";
          break;
        case "emtion42":
          this._strEmotion = "[:P";
          break;
        case "emtion43":
          this._strEmotion = "@};-";
          break;
        case "emtion44":
          this._strEmotion = "%%-";
          break;
        case "emtion45":
          this._strEmotion = "~O)";
          break;
        case "emtion46":
          this._strEmotion = ":-O";
          break;
        case "emtion47":
          this._strEmotion = ":-bd";
          break;
        case "emtion48":
          this._strEmotion = "[-O]";
          break;
        case "emtion49":
          this._strEmotion = "$-)";
          break;
        case "emtion5":
          this._strEmotion = ";;)";
          break;
        case "emtion50":
          this._strEmotion = ":-'";
          break;
        case "emtion52":
          this._strEmotion = "#-o";
          break;
        case "emtion53":
          this._strEmotion = "[-X";
          break;
        case "emtion54":
          this._strEmotion = "\\:D/";
          break;
        case "emtion55":
          this._strEmotion = "=:/";
          break;
        case "emtion56":
          this._strEmotion = ";))";
          break;
        case "emtion57":
          this._strEmotion = "^#(^";
          break;
        case "emtion58":
          this._strEmotion = ":-@";
          break;
        case "emtion59":
          this._strEmotion = "^:)^";
          break;
        case "emtion6":
          this._strEmotion = "[:D]";
          break;
        case "emtion60":
          this._strEmotion = ":-j";
          break;
        case "emtion61":
          this._strEmotion = "(*)";
          break;
        case "emtion62":
          this._strEmotion = ":)]";
          break;
        case "emtion63":
          this._strEmotion = ":-c";
          break;
        case "emtion64":
          this._strEmotion = "~X(";
          break;
        case "emtion65":
          this._strEmotion = ":-h";
          break;
        case "emtion66":
          this._strEmotion = ":-t";
          break;
        case "emtion67":
          this._strEmotion = "8-)";
          break;
        case "emtion68":
          this._strEmotion = ":-??";
          break;
        case "emtion69":
          this._strEmotion = "X_X";
          break;
        case "emtion7":
          this._strEmotion = ":-/";
          break;
        case "emtion70":
          this._strEmotion = ":!!";
          break;
        case "emtion71":
          this._strEmotion = "\\m/";
          break;
        case "emtion72":
          this._strEmotion = ":-q";
          break;
        case "emtion8":
          this._strEmotion = ":x";
          break;
        case "emtion9":
          this._strEmotion = ":'}";
          break;
        default:
          this._strEmotion = "";
          break;
      }
      return this._strEmotion;
    }

    private void CbbFontSizeSelectedIndexChanged(object sender, EventArgs e)
    {
      this._structure.FontSize = Convert.ToInt32(this.cbbFontSize.SelectedItem.ToString());
      this.txtInput.Font = new Font(this._structure.Font, (float) this._structure.FontSize, this._fontStyle);
    }

    private void TxtUrlImageKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnImage.PerformClick();
    }

    private void TxtInputKeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
      this.lblCount.Text = string.Format("{0}/120", (object) this.txtInput.Text.Length.ToString((IFormatProvider) CultureInfo.InvariantCulture));
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FPublicChat));
      this.panel1 = new Panel();
      this.bunifuImageButton1 = new BunifuImageButton();
      this.label1 = new Label();
      this.bunifuImageButton6 = new BunifuImageButton();
      this.bunifuImageButton8 = new BunifuImageButton();
      this.panel2 = new Panel();
      this.pnMainTop = new Panel();
      this.pnChatLog = new Panel();
      this.pnEmo = new Panel();
      this.emtion72 = new BunifuImageButton();
      this.emtion63 = new BunifuImageButton();
      this.emtion54 = new BunifuImageButton();
      this.emtion45 = new BunifuImageButton();
      this.emtion36 = new BunifuImageButton();
      this.emtion27 = new BunifuImageButton();
      this.emtion9 = new BunifuImageButton();
      this.emtion18 = new BunifuImageButton();
      this.emtion41 = new BunifuImageButton();
      this.emtion57 = new BunifuImageButton();
      this.emtion47 = new BunifuImageButton();
      this.emtion71 = new BunifuImageButton();
      this.emtion62 = new BunifuImageButton();
      this.emtion53 = new BunifuImageButton();
      this.emtion44 = new BunifuImageButton();
      this.emtion35 = new BunifuImageButton();
      this.emtion26 = new BunifuImageButton();
      this.emtion8 = new BunifuImageButton();
      this.emtion17 = new BunifuImageButton();
      this.emtion70 = new BunifuImageButton();
      this.emtion69 = new BunifuImageButton();
      this.emtion68 = new BunifuImageButton();
      this.emtion67 = new BunifuImageButton();
      this.emtion66 = new BunifuImageButton();
      this.emtion65 = new BunifuImageButton();
      this.emtion64 = new BunifuImageButton();
      this.emtion61 = new BunifuImageButton();
      this.emtion60 = new BunifuImageButton();
      this.emtion59 = new BunifuImageButton();
      this.emtion58 = new BunifuImageButton();
      this.emtion56 = new BunifuImageButton();
      this.emtion55 = new BunifuImageButton();
      this.emtion52 = new BunifuImageButton();
      this.emtion50 = new BunifuImageButton();
      this.emtion49 = new BunifuImageButton();
      this.emtion48 = new BunifuImageButton();
      this.emtion46 = new BunifuImageButton();
      this.emtion43 = new BunifuImageButton();
      this.emtion42 = new BunifuImageButton();
      this.emtion40 = new BunifuImageButton();
      this.emtion39 = new BunifuImageButton();
      this.emtion38 = new BunifuImageButton();
      this.emtion37 = new BunifuImageButton();
      this.emtion34 = new BunifuImageButton();
      this.emtion33 = new BunifuImageButton();
      this.emtion32 = new BunifuImageButton();
      this.emtion31 = new BunifuImageButton();
      this.emtion30 = new BunifuImageButton();
      this.emtion29 = new BunifuImageButton();
      this.emtion28 = new BunifuImageButton();
      this.emtion4 = new BunifuImageButton();
      this.emtion1 = new BunifuImageButton();
      this.emtion2 = new BunifuImageButton();
      this.emtion25 = new BunifuImageButton();
      this.emtion3 = new BunifuImageButton();
      this.emtion24 = new BunifuImageButton();
      this.emtion5 = new BunifuImageButton();
      this.emtion23 = new BunifuImageButton();
      this.emtion6 = new BunifuImageButton();
      this.emtion22 = new BunifuImageButton();
      this.emtion7 = new BunifuImageButton();
      this.emtion21 = new BunifuImageButton();
      this.emtion20 = new BunifuImageButton();
      this.emtion14 = new BunifuImageButton();
      this.emtion19 = new BunifuImageButton();
      this.emtion10 = new BunifuImageButton();
      this.emtion11 = new BunifuImageButton();
      this.emtion16 = new BunifuImageButton();
      this.emtion12 = new BunifuImageButton();
      this.emtion15 = new BunifuImageButton();
      this.emtion13 = new BunifuImageButton();
      this.pnUrlImage = new Panel();
      this.btnImage = new Button();
      this.label2 = new Label();
      this.txtUrlImage = new TextBox();
      this.wbChat = new WebBrowser();
      this.pnMainBot = new Panel();
      this.pnEmotion = new Panel();
      this.lblCount = new Label();
      this.cbbFontSize = new ComboBox();
      this.bunifuImageButton61 = new BunifuImageButton();
      this.bunifuImageButton31 = new BunifuImageButton();
      this.btnColor = new BunifuImageButton();
      this.btnU = new Button();
      this.btnI = new Button();
      this.btnB = new Button();
      this.pnTextInput = new Panel();
      this.btnSend = new BunifuImageButton();
      this.txtInput = new TextBox();
      this.toolTip1 = new ToolTip(this.components);
      this.panel3 = new Panel();
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.bunifuElipse2 = new BunifuElipse(this.components);
      this.colorDialog1 = new ColorDialog();
      this.panel1.SuspendLayout();
      this.bunifuImageButton1.BeginInit();
      this.bunifuImageButton6.BeginInit();
      this.bunifuImageButton8.BeginInit();
      this.panel2.SuspendLayout();
      this.pnMainTop.SuspendLayout();
      this.pnChatLog.SuspendLayout();
      this.pnEmo.SuspendLayout();
      this.emtion72.BeginInit();
      this.emtion63.BeginInit();
      this.emtion54.BeginInit();
      this.emtion45.BeginInit();
      this.emtion36.BeginInit();
      this.emtion27.BeginInit();
      this.emtion9.BeginInit();
      this.emtion18.BeginInit();
      this.emtion41.BeginInit();
      this.emtion57.BeginInit();
      this.emtion47.BeginInit();
      this.emtion71.BeginInit();
      this.emtion62.BeginInit();
      this.emtion53.BeginInit();
      this.emtion44.BeginInit();
      this.emtion35.BeginInit();
      this.emtion26.BeginInit();
      this.emtion8.BeginInit();
      this.emtion17.BeginInit();
      this.emtion70.BeginInit();
      this.emtion69.BeginInit();
      this.emtion68.BeginInit();
      this.emtion67.BeginInit();
      this.emtion66.BeginInit();
      this.emtion65.BeginInit();
      this.emtion64.BeginInit();
      this.emtion61.BeginInit();
      this.emtion60.BeginInit();
      this.emtion59.BeginInit();
      this.emtion58.BeginInit();
      this.emtion56.BeginInit();
      this.emtion55.BeginInit();
      this.emtion52.BeginInit();
      this.emtion50.BeginInit();
      this.emtion49.BeginInit();
      this.emtion48.BeginInit();
      this.emtion46.BeginInit();
      this.emtion43.BeginInit();
      this.emtion42.BeginInit();
      this.emtion40.BeginInit();
      this.emtion39.BeginInit();
      this.emtion38.BeginInit();
      this.emtion37.BeginInit();
      this.emtion34.BeginInit();
      this.emtion33.BeginInit();
      this.emtion32.BeginInit();
      this.emtion31.BeginInit();
      this.emtion30.BeginInit();
      this.emtion29.BeginInit();
      this.emtion28.BeginInit();
      this.emtion4.BeginInit();
      this.emtion1.BeginInit();
      this.emtion2.BeginInit();
      this.emtion25.BeginInit();
      this.emtion3.BeginInit();
      this.emtion24.BeginInit();
      this.emtion5.BeginInit();
      this.emtion23.BeginInit();
      this.emtion6.BeginInit();
      this.emtion22.BeginInit();
      this.emtion7.BeginInit();
      this.emtion21.BeginInit();
      this.emtion20.BeginInit();
      this.emtion14.BeginInit();
      this.emtion19.BeginInit();
      this.emtion10.BeginInit();
      this.emtion11.BeginInit();
      this.emtion16.BeginInit();
      this.emtion12.BeginInit();
      this.emtion15.BeginInit();
      this.emtion13.BeginInit();
      this.pnUrlImage.SuspendLayout();
      this.pnMainBot.SuspendLayout();
      this.pnEmotion.SuspendLayout();
      this.bunifuImageButton61.BeginInit();
      this.bunifuImageButton31.BeginInit();
      this.btnColor.BeginInit();
      this.pnTextInput.SuspendLayout();
      this.btnSend.BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(27, 40, 61);
      this.panel1.Controls.Add((Control) this.bunifuImageButton1);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.bunifuImageButton6);
      this.panel1.Controls.Add((Control) this.bunifuImageButton8);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1100, 21);
      this.panel1.TabIndex = 0;
      this.panel1.MouseDown += new MouseEventHandler(this.Panel1MouseDown);
      this.bunifuImageButton1.BackColor = Color.Transparent;
      this.bunifuImageButton1.Image = (Image) componentResourceManager.GetObject("bunifuImageButton1.Image");
      this.bunifuImageButton1.ImageActive = (Image) null;
      this.bunifuImageButton1.Location = new Point(3, 1);
      this.bunifuImageButton1.Name = "bunifuImageButton1";
      this.bunifuImageButton1.Size = new Size(21, 21);
      this.bunifuImageButton1.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton1.TabIndex = 32;
      this.bunifuImageButton1.TabStop = false;
      this.bunifuImageButton1.Zoom = 10;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.label1.ForeColor = SystemColors.ActiveCaptionText;
      this.label1.Location = new Point(25, 3);
      this.label1.Name = "label1";
      this.label1.Size = new Size(354, 16);
      this.label1.TabIndex = 31;
      this.label1.Text = "Phòng Chat - Hãy cho mọi người thấy sự văn minh của bạn";
      this.bunifuImageButton6.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton6.Cursor = Cursors.Hand;
      this.bunifuImageButton6.Image = (Image) componentResourceManager.GetObject("bunifuImageButton6.Image");
      this.bunifuImageButton6.ImageActive = (Image) null;
      this.bunifuImageButton6.Location = new Point(1200, 8);
      this.bunifuImageButton6.Name = "bunifuImageButton6";
      this.bunifuImageButton6.Size = new Size(12, 12);
      this.bunifuImageButton6.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton6.TabIndex = 30;
      this.bunifuImageButton6.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton6, "Thu nhỏ");
      this.bunifuImageButton6.Zoom = 10;
      this.bunifuImageButton6.Click += new EventHandler(this.BunifuImageButton6Click);
      this.bunifuImageButton8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.bunifuImageButton8.BackColor = Color.FromArgb(27, 40, 61);
      this.bunifuImageButton8.Cursor = Cursors.Hand;
      this.bunifuImageButton8.Image = (Image) componentResourceManager.GetObject("bunifuImageButton8.Image");
      this.bunifuImageButton8.ImageActive = (Image) null;
      this.bunifuImageButton8.Location = new Point(1075, 1);
      this.bunifuImageButton8.Name = "bunifuImageButton8";
      this.bunifuImageButton8.Size = new Size(20, 20);
      this.bunifuImageButton8.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton8.TabIndex = 29;
      this.bunifuImageButton8.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton8, "Đóng");
      this.bunifuImageButton8.Zoom = 5;
      this.bunifuImageButton8.Click += new EventHandler(this.BunifuImageButton8Click);
      this.panel2.BackColor = Color.LightYellow;
      this.panel2.Controls.Add((Control) this.pnMainTop);
      this.panel2.Controls.Add((Control) this.pnMainBot);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 21);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1100, 607);
      this.panel2.TabIndex = 1;
      this.pnMainTop.Controls.Add((Control) this.pnChatLog);
      this.pnMainTop.Dock = DockStyle.Fill;
      this.pnMainTop.Location = new Point(0, 0);
      this.pnMainTop.Name = "pnMainTop";
      this.pnMainTop.Size = new Size(1100, 535);
      this.pnMainTop.TabIndex = 1;
      this.pnChatLog.BackColor = Color.FromArgb(27, 40, 61);
      this.pnChatLog.Controls.Add((Control) this.pnEmo);
      this.pnChatLog.Controls.Add((Control) this.pnUrlImage);
      this.pnChatLog.Controls.Add((Control) this.wbChat);
      this.pnChatLog.Dock = DockStyle.Fill;
      this.pnChatLog.Location = new Point(0, 0);
      this.pnChatLog.Name = "pnChatLog";
      this.pnChatLog.Size = new Size(1100, 535);
      this.pnChatLog.TabIndex = 1;
      this.pnEmo.BackColor = Color.White;
      this.pnEmo.BorderStyle = BorderStyle.FixedSingle;
      this.pnEmo.Controls.Add((Control) this.emtion72);
      this.pnEmo.Controls.Add((Control) this.emtion63);
      this.pnEmo.Controls.Add((Control) this.emtion54);
      this.pnEmo.Controls.Add((Control) this.emtion45);
      this.pnEmo.Controls.Add((Control) this.emtion36);
      this.pnEmo.Controls.Add((Control) this.emtion27);
      this.pnEmo.Controls.Add((Control) this.emtion9);
      this.pnEmo.Controls.Add((Control) this.emtion18);
      this.pnEmo.Controls.Add((Control) this.emtion41);
      this.pnEmo.Controls.Add((Control) this.emtion57);
      this.pnEmo.Controls.Add((Control) this.emtion47);
      this.pnEmo.Controls.Add((Control) this.emtion71);
      this.pnEmo.Controls.Add((Control) this.emtion62);
      this.pnEmo.Controls.Add((Control) this.emtion53);
      this.pnEmo.Controls.Add((Control) this.emtion44);
      this.pnEmo.Controls.Add((Control) this.emtion35);
      this.pnEmo.Controls.Add((Control) this.emtion26);
      this.pnEmo.Controls.Add((Control) this.emtion8);
      this.pnEmo.Controls.Add((Control) this.emtion17);
      this.pnEmo.Controls.Add((Control) this.emtion70);
      this.pnEmo.Controls.Add((Control) this.emtion69);
      this.pnEmo.Controls.Add((Control) this.emtion68);
      this.pnEmo.Controls.Add((Control) this.emtion67);
      this.pnEmo.Controls.Add((Control) this.emtion66);
      this.pnEmo.Controls.Add((Control) this.emtion65);
      this.pnEmo.Controls.Add((Control) this.emtion64);
      this.pnEmo.Controls.Add((Control) this.emtion61);
      this.pnEmo.Controls.Add((Control) this.emtion60);
      this.pnEmo.Controls.Add((Control) this.emtion59);
      this.pnEmo.Controls.Add((Control) this.emtion58);
      this.pnEmo.Controls.Add((Control) this.emtion56);
      this.pnEmo.Controls.Add((Control) this.emtion55);
      this.pnEmo.Controls.Add((Control) this.emtion52);
      this.pnEmo.Controls.Add((Control) this.emtion50);
      this.pnEmo.Controls.Add((Control) this.emtion49);
      this.pnEmo.Controls.Add((Control) this.emtion48);
      this.pnEmo.Controls.Add((Control) this.emtion46);
      this.pnEmo.Controls.Add((Control) this.emtion43);
      this.pnEmo.Controls.Add((Control) this.emtion42);
      this.pnEmo.Controls.Add((Control) this.emtion40);
      this.pnEmo.Controls.Add((Control) this.emtion39);
      this.pnEmo.Controls.Add((Control) this.emtion38);
      this.pnEmo.Controls.Add((Control) this.emtion37);
      this.pnEmo.Controls.Add((Control) this.emtion34);
      this.pnEmo.Controls.Add((Control) this.emtion33);
      this.pnEmo.Controls.Add((Control) this.emtion32);
      this.pnEmo.Controls.Add((Control) this.emtion31);
      this.pnEmo.Controls.Add((Control) this.emtion30);
      this.pnEmo.Controls.Add((Control) this.emtion29);
      this.pnEmo.Controls.Add((Control) this.emtion28);
      this.pnEmo.Controls.Add((Control) this.emtion4);
      this.pnEmo.Controls.Add((Control) this.emtion1);
      this.pnEmo.Controls.Add((Control) this.emtion2);
      this.pnEmo.Controls.Add((Control) this.emtion25);
      this.pnEmo.Controls.Add((Control) this.emtion3);
      this.pnEmo.Controls.Add((Control) this.emtion24);
      this.pnEmo.Controls.Add((Control) this.emtion5);
      this.pnEmo.Controls.Add((Control) this.emtion23);
      this.pnEmo.Controls.Add((Control) this.emtion6);
      this.pnEmo.Controls.Add((Control) this.emtion22);
      this.pnEmo.Controls.Add((Control) this.emtion7);
      this.pnEmo.Controls.Add((Control) this.emtion21);
      this.pnEmo.Controls.Add((Control) this.emtion20);
      this.pnEmo.Controls.Add((Control) this.emtion14);
      this.pnEmo.Controls.Add((Control) this.emtion19);
      this.pnEmo.Controls.Add((Control) this.emtion10);
      this.pnEmo.Controls.Add((Control) this.emtion11);
      this.pnEmo.Controls.Add((Control) this.emtion16);
      this.pnEmo.Controls.Add((Control) this.emtion12);
      this.pnEmo.Controls.Add((Control) this.emtion15);
      this.pnEmo.Controls.Add((Control) this.emtion13);
      this.pnEmo.ForeColor = Color.DimGray;
      this.pnEmo.Location = new Point(186, 338);
      this.pnEmo.Name = "pnEmo";
      this.pnEmo.Size = new Size(430, 195);
      this.pnEmo.TabIndex = 9;
      this.pnEmo.Visible = false;
      this.emtion72.BackColor = Color.White;
      this.emtion72.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion72.Cursor = Cursors.Hand;
      this.emtion72.ErrorImage = (Image) componentResourceManager.GetObject("emtion72.ErrorImage");
      this.emtion72.Image = (Image) componentResourceManager.GetObject("emtion72.Image");
      this.emtion72.ImageActive = (Image) null;
      this.emtion72.Location = new Point(239, 121);
      this.emtion72.Name = "emtion72";
      this.emtion72.Size = new Size(44, 18);
      this.emtion72.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion72.TabIndex = 104;
      this.emtion72.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion72, ":-q");
      this.emtion72.Zoom = 5;
      this.emtion72.Click += new EventHandler(this.Emtion1Click);
      this.emtion63.BackColor = Color.White;
      this.emtion63.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion63.Cursor = Cursors.Hand;
      this.emtion63.ErrorImage = (Image) componentResourceManager.GetObject("emtion63.ErrorImage");
      this.emtion63.Image = (Image) componentResourceManager.GetObject("emtion63.Image");
      this.emtion63.ImageActive = (Image) null;
      this.emtion63.Location = new Point(385, 145);
      this.emtion63.Name = "emtion63";
      this.emtion63.Size = new Size(44, 18);
      this.emtion63.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion63.TabIndex = 103;
      this.emtion63.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion63, ":-c");
      this.emtion63.Zoom = 5;
      this.emtion63.Click += new EventHandler(this.Emtion1Click);
      this.emtion54.BackColor = Color.White;
      this.emtion54.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion54.Cursor = Cursors.Hand;
      this.emtion54.ErrorImage = (Image) componentResourceManager.GetObject("emtion54.ErrorImage");
      this.emtion54.Image = (Image) componentResourceManager.GetObject("emtion54.Image");
      this.emtion54.ImageActive = (Image) null;
      this.emtion54.Location = new Point(378, 122);
      this.emtion54.Name = "emtion54";
      this.emtion54.Size = new Size(44, 18);
      this.emtion54.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion54.TabIndex = 102;
      this.emtion54.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion54, "\\:D/");
      this.emtion54.Zoom = 5;
      this.emtion54.Click += new EventHandler(this.Emtion1Click);
      this.emtion45.BackColor = Color.White;
      this.emtion45.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion45.Cursor = Cursors.Hand;
      this.emtion45.ErrorImage = (Image) componentResourceManager.GetObject("emtion45.ErrorImage");
      this.emtion45.Image = (Image) componentResourceManager.GetObject("emtion45.Image");
      this.emtion45.ImageActive = (Image) null;
      this.emtion45.Location = new Point(380, 99);
      this.emtion45.Name = "emtion45";
      this.emtion45.Size = new Size(44, 18);
      this.emtion45.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion45.TabIndex = 101;
      this.emtion45.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion45, "~O)");
      this.emtion45.Zoom = 5;
      this.emtion45.Click += new EventHandler(this.Emtion1Click);
      this.emtion36.BackColor = Color.White;
      this.emtion36.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion36.Cursor = Cursors.Hand;
      this.emtion36.ErrorImage = (Image) componentResourceManager.GetObject("emtion36.ErrorImage");
      this.emtion36.Image = (Image) componentResourceManager.GetObject("emtion36.Image");
      this.emtion36.ImageActive = (Image) null;
      this.emtion36.Location = new Point(380, 75);
      this.emtion36.Name = "emtion36";
      this.emtion36.Size = new Size(44, 18);
      this.emtion36.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion36.TabIndex = 100;
      this.emtion36.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion36, "=D]");
      this.emtion36.Zoom = 5;
      this.emtion36.Click += new EventHandler(this.Emtion1Click);
      this.emtion27.BackColor = Color.White;
      this.emtion27.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion27.Cursor = Cursors.Hand;
      this.emtion27.ErrorImage = (Image) componentResourceManager.GetObject("emtion27.ErrorImage");
      this.emtion27.Image = (Image) componentResourceManager.GetObject("emtion27.Image");
      this.emtion27.ImageActive = (Image) null;
      this.emtion27.Location = new Point(380, 52);
      this.emtion27.Name = "emtion27";
      this.emtion27.Size = new Size(44, 18);
      this.emtion27.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion27.TabIndex = 99;
      this.emtion27.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion27, "8-|");
      this.emtion27.Zoom = 5;
      this.emtion27.Click += new EventHandler(this.Emtion1Click);
      this.emtion9.BackColor = Color.White;
      this.emtion9.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion9.Cursor = Cursors.Hand;
      this.emtion9.ErrorImage = (Image) componentResourceManager.GetObject("emtion9.ErrorImage");
      this.emtion9.Image = (Image) componentResourceManager.GetObject("emtion9.Image");
      this.emtion9.ImageActive = (Image) null;
      this.emtion9.Location = new Point(380, 4);
      this.emtion9.Name = "emtion9";
      this.emtion9.Size = new Size(44, 18);
      this.emtion9.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion9.TabIndex = 97;
      this.emtion9.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion9, ":'}");
      this.emtion9.Zoom = 5;
      this.emtion9.Click += new EventHandler(this.Emtion1Click);
      this.emtion18.BackColor = Color.White;
      this.emtion18.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion18.Cursor = Cursors.Hand;
      this.emtion18.ErrorImage = (Image) componentResourceManager.GetObject("emtion18.ErrorImage");
      this.emtion18.Image = (Image) componentResourceManager.GetObject("emtion18.Image");
      this.emtion18.ImageActive = (Image) null;
      this.emtion18.Location = new Point(380, 28);
      this.emtion18.Name = "emtion18";
      this.emtion18.Size = new Size(44, 18);
      this.emtion18.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion18.TabIndex = 98;
      this.emtion18.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion18, ":((");
      this.emtion18.Zoom = 5;
      this.emtion18.Click += new EventHandler(this.Emtion1Click);
      this.emtion41.BackColor = Color.White;
      this.emtion41.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion41.Cursor = Cursors.Hand;
      this.emtion41.ErrorImage = (Image) componentResourceManager.GetObject("emtion41.ErrorImage");
      this.emtion41.Image = (Image) componentResourceManager.GetObject("emtion41.Image");
      this.emtion41.ImageActive = (Image) null;
      this.emtion41.Location = new Point(192, 99);
      this.emtion41.Name = "emtion41";
      this.emtion41.Size = new Size(44, 18);
      this.emtion41.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion41.TabIndex = 83;
      this.emtion41.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion41, ":ar!");
      this.emtion41.Zoom = 5;
      this.emtion41.Click += new EventHandler(this.Emtion1Click);
      this.emtion57.BackColor = Color.White;
      this.emtion57.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion57.Cursor = Cursors.Hand;
      this.emtion57.ErrorImage = (Image) componentResourceManager.GetObject("emtion57.ErrorImage");
      this.emtion57.Image = (Image) componentResourceManager.GetObject("emtion57.Image");
      this.emtion57.ImageActive = (Image) null;
      this.emtion57.Location = new Point(98, 145);
      this.emtion57.Name = "emtion57";
      this.emtion57.Size = new Size(44, 18);
      this.emtion57.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion57.TabIndex = 82;
      this.emtion57.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion57, "^#(^");
      this.emtion57.Zoom = 5;
      this.emtion57.Click += new EventHandler(this.Emtion1Click);
      this.emtion47.BackColor = Color.White;
      this.emtion47.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion47.Cursor = Cursors.Hand;
      this.emtion47.ErrorImage = (Image) componentResourceManager.GetObject("emtion47.ErrorImage");
      this.emtion47.Image = (Image) componentResourceManager.GetObject("emtion47.Image");
      this.emtion47.ImageActive = (Image) null;
      this.emtion47.Location = new Point(51, 122);
      this.emtion47.Name = "emtion47";
      this.emtion47.Size = new Size(44, 18);
      this.emtion47.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion47.TabIndex = 81;
      this.emtion47.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion47, ":-bd");
      this.emtion47.Zoom = 5;
      this.emtion47.Click += new EventHandler(this.Emtion1Click);
      this.emtion71.BackColor = Color.White;
      this.emtion71.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion71.Cursor = Cursors.Hand;
      this.emtion71.ErrorImage = (Image) componentResourceManager.GetObject("emtion71.ErrorImage");
      this.emtion71.Image = (Image) componentResourceManager.GetObject("emtion71.Image");
      this.emtion71.ImageActive = (Image) null;
      this.emtion71.Location = new Point(330, 169);
      this.emtion71.Name = "emtion71";
      this.emtion71.Size = new Size(44, 18);
      this.emtion71.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion71.TabIndex = 80;
      this.emtion71.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion71, "\\m/");
      this.emtion71.Zoom = 5;
      this.emtion71.Click += new EventHandler(this.Emtion1Click);
      this.emtion62.BackColor = Color.White;
      this.emtion62.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion62.Cursor = Cursors.Hand;
      this.emtion62.ErrorImage = (Image) componentResourceManager.GetObject("emtion62.ErrorImage");
      this.emtion62.Image = (Image) componentResourceManager.GetObject("emtion62.Image");
      this.emtion62.ImageActive = (Image) null;
      this.emtion62.Location = new Point(334, 145);
      this.emtion62.Name = "emtion62";
      this.emtion62.Size = new Size(44, 18);
      this.emtion62.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion62.TabIndex = 79;
      this.emtion62.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion62, ":)]");
      this.emtion62.Zoom = 5;
      this.emtion62.Click += new EventHandler(this.Emtion1Click);
      this.emtion53.BackColor = Color.White;
      this.emtion53.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion53.Cursor = Cursors.Hand;
      this.emtion53.ErrorImage = (Image) componentResourceManager.GetObject("emtion53.ErrorImage");
      this.emtion53.Image = (Image) componentResourceManager.GetObject("emtion53.Image");
      this.emtion53.ImageActive = (Image) null;
      this.emtion53.Location = new Point(332, 122);
      this.emtion53.Name = "emtion53";
      this.emtion53.Size = new Size(44, 18);
      this.emtion53.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion53.TabIndex = 78;
      this.emtion53.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion53, "[-X");
      this.emtion53.Zoom = 5;
      this.emtion53.Click += new EventHandler(this.Emtion1Click);
      this.emtion44.BackColor = Color.White;
      this.emtion44.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion44.Cursor = Cursors.Hand;
      this.emtion44.ErrorImage = (Image) componentResourceManager.GetObject("emtion44.ErrorImage");
      this.emtion44.Image = (Image) componentResourceManager.GetObject("emtion44.Image");
      this.emtion44.ImageActive = (Image) null;
      this.emtion44.Location = new Point(333, 99);
      this.emtion44.Name = "emtion44";
      this.emtion44.Size = new Size(44, 18);
      this.emtion44.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion44.TabIndex = 77;
      this.emtion44.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion44, "%%-");
      this.emtion44.Zoom = 5;
      this.emtion44.Click += new EventHandler(this.Emtion1Click);
      this.emtion35.BackColor = Color.White;
      this.emtion35.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion35.Cursor = Cursors.Hand;
      this.emtion35.ErrorImage = (Image) componentResourceManager.GetObject("emtion35.ErrorImage");
      this.emtion35.Image = (Image) componentResourceManager.GetObject("emtion35.Image");
      this.emtion35.ImageActive = (Image) null;
      this.emtion35.Location = new Point(335, 75);
      this.emtion35.Name = "emtion35";
      this.emtion35.Size = new Size(44, 18);
      this.emtion35.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion35.TabIndex = 76;
      this.emtion35.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion35, "#-(");
      this.emtion35.Zoom = 5;
      this.emtion35.Click += new EventHandler(this.Emtion1Click);
      this.emtion26.BackColor = Color.White;
      this.emtion26.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion26.Cursor = Cursors.Hand;
      this.emtion26.ErrorImage = (Image) componentResourceManager.GetObject("emtion26.ErrorImage");
      this.emtion26.Image = (Image) componentResourceManager.GetObject("emtion26.Image");
      this.emtion26.ImageActive = (Image) null;
      this.emtion26.Location = new Point(335, 52);
      this.emtion26.Name = "emtion26";
      this.emtion26.Size = new Size(44, 18);
      this.emtion26.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion26.TabIndex = 75;
      this.emtion26.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion26, "|-)");
      this.emtion26.Zoom = 5;
      this.emtion26.Click += new EventHandler(this.Emtion1Click);
      this.emtion8.BackColor = Color.White;
      this.emtion8.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion8.Cursor = Cursors.Hand;
      this.emtion8.ErrorImage = (Image) componentResourceManager.GetObject("emtion8.ErrorImage");
      this.emtion8.Image = (Image) componentResourceManager.GetObject("emtion8.Image");
      this.emtion8.ImageActive = (Image) null;
      this.emtion8.Location = new Point(333, 4);
      this.emtion8.Name = "emtion8";
      this.emtion8.Size = new Size(44, 18);
      this.emtion8.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion8.TabIndex = 73;
      this.emtion8.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion8, ":x");
      this.emtion8.Zoom = 5;
      this.emtion8.Click += new EventHandler(this.Emtion1Click);
      this.emtion17.BackColor = Color.White;
      this.emtion17.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion17.Cursor = Cursors.Hand;
      this.emtion17.ErrorImage = (Image) componentResourceManager.GetObject("emtion17.ErrorImage");
      this.emtion17.Image = (Image) componentResourceManager.GetObject("emtion17.Image");
      this.emtion17.ImageActive = (Image) null;
      this.emtion17.Location = new Point(333, 28);
      this.emtion17.Name = "emtion17";
      this.emtion17.Size = new Size(44, 18);
      this.emtion17.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion17.TabIndex = 74;
      this.emtion17.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion17, ":-S");
      this.emtion17.Zoom = 5;
      this.emtion17.Click += new EventHandler(this.Emtion1Click);
      this.emtion70.BackColor = Color.White;
      this.emtion70.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion70.Cursor = Cursors.Hand;
      this.emtion70.ErrorImage = (Image) componentResourceManager.GetObject("emtion70.ErrorImage");
      this.emtion70.Image = (Image) componentResourceManager.GetObject("emtion70.Image");
      this.emtion70.ImageActive = (Image) null;
      this.emtion70.Location = new Point(291, 169);
      this.emtion70.Name = "emtion70";
      this.emtion70.Size = new Size(44, 18);
      this.emtion70.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion70.TabIndex = 72;
      this.emtion70.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion70, ":!!");
      this.emtion70.Zoom = 5;
      this.emtion70.Click += new EventHandler(this.Emtion1Click);
      this.emtion69.BackColor = Color.White;
      this.emtion69.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion69.Cursor = Cursors.Hand;
      this.emtion69.ErrorImage = (Image) componentResourceManager.GetObject("emtion69.ErrorImage");
      this.emtion69.Image = (Image) componentResourceManager.GetObject("emtion69.Image");
      this.emtion69.ImageActive = (Image) null;
      this.emtion69.Location = new Point(240, 169);
      this.emtion69.Name = "emtion69";
      this.emtion69.Size = new Size(44, 18);
      this.emtion69.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion69.TabIndex = 71;
      this.emtion69.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion69, "X_X");
      this.emtion69.Zoom = 5;
      this.emtion69.Click += new EventHandler(this.Emtion1Click);
      this.emtion68.BackColor = Color.White;
      this.emtion68.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion68.Cursor = Cursors.Hand;
      this.emtion68.ErrorImage = (Image) componentResourceManager.GetObject("emtion68.ErrorImage");
      this.emtion68.Image = (Image) componentResourceManager.GetObject("emtion68.Image");
      this.emtion68.ImageActive = (Image) null;
      this.emtion68.Location = new Point(192, 169);
      this.emtion68.Name = "emtion68";
      this.emtion68.Size = new Size(44, 18);
      this.emtion68.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion68.TabIndex = 70;
      this.emtion68.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion68, ":-??");
      this.emtion68.Zoom = 5;
      this.emtion68.Click += new EventHandler(this.Emtion1Click);
      this.emtion67.BackColor = Color.White;
      this.emtion67.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion67.Cursor = Cursors.Hand;
      this.emtion67.ErrorImage = (Image) componentResourceManager.GetObject("emtion67.ErrorImage");
      this.emtion67.Image = (Image) componentResourceManager.GetObject("emtion67.Image");
      this.emtion67.ImageActive = (Image) null;
      this.emtion67.Location = new Point(144, 169);
      this.emtion67.Name = "emtion67";
      this.emtion67.Size = new Size(44, 18);
      this.emtion67.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion67.TabIndex = 69;
      this.emtion67.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion67, "8-)");
      this.emtion67.Zoom = 5;
      this.emtion67.Click += new EventHandler(this.Emtion1Click);
      this.emtion66.BackColor = Color.White;
      this.emtion66.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion66.Cursor = Cursors.Hand;
      this.emtion66.ErrorImage = (Image) componentResourceManager.GetObject("emtion66.ErrorImage");
      this.emtion66.Image = (Image) componentResourceManager.GetObject("emtion66.Image");
      this.emtion66.ImageActive = (Image) null;
      this.emtion66.Location = new Point(93, 169);
      this.emtion66.Name = "emtion66";
      this.emtion66.Size = new Size(40, 18);
      this.emtion66.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion66.TabIndex = 68;
      this.emtion66.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion66, ":-t");
      this.emtion66.Zoom = 5;
      this.emtion66.Click += new EventHandler(this.Emtion1Click);
      this.emtion65.BackColor = Color.White;
      this.emtion65.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion65.Cursor = Cursors.Hand;
      this.emtion65.ErrorImage = (Image) componentResourceManager.GetObject("emtion65.ErrorImage");
      this.emtion65.Image = (Image) componentResourceManager.GetObject("emtion65.Image");
      this.emtion65.ImageActive = (Image) null;
      this.emtion65.Location = new Point(55, 169);
      this.emtion65.Name = "emtion65";
      this.emtion65.Size = new Size(44, 18);
      this.emtion65.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion65.TabIndex = 67;
      this.emtion65.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion65, ":-h");
      this.emtion65.Zoom = 5;
      this.emtion65.Click += new EventHandler(this.Emtion1Click);
      this.emtion64.BackColor = Color.White;
      this.emtion64.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion64.Cursor = Cursors.Hand;
      this.emtion64.ErrorImage = (Image) componentResourceManager.GetObject("emtion64.ErrorImage");
      this.emtion64.Image = (Image) componentResourceManager.GetObject("emtion64.Image");
      this.emtion64.ImageActive = (Image) null;
      this.emtion64.Location = new Point(4, 169);
      this.emtion64.Name = "emtion64";
      this.emtion64.Size = new Size(44, 18);
      this.emtion64.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion64.TabIndex = 66;
      this.emtion64.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion64, "~X(");
      this.emtion64.Zoom = 5;
      this.emtion64.Click += new EventHandler(this.Emtion1Click);
      this.emtion61.BackColor = Color.White;
      this.emtion61.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion61.Cursor = Cursors.Hand;
      this.emtion61.ErrorImage = (Image) componentResourceManager.GetObject("emtion61.ErrorImage");
      this.emtion61.Image = (Image) componentResourceManager.GetObject("emtion61.Image");
      this.emtion61.ImageActive = (Image) null;
      this.emtion61.Location = new Point(286, 145);
      this.emtion61.Name = "emtion61";
      this.emtion61.Size = new Size(44, 18);
      this.emtion61.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion61.TabIndex = 65;
      this.emtion61.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion61, "(*)");
      this.emtion61.Zoom = 5;
      this.emtion61.Click += new EventHandler(this.Emtion1Click);
      this.emtion60.BackColor = Color.White;
      this.emtion60.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion60.Cursor = Cursors.Hand;
      this.emtion60.ErrorImage = (Image) componentResourceManager.GetObject("emtion60.ErrorImage");
      this.emtion60.Image = (Image) componentResourceManager.GetObject("emtion60.Image");
      this.emtion60.ImageActive = (Image) null;
      this.emtion60.Location = new Point(240, 145);
      this.emtion60.Name = "emtion60";
      this.emtion60.Size = new Size(44, 18);
      this.emtion60.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion60.TabIndex = 64;
      this.emtion60.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion60, ":-j");
      this.emtion60.Zoom = 5;
      this.emtion60.Click += new EventHandler(this.Emtion1Click);
      this.emtion59.BackColor = Color.White;
      this.emtion59.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion59.Cursor = Cursors.Hand;
      this.emtion59.ErrorImage = (Image) componentResourceManager.GetObject("emtion59.ErrorImage");
      this.emtion59.Image = (Image) componentResourceManager.GetObject("emtion59.Image");
      this.emtion59.ImageActive = (Image) null;
      this.emtion59.Location = new Point(192, 145);
      this.emtion59.Name = "emtion59";
      this.emtion59.Size = new Size(44, 18);
      this.emtion59.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion59.TabIndex = 63;
      this.emtion59.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion59, "^:)^");
      this.emtion59.Zoom = 5;
      this.emtion59.Click += new EventHandler(this.Emtion1Click);
      this.emtion58.BackColor = Color.White;
      this.emtion58.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion58.Cursor = Cursors.Hand;
      this.emtion58.ErrorImage = (Image) componentResourceManager.GetObject("emtion58.ErrorImage");
      this.emtion58.Image = (Image) componentResourceManager.GetObject("emtion58.Image");
      this.emtion58.ImageActive = (Image) null;
      this.emtion58.Location = new Point(154, 145);
      this.emtion58.Name = "emtion58";
      this.emtion58.Size = new Size(40, 18);
      this.emtion58.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion58.TabIndex = 62;
      this.emtion58.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion58, ":-@");
      this.emtion58.Zoom = 5;
      this.emtion58.Click += new EventHandler(this.Emtion1Click);
      this.emtion56.BackColor = Color.White;
      this.emtion56.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion56.Cursor = Cursors.Hand;
      this.emtion56.ErrorImage = (Image) componentResourceManager.GetObject("emtion56.ErrorImage");
      this.emtion56.Image = (Image) componentResourceManager.GetObject("emtion56.Image");
      this.emtion56.ImageActive = (Image) null;
      this.emtion56.Location = new Point(51, 145);
      this.emtion56.Name = "emtion56";
      this.emtion56.Size = new Size(44, 18);
      this.emtion56.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion56.TabIndex = 60;
      this.emtion56.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion56, ";))");
      this.emtion56.Zoom = 5;
      this.emtion56.Click += new EventHandler(this.Emtion1Click);
      this.emtion55.BackColor = Color.White;
      this.emtion55.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion55.Cursor = Cursors.Hand;
      this.emtion55.ErrorImage = (Image) componentResourceManager.GetObject("emtion55.ErrorImage");
      this.emtion55.Image = (Image) componentResourceManager.GetObject("emtion55.Image");
      this.emtion55.ImageActive = (Image) null;
      this.emtion55.Location = new Point(4, 145);
      this.emtion55.Name = "emtion55";
      this.emtion55.Size = new Size(44, 18);
      this.emtion55.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion55.TabIndex = 59;
      this.emtion55.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion55, "=:/");
      this.emtion55.Zoom = 5;
      this.emtion55.Click += new EventHandler(this.Emtion1Click);
      this.emtion52.BackColor = Color.White;
      this.emtion52.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion52.Cursor = Cursors.Hand;
      this.emtion52.ErrorImage = (Image) componentResourceManager.GetObject("emtion52.ErrorImage");
      this.emtion52.Image = (Image) componentResourceManager.GetObject("emtion52.Image");
      this.emtion52.ImageActive = (Image) null;
      this.emtion52.Location = new Point(285, 122);
      this.emtion52.Name = "emtion52";
      this.emtion52.Size = new Size(44, 18);
      this.emtion52.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion52.TabIndex = 58;
      this.emtion52.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion52, "#-o");
      this.emtion52.Zoom = 5;
      this.emtion52.Click += new EventHandler(this.Emtion1Click);
      this.emtion50.BackColor = Color.White;
      this.emtion50.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion50.Cursor = Cursors.Hand;
      this.emtion50.ErrorImage = (Image) componentResourceManager.GetObject("emtion50.ErrorImage");
      this.emtion50.Image = (Image) componentResourceManager.GetObject("emtion50.Image");
      this.emtion50.ImageActive = (Image) null;
      this.emtion50.Location = new Point(193, 122);
      this.emtion50.Name = "emtion50";
      this.emtion50.Size = new Size(44, 18);
      this.emtion50.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion50.TabIndex = 56;
      this.emtion50.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion50, ":-'");
      this.emtion50.Zoom = 5;
      this.emtion50.Click += new EventHandler(this.Emtion1Click);
      this.emtion49.BackColor = Color.White;
      this.emtion49.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion49.Cursor = Cursors.Hand;
      this.emtion49.ErrorImage = (Image) componentResourceManager.GetObject("emtion49.ErrorImage");
      this.emtion49.Image = (Image) componentResourceManager.GetObject("emtion49.Image");
      this.emtion49.ImageActive = (Image) null;
      this.emtion49.Location = new Point(143, 122);
      this.emtion49.Name = "emtion49";
      this.emtion49.Size = new Size(44, 18);
      this.emtion49.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion49.TabIndex = 55;
      this.emtion49.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion49, "$-)");
      this.emtion49.Zoom = 5;
      this.emtion49.Click += new EventHandler(this.Emtion1Click);
      this.emtion48.BackColor = Color.White;
      this.emtion48.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion48.Cursor = Cursors.Hand;
      this.emtion48.ErrorImage = (Image) componentResourceManager.GetObject("emtion48.ErrorImage");
      this.emtion48.Image = (Image) componentResourceManager.GetObject("emtion48.Image");
      this.emtion48.ImageActive = (Image) null;
      this.emtion48.Location = new Point(98, 122);
      this.emtion48.Name = "emtion48";
      this.emtion48.Size = new Size(44, 18);
      this.emtion48.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion48.TabIndex = 54;
      this.emtion48.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion48, "[-O]");
      this.emtion48.Zoom = 5;
      this.emtion48.Click += new EventHandler(this.Emtion1Click);
      this.emtion46.BackColor = Color.White;
      this.emtion46.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion46.Cursor = Cursors.Hand;
      this.emtion46.ErrorImage = (Image) componentResourceManager.GetObject("emtion46.ErrorImage");
      this.emtion46.Image = (Image) componentResourceManager.GetObject("emtion46.Image");
      this.emtion46.ImageActive = (Image) null;
      this.emtion46.Location = new Point(4, 122);
      this.emtion46.Name = "emtion46";
      this.emtion46.Size = new Size(44, 18);
      this.emtion46.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion46.TabIndex = 52;
      this.emtion46.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion46, ":-O");
      this.emtion46.Zoom = 5;
      this.emtion46.Click += new EventHandler(this.Emtion1Click);
      this.emtion43.BackColor = Color.White;
      this.emtion43.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion43.Cursor = Cursors.Hand;
      this.emtion43.ErrorImage = (Image) componentResourceManager.GetObject("emtion43.ErrorImage");
      this.emtion43.Image = (Image) componentResourceManager.GetObject("emtion43.Image");
      this.emtion43.ImageActive = (Image) null;
      this.emtion43.Location = new Point(286, 99);
      this.emtion43.Name = "emtion43";
      this.emtion43.Size = new Size(44, 18);
      this.emtion43.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion43.TabIndex = 51;
      this.emtion43.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion43, "@};-");
      this.emtion43.Zoom = 5;
      this.emtion43.Click += new EventHandler(this.Emtion1Click);
      this.emtion42.BackColor = Color.White;
      this.emtion42.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion42.Cursor = Cursors.Hand;
      this.emtion42.ErrorImage = (Image) componentResourceManager.GetObject("emtion42.ErrorImage");
      this.emtion42.Image = (Image) componentResourceManager.GetObject("emtion42.Image");
      this.emtion42.ImageActive = (Image) null;
      this.emtion42.Location = new Point(239, 99);
      this.emtion42.Name = "emtion42";
      this.emtion42.Size = new Size(44, 18);
      this.emtion42.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion42.TabIndex = 50;
      this.emtion42.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion42, "[:P");
      this.emtion42.Zoom = 5;
      this.emtion42.Click += new EventHandler(this.Emtion1Click);
      this.emtion40.BackColor = Color.White;
      this.emtion40.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion40.Cursor = Cursors.Hand;
      this.emtion40.ErrorImage = (Image) componentResourceManager.GetObject("emtion40.ErrorImage");
      this.emtion40.Image = (Image) componentResourceManager.GetObject("emtion40.Image");
      this.emtion40.ImageActive = (Image) null;
      this.emtion40.Location = new Point(146, 99);
      this.emtion40.Name = "emtion40";
      this.emtion40.Size = new Size(44, 18);
      this.emtion40.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion40.TabIndex = 48;
      this.emtion40.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion40, ":-w");
      this.emtion40.Zoom = 5;
      this.emtion40.Click += new EventHandler(this.Emtion1Click);
      this.emtion39.BackColor = Color.White;
      this.emtion39.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion39.Cursor = Cursors.Hand;
      this.emtion39.ErrorImage = (Image) componentResourceManager.GetObject("emtion39.ErrorImage");
      this.emtion39.Image = (Image) componentResourceManager.GetObject("emtion39.Image");
      this.emtion39.ImageActive = (Image) null;
      this.emtion39.Location = new Point(98, 99);
      this.emtion39.Name = "emtion39";
      this.emtion39.Size = new Size(44, 18);
      this.emtion39.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion39.TabIndex = 47;
      this.emtion39.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion39, ":^o");
      this.emtion39.Zoom = 5;
      this.emtion39.Click += new EventHandler(this.Emtion1Click);
      this.emtion38.BackColor = Color.White;
      this.emtion38.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion38.Cursor = Cursors.Hand;
      this.emtion38.ErrorImage = (Image) componentResourceManager.GetObject("emtion38.ErrorImage");
      this.emtion38.Image = (Image) componentResourceManager.GetObject("emtion38.Image");
      this.emtion38.ImageActive = (Image) null;
      this.emtion38.Location = new Point(51, 99);
      this.emtion38.Name = "emtion38";
      this.emtion38.Size = new Size(44, 18);
      this.emtion38.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion38.TabIndex = 46;
      this.emtion38.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion38, "@-)");
      this.emtion38.Zoom = 5;
      this.emtion38.Click += new EventHandler(this.Emtion1Click);
      this.emtion37.BackColor = Color.White;
      this.emtion37.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion37.Cursor = Cursors.Hand;
      this.emtion37.ErrorImage = (Image) componentResourceManager.GetObject("emtion37.ErrorImage");
      this.emtion37.Image = (Image) componentResourceManager.GetObject("emtion37.Image");
      this.emtion37.ImageActive = (Image) null;
      this.emtion37.Location = new Point(5, 99);
      this.emtion37.Name = "emtion37";
      this.emtion37.Size = new Size(44, 18);
      this.emtion37.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion37.TabIndex = 45;
      this.emtion37.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion37, ":-SS");
      this.emtion37.Zoom = 5;
      this.emtion37.Click += new EventHandler(this.Emtion1Click);
      this.emtion34.BackColor = Color.White;
      this.emtion34.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion34.Cursor = Cursors.Hand;
      this.emtion34.ErrorImage = (Image) componentResourceManager.GetObject("emtion34.ErrorImage");
      this.emtion34.Image = (Image) componentResourceManager.GetObject("emtion34.Image");
      this.emtion34.ImageActive = (Image) null;
      this.emtion34.Location = new Point(286, 75);
      this.emtion34.Name = "emtion34";
      this.emtion34.Size = new Size(44, 18);
      this.emtion34.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion34.TabIndex = 44;
      this.emtion34.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion34, ":-?");
      this.emtion34.Zoom = 5;
      this.emtion34.Click += new EventHandler(this.Emtion1Click);
      this.emtion33.BackColor = Color.White;
      this.emtion33.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion33.Cursor = Cursors.Hand;
      this.emtion33.ErrorImage = (Image) componentResourceManager.GetObject("emtion33.ErrorImage");
      this.emtion33.Image = (Image) componentResourceManager.GetObject("emtion33.Image");
      this.emtion33.ImageActive = (Image) null;
      this.emtion33.Location = new Point(239, 75);
      this.emtion33.Name = "emtion33";
      this.emtion33.Size = new Size(44, 18);
      this.emtion33.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion33.TabIndex = 43;
      this.emtion33.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion33, "=P~");
      this.emtion33.Zoom = 5;
      this.emtion33.Click += new EventHandler(this.Emtion1Click);
      this.emtion32.BackColor = Color.White;
      this.emtion32.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion32.Cursor = Cursors.Hand;
      this.emtion32.ErrorImage = (Image) componentResourceManager.GetObject("emtion32.ErrorImage");
      this.emtion32.Image = (Image) componentResourceManager.GetObject("emtion32.Image");
      this.emtion32.ImageActive = (Image) null;
      this.emtion32.Location = new Point(192, 75);
      this.emtion32.Name = "emtion32";
      this.emtion32.Size = new Size(44, 18);
      this.emtion32.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion32.TabIndex = 42;
      this.emtion32.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion32, "(:|");
      this.emtion32.Zoom = 5;
      this.emtion32.Click += new EventHandler(this.Emtion1Click);
      this.emtion31.BackColor = Color.White;
      this.emtion31.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion31.Cursor = Cursors.Hand;
      this.emtion31.ErrorImage = (Image) componentResourceManager.GetObject("emtion31.ErrorImage");
      this.emtion31.Image = (Image) componentResourceManager.GetObject("emtion31.Image");
      this.emtion31.ImageActive = (Image) null;
      this.emtion31.Location = new Point(145, 75);
      this.emtion31.Name = "emtion31";
      this.emtion31.Size = new Size(44, 18);
      this.emtion31.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion31.TabIndex = 41;
      this.emtion31.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion31, "8-}");
      this.emtion31.Zoom = 5;
      this.emtion31.Click += new EventHandler(this.Emtion1Click);
      this.emtion30.BackColor = Color.White;
      this.emtion30.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion30.Cursor = Cursors.Hand;
      this.emtion30.ErrorImage = (Image) componentResourceManager.GetObject("emtion30.ErrorImage");
      this.emtion30.Image = (Image) componentResourceManager.GetObject("emtion30.Image");
      this.emtion30.ImageActive = (Image) null;
      this.emtion30.Location = new Point(98, 75);
      this.emtion30.Name = "emtion30";
      this.emtion30.Size = new Size(44, 18);
      this.emtion30.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion30.TabIndex = 40;
      this.emtion30.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion30, "[-(");
      this.emtion30.Zoom = 5;
      this.emtion30.Click += new EventHandler(this.Emtion1Click);
      this.emtion29.BackColor = Color.White;
      this.emtion29.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion29.Cursor = Cursors.Hand;
      this.emtion29.ErrorImage = (Image) componentResourceManager.GetObject("emtion29.ErrorImage");
      this.emtion29.Image = (Image) componentResourceManager.GetObject("emtion29.Image");
      this.emtion29.ImageActive = (Image) null;
      this.emtion29.Location = new Point(51, 75);
      this.emtion29.Name = "emtion29";
      this.emtion29.Size = new Size(44, 18);
      this.emtion29.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion29.TabIndex = 39;
      this.emtion29.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion29, ":-$");
      this.emtion29.Zoom = 5;
      this.emtion29.Click += new EventHandler(this.Emtion1Click);
      this.emtion28.BackColor = Color.White;
      this.emtion28.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion28.Cursor = Cursors.Hand;
      this.emtion28.ErrorImage = (Image) componentResourceManager.GetObject("emtion28.ErrorImage");
      this.emtion28.Image = (Image) componentResourceManager.GetObject("emtion28.Image");
      this.emtion28.ImageActive = (Image) null;
      this.emtion28.Location = new Point(2, 75);
      this.emtion28.Name = "emtion28";
      this.emtion28.Size = new Size(44, 18);
      this.emtion28.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion28.TabIndex = 38;
      this.emtion28.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion28, "L-)");
      this.emtion28.Zoom = 5;
      this.emtion28.Click += new EventHandler(this.Emtion1Click);
      this.emtion4.BackColor = Color.White;
      this.emtion4.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion4.Cursor = Cursors.Hand;
      this.emtion4.ErrorImage = (Image) componentResourceManager.GetObject("emtion4.ErrorImage");
      this.emtion4.Image = (Image) componentResourceManager.GetObject("emtion4.Image");
      this.emtion4.ImageActive = (Image) null;
      this.emtion4.Location = new Point(145, 4);
      this.emtion4.Name = "emtion4";
      this.emtion4.Size = new Size(44, 18);
      this.emtion4.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion4.TabIndex = 20;
      this.emtion4.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion4, ":D");
      this.emtion4.Zoom = 5;
      this.emtion4.Click += new EventHandler(this.Emtion1Click);
      this.emtion1.BackColor = Color.White;
      this.emtion1.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion1.Cursor = Cursors.Hand;
      this.emtion1.ErrorImage = (Image) componentResourceManager.GetObject("emtion1.ErrorImage");
      this.emtion1.Image = (Image) componentResourceManager.GetObject("emtion1.Image");
      this.emtion1.ImageActive = (Image) null;
      this.emtion1.Location = new Point(4, 4);
      this.emtion1.Name = "emtion1";
      this.emtion1.Size = new Size(44, 18);
      this.emtion1.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion1.TabIndex = 17;
      this.emtion1.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion1, ":)");
      this.emtion1.Zoom = 5;
      this.emtion1.Click += new EventHandler(this.Emtion1Click);
      this.emtion2.BackColor = Color.White;
      this.emtion2.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion2.Cursor = Cursors.Hand;
      this.emtion2.ErrorImage = (Image) componentResourceManager.GetObject("emtion2.ErrorImage");
      this.emtion2.Image = (Image) componentResourceManager.GetObject("emtion2.Image");
      this.emtion2.ImageActive = (Image) null;
      this.emtion2.Location = new Point(51, 4);
      this.emtion2.Name = "emtion2";
      this.emtion2.Size = new Size(44, 18);
      this.emtion2.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion2.TabIndex = 18;
      this.emtion2.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion2, ":(");
      this.emtion2.Zoom = 5;
      this.emtion2.Click += new EventHandler(this.Emtion1Click);
      this.emtion25.BackColor = Color.White;
      this.emtion25.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion25.Cursor = Cursors.Hand;
      this.emtion25.ErrorImage = (Image) componentResourceManager.GetObject("emtion25.ErrorImage");
      this.emtion25.Image = (Image) componentResourceManager.GetObject("emtion25.Image");
      this.emtion25.ImageActive = (Image) null;
      this.emtion25.Location = new Point(286, 52);
      this.emtion25.Name = "emtion25";
      this.emtion25.Size = new Size(44, 18);
      this.emtion25.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion25.TabIndex = 37;
      this.emtion25.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion25, "=;");
      this.emtion25.Zoom = 5;
      this.emtion25.Click += new EventHandler(this.Emtion1Click);
      this.emtion3.BackColor = Color.White;
      this.emtion3.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion3.Cursor = Cursors.Hand;
      this.emtion3.ErrorImage = (Image) componentResourceManager.GetObject("emtion3.ErrorImage");
      this.emtion3.Image = (Image) componentResourceManager.GetObject("emtion3.Image");
      this.emtion3.ImageActive = (Image) null;
      this.emtion3.Location = new Point(98, 4);
      this.emtion3.Name = "emtion3";
      this.emtion3.Size = new Size(44, 18);
      this.emtion3.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion3.TabIndex = 19;
      this.emtion3.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion3, ";)");
      this.emtion3.Zoom = 5;
      this.emtion3.Click += new EventHandler(this.Emtion1Click);
      this.emtion24.BackColor = Color.White;
      this.emtion24.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion24.Cursor = Cursors.Hand;
      this.emtion24.ErrorImage = (Image) componentResourceManager.GetObject("emtion24.ErrorImage");
      this.emtion24.Image = (Image) componentResourceManager.GetObject("emtion24.Image");
      this.emtion24.ImageActive = (Image) null;
      this.emtion24.Location = new Point(241, 52);
      this.emtion24.Name = "emtion24";
      this.emtion24.Size = new Size(44, 18);
      this.emtion24.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion24.TabIndex = 36;
      this.emtion24.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion24, ":-B");
      this.emtion24.Zoom = 5;
      this.emtion24.Click += new EventHandler(this.Emtion1Click);
      this.emtion5.BackColor = Color.White;
      this.emtion5.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion5.Cursor = Cursors.Hand;
      this.emtion5.ErrorImage = (Image) componentResourceManager.GetObject("emtion5.ErrorImage");
      this.emtion5.Image = (Image) componentResourceManager.GetObject("emtion5.Image");
      this.emtion5.ImageActive = (Image) null;
      this.emtion5.Location = new Point(192, 4);
      this.emtion5.Name = "emtion5";
      this.emtion5.Size = new Size(44, 18);
      this.emtion5.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion5.TabIndex = 21;
      this.emtion5.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion5, ";;)");
      this.emtion5.Zoom = 5;
      this.emtion5.Click += new EventHandler(this.Emtion1Click);
      this.emtion23.BackColor = Color.White;
      this.emtion23.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion23.Cursor = Cursors.Hand;
      this.emtion23.ErrorImage = (Image) componentResourceManager.GetObject("emtion23.ErrorImage");
      this.emtion23.Image = (Image) componentResourceManager.GetObject("emtion23.Image");
      this.emtion23.ImageActive = (Image) null;
      this.emtion23.Location = new Point(192, 52);
      this.emtion23.Name = "emtion23";
      this.emtion23.Size = new Size(44, 18);
      this.emtion23.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion23.TabIndex = 35;
      this.emtion23.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion23, "0:-)");
      this.emtion23.Zoom = 5;
      this.emtion23.Click += new EventHandler(this.Emtion1Click);
      this.emtion6.BackColor = Color.White;
      this.emtion6.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion6.Cursor = Cursors.Hand;
      this.emtion6.ErrorImage = (Image) componentResourceManager.GetObject("emtion6.ErrorImage");
      this.emtion6.Image = (Image) componentResourceManager.GetObject("emtion6.Image");
      this.emtion6.ImageActive = (Image) null;
      this.emtion6.Location = new Point(239, 4);
      this.emtion6.Name = "emtion6";
      this.emtion6.Size = new Size(44, 18);
      this.emtion6.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion6.TabIndex = 22;
      this.emtion6.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion6, "[:D]");
      this.emtion6.Zoom = 5;
      this.emtion6.Click += new EventHandler(this.Emtion1Click);
      this.emtion22.BackColor = Color.White;
      this.emtion22.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion22.Cursor = Cursors.Hand;
      this.emtion22.ErrorImage = (Image) componentResourceManager.GetObject("emtion22.ErrorImage");
      this.emtion22.Image = (Image) componentResourceManager.GetObject("emtion22.Image");
      this.emtion22.ImageActive = (Image) null;
      this.emtion22.Location = new Point(145, 52);
      this.emtion22.Name = "emtion22";
      this.emtion22.Size = new Size(44, 18);
      this.emtion22.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion22.TabIndex = 34;
      this.emtion22.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion22, "=))");
      this.emtion22.Zoom = 5;
      this.emtion22.Click += new EventHandler(this.Emtion1Click);
      this.emtion7.BackColor = Color.White;
      this.emtion7.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion7.Cursor = Cursors.Hand;
      this.emtion7.ErrorImage = (Image) componentResourceManager.GetObject("emtion7.ErrorImage");
      this.emtion7.Image = (Image) componentResourceManager.GetObject("emtion7.Image");
      this.emtion7.ImageActive = (Image) null;
      this.emtion7.Location = new Point(286, 4);
      this.emtion7.Name = "emtion7";
      this.emtion7.Size = new Size(44, 18);
      this.emtion7.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion7.TabIndex = 23;
      this.emtion7.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion7, ":-/");
      this.emtion7.Zoom = 5;
      this.emtion7.Click += new EventHandler(this.Emtion1Click);
      this.emtion21.BackColor = Color.White;
      this.emtion21.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion21.Cursor = Cursors.Hand;
      this.emtion21.ErrorImage = (Image) componentResourceManager.GetObject("emtion21.ErrorImage");
      this.emtion21.Image = (Image) componentResourceManager.GetObject("emtion21.Image");
      this.emtion21.ImageActive = (Image) null;
      this.emtion21.Location = new Point(98, 52);
      this.emtion21.Name = "emtion21";
      this.emtion21.Size = new Size(44, 18);
      this.emtion21.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion21.TabIndex = 33;
      this.emtion21.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion21, "/:)");
      this.emtion21.Zoom = 5;
      this.emtion21.Click += new EventHandler(this.Emtion1Click);
      this.emtion20.BackColor = Color.White;
      this.emtion20.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion20.Cursor = Cursors.Hand;
      this.emtion20.ErrorImage = (Image) componentResourceManager.GetObject("emtion20.ErrorImage");
      this.emtion20.Image = (Image) componentResourceManager.GetObject("emtion20.Image");
      this.emtion20.ImageActive = (Image) null;
      this.emtion20.Location = new Point(51, 52);
      this.emtion20.Name = "emtion20";
      this.emtion20.Size = new Size(44, 18);
      this.emtion20.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion20.TabIndex = 32;
      this.emtion20.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion20, ":|");
      this.emtion20.Zoom = 5;
      this.emtion20.Click += new EventHandler(this.Emtion1Click);
      this.emtion14.BackColor = Color.White;
      this.emtion14.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion14.Cursor = Cursors.Hand;
      this.emtion14.ErrorImage = (Image) componentResourceManager.GetObject("emtion14.ErrorImage");
      this.emtion14.Image = (Image) componentResourceManager.GetObject("emtion14.Image");
      this.emtion14.ImageActive = (Image) null;
      this.emtion14.Location = new Point(192, 28);
      this.emtion14.Name = "emtion14";
      this.emtion14.Size = new Size(44, 18);
      this.emtion14.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion14.TabIndex = 28;
      this.emtion14.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion14, "X(");
      this.emtion14.Zoom = 5;
      this.emtion14.Click += new EventHandler(this.Emtion1Click);
      this.emtion19.BackColor = Color.White;
      this.emtion19.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion19.Cursor = Cursors.Hand;
      this.emtion19.ErrorImage = (Image) componentResourceManager.GetObject("emtion19.ErrorImage");
      this.emtion19.Image = (Image) componentResourceManager.GetObject("emtion19.Image");
      this.emtion19.ImageActive = (Image) null;
      this.emtion19.Location = new Point(4, 52);
      this.emtion19.Name = "emtion19";
      this.emtion19.Size = new Size(44, 18);
      this.emtion19.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion19.TabIndex = 31;
      this.emtion19.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion19, ":))");
      this.emtion19.Zoom = 5;
      this.emtion19.Click += new EventHandler(this.Emtion1Click);
      this.emtion10.BackColor = Color.White;
      this.emtion10.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion10.Cursor = Cursors.Hand;
      this.emtion10.ErrorImage = (Image) componentResourceManager.GetObject("emtion10.ErrorImage");
      this.emtion10.Image = (Image) componentResourceManager.GetObject("emtion10.Image");
      this.emtion10.ImageActive = (Image) null;
      this.emtion10.Location = new Point(4, 28);
      this.emtion10.Name = "emtion10";
      this.emtion10.Size = new Size(44, 18);
      this.emtion10.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion10.TabIndex = 24;
      this.emtion10.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion10, ":P");
      this.emtion10.Zoom = 5;
      this.emtion10.Click += new EventHandler(this.Emtion1Click);
      this.emtion11.BackColor = Color.White;
      this.emtion11.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion11.Cursor = Cursors.Hand;
      this.emtion11.ErrorImage = (Image) componentResourceManager.GetObject("emtion11.ErrorImage");
      this.emtion11.Image = (Image) componentResourceManager.GetObject("emtion11.Image");
      this.emtion11.ImageActive = (Image) null;
      this.emtion11.Location = new Point(51, 28);
      this.emtion11.Name = "emtion11";
      this.emtion11.Size = new Size(44, 18);
      this.emtion11.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion11.TabIndex = 25;
      this.emtion11.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion11, ":-*");
      this.emtion11.Zoom = 5;
      this.emtion11.Click += new EventHandler(this.Emtion1Click);
      this.emtion16.BackColor = Color.White;
      this.emtion16.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion16.Cursor = Cursors.Hand;
      this.emtion16.ErrorImage = (Image) componentResourceManager.GetObject("emtion16.ErrorImage");
      this.emtion16.Image = (Image) componentResourceManager.GetObject("emtion16.Image");
      this.emtion16.ImageActive = (Image) null;
      this.emtion16.Location = new Point(286, 28);
      this.emtion16.Name = "emtion16";
      this.emtion16.Size = new Size(44, 18);
      this.emtion16.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion16.TabIndex = 30;
      this.emtion16.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion16, "B-)");
      this.emtion16.Zoom = 5;
      this.emtion16.Click += new EventHandler(this.Emtion1Click);
      this.emtion12.BackColor = Color.White;
      this.emtion12.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion12.Cursor = Cursors.Hand;
      this.emtion12.ErrorImage = (Image) componentResourceManager.GetObject("emtion12.ErrorImage");
      this.emtion12.Image = (Image) componentResourceManager.GetObject("emtion12.Image");
      this.emtion12.ImageActive = (Image) null;
      this.emtion12.Location = new Point(98, 28);
      this.emtion12.Name = "emtion12";
      this.emtion12.Size = new Size(44, 18);
      this.emtion12.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion12.TabIndex = 26;
      this.emtion12.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion12, "=((");
      this.emtion12.Zoom = 5;
      this.emtion12.Click += new EventHandler(this.Emtion1Click);
      this.emtion15.BackColor = Color.White;
      this.emtion15.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion15.Cursor = Cursors.Hand;
      this.emtion15.ErrorImage = (Image) componentResourceManager.GetObject("emtion15.ErrorImage");
      this.emtion15.Image = (Image) componentResourceManager.GetObject("emtion15.Image");
      this.emtion15.ImageActive = (Image) null;
      this.emtion15.Location = new Point(239, 28);
      this.emtion15.Name = "emtion15";
      this.emtion15.Size = new Size(44, 18);
      this.emtion15.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion15.TabIndex = 29;
      this.emtion15.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion15, ":}");
      this.emtion15.Zoom = 5;
      this.emtion15.Click += new EventHandler(this.Emtion1Click);
      this.emtion13.BackColor = Color.White;
      this.emtion13.BackgroundImageLayout = ImageLayout.Zoom;
      this.emtion13.Cursor = Cursors.Hand;
      this.emtion13.ErrorImage = (Image) componentResourceManager.GetObject("emtion13.ErrorImage");
      this.emtion13.Image = (Image) componentResourceManager.GetObject("emtion13.Image");
      this.emtion13.ImageActive = (Image) null;
      this.emtion13.Location = new Point(145, 28);
      this.emtion13.Name = "emtion13";
      this.emtion13.Size = new Size(44, 18);
      this.emtion13.SizeMode = PictureBoxSizeMode.Zoom;
      this.emtion13.TabIndex = 27;
      this.emtion13.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.emtion13, ":-0");
      this.emtion13.Zoom = 5;
      this.emtion13.Click += new EventHandler(this.Emtion1Click);
      this.pnUrlImage.BackColor = Color.Orange;
      this.pnUrlImage.BorderStyle = BorderStyle.FixedSingle;
      this.pnUrlImage.Controls.Add((Control) this.btnImage);
      this.pnUrlImage.Controls.Add((Control) this.label2);
      this.pnUrlImage.Controls.Add((Control) this.txtUrlImage);
      this.pnUrlImage.Location = new Point(160, 508);
      this.pnUrlImage.Name = "pnUrlImage";
      this.pnUrlImage.Size = new Size(456, 25);
      this.pnUrlImage.TabIndex = 8;
      this.pnUrlImage.Visible = false;
      this.btnImage.BackColor = Color.Gainsboro;
      this.btnImage.FlatStyle = FlatStyle.Popup;
      this.btnImage.Location = new Point(393, 1);
      this.btnImage.Margin = new Padding(0);
      this.btnImage.Name = "btnImage";
      this.btnImage.Size = new Size(60, 21);
      this.btnImage.TabIndex = 2;
      this.btnImage.Text = "Done";
      this.btnImage.UseVisualStyleBackColor = false;
      this.btnImage.Click += new EventHandler(this.Button1Click);
      this.label2.AutoSize = true;
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(2, 4);
      this.label2.Name = "label2";
      this.label2.Size = new Size(47, 15);
      this.label2.TabIndex = 1;
      this.label2.Text = "Url ảnh";
      this.txtUrlImage.BorderStyle = BorderStyle.FixedSingle;
      this.txtUrlImage.Location = new Point(49, 1);
      this.txtUrlImage.Name = "txtUrlImage";
      this.txtUrlImage.Size = new Size(343, 21);
      this.txtUrlImage.TabIndex = 0;
      this.txtUrlImage.KeyDown += new KeyEventHandler(this.TxtUrlImageKeyDown);
      this.wbChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.wbChat.Location = new Point(1, 1);
      this.wbChat.MinimumSize = new Size(20, 20);
      this.wbChat.Name = "wbChat";
      this.wbChat.ScriptErrorsSuppressed = true;
      this.wbChat.Size = new Size(1097, 533);
      this.wbChat.TabIndex = 0;
      this.wbChat.WebBrowserShortcutsEnabled = false;
      this.wbChat.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.WbChatDocumentCompleted);
      this.pnMainBot.BackColor = Color.FromArgb(27, 40, 61);
      this.pnMainBot.Controls.Add((Control) this.pnEmotion);
      this.pnMainBot.Controls.Add((Control) this.pnTextInput);
      this.pnMainBot.Dock = DockStyle.Bottom;
      this.pnMainBot.Location = new Point(0, 535);
      this.pnMainBot.Name = "pnMainBot";
      this.pnMainBot.Size = new Size(1100, 72);
      this.pnMainBot.TabIndex = 0;
      this.pnEmotion.BackColor = Color.FromArgb(236, 238, 245);
      this.pnEmotion.Controls.Add((Control) this.lblCount);
      this.pnEmotion.Controls.Add((Control) this.cbbFontSize);
      this.pnEmotion.Controls.Add((Control) this.bunifuImageButton61);
      this.pnEmotion.Controls.Add((Control) this.bunifuImageButton31);
      this.pnEmotion.Controls.Add((Control) this.btnColor);
      this.pnEmotion.Controls.Add((Control) this.btnU);
      this.pnEmotion.Controls.Add((Control) this.btnI);
      this.pnEmotion.Controls.Add((Control) this.btnB);
      this.pnEmotion.Location = new Point(1, 0);
      this.pnEmotion.Name = "pnEmotion";
      this.pnEmotion.Size = new Size(1097, 29);
      this.pnEmotion.TabIndex = 1;
      this.lblCount.BackColor = Color.FromArgb(236, 238, 245);
      this.lblCount.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblCount.ForeColor = SystemColors.AppWorkspace;
      this.lblCount.Location = new Point(1041, 5);
      this.lblCount.Name = "lblCount";
      this.lblCount.RightToLeft = RightToLeft.Yes;
      this.lblCount.Size = new Size(55, 17);
      this.lblCount.TabIndex = 47;
      this.lblCount.Text = "120/120";
      this.cbbFontSize.BackColor = Color.FromArgb(236, 238, 245);
      this.cbbFontSize.Cursor = Cursors.Hand;
      this.cbbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbbFontSize.FlatStyle = FlatStyle.Popup;
      this.cbbFontSize.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbbFontSize.FormattingEnabled = true;
      this.cbbFontSize.Items.AddRange(new object[5]
      {
        (object) "9",
        (object) "10",
        (object) "12",
        (object) "13",
        (object) "14"
      });
      this.cbbFontSize.Location = new Point(286, 2);
      this.cbbFontSize.Name = "cbbFontSize";
      this.cbbFontSize.Size = new Size(43, 23);
      this.cbbFontSize.TabIndex = 46;
      this.toolTip1.SetToolTip((Control) this.cbbFontSize, "Cỡ chữ");
      this.cbbFontSize.Visible = false;
      this.cbbFontSize.SelectedIndexChanged += new EventHandler(this.CbbFontSizeSelectedIndexChanged);
      this.bunifuImageButton61.BackColor = Color.FromArgb(236, 238, 245);
      this.bunifuImageButton61.Cursor = Cursors.Hand;
      this.bunifuImageButton61.Image = (Image) componentResourceManager.GetObject("bunifuImageButton61.Image");
      this.bunifuImageButton61.ImageActive = (Image) null;
      this.bunifuImageButton61.Location = new Point(184, 6);
      this.bunifuImageButton61.Name = "bunifuImageButton61";
      this.bunifuImageButton61.Size = new Size(18, 18);
      this.bunifuImageButton61.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton61.TabIndex = 45;
      this.bunifuImageButton61.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton61, "Chèn ảnh");
      this.bunifuImageButton61.Zoom = 10;
      this.bunifuImageButton61.Click += new EventHandler(this.BunifuImageButton61Click);
      this.bunifuImageButton31.BackColor = Color.FromArgb(236, 238, 245);
      this.bunifuImageButton31.Cursor = Cursors.Hand;
      this.bunifuImageButton31.Image = (Image) componentResourceManager.GetObject("bunifuImageButton31.Image");
      this.bunifuImageButton31.ImageActive = (Image) null;
      this.bunifuImageButton31.Location = new Point(156, 4);
      this.bunifuImageButton31.Name = "bunifuImageButton31";
      this.bunifuImageButton31.Size = new Size(22, 22);
      this.bunifuImageButton31.SizeMode = PictureBoxSizeMode.Zoom;
      this.bunifuImageButton31.TabIndex = 44;
      this.bunifuImageButton31.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton31, "Chèn ảnh");
      this.bunifuImageButton31.Zoom = 10;
      this.bunifuImageButton31.Click += new EventHandler(this.BunifuImageButton31Click);
      this.btnColor.BackColor = Color.FromArgb(236, 238, 245);
      this.btnColor.Cursor = Cursors.Hand;
      this.btnColor.ErrorImage = (Image) componentResourceManager.GetObject("btnColor.ErrorImage");
      this.btnColor.Image = (Image) componentResourceManager.GetObject("btnColor.Image");
      this.btnColor.ImageActive = (Image) null;
      this.btnColor.InitialImage = (Image) componentResourceManager.GetObject("btnColor.InitialImage");
      this.btnColor.Location = new Point(130, 5);
      this.btnColor.Name = "btnColor";
      this.btnColor.Size = new Size(21, 21);
      this.btnColor.SizeMode = PictureBoxSizeMode.Zoom;
      this.btnColor.TabIndex = 15;
      this.btnColor.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.btnColor, " Màu chữ");
      this.btnColor.Zoom = 10;
      this.btnColor.Click += new EventHandler(this.BtnColorClick);
      this.btnU.Cursor = Cursors.Hand;
      this.btnU.FlatStyle = FlatStyle.Popup;
      this.btnU.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.btnU.Location = new Point(85, 5);
      this.btnU.Name = "btnU";
      this.btnU.Size = new Size(39, 21);
      this.btnU.TabIndex = 13;
      this.btnU.Text = "U";
      this.btnU.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnU, "Gạch chân");
      this.btnU.UseVisualStyleBackColor = true;
      this.btnU.Click += new EventHandler(this.BtnUClick);
      this.btnI.Cursor = Cursors.Hand;
      this.btnI.FlatStyle = FlatStyle.Popup;
      this.btnI.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 163);
      this.btnI.Location = new Point(44, 5);
      this.btnI.Name = "btnI";
      this.btnI.Size = new Size(39, 21);
      this.btnI.TabIndex = 1;
      this.btnI.Text = "I";
      this.btnI.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnI, "In nghiêng");
      this.btnI.UseVisualStyleBackColor = true;
      this.btnI.Click += new EventHandler(this.BtnIClick);
      this.btnB.Cursor = Cursors.Hand;
      this.btnB.FlatStyle = FlatStyle.Popup;
      this.btnB.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 163);
      this.btnB.Location = new Point(3, 5);
      this.btnB.Name = "btnB";
      this.btnB.Size = new Size(39, 21);
      this.btnB.TabIndex = 0;
      this.btnB.Text = "B";
      this.btnB.TextAlign = ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip((Control) this.btnB, "Bôi đậm");
      this.btnB.UseVisualStyleBackColor = true;
      this.btnB.Click += new EventHandler(this.BtnBClick);
      this.pnTextInput.BackColor = Color.FromArgb(236, 238, 245);
      this.pnTextInput.Controls.Add((Control) this.btnSend);
      this.pnTextInput.Controls.Add((Control) this.txtInput);
      this.pnTextInput.Location = new Point(1, 28);
      this.pnTextInput.Name = "pnTextInput";
      this.pnTextInput.Size = new Size(1097, 42);
      this.pnTextInput.TabIndex = 0;
      this.btnSend.BackColor = Color.Transparent;
      this.btnSend.Cursor = Cursors.Hand;
      this.btnSend.Image = (Image) componentResourceManager.GetObject("btnSend.Image");
      this.btnSend.ImageActive = (Image) null;
      this.btnSend.Location = new Point(1047, 0);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new Size(45, 38);
      this.btnSend.SizeMode = PictureBoxSizeMode.Zoom;
      this.btnSend.TabIndex = 7;
      this.btnSend.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.btnSend, "Nhấn để gửi");
      this.btnSend.Zoom = 5;
      this.btnSend.Click += new EventHandler(this.BtnSendClick1);
      this.txtInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtInput.BackColor = Color.White;
      this.txtInput.BorderStyle = BorderStyle.None;
      this.txtInput.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.txtInput.Location = new Point(4, 3);
      this.txtInput.Margin = new Padding(0);
      this.txtInput.MaxLength = 120;
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new Size(1040, 37);
      this.txtInput.TabIndex = 0;
      this.txtInput.MouseClick += new MouseEventHandler(this.TxtInputMouseClick);
      this.txtInput.TextChanged += new EventHandler(this.txtInput_TextChanged);
      this.txtInput.KeyDown += new KeyEventHandler(this.TxtInputKeyDown);
      this.txtInput.KeyPress += new KeyPressEventHandler(this.TxtInputKeyPress);
      this.panel3.BackColor = Color.FromArgb(27, 40, 61);
      this.panel3.Dock = DockStyle.Bottom;
      this.panel3.Location = new Point(0, 627);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1100, 1);
      this.panel3.TabIndex = 12;
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this.txtInput;
      this.bunifuElipse2.ElipseRadius = 0;
      this.bunifuElipse2.TargetControl = (Control) this;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1100, 628);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FPublicChat);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Phòng chat";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.bunifuImageButton1.EndInit();
      this.bunifuImageButton6.EndInit();
      this.bunifuImageButton8.EndInit();
      this.panel2.ResumeLayout(false);
      this.pnMainTop.ResumeLayout(false);
      this.pnChatLog.ResumeLayout(false);
      this.pnEmo.ResumeLayout(false);
      this.emtion72.EndInit();
      this.emtion63.EndInit();
      this.emtion54.EndInit();
      this.emtion45.EndInit();
      this.emtion36.EndInit();
      this.emtion27.EndInit();
      this.emtion9.EndInit();
      this.emtion18.EndInit();
      this.emtion41.EndInit();
      this.emtion57.EndInit();
      this.emtion47.EndInit();
      this.emtion71.EndInit();
      this.emtion62.EndInit();
      this.emtion53.EndInit();
      this.emtion44.EndInit();
      this.emtion35.EndInit();
      this.emtion26.EndInit();
      this.emtion8.EndInit();
      this.emtion17.EndInit();
      this.emtion70.EndInit();
      this.emtion69.EndInit();
      this.emtion68.EndInit();
      this.emtion67.EndInit();
      this.emtion66.EndInit();
      this.emtion65.EndInit();
      this.emtion64.EndInit();
      this.emtion61.EndInit();
      this.emtion60.EndInit();
      this.emtion59.EndInit();
      this.emtion58.EndInit();
      this.emtion56.EndInit();
      this.emtion55.EndInit();
      this.emtion52.EndInit();
      this.emtion50.EndInit();
      this.emtion49.EndInit();
      this.emtion48.EndInit();
      this.emtion46.EndInit();
      this.emtion43.EndInit();
      this.emtion42.EndInit();
      this.emtion40.EndInit();
      this.emtion39.EndInit();
      this.emtion38.EndInit();
      this.emtion37.EndInit();
      this.emtion34.EndInit();
      this.emtion33.EndInit();
      this.emtion32.EndInit();
      this.emtion31.EndInit();
      this.emtion30.EndInit();
      this.emtion29.EndInit();
      this.emtion28.EndInit();
      this.emtion4.EndInit();
      this.emtion1.EndInit();
      this.emtion2.EndInit();
      this.emtion25.EndInit();
      this.emtion3.EndInit();
      this.emtion24.EndInit();
      this.emtion5.EndInit();
      this.emtion23.EndInit();
      this.emtion6.EndInit();
      this.emtion22.EndInit();
      this.emtion7.EndInit();
      this.emtion21.EndInit();
      this.emtion20.EndInit();
      this.emtion14.EndInit();
      this.emtion19.EndInit();
      this.emtion10.EndInit();
      this.emtion11.EndInit();
      this.emtion16.EndInit();
      this.emtion12.EndInit();
      this.emtion15.EndInit();
      this.emtion13.EndInit();
      this.pnUrlImage.ResumeLayout(false);
      this.pnUrlImage.PerformLayout();
      this.pnMainBot.ResumeLayout(false);
      this.pnEmotion.ResumeLayout(false);
      this.bunifuImageButton61.EndInit();
      this.bunifuImageButton31.EndInit();
      this.btnColor.EndInit();
      this.pnTextInput.ResumeLayout(false);
      this.pnTextInput.PerformLayout();
      this.btnSend.EndInit();
      this.ResumeLayout(false);
    }
  }
}
