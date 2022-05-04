namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONG_VIEC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONG_VIEC()
        {
            DAU_MUC_CV = new HashSet<DAU_MUC_CV>();
        }

        [Key]
        public int MaCV { get; set; }

        [StringLength(50)]
        public string TenCV { get; set; }

        public int? DinhMucKhoan { get; set; }

        [StringLength(50)]
        public string DonViKhoan { get; set; }

        public int? HeSoKhoan { get; set; }

        public int? DinhMucLaoDong { get; set; }

        public double DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAU_MUC_CV> DAU_MUC_CV { get; set; }
    }
}
