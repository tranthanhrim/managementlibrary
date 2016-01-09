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
    public partial class ThemMuonTraSach : Form
    {
        public ThemMuonTraSach()
        {
            InitializeComponent();
        }

        public delegate void OnBorrowBookHanlder(string macuonsach);
        public event OnBorrowBookHanlder OnBorrowBook;

        void noticeBorrowBook(string macuonsach)
        {
            if (OnBorrowBook != null)
                OnBorrowBook(macuonsach);
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }

        MuonTraSach data = new MuonTraSach();
        DocGia dataDocGia = new DocGia();
        Sach dataSach = new Sach();
        MUONSACH inf;

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxmdg.SelectedItem == null || cbxmacuonsach.SelectedItem == null)
                    throw new ArgumentNullException();

                inf = new MUONSACH();
                inf.madocgia = cbxmdg.SelectedItem.ToString();
                inf.macuonsach = cbxmacuonsach.SelectedItem.ToString();
                inf.ngaygiomuon = dtngaygiomuon.Value;

                int result = data.themMuonTraSach(inf);
                if (result == 0)
                {
                    MessageBox.Show("Mượn sách vượt quá số lượng cho phép!");
                }
                else if (result == -1)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!");
                }
                else
                {
                    MessageBox.Show("Đã thêm!");
                    Close();
                    noticeBorrowBook(inf.macuonsach);
                }          
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
            }
        }

        private void ThemMuonTraSach_Load(object sender, EventArgs e)
        {
            DataTable dtDocGia = dataDocGia.loadDocGia();
            DataTable dtCuonSach = dataSach.loadCuonSach();

            for (int i = 0; i < dtDocGia.Rows.Count; i++)
            {
                if (dtDocGia.Rows[i]["Tình trạng"].ToString() != String.Empty && (bool)dtDocGia.Rows[i]["Tình trạng"] == true)//== String.Empty
                    cbxmdg.Items.Add(Convert.ToInt32(dtDocGia.Rows[i]["Mã độc giả"].ToString()));            
            }

            for (int i = 0; i < dtCuonSach.Rows.Count; i++)
            {
                if (dtCuonSach.Rows[i]["Tình trạng"].ToString() != String.Empty && (bool)dtCuonSach.Rows[i]["Tình trạng"] == true)
                    cbxmacuonsach.Items.Add(Convert.ToInt32(dtCuonSach.Rows[i]["Mã cuốn sách"].ToString()));
            }

            if (cbxmdg.Items.Count > 0)
                cbxmdg.SelectedIndex = 0;
            if (cbxmacuonsach.Items.Count > 0)
                cbxmacuonsach.SelectedIndex = 0;
        }
    }
}
