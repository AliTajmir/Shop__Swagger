namespace Core.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    
    public DateTime CreateDate { get; set; }
    public User User { get; set; }
    public Product Product { get; set; }
}