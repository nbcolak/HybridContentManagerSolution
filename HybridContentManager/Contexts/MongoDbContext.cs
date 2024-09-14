using HybridContentManager.Models;
using MongoDB.Driver;

namespace HybridContentManager.Contexts;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient client)
    {
        _database = client.GetDatabase("BookDb");  
    }

    public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books"); 
}