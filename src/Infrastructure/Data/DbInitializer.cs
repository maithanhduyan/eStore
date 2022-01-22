using EStore.ApplicationCore.Entities.Product;
using Microsoft.EntityFrameworkCore;
namespace EStore.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(GetPreconfiguredProduct(context));
            await context.SaveChangesAsync();
        }
    }


    //Guid.NewGuid();
    static IEnumerable<Product> GetPreconfiguredProduct(ApplicationDbContext context)
    {
        return new List<Product> {
            new Product{Id="P0001",Name="Toothbrush"}
        };
    }



}