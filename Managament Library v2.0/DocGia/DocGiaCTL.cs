using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Managament_Library_v2._0
{
    public class DocGiaCTL
    {
        DocGiaDAO data = new DocGiaDAO();

        public DataTable loadDocGia()
        {
            return data.loadDocGia();
        }

        public void themDocGia(DocGiaDTO dg)
        {
            data.themDocGia(dg);
        }

        public void suaDocGia(DocGiaDTO dg)
        {
            data.suaDocGia(dg);
        }

        public void xoaDocGia(DocGiaDTO dg)
        {
            data.xoaDocGia(dg);
        }

        public DataTable timDocGia(DocGiaDTO dg, int type)
        {
            return data.timDocGia(dg, type);
        }

        public DataTable loadHocSinh()
        {
            return data.loadHocSinh();
        }

        public void themHocSinh(HocSinhDTO dg)
        {
            data.themHocSinh(dg);
        }

        public void suaHocSinh(HocSinhDTO dg)
        {
            data.suaHocSinh(dg);
        }

        public void xoaHocSinh(HocSinhDTO dg)
        {
            data.xoaHocSinh(dg);
        }

        public DataTable timHocSinh(HocSinhDTO dg, int type)
        {
            return data.timHocSinh(dg, type);
        }

        public DataTable loadNhanVien()
        {
            return data.loadNhanVien();
        }

        public void themNhanVien(NhanVienDTO dg)
        {
            data.themNhanVien(dg);
        }

        public void suaNhanVien(NhanVienDTO dg)
        {
            data.suaNhanVien(dg);
        }

        public void xoaNhanVien(NhanVienDTO dg)
        {
            data.xoaNhanVien(dg);
        }

        public DataTable timNhanVien(NhanVienDTO dg)
        {
            return data.timNhanVien(dg);
        }
    }
}
