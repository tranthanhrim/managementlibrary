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
    public partial class TimDocGia : Form
    {
        public TimDocGia()
        {
            InitializeComponent();
        }

        DocGiaCTL data = new DocGiaCTL();
        DocGiaDTO dg;
        HocSinhDTO hs;
        NhanVienDTO nv;

        private void btnmdg_Click(object sender, EventArgs e)
        {          
            dg = new DocGiaDTO();
            hs = new HocSinhDTO();
            dg.MaDocGia = txtmdg.Text;
            hs.MaDocGia = txtmdg.Text;

            DataTable dtDocGia = new DataTable();
            DataTable dtHocSinh = new DataTable();

            dtDocGia = data.timDocGia(dg, 1);
            dtHocSinh = data.timHocSinh(hs, 1);

            //ghép cột lớp vào bảng Độc giả tìm được
            dtDocGia.Columns.Add("lop");
            if (dtHocSinh.Rows.Count != 0)
                dtDocGia.Rows[0]["lop"] = dtHocSinh.Rows[0]["lop"];

            dgvdocgia.DataSource = dtDocGia;
        }

        private void btnten_Click(object sender, EventArgs e)
        {
            dg = new DocGiaDTO();
            dg.HoTen = txtten.Text;

            DataTable dtDocGia = new DataTable();
            DataTable dtHocSinh;

            dtDocGia = data.timDocGia(dg, 2);//tìm độc giả theo tên
            dtDocGia.Columns.Add("lop");

            for (int i = 0; i < dtDocGia.Rows.Count; i++)//tra cứu lớp đối với mỗi độc giả tìm được
            {
                hs = new HocSinhDTO();
                hs.MaDocGia = dtDocGia.Rows[i]["madocgia"].ToString();
                dtHocSinh = new DataTable();
                dtHocSinh = data.timHocSinh(hs, 1);
                if (dtHocSinh.Rows.Count != 0)
                    dtDocGia.Rows[i]["lop"] = dtHocSinh.Rows[0]["lop"];
                else
                    dtDocGia.Rows[i]["lop"] = "null";//độc giả không thuộc lớp nào
            }

            dgvdocgia.DataSource = dtDocGia;
        }

        private void btnlop_Click(object sender, EventArgs e)
        {
            hs = new HocSinhDTO();
            hs.Lop = txtlop.Text;

            DataTable dtDocGia = new DataTable();
            DataTable temp;
            DataTable dtHocSinh = new DataTable();

            dtHocSinh = data.timHocSinh(hs, 2);//tìm mã độc giả theo lớp

            for (int i = 0; i < dtHocSinh.Rows.Count; i++)//tìm thông tin độc giả dựa trên mã độc giả tìm được
            {
                dg = new DocGiaDTO();
                dg.MaDocGia = dtHocSinh.Rows[i]["madocgia"].ToString();
                temp = new DataTable();
                temp = data.timDocGia(dg, 1);
                dtDocGia.Merge(temp);
            }
            dgvdocgia.DataSource = dtDocGia;
        }
    }
}
