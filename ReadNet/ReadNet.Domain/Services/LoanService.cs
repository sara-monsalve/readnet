using ReadNet.Domain.Entities;
using ReadNet.Domain.Interfaces;

namespace ReadNet.Domain.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _repository;

    public LoanService(ILoanRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Loan>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Loan?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Loan loan)
    {
        await _repository.AddAsync(loan);
    }

    public async Task UpdateAsync(Loan loan)
    {
        await _repository.UpdateAsync(loan);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}