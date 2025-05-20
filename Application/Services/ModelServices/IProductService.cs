using Application.Common.DTOs;
using Domain.Models;
using Domain.Results;

namespace Application.Services.ModelServices;

/// <summary>
/// This interface defines the contract for the product service.
/// </summary>
public interface IProductService : IModelService<Product>
{
    Task<Result<CategoryListDTO>> TryGetCategories(int id1, int id2, int? id3);
}
