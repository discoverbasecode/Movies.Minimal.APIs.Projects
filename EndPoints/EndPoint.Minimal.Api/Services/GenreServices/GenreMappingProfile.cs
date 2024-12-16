using AutoMapper;
using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Model;

namespace EndPoint.Minimal.Api.Services.GenreServices;

public class GenreMappingProfile : Profile
{
    public GenreMappingProfile()
    {
        CreateMap<Genre, CreateGenreDto>();
        CreateMap<Genre, UpdateGenreDto>();
        CreateMap<Genre, GetByNameGenreDto>();
        CreateMap<Genre, GetByIdGenreDto>();
        CreateMap<Genre, GetAllGenreDto>();
    }
}