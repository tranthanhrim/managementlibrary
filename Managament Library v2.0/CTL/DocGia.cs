using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Managament_Library_v2._0.DAO;
using Managament_Library_v2._0.EF;

namespace Managament_Library_v2._0.CTL
{
    public class DocGia
    {
        DAO.DocGia data = new DAO.DocGia();

        public DataTable loadDocGia()
        {
            return data.loadDocGia();
        }

        public void themDocGia(DOCGIA dg)
        {
            data.themDocGia(dg);
        }

        public void suaDocGia(DOCGIA dg)
        {
            data.suaDocGia(dg);
        }

        public void xoaDocGia(string madocgia)
        {
            data.xoaDocGia(madocgia);
        }

        public DataTable timDocGia(DOCGIA dg, int type)
        {
            return data.timDocGia(dg, type);
        }

        public DOCGIA timDocGia(string madocgia)
        {
            return data.timDocGia(madocgia);
        }


        public DataTable loadHocSinh()
        {
            return data.loadHocSinh();
        }

        public void themHocSinh(HOCSINH dg)
        {
            data.themHocSinh(dg);
        }

        public void suaHocSinh(HOCSINH dg)
        {
            data.suaHocSinh(dg);
        }

        public void xoaHocSinh(string madocgia)
        {
            data.xoaHocSinh(madocgia);
        }

        public void xoaTatCa()
        {
            data.xoaTatCa();
        }

        public DataTable timHocSinh(HOCSINH dg, int type)
        {
            return data.timHocSinh(dg, type);
        }

        public HOCSINH timHocSinh(string madocgia)
        {
            return data.timHocSinh(madocgia);
        }

        public DataTable loadNhanVien()
        {
            return data.loadNhanVien();
        }

        public void themNhanVien(NHANVIEN dg)
        {
            data.themNhanVien(dg);
        }

        public void suaNhanVien(NHANVIEN dg)
        {
            data.suaNhanVien(dg);
        }

        public void xoaNhanVien(string madocgia)
        {
            data.xoaNhanVien(madocgia);
        }

        public DataTable timNhanVien(NHANVIEN dg, int type)
        {
            return data.timNhanVien(dg, type);
        }

        public NHANVIEN timNhanVien(string madocgia)
        {
            return data.timNhanVien(madocgia);
        }
    }
}
