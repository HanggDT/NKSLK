using NKSLK.Models.DAO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class LuongController : Controller
    {
        // GET: Luong
        public ActionResult Index(int pageNum = 1, int pageSize = 5, string date = "", string value = "")
        {
            ViewBag.date = date;
            LuongDAO dao = new LuongDAO();
            double _value;
            if (!double.TryParse(value, out _value))
            {
                _value = 0;
            }
            Session["value"] = _value;
            return View(dao.luong(pageNum, pageSize, date, _value));
        }

    }
}