using System;

namespace Lab04
{
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException(string message) : base(message) { }
    }

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
    }

    public class InvalidProductDataException : Exception
    {
        public InvalidProductDataException(string message) : base(message) { }
    }
}