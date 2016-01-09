using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.CTL;

namespace Managament_Library_v2._0
{
    public partial class SuaSach : Form
    {
        public SuaSach()
        {
            InitializeComponent();
        }

        public delegate void OnUpdateBookHandler();
        public event OnUpdateBookHandler OnUpdateBook;

        void noticeUpdateBook()
        {
            if (OnUpdateBook != null)
                OnUpdateBook();
        }

        Sach dataSach = new Sach();
        public static string mts = string.Empty;
        public static string mds = string.Empty;
        public static string mcs = string.Empty;
        public static int selectedTab = 0;

        private void SuaSach_Load(object sender, EventArgs e)
        {
            CTL.NgonNgu dataNgonNgu = new CTL.NgonNgu();
            ComboboxItem item;

            DataTable dtNgonNgu = dataNgonNgu.loadNgonNgu();
            DataTable dtTuaSach = dataSach.loadTuaSach();
            DataTable dtDauSach = dataSach.loadDauSachTuaSach();
            DataTable dtCuonSach = dataSach.loadCuonSach();

            TUASACH ts;
            DAUSACH ds;
            CUONSACH cs;

            tcsuasach.SelectedTabIndex = selectedTab;
            if (selectedTab == 0)
            {
                tithemtuasach.Visible = true;
                tithemdausach.Visible = false;
                tithemcuonsach.Visible = false;

                ts = dataSach.timTuaSach(mts);
                txtmatuasach.Text = ts.matuasach;
                txttentuasach.Text = ts.tentuasach;
                txttacgia.Text = ts.tacgia;
                txtgioithieu.Text = ts.gioithieu;
            }
            else if (selectedTab == 1)
            {
                tithemtuasach.Visible = false;
                tithemdausach.Visible = true;
                tithemcuonsach.Visible = false;

                ds = dataSach.timDauSach(mds);

                txtmadausach.Text = ds.madausach;
                if (ds.tinhtrang == true)
                    cbdausach.Checked = true;

                for (int i = 0; i < dtTuaSach.Rows.Count; i++)
                {
                    item = new ComboboxItem();
                    item.Text = dtTuaSach.Rows[i]["Mã tựa sách"].ToString() + " - " + dtTuaSach.Rows[i]["Tên tựa sách"].ToString();
                    item.Value = dtTuaSach.Rows[i]["Mã tựa sách"].ToString();
                    cbxmatuasach.Items.Add(item);
                }

                for (int i = 0; i < dtNgonNgu.Rows.Count; i++)
                {
                    item = new ComboboxItem();
                    item.Text = dtNgonNgu.Rows[i]["Ngôn ngữ"].ToString();
                    item.Value = dtNgonNgu.Rows[i]["Ngôn ngữ"].ToString();
                    cbxngonngu.Items.Add(item);
                }

                for (int i = 0; i < cbxmatuasach.Items.Count; i++)
                {
                    if ((cbxmatuasach.Items[i] as ComboboxItem).Value.ToString() == ds.matuasach)
                    {
                        cbxmatuasach.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbxngonngu.Items.Count; i++)
                {
                    if ((cbxngonngu.Items[i] as ComboboxItem).Value.ToString() == ds.ngonngu)
                    {
                        cbxngonngu.SelectedIndex = i;
                        break;
                    }
                }

            }
            else if (selectedTab == 2)
            {
                tithemtuasach.Visible = false;
                tithemdausach.Visible = false;
                tithemcuonsach.Visible = true;

                cs = dataSach.timCuonSach(mcs);

                txtmacuonsach.Text = cs.macuonsach;
                if (cs.tinhtrang == true)
                    cbcuonsach.Checked = true;

                for (int i = 0; i < dtDauSach.Rows.Count; i++)
                {
                    item = new ComboboxItem();
                    item.Text = dtDauSach.Rows[i]["Mã đầu sách"].ToString() + " - " + dtDauSach.Rows[i]["Tên tựa sách"].ToString() + " - " + dtDauSach.Rows[i]["Ngôn ngữ"].ToString();
                    item.Value = dtDauSach.Rows[i]["Mã đầu sách"].ToString();
                    cbxmadausach.Items.Add(item);
                }

                for (int i = 0; i < cbxmadausach.Items.Count; i++)
                {
                    if ((cbxmadausach.Items[i] as ComboboxItem).Value.ToString() == cs.madausach)
                    {
                        cbxmadausach.SelectedIndex = i;
                        break;
                    }
                }            

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                TUASACH ts;
                DAUSACH ds;
                CUONSACH cs;
                if (selectedTab == 0)
                {
                    ts = new TUASACH();
                    ts.matuasach = txtmatuasach.Text;
                    ts.tentuasach = txttentuasach.Text;
                    ts.tacgia = txttacgia.Text;
                    ts.gioithieu = txtgioithieu.Text;
                    dataSach.suaTuaSach(ts);
                    noticeUpdateBook();
                    Close();
                    MessageBox.Show("Đã lưu!");
                }
                else if (selectedTab == 1)
                {
                    ds = new DAUSACH();
                    ds.madausach = txtmadausach.Text;
                    if (cbdausach.Checked == true)
                        ds.tinhtrang = true;
                    else
                        ds.tinhtrang = false;

                    if (cbxmatuasach.SelectedItem != null)
                        ds.matuasach = (cbxmatuasach.SelectedItem as ComboboxItem).Value.ToString();

                    if(cbxngonngu.SelectedItem != null)
                        ds.ngonngu = (cbxngonngu.SelectedItem as ComboboxItem).Value.ToString();
                    dataSach.suaDauSach(ds);
                    noticeUpdateBook();
                    Close();
                    MessageBox.Show("Đã lưu!");
                }
                else if (selectedTab == 2)
                {
                    cs = new CUONSACH();
                    cs.macuonsach = txtmacuonsach.Text;
                    if (cbxmadausach.SelectedItem != null)
                        cs.madausach = (cbxmadausach.SelectedItem as ComboboxItem).Value.ToString();
                    if (cbcuonsach.Checked == true)
                        cs.tinhtrang = true;
                    else
                        cs.tinhtrang = false;
                    dataSach.suaCuonSach(cs);
                    noticeUpdateBook();
                    Close();
                    MessageBox.Show("Đã lưu!");
                }
                cbxmadausach.Items.Clear();
                cbxngonngu.Items.Clear();
                cbxmatuasach.Items.Clear();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi xảy ra, không thể sửa!");
            }
            
        }

    }
}
