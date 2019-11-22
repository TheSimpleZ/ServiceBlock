using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ServiceBlock.Storage
{
    // Summary: In-memory resource storage
    // Parameters:
    //   T: The resource type
    public class MemoryStorage<T> : Storage<T> where T : AbstractResource
    {
        private Dictionary<Guid, T> storage = new Dictionary<Guid, T>();
        private readonly ILogger<MemoryStorage<T>> _logger;

        public MemoryStorage(ILogger<MemoryStorage<T>> logger, ResourceTransformer<T>? transformer = null) : base(logger, transformer)
        {
            _logger = logger;
        }


        protected override Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
        {
            return Task.FromResult(storage.Values.Where(item => searchParams.All(p => CheckSearchParam(item, (p.Key, p.Value)))));
        }

        private bool CheckSearchParam(T item, (string name, string val) queryParam)
        {

            var propInfo = typeof(T).GetProperty(queryParam.name);
            var propVal = propInfo.GetValue(item);

            var propString = propInfo.PropertyType == typeof(string) ? (string)propVal : JsonConvert.SerializeObject(propVal);
            var propStringNormalized = Regex.Replace(propString, @"\s", "");

            var queryParamValNormalized = Regex.Replace(queryParam.val, @"\s", "");


            return propStringNormalized.Equals(queryParamValNormalized, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override Task<T> ReadItem(Guid Id)
        {

            var resource = storage.SingleOrDefault(x => x.Key == Id).Value;

            if (resource == null)
                throw new NotFoundException($"Could not find {typeof(T).Name} with ID {Id}");

            return Task.FromResult(resource);
        }

        protected override Task<T> CreateItem(T resource)
        {
            storage.Add(resource.Id, resource);
            return Task.FromResult(resource);
        }

        protected override Task DeleteItem(Guid Id)
        {
            storage.Remove(Id);
            return Task.CompletedTask;
        }


        protected override Task<T> UpdateItem(T resource)
        {
            if (storage[resource.Id] == null)
                throw new NotFoundException();

            storage[resource.Id] = resource;
            return Task.FromResult(resource);
        }
    }
}