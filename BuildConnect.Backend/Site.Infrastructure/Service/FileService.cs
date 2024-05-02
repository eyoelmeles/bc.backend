using Microsoft.AspNetCore.StaticFiles;
using Site.Application.Common.Interface;
using SixLabors.ImageSharp.Formats.Jpeg;


namespace Site.Infrastructure.Service
{
    public class FileService : IFileService
    {
        private readonly string _baseContentDirectory;

        public FileService()
        {
            _baseContentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Content");
            if (!Directory.Exists(_baseContentDirectory))
            {
                Directory.CreateDirectory(_baseContentDirectory);
            }
        }

        public async Task<string> SaveFileAsync(byte[] fileBytes, string fileType, string folderName)
        {
            var guid = Guid.NewGuid().ToString();
            var fileName = $"{guid}.{fileType}";

            var folderPath = Path.Combine(_baseContentDirectory, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);

            // Check if the fileType indicates it's an image, so we compress it.
            if (IsImage(fileType))
            {
                fileBytes = CompressImage(fileBytes);
            }

            await File.WriteAllBytesAsync(filePath, fileBytes);

            return fileName;
        }

        public async Task<string> GetFileAsync(string fileName, string folderName)
        {
            var filePath = Path.Combine(_baseContentDirectory, folderName, fileName);
            if (!File.Exists(filePath))
                return null;

            var bytes = await File.ReadAllBytesAsync(filePath);
            return Convert.ToBase64String(bytes);
        }

        public async Task<string> ConvertFileToBase64(string fileName, string folderName)
        {
            var filePath = Path.Combine(_baseContentDirectory, folderName, fileName);
            if (!File.Exists(filePath))
                return null;

            var bytes = await File.ReadAllBytesAsync(filePath);
            var base64 = Convert.ToBase64String(bytes);

            var fileType = Path.GetExtension(fileName).TrimStart('.').ToLower();
            var mimeType = GetMimeType(fileType);

            return $"data:{mimeType};base64,{base64}";
        }

        private string GetMimeType(string fileType)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType($"file.{fileType}", out var mimeType))
            {
                mimeType = "application/octet-stream"; // Default MIME type
            }
            return mimeType;
        }

        public async Task DeleteFileAsync(string filename, string folderName)
        {
            var path = Path.Combine(_baseContentDirectory, folderName, filename);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        private bool IsImage(string fileType)
        {
            return new[] { "jpg", "jpeg", "png", "bmp", "tiff", "gif" }.Contains(fileType.ToLower());
        }

        private byte[] CompressImage(byte[] inputBytes)
        {
            using var image = Image.Load(inputBytes);
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(1000, 1000), // or desired size
                Mode = ResizeMode.Max
            }));

            using var ms = new MemoryStream();
            image.Save(ms, new JpegEncoder { Quality = 75 }); // or relevant encoder based on fileType
            return ms.ToArray();
        }

        public string GetFileUrl(string fileName, string folderName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var filePath = Path.Combine(_baseContentDirectory, folderName, fileName);
            if (!File.Exists(filePath))
                return null;

            // This will create a URL pointing to a method in your API that serves the file directly. 
            // This example assumes a method named "GetFile" in a "Files" controller.
            return $"{folderName}/{fileName}";
        }
    }
}
