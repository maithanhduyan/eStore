using EStore.Core.Entities;

namespace EStore.DomainServices.Products;

public interface IProductService
{
    Task<bool> AddProduct(Product newProduct);

    Task<IEnumerable<Product>> AllProduct();
}