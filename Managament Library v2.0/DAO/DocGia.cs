using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managament_Library_v2._0.EF;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Managament_Library_v2._0.DAO
{
    public class DocGia
    {
        LibraryDataContext data = new LibraryDataContext();
        public DataTable loadDocGia()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from DOCGIA", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madocgia"].ColumnName = "Mã độc giả";
            dt.Columns["hoten"].ColumnName = "Họ tên";
            dt.Columns["gioitinh"].ColumnName = "Giới tính";
            dt.Columns["ngaysinh"].ColumnName = "Ngày sinh";
            dt.Columns["ngaylap"].ColumnName = "Ngày lập";
            dt.Columns["tinhtrang"].ColumnName = "Tình trạng";
            return dt;
        }

        public DataTable loadHocSinh()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from HOCSINH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madocgia"].ColumnName = "Mã độc giả";
            dt.Columns["lop"].ColumnName = "Lớp";
            return dt;
        }

        public DataTable loadNhanVien()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from NHANVIEN", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madocgia"].ColumnName = "Mã độc giả";
            return dt;
        }

        public void themDocGia(DOCGIA dg)
        {
            data.DOCGIAs.Add(dg);
            data.SaveChanges();
        }

        public void themHocSinh(HOCSINH hs)
        {
            data.HOCSINHs.Add(hs);
            data.SaveChanges();
        }

        public void themNhanVien(NHANVIEN nv)
        {
            data.NHANVIENs.Add(nv);
            data.SaveChanges();
        }

        public void suaDocGia(DOCGIA dg)
        {
            //data.DOCGIAs.Attach(dg);
            //data.Entry(dg).State = EntityState.Modified;
            //data.SaveChanges();
            var temp = data.DOCGIAs.Find(dg.madocgia);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(dg);
                data.SaveChanges();
            }
        }

        public void suaHocSinh(HOCSINH hs)
        {
            var temp = data.HOCSINHs.Find(hs.madocgia);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(hs);
                data.SaveChanges();
            }
        }

        public void suaNhanVien(NHANVIEN nv)
        {
            //nothing to do
        }

        public void xoaDocGia(string madocgia)
        {
            /*var temp = data.DOCGIAs.Find(dg.madocgia);

            if (temp != null)
            {
                data.DOCGIAs.Remove(temp);
                data.SaveChanges();
            }*/
            data.Database.ExecuteSqlCommand("delete from DOCGIA where madocgia = '"+madocgia+"'");
        }

        public void xoaHocSinh(string madocgia)
        {
            /*var temp = data.HOCSINHs.Find(hs.madocgia);

            if (temp != null)
            {
                data.HOCSINHs.Remove(temp);
                data.SaveChanges();
            }*/
            data.Database.ExecuteSqlCommand("delete from HOCSINH where madocgia = '" + madocgia + "'");
        }

        public void xoaNhanVien(string madocgia)
        {
            /*var temp = data.NHANVIENs.Find(nv.madocgia);

            if (temp != null)
            {
                data.NHANVIENs.Remove(temp);
                data.SaveChanges();
            }*/
            data.Database.ExecuteSqlCommand("delete from NHANVIEN where madocgia = '" + madocgia + "'");
        }

        public void xoaTatCa()
        {
            data.Database.ExecuteSqlCommand("delete from DOCGIA");
            data.Database.ExecuteSqlCommand("delete from NHANVIEN");
            data.Database.ExecuteSqlCommand("delete from HOCSINH");          
            data.SaveChanges();
        }

        //public DOCGIA timDocGia(DOCGIA dg)
        //{
        //    return data.DOCGIAs.Find(dg.madocgia);
        //}

        //public HOCSINH timHocSinh(HOCSINH hs)
        //{
        //    return data.HOCSINHs.Find(hs.madocgia);
        //}

        //public NHANVIEN timNhanVien(NHANVIEN nv)
        //{
        //    return data.NHANVIENs.Find(nv.madocgia);
        //}
        public DOCGIA timDocGia(string madocgia)
        {
            return data.DOCGIAs.Find(madocgia);
        }

        public HOCSINH timHocSinh(string madocgia)
        {
            return data.HOCSINHs.Find(madocgia);
        }

        public NHANVIEN timNhanVien(string madocgia)
        {
            return data.NHANVIENs.Find(madocgia);
        }

        public DataTable timDocGia(DOCGIA dg, int type)
        {
            if (type == 1) //tìm theo mã độc giả
            {
                string sql = "select* from DOCGIA dg left join HOCSINH hs on dg.madocgia = hs.madocgia where dg.madocgia = '" + dg.madocgia + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Remove("madocgia1");
                return dt;
            }
            else//tìm theo tên
            {
                string sql = "select* from DOCGIA dg left join HOCSINH hs on dg.madocgia = hs.madocgia where dg.hoten = '" + dg.hoten + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Remove("madocgia1");
                return dt;
            }           
        }

        public DataTable timHocSinh(HOCSINH hs, int type = 1)
        {
            string sql = "select* from DOCGIA dg left join HOCSINH hs on dg.madocgia = hs.madocgia where hs.lop = '" + hs.lop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Remove("madocgia1");
            return dt;
        }

        public DataTable timNhanVien(NHANVIEN nv, int type = 1)
        {
            string sql = "select* from NHANVIEN where madocgia = '" + nv.madocgia + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
