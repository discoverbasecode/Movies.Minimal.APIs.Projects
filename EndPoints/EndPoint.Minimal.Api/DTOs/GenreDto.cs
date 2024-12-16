namespace EndPoint.Minimal.Api.DTOs;

public class CreateGenreDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UpdateGenreDto : CreateGenreDto
{
    public Guid Id { get; set; }
}

public class GetAllGenreDto : UpdateGenreDto;
public class GetByIdGenreDto : GetAllGenreDto;
public class GetByNameGenreDto : GetAllGenreDto;


