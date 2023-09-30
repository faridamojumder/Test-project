using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;
using TestProject.Services;

namespace TestProject
{
    public class Program

    {
        //public static void Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args)
        //                 .Build();
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        //        try
        //        {
        //            //Seed Default Users
        //            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        //            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        //            await ApplicationDbContextSeed.SeedEssentialsAsync(userManager, roleManager);
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = loggerFactory.CreateLogger<Program>();
        //            logger.LogError(ex, "An error occurred seeding the DB.");
        //        }
        //    }
        //    host.Run();

        //    CreateHostBuilder(args).Build().Run();
        //}


        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                         .Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    //Seed Default Users
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ApplicationDbContextSeed.SeedEssentialsAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
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
