using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Shop.Interface;

namespace Shop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repo;
    public OrderController(IOrderRepository repo)
    {
        _repo = repo;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var item =await _repo.GetById(id);
        if (item == null)
        {
            return NotFound($"Order with id{id} not found");
        }

        return Ok(item);
    }
[HttpGet]
    public async Task<ActionResult<List<OrderViewModel>>> GetOrders()
    {
        return await _repo.ListAllAsync();
    }

    [HttpPost]
    public async Task InsertOrder(OrderViewModel orderViewModel)
    {
        Order order = new Order()
        {
            ProductId = orderViewModel.ProductId,
            UserId = orderViewModel.UserId,
            CreateDate = orderViewModel.CreateDate
        };
        
        await _repo.Add(order);
    }
    [HttpPut]
    public async Task UpdateOrder(OrderViewModel orderViewModel)
    {
        var order =await _repo.GetById(orderViewModel.Id);
        order.UserId = orderViewModel.UserId;
        order.ProductId = orderViewModel.ProductId;
        order.CreateDate = orderViewModel.CreateDate;
        await _repo.Update(order);
    }

    [HttpDelete]
    public async Task DeleteOrder(int id)
    {
        await _repo.Remove(id);
    }
}