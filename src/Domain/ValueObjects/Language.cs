// <copyright file="Language.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

namespace Domain.ValueObjects;

/// <summary>
/// Language.
/// </summary>
public sealed class Language : BaseValueObject
{
    /// <summary>
    /// Gets the components used to compare instances of the  <see cref="Language"/> class.
    /// </summary>
    /// <returns>The components one by one.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
