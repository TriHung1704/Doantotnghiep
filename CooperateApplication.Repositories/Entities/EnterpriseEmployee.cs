using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("NhanVien")]
    public class EnterpriseEmployee : BaseEntity
    {
        [Column("MaNguoiDung")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Column("MaDoanhNghiep")]
        public int EnterpriseId { get; set; }
        [ForeignKey("EnterpriseId")]
        public virtual Enterprise Enterprise { get; set; }
    }
}
