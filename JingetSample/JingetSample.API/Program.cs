using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using Jinget.ApplicationCore.WebApi.Extensions.WebHostExtensions;

namespace JingetSample.API
{
    public class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var webHostBuilder = JingetProgram.Configure(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureKestrel(c => c.AddServerHeader = false)
                        .UseIISIntegration()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>();
                })
                .LogToFile(config.GetSection("Logging:BlackList").Get<string[]>());

            return webHostBuilder;
        }
    }
}
