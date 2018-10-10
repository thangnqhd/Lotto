using PluggableCoreLibrary;
using SoKetQua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottos
{
    public partial class MainForm : Form
    {
        private const string IpServer = "107.191.52.85";
        private const int PortServer = 4500;
        public MainForm()
        {
            InitializeComponent();
            // Load menu
            this.LoadMenuTools();

            // Display html view
            this.DisplayView("Hello world");
        }

        private void LoadSetting()
        {
            

        }

        private void LoadMenuTools()
        {
            var plugins = ThongKeHostProvider.ThongKeList;
            if (plugins != null && plugins.Count > 0)
            {
                plugins.ForEach(item =>
                {
                    ToolStripMenuItem pluginMenuItem = new ToolStripMenuItem(item.GetTen());
                    toolsToolStripMenuItem.DropDownItems.Add(pluginMenuItem);
                });
            }

            // Add administrator menu
            ToolStripMenuItem adminMenu = new ToolStripMenuItem("Quan tri");
            adminMenu.Click += AdminMenu_Click;
            mnuTools.Items.Add(adminMenu);
        }

        private void AdminMenu_Click(object sender, EventArgs e)
        {
            ParseWebData parseWeb = new ParseWebData("");
            parseWeb.ImportKetQuaData();
        }

        private void DisplayView(string strHtml)
        {
            string html = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'>\r\n                                <head>\r\n                                    <meta charset='utf-8' />\r\n                                    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1' />\r\n                                    <meta name='description' content='' />\r\n                                    <meta name='author' content='' />\r\n                                    <meta http-equiv='X-UA-Compatible' content='IE=11' />\r\n                                     " + "" + "<title>THỐNG KÊ XỔ SỐ</title></head><body  style='font-family:Verdana;'><div class='container' style='margin-right:15px;'><div class='row'><div class='col-md-8'><div class='panel panel-info'><div class='panel-heading' ></div><div class='panel-body'><ul class='media-list'><li class='media'>" + strHtml + "</li> </ul></div><div class='panel-footer'></div></div></div></div></div></body></html>";
            try
            {
                if (!mainWebrowser.IsDisposed)
                {
                    mainWebrowser.Navigate("about:blank");
                }
                else
                {
                    mainWebrowser = new WebBrowser();
                    mainWebrowser.Navigate("about:blank");
                }
                if (mainWebrowser.Document != (HtmlDocument)null)
                    mainWebrowser.Document.Write(string.Empty);
            }
            finally
            {
            }
            mainWebrowser.DocumentText = html;
        }
    }
}
