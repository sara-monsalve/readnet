using Microsoft.AspNetCore.Mvc;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetAll()
    {
        var categories = await _service.GetAllAsync();

        var response = categories.Select(c => new CategoryResponseDTO
        {
            Id = c.Id,
            Name = c.Name
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDTO>> GetById(int id)
    {
        var category = await _service.GetByIdAsync(id);

        if (category == null)
            return NotFound();

        return Ok(new CategoryResponseDTO
        {
            Id = category.Id,
            Name = category.Name
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(CategoryRequestDTO dto)
    {
        var category = new Category
        {
            Name = dto.Name
        };

        await _service.AddAsync(category);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, CategoryRequestDTO dto)
    {
        var category = await _service.GetByIdAsync(id);

        if (category == null)
            return NotFound();

        category.Name = dto.Name;

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