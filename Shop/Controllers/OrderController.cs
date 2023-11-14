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
    // GET
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
    public async Task InsertOrder(Order order)
    {
        await _repo.Add(order);
    }
    [HttpPut]
    public async Task UpdateOrder(Order order)
    {
        await _repo.Update(order);
    }

    [HttpDelete]
    public async Task DeleteOrder(int id)
    {
        await _repo.Remove(id);
    }
}