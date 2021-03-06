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


        DocGia dataDocGia = new DocGia();
        Sach dataSach = new Sach();
        MuonTraSach dataMuonTraSach = new MuonTraSach();
        DangKyCho dataDangKy = new DangKyCho();


        #region update

        void updateDgvDocGia()//load lại DataGridView độc giả
        {
            ViPham dataViPham = new ViPham();
            dgvdocgia.DataSource = dataDocGia.loadDocGia();
            dgvhocsinh.DataSource = dataDocGia.loadHocSinh();
            dgvnhanvien.DataSource = dataDocGia.loadNhanVien();
            dgvvipham.DataSource = dataViPham.loadViPham();
            //dgvdocgia.Columns[0].ValueType = typeof(Int32);
            //dgvdocgia.Sort(dgvdocgia.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            
        }

        void updateDgvSach()//load lại DataGridView sách
        {
            dgvtuasach.DataSource = dataSach.loadTuaSach();
            dgvdausach.DataSource = dataSach.loadDauSach();
            dgvcuonsach.DataSource = dataSach.loadCuonSach();
        }

        void updateDgvViPham()//load lại DataGridView vi phạm
        {
            ViPham dataViPham = new ViPham();
            dgvvipham.DataSource = dataViPham.loadViPham();          
        }

        void updateDgvDangKyCho()//load lại DataGridView đăng ký chờ mượn sách
        {
            dgvchomuonsach.DataSource = dataDangKy.loadDangKyCho();
        }

        void updateDgvMuonTraSach()
        {
            dgvmuontrasach.DataSource = dataMuonTraSach.loadMuonTraSach();
        }

        void checkDocGia()//kiểm tra thẻ độc giả
        {
            ktPhucHoiThe();
            ktTheHetHan();
            ktHetHanPhat();
            updateDgvDocGia();
        }
   
        void updateViPham(string madocgia)//cập nhật bảng vi phạm
        {
            ViPham dataViPham = new ViPham();
            ThamSo dataThamSo = new ThamSo();
            VIPHAM inf = new VIPHAM();
            THAMSO songaykhoathe;
            THAMSO solantrehen = new THAMSO();
            inf.madocgia = madocgia;
            inf = dataViPham.timViPham(inf);

            solantrehen = new THAMSO();
            solantrehen.tenthamso = "solantrehen";
            solantrehen = dataThamSo.timThamSo(solantrehen);

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
            }
            dataViPham.suaViPham(inf);
            //updateDocGia();
            dgvdocgia.DataSource = dataDocGia.loadDocGia();
            dgvhocsinh.DataSource = dataDocGia.loadHocSinh();
            dgvnhanvien.DataSource = dataDocGia.loadNhanVien();
            dgvvipham.DataSource = dataViPham.loadViPham();
        }

        void updateTinhTrangCuonSach(string macuonsach)//cập nhật thuộc tính "tình trạng" của CUỐN SÁCH
        {
            CUONSACH cs = dataSach.timCuonSach(macuonsach);
            if (cs.tinhtrang == true)
                cs.tinhtrang = false;
            else
                cs.tinhtrang = true;

            dataSach.suaCuonSach(cs); //cập nhật thuộc tính "tình trạng" của CUỐN SÁCH
            updateTinhTrangDauSach(cs.madausach); //cập nhật thuộc tính "tình trạng" của ĐẦU SÁCH
            updateDgvMuonTraSach();
            updateDgvSach();
        }

        void updateTinhTrangDauSach(string madausach)//cập nhật thuộc tính "tình trạng" của ĐẦU SÁCH
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

            DAUSACH ds = dataSach.timDauSach(madausach);
            ds.tinhtrang = conCuonSach;
            dataSach.suaDauSach(ds);
            //updateTinhTrangDauSach(madausach, conCuonSach);
        }

        //void updateTinhTrangDauSach(string madausach, bool conCuonSach)
        //{
        //    DAUSACH ds = dataSach.timDauSach(madausach);
        //    ds.tinhtrang = conCuonSach;
        //    dataSach.suaDauSach(ds);
        //    updateDgvSach();
        //}

        void khoaThe(string madocgia)//khóa thẻ độc giả
        {
            DOCGIA dg = dataDocGia.timDocGia(madocgia);
            dg.tinhtrang = false;
            dataDocGia.suaDocGia(dg);
            //updateDocGia();
        }

        void ktTheHetHan()//kiểm tra thẻ độc giả hết hạn
        {
            ThamSo dataThamSo = new ThamSo();
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

                if (ngayhethan.Date < DateTime.Now.Date) //khóa thẻ
                {
                    //dg = new DOCGIA();
                    //dg.madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                    string madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                    dg = dataDocGia.timDocGia(madocgia);
                    dg.tinhtrang = false;
                    dataDocGia.suaDocGia(dg);
                }
            }
        }

        void ktPhucHoiThe()//kiểm tra phục hồi thẻ độc giả đã gia hạn
        {
            ViPham dataViPham = new ViPham();
            ThamSo dataThamSo = new ThamSo();
            DataTable dt = dataDocGia.loadDocGia();
            THAMSO handungthe = new THAMSO();
            handungthe.tenthamso = "handungthe";
            handungthe = dataThamSo.timThamSo(handungthe);

            DateTime ngaydk;
            DateTime ngayhethan;
            DOCGIA dg;
            DataTable vp;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                vp = dataViPham.timViPham(dt.Rows[i]["Mã độc giả"].ToString());

                ngaydk = new DateTime();
                ngaydk = (DateTime)dt.Rows[i]["Ngày lập"];
                ngayhethan = new DateTime();
                ngayhethan = ngaydk.AddMonths(Convert.ToInt32(handungthe.giatri));
                if (ngayhethan.Date >= DateTime.Now.Date && (vp.Rows[0]["ngayhethan"].ToString() == String.Empty || (DateTime)vp.Rows[0]["ngayhethan"] < DateTime.Now)) //mở thẻ
                {
                    //dg = new DOCGIA();
                    string madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                    //dg.madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                    dg = dataDocGia.timDocGia(madocgia);
                    if (dg.tinhtrang != true)
                    {
                        dg.tinhtrang = true;
                        dataDocGia.suaDocGia(dg);
                    }                      
                }
            }
        }

        void ktHetHanPhat()//kiểm tra phục hồi thẻ độc giả hết hạn phạt
        {
            ViPham dataViPham = new ViPham();
            DataTable dt = dataViPham.loadViPham();
            DateTime ngayhethan;
            DOCGIA dg;
            VIPHAM vp;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Ngày hết hạn phạt"].ToString() != String.Empty)
                {
                    ngayhethan = new DateTime();
                    ngayhethan = (DateTime)dt.Rows[i]["Ngày hết hạn phạt"];

                    if (ngayhethan.Date < DateTime.Now.Date)
                    {
                        //dg = new DOCGIA();
                        string madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                        //dg.madocgia = dt.Rows[i]["Mã độc giả"].ToString();
                        dg = dataDocGia.timDocGia(madocgia);
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
        }

        void updateAll()//cập nhật tất cả
        {
            updateDgvMuonTraSach();
            updateDgvViPham();
            updateDgvDangKyCho();
            updateDgvSach();
            checkDocGia();
        }

        #endregion

        private void customSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            int a = int.Parse(e.CellValue1.ToString());
            int b = int.Parse(e.CellValue2.ToString());

            // If the cell value is already an integer, just cast it instead of parsing

            e.SortResult = a.CompareTo(b);

            e.Handled = true;
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            //Suppose your interested column has index 1
            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }
        }

        private void dataGridView2_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = 1;
                }
                else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = -1;
                }
                else
                {
                    e.SortResult = 0;
                }
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataProvider.openConnect();
            updateAll();
            ToolTip setting = new ToolTip();
            setting.SetToolTip(btnsetting, "Cài đặt");
            ToolTip thongke = new ToolTip();
            thongke.SetToolTip(btnthongke, "Thống kê");
            ToolTip matkhau = new ToolTip();
            matkhau.SetToolTip(btnmatkhau, "Đổi mật khẩu");
            ToolTip xuatkhau = new ToolTip();
            xuatkhau.SetToolTip(btnexport, "Xuất dữ liệu");
            ToolTip nhapkhau = new ToolTip();
            nhapkhau.SetToolTip(btnimport, "Nhập dữ liệu");
            ToolTip ktKhoaTheDg = new ToolTip();
            ktKhoaTheDg.SetToolTip(btnblock, "Kiểm tra khóa thẻ");

            //dgvdocgia.Columns[0].ValueType = typeof(double);
            //dgvdocgia.Columns[0].DefaultCellStyle.Format = double;
            //dgvdocgia.SortCompare += new DataGridViewSortCompareEventHandler(dataGridView2_SortCompare);
            //dgvcuonsach.SortCompare += new DataGridViewSortCompareEventHandler(dataGridView1_SortCompare);
        }

        #region Độc giả
        private void btnthemdg_Click(object sender, EventArgs e)
        {
            ThemDocGia formThemDG = new ThemDocGia();
            formThemDG.OnAdd += new ThemDocGia.OnAddHandler(checkDocGia);
            formThemDG.ShowDialog();
        }

        private void btnxoadg_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult delete = MessageBox.Show("Do you really want to delete?", "Exit", MessageBoxButtons.YesNo);
                if (delete == DialogResult.No)
                    return;

                if (tcdocgia.SelectedTabIndex == 0)//xóa theo tab độc giả
                {
                    if (dgvdocgia.SelectedRows.Count == 0)
                        return;

                    string madocgia = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();
                    dataDocGia.xoaDocGia(madocgia);
                    dataDocGia.xoaNhanVien(madocgia);
                    dataDocGia.xoaHocSinh(madocgia);
                    ViPham dataViPham = new ViPham();
                    dataViPham.xoaViPham(madocgia);
                    updateDgvDocGia();
                }
                else if (tcdocgia.SelectedTabIndex == 1)//xóa theo tab học sinh
                {
                    if (dgvhocsinh.SelectedRows.Count == 0)
                        return;

                    string madocgia = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
                    dataDocGia.xoaDocGia(madocgia);
                    dataDocGia.xoaHocSinh(madocgia);
                    ViPham dataViPham = new ViPham();
                    dataViPham.xoaViPham(madocgia);
                    updateDgvDocGia();

                }
                else if (tcdocgia.SelectedTabIndex == 2)//xóa theo tab nhân viên
                {
                    if (dgvnhanvien.SelectedRows.Count == 0)
                        return;
                    string madocgia = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
                    dataDocGia.xoaDocGia(madocgia);
                    dataDocGia.xoaNhanVien(madocgia);                 
                    ViPham dataViPham = new ViPham();
                    dataViPham.xoaViPham(madocgia);
                    updateDgvDocGia();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Có liên kết dữ liệu, không thể xóa!");
            }
            /*catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Có liên kết dữ liệu, không thể xóa!");
            }*/           
        }

        private void btnsuadg_Click(object sender, EventArgs e)
        {
            if (tcdocgia.SelectedTabIndex == 0)//sửa theo tab độc giả
            {
                if (dgvdocgia.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(checkDocGia);
                SuaDocGia.mdg = dgvdocgia.SelectedRows[0].Cells[0].Value.ToString();              
                formSuaDG.ShowDialog();
            }
            else if (tcdocgia.SelectedTabIndex == 1)//sửa theo tab học sinh
            {
                if (dgvhocsinh.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(checkDocGia);
                SuaDocGia.mdg = dgvhocsinh.SelectedRows[0].Cells[0].Value.ToString();
                formSuaDG.ShowDialog();

            }
            else if (tcdocgia.SelectedTabIndex == 2)//sửa theo tab nhân viên
            {
                if (dgvnhanvien.SelectedRows.Count == 0)
                    return;
                SuaDocGia formSuaDG = new SuaDocGia();
                formSuaDG.OnUpdate += new SuaDocGia.OnUpdateHandler(checkDocGia);
                SuaDocGia.mdg = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
                formSuaDG.ShowDialog();
            }
            else if (tcdocgia.SelectedTabIndex == 3)
            {
                if (dgvvipham.SelectedRows.Count == 0)
                    return;
                SuaViPham formSuaVP = new SuaViPham();
                SuaViPham.madocgia = dgvvipham.SelectedRows[0].Cells[0].Value.ToString();
                //formSuaVP.OnUpdate += new SuaViPham.OnUpdateHandler(updateDgvViPham);
                formSuaVP.OnUpdate += new SuaViPham.OnUpdateHandler(checkDocGia);
                formSuaVP.ShowDialog();
            }
            
        }

        private void btntimdg_Click(object sender, EventArgs e)
        {
            TimDocGia formTimDG = new TimDocGia();
            formTimDG.ShowDialog();
        }

        private void btnthemlop_Click(object sender, EventArgs e)
        {
            Lop formLop = new Lop();
            formLop.ShowDialog();
        }

        #endregion

        #region Sách
        private void btnthemsach_Click(object sender, EventArgs e)
        {
            ThemSach formThemSach = new ThemSach();
            formThemSach.OnAddBook += new ThemSach.OnAddBookHandler(updateDgvSach);
            formThemSach.ShowDialog();
        }

        private void btnsuasach_Click(object sender, EventArgs e)
        {
            SuaSach formSuaSach = new SuaSach();
            formSuaSach.OnUpdateBook += new SuaSach.OnUpdateBookHandler(updateDgvSach);
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
            try
            {
                DialogResult delete = MessageBox.Show("Do you really want to delete?", "Exit", MessageBoxButtons.YesNo);
                if (delete == DialogResult.No)
                    return;

                if (tcsach.SelectedTabIndex == 0)//xóa theo tab tựa sách
                {
                    if (dgvtuasach.SelectedRows.Count == 0)
                        return;
                    
                    string matuasach = dgvtuasach.SelectedRows[0].Cells[0].Value.ToString();
                    dataSach.xoaTuaSach(matuasach);
                    updateDgvSach();

                }
                else if (tcsach.SelectedTabIndex == 1)//xóa theo tab đầu sách
                {
                    if (dgvdausach.SelectedRows.Count == 0)
                        return;

                    string madausach = dgvdausach.SelectedRows[0].Cells[0].Value.ToString();
                    dataSach.xoaDauSach(madausach);

                    updateDgvSach();

                }
                else if (tcsach.SelectedTabIndex == 2)//xóa theo tab cuốn sách
                {
                    if (dgvcuonsach.SelectedRows.Count == 0)
                        return;
                    string macuonsach = dgvcuonsach.SelectedRows[0].Cells[0].Value.ToString();
                    dataSach.xoaCuonSach(macuonsach);
                    updateDgvSach();

                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Có liên kết dữ liệu, không thể xóa!");
            }
        }

        private void btntimsach_Click(object sender, EventArgs e)
        {
            TimSach formTimSach = new TimSach();
            formTimSach.ShowDialog();
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
            formSua.OnUpdateBackBook += new SuaMuonTraSach.OnUpdateBackBookHandler(updateDgvMuonTraSach);
            formSua.ShowDialog();
        }

        private void btntimmuon_Click(object sender, EventArgs e)
        {
            TimThemMuonSach formTimMuon = new TimThemMuonSach();
            formTimMuon.ShowDialog();
        }

        #endregion
     
        #region Đăng ký chờ mượn sách
        private void btnchomuon_Click(object sender, EventArgs e)
        {
            ThemDangKyCho formCho = new ThemDangKyCho();
            formCho.OnSign += new ThemDangKyCho.OnSignHandler(updateDgvDangKyCho);
            formCho.ShowDialog();
        }

        private void btnsuacho_Click(object sender, EventArgs e)
        {
            SuaDangKyCho formSua = new SuaDangKyCho();
            formSua.OnUpdate += new SuaDangKyCho.OnUpdateHandler(updateDgvDangKyCho);
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
            inf = dataDangKy.timDangKyCho(inf);
            if (inf.tinhtrang == true)
            {
                MessageBox.Show("Đã đánh dấu trước đó!");
            }
            else
            {
                inf.tinhtrang = true;
                dataDangKy.suaDangKyCho(inf, inf);
                dgvchomuonsach.DataSource = dataDangKy.loadDangKyCho();
                MessageBox.Show("Đã đánh dấu!");
            }
            
        }
        private void btntimcho_Click(object sender, EventArgs e)
        {
            TimDangKyCho formTimDKCho = new TimDangKyCho();
            formTimDKCho.ShowDialog();
        }

        #endregion

        #region menu button
        private void btnsetting_Click(object sender, EventArgs e)
        {
            Setting formSetting = new Setting();
            formSetting.OnUpdateThamSo += new Setting.OnUpdateThamSoHandler(checkDocGia);
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

        private void btnblock_Click(object sender, EventArgs e)
        {
            checkDocGia();
        }

        private void btnmatkhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau formSuaMK = new DoiMatKhau();
            formSuaMK.ShowDialog();
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            NhapXuatDuLieu xuatDL = new NhapXuatDuLieu();
            xuatDL.xuatDuLieu();
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            NhapXuatDuLieu nhapDL = new NhapXuatDuLieu();
            nhapDL.OnImport += new NhapXuatDuLieu.OnImportHandler(updateAll);
            nhapDL.NhapDuLieu();
        }
        #endregion

        #region delete all
        private void btndelallcho_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Bạn có thực muốn xóa hết dữ liệu này?", "Exit", MessageBoxButtons.YesNo);
            if (delete == DialogResult.No)
                return;

            dataDangKy.xoaTatCa();
            updateDgvDangKyCho();
        }

        private void btndelallmuon_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Bạn có thực muốn xóa hết dữ liệu này?", "Exit", MessageBoxButtons.YesNo);
            if (delete == DialogResult.No)
                return;
            dataMuonTraSach.xoaTatCa();
            updateDgvMuonTraSach();
        }

        private void btndelallsach_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult delete = MessageBox.Show("Bạn có thực muốn xóa hết dữ liệu này?", "Exit", MessageBoxButtons.YesNo);
                if (delete == DialogResult.No)
                    return;
                dataSach.xoaTatCa();
                updateDgvSach();
            }
            catch(SqlException)
            {
                MessageBox.Show("Có ràng buộc dữ liệu, không thể xóa!");
            }
            
        }

        private void btndelalldg_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult delete = MessageBox.Show("Bạn có thực muốn xóa hết dữ liệu này?", "Exit", MessageBoxButtons.YesNo);
                if (delete == DialogResult.No)
                    return;
                dataDocGia.xoaTatCa();
                ViPham dataViPham = new ViPham();
                dataViPham.xoaTatCa();

                updateDgvDocGia();
            }
            catch (SqlException)
            {
                MessageBox.Show("Có ràng buộc dữ liệu, không thể xóa!");
            }
        }
        #endregion

        private void tcdocgia_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            if (tcdocgia.SelectedTabIndex == 3)
            {
                btndelalldg.Enabled = false;
                btnxoadg.Enabled = false;
            }
            else
            {
                btndelalldg.Enabled = true;
                btnxoadg.Enabled = true;
            }
        }


    }
}
