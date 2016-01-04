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
    public partial class TimDocGia : Form
    {
        public TimDocGia()
        {
            InitializeComponent();
        }

        DOCGIA dg;
        HOCSINH hs;

        DocGia data = new DocGia();


        private void btntim_Click(object sender, EventArgs e)
        {
            if (rbmdg.Checked == true)
            {
                dg = new DOCGIA();
                dg.madocgia = txtmdg.Text;
                DataTable dtDocGia = new DataTable();
                dtDocGia = data.timDocGia(dg, 1);
                dgvdocgia.DataSource = dtDocGia;
            }
            else if (rblop.Checked == true)
            {
                hs = new HOCSINH();
                hs.lop = txtlop.Text;

                DataTable dtDocGia = new DataTable();

                dtDocGia = data.timHocSinh(hs, 1);
                dgvdocgia.DataSource = dtDocGia;
            }
            else if (rbten.Checked == true)
            {
                dg = new DOCGIA();
                dg.hoten = txtten.Text;

                DataTable dtDocGia = new DataTable();

                dtDocGia = data.timDocGia(dg, 2);//tìm độc giả theo tên

                dgvdocgia.DataSource = dtDocGia;
            }
        }

        private void btntim_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TimDocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btntim_Click(null, null);
            }
        }

        private void txtmdg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void rblop_CheckedChanged(object sender, EventArgs e)
        {
            txtlop.Select();
        }

        private void rbmdg_CheckedChanged(object sender, EventArgs e)
        {
            txtmdg.Select();
        }

        private void rbten_CheckedChanged(object sender, EventArgs e)
        {
            txtten.Select();
        }

    }
}
