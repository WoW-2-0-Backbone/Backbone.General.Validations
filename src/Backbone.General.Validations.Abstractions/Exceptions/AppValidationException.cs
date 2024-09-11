
using Backbone.General.Exceptions.Abstractions.Exceptions.General;

namespace Backbone.General.Validations.Abstractions.Exceptions;

/// <summary>
/// Represents application validation exception.
/// </summary>
public class AppValidationException : AppException
{
    /// <inheritdoc />
    public AppValidationException(Exception exception, bool isPublicValidation = true) : base("Validation failed", exception)
    {
        IsPublicValidation = isPublicValidation;
    }

    /// <inheritdoc />
    public AppValidationException(string message, Exception exception, bool isPublicValidation = true) : base(message, exception)
    {
        IsPublicValidation = isPublicValidation;
    }

    /// <summary>
    /// Determines if the validation is public and should be shown to the user.
    /// </summary>
    public bool IsPublicValidation { get; set; }
}