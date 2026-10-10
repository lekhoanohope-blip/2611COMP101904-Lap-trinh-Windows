using System.ComponentModel;

namespace ShopManagerMini.Models
{
    /// <summary>
    /// Thông tin một khách hàng.
    /// </summary>
    public class Customer
    {
        [DisplayName("Mã khách hàng")]
        public string MaKH { get; set; }

        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [DisplayName("Số điện thoại")]
        public string DienThoai { get; set; }

        [DisplayName("Loại khách hàng")]
        public string LoaiKH { get; set; }

        public Customer() { }

        public Customer(string maKH, string hoTen, string dienThoai, string loaiKH)
        {
            MaKH = maKH;
            HoTen = hoTen;
            DienThoai = dienThoai;
            LoaiKH = loaiKH;
        }
    }
}