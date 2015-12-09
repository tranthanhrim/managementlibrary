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
    public class ViPham
    {
        DAO.ViPham data = new DAO.ViPham();

        public DataTable loadViPham()
        {
            return data.loadViPham();
        }

        public void suaViPham(VIPHAM inf)
        {
            data.suaViPham(inf);
        }

        public VIPHAM timViPham(VIPHAM inf)
        {
            return data.timViPham(inf);
        }
    }
}
