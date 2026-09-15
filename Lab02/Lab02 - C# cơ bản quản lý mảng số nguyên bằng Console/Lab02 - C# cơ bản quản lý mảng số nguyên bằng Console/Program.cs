using System;

namespace Lab02_QuanLyMang
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[]? mang = null;
            int chon;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhap mang");
                Console.WriteLine("2. Xuat mang");
                Console.WriteLine("3. Tinh tong");
                Console.WriteLine("4. Tim max/min");
                Console.WriteLine("5. Dem chan/le");
                Console.WriteLine("6. Sap xep tang dan");
                Console.WriteLine("7. Tim kiem");
                Console.WriteLine("0. Thoat");
                chon = NhapSoNguyen("Chon chuc nang: ");
                if (chon != 0 && chon != 1 && mang == null)
                {
                    Console.WriteLine("Vui long nhap mang truoc khi thuc hien chuc nang nay!");
                    continue;
                }
                switch (chon)
                {
                    case 1:
                        mang = NhapMang();
                        break;
                    case 2:
                        XuatMang(mang);
                        break;
                    case 3:
                        Console.WriteLine($"Tong cac phan tu trong mang = {TinhTong(mang)}");
                        break;
                    case 4:
                        Console.WriteLine($"Gia tri Max = {TimMax(mang)}, Min = {TimMin(mang)}");
                        break;
                    case 5:
                        Console.WriteLine($"So luong so chan = {DemChan(mang)}, so le = {DemLe(mang)}");
                        break;
                    case 6:
                        SapXepTangDan(mang);
                        Console.WriteLine("Da sap xep mang tang dan:");
                        XuatMang(mang);
                        break;
                    case 7:
                        int x = NhapSoNguyen("Nhap gia tri x can tim: ");
                        int vitri = TimKiem(mang, x);
                        if (vitri != -1)
                            Console.WriteLine($"Tim thay {x} tai vi tri dau tien: {vitri}");
                        else
                            Console.WriteLine($"Khong tim thay {x} trong mang.");
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                        break;
                }
            } while (chon != 0);
        }
        static int NhapSoNguyen(string message)
        {
            int res;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.Write("Du lieu khong hop le. " + message);
            }
            return res;
        }
        static int NhapSoNguyenDuong(string message)
        {
            int res;
            do
            {
                res = NhapSoNguyen(message);
                if (res <= 0)
                {
                    Console.WriteLine("So luong phan tu phai lon hon 0. Vui long nhap lai!");
                }
            } while (res <= 0);
            return res;
        }
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu (n > 0): ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhap phan tu a[{i}]: ");
            }
            return a;
        }
        static void XuatMang(int[]? a)
        {
            if (a == null) return;
            Console.Write("Cac phan tu trong mang: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
        static int TinhTong(int[]? a)
        {
            if (a == null) return 0;
            int tong = 0;
            foreach (int item in a)
            {
                tong += item;
            }
            return tong;
        }
        static int TimMax(int[]? a)
        {
            if (a == null || a.Length == 0) return 0;
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
            }
            return max;
        }
        static int TimMin(int[]? a)
        {
            if (a == null || a.Length == 0) return 0;
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
            }
            return min;
        }
        static int DemChan(int[]? a)
        {
            if (a == null) return 0;
            int dem = 0;
            foreach (int item in a)
            {
                if (item % 2 == 0) dem++;
            }
            return dem;
        }
        static int DemLe(int[]? a)
        {
            if (a == null) return 0;
            int dem = 0;
            foreach (int item in a)
            {
                if (item % 2 != 0) dem++;
            }
            return dem;
        }
        static void SapXepTangDan(int[]? a)
        {
            if (a != null) Array.Sort(a);
        }
        static int TimKiem(int[]? a, int x)
        {
            if (a == null) return -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x) return i;
            }
            return -1;
        }
    }
}