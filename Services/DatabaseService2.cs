using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University_Lander.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace University_Lander.Services
{
    public class DatabaseService2
    {
        private readonly IMongoCollection<FileModel> _ContactUsCollection;

    public DatabaseService2(
        IOptions<DatabaseConfiguration> DatabaseSettings)
    {
        var mongoClient = new MongoClient(
            DatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            DatabaseSettings.Value.DatabaseName);

        _ContactUsCollection = mongoDatabase.GetCollection<FileModel>(
            DatabaseSettings.Value.DatabaseName);
    }

    public async Task<List<FileModel>> GetAsync() =>
        await _ContactUsCollection.Find(_ => true).ToListAsync();

    public async Task<FileModel?> GetAsync(string id) =>
        await _ContactUsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(FileModel newFileModel) =>
        await _ContactUsCollection.InsertOneAsync(newFileModel);

    public async Task UpdateAsync(string id, FileModel updatedFileModel) =>
        await _ContactUsCollection.ReplaceOneAsync(x => x.Id == id, updatedFileModel);

    public async Task RemoveAsync(string id) =>
        await _ContactUsCollection.DeleteOneAsync(x => x.Id == id);
    }
}