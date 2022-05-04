using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class CNKDTO
    {
        public int MaNhom { get; set; }
        public string HoTen { get; set; }
        public TimeSpan ThoiGianBatDau { get; set; }

        public TimeSpan ThoiGianKetThuc { get; set; }
    }
}