namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUONSACH")]
    public partial class CUONSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUONSACH()
        {
            MUONSACHes = new HashSet<MUONSACH>();
        }

        [Key]
        [StringLength(10)]
        public string macuonsach { get; set; }

        [StringLength(10)]
        public string madausach { get; set; }

        public bool? tinhtrang { get; set; }

        public virtual DAUSACH DAUSACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUONSACH> MUONSACHes { get; set; }
    }
}
