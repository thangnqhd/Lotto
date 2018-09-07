// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.FormUI.TabChat
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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Thống_kê_xổ_số.BusinessLayer;
using Thống_kê_xổ_số.Properties;

namespace Thống_kê_xổ_số.FormUI
{
  public class TabChat : UserControl
  {
    private string htmlText = "";
    private string oldMsg = "";
    private string _strMsg = "";
    private IContainer components = (IContainer) null;
    private TBNaptienhethong objNaptienhethong;
    private string[] _strChatLogTextChat;
    private readonly Emotion.Emotion _emotion;
    private bool _checkB;
    private bool _checkI;
    private bool _checkU;
    private FontStyle _fontStyle;
    private Structure _structure;
    private bool checkChat;
    private string[] demChat;
    private BunifuImageButton _image;
    private BunifuElipse bunifuElipse1;
    private Panel pnTop;
    private Panel pnBot;
    public WebBrowser wbChat;
    private Panel pnUrlImage;
    private Button btnImage;
    private Label label2;
    private TextBox txtUrlImage;
    private Panel pnEmo;
    private BunifuImageButton emtion72;
    private BunifuImageButton emtion63;
    private BunifuImageButton emtion54;
    private BunifuImageButton emtion45;
    private BunifuImageButton emtion36;
    private BunifuImageButton emtion27;
    private BunifuImageButton emtion9;
    private BunifuImageButton emtion18;
    private BunifuImageButton emtion41;
    private BunifuImageButton emtion57;
    private BunifuImageButton emtion47;
    private BunifuImageButton emtion71;
    private BunifuImageButton emtion62;
    private BunifuImageButton emtion53;
    private BunifuImageButton emtion44;
    private BunifuImageButton emtion35;
    private BunifuImageButton emtion26;
    private BunifuImageButton emtion8;
    private BunifuImageButton emtion17;
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
    private BunifuImageButton emtion4;
    private BunifuImageButton emtion1;
    private BunifuImageButton emtion2;
    private BunifuImageButton emtion25;
    private BunifuImageButton emtion3;
    private BunifuImageButton emtion24;
    private BunifuImageButton emtion5;
    private BunifuImageButton emtion23;
    private BunifuImageButton emtion6;
    private BunifuImageButton emtion22;
    private BunifuImageButton emtion7;
    private BunifuImageButton emtion21;
    private BunifuImageButton emtion20;
    private BunifuImageButton emtion14;
    private BunifuImageButton emtion19;
    private BunifuImageButton emtion10;
    private BunifuImageButton emtion11;
    private BunifuImageButton emtion16;
    private BunifuImageButton emtion12;
    private BunifuImageButton emtion15;
    private BunifuImageButton emtion13;
    private Panel pnEmotion;
    private Label lblCount;
    private ComboBox cbbFontSize;
    private BunifuImageButton bunifuImageButton61;
    private BunifuImageButton bunifuImageButton31;
    private BunifuImageButton btnColor;
    private Button btnU;
    private Button btnI;
    private Button btnB;
    private Panel pnTextInput;
    private BunifuImageButton btnSend;
    private TextBox txtInput;
    private ColorDialog colorDialog1;
    private BunifuElipse bunifuElipse2;
    private ToolTip toolTip1;
    private BunifuCheckbox rdThongbao;
    private Label label1;
    private BunifuCheckbox rdAmthanh;
    private Label label3;
    private Timer timer1;

    public TabChat()
    {
      this.InitializeComponent();
      this.objNaptienhethong = new TBNaptienhethong();
      this._structure = new Structure();
      this._structure.Username = FMain.UserName;
      this._structure.AccountType = FMain.AccountType;
      this.cbbFontSize.SelectedIndex = 0;
      this.wbChat.IsWebBrowserContextMenuEnabled = false;
      this.wbChat.AllowWebBrowserDrop = false;
      this._emotion = new Emotion.Emotion();
      this.ConnectChat();
    }

    private void ConnectChat()
    {
      if (FLogin.StatusChat != 0)
        return;
      this._structure.Username = FMain.UserName;
      this._structure.SendTo = "Server";
      this._structure.SendType = "JoinChat";
      this._structure.TextChat = "Joined Chat";
      FLogin.Client.Send(this._structure);
      this.ReciveData();
      FLogin.StatusChat = 1;
    }

    private void ClientReceived(ClientSettings.ClientSettings cs, Structure struc)
    {
      if (!(struc.SendType == "RefreshChat"))
        return;
      Program.Invoke(this, (Action) (() =>
      {
        FLogin.StrChat = FLogin.StrChat + "<div style='margin-bottom: 5px;'>" + this.BienDichChat(struc) + "</div>";
        string[] strArray = struc.Username.Split('&');
        if ((uint) strArray.Length > 0U)
          struc.Username = strArray[0];
        if (FLogin.StatusChat != 1)
          return;
        if (this.rdThongbao.Checked && (FMain.UserName != struc.Username && struc.Username != "<< SERVER >>" && struc.Username != ""))
          FMain.ShowMessageInPopup(struc.TimeSend + TabChat.StripHTML(struc.Username) + " vừa nói : ", struc.TextChat);
        if (this.rdAmthanh.Checked)
          ClMain.tune_Thongbao("sent.wav");
        this.Chat(this.wbChat, FLogin.StrChat);
      }));
    }

    private void Chat(WebBrowser wb, string strHtml)
    {
      FLogin._countChat = (Decimal) Encoding.Unicode.GetByteCount(this.htmlText);
      if (FLogin._countChat > new Decimal(150000))
        FLogin.StrChat = "";
      this.htmlText = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                    " + CssMessage.StrCssChat + "<title>THỐNG KÊ XỔ SỐ</title></head><body class='main'><div style='width:100%;float:left;margin-right:5px;padding-bottom: 35px;' oncontextmenu='return false;'>" + strHtml + "</div></body></html>";
      Tbketqua.DisplayHtml(wb, this.htmlText);
    }

    private void UserList(WebBrowser wb, string strHtml)
    {
      this.htmlText = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                        <head>\r\n                                            <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' /><title>THỐNG KÊ XỔ SỐ</title></head><body style='font-family:Tahoma;font-size:12px;margin-top:3px;'oncontextmenu='return false;'>" + strHtml + "</body></html>";
      Tbketqua.DisplayHtml(wb, this.htmlText);
    }

    private string StrChatOk { get; set; }

    private string BienDichChat(Structure structure)
    {
      if (structure.Username != "")
      {
        this._strChatLogTextChat = structure.TextChat.Split(' ');
        this.StrChatOk = "";
        for (int index = 0; index < this._strChatLogTextChat.Length; ++index)
        {
          if (this._strChatLogTextChat[index] != " ")
            this.StrChatOk = this.StrChatOk + this._emotion.SrcEmotion(this._strChatLogTextChat[index], Directory.GetCurrentDirectory() + "/") + " ";
        }
        if (structure.Username != "<< SERVER >>")
          structure.Username = structure.Username;
        structure.FontSize = structure.FontSize;
        this.StrChatOk = "<span class='timeChat'> " + structure.TimeSend + " </span><span class='userType'>&nbsp;&nbsp;" + structure.Username + "</span><span style='font-family:" + structure.Font + ";color:" + structure.ForColor + "; font-style:" + structure.FontWeight + ";font-weight:" + structure.FontWeight + ";font-size:" + (object) structure.FontSize + "px;text-decoration:" + structure.FontWeight + ";'>" + this.StrChatOk + "</span>";
        if (structure.Image != null && structure.Image.Length > 14)
          this.StrChatOk = this.StrChatOk + "<br/><div style='text-align: center;'><img style='-webkit-user-select: none;background-position: 0px 0px, 10px 10px;background-size: 20px 20px;background-image:linear-gradient(45deg, #eee 25%, transparent 25%, transparent 75%, #eee 75%, #eee 100%),linear-gradient(45deg, #eee 25%, white 25%, white 75%, #eee 75%, #eee 100%);cursor: zoom-in;height: auto; \r\n    width: auto; \r\n    max-width: 67%;' src='" + structure.Image + "'></div>";
      }
      else
        this.StrChatOk = structure.TextChat;
      return this.StrChatOk;
    }

    private void bunifuImageButton61_Click(object sender, EventArgs e)
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

    private void bunifuImageButton31_Click(object sender, EventArgs e)
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

    private void btnColor_Click(object sender, EventArgs e)
    {
      if (this.colorDialog1.ShowDialog() == DialogResult.OK)
        this._structure.ForColor = "#" + (this.colorDialog1.Color.ToArgb() & 16777215).ToString("X6");
      this.txtInput.ForeColor = this.colorDialog1.Color;
    }

    private void btnU_Click(object sender, EventArgs e)
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

    private void btnI_Click(object sender, EventArgs e)
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

    private void btnB_Click(object sender, EventArgs e)
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

    private void btnSend_Click(object sender, EventArgs e)
    {
      this.SendMsg();
    }

    private void SendMsg()
    {
      this.checkChat = true;
      if (this.txtInput.Text != string.Empty && this.txtInput.Text.Length < 141)
      {
        if (this.txtInput.Text != this.oldMsg || this.txtInput.Text == " #img ")
        {
          this._strMsg = TabChat.StripHTML(this.txtInput.Text);
          if (this._strMsg.Length > 0)
          {
            if (this._strMsg.Length > 94)
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
            if (this.objNaptienhethong.Demsolannaptien(FMain.UserName) < 1)
              this.txtInput.Text = "Những tài khoản đã nạp tiền có thể sử dụng tính năng này.";
            else
              FLogin.Client.Send(this._structure);
          }
          this.oldMsg = this.txtInput.Text;
        }
        else
        {
          int num = (int) MessageBox.Show("Không thể thực hiện thao tác này !!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      this._structure.Image = "";
      this.txtInput.Text = "";
      this.txtInput.Focus();
      this.txtInput.SelectionStart = 0;
    }

    public static string StripHTML(string inputText)
    {
      return Regex.Replace(inputText, "<.*?>", string.Empty);
    }

    private void emtion1_Click(object sender, EventArgs e)
    {
      this._image = (BunifuImageButton) sender;
      TextBox txtInput = this.txtInput;
      txtInput.Text = txtInput.Text + Resources.FPublicChat_Emtion1Click__ + this.InsertEmotion(this._image.Name) + Resources.FPublicChat_Emtion1Click__;
      this.txtInput.Focus();
      this.txtInput.SelectionStart = this.txtInput.Text.Length;
    }

    private string _strEmotion { get; set; }

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

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
      this.lblCount.Text = string.Format("{0}/140", (object) this.txtInput.Text.Length.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    private void txtInput_MouseClick(object sender, MouseEventArgs e)
    {
      this.pnUrlImage.Visible = false;
      this.pnEmo.Visible = false;
      this.txtUrlImage.Text = string.Empty;
    }

    private void txtInput_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        this.SendMsg();
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
      if (this.txtInput.Text.Length > 139)
      {
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
      if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
        return;
      e.Handled = false;
      e.SuppressKeyPress = false;
    }

    private void txtUrlImage_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnImage.PerformClick();
    }

    private void btnImage_Click(object sender, EventArgs e)
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

    private void wbChat_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (!(this.wbChat.Document != (HtmlDocument) null))
        return;
      Debug.Assert(this.wbChat.Document.Window != (HtmlWindow) null, "wbChat.Document.Window != null");
      Debug.Assert(this.wbChat.Document.Body != (HtmlElement) null, "wbChat.Document.Body != null");
      this.wbChat.Document.Window.ScrollTo(0, this.wbChat.Document.Body.ScrollRectangle.Height);
    }

    private void ReciveData()
    {
      FLogin.Client.Received += new ClientSettings.ClientSettings.ReceivedEventHandler(this.ClientReceived);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (!FLogin._reconnectochat)
        return;
      FLogin._reconnectochat = false;
      this.ReciveData();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TabChat));
      this.bunifuElipse1 = new BunifuElipse(this.components);
      this.pnBot = new Panel();
      this.pnTextInput = new Panel();
      this.btnSend = new BunifuImageButton();
      this.txtInput = new TextBox();
      this.pnEmotion = new Panel();
      this.rdAmthanh = new BunifuCheckbox();
      this.label3 = new Label();
      this.rdThongbao = new BunifuCheckbox();
      this.lblCount = new Label();
      this.label1 = new Label();
      this.cbbFontSize = new ComboBox();
      this.bunifuImageButton61 = new BunifuImageButton();
      this.bunifuImageButton31 = new BunifuImageButton();
      this.btnColor = new BunifuImageButton();
      this.btnU = new Button();
      this.btnI = new Button();
      this.btnB = new Button();
      this.pnTop = new Panel();
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
      this.colorDialog1 = new ColorDialog();
      this.bunifuElipse2 = new BunifuElipse(this.components);
      this.toolTip1 = new ToolTip(this.components);
      this.timer1 = new Timer(this.components);
      this.pnBot.SuspendLayout();
      this.pnTextInput.SuspendLayout();
      this.btnSend.BeginInit();
      this.pnEmotion.SuspendLayout();
      this.bunifuImageButton61.BeginInit();
      this.bunifuImageButton31.BeginInit();
      this.btnColor.BeginInit();
      this.pnTop.SuspendLayout();
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
      this.SuspendLayout();
      this.bunifuElipse1.ElipseRadius = 5;
      this.bunifuElipse1.TargetControl = (Control) this;
      this.pnBot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnBot.Controls.Add((Control) this.pnTextInput);
      this.pnBot.Controls.Add((Control) this.pnEmotion);
      this.pnBot.Location = new Point(0, 582);
      this.pnBot.Name = "pnBot";
      this.pnBot.Size = new Size(1100, 75);
      this.pnBot.TabIndex = 0;
      this.pnTextInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pnTextInput.BackColor = Color.FromArgb(236, 238, 245);
      this.pnTextInput.Controls.Add((Control) this.btnSend);
      this.pnTextInput.Controls.Add((Control) this.txtInput);
      this.pnTextInput.Location = new Point(2, 31);
      this.pnTextInput.Name = "pnTextInput";
      this.pnTextInput.Size = new Size(1095, 42);
      this.pnTextInput.TabIndex = 3;
      this.btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.toolTip1.SetToolTip((Control) this.btnSend, "Gửi");
      this.btnSend.Zoom = 5;
      this.btnSend.Click += new EventHandler(this.btnSend_Click);
      this.txtInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtInput.BackColor = Color.White;
      this.txtInput.BorderStyle = BorderStyle.None;
      this.txtInput.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInput.Location = new Point(3, 3);
      this.txtInput.Margin = new Padding(0);
      this.txtInput.MaxLength = 140;
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new Size(1040, 37);
      this.txtInput.TabIndex = 0;
      this.txtInput.MouseClick += new MouseEventHandler(this.txtInput_MouseClick);
      this.txtInput.TextChanged += new EventHandler(this.txtInput_TextChanged);
      this.txtInput.KeyDown += new KeyEventHandler(this.txtInput_KeyDown);
      this.pnEmotion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pnEmotion.BackColor = Color.FromArgb(236, 238, 245);
      this.pnEmotion.Controls.Add((Control) this.rdAmthanh);
      this.pnEmotion.Controls.Add((Control) this.label3);
      this.pnEmotion.Controls.Add((Control) this.rdThongbao);
      this.pnEmotion.Controls.Add((Control) this.lblCount);
      this.pnEmotion.Controls.Add((Control) this.label1);
      this.pnEmotion.Controls.Add((Control) this.cbbFontSize);
      this.pnEmotion.Controls.Add((Control) this.bunifuImageButton61);
      this.pnEmotion.Controls.Add((Control) this.bunifuImageButton31);
      this.pnEmotion.Controls.Add((Control) this.btnColor);
      this.pnEmotion.Controls.Add((Control) this.btnU);
      this.pnEmotion.Controls.Add((Control) this.btnI);
      this.pnEmotion.Controls.Add((Control) this.btnB);
      this.pnEmotion.Location = new Point(2, 0);
      this.pnEmotion.Name = "pnEmotion";
      this.pnEmotion.Size = new Size(1095, 29);
      this.pnEmotion.TabIndex = 2;
      this.rdAmthanh.BackColor = Color.FromArgb(51, 205, 117);
      this.rdAmthanh.ChechedOffColor = Color.FromArgb(132, 135, 140);
      this.rdAmthanh.Checked = true;
      this.rdAmthanh.CheckedOnColor = Color.FromArgb(51, 205, 117);
      this.rdAmthanh.Cursor = Cursors.Hand;
      this.rdAmthanh.ForeColor = Color.White;
      this.rdAmthanh.Location = new Point(373, 5);
      this.rdAmthanh.Name = "rdAmthanh";
      this.rdAmthanh.Size = new Size(20, 20);
      this.rdAmthanh.TabIndex = 49;
      this.toolTip1.SetToolTip((Control) this.rdAmthanh, "Bật/Tắt âm thông báo");
      this.label3.AutoSize = true;
      this.label3.Location = new Point(311, 7);
      this.label3.Name = "label3";
      this.label3.Size = new Size(59, 15);
      this.label3.TabIndex = 48;
      this.label3.Text = "Âm thanh";
      this.toolTip1.SetToolTip((Control) this.label3, "Bật/Tắt âm thông báo");
      this.rdThongbao.BackColor = Color.FromArgb(51, 205, 117);
      this.rdThongbao.ChechedOffColor = Color.FromArgb(132, 135, 140);
      this.rdThongbao.Checked = true;
      this.rdThongbao.CheckedOnColor = Color.FromArgb(51, 205, 117);
      this.rdThongbao.Cursor = Cursors.Hand;
      this.rdThongbao.ForeColor = Color.White;
      this.rdThongbao.Location = new Point(279, 5);
      this.rdThongbao.Name = "rdThongbao";
      this.rdThongbao.Size = new Size(20, 20);
      this.rdThongbao.TabIndex = 12;
      this.toolTip1.SetToolTip((Control) this.rdThongbao, "Bật/Tắt bảng thông báo");
      this.lblCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblCount.BackColor = Color.FromArgb(236, 238, 245);
      this.lblCount.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 163);
      this.lblCount.ForeColor = SystemColors.AppWorkspace;
      this.lblCount.Location = new Point(1039, 5);
      this.lblCount.Name = "lblCount";
      this.lblCount.RightToLeft = RightToLeft.Yes;
      this.lblCount.Size = new Size(55, 17);
      this.lblCount.TabIndex = 47;
      this.lblCount.Text = "140/140";
      this.toolTip1.SetToolTip((Control) this.lblCount, "Số ký tự sử dụng");
      this.label1.AutoSize = true;
      this.label1.Location = new Point(210, 7);
      this.label1.Name = "label1";
      this.label1.Size = new Size(66, 15);
      this.label1.TabIndex = 11;
      this.label1.Text = "Thông báo";
      this.toolTip1.SetToolTip((Control) this.label1, "Bật/Tắt bảng thông báo");
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
      this.cbbFontSize.Location = new Point(635, 4);
      this.cbbFontSize.Name = "cbbFontSize";
      this.cbbFontSize.Size = new Size(43, 23);
      this.cbbFontSize.TabIndex = 46;
      this.cbbFontSize.Visible = false;
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
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton61, "Cảm xúc");
      this.bunifuImageButton61.Zoom = 10;
      this.bunifuImageButton61.Click += new EventHandler(this.bunifuImageButton61_Click);
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
      this.toolTip1.SetToolTip((Control) this.bunifuImageButton31, "Hình ảnh");
      this.bunifuImageButton31.Zoom = 10;
      this.bunifuImageButton31.Click += new EventHandler(this.bunifuImageButton31_Click);
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
      this.toolTip1.SetToolTip((Control) this.btnColor, "Màu chữ");
      this.btnColor.Zoom = 10;
      this.btnColor.Click += new EventHandler(this.btnColor_Click);
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
      this.btnU.Click += new EventHandler(this.btnU_Click);
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
      this.btnI.Click += new EventHandler(this.btnI_Click);
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
      this.btnB.Click += new EventHandler(this.btnB_Click);
      this.pnTop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnTop.Controls.Add((Control) this.pnEmo);
      this.pnTop.Controls.Add((Control) this.pnUrlImage);
      this.pnTop.Controls.Add((Control) this.wbChat);
      this.pnTop.Location = new Point(0, 0);
      this.pnTop.Name = "pnTop";
      this.pnTop.Size = new Size(1115, 583);
      this.pnTop.TabIndex = 1;
      this.pnEmo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
      this.pnEmo.Location = new Point(185, 387);
      this.pnEmo.Name = "pnEmo";
      this.pnEmo.Size = new Size(430, 195);
      this.pnEmo.TabIndex = 10;
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
      this.toolTip1.SetToolTip((Control) this.emtion72, "Thường thôi");
      this.emtion72.Zoom = 5;
      this.emtion72.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion63, "Gọi cho tôi");
      this.emtion63.Zoom = 5;
      this.emtion63.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion54, "Lên là lên là lên");
      this.emtion54.Zoom = 5;
      this.emtion54.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion45, "Cafe");
      this.emtion45.Zoom = 5;
      this.emtion45.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion36, "Vỗ tay");
      this.emtion36.Zoom = 5;
      this.emtion36.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion27, "Tròn mắt");
      this.emtion27.Zoom = 5;
      this.emtion27.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion9, "E thẹn");
      this.emtion9.Zoom = 5;
      this.emtion9.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion18, "Khóc");
      this.emtion18.Zoom = 5;
      this.emtion18.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion41, "Cướp biển đây");
      this.emtion41.Zoom = 5;
      this.emtion41.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion57, "Không phải em");
      this.emtion57.Zoom = 5;
      this.emtion57.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion47, "Like cả hai tay");
      this.emtion47.Zoom = 5;
      this.emtion47.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion71, "Nhìn đây này");
      this.emtion71.Zoom = 5;
      this.emtion71.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion62, "Đang nghe điện thoại");
      this.emtion62.Zoom = 5;
      this.emtion62.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion53, "Không được đâu");
      this.emtion53.Zoom = 5;
      this.emtion53.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion44, "Cỏ bốn lá");
      this.emtion44.Zoom = 5;
      this.emtion44.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion35, "Than thở");
      this.emtion35.Zoom = 5;
      this.emtion35.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion26, "Buồn ngủ");
      this.emtion26.Zoom = 5;
      this.emtion26.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion8, "Yêu thương");
      this.emtion8.Zoom = 5;
      this.emtion8.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion17, "Lo lắng");
      this.emtion17.Zoom = 5;
      this.emtion17.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion70, "Nhanh lên");
      this.emtion70.Zoom = 5;
      this.emtion70.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion69, "Không dám nhìn");
      this.emtion69.Zoom = 5;
      this.emtion69.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion68, "Dĩ nhiên rồi");
      this.emtion68.Zoom = 5;
      this.emtion68.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion67, "Mơ mộng");
      this.emtion67.Zoom = 5;
      this.emtion67.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion66, "Hết giờ");
      this.emtion66.Zoom = 5;
      this.emtion66.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion65, "Tạm biệt");
      this.emtion65.Zoom = 5;
      this.emtion65.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion64, "Tức phát điên");
      this.emtion64.Zoom = 5;
      this.emtion64.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion61, "Ngôi sao");
      this.emtion61.Zoom = 5;
      this.emtion61.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion60, "Thôi bỏ đi");
      this.emtion60.Zoom = 5;
      this.emtion60.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion59, "Vái lạy");
      this.emtion59.Zoom = 5;
      this.emtion59.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion58, "Đàn gảy tai trâu");
      this.emtion58.Zoom = 5;
      this.emtion58.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion56, "Cười tủm");
      this.emtion56.Zoom = 5;
      this.emtion56.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion55, "Lại đây");
      this.emtion55.Zoom = 5;
      this.emtion55.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion52, "Chào");
      this.emtion52.Zoom = 5;
      this.emtion52.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion50, "Thổi sao");
      this.emtion50.Zoom = 5;
      this.emtion50.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion49, "Hoa mắt vì tiền");
      this.emtion49.Zoom = 5;
      this.emtion49.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion48, "Cầu nguyện");
      this.emtion48.Zoom = 5;
      this.emtion48.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion46, "Giả dối");
      this.emtion46.Zoom = 5;
      this.emtion46.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion43, "Hoa hồng");
      this.emtion43.Zoom = 5;
      this.emtion43.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion42, "Dận hờn");
      this.emtion42.Zoom = 5;
      this.emtion42.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion40, "Đang đợi");
      this.emtion40.Zoom = 5;
      this.emtion40.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion39, "Nói dối");
      this.emtion39.Zoom = 5;
      this.emtion39.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion38, "Bị thôi miên");
      this.emtion38.Zoom = 5;
      this.emtion38.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion37, "Cắn móng tay");
      this.emtion37.Zoom = 5;
      this.emtion37.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion34, "Suy nghĩ");
      this.emtion34.Zoom = 5;
      this.emtion34.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion33, "Chảy nước dãi");
      this.emtion33.Zoom = 5;
      this.emtion33.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion32, "Ngáp");
      this.emtion32.Zoom = 5;
      this.emtion32.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion31, "Ngớ ngẩn");
      this.emtion31.Zoom = 5;
      this.emtion31.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion30, "Không nói chuyện");
      this.emtion30.Zoom = 5;
      this.emtion30.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion29, "Nói khẽ thôi");
      this.emtion29.Zoom = 5;
      this.emtion29.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion28, "Kẻ thất bại");
      this.emtion28.Zoom = 5;
      this.emtion28.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion4, "Cười toe toét");
      this.emtion4.Zoom = 5;
      this.emtion4.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion1, "Hạnh phúc");
      this.emtion1.Zoom = 5;
      this.emtion1.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion2, "Buồn");
      this.emtion2.Zoom = 5;
      this.emtion2.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion25, "Xua tay");
      this.emtion25.Zoom = 5;
      this.emtion25.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion3, "Nháy mắt");
      this.emtion3.Zoom = 5;
      this.emtion3.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion24, "Mọt sách");
      this.emtion24.Zoom = 5;
      this.emtion24.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion5, "Đánh lông mi");
      this.emtion5.Zoom = 5;
      this.emtion5.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion23, "Thiên thần");
      this.emtion23.Zoom = 5;
      this.emtion23.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion6, "Ôm vào lòng");
      this.emtion6.Zoom = 5;
      this.emtion6.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion22, "Cười ngả nghiêng");
      this.emtion22.Zoom = 5;
      this.emtion22.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion7, "Bối rối");
      this.emtion7.Zoom = 5;
      this.emtion7.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion21, "Nhếch mép");
      this.emtion21.Zoom = 5;
      this.emtion21.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion20, "Chịu đấy");
      this.emtion20.Zoom = 5;
      this.emtion20.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion14, "Tức giận");
      this.emtion14.Zoom = 5;
      this.emtion14.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion19, "Cười ha hả");
      this.emtion19.Zoom = 5;
      this.emtion19.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion10, "Thè lưỡi");
      this.emtion10.Zoom = 5;
      this.emtion10.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion11, "Hôn");
      this.emtion11.Zoom = 5;
      this.emtion11.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion16, "Đẹp zai");
      this.emtion16.Zoom = 5;
      this.emtion16.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion12, "Trái tim tan vỡ");
      this.emtion12.Zoom = 5;
      this.emtion12.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion15, "Tự mãn");
      this.emtion15.Zoom = 5;
      this.emtion15.Click += new EventHandler(this.emtion1_Click);
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
      this.toolTip1.SetToolTip((Control) this.emtion13, "Ngạc nhiên");
      this.emtion13.Zoom = 5;
      this.emtion13.Click += new EventHandler(this.emtion1_Click);
      this.pnUrlImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pnUrlImage.BackColor = Color.Orange;
      this.pnUrlImage.BorderStyle = BorderStyle.FixedSingle;
      this.pnUrlImage.Controls.Add((Control) this.btnImage);
      this.pnUrlImage.Controls.Add((Control) this.label2);
      this.pnUrlImage.Controls.Add((Control) this.txtUrlImage);
      this.pnUrlImage.Location = new Point(159, 557);
      this.pnUrlImage.Name = "pnUrlImage";
      this.pnUrlImage.Size = new Size(456, 25);
      this.pnUrlImage.TabIndex = 9;
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
      this.btnImage.Click += new EventHandler(this.btnImage_Click);
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
      this.txtUrlImage.KeyDown += new KeyEventHandler(this.txtUrlImage_KeyDown);
      this.wbChat.Dock = DockStyle.Fill;
      this.wbChat.Location = new Point(0, 0);
      this.wbChat.MinimumSize = new Size(20, 20);
      this.wbChat.Name = "wbChat";
      this.wbChat.ScriptErrorsSuppressed = true;
      this.wbChat.Size = new Size(1115, 583);
      this.wbChat.TabIndex = 1;
      this.wbChat.WebBrowserShortcutsEnabled = false;
      this.wbChat.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.wbChat_DocumentCompleted);
      this.bunifuElipse2.ElipseRadius = 5;
      this.bunifuElipse2.TargetControl = (Control) this.txtInput;
      this.timer1.Enabled = true;
      this.timer1.Interval = 500;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.pnTop);
      this.Controls.Add((Control) this.pnBot);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (TabChat);
      this.Size = new Size(1100, 657);
      this.pnBot.ResumeLayout(false);
      this.pnTextInput.ResumeLayout(false);
      this.pnTextInput.PerformLayout();
      this.btnSend.EndInit();
      this.pnEmotion.ResumeLayout(false);
      this.pnEmotion.PerformLayout();
      this.bunifuImageButton61.EndInit();
      this.bunifuImageButton31.EndInit();
      this.btnColor.EndInit();
      this.pnTop.ResumeLayout(false);
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
      this.ResumeLayout(false);
    }
  }
}
