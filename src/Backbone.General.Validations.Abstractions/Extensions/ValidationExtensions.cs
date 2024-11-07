using Backbone.General.Exceptions.Abstractions.Exceptions.General;

namespace Backbone.General.Validations.Abstractions.Extensions;

/// <summary>
/// Contains extensions for validations.
/// </summary>
public static class ValidationExtensions
{
    /// <summary>
    /// Attempts to check and retrieve a specific validation exception from an exception chain.
    /// </summary>
    /// <typeparam name="TValidationException">The type of validation exception to search for.</typeparam>
    /// <param name="exception">The base exception to check if it contains any validation exceptions.</param>
    /// <param name="validationException">Found validation exception to the specified type.</param>
    /// <returns>True if any validation exception to the specified type is found, otherwise false.</returns>
    public static bool TryGetValidationException<TValidationException>(this Exception exception, out TValidationException? validationException)
        where TValidationException : Exception, IAppException
    {
        for (var baseException = exception; baseException != null; baseException = baseException.InnerException)
        {
            if (baseException is TValidationException foundException)
            {
                validationException = foundException;
                return true;
            }
        }

        validationException = null;
        return false;
    }
}