namespace Infrastructure.Mappers; 

using Domain.Models;
using Infrastructure.Data.Entities;

/// <summary>
/// This class is used to map between the domain model and the entity model for categories.
/// </summary>
public static class CategoryMapper
{
    /// <summary>
    /// This method is used to map a category entity to a domain model.
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    public static Category MapToDomain(this CategoryEntity category)
    {
        return new Category(
            category.Id,
            category.Name,
            category.Description);
    }

    /// <summary>
    /// This method is used to map a domain model to a category entity.
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    public static CategoryEntity MapToEntity(this Category category)
    {
        return new CategoryEntity
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
