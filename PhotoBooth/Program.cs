using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PhotoBooth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel((context, options) =>
                {
                    options.ListenAnyIP(5000);
                    options.ListenAnyIP(4200);
                });
    }
}