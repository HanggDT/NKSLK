using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Data.Entity;

namespace NKSLK.Models.DAO
{
    public class LuongDAO
    {
        Model1 db;
        public LuongDAO()
        {
            db = new Model1();
        }
        public IQueryable<v_Luong> Luong
        {
            get { return db.v_Luong; }
        }
        public IEnumerable<v_Luong> luong(int pageNum, int pageSize, string date = "", double value = 0)
        {

            if (value == 1 && date != "")
            {
                var lst = db.Database.SqlQuery<v_Luong>("LuongSP_Tuan " + "'" + date + "'").ToPagedList<v_Luong>(pageNum, pageSize);
                return lst;
            }
            else if (value == 2 && date != "")
            {
                var lst = db.Database.SqlQuery<v_Luong>("LuongSP_Thang " + "'" + date + "'").ToPagedList<v_Luong>(pageNum, pageSize);
                return lst;
            }
            else
            {
                var lst1 = db.Database.SqlQuery<v_Luong>("AllLuongSP_Tuan ").ToPagedList<v_Luong>(pageNum, pageSize);
                return lst1;
            }

        }
    }
}
