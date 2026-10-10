using System;
using System.Windows.Forms;
using ShopManagerMini.Forms;

namespace ShopManagerMini
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Bước 1: mở Form đăng nhập dưới dạng hộp thoại
            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Bước 2: đăng nhập thành công -> mở Form chính, truyền user qua constructor
                    Application.Run(new FrmMain(login.CurrentUser));
                }
            }
        }
    }
}