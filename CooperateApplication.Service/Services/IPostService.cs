using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Services
{
    public interface IPostService : IBaseService<Post>
    {
        Task<PostModels> PostsAsync(PostSearchRequest postSearchRequest);
        Task<PostModel> PostsAsync(int id);
        Task<PostModels> PostOfEmployeeAsync(PostTypeName type, int page, int limit);
        Task<bool> RegisterPostsAsync(PostRequest postModel);
        Task<bool> UpdatePostsAsync(PostRequest postModel);
        Task<bool> AcceptedCVAsync(int postId, int studentId, bool isAccepted);
        Task<PostStudentModels> GetPostStudentAsync(int postId, int page);
        Task<SenimarStudentModels> GetSenimarStudentAsync(int postId, int page);
        Task<PostModels> GetAllPostsAsync(int typeNumber, int page, int limit);
        Task<bool> ConfirmPostAsync(int id, bool isConfirm);
    }
}
