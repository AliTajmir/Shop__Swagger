using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Shop;
using Shop.Interface;

namespace Infrastructure.Repositores;

public class OrderRepository:IOrderRepository
{
    private readonly ShopContext _shopContext;
    public OrderRepository(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }
    public void Dispose()
    {
       _shopContext.Dispose(); 
    }

    public async Task<Order> GetById(int id)
    {
        var item= await _shopContext.Orders.FindAsync(id);
        return item;
    }

    public async Task<List<OrderViewModel>> ListAllAsync()
    {
        return await _shopContext.Orders.Include(x => x.Product).Include(x => x.User).Select(x => new OrderViewModel()
        {
FirstName_User = x.User.FirstName,
Name_Product = x.Product.Name,
Id = x.Id,
ProductId = x.Product.Id,
UserId = x.User.Id
        }).ToListAsync();
    }

    public async Task Add(Order order)
    {
        await _shopContext.Orders.AddAsync(order);
       await this.SaveChangesAsync();
    }

    public async Task Update(Order order)
    {
        _shopContext.Entry(order).State = EntityState.Modified;
        await this.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        var item = await _shopContext.Orders.FindAsync(id);
        _shopContext.Orders.Remove(item);
        await this.SaveChangesAsync();

    }

    public async Task SaveChangesAsync()
    {
        await _shopContext.SaveChangesAsync();
    }
}