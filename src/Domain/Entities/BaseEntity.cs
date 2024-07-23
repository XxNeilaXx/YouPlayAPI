// <copyright file="BaseEntity.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using MediatR;

namespace Domain.Entities;

/// <summary>
/// BaseEntity.
/// </summary>
/// <typeparam name="T">The identifier type.</typeparam>
public abstract class BaseEntity<T>
{
    private readonly List<INotification> domainEvents;

    /// <summary>
    ///  Initializes a new instance of the <see cref="BaseEntity{T}"/> class.
    /// </summary>
    /// <param name="id">The entity identifier.</param>
    protected BaseEntity(T id)
    {
        this.Id = id;
        this.domainEvents = new List<INotification>();
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="BaseEntity{T}"/> class from being created.
    /// </summary>
    private BaseEntity()
    {
        this.Id = default!;
        this.domainEvents = new List<INotification>();
    }

    /// <summary>
    /// Gets the entity identifier.
    /// </summary>
    public T Id { get; private init; }

    /// <summary>
    /// Clear the domain events.
    /// </summary>
    /// <returns>The cleared domain events.</returns>
    public IList<INotification> PopDomainEvents()
    {
        var copy = this.domainEvents.ToList();
        this.domainEvents.Clear();

        return copy;
    }
}
