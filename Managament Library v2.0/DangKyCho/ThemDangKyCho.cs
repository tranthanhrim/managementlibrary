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
    public partial class ThemDangKyCho : Form
    {
        public ThemDangKyCho()
        {
            InitializeComponent();
        }

        public delegate void OnSignHandler();
        public event OnSignHandler OnSign;

        void noticeSign()
        {
            if (OnSign != null)
                OnSign();
        }

        DangKyCho dataDangKyCho = new DangKyCho();

        private void ThemDangKyCho_Load(object sender, EventArgs e)
        {
            Sach dataSach = new Sach();
            DocGia dataDocGia = new DocGia();

            DataTable dtDocGia = dataDocGia.loadDocGia();
            DataTable dtDauSach = dataSach.loadDauSachTuaSach();

            ComboboxItem item;
            string tuaSach = String.Empty;

            for (int i = 0; i < dtDocGia.Rows.Count; i++)
            {
                if (dtDocGia.Rows[i]["Tình trạng"].ToString() != String.Empty && (bool)dtDocGia.Rows[i]["Tình trạng"] == true)//== String.Empty
                    cbxmdg.Items.Add(Convert.ToInt32(dtDocGia.Rows[i]["Mã độc giả"].ToString()));
            }

            for (int i = 0; i < dtDauSach.Rows.Count; i++)
            {
                if (dtDauSach.Rows[i]["Tình trạng"].ToString() == String.Empty || (bool)dtDauSach.Rows[i]["Tình trạng"] == false)//== String.Empty                  
                {
                    //cbxmadausach.Items.Add(Convert.ToInt32(dtDauSach.Rows[i]["Mã đầu sách"].ToString()));
                    item = new ComboboxItem();
                    item.Text = dtDauSach.Rows[i]["Mã đầu sách"].ToString() + " - " + dtDauSach.Rows[i]["Tên tựa sách"].ToString() + " - " + dtDauSach.Rows[i]["Ngôn ngữ"].ToString();
                    item.Value = Convert.ToInt32(dtDauSach.Rows[i]["Mã đầu sách"]);
                    cbxmadausach.Items.Add(item);
                }
            }

            if (cbxmadausach.Items.Count > 0)
                cbxmadausach.SelectedIndex = 0;
            else
                btnthem.Enabled = false;

            if (cbxmdg.Items.Count > 0)
                cbxmdg.SelectedIndex = 0;
            else
                btnthem.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            DKCHOMUON inf = new DKCHOMUON();
            inf.madocgia = cbxmdg.SelectedItem.ToString();
            inf.madausach = (cbxmadausach.SelectedItem as ComboboxItem).Value.ToString();
            inf.ngaygiodk = dtngaygiodk.Value.Date;
            inf.tinhtrang = false;
            dataDangKyCho.themDangKyCho(inf);
            OnSign();          
            Close();
            MessageBox.Show("Hoàn thành!");
        }
    }
}
