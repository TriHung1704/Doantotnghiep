using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;
using static CooperateApplication.Service.Services.FileService;

namespace CooperateApplication.Service.Services
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file, string fileName, string fileNameCurrent, string uploadDirecotroy);
    }
}
