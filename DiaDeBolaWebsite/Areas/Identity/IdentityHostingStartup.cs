using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DiaDeBolaWebsite.Areas.Identity.IdentityHostingStartup))]
namespace DiaDeBolaWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}