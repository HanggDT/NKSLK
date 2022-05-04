using NKSLK.Models.DAO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        public ActionResult Index(string KW = "", string HSD = "", string NDK = "", int pageNum = 1, int pageSize = 8)
        {
            ViewBag.HienThi = "0";
            if (KW!=""|| HSD != "" || NDK != "")
            {
                ViewBag.HienThi = "1";
            }
            ViewBag.KW = KW;
            ViewBag.HSD = HSD;
            ViewBag.NDK = NDK;
            SanphamDAO dao = new SanphamDAO();
            if (!string.IsNullOrEmpty(KW) && string.IsNullOrEmpty(HSD) && string.IsNullOrEmpty(NDK))
            {
                return View(dao.lstSearchName(KW,pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(KW) && !string.IsNullOrEmpty(HSD) && string.IsNullOrEmpty(NDK))
            {
                return View(dao.lstSearchByHSD((Convert.ToInt32(HSD)), pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(KW) && string.IsNullOrEmpty(HSD) && !string.IsNullOrEmpty(NDK))
            {
                return View(dao.lstSearchByNDK(NDK, pageNum, pageSize));
            }
            return View(dao.lstjoin(pageNum, pageSize));
        }
        // create
        [Authorize(Roles ="ADMIN")]
        public ActionResult Create()
        {
            SanphamDAO dao = new SanphamDAO();
            QCDAO d = new QCDAO();
            ViewBag.cat = d.ListQC();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Create(SAN_PHAM sp, HttpPostedFileBase photo)
        {
            var img = Path.GetFileName(photo.FileName);
            SAN_PHAM sanpham = new SAN_PHAM();
            sanpham.TenSP = sp.TenSP;
            sanpham.SoDangKi = sp.SoDangKi;
            sanpham.HanSuDung = sp.HanSuDung;
            sanpham.NgayDangKi = sp.NgayDangKi;
            sanpham.QuyCach = sp.QuyCach;
            // them san pham vao db
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    sanpham.HinhAnh = photo.FileName;
                    SanphamDAO dao = new SanphamDAO();
                    dao.Create(sanpham);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(sanpham);
            }
        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int id)
            {
                List<SAN_PHAM> ls = new List<SAN_PHAM>();
                SanphamDAO dao = new SanphamDAO();
                QCDAO d = new QCDAO();
                ViewBag.cat = d.ListQC();
                SAN_PHAM sp = dao.FindProductByID(id);
                ViewBag.id = id;
                ViewBag.NgayDangKy = "";
                if (sp.NgayDangKi!=null)
                {
                    var lstDate = sp.NgayDangKi.ToString().Split(' ');
                    var strDate = lstDate[0];
                    String dt = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); ;
                    ViewBag.NgayDangKy = dt;
                }

            ViewBag.HanSuDung = "";
            if (sp.HanSuDung != null)
            {
                var lstDate = sp.HanSuDung.ToString().Split(' ');
                var strDate = lstDate[0];
                String dt = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); ;
                ViewBag.HanSuDung = dt;
            }    

                return View(sp);
            }

            [HttpPost]
   
        public ActionResult Edit(SAN_PHAM sp, int id, HttpPostedFileBase photo)
            {
                SanphamDAO dao = new SanphamDAO();
                SAN_PHAM sanpham = dao.FindProductByID(id);
                sanpham.TenSP = sp.TenSP;
                sanpham.SoDangKi = sp.SoDangKi;
                sanpham.HanSuDung = sp.HanSuDung;
                sanpham.NgayDangKi = (sp.NgayDangKi);
                sanpham.QuyCach = sp.QuyCach;
                if (ModelState.IsValid)
                {
                    if (photo != null && photo.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/images/"),
                                                System.IO.Path.GetFileName(photo.FileName));
                        photo.SaveAs(path);

                        sanpham.HinhAnh = photo.FileName;

                    }
                SanphamDAO d = new SanphamDAO();
                    d.Edit(sanpham);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(sanpham);
                }
            }

            // delete
            [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public string Delete(int id)
            {
                SanphamDAO dao = new SanphamDAO();
                SAN_PHAM sp = new SAN_PHAM();
                sp = dao.FindProductByID(id);
                if(sp!=null)
                {
                    dao.Delete(id);
                }
                return "OK";
            }
            public ActionResult Details(int id)
            {

                SanphamDAO dao = new SanphamDAO();
                SAN_PHAM sp = dao.FindProductByID(id);

                return View(sp);
            }
        }
    }
