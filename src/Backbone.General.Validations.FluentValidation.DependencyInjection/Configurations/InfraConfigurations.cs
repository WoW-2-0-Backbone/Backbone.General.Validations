using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Backbone.General.Validations.FluentValidation.DependencyInjection.Configurations;

/// <summary>
/// Provides extension methods to configure the fluent validation.
/// </summary>
public static class InfraConfigurations
{
    /// <summary>
    /// Configures the general validation settings.
    /// </summary>
    /// <param name="services">The service collection to add the validation settings to.</param>
    /// <param name="assemblies">A collection of assemblies to scan for validators.</param>
    public static IServiceCollection AddFluentValidation(this IServiceCollection services, ICollection<Assembly> assemblies)
    {
        services.AddValidatorsFromAssemblies(assemblies);
        
        return services;
    }
}