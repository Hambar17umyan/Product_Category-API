namespace Application.Common.Validators.Products;

using Application.Models.Requests.Commands.Products;
using Application.Models.Requests.Queries.Products;
using FluentValidation;

/// <summary>
/// Validator for the CreateProductCommand.
/// </summary>
public class GetProductsPaginationQueryValidator : AbstractValidator<GetProductsPaginationQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductsPaginationQueryValidator"/> class.
    /// </summary>
    public GetProductsPaginationQueryValidator()
    {
        RuleFor(x => x.Page)
            .Must(x => x > 0)
                .WithMessage("Page must be greater than 0.");

        RuleFor(x => x.PageSize)
            .Must(x => x > 0)
                .WithMessage("PageSize must be greater than 0.");
    }
}
