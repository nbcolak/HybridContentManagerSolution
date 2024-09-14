using HybridContentManager.Models;
using HybridContentManager.Models.Dtos;

namespace HybridContentManager.Repos;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooks();
    Task AddBook(Book book);
}