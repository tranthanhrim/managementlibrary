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
    public partial class Lop : Form
    {
        CTL.Lop data = new CTL.Lop();
        public Lop()
        {
            InitializeComponent();
        }

        private void Lop_Load(object sender, EventArgs e)
        {
            dgvlop.DataSource = data.loadLop();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtlop.Text))
                return;
            LOP inf = new LOP();
            inf.lop1 = txtlop.Text;
            data.themLop(inf);
            txtlop.Clear();
            MessageBox.Show("Đã thêm!");
            dgvlop.DataSource = data.loadLop();         
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            LOP inf = new LOP();
            inf.lop1 = dgvlop.SelectedRows[0].Cells[0].Value.ToString();
            data.xoaLop(inf);           
            MessageBox.Show("Đã xóa!");
            dgvlop.DataSource = data.loadLop();
        }
    }
}
