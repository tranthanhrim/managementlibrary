namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MUONSACH")]
    public partial class MUONSACH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string madocgia { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string macuonsach { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ngaygiomuon { get; set; }

        public DateTime? ngayhethan { get; set; }

        public DateTime? ngaygiotra { get; set; }

        public virtual CUONSACH CUONSACH { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }
    }
}
