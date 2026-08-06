using Day03.Interfaces;
namespace Day03.Repositories;
public class InMemoryRepository<T> : IRepository<T>
{
    private readonly List<T> _items = new List<T>();
    public void Add(T item)
    {
        _items.Add(item);
    }

    public bool Remove(Func<T, bool> predicate)
    {
        var item = _items.FirstOrDefault(predicate);
        if(item != null)
        {
            _items.Remove(item);
            return true;
        }
        return false;
    }
    public T? Find(Func<T, bool> predicate)
    {
        var result = _items.FirstOrDefault(predicate);
        return result;
    }

    public IReadOnlyList<T> FindAll(Func<T, bool> predicate)
    {
        return _items.Where(predicate).ToList();
    }

    public IReadOnlyList<T> GetAll()
    {
        return _items.AsReadOnly();
    }

    public int Count => _items.Count;

}