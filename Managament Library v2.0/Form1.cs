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
        DangKyCho dataDangKy = new DangKyCho();
        
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

        void updateThamSo()
        {
            thamSo = dataThamSo.loadThamSo();
        }

        void updateDangKyCho()
        {
            dgvchomuonsach.DataSource = dataDangKy.loadDangKyCho();
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

            inf.vipham1++;

            if (solantrehen.tinhtrang == true)
            {
                if (inf.vipham1 % Convert.ToInt32(solantrehen.giatri) == 0)
                {
                    khoaThe(madocgia);
                    songaykhoathe = new THAMSO();
                    songaykhoathe.tenthamso = "songaykhoathe";
                    songaykhoathe = dataThamSo.timThamSo(songaykhoathe);
                    inf.ngayhethan = DateTime.Now.Date.AddDays(Convert.ToInt32(songaykhoathe.giatri));
                }

                /*if (inf.vipham1 < Convert.ToInt32(solantrehen.giatri))
                    inf.vipham1++;
                else //khóa thẻ
                {
                    khoaThe(madocgia);
                    inf.vipham1 = 0;

                    songaykhoathe = new THAMSO();
                    for (int i = 0; i < thamSo.Count; i++)
                    {
                        if (thamSo[i].tenthamso == "songaykhoathe")
                        {
                            songaykhoathe = thamSo[i];
                            break;
                        }
                    }

                    inf.ngayhethan = DateTime.Now.Date.AddDays(Convert.ToInt32(songaykhoathe.giatri));
                }*/
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
                cs.tinhtrang = false;
            else
                cs.tinhtrang = true;

            dataSach.suaCuonSach(cs); //Update thuộc tính "tình trạng" của CUỐN SÁCH
            updateMuonTraSach();
            updateDauSach(cs.madausach); //Kiểm tra thuộc tính "tình trạng" của ĐẦU SÁCH
            updateSach();
        }

        void updateDauSach(string madausach)
        {
            bool conCuonSach = false;
            DataTable dtCuonSach = dataSach.loadCuonSach();
            for (int i = 0; i < dtCuonSach.Rows.Count; i++)
            {
                if (dtCuonSach.Rows[i]["Mã đầu sách"].ToString() == madausach && (bool)dtCuonSach.Rows[i]["Tình trạng"] == true)
                {
                    conCuonSach = true;
                    break;
                }
            }

            updateTinhTrangDauSach(madausach, conCuonSach);
        }

        void updateTinhTrangDauSach(string madausach, bool conCuonSach)
        {
            
            DAUSACH ds = new DAUSACH();
            ds.madausach = madausach;
            ds = dataSach.timDauSach(ds);
            ds.tinhtrang = conCuonSach;
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

        void ktTheHetHan()
        {
            DataTable dt = dataDocGia.loadDocGia();
            THAMSO handungthe = new THAMSO();
            handungthe.tenthamso = "handungthe";
            handungthe = dataThamSo.timThamSo(handungthe);

            DateTime ngaydk;
            DateTime ngayhethan;
            DOCGIA dg;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ngaydk = new DateTime();
                ngaydk = (DateTime)dt.Rows[i]["Ngày lập"];
                ngayhethan = new DateTime();
                ngayhethan = ngaydk.AddMonths(Convert.ToInt32(handungthe.giatri));
                if (ngayhethan.Date < DateTime.Now.Date)
                {
                    dg = new DOCGIA();
                    dg.madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                    dg = dataDocGia.timDocGia(dg);
                    dg.tinhtrang = false;
                    dataDocGia.suaDocGia(dg);
                }
            }
        }

        void ktHetHanPhat()
        {
            DataTable dt = dataViPham.loadViPham();

            DateTime ngayhethan;
            DOCGIA dg;
            VIPHAM vp;

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["Ngày hết hạn phạt"].ToString() == String.Empty)
                    return;

                ngayhethan = new DateTime();
                ngayhethan = (DateTime)dt.Rows[i]["Ngày hết hạn phạt"];

                if (ngayhethan.Date < DateTime.Now.Date)
                {
                    dg = new DOCGIA();
                    dg.madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                    dg = dataDocGia.timDocGia(dg);
                    dg.tinhtrang = true;
                    dataDocGia.suaDocGia(dg);

                    vp = new VIPHAM();
                    vp.madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                    vp = dataViPham.timViPham(vp);
                    vp.ngayhethan = null;
                    dataViPham.suaViPham(vp);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataProvider.openConnect();
            updateDocGia();
            updateSach();
            updateMuonTraSach();
            updateDataViPham();
            updateThamSo();
            updateDangKyCho();
            ktTheHetHan();
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
        private void btnthemsach_Click(object sender, EventArgs e)
        {
            ThemSach formThemSach = new ThemSach();
            formThemSach.OnAddBook += new ThemSach.OnAddBookHandler(updateSach);
            formThemSach.ShowDialog();
        }

        private void btnsuasach_Click(object sender, EventArgs e)
        {
            SuaSach formSuaSach = new SuaSach();
            formSuaSach.OnUpdateBook += new SuaSach.OnUpdateBookHandler(updateSach);
            if (tcsach.SelectedTabIndex == 0)
            {     
                SuaSach.mts = dgvtuasach.SelectedRows[0].Cells[0].Value.ToString();
                SuaSach.selectedTab = 0;
            }
            else if (tcsach.SelectedTabIndex == 1)
            {
                SuaSach.mds = dgvdausach.SelectedRows[0].Cells[0].Value.ToString();
                SuaSach.selectedTab = 1;
            }
            else
            {
                SuaSach.mcs = dgvcuonsach.SelectedRows[0].Cells[0].Value.ToString();
                SuaSach.selectedTab = 2;
            }
            formSuaSach.ShowDialog();
        }

        private void btnxoasach_Click(object sender, EventArgs e)
        {

        }

        private void btntimsach_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Mượn trả sách
        private void btnmuonsach_Click(object sender, EventArgs e)
        {
            ThemMuonTraSach formThemMuon = new ThemMuonTraSach();
            formThemMuon.OnBorrowBook += new ThemMuonTraSach.OnBorrowBookHanlder(updateTinhTrangCuonSach);
            formThemMuon.ShowDialog();
        }

        private void btntrasach_Click(object sender, EventArgs e)
        {
            if (dgvmuontrasach.SelectedRows[0].Cells[4].Value != DBNull.Value)
            {
                MessageBox.Show("Đã trả sách rồi!");
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

        #endregion
     


        #region Đăng ký chờ mượn sách
        private void btnchomuon_Click(object sender, EventArgs e)
        {
            ThemDangKyCho formCho = new ThemDangKyCho();
            formCho.OnSign += new ThemDangKyCho.OnSignHandler(updateDangKyCho);
            formCho.ShowDialog();
        }

        private void btnsuacho_Click(object sender, EventArgs e)
        {
            SuaDangKyCho formSua = new SuaDangKyCho();
            formSua.OnUpdate += new SuaDangKyCho.OnUpdateHandler(updateDangKyCho);
            SuaDangKyCho.inf.madocgia = dgvchomuonsach.SelectedRows[0].Cells[0].Value.ToString();
            SuaDangKyCho.inf.madausach = dgvchomuonsach.SelectedRows[0].Cells[1].Value.ToString();
            SuaDangKyCho.inf.ngaygiodk = (DateTime)dgvchomuonsach.SelectedRows[0].Cells[2].Value;
            SuaDangKyCho.inf.tinhtrang = (bool)dgvchomuonsach.SelectedRows[0].Cells[3].Value;
            formSua.ShowDialog();
        }

        private void btndamuon_Click(object sender, EventArgs e)
        {
            DKCHOMUON inf = new DKCHOMUON();
            inf.madocgia = dgvchomuonsach.SelectedRows[0].Cells[0].Value.ToString();
            inf.madausach = dgvchomuonsach.SelectedRows[0].Cells[1].Value.ToString();
            inf.ngaygiodk = (DateTime)dgvchomuonsach.SelectedRows[0].Cells[2].Value;
            inf.tinhtrang = true;
            dataDangKy.suaDangKyCho(inf, inf);
            dgvchomuonsach.DataSource = dataDangKy.loadDangKyCho();
        }
        #endregion


        private void btnsetting_Click(object sender, EventArgs e)
        {
            Setting formSetting = new Setting();
            formSetting.OnUpdateThamSo += new Setting.OnUpdateThamSoHandler(updateThamSo);
            formSetting.ShowDialog();
        }

        private void btnngonngu_Click(object sender, EventArgs e)
        {
            NgonNgu formNgonNgu = new NgonNgu();
            formNgonNgu.ShowDialog();
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            ThongKe formThongKe = new ThongKe();
            formThongKe.ShowDialog();
        }

    }
}
