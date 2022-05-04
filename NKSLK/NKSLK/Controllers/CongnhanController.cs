using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class CongnhanController : Controller
    {
        // GET: Congnhan
        
        public ActionResult Index(string TK, string PB, string CV, string tuoi,string ca, int pageNum = 1, int pageSize = 10)
        {
            ViewBag.TK = TK;
            CongnhanDAO dao = new CongnhanDAO();
            PB_DAO d = new PB_DAO();
            ViewBag.PB = d.pB_DTOs();

            CV_DAO da = new CV_DAO();
            ViewBag.CV = da.cV_DAOs();

            GT_DAO dd = new GT_DAO();
            ViewBag.GT = dd.gT_DAOs();
            ViewBag.Tuoi = tuoi;
            ViewBag.PBSelected = PB;
            ViewBag.CVSelected = CV;
            ViewBag.Ca = ca;
            if (!string.IsNullOrEmpty(TK) && string.IsNullOrEmpty(PB) && string.IsNullOrEmpty(CV) && string.IsNullOrEmpty(tuoi) && string.IsNullOrEmpty(ca))
            {
                return View(dao.lstSearchName(TK, pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(TK) && !string.IsNullOrEmpty(PB) && string.IsNullOrEmpty(CV) && string.IsNullOrEmpty(tuoi) && string.IsNullOrEmpty(ca))
            {
                return View(dao.lstSearchByPB(PB, pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(TK) && string.IsNullOrEmpty(PB) && !string.IsNullOrEmpty(CV) && string.IsNullOrEmpty(tuoi) && string.IsNullOrEmpty(ca))
            {
                return View(dao.lstSearchByCV(CV, pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(TK) && !string.IsNullOrEmpty(PB) && !string.IsNullOrEmpty(CV) && string.IsNullOrEmpty(tuoi) && string.IsNullOrEmpty(ca))
            {
                return View(dao.lstSearchByPBCV(PB, CV, pageNum, pageSize));
            }
            
            if(tuoi== "1")
            {
                return View(dao.lstKhoang( pageNum, pageSize));
            }
            else if(tuoi== "2")
            {
                return View(dao.lstVeHuu( pageNum, pageSize));
            }
            else if (ca == "1")
            {
                return View(dao.lstCa(pageNum, pageSize));
            }
            return View(dao.lstjoin(pageNum, pageSize));
        }

        public ActionResult Create()
        {
            CongnhanDAO dao = new CongnhanDAO();
            ViewBag.cat = dao.ListCongnhan();
            PB_DAO d = new PB_DAO();
            ViewBag.PB = d.pB_DTOs();

            CV_DAO da = new CV_DAO();
            ViewBag.CV = da.cV_DAOs();

            GT_DAO dd = new GT_DAO();
            ViewBag.GT = dd.gT_DAOs();
            return View();
        }
        [HttpPost]
        public ActionResult Create(CONG_NHAN cn)
        {
            CONG_NHAN congnhan = new CONG_NHAN();
            congnhan.HoTen = cn.HoTen;
            congnhan.NgaySinh = cn.NgaySinh;
            congnhan.GioiTinh = cn.GioiTinh;
            congnhan.PhongBan = cn.PhongBan;
            congnhan.ChucVu = cn.ChucVu;
            congnhan.QueQuan = cn.QueQuan;
            // them cong nhan vao db
            if (ModelState.IsValid)
            {
                CongnhanDAO dao = new CongnhanDAO();
                dao.Create(congnhan);
                return RedirectToAction("Index");
            }
            else
            {
                return View(congnhan);
            }
        }
        public ActionResult Edit(int id)
        {
            List<CONG_NHAN> ls = new List<CONG_NHAN>();
            CongnhanDAO dao = new CongnhanDAO();
            CONG_NHAN cn = dao.FindWorkerByID(id);
            
            PB_DAO d = new PB_DAO();
            ViewBag.PB = d.pB_DTOs();

            CV_DAO da = new CV_DAO();
            ViewBag.CV = da.cV_DAOs();

            GT_DAO dd = new GT_DAO();
            ViewBag.GT = dd.gT_DAOs();
            return View(cn);
        }

        [HttpPost]
        public ActionResult Edit(CONG_NHAN cn, int id)
        {
            CongnhanDAO dao = new CongnhanDAO();
            CONG_NHAN congnhan = dao.FindWorkerByID(id);
            congnhan.HoTen = cn.HoTen;
            congnhan.NgaySinh = cn.NgaySinh;
            congnhan.GioiTinh = cn.GioiTinh;
            congnhan.PhongBan = cn.PhongBan;
            congnhan.ChucVu = cn.ChucVu;
            congnhan.QueQuan = cn.QueQuan;
            if (ModelState.IsValid)
            {
                CongnhanDAO d = new CongnhanDAO();
                d.Edit(congnhan);
                return RedirectToAction("Index");
            }
            else
            {
                return View(congnhan);
            }
        }

        // delete

        [HttpPost]
        public string Delete(int id)
        {
            CongnhanDAO dao = new CongnhanDAO();
            CONG_NHAN cn = dao.FindWorkerByID(id);
            if (cn != null)
            {
                dao.Delete(id);
            }
            return "OK";
        }
        //public ActionResult Details(int id)
        //{

        //    CongnhanDAO dao = new CongnhanDAO();
        //    CONG_NHAN cn = dao.FindWorkerByID(id);
        //    return View(cn);
        //}
    }
}