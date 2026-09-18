using System;

namespace LAB03___QUẢN_LÝ_SINH_VIÊN 
{
    public class Nguoi
    {
        public string? HoTen { get; set; }
        public string? NgaySinh { get; set; }

        public Nguoi() { }

        public Nguoi(string hoTen, string ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual string LayThongTin()
        {
            return $"Họ tên: {HoTen}, Ngày sinh: {NgaySinh}";
        }
    }
}