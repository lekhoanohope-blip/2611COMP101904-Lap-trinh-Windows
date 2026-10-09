using System;

namespace ProductManager
{
    /// <summary>Lớp lưu thông tin 1 sản phẩm.</summary>
    public class Product
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public bool ConKinhDoanh { get; set; }
        public string HinhAnh { get; set; } = "";   // đường dẫn ảnh (mở rộng)
    }
}