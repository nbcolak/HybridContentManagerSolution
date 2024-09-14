using HybridContentManager.Models;

namespace HybridContentManager.Repos;

public class BookRepositoryAdapter : IBookRepository
{
    private readonly IBookRepository _repository;

    public BookRepositoryAdapter(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _repository.GetAllBooks();
    }

    public async Task AddBook(Book book)
    {
        await _repository.AddBook(book);
    }
}