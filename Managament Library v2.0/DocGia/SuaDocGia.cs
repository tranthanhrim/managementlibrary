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
        
        public static string mdg = String.Empty;
        private void SuaDocGia_Load(object sender, EventArgs e)
        {

            DOCGIA dg = data.timDocGia(mdg);
            HOCSINH hs = data.timHocSinh(mdg);
            NHANVIEN nv = data.timNhanVien(mdg);

            txtmdg.Text = dg.madocgia;
            txtten.Text = dg.hoten;

            if (dg.tinhtrang == true)
                cbtinhtrang.Checked = true;
            else
                cbtinhtrang.Checked = false;

            String[] gioitinh = { "Nam", "Nữ", "Khác" };

            ComboboxItem item;
            for (int i = 0; i < gioitinh.Count(); i++)
            {
                item = new ComboboxItem();
                item.Text = gioitinh[i];
                item.Value = gioitinh[i];
                cbxgioitinh.Items.Add(item);
            }

            CTL.Lop dataLop = new CTL.Lop();
            DataTable dtLop = dataLop.loadLop();
            for (int i = 0; i < dtLop.Rows.Count; i++)
            {
                item = new ComboboxItem();
                item.Text = dtLop.Rows[i]["Lớp"].ToString();
                item.Value = dtLop.Rows[i]["Lớp"].ToString();
                cbxlop.Items.Add(item);
            }


            for (int i = 0; i < cbxgioitinh.Items.Count; i++)
            {
                if (cbxgioitinh.Items[i].ToString() == dg.gioitinh)
                {
                    cbxgioitinh.SelectedIndex = i;
                    break;
                }
            }
            
            dngaysinh.Value = (DateTime)dg.ngaysinh;
            dngaylap.Value = (DateTime)dg.ngaylap;

            if (hs != null)
            {
                lbllop.Enabled = true;
                cbxlop.Enabled = true;
                for (int i = 0; i < cbxlop.Items.Count; i++)
                {
                    if (hs.lop == (cbxlop.Items[i] as ComboboxItem).Value.ToString())
                    {
                        cbxlop.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (nv != null)
            {
                lbllop.Enabled = false;
                cbxlop.Enabled = false;
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
                    if (cbxlop.SelectedItem != null)
                        hs.lop = (cbxlop.SelectedItem as ComboboxItem).Value.ToString();
                    data.suaHocSinh(hs);
                }

                dg.madocgia = txtmdg.Text;
                dg.hoten = txtten.Text;
                dg.gioitinh = (cbxgioitinh.SelectedItem as ComboboxItem).Value.ToString();
                dg.ngaysinh = dngaysinh.Value.Date;
                dg.ngaylap = dngaylap.Value.Date;
                if (cbtinhtrang.Checked == true)
                    dg.tinhtrang = true;
                else
                    dg.tinhtrang = false;
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
