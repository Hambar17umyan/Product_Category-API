using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Commands.Categories;

public class CreateCategoryResponse : IResponse<CreateCategoryCommand>
{
    /// <summary>
    /// Gets or sets the ID of the new category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the new category.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the new category.
    /// </summary>
    public string CategoryDescription { get; set; } = string.Empty;
}