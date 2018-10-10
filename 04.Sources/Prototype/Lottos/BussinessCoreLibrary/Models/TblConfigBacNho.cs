using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessCoreLibrary.Models
{
    public class TblConfigBacNho
    {
        public int Stt { get; set; }

        public string MaTaiKhoan { get; set; }

        public int KhungDanhLoCapNuoi { get; set; }

        public int KhungDanhBachThuNuoi { get; set; }

        public int KhungDanhDacBietNuoi { get; set; }

        public int KhungLoXien2 { get; set; }

        public int HienThiNgayVe { get; set; }

        public int BiendoTrungDau { get; set; }

        public int BiendoTrungDuoi { get; set; }

        public int SoBanGhi { get; set; }

        public int TheoGiai { get; set; }

        public int TheoNhay { get; set; }

        public int TheoCap { get; set; }

        public int DauCam { get; set; }

        public int DuoiCam { get; set; }

        public int CapCungVe { get; set; }

        public int DanCungVe { get; set; }

        public int BacNhoTheoThu { get; set; }

        public int ThongKeCauDep { get; set; }

        public DateTime NgayThem { get; set; }
    }
}
