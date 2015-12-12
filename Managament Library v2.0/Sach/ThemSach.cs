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

            int matuasach = 0;
            int madausach = 0;
            int macuonsach = 0;

            #region Tựa sách
            for (int i = 0; i < dtTuaSach.Rows.Count; i++)//tab Tựa sách
            {
                int temp = Convert.ToInt32(dtTuaSach.Rows[i]["Mã tựa sách"]);
                if (temp != matuasach)
                {
                    break;
                }
                else
                {
                    matuasach++;
                }

            }
            txtmatuasach.Text = matuasach.ToString();
            #endregion

            #region Đầu sách
            for (int i = 0; i < dtDauSach.Rows.Count; i++)//tab đầu sách
            {
                int temp = Convert.ToInt32(dtDauSach.Rows[i]["Mã đầu sách"]);
                if (temp != madausach)
                {
                    break;
                }
                else
                {
                    madausach++;
                }

            }
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
                cbxngonngu.Items.Add(dtNgonNgu.Rows[i]["Ngôn ngữ"]);
            }
            cbxtuasach.SelectedIndex = 0;
            cbxngonngu.SelectedIndex = 0;

            #endregion

            #region Cuốn sách
            for (int i = 0; i < dtCuonSach.Rows.Count; i++)
            {
                int temp = Convert.ToInt32(dtCuonSach.Rows[i]["Mã cuốn sách"]);
                if (temp != macuonsach)
                {
                    break;
                }
                else
                {
                    macuonsach++;
                }

            }

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
            }
            else
            {
                CUONSACH cs = new CUONSACH();
                cs.macuonsach = txtmacuonsach.Text;
                cs.madausach = (cbxmadausach.SelectedItem as ComboboxItem).Value.ToString();
                cs.tinhtrang = true;
                dataSach.themCuonSach(cs);
                noticeAddBook();
            }
        }
    }
}
