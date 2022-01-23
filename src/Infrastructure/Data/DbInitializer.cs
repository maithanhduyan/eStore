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
            new Product{Id="P0001",Name="Thuốc trị ngứa da đầu Roto Gold 30ml",Barcode="4987241146352",Description =""},
            new Product{Id="P0002",Name="Thuốc nhuộm CEILO",Barcode="4987205286278",Description =""},
            new Product{Id="P0003",Name="Dầu gội trị ngứa LION 320ml",Barcode="4903301437246",Description =""}
        };
    }

}