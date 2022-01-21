using EStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace EStore.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        if (!await context.Companies.AnyAsync())
        {
            await context.Companies.AddRangeAsync(GetPreconfiguredCompany());
            await context.SaveChangesAsync();
        }
        
        if (!await context.Items.AnyAsync())
        {
            await context.Items.AddRangeAsync(GetPreconfiguredItem());
            await context.SaveChangesAsync();
        }
       

    }

//Guid.NewGuid();
 static IEnumerable<Company> GetPreconfiguredCompany()
    {
        return
            new List<Company>{
                new Company { Id = Guid.NewGuid().ToString(), Name = "eStore", Address = "false" ,Country = "VN"},
            };
    }

    static IEnumerable<Item> GetPreconfiguredItem()
    {
        return new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), Name = "Classic Italian", BarCode = "123",Price=12.4 , Link ="url",Image="",Weight=0.1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Vietnamese Pizza", BarCode = "123",Price=12.4 , Link ="url",Image="",Weight=0.1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Japanese Pizza", BarCode = "123",Price=12.4 , Link ="url",Image="",Weight=0.1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Veggie", BarCode = "123",Price=12.4 , Link ="url",Image="",Weight=0.1}
            };
    }
    

}