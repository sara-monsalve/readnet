using ReadNet.Domain.Entities;
using ReadNet.Domain.Interfaces;

namespace ReadNet.Domain.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            throw new ArgumentException("El nombre del autor es obligatorio.");

        if (string.IsNullOrWhiteSpace(author.Country))
            throw new ArgumentException("El país del autor es obligatorio.");

        await _repository.AddAsync(author);
    }

    public async Task UpdateAsync(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            throw new ArgumentException("El nombre del autor es obligatorio.");

        if (string.IsNullOrWhiteSpace(author.Country))
            throw new ArgumentException("El país del autor es obligatorio.");

        await _repository.UpdateAsync(author);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}