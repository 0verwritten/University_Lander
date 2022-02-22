using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University_Lander.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace University_Lander.Services
{
    public class DatabaseService
    {
        private readonly IMongoCollection<ContactUsModel> _ContactUsCollection;

    public DatabaseService(
        IOptions<DatabaseConfiguration> DatabaseSettings)
    {
        var mongoClient = new MongoClient(
            DatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            DatabaseSettings.Value.DatabaseName);

        _ContactUsCollection = mongoDatabase.GetCollection<ContactUsModel>(
            DatabaseSettings.Value.DatabaseName);
    }

    public async Task<List<ContactUsModel>> GetAsync() =>
        await _ContactUsCollection.Find(_ => true).ToListAsync();

    public async Task<ContactUsModel?> GetAsync(string id) =>
        await _ContactUsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ContactUsModel newContactUsModel) =>
        await _ContactUsCollection.InsertOneAsync(newContactUsModel);

    public async Task UpdateAsync(string id, ContactUsModel updatedContactUsModel) =>
        await _ContactUsCollection.ReplaceOneAsync(x => x.Id == id, updatedContactUsModel);

    public async Task RemoveAsync(string id) =>
        await _ContactUsCollection.DeleteOneAsync(x => x.Id == id);
    }
}