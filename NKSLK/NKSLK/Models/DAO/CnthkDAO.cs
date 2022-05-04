using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class CnthkDAO
    {
        Model1 db;
        public CnthkDAO()
        {
            db = new Model1();
        }
        public IEnumerable<Cong_cn> cn_THK(int maCN)
        {
            var lst = db.Database.SqlQuery<Cong_cn>("CONG_CN " + maCN);
            return lst;
        }
    }
}
