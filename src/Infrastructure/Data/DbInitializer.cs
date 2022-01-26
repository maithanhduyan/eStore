using System;
using EStore.Domain.Entities;
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
        if (!await context.Categories.AnyAsync())
        {
            await context.Categories.AddRangeAsync(GetPreconfiguredCategorie(context));
            await context.SaveChangesAsync();
        }


    }

    private static List<Category> GetPreconfiguredCategorie(ApplicationDbContext context)
    {
        return new List<Category>{
            new Category{CategoryId = "Cate01",Name = "Quần Áo", CreatedDate = DateTime.Now},
            new Category{CategoryId = "Cate02",Name = "Giày Dép", CreatedDate = DateTime.Now},
            new Category{CategoryId = "Cate03",Name = "Thực Phẩm", CreatedDate = DateTime.Now},
            new Category{CategoryId = "Cate04",Name = "Điện Tử", CreatedDate = DateTime.Now}
        };
    }


    //Guid.NewGuid();
    static IEnumerable<Product> GetPreconfiguredProduct(ApplicationDbContext context)
    {
        return new List<Product> {
            new Product{ProductId="P0001",Name="Thuốc trị ngứa da đầu Roto Gold 30ml",Barcode="4987241146352",Description =""},
            new Product{ProductId="P0002",Name="Thuốc nhuộm CEILO",Barcode="4987205286278",Description =""},
            new Product{ProductId="P0003",Name="Dầu gội trị ngứa LION 320ml",Barcode="4903301437246",Description =""}
        };
    }

}