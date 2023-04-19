using CooperateApplication.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Model
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
    public static class RoleModelEmm
    {
        public static RoleModel ToModel(this Role role)
        {
            RoleModel roleModel = new RoleModel();
            roleModel.Id = role.Id;
            roleModel.RoleName = role.RoleName;

            return roleModel;
        }
    }
}
