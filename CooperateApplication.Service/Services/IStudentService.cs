using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;

namespace CooperateApplication.Service.Services
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<StudentModelReponse> GetStudentAsync(int page);
        Task<bool> LockStudent(bool isLock, int userId);
        Task<bool> UploadCvStudent(string file);
        Task<string> CvStudent();
        Task<bool> RecruitmentCV(int id);
        Task<bool> CancelCV(int id);
        Task<PostStudentModels> GetPostStudentAsync(int page);
        Task<bool> SenimarAttend(int id);
        Task<bool> CancelSenimarAttend(int id);
        Task<SenimarStudentModels> GetSenimarAttendAsync(int page);
    }
}
