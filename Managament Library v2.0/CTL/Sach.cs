using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Managament_Library_v2._0.DAO;
using Managament_Library_v2._0.EF;


namespace Managament_Library_v2._0.CTL
{
    public class Sach
    {
        DAO.Sach data = new DAO.Sach();

        public DataTable loadTuaSach()
        {
            return data.loadTuaSach();
        }
        public DataTable loadDauSach()
        {
            return data.loadDauSach();
        }
        public DataTable loadCuonSach()
        {
            return data.loadCuonSach();
        }

        public void suaDauSach(DAUSACH ds)
        {
            data.suaDauSach(ds);
        }

        public DAUSACH timDauSach(DAUSACH ds)
        {
            return data.timDauSach(ds);
        }

        public void suaCuonSach(CUONSACH cs)
        {
            data.suaCuonSach(cs);
        }

        public CUONSACH timCuonSach(CUONSACH cs)
        {
            return data.timCuonSach(cs);
        }
    }
}
