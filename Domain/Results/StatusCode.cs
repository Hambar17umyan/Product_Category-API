using System.ComponentModel;

namespace Domain.Results;

/// <summary>
/// This enum represents a status code.
/// </summary>
public enum StatusCode
{
    [Description("Status unspecified.")]
    NotSpecified = 10500,
    [Description("No error.")]
    Success = 10200,
    [Description("The request was null.")]
    ArgumentNullError = 10400,
    [Description("The request was invalid.")]
    ArgumentInvalidError = 10401,
    [Description("The request was not found.")]
    NotFound = 10404,
}
