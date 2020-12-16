using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Wallet
{
    public class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();


        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    builder.SetBasePath(ConfigDirectoryPath()).AddJsonFile("config.json");
                    builder.AddEnvironmentVariables();
                    builder.AddCommandLine(args);
                })
                .UseStartup<Startup>();

        private static string ConfigDirectoryPath()
        {
            var exeLocation = Assembly.GetExecutingAssembly().Location;
            return Path.Combine(Path.GetDirectoryName(exeLocation), "Configuration");
        }
    }
}