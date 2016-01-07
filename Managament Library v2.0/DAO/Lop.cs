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
    public class Lop
    {
        LibraryDataContext data = new LibraryDataContext();

        public DataTable loadLop()
        {
            SqlDataAdapter da = new SqlDataAdapter("select* from LOP", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["lop"].ColumnName = "Lớp";
            return dt;
        }

        public void themLop(LOP inf)
        {
            data.LOPs.Add(inf);
            data.SaveChanges();
        }

        public void suaLop(LOP bef, LOP aft)
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "update LOP set lop = @l where lop = @l1";
            sql.CommandType = CommandType.Text;
            sql.Parameters.AddWithValue("@l", aft.lop1);
            sql.Parameters.AddWithValue("@l1", bef.lop1);
            sql.Connection = DataProvider.con;
            sql.ExecuteNonQuery();
        }

        public void xoaLop(LOP inf)
        {
            var temp = data.LOPs.Find(inf.lop1);

            if (temp != null)
            {
                data.LOPs.Remove(temp);
                data.SaveChanges();
            }
        }
    }
}
