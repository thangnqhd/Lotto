using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessCoreLibrary.Common;
using BussinessCoreLibrary.Models;

namespace BussinessCoreLibrary
{
    public class KetQuaBL
    {private tblKetqua _tblKetqua;
        public KetQuaBL()
        {
        }
        public void Insert(TblKetQua dataKetQua)
        {
            if (null == dataKetQua)
            {
                return;
            }
            using (var dbEntities = new LotodbEntities())
            {
                var tblKetqua = dataKetQua.MapTo<tblKetqua>();
                dbEntities.tblKetquas.Add(tblKetqua);
                dbEntities.SaveChanges();
            }
        }

        public DateTime GetMaxDateTime()
        {
            using (var dbEntities = new LotodbEntities())
            {
                var maxDate = dbEntities.tblKetquas.OrderByDescending(item => item.NgayMoThuong).FirstOrDefault();
                if (maxDate != null)
                {
                    return maxDate.NgayMoThuong;
                }
            }
            return DateTime.Now;
        }
    }
}
