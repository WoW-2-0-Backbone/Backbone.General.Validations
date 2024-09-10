using Backbone.General.Validations.Abstractions.Exceptions;

namespace Backbone.General.Validations.Abstractions.Extensions;

/// <summary>
/// Contains extensions for validations.
/// </summary>
public static class ValidationExtensions
{
    /// <summary>
    /// Attempts to check and get validation exception from app exception.
    /// </summary>
    /// <param name="exception">The base exception to check if it contains any validation exceptions.</param>
    /// <param name="validationException">Found validation exception.</param>
    /// <returns>True, if any validation exception is found, otherwise false.</returns>
    public static bool TryGetValidationException(this Exception exception, out AppValidationException? validationException)
    {
        var baseException = exception;
        while (baseException != null)
        {
            if (baseException is AppValidationException appValidationException)
            {
                validationException = appValidationException;
                return true;
            }

            baseException = baseException.InnerException;
        }

        validationException = null;
        return false;
    }
}