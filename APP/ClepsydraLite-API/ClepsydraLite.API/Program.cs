using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClepsydraLite.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace ClepsydraLite.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                .ConfigureNLog("nlog.config")
                .GetCurrentClassLogger();

            try
            {
                logger.Info("Initializing application...");

                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var context = scope.ServiceProvider.GetService<ShopDbContext>();

                        // for demo purposes, delete the database & migrate on startup
                        // so we can start with a clean state
                        //context.Database.EnsureDeleted();
                        context.Database.Migrate();

                    }
                    catch (Exception ex)
                    {
                          logger.Error(ex, "Error on applying migrations");
                    }
                }

                host.Run();

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Application stopped because of exception");
                throw ex;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseNLog();
                });
    }
}
