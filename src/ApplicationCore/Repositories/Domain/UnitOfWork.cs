using EStore.Infrastructure.Data;

namespace EStore.Domain.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IProductRepository ProductRepositories { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        ProductRepositories = new ProductRepository(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}