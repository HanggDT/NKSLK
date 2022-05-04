using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class CongViecDTO
    {
        public int MaCV { get; set; }
        public string TenCV { get; set; }

        public int? DinhMucKhoan { get; set; }

        public string DonViKhoan { get; set; }

        public int? HeSoKhoan { get; set; }

        public int? DinhMucLaoDong { get; set; }

        public float DonGia { get; set; }
    }
}