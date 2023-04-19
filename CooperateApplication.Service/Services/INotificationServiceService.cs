using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Services
{
    public interface INotificationService : IBaseService<Notification>
    {
        Task<NotificationModels> PostsAsync(int page, int number);
        Task<bool> RegisterPostsAsync(NotificationModel notificationModel);
        Task<bool> UpdateNotiPostsAsync(NotificationModel notificationModel);
    }
}
