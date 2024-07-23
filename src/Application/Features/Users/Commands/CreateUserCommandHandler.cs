using System.Security.Principal;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Commands;

/// <summary>
/// CreateUserCommandHandler.
/// </summary>
public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository repository;
    private readonly IPrincipal claimPrincipal;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The user repository.</param>
    /// <param name="accessor">The http context.</param>
    public CreateUserCommandHandler(IUserRepository repository, IHttpContextAccessor accessor)
    {
        this.repository = repository;
        if (accessor != null)
        {
            this.claimPrincipal = accessor.HttpContext.User;
        }
        else
        {
            throw new ArgumentNullException(nameof(accessor));
        }
    }

    /// <summary>
    /// Handles the create user command.
    /// </summary>
    /// <param name="request">The request parameters to create an user entity.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created user entity.</returns>
    /// <exception cref="ArgumentNullException">Throwed when the request or its fields are null.</exception>
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request != null && request.ExternalId != null && request.EmailAddress != null && request.Name != null && request.CreatedBy != null)
        {
            var user = new User(new UserId(default), new ExternalId(this.claimPrincipal.Identity?.Name ?? string.Empty), new Email(request.EmailAddress), request.Name, new AuditMetadata(request.CreatedBy, DateTimeOffset.UtcNow, request.CreatedBy, DateTimeOffset.UtcNow));
            return await this.repository.CreateAsync(user).ConfigureAwait(false);
        }
        else
        {
            throw new ArgumentNullException(nameof(request));
        }
    }
}
