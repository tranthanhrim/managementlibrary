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

        public void themViPham(VIPHAM inf)
        {
            data.themViPham(inf);
        }

        public void suaViPham(VIPHAM inf)
        {
            data.suaViPham(inf);
        }

        public void xoaViPham(string madocgia)
        {
            data.xoaViPham(madocgia);
        }

        public void xoaTatCa()
        {
            data.xoaTatCa();
        }

        public VIPHAM timViPham(VIPHAM inf)
        {
            return data.timViPham(inf);
        }

        public DataTable timViPham(string mdg)
        {
            return data.timViPham(mdg);
        }
    }
}
