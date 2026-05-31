using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetAll()
    {
        var categories = await _service.GetAllAsync();

        var response = _mapper.Map<IEnumerable<CategoryResponseDTO>>(categories);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDTO>> GetById(int id)
    {
        var category = await _service.GetByIdAsync(id);

        if (category == null)
            return NotFound();

        var response = _mapper.Map<CategoryResponseDTO>(category);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CategoryRequestDTO dto)
    {
        var category = _mapper.Map<Category>(dto);

        await _service.AddAsync(category);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, CategoryRequestDTO dto)
    {
        var category = await _service.GetByIdAsync(id);

        if (category == null)
            return NotFound();

        _mapper.Map(dto, category);

        await _service.UpdateAsync(category);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}