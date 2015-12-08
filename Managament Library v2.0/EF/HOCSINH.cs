namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCSINH")]
    public partial class HOCSINH
    {
        [Key]
        [StringLength(10)]
        public string madocgia { get; set; }

        [StringLength(10)]
        public string lop { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }
    }
}
