using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Shop.Interface;

namespace Shop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IGenericRepository<User> _repo;
  public UserController(IGenericRepository<User> repo)
  {
      _repo = repo;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<User>> GetUser(int id)
  {
      var item =await _repo.GetById(id);
      if (item == null)
      {
         return NotFound($"Product with ID {id} not found.");
      }

      return Ok(item);
  }

  [HttpGet]
  public async Task<ActionResult<List<User>>> GetUsers()
  {
      var items =await _repo.ListAllAsync();
      return Ok(items);
  }

  [HttpPost]
  public async Task InsertUser(UserViewModel userViewModel)
  {
      User user = new User()
      {
          FirstName = userViewModel.FirstName,
          LastName = userViewModel.LastName,
          Address = userViewModel.Address,
          Mobile = userViewModel.Mobile,
      };
     await _repo.Add(user);
      await _repo.SaveChangesAsync();
  }

  [HttpPut]
  public async Task UpdateUser(UserViewModel userViewModel)
  {
     
          var item = await _repo.GetById(userViewModel.Id);
          item.FirstName = userViewModel.FirstName;
          item.LastName = userViewModel.LastName;
          item.Address = userViewModel.Address;
          item.Mobile = userViewModel.Mobile;
          await _repo.Update(item);
          await _repo.SaveChangesAsync();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteUser(int id)
  {
      var item =await _repo.GetById(id);
      if (item == null)
      {
          return NotFound($"Product with ID {id} not found.");
      }

      await _repo.Remove(item);
      await _repo.SaveChangesAsync();
      return NoContent();
  }
}