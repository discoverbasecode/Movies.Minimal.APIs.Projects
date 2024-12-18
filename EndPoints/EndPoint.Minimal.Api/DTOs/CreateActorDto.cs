namespace EndPoint.Minimal.Api.DTOs;

public class CreateActorDto
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public IFormFile Picture { get; set; }
    public string PicturePath { get; set; }
}

public class UpdateActorDto : CreateActorDto
{
    public Guid Id { get; set; }
}

public class GetAllActorDto : UpdateActorDto;

public class GetByIdActorDto : GetAllActorDto;