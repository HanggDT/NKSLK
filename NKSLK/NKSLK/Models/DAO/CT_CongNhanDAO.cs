using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class CT_CongNhanDAO
    {
        Model1 db;
        public CT_CongNhanDAO()
        {
            db = new Model1();
        }
        public CT_CongNhan CT_Congnhan(int maCN)
        {
            CT_CongNhan lst = db.Database.SqlQuery<CT_CongNhan>("CT_CN " + maCN).FirstOrDefault();
            return lst;
        }

    }
}