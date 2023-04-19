using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("DoanhNghiep")]
    public class Enterprise : BaseEntity
    {
        [Column("TenDoanhNghiep")]
        public string Name { get; set; }
        [Column("MaSoThue")]
        public string CorporateTaxCode { get; set; }
        [Column("GiamDoc")]
        public string Director { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        [Column("SoDienThoai")]
        public string Phone { get; set; }
        [Column("GioiThieu")]
        public string Description { get; set; }
        [Column("Logo")]
        public string ImageLogo { get; set; }
    }
}
