namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DAU_MUC_CV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DAU_MUC_CV()
        {
            NKSLKs = new HashSet<NKSLKs>();
        }

        [Key]
        public int MaDMCV { get; set; }

        public int MaCV { get; set; }

        public double? SLThucTe { get; set; }

        public int? SoLoSP { get; set; }

        public int? SPApDung { get; set; }

        public virtual CONG_VIEC CONG_VIEC { get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NKSLKs> NKSLKs { get; set; }
    }
}
