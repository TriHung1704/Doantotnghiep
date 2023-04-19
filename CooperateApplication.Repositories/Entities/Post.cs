using System;
using System.ComponentModel.DataAnnotations.Schema;
using static CooperateApplication.Repositories.Enums.CooperateEnums;

namespace CooperateApplication.Repositories.Entities
{
    [Table("BaiDang")]
    public class Post : BaseEntity
    {
        [Column("TieuDe")]
        public string Title { get; set; }
        [Column("MoTa")]
        public string Description { get; set; }
        [Column("SoLuong")]
        public int Quantity { get; set; }
        [Column("HinhAnh")]
        public string Image { get; set; }
        [Column("HanCuoi")]
        public DateTime ExpireTime { get; set; }
        [Column("LoaiBai")]
        public PostTypeName Type { get; set; }
        [Column("MaDoanhNghiep")]
        public int EnterpriseId { get; set; }
        [ForeignKey("EnterpriseId")]
        public virtual Enterprise Enterprise { get; set; }
        [Column("MaNguoiDung")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
