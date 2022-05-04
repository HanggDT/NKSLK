using NKSLK.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Models.DAO
{
    public class CongviecDAO : Controller
    {
        // GET: CongviecDAO
        Model1 db;
        public CongviecDAO()
        {
            db = new Model1();
        }
        public IQueryable<CONG_VIEC> Work
        {
            get { return db.CONG_VIEC; }
        }
        public IQueryable<CONG_VIEC> ListCongviec()
        {
            var res = (from s in db.CONG_VIEC select s);
            return res;
        }
        /* public IEnumerable<CONG_VIEC> lstjoin1(int pageNum, int pageSize)
         {
             var lst = db.Database.SqlQuery<CONG_VIEC>("SELECT * from CONG_VIEC "
                 ).ToPagedList<CONG_VIEC>(pageNum, pageSize);
             return lst;
         }*/


        public IEnumerable<CONG_VIEC> lstjoin1(int pageNum, int pagesize)
        {
            return db.CONG_VIEC.OrderByDescending(x => x.MaCV).ToPagedList(pageNum, pagesize);
        }

        public CONG_VIEC FindProductByID(int id)
        {
            return db.CONG_VIEC.Find(id);
        }
        public void Create(CONG_VIEC cv)
        {
            db.CONG_VIEC.Add(cv);
            db.SaveChanges();
        }

        public void Edit(CONG_VIEC cv)
        {
            CONG_VIEC congviec = FindProductByID(cv.MaCV);
            if (congviec != null)
            {
                congviec.TenCV = cv.TenCV;
                congviec.DinhMucKhoan = cv.DinhMucKhoan;
                congviec.DonViKhoan = cv.DonViKhoan;
                congviec.HeSoKhoan = cv.HeSoKhoan;
                congviec.DinhMucLaoDong = cv.DinhMucLaoDong;
                congviec.DonGia = cv.DonGia;
                db.SaveChanges();
            }


        }
        public void Delete(int id)
        {
            CONG_VIEC cv = db.CONG_VIEC.Find(id);
            if (cv != null)
            {
                db.CONG_VIEC.Remove(cv);
                db.SaveChanges();
            }
        }

        internal object Entry(object pro)
        {
            throw new NotImplementedException();
        }

        // tim kiem
        public IEnumerable<CONG_VIEC> lstjoin(int pageNum, int pagesize, string key = "", double min = 0, double max = 999999999999999999, double price = 0)
        {

            if (price == 0)
            {
                var lst = db.CONG_VIEC.Where(item => item.TenCV.Contains(key)
               && item.DonGia >= min && item.DonGia <= max).OrderByDescending(item => item.DonGia).ToPagedList(pageNum, pagesize);
                return lst;
            }
            else if (price == Convert.ToDouble(db.CONG_VIEC.Where(item => item.DonGia > 0).Max(item => item.DonGia)))
            {
                var maxprice = db.CONG_VIEC.Where(item => item.DonGia == price).OrderByDescending(item => item.DonGia).ToPagedList(pageNum, pagesize);
                return maxprice;
            }
            else if (price == Convert.ToDouble(db.CONG_VIEC.Where(item => item.DonGia > 0).Min(item => item.DonGia)))
            {

                var minprice = db.CONG_VIEC.Where(item => item.DonGia == price).OrderByDescending(item => item.DonGia).ToPagedList(pageNum, pagesize);
                return minprice;
            }
            else if (price == Convert.ToDouble(db.CONG_VIEC.Where(item => item.DonGia > 0).Average(item => item.DonGia)))
            {

                var bigavg = db.CONG_VIEC.Where(item => item.DonGia > price).OrderByDescending(item => item.DonGia).ToPagedList(pageNum, pagesize);
                return bigavg;
            }
            else
            {
                var avg = db.CONG_VIEC.Where(item => item.DonGia > 0).Average(item => item.DonGia);
                var smallavg = db.CONG_VIEC.Where(item => item.DonGia < avg).OrderByDescending(item => item.DonGia).ToPagedList(pageNum, pagesize);
                return smallavg;
            }
        }
    }
}