using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories.Abstract;

/// <summary>
/// This interface is used to define the product repository.
/// </summary>
public interface IProductRepository : IRepository<ProductEntity>
{
}
