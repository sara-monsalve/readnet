using ReadNet.Domain.Entities;
using ReadNet.Domain.Interfaces;

namespace ReadNet.Domain.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _repository;

    public MemberService(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Member?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Member member)
    {
        await _repository.AddAsync(member);
    }

    public async Task UpdateAsync(Member member)
    {
        await _repository.UpdateAsync(member);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}