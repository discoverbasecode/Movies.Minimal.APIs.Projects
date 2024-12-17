using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Utils;

namespace EndPoint.Minimal.Api.Services.ActorServices;

public interface IActorService
{
    Task<Guid> CreateAsync(CreateActorDto command);
    Task<List<GetAllActorDto>> GetAllAsync(PaginationParams pagination);
    Task<GetByIdActorDto> GetIdAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, UpdateActorDto command);
}