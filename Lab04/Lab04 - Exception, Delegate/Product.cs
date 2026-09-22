using System;

namespace Lab04
{
    public class Product : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new InvalidProductDataException("Giá sản phẩm không được nhỏ hơn 0.");
                price = value;
            }
        }

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new InvalidProductDataException("Số lượng sản phẩm không được nhỏ hơn 0.");
                quantity = value;
            }
        }

        public Product(string id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Mã: {Id} | Tên: {Name} | Giá: {Price:N0} VND | Số lượng: {Quantity}";
        }
    }
}