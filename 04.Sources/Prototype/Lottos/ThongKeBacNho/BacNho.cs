using PluggableCoreLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluggableCoreLibrary.Common;
using PluggableCoreLibrary.Attributes;
using System.Globalization;
using BussinessCoreLibrary.Common;

namespace ThongKeBacNho
{
    [ThongKePlugInAttribute("Thong ke bac nho can ban")]
    public class BacNho : IThongKe
    {
        public string HienThi()
        {

            return string.Empty;
        }

        string IThongKe.GetTenThongKe()
        {
            return Constants.TK_BACNHO;
        }

        void IThongKe.TinhToan()
        {
            
        }

        void TimNgayVeLoCap(int soBanGhi)
        {
            // Duyệt qua từng bộ số lô(tổng 100 cặp lô từ 00->99)
            for (int index1 = 0; index1 < 100; ++index1)
            {
                // tạo bộ số, trường hợp số < 10 thì ghép thêm 0 vào trước bộ số 9 -> 09
                TinhNgayVeLoCap tinhNgayVeLoCap = new TinhNgayVeLoCap();
                string loto = index1.ToString((IFormatProvider)CultureInfo.InvariantCulture);
                if (index1 < 10)
                    loto = "0" + index1.ToString((IFormatProvider)CultureInfo.InvariantCulture);

                // Get cặp tương ứng với bộ số
                string str1 = KetQuaUtils.GetCapLo(loto);
            }
        }
    }
}
