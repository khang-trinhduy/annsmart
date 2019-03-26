using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BookingForm.Areas.Identity.IdentityHostingStartup))]
namespace BookingForm.Areas.Identity
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