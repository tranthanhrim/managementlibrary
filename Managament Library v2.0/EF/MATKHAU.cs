namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATKHAU")]
    public partial class MATKHAU
    {
        [Key]
        [Column("matkhau")]
        [StringLength(20)]
        public string matkhau1 { get; set; }

        public bool? candangnhap { get; set; }
    }
}
