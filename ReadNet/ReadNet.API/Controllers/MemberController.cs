using Microsoft.AspNetCore.Mvc;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberService _service;

    public MemberController(IMemberService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberResponseDTO>>> GetAll()
    {
        var members = await _service.GetAllAsync();

        var response = members.Select(m => new MemberResponseDTO
        {
            Id = m.Id,
            FullName = m.FullName,
            Email = m.Email,
            Phone = m.Phone
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MemberResponseDTO>> GetById(int id)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        return Ok(new MemberResponseDTO
        {
            Id = member.Id,
            FullName = member.FullName,
            Email = member.Email,
            Phone = member.Phone
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(MemberRequestDTO dto)
    {
        var member = new Member
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone
        };

        await _service.AddAsync(member);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, MemberRequestDTO dto)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        member.FullName = dto.FullName;
        member.Email = dto.Email;
        member.Phone = dto.Phone;

        await _service.UpdateAsync(member);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}