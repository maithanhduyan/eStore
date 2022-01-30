namespace EStore.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepositories { get; }
    int Complete();
}