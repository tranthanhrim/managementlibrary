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
    public partial class SuaMatKhau : Form
    {
        public SuaMatKhau()
        {
            InitializeComponent();
        }

        MatKhau dataMatKhau = new MatKhau();
        
        private void btnluu_Click(object sender, EventArgs e)
        {
            string matkhaucu = dataMatKhau.layMatKhau();
            if (txtmatkhaucu.Text != matkhaucu)
            {
                MessageBox.Show("Sai mật khẩu cũ!");
                return;
            }

            if (txtmkmoi.Text != txtmkmoi2.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp nhau!");
                return;
            }

            MATKHAU mkcu = new MATKHAU();
            mkcu.matkhau1 = txtmatkhaucu.Text;

            MATKHAU mkmoi = new MATKHAU();
            mkmoi.matkhau1 = txtmatkhaucu.Text;
            mkmoi = dataMatKhau.tim(mkmoi);
            mkmoi.matkhau1 = txtmkmoi.Text;


            dataMatKhau.suaMatKhau(mkcu, mkmoi);
            MessageBox.Show("Đã luu!");
            Close();
        }
    }
}
