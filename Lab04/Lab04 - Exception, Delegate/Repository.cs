using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04
{
    public class Repository<T> where T : IEntity
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            if (items.Any(x => x.Id.Equals(item.Id, StringComparison.OrdinalIgnoreCase)))
            {
                throw new DuplicateProductException($"Mã sản phẩm '{item.Id}' đã tồn tại!");
            }
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public List<T> GetAll()
        {
            return items;
        }

        public T FindById(string id)
        {
            return items.FirstOrDefault(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return items.Where(predicate).ToList();
        }
    }
}