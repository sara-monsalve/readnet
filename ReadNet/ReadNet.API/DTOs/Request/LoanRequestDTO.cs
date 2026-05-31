using ReadNet.Domain.Enums;

namespace ReadNet.API.DTOs.Request;

public class LoanRequestDTO
{
    public DateTime LoanDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public LoanStatus Status { get; set; }

    public int MemberId { get; set; }
}