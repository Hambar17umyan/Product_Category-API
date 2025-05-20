namespace Application.Models.Requests.Commands.Categories; 

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Categories;


/// <summary>
/// This class represents a command to update a category.
/// </summary>
public class UpdateCategoryCommand : IRequest<RequestHandlerResult<UpdateCategoryResponse>>
{
    /// <summary>
    /// Gets or sets the id of the category to be updated.
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
