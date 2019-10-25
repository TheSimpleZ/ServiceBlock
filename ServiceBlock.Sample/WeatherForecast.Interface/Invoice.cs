using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Storage;

namespace WeatherForecast.Interface
{
    [Storage(typeof(MemoryStorage<>))]
    [EmitEvents]
    [ReadOnly(true)]
    public class Invoice : AbstractResource
    {
        [Queryable]
        public string InvoiceNumber { get; set; }
        public Person Sender { get; set; }
    }

    public class Person
    {
        [Required]
        public string Name { get; set; }
    }
}
