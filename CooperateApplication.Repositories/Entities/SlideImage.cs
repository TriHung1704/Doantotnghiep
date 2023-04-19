using System.ComponentModel.DataAnnotations.Schema;

namespace CooperateApplication.Repositories.Entities
{
    [Table("Banner")]
    public class SlideImage : BaseEntity
    {
        [Column("HinhAnh")]
        public string Image { get; set; }

        [Column("KichHoat")]
        public bool IsEnable { get; set; }
    }
}
