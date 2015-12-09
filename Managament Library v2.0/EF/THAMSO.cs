namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THAMSO")]
    public partial class THAMSO
    {
        [Key]
        [StringLength(20)]
        public string tenthamso { get; set; }

        [StringLength(10)]
        public string kieu { get; set; }

        [StringLength(100)]
        public string giatri { get; set; }

        public bool? tinhtrang { get; set; }
    }
}
