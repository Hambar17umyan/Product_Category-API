namespace Application.Models.Requests.Queries.Products; 

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Products;


/// <summary>
/// This class represents a request to get a product by its ID.
/// </summary>
public class GetProductByIdQuery : IRequest<RequestHandlerResult<GetProductByIdResponse>>
{
    /// <summary>
    /// Gets or sets the product ID.
    /// </summary>
    public int ProductId { get; set; }
}