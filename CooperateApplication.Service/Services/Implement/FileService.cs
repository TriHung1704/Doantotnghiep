using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Utilities.Encoders;

namespace CooperateApplication.Service.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> UploadFile(IFormFile file, string fileName, string fileNameCurrent, string uploadDirecotroy)
        {
            fileName = fileName + "." + file.FileName.Split('.').Last();

            if (file == null || string.IsNullOrEmpty(fileName))
            {
                return string.Empty; // nothing to do.
            }

            var uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, uploadDirecotroy);
            //Delete
            if (fileNameCurrent != null)
            {
                if (File.Exists(Path.Combine(uploadPath, fileNameCurrent)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(uploadPath, fileNameCurrent));
                }
            }
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return uploadDirecotroy + fileName;
        }
    }
}
