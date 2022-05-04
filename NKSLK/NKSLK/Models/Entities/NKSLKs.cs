namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NKSLKs
    {
        [Key]
        public int MaNK { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayThucHienKhoan { get; set; }

        public TimeSpan? GioBatDau { get; set; }

        public TimeSpan? GioKetThuc { get; set; }

        public int? NhomThucHienKhoan { get; set; }

        public int? CongViec { get; set; }

        public virtual DAU_MUC_CV DAU_MUC_CV { get; set; }

        public virtual NHOM_THUC_HIEN_KHOAN NHOM_THUC_HIEN_KHOAN { get; set; }
    }
}
