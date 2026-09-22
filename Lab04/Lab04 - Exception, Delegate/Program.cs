using System;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ProductService service = new ProductService();

            // Đăng ký nhận thông báo từ Event
            service.OnProductAdded += (sender, e) =>
            {
                Console.WriteLine($"\nĐã thêm sản phẩm thành công: {e.Product.Name}");
            };

            service.OnProductRemoved += (sender, e) =>
            {
                Console.WriteLine($"\nĐã xóa sản phẩm thành công: {e.Product.Name}");
            };

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("================ QUẢN LÝ SẢN PHẨM ================");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Xuất danh sách sản phẩm");
                Console.WriteLine("3. Tìm theo mã");
                Console.WriteLine("4. Tìm theo tên");
                Console.WriteLine("5. Lọc theo khoảng giá");
                Console.WriteLine("6. Xóa sản phẩm");
                Console.WriteLine("7. Tính tổng giá trị kho");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Nhập mã sản phẩm: ");
                            string id = Console.ReadLine();

                            Console.Write("Nhập tên sản phẩm: ");
                            string name = Console.ReadLine();

                            Console.Write("Nhập đơn giá: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                                throw new InvalidProductDataException("Đơn giá phải là định dạng số.");

                            Console.Write("Nhập số lượng: ");
                            if (!int.TryParse(Console.ReadLine(), out int quantity))
                                throw new InvalidProductDataException("Số lượng phải là số nguyên.");

                            service.AddProduct(id, name, price, quantity);
                            break;

                        case "2":
                            Console.WriteLine("\n--- DANH SÁCH TOÀN BỘ SẢN PHẨM ---");
                            var all = service.GetAllProducts();
                            if (all.Count == 0)
                                Console.WriteLine("Kho hàng hiện đang trống!");
                            else
                                all.ForEach(p => Console.WriteLine(p));
                            break;

                        case "3":
                            Console.Write("Nhập mã sản phẩm cần tìm: ");
                            string searchId = Console.ReadLine();
                            var pFound = service.SearchById(searchId);

                            Console.WriteLine("\n--- KẾT QUẢ TÌM KIẾM ---");
                            if (pFound != null)
                                Console.WriteLine(pFound);
                            else
                                throw new ProductNotFoundException($"Không tìm thấy sản phẩm có mã: {searchId}");
                            break;

                        case "4":
                            Console.Write("Nhập từ khóa tên sản phẩm: ");
                            string keyword = Console.ReadLine();
                            var pList = service.SearchByName(keyword);

                            Console.WriteLine("\n--- KẾT QUẢ TÌM KIẾM ---");
                            if (pList.Count == 0)
                                Console.WriteLine("Không tìm thấy sản phẩm phù hợp.");
                            else
                                pList.ForEach(p => Console.WriteLine(p));
                            break;

                        case "5":
                            Console.Write("Nhập giá tối thiểu: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal min))
                                throw new InvalidProductDataException("Giá tối thiểu không hợp lệ.");

                            Console.Write("Nhập giá tối đa: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal max))
                                throw new InvalidProductDataException("Giá tối đa không hợp lệ.");

                            var filtered = service.FilterByPriceRange(min, max);
                            Console.WriteLine($"\n--- KẾT QUẢ LỌC (Từ {min:N0} đến {max:N0}) ---");
                            if (filtered.Count == 0)
                                Console.WriteLine("Không có sản phẩm nào trong khoảng giá này.");
                            else
                                filtered.ForEach(p => Console.WriteLine(p));
                            break;

                        case "6":
                            Console.Write("Nhập mã sản phẩm cần xóa: ");
                            string delId = Console.ReadLine();
                            service.RemoveProduct(delId);
                            break;

                        case "7":
                            decimal totalVal = service.CalculateTotalInventoryValue();
                            Console.WriteLine($"\nTổng giá trị kho hàng = {totalVal:N0} VND");
                            break;

                        case "0":
                            running = false;
                            Console.WriteLine("Đang thoát chương trình...");
                            break;

                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn từ 0 đến 7!");
                            break;
                    }
                }
                catch (DuplicateProductException ex)
                {
                    Console.WriteLine($"[LỖI TRÙNG MÃ]: {ex.Message}");
                }
                catch (ProductNotFoundException ex)
                {
                    Console.WriteLine($"[LỖI KHÔNG TÌM THẤY]: {ex.Message}");
                }
                catch (InvalidProductDataException ex)
                {
                    Console.WriteLine($"[LỖI DỮ LIỆU]: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LỖI HỆ THỐNG]: {ex.Message}");
                }

                if (choice != "0")
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            }
        }
    }
}