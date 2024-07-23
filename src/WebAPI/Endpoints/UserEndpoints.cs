using Application.Features.Users.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAPI.Endpoints;

internal static class UserEndpoints
{
    internal static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/users")
            .WithTags("users")
            .WithOpenApi()
            .RequireRateLimiting("fixed")
            .RequireAuthorization();

        group.MapPost(string.Empty, CreateUser)
            .WithName(nameof(CreateUser));

        group.MapGet(string.Empty, GetUsers)
            .WithName(nameof(GetUsers));
    }

    internal static IResult GetUsers()
    {
        return Results.Ok("test");
    }

    internal static async Task<Results<Ok<User>, NotFound<string>>> CreateUser(CreateUserCommand request, IMediator mediator)
    {
        if (mediator != null)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);
            return TypedResults.Ok(result);
        }

        return TypedResults.NotFound($"Could not create user {request}");
    }

    internal static Results<Ok<IEnumerable<User>>, NotFound<string>> GetUser(IMediator mediator)
    {
        if (mediator != null)
        {
            return TypedResults.Ok(Enumerable.Empty<User>());
        }

        return TypedResults.NotFound($"Could not get users");
    }
}
