using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.DAO;

namespace Managament_Library_v2._0.CTL
{
    public class Lop
    {
        DAO.Lop data = new DAO.Lop();
        
        public DataTable loadLop()
        {
            return data.loadLop();
        }

        public void themLop(LOP inf)
        {
            data.themLop(inf);
        }

        public void suaLop(LOP bef, LOP aft)
        {
            data.suaLop(bef, aft);
        }

        public void xoaLop(LOP inf)

        {
            data.xoaLop(inf);
        }
    }
}
