namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DAUSACH")]
    public partial class DAUSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DAUSACH()
        {
            CUONSACHes = new HashSet<CUONSACH>();
            DKCHOMUONs = new HashSet<DKCHOMUON>();
        }

        [Key]
        [StringLength(10)]
        public string madausach { get; set; }

        [StringLength(10)]
        public string matuasach { get; set; }

        [StringLength(20)]
        public string ngonngu { get; set; }

        public bool? tinhtrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUONSACH> CUONSACHes { get; set; }

        public virtual TUASACH TUASACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKCHOMUON> DKCHOMUONs { get; set; }
    }
}
