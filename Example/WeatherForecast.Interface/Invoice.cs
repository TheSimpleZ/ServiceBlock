using System;
using System.ComponentModel.DataAnnotations;
using mService.Interface;
using mService.Interface.Storage;

namespace WeatherForecast.Interface
{
    [Storage(typeof(MemoryStorage<Invoice>))]
    public class Invoice : IResource
    {
        public Guid Id { get; set; }
        public Person Sender { get; set; }
    }

    public class Person
    {
        [Required]
        public string Name { get; set; }
    }
}
