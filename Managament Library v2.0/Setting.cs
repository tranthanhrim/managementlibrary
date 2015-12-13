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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        ThamSo data = new ThamSo();
        MatKhau dataMatKhau = new MatKhau();

        public delegate void OnUpdateThamSoHandler();
        public event OnUpdateThamSoHandler OnUpdateThamSo;

        void noticeUpdateThamSo()
        {
            if (OnUpdateThamSo != null)
                OnUpdateThamSo();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txthandungthe.Text);
                int y = Convert.ToInt32(txtsolantrehen.Text);
                int z = Convert.ToInt32(txtsongaykhoathe.Text);
                int t = Convert.ToInt32(txtsongaymuon.Text);
                int w = Convert.ToInt32(txtsosachmuon.Text);

                THAMSO songaymuon = new THAMSO();
                songaymuon.tenthamso = "songaymuon";
                songaymuon = data.timThamSo(songaymuon);
                songaymuon.giatri = txtsongaymuon.Text;
                data.suaThamSo(songaymuon);


                THAMSO handungthe = new THAMSO();
                handungthe.tenthamso = "handungthe";
                handungthe = data.timThamSo(handungthe);
                handungthe.giatri = txthandungthe.Text;
                data.suaThamSo(handungthe);

                THAMSO solantrehen = new THAMSO();
                solantrehen.tenthamso = "solantrehen";
                solantrehen = data.timThamSo(solantrehen);
                if (cbsolantrehen.Checked == true)
                {
                    solantrehen.giatri = txtsolantrehen.Text;
                }
                else
                {
                    solantrehen.giatri = txtsolantrehen.Text;
                    solantrehen.tinhtrang = false;
                }
                data.suaThamSo(solantrehen);

                THAMSO songaykhoathe = new THAMSO();
                songaykhoathe.tenthamso = "songaykhoathe";
                songaykhoathe = data.timThamSo(songaykhoathe);
                if (cbsolantrehen.Checked == true)
                {
                    songaykhoathe.giatri = txtsongaykhoathe.Text;
                }
                else
                {
                    songaykhoathe.giatri = txtsolantrehen.Text;
                    songaykhoathe.tinhtrang = false;
                }
                data.suaThamSo(songaykhoathe);

                THAMSO sosachmuon = new THAMSO();
                sosachmuon.tenthamso = "sosachmuon";
                sosachmuon = data.timThamSo(sosachmuon);
                if (cbsosachmuon.Checked == true)
                {
                    sosachmuon.giatri = txtsosachmuon.Text;
                }
                else
                {
                    sosachmuon.giatri = txtsosachmuon.Text;
                    sosachmuon.tinhtrang = false;
                }
                data.suaThamSo(sosachmuon);

                string matkhau = dataMatKhau.layMatKhau();
                MATKHAU mkcu = new MATKHAU();
                mkcu.matkhau1 = matkhau;
                mkcu = dataMatKhau.tim(mkcu);

                MATKHAU mkmoi = new MATKHAU();
                mkmoi.matkhau1 = matkhau;
                if (cbcandangnhap.Checked == true)
                    mkmoi.candangnhap = true;
                else
                    mkmoi.candangnhap = false;
                dataMatKhau.suaMatKhau(mkcu, mkmoi);


                MessageBox.Show("Đã lưu!");
                Close();
                noticeUpdateThamSo();
            }
            catch (FormatException)
            {
                MessageBox.Show("Chỉnh sửa không hợp lệ!");
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            THAMSO songaymuon = new THAMSO();
            songaymuon.tenthamso = "songaymuon";
            songaymuon = data.timThamSo(songaymuon);

            THAMSO sosachmuon = new THAMSO();
            sosachmuon.tenthamso = "sosachmuon";
            sosachmuon = data.timThamSo(sosachmuon);


            THAMSO handungthe = new THAMSO();
            handungthe.tenthamso = "handungthe";
            handungthe = data.timThamSo(handungthe);

            THAMSO solantrehen = new THAMSO();
            solantrehen.tenthamso = "solantrehen";
            solantrehen = data.timThamSo(solantrehen);

            THAMSO songaykhoathe = new THAMSO();
            songaykhoathe.tenthamso = "songaykhoathe";
            songaykhoathe = data.timThamSo(songaykhoathe);

            txthandungthe.Text = handungthe.giatri;
            txtsongaymuon.Text = songaymuon.giatri;
            
            if (sosachmuon.tinhtrang != true)
            {
                cbsosachmuon.Checked = false;
            }
            else
            {
                txtsosachmuon.Text = sosachmuon.giatri;
            }

            if (solantrehen.tinhtrang != true)
            {
                cbsolantrehen.Checked = false;
            }
            else
            {
                txtsolantrehen.Text = solantrehen.giatri;
                txtsongaykhoathe.Text = songaykhoathe.giatri;
            }

            bool canDangNhap = dataMatKhau.canDangNhap();
            if (canDangNhap == true)
                cbcandangnhap.Checked = true;
            else
                cbcandangnhap.Checked = false;

        }

        private void cbsosachmuon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsosachmuon.Checked == true)
                txtsosachmuon.Enabled = true;
            else
                txtsosachmuon.Enabled = false;
        }

        private void cbsolantrehen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsolantrehen.Checked == true)
            {
                txtsolantrehen.Enabled = true;
                lbsongaykhoathe.Enabled = true;
                txtsongaykhoathe.Enabled = true;
            }
            else
            {
                txtsolantrehen.Enabled = false;
                lbsongaykhoathe.Enabled = false;
                txtsongaykhoathe.Enabled = false;
            }
        }
    }
}
