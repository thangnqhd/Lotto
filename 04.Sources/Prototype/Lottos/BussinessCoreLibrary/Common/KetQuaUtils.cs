using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessCoreLibrary.Common
{
    public static class KetQuaUtils
    {
        /// <summary>
        /// Hàm trả lại bộ số lô tương ứng từ giá trị loto input để tạo thành 1 cặp
        /// </summary>
        /// <param name="loto">bộ số cần tìm cặp</param>
        /// <returns></returns>
        public static string GetCapLo(string loto)
        {
            string str;
            switch (loto)
            {
                case "00":
                    str = "55";
                    break;
                case "11":
                    str = "66";
                    break;
                case "22":
                    str = "77";
                    break;
                case "33":
                    str = "88";
                    break;
                case "44":
                    str = "99";
                    break;
                case "55":
                    str = "00";
                    break;
                case "66":
                    str = "11";
                    break;
                case "77":
                    str = "22";
                    break;
                case "88":
                    str = "33";
                    break;
                case "99":
                    str = "44";
                    break;
                default:
                    str = loto.Substring(1, 1) + loto.Substring(0, 1);
                    break;
            }
            return str;
        }
    }
}
