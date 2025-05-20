using Application.Models.Requests.Queries.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Queries.Categories;

/// <summary>
/// This class represents the response for the GetCategoryByIdQuery.
/// </summary>
public class GetCategoryByIdResponse : IResponse<GetCategoryByIdQuery>
{
    /// <summary>
    /// Gets or sets the id of the category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the category.
    /// </summary>
    public string CategoryDescription { get; set; } = string.Empty;
}