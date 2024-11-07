using System.ComponentModel.DataAnnotations;
using System.Net;
using Backbone.General.Exceptions.Abstractions.Exceptions.General;

namespace Backbone.General.Validations.Abstractions.Exceptions;

/// <summary>
/// Represents application validation exception.
/// </summary>
public class AppValidationException : AppException, IAppValidationException
{
  /// <summary>
    /// Initializes a new instance of the <see cref="AppValidationException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="statusCode">Optional HTTP status code for this exception.</param>
    /// <param name="meta">Optional metadata for additional information.</param>
    public AppValidationException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        Dictionary<string, string>? meta = null)
        : base(message, statusCode, meta)
    {
        ValidationResults = Array.Empty<ValidationResult>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppValidationException"/> class with a specified error message, validation results, and optional metadata.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="validationResults">A collection of validation results, either from DataAnnotations or FluentValidation.</param>
    /// <param name="statusCode">Optional HTTP status code for this exception (default is 400 Bad Request).</param>
    /// <param name="meta">Optional metadata for additional information.</param>
    public AppValidationException(
        string message,
        IEnumerable<ValidationResult> validationResults,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        Dictionary<string, string>? meta = null)
        : base(message)
    {
        StatusCode = statusCode;
        Meta = meta ?? new Dictionary<string, string>();
        ValidationResults = validationResults;
    }
    
    /// <summary>
    /// Gets the validation results that caused the exception.
    /// </summary>
    public IEnumerable<ValidationResult> ValidationResults { get; init; }
}