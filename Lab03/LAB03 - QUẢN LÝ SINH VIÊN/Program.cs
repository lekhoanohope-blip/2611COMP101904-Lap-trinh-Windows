using System;
using System.Globalization;

namespace LAB03___QUẢN_LÝ_SINH_VIÊN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLySinhVien qlsv = new QuanLySinhVien();
            int chon;

            do
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4. Tim sinh vien theo ten");
                Console.WriteLine("5. Sua diem trung binh");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo diem giam dan");
                Console.WriteLine("8. Loc sinh vien dat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai so tu 0 den 8!");
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        try
                        {
                            Console.Write("Nhap ma sinh vien: ");
                            string ma = Console.ReadLine() ?? "";

                            Console.Write("Nhap ho ten: ");
                            string ten = Console.ReadLine() ?? "";

                            string ns = "";
                            while (true)
                            {
                                Console.Write("Nhap ngay sinh: ");
                                string inputDate = Console.ReadLine() ?? "";
                                if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                {
                                    ns = parsedDate.ToString("dd/MM/yyyy");
                                    break;
                                }
                                Console.WriteLine("Sai dinh dạng ngày sinh! Vui lòng nhập lại theo mẫu dd/MM/yyyy (VD: 15/08/2004).");
                            }

                            Console.Write("Nhap ma lop: ");
                            string lop = Console.ReadLine() ?? "";
                            
                            double dtb = 0;
                            while (true)
                            {
                                Console.Write("Nhap diem trung binh (0-10): ");
                                if (double.TryParse(Console.ReadLine(), out dtb) && dtb >= 0 && dtb <= 10)
                                {
                                    break;
                                }
                                Console.WriteLine("Điểm không hợp lệ! Vui lòng nhập số từ 0 đến 10.");
                            }

                            SinhVien sv = new SinhVien(ma, ten, ns, lop, dtb);
                            if (qlsv.Them(sv))
                            {
                                Console.WriteLine("Them sinh vien thanh cong!");
                            }
                            else
                            {
                                Console.WriteLine("Them that bai: Ma sinh vien da ton tai trong danh sách!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Loi: {ex.Message}");
                        }
                        break;

                    case 2:
                        var ds = qlsv.LayDanhSach();
                        if (ds.Count == 0)
                        {
                            Console.WriteLine("Danh sach sinh vien hien dang trong!");
                        }
                        else
                        {
                            Console.WriteLine("\n--- DANH SACH SINH VIEN ---");
                            foreach (var sv in ds)
                            {
                                Console.WriteLine(sv.LayThongTin());
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Nhap ma sinh vien can tim: ");
                        string maTim = Console.ReadLine() ?? "";
                        var kqMa = qlsv.TimTheoMa(maTim);
                        if (kqMa != null)
                        {
                            Console.WriteLine($"Ket qua tim thay: {kqMa.LayThongTin()}");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay sinh vien co ma nay.");
                        }
                        break;

                    case 4:
                        Console.Write("Nhap tu khoa ten can tim: ");
                        string tenTim = Console.ReadLine() ?? "";
                        var kqTen = qlsv.TimTheoTen(tenTim);
                        if (kqTen.Count > 0)
                        {
                            Console.WriteLine($"\n--- KET QUA TIM KIEM ({kqTen.Count} sinh vien) ---");
                            foreach (var sv in kqTen)
                            {
                                Console.WriteLine(sv.LayThongTin());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay sinh vien phu hop.");
                        }
                        break;

                    case 5:
                        try
                        {
                            Console.Write("Nhap ma sinh vien can sua diem: ");
                            string maSua = Console.ReadLine() ?? "";

                            double diemMoi = 0;
                            while (true)
                            {
                                Console.Write("Nhap diem trung binh moi (0-10): ");
                                if (double.TryParse(Console.ReadLine(), out diemMoi) && diemMoi >= 0 && diemMoi <= 10)
                                {
                                    break;
                                }
                                Console.WriteLine("Điểm không hợp lệ! Vui lòng nhập số từ 0 đến 10.");
                            }

                            if (qlsv.SuaDiem(maSua, diemMoi))
                            {
                                Console.WriteLine("Sua diem trung binh thanh cong!");
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay ma sinh vien de sua.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Loi: {ex.Message}");
                        }
                        break;

                    case 6:
                        Console.Write("Nhap ma sinh vien can xoa: ");
                        string maXoa = Console.ReadLine() ?? "";
                        if (qlsv.Xoa(maXoa))
                        {
                            Console.WriteLine("Xoa sinh vien thanh cong!");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay ma sinh vien can xoa.");
                        }
                        break;

                    case 7:
                        qlsv.SapXepTheoDiem();
                        Console.WriteLine("Da sap xep danh sach theo diem trung binh giam dan!");
                        break;

                    case 8:
                        var dsDat = qlsv.LocSinhVienDat(5.0);
                        if (dsDat.Count == 0)
                        {
                            Console.WriteLine("Khong co sinh vien nao dat (DTB >= 5.0).");
                        }
                        else
                        {
                            Console.WriteLine($"\n--- DANH SACH SINH VIEN ĐẠT ({dsDat.Count}) ---");
                            foreach (var sv in dsDat)
                            {
                                Console.WriteLine(sv.LayThongTin());
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Cam on ban da su dung chuong trinh!");
                        break;

                    default:
                        Console.WriteLine("Chuc nang khong hop le, vui long chon lai tu 0 den 8.");
                        break;
                }
            } while (chon != 0);
        }
    }
}