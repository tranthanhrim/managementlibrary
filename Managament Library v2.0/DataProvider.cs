using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Managament_Library_v2._0
{
    public class DataProvider
    {
        public static SqlConnection con = null;
        public static bool openConnect()
        {
            try
            {
                string connect = ConfigurationManager.ConnectionStrings["LibraryDataContext"].ConnectionString;
                con = new SqlConnection(connect);
                con.Open();
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed connection!");
                return false;
            }
        }

        public static void closeConnect()
        {
            try
            {
                string connect = ConfigurationManager.ConnectionStrings["LibraryDataContext"].ConnectionString;
                con = new SqlConnection(connect);
                con.Close();
            }
            catch
            {
            }
        }

        static public DataTable getDataTable (string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
