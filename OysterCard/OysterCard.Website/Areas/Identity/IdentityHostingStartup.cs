using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(OysterCard.Website.Areas.Identity.IdentityHostingStartup))]
namespace OysterCard.Website.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}