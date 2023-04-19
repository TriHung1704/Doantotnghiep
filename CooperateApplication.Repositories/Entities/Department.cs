using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    /// <summary>
    /// Khoa
    /// </summary>
    [Table("Khoa")]
    public class Department : BaseEntity
    {
        [Column("TenKhoa")]
        public string Name { get; set; }
        [Column("MaTruong")]
        public int UniversityId { get; set; }
        [ForeignKey("UniversityId")]
        public virtual University University { get; set; }
    }
}
