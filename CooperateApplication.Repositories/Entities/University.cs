using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("Truong")]
    public class University : BaseEntity
    {
        [Column("TenTruong")]
        public string Name { get; set; }
        [Column("GioiThieu")]
        public string Introduction { get; set; }
        [Column("DiaChi")]
        public string Address { get; set; }
    }
}
