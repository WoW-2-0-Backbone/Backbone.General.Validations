using FluentValidation;
using FluentValidation.Results;

namespace Backbone.General.Validations.Abstractions.Exceptions;

/// <summary>
/// Represents application validation exception.
/// </summary>
public class AppValidationException(IEnumerable<ValidationFailure> errors, bool isPublicValidation = true) : ValidationException(errors)
{
    /// <summary>
    /// Determines if the validation is public and should be shown to the user.
    /// </summary>
    public bool IsPublicValidation { get; set; } = isPublicValidation;
}