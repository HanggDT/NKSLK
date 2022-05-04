using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class GT_DAO
    {
        Model1 db;
        public GT_DAO()
        {
            db = new Model1();
        }
        
        public IEnumerable<GT_DTO> gT_DAOs()
        {
            var lst = db.Database.SqlQuery<GT_DTO>("lstGT");
            return lst;
        }
    }
}