// Decompiled with JetBrains decompiler
// Type: AutoUpdate.Form1
// Assembly: SINH TAI SINH LOC, Version=2.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: 604FDB85-ADA0-4F31-900F-9755444F7FBB
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINH TAI SINH LOC.exe

using Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoUpdate
{
  public class Form1 : Form
  {
    private string procName = "SINHTAISINHLOC";
    private string keyEncryption = "Ax2Zk";
    private string _pathVersion = "Version.txt";
    private string urlGetVewVersion = "http://sinhtaisinhloc.com/phanmem/newVersion.txt";
    private string pathExe = "SINHTAISINHLOC.exe";
    private IContainer components = (IContainer) null;
    private WebClient webClient;
    private List<Form1.FileDownload> listFileDownload;
    private Process[] processes;
    private int countUpdate;
    private string _newVersion;
    private string _curlVersion;
    private Form1.FileDownload fileInfo;
    public long totalFileDownload;
    private Label label1;
    private ProgressBar progressBar1;
    private Label labelPerc1;
    private Timer timer1;
    private Label lblThongbao;

    public Form1()
    {
      this.InitializeComponent();
      this.countUpdate = 0;
      this.CloseAppIsRun(this.procName);
    }

    private void CloseAppIsRun(string nameApp)
    {
      try
      {
        this.processes = Process.GetProcessesByName(nameApp);
        foreach (Process process in this.processes)
        {
          process.CloseMainWindow();
          process.WaitForExit();
        }
        this.XuLy();
      }
      catch
      {
        throw;
      }
    }

    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      this.progressBar1.Value = e.ProgressPercentage;
      this.labelPerc1.Text = e.ProgressPercentage.ToString() + "%";
    }

    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
      if (e.Error != null)
      {
        int num = (int) MessageBox.Show(e.Error.ToString());
      }
      else
        ++this.countUpdate;
    }

    private string getCurrenversion()
    {
      string str = "";
      if (System.IO.File.Exists(this._pathVersion))
        str = System.IO.File.ReadAllText(this._pathVersion);
      else
        System.IO.File.Create(this._pathVersion);
      return str;
    }

    private string getNewVersion(string _urlFileListDownload)
    {
      string str;
      try
      {
        this.listFileDownload = new List<Form1.FileDownload>();
        this.webClient = new WebClient();
        str = XShortCut.Encrypt(this.webClient.DownloadString(_urlFileListDownload), this.keyEncryption);
      }
      catch
      {
        str = "Null";
      }
      return str;
    }

    private void XuLy()
    {
      try
      {
        this._newVersion = this.getNewVersion(this.urlGetVewVersion);
        this._curlVersion = this.getCurrenversion();
        string str;
        if (!System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\SINHTAISINHLOC.exe"))
        {
          str = "http://sinhtaisinhloc.com/phanmem/alldownload/Download.txt";
          this.lblThongbao.Text = "Vui lòng đợi cho đến khi quá trình tải về kết thúc .";
        }
        else
        {
          this.lblThongbao.Text = "Vui lòng đợi cho đến khi quá trình cập nhật kết thúc .";
          str = !(this._newVersion != this._curlVersion) ? this.urlGetVewVersion : "http://sinhtaisinhloc.com/phanmem/updatedownload/Download.txt";
        }
        string fileName = Path.GetFileName(str);
        this.ReadData(str, "", fileName);
      }
      catch
      {
        int num = (int) MessageBox.Show("Lỗi cập nhật dữ liệu . Vui lòng liên hệ với hỗ trợ viên để được trợ giúp !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Environment.Exit(1);
      }
    }

    private void RunApp()
    {
      try
      {
        Process.Start(Directory.GetCurrentDirectory() + "\\SINHTAISINHLOC.exe");
      }
      catch
      {
        if (MessageBox.Show("Lỗi file hệ thống, ứng dụng sẽ tự động cập nhật phiển bản mới nhất. Bạn có muốn tiếp tục ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
        {
          System.IO.File.Delete("SINHTAISINHLOC.exe");
          Process.Start(Directory.GetCurrentDirectory() + "\\SINH TAI SINH LOC.exe");
          Environment.Exit(0);
        }
      }
      Environment.Exit(0);
    }

    private void ReadData(string _urlFileListDownload, string _filePath, string _filename)
    {
      try
      {
        this.DownloadFile(_urlFileListDownload, _filePath, _filename);
        this.listFileDownload = new List<Form1.FileDownload>();
        this.webClient = new WebClient();
        string[] strArray1 = this.webClient.DownloadString(_urlFileListDownload).Split(';');
        if (System.IO.File.Exists("Download.txt"))
          System.IO.File.Delete("Download.txt");
        if (System.IO.File.Exists("newVersion.txt"))
          System.IO.File.Delete("newVersion.txt");
        if ((uint) strArray1.Length > 0U)
        {
          for (int index = 0; index < strArray1.Length - 1; ++index)
          {
            string[] strArray2 = strArray1[index].Split('|');
            this.fileInfo = new Form1.FileDownload();
            this.fileInfo.UrlDownloadFile = strArray2[0];
            this.fileInfo.FilePath = strArray2[1];
            this.fileInfo.FileName = strArray2[2];
            this.fileInfo.UrlDownloadFile = new Regex(Regex.Escape("\r\n")).Replace(this.fileInfo.UrlDownloadFile, "");
            this.listFileDownload.Add(this.fileInfo);
          }
          if (this.listFileDownload.Count > 0)
          {
            foreach (Form1.FileDownload fileDownload in this.listFileDownload)
            {
              try
              {
                string path = fileDownload.FilePath + fileDownload.FileName;
                if (System.IO.File.Exists(path))
                  System.IO.File.Delete(path);
              }
              catch
              {
              }
              this.DownloadFile(fileDownload.UrlDownloadFile, fileDownload.FilePath, fileDownload.FileName);
            }
          }
          else
            this.RunApp();
        }
        else
          this.RunApp();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Không thể kết nối tới máy chủ. Vui lòng thử lại sau !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Environment.Exit(1);
      }
    }

    public void DownloadFile(string _urlAddress, string _filePath, string _filename)
    {
      using (this.webClient = new WebClient())
      {
        this.webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.Completed);
        this.webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
        Uri address = new Uri(_urlAddress);
        try
        {
          if (!Directory.Exists(Directory.GetCurrentDirectory() + "/" + _filePath))
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/" + _filePath);
          this.webClient.DownloadFileAsync(address, Directory.GetCurrentDirectory() + "/" + _filePath + _filename);
        }
        catch
        {
          if (MessageBox.Show("Không thể lưu dữ liệu cập nhật. Vui lòng liên hệ hỗ trợ viên để được trợ giúp !", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            Process.Start("https://www.messenger.com/t/sinhtaisinhloc");
          else
            Environment.Exit(0);
        }
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.listFileDownload == null || this.listFileDownload.Count <= 0 || this.countUpdate - 1 != this.listFileDownload.Count)
        return;
      this.timer1.Stop();
      this.Hide();
      if (MessageBox.Show("Cập nhật phiên bản thành công. Bạn có muốn khởi chạy ứng dụng ngay bây giờ !", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
      {
        System.IO.File.WriteAllText(this._pathVersion, this._newVersion);
        this.RunApp();
      }
      else
        System.IO.File.WriteAllText(this._pathVersion, this._newVersion);
      Environment.Exit(0);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.label1 = new Label();
      this.progressBar1 = new ProgressBar();
      this.labelPerc1 = new Label();
      this.timer1 = new Timer(this.components);
      this.lblThongbao = new Label();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 41);
      this.label1.Name = "label1";
      this.label1.Size = new Size(64, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Tiến trình :";
      this.progressBar1.BackColor = SystemColors.Control;
      this.progressBar1.ForeColor = Color.Teal;
      this.progressBar1.Location = new Point(76, 37);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(557, 22);
      this.progressBar1.TabIndex = 1;
      this.progressBar1.Value = 30;
      this.labelPerc1.AutoSize = true;
      this.labelPerc1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelPerc1.Location = new Point(636, 40);
      this.labelPerc1.Name = "labelPerc1";
      this.labelPerc1.Size = new Size(16, 15);
      this.labelPerc1.TabIndex = 3;
      this.labelPerc1.Text = "%";
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.lblThongbao.AutoSize = true;
      this.lblThongbao.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblThongbao.ForeColor = Color.Teal;
      this.lblThongbao.Location = new Point(188, 11);
      this.lblThongbao.Name = "lblThongbao";
      this.lblThongbao.Size = new Size(322, 17);
      this.lblThongbao.TabIndex = 4;
      this.lblThongbao.Text = "Vui lòng đợi cho đến khi quá trình tải về kết thúc .";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(673, 66);
      this.Controls.Add((Control) this.lblThongbao);
      this.Controls.Add((Control) this.labelPerc1);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Cập Nhật Phiên Bản - Sinh Tài Sinh Lộc Phần Mềm Thống Kê Xổ Số Soi Cầu Lô Đề Dành Cho Dân Chuyên Nghiệp";
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public class FileDownload
    {
      public string UrlDownloadFile { get; set; }

      public string FilePath { get; set; }

      public string FileName { get; set; }
    }
  }
}
