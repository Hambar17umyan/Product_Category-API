namespace Application.Common.Validators.Products;

using Application.Models.Requests.Commands.Products;
using Application.Models.Requests.Queries.Products;
using FluentValidation;

/// <summary>
/// Validator for the GetProductByIdQuery.
/// </summary>
public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductByIdQueryValidator"/> class.
    /// </summary>
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.ProductId)
            .Must(x => x > 0)
                .WithMessage("ProductId must be greater than 0.");
    }
}
