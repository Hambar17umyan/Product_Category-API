namespace Application.Models.Response.Commands.Categories; 

using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Abstract;

/// <summary>
/// This class represents the response for updating a category.
/// </summary>
public class UpdateCategoryResponse : IResponse<UpdateCategoryCommand>
{
    public int CategoryId { get; internal set; }
    public string CategoryDescription { get; internal set; } = string.Empty;
    public string CategoryName { get; internal set; } = string.Empty;
    public bool IsDeleted { get; internal set; }
}