
using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("SinhVien")]
    public class Student : BaseEntity
    {
        public string FileCV { get; set; }
        [Column("MaNguoiDung")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Column("MaLop")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual ClassStudent Class { get; set; }
    }
}
