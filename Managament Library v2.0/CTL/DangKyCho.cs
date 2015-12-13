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
    public class DangKyCho
    {
        DAO.DangKyCho data = new DAO.DangKyCho();

        public DataTable loadDangKyCho()
        {
            return data.loadDangKyCho();
        }

        public void themDangKyCho(DKCHOMUON inf)
        {
            data.themDangKyCho(inf);
        }

        public void suaDangKyCho(DKCHOMUON bef, DKCHOMUON aft)
        {
            data.suaDangKyCho(bef, aft);
        }

        public DKCHOMUON timDangKyCho(DKCHOMUON inf)
        {
            return data.timDangKyCho(inf);
        }

        public DataTable timDangKyCho(DKCHOMUON inf, int type)
        {
            return data.timDangKyCho(inf, type);
        }
    }
}
