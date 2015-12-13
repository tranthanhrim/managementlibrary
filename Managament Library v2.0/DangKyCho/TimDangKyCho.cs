using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.CTL;

namespace Managament_Library_v2._0
{
    public partial class TimDangKyCho : Form
    {
        public TimDangKyCho()
        {
            InitializeComponent();
        }

        DangKyCho data = new DangKyCho();

        private void btntim_Click(object sender, EventArgs e)
        {
            if (rbmdg.Checked == true)
            {
                DKCHOMUON inf = new DKCHOMUON();
                inf.madocgia = txtmdg.Text;
                dgvdkcho.DataSource = data.timDangKyCho(inf, 1);
            }
            else if (rbmadausach.Checked == true)
            {
                DKCHOMUON inf = new DKCHOMUON();
                inf.madausach = txtmds.Text;
                dgvdkcho.DataSource = data.timDangKyCho(inf, 2);
            }
            else if (rbngaydk.Checked == true)
            {
                DKCHOMUON inf = new DKCHOMUON();
                inf.ngaygiodk = dtngaygiodk.Value.Date;
                dgvdkcho.DataSource = data.timDangKyCho(inf, 3);
            }
        }
    }
}
