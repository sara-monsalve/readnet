using ReadNet.Domain.Enums;

namespace ReadNet.API.DTOs.Response;

public class LoanResponseDTO
{
    public int Id { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public LoanStatus Status { get; set; }

    public int MemberId { get; set; }
}