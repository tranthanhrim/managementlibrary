using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managament_Library_v2._0
{
    public partial class ThemDocGia : Form
    {
        public ThemDocGia()
        {
            InitializeComponent();
        }

        DocGiaDTO dg = new DocGiaDTO();
        HocSinhDTO hs;
        NhanVienDTO nv;
        DocGiaDAO data = new DocGiaDAO();
        DataTable dt = new DataTable();

        public delegate void OnAddHandler();
        public event OnAddHandler OnAdd;

        void addNotice()
        {
            if (OnAdd != null)
                OnAdd();
        }

        private void ThemDocGia_Load(object sender, EventArgs e)
        {
            dt = data.loadDocGia();

            int mdg = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int temp = Convert.ToInt32(dt.Rows[i]["Mã độc giả"]);
                if (temp != mdg)
                {
                    break;
                }
                else
                {
                    mdg++;
                }

            }
            txtmdg.Text = mdg.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmdg.Text != "")
                {
                    int x = Convert.ToInt32(txtmdg.Text);

                    dg.MaDocGia = txtmdg.Text;
                    dg.HoTen = txtten.Text;
                    dg.GioiTinh = cbxgioitinh.SelectedItem.ToString();
                    dg.NgaySinh = dngaysinh.Value.Date;
                    dg.NgayLap = dngaylap.Value.Date;
                    dg.TinhTrang = true;
                    data.themDocGia(dg);

                    if (rbhocsinh.Checked == true)
                    {
                        hs = new HocSinhDTO();
                        hs.MaDocGia = txtmdg.Text;
                        hs.Lop = txtlop.Text;
                        data.themHocSinh(hs);
                    }
                    else if (rbnhanvien.Checked == true)
                    {
                        nv = new NhanVienDTO();
                        nv.MaDocGia = txtmdg.Text;
                        data.themNhanVien(nv);
                    }

                    MessageBox.Show("Hoàn tất!");
                    Close();
                    addNotice();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Wrong Format input!");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Null input!");
            }
        }

        private void rbhocsinh_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;
            if (temp.Checked == true)
            {
                lbllop.Enabled = true;
                txtlop.Enabled = true;
            }
        }

        private void rbnhanvien_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;
            if (temp.Checked == true)
            {
                lbllop.Enabled = false;
                txtlop.Enabled = false;
            }
        }
    }
}
