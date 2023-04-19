using CooperateApplication.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Avatar { get; set; }
        public string ProvinceAddress { get; set; }
        public string DetailAddress { get; set; }
        public int EnterpriseId { get; set; }
        public bool IsDeleted { get; set; }
        public string ClassName { get; set; }
    }

    public class StudentModelReponse
    {
        public List<StudentModel> StudentModels { get; set; }
        public int Total { get; set; }
    }
}
