using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop;
using Shop.Interface;

namespace Shop;
public class GenericRepository<T>:IGenericRepository<T> where T:class
{
    private readonly ShopContext _shopContext;
    private readonly DbSet<T> _set;
    public GenericRepository(ShopContext shopContext )
    {
        _shopContext = shopContext;
        _set = shopContext.Set<T>();
    }
    public GenericRepository()
    {
    }
    public async Task<T> GetById(int Id)
    {
       return await _set.FindAsync(Id);
    }

    public async Task<List<T>> ListAllAsync()
    {
       return await _set.ToListAsync();
    }

    public async Task  Remove(T entity)
    {
      _set.Remove(entity);
    }

    public async Task Update(T entity)
    {
        _shopContext.Entry(entity).State= EntityState.Modified;
    }

    public async Task Add(T entity)
    {
         _set.Add(entity);
    }

    public async Task  SaveChangesAsync()
    {
        await _shopContext.SaveChangesAsync();
    }
}