using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO.NhatKy
{
    public class CNKDAO
    {
        Model1 db = new Model1();

        public CNKDTO Congnhankhoan(int mank)
        {
            CNKDTO lst = db.Database.SqlQuery<CNKDTO>("cnk " + mank).FirstOrDefault();
            return lst;
        }
    }
}