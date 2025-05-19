using Application.Models.Requests.Queries.Categories;
using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Categories;
using Application.Services.ModelServices;
using Domain.Results;
using Application.Common.DTOs;

namespace Application.RequestHandlers.QueryHandlers.Categories;

/// <summary>
/// This class handles the request to get categories with pagination.
/// </summary>
public class GetCategoriesPaginationQueryHandler : IRequestHandler<GetCategoriesPaginationQuery, RequestHandlerResult<GetCategoriesPaginationResponse>>
{
    /// <summary>
    /// This method handles the request to get categories with pagination.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RequestHandlerResult<GetCategoriesPaginationResponse>> HandleAsync(GetCategoriesPaginationQuery request, CancellationToken cancellationToken)
    {
        var result = this._categoryService.TryGetWithPagination(request.Page, request.PageSize);
        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<GetCategoriesPaginationResponse>.NotFound(result.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<GetCategoriesPaginationResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<GetCategoriesPaginationResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<GetCategoriesPaginationResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<GetCategoriesPaginationResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = new GetCategoriesPaginationResponse()
            {
                Categories = result.Value!.Select(c => new CategoryDto()
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    CategoryDescription = c.Description,
                }).ToList(),
            };
            return RequestHandlerResult<GetCategoriesPaginationResponse>.Ok(response);
        }
    }

    /// <summary>
    /// The category service used to get categories with pagination.
    /// </summary>
    private ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCategoriesPaginationQueryHandler"/> class.
    /// </summary>
    /// <param name="categoryService"></param>
    public GetCategoriesPaginationQueryHandler(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }
}
