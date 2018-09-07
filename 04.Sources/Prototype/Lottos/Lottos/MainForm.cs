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
            parseWeb.Parsing();
        }
    }
}
