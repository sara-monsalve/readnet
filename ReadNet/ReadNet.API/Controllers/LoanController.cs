using Microsoft.AspNetCore.Mvc;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Services;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;

namespace ReadNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly ILoanService _service;

    public LoanController(ILoanService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanResponseDTO>>> GetAll()
    {
        var loans = await _service.GetAllAsync();

        var response = loans.Select(l => new LoanResponseDTO
        {
            Id = l.Id,
            LoanDate = l.LoanDate,
            ReturnDate = l.ReturnDate,
            Status = l.Status,
            MemberId = l.MemberId
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LoanResponseDTO>> GetById(int id)
    {
        var loan = await _service.GetByIdAsync(id);

        if (loan == null)
            return NotFound();

        return Ok(new LoanResponseDTO
        {
            Id = loan.Id,
            LoanDate = loan.LoanDate,
            ReturnDate = loan.ReturnDate,
            Status = loan.Status,
            MemberId = loan.MemberId
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(LoanRequestDTO dto)
    {
        var loan = new Loan
        {
            LoanDate = dto.LoanDate,
            ReturnDate = dto.ReturnDate,
            Status = dto.Status,
            MemberId = dto.MemberId
        };

        await _service.AddAsync(loan);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, LoanRequestDTO dto)
    {
        var loan = await _service.GetByIdAsync(id);

        if (loan == null)
            return NotFound();

        loan.LoanDate = dto.LoanDate;
        loan.ReturnDate = dto.ReturnDate;
        loan.Status = dto.Status;
        loan.MemberId = dto.MemberId;

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