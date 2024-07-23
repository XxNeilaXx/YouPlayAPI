using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Extensions;

internal static class SecurityExtension
{
    internal static WebApplicationBuilder RegisterSecurityServices(this WebApplicationBuilder builder)
    {
        if (builder != null)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var domain = builder.Configuration.GetValue<string?>("Auth0:Domain") ?? throw new SecurityTokenInvalidIssuerException(); // "https://dev-g6f6tq2uwjb3uaml.us.auth0.com/",
                var audience = builder.Configuration.GetValue<string?>("Auth0:Audience") ?? throw new SecurityTokenInvalidAudienceException(); // "YouPlay",
                var secret = builder.Configuration.GetValue<string?>("Auth0:SigningSecret") ?? throw new SecurityTokenInvalidSigningKeyException(); // "nym2oeoOSeePhAfmphT3RPtAMQEQnEPz"

                if (!string.IsNullOrWhiteSpace(domain) && !string.IsNullOrWhiteSpace(audience) && !string.IsNullOrWhiteSpace(secret))
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = domain,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    };
                }
                else
                {
                    throw new SecurityTokenException();
                }
            });

            builder.Services.AddAuthorization();

            builder.Services.AddCors();
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }

        return builder;
    }

    internal static WebApplication UseSecurityServices(this WebApplication app)
    {
        if (app != null)
        {
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }
        else
        {
            throw new ArgumentNullException(nameof(app));
        }

        return app;
    }
}
