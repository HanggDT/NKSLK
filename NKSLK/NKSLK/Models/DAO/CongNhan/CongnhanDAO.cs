using NKSLK.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Models.DAO
{
    public class CongnhanDAO : Controller
    {
        // GET: CongnhanDAO
        Model1 db;
        public CongnhanDAO()
        {
            db = new Model1();
        }
        public IQueryable<CONG_NHAN> ListCongnhan()
        {
            var res = (from s in db.CONG_NHAN select s);
            return res;
        }
        public IEnumerable<CONG_NHAN> lstjoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("SELECT * from CONG_NHAN "
                ).ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }

        public CONG_NHAN FindWorkerByID(int id)
        {
            return db.CONG_NHAN.Find(id);
        }
        public void Create(CONG_NHAN cn)
        {
            db.CONG_NHAN.Add(cn);
            db.SaveChanges();
        }

        public void Edit(CONG_NHAN cn)
        {
            CONG_NHAN congnhan = FindWorkerByID(cn.MaCN);
            if (congnhan != null)
            {
                congnhan.HoTen = cn.HoTen;
                congnhan.NgaySinh = cn.NgaySinh;
                congnhan.GioiTinh = cn.GioiTinh;
                congnhan.PhongBan = cn.PhongBan;
                congnhan.ChucVu = cn.ChucVu;
                congnhan.QueQuan = cn.QueQuan;
                db.SaveChanges();
            }


        }
        public void Delete(int id)
        {
            CONG_NHAN cn = db.CONG_NHAN.Find(id);
            if (cn != null)
            {
                db.CONG_NHAN.Remove(cn);
                db.SaveChanges();
            }
        }

        public IEnumerable<CONG_NHAN> lstSearchName(string ProName, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("lstSearchNameCN " +
                "N'" + ProName + "'").ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CONG_NHAN> lstSearchByPB(string PB, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("PhongBan " +
                "N'" + PB + "'").ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CONG_NHAN> lstSearchByCV(string CV, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("ChucVu " +
                "N'" + CV + "'").ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CONG_NHAN> lstSearchByPBCV(string PB, string CV, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("PB_CV " +
                "N'" + PB + " '," + "N'" + CV + "'").ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CONG_NHAN> lstKhoang(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("khoangtuoi").ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CONG_NHAN> lstVeHuu(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("tuoivehuu").ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CONG_NHAN> lstCa(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<CONG_NHAN>("Caba").ToPagedList<CONG_NHAN>(pageNum, pageSize);
            return lst;
        }
    }
}