using CooperateApplication.Repositories.Entities;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Model
{
    public class PostSearchRequest
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Title { get; set; }
        public string EnterpriseName { get; set; }
        public PostTypeName Type { get; set; }
        public int TypeNumber { get; set; }
        public string MajorsIds { get; set; }
    }

}
