using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static CooperateApplication.Service.Enum.Enum;
using EnterpriseFacility = CooperateApplication.Repositories.Entities.EnterpriseFacility;
using EnterpriseField = CooperateApplication.Repositories.Entities.EnterpriseField;

namespace CooperateApplication.Service.Services
{
    public class NotificationService : BaseService<Notification>, INotificationService
    {
        public readonly IRepository<Notification> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public NotificationService(IRepository<Notification> repository,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            IHostingEnvironment hostingEnvironment) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _hostingEnvironment = hostingEnvironment;

        }

        public async Task<NotificationModels> PostsAsync(int page, int number)
        {
            var posts = await _repository.GetAll(x=>x.User);

            int limit = number;
            int total = posts.Count();
            int start = (int)(page - 1) * limit;
            var postsPagination = posts.Skip(start).Take(limit);

            var postModels = new NotificationModels();
            postModels.PostList = new List<NotificationModel>();
            foreach (var post in postsPagination)
            {
                var postModel = new NotificationModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    Image = post.Image,
                    UserName = post.User.FullName,
                    CreateAt = post.CreateAt,
                    IsDeleted = post.IsDeleted
                };
                postModels.PostList.Add(postModel);
            }
            postModels.Total = NumberPage(total, limit);
            return postModels;
        }

        public async Task<bool> RegisterPostsAsync(NotificationModel notificationModel)
        {
            try
            {
                var userCurrent = GetUserCurent();

                var user = await _userService.GetById(userCurrent.Id);
                if (user == null)
                {
                    return false;
                }

                var noti = new Notification
                {
                    Title = notificationModel.Title,
                    Description = notificationModel.Description,
                    Image = notificationModel.Image,
                    UserId = user.Id,
                };

                var post = await Insert(noti);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        
        public async Task<bool> UpdateNotiPostsAsync(NotificationModel notificationModel)
        {
            try
            {
                var userCurrent = GetUserCurent();

                var user = await _userService.GetById(userCurrent.Id);
                if (user == null)
                {
                    return false;
                }
                var notiCurrent = await GetById(notificationModel.Id);
                if (notiCurrent == null)
                {
                    return false;
                }

                var noti = new Notification
                {
                    Id = notificationModel.Id,
                    Title = notificationModel.Title,
                    Description = notificationModel.Description,
                    Image = notificationModel.Image,
                    UserId = user.Id,
                    CreateAt = notiCurrent.CreateAt
                };

                var post = await Update(noti);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
