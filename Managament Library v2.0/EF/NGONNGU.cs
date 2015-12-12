namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGONNGU")]
    public partial class NGONNGU
    {
        [Key]
        [Column("ngonngu")]
        [StringLength(20)]
        public string ngonngu1 { get; set; }
    }
}
