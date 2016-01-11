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
    public partial class SuaMuonTraSach : Form
    {
        public SuaMuonTraSach()
        {
            InitializeComponent();
        }

        public delegate void OnUpdateBackBookHandler();
        public event OnUpdateBackBookHandler OnUpdateBackBook;

        void noticeUpdateBackBook()
        {
            if (OnUpdateBackBook != null)
                OnUpdateBackBook();
        }

        public static MUONSACH inf = new MUONSACH();
        MUONSACH temp;

        MuonTraSach data = new MuonTraSach();
        ThamSo dataThamSo = new ThamSo();
        private void SuaMuonTraSach_Load(object sender, EventArgs e)
        {
            temp = data.timMuonTraSach(inf);

            Sach dataSach = new Sach();
            DocGia dataDocGia = new DocGia();

            DataTable dtDocGia = dataDocGia.loadDocGia();
            DataTable dtCuonSach = dataSach.loadCuonSach();

            for (int i = 0; i < dtDocGia.Rows.Count; i++)
            {
                //if (dtDocGia.Rows[i]["Tình trạng"].ToString() != String.Empty && (bool)dtDocGia.Rows[i]["Tình trạng"] == true)//== String.Empty
                string mdg = dtDocGia.Rows[i]["Mã độc giả"].ToString();
                cbxmdg.Items.Add(mdg);
                if (temp.madocgia == mdg)
                    cbxmdg.SelectedIndex = i;
            }

            for (int i = 0; i < dtCuonSach.Rows.Count; i++)
            {
                string macuonsach = dtCuonSach.Rows[i]["Mã cuốn sách"].ToString();
                cbxmacuonsach.Items.Add(macuonsach);
                if (temp.macuonsach == macuonsach)
                    cbxmacuonsach.SelectedIndex = i;
            }


            dtngaygiomuon.Value = temp.ngaygiomuon;

            if (temp.ngaygiotra != null)
            {
                dtngaygiotra.Value = (DateTime)temp.ngaygiotra;
            }
            else
            {
                dtngaygiotra.Enabled = false;
            }
        }


        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                THAMSO songaymuon = new THAMSO();
                songaymuon.tenthamso = "songaymuon";
                songaymuon = dataThamSo.timThamSo(songaymuon);

                MUONSACH after = new MUONSACH();
                if (cbxmdg.SelectedItem != null)
                    after.madocgia = cbxmdg.SelectedItem.ToString();
                if (cbxmacuonsach.SelectedItem != null)
                    after.macuonsach = cbxmacuonsach.SelectedItem.ToString();
                after.ngaygiomuon = dtngaygiomuon.Value;
                after.ngayhethan = after.ngaygiomuon.Date.AddDays(Convert.ToInt32(songaymuon.giatri));
                if (dtngaygiotra.Enabled == true)
                    after.ngaygiotra = dtngaygiotra.Value.Date;
                data.suaMuonTraSach(temp, after);
                MessageBox.Show("Đã lưu!");
                noticeUpdateBackBook();
                Close();
            }
            catch(SqlException)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
            }
        }
    }
}
