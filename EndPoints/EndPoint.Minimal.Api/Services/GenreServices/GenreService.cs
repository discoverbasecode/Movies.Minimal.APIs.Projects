using EndPoint.Minimal.Api.Data;
using EndPoint.Minimal.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Minimal.Api.Services.GenreServices;

public class GenreService(ApplicationContext context) : IGenreService
{

    public async Task<Guid> CreateAsync(Genre genre)
    {
        if (genre is null)
            throw new ArgumentException("Genre cannot be null.");

        var findGenre = await context.Genres.FirstOrDefaultAsync(g => g.Name == genre.Name);

        if (findGenre is not null)
            throw new InvalidOperationException($"Genre with name '{genre.Name}' already exists.");

        var newGenre = new Genre(genre.Name, genre.Description);

        await context.Genres.AddAsync(newGenre);
        await context.SaveChangesAsync();

        return newGenre.Id;
    }

    public async Task<List<Genre>> GetAllAsync()
    {
        var genres = await context.Genres.ToListAsync();
        return genres;
    }

    public async Task<Genre> GetIdAsync(Guid id)
    {
        var result = await context.Genres.FindAsync(id);
        if (result is null)
            throw new ArgumentException("Genre cannot be null.");

        return result;
    }
}