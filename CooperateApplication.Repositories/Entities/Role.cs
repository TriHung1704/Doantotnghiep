using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("Quyen")]
    public class Role : BaseEntity
    {

        [Column("TenQuyen")]
        public string RoleName { get; set; }
    }
}
