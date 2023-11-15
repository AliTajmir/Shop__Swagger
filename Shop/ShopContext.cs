using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop;

public class ShopContext: DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; } 
    public DbSet<Order> Orders { get; set; }
}