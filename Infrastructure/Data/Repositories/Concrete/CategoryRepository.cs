namespace Infrastructure.Data.Repositories.Concrete; 

using Infrastructure.Data.DB;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Abstract;

/// <summary>
/// This class is used to implement the category repository.
/// </summary>
public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) 
        : base(context)
    {
    }
}
