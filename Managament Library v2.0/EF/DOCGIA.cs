namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCGIA")]
    public partial class DOCGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCGIA()
        {
            DKCHOMUONs = new HashSet<DKCHOMUON>();
            MUONSACHes = new HashSet<MUONSACH>();
        }

        [Key]
        [StringLength(10)]
        public string madocgia { get; set; }

        [StringLength(40)]
        public string hoten { get; set; }

        [StringLength(5)]
        public string gioitinh { get; set; }

        public DateTime? ngaysinh { get; set; }

        public DateTime? ngaylap { get; set; }

        public bool? tinhtrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKCHOMUON> DKCHOMUONs { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUONSACH> MUONSACHes { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual VIPHAM VIPHAM { get; set; }
    }
}
