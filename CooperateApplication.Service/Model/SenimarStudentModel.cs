using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Model
{
    public class SenimarStudentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public PostTypeName Type { get; set; }
        public DateTime ExpireTime { get; set; }
        public string EnterpriseName { get; set; }
        public bool IsExpire { get; set; }
        public string StudentName { get; set; }
        public string StudentCode { get; set; }
        public int StudentId { get; set; }
    }
    public class SenimarStudentModels
    {
        public List<SenimarStudentModel> PostList { get; set; }
        public int Total { get; set; }
        public string PostTitle { get; set; }
    }
}
