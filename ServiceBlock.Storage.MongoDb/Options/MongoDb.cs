namespace ServiceBlock.Storage.MongoDb.Options
{
    // All settings for MongoDb storages
    public class MongoDb
    {
        // The database name to use. If the database doesn't exists, it will be created.
        public string? DatabaseName { get; set; }
    }
}