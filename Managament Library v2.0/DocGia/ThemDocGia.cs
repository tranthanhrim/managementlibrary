﻿using System;
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

            int mdg = timSTT(dt, "Mã độc giả");

            txtmdg.Text = mdg.ToString();

            CTL.Lop dataLop = new CTL.Lop();
            DataTable dtLop = dataLop.loadLop();
            ComboboxItem item;
            for (int i = 0; i < dtLop.Rows.Count; i++)
            {
                item = new ComboboxItem();
                item.Text = dtLop.Rows[i]["Lớp"].ToString();
                item.Value = dtLop.Rows[i]["Lớp"].ToString();
                cbxlop.Items.Add(item);
            }

            String[] gioitinh = { "Nam", "Nữ", "Khác" };

            for (int i = 0; i < gioitinh.Count(); i++)
            {
                item = new ComboboxItem();
                item.Text = gioitinh[i];
                item.Value = gioitinh[i];
                cbxgioitinh.Items.Add(item);
            }

            if (cbxlop.Items.Count > 0)
                cbxlop.SelectedIndex = 0;
            cbxgioitinh.SelectedIndex = 0;
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
                    dg.gioitinh = (cbxgioitinh.SelectedItem as ComboboxItem).Value.ToString();
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
                        if (cbxlop.SelectedItem != null)
                            hs.lop = (cbxlop.SelectedItem as ComboboxItem).Value.ToString();
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
            /*catch (NullReferenceException)
            {
                MessageBox.Show("Có giá trị rỗng!");
            }*/
        }

        private void rbhocsinh_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;
            if (temp.Checked == true)
            {
                lbllop.Enabled = true;
                cbxlop.Enabled = true;
            }
        }

        private void rbnhanvien_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;
            if (temp.Checked == true)
            {
                lbllop.Enabled = false;
                cbxlop.Enabled = false;
            }
        }
    }
}
