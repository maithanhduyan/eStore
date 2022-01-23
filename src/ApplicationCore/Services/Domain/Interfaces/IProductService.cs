using EStore.Domain.Entities;

namespace EStore.Domain.Services;
public interface IProductService
{
    Task<bool> AddProduct(Product newProduct);

    Task<IEnumerable<Product>> AllProduct();
}