namespace Application.Common.Validators.Categories;

using Application.Models.Requests.Commands.Products;
using Application.Models.Requests.Queries.Categories;
using Application.Models.Requests.Queries.Products;
using FluentValidation;

/// <summary>
/// Validator for the GetCategoriesPaginationQuery.
/// </summary>
public class GetCategoriesPaginationQueryValidator : AbstractValidator<GetCategoriesPaginationQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCategoriesPaginationQueryValidator"/> class.
    /// </summary>
    public GetCategoriesPaginationQueryValidator()
    {
        RuleFor(x => x.Page)
            .Must(x => x > 0)
                .WithMessage("Page must be greater than 0.");

        RuleFor(x => x.PageSize)
            .Must(x => x > 0)
                .WithMessage("PageSize must be greater than 0.");
    }
}
