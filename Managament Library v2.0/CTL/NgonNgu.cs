using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.DAO;

namespace Managament_Library_v2._0.CTL
{
    public class NgonNgu
    {
        DAO.NgonNgu data = new DAO.NgonNgu();

        public DataTable loadNgonNgu()
        {
            return data.loadNgonNgu();
        }

        public void themNgonNgu(NGONNGU inf)
        {
            data.themNgonNgu(inf);
        }

        public void suaNgonNgu(NGONNGU bef, NGONNGU aft)
        {
            data.suaNgonNgu(bef, aft);
        }
        public void xoaNgonNgu(NGONNGU inf)
        {
            data.xoaNgonNgu(inf);
        }
    }
}
