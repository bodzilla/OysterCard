using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.Services;
using OysterCard.Persistence;
using OysterCard.Persistence.Repositories;
using OysterCard.Persistence.UOW;

namespace OysterCard.Website
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Contains configurations for wiring up all dependency injections.
        /// </summary>
        public static void WireUpDependencies(this IServiceCollection services)
        {
            // Database context.
            services.AddScoped<DbContext, OysterCardContext>();

            // Repositories.
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOysterRepository, OysterRepository>();

            // UOW.
            services.AddScoped<ISettingsUOW, SettingsUOW>();
            services.AddScoped<IUserUOW, UserUOW>();
            services.AddScoped<IOysterUOW, OysterUOW>();

            // Services.
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOysterService, OysterService>();
        }
    }
}