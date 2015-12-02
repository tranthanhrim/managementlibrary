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

        DocGiaCTL data = new DocGiaCTL();
        
        public static String mdg = String.Empty;
        private void SuaDocGia_Load(object sender, EventArgs e)
        {
            DataTable dtDocGia = new DataTable();
            DataTable dtHocSinh = new DataTable();
            DataTable dtNhanVien = new DataTable();
            DocGiaDTO dg = new DocGiaDTO();
            HocSinhDTO hs = new HocSinhDTO();
            NhanVienDTO nv = new NhanVienDTO();
            dg.MaDocGia = mdg;
            hs.MaDocGia = mdg;
            nv.MaDocGia = mdg;

            dtDocGia = data.timDocGia(dg, 1);
            dtHocSinh = data.timHocSinh(hs, 1);
            dtNhanVien = data.timNhanVien(nv);

            txtmdg.Text = dtDocGia.Rows[0]["madocgia"].ToString();
            txtten.Text = dtDocGia.Rows[0]["hoten"].ToString();
            if (cbxgioitinh.Items[0].ToString() == dtDocGia.Rows[0]["gioitinh"].ToString())
            {
                cbxgioitinh.SelectedIndex = 0;
            }
            else if (cbxgioitinh.Items[1].ToString() == dtDocGia.Rows[0]["gioitinh"].ToString())
            {
                cbxgioitinh.SelectedIndex = 1;
            }
            else
            {
                cbxgioitinh.SelectedIndex = 2;
            }
            dngaysinh.Value = (DateTime)dtDocGia.Rows[0]["ngaysinh"];
            dngaylap.Value = (DateTime)dtDocGia.Rows[0]["ngaylap"];

            if (dtHocSinh.Rows.Count > 0)
            {
                lbllop.Enabled = true;
                txtlop.Enabled = true;
                txtlop.Text = dtHocSinh.Rows[0]["lop"].ToString();
            }
            else if (dtNhanVien.Rows.Count > 0)
            {
                lbllop.Enabled = false;
                txtlop.Enabled = false;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            DocGiaDTO dg = new DocGiaDTO();
            HocSinhDTO hs;

            if (lbllop.Enabled == true)
            {
                hs = new HocSinhDTO();
                hs.MaDocGia = txtmdg.Text;
                hs.Lop = txtlop.Text;
                data.suaHocSinh(hs);
            }

            dg.MaDocGia = txtmdg.Text;
            dg.HoTen = txtten.Text;
            dg.GioiTinh = cbxgioitinh.SelectedItem.ToString();
            dg.NgaySinh = dngaysinh.Value.Date;
            dg.NgayLap = dngaylap.Value.Date;
            data.suaDocGia(dg);
            
            UpdateNotice();
            MessageBox.Show("Hoàn thành!");
            Close();
        }
    }
}
