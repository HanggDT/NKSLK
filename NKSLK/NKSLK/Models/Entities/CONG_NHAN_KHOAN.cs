namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONG_NHAN_KHOAN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhom { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

        public virtual CONG_NHAN CONG_NHAN { get; set; }

        public virtual NHOM_THUC_HIEN_KHOAN NHOM_THUC_HIEN_KHOAN { get; set; }
    }
}
