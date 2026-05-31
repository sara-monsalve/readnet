using Microsoft.EntityFrameworkCore;
using ReadNet.DataAccess.Context;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Interfaces;

namespace ReadNet.DataAccess.Repositories;

public class LoanDetailRepository : ILoanDetailRepository
{
    private readonly LibraryDbContext _context;

    public LoanDetailRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LoanDetail>> GetAllAsync()
    {
        return await _context.LoanDetails.ToListAsync();
    }

    public async Task<LoanDetail?> GetByIdAsync(int loanId, int bookId)
    {
        return await _context.LoanDetails.FindAsync(loanId, bookId);
    }

    public async Task AddAsync(LoanDetail loanDetail)
    {
        await _context.LoanDetails.AddAsync(loanDetail);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int loanId, int bookId)
    {
        var loanDetail = await _context.LoanDetails.FindAsync(loanId, bookId);

        if (loanDetail != null)
        {
            _context.LoanDetails.Remove(loanDetail);
            await _context.SaveChangesAsync();
        }
    }
}