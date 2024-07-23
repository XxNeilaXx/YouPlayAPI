// <copyright file="Email.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

namespace Domain.ValueObjects;

/// <summary>
/// Email.
/// </summary>
public sealed class Email : BaseValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class.
    /// </summary>
    /// <param name="address">The email address.</param>
    public Email(string address)
    {
        this.Address = address;
    }

    private Email()
    {
        this.Address = string.Empty;
    }

    /// <summary>
    /// Gets the email address.
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Gets the components used to compare instances of the  <see cref="Email"/> class.
    /// </summary>
    /// <returns>The components one by one.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Address;
    }
}
