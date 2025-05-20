namespace Application.RequestHandlers.CommandHandlers.Categories; 

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Application.Services.ModelServices;
using Domain.Models;
using Domain.Results;

/// <summary>
/// This class handles the updating of a category.
/// </summary>
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, RequestHandlerResult<UpdateCategoryResponse>>
{
    public async Task<RequestHandlerResult<UpdateCategoryResponse>> HandleAsync(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category(request.CategoryName, request.CategoryDescription);
        var updateResult = await this._categoryService.TryUpdateAsync(entity);

        if (updateResult.IsFail)
        {
            switch (updateResult.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<UpdateCategoryResponse>.NotFound(updateResult.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<UpdateCategoryResponse>.BadRequest(updateResult.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<UpdateCategoryResponse>.BadRequest(updateResult.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<UpdateCategoryResponse>.Unknown(updateResult.Message);
                default:
                    return RequestHandlerResult<UpdateCategoryResponse>.InternalServerError(updateResult.Message);
            }
        }

        var response = new UpdateCategoryResponse()
        {
            CategoryId = request.CategoryId,
            CategoryDescription = updateResult.Value!.Description,
            CategoryName = updateResult.Value.Name,
            IsDeleted = true
        };

        return RequestHandlerResult<UpdateCategoryResponse>.Ok(response);
    }

    /// <summary>
    /// The category service used to update a category.
    /// </summary>
    private ICategoryService _categoryService;

    /// <summary>
    /// This is the constructor for the UpdateCategoryCommandHandler class.
    /// </summary>
    /// <param name="categoryService"></param>
    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }
}
