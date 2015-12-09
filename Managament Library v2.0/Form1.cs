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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<THAMSO> thamSo;

        DocGia dataDocGia = new DocGia();
        Sach dataSach = new Sach();
        MuonTraSach dataMuonTraSach = new MuonTraSach();
        ThamSo dataThamSo = new ThamSo();
        ViPham dataViPham = new ViPham();
        
        /*DOCGIA dg;
        HOCSINH hs;
        NHANVIEN nv;
        CUONSACH cs;
        DAUSACH ds;*/

        void updateDocGia()
        {
            dgvdocgia.DataSource = dataDocGia.loadDocGia();
            dgvhocsinh.DataSource = dataDocGia.loadHocSinh();
            dgvnhanvien.DataSource = dataDocGia.loadNhanVien();
        }

        void updateDataViPham()
        {
            dgvvipham.DataSource = dataViPham.loadViPham();
        }

        void updateViPham(string madocgia)
        {
            VIPHAM inf = new VIPHAM();
            THAMSO songaykhoathe;
            THAMSO solantrehen = new THAMSO();
            inf.madocgia = madocgia;
            inf = dataViPham.timViPham(inf);

            for (int i = 0; i < thamSo.Count; i++)
            {
                if (thamSo[i].tenthamso == "solantrehen")
                {
                    solantrehen = thamSo[i];
                    break;
                }
            }

            if (inf.vipham1 < Convert.ToInt32(solantrehen.giatri))
                inf.vipham1++;
            else //khóa thẻ
            {
                khoaThe(madocgia);
                inf.vipham1 = 0;

                songaykhoathe = new THAMSO();
                for(int i = 0; i < thamSo.Count; i++)
                {
                    if (thamSo[i].tenthamso == "songaykhoathe")
                    {
                        songaykhoathe = thamSo[i];
                        break;
                    }
                }

                inf.ngayhethan = DateTime.Now.Date.AddDays(Convert.ToInt32(songaykhoathe.giatri));
            }
            dataViPham.suaViPham(inf);
        }

        void updateSach()
        {
            dgvtuasach.DataSource = dataSach.loadTuaSach();
            dgvdausach.DataSource = dataSach.loadDauSach();
            dgvcuonsach.DataSource = dataSach.loadCuonSach();
        }

        void updateMuonTraSach()
        {
            dgvmuontrasach.DataSource = dataMuonTraSach.loadMuonTraSach();
        }

        void updateTinhTrangCuonSach(string macuonsach)
        {
            CUONSACH cs = new CUONSACH();
            cs.macuonsach = macuonsach;
            cs = dataSach.timCuonSach(cs);
            if (cs.tinhtrang == true)
                cs.tinhtrang = null;
            else
                cs.tinhtrang = true;

            dataSach.suaCuonSach(cs);
            updateMuonTraSach();
            updateSach();
        }

        void updateTinhTrangDauSach(string madausach)
        {
            
            DAUSACH ds = new DAUSACH();
            ds.madausach = madausach;
            ds = dataSach.timDauSach(ds);
            if (ds.tinhtrang == true)
                ds.tinhtrang = null;
            else
                ds.tinhtrang = true;
            dataSach.suaDauSach(ds);
            updateSach();
        }

        void khoaThe(string madocgia)
        {
            DOCGIA dg = new DOCGIA();
            dg.madocgia = madocgia;
            dg = dataDocGia.timDocGia(dg);
            dg.tinhtrang = false;
            dataDocGia.suaDocGia(dg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataProvider.openConnect();
            updateDocGia();
            updateSach();
            updateMuonTraSach();
            updateDataViPham();
            thamSo = dataThamSo.loadThamSo();
            
        }

        #region Độc giả
        private void btnthemdg_Click(object sender, EventArgs e)
        {
            ThemDocGia formThemDG = new ThemDocGia();
            formThemDG.OnAdd += new ThemDocGia.OnAddHandler(updateDocGia);
            formThemDG.ShowDialog();
        }

        private void btnxoadg_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Do you really want to delete?", "Exit", MessageBoxButtons.YesNo);
            if (delete == DialogResult.No)
                return;

           if (tcdocgia.SelectedTabIndex == 0)//xóa theo tab độc giả
           {
               if (dgvdocgia.SelectedRows.Count == 0)
                   return;
               DOCGIA dg = new DOCGIA();
               HOCSINH hs = new HOCSINH();
               NHANVIEN nv = new NHANVIEN();
               dg.madocgia = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();
               hs.madocgia = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();
               nv.madocgia = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();
               dataDocGia.xoaNhanVien(nv);
               dataDocGia.xoaHocSinh(hs);
               dataDocGia.xoaDocGia(dg);
               updateDocGia();
           }
           else if (tcdocgia.SelectedTabIndex == 1)//xóa theo tab học sinh
           {
               if (dgvhocsinh.SelectedRows.Count == 0)
                   return;
               DOCGIA dg = new DOCGIA();
               HOCSINH hs = new HOCSINH();
               dg.madocgia = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
               hs.madocgia = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
               dataDocGia.xoaHocSinh(hs);
               dataDocGia.xoaDocGia(dg);
               updateDocGia();

           }
           else if (tcdocgia.SelectedTabIndex == 2)//xóa theo tab nhân viên
           {
               if (dgvnhanvien.SelectedRows.Count == 0)
                   return;
               DOCGIA dg = new DOCGIA();              
               NHANVIEN nv = new NHANVIEN();
               dg.madocgia = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
               nv.madocgia = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
               dataDocGia.xoaNhanVien(nv);
               dataDocGia.xoaDocGia(dg);
               updateDocGia();
           }
        }

        private void btnsuadg_Click(object sender, EventArgs e)
        {
            if (tcdocgia.SelectedTabIndex == 0)//sửa theo tab độc giả
            {
                if (dgvdocgia.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(updateDocGia);
                SuaDocGia.mdg = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();              
                formSuaDG.ShowDialog();
            }
            else if (tcdocgia.SelectedTabIndex == 1)//sửa theo tab học sinh
            {
                if (dgvhocsinh.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(updateDocGia);
                SuaDocGia.mdg = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
                formSuaDG.ShowDialog();

            }
            else if (tcdocgia.SelectedTabIndex == 2)//sửa theo tab nhân viên
            {
                if (dgvnhanvien.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(updateDocGia);
                SuaDocGia.mdg = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
                formSuaDG.ShowDialog();
            }
            else if (tcdocgia.SelectedTabIndex == 3)
            {
                if (dgvvipham.SelectedRows.Count == 0)
                    return;
                SuaViPham formSuaVP = new SuaViPham();
                SuaViPham.madocgia = dgvvipham.SelectedRows[0].Cells[0].Value.ToString();
                formSuaVP.OnUpdate += new SuaViPham.OnUpdateHandler(updateDataViPham);
                formSuaVP.ShowDialog();
            }
            
        }

        private void btntimdg_Click(object sender, EventArgs e)
        {
            TimDocGia formTimDG = new TimDocGia();
            formTimDG.ShowDialog();
        }
        #endregion

        #region Sách

        #endregion

        #region Mượn trả sách
        private void btnmuonsach_Click(object sender, EventArgs e)
        {
            ThemMuonTraSach formThemMuon = new ThemMuonTraSach();
            formThemMuon.OnBorrowBook += new ThemMuonTraSach.OnBorrowBookHanlder(updateTinhTrangCuonSach);
            formThemMuon.ShowDialog();
        }

        #endregion

        private void btntrasach_Click(object sender, EventArgs e)
        {
            if (dgvmuontrasach.SelectedRows[0].Cells[4].Value != DBNull.Value)
            {
                MessageBox.Show("Invalid!");
                return;
            }

            TraSach formTraSach = new TraSach();
            TraSach.inf.madocgia = dgvmuontrasach.SelectedRows[0].Cells[0].Value.ToString();
            TraSach.inf.macuonsach = dgvmuontrasach.SelectedRows[0].Cells[1].Value.ToString();
            TraSach.inf.ngaygiomuon = (DateTime)dgvmuontrasach.SelectedRows[0].Cells[2].Value;
            formTraSach.OnBackBook += new TraSach.OnBackBookHandler(updateTinhTrangCuonSach);
            formTraSach.OnIllegal += new TraSach.OnIllegalHandler(updateViPham);
            formTraSach.ShowDialog();
        }

        private void btnsuamuon_Click(object sender, EventArgs e)
        {
            SuaMuonTraSach formSua = new SuaMuonTraSach();
            SuaMuonTraSach.inf.madocgia = dgvmuontrasach.SelectedRows[0].Cells[0].Value.ToString();
            SuaMuonTraSach.inf.macuonsach = dgvmuontrasach.SelectedRows[0].Cells[1].Value.ToString();
            SuaMuonTraSach.inf.ngaygiomuon = (DateTime)dgvmuontrasach.SelectedRows[0].Cells[2].Value;
            formSua.OnUpdateBackBook += new SuaMuonTraSach.OnUpdateBackBookHandler(updateMuonTraSach);
            formSua.ShowDialog();
        }
    }
}
