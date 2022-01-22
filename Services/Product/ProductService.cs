using EStore.Core.Entities;
using EStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EStore.DomainServices.Products;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public Task<bool> AddProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> AllProduct()
    {
        // throw new NotImplementedException();
        return await _dbContext.Products.ToListAsync();
    }
}