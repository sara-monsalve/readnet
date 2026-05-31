using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly ILoanService _service;
    private readonly IMapper _mapper;

    public LoanController(ILoanService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanResponseDTO>>> GetAll()
    {
        var loans = await _service.GetAllAsync();

        var response = _mapper.Map<IEnumerable<LoanResponseDTO>>(loans);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LoanResponseDTO>> GetById(int id)
    {
        var loan = await _service.GetByIdAsync(id);

        if (loan == null)
            return NotFound();

        var response = _mapper.Map<LoanResponseDTO>(loan);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(LoanRequestDTO dto)
    {
        var loan = _mapper.Map<Loan>(dto);

        await _service.AddAsync(loan);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, LoanRequestDTO dto)
    {
        var loan = await _service.GetByIdAsync(id);

        if (loan == null)
            return NotFound();

        _mapper.Map(dto, loan);

        await _service.UpdateAsync(loan);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}