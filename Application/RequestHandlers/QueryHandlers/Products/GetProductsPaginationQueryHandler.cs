﻿using Application.Models.Requests.Queries.Products;
using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Products;
using Application.Common.DTOs;
using Application.Models.Response.Queries.Categories;
using Domain.Results;
using Application.Services.ModelServices;

namespace Application.RequestHandlers.QueryHandlers.Products;

/// <summary>
/// This class handles the request to get products with pagination.
/// </summary>
public class GetProductsPaginationQueryHandler : IRequestHandler<GetProductsPaginationQuery, RequestHandlerResult<GetProductsPaginationResponse>>
{
    /// <summary>
    /// This method handles the request to get products with pagination.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RequestHandlerResult<GetProductsPaginationResponse>> HandleAsync(GetProductsPaginationQuery request, CancellationToken cancellationToken)
    {
        var result = this._productService.TryGetWithPagination(request.Page, request.PageSize);
        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<GetProductsPaginationResponse>.NotFound(result.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<GetProductsPaginationResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<GetProductsPaginationResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<GetProductsPaginationResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<GetProductsPaginationResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = new GetProductsPaginationResponse()
            {
                Products = result.Value!.Select(c => new ProductDTO()
                {
                    ProductId = c.Id,
                    ProductName = c.Name,
                    ProductCategory1Id = c.Category1.Id,
                    ProductCategory2Id = c.Category2.Id,
                    Category3Id = c.Category3?.Id,
                }).ToList(),
            };
            return RequestHandlerResult<GetProductsPaginationResponse>.Ok(response);
        }
    }

    /// <summary>
    /// The product service used to get products with pagination.
    /// </summary>
    private IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductsPaginationQueryHandler"/> class.
    /// </summary>
    /// <param name="productService"></param>
    public GetProductsPaginationQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
}
