using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace WeatherForecast.Interface
{
    [Storage(typeof(MemoryStorage<Invoice>))]
    public class Invoice : IResource
    {
        [ReadOnly(true)]
        public Guid Id { get; set; }
        public Person Sender { get; set; }
    }

    public class Person
    {
        [Required]
        public string Name { get; set; }
    }
}
