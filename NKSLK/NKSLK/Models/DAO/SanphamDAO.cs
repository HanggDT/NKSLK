using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Data.Entity;

namespace NKSLK.Models.DAO
{
    public class SanphamDAO
    {
        Model1 db;
        public SanphamDAO()
        {
            db = new Model1();
        }
        public IQueryable<SAN_PHAM> Products
        {
            get { return db.SAN_PHAM; }
        }
        public IQueryable<SAN_PHAM> ListSanpham()
        {
            var res = (from s in db.SAN_PHAM select s);
            return res;
        }
        public IEnumerable<SAN_PHAM> lstjoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<SAN_PHAM>("SELECT * from SAN_PHAM ")
                .ToPagedList<SAN_PHAM>(pageNum, pageSize);
            return lst;
        }
        public SAN_PHAM FindProductByID(int id)
        {
            return db.SAN_PHAM.Find(id);
        }
        public void Create(SAN_PHAM sp)
        {
            db.SAN_PHAM.Add(sp);
            db.SaveChanges();
        }

        public void Edit(SAN_PHAM sp)
        {
            SAN_PHAM sanpham = FindProductByID(sp.MaSP);
            if (sanpham != null)
            {
                sanpham.TenSP = sp.TenSP;
                sanpham.SoDangKi = sp.SoDangKi;
                sanpham.HanSuDung = sp.HanSuDung;
                sanpham.NgayDangKi = sp.NgayDangKi;
                sanpham.QuyCach = sp.QuyCach;
                sanpham.HinhAnh = sp.HinhAnh;
                db.SaveChanges();
            }


        }
        public void Delete(int id)
        {
            SAN_PHAM pro = db.SAN_PHAM.Find(id);
            if (pro != null)
            {
                db.SAN_PHAM.Remove(pro);
                db.SaveChanges();
            }
        }
        public IEnumerable<SAN_PHAM> lstSearchName(string ProName, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<SAN_PHAM>("lstSearchName " +
                "N'" + ProName + "'").ToPagedList<SAN_PHAM>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<SAN_PHAM> lstSearchByHSD(int HSD, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<SAN_PHAM>("lstSearchByHSD " + HSD
                ).ToPagedList<SAN_PHAM>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<SAN_PHAM> lstSearchByNDK( string NDK, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<SAN_PHAM>("lstSearchByNDK " + "'" +NDK+"'"
                ).ToPagedList<SAN_PHAM>(pageNum, pageSize);
            return lst;
        }


    }
}