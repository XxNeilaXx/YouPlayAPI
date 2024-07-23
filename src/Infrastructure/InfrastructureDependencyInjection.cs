// <copyright file="InfrastructureDependencyInjection.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using Domain.Repositories;
using Infrastructure.Exceptions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

/// <summary>
/// InfrastructureDependencyInjection.
/// </summary>
public static class InfrastructureDependencyInjection
{
    private const string ConnectionStringKey = "DefaultConnection";

    /// <summary>
    /// AddInfrastructure.
    /// </summary>
    /// <param name="services">The services collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The.</returns>
    /// <exception cref="ConfigurationMissingException">If the connectionString is missing from the configuration.</exception>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringKey);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ConfigurationMissingException(ConnectionStringKey);
        }

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
