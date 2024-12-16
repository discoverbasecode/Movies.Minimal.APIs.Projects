using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Services.GenreServices;
using Microsoft.AspNetCore.OutputCaching;

namespace EndPoint.Minimal.Api.EndPoints;

public class GenreEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {

        var genresEndpoints = app.MapGroup("/genres");

        genresEndpoints.MapPost("/", async (CreateGenreDto genre, IGenreService service, IOutputCacheStore outputCacheStore) =>
        {
            try
            {
                var id = await service.CreateAsync(genre);
                await outputCacheStore.EvictByTagAsync("genres-get", default);
                return Results.Created($"/createGenre/{id}", genre);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Results.Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return Results.Problem($"An unexpected error occurred: {ex.Message}");
            }
        }).WithTags("Create Genre"); ;

        genresEndpoints.MapGet("/", async (IGenreService service) =>
        {
            try
            {
                var result = await service.GetAllAsync();
                return Results.Ok(result);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Results.Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return Results.Problem($"An unexpected error occurred: {ex.Message}");
            }
        }).WithTags("Get All Genre");

        genresEndpoints.MapGet("/{id:guid}", async (IGenreService service, Guid id) =>
        {

            try
            {
                var genre = await service.GetIdAsync(id);
                return Results.Ok(genre);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Results.Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return Results.Problem($"An unexpected error occurred: {ex.Message}");
            }
        }).WithTags("Get By Guid Genre");

        genresEndpoints.MapGet("/{name}", async (IGenreService service, string name) =>
        {
            try
            {
                var genre = await service.GetByNameAsync(name);
                return Results.Ok(genre);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Results.Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return Results.Problem($"An unexpected error occurred: {ex.Message}");
            }
        }).WithTags("Get By Name Genre");


        genresEndpoints.MapPut("/{id:guid}", async (UpdateGenreDto genre, IGenreService service, IOutputCacheStore outputCacheStore, Guid id) =>
        {
            await service.UpdateAsync(id, genre);
            await outputCacheStore.EvictByTagAsync("genres-get", default);
            return Results.NoContent();
        }).WithTags("Update Genre");

        genresEndpoints.MapDelete("/{id:guid}", async (IGenreService service, IOutputCacheStore outputCacheStore, Guid id) =>
        {
            await service.DeleteAsync(id);
            await outputCacheStore.EvictByTagAsync("genres-get", default);
            return Results.NoContent();
        }).WithTags("Remove Genre");
    }
}
