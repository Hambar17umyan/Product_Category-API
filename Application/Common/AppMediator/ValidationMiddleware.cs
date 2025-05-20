namespace Application.Common.AppMediator; 

using FluentValidation;

public class ValidationMiddleware
{
    /// <summary>
    /// The service provider used to resolve dependencies.
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationMiddleware"/> class.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ValidationMiddleware(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Handles the validation of a request asynchronously.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public async Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request, Func<IRequest<TResponse>, Task<TResponse>> next)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
        var validator = _serviceProvider.GetService(validatorType) as IValidator;

        if (validator != null)
        {
            var context = new ValidationContext<object>(request!);
            var result = await validator.ValidateAsync(context);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }

        return await next(request);
    }
}