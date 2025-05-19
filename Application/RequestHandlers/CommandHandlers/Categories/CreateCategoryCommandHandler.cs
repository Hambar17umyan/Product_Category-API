﻿namespace Application.RequestHandlers.CommandHandlers.Categories; 

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Application.Services.ModelServices;
using Domain.Models;
using Domain.Results;

/// <summary>
/// This class handles the creation of a category.
/// </summary>
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, RequestHandlerResult<CreateCategoryResponse>>
{
    /// <summary>
    /// This is the constructor for the CreateCategoryCommandHandler class.
    /// </summary>
    /// <param name="categoryService"></param>
    /// <param name="categoryMapper"></param>
    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }

    public async Task<RequestHandlerResult<CreateCategoryResponse>> HandleAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category(request.CategoryName, request.CategoryDescription);
        var result = await this._categoryService.TryAddAsync(entity);

        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<CreateCategoryResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<CreateCategoryResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<CreateCategoryResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<CreateCategoryResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = new CreateCategoryResponse
            {
                CategoryId = result.Value!.Id,
                CategoryName = result.Value.Name,
                CategoryDescription = result.Value.Description
            };
            return RequestHandlerResult<CreateCategoryResponse>.Ok(response);
        }
    }

    /// <summary>
    /// The category service used to create a category.
    /// </summary>
    private ICategoryService _categoryService;
}
