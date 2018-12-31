using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Models;
using OysterCard.Core.Services;
using OysterCard.Core.UOW;
using OysterCard.Persistence;
using OysterCard.Persistence.Repositories;
using OysterCard.Persistence.UOW;

namespace OysterCard.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region Wire Up Dependencies

            services.AddScoped<DbContext, OysterCardContext>();

            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOysterRepository, OysterRepository>();

            services.AddScoped<ISettingsUOW, SettingsUOW>();
            services.AddScoped<IUserUOW, UserUOW>();
            services.AddScoped<IOysterUOW, OysterUOW>();

            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOysterService, OysterService>();

            #endregion

            // Add context.
            services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add identity.
            services.AddIdentity<User, Role>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<DbContext>()
                .AddDefaultTokenProviders();

            // Configure identity options.
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            });

            // Configure site options.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRouting(options => options.LowercaseUrls = true);

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            // Ensure database exists.
            var context = serviceProvider.GetService<DbContext>();
            context.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
