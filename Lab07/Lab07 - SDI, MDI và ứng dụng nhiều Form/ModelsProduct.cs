using System.ComponentModel;

namespace ShopManagerMini.Models
{
    /// <summary>
    /// Thông tin một sản phẩm trong cửa hàng.
    /// </summary>
    public class Product
    {
        [DisplayName("Mã sản phẩm")]
        public string MaSP { get; set; }

        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }

        [DisplayName("Loại sản phẩm")]
        public string LoaiSP { get; set; }

        [DisplayName("Đơn giá")]
        public decimal DonGia { get; set; }

        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        public Product() { }

        public Product(string maSP, string tenSP, string loaiSP, decimal donGia, int soLuong)
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
            DonGia = donGia;
            SoLuong = soLuong;
        }
    }
}