using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// Configures Application dependencies.
/// </summary>
public static class ApplicationDependencyInjection
{
    /// <summary>
    /// Adds application services.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection with the added services.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        });

        return services;
    }
}
