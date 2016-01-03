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

        public DataTable loadDauSachTuaSach()
        {
            return data.loadDauSachTuaSach();
        }

        public void themTuaSach(TUASACH ts)
        {
            data.themTuaSach(ts);
        }
        public void themDauSach(DAUSACH ds)
        {
            data.themDauSach(ds);
        }

        public void themCuonSach(CUONSACH cs)
        {
            data.themCuonSach(cs);
        }

        public void suaTuaSach(TUASACH ts)
        {
            data.suaTuaSach(ts);
        }

        public void suaDauSach(DAUSACH ds)
        {
            data.suaDauSach(ds);
        }

        public void suaCuonSach(CUONSACH cs)
        {
            data.suaCuonSach(cs);
        }

        public void xoaTuaSach(string matuasach)
        {
            data.xoaTuaSach(matuasach);
        }

        public void xoaDauSach(string madausach)
        {
            data.xoaDauSach(madausach);
        }

        public void xoaCuonSach(string macuonsach)
        {
            data.xoaCuonSach(macuonsach);
        }
        
        public void xoaTatCa()
        {
            data.xoaTatCa();
        }

        public TUASACH timTuaSach(TUASACH ts)
        {
            return data.timTuaSach(ts);
        }

        public DAUSACH timDauSach(DAUSACH ds)
        {
            return data.timDauSach(ds);
        }
   
        public CUONSACH timCuonSach(CUONSACH cs)
        {
            return data.timCuonSach(cs);
        }

        public DataTable timTuaSach(TUASACH ts, int type)
        {
            return data.timTuaSach(ts, type);
        }

        public DataTable timDauSach(DAUSACH ds, int type)
        {
            return data.timDauSach(ds, type);
        }

        public DataTable timCuonSach(CUONSACH cs, int type)
        {
            return data.timCuonSach(cs, type);
        }

        public DataTable timTheoTen(string ten, int type)
        {
            return data.timTheoTen(ten, type);
        }
    }
}
