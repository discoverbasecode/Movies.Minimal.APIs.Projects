using EndPoint.Minimal.Api.Model;

namespace EndPoint.Minimal.Api.Services.GenreServices;

public interface IGenreService
{
    Task<Guid> CreateAsync(Genre genre);
}