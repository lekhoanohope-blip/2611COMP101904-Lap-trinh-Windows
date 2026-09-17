using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyNhanVien
{
    // Lớp cơ sở NhanVien
    public class NhanVien
    {
        private string maNV;
        private string hoTen;
        private double luongCoBan;

        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string HoTen
        {
            get => hoTen;
            set => hoTen = value;
        }

        public double LuongCoBan
        {
            get => luongCoBan;
            set => luongCoBan = value;
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"[Ma NV: {MaNV}] - Ten: {HoTen} - Luong CB: {LuongCoBan:N0} VND");
        }
    }

    // Lớp NhanVienVanPhong
    public class NhanVienVanPhong : NhanVien
    {
        public int SoNgayLamViec { get; set; }

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * 200000;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"   --> Loai: Van Phong | So ngay lam: {SoNgayLamViec} | Tong Luong: {TinhLuong():N0} VND");
        }
    }

    // Lớp NhanVienKinhDoanh
    public class NhanVienKinhDoanh : NhanVien
    {
        public double DoanhSo { get; set; }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + 0.05 * DoanhSo;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"   --> Loai: Kinh Doanh | Doanh so: {DoanhSo:N0} VND | Tong Luong: {TinhLuong():N0} VND");
        }
    }

    // Lớp Bonus: NhanVienThoiVu
    public class NhanVienThoiVu : NhanVien
    {
        public double SoGioLam { get; set; }
        public double LuongTheoGio { get; set; }

        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 0)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Ma NV: {MaNV}] - Ten: {HoTen}");
            Console.WriteLine($"   --> Loai: Thoi Vu | So gio: {SoGioLam} | Luong/Gio: {LuongTheoGio:N0} VND | Tong Luong: {TinhLuong():N0} VND");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<NhanVien> danhSach = new List<NhanVien>();

            // 1. NHẬP DANH SÁCH NHÂN VIÊN TRƯỚC (ÍT NHẤT 5 NHÂN VIÊN)
            Console.WriteLine("==============================================");
            Console.WriteLine("NHẬP THÔNG TIN BAN ĐẦU (ÍI NHẤT 5 NV)");
            Console.WriteLine("==============================================");

            int soLuong = ReadIntValid("Nhap so luong nhan vien can them (>= 5): ", 5, int.MaxValue);

            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine($"\n--- Nhap thong tin nhan vien thu {i + 1} ---");

                string maNV = ReadStringNonEmpty("Nhap Ma NV: ");
                string hoTen = ReadStringNonEmpty("Nhap Ho Ten: ");

                Console.WriteLine("Chon loai nhan vien: 1. Van Phong | 2. Kinh Doanh | 3. Thoi Vu");
                int loai = ReadIntValid("Lua chon (1-3): ", 1, 3);

                if (loai == 1)
                {
                    double luongCB = ReadDoubleValid("Nhap Luong co ban (> 0): ", 1);
                    int soNgay = ReadIntValid("Nhap So ngay lam việc (0-31): ", 0, 31);
                    danhSach.Add(new NhanVienVanPhong(maNV, hoTen, luongCB, soNgay));
                }
                else if (loai == 2)
                {
                    double luongCB = ReadDoubleValid("Nhap Luong co ban (> 0): ", 1);
                    double doanhSo = ReadDoubleValid("Nhap Doanh so (>= 0): ", 0);
                    danhSach.Add(new NhanVienKinhDoanh(maNV, hoTen, luongCB, doanhSo));
                }
                else if (loai == 3)
                {
                    double soGio = ReadDoubleValid("Nhap So gio lam (>= 0): ", 0);
                    double luongGio = ReadDoubleValid("Nhap Luong theo gio (>= 0): ", 0);
                    danhSach.Add(new NhanVienThoiVu(maNV, hoTen, soGio, luongGio));
                }
            }

            Console.WriteLine("\n--> Da nhap xong danh sach ban dau. Nhan pham bat ky de vao MENU...");
            Console.ReadKey();
            Console.Clear();

            // 2. HIỂN THỊ BẢNG MENU SAU KHIN HẬP XONG
            int chon = -1;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuat danh sach nhan vien");
                Console.WriteLine("2. Tim nhan vien theo ma");
                Console.WriteLine("3. Tim nhan vien co luong cao nhat");
                Console.WriteLine("4. Tinh tong luong cong ty phai tra");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("==========================");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        Console.WriteLine("\n--- DANH SACH NHAN VIEN ---");
                        foreach (NhanVien nv in danhSach)
                        {
                            nv.HienThiThongTin();
                        }
                        break;

                    case 2:
                        Console.Write("\nNhap ma nhan vien can tim: ");
                        string maTim = Console.ReadLine();
                        NhanVien nvTim = danhSach.Find(x => x.MaNV.Equals(maTim, StringComparison.OrdinalIgnoreCase));
                        if (nvTim != null)
                        {
                            Console.WriteLine("\nThong tin nhan vien tim thay:");
                            nvTim.HienThiThongTin();
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay!");
                        }
                        break;

                    case 3:
                        NhanVien nvMax = danhSach[0];
                        foreach (NhanVien nv in danhSach)
                        {
                            if (nv.TinhLuong() > nvMax.TinhLuong())
                            {
                                nvMax = nv;
                            }
                        }
                        Console.WriteLine("\n--- NHAN VIEN LUONG CAO NHAT ---");
                        nvMax.HienThiThongTin();
                        break;

                    case 4:
                        double tongLuong = 0;
                        foreach (NhanVien nv in danhSach)
                        {
                            tongLuong += nv.TinhLuong();
                        }
                        Console.WriteLine($"\nTong luong cong ty phai tra: {tongLuong:N0} VND");
                        break;

                    case 0:
                        Console.WriteLine("Da thoat chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Chuc nang khong hop le!");
                        break;
                }
            } while (chon != 0);
        }
        // Hàm bắt buộc nhập chuỗi không được để trống
        static string ReadStringNonEmpty(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("  [Loi] Truong nay khong duoc de trong. Vui long nhap lai!");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        // Hàm kiểm tra nhập số nguyên nằm trong khoảng [min, max]
        static int ReadIntValid(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"  [Loi] Vui long nhap so nguyên trong khoang trog [{min} - {(max == int.MaxValue ? "vo cuc" : max)}]");
            }
        }

        // Hàm kiểm tra nhập số thực lớn hơn hoặc bằng min
        static double ReadDoubleValid(string prompt, double min)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value >= min)
                {
                    return value;
                }
                Console.WriteLine($"  [Loi] Vui long nhap so thuc >= {min}");
            }
        }
    }
}