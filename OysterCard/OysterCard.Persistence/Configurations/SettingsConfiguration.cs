using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OysterCard.Core.Models;

namespace OysterCard.Persistence.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for <see cref="Settings" />.
    /// </summary>
    internal sealed class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.Property(x => x.EntityVersion)
                .IsConcurrencyToken()
                .IsRowVersion();

            builder.HasIndex(x => x.Key).IsUnique();

            builder.Property(x => x.Key).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Value).IsRequired()
                .HasMaxLength(2040);
        }
    }
}
