using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ServiceBlock.Core;

namespace WeatherForecast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Block.Run(args);
        }
    }
}
