using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO.NhatKy
{
    public class DauMucDAO
    {
        Model1 db = new Model1();

        public DauMucDTO daumuc(int mank)
        {
            DauMucDTO lst = db.Database.SqlQuery<DauMucDTO>("daumuc " + mank).FirstOrDefault();
            return lst;
        }
    }
}