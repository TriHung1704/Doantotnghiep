using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Repositories.Entities
{
    [Table("NganhBaiDang")]
    public class PostMajors : BaseEntity
    {
        [Column("MaBaiDang")]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Column("MaNganh")]
        public int MajorsId { get; set; }
        [ForeignKey("MajorsId")]
        public virtual Majors Majors { get; set; }
    }
}
