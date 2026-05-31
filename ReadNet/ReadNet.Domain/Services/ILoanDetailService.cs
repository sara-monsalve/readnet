using ReadNet.Domain.Entities;

namespace ReadNet.Domain.Services;

public interface ILoanDetailService
{
    Task<IEnumerable<LoanDetail>> GetAllAsync();
    Task<LoanDetail?> GetByIdAsync(int loanId, int bookId);
    Task AddAsync(LoanDetail loanDetail);
    Task DeleteAsync(int loanId, int bookId);
} 