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

        public int themMuonTraSach(MUONSACH inf)
        {
            DataTable phieuMuon = timMuonTraSach(inf, 1);
            int chuaTra = 0;
            for (int i = 0; i < phieuMuon.Rows.Count; i++)
            {
                if (phieuMuon.Rows[i]["ngaygiotra"].ToString() == String.Empty)
                    chuaTra++;
            }

            THAMSO sosachmuon = new THAMSO();
            THAMSO songaymuon = new THAMSO();
            for (int i = 0; i < Form1.thamSo.Count; i++)
            {
                if (Form1.thamSo[i].tenthamso == "sosachmuon")
                {
                    sosachmuon = Form1.thamSo[i];
                    break;
                }
            }

            for (int i = 0; i < Form1.thamSo.Count; i++)
            {
                if (Form1.thamSo[i].tenthamso == "songaymuon")
                {
                    songaymuon = Form1.thamSo[i];
                    break;
                }
            }

            if (sosachmuon.tinhtrang == true)
            {
                if (chuaTra > Convert.ToInt32(sosachmuon.giatri))
                {
                    return 0;
                }
            }

            inf.ngayhethan = inf.ngaygiomuon.AddDays(Convert.ToInt32(songaymuon.giatri));
            data.MUONSACHes.Add(inf);
            data.SaveChanges();
            return 1;
        }

        public void suaMuonTraSach(MUONSACH before, MUONSACH after)
        {
            /*var temp = data.MUONSACHes.Find(before.madocgia, before.macuonsach, before.ngaygiomuon);
            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(after);
                data.SaveChanges();
            }*/
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "update MUONSACH set madocgia = @mdg, macuonsach = @sach, ngaygiomuon = @muon, ngayhethan = @han, ngaygiotra = @tra where madocgia = @mdg1 and macuonsach = @sach1 and ngaygiomuon = @muon1";
            sql.CommandType = CommandType.Text;
            sql.Parameters.AddWithValue("@mdg", after.madocgia);
            sql.Parameters.AddWithValue("@sach", after.macuonsach);
            sql.Parameters.AddWithValue("@muon", after.ngaygiomuon);
            sql.Parameters.AddWithValue("@han", after.ngayhethan);
            
            if (after.ngaygiotra != null)
                sql.Parameters.AddWithValue("@tra", after.ngaygiotra);
            else
            {
                sql.Parameters.AddWithValue("@tra", DBNull.Value);
            }
            
            sql.Parameters.AddWithValue("@mdg1", before.madocgia);
            sql.Parameters.AddWithValue("@sach1", before.macuonsach);
            sql.Parameters.AddWithValue("@muon1", before.ngaygiomuon);
            sql.Connection = DataProvider.con;
            sql.ExecuteNonQuery();
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

        /*public DataTable thongKeDauSachMuonNhieu()
        {
            string sql = "select* from (MUONSACH ms join CUONSACH cs on ms.macuonsach = cs.macuonsach) join DAUSACH ds on cs.madausach = ds.madausach"
        }*/
    }
}
