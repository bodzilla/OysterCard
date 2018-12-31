using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts;
using OysterCard.Core.Models;
using OysterCard.Persistence.Configurations;

namespace OysterCard.Persistence
{
    /// <inheritdoc cref="IdentityDbContext{TUser}" />
    /// <summary>
    /// The database context.
    /// </summary>
    public sealed class OysterCardContext : IdentityDbContext<User, Role, int>, IDbContext
    {
        /// <summary>
        /// All public dbsets, the internal dbsets are inherited from <see cref="IdentityDbContext{TUser}"/>.
        /// </summary>
        #region Public Properties

        public DbSet<Settings> Settings { get; set; }

        public DbSet<Oyster> Oysters { get; set; }

        #endregion

        #region Default Constructor

        /// <inheritdoc />
        public OysterCardContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// This method is run when the context is creating the model.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Model Configurations

            // The derived oysters are inerhited from the base oyster and need to be included as entities.
            builder.Entity<OysterJunior>();
            builder.Entity<OysterAdult>();
            builder.Entity<OysterSenior>();

            builder.ApplyConfiguration(new SettingsConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OysterConfiguration());

            #endregion
        }
    }
}
