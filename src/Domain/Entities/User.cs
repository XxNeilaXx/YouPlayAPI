// <copyright file="User.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using Domain.ValueObjects;

namespace Domain.Entities;

/// <summary>
/// User.
/// </summary>
public sealed class User : BaseEntity<UserId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="id">The user identifier.</param>
    /// <param name="externalId">The external user identifier.</param>
    /// <param name="email">The user email.</param>
    /// <param name="name">The user name.</param>
    /// <param name="auditMetadata">The audit metadata.</param>
    public User(
        UserId id,
        ExternalId externalId,
        Email email,
        string name,
        AuditMetadata auditMetadata)
        : base(id)
    {
        this.ExternalId = externalId;
        this.Email = email;
        this.Name = name;
        this.AuditMetadata = auditMetadata;
    }

#pragma warning disable IDE0051
#pragma warning disable S1144
    private User(
        UserId id,
        ExternalId externalId,
        Email email,
        string name)
        : base(id)
    {
        this.ExternalId = externalId;
        this.Email = email;
        this.Name = name;
        this.AuditMetadata = new AuditMetadata(new UserId(default), DateTimeOffset.UtcNow, new UserId(default), DateTimeOffset.UtcNow);
    }
#pragma warning restore IDE0051
#pragma warning restore S1144

    /// <summary>
    /// Gets the external user identifier.
    /// </summary>
    public ExternalId ExternalId { get; private init; }

    /// <summary>
    /// Gets the user email.
    /// </summary>
    public Email Email { get; private init; }

    /// <summary>
    /// Gets the user name.
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// Gets the audit metadata.
    /// </summary>
    public AuditMetadata AuditMetadata { get; private set; }
}
