using Core.Entities;

namespace Shop.Interface;

public interface IOrderRepository:IDisposable
{
    Task<Order> GetById(int id);
    Task<List<OrderViewModel>> ListAllAsync();
    Task Add(Order order);
    Task Update(Order order);
    Task Remove(int id);
    Task SaveChangesAsync();
}