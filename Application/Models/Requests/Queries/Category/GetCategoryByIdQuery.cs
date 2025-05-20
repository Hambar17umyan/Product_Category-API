namespace Application.Models.Requests.Queries.Categories; 

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Categories;

/// <summary>
/// This class represents a query to get a category by its ID.
/// </summary>
public class GetCategoryByIdQuery : IRequest<RequestHandlerResult<GetCategoryByIdResponse>>
{
    /// <summary>
    /// The ID of the category to be retrieved.
    /// </summary>
    public int CategoryId { get; set; }
}