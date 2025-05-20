namespace Application.Common.Validators.Categories;

using Application.Models.Requests.Commands.Categories;
using Application.Models.Requests.Commands.Products;
using FluentValidation;

/// <summary>
/// Validator for the UpdateCategoryCommand.
/// </summary>
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCategoryCommandValidator"/> class.
    /// </summary>
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .Must(x => x > 0)
                .WithMessage("CategoryId must be greater than 0.");
    }
}
