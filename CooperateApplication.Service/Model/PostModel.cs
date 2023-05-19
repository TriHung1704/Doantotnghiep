using CooperateApplication.Repositories.Entities;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Model
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public byte[] ImageByte { get; set; }
        public PostTypeName Type { get; set; }
        public DateTime ExpireTime { get; set; }
        public DateTime CreateAt { get; set; }
        public int ViewNumber { get; set; }
        public string EnterpriseName { get; set; }
        public string UserName { get; set; }
        public EnterpriseModel Enterprise { get; set; }
        public List<MajorsModel> MajorsModels { get; set; }
        public List<EnterpriseField> EnterpriseFields { get; set; }
        public List<EnterpriseFacility> EnterpriseFacilities { get; set; }
        public List<int> MajorsIds { get; set; }
        public bool IsSeen { get; set; }
        public bool Status { get; set; }
        public int NumberNotification { get; set; }
    }

    public class PostRequest : PostModel
    {
        //public List<int> MajorsIds { get; set; }
    }

    public class PostModels
    {
        public List<PostModel> PostList { get; set;}
        public int Total { get; set; }
    }
    public static class PostModelEmm
    {
        public static PostModel ToModel(this Post post, List<MajorsModel> majorsModel)
        {
            PostModel postModel = new PostModel();
            postModel.Id = post.Id;
            postModel.Title = post.Title;
            postModel.Description = post.Description;
            postModel.Quantity = post.Quantity;
            postModel.Image = post.Image;
            postModel.ExpireTime = post.ExpireTime;
            postModel.Type = (PostTypeName)post.Type;
            postModel.EnterpriseName = post.Enterprise?.Name;
            postModel.UserName = post.User?.FullName;
            postModel.MajorsModels = majorsModel;
            postModel.CreateAt = post.CreateAt;
            return postModel;
        }
        public static Post ToEntities(this PostModel postModel)
        {
            Post post = new Post();
            post.Id = postModel.Id;
            post.Title = postModel.Title;
            post.Description = postModel.Description;
            post.Quantity = postModel.Quantity;
            post.Image = postModel.Image;
            post.ExpireTime = postModel.ExpireTime;
            post.Type = (Repositories.Enums.CooperateEnums.PostTypeName)postModel.Type;
            post.CreateAt = postModel.CreateAt;
            return post;
        }
        public static List<PostModel> ToListModel(this List<Post> postModels, List<MajorsModel> majorsModel)
        {
            return postModels.Select(x => x.ToModel(majorsModel)).ToList();
        }
    }
}
