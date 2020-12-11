using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Services;

namespace Wallet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<UserRecord>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var currencyManager = services.GetRequiredService<CurrencyManager>();
                    var context = services.GetRequiredService<WalletDbContext>();
                    await IdentityDbInitializer.Initialize(context, userManager, rolesManager, currencyManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            await host.RunAsync();
        }


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
            var exeLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return Path.Combine(Path.GetDirectoryName(exeLocation), "Configuration");
        }
    }
}