using AutoMapper;
using EndPoint.Minimal.Api.Data;
using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Minimal.Api.Services.GenreServices;

public class GenreService(ApplicationContext context, IMapper mapper) : IGenreService
{


    public async Task<Guid> CreateAsync(CreateGenreDto command)
    {
        if (command is null)
            throw new ArgumentException("Genre cannot be null.");

        var findGenre = await context.Genres.FirstOrDefaultAsync(g => g.Name == command.Name);

        if (findGenre is not null)
            throw new InvalidOperationException($"Genre with name '{command.Name}' already exists.");

        var newGenre = new Genre(command.Name, command.Description);

        await context.Genres.AddAsync(newGenre);
        await context.SaveChangesAsync();

        return newGenre.Id;
    }

    public async Task<List<GetAllGenreDto>> GetAllAsync()
    {
        var genres = await context.Genres.ToListAsync();
        return mapper.Map<List<GetAllGenreDto>>(genres);

    }

    public async Task<GetByIdGenreDto> GetIdAsync(Guid id)
    {
        var result = await context.Genres.FindAsync(id);
        if (result is null)
            throw new ArgumentException("Genre cannot be null.");

        return mapper.Map<GetByIdGenreDto>(result);

    }

    public async Task<GetByNameGenreDto> GetByNameAsync(string name)
    {
        var result = await context.Genres.FirstOrDefaultAsync(c => c.Name == name);
        return mapper.Map<GetByNameGenreDto>(result);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingGenre = await context.Genres
            .FirstOrDefaultAsync(g => g.Id == id);

        if (existingGenre is null)
        {
            throw new ArgumentException($"No genre found with ID: {id}", nameof(id));
        }

        context.Genres.Remove(existingGenre);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateGenreDto command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command), "Genre cannot be null");
        }

        var existingGenre = await context.Genres
            .FirstOrDefaultAsync(g => g.Id == id);

        if (existingGenre == null)
        {
            throw new ArgumentException($"No genre found with ID: {command.Id}", nameof(command));
        }

        existingGenre.Name = command.Name;
        existingGenre.Description = command.Description;
        await context.SaveChangesAsync();
    }
}