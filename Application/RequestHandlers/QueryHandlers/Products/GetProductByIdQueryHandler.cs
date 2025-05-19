using Application.Models.Requests.Queries.Products;
using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Products;
using Application.Models.Response.Queries.Categories;
using Domain.Results;
using Application.Services.ModelServices;

namespace Application.RequestHandlers.QueryHandlers.Products;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, RequestHandlerResult<GetProductByIdResponse>>
{
    /// <summary>
    /// This method handles the request to get a product by its ID.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RequestHandlerResult<GetProductByIdResponse>> HandleAsync(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await this._productService.TryGetByIdAsync(request.ProductId);
        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<GetProductByIdResponse>.NotFound(result.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<GetProductByIdResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<GetProductByIdResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<GetProductByIdResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<GetProductByIdResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = new GetProductByIdResponse()
            {
                ProductId = result.Value!.Id,
                Name = result.Value!.Name,
                Category1Id = result.Value.Category1.Id,
                Category2Id = result.Value.Category2.Id,
                Category3Id = result.Value.Category3?.Id,
            };
            return RequestHandlerResult<GetProductByIdResponse>.Ok(response);
        }
    }

    /// <summary>
    /// The product service used to get a product by its ID.
    /// </summary>
    private IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="productService"></param>
    public GetProductByIdQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
}
