using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluggableCoreLibrary.Interfaces;

namespace PluggableCoreLibrary
{
    public class ThongKeHost
    {
        private IThongKe _thongke;
        public ThongKeHost(IThongKe thongke)
        {
            this._thongke = thongke;
        }

        public string GetTen()
        {
            return _thongke.GetTenThongKe();
        }
    }
}
