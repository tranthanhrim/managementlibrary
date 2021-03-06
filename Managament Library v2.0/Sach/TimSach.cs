﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.CTL;

namespace Managament_Library_v2._0
{
    public partial class TimSach : Form
    {
        public TimSach()
        {
            InitializeComponent();
        }

        Sach dataSach = new Sach();

        private void btntim_Click(object sender, EventArgs e)
        {
            if (tctimsach.SelectedTabIndex == 0)//tab tựa sách
            {
                TUASACH ts = new TUASACH();
                if (rbmatuasach.Checked == true)//tìm theo mã tựa sách
                {
                    ts.matuasach = txtmatuasach.Text;
                    dgvtuasach.DataSource = dataSach.timTuaSach(ts, 1);
                }
                else if (rbtentuasach.Checked == true)//tìm theo tên tựa sách
                {
                    ts.tentuasach = txttentuasach.Text;
                    dgvtuasach.DataSource = dataSach.timTuaSach(ts, 2);
                }
                else if (rbtacgia.Checked == true)//tìm theo tác giả
                {
                    ts.tacgia = txttacgia.Text;
                    dgvtuasach.DataSource = dataSach.timTuaSach(ts, 3);
                }
            }
            else if (tctimsach.SelectedTabIndex == 1)
            {
                DAUSACH ds = new DAUSACH();
                if (rbmadausach.Checked == true)//tìm theo mã đầu sách
                {
                    ds.madausach = txtmadausach.Text;
                    dgvdausach.DataSource = dataSach.timDauSach(ds, 1);
                }
                else if (rbmatuasach2.Checked == true)//tìm theo mã tựa sách
                {
                    ds.matuasach = txtmatuasach2.Text;
                    dgvdausach.DataSource = dataSach.timDauSach(ds, 2);
                }
                else if (rbtentuasach2.Checked == true) //tìm theo tên tựa sách
                {
                    dgvdausach.DataSource = dataSach.timTheoTen(txttentuasach2.Text.ToString(), 1);
                }
            }
            else
            {
                CUONSACH cs = new CUONSACH();
                if (rbmacuonsach.Checked == true) //tìm theo mã cuốn sách
                {
                    cs.macuonsach = txtmacuonsach.Text;
                    dgvcuonsach.DataSource = dataSach.timCuonSach(cs, 1);
                }
                else if (rbmadausach2.Checked == true) //tìm theo mã đầu sách
                {
                    cs.madausach = txtmadausach2.Text;
                    dgvcuonsach.DataSource = dataSach.timCuonSach(cs, 2);
                }
                else if (rbmatuasach3.Checked == true)
                {
                    cs.madausach = txtmatuasach3.Text;
                    dgvcuonsach.DataSource = dataSach.timCuonSach(cs, 3);
                }
                else if (rbtentuasach3.Checked == true)
                {
                    dgvcuonsach.DataSource = dataSach.timTheoTen(txttentuasach3.Text.ToString(), 2);
                }
            }
        }

        private void TimSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btntim_Click(null, null);
            }
        }
        private void txtmatuasach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void rbmatuasach_CheckedChanged(object sender, EventArgs e)
        {
            txtmatuasach.Select();
        }

        private void rbtentuasach_CheckedChanged(object sender, EventArgs e)
        {
            txttentuasach.Select();
        }

        private void rbtacgia_CheckedChanged(object sender, EventArgs e)
        {
            txttacgia.Select();
        }

        private void rbmadausach_CheckedChanged(object sender, EventArgs e)
        {
            txtmadausach.Select();
        }

        private void rbmatuasach2_CheckedChanged(object sender, EventArgs e)
        {
            txtmatuasach2.Select();
        }

        private void rbtentuasach2_CheckedChanged(object sender, EventArgs e)
        {
            txttentuasach2.Select();
        }

        private void rbmacuonsach_CheckedChanged(object sender, EventArgs e)
        {
            txtmacuonsach.Select();
        }

        private void rbmadausach2_CheckedChanged(object sender, EventArgs e)
        {
            txtmadausach2.Select();
        }

        private void rbmatuasach3_CheckedChanged(object sender, EventArgs e)
        {
            txtmatuasach3.Select();
        }

        private void rbtentuasach3_CheckedChanged(object sender, EventArgs e)
        {
            txttentuasach3.Select();
        }


    }
}
