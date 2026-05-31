using ReadNet.Domain.Entities;
using ReadNet.Domain.Interfaces;

namespace ReadNet.Domain.Services;

public class LoanDetailService : ILoanDetailService
{
    private readonly ILoanDetailRepository _repository;

    public LoanDetailService(ILoanDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<LoanDetail>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<LoanDetail?> GetByIdAsync(int loanId, int bookId)
    {
        return await _repository.GetByIdAsync(loanId, bookId);
    }

    public async Task AddAsync(LoanDetail loanDetail)
    {
        await _repository.AddAsync(loanDetail);
    }

    public async Task DeleteAsync(int loanId, int bookId)
    {
        await _repository.DeleteAsync(loanId, bookId);
    }
}