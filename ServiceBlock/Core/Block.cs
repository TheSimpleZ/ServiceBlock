#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ServiceBlock.Extensions;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Internal;

namespace ServiceBlock.Core
{
    public static class Block
    {

        public static IEnumerable<TypeInfo> Controllers => GetResourceController(readOnly: true).Concat(GetResourceController());

        public static void Run(string[] args, Logger? logger = null)
        {
            ValidateResources();

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
                Log.Information("Starting ServiceBlock");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ServiceBlock terminated unexpectedly");
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

        private static IEnumerable<TypeInfo> GetResourceController(bool readOnly = false)
        {
            bool predicate(Type r) => readOnly ? r.HasAttribute<ReadOnlyAttribute>() : !r.HasAttribute<ReadOnlyAttribute>();

            var controllerType = readOnly ? typeof(ResourceControllerRead<>) : typeof(ResourceControllerWrite<>);
            return BlockInfo.ResourceTypes.Where(predicate).Select(r => controllerType.MakeGenericType(r).GetTypeInfo());
        }

        private static void ValidateResources()
        {
            var exceptions = BlockInfo.ResourceTypes.Where(r => !r.HasAttribute<StorageAttribute>()).Select(r => new NoStorageException($"The resource {r.GetType().Name} does not have a compatible storage associated with it."));
            if (exceptions.Any())
            {
                throw new AggregateException("One or more resources does not have a storage", exceptions);
            }
        }
    }
}