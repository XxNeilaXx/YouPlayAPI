using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

internal sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(x => x.Id);

        builder.Property(b => b.Id)
            .HasColumnName("id")
            .HasConversion(x => x.Id, value => new UserId(value))
            .UseHiLo("id");

        builder.Property(x => x.ExternalId)
            .HasColumnName(nameof(User.ExternalId))
            .HasConversion(x => x.Id, value => new ExternalId(value));

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(x => x.Email)
           .HasColumnName("email")
           .HasConversion(x => x.Address, value => new Email(value))
           .HasMaxLength(100);

        builder.OwnsOne(p => p.AuditMetadata, auditMetadata =>
        {
            auditMetadata.Property(p => p.CreatedBy).HasColumnName(nameof(AuditMetadata.CreatedBy)).HasConversion(x => x.Id, value => new UserId(value)).IsRequired();
            auditMetadata.Property(p => p.CreatedOn).HasColumnName(nameof(AuditMetadata.CreatedOn)).IsRequired();
            auditMetadata.Property(p => p.LastModifiedBy).HasColumnName(nameof(AuditMetadata.LastModifiedBy)).HasConversion(x => x.Id, value => new UserId(value)).IsRequired();
            auditMetadata.Property(p => p.LastModifiedOn).HasColumnName(nameof(AuditMetadata.LastModifiedOn)).IsRequired();
        });
    }
}
