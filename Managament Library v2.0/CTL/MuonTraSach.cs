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
    public class MuonTraSach
    {
        DAO.MuonTraSach data = new DAO.MuonTraSach();
        public DataTable loadMuonTraSach()
        {
            return data.loadMuonTraSach();
        }

        public int themMuonTraSach(MUONSACH inf)
        {
            return data.themMuonTraSach(inf);
        }

        public void suaMuonTraSach(MUONSACH before, MUONSACH after)
        {
            data.suaMuonTraSach(before, after);
        }

        public void xoaMuonTraSach(MUONSACH inf)
        {
            data.xoaMuonTraSach(inf);
        }

        public MUONSACH timMuonTraSach(MUONSACH inf)
        {
            return data.timMuonTraSach(inf);
        }

        public DataTable timMuonTraSach(MUONSACH inf, int type)
        {
            return data.timMuonTraSach(inf, type);
        }

    }
}
