//using Microsoft.AspNetCore.Http;
//using Site.Application.Common.Interface;
//using System.IO;

//namespace Site.Infrastructure.Service;

//public class FileService : IFileService
//{
//    //public async Task<string> SaveFileAsync(IFormFile file, string folderName)
//    //{


//    //    var guidFilename = Guid.NewGuid().ToString();
//    //    var path = Path.Combine(
//    //        Directory.GetCurrentDirectory(), folderName,
//    //        guidFilename + Path.GetExtension(file.FileName));

//    //    using (var stream = new FileStream(path, FileMode.Create))
//    //    {
//    //        await file.CopyToAsync(stream);
//    //    }

//    //    return guidFilename;
//    //}

//    //public async Task<string> SaveFileAsync(byte[] fileBytes, string fileType, string folderName)
//    //{
//    //    if (fileBytes == null || fileBytes.Length == 0)
//    //        throw new Exception("File is empty!");

//    //    var guid = Guid.NewGuid().ToString();
//    //    var fileName = $"{guid}.{fileType}";
//    //    var path = Path.Combine(
//    //        Directory.GetCurrentDirectory(), folderName,
//    //        fileName);

//    //    await File.WriteAllBytesAsync(path, fileBytes);

//    //    return fileName;
//    //}

//    //public async Task DeleteFileAsync(string filename, string folderName)
//    //{
//    //    var path = Path.Combine(
//    //        Directory.GetCurrentDirectory(), folderName,
//    //        filename);

//    //    if (File.Exists(path))
//    //    {
//    //        File.Delete(path);
//    //    }
//    //}

//    //public async Task<string> ConvertFileToBase64(string fileName)
//    //{
//    //    var filePath = Path.Combine(
//    //        Directory.GetCurrentDirectory(), "Content",
//    //        fileName);
//    //    if (!File.Exists(filePath))
//    //        return null;

//    //    var bytes = await File.ReadAllBytesAsync(filePath);
//    //    var base64 = Convert.ToBase64String(bytes);

//    //    var fileType = Path.GetExtension(fileName).TrimStart('.').ToLower();
//    //    var mimeType = GetMimeType(fileType);

//    //    return $"data:{mimeType};base64,{base64}";
//    //}

//    //private string GetMimeType(string fileType)
//    //{
//    //    // This is a simple example. In a real-world scenario, you might want to use a library or a more comprehensive mapping.
//    //    return fileType switch
//    //    {
//    //        "png" => "image/png",
//    //        "jpg" => "image/jpeg",
//    //        "jpeg" => "image/jpeg",
//    //        "gif" => "image/gif",
//    //        _ => "application/octet-stream"
//    //    };
//    //}


//    //public Task<string> GetFileAsync(string fileName)
//    //{
//    //    throw new NotImplementedException();
//    //}

//    //Task<string> IFileService.ConvertFileToBase64(string fileName)
//    //{
//    //    throw new NotImplementedException();
//    //}

//    // Other methods as needed (e.g., retrieving files)
//    private readonly string _baseContentDirectory;

//    public FileService()
//    {
//        _baseContentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Content");
//        if (!Directory.Exists(_baseContentDirectory))
//        {
//            Directory.CreateDirectory(_baseContentDirectory);
//        }
//    }
//    public async Task<string> SaveFileAsync(byte[] fileBytes, string fileType, string folderName)
//    {
//        var guid = Guid.NewGuid().ToString();
//        var fileName = $"{guid}.{fileType}";

//        var folderPath = Path.Combine(_baseContentDirectory, folderName);
//        if (!Directory.Exists(folderPath))
//        {
//            Directory.CreateDirectory(folderPath);
//        }

//        var filePath = Path.Combine(folderPath, fileName);

//        await File.WriteAllBytesAsync(filePath, fileBytes);

//        return fileName;
//    }

//    public async Task<string> GetFileAsync(string fileName, string folderName)
//    {
//        var filePath = Path.Combine(_baseContentDirectory, folderName, fileName);
//        if (!File.Exists(filePath))
//            return null;

//        var bytes = await File.ReadAllBytesAsync(filePath);
//        return Convert.ToBase64String(bytes);
//    }

//    public async Task<string> ConvertFileToBase64(string fileName, string folderName)
//    {
//        var filePath = Path.Combine(_baseContentDirectory, folderName, fileName);
//        if (!File.Exists(filePath))
//            return null;

//        var bytes = await File.ReadAllBytesAsync(filePath);
//        var base64 = Convert.ToBase64String(bytes);

//        var fileType = Path.GetExtension(fileName).TrimStart('.').ToLower();
//        var mimeType = GetMimeType(fileType);

//        return $"data:{mimeType};base64,{base64}";
//    }

//    private string GetMimeType(string fileType)
//    {
//        var provider = new FileExtensionContentTypeProvider();
//        if (!provider.TryGetContentType($"file.{fileType}", out var mimeType))
//        {
//            mimeType = "application/octet-stream"; // Default MIME type
//        }
//        return mimeType;
//    }

//    public async Task DeleteFileAsync(string filename, string folderName)
//    {
//        var path = Path.Combine(_baseContentDirectory, folderName, filename);

//        if (File.Exists(path))
//        {
//            File.Delete(path);
//        }
//    }
//}

