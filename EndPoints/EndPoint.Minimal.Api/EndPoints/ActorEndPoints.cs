using AutoMapper;
using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Services.ActorServices;
using EndPoint.Minimal.Api.Utils;
using EndPoint.Minimal.Api.Utils.FilesUtils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EndPoint.Minimal.Api.EndPoints;
public static class ActorEndPoints
{
    public static readonly string Container = "actors";

    public static RouteGroupBuilder MapActor(this RouteGroupBuilder group)
    {
        group.MapPost("actors", Create).DisableAntiforgery().WithName("CreateActor");
        return group;
    }

    private static async Task<Created<CreateActorDto>> Create([FromForm] CreateActorDto createActorDto, IMapper mapper, IActorService service, IOutputCacheStore outputCacheStore)
    {
        if (createActorDto.Picture is null || createActorDto.Picture.Length == 0)
            throw new ArgumentException("Picture file is required.");

        var uploadsFolder = Path.Combine("uploads", "images");
        var filePath = await FileHelper.SaveFileAsync(createActorDto.Picture, uploadsFolder);

        createActorDto.PicturePath = filePath;

        var id = await service.CreateAsync(createActorDto);
        await outputCacheStore.EvictByTagAsync("Actor-Get", default);

        var actorDto = mapper.Map<CreateActorDto>(createActorDto);
        return TypedResults.Created($"/actors/{id}", actorDto);
    }


}
