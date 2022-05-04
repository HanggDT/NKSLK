using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class PB_DAO
    {
        Model1 db;
        public PB_DAO()
        {
            db = new Model1();
        }
        
        public IEnumerable<PB_DTO> pB_DTOs()
        {
            var lst = db.Database.SqlQuery<PB_DTO>("lstPB");
            return lst;
        }
    }
}