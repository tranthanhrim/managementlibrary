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
        NHANVIEN nv;

        DocGia data = new DocGia();

        private void btnmdg_Click(object sender, EventArgs e)
        {          
            dg = new DOCGIA();
            dg.madocgia = txtmdg.Text;
            DataTable dtDocGia = new DataTable();
            dtDocGia = data.timDocGia(dg, 1);
            dgvdocgia.DataSource = dtDocGia;
        }

        private void btnten_Click(object sender, EventArgs e)
        {
            dg = new DOCGIA();
            dg.hoten = txtten.Text;

            DataTable dtDocGia = new DataTable();
            

            dtDocGia = data.timDocGia(dg, 2);//tìm độc giả theo tên

            dgvdocgia.DataSource = dtDocGia;
        }

        private void btnlop_Click(object sender, EventArgs e)
        {
            hs = new HOCSINH();
            hs.lop = txtlop.Text;

            DataTable dtDocGia = new DataTable();

            dtDocGia = data.timHocSinh(hs, 1);
            dgvdocgia.DataSource = dtDocGia;
        }
    }
}
