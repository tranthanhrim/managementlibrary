using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.CTL;

namespace Managament_Library_v2._0
{
    public partial class SuaMuonTraSach : Form
    {
        public SuaMuonTraSach()
        {
            InitializeComponent();
        }

        public delegate void OnUpdateBackBookHandler();
        public event OnUpdateBackBookHandler OnUpdateBackBook;

        void noticeUpdateBackBook()
        {
            if (OnUpdateBackBook != null)
                OnUpdateBackBook();
        }

        public static MUONSACH inf = new MUONSACH();
        MUONSACH temp;

        MuonTraSach data = new MuonTraSach();

        private void SuaMuonTraSach_Load(object sender, EventArgs e)
        {
            temp = data.timMuonTraSach(inf);
            txtmdg.Text = temp.madocgia;
            txtmacuonsach.Text = temp.macuonsach;
            dtngaygiomuon.Value = temp.ngaygiomuon;

            if (temp.ngaygiotra != null)
            {
                dtngaygiotra.Value = (DateTime)temp.ngaygiotra;
            }
            else
            {
                dtngaygiotra.Enabled = false;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                MUONSACH after = new MUONSACH();
                after.madocgia = txtmdg.Text.ToString();
                after.macuonsach = txtmacuonsach.Text.ToString();
                after.ngaygiomuon = dtngaygiomuon.Value.Date;
                after.ngayhethan = after.ngaygiomuon.AddDays(7);
                if (dtngaygiotra.Enabled == true)
                    after.ngaygiotra = dtngaygiotra.Value.Date;
                data.suaMuonTraSach(temp, after);
                noticeUpdateBackBook();
                Close();
            }
            catch(SqlException)
            {
                MessageBox.Show("Invalid input!");
            }
        }
    }
}
