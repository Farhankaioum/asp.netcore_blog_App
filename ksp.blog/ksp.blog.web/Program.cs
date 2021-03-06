using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using ksp.blog.membership.Contexts;
using ksp.blog.membership.Services;
using ksp.blog.web.Seeder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ksp.blog.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.RollingFile("Logs//blog-log-{Date}.log")
                        .CreateLogger();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager>();
                    var roleManager = services.GetRequiredService<RoleManager>();
                    await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);

                    Log.Information("Application Starting up");

                   // CreateHostBuilder(args).Build().Run();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "An error occurred seeding the DB.");
                }

                finally
                {
                    Log.CloseAndFlush();
                    host.Run();
                }
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
