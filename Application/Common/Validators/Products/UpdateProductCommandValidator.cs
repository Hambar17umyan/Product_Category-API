namespace Application.Common.Validators.Products;

using Application.Models.Requests.Commands.Products;
using FluentValidation;

/// <summary>
/// Validator for the DeleteProductCommand.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductCommandValidator"/> class.
    /// </summary>
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.ProductCategory1Id)
            .NotEqual(x => x.ProductCategory2Id)
                .WithMessage("ProductCategory1Id and ProductCategory2Id cannot be the same.");

        RuleFor(x => x.ProductCategory1Id)
            .NotEqual(x => x.ProductCategory3Id ?? -10)
                .WithMessage("ProductCategory1Id and ProductCategory3Id cannot be the same.");

        RuleFor(x => x.ProductCategory2Id)
            .NotEqual(x => x.ProductCategory3Id ?? -10)
                .WithMessage("ProductCategory2Id and ProductCategory3Id cannot be the same.");

        RuleFor(x => x.ProductCategory1Id)
            .Must(x => x > 0)
                .WithMessage("ProductCategory1Id must be greater than 0.");

        RuleFor(x => x.ProductCategory2Id)
            .Must(x => x > 0)
                .WithMessage("ProductCategory2Id must be greater than 0.");

        RuleFor(x => x.ProductId)
            .Must(x => x > 0)
                .WithMessage("ProductId must be greater than 0.");
    }
}
