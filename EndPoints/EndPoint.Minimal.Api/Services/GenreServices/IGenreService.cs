using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Model;

namespace EndPoint.Minimal.Api.Services.GenreServices;

public interface IGenreService
{
    Task<Guid> CreateAsync(CreateGenreDto command);
    Task<List<GetAllGenreDto>> GetAllAsync();
    Task<GetByIdGenreDto> GetIdAsync(Guid id);
    Task<GetByNameGenreDto> GetByNameAsync(string name);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, UpdateGenreDto command);
}