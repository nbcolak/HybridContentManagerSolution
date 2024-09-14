using HybridContentManager.Models;
using MongoDB.Driver;

namespace HybridContentManager.Repos;
public class MongoBookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _books;

    public MongoBookRepository(IMongoDatabase database)
    {
        _books = database.GetCollection<Book>("Books");
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _books.Find(_ => true).ToListAsync();
    }

    public async Task AddBook(Book book)
    {
        var lastBook = await _books.Find(_ => true).SortByDescending(b => b.Id).FirstOrDefaultAsync();
        book.Id = (lastBook != null ? lastBook.Id + 1 : 1);
        await _books.InsertOneAsync(book);
    }
}