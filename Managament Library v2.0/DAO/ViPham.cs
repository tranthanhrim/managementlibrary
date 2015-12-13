using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Managament_Library_v2._0.EF;

namespace Managament_Library_v2._0.DAO
{
    public class ViPham
    {
        LibraryDataContext data = new LibraryDataContext();
        public DataTable loadViPham()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from VIPHAM", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madocgia"].ColumnName = "Mã độc giả";
            dt.Columns["vipham"].ColumnName = "Số lần vi phạm";
            dt.Columns["ngayhethan"].ColumnName = "Ngày hết hạn phạt";
            return dt;
        }

        public void themViPham(VIPHAM inf)
        {
            data.VIPHAMs.Add(inf);
            data.SaveChanges();
        }

        public void suaViPham(VIPHAM inf)
        {
            var temp = data.VIPHAMs.Find(inf.madocgia);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(inf);
                data.SaveChanges();
            }
        }

        public VIPHAM timViPham(VIPHAM inf)
        {
            return data.VIPHAMs.Find(inf.madocgia);
        }

        public DataTable timViPham(string mdg)
        {
            SqlDataAdapter da = new SqlDataAdapter("select* from VIPHAM where madocgia = '" + mdg + "'", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
