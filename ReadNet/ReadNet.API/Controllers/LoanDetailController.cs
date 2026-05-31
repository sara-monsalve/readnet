using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanDetailController : ControllerBase
{
    private readonly ILoanDetailService _service;
    private readonly IMapper _mapper;

    public LoanDetailController(ILoanDetailService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanDetailResponseDTO>>> GetAll()
    {
        var loanDetails = await _service.GetAllAsync();

        var response = _mapper.Map<IEnumerable<LoanDetailResponseDTO>>(loanDetails);

        return Ok(response);
    }

    [HttpGet("{loanId}/{bookId}")]
    public async Task<ActionResult<LoanDetailResponseDTO>> GetById(
        int loanId,
        int bookId)
    {
        var loanDetail = await _service.GetByIdAsync(loanId, bookId);

        if (loanDetail == null)
            return NotFound();

        var response = _mapper.Map<LoanDetailResponseDTO>(loanDetail);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(LoanDetailRequestDTO dto)
    {
        var loanDetail = _mapper.Map<LoanDetail>(dto);

        await _service.AddAsync(loanDetail);

        return Ok();
    }

    [HttpDelete("{loanId}/{bookId}")]
    public async Task<ActionResult> Delete(
        int loanId,
        int bookId)
    {
        await _service.DeleteAsync(loanId, bookId);

        return NoContent();
    }
}