using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Managament_Library_v2._0.CTL;
using Managament_Library_v2._0.EF;

namespace Managament_Library_v2._0
{
    public partial class TimThemMuonSach : Form
    {
        public TimThemMuonSach()
        {
            InitializeComponent();
        }

        MuonTraSach dataMuon = new MuonTraSach();

        private void btntim_Click(object sender, EventArgs e)
        {
            if (rbmdg.Checked == true)
            {
                MUONSACH ms = new MUONSACH();
                ms.madocgia = txtmdg.Text;
                dgvmuonsach.DataSource = dataMuon.timMuonTraSach(ms, 1);
            }
            else if (rbmacuonsach.Checked == true)
            {
                MUONSACH ms = new MUONSACH();
                ms.macuonsach = txtmcs.Text;
                dgvmuonsach.DataSource = dataMuon.timMuonTraSach(ms, 2);
            }
            else if (rbngaymuon.Checked == true)
            {
                MUONSACH ms = new MUONSACH();
                ms.ngaygiomuon = dtngaygiomuon.Value.Date;
                dgvmuonsach.DataSource = dataMuon.timMuonTraSach(ms, 3);
            }
        }
    }
}
