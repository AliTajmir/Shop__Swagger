 
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Shop.Interface;

namespace Shop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController :ControllerBase
{
    private readonly IGenericRepository<Product> _repo;
    public ProductController(IGenericRepository<Product> repo)
    {
        _repo = repo;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
       var result= await _repo.GetById(id);
       if (result == null)
       {
           return NotFound($"Product with ID {id} not found.");
       }
      return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var result = await _repo.ListAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task InsertProduct(ProductViewModel productViewModel)
    {
        Product product = new Product()
        {
            Count = productViewModel.Count,
            Description = productViewModel.Description,
            Name = productViewModel.Name,
            Price = productViewModel.Price,
            ImageUrl = productViewModel.ImageUrl,
        };
        
        _repo.Add(product);
        await _repo.SaveChangesAsync();  
    }
   [HttpDelete("{id}")]
   public async Task<ActionResult> DeleteProduct(int id)
   {
       var result = await _repo.GetById(id);

       if (result == null)
       {
           return NotFound($"Product with ID {id} not found.");
       }

       _repo.Remove(result);
       await _repo.SaveChangesAsync();  

       return NoContent();  
   }
   
    [HttpPut]
    public async Task<ActionResult> UpdateProduct(ProductViewModel productViewModel)
    {
        var product =await _repo.GetById(productViewModel.Id);
        
        if (product == null)
        {
            return NotFound($"Product not found.");
        }

        product.Description = productViewModel.Description;
        product.Count = productViewModel.Count;
        product.Price = productViewModel.Price;
        product.Name = productViewModel.Name;
        product.ImageUrl = productViewModel.ImageUrl;
        _repo.Update(product);
        await _repo.SaveChangesAsync();  
        
        return NoContent(); 
    }
}