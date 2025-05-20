namespace Application.Common.Validators.Products;

using Application.Models.Requests.Commands.Products;
using FluentValidation;

/// <summary>
/// Validator for the CreateProductCommand.
/// </summary>
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteProductCommandValidator"/> class.
    /// </summary>
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .Must(x => x > 0)
            .WithMessage("ProductId must be greater than 0.");
    }
}
