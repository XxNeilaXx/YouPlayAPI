// <copyright file="ExternalId.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

namespace Domain.ValueObjects;

/// <summary>
/// An identifier of the user user in external resources.
/// </summary>
public sealed class ExternalId : BaseValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExternalId"/> class.
    /// </summary>
    /// <param name="id">The external identifier value.</param>
    public ExternalId(string id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="ExternalId"/> class from being created.
    /// </summary>
    private ExternalId()
    {
        this.Id = string.Empty;
    }

    /// <summary>
    /// Gets the external identifier.
    /// </summary>
    public string Id { get; init; }

    /// <summary>
    /// Gets the components used to identify equality between instances of this class.
    /// </summary>
    /// <returns>The components.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Id;
    }
}
