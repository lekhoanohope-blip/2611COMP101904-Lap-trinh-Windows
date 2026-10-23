using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Views;

namespace Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmStudent());
        }
    }
}