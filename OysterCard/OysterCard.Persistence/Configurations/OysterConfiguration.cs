using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;

namespace OysterCard.Persistence.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for <see cref="Oyster" />.
    /// </summary>
    internal sealed class OysterConfiguration : IEntityTypeConfiguration<Oyster>
    {
        public void Configure(EntityTypeBuilder<Oyster> builder)
        {
            builder.Property(x => x.EntityCreated).HasDefaultValueSql("getdate()");
            builder.Property(x => x.EntityActive).HasDefaultValue(true);

            builder.Property(x => x.EntityVersion)
                .IsConcurrencyToken()
                .IsRowVersion();

            builder.Property(x => x.Forename).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Surname).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.DateOfBirth).IsRequired();

            builder.Property(x => x.Address).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.City).IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PostCode).IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Balance).HasDefaultValue(0);

            builder.Property(x => x.OysterState).HasDefaultValue(OysterState.InReview);

            // Oyster rate precision and scale.
            // Scale: max £9.
            // Precision: max 2 decimal points.
            builder.Property(x => x.Rate).HasColumnType("decimal(3,2)");

            // Oyster balance precision and scale.
            // Scale: max £99.
            // Precision: max 2 decimal points.
            builder.Property(x => x.Balance).HasColumnType("decimal(4,2)");

            // Oyster has one user.
            // User has many oysters.
            builder.HasOne(x => x.User);
        }
    }
}
