using HybridContentManager.Contexts;
using HybridContentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HybridContentManager.Repos;
public class SqlBookRepository : IBookRepository
{
    private readonly SqlDbContext _context;

    public SqlBookRepository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddBook(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }
}