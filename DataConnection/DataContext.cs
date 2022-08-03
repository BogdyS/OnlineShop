using DataConnection.Configurations;
using DataConnection.Entity;
using Microsoft.EntityFrameworkCore;
using Type = DataConnection.Entity.Type;

namespace DataConnection;

public class DataContext : DbContext
{
    public DataContext() : base() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<ProductOrder> ProductOrder { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
    }
}