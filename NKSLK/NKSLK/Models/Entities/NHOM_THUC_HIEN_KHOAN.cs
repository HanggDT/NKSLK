namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHOM_THUC_HIEN_KHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHOM_THUC_HIEN_KHOAN()
        {
            CONG_NHAN_KHOAN = new HashSet<CONG_NHAN_KHOAN>();
            NKSLKs = new HashSet<NKSLKs>();
        }

        [Key]
        public int MaNhom { get; set; }

        public int? SLThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONG_NHAN_KHOAN> CONG_NHAN_KHOAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NKSLKs> NKSLKs { get; set; }
    }
}
