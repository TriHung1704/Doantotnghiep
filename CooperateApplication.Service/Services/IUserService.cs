using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;

namespace CooperateApplication.Service.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<bool> CreateUser(string fileUrl);
        Task<UserModel> GetUser();
    }
}
