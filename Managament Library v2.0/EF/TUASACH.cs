namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TUASACH")]
    public partial class TUASACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUASACH()
        {
            DAUSACHes = new HashSet<DAUSACH>();
        }

        [Key]
        [StringLength(10)]
        public string matuasach { get; set; }

        [StringLength(100)]
        public string tentuasach { get; set; }

        [StringLength(40)]
        public string tacgia { get; set; }

        [StringLength(1000)]
        public string gioithieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAUSACH> DAUSACHes { get; set; }
    }
}
