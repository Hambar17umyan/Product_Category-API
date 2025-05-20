namespace Application.RequestHandlers.CommandHandlers.Products;

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Requests.Commands.Products;
using Application.Models.Response.Commands.Products;
using Application.Services.ModelServices;
using Domain.Models;
using Domain.Results;


/// <summary>
/// This class handles the creation of a product.
/// </summary>
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, RequestHandlerResult<CreateProductResponse>>
{
    /// <summary>
    /// The product service used to create a product.
    /// </summary>
    /// <param name="productService"></param>
    /// <param name="categoryService"></param>
    public CreateProductCommandHandler(IProductService productService, ICategoryService categoryService)
    {
        this._productService = productService;
        this._categoryService = categoryService;
    }

    /// <summary>
    /// This method handles the creation of a product.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RequestHandlerResult<CreateProductResponse>> HandleAsync(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var res = await this._productService.TryGetCategories(request.ProductCategory1Id, request.ProductCategory2Id, request.ProductCategory3Id);
        if (res.IsFail)
        {
            switch(res.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<CreateProductResponse>.NotFound(res.Message);
                case StatusCode.ArgumentNullError:
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<CreateProductResponse>.BadRequest(res.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<CreateProductResponse>.Unknown(res.Message);
                default:
                    return RequestHandlerResult<CreateProductResponse>.InternalServerError(res.Message);
            }
        }

        var product = new Product(request.ProductName, res.Value!.Category1, res.Value!.Category2, res.Value?.Category3);
        var result = await this._productService.TryAddAsync(product);

        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<CreateProductResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<CreateProductResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<CreateProductResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<CreateProductResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = new CreateProductResponse
            {
                ProductId = result.Value!.Id,
                ProductName = result.Value!.Name,
                ProductCategory1Id = result.Value.Category1.Id,
                ProductCategory2Id = result.Value.Category2.Id,
                ProductCategory3Id = result.Value.Category3?.Id
            };
            return RequestHandlerResult<CreateProductResponse>.Ok(response);
        }
    }

    /// <summary>
    /// The product service used to create a product.
    /// </summary>
    private IProductService _productService;

    /// <summary>
    /// The category service used to create a product.
    /// </summary>
    private ICategoryService _categoryService;
}
