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
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.CTL;

namespace Managament_Library_v2._0
{
    public partial class SuaDangKyCho : Form
    {
        public SuaDangKyCho()
        {
            InitializeComponent();
        }

        public static DKCHOMUON inf = new DKCHOMUON();
        DangKyCho dataDangKyCho = new DangKyCho();

        public delegate void OnUpdateHandler();
        public event OnUpdateHandler OnUpdate;

        void noticeUpdate()
        {
            if (OnUpdate != null)
                OnUpdate();
        }

        private void SuaDangKyCho_Load(object sender, EventArgs e)
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
                //if (dtDauSach.Rows[i]["Tình trạng"].ToString() == String.Empty || (bool)dtDauSach.Rows[i]["Tình trạng"] == false)//== String.Empty                  
                //{
                    //cbxmadausach.Items.Add(Convert.ToInt32(dtDauSach.Rows[i]["Mã đầu sách"].ToString()));
                    item = new ComboboxItem();
                    item.Text = dtDauSach.Rows[i]["Mã đầu sách"].ToString() + " - " + dtDauSach.Rows[i]["Tên tựa sách"].ToString() + " - " + dtDauSach.Rows[i]["Ngôn ngữ"].ToString();
                    item.Value = Convert.ToInt32(dtDauSach.Rows[i]["Mã đầu sách"]);
                    cbxmadausach.Items.Add(item);
                //}
            }

            //cbxmadausach.SelectedIndex = inf.ma;
            //cbxmdg.SelectedIndex = 0;

            for (int i = 0; i < cbxmdg.Items.Count; i++)
            {
                if (cbxmdg.Items[i].ToString() == inf.madocgia)
                {
                    cbxmdg.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cbxmadausach.Items.Count; i++)
            {
                if ((cbxmadausach.Items[i] as ComboboxItem).Value.ToString() == inf.madausach)
                {
                    cbxmadausach.SelectedIndex = i;
                    break;
                }
            }

            dtngaygiodk.Value = inf.ngaygiodk;
            if (inf.tinhtrang == true)
                cbdamuon.Checked = true;
            else
                cbdamuon.Checked = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                DKCHOMUON after = new DKCHOMUON();
                after.madocgia = cbxmdg.SelectedItem.ToString();
                after.madausach = (cbxmadausach.SelectedItem as ComboboxItem).Value.ToString();
                after.ngaygiodk = dtngaygiodk.Value.Date;
                after.tinhtrang = cbdamuon.Checked;
                dataDangKyCho.suaDangKyCho(inf, after);
                MessageBox.Show("Đã lưu!");
                Close();
                OnUpdate();
            }
            catch (SqlException)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
            }
        }
    }
}
