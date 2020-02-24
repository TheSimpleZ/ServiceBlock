using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServiceBlock.Storage.MongoDb.Options;

namespace ServiceBlock.Storage.MongoDb
{
    // Summary: ServiceBlock storage backed by mongo db.
    // Parameters:
    //   T: The resource type
    public class MongoDbStorage<T> : Storage<T> where T : AbstractResource
    {
        private readonly IMongoCollection<T> resources;
        private readonly ILogger<MemoryStorage<T>> _logger;

        public MongoDbStorage(ILogger<MemoryStorage<T>> logger, IConfiguration config, IOptionsMonitor<Options.MongoDb> options) : base(logger)
        {
            var client = new MongoClient(config.GetConnectionString(nameof(MongoDb)));
            var database = client.GetDatabase(options.CurrentValue.DatabaseName);

            resources = database.GetCollection<T>(typeof(T).Name);

            _logger = logger;
        }


        protected override async Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Empty;
            foreach (var kv in searchParams)
            {
                filter = filter & builder.Eq(kv.Key, kv.Value);
            }
            var filteredResources = await resources.FindAsync(filter);
            return await filteredResources.ToListAsync();
        }

        protected override async Task<T> ReadItem(Guid Id)
        {

            var resource = (await resources.FindAsync<T>(r => r.Id == Id)).FirstOrDefault();

            if (resource == null)
                throw new NotFoundException($"Could not find {typeof(T).Name} with ID {Id}");

            return resource;
        }

        protected override async Task<T> CreateItem(T resource)
        {
            await resources.InsertOneAsync(resource);
            return resource;
        }

        protected override async Task DeleteItem(Guid Id) => await resources.DeleteOneAsync(r => r.Id == Id);


        protected override async Task<T> UpdateItem(T resource)
        {
            var result = await resources.ReplaceOneAsync(r => r.Id == resource.Id, resource);

            if (result.IsAcknowledged && result.MatchedCount < 1)
            {
                throw new NotFoundException($"Could not find {typeof(T).Name} with ID {resource.Id}");
            }

            return resource;
        }
    }
}