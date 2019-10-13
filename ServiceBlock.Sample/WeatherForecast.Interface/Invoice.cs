using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Storage;
using ServiceBlock.Messaging;

namespace WeatherForecast.Interface
{
    [Storage(typeof(MemoryStorage<>))]
    [EmitEvents]
    [ReadOnly(true)]
    public class Invoice : AbstractResource
    {
        public Person Sender { get; set; }
    }

    public class Person
    {
        [Required]
        public string Name { get; set; }
    }
}
