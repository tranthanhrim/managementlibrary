using Managament_Library_v2._0.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managament_Library_v2._0.DAO
{
    public class MatKhau
    {
        LibraryDataContext data = new LibraryDataContext();
        public void suaMatKhau(MATKHAU bef, MATKHAU aft)
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "update MATKHAU set matkhau = @mk, candangnhap = @tt where matkhau = @mk1";
            sql.CommandType = CommandType.Text;
            sql.Parameters.AddWithValue("@mk", aft.matkhau1);
            sql.Parameters.AddWithValue("@tt", aft.candangnhap);
            sql.Parameters.AddWithValue("mk1", bef.matkhau1);
            sql.Connection = DataProvider.con;
            sql.ExecuteNonQuery();
        }

        public string layMatKhau()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from MATKHAU", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["matkhau"].ToString();
        }

        public bool canDangNhap()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from MATKHAU", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0]["candangnhap"].ToString() == String.Empty)
                return false;
            else if ((bool)dt.Rows[0]["candangnhap"] == true)
                return true;
            else
                return false;
        }

        public MATKHAU tim(MATKHAU inf)
        {
            return data.MATKHAUs.Find(inf.matkhau1);
        }
    }
}
