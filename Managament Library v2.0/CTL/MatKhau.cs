using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.DAO;

namespace Managament_Library_v2._0.CTL
{
    public class MatKhau
    {
        DAO.MatKhau data = new DAO.MatKhau();
        public void suaMatKhau(MATKHAU bef, MATKHAU aft)
        {
            data.suaMatKhau(bef, aft);
        }

        public string layMatKhau()
        {
            return data.layMatKhau();
        }

        public bool canDangNhap()
        {
            return data.canDangNhap();
        }

        public MATKHAU tim(MATKHAU inf)
        {
            return data.tim(inf);
        }
    }
}
