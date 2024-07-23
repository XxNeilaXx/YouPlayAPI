// <copyright file="BaseEnumeration.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using System.Reflection;

namespace Domain.Enumerations;

/// <summary>
/// The enumeration class.
/// </summary>
public abstract class BaseEnumeration : IComparable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEnumeration"/> class.
    /// </summary>
    /// <param name="id">The id of the enumeration.</param>
    /// <param name="name">The name of the enumeration.</param>
    protected BaseEnumeration(int id, string name) => (this.Id, this.Name) = (id, name);

    /// <summary>
    /// Gets the name of the enumeration.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the identifier of the enumeration.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Compares the left and the right enumerations.
    /// </summary>
    /// <param name="left">First object.</param>
    /// <param name="right">Second object.</param>
    /// <returns>True if the left enumeration is equal to the right enumeration.</returns>
    public static bool operator ==(BaseEnumeration left, BaseEnumeration right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    /// <summary>
    /// Compares the left and the right enumerations.
    /// </summary>
    /// <param name="left">First object.</param>
    /// <param name="right">Second object.</param>
    /// <returns>True if the left enumeration is different from the right enumeration.</returns>
    public static bool operator !=(BaseEnumeration left, BaseEnumeration right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Compares the left and the right enumerations.
    /// </summary>
    /// <param name="left">First object.</param>
    /// <param name="right">Second object.</param>
    /// <returns>True if the left enumeration is less than the right enumeration.</returns>
    public static bool operator <(BaseEnumeration left, BaseEnumeration right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    /// <summary>
    /// Compares the left and the right enumerations.
    /// </summary>
    /// <param name="left">First object.</param>
    /// <param name="right">Second object.</param>
    /// <returns>True if the left enumeration is less or equal to the right enumeration.</returns>
    public static bool operator <=(BaseEnumeration left, BaseEnumeration right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    /// <summary>
    /// Compares the left and the right enumerations.
    /// </summary>
    /// <param name="left">First object.</param>
    /// <param name="right">Second object.</param>
    /// <returns>True if the left enumeration is bigger than the right enumeration.</returns>
    public static bool operator >(BaseEnumeration left, BaseEnumeration right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    /// <summary>
    /// Compares the left and the right enumerations.
    /// </summary>
    /// <param name="left">First object.</param>
    /// <param name="right">Second object.</param>
    /// <returns>True if the left enumeration is bigger or equal to the right enumeration.</returns>
    public static bool operator >=(BaseEnumeration left, BaseEnumeration right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }

    /// <summary>
    /// Gets all available enumerations of one specific type.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <returns>All available enumerations of this type.</returns>
    public static IEnumerable<T> GetAll<T>()
        where T : BaseEnumeration => typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
              .Select(f => f.GetValue(null))
              .Cast<T>();

    /// <summary>
    /// Gets the name of the enumeration.
    /// </summary>
    /// <returns>The name of the enumeration.</returns>
    public override string ToString() => this.Name;

    /// <summary>
    /// Compares two enumerations.
    /// </summary>
    /// <param name="obj">The enumeration to be compared to.</param>
    /// <returns>True if they are the same, false otherwise.</returns>
    public override bool Equals(object? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        if (obj is not BaseEnumeration otherValue)
        {
            return false;
        }

        var typeMatches = this.GetType().Equals(obj.GetType());
        var valueMatches = this.Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    /// <summary>
    /// Compares two enumerations.
    /// </summary>
    /// <param name="obj">The other enumeration to be compared to.</param>
    /// <returns>Returns 0 if the enumerations are the same, -1 if the left side is less than the right side, and 1 if the left side is bigger than the right side.</returns>
    public int CompareTo(object? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return this.Id.CompareTo(((BaseEnumeration)obj).Id);
    }

    /// <summary>
    /// Get the hash code.
    /// </summary>
    /// <returns>The int representing the hash code of the enumeration.</returns>
    public override int GetHashCode() => this.Id.GetHashCode();
}
