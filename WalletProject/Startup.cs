using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Services;

namespace Wallet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentity<UserRecord, IdentityRole>().AddEntityFrameworkStores<WalletContext>();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/user/login");
            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/user/login");

            services.AddScoped<AccountsManager>();
            services.AddScoped<OperationManager>();
            services.AddScoped<CurrencyManager>();
            services.AddScoped<CommissionManager>();

            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<WalletContext>((provider, options) =>
            {
                options.UseNpgsql(Configuration["Database:ConnectionString"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}