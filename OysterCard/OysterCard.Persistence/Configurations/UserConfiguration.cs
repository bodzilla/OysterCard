using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OysterCard.Core.Models;

namespace OysterCard.Persistence.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for <see cref="User" />.
    /// </summary>
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.NormalizedEmail).IsUnique();

            builder.Property(x => x.Email).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.NormalizedEmail).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.UserName).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.NormalizedUserName).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Forename).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Surname).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.PostCode).HasMaxLength(10);

            // User has many oysters.
            // Oyster has one user.
            builder.HasMany(x => x.Oysters);
        }
    }
}
