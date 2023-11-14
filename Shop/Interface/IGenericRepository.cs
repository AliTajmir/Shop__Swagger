using System.Linq.Expressions;

namespace Shop.Interface;

public interface IGenericRepository<T> where T :class
{
    Task<T> GetById(int Id);
    Task<List<T>> ListAllAsync();
    Task Remove(T entity);
    Task Update(T entity);
    Task Add(T entity);
    Task SaveChangesAsync();
}