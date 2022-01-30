using EStore.Domain.Entities;
using EStore.Domain.Repositories;
using EStore.Infrastructure.Data;

namespace EStore.Domain.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<bool> AddProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAll()
    {
        return _productRepository.GetAll();
    }

    private Task<List<Product>> AllProduct()
    {
        throw new NotImplementedException();
    }

    Task<List<Product>> IProductService.AllProduct()
    {
        throw new NotImplementedException();
    }
}