
namespace Day06.Interfaces;
public interface IRepository<T>
{
    void Add(T item);
    bool Remove(Func<T,bool> predicate);
    T? Find(Func<T,bool> predicate);
    IReadOnlyList<T> FindAll(Func<T,bool> predicate);
    IReadOnlyList<T> GetAll();
    int Count { get; }
    
}