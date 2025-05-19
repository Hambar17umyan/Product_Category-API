using Application.Models.Requests.Queries.Categories;
using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Categories;
using Application.Services.ModelServices;
using Domain.Results;

namespace Application.RequestHandlers.QueryHandlers.Categories;

/// <summary>
/// This class handles the request to get a category by its ID.
/// </summary>
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, RequestHandlerResult<GetCategoryByIdResponse>>
{
    /// <summary>
    /// This method handles the request to get a category by its ID.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RequestHandlerResult<GetCategoryByIdResponse>> HandleAsync(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await this._categoryService.TryGetByIdAsync(request.CategoryId);
        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<GetCategoryByIdResponse>.NotFound(result.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<GetCategoryByIdResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<GetCategoryByIdResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<GetCategoryByIdResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<GetCategoryByIdResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = new GetCategoryByIdResponse()
            {
                CategoryId = result.Value!.Id,
                CategoryName = result.Value!.Name,
                CategoryDescription = result.Value!.Description,
            };
            return RequestHandlerResult<GetCategoryByIdResponse>.Ok(response);
        }
    }

    /// <summary>
    /// The category service used to get a category by its ID.
    /// </summary>
    private ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCategoryByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="categoryService"></param>
    public GetCategoryByIdQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
}
