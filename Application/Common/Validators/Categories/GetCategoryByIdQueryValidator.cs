namespace Application.Common.Validators.Categories;

using Application.Models.Requests.Commands.Products;
using Application.Models.Requests.Queries.Categories;
using Application.Models.Requests.Queries.Products;
using FluentValidation;

/// <summary>
/// Validator for the GetProductByIdQuery.
/// </summary>
public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCategoryByIdQueryValidator"/> class.
    /// </summary>
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.CategoryId)
            .Must(x => x > 0)
                .WithMessage("CategoryId must be greater than 0.");
    }
}
