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
    public partial class ThemSach : Form
    {
        public ThemSach()
        {
            InitializeComponent();
        }

        public int timSTT(DataTable dt, string column)
        {
            int STT = 0;
            while (true)
            {
                int temp = STT;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (temp.ToString() == dt.Rows[i][column].ToString())
                    {
                        temp++;
                        break;
                    }
                }

                if (temp == STT)
                {
                    return STT;
                }
                else
                    STT++;
            }
        }

        Sach dataSach = new Sach();
        public delegate void OnAddBookHandler();
        public event OnAddBookHandler OnAddBook;

        void noticeAddBook()
        {
            if (OnAddBook != null)
                OnAddBook();
        }


        private void ThemSach_Load(object sender, EventArgs e)
        {
            CTL.NgonNgu dataNgonNgu = new CTL.NgonNgu();
            ComboboxItem item;

            DataTable dtNgonNgu = dataNgonNgu.loadNgonNgu();
            DataTable dtTuaSach = dataSach.loadTuaSach();
            DataTable dtDauSach = dataSach.loadDauSachTuaSach();
            DataTable dtCuonSach = dataSach.loadCuonSach();

            int matuasach = timSTT(dtTuaSach, "Mã tựa sách");
            int madausach = timSTT(dtDauSach, "Mã đầu sách");
            int macuonsach = timSTT(dtCuonSach, "Mã cuốn sách");

            #region Tựa sách
            txtmatuasach.Text = matuasach.ToString();
            #endregion

            #region Đầu sách
            txtmadausach.Text = madausach.ToString();

            for (int i = 0; i < dtTuaSach.Rows.Count; i++)
            {
                item = new ComboboxItem();
                item.Text = dtTuaSach.Rows[i]["Mã tựa sách"].ToString() + " - " + dtTuaSach.Rows[i]["Tên tựa sách"].ToString();
                item.Value = dtTuaSach.Rows[i]["Mã tựa sách"].ToString();
                cbxtuasach.Items.Add(item);
            }

            for (int i = 0; i < dtNgonNgu.Rows.Count; i++)
            {
                item = new ComboboxItem();
                item.Text = dtNgonNgu.Rows[i]["Ngôn ngữ"].ToString();
                item.Value = dtNgonNgu.Rows[i]["Ngôn ngữ"].ToString();
                cbxngonngu.Items.Add(item);
            }
            cbxtuasach.SelectedIndex = 0;
            cbxngonngu.SelectedIndex = 0;

            #endregion

            #region Cuốn sách

            for (int i = 0; i < dtDauSach.Rows.Count; i++)
            {
                item = new ComboboxItem();
                item.Text = dtDauSach.Rows[i]["Mã đầu sách"].ToString() + " - " + dtDauSach.Rows[i]["Tên tựa sách"].ToString() + " - " + dtDauSach.Rows[i]["Ngôn ngữ"].ToString();
                item.Value = dtDauSach.Rows[i]["Mã đầu sách"].ToString();
                cbxmadausach.Items.Add(item);
            }
            cbxmadausach.SelectedIndex = 0;
            txtmacuonsach.Text = macuonsach.ToString();
            #endregion
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (tcthemsach.SelectedTabIndex == 0) //thêm tựa sách
            {
                TUASACH ts = new TUASACH();
                ts.matuasach = txtmatuasach.Text;
                ts.tentuasach = txttentuasach.Text;
                ts.tacgia = txttacgia.Text;
                ts.gioithieu = txtgioithieu.Text;
                dataSach.themTuaSach(ts);
                noticeAddBook();
                Close();
                MessageBox.Show("Đã thêm");
            }
            else if (tcthemsach.SelectedTabIndex == 1) //thêm đầu sách
            {
                DAUSACH ds = new DAUSACH();
                ds.madausach = txtmadausach.Text;
                ds.tinhtrang = false;
                ds.matuasach = (cbxtuasach.SelectedItem as ComboboxItem).Value.ToString();
                ds.ngonngu = (cbxngonngu.SelectedItem as ComboboxItem).Value.ToString();
                dataSach.themDauSach(ds);
                noticeAddBook();
                Close();
                MessageBox.Show("Đã thêm");
            }
            else
            {
                CUONSACH cs = new CUONSACH();
                cs.macuonsach = txtmacuonsach.Text;
                cs.madausach = (cbxmadausach.SelectedItem as ComboboxItem).Value.ToString();
                cs.tinhtrang = true;
                dataSach.themCuonSach(cs);

                DAUSACH ds = dataSach.timDauSach(cs.madausach);
                if (ds.tinhtrang != true)
                {
                    ds.tinhtrang = true;
                    dataSach.suaDauSach(ds);
                }
                noticeAddBook();
                Close();
                MessageBox.Show("Đã thêm");
            }
        }
    }
}
