using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorResponseDTO>>> GetAll()
    {
        var authors = await _service.GetAllAsync();

        var response = _mapper.Map<IEnumerable<AuthorResponseDTO>>(authors);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponseDTO>> GetById(int id)
    {
        var author = await _service.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        var response = _mapper.Map<AuthorResponseDTO>(author);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(AuthorRequestDTO dto)
    {
        var author = _mapper.Map<Author>(dto);

        await _service.AddAsync(author);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, AuthorRequestDTO dto)
    {
        var author = await _service.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        _mapper.Map(dto, author);

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