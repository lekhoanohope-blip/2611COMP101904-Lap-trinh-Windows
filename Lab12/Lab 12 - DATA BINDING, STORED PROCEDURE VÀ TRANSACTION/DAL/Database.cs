namespace QLSinhVienLab12.DAL
{
    public static class Database
    {
        // Đổi Data Source cho đúng máy thực hành
        public static string ConnectionString { get; set; } =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True";
    }
}