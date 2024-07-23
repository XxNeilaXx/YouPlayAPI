// <copyright file="AuditMetadata.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

namespace Domain.ValueObjects;

/// <summary>
/// Audit Metadata.
/// </summary>
public sealed class AuditMetadata : BaseValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditMetadata"/> class.
    /// </summary>
    /// <param name="createdBy">The identifier of the user who created the entity.</param>
    /// <param name="createdOn">The date time with timezone representing when the entity was created.</param>
    /// <param name="lastModifiedBy">The identifier of the user who last modified the entity.</param>
    /// <param name="lastModifiedOn">The date time with timezone representing when the entity was last modified.</param>
    public AuditMetadata(UserId createdBy, DateTimeOffset createdOn, UserId lastModifiedBy, DateTimeOffset lastModifiedOn)
    {
        this.CreatedBy = createdBy;
        this.CreatedOn = createdOn;
        this.LastModifiedBy = lastModifiedBy;
        this.LastModifiedOn = lastModifiedOn;
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="AuditMetadata"/> class from being created.
    /// </summary>
    private AuditMetadata()
    {
        this.CreatedBy = new UserId(0);
        this.CreatedOn = DateTimeOffset.UtcNow;
        this.LastModifiedBy = new UserId(0);
        this.LastModifiedOn = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Gets the identifier of the user who created the entity.
    /// </summary>
    public UserId CreatedBy { get; init; }

    /// <summary>
    /// Gets the date time with timezone representing when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; init; }

    /// <summary>
    /// Gets the identifier of the user who last modified the entity.
    /// </summary>
    public UserId LastModifiedBy { get; init; }

    /// <summary>
    /// Gets the date time with timezone representing when the entity was last modified.
    /// </summary>
    public DateTimeOffset LastModifiedOn { get; init; }

    /// <summary>
    /// Gets the components used to compare instances of the  <see cref="AuditMetadata"/> class.
    /// </summary>
    /// <returns>The components one by one.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.CreatedBy;
        yield return this.CreatedOn;
        yield return this.LastModifiedBy;
        yield return this.LastModifiedOn;
    }
}
