using Backbone.General.Validations.Abstractions.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backbone.General.Validations.Abstractions.Configurations;

/// <summary>
/// Provides extension methods to configure the general validation dependencies.
/// </summary>
public static class InfraConfigurations
{
    /// <summary>
    /// Configures the general validation settings.
    /// </summary>
    /// <param name="services">The service collection to add the validation settings to.</param>
    /// <param name="configuration">The application configuration to bind the validation settings from.</param>
    public static void AddGeneralValidationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ValidationSettings>(configuration.GetSection(nameof(ValidationSettings)));
    }
}