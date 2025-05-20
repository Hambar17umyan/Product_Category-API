namespace Application.Common.Validators.Products;

using Application.Models.Requests.Commands.Products;
using FluentValidation;

/// <summary>
/// Validator for the CreateProductCommand.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductCommandValidator"/> class.
    /// </summary>
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductCategory1Id).NotEqual(x => x.ProductCategory2Id).WithMessage("ProductCategory1Id and ProductCategory2Id cannot be the same.");
        RuleFor(x => x.ProductCategory1Id).NotEqual(x => x.ProductCategory3Id ?? -10).WithMessage("ProductCategory1Id and ProductCategory3Id cannot be the same.");
        RuleFor(x => x.ProductCategory2Id).NotEqual(x => x.ProductCategory3Id ?? -10).WithMessage("ProductCategory2Id and ProductCategory3Id cannot be the same.");

        RuleFor(x => x.ProductCategory1Id).Must(x => x > 0).WithMessage("ProductCategory1Id must be greater than 0.");
        RuleFor(x => x.ProductCategory2Id).Must(x => x > 0).WithMessage("ProductCategory2Id must be greater than 0.");
        RuleFor(x => x.ProductCategory3Id).Must(x => x == null || x > 0).WithMessage("ProductCategory3Id must be greater than 0 or null.");
    }
}
