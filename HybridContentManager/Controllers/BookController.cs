using HybridContentManager.Models;
using HybridContentManager.Models.Dtos;
using HybridContentManager.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HybridContentManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookRepositoryAdapter _bookRepositoryAdapter;

    public BooksController(BookRepositoryAdapter bookRepositoryAdapter)
    {
        _bookRepositoryAdapter = bookRepositoryAdapter;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookRepositoryAdapter.GetAllBooks();
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        await _bookRepositoryAdapter.AddBook(book);
        return Ok();
    }
}