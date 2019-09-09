using System;
using MicroNet;

namespace WeatherForecast
{
    public class Invoice : IResource
    {
        public Guid Id { get; set; }
        public Person Sender { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
