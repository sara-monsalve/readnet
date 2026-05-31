using Microsoft.AspNetCore.Mvc;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponseDTO>>> GetAll()
    {
        var books = await _service.GetAllAsync();

        var response = books.Select(b => new BookResponseDTO
        {
            Id = b.Id,
            Title = b.Title,
            ISBN = b.ISBN,
            PublishYear = b.PublishYear,
            AuthorId = b.AuthorId,
            CategoryId = b.CategoryId
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseDTO>> GetById(int id)
    {
        var book = await _service.GetByIdAsync(id);

        if (book == null)
            return NotFound();

        return Ok(new BookResponseDTO
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            PublishYear = book.PublishYear,
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(BookRequestDTO dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            ISBN = dto.ISBN,
            PublishYear = dto.PublishYear,
            AuthorId = dto.AuthorId,
            CategoryId = dto.CategoryId
        };

        await _service.AddAsync(book);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, BookRequestDTO dto)
    {
        var book = await _service.GetByIdAsync(id);

        if (book == null)
            return NotFound();

        book.Title = dto.Title;
        book.ISBN = dto.ISBN;
        book.PublishYear = dto.PublishYear;
        book.AuthorId = dto.AuthorId;
        book.CategoryId = dto.CategoryId;

        await _service.UpdateAsync(book);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}