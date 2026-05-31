using Microsoft.AspNetCore.Mvc;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanDetailController : ControllerBase
{
    private readonly ILoanDetailService _service;

    public LoanDetailController(ILoanDetailService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanDetailResponseDTO>>> GetAll()
    {
        var loanDetails = await _service.GetAllAsync();

        var response = loanDetails.Select(ld => new LoanDetailResponseDTO
        {
            LoanId = ld.LoanId,
            BookId = ld.BookId
        });

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

        return Ok(new LoanDetailResponseDTO
        {
            LoanId = loanDetail.LoanId,
            BookId = loanDetail.BookId
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(LoanDetailRequestDTO dto)
    {
        var loanDetail = new LoanDetail
        {
            LoanId = dto.LoanId,
            BookId = dto.BookId
        };

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