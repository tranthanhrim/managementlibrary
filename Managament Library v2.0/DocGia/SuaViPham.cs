using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.CTL;

namespace Managament_Library_v2._0
{
    public partial class SuaViPham : Form
    {
        public static string madocgia = String.Empty;
        ViPham data = new ViPham();
        public SuaViPham()
        {
            InitializeComponent();
        }

        public delegate void OnUpdateHandler();
        public event OnUpdateHandler OnUpdate;

        void noticeUpdate()
        {
            if (OnUpdate != null)
                OnUpdate();
        }

        private void SuaViPham_Load(object sender, EventArgs e)
        {
            VIPHAM vp = new VIPHAM();
            vp.madocgia = madocgia;
            vp = data.timViPham(vp);
            txtmdg.Text = vp.madocgia;
            txtvipham.Text = vp.vipham1.ToString();
            if (vp.ngayhethan != null)
                dtngayhethan.Value = (DateTime)vp.ngayhethan;
            else
                dtngayhethan.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                VIPHAM vp = new VIPHAM();
                vp.madocgia = txtmdg.Text;
                vp.vipham1 = Convert.ToInt32(txtvipham.Text);
                if (dtngayhethan.Enabled == true)
                    vp.ngayhethan = dtngayhethan.Value.Date;
                data.suaViPham(vp);
                noticeUpdate();
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Can not update!");
            }
            
        }
    }
}
