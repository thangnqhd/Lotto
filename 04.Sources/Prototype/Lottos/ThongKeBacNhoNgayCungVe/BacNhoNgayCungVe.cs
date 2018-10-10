using PluggableCoreLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluggableCoreLibrary.Common;
using PluggableCoreLibrary.Attributes;

namespace ThongKeBacNhoNgayCungVe
{
    [ThongKePlugInAttribute("Thong ke bac nho ngay cung ve")]
    public class BacNhoNgayCungVe : IThongKe
    {
        public string HienThi()
        {
            return string.Empty;
        }

        string IThongKe.GetTenThongKe()
        {
            return Constants.TK_BACNHO_NGAYCUNGVE;
        }

        void IThongKe.TinhToan()
        {
            
        }
    }
}
