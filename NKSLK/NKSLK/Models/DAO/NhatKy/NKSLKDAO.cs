using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Models.DAO
{
    public class NKSLKDAO : Controller
    {
        // GET: NKSLKDAO
        Model1 db;
        public NKSLKDAO()
        {
            db = new Model1();
        }
        
        public IQueryable<NKSLKs> ListNKSLK()
        {
            var res = (from s in db.NKSLKs select s);
            return res;
        }
        public IEnumerable<NKSLKs> lstjoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<NKSLKs>("Select * from NKSLKs"
                ).ToPagedList<NKSLKs>(pageNum, pageSize);
            return lst;
        }

        public NKSLKs FindNKSLKByID(int id)
        {
            return db.NKSLKs.Find(id);
        }
        
        public void Create(NKSLKs nk)
        {
            db.NKSLKs.Add(nk);
            db.SaveChanges();
        }

        public void Edit(NKSLKs nk)
        {
            NKSLKs nKSLK = FindNKSLKByID(nk.MaNK);
            if (nKSLK != null)
            {
                nKSLK.NgayThucHienKhoan = nk.NgayThucHienKhoan;
                nKSLK.GioBatDau = nk.GioBatDau;
                nKSLK.GioKetThuc = nk.GioKetThuc;
                nKSLK.NhomThucHienKhoan = nk.NhomThucHienKhoan;
                nKSLK.CongViec = nk.CongViec;
                db.SaveChanges();
            }


        }
        public void Delete(int id)
        {
            NKSLKs nk = db.NKSLKs.Find(id);
            if (nk != null)
            {
                db.NKSLKs.Remove(nk);
                db.SaveChanges();
            }
        }

        
        public IEnumerable<NKSLKs> lstSearchByThang(string Thang, int Macn, int pageNum, int pageSize)
        {
            var lst1 = db.Database.SqlQuery<NKSLKs>("Thang_CN" + "'" + Thang + " '," + Macn
                ).ToPagedList<NKSLKs>(pageNum, pageSize);
            return lst1;
        }
        public IEnumerable<NKSLKs> lstSearchByTuan(string Tuan, int Macn, int pageNum, int pageSize)
        {
            var lst2 = db.Database.SqlQuery<NKSLKs>("Tuan_CN" + "'" + Tuan + " '," + Macn
                ).ToPagedList<NKSLKs>(pageNum, pageSize);
            return lst2;
        }
        public IEnumerable<NKSLKs> lstSearchAllByThang(string Thang,  int pageNum, int pageSize)
        {
            var lst3 = db.Database.SqlQuery<NKSLKs>("Thang" + "'" + Thang + "'" 
                ).ToPagedList<NKSLKs>(pageNum, pageSize);
            return lst3;
        }
        public IEnumerable<NKSLKs> lstSearchAllByTuan(string Tuan, int pageNum, int pageSize)
        {
            var lst4 = db.Database.SqlQuery<NKSLKs>("Tuan" + "'" + Tuan + "'" 
                ).ToPagedList<NKSLKs>(pageNum, pageSize);
            return lst4;
        }

    }
}