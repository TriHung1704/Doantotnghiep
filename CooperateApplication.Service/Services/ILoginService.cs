using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;

namespace CooperateApplication.Service.Services
{
    public interface ILoginService : IBaseService<User>
    {
        Task<UserModel> Login(string userName, string password);
        Task<AthenticationResponse> LoginCreateToken(UserModel user);
        Task<AthenticationResponse> RefreshToken(AthenticationResponse athenticationResponse);
    }
}
