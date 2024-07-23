using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Users.Commands;

/// <summary>
/// The command used to create an user entity.
/// </summary>
public record CreateUserCommand : IRequest<User>
{
    /// <summary>
    /// Gets the external id.
    /// </summary>
    public ExternalId? ExternalId { get; init; }

    /// <summary>
    /// Gets the user email.
    /// </summary>
    public string? EmailAddress { get; init; }

    /// <summary>
    /// Gets the user name.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Gets the created by.
    /// </summary>
    public UserId? CreatedBy { get; init; }
}
