using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managament_Library_v2._0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            //Application.Run(new DangNhap());

            DangNhap formDangNhap = new DangNhap();
            if (formDangNhap.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }
    }
}
