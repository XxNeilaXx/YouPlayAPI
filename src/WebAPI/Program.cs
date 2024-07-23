// <copyright file="Program.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using Application;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAPI.Endpoints;
using WebAPI.Extensions;

namespace WebAPI;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args)
            .RegisterSecurityServices()
            .RegisterDocumentationServices();

        builder.Services.AddHealthChecks();

        builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        builder.Services.AddApplication()
            .AddInfrastructure(builder.Configuration);

        var app = builder.Build()
            .UseSecurityServices()
            .UseDocumentationServices();

        app.MapUserEndpoints();

        app.MapHealthChecks("/healthcheck");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHttpsRedirection();
        }

        app.Run();
    }
}
