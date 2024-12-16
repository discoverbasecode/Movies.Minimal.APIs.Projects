using EndPoint.Minimal.Api.DTOs;

namespace EndPoint.Minimal.Api.Services.ActorServices;

public interface IActorService
{
    Task<Guid> CreateAsync(CreateActorDto command);
    Task<List<GetAllActorDto>> GetAllAsync();
    Task<GetByIdActorDto> GetIdAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, UpdateActorDto command);
}