using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessCoreLibrary
{
    public class KetQuaBL
    {
        private tblKetqua _tblKetqua;
        public KetQuaBL(tblKetqua tblKetqua)
        {
            _tblKetqua = tblKetqua;
        }
        public void Insert()
        {
            if (null == _tblKetqua)
            {
                return;
            }
            using (var dbEntities = new LotodbEntities())
            {
                dbEntities.tblKetquas.Add(_tblKetqua);
                dbEntities.SaveChanges();
            }
        }
    }
}
