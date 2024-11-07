using System.Net;
using Backbone.General.Exceptions.Abstractions.Exceptions.General;
using FluentValidation;
using FluentValidation.Results;

namespace Backbone.General.Validations.FluentValidation.Exceptions;

/// <summary>
/// Represents an application exception specifically for Fluent Validation errors.
/// </summary>
public class AppFluentValidationException : ValidationException, IAppException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppFluentValidationException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="errors">A collection of <see cref="ValidationFailure"/> objects.</param>
    /// <param name="statusCode">Optional HTTP status code for this exception.</param>
    /// <param name="meta">Optional metadata for additional information.</param>
    public AppFluentValidationException(
        string message,
        IEnumerable<ValidationFailure> errors,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        Dictionary<string, string>? meta = null)
        : base(message, errors)
    {
        StatusCode = statusCode;
        Meta = meta ?? new Dictionary<string, string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppFluentValidationException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="statusCode">Optional HTTP status code for this exception.</param>
    /// <param name="meta">Optional metadata for additional information.</param>
    public AppFluentValidationException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        Dictionary<string, string>? meta = null)
        : base(message, Enumerable.Empty<ValidationFailure>())
    {
        StatusCode = statusCode;
        Meta = meta ?? new Dictionary<string, string>();
    }

    /// <inheritdoc />
    public HttpStatusCode StatusCode { get; init; }

    /// <inheritdoc />
    public Dictionary<string, string> Meta { get; init; }
}