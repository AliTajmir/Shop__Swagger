namespace Core.Entities;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}