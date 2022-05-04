using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class Congnhan_CTDAO
    {
        Model1 db;
        public Congnhan_CTDAO()
        {
            db = new Model1();
        }
        public IQueryable<CONG_NHAN> Products
        {
            get { return db.CONG_NHAN; }
        }
        public CONG_NHAN FindProductByID(int id)
        {
            return db.CONG_NHAN.Find(id);
        }
        public IEnumerable<SAN_PHAM> SearchCN(string ProName)
        {
            var lst = db.Database.SqlQuery<SAN_PHAM>("lstSearchName " +
                "N'" + ProName + "'");
            return lst;
        }
    }
}