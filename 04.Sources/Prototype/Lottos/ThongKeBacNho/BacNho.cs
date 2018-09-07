using PluggableCoreLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluggableCoreLibrary.Common;
using PluggableCoreLibrary.Attributes;

namespace ThongKeBacNho
{
    [ThongKePlugInAttribute("Thong ke bac nho can ban")]
    public class BacNho : IThongKe
    {
        string IThongKe.GetTenThongKe()
        {
            return Constants.TK_BACNHO;
        }

        void IThongKe.TinhToan()
        {
            
        }
    }
}
