using ReadNet.Domain.Entities;

namespace ReadNet.Domain.Services;

public interface ILoanService
{
    Task<IEnumerable<Loan>> GetAllAsync();
    Task<Loan?> GetByIdAsync(int id);
    Task AddAsync(Loan loan);
    Task UpdateAsync(Loan loan);
    Task DeleteAsync(int id);
}