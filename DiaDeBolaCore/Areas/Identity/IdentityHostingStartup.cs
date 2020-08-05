using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DiaDeBolaCore.Areas.Identity.IdentityHostingStartup))]
namespace DiaDeBolaCore.Areas.Identity
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