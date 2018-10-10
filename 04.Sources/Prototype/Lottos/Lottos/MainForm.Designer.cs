namespace Lottos
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuTools = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWebrowser = new System.Windows.Forms.WebBrowser();
            this.mnuTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuTools
            // 
            this.mnuTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.mnuTools.Location = new System.Drawing.Point(0, 0);
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(800, 24);
            this.mnuTools.TabIndex = 0;
            this.mnuTools.Text = "Tools Menu";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mainWebrowser
            // 
            this.mainWebrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWebrowser.Location = new System.Drawing.Point(0, 24);
            this.mainWebrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mainWebrowser.Name = "mainWebrowser";
            this.mainWebrowser.Size = new System.Drawing.Size(800, 426);
            this.mainWebrowser.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainWebrowser);
            this.Controls.Add(this.mnuTools);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mnuTools.ResumeLayout(false);
            this.mnuTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuTools;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.WebBrowser mainWebrowser;
    }
}