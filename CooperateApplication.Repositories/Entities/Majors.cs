using System.ComponentModel.DataAnnotations.Schema;
namespace CooperateApplication.Repositories.Entities
{
    /// <summary>
    /// Ngành học
    /// </summary>
    [Table("Nganh")]
    public class Majors : BaseEntity
    {
        [Column("TenNganh")]
        public string Name { get; set; }
        [Column("MaKhoa")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }   
    }
}
