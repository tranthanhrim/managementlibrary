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
using Managament_Library_v2._0.DAO;
using Managament_Library_v2._0.EF;

namespace Managament_Library_v2._0
{
    public partial class ThemDocGia : Form
    {
        public ThemDocGia()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        DocGia data = new DocGia();
        ViPham dataViPham = new ViPham();
        DOCGIA dg;
        HOCSINH hs;
        NHANVIEN nv;
        
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
                    dg = new DOCGIA();
                    dg.madocgia = txtmdg.Text;
                    dg.hoten = txtten.Text;
                    dg.gioitinh = cbxgioitinh.SelectedItem.ToString();
                    dg.ngaysinh = dngaysinh.Value.Date;
                    dg.ngaylap = dngaylap.Value.Date;
                    dg.tinhtrang = true;
                    data.themDocGia(dg);

                    VIPHAM vp = new VIPHAM();
                    vp.madocgia = txtmdg.Text;
                    vp.vipham1 = 0;
                    dataViPham.themViPham(vp);

                    if (rbhocsinh.Checked == true)
                    {
                        hs = new HOCSINH();
                        hs.madocgia = txtmdg.Text;
                        hs.lop = txtlop.Text;
                        data.themHocSinh(hs);
                    }
                    else if (rbnhanvien.Checked == true)
                    {
                        nv = new NHANVIEN();
                        nv.madocgia = txtmdg.Text;
                        data.themNhanVien(nv);
                    }

                    MessageBox.Show("Hoàn tất!");
                    Close();
                    addNotice();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Sai định dạng!");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Có giá trị rỗng!");
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
