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
            builder.Property(x => x.EntityCreated).HasDefaultValueSql("getdate()");
            builder.Property(x => x.EntityActive).HasDefaultValue(true);
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

            // User has many oysters.
            // Oyster has one user.
            builder.HasMany(x => x.Oysters);
        }
    }
}
