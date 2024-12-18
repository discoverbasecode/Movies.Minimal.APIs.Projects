namespace EndPoint.Minimal.Api.Model;

public class Actor(string fullName, DateTime dateOfBirth, string picturePath, string pictureName)
{
    public Guid Id { get; set; } = new();
    public string FullName { get; set; } = fullName;
    public DateTime DateOfBirth { get; set; } = dateOfBirth;
    public string PictureName { get; set; } = pictureName;
    public string PicturePath { get; set; } = picturePath;
}