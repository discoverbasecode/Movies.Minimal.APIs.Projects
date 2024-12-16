using AutoMapper;
using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Model;

namespace EndPoint.Minimal.Api.Services.ActorServices;

public class ActorMappingProfile : Profile
{
    public ActorMappingProfile()
    {
        CreateMap<Actor, CreateActorDto>();
        CreateMap<Actor, UpdateActorDto>();
        CreateMap<Actor, GetAllActorDto>();
        CreateMap<Actor, GetByIdActorDto>();
    }
}