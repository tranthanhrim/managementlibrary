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
    }
}
