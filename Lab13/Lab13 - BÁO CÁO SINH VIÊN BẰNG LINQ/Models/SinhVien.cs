namespace StudentReportDemo.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public double Diem { get; set; }

        // Thuộc tính chỉ đọc, tự tính từ Diem -> tránh sai lệch dữ liệu
        public string KetQua => Diem >= 5 ? "Đạt" : "Không đạt";
    }
}