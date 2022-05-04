using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class Cong_cn
    {
        public DateTime NgayThucHienKhoan { get; set; }
        public TimeSpan? ThoiGianBatDau { get; set; }

        public TimeSpan? ThoiGianKetThuc { get; set; }
    }
}