using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.Property(x => x.EntityVersion)
                .IsConcurrencyToken()
                .IsRowVersion();

            builder.Property(x => x.Balance).HasDefaultValue(0);

            // Oyster rate precision and scale.
            // Scale: max £9.
            // Precision: max 2 decimal points.
            builder.Property(x => x.Balance).HasColumnType("decimal(1,2)");

            // Oyster balance precision and scale.
            // Scale: max £9999.
            // Precision: max 2 decimal points.
            builder.Property(x => x.Balance).HasColumnType("decimal(4,2)");

            // Oyster has one user.
            // User has many oysters.
            builder.HasOne(x => x.User);
        }
    }
}
