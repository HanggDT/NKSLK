using NKSLK.Models.DAO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class CongviecController : Controller
    {
        // GET: Congviec
       /* public ActionResult Index(int pageNum = 1, int pageSize = 3)
        {
            CongviecDAO dao = new CongviecDAO();
            //IQueryable<CONG_VIEC> lst = dao.ListCongviec();
            return View(dao.lstjoin1(pageNum, pageSize));
        }*/

        public ActionResult Create()
        {
            CongviecDAO dao = new CongviecDAO();
            ViewBag.cat = dao.ListCongviec();
            return View();
        }
        [HttpPost]
        public ActionResult Create(CONG_VIEC cv)
        {
            CONG_VIEC congviec = new CONG_VIEC();
            congviec.TenCV = cv.TenCV;
            congviec.DinhMucKhoan = cv.DinhMucKhoan;
            congviec.DonViKhoan = cv.DonViKhoan;
            congviec.HeSoKhoan = cv.HeSoKhoan;
            congviec.DinhMucLaoDong = cv.DinhMucLaoDong;
            congviec.DonGia = cv.DonGia;
            // them san pham vao db
            if (ModelState.IsValid)
            {
                CongviecDAO dao = new CongviecDAO();
                dao.Create(congviec);
                return RedirectToAction("Search");
            }
            else
            {
                return View(congviec);
            }
        }
        public ActionResult Edit(int id)
        {
            List<CONG_VIEC> ls = new List<CONG_VIEC>();
            CongviecDAO dao = new CongviecDAO();
            /*   ViewBag.cat = dao.ListSanpham();*/
            CONG_VIEC cv = dao.FindProductByID(id);
            return View(cv);
        }

        [HttpPost]
        public ActionResult Edit(CONG_VIEC cv, int id)
        {
            CongviecDAO dao = new CongviecDAO();
            CONG_VIEC congviec = dao.FindProductByID(id);
            congviec.TenCV = cv.TenCV;
            congviec.DinhMucKhoan = cv.DinhMucKhoan;
            congviec.DonViKhoan = cv.DonViKhoan;
            congviec.HeSoKhoan = cv.HeSoKhoan;
            congviec.DinhMucLaoDong = cv.DinhMucLaoDong;
            congviec.DonGia = cv.DonGia;
            if (ModelState.IsValid)
            {
                CongviecDAO d = new CongviecDAO();
                d.Edit(congviec);
                return RedirectToAction("Search");
            }
            else
            {
                return View(congviec);
            }
        }

        // delete
        [HttpPost]
        public string Delete(int id)
        {
            CongviecDAO dao = new CongviecDAO();
            CONG_VIEC cn = dao.FindProductByID(id);
            if (cn != null)
            {
                dao.Delete(id);
            }
            return "OK";
        }


        // tim kiem

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Search(int pageNum = 1, int pageSize = 4, string searchKey = "", string min = "", string max = "", string price = "")
        {
            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(searchKey))
                {
                    RedirectToAction("Search");
                }
                double _min, _max, _price;
                string _searchKey = String.IsNullOrEmpty(searchKey) ? "" : searchKey;
                if (!double.TryParse(min, out _min))
                {
                    _min = 0;
                }
                if (!double.TryParse(max, out _max))
                {
                    _max = 10000000;
                }
                if (!double.TryParse(price, out _price))
                {
                    _price = 0;
                }
                Session["searchKey"] = _searchKey;
                Session["min"] = _min;
                Session["max"] = _max;
                Session["price"] = _price;
                Model1 dao = new Model1();
                ViewBag.maxprice = Convert.ToDouble(dao.CONG_VIEC.Max(p => p.DonGia));
                ViewBag.minprice = Convert.ToDouble(dao.CONG_VIEC.Min(p => p.DonGia));
                ViewBag.avg = Convert.ToDouble(dao.CONG_VIEC.Average(p => p.DonGia));
                CongviecDAO cvdao = new CongviecDAO();
                return View(cvdao.lstjoin(pageNum, pageSize, _searchKey.Trim(), _min, _max, _price));
            }
            else
                return RedirectToAction("Search");


        }
    }
}