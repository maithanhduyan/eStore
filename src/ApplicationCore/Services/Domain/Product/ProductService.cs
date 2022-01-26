using EStore.Domain.Entities;

namespace EStore.Domain.Services;

public class ProductService : IProductService
{
    public Task<bool> AddProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> AllProduct()
    {
        throw new NotImplementedException();
    }
}