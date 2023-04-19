using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("LinhVucKinhDoanh")]
    public class EnterpriseField : BaseEntity
    {
        [Column("TenLinhVuc")]
        public string Name { get; set; }
        [Column("MaDoanhNghiep")]
        public int EnterpriseId { get; set; }
        [ForeignKey("EnterpriseId")]
        public virtual Enterprise Enterprise { get; set; }
    }
}
