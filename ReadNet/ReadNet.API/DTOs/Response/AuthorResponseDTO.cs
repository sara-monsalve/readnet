namespace ReadNet.API.DTOs.Response;

public class AuthorResponseDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;
}