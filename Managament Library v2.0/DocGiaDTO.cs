using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managament_Library_v2._0
{
    public class DocGiaDTO
    {
        string _madocgia;
        string _hoten;
        string _gioitinh;
        DateTime _ngaysinh;
        DateTime _ngaylap;
        bool _tinhtrang;

        public string MaDocGia
        {
            get { return _madocgia; }
            set { _madocgia = value; }
        }

        public string HoTen
        {
            get { return _hoten; }
            set { _hoten = value; }
        }

        public string GioiTinh
        {
            get { return _gioitinh; }
            set { _gioitinh = value; }
        }

        public DateTime NgaySinh
        {
            get { return _ngaysinh; }
            set { _ngaysinh = value; }
        }

        public DateTime NgayLap
        {
            get { return _ngaylap; }
            set { _ngaylap = value; }
        }

        public bool TinhTrang
        {
            get { return _tinhtrang; }
            set { _tinhtrang = value; }
        }
    }

    public class HocSinhDTO
    {
        string _madocgia;
        string _lop;

        public string MaDocGia
        {
            get { return _madocgia; }
            set { _madocgia = value; }
        }

        public string Lop
        {
            get { return _lop; }
            set { _lop = value; }
        }
    }

    public class NhanVienDTO
    {
        string _madocgia;

        public string MaDocGia
        {
            get { return _madocgia; }
            set { _madocgia = value; }
        }
    }

}
