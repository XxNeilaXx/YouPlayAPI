// <copyright file="UserId.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

namespace Domain.ValueObjects;

/// <summary>
/// UserId.
/// </summary>
public sealed class UserId : BaseValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserId"/> class.
    /// </summary>
    /// <param name="id">The user identifier.</param>
    public UserId(int id)
    {
        this.Id = id;
    }

    private UserId()
    {
        this.Id = 0;
    }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    public int Id { get; private init; }

    /// <summary>
    /// Gets the components used to compare instances of the  <see cref="UserId"/> class.
    /// </summary>
    /// <returns>The components one by one.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Id;
    }
}
