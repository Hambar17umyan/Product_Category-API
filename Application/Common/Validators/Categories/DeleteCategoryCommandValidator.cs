namespace Application.Common.Validators.Categories;

using Application.Models.Requests.Commands.Categories;
using Application.Models.Requests.Commands.Products;
using FluentValidation;

/// <summary>
/// Validator for the DeleteProductCommand.
/// </summary>
public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteCategoryCommandValidator"/> class.
    /// </summary>
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .Must(x => x > 0)
                .WithMessage("CategoryId must be greater than 0.");
    }
}
