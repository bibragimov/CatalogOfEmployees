using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CatalogOfEmployees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration();

                    webBuilder.UseStartup<Startup>();

                    webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                });
        }
    }
}