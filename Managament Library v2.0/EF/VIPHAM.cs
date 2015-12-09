namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIPHAM")]
    public partial class VIPHAM
    {
        [Key]
        [StringLength(10)]
        public string madocgia { get; set; }

        [Column("vipham")]
        public int? vipham1 { get; set; }

        public DateTime? ngayhethan { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }
    }
}
