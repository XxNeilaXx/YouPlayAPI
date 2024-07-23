using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions;

internal static class DocumentationExtension
{
    internal static WebApplicationBuilder RegisterDocumentationServices(this WebApplicationBuilder builder)
    {
        if (builder != null)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme,
                    },
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        jwtSecurityScheme,
                        Array.Empty<string>()
                    },
                });
            });
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }

        return builder;
    }

    internal static WebApplication UseDocumentationServices(this WebApplication app)
    {
        if (app != null)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            throw new ArgumentNullException(nameof(app));
        }

        return app;
    }
}
