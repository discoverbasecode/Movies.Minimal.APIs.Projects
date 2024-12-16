﻿using AutoMapper;
using EndPoint.Minimal.Api.Data;
using EndPoint.Minimal.Api.DTOs;
using EndPoint.Minimal.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Minimal.Api.Services.ActorServices;

public class ActorService(ApplicationContext context, IMapper mapper) : IActorService
{
    public async Task<Guid> CreateAsync(CreateActorDto command)
    {
        if (command is null)
            throw new ArgumentException("Actor cannot be null.");

        var findActor = await context.Actors.FirstOrDefaultAsync(g => g.FullName == command.FullName);

        if (findActor is not null)
            throw new InvalidOperationException($"Actor with name '{command.FullName}' already exists.");

        var newActor = new Actor(command.FullName, command.DateOfBirth, command.Picture);

        await context.Actors.AddAsync(newActor);
        await context.SaveChangesAsync();
        return newActor.Id;
    }

    public async Task<List<GetAllActorDto>> GetAllAsync()
    {
        var actors = await context.Actors.ToListAsync();
        return mapper.Map<List<GetAllActorDto>>(actors);
    }

    public async Task<GetByIdActorDto> GetIdAsync(Guid id)
    {
        var result = await context.Actors.FindAsync(id);
        if (result is null)
            throw new ArgumentException("Genre cannot be null.");

        return mapper.Map<GetByIdActorDto>(result);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existActor = await context.Actors
            .FirstOrDefaultAsync(g => g.Id == id);

        if (existActor is null)
        {
            throw new ArgumentException($"No genre found with ID: {id}", nameof(id));
        }

        context.Actors.Remove(existActor);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateActorDto command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command), "Genre cannot be null");
        }

        var existActor = await context.Actors
            .FirstOrDefaultAsync(g => g.Id == id);

        if (existActor == null)
        {
            throw new ArgumentException($"No genre found with ID: {command.Id}", nameof(command));
        }

        existActor.FullName = command.FullName;
        existActor.DateOfBirth = command.DateOfBirth;
        existActor.Picture = command.Picture;

        await context.SaveChangesAsync();
    }
}