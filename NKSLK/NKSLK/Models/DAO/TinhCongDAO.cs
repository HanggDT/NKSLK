using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class TinhCongDAO
    {
        Model1 db;
        public TinhCongDAO()
        {
            db = new Model1();
        }

        public IEnumerable<TinhCongDTO> lstjoin(int Month,int Year, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<TinhCongDTO>("CongNT " +
                Month+"," +Year).ToPagedList<TinhCongDTO>(pageNum, pageSize); 
            return lst;
        }
        public IEnumerable<TinhCongDTO> lsta(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<TinhCongDTO>("Cong_TatCaCN1").ToPagedList<TinhCongDTO>(pageNum, pageSize);
            return lst;
        }
        //public IEnumerable<TinhCongDTO> lstjoin(string thang)
        //{
        //    var lst = db.Database.SqlQuery<TinhCongDTO>("ListCong");
        //    return lst;
        //}
    }
}