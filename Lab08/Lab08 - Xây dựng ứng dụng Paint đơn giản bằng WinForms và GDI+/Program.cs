using COMP1019_Lab08_SimplePaint;

namespace Lab08___Xây_dựng_ứng_dụng_Paint_đơn_giản_bằng_WinForms_và_GDI_
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}