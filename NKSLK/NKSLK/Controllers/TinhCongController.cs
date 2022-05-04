using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class TinhCongController : Controller
    {
        // GET: TinhCong
        public ActionResult Index(string Month, string Year, int pageNum = 1, int pageSize = 10)
        {
            ViewBag.Month = Month;
            ViewBag.Year = Year;
            TinhCongDAO dao = new TinhCongDAO();
            if (!string.IsNullOrEmpty(Month) && !string.IsNullOrEmpty(Year))
            {
                return View(dao.lstjoin(Convert.ToInt32(Month), Convert.ToInt32(Year), pageNum, pageSize));
            }
            return View(dao.lsta(pageNum, pageSize));

        }
        public ActionResult Ct_congnhan(int macn)
        {
            CT_CongNhanDAO dao = new CT_CongNhanDAO();
            CT_CongNhan cn = dao.CT_Congnhan(macn);
            return View(cn);
        }
        public ActionResult cn_thk(int macn)
        {
            CnthkDAO dao = new CnthkDAO();
            return View(dao.cn_THK(macn));
        }
        public ActionResult Chitiet(int macn)
        {
            ViewBag.macn = macn;
            return View();
        }
    }
}