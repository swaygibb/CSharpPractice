using CSharpPractice.Models;

namespace CSharpPractice.Repositories
{
    public class Repository<T> where T: class, IEntity
    {
        private readonly List<T> _items = new();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T? GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }
    }
}
