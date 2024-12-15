using EndPoint.Minimal.Api.Model;
using EndPoint.Minimal.Api.Services.GenreServices;
using Microsoft.AspNetCore.OutputCaching;

namespace EndPoint.Minimal.Api.EndPoints;

public class GenreEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        // ثبت مسیر POST برای ایجاد ژانر جدید
        app.MapPost("/createGenre", async (Genre genre, IGenreService service, IOutputCacheStore outputCacheStore) =>
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
        }).WithTags("Return Create Genre"); ;

        // ثبت مسیر GET برای دریافت لیست ژانرها
        app.MapGet("/genres", async (IGenreService service) =>
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
        }).WithTags("Return Get All Genre");

        // ثبت مسیر GET برای دریافت یک ژانر
        app.MapGet("/genre/{id:guid}", async (IGenreService service, Guid id) =>
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
        }).WithTags("Return Get By Guid Genre");
    }
}
