namespace Application.RequestHandlers.CommandHandlers.Products; 

using Application.Models.Requests.Commands.Products;
using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Products;
using Domain.Results;
using Application.Services.ModelServices;
using Domain.Models;

/// <summary>
/// This class is used to handle the update product command.
/// </summary>
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, RequestHandlerResult<UpdateProductResponse>>
{
    /// <summary>
    /// This method handles the update of a product.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RequestHandlerResult<UpdateProductResponse>> HandleAsync(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var res = await this._productService.TryGetCategories(request.ProductCategory1Id, request.ProductCategory2Id, request.ProductCategory3Id);
        if (res.IsFail)
        {
            switch (res.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<UpdateProductResponse>.NotFound(res.Message);
                case StatusCode.ArgumentNullError:
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<UpdateProductResponse>.BadRequest(res.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<UpdateProductResponse>.Unknown(res.Message);
                default:
                    return RequestHandlerResult<UpdateProductResponse>.InternalServerError(res.Message);
            }
        }

        var product = new Product(request.ProductId, request.ProductName, res.Value!.Category1, res.Value!.Category2, res.Value?.Category3);

        var updateResult = await this._productService.TryUpdateAsync(product);

        if (updateResult.IsFail)
        {
            switch (updateResult.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<UpdateProductResponse>.NotFound(updateResult.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<UpdateProductResponse>.BadRequest(updateResult.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<UpdateProductResponse>.BadRequest(updateResult.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<UpdateProductResponse>.Unknown(updateResult.Message);
                default:
                    return RequestHandlerResult<UpdateProductResponse>.InternalServerError(updateResult.Message);
            }
        }

        var response = new UpdateProductResponse()
        {
            ProductId = request.ProductId,
            ProductName = updateResult.Value!.Name,
            ProductCategory1Id = updateResult.Value.Category1.Id,
            ProductCategory2Id = updateResult.Value.Category2.Id,
            ProductCategory3Id = updateResult.Value.Category3?.Id,
        };

        return RequestHandlerResult<UpdateProductResponse>.Ok(response);
    }

    /// <summary>
    /// The product service used to update a product.
    /// </summary>
    private IProductService _productService;

    /// <summary>
    /// /// This is the constructor for the UpdateProductCommandHandler class.
    /// </summary>
    /// <param name="productService"></param>
    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
}
