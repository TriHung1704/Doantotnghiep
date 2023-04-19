using System;
using System.ComponentModel.DataAnnotations.Schema;
using static CooperateApplication.Repositories.Enums.CooperateEnums;

namespace CooperateApplication.Repositories.Entities
{
    [Table("NguoiDung")]
    public class User : BaseEntity
    {
        [Column("TaiKhoan")]
        public string UserName { get; set; }
        [Column("MatKhau")]
        public string Password { get; set; }
        public string Email { get; set; }
        [Column("SoDienThoai")]
        public string Phone { get; set; }
        [Column("Ten")]
        public string FullName { get; set; }
        [Column("GioiTinh")]
        public bool Gender { get; set; }
        [Column("NgaySinh")]
        public DateTime Birthday { get; set; }
        public string Avatar { get; set; }
        [Column("DiaChi")]
        public string ProvinceAddress { get; set; }
        [Column("DiaChiCuThe")]
        public string DetailAddress { get; set; }
        //control token
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        [Column("LoaiNguoiDung")]
        public UserTypeName UserType { get; set; }
    }
}
