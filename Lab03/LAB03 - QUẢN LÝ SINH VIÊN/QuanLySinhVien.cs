using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB03___QUẢN_LÝ_SINH_VIÊN
{
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        public bool Them(SinhVien sv)
        {
            if (danhSachSinhVien.Any(s => s.MaSinhVien != null && s.MaSinhVien.Equals(sv.MaSinhVien, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            danhSachSinhVien.Add(sv);
            return true;
        }

        public List<SinhVien> LayDanhSach() => danhSachSinhVien;

        public SinhVien? TimTheoMa(string maSV)
        {
            return danhSachSinhVien.FirstOrDefault(s => s.MaSinhVien != null && s.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string keyword)
        {
            return danhSachSinhVien.Where(s => s.HoTen != null && s.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public bool SuaDiem(string maSV, double diemMoi)
        {
            var sv = TimTheoMa(maSV);
            if (sv != null)
            {
                sv.DiemTrungBinh = diemMoi;
                return true;
            }
            return false;
        }

        public bool Xoa(string maSV)
        {
            var sv = TimTheoMa(maSV);
            if (sv != null)
            {
                danhSachSinhVien.Remove(sv);
                return true;
            }
            return false;
        }

        public void SapXepTheoDiem()
        {
            danhSachSinhVien = danhSachSinhVien.OrderByDescending(s => s.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocSinhVienDat(double diemChuan = 5.0)
        {
            return danhSachSinhVien.Where(s => s.DiemTrungBinh >= diemChuan).ToList();
        }
    }
}