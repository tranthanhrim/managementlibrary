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
    public partial class DangNhap : Form
    {
        CTL.MatKhau dataMatKhau = new CTL.MatKhau();

        public DangNhap()
        {
            InitializeComponent();
            bool canDangNhap = dataMatKhau.canDangNhap();
            if (canDangNhap != true)
            {               
                //Form1 mainForm = new Form1();
                //mainForm.ShowDialog();
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (txtmatkhau.Text == dataMatKhau.layMatKhau())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();              
            }
            else
            {
                MessageBox.Show("Mật khẩu sai!");
            }
        }

        private void DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btndangnhap_Click(null, null);
        }
    }
}
