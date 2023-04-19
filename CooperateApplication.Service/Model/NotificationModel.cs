using CooperateApplication.Repositories.Entities;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Model
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }

    }
    public class NotificationModels
    {
        public List<NotificationModel> PostList { get; set; }
        public int Total { get; set; }
    }

    public static class NotificationModelEmm
    {
        public static NotificationModel ToModel(this Notification notification)
        {
            var entity = new NotificationModel();
            entity.Id = notification.Id;
            entity.Title = notification.Title;
            entity.Description = notification.Description;
            entity.Image = notification.Image;
            return entity;
        }
    }
}
