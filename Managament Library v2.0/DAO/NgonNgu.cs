using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Managament_Library_v2._0.EF;

namespace Managament_Library_v2._0.DAO
{
    public class NgonNgu
    {
        LibraryDataContext data = new LibraryDataContext();
        public DataTable loadNgonNgu()
        {
            SqlDataAdapter da = new SqlDataAdapter("select* from NGONNGU", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["ngonngu"].ColumnName = "Ngôn ngữ";
            return dt;
        }

        public void themNgonNgu(NGONNGU inf)
        {
            data.NGONNGUs.Add(inf);
            data.SaveChanges();
        }

        public void suaNgonNgu(NGONNGU bef, NGONNGU aft)
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "update NGONNGU set ngonngu = @nn where ngonngu = @nn1";
            sql.CommandType = CommandType.Text;
            sql.Parameters.AddWithValue("@nn", aft.ngonngu1);
            sql.Parameters.AddWithValue("@nn1", bef.ngonngu1);
            sql.Connection = DataProvider.con;
            sql.ExecuteNonQuery();
        }

        public void xoaNgonNgu(NGONNGU inf)
        {
            var temp = data.NGONNGUs.Find(inf.ngonngu1);

            if (temp != null)
            {
                data.NGONNGUs.Remove(temp);
                data.SaveChanges();
            }
        }
    }
}
