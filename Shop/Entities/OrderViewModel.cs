namespace Core.Entities;

public class OrderViewModel
{
    public int Id { get; set; }
    public string Name_Product { get; set; }
    public string FirstName_User { get; set; }
    public DateTime CreateDate { get; set; } 
    public int UserId { get; set; }
    public int ProductId { get; set; }
}