#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ServiceBlock.Extensions;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Core
{
    public class Block : BaseBlock
    {


        public static IEnumerable<Type> GetResourceTypes() => GetBlockTypes().Where(x => typeof(AbstractResource).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
        public static IEnumerable<IServiceConfiguration> GetServiceConfigurators() =>
        GetBlockTypes()
        .Where(t => t.IsClass && typeof(IServiceConfiguration).IsAssignableFrom(t))
        .Select(Activator.CreateInstance)
        .Cast<IServiceConfiguration>();

        public static void Run(string[] args, Logger? logger = null)
        {

            if (logger != null)
            {
                Log.Logger = logger;
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
               .WriteTo.ColoredConsole()
                   .CreateLogger();
            }


            try
            {
                Log.Information("Starting microservice");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Microservice terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });
    }
}