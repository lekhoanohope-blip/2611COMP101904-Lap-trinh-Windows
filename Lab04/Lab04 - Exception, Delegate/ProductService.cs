using System;
using System.Collections.Generic;

namespace Lab04
{
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; }
        public ProductEventArgs(Product product)
        {
            Product = product;
        }
    }

    public class ProductService
    {
        private Repository<Product> repository = new Repository<Product>();

        // Sử dụng event để thông báo thay đổi dữ liệu
        public event EventHandler<ProductEventArgs> OnProductAdded;
        public event EventHandler<ProductEventArgs> OnProductRemoved;

        public void AddProduct(string id, string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidProductDataException("Mã sản phẩm không được để trống.");
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductDataException("Tên sản phẩm không được để trống.");

            Product p = new Product(id, name, price, quantity);
            repository.Add(p);

            // Phát sự kiện thêm thành công
            OnProductAdded?.Invoke(this, new ProductEventArgs(p));
        }

        public void RemoveProduct(string id)
        {
            var product = repository.FindById(id);
            if (product == null)
            {
                throw new ProductNotFoundException($"Không tìm thấy sản phẩm có mã '{id}' để xóa.");
            }
            repository.Remove(product);

            // Phát sự kiện xóa thành công
            OnProductRemoved?.Invoke(this, new ProductEventArgs(product));
        }

        public Product SearchById(string id)
        {
            return repository.FindById(id);
        }

        public List<Product> SearchByName(string keyword)
        {
            return repository.Find(x => x.Name.ToLower().Contains(keyword.ToLower()));
        }

        public List<Product> FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            // Sử dụng Func<Product, bool> theo yêu cầu đề bài
            Func<Product, bool> priceFilter = x => x.Price >= minPrice && x.Price <= maxPrice;
            return repository.Find(priceFilter);
        }

        public List<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        public decimal CalculateTotalInventoryValue()
        {
            decimal total = 0;
            repository.GetAll().ForEach(x => total += (x.Price * x.Quantity));
            return total;
        }
    }
}