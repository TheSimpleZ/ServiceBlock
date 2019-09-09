using System;
using MicroNet;
using MicroNet.Storage;

namespace WeatherForecast
{
    [Storage(typeof(MemoryStorage<Invoice>))]
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
