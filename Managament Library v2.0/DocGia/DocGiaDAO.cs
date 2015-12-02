using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Managament_Library_v2._0
{
    public class DocGiaDAO
    {
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

        public void themDocGia(DocGiaDTO dg)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into DOCGIA (madocgia,hoten,gioitinh,ngaysinh,ngaylap,tinhtrang) values (@mdg, @ht, @gt, @ns, @nl, @tt)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", dg.MaDocGia);
            cmd.Parameters.AddWithValue("@ht", dg.HoTen);
            cmd.Parameters.AddWithValue("@gt", dg.GioiTinh);
            cmd.Parameters.AddWithValue("@ns", dg.NgaySinh);
            cmd.Parameters.AddWithValue("@nl", dg.NgayLap);
            cmd.Parameters.AddWithValue("@tt", dg.TinhTrang);        
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public void themHocSinh(HocSinhDTO hs)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into HOCSINH (madocgia,lop) values (@mdg, @lop)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", hs.MaDocGia);
            cmd.Parameters.AddWithValue("@lop", hs.Lop);
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public void themNhanVien(NhanVienDTO nv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into NHANVIEN (madocgia) values (@mdg)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", nv.MaDocGia);
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public void suaDocGia(DocGiaDTO dg)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update DOCGIA set hoten = @ht, gioitinh = @gt, ngaysinh = @ns, ngaylap = @nl ,tinhtrang = @tt where madocgia = @mdg";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", dg.MaDocGia);
            cmd.Parameters.AddWithValue("@ht", dg.HoTen);
            cmd.Parameters.AddWithValue("@gt", dg.GioiTinh);
            cmd.Parameters.AddWithValue("@ns", dg.NgaySinh);
            cmd.Parameters.AddWithValue("@nl", dg.NgayLap);
            cmd.Parameters.AddWithValue("@tt", dg.TinhTrang);
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public void suaHocSinh(HocSinhDTO hs)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update HOCSINH set lop = @lop where madocgia = @mdg";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", hs.MaDocGia);
            cmd.Parameters.AddWithValue("@lop", hs.Lop);
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public void suaNhanVien(NhanVienDTO nv)
        {
            //nothing to do
        }

        public void xoaDocGia(DocGiaDTO dg)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from DOCGIA where madocgia = @mdg";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", dg.MaDocGia);
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public void xoaHocSinh(HocSinhDTO hs)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from HOCSINH where madocgia = @mdg";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", hs.MaDocGia);
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public void xoaNhanVien(NhanVienDTO nv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from NHANVIEN where madocgia = @mdg";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mdg", nv.MaDocGia);
            cmd.Connection = DataProvider.con;
            cmd.ExecuteNonQuery();
        }

        public DataTable timDocGia(DocGiaDTO dg, int type)
        {
            if (type == 1) //tìm theo mã độc giả
            {
                string sql = "select* from DOCGIA where madocgia = '" + dg.MaDocGia + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            else//tìm theo tên
            {
                string sql = "select* from DOCGIA where hoten = '" + dg.HoTen + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable timHocSinh(HocSinhDTO hs, int type)
        {
            if (type == 1)//tìm theo mã độc giả
            {
                string sql = "select* from HOCSINH where madocgia = '" + hs.MaDocGia + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            else//tìm theo lớp
            {
                string sql = "select* from HOCSINH where lop = '" + hs.Lop + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }      
        }

        public DataTable timNhanVien(NhanVienDTO nv)
        {
            string sql = "select* from NHANVIEN where madocgia = '" + nv.MaDocGia + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
