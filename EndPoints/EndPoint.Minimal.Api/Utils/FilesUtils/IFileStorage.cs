namespace EndPoint.Minimal.Api.Utils.FilesUtils;

public interface IFileStorage
{
    Task<string> Store(string? container, IFormFile file);
    Task<string> Delete(string? route, string? container);
    Task<string> SaveFileAsync(IFormFile file, string folderName);
    Task<string> GetFileUrlAsync(string route, string container);

    async Task<string> Edit(string? route, string? container, IFormFile file)
    {
        await Delete(route, container);
        return await Store(container, file);
    }
}