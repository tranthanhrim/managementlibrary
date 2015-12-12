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
    public partial class NgonNgu : Form
    {
        public NgonNgu()
        {
            InitializeComponent();
        }


        CTL.NgonNgu data = new CTL.NgonNgu();


        private void NgonNgu_Load(object sender, EventArgs e)
        {
            dgvngonngu.DataSource = data.loadNgonNgu();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtngonngu.Text))
                return;
            NGONNGU inf = new NGONNGU();
            inf.ngonngu1 = txtngonngu.Text;
            data.themNgonNgu(inf);
            txtngonngu.Clear();
            MessageBox.Show("Đã thêm!");
            dgvngonngu.DataSource = data.loadNgonNgu();          
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            NGONNGU inf = new NGONNGU();
            inf.ngonngu1 = dgvngonngu.SelectedRows[0].Cells[0].Value.ToString();
            data.xoaNgonNgu(inf);
            dgvngonngu.DataSource = data.loadNgonNgu();
            MessageBox.Show("Đã xóa!");
        }
    }
}
