namespace Domain.ValueObjects;

/// <summary>
/// ValueObject abstract class.
/// </summary>
public abstract class BaseValueObject
{
    /// <summary>
    /// Compares two value objects.
    /// </summary>
    /// <param name="obj">The object to be compared to.</param>
    /// <returns>True if they are the same.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
        {
            return false;
        }

        var other = (BaseValueObject)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Gets the hash code of the value object.
    /// </summary>
    /// <returns>The hash code of the object.</returns>
    public override int GetHashCode()
    {
        return this.GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    /// <summary>
    /// Returns if two value objects are equal.
    /// </summary>
    /// <param name="left">The left object.</param>
    /// <param name="right">The right object.</param>
    /// <returns>True if they are equal.</returns>
    protected static bool EqualOperator(BaseValueObject? left, BaseValueObject? right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        if (left != null)
        {
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        return false;
    }

    /// <summary>
    /// Returns if two value objects are different.
    /// </summary>
    /// <param name="left">The left object.</param>
    /// <param name="right">The right object.</param>
    /// <returns>True if they are different.</returns>
    protected static bool NotEqualOperator(BaseValueObject? left, BaseValueObject? right)
    {
        return !EqualOperator(left, right);
    }

    /// <summary>
    /// Gets the equality components used to compare value objects.
    /// </summary>
    /// <returns>The equality components.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();
}
