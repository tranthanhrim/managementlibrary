namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DKCHOMUON")]
    public partial class DKCHOMUON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string madocgia { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string madausach { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ngaygiodk { get; set; }

        public virtual DAUSACH DAUSACH { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }
    }
}
