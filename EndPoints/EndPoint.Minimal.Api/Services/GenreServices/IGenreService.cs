using EndPoint.Minimal.Api.Model;

namespace EndPoint.Minimal.Api.Services.GenreServices;

public interface IGenreService
{
    Task<Guid> CreateAsync(Genre genre);
    Task<List<Genre>> GetAllAsync();
    Task<Genre> GetIdAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Guid id, Genre genre);
}