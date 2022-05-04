namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONG_NHAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONG_NHAN()
        {
            CONG_NHAN_KHOAN = new HashSet<CONG_NHAN_KHOAN>();
        }

        [Key]
        public int MaCN { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string PhongBan { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONG_NHAN_KHOAN> CONG_NHAN_KHOAN { get; set; }
    }
}
