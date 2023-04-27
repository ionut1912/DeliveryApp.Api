using DeliveryApp.Internationalization.Mongo.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DeliveryApp.Internationalization.Mongo.Services.Services;

public class ConfigService
{
    private readonly IMongoCollection<Config> _configsCollection;

    public ConfigService(IOptions<InternationalizationDatabaseSettings> configCollectionSettings)
    {
        var mongoClient = new MongoClient(
            configCollectionSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            configCollectionSettings.Value.DatabaseName);

        _configsCollection = mongoDatabase.GetCollection<Config>(
            configCollectionSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Config config)
    {
        await _configsCollection.InsertOneAsync(config);
    }

    public async Task<Config> GetByPageNameAsync(string pageName)
    {
        return await _configsCollection.Find(x => x.PageName == pageName).FirstOrDefaultAsync();
    }
}