namespace EndPoint.Minimal.Api.Utils;

public static class FileHelper
{
    public static async Task<string> SaveFileAsync(IFormFile file, string directory)
    {
        if (file is null || file.Length == 0)
            throw new ArgumentException("File is required.");

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        var filePath = Path.Combine(directory, fileName);

        Directory.CreateDirectory(directory);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return filePath; // مسیر کامل فایل را برمی‌گرداند
    }
}
