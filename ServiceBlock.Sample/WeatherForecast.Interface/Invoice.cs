using System.ComponentModel.DataAnnotations;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherForecast.Interface
{
    [Storage(typeof(MongoDbStorage<>))]
    [EmitEvents]
    public class Invoice : AbstractResource
    {
        public IEnumerable<int> InvoiceNumber { get; set; }

        [Queryable]
        public string Name { get; set; }

        [Queryable]
        public Person Sender { get; set; }

        public override Task OnRead()
        {
            Name = Name + Name;
            return base.OnRead();
        }
    }

    public class Person
    {
        [Required]
        public string Name { get; set; }
    }
}
