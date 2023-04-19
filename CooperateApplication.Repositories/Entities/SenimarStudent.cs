using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("SinhVienHoiThao")]
    public class SenimarStudent : BaseEntity
    {

        [Column("MaSinhVien")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Column("MaBaiDang")]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
