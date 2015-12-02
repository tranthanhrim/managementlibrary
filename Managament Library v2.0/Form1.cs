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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DocGiaCTL dataDocGia = new DocGiaCTL();
        DocGiaDTO dg;
        HocSinhDTO hs;
        NhanVienDTO nv;

        void update()
        {
            dgvdocgia.DataSource = dataDocGia.loadDocGia();
            dgvhocsinh.DataSource = dataDocGia.loadHocSinh();
            dgvnhanvien.DataSource = dataDocGia.loadNhanVien();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataProvider.openConnect();
            update();           
        }

        private void btnthemdg_Click(object sender, EventArgs e)
        {
            ThemDocGia formThemDG = new ThemDocGia();
            formThemDG.OnAdd += new ThemDocGia.OnAddHandler(update);
            formThemDG.ShowDialog();
        }

        private void btnxoadg_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Do you really want to delete?", "Exit", MessageBoxButtons.YesNo);
            if (delete == DialogResult.No)
                return;

           if (tcdocgia.SelectedTabIndex == 0)//tab độc giả
           {
               if (dgvdocgia.SelectedRows.Count == 0)
                   return;
               dg = new DocGiaDTO();
               hs = new HocSinhDTO();
               nv = new NhanVienDTO();
               dg.MaDocGia = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();
               hs.MaDocGia = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();
               nv.MaDocGia = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();
               dataDocGia.xoaNhanVien(nv);
               dataDocGia.xoaHocSinh(hs);
               dataDocGia.xoaDocGia(dg);
               update();
           }
           else if (tcdocgia.SelectedTabIndex == 1)//tab học sinh
           {
               if (dgvhocsinh.SelectedRows.Count == 0)
                   return;
               dg = new DocGiaDTO();
               hs = new HocSinhDTO();
               dg.MaDocGia = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
               hs.MaDocGia = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
               dataDocGia.xoaHocSinh(hs);
               dataDocGia.xoaDocGia(dg);
               update();

           }
           else if (tcdocgia.SelectedTabIndex == 2)//tab nhân viên
           {
               if (dgvnhanvien.SelectedRows.Count == 0)
                   return;
               dg = new DocGiaDTO();              
               nv = new NhanVienDTO();
               dg.MaDocGia = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
               nv.MaDocGia = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
               dataDocGia.xoaNhanVien(nv);
               dataDocGia.xoaDocGia(dg);
               update();
           }
        }

        private void btnsuadg_Click(object sender, EventArgs e)
        {
            if (tcdocgia.SelectedTabIndex == 0)//tab độc giả
            {
                if (dgvdocgia.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(update);
                SuaDocGia.mdg = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();              
                formSuaDG.ShowDialog();
            }
            else if (tcdocgia.SelectedTabIndex == 1)//tab học sinh
            {
                if (dgvhocsinh.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(update);
                SuaDocGia.mdg = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
                formSuaDG.ShowDialog();

            }
            else if (tcdocgia.SelectedTabIndex == 2)//tab nhân viên
            {
                if (dgvnhanvien.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(update);
                SuaDocGia.mdg = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
                formSuaDG.ShowDialog();
            }
        }

        private void btntimdg_Click(object sender, EventArgs e)
        {
            TimDocGia formTimDG = new TimDocGia();
            formTimDG.ShowDialog();
        }
    }
}
