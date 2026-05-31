using ReadNet.Domain.Entities;

namespace ReadNet.Domain.Interfaces;

public interface ILoanDetailRepository
{
    Task<IEnumerable<LoanDetail>> GetAllAsync();
    Task<LoanDetail?> GetByIdAsync(int loanId, int bookId);
    Task AddAsync(LoanDetail loanDetail);
    Task DeleteAsync(int loanId, int bookId);
}