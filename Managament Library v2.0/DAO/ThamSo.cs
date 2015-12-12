using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Managament_Library_v2._0.EF;

namespace Managament_Library_v2._0.DAO
{
    public class ThamSo
    {
        LibraryDataContext data = new LibraryDataContext();

        DataTable loadTableThamSo()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from THAMSO", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<THAMSO> loadThamSo()
        {
            List<THAMSO> thamSo = new List<THAMSO>();
            DataTable dt = loadTableThamSo();
            THAMSO temp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                temp = new THAMSO();
                temp.tenthamso = dt.Rows[i]["tenthamso"].ToString();
                temp.kieu = dt.Rows[i]["kieu"].ToString();
                temp.giatri = dt.Rows[i]["giatri"].ToString();
                temp.tinhtrang = (bool)dt.Rows[i]["tinhtrang"];
                thamSo.Add(temp);
            }
            return thamSo;
        }

        public THAMSO timThamSo(THAMSO inf)
        {
            return data.THAMSOes.Find(inf.tenthamso);
        }

        public void suaThamSo(THAMSO inf)
        {
            var temp = data.THAMSOes.Find(inf.tenthamso);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(inf);
                data.SaveChanges();
            }
        }
    }
}
