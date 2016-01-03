using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managament_Library_v2._0
{
    public partial class XuatDuLieu : Form
    {
        public XuatDuLieu()
        {
            InitializeComponent();
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {

        }

        private void cbxdocgia_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = (CheckBox)sender;
            if (temp.Checked == true)
            {
                //MessageBox.Show("Dữ liệu quan trọng! Bạn có muốn thực sự muốn xuất")
                DialogResult xuat = MessageBox.Show("Dữ liệu quan trọng! Bạn có thực sự muốn xuất dữ liệu này?", "Exit", MessageBoxButtons.YesNo);
                if (xuat == DialogResult.No || xuat == DialogResult.Cancel)
                    temp.Checked = false;
            }
        }
    }
}
