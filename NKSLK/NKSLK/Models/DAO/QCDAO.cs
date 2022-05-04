using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class QCDAO
    {
        Model1 db;
        public QCDAO()
        {
            db = new Model1();
        }

        public IEnumerable<QCDTO> ListQC()
        {
            var lst = db.Database.SqlQuery<QCDTO>("lstQC");
            return lst;
        }
    }
}