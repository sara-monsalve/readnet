using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberService _service;
    private readonly IMapper _mapper;

    public MemberController(IMemberService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberResponseDTO>>> GetAll()
    {
        var members = await _service.GetAllAsync();

        var response = _mapper.Map<IEnumerable<MemberResponseDTO>>(members);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MemberResponseDTO>> GetById(int id)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        var response = _mapper.Map<MemberResponseDTO>(member);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(MemberRequestDTO dto)
    {
        var member = _mapper.Map<Member>(dto);

        await _service.AddAsync(member);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, MemberRequestDTO dto)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        _mapper.Map(dto, member);

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