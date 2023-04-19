using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("ChiNhanhDoanhNghiep")]
    public class EnterpriseFacility : BaseEntity
    {
        [Column("TenChiNhanh")]
        public string Name { get; set; }
        [Column("Tinh")]
        public string ProvinceAddress { get; set; }
        [Column("DiaChiCuThe")]
        public string DetailAddress { get; set; }
        [Column("MaDoanhNghiep")]
        public int EnterpriseId { get; set; }
        [ForeignKey("EnterpriseId")]
        public virtual Enterprise Enterprise { get; set; }
    }
}
