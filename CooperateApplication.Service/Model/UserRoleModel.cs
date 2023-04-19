using CooperateApplication.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Model
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
    public static class UserRoleModelEmm
    {
        public static UserRoleModel ToModel(this UserRole userRole)
        {
            UserRoleModel userRoleModel = new UserRoleModel();
            userRoleModel.UserId = userRole.Id;
            userRoleModel.RoleId = userRole.RoleId;

            return userRoleModel;
        }
        public static List<UserRoleModel> ToListModel(this List<UserRole> userRole)
        {
            return userRole.Select(x=> x.ToModel()).ToList();
        }
    }
}
