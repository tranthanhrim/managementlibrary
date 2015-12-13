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
    public class DangKyCho
    {
        LibraryDataContext data = new LibraryDataContext();
        public DataTable loadDangKyCho()
        {
            SqlDataAdapter da = new SqlDataAdapter("select* from DKCHOMUON", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madocgia"].ColumnName = "Mã độc giả";
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["ngaygiodk"].ColumnName = "Ngày đăng ký";
            dt.Columns["tinhtrang"].ColumnName = "Tình trạng";
            return dt;
        }

        public void themDangKyCho(DKCHOMUON inf)
        {
            data.DKCHOMUONs.Add(inf);
            data.SaveChanges();
        }

        public void suaDangKyCho(DKCHOMUON bef, DKCHOMUON aft)
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "update DKCHOMUON set madocgia = @mdg, madausach = @sach, ngaygiodk = @ngay, tinhtrang = @tt where madocgia = @mdg1 and madausach = @sach1 and ngaygiodk = @ngay1";
            sql.CommandType = CommandType.Text;
            sql.Parameters.AddWithValue("@mdg", aft.madocgia);
            sql.Parameters.AddWithValue("@sach", aft.madausach);
            sql.Parameters.AddWithValue("@ngay", aft.ngaygiodk);
            sql.Parameters.AddWithValue("@tt", aft.tinhtrang);

            sql.Parameters.AddWithValue("@mdg1", bef.madocgia);
            sql.Parameters.AddWithValue("@sach1", bef.madausach);
            sql.Parameters.AddWithValue("@ngay1", bef.ngaygiodk);

            sql.Connection = DataProvider.con;
            sql.ExecuteNonQuery();
        }

        public DKCHOMUON timDangKyCho(DKCHOMUON inf)
        {
            return data.DKCHOMUONs.Find(inf.madocgia, inf.madausach, inf.ngaygiodk);
        }

        public DataTable timDangKyCho(DKCHOMUON inf, int type)
        {
            DataTable dt = new DataTable();
            if (type == 1)//tìm theo mã độc giả
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from DKCHOMUON where madocgia = @mdg", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@mdg", inf.madocgia);
                da.Fill(dt);
            }
            else if (type == 2)//tìm theo mã cuốn sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from DKCHOMUON where madausach = @sach", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@sach", inf.madausach);
                da.Fill(dt);
            }
            else if (type == 3)//tìm theo ngày
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from DKCHOMUON where ngaygiodk = @ngay", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@ngay", inf.ngaygiodk.Date);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
