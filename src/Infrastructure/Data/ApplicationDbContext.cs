using System.Reflection;
using EStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EStore.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<SubCategory>().ToTable("SubCategory");
        modelBuilder.Entity<Order>().ToTable("Order");
        modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
        modelBuilder.Entity<Cart>().ToTable("Cart");
        modelBuilder.Entity<Person>().ToTable("Person");
        modelBuilder.Entity<Company>().ToTable("Company");
        modelBuilder.Entity<Address>().ToTable("Address");
        modelBuilder.Entity<Country>().ToTable("Country");

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}