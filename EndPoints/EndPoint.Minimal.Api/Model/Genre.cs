namespace EndPoint.Minimal.Api.Model;

public class Genre
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public Genre(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}