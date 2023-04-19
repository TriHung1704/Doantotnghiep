using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("SinhVienTuyenDung")]
    public class PostStudent : BaseEntity
    {
        [Column("DuyetDangKi")]
        public bool IsAccept { get; set; }

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
