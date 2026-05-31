using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _service;
    private readonly IMapper _mapper;

    public BookController(IBookService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponseDTO>>> GetAll()
    {
        var books = await _service.GetAllAsync();

        var response = _mapper.Map<IEnumerable<BookResponseDTO>>(books);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseDTO>> GetById(int id)
    {
        var book = await _service.GetByIdAsync(id);

        if (book == null)
            return NotFound();

        var response = _mapper.Map<BookResponseDTO>(book);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(BookRequestDTO dto)
    {
        var book = _mapper.Map<Book>(dto);

        await _service.AddAsync(book);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, BookRequestDTO dto)
    {
        var book = await _service.GetByIdAsync(id);

        if (book == null)
            return NotFound();

        _mapper.Map(dto, book);

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