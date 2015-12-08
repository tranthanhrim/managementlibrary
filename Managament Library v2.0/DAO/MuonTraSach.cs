using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managament_Library_v2._0.EF;
using System.Data;
using System.Data.SqlClient;

namespace Managament_Library_v2._0.DAO
{
    public class MuonTraSach
    {
        LibraryDataContext data = new LibraryDataContext();
        public DataTable loadMuonTraSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from MUONSACH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madocgia"].ColumnName = "Mã độc giả";
            dt.Columns["macuonsach"].ColumnName = "Mã cuốn sách";
            dt.Columns["ngaygiomuon"].ColumnName = "Ngày giờ mượn";
            dt.Columns["ngayhethan"].ColumnName = "Ngày hết hạn";
            dt.Columns["ngaygiotra"].ColumnName = "Ngày giờ trả";
            dt.DefaultView.Sort = "Mã độc giả";
            return dt;
        }

        public void themMuonTraSach(MUONSACH inf)
        {
            data.MUONSACHes.Add(inf);
            data.SaveChanges();
        }

        public void suaMuonTraSach(MUONSACH before, MUONSACH after)
        {
            var temp = data.MUONSACHes.Find(before.madocgia, before.macuonsach, before.ngaygiomuon);
            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(after);
                data.SaveChanges();
            }
        }

        public void xoaMuonTraSach(MUONSACH inf)
        {
            data.MUONSACHes.Remove(inf);
            data.SaveChanges();
        }

        public MUONSACH timMuonTraSach(MUONSACH inf)
        {
            return data.MUONSACHes.Find(inf.madocgia, inf.macuonsach, inf.ngaygiomuon);
        }

        public DataTable timMuonTraSach(MUONSACH inf, int type)
        {
            if (type == 1)
            {
                string sql = "select* from MUONSACH where madocgia = '"+ inf.madocgia +"'";
                SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            else
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }
    }
}
