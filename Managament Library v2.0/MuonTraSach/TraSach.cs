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
    public partial class TraSach : Form
    {
        public TraSach()
        {
            InitializeComponent();
        }

        public delegate void OnBackBookHandler(string macuonsach);
        public event OnBackBookHandler OnBackBook;

        public delegate void OnIllegalHandler(string madocgia);
        public event OnIllegalHandler OnIllegal;

        void notiveBackBook(string macuonsach)
        {
            if (OnBackBook != null)
                OnBackBook(macuonsach);
        }

        void noticeIllegal(string madocgia)
        {
            if (OnIllegal != null)
                OnIllegal(madocgia);
        }

        public static MUONSACH inf = new MUONSACH();
        MUONSACH temp;

        MuonTraSach data = new MuonTraSach();

        private void TraSach_Load(object sender, EventArgs e)
        {
            temp = data.timMuonTraSach(inf);
            txtmdg.Text = temp.madocgia;
            txtmacuonsach.Text = temp.macuonsach;
            dtngaygiomuon.Value = temp.ngaygiomuon;            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            temp.ngaygiotra = dtngaygiotra.Value.Date;
            data.suaMuonTraSach(temp, temp);

            if (temp.ngaygiotra > temp.ngayhethan)
            {
                noticeIllegal(temp.madocgia);
            }

            MessageBox.Show("Đã lưu!");
            Close();
            OnBackBook(temp.macuonsach);
        }
    }
}
