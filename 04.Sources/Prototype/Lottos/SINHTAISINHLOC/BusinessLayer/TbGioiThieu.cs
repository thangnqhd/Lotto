// Decompiled with JetBrains decompiler
// Type: Thống_kê_xổ_số.BusinessLayer.TbGioiThieu
// Assembly: SINHTAISINHLOC, Version=6.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: 14ECBB60-AC76-4B86-9AB8-7862FB51126A
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\SINHTAISINHLOC.exe

using ConfigClient;
using System.Data;
using System.Data.SqlClient;

namespace Thống_kê_xổ_số.BusinessLayer
{
  internal class TbGioiThieu
  {
    public bool Insert(string userGioiThieu, string userThanhVien)
    {
      string cmdText = string.Format("TBGioiThieu_Insert N'{0}', N'{1}'", (object) userGioiThieu, (object) userThanhVien);
      try
      {
        SqlCommand sqlCommand = new SqlCommand(cmdText);
        sqlCommand.CommandType = CommandType.Text;
        SqlCommand cmd = sqlCommand;
        DataWeb.db.ExecuteNonQuery(cmd);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
