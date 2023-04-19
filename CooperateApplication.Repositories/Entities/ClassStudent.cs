using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("Lop")]
    public class ClassStudent : BaseEntity
    {
        [Column("TenLop")]
        public string Name { get; set; }
        [Column("MaNganh")]
        public int MajorsId { get; set; }
        [ForeignKey("MajorsId")]
        public virtual Majors Majors { get; set; }
    }
}
