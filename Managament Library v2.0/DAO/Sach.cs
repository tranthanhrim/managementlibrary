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
    public class Sach
    {
        LibraryDataContext data = new LibraryDataContext();
        public DataTable loadTuaSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from TUASACH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["matuasach"].ColumnName = "Mã tựa sách";
            dt.Columns["tentuasach"].ColumnName = "Tên tựa sách";
            dt.Columns["tacgia"].ColumnName = "Tác giả";
            dt.Columns["gioithieu"].ColumnName = "Giới thiệu";
            return dt;
        }

        public DataTable loadDauSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from DAUSACH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["matuasach"].ColumnName = "Mã tựa sách";
            dt.Columns["ngonngu"].ColumnName = "Ngôn ngữ";
            dt.Columns["tinhtrang"].ColumnName = "Tình trạng";
            dt.DefaultView.Sort = "Mã tựa sách";
            return dt;
        }

        public DataTable loadCuonSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from CUONSACH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["macuonsach"].ColumnName = "Mã cuốn sách";
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["tinhtrang"].ColumnName = "Tình trạng";
            dt.DefaultView.Sort = "Mã đầu sách";
            return dt;
        }

        public DataTable loadDauSachTuaSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from DAUSACH ds join TUASACH ts on ds.matuasach = ts.matuasach", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Remove("matuasach1");
            dt.Columns.Remove("gioithieu");
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["matuasach"].ColumnName = "Mã tựa sách";
            dt.Columns["ngonngu"].ColumnName = "Ngôn ngữ";
            dt.Columns["tinhtrang"].ColumnName = "Tình trạng";
            dt.Columns["tentuasach"].ColumnName = "Tên tựa sách";
            dt.Columns["tacgia"].ColumnName = "Tác giả";
            dt.DefaultView.Sort = "Mã tựa sách";
            return dt;
        }

        public void themTuaSach(TUASACH ts)
        {
            data.TUASACHes.Add(ts);
            data.SaveChanges();
        }

        public void themDauSach(DAUSACH ds)
        {
            data.DAUSACHes.Add(ds);
            data.SaveChanges();
        }

        public void themCuonSach(CUONSACH cs)
        {
            data.CUONSACHes.Add(cs);
            data.SaveChanges();
        }

        public void suaTuaSach(TUASACH ts)
        {
            var temp = data.TUASACHes.Find(ts.matuasach);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(ts);
                data.SaveChanges();
            }
        }

        public void suaDauSach(DAUSACH ds)
        {
            var temp = data.DAUSACHes.Find(ds.madausach);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(ds);
                data.SaveChanges();
            }
        }

        public void suaCuonSach(CUONSACH cs)
        {
            var temp = data.CUONSACHes.Find(cs.macuonsach);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(cs);
                data.SaveChanges();
            }
        }

        public void xoaTuaSach(string matuasach)
        {
            data.Database.ExecuteSqlCommand("delete from TUASACH where matuasach = '"+matuasach+"'");
        }

        public void xoaDauSach(string madausach)
        {
            data.Database.ExecuteSqlCommand("delete from DAUSACH where madausach = '" + madausach + "'");
        }

        public void xoaCuonSach(string macuonsach)
        {
            data.Database.ExecuteSqlCommand("delete from CUONSACH where macuonsach = '" + macuonsach + "'");
        }

        public void xoaTatCa()
        {
            data.Database.ExecuteSqlCommand("delete from CUONSACH");
            data.Database.ExecuteSqlCommand("delete from DAUSACH");
            data.Database.ExecuteSqlCommand("delete from TUASACH");
            data.SaveChanges();
        }

        public TUASACH timTuaSach(TUASACH ts)
        {
            return data.TUASACHes.Find(ts.matuasach);
        }

        public DAUSACH timDauSach(DAUSACH ds)
        {
            return data.DAUSACHes.Find(ds.madausach);
        }

        public CUONSACH timCuonSach(CUONSACH cs)
        {
            return data.CUONSACHes.Find(cs.macuonsach);
        }

        public DataTable timTuaSach(TUASACH ts, int type)
        {
            DataTable result = new DataTable();
            if (type == 1) //tìm theo mã tựa sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from TUASACH where matuasach = @mts",DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@mts", ts.matuasach);
                da.Fill(result);
            }
            else if (type == 2) //tìm theo tên tựa sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from TUASACH where tentuasach = @ten",DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@ten", ts.tentuasach);
                da.Fill(result);
            }
            else if (type == 3) //tìm theo tên tác giả
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from TUASACH where tacgia = @tg",DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@tg", ts.tacgia);
                da.Fill(result);
            }
            return result;
        }

        public DataTable timDauSach(DAUSACH ds, int type)
        {
            DataTable result = new DataTable();
            if (type == 1) //tìm theo mã đầu sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from DAUSACH where madausach = @mds", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@mds", ds.madausach);
                da.Fill(result);
            }
            else if (type == 2) //tìm theo mã tựa sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from DAUSACH where matuasach = @mts", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@mts", ds.matuasach);
                da.Fill(result);
                result.Columns["madausach"].ColumnName = "Mã đầu sách";
                result.Columns["matuasach"].ColumnName = "Mã tựa sách";
            }
            return result;
        }

        public DataTable timCuonSach(CUONSACH cs, int type)
        {
            DataTable result = new DataTable();
            if (type == 1) //tìm theo mã cuốn sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from CUONSACH where macuonsach = @mcs", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@mcs", cs.macuonsach);
                da.Fill(result);
            }
            else if (type == 2) //tìm theo mã đầu sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from CUONSACH where madausach = @mds", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@mds", cs.madausach);
                
                da.Fill(result);
            }
            else if (type == 3) //tìm theo mã tựa sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from CUONSACH cs join DAUSACH ds on cs.madausach = ds.madausach where ds.matuasach = @mts", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@mts", cs.madausach);//thuộc tính madausach chứa mã tựa sách
                da.Fill(result);
                result.Columns.Remove("madausach1");
                result.Columns.Remove("tinhtrang1");
                result.Columns["madausach"].ColumnName = "Mã đầu sách";
                result.Columns["macuonsach"].ColumnName = "Mã cuốn sách";
                result.Columns["matuasach"].ColumnName = "Mã tựa sách";
            }
            
            return result;
        }

        public DataTable timTheoTen(string ten, int type)
        {
            DataTable result = new DataTable();
            if (type == 1) //tìm đầu sách theo tên tựa sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from DAUSACH ds join TUASACH ts on ds.matuasach = ts.matuasach where ts.tentuasach = @ten", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@ten", ten);
                da.Fill(result);
                result.Columns.Remove("matuasach1");
                result.Columns["madausach"].ColumnName = "Mã đầu sách";
                result.Columns["matuasach"].ColumnName = "Mã tựa sách";
            }
            else if (type == 2) //tìm cuốn sách theo tên tựa sách
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from (CUONSACH cs join DAUSACH ds on cs.madausach = ds.madausach) join TUASACH ts on ds.matuasach = ts.matuasach where ts.tentuasach = @ten", DataProvider.con);
                da.SelectCommand.Parameters.AddWithValue("@ten", ten);
                da.Fill(result);
                result.Columns.Remove("matuasach1");
                result.Columns.Remove("madausach1");
                result.Columns.Remove("tinhtrang1");
                result.Columns["madausach"].ColumnName = "Mã đầu sách";
                result.Columns["macuonsach"].ColumnName = "Mã cuốn sách";
                result.Columns["matuasach"].ColumnName = "Mã tựa sách";

            }
            return result;
        }
    }
}
