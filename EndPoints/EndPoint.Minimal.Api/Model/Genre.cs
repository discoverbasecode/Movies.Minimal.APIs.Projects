namespace EndPoint.Minimal.Api.Model;

public class Genre(string name, string description)
{
    public Guid Id { get; set; } = new();
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
}