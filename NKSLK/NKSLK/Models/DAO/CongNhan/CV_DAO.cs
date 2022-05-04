using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class CV_DAO
    {
        Model1 db;
        public CV_DAO()
        {
            db = new Model1();
        }
        
        public IEnumerable<CV_DTO> cV_DAOs()
        {
            var lst = db.Database.SqlQuery<CV_DTO>("lstCV");
            return lst;
        }
    }
}