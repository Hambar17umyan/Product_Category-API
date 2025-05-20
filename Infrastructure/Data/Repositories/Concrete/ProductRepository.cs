namespace Infrastructure.Data.Repositories.Concrete; 

using Infrastructure.Data.DB;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Abstract;

/// <summary>
/// This class is used to implement the product repository.
/// </summary>
public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
    public ProductRepository(AppDbContext context) 
        : base(context)
    {
        
    }
}
