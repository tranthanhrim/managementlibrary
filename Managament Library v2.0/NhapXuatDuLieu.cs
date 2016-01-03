using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.CTL;
using Excel = Microsoft.Office.Interop.Excel;

namespace Managament_Library_v2._0
{
    public class NhapXuatDuLieu
    {
        public delegate void OnImportHandler();
        public event OnImportHandler OnImport;

        void noticeImport()
        {
            if (OnImport != null)
                OnImport();
        }

        void setDataToSheet(Excel.Worksheet sheet, DataTable data)
        {
            for (int i = 0; i < data.Columns.Count; i++)
                sheet.Cells[1, i + 1] = data.Columns[i].ColumnName;

            for (int i = 0; i < data.Rows.Count; i++)
                for (int j = 0; j < data.Columns.Count; j++)
                    sheet.Cells[i + 2, j + 1] = data.Rows[i].ItemArray[j].ToString();
        }

        public void xuatDuLieu()
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = ("Excel file (*.xls; *.xlsx; *.xlsm; *.xlsb)|*.xls");
            saveFile.ShowDialog();

            if (saveFile.FileName == String.Empty)
            {
                return;
            }

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet sheetDocGia, sheetHocSinh, sheetNhanVien, sheetViPham;
            Excel.Worksheet sheetTuaSach, sheetDauSach, sheetCuonSach;
            Excel.Worksheet sheetMuonSach;
            Excel.Worksheet sheetDkChoMuon;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);   
      
            //docgia = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //docgia.Name = "Độc giả";

            sheetMuonSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetMuonSach.Name = "Mượn sách";

            sheetDkChoMuon = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            sheetDkChoMuon.Name = "ĐK chờ mượn";

            //SqlDataAdapter da = new SqlDataAdapter("select* from DOCGIA", DataProvider.con);
            //DataSet ds = new DataSet();          
            //da.Fill(ds);
            //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            //    {
            //        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
            //        docgia.Cells[i + 1, j + 1] = data;
            //    }
            //}

            DataTable dtMuonSach = DataProvider.getDataTable("select* from MUONSACH");

            DataTable dtDkChoMuon = DataProvider.getDataTable("select* from DKCHOMUON");

            setDataToSheet(sheetMuonSach, dtMuonSach);
            setDataToSheet(sheetDkChoMuon, dtDkChoMuon);

            xlWorkBook.Worksheets.Add();
            sheetCuonSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetCuonSach.Name = "Cuốn sách";

            xlWorkBook.Worksheets.Add();
            sheetDauSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetDauSach.Name = "Đầu sách";

            xlWorkBook.Worksheets.Add();
            sheetTuaSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetTuaSach.Name = "Tựa sách";

            xlWorkBook.Worksheets.Add();
            sheetViPham = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetViPham.Name = "Vi phạm";

            xlWorkBook.Worksheets.Add();
            sheetNhanVien = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetNhanVien.Name = "Nhân viên";

            xlWorkBook.Worksheets.Add();
            sheetHocSinh = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetHocSinh.Name = "Học sinh";

            xlWorkBook.Worksheets.Add();
            sheetDocGia = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheetDocGia.Name = "Độc giả";


            DataTable dtDocGia = DataProvider.getDataTable("select* from DOCGIA");
            setDataToSheet(sheetDocGia, dtDocGia);

            DataTable dtHocSinh = DataProvider.getDataTable("select* from HOCSINH");
            setDataToSheet(sheetHocSinh, dtHocSinh);

            DataTable dtNhanVien = DataProvider.getDataTable("select* from NHANVIEN");
            setDataToSheet(sheetNhanVien, dtNhanVien);

            DataTable dtViPham = DataProvider.getDataTable("select* from VIPHAM");
            setDataToSheet(sheetViPham, dtViPham);

            DataTable dtTuaSach = DataProvider.getDataTable("select* from TUASACH");
            setDataToSheet(sheetTuaSach, dtTuaSach);

            DataTable dtDauSach = DataProvider.getDataTable("select* from DAUSACH");
            setDataToSheet(sheetDauSach, dtDauSach);

            DataTable dtCuonSach = DataProvider.getDataTable("select* from CUONSACH");
            setDataToSheet(sheetCuonSach, dtCuonSach);


            xlWorkBook.SaveAs(saveFile.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();


            /*releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);*/

            MessageBox.Show("Hoàn thành!");

        }

        public void NhapDuLieu()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel file (*.xls; *.xlsx; *.xlsm; *.xlsb)|*.xls";
            openFile.ShowDialog();

            if (openFile.FileName == String.Empty)
                return;


            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Worksheet sheetDocGia, sheetHocSinh, sheetNhanVien, sheetViPham;
            Excel.Worksheet sheetTuaSach, sheetDauSach, sheetCuonSach;
            Excel.Worksheet sheetMuonSach;
            Excel.Worksheet sheetDkChoMuon;
            Excel.Range rangeDocGia;

            string str;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(openFile.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            sheetDocGia = xlWorkBook.Sheets["Độc giả"] as Excel.Worksheet;
            sheetHocSinh = xlWorkBook.Sheets["Học sinh"] as Excel.Worksheet;
            sheetNhanVien = xlWorkBook.Sheets["Nhân viên"] as Excel.Worksheet;
            sheetViPham = xlWorkBook.Sheets["Vi phạm"] as Excel.Worksheet;
            sheetTuaSach = xlWorkBook.Sheets["Tựa sách"] as Excel.Worksheet;
            sheetDauSach = xlWorkBook.Sheets["Đầu sách"] as Excel.Worksheet;
            sheetCuonSach = xlWorkBook.Sheets["Cuốn sách"] as Excel.Worksheet;
            sheetMuonSach = xlWorkBook.Sheets["Mượn sách"] as Excel.Worksheet;
            sheetDkChoMuon = xlWorkBook.Sheets["ĐK chờ mượn"] as Excel.Worksheet;
            //sheetDocGia = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            /*sheetHocSinh = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            sheetNhanVien = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
            sheetViPham = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(4);
            sheetTuaSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(5);
            sheetDauSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(6);
            sheetCuonSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(7);
            sheetMuonSach = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(8);
            sheetDkChoMuon = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(9);*/

            //range = xlWorkSheet.UsedRange;

            //for (int rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            //{
            //    for (int cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
            //    {
            //        str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
            //        MessageBox.Show(str);
            //    }
            //}

            //rangeDocGia = sheetDocGia.UsedRange;

            //if ((sheetDocGia.Cells[2, 6] as Excel.Range).Value == false)
            //    MessageBox.Show("false");
            //MessageBox.Show(Convert.ToString((sheetDocGia.Cells[2,6] as Excel.Range).Value));

            DangKyCho dataDkCho = new DangKyCho();
            MuonTraSach dataMuonSach = new MuonTraSach();
            Sach dataSach = new Sach();
            DocGia dataDocGia = new DocGia();
            ViPham dataViPham = new ViPham();
            dataDkCho.xoaTatCa();
            dataMuonSach.xoaTatCa();
            dataSach.xoaTatCa();
            dataViPham.xoaTatCa();
            dataDocGia.xoaTatCa();
            //Excel.Range rangeDkChoMuon = sheetDkChoMuon.UsedRange;

            DOCGIA dg;
            for (int i = 2; i <= sheetDocGia.UsedRange.Rows.Count; i++)
            {
                dg = new DOCGIA();
                dg.madocgia = Convert.ToString((sheetDocGia.Cells[i, 1] as Excel.Range).Value);
                dg.hoten = Convert.ToString((sheetDocGia.Cells[i, 2] as Excel.Range).Value);
                dg.gioitinh = Convert.ToString((sheetDocGia.Cells[i, 3] as Excel.Range).Value);
                String date = Convert.ToString((sheetDocGia.Cells[i, 4] as Excel.Range).Value);
                if (date != null)
                    dg.ngaysinh = DateTime.Parse(date);
                String date1 = Convert.ToString((sheetDocGia.Cells[i, 5] as Excel.Range).Value);
                if (date1 != null)
                    dg.ngaylap = DateTime.Parse(date1);
                dg.tinhtrang = (bool)(sheetDocGia.Cells[i, 6] as Excel.Range).Value;
                dataDocGia.themDocGia(dg);
            }

            HOCSINH hs;
            for (int i = 2; i <= sheetHocSinh.UsedRange.Rows.Count; i++)
            {
                hs = new HOCSINH();
                hs.madocgia = Convert.ToString((sheetHocSinh.Cells[i, 1] as Excel.Range).Value);
                hs.lop = Convert.ToString((sheetHocSinh.Cells[i, 2] as Excel.Range).Value);
                dataDocGia.themHocSinh(hs);
            }

            NHANVIEN nv;
            for (int i = 2; i <= sheetNhanVien.UsedRange.Rows.Count; i++)
            {
                nv = new NHANVIEN();
                nv.madocgia = Convert.ToString((sheetNhanVien.Cells[i, 1] as Excel.Range).Value);
                dataDocGia.themNhanVien(nv);
            }

            VIPHAM vp;
            for (int i = 2; i <= sheetViPham.UsedRange.Rows.Count; i++)
            {
                vp = new VIPHAM();
                vp.madocgia = Convert.ToString((sheetViPham.Cells[i, 1] as Excel.Range).Value);
                vp.vipham1 = Convert.ToInt32((sheetViPham.Cells[i, 2] as Excel.Range).Value);
                String date = Convert.ToString((sheetViPham.Cells[i, 3] as Excel.Range).Value);
                if (date != null)
                    vp.ngayhethan = DateTime.Parse(date);
                dataViPham.themViPham(vp);
            }

            TUASACH ts;
            for (int i = 2; i <= sheetTuaSach.UsedRange.Rows.Count; i++)
            {
                ts = new TUASACH();
                ts.matuasach = Convert.ToString((sheetTuaSach.Cells[i, 1] as Excel.Range).Value);
                ts.tentuasach = Convert.ToString((sheetTuaSach.Cells[i, 2] as Excel.Range).Value);
                ts.tacgia = Convert.ToString((sheetTuaSach.Cells[i, 3] as Excel.Range).Value);
                ts.gioithieu = Convert.ToString((sheetTuaSach.Cells[i, 4] as Excel.Range).Value);
                dataSach.themTuaSach(ts);
            }

            DAUSACH ds;
            for (int i = 2; i <= sheetDauSach.UsedRange.Rows.Count; i++)
            {
                ds = new DAUSACH();
                ds.madausach = Convert.ToString((sheetDauSach.Cells[i, 1] as Excel.Range).Value);
                ds.matuasach = Convert.ToString((sheetDauSach.Cells[i, 2] as Excel.Range).Value);
                ds.ngonngu = Convert.ToString((sheetDauSach.Cells[i, 3] as Excel.Range).Value);
                ds.tinhtrang = (bool)(sheetDauSach.Cells[i, 4] as Excel.Range).Value;
                dataSach.themDauSach(ds);
            }

            CUONSACH cs;
            for (int i = 2; i <= sheetCuonSach.UsedRange.Rows.Count; i++)
            {
                cs = new CUONSACH();
                cs.macuonsach = Convert.ToString((sheetCuonSach.Cells[i, 1] as Excel.Range).Value);
                cs.madausach = Convert.ToString((sheetCuonSach.Cells[i, 2] as Excel.Range).Value);
                cs.tinhtrang = (bool)(sheetCuonSach.Cells[i, 3] as Excel.Range).Value;
                dataSach.themCuonSach(cs);
            }

            DKCHOMUON dk;
            for (int i = 2; i <= sheetDkChoMuon.UsedRange.Rows.Count; i++)
            {
                dk = new DKCHOMUON();
                dk.madocgia = Convert.ToString((sheetDkChoMuon.Cells[i, 1] as Excel.Range).Value);
                dk.madausach = Convert.ToString((sheetDkChoMuon.Cells[i, 2] as Excel.Range).Value);
                String date = Convert.ToString((sheetDkChoMuon.Cells[i, 3] as Excel.Range).Value);
                if (date != null)
                    dk.ngaygiodk = DateTime.Parse(date);
                dk.tinhtrang = (bool)(sheetDkChoMuon.Cells[i, 4] as Excel.Range).Value;
                dataDkCho.themDangKyCho(dk);
            }

            
            
            MUONSACH ms;
            for (int i = 2; i <= sheetMuonSach.UsedRange.Rows.Count; i++)
            {
                ms = new MUONSACH();
                ms.madocgia = Convert.ToString((sheetMuonSach.Cells[i, 1] as Excel.Range).Value);
                ms.macuonsach = Convert.ToString((sheetMuonSach.Cells[i, 2] as Excel.Range).Value);
                String date = Convert.ToString((sheetMuonSach.Cells[i, 3] as Excel.Range).Value);
                if (date != null)
                    ms.ngaygiomuon = DateTime.Parse(date);
                String date1 = Convert.ToString((sheetMuonSach.Cells[i, 4] as Excel.Range).Value);
                if (date1 != null)
                    ms.ngayhethan = DateTime.Parse(date1);
                String date2 = Convert.ToString((sheetMuonSach.Cells[i, 5] as Excel.Range).Value);
                if (date2 != null)
                    ms.ngaygiotra = DateTime.Parse(date2);
                dataMuonSach.themMuonTraSach(ms);
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            MessageBox.Show("Hoàn thành!");
            noticeImport();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        } 
    }
}
