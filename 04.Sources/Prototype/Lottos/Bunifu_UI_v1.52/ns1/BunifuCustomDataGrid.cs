// Decompiled with JetBrains decompiler
// Type: ns1.BunifuCustomDataGrid
// Assembly: Bunifu_UI_v1.52, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9413D093-E954-4F52-971C-372F90D3860A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Bunifu_UI_v1.52.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ns1
{
  public class BunifuCustomDataGrid : DataGridView
  {
    private bool bool_0 = true;
    public Color Hcolor = Color.SeaGreen;
    public Color HBgcolor = Color.SeaGreen;
    private IContainer icontainer_0;

    public BunifuCustomDataGrid()
    {
      this.method_0();
      this.ColumnHeadersDefaultCellStyle.BackColor = this.Hcolor;
      this.ColumnHeadersDefaultCellStyle.ForeColor = this.HBgcolor;
      this.BorderStyle = BorderStyle.None;
      this.EnableHeadersVisualStyles = false;
    }

    public new bool DoubleBuffered
    {
      set
      {
        this.bool_0 = value;
        this.ApplyDoubleBuffer((DataGridView) this, this.bool_0);
      }
      get
      {
        return this.bool_0;
      }
    }

    public Color HeaderBgColor
    {
      get
      {
        return this.Hcolor;
      }
      set
      {
        this.Hcolor = value;
        this.ColumnHeadersDefaultCellStyle.BackColor = this.Hcolor;
        this.ColumnHeadersDefaultCellStyle.ForeColor = this.HBgcolor;
        this.BorderStyle = BorderStyle.None;
      }
    }

    public Color HeaderForeColor
    {
      get
      {
        return this.HBgcolor;
      }
      set
      {
        this.HBgcolor = value;
        this.ColumnHeadersDefaultCellStyle.BackColor = this.Hcolor;
        this.ColumnHeadersDefaultCellStyle.ForeColor = this.HBgcolor;
        this.BorderStyle = BorderStyle.None;
      }
    }

    public void ApplyDoubleBuffer(DataGridView dgv, bool setting)
    {
      try
      {
        dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) dgv, (object) setting, (object[]) null);
      }
      catch (Exception ex)
      {
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_0()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.BeginInit();
      this.SuspendLayout();
      gridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
      this.AlternatingRowsDefaultCellStyle = gridViewCellStyle1;
      this.BackgroundColor = Color.Gainsboro;
      this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = Color.SeaGreen;
      gridViewCellStyle2.Font = new Font("Century Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = Color.White;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.ColumnHeadersDefaultCellStyle = gridViewCellStyle2;
      this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      this.EndInit();
      this.ResumeLayout(false);
    }
  }
}
