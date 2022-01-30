using EStore.Domain.Entities;

namespace EStore.Domain.Services;
public interface IProductService
{
    Task<bool> AddProduct(Product newProduct);
    Task<List<Product>> AllProduct();
    IEnumerable<Product> GetAll();
}