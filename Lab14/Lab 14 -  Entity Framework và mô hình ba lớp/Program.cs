using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.GUI;

namespace Lab_14____Entity_Framework_và_mô_hình_ba_lớp
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
            Application.Run(new FrmMonHoc());
        }
    }
}