namespace Infrastructure.Mappers; 

using Domain.Models;
using Infrastructure.Data.Entities;

/// <summary>
/// This class is used to map the product entity to the product domain model and vice versa.
/// </summary>
public static class ProductMapper
{
    /// <summary>
    /// This method is used to map the product entity to the product domain model.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public static Product MapToDomain(this ProductEntity product)
    {
        return new Product(
            product.Id,
            product.Name,
            product.Category1!.MapToDomain(),
            product.Category2!.MapToDomain(),
            product.Category3 is not null ?
                product.Category3.MapToDomain() :
                default);
    }

    /// <summary>
    /// This method is used to map the product domain model to the product entity.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public static ProductEntity MapToEntity(this Product product)
    {
        return new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Category1Id = product.Category1.Id,
            Category2Id = product.Category2.Id,
            Category3Id = product.Category3 is not null ?
                product.Category3.Id :
                null
        };
    }
}
