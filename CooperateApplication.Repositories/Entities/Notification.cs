using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("ThongBao")]
    public class Notification : BaseEntity
    {
        [Column("TieuDe")]
        public string Title { get; set; }
        [Column("NoiDung")]
        public string Description { get; set; }
        [Column("HinhAnh")]
        public string Image { get; set; }
        [Column("MaNguoiDung")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
