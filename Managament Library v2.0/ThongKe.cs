using System;
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
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        public DataTable thongKeDsMuonNhieu()
        {
            SqlDataAdapter da = new SqlDataAdapter("select cs.madausach, ts.tentuasach, count(*) as solanmuon from ((MUONSACH ms join CUONSACH cs on ms.macuonsach = cs.macuonsach) join DAUSACH ds on cs.madausach = ds.madausach) join TUASACH ts on ds.matuasach = ts.matuasach group by cs.madausach, ts.tentuasach order by solanmuon desc", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["solanmuon"].ColumnName = "Số lần mượn";
            dt.Columns["tentuasach"].ColumnName = "Tên Tựa sách";
            return dt;
        }

        public DataTable thongKeDsChoMuon()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ds.madausach, ts.tentuasach from (DKCHOMUON dk join DAUSACH ds on dk.madausach = ds.madausach) join TUASACH ts on ds.matuasach = ts.matuasach where dk.tinhtrang != 1 group by ds.madausach, ts.tentuasach", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["tentuasach"].ColumnName = "Tên tựa sách";
            return dt;
        }

        public DataTable thongKeDocGiaHetHan()
        {
            DocGia dataDocGia = new DocGia();
            DataTable dt = dataDocGia.loadDocGia();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["Tình trạng"] == true)
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }                 
            }
            return dt;
        }

        public DataTable thongKeDocGiaTreHen()
        {
            SqlDataAdapter da = new SqlDataAdapter("select dg.madocgia, dg.hoten, hs.lop from (MUONSACH ms join DOCGIA dg on ms.madocgia = dg.madocgia) left join HOCSINH hs on dg.madocgia = hs.madocgia where ms.ngayhethan < GETDATE() and ms.ngaygiotra is null", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madocgia"].ColumnName = "Mã độc giả";
            dt.Columns["hoten"].ColumnName = "Họ tên";
            dt.Columns["lop"].ColumnName = "Lớp";
            return dt;
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            dgvdausachmuonnhieu.DataSource = thongKeDsMuonNhieu();
            dgvdausachchomuon.DataSource = thongKeDsChoMuon();
            dgvdocgiahethan.DataSource = thongKeDocGiaHetHan();
            dgvdocgiatrehen.DataSource = thongKeDocGiaTreHen();
        }
    }
}
