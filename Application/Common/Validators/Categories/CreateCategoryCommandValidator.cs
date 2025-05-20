namespace Application.Common.Validators.Categories;

using Application.Models.Requests.Commands.Categories;
using FluentValidation;

/// <summary>
/// Validator for the CreateCategoryCommand.
/// </summary>
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCategoryCommandValidator"/> class.
    /// </summary>
    public CreateCategoryCommandValidator()
    {
        
    }
}
