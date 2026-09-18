using System;

namespace LAB03___QUẢN_LÝ_SINH_VIÊN
{
    public class SinhVien : Nguoi
    {
        public string? MaSinhVien { get; set; }
        private double _diemTrungBinh;

        public double DiemTrungBinh
        {
            get => _diemTrungBinh;
            set
            {
                if (value >= 0 && value <= 10)
                    _diemTrungBinh = value;
                else
                    throw new ArgumentOutOfRangeException("Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");
            }
        }

        public string? MaLop { get; set; }

        public SinhVien() { }

        public SinhVien(string maSinhVien, string hoTen, string ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.0) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5.0) return "Trung bình";
            return "Yếu";
        }

        public override string LayThongTin()
        {
            return $"Mã SV: {MaSinhVien} | {base.LayThongTin()} | Lớp: {MaLop} | ĐTB: {DiemTrungBinh} | Xếp loại: {XepLoai()}";
        }
    }
}