using CooperateApplication.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CooperateApplication.Repositories.Enums.CooperateEnums;

using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Model
{
    public class UserModel
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
        public string RefreshToken { get; set; }
        public bool IsDeleted { get; set; }

        public UserTypeName UserType { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public List<RoleModel> RoleModels { get; set; }

    }
    public class UserRequest: UserModel
    {
        public EmployeeType EmployeeType { get; set; }
    }
    public static class UserModelEmm
    {
        public static UserModel ToModel(this User user)
        {
            UserModel userModel = new UserModel();
            userModel.Id = user.Id;
            userModel.UserName = user.UserName;
            userModel.Password = user.Password;
            userModel.FullName = user.FullName;
            userModel.Email = user.Email;
            userModel.Phone = user.Phone;
            userModel.Birthday = user.Birthday;
            userModel.Avatar = user.Avatar;
            userModel.ProvinceAddress = user.ProvinceAddress;
            userModel.RefreshToken = user.RefreshToken;
            userModel.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
            userModel.IsDeleted = user.IsDeleted;
            userModel.UserType = user.UserType;

            return userModel;
        }
        public static User ToEntity(this UserModel userModel)
        {
            User user = new User();
            user.Id = userModel.Id;
            user.UserName = userModel.UserName;
            user.Password = userModel.Password;
            user.FullName = userModel.FullName;
            user.Avatar = userModel.Avatar;
            user.Birthday = userModel.Birthday;
            user.Gender = userModel.Gender;
            user.ProvinceAddress = userModel.ProvinceAddress;
            user.DetailAddress = userModel.DetailAddress;
            user.Email = userModel.Email;
            user.Phone = userModel.Phone;
            user.RefreshToken = userModel.RefreshToken;
            user.RefreshTokenExpiryTime = userModel.RefreshTokenExpiryTime;
            user.UserType = userModel.UserType;
            return user;
        }
    }
}
