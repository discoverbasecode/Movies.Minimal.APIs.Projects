using EndPoint.Minimal.Api.Data;
using EndPoint.Minimal.Api.Model;

namespace EndPoint.Minimal.Api.Services.GenreServices;

public class GenreService(ApplicationContext context) : IGenreService
{

    public async Task<Guid> CreateAsync(Genre genre)
    {
        var newGenre = new Genre(genre.Name, genre.Description);

        await context.Genres.AddAsync(newGenre);
        await context.SaveChangesAsync();

        return newGenre.Id;
    }
}