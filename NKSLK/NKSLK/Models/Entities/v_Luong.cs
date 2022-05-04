namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_Luong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCN { get; set; }

        public double? Luong { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NgayThucHienKhoan { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }
    }
}
