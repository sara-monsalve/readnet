using Microsoft.AspNetCore.Mvc;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorResponseDTO>>> GetAll()
    {
        var authors = await _service.GetAllAsync();

        var response = authors.Select(a => new AuthorResponseDTO
        {
            Id = a.Id,
            Name = a.Name,
            Country = a.Country
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponseDTO>> GetById(int id)
    {
        var author = await _service.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        return Ok(new AuthorResponseDTO
        {
            Id = author.Id,
            Name = author.Name,
            Country = author.Country
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(AuthorRequestDTO dto)
    {
        var author = new Author
        {
            Name = dto.Name,
            Country = dto.Country
        };

        await _service.AddAsync(author);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, AuthorRequestDTO dto)
    {
        var author = await _service.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        author.Name = dto.Name;
        author.Country = dto.Country;

        await _service.UpdateAsync(author);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}