using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MicroNet.Startup;
using Microsoft.Extensions.DependencyInjection;
using MicroNet.Storage;

namespace WeatherForecast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((IServiceCollection servicesCollection) =>
                        servicesCollection.AddSingleton<IStorage<WeatherForecast>, MemoryStorage<WeatherForecast>>()
                        ).UseStartup<MicroStartup>();
                });
    }
}
