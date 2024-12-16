namespace EndPoint.Minimal.Api.Model;

public class Actor(string fullName, DateTime dateOfBirth, string picture)
{
    public Guid Id { get; set; } = new();
    public string FullName { get; set; } = fullName;
    public DateTime DateOfBirth { get; set; } = dateOfBirth;
    public string Picture { get; set; } = picture;
}