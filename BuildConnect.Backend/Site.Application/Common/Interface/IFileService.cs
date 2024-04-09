namespace Site.Application.Common.Interface;
public interface IFileService
{
    Task<string> SaveFileAsync(byte[] fileBytes, string fileType, string folderName);
    Task<string> GetFileAsync(string fileName, string folderName);
    Task DeleteFileAsync(string filename, string folderName);
    Task<string> ConvertFileToBase64(string fileName, string folderName);
    public string GetFileUrl(string fileName, string folder);
    // Other methods as needed (e.g., retrieving files)
}
