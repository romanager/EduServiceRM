using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduServiceRM.Models;

namespace EduServiceRM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = scope.ServiceProvider.GetService<ApplicationContext>();
                
                DataSeeder.SeedUsers(context, 10);
                DataSeeder.SeedGroups(context, 9);
                DataSeeder.SeedUserGroups(context);
                DataSeeder.SeedVideos(context, 30);
                DataSeeder.UpdateVideos(context, 30);
                DataSeeder.SeedUserVideos(context);
                DataSeeder.SeedFlows(context, 12);
                DataSeeder.SeedUserFlows(context);
                DataSeeder.SeedGroupVideos(context);
                DataSeeder.SeedGroupFlows(context);
                DataSeeder.SeedFlowVideos(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
