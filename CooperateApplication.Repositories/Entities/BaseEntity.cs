using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Repositories.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        [Column("NgayTao")]
        public DateTime CreateAt { get; set; }
        [Column("NgayChinhSua")]
        public DateTime? UpdateAt { get; set; }
        [Column("TrangThai")]
        public bool Status { get; set; }
    }
}
