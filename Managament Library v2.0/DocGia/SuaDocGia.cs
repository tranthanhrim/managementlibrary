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
    public partial class SuaDocGia : Form
    {
        public SuaDocGia()
        {
            InitializeComponent();
        }

        public delegate void OnUpdateHandler();
        public event OnUpdateHandler OnUpdate;

        void UpdateNotice()
        {
            if (OnUpdate != null)
                OnUpdate();
        }

        DocGia data = new DocGia();
        
        public static String mdg = String.Empty;
        private void SuaDocGia_Load(object sender, EventArgs e)
        {
            DOCGIA temp1 = new DOCGIA();
            HOCSINH temp2 = new HOCSINH();
            NHANVIEN temp3 = new NHANVIEN();

            temp1.madocgia = mdg;
            temp2.madocgia = mdg;
            temp3.madocgia = mdg;

            DOCGIA dg = data.timDocGia(temp1);
            HOCSINH hs = data.timHocSinh(temp2);
            NHANVIEN nv = data.timNhanVien(temp3);



            txtmdg.Text = dg.madocgia;
            txtten.Text = dg.hoten;

            if (dg.tinhtrang == true)
                cbtinhtrang.Checked = true;
            else
                cbtinhtrang.Checked = false;

            for (int i = 0; i < cbxgioitinh.Items.Count; i++)
            {
                if (cbxgioitinh.Items[i].ToString() == dg.gioitinh)
                {
                    cbxgioitinh.SelectedIndex = i;
                    return;
                }
            }
            
            dngaysinh.Value = (DateTime)dg.ngaysinh;
            dngaylap.Value = (DateTime)dg.ngaylap;

            if (hs != null)
            {
                lbllop.Enabled = true;
                txtlop.Enabled = true;
                txtlop.Text = hs.lop;
            }
            else if (nv != null)
            {
                lbllop.Enabled = false;
                txtlop.Enabled = false;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                DOCGIA dg = new DOCGIA();
                HOCSINH hs;

                if (lbllop.Enabled == true)
                {
                    hs = new HOCSINH();
                    hs.madocgia = txtmdg.Text;
                    hs.lop = txtlop.Text;
                    data.suaHocSinh(hs);
                }

                dg.madocgia = txtmdg.Text;
                dg.hoten = txtten.Text;
                dg.gioitinh = cbxgioitinh.SelectedItem.ToString();
                dg.ngaysinh = dngaysinh.Value.Date;
                dg.ngaylap = dngaylap.Value.Date;
                dg.tinhtrang = cbtinhtrang.Checked;
                data.suaDocGia(dg);

                UpdateNotice();
                MessageBox.Show("Hoàn thành!");
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input!");
            }
            
        }
    }
}
