using ReadNet.Domain.Enums;

namespace ReadNet.Domain.Entities;

public class Loan
{
    public int Id { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public LoanStatus Status { get; set; }

    public int MemberId { get; set; }

    public Member Member { get; set; } = null!;

    public ICollection<LoanDetail> LoanDetails { get; set; }
        = new List<LoanDetail>();
}