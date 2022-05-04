namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SAN_PHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SAN_PHAM()
        {
            DAU_MUC_CV = new HashSet<DAU_MUC_CV>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoDangKi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKi { get; set; }

        [StringLength(50)]
        public string QuyCach { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAU_MUC_CV> DAU_MUC_CV { get; set; }
    }
}
