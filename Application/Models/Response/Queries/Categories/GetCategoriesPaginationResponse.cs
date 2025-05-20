using Application.Common.DTOs;
using Application.Models.Requests.Queries.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Queries.Categories;

/// <summary>
/// This class represents the response for the GetCategoriesPaginationQuery.
/// </summary>
public class GetCategoriesPaginationResponse : IResponse<GetCategoriesPaginationQuery>
{
    /// <summary>
    /// Gets or sets the list of categories.
    /// </summary>
    public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
}