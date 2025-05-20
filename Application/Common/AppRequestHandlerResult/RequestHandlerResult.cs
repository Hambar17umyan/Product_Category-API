namespace Application.Common.AppRequestHandlerResult;

using Application.Models.Response.Abstract;
using System.Net;

/// <summary>
/// Represents the result of a request handler.
/// </summary>
/// <typeparam name="TResponse">The type of response.</typeparam>
/// <param name="StatusCode">The status code.</param>
/// <param name="Response">The response.</param>
/// <param name="Message">The message.</param>
public record RequestHandlerResult<TResponse>(HttpStatusCode StatusCode, TResponse? Response, string? Message)
    where TResponse : IResponse
{
    /// <summary>
    /// Creates a new instance of <see cref="RequestHandlerResult{TResponse}"/> with the specified status code and message.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static RequestHandlerResult<TResponse> NotFound(string? message)
        => new RequestHandlerResult<TResponse>(HttpStatusCode.NotFound, default, message);

    /// <summary>
    /// Creates a new instance of <see cref="RequestHandlerResult{TResponse}"/> with the specified status code and message.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static RequestHandlerResult<TResponse> BadRequest(string? message)
        => new RequestHandlerResult<TResponse>(HttpStatusCode.BadRequest, default, message);

    /// <summary>
    /// Creates a new instance of <see cref="RequestHandlerResult{TResponse}"/> with the specified status code and message.
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public static RequestHandlerResult<TResponse> Ok(TResponse? response)
        => new RequestHandlerResult<TResponse>(HttpStatusCode.OK, response, null);

    /// <summary>
    /// Creates a new instance of <see cref="RequestHandlerResult{TResponse}"/> with the specified status code and message.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static RequestHandlerResult<TResponse> Unknown(string? message)
        => new RequestHandlerResult<TResponse>(HttpStatusCode.InternalServerError, default, message);

    /// <summary>
    /// Creates a new instance of <see cref="RequestHandlerResult{TResponse}"/> with the specified status code and message.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static RequestHandlerResult<TResponse> InternalServerError(string? message)
        => new RequestHandlerResult<TResponse>(HttpStatusCode.InternalServerError, default, message);
}
