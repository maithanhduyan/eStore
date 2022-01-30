using System.Linq.Expressions;
using EStore.Domain.Entities;
using EStore.Infrastructure.Data;

namespace EStore.Domain.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }


}